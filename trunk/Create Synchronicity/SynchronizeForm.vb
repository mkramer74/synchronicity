﻿Public Class SynchronizeForm
    Dim Log As LogHandler
    Dim Handler As SettingsHandler
    Dim SyncingList As New Dictionary(Of SideOfSource, List(Of SyncingItem))

    Dim Status_StartTime As Date
    Dim Status_BytesCopied As Integer
    Dim Status_ActionsDone As Integer
    Dim Status_TimeElapsed As TimeSpan
    Dim Status_MillisecondsSpeed As Double
    Dim Status_TotalActionsCount As Integer
    Dim DisplayPreview As Boolean, PreviewFinished As Boolean

    Dim SyncThread As New Threading.Thread(AddressOf Synchronize)
    Dim SecondarySyncThread As New Threading.Thread(AddressOf Do_SecondThirdStep)

    Delegate Sub UpdateListCallBack()
    Delegate Sub TaskDoneCallBack(ByVal Id As Integer)
    Delegate Sub LabelCallBack(ByVal Id As Integer, ByVal Text As String)
    Delegate Sub SetElapsedTimeCallBack(ByVal CurrentTimeSpan As TimeSpan)
    Delegate Sub ProgressSetMaxCallBack(ByVal Id As Integer, ByVal Max As Integer)
    Delegate Sub SetProgessCallBack(ByVal Id As Integer, ByVal Progress As Integer)

#Region " Events "
    Sub New(ByVal ConfigName As String, ByVal ShowPreview As Boolean)
        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        DisplayPreview = ShowPreview
        PreviewFinished = Not ShowPreview

        SyncBtn.Enabled = False
        SyncBtn.Visible = ShowPreview

        Status_BytesCopied = 0
        Status_ActionsDone = 0
        Status_TotalActionsCount = 0
        Status_StartTime = DateTime.Now

        Log = New LogHandler(ConfigName)
        Handler = New SettingsHandler(ConfigName)
        SyncThread.Start()
    End Sub

    Private Sub CancelBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StopBtn.Click
        Select Case StopBtn.Text
            Case StopBtn.Tag.ToString.Split(";"c)(0)
                SyncThread.Abort()
                SecondarySyncThread.Abort()
                TaskDone(1) : TaskDone(2) : TaskDone(3)
            Case StopBtn.Tag.ToString.Split(";"c)(1)
                Close()
        End Select
    End Sub

    Private Sub SyncBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SyncBtn.Click
        PreviewList.Dispose()
        SyncBtn.Visible = False
        StopBtn.Text = StopBtn.Tag.Split(";"c)(0)

        SyncingTimeCounter.Start()
        SecondarySyncThread.Start()
    End Sub

    Private Sub SyncingTimeCounter_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SyncingTimeCounter.Tick
        UpdateStatuses()
    End Sub

    Sub UpdateStatuses()
        Status_TimeElapsed = DateTime.Now - Status_StartTime
        Status_MillisecondsSpeed = Status_BytesCopied / (If(Status_TimeElapsed.TotalMilliseconds = 0, New System.TimeSpan(1), Status_TimeElapsed).TotalMilliseconds / 1000)
        Done.Text = Status_ActionsDone

        Select Case Status_MillisecondsSpeed
            Case Is > 1024 * 1000
                Speed.Text = Math.Round(Status_MillisecondsSpeed / (1024 * 1000), 2).ToString & "MB/s"
            Case Is > 1024
                Speed.Text = Math.Round(Status_MillisecondsSpeed / 1024, 2).ToString & "kB/s"
            Case Else
                Speed.Text = Math.Round(Status_MillisecondsSpeed, 2).ToString & "B/s"
        End Select

        ElapsedTime.Text = If(Status_TimeElapsed.Hours = 0, "", Status_TimeElapsed.Hours.ToString & "h, ") & If(Status_TimeElapsed.Minutes = 0, "", Status_TimeElapsed.Minutes.ToString & "m, ") & Status_TimeElapsed.Seconds.ToString & "s."
    End Sub
#End Region

