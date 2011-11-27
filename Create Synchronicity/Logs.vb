'This file is part of Create Synchronicity.
'
'Create Synchronicity is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version.
'Create Synchronicity is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU General Public License for more details.
'You should have received a copy of the GNU General Public License along with Create Synchronicity.  If not, see <http://www.gnu.org/licenses/>.
'Created by:	Clément Pit--Claudel.
'Web site:		http://synchronicity.sourceforge.net.

Structure ErrorItem
    Dim Ex As Exception
    Dim Details As String

    Sub New(ByVal _Ex As Exception, ByVal _Details As String)
        Ex = _Ex : Details = _Details
    End Sub
End Structure

Structure LogItem
    Dim Item As SyncingItem
    Dim Side As SideOfSource
    Dim Success As Boolean
    'Dim ErrorId As Integer

    Sub New(ByVal _Item As SyncingItem, ByVal _Side As SideOfSource, ByVal _Success As Boolean) ', Optional ByVal _ErrorId As Integer = -1)
        Item = _Item : Side = _Side : Success = _Success ' : ErrorId = _ErrorId
    End Sub

    Function GetHeader() As String
        Return If(Success, Translation.Translate("\SUCCEDED"), Translation.Translate("\FAILED"))
    End Function
End Structure

Friend NotInheritable Class LogHandler
    Dim LogName As String
    Public Errors As List(Of ErrorItem)
    Public Log As List(Of LogItem)
#If DEBUG Then
    Public DebugInfo As List(Of String)
#End If

    Private Disposed As Boolean '= False

    Private LogId As String 'HTML 'id' to current log
    Private LogTitle As String 'Store current date when launching sync

    Sub New(ByVal _LogName As String)
        IO.Directory.CreateDirectory(ProgramConfig.LogRootDir)

        'Disposed
        LogId = "cs_" + DateTime.UtcNow.Ticks.ToString()
        LogTitle = String.Format("<h2 id=""{0}"">{1}</h2>", LogId, Date.Now.ToString("g"))

        LogName = _LogName
        Errors = New List(Of ErrorItem)
        Log = New List(Of LogItem)

#If DEBUG Then
        DebugInfo = New List(Of String)
#End If
    End Sub

    Sub HandleError(ByVal Ex As Exception, Optional ByVal Details As String = "")
        If Ex Is Nothing OrElse TypeOf Ex Is Threading.ThreadAbortException Then Exit Sub
        Errors.Add(New ErrorItem(Ex, Details))
    End Sub

    Sub LogAction(ByVal Item As SyncingItem, ByVal Side As SideOfSource, ByVal Success As Boolean)
        Log.Add(New LogItem(Item, Side, Success))
    End Sub

    <Diagnostics.Conditional("Debug")>
    Sub HandleSilentError(ByVal Ex As Exception, Optional ByVal Details As String = "Debug message")
#If DEBUG Then
        HandleError(Ex, Details)
#End If
    End Sub

    <Diagnostics.Conditional("Debug")>
    Sub LogInfo(ByVal Info As String)
#If DEBUG Then
        DebugInfo.Add(Info)
