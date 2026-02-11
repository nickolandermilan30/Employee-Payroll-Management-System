<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AttendanceChecker
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AttendanceChecker))
        Notification = New Button()
        Label3 = New Label()
        Label2 = New Label()
        Label1 = New Label()
        Employedropdown = New ComboBox()
        viewemployeedata = New Panel()
        Panel4 = New Panel()
        monthofdate = New DateTimePicker()
        Label10 = New Label()
        checkout = New ComboBox()
        Label12 = New Label()
        checkin = New ComboBox()
        Label5 = New Label()
        Label6 = New Label()
        PictureBox5 = New PictureBox()
        Panel7 = New Panel()
        status = New ComboBox()
        Label19 = New Label()
        PictureBox7 = New PictureBox()
        Panel2 = New Panel()
        halfdaycount = New Label()
        Label9 = New Label()
        PictureBox3 = New PictureBox()
        Panel3 = New Panel()
        latedayscount = New Label()
        Label11 = New Label()
        PictureBox4 = New PictureBox()
        Panel1 = New Panel()
        presentcount = New Label()
        Label4 = New Label()
        PictureBox1 = New PictureBox()
        Panel5 = New Panel()
        absentcount = New Label()
        Label7 = New Label()
        PictureBox2 = New PictureBox()
        save = New Button()
        Panel4.SuspendLayout()
        CType(PictureBox5, ComponentModel.ISupportInitialize).BeginInit()
        Panel7.SuspendLayout()
        CType(PictureBox7, ComponentModel.ISupportInitialize).BeginInit()
        Panel2.SuspendLayout()
        CType(PictureBox3, ComponentModel.ISupportInitialize).BeginInit()
        Panel3.SuspendLayout()
        CType(PictureBox4, ComponentModel.ISupportInitialize).BeginInit()
        Panel1.SuspendLayout()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        Panel5.SuspendLayout()
        CType(PictureBox2, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Notification
        ' 
        Notification.Anchor = AnchorStyles.Top
        Notification.BackColor = Color.FromArgb(CByte(208), CByte(39), CByte(82))
        Notification.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Notification.ForeColor = SystemColors.Window
        Notification.Image = CType(resources.GetObject("Notification.Image"), Image)
        Notification.Location = New Point(344, 133)
        Notification.Name = "Notification"
        Notification.Size = New Size(54, 47)
        Notification.TabIndex = 27
        Notification.UseVisualStyleBackColor = False
        ' 
        ' Label3
        ' 
        Label3.Anchor = AnchorStyles.Top
        Label3.AutoSize = True
        Label3.BackColor = SystemColors.Control
        Label3.Font = New Font("Century Gothic", 9.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label3.ForeColor = SystemColors.ActiveCaptionText
        Label3.Location = New Point(52, 133)
        Label3.Name = "Label3"
        Label3.Size = New Size(71, 16)
        Label3.TabIndex = 28
        Label3.Text = "Employee"
        Label3.TextAlign = ContentAlignment.TopCenter
        ' 
        ' Label2
        ' 
        Label2.Anchor = AnchorStyles.Top
        Label2.AutoSize = True
        Label2.BackColor = SystemColors.Control
        Label2.Font = New Font("Century Gothic", 12F, FontStyle.Bold)
        Label2.ForeColor = SystemColors.ControlDarkDark
        Label2.Location = New Point(51, 84)
        Label2.Name = "Label2"
        Label2.Size = New Size(428, 19)
        Label2.TabIndex = 26
        Label2.Text = "Here's what happening with your payroll system today."
        Label2.TextAlign = ContentAlignment.TopCenter
        ' 
        ' Label1
        ' 
        Label1.Anchor = AnchorStyles.Top
        Label1.AutoSize = True
        Label1.BackColor = SystemColors.Control
        Label1.Font = New Font("Century Gothic", 20.25F, FontStyle.Bold)
        Label1.Location = New Point(51, 42)
        Label1.Name = "Label1"
        Label1.Size = New Size(226, 32)
        Label1.TabIndex = 25
        Label1.Text = "Wellcome Back "
        ' 
        ' Employedropdown
        ' 
        Employedropdown.Anchor = AnchorStyles.Top
        Employedropdown.FormattingEnabled = True
        Employedropdown.Location = New Point(52, 157)
        Employedropdown.Name = "Employedropdown"
        Employedropdown.Size = New Size(276, 23)
        Employedropdown.TabIndex = 24
        ' 
        ' viewemployeedata
        ' 
        viewemployeedata.Anchor = AnchorStyles.Top
        viewemployeedata.BackColor = SystemColors.ButtonShadow
        viewemployeedata.Location = New Point(421, 133)
        viewemployeedata.Name = "viewemployeedata"
        viewemployeedata.Size = New Size(722, 602)
        viewemployeedata.TabIndex = 29
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
        Panel4.Location = New Point(52, 199)
        Panel4.Name = "Panel4"
        Panel4.Size = New Size(346, 183)
        Panel4.TabIndex = 30
        ' 
        ' monthofdate
        ' 
        monthofdate.Anchor = AnchorStyles.Top
        monthofdate.Location = New Point(36, 82)
        monthofdate.Name = "monthofdate"
        monthofdate.Size = New Size(276, 23)
        monthofdate.TabIndex = 21
        ' 
        ' Label10
        ' 
        Label10.Anchor = AnchorStyles.Top
        Label10.AutoSize = True
        Label10.BackColor = Color.Transparent
        Label10.Font = New Font("Century Gothic", 9.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label10.ForeColor = Color.White
        Label10.Location = New Point(169, 121)
        Label10.Name = "Label10"
        Label10.Size = New Size(110, 16)
        Label10.TabIndex = 20
        Label10.Text = "Check Out Time"
        Label10.TextAlign = ContentAlignment.TopCenter
        ' 
        ' checkout
        ' 
        checkout.Anchor = AnchorStyles.Top
        checkout.FormattingEnabled = True
        checkout.Location = New Point(169, 140)
        checkout.Name = "checkout"
        checkout.Size = New Size(143, 23)
        checkout.TabIndex = 19
        ' 
        ' Label12
        ' 
        Label12.Anchor = AnchorStyles.Top
        Label12.AutoSize = True
        Label12.BackColor = Color.Transparent
        Label12.Font = New Font("Century Gothic", 9.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label12.ForeColor = Color.White
        Label12.Location = New Point(36, 121)
        Label12.Name = "Label12"
        Label12.Size = New Size(99, 16)
        Label12.TabIndex = 18
        Label12.Text = "Check in Time"
        Label12.TextAlign = ContentAlignment.TopCenter
        ' 
        ' checkin
        ' 
        checkin.Anchor = AnchorStyles.Top
        checkin.FormattingEnabled = True
        checkin.Location = New Point(36, 140)
        checkin.Name = "checkin"
        checkin.Size = New Size(121, 23)
        checkin.TabIndex = 17
        ' 
        ' Label5
        ' 
        Label5.Anchor = AnchorStyles.Top
        Label5.AutoSize = True
        Label5.BackColor = Color.Transparent
        Label5.Font = New Font("Century Gothic", 9.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label5.ForeColor = Color.White
        Label5.Location = New Point(36, 62)
        Label5.Name = "Label5"
        Label5.Size = New Size(37, 16)
        Label5.TabIndex = 14
        Label5.Text = "Date"
        Label5.TextAlign = ContentAlignment.TopCenter
        ' 
        ' Label6
        ' 
        Label6.Anchor = AnchorStyles.Top
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
        PictureBox5.Anchor = AnchorStyles.Top
        PictureBox5.Image = CType(resources.GetObject("PictureBox5.Image"), Image)
        PictureBox5.Location = New Point(17, 18)
        PictureBox5.Name = "PictureBox5"
        PictureBox5.Size = New Size(22, 28)
        PictureBox5.SizeMode = PictureBoxSizeMode.Zoom
        PictureBox5.TabIndex = 12
        PictureBox5.TabStop = False
        ' 
        ' Panel7
        ' 
        Panel7.Anchor = AnchorStyles.Top
        Panel7.BackColor = Color.FromArgb(CByte(41), CByte(99), CByte(116))
        Panel7.Controls.Add(status)
        Panel7.Controls.Add(Label19)
        Panel7.Controls.Add(PictureBox7)
        Panel7.Location = New Point(51, 388)
        Panel7.Name = "Panel7"
        Panel7.Size = New Size(347, 100)
        Panel7.TabIndex = 22
        ' 
        ' status
        ' 
        status.Anchor = AnchorStyles.Top
        status.FormattingEnabled = True
        status.Location = New Point(45, 55)
        status.Name = "status"
        status.Size = New Size(276, 23)
        status.TabIndex = 15
        ' 
        ' Label19
        ' 
        Label19.Anchor = AnchorStyles.Top
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
        PictureBox7.Anchor = AnchorStyles.Top
        PictureBox7.Image = CType(resources.GetObject("PictureBox7.Image"), Image)
        PictureBox7.Location = New Point(17, 18)
        PictureBox7.Name = "PictureBox7"
        PictureBox7.Size = New Size(22, 28)
        PictureBox7.SizeMode = PictureBoxSizeMode.Zoom
        PictureBox7.TabIndex = 12
        PictureBox7.TabStop = False
        ' 
        ' Panel2
        ' 
        Panel2.Anchor = AnchorStyles.Top
        Panel2.BackColor = Color.FromArgb(CByte(38), CByte(49), CByte(64))
        Panel2.Controls.Add(halfdaycount)
        Panel2.Controls.Add(Label9)
        Panel2.Controls.Add(PictureBox3)
        Panel2.Location = New Point(52, 494)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(346, 69)
        Panel2.TabIndex = 31
        ' 
        ' halfdaycount
        ' 
        halfdaycount.Anchor = AnchorStyles.Top
        halfdaycount.AutoSize = True
        halfdaycount.BackColor = Color.Transparent
        halfdaycount.Font = New Font("Century Gothic", 20.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        halfdaycount.ForeColor = Color.White
        halfdaycount.Location = New Point(54, 9)
        halfdaycount.Name = "halfdaycount"
        halfdaycount.Size = New Size(29, 32)
        halfdaycount.TabIndex = 13
        halfdaycount.Text = "0"
        halfdaycount.TextAlign = ContentAlignment.TopCenter
        ' 
        ' Label9
        ' 
        Label9.Anchor = AnchorStyles.Top
        Label9.AutoSize = True
        Label9.BackColor = Color.Transparent
        Label9.Font = New Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label9.ForeColor = Color.White
        Label9.Location = New Point(15, 41)
        Label9.Name = "Label9"
        Label9.Size = New Size(80, 19)
        Label9.TabIndex = 12
        Label9.Text = "Half Days"
        Label9.TextAlign = ContentAlignment.TopCenter
        ' 
        ' PictureBox3
        ' 
        PictureBox3.Anchor = AnchorStyles.Top
        PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), Image)
        PictureBox3.Location = New Point(16, 9)
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
        Panel3.Location = New Point(51, 568)
        Panel3.Name = "Panel3"
        Panel3.Size = New Size(347, 79)
        Panel3.TabIndex = 32
        ' 
        ' latedayscount
        ' 
        latedayscount.Anchor = AnchorStyles.Top
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
        Label11.Anchor = AnchorStyles.Top
        Label11.AutoSize = True
        Label11.BackColor = Color.Transparent
        Label11.Font = New Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label11.ForeColor = Color.White
        Label11.Location = New Point(17, 46)
        Label11.Name = "Label11"
        Label11.Size = New Size(82, 19)
        Label11.TabIndex = 12
        Label11.Text = "Late Days"
        Label11.TextAlign = ContentAlignment.TopCenter
        ' 
        ' PictureBox4
        ' 
        PictureBox4.Anchor = AnchorStyles.Top
        PictureBox4.Image = CType(resources.GetObject("PictureBox4.Image"), Image)
        PictureBox4.Location = New Point(17, 14)
        PictureBox4.Name = "PictureBox4"
        PictureBox4.Size = New Size(22, 28)
        PictureBox4.SizeMode = PictureBoxSizeMode.Zoom
        PictureBox4.TabIndex = 12
        PictureBox4.TabStop = False
        ' 
        ' Panel1
        ' 
        Panel1.Anchor = AnchorStyles.Top
        Panel1.BackColor = Color.FromArgb(CByte(38), CByte(49), CByte(64))
        Panel1.Controls.Add(presentcount)
        Panel1.Controls.Add(Label4)
        Panel1.Controls.Add(PictureBox1)
        Panel1.Location = New Point(52, 653)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(346, 82)
        Panel1.TabIndex = 33
        ' 
        ' presentcount
        ' 
        presentcount.Anchor = AnchorStyles.Top
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
        Label4.Anchor = AnchorStyles.Top
        Label4.AutoSize = True
        Label4.BackColor = Color.Transparent
        Label4.Font = New Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label4.ForeColor = Color.White
        Label4.Location = New Point(17, 46)
        Label4.Name = "Label4"
        Label4.Size = New Size(104, 19)
        Label4.TabIndex = 12
        Label4.Text = "Present Days"
        Label4.TextAlign = ContentAlignment.TopCenter
        ' 
        ' PictureBox1
        ' 
        PictureBox1.Anchor = AnchorStyles.Top
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
        Panel5.Location = New Point(52, 741)
        Panel5.Name = "Panel5"
        Panel5.Size = New Size(346, 77)
        Panel5.TabIndex = 34
        ' 
        ' absentcount
        ' 
        absentcount.Anchor = AnchorStyles.Top
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
        Label7.Anchor = AnchorStyles.Top
        Label7.AutoSize = True
        Label7.BackColor = Color.Transparent
        Label7.Font = New Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label7.ForeColor = Color.White
        Label7.Location = New Point(16, 46)
        Label7.Name = "Label7"
        Label7.Size = New Size(103, 19)
        Label7.TabIndex = 12
        Label7.Text = "Absent Days"
        Label7.TextAlign = ContentAlignment.TopCenter
        ' 
        ' PictureBox2
        ' 
        PictureBox2.Anchor = AnchorStyles.Top
        PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), Image)
        PictureBox2.Location = New Point(17, 14)
        PictureBox2.Name = "PictureBox2"
        PictureBox2.Size = New Size(22, 28)
        PictureBox2.SizeMode = PictureBoxSizeMode.Zoom
        PictureBox2.TabIndex = 12
        PictureBox2.TabStop = False
        ' 
        ' save
        ' 
        save.Anchor = AnchorStyles.Top
        save.BackColor = Color.FromArgb(CByte(208), CByte(39), CByte(82))
        save.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        save.ForeColor = Color.White
        save.Image = CType(resources.GetObject("save.Image"), Image)
        save.ImageAlign = ContentAlignment.MiddleLeft
        save.Location = New Point(878, 748)
        save.Name = "save"
        save.Padding = New Padding(25, 0, 35, 0)
        save.Size = New Size(265, 70)
        save.TabIndex = 8
        save.Text = "    Save Attendance"
        save.UseVisualStyleBackColor = False
        ' 
        ' AttendanceChecker
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1169, 839)
        Controls.Add(save)
        Controls.Add(Panel5)
        Controls.Add(Panel1)
        Controls.Add(Panel3)
        Controls.Add(Panel2)
        Controls.Add(Panel7)
        Controls.Add(Panel4)
        Controls.Add(viewemployeedata)
        Controls.Add(Notification)
        Controls.Add(Label3)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Controls.Add(Employedropdown)
        FormBorderStyle = FormBorderStyle.None
        Name = "AttendanceChecker"
        Text = "AttendanceChecker"
        Panel4.ResumeLayout(False)
        Panel4.PerformLayout()
        CType(PictureBox5, ComponentModel.ISupportInitialize).EndInit()
        Panel7.ResumeLayout(False)
        Panel7.PerformLayout()
        CType(PictureBox7, ComponentModel.ISupportInitialize).EndInit()
        Panel2.ResumeLayout(False)
        Panel2.PerformLayout()
        CType(PictureBox3, ComponentModel.ISupportInitialize).EndInit()
        Panel3.ResumeLayout(False)
        Panel3.PerformLayout()
        CType(PictureBox4, ComponentModel.ISupportInitialize).EndInit()
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        Panel5.ResumeLayout(False)
        Panel5.PerformLayout()
        CType(PictureBox2, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub
    Friend WithEvents Notification As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Employedropdown As ComboBox
    Friend WithEvents viewemployeedata As Panel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents monthofdate As DateTimePicker
    Friend WithEvents Label10 As Label
    Friend WithEvents checkout As ComboBox
    Friend WithEvents Label12 As Label
    Friend WithEvents checkin As ComboBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents PictureBox5 As PictureBox
    Friend WithEvents Panel7 As Panel
    Friend WithEvents status As ComboBox
    Friend WithEvents Label19 As Label
    Friend WithEvents PictureBox7 As PictureBox
    Friend WithEvents Panel2 As Panel
    Friend WithEvents halfdaycount As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents PictureBox3 As PictureBox
    Friend WithEvents Panel3 As Panel
    Friend WithEvents latedayscount As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents PictureBox4 As PictureBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents presentcount As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Panel5 As Panel
    Friend WithEvents absentcount As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents save As Button
End Class
