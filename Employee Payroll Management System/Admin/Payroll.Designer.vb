<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Payroll
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Payroll))
        PictureBox1 = New PictureBox()
        Label1 = New Label()
        employee = New ComboBox()
        Label2 = New Label()
        Label3 = New Label()
        Label4 = New Label()
        Month = New DateTimePicker()
        Label5 = New Label()
        Year = New DomainUpDown()
        Label6 = New Label()
        Salary = New TextBox()
        Label15 = New Label()
        PictureBox2 = New PictureBox()
        Label7 = New Label()
        Deduction = New TextBox()
        Label8 = New Label()
        Notes = New TextBox()
        Label9 = New Label()
        Panel1 = New Panel()
        Pay = New Button()
        Panel3 = New Panel()
        late = New Label()
        Label11 = New Label()
        PictureBox4 = New PictureBox()
        Panel2 = New Panel()
        Halfday = New Label()
        Label12 = New Label()
        PictureBox3 = New PictureBox()
        Panel4 = New Panel()
        Absent = New Label()
        Label14 = New Label()
        PictureBox5 = New PictureBox()
        Panel5 = New Panel()
        Present = New Label()
        Label17 = New Label()
        PictureBox6 = New PictureBox()
        daysdate = New TextBox()
        Label10 = New Label()
        deductionbtn = New Button()
        Listofdeduction = New ListBox()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox2, ComponentModel.ISupportInitialize).BeginInit()
        Panel1.SuspendLayout()
        Panel3.SuspendLayout()
        CType(PictureBox4, ComponentModel.ISupportInitialize).BeginInit()
        Panel2.SuspendLayout()
        CType(PictureBox3, ComponentModel.ISupportInitialize).BeginInit()
        Panel4.SuspendLayout()
        CType(PictureBox5, ComponentModel.ISupportInitialize).BeginInit()
        Panel5.SuspendLayout()
        CType(PictureBox6, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' PictureBox1
        ' 
        PictureBox1.Anchor = AnchorStyles.Top
        PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), Image)
        PictureBox1.Location = New Point(70, 212)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(449, 252)
        PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
        PictureBox1.TabIndex = 0
        PictureBox1.TabStop = False
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.BackColor = SystemColors.Control
        Label1.Font = New Font("Century Gothic", 20.25F, FontStyle.Bold)
        Label1.Location = New Point(27, 37)
        Label1.Name = "Label1"
        Label1.Size = New Size(208, 32)
        Label1.TabIndex = 6
        Label1.Text = "Process Payroll"
        ' 
        ' employee
        ' 
        employee.Anchor = AnchorStyles.Top
        employee.FormattingEnabled = True
        employee.Location = New Point(108, 284)
        employee.Name = "employee"
        employee.Size = New Size(361, 23)
        employee.TabIndex = 7
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.BackColor = SystemColors.Control
        Label2.Font = New Font("Century Gothic", 12F, FontStyle.Bold)
        Label2.ForeColor = SystemColors.ControlDarkDark
        Label2.Location = New Point(29, 79)
        Label2.Name = "Label2"
        Label2.Size = New Size(490, 19)
        Label2.TabIndex = 8
        Label2.Text = "Ensure timely and precise payroll processing for all employees."
        Label2.TextAlign = ContentAlignment.TopCenter
        ' 
        ' Label3
        ' 
        Label3.Anchor = AnchorStyles.Top
        Label3.AutoSize = True
        Label3.BackColor = SystemColors.Window
        Label3.Font = New Font("Century Gothic", 12F, FontStyle.Bold)
        Label3.ForeColor = SystemColors.ActiveCaptionText
        Label3.Location = New Point(108, 259)
        Label3.Name = "Label3"
        Label3.Size = New Size(98, 19)
        Label3.TabIndex = 9
        Label3.Text = "Employee *"
        Label3.TextAlign = ContentAlignment.TopCenter
        ' 
        ' Label4
        ' 
        Label4.Anchor = AnchorStyles.Top
        Label4.AutoSize = True
        Label4.BackColor = SystemColors.Window
        Label4.Font = New Font("Century Gothic", 12F, FontStyle.Bold)
        Label4.ForeColor = SystemColors.ActiveCaptionText
        Label4.Location = New Point(108, 323)
        Label4.Name = "Label4"
        Label4.Size = New Size(68, 19)
        Label4.TabIndex = 11
        Label4.Text = "Month *"
        Label4.TextAlign = ContentAlignment.TopCenter
        ' 
        ' Month
        ' 
        Month.Anchor = AnchorStyles.Top
        Month.Location = New Point(108, 348)
        Month.Name = "Month"
        Month.Size = New Size(114, 23)
        Month.TabIndex = 12
        ' 
        ' Label5
        ' 
        Label5.Anchor = AnchorStyles.Top
        Label5.AutoSize = True
        Label5.BackColor = SystemColors.Window
        Label5.Font = New Font("Century Gothic", 12F, FontStyle.Bold)
        Label5.ForeColor = SystemColors.ActiveCaptionText
        Label5.Location = New Point(108, 389)
        Label5.Name = "Label5"
        Label5.Size = New Size(56, 19)
        Label5.TabIndex = 14
        Label5.Text = "Year *"
        Label5.TextAlign = ContentAlignment.TopCenter
        ' 
        ' Year
        ' 
        Year.Anchor = AnchorStyles.Top
        Year.Location = New Point(108, 414)
        Year.Name = "Year"
        Year.Size = New Size(173, 23)
        Year.TabIndex = 15
        Year.Text = "DomainUpDown1"
        ' 
        ' Label6
        ' 
        Label6.Anchor = AnchorStyles.Top
        Label6.AutoSize = True
        Label6.BackColor = SystemColors.Window
        Label6.Font = New Font("Century Gothic", 12F, FontStyle.Bold)
        Label6.ForeColor = SystemColors.ActiveCaptionText
        Label6.Location = New Point(604, 259)
        Label6.Name = "Label6"
        Label6.Size = New Size(64, 19)
        Label6.TabIndex = 16
        Label6.Text = "Salary*"
        Label6.TextAlign = ContentAlignment.TopCenter
        ' 
        ' Salary
        ' 
        Salary.Anchor = AnchorStyles.Top
        Salary.BorderStyle = BorderStyle.FixedSingle
        Salary.Location = New Point(604, 284)
        Salary.Name = "Salary"
        Salary.Size = New Size(234, 23)
        Salary.TabIndex = 17
        ' 
        ' Label15
        ' 
        Label15.Anchor = AnchorStyles.Top
        Label15.AutoSize = True
        Label15.BackColor = SystemColors.Window
        Label15.Font = New Font("Century Gothic", 8.25F, FontStyle.Italic, GraphicsUnit.Point, CByte(0))
        Label15.ForeColor = Color.DarkOliveGreen
        Label15.Location = New Point(604, 310)
        Label15.Name = "Label15"
        Label15.Size = New Size(86, 15)
        Label15.TabIndex = 27
        Label15.Text = "Example 10000"
        ' 
        ' PictureBox2
        ' 
        PictureBox2.Anchor = AnchorStyles.Top
        PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), Image)
        PictureBox2.Location = New Point(575, 212)
        PictureBox2.Name = "PictureBox2"
        PictureBox2.Size = New Size(449, 362)
        PictureBox2.SizeMode = PictureBoxSizeMode.StretchImage
        PictureBox2.TabIndex = 28
        PictureBox2.TabStop = False
        ' 
        ' Label7
        ' 
        Label7.Anchor = AnchorStyles.Top
        Label7.AutoSize = True
        Label7.BackColor = SystemColors.Window
        Label7.Font = New Font("Century Gothic", 8.25F, FontStyle.Italic, GraphicsUnit.Point, CByte(0))
        Label7.ForeColor = Color.DarkOliveGreen
        Label7.Location = New Point(604, 399)
        Label7.Name = "Label7"
        Label7.Size = New Size(86, 15)
        Label7.TabIndex = 31
        Label7.Text = "Example 10000"
        ' 
        ' Deduction
        ' 
        Deduction.Anchor = AnchorStyles.Top
        Deduction.BorderStyle = BorderStyle.FixedSingle
        Deduction.Location = New Point(604, 373)
        Deduction.Name = "Deduction"
        Deduction.Size = New Size(137, 23)
        Deduction.TabIndex = 30
        ' 
        ' Label8
        ' 
        Label8.Anchor = AnchorStyles.Top
        Label8.AutoSize = True
        Label8.BackColor = SystemColors.Window
        Label8.Font = New Font("Century Gothic", 12F, FontStyle.Bold)
        Label8.ForeColor = SystemColors.ActiveCaptionText
        Label8.Location = New Point(604, 348)
        Label8.Name = "Label8"
        Label8.Size = New Size(96, 19)
        Label8.TabIndex = 29
        Label8.Text = "Deduction*"
        Label8.TextAlign = ContentAlignment.TopCenter
        ' 
        ' Notes
        ' 
        Notes.Anchor = AnchorStyles.Top
        Notes.BorderStyle = BorderStyle.FixedSingle
        Notes.Location = New Point(604, 461)
        Notes.Multiline = True
        Notes.Name = "Notes"
        Notes.Size = New Size(389, 83)
        Notes.TabIndex = 33
        ' 
        ' Label9
        ' 
        Label9.Anchor = AnchorStyles.Top
        Label9.AutoSize = True
        Label9.BackColor = SystemColors.Window
        Label9.Font = New Font("Century Gothic", 12F, FontStyle.Bold)
        Label9.ForeColor = SystemColors.ActiveCaptionText
        Label9.Location = New Point(604, 432)
        Label9.Name = "Label9"
        Label9.Size = New Size(51, 19)
        Label9.TabIndex = 32
        Label9.Text = "Notes"
        Label9.TextAlign = ContentAlignment.TopCenter
        ' 
        ' Panel1
        ' 
        Panel1.Anchor = AnchorStyles.Top
        Panel1.Controls.Add(Pay)
        Panel1.Location = New Point(873, 598)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(151, 54)
        Panel1.TabIndex = 34
        ' 
        ' Pay
        ' 
        Pay.BackColor = Color.FromArgb(CByte(38), CByte(49), CByte(64))
        Pay.ForeColor = Color.White
        Pay.Image = CType(resources.GetObject("Pay.Image"), Image)
        Pay.ImageAlign = ContentAlignment.MiddleLeft
        Pay.Location = New Point(-13, -9)
        Pay.Name = "Pay"
        Pay.Padding = New Padding(25, 0, 0, 0)
        Pay.Size = New Size(175, 74)
        Pay.TabIndex = 35
        Pay.Text = "Process Payroll"
        Pay.UseVisualStyleBackColor = False
        ' 
        ' Panel3
        ' 
        Panel3.Anchor = AnchorStyles.Top
        Panel3.BackColor = Color.FromArgb(CByte(38), CByte(49), CByte(64))
        Panel3.Controls.Add(late)
        Panel3.Controls.Add(Label11)
        Panel3.Controls.Add(PictureBox4)
        Panel3.Location = New Point(412, 480)
        Panel3.Name = "Panel3"
        Panel3.Size = New Size(108, 94)
        Panel3.TabIndex = 35
        ' 
        ' late
        ' 
        late.AutoSize = True
        late.BackColor = Color.Transparent
        late.Font = New Font("Century Gothic", 20.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        late.ForeColor = Color.White
        late.Location = New Point(58, 21)
        late.Name = "late"
        late.Size = New Size(29, 32)
        late.TabIndex = 13
        late.Text = "0"
        late.TextAlign = ContentAlignment.TopCenter
        ' 
        ' Label11
        ' 
        Label11.AutoSize = True
        Label11.BackColor = Color.Transparent
        Label11.Font = New Font("Century Gothic", 9.75F, FontStyle.Bold)
        Label11.ForeColor = Color.White
        Label11.Location = New Point(17, 67)
        Label11.Name = "Label11"
        Label11.Size = New Size(70, 16)
        Label11.TabIndex = 12
        Label11.Text = "Late Days"
        Label11.TextAlign = ContentAlignment.TopCenter
        ' 
        ' PictureBox4
        ' 
        PictureBox4.Image = CType(resources.GetObject("PictureBox4.Image"), Image)
        PictureBox4.Location = New Point(20, 22)
        PictureBox4.Name = "PictureBox4"
        PictureBox4.Size = New Size(22, 28)
        PictureBox4.SizeMode = PictureBoxSizeMode.Zoom
        PictureBox4.TabIndex = 12
        PictureBox4.TabStop = False
        ' 
        ' Panel2
        ' 
        Panel2.Anchor = AnchorStyles.Top
        Panel2.BackColor = Color.FromArgb(CByte(38), CByte(49), CByte(64))
        Panel2.Controls.Add(Halfday)
        Panel2.Controls.Add(Label12)
        Panel2.Controls.Add(PictureBox3)
        Panel2.Location = New Point(298, 480)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(108, 94)
        Panel2.TabIndex = 36
        ' 
        ' Halfday
        ' 
        Halfday.AutoSize = True
        Halfday.BackColor = Color.Transparent
        Halfday.Font = New Font("Century Gothic", 20.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Halfday.ForeColor = Color.White
        Halfday.Location = New Point(55, 21)
        Halfday.Name = "Halfday"
        Halfday.Size = New Size(29, 32)
        Halfday.TabIndex = 13
        Halfday.Text = "0"
        Halfday.TextAlign = ContentAlignment.TopCenter
        ' 
        ' Label12
        ' 
        Label12.AutoSize = True
        Label12.BackColor = Color.Transparent
        Label12.Font = New Font("Century Gothic", 9.75F, FontStyle.Bold)
        Label12.ForeColor = Color.White
        Label12.Location = New Point(17, 67)
        Label12.Name = "Label12"
        Label12.Size = New Size(69, 16)
        Label12.TabIndex = 12
        Label12.Text = "Half Days"
        Label12.TextAlign = ContentAlignment.TopCenter
        ' 
        ' PictureBox3
        ' 
        PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), Image)
        PictureBox3.Location = New Point(17, 22)
        PictureBox3.Name = "PictureBox3"
        PictureBox3.Size = New Size(22, 28)
        PictureBox3.SizeMode = PictureBoxSizeMode.Zoom
        PictureBox3.TabIndex = 12
        PictureBox3.TabStop = False
        ' 
        ' Panel4
        ' 
        Panel4.Anchor = AnchorStyles.Top
        Panel4.BackColor = Color.FromArgb(CByte(38), CByte(49), CByte(64))
        Panel4.Controls.Add(Absent)
        Panel4.Controls.Add(Label14)
        Panel4.Controls.Add(PictureBox5)
        Panel4.Location = New Point(184, 480)
        Panel4.Name = "Panel4"
        Panel4.Size = New Size(108, 94)
        Panel4.TabIndex = 37
        ' 
        ' Absent
        ' 
        Absent.AutoSize = True
        Absent.BackColor = Color.Transparent
        Absent.Font = New Font("Century Gothic", 20.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Absent.ForeColor = Color.White
        Absent.Location = New Point(54, 21)
        Absent.Name = "Absent"
        Absent.Size = New Size(29, 32)
        Absent.TabIndex = 13
        Absent.Text = "0"
        Absent.TextAlign = ContentAlignment.TopCenter
        ' 
        ' Label14
        ' 
        Label14.AutoSize = True
        Label14.BackColor = Color.Transparent
        Label14.Font = New Font("Century Gothic", 9.75F, FontStyle.Bold)
        Label14.ForeColor = Color.White
        Label14.Location = New Point(9, 67)
        Label14.Name = "Label14"
        Label14.Size = New Size(88, 16)
        Label14.TabIndex = 12
        Label14.Text = "Absent Days"
        Label14.TextAlign = ContentAlignment.TopCenter
        ' 
        ' PictureBox5
        ' 
        PictureBox5.Image = CType(resources.GetObject("PictureBox5.Image"), Image)
        PictureBox5.Location = New Point(16, 22)
        PictureBox5.Name = "PictureBox5"
        PictureBox5.Size = New Size(22, 28)
        PictureBox5.SizeMode = PictureBoxSizeMode.Zoom
        PictureBox5.TabIndex = 12
        PictureBox5.TabStop = False
        ' 
        ' Panel5
        ' 
        Panel5.Anchor = AnchorStyles.Top
        Panel5.BackColor = Color.FromArgb(CByte(38), CByte(49), CByte(64))
        Panel5.Controls.Add(Present)
        Panel5.Controls.Add(Label17)
        Panel5.Controls.Add(PictureBox6)
        Panel5.Location = New Point(70, 480)
        Panel5.Name = "Panel5"
        Panel5.Size = New Size(108, 94)
        Panel5.TabIndex = 38
        ' 
        ' Present
        ' 
        Present.AutoSize = True
        Present.BackColor = Color.Transparent
        Present.Font = New Font("Century Gothic", 20.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Present.ForeColor = Color.White
        Present.Location = New Point(55, 22)
        Present.Name = "Present"
        Present.Size = New Size(29, 32)
        Present.TabIndex = 13
        Present.Text = "0"
        Present.TextAlign = ContentAlignment.TopCenter
        ' 
        ' Label17
        ' 
        Label17.AutoSize = True
        Label17.BackColor = Color.Transparent
        Label17.Font = New Font("Century Gothic", 9.75F, FontStyle.Bold)
        Label17.ForeColor = Color.White
        Label17.Location = New Point(9, 67)
        Label17.Name = "Label17"
        Label17.Size = New Size(89, 16)
        Label17.TabIndex = 12
        Label17.Text = "Present Days"
        Label17.TextAlign = ContentAlignment.TopCenter
        ' 
        ' PictureBox6
        ' 
        PictureBox6.Image = CType(resources.GetObject("PictureBox6.Image"), Image)
        PictureBox6.Location = New Point(17, 22)
        PictureBox6.Name = "PictureBox6"
        PictureBox6.Size = New Size(22, 28)
        PictureBox6.SizeMode = PictureBoxSizeMode.Zoom
        PictureBox6.TabIndex = 12
        PictureBox6.TabStop = False
        ' 
        ' daysdate
        ' 
        daysdate.Anchor = AnchorStyles.Top
        daysdate.BorderStyle = BorderStyle.FixedSingle
        daysdate.Location = New Point(238, 348)
        daysdate.Name = "daysdate"
        daysdate.Size = New Size(85, 23)
        daysdate.TabIndex = 39
        ' 
        ' Label10
        ' 
        Label10.Anchor = AnchorStyles.Top
        Label10.AutoSize = True
        Label10.BackColor = SystemColors.Window
        Label10.Font = New Font("Century Gothic", 12F, FontStyle.Bold)
        Label10.ForeColor = SystemColors.ActiveCaptionText
        Label10.Location = New Point(238, 323)
        Label10.Name = "Label10"
        Label10.Size = New Size(56, 19)
        Label10.TabIndex = 40
        Label10.Text = "Date *"
        Label10.TextAlign = ContentAlignment.TopCenter
        ' 
        ' deductionbtn
        ' 
        deductionbtn.Anchor = AnchorStyles.Top
        deductionbtn.BackColor = Color.OrangeRed
        deductionbtn.FlatStyle = FlatStyle.Flat
        deductionbtn.ForeColor = Color.White
        deductionbtn.Location = New Point(747, 368)
        deductionbtn.Name = "deductionbtn"
        deductionbtn.Size = New Size(80, 35)
        deductionbtn.TabIndex = 41
        deductionbtn.Text = "Deduction"
        deductionbtn.UseVisualStyleBackColor = False
        ' 
        ' Listofdeduction
        ' 
        Listofdeduction.Anchor = AnchorStyles.Top
        Listofdeduction.BorderStyle = BorderStyle.None
        Listofdeduction.ForeColor = Color.ForestGreen
        Listofdeduction.FormattingEnabled = True
        Listofdeduction.ItemHeight = 15
        Listofdeduction.Location = New Point(833, 368)
        Listofdeduction.Name = "Listofdeduction"
        Listofdeduction.Size = New Size(160, 75)
        Listofdeduction.TabIndex = 42
        ' 
        ' Payroll
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1092, 684)
        Controls.Add(Listofdeduction)
        Controls.Add(deductionbtn)
        Controls.Add(Label10)
        Controls.Add(daysdate)
        Controls.Add(Panel5)
        Controls.Add(Panel4)
        Controls.Add(Panel2)
        Controls.Add(Panel3)
        Controls.Add(Panel1)
        Controls.Add(Notes)
        Controls.Add(Label9)
        Controls.Add(Label7)
        Controls.Add(Deduction)
        Controls.Add(Label8)
        Controls.Add(Label15)
        Controls.Add(Salary)
        Controls.Add(Label6)
        Controls.Add(Year)
        Controls.Add(Label5)
        Controls.Add(Month)
        Controls.Add(Label4)
        Controls.Add(Label3)
        Controls.Add(Label2)
        Controls.Add(employee)
        Controls.Add(Label1)
        Controls.Add(PictureBox1)
        Controls.Add(PictureBox2)
        FormBorderStyle = FormBorderStyle.None
        Name = "Payroll"
        Text = "Payroll"
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox2, ComponentModel.ISupportInitialize).EndInit()
        Panel1.ResumeLayout(False)
        Panel3.ResumeLayout(False)
        Panel3.PerformLayout()
        CType(PictureBox4, ComponentModel.ISupportInitialize).EndInit()
        Panel2.ResumeLayout(False)
        Panel2.PerformLayout()
        CType(PictureBox3, ComponentModel.ISupportInitialize).EndInit()
        Panel4.ResumeLayout(False)
        Panel4.PerformLayout()
        CType(PictureBox5, ComponentModel.ISupportInitialize).EndInit()
        Panel5.ResumeLayout(False)
        Panel5.PerformLayout()
        CType(PictureBox6, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label1 As Label
    Friend WithEvents employee As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Month As DateTimePicker
    Friend WithEvents Label5 As Label
    Friend WithEvents Year As DomainUpDown
    Friend WithEvents Label6 As Label
    Friend WithEvents Salary As TextBox
    Friend WithEvents Label15 As Label
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Deduction As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Notes As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Pay As Button
    Friend WithEvents Panel3 As Panel
    Friend WithEvents late As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents PictureBox4 As PictureBox
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Halfday As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents PictureBox3 As PictureBox
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Absent As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents PictureBox5 As PictureBox
    Friend WithEvents Panel5 As Panel
    Friend WithEvents Present As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents PictureBox6 As PictureBox
    Friend WithEvents daysdate As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents deductionbtn As Button
    Friend WithEvents Listofdeduction As ListBox
End Class