#Region " Processes interaction "
    Sub UpdateLabel(ByVal Id As Integer, ByVal Text As String)
        Select Case Id
            Case 1
                Step1StatusLabel.Text = Text
            Case 2
                Step2StatusLabel.Text = Text
            Case 3
                Step3StatusLabel.Text = Text
        End Select
    End Sub

    Sub SetProgess(ByVal Id As Integer, ByVal Progress As Integer)
        Select Case Id
            Case 1
                If Step1ProgressBar.Value + Progress < Step1ProgressBar.Maximum Then Step1ProgressBar.Value += Progress
            Case 2
                If Step2ProgressBar.Value + Progress < Step2ProgressBar.Maximum Then Step2ProgressBar.Value += Progress
            Case 3
                If Step3ProgressBar.Value + Progress < Step3ProgressBar.Maximum Then Step3ProgressBar.Value += Progress
        End Select
    End Sub

    Sub SetMaxProgess(ByVal Id As Integer, ByVal MaxValue As Integer)
        Select Case Id
            Case 1
                If MaxValue = -1 Then
                    Step1ProgressBar.Style = ProgressBarStyle.Marquee
                Else
                    Step1ProgressBar.Style = ProgressBarStyle.Blocks
                    Step1ProgressBar.Value = 0
                    Step1ProgressBar.Maximum = MaxValue
                End If
            Case 2
                If MaxValue = -1 Then
                    Step2ProgressBar.Style = ProgressBarStyle.Marquee
                Else
                    Step2ProgressBar.Style = ProgressBarStyle.Blocks
                    Step2ProgressBar.Value = 0
                    Step2ProgressBar.Maximum = MaxValue
                End If
            Case 3
                If MaxValue = -1 Then
                    Step3ProgressBar.Style = ProgressBarStyle.Marquee
                Else
                    Step3ProgressBar.Style = ProgressBarStyle.Blocks
                    Step3ProgressBar.Value = 0
                    Step3ProgressBar.Maximum = MaxValue
                End If
        End Select
    End Sub

    Sub TaskDone(ByVal Id As Integer)
        Select Case Id
            Case 1
                UpdateLabel(1, "Done !")
                Step1ProgressBar.Maximum = 100
                Step1ProgressBar.Value = Step1ProgressBar.Maximum
                Step1ProgressBar.Style = ProgressBarStyle.Blocks
                If Not PreviewFinished Then
                    UpdateList()
                    StopBtn.Text = StopBtn.Tag.ToString.Split(";"c)(1)
                End If
                TotalCount.Text = SyncingList(SideOfSource.Left).Count + SyncingList(SideOfSource.Right).Count
            Case 2
                UpdateLabel(2, "Done !")
                Step2ProgressBar.Maximum = 100
                Step2ProgressBar.Value = Step2ProgressBar.Maximum
                Step2ProgressBar.Style = ProgressBarStyle.Blocks
            Case 3
                UpdateLabel(3, "Done !")
                Step3ProgressBar.Maximum = 100
                Step3ProgressBar.Value = Step3ProgressBar.Maximum
                Step3ProgressBar.Style = ProgressBarStyle.Blocks

                SyncingTimeCounter.Stop()
                UpdateStatuses()
                Log.SaveAndDispose()
                StopBtn.Text = StopBtn.Tag.ToString.Split(";"c)(1)
        End Select
    End Sub

    Sub UpdateList()
        PreviewList.Items.Clear()
        PreviewList.Visible = True
        For Each Item As SyncingItem In SyncingList(SideOfSource.Left)
            AddItem(Item, SideOfSource.Left)
        Next
        For Each Item As SyncingItem In SyncingList(SideOfSource.Right)
            AddItem(Item, SideOfSource.Right)
        Next
        PreviewFinished = True
        SyncBtn.Enabled = True
    End Sub

    Sub AddItem(ByRef Item As SyncingItem, ByVal Side As SideOfSource)
        Dim NewItem As New ListViewItem
        NewItem = PreviewList.Items.Add(Item.Path)

        NewItem.SubItems.Add(Item.FormatType)
        NewItem.SubItems.Add(Item.FormatAction)

        Dim DirectionString As String = ""
        Select Case Side
            Case SideOfSource.Left
                DirectionString = "Left->Right"
            Case SideOfSource.Right
                DirectionString = "Right->Left"
        End Select

        NewItem.SubItems.Add(DirectionString)
    End Sub
