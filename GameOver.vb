' Author: Ben Glasser, Jeff Fung, Evan Messinger, Ruvim Micsanschi, Ryan Larson
' Date: 12-09-11
' File: GameOver.vb
' Purpose: this file handles the display window win the player has lost and the game is over

' *************************************************[ RUVIM MICSANCHI ]*********************************************
Public Class GameOver

    Private Sub GameOver_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        GameWindow.Enabled = False

    End Sub

    Private Sub QuitGame_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles QuitGame.Click
        Me.Close()
        GameWindow.Close()
    End Sub

End Class