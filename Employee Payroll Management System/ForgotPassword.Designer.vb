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
        Timercooldown = New Label()
        Showpassword = New CheckBox()
        SetNewpassword = New Button()
        Label4 = New Label()
        Label3 = New Label()
        NewPassword = New TextBox()
        Email = New TextBox()
        Label2 = New Label()
        Label1 = New Label()
        PictureBox2 = New PictureBox()
        PictureBox1 = New PictureBox()
        CType(PictureBox2, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' BackBtn
        ' 
        BackBtn.Anchor = AnchorStyles.Bottom
        BackBtn.BackColor = Color.FromArgb(CByte(38), CByte(49), CByte(64))
        BackBtn.FlatStyle = FlatStyle.Flat
        BackBtn.Font = New Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        BackBtn.ForeColor = Color.White
        BackBtn.Location = New Point(94, 560)
        BackBtn.Name = "BackBtn"
        BackBtn.Size = New Size(433, 56)
        BackBtn.TabIndex = 41
        BackBtn.Text = "Back to Sign in"
        BackBtn.UseVisualStyleBackColor = False
        ' 
        ' Timercooldown
        ' 
        Timercooldown.Anchor = AnchorStyles.Top
        Timercooldown.AutoSize = True
        Timercooldown.BackColor = SystemColors.Window
        Timercooldown.Font = New Font("Segoe UI Variable Display", 9.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Timercooldown.ForeColor = SystemColors.ControlDarkDark
        Timercooldown.Location = New Point(94, 428)
        Timercooldown.Name = "Timercooldown"
        Timercooldown.Size = New Size(0, 17)
        Timercooldown.TabIndex = 39
        Timercooldown.TextAlign = ContentAlignment.TopCenter
        ' 
        ' Showpassword
        ' 
        Showpassword.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        Showpassword.AutoSize = True
        Showpassword.BackColor = SystemColors.Window
        Showpassword.Location = New Point(419, 429)
        Showpassword.Name = "Showpassword"
        Showpassword.Size = New Size(108, 19)
        Showpassword.TabIndex = 38
        Showpassword.Text = "Show Password"
        Showpassword.UseVisualStyleBackColor = False
        ' 
        ' SetNewpassword
        ' 
        SetNewpassword.Anchor = AnchorStyles.Bottom
        SetNewpassword.BackColor = Color.DeepSkyBlue
        SetNewpassword.FlatStyle = FlatStyle.Flat
        SetNewpassword.Font = New Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        SetNewpassword.ForeColor = Color.White
        SetNewpassword.Location = New Point(94, 487)
        SetNewpassword.Name = "SetNewpassword"
        SetNewpassword.Size = New Size(433, 56)
        SetNewpassword.TabIndex = 36
        SetNewpassword.Text = "Set Password"
        SetNewpassword.UseVisualStyleBackColor = False
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.BackColor = SystemColors.Window
        Label4.Font = New Font("Segoe UI Variable Display", 9.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label4.ForeColor = SystemColors.InfoText
        Label4.Location = New Point(94, 358)
        Label4.Name = "Label4"
        Label4.Size = New Size(96, 17)
        Label4.TabIndex = 35
        Label4.Text = "New Password"
        Label4.TextAlign = ContentAlignment.TopCenter
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.BackColor = SystemColors.Window
        Label3.Font = New Font("Segoe UI Variable Display", 9.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label3.ForeColor = SystemColors.InfoText
        Label3.Location = New Point(94, 278)
        Label3.Name = "Label3"
        Label3.Size = New Size(42, 17)
        Label3.TabIndex = 34
        Label3.Text = "Email"
        Label3.TextAlign = ContentAlignment.TopCenter
        ' 
        ' NewPassword
        ' 
        NewPassword.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        NewPassword.BackColor = SystemColors.Window
        NewPassword.BorderStyle = BorderStyle.FixedSingle
        NewPassword.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        NewPassword.ForeColor = SystemColors.InfoText
        NewPassword.Location = New Point(94, 378)
        NewPassword.Name = "NewPassword"
        NewPassword.Size = New Size(433, 29)
        NewPassword.TabIndex = 33
        NewPassword.UseSystemPasswordChar = True
        ' 
        ' Email
        ' 
        Email.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        Email.BackColor = SystemColors.Window
        Email.BorderStyle = BorderStyle.FixedSingle
        Email.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Email.ForeColor = SystemColors.InfoText
        Email.Location = New Point(94, 299)
        Email.Margin = New Padding(3, 4, 3, 3)
        Email.Multiline = True
        Email.Name = "Email"
        Email.Size = New Size(433, 36)
        Email.TabIndex = 32
        ' 
        ' Label2
        ' 
        Label2.Anchor = AnchorStyles.Top
        Label2.AutoSize = True
        Label2.BackColor = SystemColors.Window
        Label2.Font = New Font("Segoe UI Variable Display", 14.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label2.ForeColor = SystemColors.ControlDarkDark
        Label2.Location = New Point(230, 239)
        Label2.Name = "Label2"
        Label2.Size = New Size(161, 26)
        Label2.TabIndex = 31
        Label2.Text = "Forget Password"
        Label2.TextAlign = ContentAlignment.TopCenter
        ' 
        ' Label1
        ' 
        Label1.Anchor = AnchorStyles.Top
        Label1.AutoSize = True
        Label1.BackColor = SystemColors.Window
        Label1.Font = New Font("Segoe UI Variable Display", 20.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.Location = New Point(174, 154)
        Label1.Name = "Label1"
        Label1.Size = New Size(282, 72)
        Label1.TabIndex = 30
        Label1.Text = "Employee Payroll " & vbCrLf & "Management System"
        Label1.TextAlign = ContentAlignment.TopCenter
        ' 
        ' PictureBox2
        ' 
        PictureBox2.Anchor = AnchorStyles.Top
        PictureBox2.BackColor = SystemColors.Window
        PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), Image)
        PictureBox2.Location = New Point(261, 56)
        PictureBox2.Name = "PictureBox2"
        PictureBox2.Size = New Size(100, 86)
        PictureBox2.SizeMode = PictureBoxSizeMode.Zoom
        PictureBox2.TabIndex = 29
        PictureBox2.TabStop = False
        ' 
        ' PictureBox1
        ' 
        PictureBox1.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        PictureBox1.BackColor = SystemColors.Control
        PictureBox1.Image = My.Resources.Resources.Box
        PictureBox1.Location = New Point(60, 38)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(500, 643)
        PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
        PictureBox1.TabIndex = 28
        PictureBox1.TabStop = False
        ' 
        ' ForgotPassword
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(621, 719)
        Controls.Add(BackBtn)
        Controls.Add(Timercooldown)
        Controls.Add(Showpassword)
        Controls.Add(SetNewpassword)
        Controls.Add(Label4)
        Controls.Add(Label3)
        Controls.Add(NewPassword)
        Controls.Add(Email)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Controls.Add(PictureBox2)
        Controls.Add(PictureBox1)
        Name = "ForgotPassword"
        Text = "ForgotPassword"
        CType(PictureBox2, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents BackBtn As Button
    Friend WithEvents Timercooldown As Label
    Friend WithEvents Showpassword As CheckBox
    Friend WithEvents SetNewpassword As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents NewPassword As TextBox
    Friend WithEvents Email As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents PictureBox1 As PictureBox
End Class
