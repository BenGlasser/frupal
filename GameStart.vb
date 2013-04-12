' Author: Ben Glasser, Jeff Fung, Evan Messinger, Ruvim Micsanschi, Ryan Larson
' Date: 12-09-11
' File Gamestart.vb
' Purpose:  this file handles the behavior of the start up screen when the game is loaded.

' *************************************************************[ BEN GLASSER ]****************************************************************
Public Class GameStart

    Private Sub closeButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles closeButton.Click
        Me.Dispose()
        GameWindow.Dispose()
    End Sub

    Private Sub GameStart_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        GameWindow.Opacity = 0.85
        GameWindow.Enabled = False
    End Sub

    Private Sub NewGameButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewGameButton.Click
        Me.Close()
        GameWindow.Show()
        GameWindow.Opacity = 1
        GameWindow.Enabled = True
        GameWindow.BringToFront()
        GameWindow.NewToolStripMenuItem_Click(sender, e)
    End Sub

    Private Sub LoadGameButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LoadGameButton.Click
        Me.Close()
        GameWindow.Show()
        GameWindow.Opacity = 1
        GameWindow.Enabled = True
        GameWindow.BringToFront()
        GameWindow.OpenToolStripMenuItem_Click(sender, e)
    End Sub
End Class