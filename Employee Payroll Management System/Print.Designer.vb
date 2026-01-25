<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Print
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
        Panel2 = New Panel()
        Label1 = New Label()
        Panel1 = New Panel()
        btn_Save = New Button()
        btn_Print = New Button()
        PrintPreviewControl1 = New PrintPreviewControl()
        prntDoc_ANNEX_A = New Printing.PrintDocument()
        Preview = New Button()
        Panel2.SuspendLayout()
        Panel1.SuspendLayout()
        SuspendLayout()
        ' 
        ' Panel2
        ' 
        Panel2.BackColor = Color.FromArgb(CByte(38), CByte(49), CByte(64))
        Panel2.Controls.Add(Label1)
        Panel2.Dock = DockStyle.Top
        Panel2.Location = New Point(0, 0)
        Panel2.Margin = New Padding(2)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(988, 37)
        Panel2.TabIndex = 4
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Microsoft Sans Serif", 10.8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.ForeColor = Color.White
        Label1.Location = New Point(419, 9)
        Label1.Margin = New Padding(2, 0, 2, 0)
        Label1.Name = "Label1"
        Label1.Size = New Size(74, 18)
        Label1.TabIndex = 0
        Label1.Text = "PAYSLIP"
        ' 
        ' Panel1
        ' 
        Panel1.Controls.Add(Preview)
        Panel1.Controls.Add(btn_Save)
        Panel1.Controls.Add(btn_Print)
        Panel1.Dock = DockStyle.Bottom
        Panel1.Location = New Point(0, 552)
        Panel1.Margin = New Padding(2)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(988, 43)
        Panel1.TabIndex = 3
        ' 
        ' btn_Save
        ' 
        btn_Save.BackColor = Color.FromArgb(CByte(38), CByte(49), CByte(64))
        btn_Save.Dock = DockStyle.Right
        btn_Save.FlatStyle = FlatStyle.Flat
        btn_Save.ForeColor = Color.White
        btn_Save.Location = New Point(675, 0)
        btn_Save.Margin = New Padding(2)
        btn_Save.Name = "btn_Save"
        btn_Save.Size = New Size(158, 43)
        btn_Save.TabIndex = 1
        btn_Save.Text = "Save"
        btn_Save.UseVisualStyleBackColor = False
        ' 
        ' btn_Print
        ' 
        btn_Print.BackColor = Color.FromArgb(CByte(38), CByte(49), CByte(64))
        btn_Print.Dock = DockStyle.Right
        btn_Print.FlatStyle = FlatStyle.Flat
        btn_Print.ForeColor = Color.White
        btn_Print.Location = New Point(833, 0)
        btn_Print.Margin = New Padding(2)
        btn_Print.Name = "btn_Print"
        btn_Print.Size = New Size(155, 43)
        btn_Print.TabIndex = 0
        btn_Print.Text = "Print"
        btn_Print.UseVisualStyleBackColor = False
        ' 
        ' PrintPreviewControl1
        ' 
        PrintPreviewControl1.AutoZoom = False
        PrintPreviewControl1.Dock = DockStyle.Fill
        PrintPreviewControl1.Document = prntDoc_ANNEX_A
        PrintPreviewControl1.Location = New Point(0, 0)
        PrintPreviewControl1.Margin = New Padding(2)
        PrintPreviewControl1.Name = "PrintPreviewControl1"
        PrintPreviewControl1.Size = New Size(988, 595)
        PrintPreviewControl1.TabIndex = 5
        PrintPreviewControl1.Zoom = 1.09R
        ' 
        ' Preview
        ' 
        Preview.BackColor = Color.FromArgb(CByte(38), CByte(49), CByte(64))
        Preview.Dock = DockStyle.Left
        Preview.FlatStyle = FlatStyle.Flat
        Preview.ForeColor = Color.White
        Preview.Location = New Point(0, 0)
        Preview.Margin = New Padding(2)
        Preview.Name = "Preview"
        Preview.Size = New Size(158, 43)
        Preview.TabIndex = 2
        Preview.Text = "Preview"
        Preview.UseVisualStyleBackColor = False
        ' 
        ' Print
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = SystemColors.Control
        ClientSize = New Size(988, 595)
        Controls.Add(Panel2)
        Controls.Add(Panel1)
        Controls.Add(PrintPreviewControl1)
        Margin = New Padding(4, 3, 4, 3)
        Name = "Print"
        Text = "View_Form"
        Panel2.ResumeLayout(False)
        Panel2.PerformLayout()
        Panel1.ResumeLayout(False)
        ResumeLayout(False)

    End Sub

    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents btn_Print As Button
    Friend WithEvents PrintPreviewControl1 As PrintPreviewControl
    Friend WithEvents prntDoc_ANNEX_A As Printing.PrintDocument
    Friend WithEvents btn_Save As Button
    Friend WithEvents Preview As Button
End Class
