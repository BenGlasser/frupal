Imports System.IO

' Author: Ben Glasser, Jeff Fung, Evan Messinger, Ruvim Micsanschi, Ryan Larson
' Date: 12-09-11
' File: GameWindow.vb
' Purpose: creates main user interface


Public Class GameWindow
    Inherits System.Windows.Forms.Form
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(GameWindow))
#Region "API Declarations"
    Private Declare Sub ReleaseCapture Lib "user32" ()
    Private Declare Sub SendMessage Lib "user32" Alias "SendMessageA" (ByVal _
    hWnd As Integer, ByVal wMsg As Integer, ByVal wParam As Integer, _
    ByVal lParam As Integer)

    Private Const WM_NCLBUTTONDOWN As Integer = &HA1
    Private Const HTCAPTION As Integer = 2
#End Region


    ' enumerate types of land for readability
    Enum SPRITES_
        MEADOW = 0
        FOREST = 1
        WATER = 2
        WALL = 3
        BOG = 4
        SWAMP = 5
        AXE = 6
        BINOCULAR = 7
        BLACKBERRY_BUSHES = 8
        BOULDER = 9
        CHAINSAW = 10
        CHISEL = 11
        HATCHET = 12
        JACKHAMMER = 13
        MACHETE = 14
        POWERBAR = 15
        ROYAL_DIAMONDS = 16
        SLEDGE = 17
        TREASURE_CHEST_1 = 18
        TREASURE_CHEST_2 = 19
        TREE = 20
        HERO = 21
        NONE = 22
        SHEARS = 23
        BOAT = 24
        CLUE = 25
        TRUE_CLUE = 26
    End Enum
    ' determine enumerated values by string
    Private Function contentEnum(ByVal content As String)
        Select Case (content.ToLower)
            Case "axe"
                Return SPRITES_.AXE
            Case "binoculars"
                Return SPRITES_.BINOCULAR
            Case "blackberry bushes"
                Return SPRITES_.BLACKBERRY_BUSHES
            Case "boulder"
                Return SPRITES_.BOULDER
            Case "chainsaw"
                Return SPRITES_.CHAINSAW
            Case "chisel"
                Return SPRITES_.CHISEL
            Case "hatchet"
                Return SPRITES_.HATCHET
            Case "jackhammer"
                Return SPRITES_.JACKHAMMER
            Case "machete"
                Return SPRITES_.MACHETE
            Case "power bar"
                Return SPRITES_.POWERBAR
            Case "royal diamonds"
                Return SPRITES_.ROYAL_DIAMONDS
            Case "sledge"
                Return SPRITES_.SLEDGE
            Case "treasure chest"
                Return SPRITES_.TREASURE_CHEST_1
            Case "type 1 treasure chest"
                Return SPRITES_.TREASURE_CHEST_1
            Case "type 2 treasure chest"
                Return SPRITES_.TREASURE_CHEST_2
            Case "tree"
                Return SPRITES_.TREE
            Case "none"
                Return SPRITES_.NONE
            Case "shears"
                Return SPRITES_.SHEARS
            Case "boat"
                Return SPRITES_.BOAT
            Case "swamp"
                Return SPRITES_.SWAMP
            Case "bog"
                Return SPRITES_.BOG
            Case "clue"
                Return SPRITES_.CLUE
            Case "true clue"
                Return SPRITES_.TRUE_CLUE
        End Select

        Return SPRITES_.NONE
    End Function

    ' game variables.
    Dim GameMap As Map = New Map()
    Dim loc As Point = New Point(0, 0)
    Dim WindowLocation As Point = New Point(0, 0)
    Dim LoadHero As Boolean = 0
    Dim mapFile As String
    Dim up As Boolean
    Dim down As Boolean
    Dim rt As Boolean
    Dim lt As Boolean
    Dim mapReDrawn As Boolean

    ' GamePanel_Paint paints the board to GamePanel
    Private Sub GamePanel_Paint() Handles GamePanel.Paint
        Dim location As Point = New Point(0, 0)
        For i As Integer = WindowLocation.Y To (WindowLocation.Y + 9)
            location.Y = i
            For j As Integer = WindowLocation.X To (WindowLocation.X + 9)
                location.X = j
                drawCell(GamePanel.CreateGraphics, location)
            Next
        Next
        If LoadHero Then
            drawHero(GamePanel.CreateGraphics, GameMap.GetHeroLocation())
        End If
        EnergyAmt.Text = GameMap.GetEnergy
        WhiffleAmt.Text = GameMap.GetWhiffles
    End Sub

    ' draws a specified cell to the the given graphics
    Public Sub drawCell(ByVal g As Graphics, ByVal loc As Point)
        ' first draw terrain
        If (Not GameMap.cellIsVisible(loc)) Then
            Sprites.Draw(g, setPos(loc), SPRITES_.NONE)
        Else
            Sprites.Draw(g, setPos(loc), GameMap.getCellTerrain(loc))
            ' then draw content
            If (Not (GameMap.getCellContent(loc).ToLower.Equals("none"))) Then
                Dim str As String = GameMap.getCellContent(loc)
                Dim eq As Boolean = GameMap.getCellContent(loc).ToLower.Equals("none")
                Sprites.Draw(g, setPos(loc), contentEnum(GameMap.getCellContent(loc)))
            End If
        End If
    End Sub

    ' this function tranaslates locations on the gameboard into positions on the screen
    Private Function setPos(ByVal loc As Point) As Point
        Dim position As Point = New Point
        position.X = (loc.X - WindowLocation.X) * Sprites.ImageSize.Width
        position.Y = (loc.Y - WindowLocation.Y) * Sprites.ImageSize.Height
        Return position
    End Function

    ' from toolbar selection open file
    Private Sub OpenMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenMenu.Click
        Dim didWork As Integer

        OpenFile.Filter = "Map(*.map)|*.map|Text(*.txt)|*.txt|All Files(*.*)|*.*"
        didWork = OpenFile.ShowDialog()

        If Not didWork = Windows.Forms.DialogResult.Cancel Then
            mapFile = OpenFile.FileName
            GameMap = New Map(mapFile)
        End If
        WindowLocation = New Point(0, 0)
        LoadHero = True
        GamePanel.Invalidate()
        GamePanel_Paint()
    End Sub

    ' Draw hero at specified coords
    Private Sub drawHero(ByVal g As Graphics, ByVal loc As Point)
        Sprites.Draw(g, setPos(loc), SPRITES_.HERO)
    End Sub

    'Map viewing window directional buttons
    Private Sub upButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles upButton.Click
        If WindowLocation.Y > 0 Then
            WindowLocation.Y -= 1
            GamePanel.Invalidate()
            GamePanel_Paint()
        End If
    End Sub

    Private Sub DownButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DownButton.Click
        If WindowLocation.Y < (GameMap.getDimension - 10) Then
            WindowLocation.Y += 1
            GamePanel.Invalidate()
            GamePanel_Paint()
        End If
    End Sub

    Private Sub LeftButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LeftButton.Click
        If WindowLocation.X > 0 Then
            WindowLocation.X -= 1
            GamePanel.Invalidate()
            GamePanel_Paint()
        End If
    End Sub

    Private Sub RightButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RightButton.Click
        If WindowLocation.X < (GameMap.getDimension - 10) Then
            WindowLocation.X += 1
            GamePanel.Invalidate()
            GamePanel_Paint()
        End If
    End Sub


    Private Sub Hero_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress

        Select Case e.KeyChar
            ' move right
            Case ChrW(Keys.D)
                GameMap.MoveHeroHorizontal(1)
            Case ChrW(Keys.Right)
                GameMap.MoveHeroHorizontal(1)
                ' move left
            Case ChrW(Keys.A)
                GameMap.MoveHeroHorizontal(-1)
            Case ChrW(Keys.Left)
                GameMap.MoveHeroHorizontal(-1)
                ' move up
            Case ChrW(Keys.W)
                GameMap.MoveHeroVertical(-1)
            Case ChrW(Keys.Up)
                GameMap.MoveHeroVertical(-1)
                ' move Down
            Case ChrW(Keys.S)
                GameMap.MoveHeroVertical(1)
            Case ChrW(Keys.Down)
                GameMap.MoveHeroVertical(1)
        End Select
        GamePanel.Invalidate()
        GamePanel_Paint()
    End Sub



    ' *********************************************************[ BEN GLASSER & JEFF FUNG ]*********************************************************
    Private Sub Menu_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MenuStrip.MouseDown
        If e.Button = MouseButtons.Left Then
            ReleaseCapture()
            SendMessage(Me.Handle.ToInt32, WM_NCLBUTTONDOWN, HTCAPTION, 0&)
        End If
    End Sub
    ' left arrow functions 
    Private Sub leftArrow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles leftArrow.Click
        mapReDrawn = False
        up = False
        down = False
        lt = True
        rt = False

        GameMap.MoveHeroHorizontal(-1)
        If (GameMap.GetHeroLocation.X < (WindowLocation.X + 3)) Then
            LeftButton_Click(sender, e)
        End If

        If (Not GameMap.getExceptionValue()) Then
            GamePanel.Invalidate()
            GamePanel_Paint()
            EnergyAmt.Text = GameMap.GetEnergy()
            WhiffleAmt.Text = GameMap.GetWhiffles()
            lt = False
            GameMap.setToolChosen(Nothing)
            Inventory.SelectedItem = Nothing
            'Inventory.Visible = False
        End If

    End Sub
    Private Sub leftArrow_Hover(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles leftArrow.MouseHover
        leftArrow.BackgroundImage = CType(My.Resources.leftHover, System.Drawing.Image)
    End Sub
    Private Sub leftArrow_Out(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles leftArrow.MouseLeave
        leftArrow.BackgroundImage = CType(resources.GetObject("leftArrow.BackgroundImage"), System.Drawing.Image)
    End Sub
    Private Sub leftArrow_MouseDown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles leftArrow.MouseDown
        leftArrow.BackgroundImage = CType(My.Resources.leftClick, System.Drawing.Image)
    End Sub
    Private Sub leftArrow_MouseUp(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles leftArrow.MouseUp
        leftArrow.BackgroundImage = CType(My.Resources.leftHover, System.Drawing.Image)
    End Sub
    ' right arrow functions
    Private Sub rightArrow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rightArrow.Click
        up = False
        down = False
        lt = False
        rt = True

        GameMap.MoveHeroHorizontal(1)

        If (GameMap.GetHeroLocation.X > (WindowLocation.X + 7)) Then
            RightButton_Click(sender, e)
        End If

        If (Not GameMap.getExceptionValue()) Then
            GamePanel.Invalidate()
            GamePanel_Paint()
            EnergyAmt.Text = GameMap.GetEnergy()
            WhiffleAmt.Text = GameMap.GetWhiffles()
            rt = False
            GameMap.setToolChosen(Nothing)
            Inventory.SelectedItem = Nothing
            'Inventory.Visible = False

        End If

    End Sub
    Private Sub rightArrow_Hover(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rightArrow.MouseHover
        rightArrow.BackgroundImage = CType(My.Resources.rightHover, System.Drawing.Image)
    End Sub
    Private Sub rightArrow_Out(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rightArrow.MouseLeave
        rightArrow.BackgroundImage = CType(resources.GetObject("rightArrow.BackgroundImage"), System.Drawing.Image)
    End Sub
    Private Sub rightArrow_MouseDown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rightArrow.MouseDown
        rightArrow.BackgroundImage = CType(My.Resources.rightClick, System.Drawing.Image)
    End Sub
    Private Sub rightArrow_MouseUp(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rightArrow.MouseUp
        rightArrow.BackgroundImage = CType(My.Resources.rightHover, System.Drawing.Image)
    End Sub
    'up Arrow functions
    Private Sub upArrow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles upArrow.Click
        up = True
        down = False
        lt = False
        rt = False

        GameMap.MoveHeroVertical(-1)
        If (GameMap.GetHeroLocation.Y < (WindowLocation.Y + 3)) Then
            upButton_Click(sender, e)
        End If

        If (Not GameMap.getExceptionValue()) Then
            GamePanel.Invalidate()
            GamePanel_Paint()
            EnergyAmt.Text = GameMap.GetEnergy()
            WhiffleAmt.Text = GameMap.GetWhiffles()
            up = False
            GameMap.setToolChosen(Nothing)
            Inventory.SelectedItem = Nothing
            'Inventory.Visible = False
        End If
    End Sub
    Private Sub upArrow_Hover(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles upArrow.MouseHover
        upArrow.BackgroundImage = CType(My.Resources.upHover, System.Drawing.Image)
    End Sub
    Private Sub upArrow_Out(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles upArrow.MouseLeave
        upArrow.BackgroundImage = CType(resources.GetObject("upArrow.BackgroundImage"), System.Drawing.Image)
    End Sub
    Private Sub upArrow_MouseDown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles upArrow.MouseDown
        upArrow.BackgroundImage = CType(My.Resources.upClick, System.Drawing.Image)
    End Sub
    Private Sub upArrow_MouseUp(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles upArrow.MouseUp
        upArrow.BackgroundImage = CType(My.Resources.upHover, System.Drawing.Image)
    End Sub
    'down arrow functions
    Private Sub downArrow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles downArrow.Click
        up = False
        down = True
        lt = False
        rt = False

        GameMap.MoveHeroVertical(1)
        If (GameMap.GetHeroLocation.Y > (WindowLocation.Y + 7)) Then
            DownButton_Click(sender, e)
        End If

        If (Not GameMap.getExceptionValue()) Then
            GamePanel.Invalidate()
            GamePanel_Paint()
            EnergyAmt.Text = GameMap.GetEnergy()
            WhiffleAmt.Text = GameMap.GetWhiffles()
            down = False
            GameMap.setToolChosen(Nothing)
            Inventory.SelectedItem = Nothing
            'Inventory.Visible = False
        End If

    End Sub
    Private Sub downArrow_Hover(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles downArrow.MouseHover
        downArrow.BackgroundImage = CType(My.Resources.downHover, System.Drawing.Image)
    End Sub
    Private Sub downArrow_Out(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles downArrow.MouseLeave
        downArrow.BackgroundImage = CType(resources.GetObject("downArrow.BackgroundImage"), System.Drawing.Image)
    End Sub
    Private Sub downArrow_MouseDown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles downArrow.MouseDown
        downArrow.BackgroundImage = CType(My.Resources.downClick, System.Drawing.Image)
    End Sub
    Private Sub downArrow_MouseUp(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles downArrow.MouseUp
        downArrow.BackgroundImage = CType(My.Resources.downHover, System.Drawing.Image)
    End Sub

    Private Sub SaveAsToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveAsToolStripMenuItem.Click
        Dim myStream As Stream
        Dim myString As String = GameMap.ToString()
        Dim buff As New System.Text.UTF8Encoding

        SaveGame.Filter = "txt files (*.txt)|*.txt|Map files (*.map)|*.map"
        SaveGame.FilterIndex = 2
        SaveGame.RestoreDirectory = True

        If SaveGame.ShowDialog() = DialogResult.OK Then
            myStream = SaveGame.OpenFile()
            If (myStream IsNot Nothing) Then
                myStream.Write(buff.GetBytes(myString), 0, buff.GetBytes(myString).Count)
                myStream.Close()
            End If
        End If
    End Sub

    ' *********************************************************[ new tool strip menu items ]*********************************************************

    Sub NewToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewToolStripMenuItem2.Click
        Inventory.Visible = True
        Inventory.Items.Clear()
        GameMap = New Map()
        GameMap.Random("Random Map", 10, 25)
        WindowLocation = New Point(0, 0)
        LoadHero = True
        GamePanel_Paint()

    End Sub

    Sub OpenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenToolStripMenuItem.Click
        Inventory.Visible = True
        Dim didWork As Integer

        OpenFile.Filter = "Map(*.map)|*.map|Text(*.txt)|*.txt|All Files(*.*)|*.*"
        didWork = OpenFile.ShowDialog()

        If Not didWork = Windows.Forms.DialogResult.Cancel Then
            mapFile = OpenFile.FileName
            GameMap = New Map(mapFile)
        End If
        WindowLocation = New Point(0, 0)
        LoadHero = True
        EnergyAmt.Text = GameMap.GetEnergy
        WhiffleAmt.Text = GameMap.GetWhiffles
        GamePanel.Invalidate()
        GamePanel_Paint()

    End Sub

    Private Sub SaveToolStripMenuItem4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveToolStripMenuItem4.Click
        Dim myStream As New StreamWriter(mapFile)
        Dim myString As String = GameMap.ToString()
        myStream.WriteLine(myString)
        myStream.Close()
    End Sub

    Private Sub SaveAsToolStripMenuItem5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveAsToolStripMenuItem5.Click
        Dim myStream As Stream
        Dim myString As String = GameMap.ToString()
        Dim buff As New System.Text.UTF8Encoding

        SaveGame.Filter = "txt files (*.txt)|*.txt|Map files (*.map)|*.map"
        SaveGame.FilterIndex = 2
        SaveGame.RestoreDirectory = True

        If SaveGame.ShowDialog() = DialogResult.OK Then
            myStream = SaveGame.OpenFile()
            mapFile = SaveGame.FileName
            If (myStream IsNot Nothing) Then
                myStream.Write(buff.GetBytes(myString), 0, buff.GetBytes(myString).Count)
                myStream.Close()
            End If
        End If

    End Sub
    Private Sub ExitToolStripMenuItem6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem6.Click
        Me.Close()
    End Sub
    Private Sub CloseButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CloseButton.Click
        Me.Close()
    End Sub
    ' ********************************************************[ RUVIM MICSANSCHI ]************************************************************
    Private Sub ExploreMap_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExploreMap.Click
        GameMap.LookingAround(Me.Inventory.FindStringExact("binoculars"))
        GamePanel_Paint()
    End Sub

    ' ********************************************************[ EVAN MESSINGER ]************************************************************
    Private Sub GameWindow_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        GameStart.Show()
        Inventory.Visible = False
        Inventory.Enabled = False
        initializeHashes()
    End Sub

    Public ToolWhiffleCost As New Hashtable()
    'turns a tool string into its whiffle cost

    Private Sub initializeHashes() 'do this on form load
        Me.ToolWhiffleCost.Add("power bar", 1)
        Me.ToolWhiffleCost.Add("treasure chest", 100)
        Me.ToolWhiffleCost.Add("hatchet", 15)
        Me.ToolWhiffleCost.Add("axe", 30)
        Me.ToolWhiffleCost.Add("chainsaw", 60)
        Me.ToolWhiffleCost.Add("chisel", 5)
        Me.ToolWhiffleCost.Add("sledge", 25)
        Me.ToolWhiffleCost.Add("jackhammer", 100)
        Me.ToolWhiffleCost.Add("machete", 25)
        Me.ToolWhiffleCost.Add("shears", 35)
        Me.ToolWhiffleCost.Add("binoculars", 50)
        Me.ToolWhiffleCost.Add("boat", 250)
        Me.ToolWhiffleCost.Add("clue", 25)
    End Sub


    Public Sub updateEnergy() 'this is called to update energy onscreen whenever energy changes during a game
        EnergyAmt.Text = GameMap.GetEnergy
    End Sub

    Public Sub updateWhiffles() 'this is called to update whiffles onscreen whenever energy changes during a game
        WhiffleAmt.Text = GameMap.GetWhiffles
    End Sub


    ' ********************************************************[ JEFF FUNG ]************************************************************
    Private Sub Inventory_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Inventory.SelectedIndexChanged
        Dim tempString As String = Nothing
        If (Inventory.SelectedItem <> Nothing) Then
            tempString = Inventory.SelectedItem
            tempString = tempString.ToLower
        End If
        GameMap.setToolChosen(tempString)

        If (up And GameMap.getAutoValue()) Then
            GameMap.MoveHeroVertical(-1)
            GamePanel.Invalidate()
            GamePanel_Paint()
            EnergyAmt.Text = GameMap.GetEnergy()
            WhiffleAmt.Text = GameMap.GetWhiffles()
            up = False
            GameMap.setToolChosen(Nothing)
            Inventory.SelectedItem = Nothing
        End If

        If (down And GameMap.getAutoValue()) Then
            GameMap.MoveHeroVertical(1)
            GamePanel.Invalidate()
            GamePanel_Paint()
            EnergyAmt.Text = GameMap.GetEnergy()
            WhiffleAmt.Text = GameMap.GetWhiffles()
            down = False
            GameMap.setToolChosen(Nothing)
            Inventory.SelectedItem = Nothing
        End If

        If (lt And GameMap.getAutoValue()) Then
            GameMap.MoveHeroHorizontal(-1)
            GamePanel.Invalidate()
            GamePanel_Paint()
            EnergyAmt.Text = GameMap.GetEnergy()
            WhiffleAmt.Text = GameMap.GetWhiffles()
            lt = False
            GameMap.setToolChosen(Nothing)
            Inventory.SelectedItem = Nothing
        End If

        If (rt And GameMap.getAutoValue()) Then
            GameMap.MoveHeroHorizontal(1)
            GamePanel.Invalidate()
            GamePanel_Paint()
            EnergyAmt.Text = GameMap.GetEnergy()
            WhiffleAmt.Text = GameMap.GetWhiffles()
            rt = False
            GameMap.setToolChosen(Nothing)
            Inventory.SelectedItem = Nothing
        End If
    End Sub
End Class
