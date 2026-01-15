<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Employee
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Employee))
        Label2 = New Label()
        Label1 = New Label()
        employelist = New Panel()
        search = New TextBox()
        Role = New ComboBox()
        Panel1 = New Panel()
        Refresh = New Button()
        Label3 = New Label()
        Label4 = New Label()
        Panel1.SuspendLayout()
        SuspendLayout()
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.BackColor = SystemColors.Control
        Label2.Font = New Font("Century Gothic", 12F, FontStyle.Bold)
        Label2.ForeColor = SystemColors.ControlDarkDark
        Label2.Location = New Point(27, 79)
        Label2.Name = "Label2"
        Label2.Size = New Size(410, 19)
        Label2.TabIndex = 6
        Label2.Text = "Manage and organize employee records efficiently."
        Label2.TextAlign = ContentAlignment.TopCenter
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.BackColor = SystemColors.Control
        Label1.Font = New Font("Century Gothic", 20.25F, FontStyle.Bold)
        Label1.Location = New Point(27, 37)
        Label1.Name = "Label1"
        Label1.Size = New Size(393, 32)
        Label1.TabIndex = 5
        Label1.Text = "Manage Employee Members"
        ' 
        ' employelist
        ' 
        employelist.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        employelist.Location = New Point(67, 186)
        employelist.Name = "employelist"
        employelist.Size = New Size(964, 488)
        employelist.TabIndex = 7
        ' 
        ' search
        ' 
        search.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        search.BackColor = SystemColors.Window
        search.BorderStyle = BorderStyle.FixedSingle
        search.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        search.ForeColor = SystemColors.InfoText
        search.Location = New Point(147, 138)
        search.Margin = New Padding(3, 4, 3, 3)
        search.Multiline = True
        search.Name = "search"
        search.Size = New Size(735, 26)
        search.TabIndex = 5
        search.Tag = ""
        ' 
        ' Role
        ' 
        Role.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        Role.FormattingEnabled = True
        Role.Location = New Point(909, 137)
        Role.Name = "Role"
        Role.Size = New Size(121, 23)
        Role.TabIndex = 8
        ' 
        ' Panel1
        ' 
        Panel1.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        Panel1.Controls.Add(Refresh)
        Panel1.Location = New Point(883, 50)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(148, 39)
        Panel1.TabIndex = 9
        ' 
        ' Refresh
        ' 
        Refresh.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        Refresh.BackColor = Color.ForestGreen
        Refresh.Font = New Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Refresh.ForeColor = Color.White
        Refresh.Image = CType(resources.GetObject("Refresh.Image"), Image)
        Refresh.ImageAlign = ContentAlignment.MiddleLeft
        Refresh.Location = New Point(-4, -10)
        Refresh.Name = "Refresh"
        Refresh.Padding = New Padding(25, 0, 0, 0)
        Refresh.Size = New Size(156, 59)
        Refresh.TabIndex = 10
        Refresh.Text = "Refresh"
        Refresh.UseVisualStyleBackColor = False
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.BackColor = SystemColors.Control
        Label3.Font = New Font("Century Gothic", 14.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label3.ForeColor = SystemColors.ActiveCaptionText
        Label3.Location = New Point(67, 139)
        Label3.Name = "Label3"
        Label3.Size = New Size(74, 23)
        Label3.TabIndex = 10
        Label3.Text = "Search"
        Label3.TextAlign = ContentAlignment.TopCenter
        ' 
        ' Label4
        ' 
        Label4.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        Label4.AutoSize = True
        Label4.BackColor = SystemColors.Control
        Label4.Font = New Font("Century Gothic", 9.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label4.ForeColor = SystemColors.ActiveCaptionText
        Label4.Location = New Point(909, 118)
        Label4.Name = "Label4"
        Label4.Size = New Size(35, 16)
        Label4.TabIndex = 11
        Label4.Text = "Role"
        Label4.TextAlign = ContentAlignment.TopCenter
        ' 
        ' Employee
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1108, 723)
        Controls.Add(Label4)
        Controls.Add(Label3)
        Controls.Add(Panel1)
        Controls.Add(Role)
        Controls.Add(search)
        Controls.Add(employelist)
        Controls.Add(Label2)
        Controls.Add(Label1)
        FormBorderStyle = FormBorderStyle.None
        Name = "Employee"
        Text = "Employee"
        Panel1.ResumeLayout(False)
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents employelist As Panel
    Friend WithEvents search As TextBox
    Friend WithEvents Role As ComboBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Refresh As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
End Class