#End Region

#Region " Syncing code "
    Sub Synchronize()
        SyncingTimeCounter.Start()
        Do_FirstStep()

        If DisplayPreview Then
            SyncingTimeCounter.Stop()
        Else
            Do_SecondThirdStep()
        End If
    End Sub

    Sub Do_FirstStep()
        Dim Context As New SyncingAction
        Dim TaskDoneDelegate As New TaskDoneCallBack(AddressOf TaskDone)
        Dim Left As String = Handler.GetSetting("From")
        Dim Right As String = Handler.GetSetting("To")

        SyncingList.Clear()
        SyncingList.Add(SideOfSource.Left, New List(Of SyncingItem))
        SyncingList.Add(SideOfSource.Right, New List(Of SyncingItem))

        Context.Source = SideOfSource.Left
        Context.SourcePath = Handler.GetSetting("From")
        Context.DestinationPath = Handler.GetSetting("To")
        Context.Action = TypeOfAction.Create
        Init_Synchronization(Handler.LeftCheckedNodes, Context)

        Context.Source = SideOfSource.Right
        Context.SourcePath = Handler.GetSetting("To")
        Context.DestinationPath = Handler.GetSetting("From")
        Select Case Handler.GetSetting("Method")
            Case "0"
                Context.Action = TypeOfAction.Delete
                Init_Synchronization(Handler.RightCheckedNodes, Context)
            Case "2"
                Context.Action = TypeOfAction.Create
                Init_Synchronization(Handler.RightCheckedNodes, Context)
        End Select
        Me.Invoke(TaskDoneDelegate, 1)
    End Sub

    Sub Do_SecondThirdStep()
        Dim TaskDoneDelegate As New TaskDoneCallBack(AddressOf TaskDone)
        Dim SetProgessDelegate As New SetProgessCallBack(AddressOf SetProgess)
        Dim ProgessSetMaxCallBack As New ProgressSetMaxCallBack(AddressOf SetMaxProgess)
        Dim LabelDelegate As New LabelCallBack(AddressOf UpdateLabel)

        Dim Left As String = Handler.GetSetting("From")
        Dim Right As String = Handler.GetSetting("To")

        Me.Invoke(ProgessSetMaxCallBack, New Object() {2, SyncingList(SideOfSource.Left).Count})
        Do_Task(SyncingList(SideOfSource.Left), Left, Right, 2)
        Me.Invoke(TaskDoneDelegate, 2)

        Me.Invoke(ProgessSetMaxCallBack, New Object() {3, SyncingList(SideOfSource.Right).Count})
        Do_Task(SyncingList(SideOfSource.Right), Right, Left, 3)
        Me.Invoke(TaskDoneDelegate, 3)
    End Sub

    Sub Do_Task(ByRef ListOfActions As List(Of SyncingItem), ByVal Source As String, ByVal Destination As String, ByVal CurrentStep As Integer)
        Dim SetProgessDelegate As New SetProgessCallBack(AddressOf SetProgess)
        Dim LabelDelegate As New LabelCallBack(AddressOf UpdateLabel)

        For Each Entry As SyncingItem In ListOfActions
            Try
                Me.Invoke(LabelDelegate, New Object() {CurrentStep, Destination & Entry.Path})

                Select Case Entry.Type
                    Case TypeOfItem.File
                        Select Case Entry.Action
                            Case TypeOfAction.Create
                                CopyFile(Entry.Path, Source, Destination)
                            Case TypeOfAction.Delete
                                IO.File.SetAttributes(Source & Entry.Path, IO.FileAttributes.Normal)
                                IO.File.Delete(Source & Entry.Path)
                        End Select

                    Case TypeOfItem.Folder
                        Select Case Entry.Action
                            Case TypeOfAction.Create
                                IO.Directory.CreateDirectory(Destination & Entry.Path)
                            Case TypeOfAction.Delete
                                If IO.Directory.GetFiles(Source & Entry.Path).GetLength(0) = 0 Then IO.Directory.Delete(Source & Entry.Path)
                        End Select
                End Select
                Status_ActionsDone += 1
                Log.LogAction(Entry, True)

            Catch ex As Exception
                Log.LogAction(Entry, False)

            Finally
                Me.Invoke(SetProgessDelegate, New Object() {CurrentStep, 1})
            End Try
        Next
    End Sub


    Sub Init_Synchronization(ByRef FoldersList As SortedList(Of String, Boolean), ByVal Context As SyncingAction)
        For Each Folder As String In FoldersList.Keys
            BuildList(Folder, FoldersList(Folder), Context)
        Next
    End Sub

    Sub BuildList(ByVal Folder As String, ByVal Recursive As Boolean, ByVal Context As SyncingAction) ' As Boolean 'Returns whether the directory (or its subdirectories) contains files.
        Dim LabelDelegate As New LabelCallBack(AddressOf UpdateLabel)

        If Not Folder.StartsWith("\") Then Folder = "\" & Folder
        Dim AbsolutePath As String = Context.SourcePath & Folder

        Me.Invoke(LabelDelegate, New Object() {1, AbsolutePath})

        Dim ModifyDirectory As Boolean = Not IO.Directory.Exists(Context.DestinationPath & Folder)
        If ModifyDirectory And Not Context.Action = TypeOfAction.Delete Then SyncingList(Context.Source).Add(New SyncingItem(Folder, TypeOfItem.Folder, Context.Action))

        For Each File As String In IO.Directory.GetFiles(AbsolutePath)
            Dim SourceFile As String = File
            Dim DestinationFile As String = Context.DestinationPath & Folder & "\" & GetFileOrFolderName(File)
            If (Not HasValidExtension(File)) OrElse (IO.File.Exists(DestinationFile)) OrElse (IO.File.GetLastWriteTime(SourceFile) = IO.File.GetLastWriteTime(DestinationFile)) Then Continue For

            SyncingList(Context.Source).Add(New SyncingItem(File.Substring(Context.SourcePath.Length), TypeOfItem.File, Context.Action))
        Next

        If Recursive Then
            For Each SubFolder As String In IO.Directory.GetDirectories(AbsolutePath)
                BuildList(SubFolder.Substring(Context.SourcePath.Length), True, Context)
            Next
        End If

        'LOTS OF TESTING NEEDED...
        If ModifyDirectory AndAlso Handler.GetSetting("ReplicateEmptyDirectories", "False") = "False" Then
            If Context.Action = TypeOfAction.Delete Then
                SyncingList(Context.Source).Add(New SyncingItem(Folder, TypeOfItem.Folder, Context.Action))
            Else
                If SyncingList(Context.Source)(SyncingList(Context.Source).Count - 1).Path = Folder Then SyncingList(Context.Source).RemoveAt(SyncingList(Context.Source).Count - 1)
            End If
        End If
    End Sub

    Function HasValidExtension(ByVal Path As String) As Boolean
        Select Case Handler.GetSetting("Restrictions")
            Case "1"
                Return InArray(GetExtension(Path), Handler.GetSetting("IncludedTypes").Split(";"c))
            Case "2"
                Return Not InArray(GetExtension(Path), Handler.GetSetting("ExcludedTypes").Split(";"c))
        End Select
        Return True
    End Function

    Sub CopyFile(ByVal Path As String, ByVal Source As String, ByVal Dest As String)
        Try
            IO.Directory.CreateDirectory(Dest & Path.Substring(0, Path.LastIndexOf("\") + 1))
            IO.File.Copy(Source & Path, Dest & Path)
            Status_BytesCopied += My.Computer.FileSystem.GetFileInfo(Source & Path).Length
        Catch Ex As Exception
            Log.HandleError(Ex)
        End Try
    End Sub
#End Region

#Region " Functions "
    Function GetFileOrFolderName(ByVal Path As String) As String
        Return Path.Substring(Path.LastIndexOf("\") + 1)
    End Function

    Function GetExtension(ByVal Path As String) As String
        Return Path.Substring(Path.LastIndexOf(".") + 1)
    End Function

    Function InArray(ByVal Str As String, ByRef ListObject As String()) As Boolean
        For Each SubStr As String In ListObject
            If Str = SubStr Then Return True
        Next
        Return False
    End Function
#End Region

End Class