﻿'This file is part of Create Synchronicity.
'
'Create Synchronicity is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version.
'Create Synchronicity is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU General Public License for more details.
'You should have received a copy of the GNU General Public License along with Create Synchronicity.  If not, see <http://www.gnu.org/licenses/>.
'Created by:	Clément Pit--Claudel.
'Web site:		http://synchronicity.sourceforge.net.

Public Class MainForm
    Dim CurView As Integer = 0
    Dim Views() As View = New View() {View.Tile, View.Details, View.LargeIcon}

#Region " Events "
    Sub New()
        ' This call is required by the designer.
        InitializeComponent()
#If CONFIG = "Linux" Then
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.Sizable
#End If

        ' Code (largely inspired) by U.N. Owen
        Dim WindowSettings As New List(Of String)(ProgramConfig.GetProgramSetting(ConfigOptions.MainFormAttributes, String.Empty).Split(","))
        If WindowSettings.Count = 4 AndAlso WindowSettings.TrueForAll(Function(Value As Integer) Value > 0 And Value < 5000) Then
            Try
                Me.Location = New Drawing.Point(WindowSettings(0), WindowSettings(1))
                Me.Size = New Drawing.Point(WindowSettings(2), WindowSettings(3))
                Me.StartPosition = FormStartPosition.Manual
            Catch
                ' If any string->integer conversion fails (due to invalid syntax), then Me.StartPosition will have remained unchanged.
            End Try
        End If

        ReloadNeeded = False

        BuildIcons()
        Me.Icon = ProgramConfig.GetIcon()

        Translation.TranslateControl(Me)
        Translation.TranslateControl(Me.ActionsMenu)
        Translation.TranslateControl(Me.StatusIconMenu)

        'Position the "About" label correctly
        Dim PreviousWidth As Integer = AboutLinkLabel.Width
        AboutLinkLabel.AutoSize = True
        AboutLinkLabel.Location += New Drawing.Point(PreviousWidth - AboutLinkLabel.Width, 0)
    End Sub

    Private Sub MainForm_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dim WindowAttributes As String = String.Format("{0},{1},{2},{3}", Me.Location.X, Me.Location.Y, Me.Size.Width, Me.Size.Height)
        ProgramConfig.SetProgramSetting(ConfigOptions.MainFormAttributes, WindowAttributes)
        ProgramConfig.SetProgramSetting(ConfigOptions.MainView, CurView)
        ProgramConfig.SetProgramSetting(ConfigOptions.FontSize, Actions.Font.Size)
    End Sub

    Private Sub MainForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ReloadConfigs()
        RedoSchedulerRegistration()
        SetView(CInt(ProgramConfig.GetProgramSetting(ConfigOptions.MainView, "0")))
        SetFont(CInt(ProgramConfig.GetProgramSetting(ConfigOptions.FontSize, Actions.Font.Size)))
    End Sub

    Private Sub MainForm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        'Requires PreviewKeys to be set to true to work, otherwise the form won't catch the keypress.
        If e.KeyCode = Keys.F1 Then
            Interaction.StartProcess("http://synchronicity.sourceforge.net/help.html")
        ElseIf e.KeyCode = Keys.F5 Then
            ReloadConfigs()
        ElseIf e.Control Then
            Select Case e.KeyCode
                Case Keys.N
                    Actions.LabelEdit = True
                    Actions.Items(0).BeginEdit()
                Case Keys.O
                    Interaction.StartProcess(ProgramConfig.ConfigRootDir)
                Case Keys.E
                    If e.Alt Then
                        Dim EMEnabled As Boolean = ProgramConfig.GetProgramSetting(ConfigOptions.ExpertMode, "False")
                        ProgramConfig.SetProgramSetting(ConfigOptions.ExpertMode, Not EMEnabled)
                        Interaction.ShowMsg("Expert mode " & If(EMEnabled, "disabled", "enabled") & "!")
                    End If
                Case Keys.L
                    SetView(1)
                Case Keys.Add
                    SetFont(Actions.Font.Size + 1)
                Case (Keys.Subtract)
                    SetFont(Actions.Font.Size - 1)
            End Select
        End If
    End Sub

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
        Application.Exit()
    End Sub

    Private Sub Actions_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Actions.KeyDown
        If Actions.SelectedItems.Count = 0 Then Exit Sub
        If e.KeyCode = Keys.Enter Then
            If Actions.SelectedIndices(0) = 0 Then
                Actions.LabelEdit = True
                Actions.SelectedItems(0).BeginEdit()
            Else
                ActionsMenu.Show(Actions, New Drawing.Point(Actions.SelectedItems(0).Bounds.Location.X, Actions.SelectedItems(0).Bounds.Location.Y + Actions.SelectedItems(0).Bounds.Height))
            End If
        ElseIf e.KeyCode = Keys.F2 And Not Actions.SelectedIndices(0) = 0 Then
            Actions.LabelEdit = True
            Actions.SelectedItems(0).BeginEdit()
        End If
    End Sub

    Private Sub Actions_Click(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Actions.MouseClick
        If Actions.SelectedItems.Count = 0 Then Exit Sub

        If Actions.SelectedIndices(0) = 0 And e.Button = MouseButtons.Left Then
            Actions.LabelEdit = True
            Actions.SelectedItems(0).BeginEdit()
        Else
            ActionsMenu.Show(Actions, e.Location)
        End If
    End Sub

    Private Sub Actions_AfterLabelEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LabelEditEventArgs) Handles Actions.AfterLabelEdit
        Actions.LabelEdit = False
        If e.Label = "" OrElse e.Label.IndexOfAny(IO.Path.GetInvalidFileNameChars) >= 0 Then
            e.CancelEdit = True
            Exit Sub
        End If

        If e.Item = 0 Then
            e.CancelEdit = True
            Dim SettingsForm As New SettingsForm(e.Label, True)
            SettingsForm.ShowDialog()
        Else
            If Not Profiles(Actions.Items(e.Item).Text).RenameProfile(e.Label) Then e.CancelEdit = True
        End If
        ReloadConfigs()
    End Sub

    Private Sub Actions_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Actions.SelectedIndexChanged
        If Actions.SelectedIndices.Count = 0 OrElse Actions.SelectedIndices(0) = 0 Then
            If Actions.SelectedIndices.Count = 0 Then
                Display_Options("", True)
            ElseIf Actions.SelectedIndices(0) = 0 Then
                Display_Options(Translation.Translate("\NEW_PROFILE"), True)
            End If

            ActionsMenu.Close()
            Exit Sub
        End If

        Display_Options(CurrentProfile, False)
    End Sub

    Private Sub AboutLinkLabel_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles AboutLinkLabel.LinkClicked
        Dim About As New AboutForm
        About.ShowDialog()
        If ReloadNeeded Then Me.Close()
    End Sub

    Private Sub ActionsMenu_Opening(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ActionsMenu.Opening
        Dim FileSize As Integer = If(IO.File.Exists(ProgramConfig.GetLogPath(CurrentProfile)), CInt((New System.IO.FileInfo(ProgramConfig.GetLogPath(CurrentProfile))).Length / 1000), 0)
        ClearLogMenuItem.Text = String.Format(ClearLogMenuItem.Tag, FileSize)
    End Sub

    Private Sub PreviewMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PreviewMenuItem.Click
        If Not CheckValidity() Then Exit Sub

        Dim SyncForm As New SynchronizeForm(CurrentProfile, True, False)
        SetVisible(False) : SyncForm.StartSynchronization(True) : SyncForm.ShowDialog() : SetVisible(True)
        SyncForm.Dispose()
    End Sub

    Private Sub SynchronizeMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SynchronizeMenuItem.Click
        If Not CheckValidity() Then Exit Sub

        Dim SyncForm As New SynchronizeForm(CurrentProfile, False, False)
        SetVisible(False) : SyncForm.StartSynchronization(True) : SyncForm.ShowDialog() : SetVisible(True)
        SyncForm.Dispose()
    End Sub

    Private Sub ChangeSettingsMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChangeSettingsMenuItem.Click
        Dim SettingsForm As New SettingsForm(CurrentProfile, False)
        SettingsForm.ShowDialog()
        ReloadConfigs()
    End Sub

    Private Sub DeleteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteToolStripMenuItem.Click
        If Interaction.ShowMsg(String.Format(Translation.Translate("\DELETE_PROFILE"), CurrentProfile), Translation.Translate("\CONFIRM_DELETION"), MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Profiles(CurrentProfile).DeleteConfigFile()
            Profiles(CurrentProfile) = Nothing
            Actions.Items.RemoveAt(Actions.SelectedIndices(0))
        End If
    End Sub

    Private Sub RenameMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RenameMenuItem.Click
        Actions.LabelEdit = True
        Actions.SelectedItems(0).BeginEdit()
    End Sub

    Private Sub ViewLogMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ViewLogMenuItem.Click
        If Not IO.File.Exists(ProgramConfig.GetLogPath(CurrentProfile)) Then Exit Sub
        Interaction.StartProcess(ProgramConfig.GetLogPath(CurrentProfile))
    End Sub

    Private Sub ClearLogMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClearLogMenuItem.Click
        Profiles(CurrentProfile).DeleteLogFile()
    End Sub

    Private Sub ScheduleMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ScheduleMenuItem.Click
        Dim SchedForm As New SchedulingForm(CurrentProfile)
        SchedForm.ShowDialog()
        ReloadConfigs()
        RedoSchedulerRegistration()
    End Sub

    Private Sub Donate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Donate.Click
        Interaction.StartProcess("http://synchronicity.sourceforge.net/contribute.html")
    End Sub

#If 0 Then
    Private Sub WarningIcon_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles WarningIcon.Click
        If IO.File.Exists(ProgramConfig.MessagesFile) Then
        End If
    End Sub
#End If

    Private Sub Donate_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Donate.MouseEnter
        CType(sender, PictureBox).BackColor = Drawing.Color.LightGray
    End Sub

    Private Sub Donate_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Donate.MouseLeave
        CType(sender, PictureBox).BackColor = Drawing.Color.White
    End Sub
#End Region

#Region " Functions and Routines "
    Sub SetVisible(ByVal _Visible As Boolean)
        If Me.IsDisposed Then Exit Sub
        Me.Visible = _Visible
    End Sub

    Sub SetView(ByVal Offset As Integer)
        CurView = (CurView + Offset) Mod Views.Length
#If CONFIG = "Linux" Then
        CurView = If(CurView = 0, CurView + 1, CurView) 'Exclude tile view.
#End If

        Actions.View = Views(CurView)
        Actions.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent)
    End Sub

    Sub SetFont(ByVal Size As Integer)
        Size = Math.Max(6.25, Math.Min(24.25, Size))
        Actions.Font = New Drawing.Font(Actions.Font.Name, Size)
    End Sub

    Sub ReloadConfigs()
        If Me.IsDisposed Then Exit Sub
        Dim CreateProfileItem As ListViewItem = Actions.Items(0)

        ReloadProfiles()
        Actions.Items.Clear()
        Actions.Items.Add(CreateProfileItem).Group = Actions.Groups(0)

        Dim Groups As New List(Of String)
        For Each ProfilePair As KeyValuePair(Of String, ProfileHandler) In Profiles
            Dim ProfileName As String = ProfilePair.Key
            Dim NewItem As ListViewItem = Actions.Items.Add(ProfileName)

            NewItem.Group = Actions.Groups(1)
            NewItem.ImageIndex = CInt(Profiles(ProfileName).GetSetting(ConfigOptions.Method)) + If(ProfilePair.Value.Scheduler.Frequency = ScheduleInfo.NEVER, 0, 4)
            NewItem.SubItems.Add(GetMethodName(ProfileName)).ForeColor = Drawing.Color.DarkGray

            Dim GroupName As String = Profiles(ProfileName).GetSetting(ConfigOptions.Group)
            If GroupName IsNot Nothing AndAlso GroupName <> "" Then
                If Not Groups.Contains(GroupName) Then
                    Groups.Add(GroupName)
                    Actions.Groups.Add(New ListViewGroup(GroupName, GroupName))
                End If

                NewItem.Group = Actions.Groups.Item(GroupName)
            End If
        Next
    End Sub

    Sub Display_Options(ByVal Name As String, ByVal Clear As Boolean)
        ProfileName.Text = Name

        Method.Text = ""
        Source.Text = ""
        Destination.Text = ""
        LimitedCopy.Text = ""
        FileTypes.Text = ""
        Scheduling.Text = ""
        TimeOffset.Text = ""

        If Clear Then Exit Sub

        Method.Text = GetMethodName(Name)
        Source.Text = Profiles(Name).GetSetting(ConfigOptions.Source)
        Destination.Text = Profiles(Name).GetSetting(ConfigOptions.Destination)

        Scheduling.Text = Translation.Translate("\" & Profiles(Name).Scheduler.Frequency.ToUpper)

        Select Case Profiles(Name).Scheduler.Frequency
            Case ScheduleInfo.WEEKLY
                Dim Day As String = Translation.Translate("\WEEK_DAYS", ";;;;;;").Split(";"c)(Profiles(Name).Scheduler.WeekDay)
                Scheduling.Text &= Day
            Case ScheduleInfo.MONTHLY
                Scheduling.Text &= Profiles(Name).Scheduler.MonthDay
        End Select

        If Profiles(Name).Scheduler.Frequency = ScheduleInfo.NEVER Then
            Scheduling.Text = ""
        Else
            Scheduling.Text &= ", " & Profiles(Name).Scheduler.Hour.ToString.PadLeft(2, "0"c) & Translation.Translate("\H_M_SEP") & Profiles(Name).Scheduler.Minute.ToString.PadLeft(2, "0"c)
        End If

        TimeOffset.Text = Profiles(Name).GetSetting(ConfigOptions.TimeOffset)

        Select Case CInt(Profiles(Name).GetSetting(ConfigOptions.Restrictions, "0"))
            Case 0
                LimitedCopy.Text = Translation.Translate("\NO")
            Case 1, 2
                LimitedCopy.Text = Translation.Translate("\YES")
        End Select

        Select Case CInt(Profiles(Name).GetSetting(ConfigOptions.Restrictions, "0"))
            Case 1
                FileTypes.Text = Profiles(Name).GetSetting(ConfigOptions.IncludedTypes, "")
            Case 2
                FileTypes.Text = "-" & Profiles(Name).GetSetting(ConfigOptions.ExcludedTypes, "")
        End Select
    End Sub

    Function GetMethodName(ByVal Name As String) As String
        Select Case Profiles(Name).GetSetting(ConfigOptions.Method, "")
            Case "1"
                Return Translation.Translate("\LR_INCREMENTAL")
            Case "2"
                Return Translation.Translate("\TWOWAYS_INCREMENTAL")
            Case Else
                Return Translation.Translate("\LR_MIRROR")
        End Select
    End Function

    Function CheckValidity() As Boolean
        If Not Profiles(CurrentProfile).ValidateConfigFile(True, True) Then
            Interaction.ShowMsg(Translation.Translate("\INVALID_CONFIG"), Translation.Translate("\ERROR"), , MessageBoxIcon.Error)
            Return False
        End If
        Return True
    End Function

    Function CurrentProfile() As String
        Return Actions.SelectedItems(0).Text
    End Function

    Sub BuildIcons()
        For Id As Integer = 0 To SyncIcons.Images.Count - 2
            Dim NewImg As New Drawing.Bitmap(32, 32)
            Dim Painter As Drawing.Graphics = Drawing.Graphics.FromImage(NewImg)

            If Id < 2 Then
                Painter.DrawImage(ScheduleMenuItem.Image, 0, 0, 16, 16) 'Not specifying the destination size makes everything blurry.
            Else
                Painter.DrawImage(ScheduleMenuItem.Image, 9, 6, 16, 16)
            End If
            Painter.DrawImageUnscaled(SyncIcons.Images(Id), 0, 0)
            SyncIcons.Images.Add(NewImg)
        Next
    End Sub

    Public Delegate Sub ExitAppCallBack()
    Public Sub ExitApp()
        Me.Close()
        Application.Exit()
    End Sub
#End Region
End Class