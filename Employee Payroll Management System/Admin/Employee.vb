Imports System.Drawing
Imports System.Windows.Forms
Imports MySql.Data.MySqlClient
Imports System.Data

Public Class Employee

    ' MySQL connection
    Private conn As New MySqlConnection("Server=127.0.0.1;Database=payroll_system;Uid=root;Pwd=;")
    Private employeesTable As DataTable
    Private filteredTable As DataTable

    ' Dictionary to store action buttons rectangles per row
    Private buttonRects As New Dictionary(Of Integer, Tuple(Of Rectangle, Rectangle))()

    ' Row settings
    Private headerHeight As Integer = 45
    Private rowHeight As Integer = 45
    Private padding As Integer = 10

    Private Sub Employee_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Load employees from database
        LoadEmployees()

        ' Populate Role ComboBox
        PopulateRoles()

        ' Apply filters to populate the panel
        ApplyFilters()

        ' Handle Form resize to auto-adjust panel contents
        AddHandler Me.Resize, AddressOf Form_Resized
        AddHandler employelist.Resize, AddressOf Panel_Resized
    End Sub

    ' Load all employees from MySQL
    Private Sub LoadEmployees()
        Try
            Dim sql As String = "SELECT id, fullname, email, job_position, position_level FROM employees ORDER BY id"
            Dim adapter As New MySqlDataAdapter(sql, conn)
            employeesTable = New DataTable()
            adapter.Fill(employeesTable)
        Catch ex As Exception
            MessageBox.Show("Error loading employees: " & ex.Message)
        End Try
    End Sub

    ' Populate Role filter ComboBox
    Private Sub PopulateRoles()
        Role.Items.Clear()
        Role.Items.Add("All") ' Default option

        Dim roles = employeesTable.AsEnumerable().[Select](Function(r) r.Field(Of String)("position_level")).Distinct()
        For Each r In roles
            Role.Items.Add(r)
        Next

        Role.SelectedIndex = 0 ' Default to "All"
    End Sub

    ' Apply search and role filters
    Private Sub ApplyFilters()
        ' Start with full table
        filteredTable = employeesTable.Copy()

        Try
            ' Search filter
            If Not String.IsNullOrEmpty(search.Text) Then
                Dim tempTable = filteredTable.AsEnumerable().
                    Where(Function(r) r.Field(Of String)("fullname").ToLower().Contains(search.Text.ToLower())).ToList()

                If tempTable.Count = 0 Then
                    filteredTable.Clear()
                Else
                    filteredTable = tempTable.CopyToDataTable()
                End If
            End If

            ' Role filter
            If Role.SelectedItem IsNot Nothing AndAlso Role.SelectedItem.ToString() <> "All" Then
                Dim tempTable = filteredTable.AsEnumerable().
                    Where(Function(r) r.Field(Of String)("position_level") = Role.SelectedItem.ToString()).ToList()

                If tempTable.Count = 0 Then
                    filteredTable.Clear()
                Else
                    filteredTable = tempTable.CopyToDataTable()
                End If
            End If
        Catch ex As Exception
            ' Ignore errors from CopyToDataTable if empty
        End Try

        ' Clear previous button rectangles
        buttonRects.Clear()

        ' Refresh panel
        employelist.Invalidate()
    End Sub

    ' Paint the employee list panel
    Private Sub employelist_Paint(sender As Object, e As PaintEventArgs) Handles employelist.Paint
        Dim g As Graphics = e.Graphics
        Dim fontHeader As New Font("Segoe UI", 10, FontStyle.Bold)
        Dim fontRow As New Font("Segoe UI", 9)
        Dim penLine As New Pen(Color.LightGray)
        Dim brushText As Brush = Brushes.Black

        Dim panelWidth As Integer = employelist.ClientSize.Width
        Dim panelHeight As Integer = employelist.ClientSize.Height

        ' Fill background
        g.FillRectangle(Brushes.White, employelist.ClientRectangle)

        ' Column widths (adjust based on panel width)
        Dim colPosition As Integer = CInt(panelWidth * 0.18)
        Dim colFullname As Integer = CInt(panelWidth * 0.21)
        Dim colEmail As Integer = CInt(panelWidth * 0.23)
        Dim colRole As Integer = CInt(panelWidth * 0.17)
        Dim colAction As Integer = panelWidth - (colPosition + colFullname + colEmail + colRole + padding * 2)

        ' Draw headers
        g.FillRectangle(Brushes.LightGray, 0, 0, panelWidth, headerHeight)
        g.DrawRectangle(Pens.Gray, 0, 0, panelWidth, headerHeight)

        g.DrawString("Position", fontHeader, brushText, padding, 12)
        g.DrawString("Full Name", fontHeader, brushText, colPosition + padding, 12)
        g.DrawString("Email", fontHeader, brushText, colPosition + colFullname + padding, 12)
        g.DrawString("Role", fontHeader, brushText, colPosition + colFullname + colEmail + padding, 12)
        g.DrawString("Action", fontHeader, brushText, colPosition + colFullname + colEmail + colRole + padding, 12)

        ' Draw rows
        If filteredTable IsNot Nothing AndAlso filteredTable.Rows.Count > 0 Then
            For i As Integer = 0 To filteredTable.Rows.Count - 1
                Dim y As Integer = headerHeight + i * rowHeight

                ' Stop drawing if row exceeds panel height
                If y + rowHeight > panelHeight Then Exit For

                ' Alternating row background
                If i Mod 2 = 0 Then
                    g.FillRectangle(Brushes.WhiteSmoke, 0, y, panelWidth, rowHeight)
                Else
                    g.FillRectangle(Brushes.White, 0, y, panelWidth, rowHeight)
                End If

                ' Row border line
                g.DrawLine(penLine, 0, y, panelWidth, y)

                ' Draw employee data
                Dim row As DataRow = filteredTable.Rows(i)
                g.DrawString(row("job_position").ToString(), fontRow, brushText, padding, y + 14)
                g.DrawString(row("fullname").ToString(), fontRow, brushText, colPosition + padding, y + 14)
                g.DrawString(row("email").ToString(), fontRow, brushText, colPosition + colFullname + padding, y + 14)
                g.DrawString(row("position_level").ToString(), fontRow, brushText, colPosition + colFullname + colEmail + padding, y + 14)

                ' Draw Action buttons
                Dim buttonWidth As Integer = CInt(colAction * 0.45)
                Dim buttonHeight As Integer = 28
                Dim actionX As Integer = colPosition + colFullname + colEmail + colRole + padding
                Dim editRect As New Rectangle(actionX, y + 8, buttonWidth, buttonHeight)
                Dim viewRect As New Rectangle(actionX + buttonWidth + 8, y + 8, buttonWidth, buttonHeight)

                ' Edit button: RGB(38, 49, 64)
                g.FillRectangle(New SolidBrush(Color.FromArgb(38, 49, 64)), editRect)
                g.DrawRectangle(Pens.Black, editRect)
                g.DrawString("Edit", fontRow, Brushes.White, editRect.X + 15, editRect.Y + 6)


                ' Store rectangles for click events
                If Not buttonRects.ContainsKey(i) Then
                    buttonRects.Add(i, New Tuple(Of Rectangle, Rectangle)(editRect, viewRect))
                End If
            Next
        End If
    End Sub

    ' Handle mouse clicks on action buttons
    Private Sub employelist_MouseClick(sender As Object, e As MouseEventArgs) Handles employelist.MouseClick
        For Each kvp In buttonRects
            Dim rowIndex As Integer = kvp.Key
            Dim editRect As Rectangle = kvp.Value.Item1
            Dim viewRect As Rectangle = kvp.Value.Item2

            Dim row As DataRow = filteredTable.Rows(rowIndex)

            ' Edit button clicked
            If editRect.Contains(e.Location) Then
                Dim editForm As New EditEmployee(row("id"))
                editForm.ShowDialog()

                ' Refresh list after editing
                LoadEmployees()
                PopulateRoles()
                ApplyFilters()
            End If


        Next
    End Sub

    ' Search box text changed
    Private Sub search_TextChanged(sender As Object, e As EventArgs) Handles search.TextChanged
        ApplyFilters()
    End Sub

    ' Role filter changed
    Private Sub Role_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Role.SelectedIndexChanged
        ApplyFilters()
    End Sub

    ' Refresh button click
    Private Sub Refresh_Click(sender As Object, e As EventArgs) Handles Refresh.Click
        search.Text = ""
        Role.SelectedIndex = 0
        LoadEmployees()
        PopulateRoles()
        ApplyFilters()
    End Sub

    ' Form resize event to refresh panel
    Private Sub Form_Resized(sender As Object, e As EventArgs)
        employelist.Invalidate()
    End Sub

    ' Panel resize event to refresh panel
    Private Sub Panel_Resized(sender As Object, e As EventArgs)
        employelist.Invalidate()
    End Sub

End Class
