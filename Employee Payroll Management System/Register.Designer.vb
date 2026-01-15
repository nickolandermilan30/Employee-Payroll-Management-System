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
        PictureBox2 = New PictureBox()
        PictureBox1 = New PictureBox()
        Label2 = New Label()
        Label5 = New Label()
        Password = New TextBox()
        Label6 = New Label()
        confirmpassword = New TextBox()
        PictureBox3 = New PictureBox()
        Label7 = New Label()
        Roledropdown = New ComboBox()
        CType(PictureBox2, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox3, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Showpassword1
        ' 
        Showpassword1.Anchor = AnchorStyles.Top
        Showpassword1.AutoSize = True
        Showpassword1.BackColor = SystemColors.Window
        Showpassword1.Location = New Point(568, 537)
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
        Signup.Location = New Point(773, 239)
        Signup.Name = "Signup"
        Signup.Size = New Size(253, 53)
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
        BackSignin.Location = New Point(773, 303)
        BackSignin.Name = "BackSignin"
        BackSignin.Size = New Size(253, 53)
        BackSignin.TabIndex = 19
        BackSignin.Text = "Sign in "
        BackSignin.UseVisualStyleBackColor = False
        ' 
        ' Label4
        ' 
        Label4.Anchor = AnchorStyles.Top
        Label4.AutoSize = True
        Label4.BackColor = SystemColors.Window
        Label4.Font = New Font("Segoe UI Variable Display", 9.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label4.ForeColor = SystemColors.InfoText
        Label4.Location = New Point(266, 300)
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
        Label3.Location = New Point(266, 219)
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
        Email.Location = New Point(266, 320)
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
        Username.Location = New Point(266, 239)
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
        Label1.Location = New Point(257, 124)
        Label1.Name = "Label1"
        Label1.Size = New Size(209, 36)
        Label1.TabIndex = 13
        Label1.Text = "Create account"
        Label1.TextAlign = ContentAlignment.TopCenter
        ' 
        ' PictureBox2
        ' 
        PictureBox2.Anchor = AnchorStyles.Top
        PictureBox2.BackColor = SystemColors.Window
        PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), Image)
        PictureBox2.Location = New Point(636, 124)
        PictureBox2.Name = "PictureBox2"
        PictureBox2.Size = New Size(66, 65)
        PictureBox2.SizeMode = PictureBoxSizeMode.Zoom
        PictureBox2.TabIndex = 12
        PictureBox2.TabStop = False
        ' 
        ' PictureBox1
        ' 
        PictureBox1.Anchor = AnchorStyles.Top
        PictureBox1.BackColor = SystemColors.Control
        PictureBox1.Image = My.Resources.Resources.Box
        PictureBox1.Location = New Point(219, 62)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(540, 573)
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
        Label2.Location = New Point(257, 166)
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
        Label5.Location = New Point(266, 383)
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
        Password.Location = New Point(266, 403)
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
        Label6.Location = New Point(266, 463)
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
        confirmpassword.Location = New Point(266, 483)
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
        PictureBox3.Location = New Point(773, 100)
        PictureBox3.Name = "PictureBox3"
        PictureBox3.Size = New Size(256, 112)
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
        Label7.Location = New Point(791, 124)
        Label7.Name = "Label7"
        Label7.Size = New Size(35, 17)
        Label7.TabIndex = 30
        Label7.Text = "Role"
        Label7.TextAlign = ContentAlignment.TopCenter
        ' 
        ' Roledropdown
        ' 
        Roledropdown.Anchor = AnchorStyles.Top
        Roledropdown.FormattingEnabled = True
        Roledropdown.Location = New Point(791, 155)
        Roledropdown.Name = "Roledropdown"
        Roledropdown.Size = New Size(220, 23)
        Roledropdown.TabIndex = 31
        ' 
        ' Register
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1222, 719)
        Controls.Add(Roledropdown)
        Controls.Add(Label7)
        Controls.Add(PictureBox3)
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
        Controls.Add(PictureBox2)
        Controls.Add(PictureBox1)
        Name = "Register"
        Text = "Register"
        CType(PictureBox2, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox3, ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Password As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents confirmpassword As TextBox
    Friend WithEvents PictureBox3 As PictureBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Roledropdown As ComboBox
End Class
