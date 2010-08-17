'This file is part of Create Synchronicity.
'
'Create Synchronicity is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version.
'Create Synchronicity is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU General Public License for more details.
'You should have received a copy of the GNU General Public License along with Create Synchronicity.  If not, see <http://www.gnu.org/licenses/>.
'Created by:	Clément Pit--Claudel.
'Web site:		http://synchronicity.sourceforge.net.

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim ListViewGroup1 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("\ACTIONS", System.Windows.Forms.HorizontalAlignment.Left)
        Dim ListViewGroup2 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("\PROFILES", System.Windows.Forms.HorizontalAlignment.Left)
        Dim ListViewItem1 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New System.Windows.Forms.ListViewItem.ListViewSubItem() {New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, "\NEW_PROFILE_LABEL"), New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, "\NEW_PROFILE", System.Drawing.Color.DarkGray, System.Drawing.SystemColors.Window, New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte)))}, 3)
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
        Me.Main_Actions = New System.Windows.Forms.ListView()
        Me.Actions_NameColumn = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Main_MethodsColumn = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Main_SyncIcons = New System.Windows.Forms.ImageList(Me.components)
        Me.Main_InfoPanel = New System.Windows.Forms.Panel()
        Me.Main_InfoLayout = New System.Windows.Forms.TableLayoutPanel()
        Me.Main_TimeOffset = New System.Windows.Forms.Label()
        Me.Main_Scheduling = New System.Windows.Forms.Label()
        Me.Main_SchedulingLabel = New System.Windows.Forms.Label()
        Me.Main_Destination = New System.Windows.Forms.Label()
        Me.Main_DestinationLabel = New System.Windows.Forms.Label()
        Me.Main_Source = New System.Windows.Forms.Label()
        Me.Main_SourceLabel = New System.Windows.Forms.Label()
        Me.Main_FileTypes = New System.Windows.Forms.Label()
        Me.Main_FileTypesLabel = New System.Windows.Forms.Label()
        Me.Main_Method = New System.Windows.Forms.Label()
        Me.Main_MethodLabel = New System.Windows.Forms.Label()
        Me.Main_LimitedCopy = New System.Windows.Forms.Label()
        Me.Main_LimitedCopyLabel = New System.Windows.Forms.Label()
        Me.Main_Name = New System.Windows.Forms.Label()
        Me.Main_NameLabel = New System.Windows.Forms.Label()
        Me.Main_TimeOffsetLabel = New System.Windows.Forms.Label()
        Me.Main_ActionsMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.PreviewMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SynchronizeMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ChangeSettingsMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ActionsMenuToolStripSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RenameMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ViewLogMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ClearLogMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ActionsMenuToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ScheduleMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Main_AboutLinkLabel = New System.Windows.Forms.LinkLabel()
        Me.ApplicationTimer = New System.Windows.Forms.Timer(Me.components)
        Me.StatusIconMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Main_Donate = New System.Windows.Forms.PictureBox()
        Me.Main_InfoPanel.SuspendLayout()
        Me.Main_InfoLayout.SuspendLayout()
        Me.Main_ActionsMenu.SuspendLayout()
        Me.StatusIconMenu.SuspendLayout()
        CType(Me.Main_Donate, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Main_Actions
        '
        Me.Main_Actions.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.Actions_NameColumn, Me.Main_MethodsColumn})
        Me.Main_Actions.Dock = System.Windows.Forms.DockStyle.Fill
        ListViewGroup1.Header = "\ACTIONS"
        ListViewGroup1.Name = "Actions"
        ListViewGroup2.Header = "\PROFILES"
        ListViewGroup2.Name = "Profiles"
        Me.Main_Actions.Groups.AddRange(New System.Windows.Forms.ListViewGroup() {ListViewGroup1, ListViewGroup2})
        ListViewItem1.Group = ListViewGroup1
        ListViewItem1.StateImageIndex = 0
        Me.Main_Actions.Items.AddRange(New System.Windows.Forms.ListViewItem() {ListViewItem1})
        Me.Main_Actions.LargeImageList = Me.Main_SyncIcons
        Me.Main_Actions.Location = New System.Drawing.Point(0, 0)
        Me.Main_Actions.MultiSelect = False
        Me.Main_Actions.Name = "Main_Actions"
        Me.Main_Actions.Size = New System.Drawing.Size(355, 262)
        Me.Main_Actions.TabIndex = 0
        Me.Main_Actions.TileSize = New System.Drawing.Size(160, 40)
        Me.Main_Actions.UseCompatibleStateImageBehavior = False
        Me.Main_Actions.View = System.Windows.Forms.View.Tile
        '
        'Actions_NameColumn
        '
        Me.Actions_NameColumn.Text = "\NAME"
        '
        'Main_MethodsColumn
        '
        Me.Main_MethodsColumn.Text = "\METHOD"
        '
        'Main_SyncIcons
        '
        Me.Main_SyncIcons.ImageStream = CType(resources.GetObject("Main_SyncIcons.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.Main_SyncIcons.TransparentColor = System.Drawing.Color.Empty
        Me.Main_SyncIcons.Images.SetKeyName(0, "edit-redo.png")
        Me.Main_SyncIcons.Images.SetKeyName(1, "edit-redo-add.png")
        Me.Main_SyncIcons.Images.SetKeyName(2, "view-refresh.png")
        Me.Main_SyncIcons.Images.SetKeyName(3, "document-new.png")
        '
        'Main_InfoPanel
        '
        Me.Main_InfoPanel.Controls.Add(Me.Main_InfoLayout)
        Me.Main_InfoPanel.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Main_InfoPanel.Location = New System.Drawing.Point(0, 262)
        Me.Main_InfoPanel.Name = "Main_InfoPanel"
        Me.Main_InfoPanel.Size = New System.Drawing.Size(355, 160)
        Me.Main_InfoPanel.TabIndex = 2
        '
        'Main_InfoLayout
        '
        Me.Main_InfoLayout.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Main_InfoLayout.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.[Single]
        Me.Main_InfoLayout.ColumnCount = 4
        Me.Main_InfoLayout.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.Main_InfoLayout.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60.0!))
        Me.Main_InfoLayout.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.Main_InfoLayout.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40.0!))
        Me.Main_InfoLayout.Controls.Add(Me.Main_TimeOffset, 3, 2)
        Me.Main_InfoLayout.Controls.Add(Me.Main_Scheduling, 1, 2)
        Me.Main_InfoLayout.Controls.Add(Me.Main_SchedulingLabel, 0, 2)
        Me.Main_InfoLayout.Controls.Add(Me.Main_Destination, 1, 4)
        Me.Main_InfoLayout.Controls.Add(Me.Main_DestinationLabel, 0, 4)
        Me.Main_InfoLayout.Controls.Add(Me.Main_Source, 1, 3)
        Me.Main_InfoLayout.Controls.Add(Me.Main_SourceLabel, 0, 3)
        Me.Main_InfoLayout.Controls.Add(Me.Main_FileTypes, 3, 1)
        Me.Main_InfoLayout.Controls.Add(Me.Main_FileTypesLabel, 2, 1)
        Me.Main_InfoLayout.Controls.Add(Me.Main_Method, 1, 1)
        Me.Main_InfoLayout.Controls.Add(Me.Main_MethodLabel, 0, 1)
        Me.Main_InfoLayout.Controls.Add(Me.Main_LimitedCopy, 3, 0)
        Me.Main_InfoLayout.Controls.Add(Me.Main_LimitedCopyLabel, 2, 0)
        Me.Main_InfoLayout.Controls.Add(Me.Main_Name, 1, 0)
        Me.Main_InfoLayout.Controls.Add(Me.Main_NameLabel, 0, 0)
        Me.Main_InfoLayout.Controls.Add(Me.Main_TimeOffsetLabel, 2, 2)
        Me.Main_InfoLayout.Location = New System.Drawing.Point(12, 6)
        Me.Main_InfoLayout.Name = "Main_InfoLayout"
        Me.Main_InfoLayout.RowCount = 5
        Me.Main_InfoLayout.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.Main_InfoLayout.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.Main_InfoLayout.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.Main_InfoLayout.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.Main_InfoLayout.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.Main_InfoLayout.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.Main_InfoLayout.Size = New System.Drawing.Size(331, 142)
        Me.Main_InfoLayout.TabIndex = 0
        '
        'Main_TimeOffset
        '
        Me.Main_TimeOffset.AutoSize = True
        Me.Main_TimeOffset.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Main_TimeOffset.Location = New System.Drawing.Point(284, 57)
        Me.Main_TimeOffset.Name = "Main_TimeOffset"
        Me.Main_TimeOffset.Size = New System.Drawing.Size(43, 27)
        Me.Main_TimeOffset.TabIndex = 15
        Me.Main_TimeOffset.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Main_Scheduling
        '
        Me.Main_Scheduling.AutoSize = True
        Me.Main_Scheduling.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Main_Scheduling.Location = New System.Drawing.Point(104, 57)
        Me.Main_Scheduling.Name = "Main_Scheduling"
        Me.Main_Scheduling.Size = New System.Drawing.Size(67, 27)
        Me.Main_Scheduling.TabIndex = 14
        Me.Main_Scheduling.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Main_SchedulingLabel
        '
        Me.Main_SchedulingLabel.AutoSize = True
        Me.Main_SchedulingLabel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Main_SchedulingLabel.Location = New System.Drawing.Point(4, 57)
        Me.Main_SchedulingLabel.Name = "Main_SchedulingLabel"
        Me.Main_SchedulingLabel.Size = New System.Drawing.Size(93, 27)
        Me.Main_SchedulingLabel.TabIndex = 13
        Me.Main_SchedulingLabel.Text = "\SCH_LABEL"
        Me.Main_SchedulingLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Main_Destination
        '
        Me.Main_Destination.AutoSize = True
        Me.Main_InfoLayout.SetColumnSpan(Me.Main_Destination, 3)
        Me.Main_Destination.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Main_Destination.Location = New System.Drawing.Point(104, 113)
        Me.Main_Destination.Name = "Main_Destination"
        Me.Main_Destination.Size = New System.Drawing.Size(223, 28)
        Me.Main_Destination.TabIndex = 11
        Me.Main_Destination.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Main_DestinationLabel
        '
        Me.Main_DestinationLabel.AutoSize = True
        Me.Main_DestinationLabel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Main_DestinationLabel.Location = New System.Drawing.Point(4, 113)
        Me.Main_DestinationLabel.Name = "Main_DestinationLabel"
        Me.Main_DestinationLabel.Size = New System.Drawing.Size(93, 28)
        Me.Main_DestinationLabel.TabIndex = 10
        Me.Main_DestinationLabel.Text = "\DESTINATION"
        Me.Main_DestinationLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Main_Source
        '
        Me.Main_Source.AutoSize = True
        Me.Main_InfoLayout.SetColumnSpan(Me.Main_Source, 3)
        Me.Main_Source.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Main_Source.Location = New System.Drawing.Point(104, 85)
        Me.Main_Source.Name = "Main_Source"
        Me.Main_Source.Size = New System.Drawing.Size(223, 27)
        Me.Main_Source.TabIndex = 9
        Me.Main_Source.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Main_SourceLabel
        '
        Me.Main_SourceLabel.AutoSize = True
        Me.Main_SourceLabel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Main_SourceLabel.Location = New System.Drawing.Point(4, 85)
        Me.Main_SourceLabel.Name = "Main_SourceLabel"
        Me.Main_SourceLabel.Size = New System.Drawing.Size(93, 27)
        Me.Main_SourceLabel.TabIndex = 8
        Me.Main_SourceLabel.Text = "\SOURCE"
        Me.Main_SourceLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Main_FileTypes
        '
        Me.Main_FileTypes.AutoSize = True
        Me.Main_FileTypes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Main_FileTypes.Location = New System.Drawing.Point(284, 29)
        Me.Main_FileTypes.Name = "Main_FileTypes"
        Me.Main_FileTypes.Size = New System.Drawing.Size(43, 27)
        Me.Main_FileTypes.TabIndex = 7
        Me.Main_FileTypes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Main_FileTypesLabel
        '
        Me.Main_FileTypesLabel.AutoSize = True
        Me.Main_FileTypesLabel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Main_FileTypesLabel.Location = New System.Drawing.Point(178, 29)
        Me.Main_FileTypesLabel.Name = "Main_FileTypesLabel"
        Me.Main_FileTypesLabel.Size = New System.Drawing.Size(99, 27)
        Me.Main_FileTypesLabel.TabIndex = 6
        Me.Main_FileTypesLabel.Text = "\FILETYPES"
        Me.Main_FileTypesLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Main_Method
        '
        Me.Main_Method.AutoSize = True
        Me.Main_Method.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Main_Method.Location = New System.Drawing.Point(104, 29)
        Me.Main_Method.Name = "Main_Method"
        Me.Main_Method.Size = New System.Drawing.Size(67, 27)
        Me.Main_Method.TabIndex = 5
        Me.Main_Method.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Main_MethodLabel
        '
        Me.Main_MethodLabel.AutoSize = True
        Me.Main_MethodLabel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Main_MethodLabel.Location = New System.Drawing.Point(4, 29)
        Me.Main_MethodLabel.Name = "Main_MethodLabel"
        Me.Main_MethodLabel.Size = New System.Drawing.Size(93, 27)
        Me.Main_MethodLabel.TabIndex = 4
        Me.Main_MethodLabel.Text = "\METHOD"
        Me.Main_MethodLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Main_LimitedCopy
        '
        Me.Main_LimitedCopy.AutoSize = True
        Me.Main_LimitedCopy.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Main_LimitedCopy.Location = New System.Drawing.Point(284, 1)
        Me.Main_LimitedCopy.Name = "Main_LimitedCopy"
        Me.Main_LimitedCopy.Size = New System.Drawing.Size(43, 27)
        Me.Main_LimitedCopy.TabIndex = 3
        Me.Main_LimitedCopy.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Main_LimitedCopyLabel
        '
        Me.Main_LimitedCopyLabel.AutoSize = True
        Me.Main_LimitedCopyLabel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Main_LimitedCopyLabel.Location = New System.Drawing.Point(178, 1)
        Me.Main_LimitedCopyLabel.Name = "Main_LimitedCopyLabel"
        Me.Main_LimitedCopyLabel.Size = New System.Drawing.Size(99, 27)
        Me.Main_LimitedCopyLabel.TabIndex = 2
        Me.Main_LimitedCopyLabel.Text = "\LIMITED_COPY"
        Me.Main_LimitedCopyLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Main_Name
        '
        Me.Main_Name.AutoSize = True
        Me.Main_Name.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Main_Name.Location = New System.Drawing.Point(104, 1)
        Me.Main_Name.Name = "Main_Name"
        Me.Main_Name.Size = New System.Drawing.Size(67, 27)
        Me.Main_Name.TabIndex = 1
        Me.Main_Name.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Main_NameLabel
        '
        Me.Main_NameLabel.AutoSize = True
        Me.Main_NameLabel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Main_NameLabel.Location = New System.Drawing.Point(4, 1)
        Me.Main_NameLabel.Name = "Main_NameLabel"
        Me.Main_NameLabel.Size = New System.Drawing.Size(93, 27)
        Me.Main_NameLabel.TabIndex = 0
        Me.Main_NameLabel.Text = "\NAME"
        Me.Main_NameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Main_TimeOffsetLabel
        '
        Me.Main_TimeOffsetLabel.AutoSize = True
        Me.Main_TimeOffsetLabel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Main_TimeOffsetLabel.Location = New System.Drawing.Point(178, 57)
        Me.Main_TimeOffsetLabel.Name = "Main_TimeOffsetLabel"
        Me.Main_TimeOffsetLabel.Size = New System.Drawing.Size(99, 27)
        Me.Main_TimeOffsetLabel.TabIndex = 12
        Me.Main_TimeOffsetLabel.Text = "\TIME_OFFSET"
        Me.Main_TimeOffsetLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Main_ActionsMenu
        '
        Me.Main_ActionsMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PreviewMenuItem, Me.SynchronizeMenuItem, Me.ChangeSettingsMenuItem, Me.ActionsMenuToolStripSeparator, Me.DeleteToolStripMenuItem, Me.RenameMenuItem, Me.ViewLogMenuItem, Me.ClearLogMenuItem, Me.ActionsMenuToolStripSeparator2, Me.ScheduleMenuItem})
        Me.Main_ActionsMenu.Name = "Main_ActionsMenu"
        Me.Main_ActionsMenu.Size = New System.Drawing.Size(185, 192)
        '
        'PreviewMenuItem
        '
        Me.PreviewMenuItem.Image = CType(resources.GetObject("PreviewMenuItem.Image"), System.Drawing.Image)
        Me.PreviewMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.PreviewMenuItem.Name = "PreviewMenuItem"
        Me.PreviewMenuItem.Size = New System.Drawing.Size(184, 22)
        Me.PreviewMenuItem.Text = "\PREVIEW"
        '
        'SynchronizeMenuItem
        '
        Me.SynchronizeMenuItem.Image = CType(resources.GetObject("SynchronizeMenuItem.Image"), System.Drawing.Image)
        Me.SynchronizeMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.SynchronizeMenuItem.Name = "SynchronizeMenuItem"
        Me.SynchronizeMenuItem.Size = New System.Drawing.Size(184, 22)
        Me.SynchronizeMenuItem.Text = "\SYNC"
        '
        'ChangeSettingsMenuItem
        '
        Me.ChangeSettingsMenuItem.Image = CType(resources.GetObject("ChangeSettingsMenuItem.Image"), System.Drawing.Image)
        Me.ChangeSettingsMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ChangeSettingsMenuItem.Name = "ChangeSettingsMenuItem"
        Me.ChangeSettingsMenuItem.Size = New System.Drawing.Size(184, 22)
        Me.ChangeSettingsMenuItem.Text = "\CHANGE_SETTINGS"
        '
        'ActionsMenuToolStripSeparator
        '
        Me.ActionsMenuToolStripSeparator.Name = "ActionsMenuToolStripSeparator"
        Me.ActionsMenuToolStripSeparator.Size = New System.Drawing.Size(181, 6)
        '
        'DeleteToolStripMenuItem
        '
        Me.DeleteToolStripMenuItem.Image = CType(resources.GetObject("DeleteToolStripMenuItem.Image"), System.Drawing.Image)
        Me.DeleteToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem"
        Me.DeleteToolStripMenuItem.Size = New System.Drawing.Size(184, 22)
        Me.DeleteToolStripMenuItem.Text = "\DELETE"
        '
        'RenameMenuItem
        '
        Me.RenameMenuItem.Image = CType(resources.GetObject("RenameMenuItem.Image"), System.Drawing.Image)
        Me.RenameMenuItem.Name = "RenameMenuItem"
        Me.RenameMenuItem.Size = New System.Drawing.Size(184, 22)
        Me.RenameMenuItem.Text = "\RENAME"
        '
        'ViewLogMenuItem
        '
        Me.ViewLogMenuItem.Image = CType(resources.GetObject("ViewLogMenuItem.Image"), System.Drawing.Image)
        Me.ViewLogMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ViewLogMenuItem.Name = "ViewLogMenuItem"
        Me.ViewLogMenuItem.Size = New System.Drawing.Size(184, 22)
        Me.ViewLogMenuItem.Text = "\VIEW_LOG"
        '
        'ClearLogMenuItem
        '
        Me.ClearLogMenuItem.Image = CType(resources.GetObject("ClearLogMenuItem.Image"), System.Drawing.Image)
        Me.ClearLogMenuItem.Name = "ClearLogMenuItem"
        Me.ClearLogMenuItem.Size = New System.Drawing.Size(184, 22)
        Me.ClearLogMenuItem.Tag = "\CLEAR_LOG"
        '
        'ActionsMenuToolStripSeparator2
        '
        Me.ActionsMenuToolStripSeparator2.Name = "ActionsMenuToolStripSeparator2"
        Me.ActionsMenuToolStripSeparator2.Size = New System.Drawing.Size(181, 6)
        '
        'ScheduleMenuItem
        '
        Me.ScheduleMenuItem.Image = CType(resources.GetObject("ScheduleMenuItem.Image"), System.Drawing.Image)
        Me.ScheduleMenuItem.Name = "ScheduleMenuItem"
        Me.ScheduleMenuItem.Size = New System.Drawing.Size(184, 22)
        Me.ScheduleMenuItem.Text = "\SCHEDULING"
        '
        'Main_AboutLinkLabel
        '
        Me.Main_AboutLinkLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Main_AboutLinkLabel.BackColor = System.Drawing.Color.White
        Me.Main_AboutLinkLabel.Location = New System.Drawing.Point(234, 6)
        Me.Main_AboutLinkLabel.Name = "Main_AboutLinkLabel"
        Me.Main_AboutLinkLabel.Size = New System.Drawing.Size(118, 13)
        Me.Main_AboutLinkLabel.TabIndex = 1
        Me.Main_AboutLinkLabel.TabStop = True
        Me.Main_AboutLinkLabel.Text = "\ABOUT_SETTINGS"
        Me.Main_AboutLinkLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Main_AboutLinkLabel.VisitedLinkColor = System.Drawing.Color.Blue
        '
        'ApplicationTimer
        '
        Me.ApplicationTimer.Interval = 10
        '
        'StatusIconMenu
        '
        Me.StatusIconMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ExitToolStripMenuItem})
        Me.StatusIconMenu.Name = "StatusIconMenu"
        Me.StatusIconMenu.ShowImageMargin = False
        Me.StatusIconMenu.Size = New System.Drawing.Size(100, 26)
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(99, 22)
        Me.ExitToolStripMenuItem.Text = "\CANCEL"
        '
        'Main_Donate
        '
        Me.Main_Donate.BackColor = System.Drawing.Color.White
        Me.Main_Donate.Image = CType(resources.GetObject("Main_Donate.Image"), System.Drawing.Image)
        Me.Main_Donate.Location = New System.Drawing.Point(314, 22)
        Me.Main_Donate.Name = "Main_Donate"
        Me.Main_Donate.Size = New System.Drawing.Size(34, 34)
        Me.Main_Donate.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.Main_Donate.TabIndex = 3
        Me.Main_Donate.TabStop = False
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(355, 422)
        Me.Controls.Add(Me.Main_Donate)
        Me.Controls.Add(Me.Main_AboutLinkLabel)
        Me.Controls.Add(Me.Main_Actions)
        Me.Controls.Add(Me.Main_InfoPanel)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.Name = "MainForm"
        Me.Text = "Create Synchronicity"
        Me.Main_InfoPanel.ResumeLayout(False)
        Me.Main_InfoLayout.ResumeLayout(False)
        Me.Main_InfoLayout.PerformLayout()
        Me.Main_ActionsMenu.ResumeLayout(False)
        Me.StatusIconMenu.ResumeLayout(False)
        CType(Me.Main_Donate, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Main_Actions As System.Windows.Forms.ListView
    Friend WithEvents Main_InfoPanel As System.Windows.Forms.Panel
    Friend WithEvents Main_InfoLayout As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Main_Name As System.Windows.Forms.Label
    Friend WithEvents Main_NameLabel As System.Windows.Forms.Label
    Friend WithEvents Main_Destination As System.Windows.Forms.Label
    Friend WithEvents Main_DestinationLabel As System.Windows.Forms.Label
    Friend WithEvents Main_Source As System.Windows.Forms.Label
    Friend WithEvents Main_SourceLabel As System.Windows.Forms.Label
    Friend WithEvents Main_FileTypes As System.Windows.Forms.Label
    Friend WithEvents Main_FileTypesLabel As System.Windows.Forms.Label
    Friend WithEvents Main_Method As System.Windows.Forms.Label
    Friend WithEvents Main_MethodLabel As System.Windows.Forms.Label
    Friend WithEvents Main_LimitedCopy As System.Windows.Forms.Label
    Friend WithEvents Main_LimitedCopyLabel As System.Windows.Forms.Label
    Friend WithEvents Main_ActionsMenu As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents SynchronizeMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PreviewMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ChangeSettingsMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ViewLogMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Main_SyncIcons As System.Windows.Forms.ImageList
    Friend WithEvents Actions_NameColumn As System.Windows.Forms.ColumnHeader
    Friend WithEvents Main_MethodsColumn As System.Windows.Forms.ColumnHeader
    Friend WithEvents ActionsMenuToolStripSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents DeleteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Main_AboutLinkLabel As System.Windows.Forms.LinkLabel
    Friend WithEvents ClearLogMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ActionsMenuToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ScheduleMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ApplicationTimer As System.Windows.Forms.Timer
    Friend WithEvents Main_TimeOffset As System.Windows.Forms.Label
    Friend WithEvents Main_Scheduling As System.Windows.Forms.Label
    Friend WithEvents Main_SchedulingLabel As System.Windows.Forms.Label
    Friend WithEvents Main_TimeOffsetLabel As System.Windows.Forms.Label
    Friend WithEvents StatusIconMenu As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RenameMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Main_Donate As System.Windows.Forms.PictureBox
End Class