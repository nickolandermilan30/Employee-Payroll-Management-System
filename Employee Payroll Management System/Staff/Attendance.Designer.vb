<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Attendance
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
        attendancePanel = New Panel()
        Label1 = New Label()
        SuspendLayout()
        ' 
        ' attendancePanel
        ' 
        attendancePanel.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        attendancePanel.Location = New Point(55, 121)
        attendancePanel.Name = "attendancePanel"
        attendancePanel.Size = New Size(974, 470)
        attendancePanel.TabIndex = 15
        ' 
        ' Label1
        ' 
        Label1.Anchor = AnchorStyles.Top
        Label1.AutoSize = True
        Label1.BackColor = SystemColors.Control
        Label1.Font = New Font("Trebuchet MS", 36F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.Location = New Point(317, 29)
        Label1.Name = "Label1"
        Label1.Size = New Size(469, 61)
        Label1.TabIndex = 14
        Label1.Text = "Monitor Attendance"
        Label1.TextAlign = ContentAlignment.TopCenter
        ' 
        ' Attendance
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1076, 645)
        Controls.Add(Label1)
        Controls.Add(attendancePanel)
        FormBorderStyle = FormBorderStyle.None
        Name = "Attendance"
        Text = "Attendance"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents attendancePanel As Panel
    Friend WithEvents Label1 As Label
End Class
