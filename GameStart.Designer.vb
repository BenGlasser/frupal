<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class GameStart
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(GameStart))
        Me.closeButton = New System.Windows.Forms.PictureBox()
        Me.NewGameButton = New System.Windows.Forms.Label()
        Me.LoadGameButton = New System.Windows.Forms.Label()
        CType(Me.closeButton, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'closeButton
        '
        Me.closeButton.Image = Global.Frupal.My.Resources.Resources.Actions_application_exit_icon
        Me.closeButton.Location = New System.Drawing.Point(373, 12)
        Me.closeButton.Margin = New System.Windows.Forms.Padding(0)
        Me.closeButton.Name = "closeButton"
        Me.closeButton.Size = New System.Drawing.Size(16, 16)
        Me.closeButton.TabIndex = 0
        Me.closeButton.TabStop = False
        '
        'NewGameButton
        '
        Me.NewGameButton.BackColor = System.Drawing.Color.Transparent
        Me.NewGameButton.Location = New System.Drawing.Point(73, 378)
        Me.NewGameButton.Name = "NewGameButton"
        Me.NewGameButton.Size = New System.Drawing.Size(271, 46)
        Me.NewGameButton.TabIndex = 1
        '
        'LoadGameButton
        '
        Me.LoadGameButton.BackColor = System.Drawing.Color.Transparent
        Me.LoadGameButton.Location = New System.Drawing.Point(75, 437)
        Me.LoadGameButton.Name = "LoadGameButton"
        Me.LoadGameButton.Size = New System.Drawing.Size(269, 46)
        Me.LoadGameButton.TabIndex = 2
        '
        'GameStart
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(401, 577)
        Me.Controls.Add(Me.LoadGameButton)
        Me.Controls.Add(Me.NewGameButton)
        Me.Controls.Add(Me.closeButton)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "GameStart"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "GameStart"
        Me.TopMost = True
        CType(Me.closeButton, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents closeButton As System.Windows.Forms.PictureBox
    Friend WithEvents NewGameButton As System.Windows.Forms.Label
    Friend WithEvents LoadGameButton As System.Windows.Forms.Label
End Class
