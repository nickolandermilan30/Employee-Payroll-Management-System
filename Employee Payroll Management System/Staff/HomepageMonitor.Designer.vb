<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class HomepageMonitor
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(HomepageMonitor))
        Panel2 = New Panel()
        Home = New Button()
        PictureBox1 = New PictureBox()
        lblUsername = New Label()
        Label1 = New Label()
        Panel1 = New Panel()
        Panel5 = New Panel()
        logout = New Button()
        Panel3 = New Panel()
        Salary = New Button()
        SalaryHistiory = New Button()
        Panel4 = New Panel()
        View = New Panel()
        Panel2.SuspendLayout()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        Panel1.SuspendLayout()
        Panel5.SuspendLayout()
        Panel3.SuspendLayout()
        Panel4.SuspendLayout()
        SuspendLayout()
        ' 
        ' Panel2
        ' 
        Panel2.Anchor = AnchorStyles.Top
        Panel2.Controls.Add(Home)
        Panel2.Location = New Point(490, 20)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(116, 44)
        Panel2.TabIndex = 4
        ' 
        ' Home
        ' 
        Home.BackColor = Color.FromArgb(CByte(38), CByte(49), CByte(64))
        Home.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Home.ForeColor = Color.White
        Home.ImageAlign = ContentAlignment.MiddleLeft
        Home.Location = New Point(-9, -4)
        Home.Name = "Home"
        Home.Size = New Size(136, 52)
        Home.TabIndex = 3
        Home.Text = "Attendance"
        Home.UseVisualStyleBackColor = False
        ' 
        ' PictureBox1
        ' 
        PictureBox1.BackColor = Color.Transparent
        PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), Image)
        PictureBox1.Location = New Point(26, 17)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(66, 57)
        PictureBox1.SizeMode = PictureBoxSizeMode.Zoom
        PictureBox1.TabIndex = 0
        PictureBox1.TabStop = False
        ' 
        ' lblUsername
        ' 
        lblUsername.AutoSize = True
        lblUsername.Font = New Font("Century Gothic", 11.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblUsername.ForeColor = Color.Black
        lblUsername.Location = New Point(13, 6)
        lblUsername.Name = "lblUsername"
        lblUsername.Size = New Size(82, 18)
        lblUsername.TabIndex = 1
        lblUsername.Text = "Username"
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label1.ForeColor = Color.Black
        Label1.Location = New Point(15, 27)
        Label1.Name = "Label1"
        Label1.Size = New Size(92, 17)
        Label1.TabIndex = 2
        Label1.Text = "Employee Site"
        ' 
        ' Panel1
        ' 
        Panel1.BackColor = Color.FromArgb(CByte(38), CByte(49), CByte(64))
        Panel1.Controls.Add(Panel5)
        Panel1.Controls.Add(Panel3)
        Panel1.Controls.Add(PictureBox1)
        Panel1.Controls.Add(Panel4)
        Panel1.Controls.Add(Panel2)
        Panel1.Dock = DockStyle.Top
        Panel1.Location = New Point(0, 0)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(1313, 90)
        Panel1.TabIndex = 1
        ' 
        ' Panel5
        ' 
        Panel5.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        Panel5.Controls.Add(logout)
        Panel5.Location = New Point(1240, 20)
        Panel5.Name = "Panel5"
        Panel5.Size = New Size(61, 48)
        Panel5.TabIndex = 8
        ' 
        ' logout
        ' 
        logout.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
        logout.BackColor = Color.FromArgb(CByte(208), CByte(39), CByte(82))
        logout.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        logout.ForeColor = Color.White
        logout.Image = CType(resources.GetObject("logout.Image"), Image)
        logout.ImageAlign = ContentAlignment.MiddleLeft
        logout.Location = New Point(-8, -9)
        logout.Name = "logout"
        logout.Padding = New Padding(25, 0, 35, 0)
        logout.Size = New Size(76, 64)
        logout.TabIndex = 7
        logout.UseVisualStyleBackColor = False
        ' 
        ' Panel3
        ' 
        Panel3.Anchor = AnchorStyles.Top
        Panel3.Controls.Add(Salary)
        Panel3.Controls.Add(SalaryHistiory)
        Panel3.Font = New Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Panel3.Location = New Point(644, 20)
        Panel3.Name = "Panel3"
        Panel3.Size = New Size(148, 44)
        Panel3.TabIndex = 5
        ' 
        ' Salary
        ' 
        Salary.BackColor = Color.FromArgb(CByte(38), CByte(49), CByte(64))
        Salary.Font = New Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Salary.ForeColor = Color.White
        Salary.ImageAlign = ContentAlignment.MiddleLeft
        Salary.Location = New Point(-6, -6)
        Salary.Name = "Salary"
        Salary.Size = New Size(161, 56)
        Salary.TabIndex = 4
        Salary.Text = "Salary Transaction"
        Salary.UseVisualStyleBackColor = False
        ' 
        ' SalaryHistiory
        ' 
        SalaryHistiory.BackColor = Color.FromArgb(CByte(38), CByte(49), CByte(64))
        SalaryHistiory.Font = New Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        SalaryHistiory.ForeColor = Color.White
        SalaryHistiory.ImageAlign = ContentAlignment.MiddleLeft
        SalaryHistiory.Location = New Point(-8, -6)
        SalaryHistiory.Name = "SalaryHistiory"
        SalaryHistiory.Size = New Size(161, 56)
        SalaryHistiory.TabIndex = 3
        SalaryHistiory.Text = "Salary Transaction"
        SalaryHistiory.UseVisualStyleBackColor = False
        ' 
        ' Panel4
        ' 
        Panel4.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        Panel4.BackColor = Color.FromArgb(CByte(250), CByte(129), CByte(18))
        Panel4.Controls.Add(Label1)
        Panel4.Controls.Add(lblUsername)
        Panel4.Location = New Point(992, 20)
        Panel4.Name = "Panel4"
        Panel4.Size = New Size(235, 48)
        Panel4.TabIndex = 6
        ' 
        ' View
        ' 
        View.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        View.BackColor = SystemColors.AppWorkspace
        View.Location = New Point(0, 83)
        View.Name = "View"
        View.Size = New Size(1314, 701)
        View.TabIndex = 2
        ' 
        ' HomepageMonitor
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1313, 782)
        Controls.Add(Panel1)
        Controls.Add(View)
        Name = "HomepageMonitor"
        Text = "HomepageMonitor"
        WindowState = FormWindowState.Maximized
        Panel2.ResumeLayout(False)
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        Panel1.ResumeLayout(False)
        Panel5.ResumeLayout(False)
        Panel3.ResumeLayout(False)
        Panel4.ResumeLayout(False)
        Panel4.PerformLayout()
        ResumeLayout(False)
    End Sub
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Home As Button
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents lblUsername As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents SalaryHistiory As Button
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Panel5 As Panel
    Friend WithEvents logout As Button
    Friend WithEvents Salary As Button
    Friend WithEvents View As Panel
End Class
