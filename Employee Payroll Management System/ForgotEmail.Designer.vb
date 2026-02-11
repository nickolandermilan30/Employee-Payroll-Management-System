<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ForgotEmail
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ForgotEmail))
        PictureBox1 = New PictureBox()
        Signup = New Button()
        setemail = New Button()
        Label4 = New Label()
        Label3 = New Label()
        Mothersname = New TextBox()
        s = New Label()
        Label1 = New Label()
        PictureBox2 = New PictureBox()
        Timer = New Label()
        Newemail = New TextBox()
        lblStatusssssss = New Label()
        Valid = New Button()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox2, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' PictureBox1
        ' 
        PictureBox1.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        PictureBox1.BackColor = SystemColors.Control
        PictureBox1.Image = My.Resources.Resources.Box
        PictureBox1.Location = New Point(65, 83)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(500, 624)
        PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
        PictureBox1.TabIndex = 29
        PictureBox1.TabStop = False
        ' 
        ' Signup
        ' 
        Signup.Anchor = AnchorStyles.Bottom
        Signup.BackColor = Color.FromArgb(CByte(38), CByte(49), CByte(64))
        Signup.FlatStyle = FlatStyle.Flat
        Signup.Font = New Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Signup.ForeColor = Color.White
        Signup.Location = New Point(102, 620)
        Signup.Name = "Signup"
        Signup.Size = New Size(433, 56)
        Signup.TabIndex = 38
        Signup.Text = "Back to Login "
        Signup.UseVisualStyleBackColor = False
        ' 
        ' setemail
        ' 
        setemail.Anchor = AnchorStyles.Bottom
        setemail.BackColor = Color.DeepSkyBlue
        setemail.FlatStyle = FlatStyle.Flat
        setemail.Font = New Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        setemail.ForeColor = Color.White
        setemail.Location = New Point(102, 545)
        setemail.Name = "setemail"
        setemail.Size = New Size(433, 56)
        setemail.TabIndex = 37
        setemail.Text = "Set New email"
        setemail.UseVisualStyleBackColor = False
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.BackColor = SystemColors.Window
        Label4.Font = New Font("Segoe UI Variable Display", 9.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label4.ForeColor = SystemColors.InfoText
        Label4.Location = New Point(102, 425)
        Label4.Name = "Label4"
        Label4.Size = New Size(72, 17)
        Label4.TabIndex = 36
        Label4.Text = "New Email"
        Label4.TextAlign = ContentAlignment.TopCenter
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.BackColor = SystemColors.Window
        Label3.Font = New Font("Segoe UI Variable Display", 9.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label3.ForeColor = SystemColors.InfoText
        Label3.Location = New Point(102, 345)
        Label3.Name = "Label3"
        Label3.Size = New Size(148, 17)
        Label3.TabIndex = 35
        Label3.Text = "Your mothers fullname"
        Label3.TextAlign = ContentAlignment.TopCenter
        ' 
        ' Mothersname
        ' 
        Mothersname.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        Mothersname.BackColor = SystemColors.Window
        Mothersname.BorderStyle = BorderStyle.FixedSingle
        Mothersname.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Mothersname.ForeColor = SystemColors.InfoText
        Mothersname.Location = New Point(102, 366)
        Mothersname.Margin = New Padding(3, 4, 3, 3)
        Mothersname.Multiline = True
        Mothersname.Name = "Mothersname"
        Mothersname.Size = New Size(433, 36)
        Mothersname.TabIndex = 33
        ' 
        ' s
        ' 
        s.Anchor = AnchorStyles.Top
        s.AutoSize = True
        s.BackColor = SystemColors.Window
        s.Font = New Font("Segoe UI Variable Display", 14.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        s.ForeColor = SystemColors.ControlDarkDark
        s.Location = New Point(244, 307)
        s.Name = "s"
        s.Size = New Size(125, 26)
        s.TabIndex = 32
        s.Text = "Forgot email"
        s.TextAlign = ContentAlignment.TopCenter
        ' 
        ' Label1
        ' 
        Label1.Anchor = AnchorStyles.Top
        Label1.AutoSize = True
        Label1.BackColor = SystemColors.Window
        Label1.Font = New Font("Segoe UI Variable Display", 20.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.Location = New Point(182, 221)
        Label1.Name = "Label1"
        Label1.Size = New Size(282, 72)
        Label1.TabIndex = 31
        Label1.Text = "Employee Payroll " & vbCrLf & "Management System"
        Label1.TextAlign = ContentAlignment.TopCenter
        ' 
        ' PictureBox2
        ' 
        PictureBox2.Anchor = AnchorStyles.Top
        PictureBox2.BackColor = SystemColors.Window
        PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), Image)
        PictureBox2.Location = New Point(269, 123)
        PictureBox2.Name = "PictureBox2"
        PictureBox2.Size = New Size(100, 86)
        PictureBox2.SizeMode = PictureBoxSizeMode.Zoom
        PictureBox2.TabIndex = 30
        PictureBox2.TabStop = False
        ' 
        ' Timer
        ' 
        Timer.AutoSize = True
        Timer.BackColor = SystemColors.Window
        Timer.Font = New Font("Segoe UI Variable Display", 14.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Timer.ForeColor = SystemColors.ControlDarkDark
        Timer.Location = New Point(102, 492)
        Timer.Name = "Timer"
        Timer.Size = New Size(0, 26)
        Timer.TabIndex = 39
        Timer.TextAlign = ContentAlignment.TopCenter
        ' 
        ' Newemail
        ' 
        Newemail.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        Newemail.BackColor = SystemColors.Window
        Newemail.BorderStyle = BorderStyle.FixedSingle
        Newemail.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Newemail.ForeColor = SystemColors.InfoText
        Newemail.Location = New Point(102, 446)
        Newemail.Margin = New Padding(3, 4, 3, 3)
        Newemail.Multiline = True
        Newemail.Name = "Newemail"
        Newemail.Size = New Size(433, 36)
        Newemail.TabIndex = 40
        ' 
        ' lblStatusssssss
        ' 
        lblStatusssssss.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        lblStatusssssss.AutoSize = True
        lblStatusssssss.BackColor = SystemColors.Window
        lblStatusssssss.Font = New Font("Segoe UI Variable Display", 14.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblStatusssssss.ForeColor = Color.Green
        lblStatusssssss.Location = New Point(447, 336)
        lblStatusssssss.Name = "lblStatusssssss"
        lblStatusssssss.Size = New Size(56, 26)
        lblStatusssssss.TabIndex = 41
        lblStatusssssss.Text = "Valid"
        lblStatusssssss.TextAlign = ContentAlignment.TopCenter
        ' 
        ' Valid
        ' 
        Valid.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        Valid.BackColor = Color.Green
        Valid.FlatStyle = FlatStyle.Flat
        Valid.Font = New Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Valid.ForeColor = Color.White
        Valid.Location = New Point(458, 408)
        Valid.Name = "Valid"
        Valid.Size = New Size(77, 26)
        Valid.TabIndex = 42
        Valid.Text = "Set Valid"
        Valid.UseVisualStyleBackColor = False
        ' 
        ' ForgotEmail
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(631, 788)
        Controls.Add(Valid)
        Controls.Add(lblStatusssssss)
        Controls.Add(Newemail)
        Controls.Add(Timer)
        Controls.Add(Signup)
        Controls.Add(setemail)
        Controls.Add(Label4)
        Controls.Add(Label3)
        Controls.Add(Mothersname)
        Controls.Add(s)
        Controls.Add(Label1)
        Controls.Add(PictureBox2)
        Controls.Add(PictureBox1)
        Name = "ForgotEmail"
        Text = "ForgotEmail"
        WindowState = FormWindowState.Maximized
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox2, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Signup As Button
    Friend WithEvents setemail As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Mothersname As TextBox
    Friend WithEvents s As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents Timer As Label
    Friend WithEvents Newemail As TextBox
    Friend WithEvents lblStatusssssss As Label
    Friend WithEvents Valid As Button
End Class
