<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Home
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Home))
        PictureBox1 = New PictureBox()
        Label1 = New Label()
        Label2 = New Label()
        Label3 = New Label()
        employeedateadded = New Label()
        employeecount = New Label()
        PictureBox5 = New PictureBox()
        PictureBox6 = New PictureBox()
        PictureBox2 = New PictureBox()
        PictureBox3 = New PictureBox()
        Admincount = New Label()
        adminlatestdate = New Label()
        Label7 = New Label()
        PictureBox4 = New PictureBox()
        PictureBox7 = New PictureBox()
        PictureBox8 = New PictureBox()
        totalcountpayroll = New Label()
        lasttransactiondate = New Label()
        Label10 = New Label()
        PictureBox9 = New PictureBox()
        PictureBox10 = New PictureBox()
        PictureBox11 = New PictureBox()
        deletecount = New Label()
        historydate = New Label()
        Label13 = New Label()
        PictureBox12 = New PictureBox()
        Addemployee = New Button()
        Panel1 = New Panel()
        Button2 = New Button()
        Panel2 = New Panel()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox5, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox6, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox2, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox3, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox4, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox7, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox8, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox9, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox10, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox11, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox12, ComponentModel.ISupportInitialize).BeginInit()
        Panel1.SuspendLayout()
        Panel2.SuspendLayout()
        SuspendLayout()
        ' 
        ' PictureBox1
        ' 
        PictureBox1.Anchor = AnchorStyles.Top
        PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), Image)
        PictureBox1.Location = New Point(42, 233)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(220, 223)
        PictureBox1.SizeMode = PictureBoxSizeMode.Zoom
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
        Label1.Size = New Size(226, 32)
        Label1.TabIndex = 3
        Label1.Text = "Wellcome Back "
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
        Label2.TabIndex = 4
        Label2.Text = "Here's what happening with your payroll system today."
        Label2.TextAlign = ContentAlignment.TopCenter
        ' 
        ' Label3
        ' 
        Label3.Anchor = AnchorStyles.Top
        Label3.AutoSize = True
        Label3.BackColor = SystemColors.Window
        Label3.Font = New Font("Century Gothic", 14.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label3.Location = New Point(54, 376)
        Label3.Name = "Label3"
        Label3.Size = New Size(152, 23)
        Label3.TabIndex = 8
        Label3.Text = "Total Employee"
        ' 
        ' employeedateadded
        ' 
        employeedateadded.Anchor = AnchorStyles.Top
        employeedateadded.AutoSize = True
        employeedateadded.BackColor = SystemColors.Window
        employeedateadded.Font = New Font("Century Gothic", 9.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        employeedateadded.ForeColor = Color.Green
        employeedateadded.Location = New Point(101, 406)
        employeedateadded.Name = "employeedateadded"
        employeedateadded.Size = New Size(86, 16)
        employeedateadded.TabIndex = 9
        employeedateadded.Text = "Date Added"
        ' 
        ' employeecount
        ' 
        employeecount.Anchor = AnchorStyles.Top
        employeecount.AutoSize = True
        employeecount.BackColor = SystemColors.Window
        employeecount.Font = New Font("Arial", 20.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        employeecount.Location = New Point(54, 321)
        employeecount.Name = "employeecount"
        employeecount.Size = New Size(53, 32)
        employeecount.TabIndex = 10
        employeecount.Text = "0%"
        ' 
        ' PictureBox5
        ' 
        PictureBox5.Anchor = AnchorStyles.Top
        PictureBox5.BackColor = SystemColors.Window
        PictureBox5.Image = CType(resources.GetObject("PictureBox5.Image"), Image)
        PictureBox5.Location = New Point(63, 402)
        PictureBox5.Name = "PictureBox5"
        PictureBox5.Size = New Size(33, 24)
        PictureBox5.SizeMode = PictureBoxSizeMode.Zoom
        PictureBox5.TabIndex = 11
        PictureBox5.TabStop = False
        ' 
        ' PictureBox6
        ' 
        PictureBox6.Anchor = AnchorStyles.Top
        PictureBox6.BackColor = SystemColors.Window
        PictureBox6.Image = CType(resources.GetObject("PictureBox6.Image"), Image)
        PictureBox6.Location = New Point(177, 262)
        PictureBox6.Name = "PictureBox6"
        PictureBox6.Size = New Size(54, 45)
        PictureBox6.SizeMode = PictureBoxSizeMode.Zoom
        PictureBox6.TabIndex = 12
        PictureBox6.TabStop = False
        ' 
        ' PictureBox2
        ' 
        PictureBox2.Anchor = AnchorStyles.Top
        PictureBox2.BackColor = SystemColors.Window
        PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), Image)
        PictureBox2.Location = New Point(446, 262)
        PictureBox2.Name = "PictureBox2"
        PictureBox2.Size = New Size(54, 45)
        PictureBox2.SizeMode = PictureBoxSizeMode.Zoom
        PictureBox2.TabIndex = 18
        PictureBox2.TabStop = False
        ' 
        ' PictureBox3
        ' 
        PictureBox3.Anchor = AnchorStyles.Top
        PictureBox3.BackColor = SystemColors.Window
        PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), Image)
        PictureBox3.Location = New Point(332, 402)
        PictureBox3.Name = "PictureBox3"
        PictureBox3.Size = New Size(33, 24)
        PictureBox3.SizeMode = PictureBoxSizeMode.Zoom
        PictureBox3.TabIndex = 17
        PictureBox3.TabStop = False
        ' 
        ' Admincount
        ' 
        Admincount.Anchor = AnchorStyles.Top
        Admincount.AutoSize = True
        Admincount.BackColor = SystemColors.Window
        Admincount.Font = New Font("Arial", 20.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Admincount.Location = New Point(323, 321)
        Admincount.Name = "Admincount"
        Admincount.Size = New Size(53, 32)
        Admincount.TabIndex = 16
        Admincount.Text = "0%"
        ' 
        ' adminlatestdate
        ' 
        adminlatestdate.Anchor = AnchorStyles.Top
        adminlatestdate.AutoSize = True
        adminlatestdate.BackColor = SystemColors.Window
        adminlatestdate.Font = New Font("Century Gothic", 9.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        adminlatestdate.ForeColor = Color.Green
        adminlatestdate.Location = New Point(370, 406)
        adminlatestdate.Name = "adminlatestdate"
        adminlatestdate.Size = New Size(86, 16)
        adminlatestdate.TabIndex = 15
        adminlatestdate.Text = "Date Added"
        ' 
        ' Label7
        ' 
        Label7.Anchor = AnchorStyles.Top
        Label7.AutoSize = True
        Label7.BackColor = SystemColors.Window
        Label7.Font = New Font("Century Gothic", 14.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label7.Location = New Point(323, 376)
        Label7.Name = "Label7"
        Label7.Size = New Size(120, 23)
        Label7.TabIndex = 14
        Label7.Text = "Total Admin"
        ' 
        ' PictureBox4
        ' 
        PictureBox4.Anchor = AnchorStyles.Top
        PictureBox4.Image = CType(resources.GetObject("PictureBox4.Image"), Image)
        PictureBox4.Location = New Point(311, 233)
        PictureBox4.Name = "PictureBox4"
        PictureBox4.Size = New Size(220, 223)
        PictureBox4.SizeMode = PictureBoxSizeMode.Zoom
        PictureBox4.TabIndex = 13
        PictureBox4.TabStop = False
        ' 
        ' PictureBox7
        ' 
        PictureBox7.Anchor = AnchorStyles.Top
        PictureBox7.BackColor = SystemColors.Window
        PictureBox7.Image = CType(resources.GetObject("PictureBox7.Image"), Image)
        PictureBox7.Location = New Point(717, 262)
        PictureBox7.Name = "PictureBox7"
        PictureBox7.Size = New Size(54, 45)
        PictureBox7.SizeMode = PictureBoxSizeMode.Zoom
        PictureBox7.TabIndex = 24
        PictureBox7.TabStop = False
        ' 
        ' PictureBox8
        ' 
        PictureBox8.Anchor = AnchorStyles.Top
        PictureBox8.BackColor = SystemColors.Window
        PictureBox8.Image = CType(resources.GetObject("PictureBox8.Image"), Image)
        PictureBox8.Location = New Point(603, 402)
        PictureBox8.Name = "PictureBox8"
        PictureBox8.Size = New Size(33, 24)
        PictureBox8.SizeMode = PictureBoxSizeMode.Zoom
        PictureBox8.TabIndex = 23
        PictureBox8.TabStop = False
        ' 
        ' totalcountpayroll
        ' 
        totalcountpayroll.Anchor = AnchorStyles.Top
        totalcountpayroll.AutoSize = True
        totalcountpayroll.BackColor = SystemColors.Window
        totalcountpayroll.Font = New Font("Arial", 20.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        totalcountpayroll.Location = New Point(594, 321)
        totalcountpayroll.Name = "totalcountpayroll"
        totalcountpayroll.Size = New Size(53, 32)
        totalcountpayroll.TabIndex = 22
        totalcountpayroll.Text = "0%"
        ' 
        ' lasttransactiondate
        ' 
        lasttransactiondate.Anchor = AnchorStyles.Top
        lasttransactiondate.AutoSize = True
        lasttransactiondate.BackColor = SystemColors.Window
        lasttransactiondate.Font = New Font("Century Gothic", 9.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lasttransactiondate.ForeColor = Color.Green
        lasttransactiondate.Location = New Point(641, 406)
        lasttransactiondate.Name = "lasttransactiondate"
        lasttransactiondate.Size = New Size(86, 16)
        lasttransactiondate.TabIndex = 21
        lasttransactiondate.Text = "Date Added"
        ' 
        ' Label10
        ' 
        Label10.Anchor = AnchorStyles.Top
        Label10.AutoSize = True
        Label10.BackColor = SystemColors.Window
        Label10.Font = New Font("Century Gothic", 14.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label10.Location = New Point(594, 376)
        Label10.Name = "Label10"
        Label10.Size = New Size(122, 23)
        Label10.TabIndex = 20
        Label10.Text = "Total Payroll"
        ' 
        ' PictureBox9
        ' 
        PictureBox9.Anchor = AnchorStyles.Top
        PictureBox9.Image = CType(resources.GetObject("PictureBox9.Image"), Image)
        PictureBox9.Location = New Point(582, 233)
        PictureBox9.Name = "PictureBox9"
        PictureBox9.Size = New Size(220, 223)
        PictureBox9.SizeMode = PictureBoxSizeMode.Zoom
        PictureBox9.TabIndex = 19
        PictureBox9.TabStop = False
        ' 
        ' PictureBox10
        ' 
        PictureBox10.Anchor = AnchorStyles.Top
        PictureBox10.BackColor = SystemColors.Window
        PictureBox10.Image = CType(resources.GetObject("PictureBox10.Image"), Image)
        PictureBox10.Location = New Point(1003, 262)
        PictureBox10.Name = "PictureBox10"
        PictureBox10.Size = New Size(39, 45)
        PictureBox10.SizeMode = PictureBoxSizeMode.Zoom
        PictureBox10.TabIndex = 30
        PictureBox10.TabStop = False
        ' 
        ' PictureBox11
        ' 
        PictureBox11.Anchor = AnchorStyles.Top
        PictureBox11.BackColor = SystemColors.Window
        PictureBox11.Image = CType(resources.GetObject("PictureBox11.Image"), Image)
        PictureBox11.Location = New Point(874, 402)
        PictureBox11.Name = "PictureBox11"
        PictureBox11.Size = New Size(33, 24)
        PictureBox11.SizeMode = PictureBoxSizeMode.Zoom
        PictureBox11.TabIndex = 29
        PictureBox11.TabStop = False
        ' 
        ' deletecount
        ' 
        deletecount.Anchor = AnchorStyles.Top
        deletecount.AutoSize = True
        deletecount.BackColor = SystemColors.Window
        deletecount.Font = New Font("Arial", 20.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        deletecount.Location = New Point(865, 321)
        deletecount.Name = "deletecount"
        deletecount.Size = New Size(53, 32)
        deletecount.TabIndex = 28
        deletecount.Text = "0%"
        ' 
        ' historydate
        ' 
        historydate.Anchor = AnchorStyles.Top
        historydate.AutoSize = True
        historydate.BackColor = SystemColors.Window
        historydate.Font = New Font("Century Gothic", 9.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        historydate.ForeColor = Color.Green
        historydate.Location = New Point(912, 406)
        historydate.Name = "historydate"
        historydate.Size = New Size(86, 16)
        historydate.TabIndex = 27
        historydate.Text = "Date Added"
        ' 
        ' Label13
        ' 
        Label13.Anchor = AnchorStyles.Top
        Label13.AutoSize = True
        Label13.BackColor = SystemColors.Window
        Label13.Font = New Font("Century Gothic", 14.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label13.Location = New Point(865, 376)
        Label13.Name = "Label13"
        Label13.Size = New Size(120, 23)
        Label13.TabIndex = 26
        Label13.Text = "Total History"
        ' 
        ' PictureBox12
        ' 
        PictureBox12.Anchor = AnchorStyles.Top
        PictureBox12.Image = CType(resources.GetObject("PictureBox12.Image"), Image)
        PictureBox12.Location = New Point(853, 233)
        PictureBox12.Name = "PictureBox12"
        PictureBox12.Size = New Size(220, 223)
        PictureBox12.SizeMode = PictureBoxSizeMode.Zoom
        PictureBox12.TabIndex = 25
        PictureBox12.TabStop = False
        ' 
        ' Addemployee
        ' 
        Addemployee.BackColor = Color.DodgerBlue
        Addemployee.Font = New Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Addemployee.ForeColor = Color.White
        Addemployee.Image = CType(resources.GetObject("Addemployee.Image"), Image)
        Addemployee.ImageAlign = ContentAlignment.TopCenter
        Addemployee.Location = New Point(-7, -10)
        Addemployee.Name = "Addemployee"
        Addemployee.Padding = New Padding(0, 31, 0, 0)
        Addemployee.Size = New Size(359, 185)
        Addemployee.TabIndex = 31
        Addemployee.Text = vbCrLf & "Add Employee" & vbCrLf & "Register new staff members"
        Addemployee.UseVisualStyleBackColor = False
        ' 
        ' Panel1
        ' 
        Panel1.Anchor = AnchorStyles.Top
        Panel1.Controls.Add(Addemployee)
        Panel1.Location = New Point(184, 542)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(347, 164)
        Panel1.TabIndex = 32
        ' 
        ' Button2
        ' 
        Button2.BackColor = Color.DodgerBlue
        Button2.Font = New Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Button2.ForeColor = Color.White
        Button2.Image = CType(resources.GetObject("Button2.Image"), Image)
        Button2.ImageAlign = ContentAlignment.TopCenter
        Button2.Location = New Point(-10, -10)
        Button2.Name = "Button2"
        Button2.Padding = New Padding(0, 40, 0, 0)
        Button2.Size = New Size(369, 185)
        Button2.TabIndex = 32
        Button2.Text = "Button"
        Button2.UseVisualStyleBackColor = False
        ' 
        ' Panel2
        ' 
        Panel2.Anchor = AnchorStyles.Top
        Panel2.Controls.Add(Button2)
        Panel2.Location = New Point(582, 542)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(347, 164)
        Panel2.TabIndex = 33
        ' 
        ' Home
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1124, 762)
        Controls.Add(Panel2)
        Controls.Add(Panel1)
        Controls.Add(PictureBox10)
        Controls.Add(PictureBox11)
        Controls.Add(deletecount)
        Controls.Add(historydate)
        Controls.Add(Label13)
        Controls.Add(PictureBox12)
        Controls.Add(PictureBox7)
        Controls.Add(PictureBox8)
        Controls.Add(totalcountpayroll)
        Controls.Add(lasttransactiondate)
        Controls.Add(Label10)
        Controls.Add(PictureBox9)
        Controls.Add(PictureBox2)
        Controls.Add(PictureBox3)
        Controls.Add(Admincount)
        Controls.Add(adminlatestdate)
        Controls.Add(Label7)
        Controls.Add(PictureBox4)
        Controls.Add(PictureBox6)
        Controls.Add(PictureBox5)
        Controls.Add(employeecount)
        Controls.Add(employeedateadded)
        Controls.Add(Label3)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Controls.Add(PictureBox1)
        FormBorderStyle = FormBorderStyle.None
        Name = "Home"
        Text = "Home"
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox5, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox6, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox2, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox3, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox4, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox7, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox8, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox9, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox10, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox11, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox12, ComponentModel.ISupportInitialize).EndInit()
        Panel1.ResumeLayout(False)
        Panel2.ResumeLayout(False)
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents employeedateadded As Label
    Friend WithEvents employeecount As Label
    Friend WithEvents PictureBox5 As PictureBox
    Friend WithEvents PictureBox6 As PictureBox
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents PictureBox3 As PictureBox
    Friend WithEvents Admincount As Label
    Friend WithEvents adminlatestdate As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents PictureBox4 As PictureBox
    Friend WithEvents PictureBox7 As PictureBox
    Friend WithEvents PictureBox8 As PictureBox
    Friend WithEvents totalcountpayroll As Label
    Friend WithEvents lasttransactiondate As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents PictureBox9 As PictureBox
    Friend WithEvents PictureBox10 As PictureBox
    Friend WithEvents PictureBox11 As PictureBox
    Friend WithEvents deletecount As Label
    Friend WithEvents historydate As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents PictureBox12 As PictureBox
    Friend WithEvents Addemployee As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Button2 As Button
    Friend WithEvents Panel2 As Panel
End Class
