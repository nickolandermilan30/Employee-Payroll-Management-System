<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class HomeEmployee
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
        Panel4 = New Panel()
        absentday = New Label()
        Label5 = New Label()
        Panel1 = New Panel()
        presentday = New Label()
        lblUsername = New Label()
        Panel2 = New Panel()
        halfday = New Label()
        Label3 = New Label()
        Panel3 = New Panel()
        late = New Label()
        Label7 = New Label()
        attendancePanel = New Panel()
        Label1 = New Label()
        Panel4.SuspendLayout()
        Panel1.SuspendLayout()
        Panel2.SuspendLayout()
        Panel3.SuspendLayout()
        SuspendLayout()
        ' 
        ' Panel4
        ' 
        Panel4.Anchor = AnchorStyles.Top
        Panel4.BackColor = Color.FromArgb(CByte(38), CByte(49), CByte(64))
        Panel4.Controls.Add(absentday)
        Panel4.Controls.Add(Label5)
        Panel4.Location = New Point(340, 77)
        Panel4.Name = "Panel4"
        Panel4.Size = New Size(173, 88)
        Panel4.TabIndex = 7
        ' 
        ' absentday
        ' 
        absentday.AutoSize = True
        absentday.Font = New Font("Century Gothic", 36F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        absentday.ForeColor = Color.White
        absentday.Location = New Point(98, 15)
        absentday.Name = "absentday"
        absentday.Size = New Size(51, 56)
        absentday.TabIndex = 15
        absentday.Text = "0"
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Font = New Font("Century Gothic", 11.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label5.ForeColor = Color.White
        Label5.Location = New Point(23, 47)
        Label5.Name = "Label5"
        Label5.Size = New Size(58, 18)
        Label5.TabIndex = 13
        Label5.Text = "Absent"
        ' 
        ' Panel1
        ' 
        Panel1.Anchor = AnchorStyles.Top
        Panel1.BackColor = Color.FromArgb(CByte(250), CByte(129), CByte(18))
        Panel1.Controls.Add(presentday)
        Panel1.Controls.Add(lblUsername)
        Panel1.Location = New Point(88, 77)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(173, 88)
        Panel1.TabIndex = 8
        ' 
        ' presentday
        ' 
        presentday.AutoSize = True
        presentday.Font = New Font("Century Gothic", 36F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        presentday.ForeColor = Color.Black
        presentday.Location = New Point(101, 15)
        presentday.Name = "presentday"
        presentday.Size = New Size(51, 56)
        presentday.TabIndex = 13
        presentday.Text = "0"
        ' 
        ' lblUsername
        ' 
        lblUsername.AutoSize = True
        lblUsername.Font = New Font("Century Gothic", 11.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblUsername.ForeColor = Color.Black
        lblUsername.Location = New Point(25, 47)
        lblUsername.Name = "lblUsername"
        lblUsername.Size = New Size(60, 18)
        lblUsername.TabIndex = 11
        lblUsername.Text = "Present"
        ' 
        ' Panel2
        ' 
        Panel2.Anchor = AnchorStyles.Top
        Panel2.BackColor = Color.FromArgb(CByte(250), CByte(129), CByte(18))
        Panel2.Controls.Add(halfday)
        Panel2.Controls.Add(Label3)
        Panel2.Location = New Point(586, 77)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(173, 88)
        Panel2.TabIndex = 13
        ' 
        ' halfday
        ' 
        halfday.AutoSize = True
        halfday.Font = New Font("Century Gothic", 36F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        halfday.ForeColor = Color.Black
        halfday.Location = New Point(103, 15)
        halfday.Name = "halfday"
        halfday.Size = New Size(51, 56)
        halfday.TabIndex = 12
        halfday.Text = "0"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Century Gothic", 11.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label3.ForeColor = Color.Black
        Label3.Location = New Point(25, 47)
        Label3.Name = "Label3"
        Label3.Size = New Size(65, 18)
        Label3.TabIndex = 11
        Label3.Text = "Halfday"
        ' 
        ' Panel3
        ' 
        Panel3.Anchor = AnchorStyles.Top
        Panel3.BackColor = Color.FromArgb(CByte(38), CByte(49), CByte(64))
        Panel3.Controls.Add(late)
        Panel3.Controls.Add(Label7)
        Panel3.Location = New Point(839, 77)
        Panel3.Name = "Panel3"
        Panel3.Size = New Size(173, 88)
        Panel3.TabIndex = 13
        ' 
        ' late
        ' 
        late.AutoSize = True
        late.Font = New Font("Century Gothic", 36F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        late.ForeColor = Color.White
        late.Location = New Point(101, 15)
        late.Name = "late"
        late.Size = New Size(51, 56)
        late.TabIndex = 14
        late.Text = "0"
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.Font = New Font("Century Gothic", 11.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label7.ForeColor = Color.White
        Label7.Location = New Point(23, 47)
        Label7.Name = "Label7"
        Label7.Size = New Size(39, 18)
        Label7.TabIndex = 13
        Label7.Text = "Late"
        ' 
        ' attendancePanel
        ' 
        attendancePanel.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        attendancePanel.Location = New Point(88, 215)
        attendancePanel.Name = "attendancePanel"
        attendancePanel.Size = New Size(924, 419)
        attendancePanel.TabIndex = 14
        ' 
        ' Label1
        ' 
        Label1.Anchor = AnchorStyles.Top
        Label1.AutoSize = True
        Label1.ForeColor = SystemColors.Control
        Label1.Location = New Point(284, 24)
        Label1.Name = "Label1"
        Label1.Size = New Size(41, 15)
        Label1.TabIndex = 15
        Label1.Text = "Label1"
        ' 
        ' HomeEmployee
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1092, 684)
        Controls.Add(Label1)
        Controls.Add(attendancePanel)
        Controls.Add(Panel3)
        Controls.Add(Panel2)
        Controls.Add(Panel1)
        Controls.Add(Panel4)
        FormBorderStyle = FormBorderStyle.None
        Name = "HomeEmployee"
        Text = "HomeEmployee"
        Panel4.ResumeLayout(False)
        Panel4.PerformLayout()
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        Panel2.ResumeLayout(False)
        Panel2.PerformLayout()
        Panel3.ResumeLayout(False)
        Panel3.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Panel4 As Panel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents lblUsername As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents halfday As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Panel3 As Panel
    Friend WithEvents late As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents attendancePanel As Panel
    Friend WithEvents absentday As Label
    Friend WithEvents presentday As Label
End Class
