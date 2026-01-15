<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(disposing As Boolean)
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        PictureBox1 = New PictureBox()
        Label1 = New Label()
        Label2 = New Label()
        Email = New TextBox()
        Password = New TextBox()
        Label3 = New Label()
        Label4 = New Label()
        PictureBox2 = New PictureBox()
        Signin = New Button()
        Signup = New Button()
        Showpassword = New CheckBox()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox2, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' PictureBox1
        ' 
        PictureBox1.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        PictureBox1.BackColor = SystemColors.ControlLight
        PictureBox1.Image = My.Resources.Resources.Box
        PictureBox1.Location = New Point(376, 70)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(500, 573)
        PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
        PictureBox1.TabIndex = 0
        PictureBox1.TabStop = False
        ' 
        ' Label1
        ' 
        Label1.Anchor = AnchorStyles.Top
        Label1.AutoSize = True
        Label1.BackColor = SystemColors.Window
        Label1.Font = New Font("Segoe UI Variable Display", 20.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.Location = New Point(490, 186)
        Label1.Name = "Label1"
        Label1.Size = New Size(282, 72)
        Label1.TabIndex = 2
        Label1.Text = "Employee Payroll " & vbCrLf & "Management System"
        Label1.TextAlign = ContentAlignment.TopCenter
        ' 
        ' Label2
        ' 
        Label2.Anchor = AnchorStyles.Top
        Label2.AutoSize = True
        Label2.BackColor = SystemColors.Window
        Label2.Font = New Font("Segoe UI Variable Display", 14.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label2.ForeColor = SystemColors.ControlDarkDark
        Label2.Location = New Point(592, 267)
        Label2.Name = "Label2"
        Label2.Size = New Size(71, 26)
        Label2.TabIndex = 3
        Label2.Text = "Sign in"
        Label2.TextAlign = ContentAlignment.TopCenter
        ' 
        ' Email
        ' 
        Email.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        Email.BackColor = SystemColors.Window
        Email.BorderStyle = BorderStyle.FixedSingle
        Email.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Email.ForeColor = SystemColors.InfoText
        Email.Location = New Point(410, 331)
        Email.Margin = New Padding(3, 4, 3, 3)
        Email.Multiline = True
        Email.Name = "Email"
        Email.Size = New Size(433, 36)
        Email.TabIndex = 4
        ' 
        ' Password
        ' 
        Password.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        Password.BackColor = SystemColors.Window
        Password.BorderStyle = BorderStyle.FixedSingle
        Password.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Password.ForeColor = SystemColors.InfoText
        Password.Location = New Point(410, 410)
        Password.Multiline = True
        Password.Name = "Password"
        Password.Size = New Size(433, 36)
        Password.TabIndex = 5
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.BackColor = SystemColors.Window
        Label3.Font = New Font("Segoe UI Variable Display", 9.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label3.ForeColor = SystemColors.InfoText
        Label3.Location = New Point(410, 310)
        Label3.Name = "Label3"
        Label3.Size = New Size(42, 17)
        Label3.TabIndex = 6
        Label3.Text = "Email"
        Label3.TextAlign = ContentAlignment.TopCenter
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.BackColor = SystemColors.Window
        Label4.Font = New Font("Segoe UI Variable Display", 9.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label4.ForeColor = SystemColors.InfoText
        Label4.Location = New Point(410, 390)
        Label4.Name = "Label4"
        Label4.Size = New Size(66, 17)
        Label4.TabIndex = 7
        Label4.Text = "Password"
        Label4.TextAlign = ContentAlignment.TopCenter
        ' 
        ' PictureBox2
        ' 
        PictureBox2.Anchor = AnchorStyles.Top
        PictureBox2.BackColor = SystemColors.Window
        PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), Image)
        PictureBox2.Location = New Point(577, 88)
        PictureBox2.Name = "PictureBox2"
        PictureBox2.Size = New Size(100, 86)
        PictureBox2.SizeMode = PictureBoxSizeMode.Zoom
        PictureBox2.TabIndex = 1
        PictureBox2.TabStop = False
        ' 
        ' Signin
        ' 
        Signin.Anchor = AnchorStyles.Bottom
        Signin.BackColor = Color.DeepSkyBlue
        Signin.FlatStyle = FlatStyle.Flat
        Signin.Font = New Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Signin.ForeColor = Color.White
        Signin.Location = New Point(631, 522)
        Signin.Name = "Signin"
        Signin.Size = New Size(212, 56)
        Signin.TabIndex = 8
        Signin.Text = "Sign in "
        Signin.UseVisualStyleBackColor = False
        ' 
        ' Signup
        ' 
        Signup.Anchor = AnchorStyles.Bottom
        Signup.BackColor = Color.FromArgb(CByte(38), CByte(49), CByte(64))
        Signup.FlatStyle = FlatStyle.Flat
        Signup.Font = New Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Signup.ForeColor = Color.White
        Signup.Location = New Point(410, 522)
        Signup.Name = "Signup"
        Signup.Size = New Size(201, 56)
        Signup.TabIndex = 9
        Signup.Text = "Sign up"
        Signup.UseVisualStyleBackColor = False
        ' 
        ' Showpassword
        ' 
        Showpassword.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        Showpassword.AutoSize = True
        Showpassword.BackColor = SystemColors.Window
        Showpassword.Location = New Point(735, 461)
        Showpassword.Name = "Showpassword"
        Showpassword.Size = New Size(108, 19)
        Showpassword.TabIndex = 10
        Showpassword.Text = "Show Password"
        Showpassword.UseVisualStyleBackColor = False
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = SystemColors.ControlLight
        ClientSize = New Size(1222, 719)
        Controls.Add(Showpassword)
        Controls.Add(Signup)
        Controls.Add(Signin)
        Controls.Add(Label4)
        Controls.Add(Label3)
        Controls.Add(Password)
        Controls.Add(Email)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Controls.Add(PictureBox2)
        Controls.Add(PictureBox1)
        Name = "Form1"
        Text = "Form1"
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox2, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Email As TextBox
    Friend WithEvents Password As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents Signin As Button
    Friend WithEvents Signup As Button
    Friend WithEvents Showpassword As CheckBox

End Class
