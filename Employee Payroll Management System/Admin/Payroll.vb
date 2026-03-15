Imports System.Drawing
Imports System.Windows.Forms
Imports MySql.Data.MySqlClient
Imports System.Data
Imports System.Threading.Tasks
Imports System.Globalization

Public Class Payroll

    Private conn As New MySqlConnection("Server=127.0.0.1;Database=payroll_system;Uid=root;Pwd=;")
    Private employeesTable As DataTable
    Private UnitSelectors As New List(Of CheckBox)
    Private SelectedSubjectsList As New List(Of String)
    Private CurrentSemester As String = "" ' Dito mai-store ang semester na lumalabas sa panel

    ' =========================
    ' FORM LOAD
    ' =========================
    Private Sub Payroll_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.KeyPreview = True
        Me.BackColor = Color.FromArgb(240, 242, 245)

        SetupUIStyle()
        LoadEmployees()

        ' Year Setup
        Year.Items.Clear()
        Dim currentYear As Integer = DateTime.Now.Year
        For y As Integer = currentYear - 5 To currentYear + 1
            Year.Items.Add(y.ToString())
        Next
        Year.SelectedItem = currentYear.ToString()

        Salary.ReadOnly = True
        Salary.BackColor = Color.White
        Salary.Text = "0.00"
        Units.AutoScroll = True
    End Sub

    Private Sub SetupUIStyle()
        employee.DropDownStyle = ComboBoxStyle.DropDownList
        Month.Format = DateTimePickerFormat.Custom
        Month.CustomFormat = "MMMM"
        Month.ShowUpDown = True
    End Sub

    Private Sub LoadEmployees()
        Try
            Dim sql As String = "SELECT * FROM employees WHERE status='Active' ORDER BY fullname"
            Dim adapter As New MySqlDataAdapter(sql, conn)
            employeesTable = New DataTable()
            adapter.Fill(employeesTable)

            employee.Items.Clear()
            For Each row As DataRow In employeesTable.Rows
                employee.Items.Add(row("fullname").ToString())
            Next
        Catch ex As Exception
            ShowToast("⚠ Error loading database", Color.Red)
        End Try
    End Sub

    Private Sub employee_SelectedIndexChanged(sender As Object, e As EventArgs) Handles employee.SelectedIndexChanged
        If employee.SelectedIndex = -1 Then Exit Sub
        Dim empName As String = employee.SelectedItem.ToString()
        UpdateAttendanceCounts(empName)
        Dim row = employeesTable.Select("fullname='" & empName.Replace("'", "''") & "'").FirstOrDefault()
        If row IsNot Nothing Then GenerateSubjectTable(row)
    End Sub

    Private Sub GenerateSubjectTable(row As DataRow)
        Units.Controls.Clear()
        UnitSelectors.Clear()
        Units.Padding = New Padding(10)

        Dim subjects As String() = row("subject_names").ToString().Split({", "}, StringSplitOptions.None)
        Dim salariesRaw As String() = row("unit_salaries_breakdown").ToString().Split({" ; "}, StringSplitOptions.None)

        ' KUKUNIN ANG SEMESTER MULA SA DATABASE PARA LUMABAS SA PANEL
        CurrentSemester = row("semester").ToString()

        Dim lblTitle As New Label With {.Text = "COURSE LOAD BREAKDOWN - " & CurrentSemester.ToUpper(), .Font = New Font("Segoe UI", 10, FontStyle.Bold), .ForeColor = Color.FromArgb(52, 73, 94), .Dock = DockStyle.Top, .Height = 30}
        Units.Controls.Add(lblTitle)

        Dim yPos As Integer = 40
        For i As Integer = 0 To subjects.Length - 1
            Dim card As New Panel With {.Width = Units.Width - 45, .Height = 90, .Location = New Point(10, yPos), .BackColor = Color.White, .Padding = New Padding(5)}
            AddHandler card.Paint, Sub(s, e) ControlPaint.DrawBorder(e.Graphics, card.ClientRectangle, Color.LightGray, ButtonBorderStyle.Solid)

            Dim lblSub As New Label With {.Text = subjects(i).ToUpper(), .Font = New Font("Segoe UI", 9, FontStyle.Bold), .ForeColor = Color.FromArgb(41, 128, 185), .Location = New Point(15, 12), .AutoSize = True}
            card.Controls.Add(lblSub)

            If i < salariesRaw.Length Then
                Dim cleanSal As String = salariesRaw(i).Trim("["c, "]"c)
                Dim individualUnits As String() = cleanSal.Split("|"c)
                Dim xPos As Integer = 15
                For u As Integer = 0 To individualUnits.Length - 1
                    Dim unitVal As Decimal = 0
                    Decimal.TryParse(individualUnits(u), unitVal)
                    Dim chkUnit As New CheckBox With {.Appearance = Appearance.Button, .Text = "UNIT " & (u + 1) & vbCrLf & "₱" & unitVal.ToString("N0"), .Tag = New With {.Value = unitVal, .Subject = subjects(i)}, .Size = New Size(85, 45), .Location = New Point(xPos, 35), .TextAlign = ContentAlignment.MiddleCenter, .Font = New Font("Segoe UI", 7, FontStyle.Bold), .FlatStyle = FlatStyle.Flat, .Checked = True}
                    AddHandler chkUnit.CheckedChanged, AddressOf CalculateTotalFromToggles
                    card.Controls.Add(chkUnit)
                    UnitSelectors.Add(chkUnit)
                    xPos += 90
                Next
            End If
            Units.Controls.Add(card)
            yPos += 100
        Next
        CalculateTotalFromToggles(Nothing, Nothing)
    End Sub

    Private Sub CalculateTotalFromToggles(sender As Object, e As EventArgs)
        Dim total As Decimal = 0
        SelectedSubjectsList.Clear()
        For Each chk In UnitSelectors
            Dim data = chk.Tag
            If chk.Checked Then
                total += data.Value
                chk.BackColor = Color.FromArgb(46, 204, 113)
                chk.ForeColor = Color.White
                If Not SelectedSubjectsList.Contains(data.Subject) Then SelectedSubjectsList.Add(data.Subject)
            Else
                chk.BackColor = Color.FromArgb(236, 240, 241)
                chk.ForeColor = Color.Silver
            End If
        Next
        Salary.Text = total.ToString("N2")
    End Sub

    Private Sub UpdateAttendanceCounts(employeeName As String)
        Try
            Dim sql As String = "SELECT SUM(CASE WHEN status='Present' THEN 1 ELSE 0 END) AS count_present, SUM(CASE WHEN status='Absent' THEN 1 ELSE 0 END) AS count_absent, SUM(CASE WHEN status='Late' THEN 1 ELSE 0 END) AS count_late, SUM(CASE WHEN status='Half Day' THEN 1 ELSE 0 END) AS count_halfday FROM attendance WHERE fullname=@name AND MONTH(attendance_date)=@m AND YEAR(attendance_date)=@y"
            Using cmd As New MySqlCommand(sql, conn)
                cmd.Parameters.AddWithValue("@name", employeeName)
                cmd.Parameters.AddWithValue("@m", Month.Value.Month)
                cmd.Parameters.AddWithValue("@y", Year.SelectedItem.ToString())
                conn.Open()
                Using reader = cmd.ExecuteReader()
                    If reader.Read() Then
                        Present.Text = If(reader("count_present") Is DBNull.Value, "0", reader("count_present").ToString())
                        Absent.Text = If(reader("count_absent") Is DBNull.Value, "0", reader("count_absent").ToString())
                        late.Text = If(reader("count_late") Is DBNull.Value, "0", reader("count_late").ToString())
                        Halfday.Text = If(reader("count_halfday") Is DBNull.Value, "0", reader("count_halfday").ToString())
                    End If
                End Using
                conn.Close()
            End Using
        Catch ex As Exception
            If conn.State = ConnectionState.Open Then conn.Close()
        End Try
    End Sub

    Private Sub deductionbtn_Click(sender As Object, e As EventArgs) Handles deductionbtn.Click
        Using d As New Deduction()
            If d.ShowDialog() = DialogResult.OK Then
                Deduction.Text = d.TotalDeduction.ToString("N2")
                Listofdeduction.Items.Clear()
                For Each item In d.DeductionDetails
                    Listofdeduction.Items.Add(item)
                Next
            End If
        End Using
    End Sub

    ' ==========================================
    ' PAY BUTTON: SAVE TO DB AND SHOW PAYSLIP
    ' ==========================================
    Private Sub Pay_Click(sender As Object, e As EventArgs) Handles Pay.Click
        If employee.SelectedIndex = -1 Then
            ShowToast("⚠ Select employee first", Color.Orange)
            Exit Sub
        End If

        Try
            ' 1. Kunin ang basic data
            Dim empName As String = employee.SelectedItem.ToString()
            Dim periodMonth As String = Month.Value.ToString("MMMM")
            Dim periodYear As String = Year.SelectedItem.ToString()
            Dim grossSal As Decimal = Decimal.Parse(Salary.Text)
            Dim totalDeduc As Decimal = If(String.IsNullOrEmpty(Deduction.Text), 0, Decimal.Parse(Deduction.Text))

            ' Ito yung requested mo na Position as N/A
            Dim empPos As String = "N/A"

            ' 2. I-prepare ang Notes (Dito natin ilalagay ang Semester at Unit Breakdowns)
            Dim unitDetails As New List(Of String)
            For Each chk In UnitSelectors
                If chk.Checked Then
                    Dim data = chk.Tag
                    unitDetails.Add(data.Subject & "(" & chk.Text.Split({vbCrLf}, StringSplitOptions.None)(0) & ")")
                End If
            Next
            Dim notesContent As String = "Sem: " & CurrentSemester & " | Units: " & String.Join(", ", unitDetails)

            ' 3. INSERT QUERY SA DATABASE (payroll table)
            Dim sqlSave As String = "INSERT INTO payroll (employee_name, month, year, salary, deduction, notes, created_at) " &
                                    "VALUES (@name, @month, @year, @sal, @deduc, @notes, NOW())"

            Using cmd As New MySqlCommand(sqlSave, conn)
                cmd.Parameters.AddWithValue("@name", empName)
                cmd.Parameters.AddWithValue("@month", periodMonth)
                cmd.Parameters.AddWithValue("@year", periodYear)
                cmd.Parameters.AddWithValue("@sal", grossSal)
                cmd.Parameters.AddWithValue("@deduc", totalDeduc)
                cmd.Parameters.AddWithValue("@notes", notesContent)

                conn.Open()
                cmd.ExecuteNonQuery()
                conn.Close()
            End Using

            ' 4. Pagkatapos ma-save, ipakita ang Payslip Form
            Dim deductionList As New List(Of String)
            For Each item In Listofdeduction.Items
                deductionList.Add(item.ToString())
            Next

            Dim subjectsBreakdown As New List(Of String)
            For Each chk In UnitSelectors
                If chk.Checked Then
                    Dim data = chk.Tag
                    subjectsBreakdown.Add(data.Subject & " - ₱" & DirectCast(data.Value, Decimal).ToString("N2"))
                End If
            Next

            Dim presDays As Integer = If(String.IsNullOrEmpty(Present.Text), 0, Integer.Parse(Present.Text))
            Dim netSalary As Decimal = grossSal - totalDeduc

            Dim frmPayslip As New Payslip(empName, empPos, periodMonth & " " & periodYear, presDays, grossSal, totalDeduc, netSalary, deductionList, subjectsBreakdown)
            frmPayslip.Show()

            ShowToast("✅ Saved to Database!", Color.Green)

        Catch ex As Exception
            If conn.State = ConnectionState.Open Then conn.Close()
            MessageBox.Show("Error Saving: " & ex.Message)
        End Try
    End Sub

    Private Async Sub ShowToast(msg As String, bg As Color)
        Dim p As New Panel With {.Size = New Size(300, 50), .BackColor = bg, .Location = New Point(Me.Width - 320, 20)}
        Dim l As New Label With {.Text = msg, .Dock = DockStyle.Fill, .ForeColor = Color.White, .Font = New Font("Segoe UI", 9, FontStyle.Bold), .TextAlign = ContentAlignment.MiddleCenter}
        p.Controls.Add(l)
        Me.Controls.Add(p)
        p.BringToFront()
        Await Task.Delay(2000)
        Me.Controls.Remove(p)
    End Sub
End Class