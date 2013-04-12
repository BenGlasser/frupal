' Author: Ben Glasser, Jeff Fung, Evan Messinger, Ruvim Micsanschi, Ryan Larson
' Date: 12-09-11
' File: Map.vb
' Purpose: parses a saved map file inorder to load a valid map for the game

Imports System.IO
Imports Frupal.Cell

<Serializable()> Public Class Map
    Const numberOfObstacles = 3
    Const numberOfTools = 9

    ' define Map Vars
    'Bool for boat or no boat
    Dim Boat As Boolean = False

    'Struct to define different attributes for the different obstacles
    Private Structure obstacleAttributes
        Dim obstacle As String    'types of obstacle
        Dim tool() As String        'Array of tools that can be used with the obstacles
        Dim energyCost As Integer
    End Structure

    'Struct to define different attributes of the tools when used
    Private Structure toolAttributes
        Dim tool As String          'tool name
        Dim whiffleCost As Integer   'Cost in wiffels
        Dim energyCost As Integer   'Amount of energy decreased when tool is used
    End Structure

    Private toolChosen As String

    Dim trimArr() As Char = {" "} '  array of characters to trim from strings as they are read in
    Dim map(,) As Cell
    Dim mapID As String
    Dim mapFile As String
    Dim dimension As Integer
    Dim heroLocation As Point
    Dim energy As Integer
    Dim whiffles As Integer
    Dim newCell As Cell
    Dim lineCount As Integer
    Dim separator As New String("#########################")
    Dim trueObstacleTool(numberOfObstacles) As obstacleAttributes
    Dim toolLookUp(numberOfTools) As toolAttributes
    Dim diamondsLocation As Point
    Dim exception As Boolean        'When obstacle or exception is found, set exception to true and exit move subroutine and don't draw map
    Dim auto As Boolean             'When false, turns off automatic recall of move function when tool is deleted from list
    'Dim change As Boolean           'When false, up, down, lt, rt bools won't be changed in GameWindow.vb

    ' enumaerate Cell values for readability
    Private Enum CELLNFO_
        X = 1
        Y = 0
        VISIBILITY = 2
        TERRAIN = 3
        CONTENT = 4
    End Enum

    ' Default Constructor
    Sub New()
        InitVars()
        map = New Cell(dimension, dimension) {}
        mapInit()
        setTrueTools()
        setToolLookUp()
    End Sub

    ' Map class constructor
    Sub New(ByVal mapFile As String)
        lineCount = 0
        Dim lineBuff As New String("")
        Me.mapFile = mapFile
        InitVars()
        Dim inFile As StreamReader
        inFile = My.Computer.FileSystem.OpenTextFileReader(mapFile)
        ' set mapID and dimension
        lineBuff = Read(inFile)
        If lineBuff.Equals(separator) Then
            Corrupt()
            mapInit()
            Exit Sub
        Else
            Try
                mapID = lineBuff
            Catch
                Corrupt()
                mapInit()
                Exit Sub
            End Try
        End If
        lineBuff = Read(inFile)
        If lineBuff.Equals(separator) Then
            Corrupt()
            mapInit()
            Exit Sub
        Else
            Try
                dimension = CInt(lineBuff)
            Catch
                Corrupt()
                mapInit()
                Exit Sub
            End Try
        End If
        map = New Cell(dimension, dimension) {}
        mapInit()
        Try
            ParseGameState(inFile)
        Catch
            Corrupt()
            mapInit()
            Exit Sub
        End Try
        inFile.Close()

        setTrueTools()
        setToolLookUp()
    End Sub

    '****************************[ Private Methods ]******************************************
    ' this function trims whitespace and skips blank lines
    Private Function Read(ByRef infile As StreamReader) As String
        Dim lineBuff As New String(infile.ReadLine().Trim(trimArr))
        lineCount += 1
        If lineBuff.Equals("") Then
            Read(infile)
        End If
        Return lineBuff
    End Function
    ' parse game state section of the text file
    Private Sub ParseGameState(ByRef infile As StreamReader)
        'HACK make sure you get this to work
        Dim lineBuff As New String("")
        Dim location(0 To 1) As String
        If (infile.ReadLine.Equals(separator)) Then
            lineCount += 1
            location = infile.ReadLine().Split(",")
            lineCount += 1
            If (location(0) <= dimension And location(0) >= 0 And _
                location(1) <= dimension And location(0) >= 0) Then
                heroLocation.X = location(0)
                heroLocation.Y = location(1)
            Else
                Corrupt()
                'mapInit()
                Exit Sub
                End
            End If
        Else
            Corrupt()
            'mapInit()
            Exit Sub
        End If

        energy = infile.ReadLine()
        lineCount += 1
        whiffles = infile.ReadLine()
        lineCount += 1
        'infile.ReadLine()
        lineBuff = New String(infile.ReadLine())
        lineBuff = lineBuff.ToLower
        lineCount += 1
        ' parse game state
        GameWindow.Inventory.Items.Clear()
        While (Not lineBuff.Equals("#########################"))
            GameWindow.Inventory.Items.Add(lineBuff)
            lineBuff = New String(infile.ReadLine())
            lineBuff = lineBuff.ToLower
            If lineBuff.Contains("boat") Then Boat = True
            lineCount += 1
            If infile.EndOfStream Then
                Corrupt()
                'mapInit()
                Exit Sub
            End If
        End While
        ' finish parsing the rest of the document

        GameWindow.Inventory.Items.Add("None")      'Adds 'none' to tool inventory for read-in maps
        ParseCells(infile)
    End Sub

    Private Sub ParseCells(ByRef infile As StreamReader)
        Dim line(0 To 4) As String
        ' parse cell information and insert into map
        While (Not infile.EndOfStream)
            line = infile.ReadLine.Split(",")
            lineCount += 1
            ' ensure cell location is within given range
            If (line(0) >= dimension Or line(1) >= dimension Or _
                line(0) < 0 Or line(1) < 0) Then
                Corrupt()
                'mapInit()
            Else
                map(line(CELLNFO_.X), line(CELLNFO_.Y)).SetVisible(line(CELLNFO_.VISIBILITY))
                map(line(CELLNFO_.X), line(CELLNFO_.Y)).SetTerrain(line(CELLNFO_.TERRAIN))
                map(line(CELLNFO_.X), line(CELLNFO_.Y)).SetContent(line(CELLNFO_.CONTENT).ToLower.Trim(trimArr))
                If line(CELLNFO_.CONTENT).ToLower.Trim(trimArr).Contains("royal diamonds") Then diamondsLocation = New Point(line(CELLNFO_.X), line(CELLNFO_.Y))
            End If
        End While
    End Sub
    Private Sub Corrupt()
        ' MsgBox("File Corrupt! Error at line: " + lineCount.ToString + vbNewLine)
        Dim msg As String
        Dim title As String
        Dim style As MsgBoxStyle
        Dim response As MsgBoxResult
        msg = "File Corrupt! Error at line: " + lineCount.ToString + vbNewLine _
                + "Would you like to load a random map?" ' Define message.
        style = MsgBoxStyle.DefaultButton2 Or _
           MsgBoxStyle.Critical Or MsgBoxStyle.YesNo
        title = "MsgBox Demonstration"   ' Define title.
        ' Display message.
        response = MsgBox(msg, style, title)
        If response = MsgBoxResult.Yes Then   ' User chose Yes.
            Random("Random Map", 10, 25)
            ' GameWindow.NewToolStripMenuItem_Click(GameWindow, New System.EventArgs)
        Else
            GameStart.Show()
        End If
    End Sub
    ' variable initialization
    Private Sub InitVars()
        ' default game state
        map = New Cell(25, 25) {}
        mapID = "untitled"
        dimension = 25
        heroLocation = New Point(0, 0)
        energy = 100
        whiffles = 100
        newCell = New Cell
    End Sub

    ' initialize all cells in map to invisible cells of meadows with no content
    Private Sub mapInit()
        For i As Integer = 0 To dimension - 1
            For j As Integer = 0 To dimension - 1
                map(i, j) = New Cell(False, 0, "None")
            Next
        Next
    End Sub
    Private Function visibility(ByVal val As Boolean) As String
        If (val) Then
            Return "1"
        Else
            Return "0"
        End If
    End Function

    ' ***********************************************************[ BEN GLASSER ]********************************************************
    ' retruns a random number between 0 and myNum inclusive
    Private Function Get_Random(ByVal myNum As Integer) As Integer
        Randomize()
        Return Math.Round(myNum * Rnd(1))
    End Function
    '
    ' generates true clue if param is true else generates a false clue.
    Private Sub getClue(ByVal clue As Boolean)
        'TODO GETcLUE function
        Dim distanceFromWest = dimension - (dimension - heroLocation.X)
        Dim moreThanXWhiffles As Integer = whiffles - Get_Random(whiffles)
        Dim distanceFromRoyalDiamondsX As Integer = diamondsLocation.X - heroLocation.X
        Dim distanceFromRoyalDiamondsY As Integer = diamondsLocation.Y - heroLocation.Y
        Dim horizontalDirection As String = ""
        Dim verticalDirection As String = ""
        Dim myClue As Integer = Get_Random(3)

        ' used to determine horizontal direction to diamonds for true clue
        If distanceFromRoyalDiamondsX < 0 Then
            horizontalDirection = "east"
        ElseIf distanceFromRoyalDiamondsX > 0 Then
            horizontalDirection = "west"
        Else
            horizontalDirection = "east or west"
        End If

        ' used to determine horizontal direction to diamonds for true clue
        If distanceFromRoyalDiamondsY < 0 Then
            verticalDirection = "north"
        ElseIf distanceFromRoyalDiamondsY > 0 Then
            verticalDirection = "south"
        Else
            verticalDirection = "north or south"
        End If

        If clue Then
            MsgBox("You are " + distanceFromWest.ToString + " from the western border, you possess more than " + moreThanXWhiffles.ToString _
            + ", and the Royal Diamonds are located " + Math.Abs(distanceFromRoyalDiamondsX).ToString + " to the " + horizontalDirection + " and " + Math.Abs(distanceFromRoyalDiamondsY).ToString _
            + " to the " + verticalDirection + ".", MsgBoxStyle.OkOnly)
        Else
            Select Case Get_Random(4)
                Case 1
                    horizontalDirection = "west"
                    verticalDirection = "north"
                Case 2
                    horizontalDirection = "east"
                    verticalDirection = "north"
                Case 3
                    horizontalDirection = "east"
                    verticalDirection = "south"
                Case 4
                    horizontalDirection = "west"
                    verticalDirection = "south"
            End Select
            MsgBox("You are " + Get_Random(dimension).ToString + " from the western border, you possess more than " _
            + Get_Random(whiffles * 2).ToString + ", and the Royal Diamonds are located " _
            + Get_Random(dimension).ToString + " to the " + horizontalDirection + " and " _
            + Get_Random(dimension).ToString + " to the " + verticalDirection + ".", MsgBoxStyle.OkOnly)

        End If
    End Sub
    '****************************[ Public Methods ]******************************************
    Function getMap()
        Return map
    End Function

    Function getDimension() As Integer
        Return dimension
    End Function

    Function GetEnergy() As Integer
        Return energy
    End Function

    Function GetWhiffles() As Integer
        Return whiffles
    End Function

    Function GetHeroLocation() As Point
        Return heroLocation
    End Function

    Sub SetHeroLocation(ByVal loc As Point)
        heroLocation = loc
    End Sub
    Function GetCell(ByVal loc As Point) As Cell
        Return map(loc.X, loc.Y)
    End Function


    ' ******************************************[ JEFF FUNG & RYAN LARSON ]****************************************************
