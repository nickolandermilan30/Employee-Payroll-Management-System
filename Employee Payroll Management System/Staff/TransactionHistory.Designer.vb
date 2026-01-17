<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TransactionHistory
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
        Historyview = New Panel()
        Label3 = New Label()
        search = New TextBox()
        Panel6 = New Panel()
        today = New Button()
        Panel1 = New Panel()
        refresh = New Button()
        username = New Label()
        Panel6.SuspendLayout()
        Panel1.SuspendLayout()
        SuspendLayout()
        ' 
        ' Historyview
        ' 
        Historyview.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        Historyview.Location = New Point(47, 124)
        Historyview.Name = "Historyview"
        Historyview.Size = New Size(984, 472)
        Historyview.TabIndex = 15
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.BackColor = SystemColors.Control
        Label3.Font = New Font("Century Gothic", 14.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label3.ForeColor = SystemColors.ActiveCaptionText
        Label3.Location = New Point(47, 80)
        Label3.Name = "Label3"
        Label3.Size = New Size(74, 23)
        Label3.TabIndex = 14
        Label3.Text = "Search"
        Label3.TextAlign = ContentAlignment.TopCenter
        ' 
        ' search
        ' 
        search.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        search.BackColor = SystemColors.Window
        search.BorderStyle = BorderStyle.FixedSingle
        search.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        search.ForeColor = SystemColors.InfoText
        search.Location = New Point(127, 78)
        search.Margin = New Padding(3, 4, 3, 3)
        search.Multiline = True
        search.Name = "search"
        search.Size = New Size(621, 26)
        search.TabIndex = 13
        search.Tag = ""
        ' 
        ' Panel6
        ' 
        Panel6.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        Panel6.Controls.Add(today)
        Panel6.Location = New Point(765, 60)
        Panel6.Name = "Panel6"
        Panel6.Size = New Size(130, 44)
        Panel6.TabIndex = 16
        ' 
        ' today
        ' 
        today.BackColor = Color.FromArgb(CByte(38), CByte(49), CByte(64))
        today.Font = New Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        today.ForeColor = Color.White
        today.ImageAlign = ContentAlignment.MiddleLeft
        today.Location = New Point(-15, -8)
        today.Name = "today"
        today.Size = New Size(161, 56)
        today.TabIndex = 5
        today.Text = "Today"
        today.UseVisualStyleBackColor = False
        ' 
        ' Panel1
        ' 
        Panel1.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        Panel1.Controls.Add(refresh)
        Panel1.Location = New Point(901, 60)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(130, 44)
        Panel1.TabIndex = 17
        ' 
        ' refresh
        ' 
        refresh.BackColor = Color.FromArgb(CByte(250), CByte(129), CByte(18))
        refresh.Font = New Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        refresh.ForeColor = Color.White
        refresh.ImageAlign = ContentAlignment.MiddleLeft
        refresh.Location = New Point(-15, -8)
        refresh.Name = "refresh"
        refresh.Size = New Size(161, 56)
        refresh.TabIndex = 5
        refresh.Text = "Refresh"
        refresh.UseVisualStyleBackColor = False
        ' 
        ' username
        ' 
        username.AutoSize = True
        username.ForeColor = SystemColors.Control
        username.Location = New Point(127, 37)
        username.Name = "username"
        username.Size = New Size(41, 15)
        username.TabIndex = 18
        username.Text = "Label1"
        ' 
        ' TransactionHistory
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1076, 645)
        Controls.Add(username)
        Controls.Add(Panel1)
        Controls.Add(Panel6)
        Controls.Add(Label3)
        Controls.Add(Historyview)
        Controls.Add(search)
        FormBorderStyle = FormBorderStyle.None
        Name = "TransactionHistory"
        Text = "TransactionHistory"
        Panel6.ResumeLayout(False)
        Panel1.ResumeLayout(False)
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Historyview As Panel
    Friend WithEvents Label3 As Label
    Friend WithEvents search As TextBox
    Friend WithEvents Panel6 As Panel
    Friend WithEvents today As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents refresh As Button
    Friend WithEvents username As Label
End Class
