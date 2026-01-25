<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Notification
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
        ListNotif = New Panel()
        Label3 = New Label()
        search = New TextBox()
        SuspendLayout()
        ' 
        ' ListNotif
        ' 
        ListNotif.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        ListNotif.BackColor = SystemColors.AppWorkspace
        ListNotif.Location = New Point(12, 74)
        ListNotif.Name = "ListNotif"
        ListNotif.Size = New Size(955, 508)
        ListNotif.TabIndex = 0
        ' 
        ' Label3
        ' 
        Label3.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        Label3.AutoSize = True
        Label3.BackColor = SystemColors.Control
        Label3.Font = New Font("Century Gothic", 14.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label3.ForeColor = SystemColors.ActiveCaptionText
        Label3.Location = New Point(12, 32)
        Label3.Name = "Label3"
        Label3.Size = New Size(74, 23)
        Label3.TabIndex = 14
        Label3.Text = "Search"
        Label3.TextAlign = ContentAlignment.TopCenter
        ' 
        ' search
        ' 
        search.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        search.BackColor = SystemColors.Window
        search.BorderStyle = BorderStyle.FixedSingle
        search.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        search.ForeColor = SystemColors.InfoText
        search.Location = New Point(92, 30)
        search.Margin = New Padding(3, 4, 3, 3)
        search.Multiline = True
        search.Name = "search"
        search.Size = New Size(875, 26)
        search.TabIndex = 13
        search.Tag = ""
        ' 
        ' Notification
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(979, 594)
        Controls.Add(Label3)
        Controls.Add(ListNotif)
        Controls.Add(search)
        FormBorderStyle = FormBorderStyle.FixedToolWindow
        Name = "Notification"
        Text = "Notification"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents ListNotif As Panel
    Friend WithEvents Label3 As Label
    Friend WithEvents search As TextBox
End Class
