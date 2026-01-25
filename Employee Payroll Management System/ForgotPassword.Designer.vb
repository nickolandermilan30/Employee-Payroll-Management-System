<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ForgotPassword
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ForgotPassword))
        BackBtn = New Button()
        Showpassword = New CheckBox()
        SetNewpassword = New Button()
        Label4 = New Label()
        namesinfo = New Label()
        NewPassword = New TextBox()
        Email = New TextBox()
        Label2 = New Label()
        Label1 = New Label()
        PictureBox2 = New PictureBox()
        PictureBox1 = New PictureBox()
        PictureBox3 = New PictureBox()
        Panel1 = New Panel()
        Datecreated = New Label()
        Username = New Label()
        PictureBox4 = New PictureBox()
        Label5 = New Label()
        typeofinfo = New ComboBox()
        AttemptTimerLabel = New Label()
        CType(PictureBox2, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox3, ComponentModel.ISupportInitialize).BeginInit()
        Panel1.SuspendLayout()
        CType(PictureBox4, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' BackBtn
        ' 
        BackBtn.Anchor = AnchorStyles.Top
        BackBtn.BackColor = Color.FromArgb(CByte(38), CByte(49), CByte(64))
        BackBtn.FlatStyle = FlatStyle.Flat
        BackBtn.Font = New Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        BackBtn.ForeColor = Color.White
        BackBtn.Location = New Point(631, 576)
        BackBtn.Name = "BackBtn"
        BackBtn.Size = New Size(433, 56)
        BackBtn.TabIndex = 53
        BackBtn.Text = "Back to Sign in"
        BackBtn.UseVisualStyleBackColor = False
        ' 
        ' Showpassword
        ' 
        Showpassword.Anchor = AnchorStyles.Top
        Showpassword.AutoSize = True
        Showpassword.BackColor = SystemColors.Window
        Showpassword.Location = New Point(956, 455)
        Showpassword.Name = "Showpassword"
        Showpassword.Size = New Size(108, 19)
        Showpassword.TabIndex = 51
        Showpassword.Text = "Show Password"
        Showpassword.UseVisualStyleBackColor = False
        ' 
        ' SetNewpassword
        ' 
        SetNewpassword.Anchor = AnchorStyles.Top
        SetNewpassword.BackColor = Color.DeepSkyBlue
        SetNewpassword.FlatStyle = FlatStyle.Flat
        SetNewpassword.Font = New Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        SetNewpassword.ForeColor = Color.White
        SetNewpassword.Location = New Point(631, 501)
        SetNewpassword.Name = "SetNewpassword"
        SetNewpassword.Size = New Size(433, 56)
        SetNewpassword.TabIndex = 50
        SetNewpassword.Text = "Set Password"
        SetNewpassword.UseVisualStyleBackColor = False
        ' 
        ' Label4
        ' 
        Label4.Anchor = AnchorStyles.Top
        Label4.AutoSize = True
        Label4.BackColor = SystemColors.Window
        Label4.Font = New Font("Segoe UI Variable Display", 9.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label4.ForeColor = SystemColors.InfoText
        Label4.Location = New Point(631, 384)
        Label4.Name = "Label4"
        Label4.Size = New Size(96, 17)
        Label4.TabIndex = 49
        Label4.Text = "New Password"
        Label4.TextAlign = ContentAlignment.TopCenter
        ' 
        ' namesinfo
        ' 
        namesinfo.Anchor = AnchorStyles.Top
        namesinfo.AutoSize = True
        namesinfo.BackColor = SystemColors.Window
        namesinfo.Font = New Font("Segoe UI Variable Display", 9.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        namesinfo.ForeColor = SystemColors.InfoText
        namesinfo.Location = New Point(633, 304)
        namesinfo.Name = "namesinfo"
        namesinfo.Size = New Size(182, 17)
        namesinfo.TabIndex = 48
        namesinfo.Text = "Add Email or Phone number "
        namesinfo.TextAlign = ContentAlignment.TopCenter
        ' 
        ' NewPassword
        ' 
        NewPassword.Anchor = AnchorStyles.Top
        NewPassword.BackColor = SystemColors.Window
        NewPassword.BorderStyle = BorderStyle.FixedSingle
        NewPassword.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        NewPassword.ForeColor = SystemColors.InfoText
        NewPassword.Location = New Point(631, 404)
        NewPassword.Name = "NewPassword"
        NewPassword.Size = New Size(433, 29)
        NewPassword.TabIndex = 47
        NewPassword.UseSystemPasswordChar = True
        ' 
        ' Email
        ' 
        Email.Anchor = AnchorStyles.Top
        Email.BackColor = SystemColors.Window
        Email.BorderStyle = BorderStyle.FixedSingle
        Email.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Email.ForeColor = SystemColors.InfoText
        Email.Location = New Point(633, 325)
        Email.Margin = New Padding(3, 4, 3, 3)
        Email.Multiline = True
        Email.Name = "Email"
        Email.Size = New Size(433, 31)
        Email.TabIndex = 46
        ' 
        ' Label2
        ' 
        Label2.Anchor = AnchorStyles.Top
        Label2.AutoSize = True
        Label2.BackColor = SystemColors.Window
        Label2.Font = New Font("Segoe UI Variable Display", 14.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label2.ForeColor = SystemColors.ControlDarkDark
        Label2.Location = New Point(240, 300)
        Label2.Name = "Label2"
        Label2.Size = New Size(161, 26)
        Label2.TabIndex = 45
        Label2.Text = "Forget Password"
        Label2.TextAlign = ContentAlignment.TopCenter
        ' 
        ' Label1
        ' 
        Label1.Anchor = AnchorStyles.Top
        Label1.AutoSize = True
        Label1.BackColor = SystemColors.Window
        Label1.Font = New Font("Segoe UI Variable Display", 20.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.Location = New Point(184, 215)
        Label1.Name = "Label1"
        Label1.Size = New Size(282, 72)
        Label1.TabIndex = 44
        Label1.Text = "Employee Payroll " & vbCrLf & "Management System"
        Label1.TextAlign = ContentAlignment.TopCenter
        ' 
        ' PictureBox2
        ' 
        PictureBox2.Anchor = AnchorStyles.Top
        PictureBox2.BackColor = SystemColors.Window
        PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), Image)
        PictureBox2.Location = New Point(271, 117)
        PictureBox2.Name = "PictureBox2"
        PictureBox2.Size = New Size(100, 86)
        PictureBox2.SizeMode = PictureBoxSizeMode.Zoom
        PictureBox2.TabIndex = 43
        PictureBox2.TabStop = False
        ' 
        ' PictureBox1
        ' 
        PictureBox1.Anchor = AnchorStyles.Top
        PictureBox1.BackColor = SystemColors.Control
        PictureBox1.Image = My.Resources.Resources.Box
        PictureBox1.Location = New Point(70, 99)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(500, 407)
        PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
        PictureBox1.TabIndex = 42
        PictureBox1.TabStop = False
        ' 
        ' PictureBox3
        ' 
        PictureBox3.Anchor = AnchorStyles.Top
        PictureBox3.BackColor = SystemColors.Control
        PictureBox3.Image = My.Resources.Resources.Box
        PictureBox3.Location = New Point(595, 99)
        PictureBox3.Name = "PictureBox3"
        PictureBox3.Size = New Size(500, 583)
        PictureBox3.SizeMode = PictureBoxSizeMode.StretchImage
        PictureBox3.TabIndex = 54
        PictureBox3.TabStop = False
        ' 
        ' Panel1
        ' 
        Panel1.Anchor = AnchorStyles.Top
        Panel1.BackColor = Color.FromArgb(CByte(38), CByte(49), CByte(64))
        Panel1.Controls.Add(Datecreated)
        Panel1.Controls.Add(Username)
        Panel1.Controls.Add(PictureBox4)
        Panel1.Location = New Point(631, 153)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(435, 113)
        Panel1.TabIndex = 55
        ' 
        ' Datecreated
        ' 
        Datecreated.Anchor = AnchorStyles.Top
        Datecreated.AutoSize = True
        Datecreated.BackColor = Color.Transparent
        Datecreated.Font = New Font("Segoe UI Variable Display", 9.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Datecreated.ForeColor = SystemColors.Window
        Datecreated.Location = New Point(115, 57)
        Datecreated.Name = "Datecreated"
        Datecreated.Size = New Size(36, 17)
        Datecreated.TabIndex = 61
        Datecreated.Text = "Date"
        ' 
        ' Username
        ' 
        Username.Anchor = AnchorStyles.Top
        Username.AutoSize = True
        Username.BackColor = Color.Transparent
        Username.Font = New Font("Segoe UI Variable Display", 14.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Username.ForeColor = SystemColors.Window
        Username.Location = New Point(113, 31)
        Username.Name = "Username"
        Username.Size = New Size(101, 26)
        Username.TabIndex = 60
        Username.Text = "Username"
        ' 
        ' PictureBox4
        ' 
        PictureBox4.Anchor = AnchorStyles.Top
        PictureBox4.Image = CType(resources.GetObject("PictureBox4.Image"), Image)
        PictureBox4.Location = New Point(30, 23)
        PictureBox4.Name = "PictureBox4"
        PictureBox4.Size = New Size(68, 59)
        PictureBox4.SizeMode = PictureBoxSizeMode.Zoom
        PictureBox4.TabIndex = 0
        PictureBox4.TabStop = False
        ' 
        ' Label5
        ' 
        Label5.Anchor = AnchorStyles.Top
        Label5.AutoSize = True
        Label5.BackColor = SystemColors.Window
        Label5.Font = New Font("Segoe UI Variable Display", 9.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label5.ForeColor = SystemColors.InfoText
        Label5.Location = New Point(113, 369)
        Label5.Name = "Label5"
        Label5.Size = New Size(81, 17)
        Label5.TabIndex = 57
        Label5.Text = "Backup Info"
        Label5.TextAlign = ContentAlignment.TopCenter
        ' 
        ' typeofinfo
        ' 
        typeofinfo.Anchor = AnchorStyles.Top
        typeofinfo.FormattingEnabled = True
        typeofinfo.Location = New Point(113, 389)
        typeofinfo.Name = "typeofinfo"
        typeofinfo.Size = New Size(407, 23)
        typeofinfo.TabIndex = 58
        ' 
        ' AttemptTimerLabel
        ' 
        AttemptTimerLabel.Anchor = AnchorStyles.Top
        AttemptTimerLabel.AutoSize = True
        AttemptTimerLabel.BackColor = SystemColors.Window
        AttemptTimerLabel.Font = New Font("Segoe UI Variable Display", 14.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        AttemptTimerLabel.ForeColor = SystemColors.ControlDarkDark
        AttemptTimerLabel.Location = New Point(113, 435)
        AttemptTimerLabel.Name = "AttemptTimerLabel"
        AttemptTimerLabel.Size = New Size(0, 26)
        AttemptTimerLabel.TabIndex = 59
        AttemptTimerLabel.TextAlign = ContentAlignment.TopCenter
        ' 
        ' ForgotPassword
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1152, 719)
        Controls.Add(AttemptTimerLabel)
        Controls.Add(typeofinfo)
        Controls.Add(Label5)
        Controls.Add(Panel1)
        Controls.Add(BackBtn)
        Controls.Add(Showpassword)
        Controls.Add(SetNewpassword)
        Controls.Add(Label4)
        Controls.Add(namesinfo)
        Controls.Add(NewPassword)
        Controls.Add(Email)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Controls.Add(PictureBox2)
        Controls.Add(PictureBox1)
        Controls.Add(PictureBox3)
        Name = "ForgotPassword"
        Text = "ForgotPassword"
        WindowState = FormWindowState.Maximized
        CType(PictureBox2, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox3, ComponentModel.ISupportInitialize).EndInit()
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        CType(PictureBox4, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents BackBtn As Button
    Friend WithEvents Showpassword As CheckBox
    Friend WithEvents SetNewpassword As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents namesinfo As Label
    Friend WithEvents NewPassword As TextBox
    Friend WithEvents Email As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents PictureBox3 As PictureBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents PictureBox4 As PictureBox
    Friend WithEvents Label5 As Label
    Friend WithEvents typeofinfo As ComboBox
    Friend WithEvents Username As Label
    Friend WithEvents AttemptTimerLabel As Label
    Friend WithEvents Datecreated As Label
End Class
