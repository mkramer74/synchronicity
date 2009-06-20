﻿'This file is part of Create Synchronicity.
'
'Create Synchronicity is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version.
'Create Synchronicity is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU General Public License for more details.
'You should have received a copy of the GNU General Public License along with Create Synchronicity.  If not, see <http://www.gnu.org/licenses/>.
'Created by:	Clément Pit--Claudel.
'Web site:		http://synchronicity.sourceforge.net.

Public Structure ConfigOptions
    Const Source As String = "Source Directory"
    Const Destination As String = "Destination Directory"
    Const IncludedTypes As String = "Included Filetypes"
    Const ExcludedTypes As String = "Excluded FileTypes"
    Const ReplicateEmptyDirectories As String = "Replicate Empty Directories"
    Const Method As String = "Synchronization Method"
    Const Restrictions As String = "Files restrictions"
    Const LeftSubFolders As String = "Source folders to be synchronized"
    Const RightSubFolders As String = "Destination folders to be synchronized"
    Dim _EMPTY_ As String
End Structure

Class SettingsHandler
    Public ConfigName As String
    Public Configuration As New Dictionary(Of String, String)
    Public LeftCheckedNodes As New Dictionary(Of String, Boolean)
    Public RightCheckedNodes As New Dictionary(Of String, Boolean)

    Private ConfigPath As String = Application.StartupPath & "\config\"
    Private PredicateConfigMatchingList As Dictionary(Of String, String)

    Public Sub New(ByVal Name As String)
        ConfigName = Name
        LoadConfigFile()

        PredicateConfigMatchingList = New Dictionary(Of String, String)
        PredicateConfigMatchingList.Add(ConfigOptions.IncludedTypes, "(([a-zA-Z0-9]+;)*[a-zA-Z0-9])?")
        PredicateConfigMatchingList.Add(ConfigOptions.ExcludedTypes, "(([a-zA-Z0-9]+;)*[a-zA-Z0-9])?")
        PredicateConfigMatchingList.Add(ConfigOptions.LeftSubFolders, ".*")
        PredicateConfigMatchingList.Add(ConfigOptions.RightSubFolders, ".*")
        PredicateConfigMatchingList.Add(ConfigOptions.Source, ".*")
        PredicateConfigMatchingList.Add(ConfigOptions.Destination, ".*")
        PredicateConfigMatchingList.Add(ConfigOptions.Method, "[012]")
        PredicateConfigMatchingList.Add(ConfigOptions.Restrictions, "[012]")
        PredicateConfigMatchingList.Add(ConfigOptions.ReplicateEmptyDirectories, "True|False")
    End Sub

    Function LoadConfigFile() As Boolean
        If Not IO.File.Exists(GetConfigFilePath()) Then Exit Function
        Dim FileReader As New IO.StreamReader(GetConfigFilePath())

        Configuration.Clear()
        While Not FileReader.EndOfStream
            Dim ConfigLine As String = FileReader.ReadLine()
            Dim Key As String = ConfigLine.Substring(0, ConfigLine.IndexOf(":"))
            Dim Value As String = ConfigLine.Substring(ConfigLine.IndexOf(":") + 1)
            If Not Configuration.ContainsKey(Key) Then Configuration.Add(Key, Value)
        End While

        FileReader.Close()

        LoadSubFoldersList(ConfigOptions.LeftSubFolders, LeftCheckedNodes)
        LoadSubFoldersList(ConfigOptions.RightSubFolders, RightCheckedNodes)
        Return True
    End Function

    Sub LoadSubFoldersList(ByVal ConfigLine As String, ByRef Subfolders As Dictionary(Of String, Boolean))
        Subfolders.Clear()
        For Each Dir As String In Configuration(ConfigLine).Split(";"c)
            If Not Subfolders.ContainsKey(Dir) Then
                If Dir.EndsWith("*") Then
                    Subfolders.Add(Dir.Substring(0, Dir.Length - 1), True)
                Else
                    Subfolders.Add(Dir, False)
                End If
            End If
        Next
    End Sub

    Function SaveConfigFile() As Boolean
        Try
            Dim ConfigString As String = ""
            Dim FileWriter As New IO.StreamWriter(GetConfigFilePath())

            For Each Setting As KeyValuePair(Of String, String) In Configuration
                FileWriter.WriteLine(Setting.Key & ":" & Setting.Value)
            Next

            FileWriter.Close()
            Return True
        Catch Ex As Exception
            Return False
        End Try
    End Function

    Function ValidateConfigFile() As Boolean
        Dim IsValid As Boolean = True
        Dim InvalidListing As New List(Of String)

        If Not IO.Directory.Exists(GetSetting(ConfigOptions.Source)) Then
            InvalidListing.Add("Source directory is not valid.")
            IsValid = False
        End If

        If Not IO.Directory.Exists(GetSetting(ConfigOptions.Destination)) Then
            InvalidListing.Add("Destination directory is not valid.")
            IsValid = False
        End If

        For Each Pair As KeyValuePair(Of String, String) In PredicateConfigMatchingList
            If Not Configuration.ContainsKey(Pair.Key) Then
                IsValid = False
                InvalidListing.Add("""" & Pair.Key & """ setting is not set.")
            Else
                If Not System.Text.RegularExpressions.Regex.IsMatch(GetSetting(Pair.Key), Pair.Value) Then
                    IsValid = False
                    InvalidListing.Add("Value for """ & Pair.Key & """ setting is invalid.")
                End If
            End If
        Next
        If Not IsValid Then
            Microsoft.VisualBasic.MsgBox(ListToString(InvalidListing, Microsoft.VisualBasic.vbNewLine), Microsoft.VisualBasic.MsgBoxStyle.OkOnly + Microsoft.VisualBasic.MsgBoxStyle.Critical, "Invalid configuration")
        End If
        Return IsValid
    End Function

    Sub DeleteConfigFile()
        IO.File.Delete(GetConfigFilePath())
    End Sub

    Function GetConfigFilePath() As String
        Return ConfigPath & ConfigName & ".sync"
    End Function

    Sub SetSetting(ByVal SettingName As String, ByVal Value As Object)
        Configuration(SettingName) = Value
    End Sub

    Sub SetSetting(ByVal SettingName As String, ByRef SettingField As Object, ByVal LoadSetting As Boolean)
        If LoadSetting Then
            SettingField = GetSetting(SettingName, SettingField)
        Else
            Configuration(SettingName) = SettingField
        End If
    End Sub

    Function GetSetting(ByVal SettingName As String, Optional ByRef DefaultVal As Object = Nothing) As String
        If Configuration.ContainsKey(SettingName) Then
            Return Configuration(SettingName)
        Else
            Return DefaultVal
        End If
    End Function

    Function ListToString(ByVal StrList As List(Of String), ByVal Separator As Char) As String
        Dim ReturnStr As String = ""
        For Each Str As String In StrList
            ReturnStr &= Str & Separator
        Next
        If ReturnStr.EndsWith(Separator) Then ReturnStr = ReturnStr.Substring(0, ReturnStr.Length - 1)
        Return ReturnStr
    End Function
End Class
