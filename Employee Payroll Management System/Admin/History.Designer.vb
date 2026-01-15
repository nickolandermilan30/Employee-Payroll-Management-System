<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class History
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
        Label2 = New Label()
        Label1 = New Label()
        payrollhistorylist = New Panel()
        search = New TextBox()
        Label3 = New Label()
        SuspendLayout()
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.BackColor = SystemColors.Control
        Label2.Font = New Font("Century Gothic", 12F, FontStyle.Bold)
        Label2.ForeColor = SystemColors.ControlDarkDark
        Label2.Location = New Point(29, 79)
        Label2.Name = "Label2"
        Label2.Size = New Size(490, 19)
        Label2.TabIndex = 10
        Label2.Text = "Ensure timely and precise payroll processing for all employees."
        Label2.TextAlign = ContentAlignment.TopCenter
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.BackColor = SystemColors.Control
        Label1.Font = New Font("Century Gothic", 20.25F, FontStyle.Bold)
        Label1.Location = New Point(27, 37)
        Label1.Name = "Label1"
        Label1.Size = New Size(208, 32)
        Label1.TabIndex = 9
        Label1.Text = "Process Payroll"
        ' 
        ' payrollhistorylist
        ' 
        payrollhistorylist.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        payrollhistorylist.Location = New Point(35, 124)
        payrollhistorylist.Name = "payrollhistorylist"
        payrollhistorylist.Size = New Size(1004, 484)
        payrollhistorylist.TabIndex = 11
        ' 
        ' search
        ' 
        search.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        search.BackColor = SystemColors.Window
        search.BorderStyle = BorderStyle.FixedSingle
        search.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        search.ForeColor = SystemColors.InfoText
        search.Location = New Point(787, 44)
        search.Margin = New Padding(3, 4, 3, 3)
        search.Multiline = True
        search.Name = "search"
        search.Size = New Size(252, 26)
        search.TabIndex = 6
        search.Tag = ""
        ' 
        ' Label3
        ' 
        Label3.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        Label3.AutoSize = True
        Label3.BackColor = SystemColors.Control
        Label3.Font = New Font("Century Gothic", 14.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label3.ForeColor = SystemColors.ActiveCaptionText
        Label3.Location = New Point(707, 46)
        Label3.Name = "Label3"
        Label3.Size = New Size(74, 23)
        Label3.TabIndex = 12
        Label3.Text = "Search"
        Label3.TextAlign = ContentAlignment.TopCenter
        ' 
        ' History
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1076, 645)
        Controls.Add(Label3)
        Controls.Add(search)
        Controls.Add(payrollhistorylist)
        Controls.Add(Label2)
        Controls.Add(Label1)
        FormBorderStyle = FormBorderStyle.None
        Name = "History"
        Text = "History"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents payrollhistorylist As Panel
    Friend WithEvents search As TextBox
    Friend WithEvents Label3 As Label
End Class
