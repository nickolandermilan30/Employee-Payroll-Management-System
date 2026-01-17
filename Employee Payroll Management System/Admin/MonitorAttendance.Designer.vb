<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MonitorAttendance
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MonitorAttendance))
        Employedropdown = New ComboBox()
        Label2 = New Label()
        Label1 = New Label()
        Label3 = New Label()
        Panel1 = New Panel()
        presentcount = New Label()
        Label4 = New Label()
        PictureBox1 = New PictureBox()
        Panel5 = New Panel()
        absentcount = New Label()
        Label7 = New Label()
        PictureBox2 = New PictureBox()
        Panel2 = New Panel()
        halfdaycount = New Label()
        Label9 = New Label()
        PictureBox3 = New PictureBox()
        Panel3 = New Panel()
        latedayscount = New Label()
        Label11 = New Label()
        PictureBox4 = New PictureBox()
        Panel4 = New Panel()
        monthofdate = New DateTimePicker()
        Label10 = New Label()
        checkout = New ComboBox()
        Label12 = New Label()
        checkin = New ComboBox()
        Label5 = New Label()
        Label6 = New Label()
        PictureBox5 = New PictureBox()
        Panel6 = New Panel()
        emailofemployee = New Label()
        nameemployee = New Label()
        PictureBox6 = New PictureBox()
        Panel7 = New Panel()
        status = New ComboBox()
        Label19 = New Label()
        PictureBox7 = New PictureBox()
        viewemployeedata = New Panel()
        save = New Button()
        Panel9 = New Panel()
        Panel1.SuspendLayout()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        Panel5.SuspendLayout()
        CType(PictureBox2, ComponentModel.ISupportInitialize).BeginInit()
        Panel2.SuspendLayout()
        CType(PictureBox3, ComponentModel.ISupportInitialize).BeginInit()
        Panel3.SuspendLayout()
        CType(PictureBox4, ComponentModel.ISupportInitialize).BeginInit()
        Panel4.SuspendLayout()
        CType(PictureBox5, ComponentModel.ISupportInitialize).BeginInit()
        Panel6.SuspendLayout()
        CType(PictureBox6, ComponentModel.ISupportInitialize).BeginInit()
        Panel7.SuspendLayout()
        CType(PictureBox7, ComponentModel.ISupportInitialize).BeginInit()
        Panel9.SuspendLayout()
        SuspendLayout()
        ' 
        ' Employedropdown
        ' 
        Employedropdown.Anchor = AnchorStyles.Top
        Employedropdown.FormattingEnabled = True
        Employedropdown.Location = New Point(53, 186)
        Employedropdown.Name = "Employedropdown"
        Employedropdown.Size = New Size(276, 23)
        Employedropdown.TabIndex = 0
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.BackColor = SystemColors.Control
        Label2.Font = New Font("Century Gothic", 12F, FontStyle.Bold)
        Label2.ForeColor = SystemColors.ControlDarkDark
        Label2.Location = New Point(27, 79)
        Label2.Name = "Label2"
        Label2.Size = New Size(428, 19)
        Label2.TabIndex = 6
        Label2.Text = "Here's what happening with your payroll system today."
        Label2.TextAlign = ContentAlignment.TopCenter
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.BackColor = SystemColors.Control
        Label1.Font = New Font("Century Gothic", 20.25F, FontStyle.Bold)
        Label1.Location = New Point(27, 37)
        Label1.Name = "Label1"
        Label1.Size = New Size(226, 32)
        Label1.TabIndex = 5
        Label1.Text = "Wellcome Back "
        ' 
        ' Label3
        ' 
        Label3.Anchor = AnchorStyles.Top
        Label3.AutoSize = True
        Label3.BackColor = SystemColors.Control
        Label3.Font = New Font("Century Gothic", 9.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label3.ForeColor = SystemColors.ActiveCaptionText
        Label3.Location = New Point(53, 162)
        Label3.Name = "Label3"
        Label3.Size = New Size(71, 16)
        Label3.TabIndex = 7
        Label3.Text = "Employee"
        Label3.TextAlign = ContentAlignment.TopCenter
        ' 
        ' Panel1
        ' 
        Panel1.Anchor = AnchorStyles.Top
        Panel1.BackColor = Color.FromArgb(CByte(38), CByte(49), CByte(64))
        Panel1.Controls.Add(presentcount)
        Panel1.Controls.Add(Label4)
        Panel1.Controls.Add(PictureBox1)
        Panel1.Location = New Point(546, 427)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(200, 100)
        Panel1.TabIndex = 8
        ' 
        ' presentcount
        ' 
        presentcount.AutoSize = True
        presentcount.BackColor = Color.Transparent
        presentcount.Font = New Font("Century Gothic", 20.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        presentcount.ForeColor = Color.White
        presentcount.Location = New Point(55, 14)
        presentcount.Name = "presentcount"
        presentcount.Size = New Size(29, 32)
        presentcount.TabIndex = 13
        presentcount.Text = "0"
        presentcount.TextAlign = ContentAlignment.TopCenter
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.BackColor = Color.Transparent
        Label4.Font = New Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label4.ForeColor = Color.White
        Label4.Location = New Point(17, 58)
        Label4.Name = "Label4"
        Label4.Size = New Size(104, 19)
        Label4.TabIndex = 12
        Label4.Text = "Present Days"
        Label4.TextAlign = ContentAlignment.TopCenter
        ' 
        ' PictureBox1
        ' 
        PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), Image)
        PictureBox1.Location = New Point(17, 14)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(22, 28)
        PictureBox1.SizeMode = PictureBoxSizeMode.Zoom
        PictureBox1.TabIndex = 12
        PictureBox1.TabStop = False
        ' 
        ' Panel5
        ' 
        Panel5.Anchor = AnchorStyles.Top
        Panel5.BackColor = Color.FromArgb(CByte(38), CByte(49), CByte(64))
        Panel5.Controls.Add(absentcount)
        Panel5.Controls.Add(Label7)
        Panel5.Controls.Add(PictureBox2)
        Panel5.Location = New Point(772, 427)
        Panel5.Name = "Panel5"
        Panel5.Size = New Size(200, 100)
        Panel5.TabIndex = 14
        ' 
        ' absentcount
        ' 
        absentcount.AutoSize = True
        absentcount.BackColor = Color.Transparent
        absentcount.Font = New Font("Century Gothic", 20.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        absentcount.ForeColor = Color.White
        absentcount.Location = New Point(55, 14)
        absentcount.Name = "absentcount"
        absentcount.Size = New Size(29, 32)
        absentcount.TabIndex = 13
        absentcount.Text = "0"
        absentcount.TextAlign = ContentAlignment.TopCenter
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.BackColor = Color.Transparent
        Label7.Font = New Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label7.ForeColor = Color.White
        Label7.Location = New Point(17, 58)
        Label7.Name = "Label7"
        Label7.Size = New Size(103, 19)
        Label7.TabIndex = 12
        Label7.Text = "Absent Days"
        Label7.TextAlign = ContentAlignment.TopCenter
        ' 
        ' PictureBox2
        ' 
        PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), Image)
        PictureBox2.Location = New Point(17, 14)
        PictureBox2.Name = "PictureBox2"
        PictureBox2.Size = New Size(22, 28)
        PictureBox2.SizeMode = PictureBoxSizeMode.Zoom
        PictureBox2.TabIndex = 12
        PictureBox2.TabStop = False
        ' 
        ' Panel2
        ' 
        Panel2.Anchor = AnchorStyles.Top
        Panel2.BackColor = Color.FromArgb(CByte(38), CByte(49), CByte(64))
        Panel2.Controls.Add(halfdaycount)
        Panel2.Controls.Add(Label9)
        Panel2.Controls.Add(PictureBox3)
        Panel2.Location = New Point(546, 295)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(200, 100)
        Panel2.TabIndex = 15
        ' 
        ' halfdaycount
        ' 
        halfdaycount.AutoSize = True
        halfdaycount.BackColor = Color.Transparent
        halfdaycount.Font = New Font("Century Gothic", 20.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        halfdaycount.ForeColor = Color.White
        halfdaycount.Location = New Point(55, 14)
        halfdaycount.Name = "halfdaycount"
        halfdaycount.Size = New Size(29, 32)
        halfdaycount.TabIndex = 13
        halfdaycount.Text = "0"
        halfdaycount.TextAlign = ContentAlignment.TopCenter
        ' 
        ' Label9
        ' 
        Label9.AutoSize = True
        Label9.BackColor = Color.Transparent
        Label9.Font = New Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label9.ForeColor = Color.White
        Label9.Location = New Point(17, 58)
        Label9.Name = "Label9"
        Label9.Size = New Size(80, 19)
        Label9.TabIndex = 12
        Label9.Text = "Half Days"
        Label9.TextAlign = ContentAlignment.TopCenter
        ' 
        ' PictureBox3
        ' 
        PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), Image)
        PictureBox3.Location = New Point(17, 14)
        PictureBox3.Name = "PictureBox3"
        PictureBox3.Size = New Size(22, 28)
        PictureBox3.SizeMode = PictureBoxSizeMode.Zoom
        PictureBox3.TabIndex = 12
        PictureBox3.TabStop = False
        ' 
        ' Panel3
        ' 
        Panel3.Anchor = AnchorStyles.Top
        Panel3.BackColor = Color.FromArgb(CByte(38), CByte(49), CByte(64))
        Panel3.Controls.Add(latedayscount)
        Panel3.Controls.Add(Label11)
        Panel3.Controls.Add(PictureBox4)
        Panel3.Location = New Point(768, 295)
        Panel3.Name = "Panel3"
        Panel3.Size = New Size(200, 100)
        Panel3.TabIndex = 16
        ' 
        ' latedayscount
        ' 
        latedayscount.AutoSize = True
        latedayscount.BackColor = Color.Transparent
        latedayscount.Font = New Font("Century Gothic", 20.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        latedayscount.ForeColor = Color.White
        latedayscount.Location = New Point(55, 14)
        latedayscount.Name = "latedayscount"
        latedayscount.Size = New Size(29, 32)
        latedayscount.TabIndex = 13
        latedayscount.Text = "0"
        latedayscount.TextAlign = ContentAlignment.TopCenter
        ' 
        ' Label11
        ' 
        Label11.AutoSize = True
        Label11.BackColor = Color.Transparent
        Label11.Font = New Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label11.ForeColor = Color.White
        Label11.Location = New Point(17, 58)
        Label11.Name = "Label11"
        Label11.Size = New Size(82, 19)
        Label11.TabIndex = 12
        Label11.Text = "Late Days"
        Label11.TextAlign = ContentAlignment.TopCenter
        ' 
        ' PictureBox4
        ' 
        PictureBox4.Image = CType(resources.GetObject("PictureBox4.Image"), Image)
        PictureBox4.Location = New Point(17, 14)
        PictureBox4.Name = "PictureBox4"
        PictureBox4.Size = New Size(22, 28)
        PictureBox4.SizeMode = PictureBoxSizeMode.Zoom
        PictureBox4.TabIndex = 12
        PictureBox4.TabStop = False
        ' 
        ' Panel4
        ' 
        Panel4.Anchor = AnchorStyles.Top
        Panel4.BackColor = Color.FromArgb(CByte(41), CByte(99), CByte(116))
        Panel4.Controls.Add(monthofdate)
        Panel4.Controls.Add(Label10)
        Panel4.Controls.Add(checkout)
        Panel4.Controls.Add(Label12)
        Panel4.Controls.Add(checkin)
        Panel4.Controls.Add(Label5)
        Panel4.Controls.Add(Label6)
        Panel4.Controls.Add(PictureBox5)
        Panel4.Location = New Point(53, 234)
        Panel4.Name = "Panel4"
        Panel4.Size = New Size(472, 183)
        Panel4.TabIndex = 15
        ' 
        ' monthofdate
        ' 
        monthofdate.Location = New Point(45, 81)
        monthofdate.Name = "monthofdate"
        monthofdate.Size = New Size(362, 23)
        monthofdate.TabIndex = 21
        ' 
        ' Label10
        ' 
        Label10.AutoSize = True
        Label10.BackColor = Color.Transparent
        Label10.Font = New Font("Century Gothic", 9.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label10.ForeColor = Color.White
        Label10.Location = New Point(239, 120)
        Label10.Name = "Label10"
        Label10.Size = New Size(110, 16)
        Label10.TabIndex = 20
        Label10.Text = "Check Out Time"
        Label10.TextAlign = ContentAlignment.TopCenter
        ' 
        ' checkout
        ' 
        checkout.FormattingEnabled = True
        checkout.Location = New Point(239, 139)
        checkout.Name = "checkout"
        checkout.Size = New Size(168, 23)
        checkout.TabIndex = 19
        ' 
        ' Label12
        ' 
        Label12.AutoSize = True
        Label12.BackColor = Color.Transparent
        Label12.Font = New Font("Century Gothic", 9.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label12.ForeColor = Color.White
        Label12.Location = New Point(45, 120)
        Label12.Name = "Label12"
        Label12.Size = New Size(99, 16)
        Label12.TabIndex = 18
        Label12.Text = "Check in Time"
        Label12.TextAlign = ContentAlignment.TopCenter
        ' 
        ' checkin
        ' 
        checkin.FormattingEnabled = True
        checkin.Location = New Point(45, 139)
        checkin.Name = "checkin"
        checkin.Size = New Size(168, 23)
        checkin.TabIndex = 17
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.BackColor = Color.Transparent
        Label5.Font = New Font("Century Gothic", 9.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label5.ForeColor = Color.White
        Label5.Location = New Point(45, 61)
        Label5.Name = "Label5"
        Label5.Size = New Size(37, 16)
        Label5.TabIndex = 14
        Label5.Text = "Date"
        Label5.TextAlign = ContentAlignment.TopCenter
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.BackColor = Color.Transparent
        Label6.Font = New Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label6.ForeColor = Color.White
        Label6.Location = New Point(45, 22)
        Label6.Name = "Label6"
        Label6.Size = New Size(140, 19)
        Label6.TabIndex = 12
        Label6.Text = "Filter Attendance"
        Label6.TextAlign = ContentAlignment.TopCenter
        ' 
        ' PictureBox5
        ' 
        PictureBox5.Image = CType(resources.GetObject("PictureBox5.Image"), Image)
        PictureBox5.Location = New Point(17, 18)
        PictureBox5.Name = "PictureBox5"
        PictureBox5.Size = New Size(22, 28)
        PictureBox5.SizeMode = PictureBoxSizeMode.Zoom
        PictureBox5.TabIndex = 12
        PictureBox5.TabStop = False
        ' 
        ' Panel6
        ' 
        Panel6.Anchor = AnchorStyles.Top
        Panel6.BackColor = Color.FromArgb(CByte(41), CByte(99), CByte(116))
        Panel6.Controls.Add(emailofemployee)
        Panel6.Controls.Add(nameemployee)
        Panel6.Controls.Add(PictureBox6)
        Panel6.Location = New Point(546, 203)
        Panel6.Name = "Panel6"
        Panel6.Size = New Size(468, 72)
        Panel6.TabIndex = 21
        ' 
        ' emailofemployee
        ' 
        emailofemployee.AutoSize = True
        emailofemployee.BackColor = Color.Transparent
        emailofemployee.Font = New Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        emailofemployee.ForeColor = Color.White
        emailofemployee.Location = New Point(60, 39)
        emailofemployee.Name = "emailofemployee"
        emailofemployee.Size = New Size(113, 16)
        emailofemployee.TabIndex = 23
        emailofemployee.Text = "name@gmail.com"
        emailofemployee.TextAlign = ContentAlignment.TopCenter
        ' 
        ' nameemployee
        ' 
        nameemployee.AutoSize = True
        nameemployee.BackColor = Color.Transparent
        nameemployee.Font = New Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        nameemployee.ForeColor = Color.White
        nameemployee.Location = New Point(59, 12)
        nameemployee.Name = "nameemployee"
        nameemployee.Size = New Size(62, 19)
        nameemployee.TabIndex = 21
        nameemployee.Text = "Name:"
        nameemployee.TextAlign = ContentAlignment.TopCenter
        ' 
        ' PictureBox6
        ' 
        PictureBox6.Image = CType(resources.GetObject("PictureBox6.Image"), Image)
        PictureBox6.Location = New Point(17, 12)
        PictureBox6.Name = "PictureBox6"
        PictureBox6.Size = New Size(33, 43)
        PictureBox6.SizeMode = PictureBoxSizeMode.Zoom
        PictureBox6.TabIndex = 22
        PictureBox6.TabStop = False
        ' 
        ' Panel7
        ' 
        Panel7.Anchor = AnchorStyles.Top
        Panel7.BackColor = Color.FromArgb(CByte(41), CByte(99), CByte(116))
        Panel7.Controls.Add(status)
        Panel7.Controls.Add(Label19)
        Panel7.Controls.Add(PictureBox7)
        Panel7.Location = New Point(53, 423)
        Panel7.Name = "Panel7"
        Panel7.Size = New Size(472, 100)
        Panel7.TabIndex = 21
        ' 
        ' status
        ' 
        status.FormattingEnabled = True
        status.Location = New Point(45, 55)
        status.Name = "status"
        status.Size = New Size(276, 23)
        status.TabIndex = 15
        ' 
        ' Label19
        ' 
        Label19.AutoSize = True
        Label19.BackColor = Color.Transparent
        Label19.Font = New Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label19.ForeColor = Color.White
        Label19.Location = New Point(45, 22)
        Label19.Name = "Label19"
        Label19.Size = New Size(52, 19)
        Label19.TabIndex = 12
        Label19.Text = "Status"
        Label19.TextAlign = ContentAlignment.TopCenter
        ' 
        ' PictureBox7
        ' 
        PictureBox7.Image = CType(resources.GetObject("PictureBox7.Image"), Image)
        PictureBox7.Location = New Point(17, 18)
        PictureBox7.Name = "PictureBox7"
        PictureBox7.Size = New Size(22, 28)
        PictureBox7.SizeMode = PictureBoxSizeMode.Zoom
        PictureBox7.TabIndex = 12
        PictureBox7.TabStop = False
        ' 
        ' viewemployeedata
        ' 
        viewemployeedata.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        viewemployeedata.Location = New Point(53, 551)
        viewemployeedata.Name = "viewemployeedata"
        viewemployeedata.Size = New Size(965, 166)
        viewemployeedata.TabIndex = 22
        ' 
        ' save
        ' 
        save.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
        save.BackColor = Color.FromArgb(CByte(208), CByte(39), CByte(82))
        save.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        save.ForeColor = Color.White
        save.Image = CType(resources.GetObject("save.Image"), Image)
        save.ImageAlign = ContentAlignment.MiddleLeft
        save.Location = New Point(-16, -6)
        save.Name = "save"
        save.Padding = New Padding(25, 0, 35, 0)
        save.Size = New Size(265, 70)
        save.TabIndex = 7
        save.Text = "    Save Attendance"
        save.UseVisualStyleBackColor = False
        ' 
        ' Panel9
        ' 
        Panel9.Anchor = AnchorStyles.Top
        Panel9.Controls.Add(save)
        Panel9.Location = New Point(796, 127)
        Panel9.Name = "Panel9"
        Panel9.Size = New Size(218, 61)
        Panel9.TabIndex = 23
        ' 
        ' MonitorAttendance
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1108, 723)
        Controls.Add(Panel9)
        Controls.Add(viewemployeedata)
        Controls.Add(Panel7)
        Controls.Add(Panel6)
        Controls.Add(Panel4)
        Controls.Add(Panel3)
        Controls.Add(Panel2)
        Controls.Add(Panel5)
        Controls.Add(Panel1)
        Controls.Add(Label3)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Controls.Add(Employedropdown)
        FormBorderStyle = FormBorderStyle.None
        Name = "MonitorAttendance"
        Text = "MonitorAttendance"
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        Panel5.ResumeLayout(False)
        Panel5.PerformLayout()
        CType(PictureBox2, ComponentModel.ISupportInitialize).EndInit()
        Panel2.ResumeLayout(False)
        Panel2.PerformLayout()
        CType(PictureBox3, ComponentModel.ISupportInitialize).EndInit()
        Panel3.ResumeLayout(False)
        Panel3.PerformLayout()
        CType(PictureBox4, ComponentModel.ISupportInitialize).EndInit()
        Panel4.ResumeLayout(False)
        Panel4.PerformLayout()
        CType(PictureBox5, ComponentModel.ISupportInitialize).EndInit()
        Panel6.ResumeLayout(False)
        Panel6.PerformLayout()
        CType(PictureBox6, ComponentModel.ISupportInitialize).EndInit()
        Panel7.ResumeLayout(False)
        Panel7.PerformLayout()
        CType(PictureBox7, ComponentModel.ISupportInitialize).EndInit()
        Panel9.ResumeLayout(False)
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Employedropdown As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label4 As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents presentcount As Label
    Friend WithEvents Panel5 As Panel
    Friend WithEvents absentcount As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents Panel2 As Panel
    Friend WithEvents halfdaycount As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents PictureBox3 As PictureBox
    Friend WithEvents Panel3 As Panel
    Friend WithEvents latedayscount As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents PictureBox4 As PictureBox
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Label6 As Label
    Friend WithEvents PictureBox5 As PictureBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents checkout As ComboBox
    Friend WithEvents Label12 As Label
    Friend WithEvents checkin As ComboBox
    Friend WithEvents Panel6 As Panel
    Friend WithEvents emailofemployee As Label
    Friend WithEvents nameemployee As Label
    Friend WithEvents PictureBox6 As PictureBox
    Friend WithEvents Panel7 As Panel
    Friend WithEvents Label19 As Label
    Friend WithEvents PictureBox7 As PictureBox
    Friend WithEvents status As ComboBox
    Friend WithEvents viewemployeedata As Panel
    Friend WithEvents save As Button
    Friend WithEvents Panel9 As Panel
    Friend WithEvents monthofdate As DateTimePicker
End Class
