<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AddEmployee
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AddEmployee))
        PictureBox1 = New PictureBox()
        Label1 = New Label()
        Label2 = New Label()
        close = New Button()
        Panel1 = New Panel()
        fullname = New TextBox()
        Label3 = New Label()
        Panel2 = New Panel()
        ComboBox1 = New ComboBox()
        Label7 = New Label()
        birthday = New DateTimePicker()
        Label6 = New Label()
        Label5 = New Label()
        email = New TextBox()
        Label4 = New Label()
        Label8 = New Label()
        Panel3 = New Panel()
        Status = New ComboBox()
        Label16 = New Label()
        showpassword = New CheckBox()
        Password = New Label()
        Passwordemployee = New TextBox()
        Label15 = New Label()
        Label14 = New Label()
        Panel4 = New Panel()
        save = New Button()
        sex = New ComboBox()
        Label13 = New Label()
        contactnumber = New TextBox()
        Label9 = New Label()
        datehired = New DateTimePicker()
        Label10 = New Label()
        Label11 = New Label()
        salary = New TextBox()
        Label12 = New Label()
        position = New TextBox()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        Panel1.SuspendLayout()
        Panel2.SuspendLayout()
        Panel3.SuspendLayout()
        Panel4.SuspendLayout()
        SuspendLayout()
        ' 
        ' PictureBox1
        ' 
        PictureBox1.BackColor = Color.FromArgb(CByte(38), CByte(49), CByte(64))
        PictureBox1.Location = New Point(0, -3)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(664, 58)
        PictureBox1.TabIndex = 0
        PictureBox1.TabStop = False
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.BackColor = Color.FromArgb(CByte(38), CByte(49), CByte(64))
        Label1.Font = New Font("Century Gothic", 20.25F, FontStyle.Bold)
        Label1.ForeColor = SystemColors.Control
        Label1.Location = New Point(12, 9)
        Label1.Name = "Label1"
        Label1.Size = New Size(208, 32)
        Label1.TabIndex = 4
        Label1.Text = "Add Employee"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.BackColor = Color.FromArgb(CByte(38), CByte(49), CByte(64))
        Label2.Font = New Font("Century Gothic", 20.25F, FontStyle.Bold)
        Label2.ForeColor = SystemColors.Control
        Label2.Location = New Point(421, 9)
        Label2.Name = "Label2"
        Label2.Size = New Size(0, 32)
        Label2.TabIndex = 5
        ' 
        ' close
        ' 
        close.FlatStyle = FlatStyle.Flat
        close.Image = CType(resources.GetObject("close.Image"), Image)
        close.ImageAlign = ContentAlignment.MiddleLeft
        close.Location = New Point(-11, -9)
        close.Name = "close"
        close.Padding = New Padding(15, 0, 0, 0)
        close.Size = New Size(122, 52)
        close.TabIndex = 6
        close.Text = "    Close "
        close.UseVisualStyleBackColor = True
        ' 
        ' Panel1
        ' 
        Panel1.BackColor = Color.FromArgb(CByte(208), CByte(39), CByte(82))
        Panel1.Controls.Add(close)
        Panel1.Font = New Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Panel1.ForeColor = SystemColors.Control
        Panel1.Location = New Point(546, 9)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(101, 35)
        Panel1.TabIndex = 7
        ' 
        ' fullname
        ' 
        fullname.BorderStyle = BorderStyle.FixedSingle
        fullname.Location = New Point(18, 74)
        fullname.Name = "fullname"
        fullname.Size = New Size(249, 23)
        fullname.TabIndex = 8
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.BackColor = SystemColors.Control
        Label3.Font = New Font("Century Gothic", 14.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label3.ForeColor = Color.Black
        Label3.Location = New Point(59, 85)
        Label3.Name = "Label3"
        Label3.Size = New Size(155, 23)
        Label3.TabIndex = 10
        Label3.Text = "Personal Details"
        ' 
        ' Panel2
        ' 
        Panel2.BorderStyle = BorderStyle.FixedSingle
        Panel2.Controls.Add(ComboBox1)
        Panel2.Controls.Add(Label7)
        Panel2.Controls.Add(birthday)
        Panel2.Controls.Add(Label6)
        Panel2.Controls.Add(Label5)
        Panel2.Controls.Add(email)
        Panel2.Controls.Add(Label4)
        Panel2.Controls.Add(fullname)
        Panel2.Location = New Point(39, 99)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(574, 222)
        Panel2.TabIndex = 11
        ' 
        ' ComboBox1
        ' 
        ComboBox1.FormattingEnabled = True
        ComboBox1.Location = New Point(320, 150)
        ComboBox1.Name = "ComboBox1"
        ComboBox1.Size = New Size(222, 23)
        ComboBox1.TabIndex = 20
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.BackColor = SystemColors.Control
        Label7.Font = New Font("Century Gothic", 9.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label7.ForeColor = Color.Black
        Label7.Location = New Point(320, 131)
        Label7.Name = "Label7"
        Label7.Size = New Size(35, 16)
        Label7.TabIndex = 19
        Label7.Text = "Role"
        ' 
        ' birthday
        ' 
        birthday.Location = New Point(18, 150)
        birthday.Name = "birthday"
        birthday.Size = New Size(249, 23)
        birthday.TabIndex = 17
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.BackColor = SystemColors.Control
        Label6.Font = New Font("Century Gothic", 9.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label6.ForeColor = Color.Black
        Label6.Location = New Point(18, 131)
        Label6.Name = "Label6"
        Label6.Size = New Size(62, 16)
        Label6.TabIndex = 16
        Label6.Text = "Birthday"
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.BackColor = SystemColors.Control
        Label5.Font = New Font("Century Gothic", 9.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label5.ForeColor = Color.Black
        Label5.Location = New Point(320, 55)
        Label5.Name = "Label5"
        Label5.Size = New Size(43, 16)
        Label5.TabIndex = 14
        Label5.Text = "Email"
        ' 
        ' email
        ' 
        email.BorderStyle = BorderStyle.FixedSingle
        email.Location = New Point(320, 74)
        email.Name = "email"
        email.Size = New Size(222, 23)
        email.TabIndex = 13
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.BackColor = SystemColors.Control
        Label4.Font = New Font("Century Gothic", 9.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label4.ForeColor = Color.Black
        Label4.Location = New Point(18, 55)
        Label4.Name = "Label4"
        Label4.Size = New Size(66, 16)
        Label4.TabIndex = 12
        Label4.Text = "Fullname"
        ' 
        ' Label8
        ' 
        Label8.AutoSize = True
        Label8.BackColor = SystemColors.Control
        Label8.Font = New Font("Century Gothic", 14.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label8.ForeColor = Color.Black
        Label8.Location = New Point(59, 364)
        Label8.Name = "Label8"
        Label8.Size = New Size(170, 23)
        Label8.TabIndex = 12
        Label8.Text = "Employee Details"
        ' 
        ' Panel3
        ' 
        Panel3.BorderStyle = BorderStyle.FixedSingle
        Panel3.Controls.Add(Status)
        Panel3.Controls.Add(Label16)
        Panel3.Controls.Add(showpassword)
        Panel3.Controls.Add(Password)
        Panel3.Controls.Add(Passwordemployee)
        Panel3.Controls.Add(Label15)
        Panel3.Controls.Add(Label14)
        Panel3.Controls.Add(Panel4)
        Panel3.Controls.Add(sex)
        Panel3.Controls.Add(Label13)
        Panel3.Controls.Add(contactnumber)
        Panel3.Controls.Add(Label9)
        Panel3.Controls.Add(datehired)
        Panel3.Controls.Add(Label10)
        Panel3.Controls.Add(Label11)
        Panel3.Controls.Add(salary)
        Panel3.Controls.Add(Label12)
        Panel3.Controls.Add(position)
        Panel3.Location = New Point(39, 378)
        Panel3.Name = "Panel3"
        Panel3.Size = New Size(574, 339)
        Panel3.TabIndex = 13
        ' 
        ' Status
        ' 
        Status.FormattingEnabled = True
        Status.Location = New Point(320, 212)
        Status.Name = "Status"
        Status.Size = New Size(222, 23)
        Status.TabIndex = 31
        ' 
        ' Label16
        ' 
        Label16.AutoSize = True
        Label16.BackColor = SystemColors.Control
        Label16.Font = New Font("Century Gothic", 9.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label16.ForeColor = Color.Black
        Label16.Location = New Point(320, 190)
        Label16.Name = "Label16"
        Label16.Size = New Size(45, 16)
        Label16.TabIndex = 30
        Label16.Text = "Status"
        ' 
        ' showpassword
        ' 
        showpassword.AutoSize = True
        showpassword.Location = New Point(160, 291)
        showpassword.Name = "showpassword"
        showpassword.Size = New Size(108, 19)
        showpassword.TabIndex = 29
        showpassword.Text = "Show password"
        showpassword.UseVisualStyleBackColor = True
        ' 
        ' Password
        ' 
        Password.AutoSize = True
        Password.BackColor = SystemColors.Control
        Password.Font = New Font("Century Gothic", 9.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Password.ForeColor = Color.Black
        Password.Location = New Point(19, 243)
        Password.Name = "Password"
        Password.Size = New Size(67, 16)
        Password.TabIndex = 28
        Password.Text = "Password"
        ' 
        ' Passwordemployee
        ' 
        Passwordemployee.BorderStyle = BorderStyle.FixedSingle
        Passwordemployee.Location = New Point(19, 262)
        Passwordemployee.Name = "Passwordemployee"
        Passwordemployee.Size = New Size(249, 23)
        Passwordemployee.TabIndex = 27
        ' 
        ' Label15
        ' 
        Label15.AutoSize = True
        Label15.BackColor = SystemColors.Control
        Label15.Font = New Font("Century Gothic", 8.25F, FontStyle.Italic, GraphicsUnit.Point, CByte(0))
        Label15.ForeColor = Color.DarkOliveGreen
        Label15.Location = New Point(323, 100)
        Label15.Name = "Label15"
        Label15.Size = New Size(89, 15)
        Label15.TabIndex = 26
        Label15.Text = "Example 10,000"
        ' 
        ' Label14
        ' 
        Label14.AutoSize = True
        Label14.BackColor = SystemColors.Control
        Label14.Font = New Font("Century Gothic", 9.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label14.ForeColor = Color.Black
        Label14.Location = New Point(443, 77)
        Label14.Name = "Label14"
        Label14.Size = New Size(31, 16)
        Label14.TabIndex = 25
        Label14.Text = "Php"
        ' 
        ' Panel4
        ' 
        Panel4.Controls.Add(save)
        Panel4.Location = New Point(394, 262)
        Panel4.Name = "Panel4"
        Panel4.Size = New Size(148, 56)
        Panel4.TabIndex = 24
        ' 
        ' save
        ' 
        save.BackColor = Color.DodgerBlue
        save.FlatStyle = FlatStyle.Flat
        save.Font = New Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        save.ForeColor = SystemColors.Window
        save.Image = CType(resources.GetObject("save.Image"), Image)
        save.ImageAlign = ContentAlignment.MiddleLeft
        save.Location = New Point(-7, -8)
        save.Name = "save"
        save.Padding = New Padding(20, 0, 0, 0)
        save.Size = New Size(164, 72)
        save.TabIndex = 23
        save.Text = "Save"
        save.UseVisualStyleBackColor = False
        ' 
        ' sex
        ' 
        sex.FormattingEnabled = True
        sex.Location = New Point(320, 149)
        sex.Name = "sex"
        sex.Size = New Size(222, 23)
        sex.TabIndex = 21
        ' 
        ' Label13
        ' 
        Label13.AutoSize = True
        Label13.BackColor = SystemColors.Control
        Label13.Font = New Font("Century Gothic", 9.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label13.ForeColor = Color.Black
        Label13.Location = New Point(18, 176)
        Label13.Name = "Label13"
        Label13.Size = New Size(114, 16)
        Label13.TabIndex = 22
        Label13.Text = "Contact Number"
        ' 
        ' contactnumber
        ' 
        contactnumber.BorderStyle = BorderStyle.FixedSingle
        contactnumber.Location = New Point(18, 195)
        contactnumber.Name = "contactnumber"
        contactnumber.Size = New Size(249, 23)
        contactnumber.TabIndex = 21
        ' 
        ' Label9
        ' 
        Label9.AutoSize = True
        Label9.BackColor = SystemColors.Control
        Label9.Font = New Font("Century Gothic", 9.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label9.ForeColor = Color.Black
        Label9.Location = New Point(320, 127)
        Label9.Name = "Label9"
        Label9.Size = New Size(29, 16)
        Label9.TabIndex = 19
        Label9.Text = "Sex"
        ' 
        ' datehired
        ' 
        datehired.Location = New Point(18, 131)
        datehired.Name = "datehired"
        datehired.Size = New Size(249, 23)
        datehired.TabIndex = 17
        ' 
        ' Label10
        ' 
        Label10.AutoSize = True
        Label10.BackColor = SystemColors.Control
        Label10.Font = New Font("Century Gothic", 9.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label10.ForeColor = Color.Black
        Label10.Location = New Point(18, 112)
        Label10.Name = "Label10"
        Label10.Size = New Size(75, 16)
        Label10.TabIndex = 16
        Label10.Text = "Date hired"
        ' 
        ' Label11
        ' 
        Label11.AutoSize = True
        Label11.BackColor = SystemColors.Control
        Label11.Font = New Font("Century Gothic", 9.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label11.ForeColor = Color.Black
        Label11.Location = New Point(320, 55)
        Label11.Name = "Label11"
        Label11.Size = New Size(49, 16)
        Label11.TabIndex = 14
        Label11.Text = "Salary"
        ' 
        ' salary
        ' 
        salary.BorderStyle = BorderStyle.FixedSingle
        salary.Location = New Point(320, 74)
        salary.Name = "salary"
        salary.Size = New Size(117, 23)
        salary.TabIndex = 13
        ' 
        ' Label12
        ' 
        Label12.AutoSize = True
        Label12.BackColor = SystemColors.Control
        Label12.Font = New Font("Century Gothic", 9.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label12.ForeColor = Color.Black
        Label12.Location = New Point(18, 55)
        Label12.Name = "Label12"
        Label12.Size = New Size(56, 16)
        Label12.TabIndex = 12
        Label12.Text = "Position"
        ' 
        ' position
        ' 
        position.BorderStyle = BorderStyle.FixedSingle
        position.Location = New Point(18, 74)
        position.Name = "position"
        position.Size = New Size(249, 23)
        position.TabIndex = 8
        ' 
        ' AddEmployee
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(659, 763)
        Controls.Add(Label8)
        Controls.Add(Panel3)
        Controls.Add(Label3)
        Controls.Add(Panel2)
        Controls.Add(Panel1)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Controls.Add(PictureBox1)
        FormBorderStyle = FormBorderStyle.None
        Name = "AddEmployee"
        Text = "AddEmployee"
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        Panel1.ResumeLayout(False)
        Panel2.ResumeLayout(False)
        Panel2.PerformLayout()
        Panel3.ResumeLayout(False)
        Panel3.PerformLayout()
        Panel4.ResumeLayout(False)
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents close As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents fullname As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label4 As Label
    Friend WithEvents birthday As DateTimePicker
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents email As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Label9 As Label
    Friend WithEvents datehired As DateTimePicker
    Friend WithEvents Label10 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents salary As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents position As TextBox
    Friend WithEvents Passwordemployee As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents contactnumber As TextBox
    Friend WithEvents sex As ComboBox
    Friend WithEvents Panel4 As Panel
    Friend WithEvents save As Button
    Friend WithEvents Label15 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents Password As Label
    Friend WithEvents showpassword As CheckBox
    Friend WithEvents Status As ComboBox
    Friend WithEvents Label16 As Label
End Class
