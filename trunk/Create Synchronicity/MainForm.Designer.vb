﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
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
        Me.components = New System.ComponentModel.Container
        Dim ListViewGroup1 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("Actions", System.Windows.Forms.HorizontalAlignment.Left)
        Dim ListViewGroup2 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("Profiles", System.Windows.Forms.HorizontalAlignment.Left)
        Dim ListViewItem1 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New System.Windows.Forms.ListViewItem.ListViewSubItem() {New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, "New profile"), New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, "Create a new profile", System.Drawing.Color.DarkGray, System.Drawing.SystemColors.Window, New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte)))}, 3)
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
        Me.Main_Actions = New System.Windows.Forms.ListView
        Me.Actions_NameColumn = New System.Windows.Forms.ColumnHeader
        Me.Main_MethodsColumn = New System.Windows.Forms.ColumnHeader
        Me.Main_SyncIcons = New System.Windows.Forms.ImageList(Me.components)
        Me.Main_InfoPanel = New System.Windows.Forms.Panel
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.Main_Destination = New System.Windows.Forms.Label
        Me.Main_DestinationLabel = New System.Windows.Forms.Label
        Me.Main_Source = New System.Windows.Forms.Label
        Me.Main_SourceLabel = New System.Windows.Forms.Label
        Me.Main_FileTypes = New System.Windows.Forms.Label
        Me.Main_FileTypesLabel = New System.Windows.Forms.Label
        Me.Main_Method = New System.Windows.Forms.Label
        Me.Main_MethodLabel = New System.Windows.Forms.Label
        Me.Main_LimitedCopy = New System.Windows.Forms.Label
        Me.Main_LimitedCopyLabel = New System.Windows.Forms.Label
        Me.Main_Name = New System.Windows.Forms.Label
        Me.Main_NameLabel = New System.Windows.Forms.Label
        Me.Main_ActionsMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.PreviewMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SynchronizeMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.Main_ChangeSettingsMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ViewLogMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker
        Me.Main_AboutLinkLabel = New System.Windows.Forms.LinkLabel
        Me.Main_InfoPanel.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Main_ActionsMenu.SuspendLayout()
        Me.SuspendLayout()
        '
        'Main_Actions
        '
        Me.Main_Actions.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.Actions_NameColumn, Me.Main_MethodsColumn})
        Me.Main_Actions.Dock = System.Windows.Forms.DockStyle.Fill
        ListViewGroup1.Header = "Actions"
        ListViewGroup1.Name = "Actions"
        ListViewGroup2.Header = "Profiles"
        ListViewGroup2.Name = "Profiles"
        Me.Main_Actions.Groups.AddRange(New System.Windows.Forms.ListViewGroup() {ListViewGroup1, ListViewGroup2})
        ListViewItem1.Group = ListViewGroup1
        ListViewItem1.StateImageIndex = 0
        Me.Main_Actions.Items.AddRange(New System.Windows.Forms.ListViewItem() {ListViewItem1})
        Me.Main_Actions.LargeImageList = Me.Main_SyncIcons
        Me.Main_Actions.Location = New System.Drawing.Point(0, 0)
        Me.Main_Actions.MultiSelect = False
        Me.Main_Actions.Name = "Main_Actions"
        Me.Main_Actions.Size = New System.Drawing.Size(355, 268)
        Me.Main_Actions.SmallImageList = Me.Main_SyncIcons
        Me.Main_Actions.TabIndex = 0
        Me.Main_Actions.TileSize = New System.Drawing.Size(160, 40)
        Me.Main_Actions.UseCompatibleStateImageBehavior = False
        Me.Main_Actions.View = System.Windows.Forms.View.Tile
        '
        'Actions_NameColumn
        '
        Me.Actions_NameColumn.Text = "Name"
        '
        'Main_MethodsColumn
        '
        Me.Main_MethodsColumn.Text = "Method"
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
        Me.Main_InfoPanel.Controls.Add(Me.TableLayoutPanel1)
        Me.Main_InfoPanel.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Main_InfoPanel.Location = New System.Drawing.Point(0, 268)
        Me.Main_InfoPanel.Name = "Main_InfoPanel"
        Me.Main_InfoPanel.Size = New System.Drawing.Size(355, 132)
        Me.Main_InfoPanel.TabIndex = 1
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.[Single]
        Me.TableLayoutPanel1.ColumnCount = 4
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Main_Destination, 1, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.Main_DestinationLabel, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.Main_Source, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Main_SourceLabel, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Main_FileTypes, 3, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Main_FileTypesLabel, 2, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Main_Method, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Main_MethodLabel, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Main_LimitedCopy, 3, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Main_LimitedCopyLabel, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Main_Name, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Main_NameLabel, 0, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(12, 6)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 4
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(331, 114)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'Main_Destination
        '
        Me.Main_Destination.AutoSize = True
        Me.TableLayoutPanel1.SetColumnSpan(Me.Main_Destination, 3)
        Me.Main_Destination.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Main_Destination.Location = New System.Drawing.Point(87, 85)
        Me.Main_Destination.Name = "Main_Destination"
        Me.Main_Destination.Size = New System.Drawing.Size(240, 28)
        Me.Main_Destination.TabIndex = 11
        Me.Main_Destination.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Main_DestinationLabel
        '
        Me.Main_DestinationLabel.AutoSize = True
        Me.Main_DestinationLabel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Main_DestinationLabel.Location = New System.Drawing.Point(4, 85)
        Me.Main_DestinationLabel.Name = "Main_DestinationLabel"
        Me.Main_DestinationLabel.Size = New System.Drawing.Size(76, 28)
        Me.Main_DestinationLabel.TabIndex = 10
        Me.Main_DestinationLabel.Text = "Destination:"
        Me.Main_DestinationLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Main_Source
        '
        Me.Main_Source.AutoSize = True
        Me.TableLayoutPanel1.SetColumnSpan(Me.Main_Source, 3)
        Me.Main_Source.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Main_Source.Location = New System.Drawing.Point(87, 57)
        Me.Main_Source.Name = "Main_Source"
        Me.Main_Source.Size = New System.Drawing.Size(240, 27)
        Me.Main_Source.TabIndex = 9
        Me.Main_Source.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Main_SourceLabel
        '
        Me.Main_SourceLabel.AutoSize = True
        Me.Main_SourceLabel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Main_SourceLabel.Location = New System.Drawing.Point(4, 57)
        Me.Main_SourceLabel.Name = "Main_SourceLabel"
        Me.Main_SourceLabel.Size = New System.Drawing.Size(76, 27)
        Me.Main_SourceLabel.TabIndex = 8
        Me.Main_SourceLabel.Text = "Source:"
        Me.Main_SourceLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Main_FileTypes
        '
        Me.Main_FileTypes.AutoSize = True
        Me.Main_FileTypes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Main_FileTypes.Location = New System.Drawing.Point(271, 29)
        Me.Main_FileTypes.Name = "Main_FileTypes"
        Me.Main_FileTypes.Size = New System.Drawing.Size(56, 27)
        Me.Main_FileTypes.TabIndex = 7
        Me.Main_FileTypes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Main_FileTypesLabel
        '
        Me.Main_FileTypesLabel.AutoSize = True
        Me.Main_FileTypesLabel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Main_FileTypesLabel.Location = New System.Drawing.Point(180, 29)
        Me.Main_FileTypesLabel.Name = "Main_FileTypesLabel"
        Me.Main_FileTypesLabel.Size = New System.Drawing.Size(84, 27)
        Me.Main_FileTypesLabel.TabIndex = 6
        Me.Main_FileTypesLabel.Text = "Filetypes:"
        Me.Main_FileTypesLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Main_Method
        '
        Me.Main_Method.AutoSize = True
        Me.Main_Method.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Main_Method.Location = New System.Drawing.Point(87, 29)
        Me.Main_Method.Name = "Main_Method"
        Me.Main_Method.Size = New System.Drawing.Size(86, 27)
        Me.Main_Method.TabIndex = 5
        Me.Main_Method.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Main_MethodLabel
        '
        Me.Main_MethodLabel.AutoSize = True
        Me.Main_MethodLabel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Main_MethodLabel.Location = New System.Drawing.Point(4, 29)
        Me.Main_MethodLabel.Name = "Main_MethodLabel"
        Me.Main_MethodLabel.Size = New System.Drawing.Size(76, 27)
        Me.Main_MethodLabel.TabIndex = 4
        Me.Main_MethodLabel.Text = "Method:"
        Me.Main_MethodLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Main_LimitedCopy
        '
        Me.Main_LimitedCopy.AutoSize = True
        Me.Main_LimitedCopy.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Main_LimitedCopy.Location = New System.Drawing.Point(271, 1)
        Me.Main_LimitedCopy.Name = "Main_LimitedCopy"
        Me.Main_LimitedCopy.Size = New System.Drawing.Size(56, 27)
        Me.Main_LimitedCopy.TabIndex = 3
        Me.Main_LimitedCopy.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Main_LimitedCopyLabel
        '
        Me.Main_LimitedCopyLabel.AutoSize = True
        Me.Main_LimitedCopyLabel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Main_LimitedCopyLabel.Location = New System.Drawing.Point(180, 1)
        Me.Main_LimitedCopyLabel.Name = "Main_LimitedCopyLabel"
        Me.Main_LimitedCopyLabel.Size = New System.Drawing.Size(84, 27)
        Me.Main_LimitedCopyLabel.TabIndex = 2
        Me.Main_LimitedCopyLabel.Text = "Limited copy:"
        Me.Main_LimitedCopyLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Main_Name
        '
        Me.Main_Name.AutoSize = True
        Me.Main_Name.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Main_Name.Location = New System.Drawing.Point(87, 1)
        Me.Main_Name.Name = "Main_Name"
        Me.Main_Name.Size = New System.Drawing.Size(86, 27)
        Me.Main_Name.TabIndex = 1
        Me.Main_Name.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Main_NameLabel
        '
        Me.Main_NameLabel.AutoSize = True
        Me.Main_NameLabel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Main_NameLabel.Location = New System.Drawing.Point(4, 1)
        Me.Main_NameLabel.Name = "Main_NameLabel"
        Me.Main_NameLabel.Size = New System.Drawing.Size(76, 27)
        Me.Main_NameLabel.TabIndex = 0
        Me.Main_NameLabel.Text = "Name:"
        Me.Main_NameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Main_ActionsMenu
        '
        Me.Main_ActionsMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PreviewMenuItem, Me.SynchronizeMenuItem, Me.Main_ChangeSettingsMenuItem, Me.ToolStripSeparator1, Me.DeleteToolStripMenuItem, Me.ViewLogMenuItem})
        Me.Main_ActionsMenu.Name = "Main_ActionsMenu"
        Me.Main_ActionsMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.Main_ActionsMenu.Size = New System.Drawing.Size(165, 120)
        '
        'PreviewMenuItem
        '
        Me.PreviewMenuItem.Image = CType(resources.GetObject("PreviewMenuItem.Image"), System.Drawing.Image)
        Me.PreviewMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.PreviewMenuItem.Name = "PreviewMenuItem"
        Me.PreviewMenuItem.Size = New System.Drawing.Size(164, 22)
        Me.PreviewMenuItem.Text = "Preview"
        '
        'SynchronizeMenuItem
        '
        Me.SynchronizeMenuItem.Image = CType(resources.GetObject("SynchronizeMenuItem.Image"), System.Drawing.Image)
        Me.SynchronizeMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.SynchronizeMenuItem.Name = "SynchronizeMenuItem"
        Me.SynchronizeMenuItem.Size = New System.Drawing.Size(164, 22)
        Me.SynchronizeMenuItem.Text = "Synchronize"
        '
        'Main_ChangeSettingsMenuItem
        '
        Me.Main_ChangeSettingsMenuItem.Image = CType(resources.GetObject("Main_ChangeSettingsMenuItem.Image"), System.Drawing.Image)
        Me.Main_ChangeSettingsMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.Main_ChangeSettingsMenuItem.Name = "Main_ChangeSettingsMenuItem"
        Me.Main_ChangeSettingsMenuItem.Size = New System.Drawing.Size(164, 22)
        Me.Main_ChangeSettingsMenuItem.Text = "Change Settings"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(161, 6)
        '
        'DeleteToolStripMenuItem
        '
        Me.DeleteToolStripMenuItem.Image = CType(resources.GetObject("DeleteToolStripMenuItem.Image"), System.Drawing.Image)
        Me.DeleteToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem"
        Me.DeleteToolStripMenuItem.Size = New System.Drawing.Size(164, 22)
        Me.DeleteToolStripMenuItem.Text = "Delete"
        '
        'ViewLogMenuItem
        '
        Me.ViewLogMenuItem.Image = CType(resources.GetObject("ViewLogMenuItem.Image"), System.Drawing.Image)
        Me.ViewLogMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ViewLogMenuItem.Name = "ViewLogMenuItem"
        Me.ViewLogMenuItem.Size = New System.Drawing.Size(164, 22)
        Me.ViewLogMenuItem.Text = "View log"
        '
        'BackgroundWorker1
        '
        Me.BackgroundWorker1.WorkerSupportsCancellation = True
        '
        'Main_AboutLinkLabel
        '
        Me.Main_AboutLinkLabel.AutoSize = True
        Me.Main_AboutLinkLabel.BackColor = System.Drawing.SystemColors.Window
        Me.Main_AboutLinkLabel.Location = New System.Drawing.Point(314, 3)
        Me.Main_AboutLinkLabel.Name = "Main_AboutLinkLabel"
        Me.Main_AboutLinkLabel.Size = New System.Drawing.Size(40, 13)
        Me.Main_AboutLinkLabel.TabIndex = 2
        Me.Main_AboutLinkLabel.TabStop = True
        Me.Main_AboutLinkLabel.Text = "About"
        Me.Main_AboutLinkLabel.VisitedLinkColor = System.Drawing.Color.Blue
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(355, 400)
        Me.Controls.Add(Me.Main_AboutLinkLabel)
        Me.Controls.Add(Me.Main_Actions)
        Me.Controls.Add(Me.Main_InfoPanel)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.Name = "MainForm"
        Me.Text = "Create Synchronicity"
        Me.Main_InfoPanel.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.Main_ActionsMenu.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Main_Actions As System.Windows.Forms.ListView
    Friend WithEvents Main_InfoPanel As System.Windows.Forms.Panel
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
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
    Friend WithEvents Main_ChangeSettingsMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ViewLogMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Main_SyncIcons As System.Windows.Forms.ImageList
    Friend WithEvents Actions_NameColumn As System.Windows.Forms.ColumnHeader
    Friend WithEvents Main_MethodsColumn As System.Windows.Forms.ColumnHeader
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents DeleteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents Main_AboutLinkLabel As System.Windows.Forms.LinkLabel
End Class
