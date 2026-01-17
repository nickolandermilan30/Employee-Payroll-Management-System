<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Homepage
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Homepage))
        Panel1 = New Panel()
        Panel7 = New Panel()
        Attendance = New Button()
        Panel6 = New Panel()
        History = New Button()
        Panel5 = New Panel()
        logout = New Button()
        Panel4 = New Panel()
        Payroll = New Button()
        Panel3 = New Panel()
        Employee = New Button()
        Panel2 = New Panel()
        Home = New Button()
        Label1 = New Label()
        username = New Label()
        PictureBox1 = New PictureBox()
        View = New Panel()
        Panel1.SuspendLayout()
        Panel7.SuspendLayout()
        Panel6.SuspendLayout()
        Panel5.SuspendLayout()
        Panel4.SuspendLayout()
        Panel3.SuspendLayout()
        Panel2.SuspendLayout()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Panel1
        ' 
        Panel1.BackColor = Color.FromArgb(CByte(38), CByte(49), CByte(64))
        Panel1.Controls.Add(Panel7)
        Panel1.Controls.Add(Panel6)
        Panel1.Controls.Add(Panel5)
        Panel1.Controls.Add(Panel4)
        Panel1.Controls.Add(Panel3)
        Panel1.Controls.Add(Panel2)
        Panel1.Controls.Add(Label1)
        Panel1.Controls.Add(username)
        Panel1.Controls.Add(PictureBox1)
        Panel1.Dock = DockStyle.Left
        Panel1.Location = New Point(0, 0)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(190, 782)
        Panel1.TabIndex = 0
        ' 
        ' Panel7
        ' 
        Panel7.Controls.Add(Attendance)
        Panel7.Location = New Point(3, 341)
        Panel7.Name = "Panel7"
        Panel7.Size = New Size(193, 47)
        Panel7.TabIndex = 8
        ' 
        ' Attendance
        ' 
        Attendance.BackColor = Color.FromArgb(CByte(38), CByte(49), CByte(64))
        Attendance.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Attendance.ForeColor = Color.White
        Attendance.Image = CType(resources.GetObject("Attendance.Image"), Image)
        Attendance.ImageAlign = ContentAlignment.MiddleLeft
        Attendance.Location = New Point(-13, -11)
        Attendance.Name = "Attendance"
        Attendance.Padding = New Padding(25, 0, 35, 0)
        Attendance.Size = New Size(207, 64)
        Attendance.TabIndex = 7
        Attendance.Text = "        Attendance"
        Attendance.UseVisualStyleBackColor = False
        ' 
        ' Panel6
        ' 
        Panel6.Controls.Add(History)
        Panel6.Location = New Point(0, 457)
        Panel6.Name = "Panel6"
        Panel6.Size = New Size(187, 47)
        Panel6.TabIndex = 7
        ' 
        ' History
        ' 
        History.BackColor = Color.FromArgb(CByte(38), CByte(49), CByte(64))
        History.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        History.ForeColor = Color.White
        History.Image = CType(resources.GetObject("History.Image"), Image)
        History.ImageAlign = ContentAlignment.MiddleLeft
        History.Location = New Point(-9, -12)
        History.Name = "History"
        History.Padding = New Padding(25, 0, 35, 0)
        History.Size = New Size(199, 64)
        History.TabIndex = 6
        History.Text = "  History"
        History.UseVisualStyleBackColor = False
        ' 
        ' Panel5
        ' 
        Panel5.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
        Panel5.Controls.Add(logout)
        Panel5.Location = New Point(6, 710)
        Panel5.Name = "Panel5"
        Panel5.Size = New Size(190, 48)
        Panel5.TabIndex = 7
        ' 
        ' logout
        ' 
        logout.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
        logout.BackColor = Color.FromArgb(CByte(208), CByte(39), CByte(82))
        logout.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        logout.ForeColor = Color.White
        logout.Image = CType(resources.GetObject("logout.Image"), Image)
        logout.ImageAlign = ContentAlignment.MiddleLeft
        logout.Location = New Point(-6, -7)
        logout.Name = "logout"
        logout.Padding = New Padding(25, 0, 35, 0)
        logout.Size = New Size(203, 64)
        logout.TabIndex = 6
        logout.Text = "Logout"
        logout.UseVisualStyleBackColor = False
        ' 
        ' Panel4
        ' 
        Panel4.Controls.Add(Payroll)
        Panel4.Location = New Point(0, 400)
        Panel4.Name = "Panel4"
        Panel4.Size = New Size(182, 44)
        Panel4.TabIndex = 6
        ' 
        ' Payroll
        ' 
        Payroll.BackColor = Color.FromArgb(CByte(38), CByte(49), CByte(64))
        Payroll.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Payroll.ForeColor = Color.White
        Payroll.Image = CType(resources.GetObject("Payroll.Image"), Image)
        Payroll.ImageAlign = ContentAlignment.MiddleLeft
        Payroll.Location = New Point(-8, -13)
        Payroll.Name = "Payroll"
        Payroll.Padding = New Padding(25, 0, 35, 0)
        Payroll.Size = New Size(203, 64)
        Payroll.TabIndex = 5
        Payroll.Text = "Payroll"
        Payroll.UseVisualStyleBackColor = False
        ' 
        ' Panel3
        ' 
        Panel3.Controls.Add(Employee)
        Panel3.Location = New Point(6, 280)
        Panel3.Name = "Panel3"
        Panel3.Size = New Size(182, 44)
        Panel3.TabIndex = 5
        ' 
        ' Employee
        ' 
        Employee.BackColor = Color.FromArgb(CByte(38), CByte(49), CByte(64))
        Employee.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Employee.ForeColor = Color.White
        Employee.Image = CType(resources.GetObject("Employee.Image"), Image)
        Employee.ImageAlign = ContentAlignment.MiddleLeft
        Employee.Location = New Point(-16, -9)
        Employee.Name = "Employee"
        Employee.Padding = New Padding(25, 0, 35, 0)
        Employee.Size = New Size(203, 64)
        Employee.TabIndex = 4
        Employee.Text = "      Employee"
        Employee.UseVisualStyleBackColor = False
        ' 
        ' Panel2
        ' 
        Panel2.Controls.Add(Home)
        Panel2.Location = New Point(6, 225)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(182, 44)
        Panel2.TabIndex = 4
        ' 
        ' Home
        ' 
        Home.BackColor = Color.FromArgb(CByte(38), CByte(49), CByte(64))
        Home.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Home.ForeColor = Color.White
        Home.Image = CType(resources.GetObject("Home.Image"), Image)
        Home.ImageAlign = ContentAlignment.MiddleLeft
        Home.Location = New Point(-16, -8)
        Home.Name = "Home"
        Home.Padding = New Padding(25, 0, 35, 0)
        Home.Size = New Size(203, 64)
        Home.TabIndex = 3
        Home.Text = "Home"
        Home.UseVisualStyleBackColor = False
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Century Gothic", 8.25F)
        Label1.ForeColor = Color.White
        Label1.Location = New Point(83, 56)
        Label1.Name = "Label1"
        Label1.Size = New Size(63, 16)
        Label1.TabIndex = 2
        Label1.Text = "Admin Site"
        ' 
        ' username
        ' 
        username.AutoSize = True
        username.Font = New Font("Century Gothic", 12F, FontStyle.Bold)
        username.ForeColor = Color.White
        username.Location = New Point(81, 34)
        username.Name = "username"
        username.Size = New Size(87, 19)
        username.TabIndex = 1
        username.Text = "Username"
        ' 
        ' PictureBox1
        ' 
        PictureBox1.BackColor = Color.Transparent
        PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), Image)
        PictureBox1.Location = New Point(21, 31)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(43, 41)
        PictureBox1.SizeMode = PictureBoxSizeMode.Zoom
        PictureBox1.TabIndex = 0
        PictureBox1.TabStop = False
        ' 
        ' View
        ' 
        View.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        View.BackColor = SystemColors.AppWorkspace
        View.Location = New Point(185, 0)
        View.Name = "View"
        View.Size = New Size(1132, 782)
        View.TabIndex = 1
        ' 
        ' Homepage
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1313, 782)
        Controls.Add(View)
        Controls.Add(Panel1)
        Name = "Homepage"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Admin"
        WindowState = FormWindowState.Maximized
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        Panel7.ResumeLayout(False)
        Panel6.ResumeLayout(False)
        Panel5.ResumeLayout(False)
        Panel4.ResumeLayout(False)
        Panel3.ResumeLayout(False)
        Panel2.ResumeLayout(False)
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents username As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Home As Button
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Employee As Button
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Payroll As Button
    Friend WithEvents logout As Button
    Friend WithEvents Panel5 As Panel
    Friend WithEvents View As Panel
    Friend WithEvents Panel6 As Panel
    Friend WithEvents History As Button
    Friend WithEvents Panel7 As Panel
    Friend WithEvents Attendance As Button
End Class
