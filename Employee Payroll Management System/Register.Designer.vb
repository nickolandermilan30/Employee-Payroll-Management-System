<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Register
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Register))
        Showpassword1 = New CheckBox()
        Signup = New Button()
        BackSignin = New Button()
        Label4 = New Label()
        Label3 = New Label()
        Email = New TextBox()
        Username = New TextBox()
        Label1 = New Label()
        PictureBox1 = New PictureBox()
        Label2 = New Label()
        Label5 = New Label()
        Password = New TextBox()
        Label6 = New Label()
        confirmpassword = New TextBox()
        PictureBox3 = New PictureBox()
        Label7 = New Label()
        Label8 = New Label()
        Phonenumber = New TextBox()
        PictureBox4 = New PictureBox()
        Label9 = New Label()
        age = New TextBox()
        gender = New ComboBox()
        Label10 = New Label()
        birthday = New DateTimePicker()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox3, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox4, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Showpassword1
        ' 
        Showpassword1.Anchor = AnchorStyles.Top
        Showpassword1.AutoSize = True
        Showpassword1.BackColor = SystemColors.Window
        Showpassword1.Location = New Point(442, 522)
        Showpassword1.Name = "Showpassword1"
        Showpassword1.Size = New Size(108, 19)
        Showpassword1.TabIndex = 21
        Showpassword1.Text = "Show Password"
        Showpassword1.UseVisualStyleBackColor = False
        ' 
        ' Signup
        ' 
        Signup.Anchor = AnchorStyles.Top
        Signup.BackColor = Color.DeepSkyBlue
        Signup.FlatStyle = FlatStyle.Flat
        Signup.Font = New Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Signup.ForeColor = Color.White
        Signup.Location = New Point(953, 561)
        Signup.Name = "Signup"
        Signup.Size = New Size(173, 51)
        Signup.TabIndex = 20
        Signup.Text = "Sign up"
        Signup.UseVisualStyleBackColor = False
        ' 
        ' BackSignin
        ' 
        BackSignin.Anchor = AnchorStyles.Top
        BackSignin.BackColor = Color.FromArgb(CByte(38), CByte(49), CByte(64))
        BackSignin.FlatStyle = FlatStyle.Flat
        BackSignin.Font = New Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        BackSignin.ForeColor = Color.White
        BackSignin.Location = New Point(716, 561)
        BackSignin.Name = "BackSignin"
        BackSignin.Size = New Size(200, 53)
        BackSignin.TabIndex = 19
        BackSignin.Text = "Back to Sign in "
        BackSignin.UseVisualStyleBackColor = False
        ' 
        ' Label4
        ' 
        Label4.Anchor = AnchorStyles.Top
        Label4.AutoSize = True
        Label4.BackColor = SystemColors.Window
        Label4.Font = New Font("Segoe UI Variable Display", 9.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label4.ForeColor = SystemColors.InfoText
        Label4.Location = New Point(140, 285)
        Label4.Name = "Label4"
        Label4.Size = New Size(42, 17)
        Label4.TabIndex = 18
        Label4.Text = "Email"
        Label4.TextAlign = ContentAlignment.TopCenter
        ' 
        ' Label3
        ' 
        Label3.Anchor = AnchorStyles.Top
        Label3.AutoSize = True
        Label3.BackColor = SystemColors.Window
        Label3.Font = New Font("Segoe UI Variable Display", 9.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label3.ForeColor = SystemColors.InfoText
        Label3.Location = New Point(140, 204)
        Label3.Name = "Label3"
        Label3.Size = New Size(69, 17)
        Label3.TabIndex = 17
        Label3.Text = "Username"
        Label3.TextAlign = ContentAlignment.TopCenter
        ' 
        ' Email
        ' 
        Email.Anchor = AnchorStyles.Top
        Email.BackColor = SystemColors.Window
        Email.BorderStyle = BorderStyle.FixedSingle
        Email.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Email.ForeColor = SystemColors.InfoText
        Email.Location = New Point(140, 305)
        Email.Multiline = True
        Email.Name = "Email"
        Email.Size = New Size(410, 36)
        Email.TabIndex = 16
        ' 
        ' Username
        ' 
        Username.Anchor = AnchorStyles.Top
        Username.BackColor = SystemColors.Window
        Username.BorderStyle = BorderStyle.FixedSingle
        Username.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Username.ForeColor = SystemColors.InfoText
        Username.Location = New Point(140, 224)
        Username.Margin = New Padding(3, 4, 3, 3)
        Username.Multiline = True
        Username.Name = "Username"
        Username.Size = New Size(410, 36)
        Username.TabIndex = 15
        ' 
        ' Label1
        ' 
        Label1.Anchor = AnchorStyles.Top
        Label1.AutoSize = True
        Label1.BackColor = SystemColors.Window
        Label1.Font = New Font("Segoe UI Variable Display", 20.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.Location = New Point(247, 103)
        Label1.Name = "Label1"
        Label1.Size = New Size(209, 36)
        Label1.TabIndex = 13
        Label1.Text = "Create account"
        Label1.TextAlign = ContentAlignment.TopCenter
        ' 
        ' PictureBox1
        ' 
        PictureBox1.Anchor = AnchorStyles.Top
        PictureBox1.BackColor = SystemColors.Control
        PictureBox1.Image = My.Resources.Resources.Box
        PictureBox1.Location = New Point(93, 47)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(540, 549)
        PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
        PictureBox1.TabIndex = 11
        PictureBox1.TabStop = False
        ' 
        ' Label2
        ' 
        Label2.Anchor = AnchorStyles.Top
        Label2.AutoSize = True
        Label2.BackColor = SystemColors.Window
        Label2.Font = New Font("Segoe UI Variable Display", 14.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label2.ForeColor = SystemColors.ControlDarkDark
        Label2.Location = New Point(310, 152)
        Label2.Name = "Label2"
        Label2.Size = New Size(78, 26)
        Label2.TabIndex = 22
        Label2.Text = "Sign up"
        Label2.TextAlign = ContentAlignment.TopCenter
        ' 
        ' Label5
        ' 
        Label5.Anchor = AnchorStyles.Top
        Label5.AutoSize = True
        Label5.BackColor = SystemColors.Window
        Label5.Font = New Font("Segoe UI Variable Display", 9.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label5.ForeColor = SystemColors.InfoText
        Label5.Location = New Point(140, 368)
        Label5.Name = "Label5"
        Label5.Size = New Size(66, 17)
        Label5.TabIndex = 24
        Label5.Text = "Password"
        Label5.TextAlign = ContentAlignment.TopCenter
        ' 
        ' Password
        ' 
        Password.Anchor = AnchorStyles.Top
        Password.BackColor = SystemColors.Window
        Password.BorderStyle = BorderStyle.FixedSingle
        Password.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Password.ForeColor = SystemColors.InfoText
        Password.Location = New Point(140, 388)
        Password.Multiline = True
        Password.Name = "Password"
        Password.Size = New Size(410, 36)
        Password.TabIndex = 23
        ' 
        ' Label6
        ' 
        Label6.Anchor = AnchorStyles.Top
        Label6.AutoSize = True
        Label6.BackColor = SystemColors.Window
        Label6.Font = New Font("Segoe UI Variable Display", 9.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label6.ForeColor = SystemColors.InfoText
        Label6.Location = New Point(140, 448)
        Label6.Name = "Label6"
        Label6.Size = New Size(120, 17)
        Label6.TabIndex = 27
        Label6.Text = "Confirm Password"
        Label6.TextAlign = ContentAlignment.TopCenter
        ' 
        ' confirmpassword
        ' 
        confirmpassword.Anchor = AnchorStyles.Top
        confirmpassword.BackColor = SystemColors.Window
        confirmpassword.BorderStyle = BorderStyle.FixedSingle
        confirmpassword.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        confirmpassword.ForeColor = SystemColors.InfoText
        confirmpassword.Location = New Point(140, 468)
        confirmpassword.Multiline = True
        confirmpassword.Name = "confirmpassword"
        confirmpassword.Size = New Size(410, 36)
        confirmpassword.TabIndex = 26
        ' 
        ' PictureBox3
        ' 
        PictureBox3.Anchor = AnchorStyles.Top
        PictureBox3.BackColor = SystemColors.Control
        PictureBox3.Image = My.Resources.Resources.Box
        PictureBox3.Location = New Point(652, 47)
        PictureBox3.Name = "PictureBox3"
        PictureBox3.Size = New Size(540, 625)
        PictureBox3.SizeMode = PictureBoxSizeMode.StretchImage
        PictureBox3.TabIndex = 28
        PictureBox3.TabStop = False
        ' 
        ' Label7
        ' 
        Label7.Anchor = AnchorStyles.Top
        Label7.AutoSize = True
        Label7.BackColor = SystemColors.Window
        Label7.Font = New Font("Segoe UI Variable Display", 9.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label7.ForeColor = SystemColors.InfoText
        Label7.Location = New Point(716, 377)
        Label7.Name = "Label7"
        Label7.Size = New Size(63, 17)
        Label7.TabIndex = 32
        Label7.Text = "Birthday "
        Label7.TextAlign = ContentAlignment.TopCenter
        ' 
        ' Label8
        ' 
        Label8.Anchor = AnchorStyles.Top
        Label8.AutoSize = True
        Label8.BackColor = SystemColors.Window
        Label8.Font = New Font("Segoe UI Variable Display", 9.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label8.ForeColor = SystemColors.InfoText
        Label8.Location = New Point(716, 302)
        Label8.Name = "Label8"
        Label8.Size = New Size(107, 17)
        Label8.TabIndex = 31
        Label8.Text = "Mobile Number "
        Label8.TextAlign = ContentAlignment.TopCenter
        ' 
        ' Phonenumber
        ' 
        Phonenumber.Anchor = AnchorStyles.Top
        Phonenumber.BackColor = SystemColors.Window
        Phonenumber.BorderStyle = BorderStyle.FixedSingle
        Phonenumber.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Phonenumber.ForeColor = SystemColors.InfoText
        Phonenumber.Location = New Point(716, 322)
        Phonenumber.Margin = New Padding(3, 4, 3, 3)
        Phonenumber.Multiline = True
        Phonenumber.Name = "Phonenumber"
        Phonenumber.Size = New Size(410, 26)
        Phonenumber.TabIndex = 29
        ' 
        ' PictureBox4
        ' 
        PictureBox4.Anchor = AnchorStyles.Top
        PictureBox4.BackColor = SystemColors.Window
        PictureBox4.Image = CType(resources.GetObject("PictureBox4.Image"), Image)
        PictureBox4.Location = New Point(811, 92)
        PictureBox4.Name = "PictureBox4"
        PictureBox4.Size = New Size(237, 168)
        PictureBox4.SizeMode = PictureBoxSizeMode.Zoom
        PictureBox4.TabIndex = 33
        PictureBox4.TabStop = False
        ' 
        ' Label9
        ' 
        Label9.Anchor = AnchorStyles.Top
        Label9.AutoSize = True
        Label9.BackColor = SystemColors.Window
        Label9.Font = New Font("Segoe UI Variable Display", 9.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label9.ForeColor = SystemColors.InfoText
        Label9.Location = New Point(716, 438)
        Label9.Name = "Label9"
        Label9.Size = New Size(32, 17)
        Label9.TabIndex = 35
        Label9.Text = "Age"
        Label9.TextAlign = ContentAlignment.TopCenter
        ' 
        ' age
        ' 
        age.Anchor = AnchorStyles.Top
        age.BackColor = SystemColors.Window
        age.BorderStyle = BorderStyle.FixedSingle
        age.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        age.ForeColor = SystemColors.InfoText
        age.Location = New Point(716, 458)
        age.Multiline = True
        age.Name = "age"
        age.Size = New Size(200, 26)
        age.TabIndex = 34
        ' 
        ' gender
        ' 
        gender.Anchor = AnchorStyles.Top
        gender.FormattingEnabled = True
        gender.Location = New Point(953, 404)
        gender.Name = "gender"
        gender.Size = New Size(173, 23)
        gender.TabIndex = 36
        ' 
        ' Label10
        ' 
        Label10.Anchor = AnchorStyles.Top
        Label10.AutoSize = True
        Label10.BackColor = SystemColors.Window
        Label10.Font = New Font("Segoe UI Variable Display", 9.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label10.ForeColor = SystemColors.InfoText
        Label10.Location = New Point(953, 381)
        Label10.Name = "Label10"
        Label10.Size = New Size(52, 17)
        Label10.TabIndex = 37
        Label10.Text = "Gender"
        Label10.TextAlign = ContentAlignment.TopCenter
        ' 
        ' birthday
        ' 
        birthday.Anchor = AnchorStyles.Top
        birthday.Location = New Point(716, 401)
        birthday.Name = "birthday"
        birthday.Size = New Size(200, 23)
        birthday.TabIndex = 38
        ' 
        ' Register
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1222, 719)
        Controls.Add(birthday)
        Controls.Add(Label10)
        Controls.Add(gender)
        Controls.Add(Label9)
        Controls.Add(age)
        Controls.Add(PictureBox4)
        Controls.Add(Label7)
        Controls.Add(Label8)
        Controls.Add(Phonenumber)
        Controls.Add(Label6)
        Controls.Add(confirmpassword)
        Controls.Add(Label5)
        Controls.Add(Password)
        Controls.Add(Label2)
        Controls.Add(Showpassword1)
        Controls.Add(Signup)
        Controls.Add(BackSignin)
        Controls.Add(Label4)
        Controls.Add(Label3)
        Controls.Add(Email)
        Controls.Add(Username)
        Controls.Add(Label1)
        Controls.Add(PictureBox1)
        Controls.Add(PictureBox3)
        Name = "Register"
        Text = "Register"
        WindowState = FormWindowState.Maximized
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox3, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox4, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Showpassword1 As CheckBox
    Friend WithEvents Signup As Button
    Friend WithEvents BackSignin As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Email As TextBox
    Friend WithEvents Username As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Password As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents confirmpassword As TextBox
    Friend WithEvents PictureBox3 As PictureBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Phonenumber As TextBox
    Friend WithEvents PictureBox4 As PictureBox
    Friend WithEvents Label9 As Label
    Friend WithEvents age As TextBox
    Friend WithEvents gender As ComboBox
    Friend WithEvents Label10 As Label
    Friend WithEvents birthday As DateTimePicker
End Class
