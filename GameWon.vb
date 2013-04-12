' Author: Ben Glasser, Jeff Fung, Evan Messinger, Ruvim Micsanschi, Ryan Larson
' Date: 12-09-11
' File: GameOver.vb
' Purpose: this file handles the display window that is shown when the player has won the game.

' *************************************************[ RUVIM MICSANCHI ]*********************************************
Public Class GameWon

    Private Sub GameWon_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        GameWindow.Enabled = False
    End Sub

    Private Sub CloseButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CloseButton.Click
        Me.Close()
        GameWindow.Close()
    End Sub
End Class