Sub MoveHeroHorizontal(ByVal move As Integer)

        Dim tempString As String            'temp String holder
        Dim energyCost As Integer           'Energy cost for movement
        Dim whiffelCost As Integer          'Whiffel cost for items
        Dim toolIndex As Integer            'Index found from array for obstacle
        Dim obstacleIndex As Integer        'Index found from array for tool

        exception = False
        auto = True

        'Handling map edge exceptions
        If (heroLocation.X = 0 And move = -1) Or (heroLocation.X = dimension - 1 And move = 1) Then
            'heroLocation.X += 0
            MsgBox("You cannot leave the map!")
            'exception = True
            Exit Sub
        End If

        'makes new cell visible
        map(heroLocation.X + move, heroLocation.Y).SetVisible(True)

        'Handling different terrains - Water
        ' w/o boat
        If (map(heroLocation.X + move, heroLocation.Y).GetTerrain = 2) And Boat = False Then
            'heroLocation.X += 0
            MsgBox("You are trying to enter a river")
            Exit Sub
            'water w/ boat
            ' with boat
        ElseIf (map(heroLocation.X + move, heroLocation.Y).GetTerrain = 2) And Boat = True Then
            heroLocation.X += move
            Exit Sub
            'Wall
        ElseIf map(heroLocation.X + move, heroLocation.Y).GetTerrain = 3 Then
            'heroLocation.Y += 0
            energy -= 1
            CheckEnergyLevel()
            MsgBox("You are trying to walk through a wall")
            Exit Sub
            'Bogs and Swamps
        ElseIf (map(heroLocation.X + move, heroLocation.Y).GetTerrain = 4 Or map(heroLocation.X + move, heroLocation.Y).GetTerrain = 5) Then

            If (map(heroLocation.X + move, heroLocation.Y).GetTerrain = 4) Then
                MsgBox("You've enter bog")
            End If

            If (map(heroLocation.X + move, heroLocation.Y).GetTerrain = 5) Then
                MsgBox("You've enter swamp")
            End If


            tempString = map(heroLocation.X + move, heroLocation.Y).GetContent

            'Section for handling running into obstacles
            If (tempString = "tree" Or tempString = "blackberry bushes" Or tempString = "boulder") Then
                If (toolChosen = Nothing) Then
                    MsgBox("You've encountered " & tempString & ". Please choose a 'tool' or 'none'")
                End If

                GameWindow.Inventory.Visible = True

                If (toolChosen = Nothing) Then
                    exception = True
                    Exit Sub
                Else
                    If (loadTrueTools(tempString, obstacleIndex)) Then

                        toolIndex = findToolAttributes(toolChosen)   'finds attributes of tool chosen

                        'toolindex = 8 when tool chosen is none
                        If (toolIndex = 8) Then
                            energyCost = trueObstacleTool(obstacleIndex).energyCost
                            whiffelCost = 0
                        Else
                            auto = False
                            GameWindow.Inventory.Items.Remove(toolLookUp(toolIndex).tool)   'Removes tool from inventory
                            energyCost = toolLookUp(toolIndex).energyCost
                            whiffelCost = 0
                        End If
                        'deletes content after being removed
                        map(heroLocation.X + move, heroLocation.Y).SetContent("none")
                    Else
                        MsgBox("Tool Invalid for obstacle. Will now remove obstacle as if no tools were chosen.")
                        energyCost = trueObstacleTool(obstacleIndex).energyCost
                        whiffelCost = 0
                        map(heroLocation.X + move, heroLocation.Y).SetContent("none")
                    End If
                End If
                'Updates energy and whiffel with obstacle
                energy -= (energyCost + 2)
                CheckEnergyLevel()
                whiffles -= whiffelCost

            Else        'Handling energy with no obstacels
                energy -= 2
                CheckEnergyLevel()
            End If

        Else  'Handles Meadows or Forests 

            tempString = map(heroLocation.X + move, heroLocation.Y).GetContent


            'Section for handling running into obstacles
            If (tempString = "tree" Or tempString = "blackberry bushes" Or tempString = "boulder") Then
                If (toolChosen = Nothing) Then
                    MsgBox("You've encountered " & tempString & ". Please choose a 'tool' or 'none'")
                End If

                GameWindow.Inventory.Visible = True
                GameWindow.Inventory.Enabled = True

                If (toolChosen = Nothing) Then
                    exception = True
                    Exit Sub
                Else
                    If (loadTrueTools(tempString, obstacleIndex)) Then

                        toolIndex = findToolAttributes(toolChosen)   'finds attributes of tool chosen

                        'toolindex = 8 when tool chosen is none
                        If (toolIndex = 8) Then
                            energyCost = trueObstacleTool(obstacleIndex).energyCost
                            whiffelCost = 0
                        Else
                            auto = False
                            GameWindow.Inventory.Items.Remove(toolLookUp(toolIndex).tool)   'Removes tool from inventory
                            energyCost = toolLookUp(toolIndex).energyCost
                            whiffelCost = 0
                        End If
                        'deletes content after being removed
                        map(heroLocation.X + move, heroLocation.Y).SetContent("none")
                    Else
                        MsgBox("Tool Invalid for obstacle. Will now remove obstacle as if no tools were chosen.")
                        energyCost = trueObstacleTool(obstacleIndex).energyCost
                        whiffelCost = 0
                        map(heroLocation.X + move, heroLocation.Y).SetContent("none")
                    End If
                End If
                'Updates energy and whiffel with obstacle
                energy -= (energyCost + 1)
                CheckEnergyLevel()
                whiffles -= whiffelCost

            Else        'Handling energy with no obstacels
                energy -= 1
                CheckEnergyLevel()
            End If
        End If

        heroLocation.X += move
        HandleInventory(map(heroLocation.X, heroLocation.Y).GetContent)
        'map(heroLocation.X, heroLocation.Y).SetVisible(True)
        If buyTool(heroLocation) Then GameWindow.drawCell(GameWindow.GamePanel.CreateGraphics, heroLocation)
    End Sub
    '
    ' control vertical movement
    Sub MoveHeroVertical(ByVal move As Integer)
        Dim tempString As String        'temp String holder
        Dim energyCost As Integer       'Energy cost for movement
        Dim whiffelCost As Integer      'Whiffel cost for items
        Dim toolIndex As Integer        'Index found from array for obstacle
        Dim obstacleIndex As Integer    'Index found from array for tool

        exception = False
        auto = True

        'Handling map edge exception        
        If (heroLocation.Y = 0 And move = -1) Or (heroLocation.Y = dimension - 1 And move = 1) Then
            'heroLocation.X += 0
            MsgBox("You cannot leave the map!")
            'exception = True
            Exit Sub
        End If

        'makes new cell visible
        map(heroLocation.X, heroLocation.Y + move).SetVisible(True)

        'Hnandling different terrains - Water
        'Hnandling different terrains - Water (w/o boat)
        If (map(heroLocation.X, heroLocation.Y + move).GetTerrain = 2) And Boat = False Then
            'heroLocation.Y += 0
            MsgBox("You are trying to enter a river")
            Exit Sub
            'water with boat
        ElseIf (map(heroLocation.X, heroLocation.Y + move).GetTerrain = 2) And Boat = True Then
            heroLocation.Y += move
            Exit Sub
            'Wall
        ElseIf map(heroLocation.X, heroLocation.Y + move).GetTerrain = 3 Then
            'heroLocation.Y += 0
            energy -= 1
            CheckEnergyLevel()
            MsgBox("You are trying to walk through a wall")
            Exit Sub
            'Bogs or Swamps
        ElseIf (map(heroLocation.X, heroLocation.Y + move).GetTerrain = 4 Or map(heroLocation.X, heroLocation.Y + move).GetTerrain = 5) Then

            If (map(heroLocation.X, heroLocation.Y + move).GetTerrain = 4) Then
                MsgBox("You've enter bog")
            End If

            If (map(heroLocation.X, heroLocation.Y + move).GetTerrain = 5) Then
                MsgBox("You've enter swamp")
            End If


            tempString = map(heroLocation.X, heroLocation.Y + move).GetContent

            'Section for handling running into obstacles
            If (tempString = "tree" Or tempString = "blackberry bushes" Or tempString = "boulder") Then
                If (toolChosen = Nothing) Then
                    MsgBox("You've encountered " & tempString & ". Please choose a 'tool' or 'none'")
                End If
                GameWindow.Inventory.Visible = True
                GameWindow.Inventory.Enabled = True

                If (toolChosen = Nothing) Then
                    exception = True
                    Exit Sub
                Else
                    If (loadTrueTools(tempString, obstacleIndex)) Then

                        toolIndex = findToolAttributes(toolChosen)   'finds attributes of tool chosen

                        'toolindex = 8 when tool chosen is none
                        If (toolIndex = 8) Then
                            energyCost = trueObstacleTool(obstacleIndex).energyCost
                            whiffelCost = 0
                        Else
                            auto = False
                            GameWindow.Inventory.Items.Remove(toolLookUp(toolIndex).tool)   'Removes tool from inventory
                            energyCost = toolLookUp(toolIndex).energyCost
                            whiffelCost = 0
                        End If
                        'deletes content after being removed
                        map(heroLocation.X, heroLocation.Y + move).SetContent("none")
                    Else
                        MsgBox("Tool Invalid for obstacle. Will now remove obstacle as if no tools were chosen.")
                        energyCost = trueObstacleTool(obstacleIndex).energyCost
                        whiffelCost = 0
                        map(heroLocation.X, heroLocation.Y + move).SetContent("none")
                    End If

                End If

                'Updates energy and whiffel with obstacle
                energy -= (energyCost + 2)
                CheckEnergyLevel()
                whiffles -= whiffelCost

            Else   'Handling energy with no obstacels
                energy -= 2
                CheckEnergyLevel()
            End If

            'Handles Meadow or Forest
        Else

            tempString = map(heroLocation.X, heroLocation.Y + move).GetContent

            'Section for handling running into obstacles
            If (tempString = "tree" Or tempString = "blackberry bushes" Or tempString = "boulder") Then
                If (toolChosen = Nothing) Then
                    MsgBox("You've encountered " & tempString & ". Please choose a 'tool' or 'none'")
                End If
                GameWindow.Inventory.Visible = True
                GameWindow.Inventory.Enabled = True

                If (toolChosen = Nothing) Then
                    exception = True
                    Exit Sub
                Else
                    If (loadTrueTools(tempString, obstacleIndex)) Then

                        toolIndex = findToolAttributes(toolChosen)   'finds attributes of tool chosen

                        'toolindex = 8 when tool chosen is none
                        If (toolIndex = 8) Then
                            energyCost = trueObstacleTool(obstacleIndex).energyCost
                            whiffelCost = 0
                        Else
                            auto = False
                            GameWindow.Inventory.Items.Remove(toolLookUp(toolIndex).tool)   'Removes tool from inventory
                            energyCost = toolLookUp(toolIndex).energyCost
                            whiffelCost = 0
                        End If
                        'deletes content after being removed
                        map(heroLocation.X, heroLocation.Y + move).SetContent("none")
                    Else
                        MsgBox("Tool Invalid for obstacle. Will now remove obstacle as if no tools were chosen.")
                        energyCost = trueObstacleTool(obstacleIndex).energyCost
                        whiffelCost = 0
                        map(heroLocation.X, heroLocation.Y + move).SetContent("none")
                    End If

                End If

                'Updates energy and whiffel with obstacle
                energy -= (energyCost + 1)
                CheckEnergyLevel()
                whiffles -= whiffelCost

            Else   'Handling energy with no obstacels
                energy -= 1
                CheckEnergyLevel()
            End If

            'map(heroLocation.X, heroLocation.Y).SetVisible(True)
        End If
        heroLocation.Y += move
        HandleInventory(map(heroLocation.X, heroLocation.Y).GetContent)
        If buyTool(heroLocation) Then GameWindow.drawCell(GameWindow.GamePanel.CreateGraphics, heroLocation)
    End Sub

    Function cellIsVisible(ByVal loc As Point) As Boolean
        Return map(loc.X, loc.Y).IsVisible
    End Function

    Function getCellContent(ByVal loc As Point) As String
        Return map(loc.X, loc.Y).GetContent
    End Function

    Function getCellTerrain(ByVal loc As Point) As Integer
        Return map(loc.X, loc.Y).GetTerrain
    End Function
    Function HandleInventory(ByVal content As String) As Integer
        Select Case getCellContent(heroLocation)
            Case "axe"

            Case "binoculars"

            Case "blackberry bushes"

            Case "boulder"

            Case "chainsaw"

            Case "chisel"

            Case "hatchet"

            Case "jackhammer"

            Case "machete"

            Case "powerbar"

            Case "royal diamonds"
                MoveIntoCellWithRoyalDiamonds()
            Case "sledge"

            Case "treasure chest"

            Case "boat"

        End Select
        Return 0
    End Function

    ' this function writes a string in the probper .map format of the current state of the map.
    Overrides Function ToString() As String
        Dim myString As String = ""
        myString = mapID + vbNewLine
        myString = myString + dimension.ToString + vbNewLine
        myString = myString + separator + vbNewLine
        myString = myString + heroLocation.X.ToString + "," + heroLocation.Y.ToString + vbNewLine
        myString = myString + energy.ToString + vbNewLine
        myString = myString + whiffles.ToString + vbNewLine
        For i As Integer = 0 To (GameWindow.Inventory.Items.Count - 1)
            myString = myString + GameWindow.Inventory.Items.Item(i) + vbNewLine
        Next
        myString = myString + separator
        For i As Integer = 0 To (dimension - 1)
            For j = 0 To (dimension - 1)
                myString = myString + vbNewLine _
                       + j.ToString _
                       + "," + i.ToString _
                       + "," + visibility(map(i, j).IsVisible()) _
                       + "," + map(i, j).GetTerrain().ToString _
                       + "," + map(i, j).GetContent()
            Next
        Next
        Return myString
    End Function

    ' this function creates a random map with a given name and dimension, density refers to an
    ' integer from 0 - 100 which determins how much random "content" is placed on the board
    ' 0 means no contenet, 100 means nearly every cell which is not a wall or water has content.
    ' written by Ben Glasser
    Public Sub Random(ByVal name As String, ByVal dimension As Integer, ByVal density As Integer)
        Dim terr As Integer = 0
        Dim cont As Integer = 0

        mapID = name
        Me.dimension = dimension
        whiffles = 1000
        energy = 100

        ' create map
        For i As Integer = 0 To (dimension)
            For j As Integer = 0 To (dimension)
                terr = Get_Random(5)
                cont = Get_Random(19)
                ' if terrain is not water or a wall
                If (terr < 2 Or (terr > 3 And terr < 6)) And Get_Random(100) < density Then
                    'HACK set vis random
                    map(i, j) = New Cell(False, terr, cont)
                Else ' else don't add content
                    map(i, j) = New Cell(False, terr, 0)
                End If
            Next
        Next

        ' format the cell in which to place the royal jewels
        Dim x As Integer = Get_Random(dimension - 1)
        Dim y As Integer = Get_Random(dimension - 1)
        map(x, y).SetContent("royal diamonds")
        map(x, y).SetTerrain(0)
        diamondsLocation = New Point(x, y)
        ' place hero in starting location
        map(0, 0).SetContent("none")
        map(0, 0).SetTerrain(0)
        map(0, 0).SetVisible(True)
        heroLocation = (New Point(0, 0))
        GameWindow.Inventory.Items.Add("None")      'Adds 'none' to tool inventory for random maps
    End Sub



    ' ********************************************************[ RUVIM MICSANSCHI ]************************************************************
    '----------------------LOOKING AROUND--------------------------
    'Player selects EXPLORE button 
    'if hero doesn't posesses binoculars the contents of the adjecent map cells become visible
    'if hero posesses binoculars the contents of all adjecent cells plus all map cells adjecent to them become visible

    Sub LookingAround(ByVal hasBinoculars)
        If hasBinoculars = -1 Then
            makeOneLevelAdjecentCellsVisible()
        Else
            makeTwoLevelOfAdjecentCellsVisible()
        End If
    End Sub

    'implements case when hero doesn't have binoculars
    Sub makeOneLevelAdjecentCellsVisible()
        Dim heroLocation As Point = GetHeroLocation()
        Dim MapDimention As Integer = getDimension()

        For i As Integer = heroLocation.X - 1 To heroLocation.X + 1
            For j As Integer = heroLocation.Y - 1 To heroLocation.Y + 1
                Try
                    'This code check is added
                    If i <= MapDimention And j <= MapDimention Then
                        map(i, j).SetVisible(True)
                    End If
                Catch ex As Exception
                End Try
            Next
        Next
    End Sub

    'implements case when hero doesn't have binoculars
    Sub makeTwoLevelOfAdjecentCellsVisible()

        Dim heroLocation As Point = GetHeroLocation()
        Dim MapDimention As Integer = getDimension()

        For i As Integer = heroLocation.X - 2 To heroLocation.X + 2
            For j As Integer = heroLocation.Y - 2 To heroLocation.Y + 2
                Try
                    'This code check is added
                    If i <= MapDimention And j <= MapDimention Then
                        map(i, j).SetVisible(True)
                    End If

                Catch ex As Exception
                End Try
            Next
        Next

    End Sub

    '---------------------- FUNCTION CHECKS HERO's ENERGY -----------------------

    'if energy level is <= 0 GameOver Window pops up, game exits
    Function CheckEnergyLevel()

        'check energy level
        If energy <= 0 Then
            Dim ErrorMsgBox As New GameOver
            ErrorMsgBox.Show()
        End If
        Return False
    End Function


    '---------------------- MOVE HERO INTO CELL WITH DIAMONDS -----------------------
    'Function checks if cell contains royal diamonds
    'if yes returns true, else returns false. 
    '
    Function MoveIntoCellWithRoyalDiamonds()
        Dim GameWon As New GameWon
        GameWon.Show()
        Return True
    End Function
    ' *********************************************************************************************************************************

    ' ********************************************************[ JEFF FUNG ]************************************************************

    'Sets array values of applicable tools for obstacles
    Sub setTrueTools()
        'sets available tools for tree
        trueObstacleTool(0).obstacle = "tree"
        trueObstacleTool(0).tool = {"hatchet", "axe", "chainsaw", "none"}
        trueObstacleTool(0).energyCost = 10

        'sets available tools for boulder
        trueObstacleTool(1).obstacle = "boulder"
        trueObstacleTool(1).tool = {"chisel", "sledge", "jackhammer", "none"}
        trueObstacleTool(1).energyCost = 16

        'sets available tools for blackberry bush
        trueObstacleTool(2).obstacle = "blackberry bushes"
        trueObstacleTool(2).tool = {"machete", "shears", "none"}
        trueObstacleTool(2).energyCost = 4

    End Sub
    'Sets array values for tool attributes 
    Sub setToolLookUp()
        'sets attributes for hatchet
        toolLookUp(0).tool = "hatchet"
        toolLookUp(0).energyCost = 8
        toolLookUp(0).whiffleCost = 15

        'set attributes for axe
        toolLookUp(1).tool = "axe"
        toolLookUp(1).energyCost = 6
        toolLookUp(1).whiffleCost = 30

        'set attributes for chainsaw
        toolLookUp(2).tool = "chainsaw"
        toolLookUp(2).energyCost = 2
        toolLookUp(2).whiffleCost = 60

        'set attributes for chisel
        toolLookUp(3).tool = "chisel"
        toolLookUp(3).energyCost = 15
        toolLookUp(3).whiffleCost = 5

        'set attributes for sledge
        toolLookUp(4).tool = "sledge"
        toolLookUp(4).energyCost = 12
        toolLookUp(4).whiffleCost = 25


        'set attributes for jackhammer
        toolLookUp(5).tool = "jackhammer"
        toolLookUp(5).energyCost = 4
        toolLookUp(5).whiffleCost = 100

        'set attributes for machete
        toolLookUp(6).tool = "machete"
        toolLookUp(6).energyCost = 2
        toolLookUp(6).whiffleCost = 25

        'set attributes for shears
        toolLookUp(7).tool = "shears"
        toolLookUp(7).energyCost = 2
        toolLookUp(7).whiffleCost = 35

        'set summy attributes for none
        toolLookUp(8).tool = "none"
        toolLookUp(8).energyCost = 0
        toolLookUp(8).whiffleCost = 0
    End Sub


    'Checks if tool selected by user is applicable for the obstacle
    Function loadTrueTools(ByVal obstacle As String, ByRef index As Integer)
        Dim toolChosen As String = GameWindow.Inventory.SelectedItem

        For i As Integer = 0 To numberOfObstacles - 1
            If (obstacle = trueObstacleTool(i).obstacle) Then
                index = i
                For j As Integer = 0 To trueObstacleTool(i).tool.Length - 1
                    If (toolChosen.ToLower = trueObstacleTool(i).tool(j)) Then
                        Return True
                    End If
                Next
            End If
        Next

        Return False
    End Function

    'Return tool attribute array index when tool kis found
    Function findToolAttributes(ByVal tool As String) As Integer

        Dim i As Integer
        For i = 0 To numberOfTools - 1
            If (tool = toolLookUp(i).tool) Then
                Exit For
            End If
        Next

        Return i
    End Function

    Sub setToolChosen(ByVal tool As String)
        toolChosen = tool
    End Sub

    Function getToolChosen() As String
        Return toolChosen
    End Function

    Function getExceptionValue() As Boolean
        Return exception
    End Function

    Function getAutoValue() As Boolean
        Return auto
    End Function

    'Function getChangeValue() As Boolean
    '    Return change
    'End Function
    ' ******************************************************************[ EVAN MESSINGER ]**************************************************************************
    Private Function buyTool(ByVal location As Point) As Boolean
        'get content only once
        Dim content = map(location.X, location.Y).GetContent()

        'check if we won the game
        If content = "royal diamonds" Then
            'MoveIntoCellWithRoyalDiamonds()
            Return False
            Exit Function
        End If

        'check if there is something we can't buy in the tile
        If (content = "none" Or content = "tree" Or content = "boulder" Or content = "blackberry bushes") Then
            'we don't want to redraw the cell
            Return False
        End If

        'ask user to purchase
        Dim response As MsgBoxResult

        'treasure chest: we don't buy these
        If content.Contains("treasure chest") Then
            response = MsgBox("Do you want to open the treasure chest?", MsgBoxStyle.YesNo)
            If response = MsgBoxResult.No Then
                'we don't want to redraw the cell
                Return False
            End If
            If content.Contains("type 1") Then 'type 1 treasure chest
                MsgBox("There were " & GameWindow.ToolWhiffleCost("treasure chest") & " whiffles in the treasure chest!", MsgBoxStyle.OkOnly)
                whiffles = whiffles + GameWindow.ToolWhiffleCost("treasure chest")
            Else 'type 2 treasure chest
                MsgBox("The treasure chest EXPLODED!", MsgBoxStyle.OkOnly)
                whiffles = whiffles - GameWindow.ToolWhiffleCost("treasure chest")
                If whiffles < 1 Then whiffles = 0
            End If
            'we opened the treasure chest, so it's no longer in the cell. remove the content, update whiffles, and redraw the cell
            map(location.X, location.Y).SetContent("none")
            GameWindow.updateWhiffles()
            Return True
        End If

        'do we have enough whiffles? if not, we can't even think about purchasing the item.
        'nothing happens, so don't redraw the tile
        If whiffles < GameWindow.ToolWhiffleCost(content) Then Return False

        'clue: we have a specialized message box
        If content.Contains("clue") Then
            response = MsgBox("Do you want to purchase and read the clue?", MsgBoxStyle.YesNo)
            If response = MsgBoxResult.No Then
                'we don't want to redraw the cell
                Return False
            End If

            getClue(content.Contains("true"))
            'If content.Contains("true") Then 'true clue

            'Else 'false clue

            'End If
            'we read the clue, so it's no longer in the cell. remove the content, update whiffles, and redraw the cell
            map(location.X, location.Y).SetContent("none")
            GameWindow.updateWhiffles()
            Return True
        End If

        'it's some other tool
        If Not content.ToLower.Contains("none") Then
            response = MsgBox("Do you want to buy the " & content, MsgBoxStyle.YesNo)
            If response = MsgBoxResult.No Then
                'we don't want to redraw the cell
                Return False
            End If
            'we're buying the tool:
        'subtract cost and update whiffles
        whiffles = whiffles - GameWindow.ToolWhiffleCost(content)
            GameWindow.updateWhiffles()
        End If
        'is item a power bar? if so, it takes effect immediately; update energy
        If content = "power bar" Then
            energy = energy + 10
            GameWindow.updateEnergy()
        Else 'otherwise, it's added to the player's inventory
            If Not content.ToLower.Contains("none") Then
                GameWindow.Inventory.Items.Add(content)
                If content.ToLower.Contains("boat") Then Boat = True
            End If
        End If

        'remove item from map
        map(location.X, location.Y).SetContent("none")

        'we bought the item, and we do want to redraw the cell
        Return True

    End Function
End Class
