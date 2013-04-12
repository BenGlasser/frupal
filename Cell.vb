' Author: Ben Glasser, Jeff Fung, Evan Messinger, Ruvim Micsanschi, Ryan Larson
' Date: 12-09-11
' File: Cell.vb
' Purpose: holds information about a given map cell

Public Class Cell
    Private Visibility As Boolean
    Private Terrain As Integer
    Private Content As String
    Private contentArr() As String = {"none", "axe", "hatchet", "chainsaw", "chisel", "sledge", _
                                        "jackhammer", "machete", "shears", "tree", "boat", "binoculars", _
                                        "type 1 treasure chest", "type 2 treasure chest", "tree", "boulder", _
                                        "blackberry bushes", "power bar", "clue", "true clue"}
    Sub New()
        Visibility = False
        Terrain = GameWindow.SPRITES_.NONE
        Content = "None"
    End Sub
    Sub New(ByVal isVisible As Boolean, ByVal terrain As Integer, ByVal content As String)
        Me.Visibility = isVisible
        Me.Content = content.Trim(" ")
        Me.Terrain = terrain
    End Sub
    Sub New(ByVal isVisible As Boolean, ByVal terrain As Integer, ByVal content As Integer)
        Me.Visibility = isVisible
        Me.Content = contentArr(content)
        Me.Terrain = terrain
    End Sub
    '
    '****************************[ Public Methods ]******************************************
    '
    Sub SetVisible(ByVal val As Boolean)
        Visibility = val
    End Sub

    Sub SetTerrain(ByVal val As Integer)
        Terrain = val
    End Sub

    Sub SetContent(ByVal val As String)
        Content = val
    End Sub

    Function IsVisible() As Boolean
        Return Visibility
    End Function

    Function GetTerrain() As Integer
        Return Terrain
    End Function

    Function GetContent() As String
        Return Content
    End Function
End Class
