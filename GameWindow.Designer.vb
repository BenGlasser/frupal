<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class GameWindow
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(GameWindow))
        Me.Sprites = New System.Windows.Forms.ImageList(Me.components)
        Me.Inventory = New System.Windows.Forms.ListBox()
        Me.MenuStrip = New System.Windows.Forms.MenuStrip()
        Me.ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NewToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.SaveToolStripMenuItem4 = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveAsToolStripMenuItem5 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.ExitToolStripMenuItem6 = New System.Windows.Forms.ToolStripMenuItem()
        Me.FileMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.NewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.toolStripSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.SaveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveAsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.toolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenFile = New System.Windows.Forms.OpenFileDialog()
        Me.WhiffleAmt = New System.Windows.Forms.Label()
        Me.WhifflesLabel = New System.Windows.Forms.Label()
        Me.EnergyAmt = New System.Windows.Forms.Label()
        Me.EnergyLabel = New System.Windows.Forms.Label()
        Me.upButton = New System.Windows.Forms.Button()
        Me.DownButton = New System.Windows.Forms.Button()
        Me.LeftButton = New System.Windows.Forms.Button()
        Me.RightButton = New System.Windows.Forms.Button()
        Me.GamePanel = New System.Windows.Forms.Panel()
        Me.InventoryBorder = New System.Windows.Forms.GroupBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.ExploreMap = New System.Windows.Forms.PictureBox()
        Me.rightArrow = New System.Windows.Forms.PictureBox()
        Me.leftArrow = New System.Windows.Forms.PictureBox()
        Me.downArrow = New System.Windows.Forms.PictureBox()
        Me.upArrow = New System.Windows.Forms.PictureBox()
        Me.SaveGame = New System.Windows.Forms.SaveFileDialog()
        Me.CloseButton = New System.Windows.Forms.PictureBox()
        Me.MenuStrip.SuspendLayout()
        Me.InventoryBorder.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.ExploreMap, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.rightArrow, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.leftArrow, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.downArrow, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.upArrow, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CloseButton, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Sprites
        '
        Me.Sprites.ImageStream = CType(resources.GetObject("Sprites.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.Sprites.TransparentColor = System.Drawing.Color.Transparent
        Me.Sprites.Images.SetKeyName(0, "meadow")
        Me.Sprites.Images.SetKeyName(1, "forest")
        Me.Sprites.Images.SetKeyName(2, "water")
        Me.Sprites.Images.SetKeyName(3, "wall")
        Me.Sprites.Images.SetKeyName(4, "bog.png")
        Me.Sprites.Images.SetKeyName(5, "swamp.png")
        Me.Sprites.Images.SetKeyName(6, "Axe")
        Me.Sprites.Images.SetKeyName(7, "Binoculars")
        Me.Sprites.Images.SetKeyName(8, "Blackberry Bushes")
        Me.Sprites.Images.SetKeyName(9, "Boulder")
        Me.Sprites.Images.SetKeyName(10, "Chainsaw")
        Me.Sprites.Images.SetKeyName(11, "Chisel")
        Me.Sprites.Images.SetKeyName(12, "Hatchet")
        Me.Sprites.Images.SetKeyName(13, "Jackhammer")
        Me.Sprites.Images.SetKeyName(14, "Machete")
        Me.Sprites.Images.SetKeyName(15, "Powerbar")
        Me.Sprites.Images.SetKeyName(16, "Royal Diamonds")
        Me.Sprites.Images.SetKeyName(17, "Sledge")
        Me.Sprites.Images.SetKeyName(18, "Treasure Chest")
        Me.Sprites.Images.SetKeyName(19, "treasure chest.png")
        Me.Sprites.Images.SetKeyName(20, "Tree")
        Me.Sprites.Images.SetKeyName(21, "Hero")
        Me.Sprites.Images.SetKeyName(22, "None")
        Me.Sprites.Images.SetKeyName(23, "shears.png")
        Me.Sprites.Images.SetKeyName(24, "boat.png")
        Me.Sprites.Images.SetKeyName(25, "clue.png")
        Me.Sprites.Images.SetKeyName(26, "clue.png")
        '
        'Inventory
        '
        Me.Inventory.BackColor = System.Drawing.Color.Cornsilk
        Me.Inventory.Font = New System.Drawing.Font("Segoe Script", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Inventory.ForeColor = System.Drawing.Color.SaddleBrown
        Me.Inventory.FormattingEnabled = True
        Me.Inventory.ItemHeight = 25
        Me.Inventory.Location = New System.Drawing.Point(7, 26)
        Me.Inventory.Name = "Inventory"
        Me.Inventory.Size = New System.Drawing.Size(120, 179)
        Me.Inventory.TabIndex = 2
        '
        'MenuStrip
        '
        Me.MenuStrip.BackColor = System.Drawing.SystemColors.Control
        Me.MenuStrip.BackgroundImage = CType(resources.GetObject("MenuStrip.BackgroundImage"), System.Drawing.Image)
        Me.MenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem})
        Me.MenuStrip.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip.Name = "MenuStrip"
        Me.MenuStrip.Size = New System.Drawing.Size(1010, 24)
        Me.MenuStrip.TabIndex = 4
        Me.MenuStrip.Text = "MenuStrip"
        '
        'ToolStripMenuItem
        '
        Me.ToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NewToolStripMenuItem2, Me.OpenToolStripMenuItem, Me.ToolStripSeparator2, Me.SaveToolStripMenuItem4, Me.SaveAsToolStripMenuItem5, Me.ToolStripSeparator3, Me.ExitToolStripMenuItem6})
        Me.ToolStripMenuItem.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripMenuItem.ForeColor = System.Drawing.SystemColors.MenuText
        Me.ToolStripMenuItem.Name = "ToolStripMenuItem"
        Me.ToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.ToolStripMenuItem.Text = "&File"
        '
        'NewToolStripMenuItem2
        '
        Me.NewToolStripMenuItem2.Image = CType(resources.GetObject("NewToolStripMenuItem2.Image"), System.Drawing.Image)
        Me.NewToolStripMenuItem2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.NewToolStripMenuItem2.Name = "NewToolStripMenuItem2"
        Me.NewToolStripMenuItem2.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.N), System.Windows.Forms.Keys)
        Me.NewToolStripMenuItem2.Size = New System.Drawing.Size(152, 22)
        Me.NewToolStripMenuItem2.Text = "&New"
        '
        'OpenToolStripMenuItem
        '
        Me.OpenToolStripMenuItem.Image = CType(resources.GetObject("OpenToolStripMenuItem.Image"), System.Drawing.Image)
        Me.OpenToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.OpenToolStripMenuItem.Name = "OpenToolStripMenuItem"
        Me.OpenToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.O), System.Windows.Forms.Keys)
        Me.OpenToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.OpenToolStripMenuItem.Text = "&Open"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(149, 6)
        '
        'SaveToolStripMenuItem4
        '
        Me.SaveToolStripMenuItem4.Image = CType(resources.GetObject("SaveToolStripMenuItem4.Image"), System.Drawing.Image)
        Me.SaveToolStripMenuItem4.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.SaveToolStripMenuItem4.Name = "SaveToolStripMenuItem4"
        Me.SaveToolStripMenuItem4.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.S), System.Windows.Forms.Keys)
        Me.SaveToolStripMenuItem4.Size = New System.Drawing.Size(152, 22)
        Me.SaveToolStripMenuItem4.Text = "&Save"
        '
        'SaveAsToolStripMenuItem5
        '
        Me.SaveAsToolStripMenuItem5.Name = "SaveAsToolStripMenuItem5"
        Me.SaveAsToolStripMenuItem5.Size = New System.Drawing.Size(152, 22)
        Me.SaveAsToolStripMenuItem5.Text = "Save &As"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(149, 6)
        '
        'ExitToolStripMenuItem6
        '
        Me.ExitToolStripMenuItem6.Name = "ExitToolStripMenuItem6"
        Me.ExitToolStripMenuItem6.Size = New System.Drawing.Size(152, 22)
        Me.ExitToolStripMenuItem6.Text = "E&xit"
        '
        'FileMenu
        '
        Me.FileMenu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NewToolStripMenuItem, Me.OpenMenu, Me.toolStripSeparator, Me.SaveToolStripMenuItem, Me.SaveAsToolStripMenuItem, Me.toolStripSeparator1, Me.ExitToolStripMenuItem})
        Me.FileMenu.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FileMenu.ForeColor = System.Drawing.SystemColors.MenuText
        Me.FileMenu.Name = "FileMenu"
        Me.FileMenu.Size = New System.Drawing.Size(37, 20)
        Me.FileMenu.Text = "&File"
        '
        'NewToolStripMenuItem
        '
        Me.NewToolStripMenuItem.Image = CType(resources.GetObject("NewToolStripMenuItem.Image"), System.Drawing.Image)
        Me.NewToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.NewToolStripMenuItem.Name = "NewToolStripMenuItem"
        Me.NewToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.N), System.Windows.Forms.Keys)
        Me.NewToolStripMenuItem.Size = New System.Drawing.Size(146, 22)
        Me.NewToolStripMenuItem.Text = "&New"
        '
        'OpenMenu
        '
        Me.OpenMenu.Image = CType(resources.GetObject("OpenMenu.Image"), System.Drawing.Image)
        Me.OpenMenu.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.OpenMenu.Name = "OpenMenu"
        Me.OpenMenu.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.O), System.Windows.Forms.Keys)
        Me.OpenMenu.Size = New System.Drawing.Size(146, 22)
        Me.OpenMenu.Text = "&Open"
        '
        'toolStripSeparator
        '
        Me.toolStripSeparator.Name = "toolStripSeparator"
        Me.toolStripSeparator.Size = New System.Drawing.Size(143, 6)
        '
        'SaveToolStripMenuItem
        '
        Me.SaveToolStripMenuItem.Image = CType(resources.GetObject("SaveToolStripMenuItem.Image"), System.Drawing.Image)
        Me.SaveToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.SaveToolStripMenuItem.Name = "SaveToolStripMenuItem"
        Me.SaveToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.S), System.Windows.Forms.Keys)
        Me.SaveToolStripMenuItem.Size = New System.Drawing.Size(146, 22)
        Me.SaveToolStripMenuItem.Text = "&Save"
        '
        'SaveAsToolStripMenuItem
        '
        Me.SaveAsToolStripMenuItem.Name = "SaveAsToolStripMenuItem"
        Me.SaveAsToolStripMenuItem.Size = New System.Drawing.Size(146, 22)
        Me.SaveAsToolStripMenuItem.Text = "Save &As"
        '
        'toolStripSeparator1
        '
        Me.toolStripSeparator1.Name = "toolStripSeparator1"
        Me.toolStripSeparator1.Size = New System.Drawing.Size(143, 6)
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(146, 22)
        Me.ExitToolStripMenuItem.Text = "E&xit"
        '
        'OpenFile
        '
        Me.OpenFile.FileName = "OpenFileDialog1"
        '
        'WhiffleAmt
        '
        Me.WhiffleAmt.AutoSize = True
        Me.WhiffleAmt.BackColor = System.Drawing.Color.Transparent
        Me.WhiffleAmt.Font = New System.Drawing.Font("Segoe Script", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.WhiffleAmt.ForeColor = System.Drawing.Color.SaddleBrown
        Me.WhiffleAmt.Location = New System.Drawing.Point(225, 542)
        Me.WhiffleAmt.Name = "WhiffleAmt"
        Me.WhiffleAmt.Size = New System.Drawing.Size(0, 30)
        Me.WhiffleAmt.TabIndex = 10
        '
        'WhifflesLabel
        '
        Me.WhifflesLabel.AutoSize = True
        Me.WhifflesLabel.BackColor = System.Drawing.Color.Transparent
        Me.WhifflesLabel.Font = New System.Drawing.Font("Segoe Script", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.WhifflesLabel.ForeColor = System.Drawing.Color.SaddleBrown
        Me.WhifflesLabel.Location = New System.Drawing.Point(108, 542)
        Me.WhifflesLabel.Name = "WhifflesLabel"
        Me.WhifflesLabel.Size = New System.Drawing.Size(108, 30)
        Me.WhifflesLabel.TabIndex = 8
        Me.WhifflesLabel.Text = "Whiffles: "
        '
        'EnergyAmt
        '
        Me.EnergyAmt.AutoSize = True
        Me.EnergyAmt.BackColor = System.Drawing.Color.Transparent
        Me.EnergyAmt.Font = New System.Drawing.Font("Segoe Script", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EnergyAmt.ForeColor = System.Drawing.Color.SaddleBrown
        Me.EnergyAmt.Location = New System.Drawing.Point(225, 505)
        Me.EnergyAmt.Name = "EnergyAmt"
        Me.EnergyAmt.Size = New System.Drawing.Size(0, 30)
        Me.EnergyAmt.TabIndex = 9
        '
        'EnergyLabel
        '
        Me.EnergyLabel.AutoSize = True
        Me.EnergyLabel.BackColor = System.Drawing.Color.Transparent
        Me.EnergyLabel.Font = New System.Drawing.Font("Segoe Script", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EnergyLabel.ForeColor = System.Drawing.Color.SaddleBrown
        Me.EnergyLabel.Location = New System.Drawing.Point(108, 505)
        Me.EnergyLabel.Name = "EnergyLabel"
        Me.EnergyLabel.Size = New System.Drawing.Size(96, 30)
        Me.EnergyLabel.TabIndex = 7
        Me.EnergyLabel.Text = "Energy: "
        '
        'upButton
        '
        Me.upButton.BackgroundImage = CType(resources.GetObject("upButton.BackgroundImage"), System.Drawing.Image)
        Me.upButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.upButton.Font = New System.Drawing.Font("Segoe Print", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.upButton.ForeColor = System.Drawing.Color.Khaki
        Me.upButton.Location = New System.Drawing.Point(485, 40)
        Me.upButton.Name = "upButton"
        Me.upButton.Size = New System.Drawing.Size(480, 20)
        Me.upButton.TabIndex = 5
        Me.upButton.Text = "UP"
        Me.upButton.UseVisualStyleBackColor = True
        '
        'DownButton
        '
        Me.DownButton.BackgroundImage = CType(resources.GetObject("DownButton.BackgroundImage"), System.Drawing.Image)
        Me.DownButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.DownButton.Font = New System.Drawing.Font("Segoe Script", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DownButton.ForeColor = System.Drawing.Color.Khaki
        Me.DownButton.Location = New System.Drawing.Point(484, 552)
        Me.DownButton.Name = "DownButton"
        Me.DownButton.Size = New System.Drawing.Size(480, 20)
        Me.DownButton.TabIndex = 13
        Me.DownButton.Text = "DOWN"
        Me.DownButton.UseVisualStyleBackColor = True
        '
        'LeftButton
        '
        Me.LeftButton.BackgroundImage = CType(resources.GetObject("LeftButton.BackgroundImage"), System.Drawing.Image)
        Me.LeftButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.LeftButton.Font = New System.Drawing.Font("Segoe Print", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LeftButton.ForeColor = System.Drawing.Color.Khaki
        Me.LeftButton.Location = New System.Drawing.Point(459, 66)
        Me.LeftButton.Name = "LeftButton"
        Me.LeftButton.Size = New System.Drawing.Size(20, 480)
        Me.LeftButton.TabIndex = 11
        Me.LeftButton.Text = "LEFT"
        Me.LeftButton.UseVisualStyleBackColor = True
        '
        'RightButton
        '
        Me.RightButton.BackgroundImage = CType(resources.GetObject("RightButton.BackgroundImage"), System.Drawing.Image)
        Me.RightButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.RightButton.Font = New System.Drawing.Font("Segoe Print", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RightButton.ForeColor = System.Drawing.Color.Khaki
        Me.RightButton.Location = New System.Drawing.Point(971, 66)
        Me.RightButton.Name = "RightButton"
        Me.RightButton.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.RightButton.Size = New System.Drawing.Size(20, 480)
        Me.RightButton.TabIndex = 12
        Me.RightButton.Text = "RIGHT"
        Me.RightButton.UseVisualStyleBackColor = True
        '
        'GamePanel
        '
        Me.GamePanel.AutoScroll = True
        Me.GamePanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.GamePanel.Location = New System.Drawing.Point(485, 66)
        Me.GamePanel.Name = "GamePanel"
        Me.GamePanel.Size = New System.Drawing.Size(480, 480)
        Me.GamePanel.TabIndex = 3
        '
        'InventoryBorder
        '
        Me.InventoryBorder.BackColor = System.Drawing.Color.Transparent
        Me.InventoryBorder.Controls.Add(Me.Inventory)
        Me.InventoryBorder.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.InventoryBorder.Font = New System.Drawing.Font("Segoe Script", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.InventoryBorder.ForeColor = System.Drawing.Color.SaddleBrown
        Me.InventoryBorder.Location = New System.Drawing.Point(134, 291)
        Me.InventoryBorder.Name = "InventoryBorder"
        Me.InventoryBorder.Size = New System.Drawing.Size(134, 211)
        Me.InventoryBorder.TabIndex = 14
        Me.InventoryBorder.TabStop = False
        Me.InventoryBorder.Text = "Inventory"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.BackgroundImage = CType(resources.GetObject("Panel1.BackgroundImage"), System.Drawing.Image)
        Me.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel1.Controls.Add(Me.ExploreMap)
        Me.Panel1.Controls.Add(Me.rightArrow)
        Me.Panel1.Controls.Add(Me.leftArrow)
        Me.Panel1.Controls.Add(Me.downArrow)
        Me.Panel1.Controls.Add(Me.upArrow)
        Me.Panel1.Location = New System.Drawing.Point(525, 578)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(401, 278)
        Me.Panel1.TabIndex = 17
        '
        'ExploreMap
        '
        Me.ExploreMap.BackgroundImage = Global.Frupal.My.Resources.Resources.explore
        Me.ExploreMap.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ExploreMap.Location = New System.Drawing.Point(174, 115)
        Me.ExploreMap.Name = "ExploreMap"
        Me.ExploreMap.Size = New System.Drawing.Size(48, 48)
        Me.ExploreMap.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.ExploreMap.TabIndex = 5
        Me.ExploreMap.TabStop = False
        '
        'rightArrow
        '
        Me.rightArrow.BackgroundImage = CType(resources.GetObject("rightArrow.BackgroundImage"), System.Drawing.Image)
        Me.rightArrow.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.rightArrow.Location = New System.Drawing.Point(225, 118)
        Me.rightArrow.Name = "rightArrow"
        Me.rightArrow.Size = New System.Drawing.Size(48, 48)
        Me.rightArrow.TabIndex = 4
        Me.rightArrow.TabStop = False
        '
        'leftArrow
        '
        Me.leftArrow.BackgroundImage = CType(resources.GetObject("leftArrow.BackgroundImage"), System.Drawing.Image)
        Me.leftArrow.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.leftArrow.Location = New System.Drawing.Point(122, 118)
        Me.leftArrow.Name = "leftArrow"
        Me.leftArrow.Size = New System.Drawing.Size(48, 48)
        Me.leftArrow.TabIndex = 3
        Me.leftArrow.TabStop = False
        '
        'downArrow
        '
        Me.downArrow.BackgroundImage = CType(resources.GetObject("downArrow.BackgroundImage"), System.Drawing.Image)
        Me.downArrow.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.downArrow.Location = New System.Drawing.Point(174, 168)
        Me.downArrow.Name = "downArrow"
        Me.downArrow.Size = New System.Drawing.Size(48, 48)
        Me.downArrow.TabIndex = 1
        Me.downArrow.TabStop = False
        '
        'upArrow
        '
        Me.upArrow.BackgroundImage = CType(resources.GetObject("upArrow.BackgroundImage"), System.Drawing.Image)
        Me.upArrow.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.upArrow.Location = New System.Drawing.Point(174, 64)
        Me.upArrow.Name = "upArrow"
        Me.upArrow.Size = New System.Drawing.Size(48, 48)
        Me.upArrow.TabIndex = 0
        Me.upArrow.TabStop = False
        '
        'CloseButton
        '
        Me.CloseButton.Image = Global.Frupal.My.Resources.Resources.Actions_application_exit_icon
        Me.CloseButton.Location = New System.Drawing.Point(985, 4)
        Me.CloseButton.Margin = New System.Windows.Forms.Padding(0)
        Me.CloseButton.Name = "CloseButton"
        Me.CloseButton.Size = New System.Drawing.Size(16, 16)
        Me.CloseButton.TabIndex = 19
        Me.CloseButton.TabStop = False
        '
        'GameWindow
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.ClientSize = New System.Drawing.Size(1010, 858)
        Me.Controls.Add(Me.CloseButton)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.InventoryBorder)
        Me.Controls.Add(Me.GamePanel)
        Me.Controls.Add(Me.WhiffleAmt)
        Me.Controls.Add(Me.DownButton)
        Me.Controls.Add(Me.upButton)
        Me.Controls.Add(Me.WhifflesLabel)
        Me.Controls.Add(Me.RightButton)
        Me.Controls.Add(Me.LeftButton)
        Me.Controls.Add(Me.EnergyAmt)
        Me.Controls.Add(Me.EnergyLabel)
        Me.Controls.Add(Me.MenuStrip)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip
        Me.Name = "GameWindow"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Frupal - Ben Glasser - WP3"
        Me.MenuStrip.ResumeLayout(False)
        Me.MenuStrip.PerformLayout()
        Me.InventoryBorder.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.ExploreMap, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rightArrow, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.leftArrow, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.downArrow, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.upArrow, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CloseButton, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Sprites As System.Windows.Forms.ImageList
    Friend WithEvents Inventory As System.Windows.Forms.ListBox
    Friend WithEvents MenuStrip As System.Windows.Forms.MenuStrip
    Friend WithEvents FileMenu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NewToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OpenMenu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents toolStripSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents SaveToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SaveAsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents toolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OpenFile As System.Windows.Forms.OpenFileDialog
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents EnergyLabel As System.Windows.Forms.Label
    Friend WithEvents WhifflesLabel As System.Windows.Forms.Label
    Friend WithEvents EnergyAmt As System.Windows.Forms.Label
    Friend WithEvents WhiffleAmt As System.Windows.Forms.Label
    Friend WithEvents upButton As System.Windows.Forms.Button
    Friend WithEvents DownButton As System.Windows.Forms.Button
    Friend WithEvents LeftButton As System.Windows.Forms.Button
    Friend WithEvents RightButton As System.Windows.Forms.Button
    Friend WithEvents GamePanel As System.Windows.Forms.Panel
    Friend WithEvents InventoryBorder As System.Windows.Forms.GroupBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents leftArrow As System.Windows.Forms.PictureBox
    Friend WithEvents downArrow As System.Windows.Forms.PictureBox
    Friend WithEvents upArrow As System.Windows.Forms.PictureBox
    Friend WithEvents rightArrow As System.Windows.Forms.PictureBox
    Friend WithEvents SaveGame As System.Windows.Forms.SaveFileDialog
    Friend WithEvents ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NewToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OpenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents SaveToolStripMenuItem4 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SaveAsToolStripMenuItem5 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ExitToolStripMenuItem6 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExploreMap As System.Windows.Forms.PictureBox
    Friend WithEvents CloseButton As System.Windows.Forms.PictureBox

End Class