#End If
    End Sub

    Private Sub OpenHTMLHeaders(ByRef LogW As IO.StreamWriter)
        Dim LogTitle As String = String.Format(Translation.Translate("\LOG_TITLE"), LogName)

        If Not (ProgramSetting.Debug Or ProgramConfig.GetProgramSetting(Of Boolean)(ProgramSetting.TextLogs, False)) Then
            LogW.WriteLine("<!DOCTYPE html PUBLIC ""-//W3C//DTD XHTML 1.1//EN"" ""http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd""><html xmlns=""http://www.w3.org/1999/xhtml""><head><title>" & LogTitle & "</title><meta http-equiv=""Content-Type"" content=""text/html;charset=utf-8"" /><style type=""text/css"">body{font-family:Consolas, Courier, monospace;font-size:0.8em;margin:auto;width:80%;}table{border-collapse:collapse;margin:1em 0;width:100%;}th, td{border:solid grey;border-width:1px 0;padding-right:2em;}tr:nth-child(odd){background-color:#EEE;}.actions tr td{white-space:nowrap;}.actions tr td:nth-child(5), .errors tr td:nth-child(2){white-space:normal;word-break:break-all;}tr td:last-child{padding-right:0;}</style></head><body>")
        End If

        LogW.WriteLine("<h1>" & LogTitle & "</h1>")
        LogW.WriteLine(String.Format("<p><a href=""#{0}"">{1}</a></p>", LogId, Translation.Translate("\LATEST")))
    End Sub

    Private Shared Sub CloseHTMLHeaders(ByRef LogW As IO.StreamWriter)
        If ProgramSetting.Debug Or ProgramConfig.GetProgramSetting(Of Boolean)(ProgramSetting.TextLogs, False) Then
            LogW.WriteLine()
        Else
            LogW.WriteLine("</body></html>")
        End If
    End Sub

    Private Shared Sub PutFormatted(ByVal Contents As String(), ByRef LogW As IO.StreamWriter)
        If ProgramSetting.Debug Or ProgramConfig.GetProgramSetting(Of Boolean)(ProgramSetting.TextLogs, False) Then
            LogW.WriteLine(String.Join("	", Contents))
        Else
            LogW.WriteLine("<tr>")
            For Each Cell As String In Contents
                LogW.WriteLine("	<td>" & Cell & "</td>")
            Next
            LogW.WriteLine("</tr>")
        End If
    End Sub

    Private Shared Sub PutHTML(ByVal LogWriter As IO.StreamWriter, ByVal Line As String)
        If Not (ProgramSetting.Debug Or ProgramConfig.GetProgramSetting(Of Boolean)(ProgramSetting.TextLogs, False)) Then LogWriter.WriteLine(Line)
    End Sub

    Sub SaveAndDispose(ByVal Left As String, ByVal Right As String, ByVal Status As StatusData)
        If Disposed Then Exit Sub
        Disposed = True

        Try
            Dim NewLog As Boolean = Not IO.File.Exists(ProgramConfig.GetLogPath(LogName))

            'Load the contents of the previous log, excluding the closing tags
            Dim MaxArchivesCount As Integer = ProgramConfig.GetProgramSetting(Of Integer)(ProgramSetting.MaxLogEntries, 7)
            Dim Archives As New List(Of Text.StringBuilder)

            Dim TitleLine As New Text.RegularExpressions.Regex("<h2.*>")
            Dim StrippedLines As New Text.RegularExpressions.Regex("<h1>|<a.*>|</body>|</html>")

            If Not NewLog And Not Debug Then
                Using LogReader As New IO.StreamReader(ProgramConfig.GetLogPath(LogName))
                    While Not LogReader.EndOfStream
                        Dim Line As String = LogReader.ReadLine()
                        If TitleLine.IsMatch(Line) Then
                            Archives.Add(New Text.StringBuilder())
                            If Archives.Count > MaxArchivesCount Then Archives.RemoveAt(0) 'Don't store more than ConfigOptions.MaxLogEntries in memory
                        End If
                        If Archives.Count > 0 AndAlso (Not StrippedLines.IsMatch(Line)) Then Archives(Archives.Count - 1).AppendLine(Line)
                    End While
                End Using
            End If

            'This erases log contents.
            Dim LogWriter As New IO.StreamWriter(ProgramConfig.GetLogPath(LogName), False, Text.Encoding.UTF8)
            OpenHTMLHeaders(LogWriter)
            For LogId As Integer = 0 To Archives.Count - 1
                LogWriter.Write(Archives(LogId).ToString)
            Next

            Try
                'Log format: <h2>, then two <table>s (info, errors)
                LogWriter.WriteLine(LogTitle) 'Must be kept, to detect log boundaries

                PutHTML(LogWriter, "<p>")
                LogWriter.WriteLine(String.Format("Create Synchronicity v{0}", Application.ProductVersion))
                PutHTML(LogWriter, "<br />")
                LogWriter.WriteLine(String.Format("{0}: {1}", Translation.Translate("\LEFT"), Left))
                PutHTML(LogWriter, "<br />")
                LogWriter.WriteLine(String.Format("{0}: {1}", Translation.Translate("\RIGHT"), Right))
                PutHTML(LogWriter, "<br />")
                LogWriter.WriteLine(String.Format("{0} {1}/{2}", Translation.Translate("\DONE"), Status.ActionsDone, Status.TotalActionsCount))
                If Status.Failed And (Status.FailureMsg IsNot Nothing) Then
                    PutHTML(LogWriter, "<br />")
                    LogWriter.WriteLine(Status.FailureMsg)
                End If
                PutHTML(LogWriter, "</p>")

#If DEBUG Then
                For Each Info As String In DebugInfo
                    PutFormatted(New String() {"Info", Info}, LogWriter)
                Next
#End If

                If Log.Count > 0 Then
                    PutHTML(LogWriter, "<table class=""actions"">")
                    For Each Record As LogItem In Log
                        PutFormatted(New String() {Record.GetHeader(), Record.Item.FormatType(), Record.Item.FormatAction(), Record.Item.FormatDirection(Record.Side), Record.Item.Path}, LogWriter)
                    Next
                    PutHTML(LogWriter, "</table>")
                End If

                If Errors.Count > 0 Then
                    PutHTML(LogWriter, "<table class=""errors"">")
                    For Each Err As ErrorItem In Errors
                        PutFormatted(New String() {Translation.Translate("\ERROR"), Err.Details, Err.Ex.Message, Err.Ex.StackTrace.Replace(Environment.NewLine, "\n")}, LogWriter)
                    Next
                    PutHTML(LogWriter, "</table>")
                End If

                CloseHTMLHeaders(LogWriter)

            Catch Ex As Threading.ThreadAbortException
                Exit Sub
            Catch Ex As Exception
                Interaction.ShowMsg(Translation.Translate("\LOGFILE_WRITE_ERROR") & Environment.NewLine & Ex.Message & Environment.NewLine & Environment.NewLine & Ex.ToString)
            Finally
                LogWriter.Close()
            End Try

        Catch Ex As Exception
            Interaction.ShowMsg(Translation.Translate("\LOGFILE_OPEN_ERROR") & Environment.NewLine & Ex.Message & Environment.NewLine & Environment.NewLine & Ex.ToString)
        End Try
    End Sub
End Class