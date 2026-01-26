<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Payslip
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Payslip))
        Panel1 = New Panel()
        Label2 = New Label()
        Panel2 = New Panel()
        PrintPayslip = New Button()
        Panel3 = New Panel()
        name = New Label()
        Deduction = New Label()
        Label13 = New Label()
        Basesalary = New Label()
        Label11 = New Label()
        Presentdays = New Label()
        Label9 = New Label()
        Label7 = New Label()
        Position = New Label()
        MonthandYear = New Label()
        Label4 = New Label()
        Label1 = New Label()
        PictureBox4 = New PictureBox()
        Label3 = New Label()
        PictureBox3 = New PictureBox()
        Panel4 = New Panel()
        NetSalary = New Label()
        Label19 = New Label()
        Panel6 = New Panel()
        deduct = New Label()
        Label18 = New Label()
        Basicsalary = New Label()
        Label14 = New Label()
        Label16 = New Label()
        PictureBox5 = New PictureBox()
        Panel5 = New Panel()
        PictureBox2 = New PictureBox()
        PictureBox1 = New PictureBox()
        DeductionSlips = New Panel()
        Panel1.SuspendLayout()
        Panel2.SuspendLayout()
        Panel3.SuspendLayout()
        CType(PictureBox4, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox3, ComponentModel.ISupportInitialize).BeginInit()
        Panel4.SuspendLayout()
        CType(PictureBox5, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox2, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Panel1
        ' 
        Panel1.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        Panel1.BackColor = Color.FromArgb(CByte(38), CByte(49), CByte(64))
        Panel1.Controls.Add(Label2)
        Panel1.Location = New Point(-2, -4)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(944, 79)
        Panel1.TabIndex = 0
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.BackColor = Color.FromArgb(CByte(38), CByte(49), CByte(64))
        Label2.Font = New Font("Century Gothic", 20.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label2.ForeColor = Color.White
        Label2.Location = New Point(26, 26)
        Label2.Name = "Label2"
        Label2.Size = New Size(212, 32)
        Label2.TabIndex = 11
        Label2.Text = "Payslip Process"
        Label2.TextAlign = ContentAlignment.TopCenter
        ' 
        ' Panel2
        ' 
        Panel2.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        Panel2.BackColor = Color.FromArgb(CByte(38), CByte(49), CByte(64))
        Panel2.Controls.Add(PrintPayslip)
        Panel2.Location = New Point(-2, 650)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(944, 79)
        Panel2.TabIndex = 1
        ' 
        ' PrintPayslip
        ' 
        PrintPayslip.BackColor = Color.FromArgb(CByte(208), CByte(39), CByte(82))
        PrintPayslip.FlatStyle = FlatStyle.Flat
        PrintPayslip.ForeColor = Color.FromArgb(CByte(38), CByte(49), CByte(64))
        PrintPayslip.Image = CType(resources.GetObject("PrintPayslip.Image"), Image)
        PrintPayslip.Location = New Point(859, 12)
        PrintPayslip.Name = "PrintPayslip"
        PrintPayslip.Size = New Size(47, 46)
        PrintPayslip.TabIndex = 12
        PrintPayslip.UseVisualStyleBackColor = False
        ' 
        ' Panel3
        ' 
        Panel3.Anchor = AnchorStyles.Top
        Panel3.BackColor = Color.WhiteSmoke
        Panel3.Controls.Add(name)
        Panel3.Controls.Add(Deduction)
        Panel3.Controls.Add(Label13)
        Panel3.Controls.Add(Basesalary)
        Panel3.Controls.Add(Label11)
        Panel3.Controls.Add(Presentdays)
        Panel3.Controls.Add(Label9)
        Panel3.Controls.Add(Label7)
        Panel3.Controls.Add(Position)
        Panel3.Controls.Add(MonthandYear)
        Panel3.Controls.Add(Label4)
        Panel3.Controls.Add(Label1)
        Panel3.Controls.Add(PictureBox4)
        Panel3.Controls.Add(Label3)
        Panel3.Controls.Add(PictureBox3)
        Panel3.Controls.Add(Panel4)
        Panel3.Controls.Add(PictureBox2)
        Panel3.Controls.Add(PictureBox1)
        Panel3.Location = New Point(33, 109)
        Panel3.Name = "Panel3"
        Panel3.Size = New Size(662, 511)
        Panel3.TabIndex = 2
        ' 
        ' name
        ' 
        name.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        name.AutoSize = True
        name.BackColor = Color.White
        name.Font = New Font("Century Gothic", 9.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        name.ForeColor = Color.Gray
        name.Location = New Point(63, 123)
        name.Name = "name"
        name.Size = New Size(46, 16)
        name.TabIndex = 27
        name.Text = "Name"
        name.TextAlign = ContentAlignment.TopCenter
        ' 
        ' Deduction
        ' 
        Deduction.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        Deduction.AutoSize = True
        Deduction.BackColor = Color.White
        Deduction.Font = New Font("Century Gothic", 9.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Deduction.ForeColor = Color.DodgerBlue
        Deduction.Location = New Point(534, 215)
        Deduction.Name = "Deduction"
        Deduction.Size = New Size(41, 16)
        Deduction.TabIndex = 26
        Deduction.Text = "Fetch"
        Deduction.TextAlign = ContentAlignment.TopCenter
        ' 
        ' Label13
        ' 
        Label13.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        Label13.AutoSize = True
        Label13.BackColor = Color.White
        Label13.Font = New Font("Century Gothic", 9.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label13.ForeColor = Color.Gray
        Label13.Location = New Point(387, 215)
        Label13.Name = "Label13"
        Label13.Size = New Size(77, 16)
        Label13.TabIndex = 25
        Label13.Text = "Deduction:"
        Label13.TextAlign = ContentAlignment.TopCenter
        ' 
        ' Basesalary
        ' 
        Basesalary.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        Basesalary.AutoSize = True
        Basesalary.BackColor = Color.White
        Basesalary.Font = New Font("Century Gothic", 9.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Basesalary.ForeColor = Color.DodgerBlue
        Basesalary.Location = New Point(534, 172)
        Basesalary.Name = "Basesalary"
        Basesalary.Size = New Size(41, 16)
        Basesalary.TabIndex = 24
        Basesalary.Text = "Fetch"
        Basesalary.TextAlign = ContentAlignment.TopCenter
        ' 
        ' Label11
        ' 
        Label11.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        Label11.AutoSize = True
        Label11.BackColor = Color.White
        Label11.Font = New Font("Century Gothic", 9.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label11.ForeColor = Color.Gray
        Label11.Location = New Point(387, 172)
        Label11.Name = "Label11"
        Label11.Size = New Size(88, 16)
        Label11.TabIndex = 23
        Label11.Text = "Base Salary:"
        Label11.TextAlign = ContentAlignment.TopCenter
        ' 
        ' Presentdays
        ' 
        Presentdays.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        Presentdays.AutoSize = True
        Presentdays.BackColor = Color.White
        Presentdays.Font = New Font("Century Gothic", 9.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Presentdays.ForeColor = SystemColors.ActiveCaptionText
        Presentdays.Location = New Point(534, 132)
        Presentdays.Name = "Presentdays"
        Presentdays.Size = New Size(41, 16)
        Presentdays.TabIndex = 22
        Presentdays.Text = "Fetch"
        Presentdays.TextAlign = ContentAlignment.TopCenter
        ' 
        ' Label9
        ' 
        Label9.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        Label9.AutoSize = True
        Label9.BackColor = Color.White
        Label9.Font = New Font("Century Gothic", 9.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label9.ForeColor = Color.Gray
        Label9.Location = New Point(387, 132)
        Label9.Name = "Label9"
        Label9.Size = New Size(93, 16)
        Label9.TabIndex = 21
        Label9.Text = "Present Days:"
        Label9.TextAlign = ContentAlignment.TopCenter
        ' 
        ' Label7
        ' 
        Label7.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        Label7.AutoSize = True
        Label7.BackColor = Color.White
        Label7.Font = New Font("Century Gothic", 9.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label7.ForeColor = Color.Gray
        Label7.Location = New Point(63, 152)
        Label7.Name = "Label7"
        Label7.Size = New Size(60, 16)
        Label7.TabIndex = 20
        Label7.Text = "Position:"
        Label7.TextAlign = ContentAlignment.TopCenter
        ' 
        ' Position
        ' 
        Position.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        Position.AutoSize = True
        Position.BackColor = Color.White
        Position.Font = New Font("Century Gothic", 8.25F, FontStyle.Bold)
        Position.ForeColor = SystemColors.ActiveCaptionText
        Position.Location = New Point(152, 152)
        Position.Name = "Position"
        Position.Size = New Size(37, 15)
        Position.TabIndex = 19
        Position.Text = "Fetch"
        Position.TextAlign = ContentAlignment.TopCenter
        ' 
        ' MonthandYear
        ' 
        MonthandYear.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        MonthandYear.AutoSize = True
        MonthandYear.BackColor = Color.White
        MonthandYear.Font = New Font("Century Gothic", 8.25F, FontStyle.Bold)
        MonthandYear.ForeColor = SystemColors.ActiveCaptionText
        MonthandYear.Location = New Point(156, 184)
        MonthandYear.Name = "MonthandYear"
        MonthandYear.Size = New Size(37, 15)
        MonthandYear.TabIndex = 18
        MonthandYear.Text = "Fetch"
        MonthandYear.TextAlign = ContentAlignment.TopCenter
        ' 
        ' Label4
        ' 
        Label4.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        Label4.AutoSize = True
        Label4.BackColor = Color.White
        Label4.Font = New Font("Century Gothic", 9.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label4.ForeColor = Color.Gray
        Label4.Location = New Point(63, 183)
        Label4.Name = "Label4"
        Label4.Size = New Size(87, 16)
        Label4.TabIndex = 17
        Label4.Text = "Month/Year:"
        Label4.TextAlign = ContentAlignment.TopCenter
        ' 
        ' Label1
        ' 
        Label1.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        Label1.AutoSize = True
        Label1.BackColor = Color.White
        Label1.Font = New Font("Century Gothic", 9.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.ForeColor = SystemColors.ActiveCaptionText
        Label1.Location = New Point(416, 84)
        Label1.Name = "Label1"
        Label1.Size = New Size(83, 16)
        Label1.TabIndex = 15
        Label1.Text = "Attendance"
        Label1.TextAlign = ContentAlignment.TopCenter
        ' 
        ' PictureBox4
        ' 
        PictureBox4.BackColor = Color.White
        PictureBox4.Image = CType(resources.GetObject("PictureBox4.Image"), Image)
        PictureBox4.Location = New Point(387, 77)
        PictureBox4.Name = "PictureBox4"
        PictureBox4.Size = New Size(31, 30)
        PictureBox4.SizeMode = PictureBoxSizeMode.CenterImage
        PictureBox4.TabIndex = 16
        PictureBox4.TabStop = False
        ' 
        ' Label3
        ' 
        Label3.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        Label3.AutoSize = True
        Label3.BackColor = Color.White
        Label3.Font = New Font("Century Gothic", 9.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label3.ForeColor = SystemColors.ActiveCaptionText
        Label3.Location = New Point(92, 84)
        Label3.Name = "Label3"
        Label3.Size = New Size(97, 16)
        Label3.TabIndex = 13
        Label3.Text = "Payroll Period"
        Label3.TextAlign = ContentAlignment.TopCenter
        ' 
        ' PictureBox3
        ' 
        PictureBox3.BackColor = Color.White
        PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), Image)
        PictureBox3.Location = New Point(63, 77)
        PictureBox3.Name = "PictureBox3"
        PictureBox3.Size = New Size(31, 30)
        PictureBox3.SizeMode = PictureBoxSizeMode.CenterImage
        PictureBox3.TabIndex = 14
        PictureBox3.TabStop = False
        ' 
        ' Panel4
        ' 
        Panel4.BackColor = Color.LightBlue
        Panel4.Controls.Add(NetSalary)
        Panel4.Controls.Add(Label19)
        Panel4.Controls.Add(Panel6)
        Panel4.Controls.Add(deduct)
        Panel4.Controls.Add(Label18)
        Panel4.Controls.Add(Basicsalary)
        Panel4.Controls.Add(Label14)
        Panel4.Controls.Add(Label16)
        Panel4.Controls.Add(PictureBox5)
        Panel4.Controls.Add(Panel5)
        Panel4.Location = New Point(25, 317)
        Panel4.Name = "Panel4"
        Panel4.Size = New Size(608, 169)
        Panel4.TabIndex = 2
        ' 
        ' NetSalary
        ' 
        NetSalary.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        NetSalary.AutoSize = True
        NetSalary.BackColor = Color.LightBlue
        NetSalary.Font = New Font("Century Gothic", 9.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        NetSalary.ForeColor = Color.Blue
        NetSalary.Location = New Point(509, 134)
        NetSalary.Name = "NetSalary"
        NetSalary.Size = New Size(41, 16)
        NetSalary.TabIndex = 31
        NetSalary.Text = "Fetch"
        NetSalary.TextAlign = ContentAlignment.TopCenter
        ' 
        ' Label19
        ' 
        Label19.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        Label19.AutoSize = True
        Label19.BackColor = Color.LightBlue
        Label19.Font = New Font("Century Gothic", 9.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label19.ForeColor = Color.Blue
        Label19.Location = New Point(29, 134)
        Label19.Name = "Label19"
        Label19.Size = New Size(79, 16)
        Label19.TabIndex = 27
        Label19.Text = "Net Salary:"
        Label19.TextAlign = ContentAlignment.TopCenter
        ' 
        ' Panel6
        ' 
        Panel6.BackColor = Color.DeepSkyBlue
        Panel6.Location = New Point(29, 123)
        Panel6.Name = "Panel6"
        Panel6.Size = New Size(521, 1)
        Panel6.TabIndex = 4
        ' 
        ' deduct
        ' 
        deduct.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        deduct.AutoSize = True
        deduct.BackColor = Color.LightBlue
        deduct.Font = New Font("Century Gothic", 9.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        deduct.ForeColor = Color.Black
        deduct.Location = New Point(509, 93)
        deduct.Name = "deduct"
        deduct.Size = New Size(41, 16)
        deduct.TabIndex = 30
        deduct.Text = "Fetch"
        deduct.TextAlign = ContentAlignment.TopCenter
        ' 
        ' Label18
        ' 
        Label18.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        Label18.AutoSize = True
        Label18.BackColor = Color.LightBlue
        Label18.Font = New Font("Century Gothic", 9.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label18.ForeColor = Color.Black
        Label18.Location = New Point(29, 62)
        Label18.Name = "Label18"
        Label18.Size = New Size(92, 16)
        Label18.TabIndex = 29
        Label18.Text = "Basic Salary:"
        Label18.TextAlign = ContentAlignment.TopCenter
        ' 
        ' Basicsalary
        ' 
        Basicsalary.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        Basicsalary.AutoSize = True
        Basicsalary.BackColor = Color.LightBlue
        Basicsalary.Font = New Font("Century Gothic", 9.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Basicsalary.ForeColor = Color.Black
        Basicsalary.Location = New Point(509, 62)
        Basicsalary.Name = "Basicsalary"
        Basicsalary.Size = New Size(41, 16)
        Basicsalary.TabIndex = 28
        Basicsalary.Text = "Fetch"
        Basicsalary.TextAlign = ContentAlignment.TopCenter
        ' 
        ' Label14
        ' 
        Label14.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        Label14.AutoSize = True
        Label14.BackColor = Color.LightBlue
        Label14.Font = New Font("Century Gothic", 9.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label14.ForeColor = SystemColors.ActiveCaptionText
        Label14.Location = New Point(58, 21)
        Label14.Name = "Label14"
        Label14.Size = New Size(97, 16)
        Label14.TabIndex = 27
        Label14.Text = "Payroll Period"
        Label14.TextAlign = ContentAlignment.TopCenter
        ' 
        ' Label16
        ' 
        Label16.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        Label16.AutoSize = True
        Label16.BackColor = Color.LightBlue
        Label16.Font = New Font("Century Gothic", 9.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label16.ForeColor = Color.Black
        Label16.Location = New Point(29, 93)
        Label16.Name = "Label16"
        Label16.Size = New Size(77, 16)
        Label16.TabIndex = 27
        Label16.Text = "Deduction:"
        Label16.TextAlign = ContentAlignment.TopCenter
        ' 
        ' PictureBox5
        ' 
        PictureBox5.BackColor = Color.LightBlue
        PictureBox5.Image = CType(resources.GetObject("PictureBox5.Image"), Image)
        PictureBox5.Location = New Point(29, 14)
        PictureBox5.Name = "PictureBox5"
        PictureBox5.Size = New Size(31, 30)
        PictureBox5.SizeMode = PictureBoxSizeMode.CenterImage
        PictureBox5.TabIndex = 28
        PictureBox5.TabStop = False
        ' 
        ' Panel5
        ' 
        Panel5.BackColor = Color.DeepSkyBlue
        Panel5.Location = New Point(0, 0)
        Panel5.Name = "Panel5"
        Panel5.Size = New Size(14, 169)
        Panel5.TabIndex = 3
        ' 
        ' PictureBox2
        ' 
        PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), Image)
        PictureBox2.Location = New Point(352, 14)
        PictureBox2.Name = "PictureBox2"
        PictureBox2.Size = New Size(281, 275)
        PictureBox2.SizeMode = PictureBoxSizeMode.CenterImage
        PictureBox2.TabIndex = 1
        PictureBox2.TabStop = False
        ' 
        ' PictureBox1
        ' 
        PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), Image)
        PictureBox1.Location = New Point(25, 14)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(281, 275)
        PictureBox1.SizeMode = PictureBoxSizeMode.CenterImage
        PictureBox1.TabIndex = 0
        PictureBox1.TabStop = False
        ' 
        ' DeductionSlips
        ' 
        DeductionSlips.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        DeductionSlips.BackColor = Color.White
        DeductionSlips.ForeColor = Color.Black
        DeductionSlips.Location = New Point(709, 109)
        DeductionSlips.Name = "DeductionSlips"
        DeductionSlips.Size = New Size(208, 511)
        DeductionSlips.TabIndex = 12
        ' 
        ' Payslip
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(929, 720)
        Controls.Add(DeductionSlips)
        Controls.Add(Panel3)
        Controls.Add(Panel2)
        Controls.Add(Panel1)

        Text = "Payslip"
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        Panel2.ResumeLayout(False)
        Panel3.ResumeLayout(False)
        Panel3.PerformLayout()
        CType(PictureBox4, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox3, ComponentModel.ISupportInitialize).EndInit()
        Panel4.ResumeLayout(False)
        Panel4.PerformLayout()
        CType(PictureBox5, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox2, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Panel5 As Panel
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label2 As Label
    Friend WithEvents PictureBox3 As PictureBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Position As Label
    Friend WithEvents MonthandYear As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents PictureBox4 As PictureBox
    Friend WithEvents Deduction As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents Basesalary As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Presentdays As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents PictureBox5 As PictureBox
    Friend WithEvents deduct As Label
    Friend WithEvents Label18 As Label
    Friend WithEvents Basicsalary As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents Panel6 As Panel
    Friend WithEvents Label19 As Label
    Friend WithEvents PrintPayslip As Button
    Friend WithEvents NetSalary As Label
    Friend WithEvents name As Label
    Friend WithEvents DeductionSlips As Panel
End Class
