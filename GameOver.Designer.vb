<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class GameOver
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(GameOver))
        Me.QuitGameButton = New System.Windows.Forms.Label()
        Me.QuitGame = New System.Windows.Forms.Panel()
        Me.SuspendLayout()
        '
        'QuitGameButton
        '
        Me.QuitGameButton.AutoSize = True
        Me.QuitGameButton.BackColor = System.Drawing.Color.Transparent
        Me.QuitGameButton.Font = New System.Drawing.Font("Calibri", 32.0!, System.Drawing.FontStyle.Bold)
        Me.QuitGameButton.ForeColor = System.Drawing.Color.Transparent
        Me.QuitGameButton.Location = New System.Drawing.Point(103, 483)
        Me.QuitGameButton.Name = "QuitGameButton"
        Me.QuitGameButton.Size = New System.Drawing.Size(0, 53)
        Me.QuitGameButton.TabIndex = 0
        '
        'QuitGame
        '
        Me.QuitGame.BackColor = System.Drawing.Color.Transparent
        Me.QuitGame.Location = New System.Drawing.Point(100, 483)
        Me.QuitGame.Name = "QuitGame"
        Me.QuitGame.Size = New System.Drawing.Size(239, 53)
        Me.QuitGame.TabIndex = 1
        '
        'GameOver
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.BackgroundImage = Global.Frupal.My.Resources.Resources.GameOverBg
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ClientSize = New System.Drawing.Size(400, 577)
        Me.ControlBox = False
        Me.Controls.Add(Me.QuitGame)
        Me.Controls.Add(Me.QuitGameButton)
        Me.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.ForeColor = System.Drawing.SystemColors.WindowText
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "GameOver"
        Me.Opacity = 0.95R
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "GameOver"
        Me.TopMost = True
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents QuitGameButton As System.Windows.Forms.Label
    Friend WithEvents QuitGame As System.Windows.Forms.Panel
End Class
