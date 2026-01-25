Imports System.Drawing
Imports System.Windows.Forms
Imports MySql.Data.MySqlClient
Imports System.Text.RegularExpressions
Imports System.Globalization

Public Class EditEmployee

    Private empId As Integer
    Private conn As New MySqlConnection(
        "Server=127.0.0.1;Database=payroll_system;Uid=root;Pwd=;"
    )

    ' =========================
    ' CONSTRUCTOR
    ' =========================
    Public Sub New(ByVal id As Integer)
        InitializeComponent()
        empId = id
    End Sub

    ' =========================
    ' FORM LOAD
    ' =========================
    Private Sub EditEmployee_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.StartPosition = FormStartPosition.CenterScreen

        ' ===== DROP DOWNS: SELECT ONLY =====
        ComboBox1.DropDownStyle = ComboBoxStyle.DropDownList ' Position Level
        sex.DropDownStyle = ComboBoxStyle.DropDownList       ' Sex
        Status.DropDownStyle = ComboBoxStyle.DropDownList    ' Status

        ' ===== TAB ORDER =====
        fullname.TabIndex = 0
        email.TabIndex = 1
        birthday.TabIndex = 2
        ComboBox1.TabIndex = 3
        position.TabIndex = 4
        salary.TabIndex = 5
        datehired.TabIndex = 6
        sex.TabIndex = 7
        contactnumber.TabIndex = 8
        Status.TabIndex = 9
        Passwordemployee.TabIndex = 10
        showpassword.TabIndex = 11
        save.TabIndex = 12
        close.TabIndex = 13

        ' ===== POSITION LEVEL DROPDOWN =====
        ComboBox1.Items.AddRange(New String() {"Regular", "Extra", "Faculties"})

        ' ===== SEX DROPDOWN =====
        sex.Items.AddRange(New String() {"Male", "Female", "Other"})

        ' ===== STATUS DROPDOWN =====
        Status.Items.Add("Active")
        Status.Items.Add("Inactive")

        ' ===== PASSWORD HIDE =====
        Passwordemployee.UseSystemPasswordChar = True

        ' ===== LOAD EMPLOYEE DATA =====
        LoadEmployeeData()
    End Sub

    ' =========================
    ' LOAD EMPLOYEE DATA
    ' =========================
    Private Sub LoadEmployeeData()
        Try
            conn.Open()

            Dim sql As String = "SELECT * FROM employees WHERE id=@id"
            Using cmd As New MySqlCommand(sql, conn)
                cmd.Parameters.AddWithValue("@id", empId)

                Using reader As MySqlDataReader = cmd.ExecuteReader()
                    If reader.Read() Then
                        fullname.Text = reader("fullname").ToString()
                        email.Text = reader("email").ToString()
                        birthday.Value = CDate(reader("birthday"))

                        ComboBox1.SelectedItem = reader("position_level").ToString()
                        position.Text = reader("job_position").ToString()
                        salary.Text = String.Format(CultureInfo.InvariantCulture, "{0:N0}", reader("salary"))
                        datehired.Value = CDate(reader("date_hired"))

                        sex.SelectedItem = reader("sex").ToString()
                        contactnumber.Text = reader("contact_number").ToString()

                        ' Password (hidden)
                        Passwordemployee.Text = reader("password").ToString()

                        ' STATUS
                        Status.SelectedItem = reader("status").ToString()
                    End If
                End Using
            End Using

        Catch ex As Exception
            MessageBox.Show("Error loading employee: " & ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub

    ' =========================
    ' SAVE / UPDATE EMPLOYEE
    ' =========================
    Private Sub save_Click(sender As Object, e As EventArgs) Handles save.Click
        ' ===== VALIDATIONS =====
        If Not Regex.IsMatch(fullname.Text, "^[A-Za-z\s]+$") Then
            MessageBox.Show("Fullname must only contain letters and spaces.")
            fullname.Focus()
            Exit Sub
        End If

        If Not Regex.IsMatch(position.Text, "^[A-Za-z\s]+$") Then
            MessageBox.Show("Position must only contain letters and spaces.")
            position.Focus()
            Exit Sub
        End If

        If Not Regex.IsMatch(contactnumber.Text, "^\d{10,15}$") Then
            MessageBox.Show("Contact number must contain only numbers (10-15 digits).")
            contactnumber.Focus()
            Exit Sub
        End If

        ' ===== SAVE =====
        Try
            conn.Open()

            Dim sql As String
            If Passwordemployee.Text.Trim() = "" Then
                sql = "
                    UPDATE employees SET
                        fullname=@fullname,
                        email=@email,
                        birthday=@birthday,
                        position_level=@level,
                        job_position=@job,
                        salary=@salary,
                        date_hired=@datehired,
                        sex=@sex,
                        contact_number=@contact,
                        status=@status
                    WHERE id=@id
                "
            Else
                sql = "
                    UPDATE employees SET
                        fullname=@fullname,
                        email=@email,
                        password=@password,
                        birthday=@birthday,
                        position_level=@level,
                        job_position=@job,
                        salary=@salary,
                        date_hired=@datehired,
                        sex=@sex,
                        contact_number=@contact,
                        status=@status
                    WHERE id=@id
                "
            End If

            Using cmd As New MySqlCommand(sql, conn)
                cmd.Parameters.AddWithValue("@fullname", fullname.Text)
                cmd.Parameters.AddWithValue("@email", email.Text)
                cmd.Parameters.AddWithValue("@birthday", birthday.Value)
                cmd.Parameters.AddWithValue("@level", ComboBox1.Text)
                cmd.Parameters.AddWithValue("@job", position.Text)
                ' Remove formatting before saving
                cmd.Parameters.AddWithValue("@salary", Convert.ToDecimal(salary.Text.Replace(",", "")))
                cmd.Parameters.AddWithValue("@datehired", datehired.Value)
                cmd.Parameters.AddWithValue("@sex", sex.Text)
                cmd.Parameters.AddWithValue("@contact", contactnumber.Text)
                cmd.Parameters.AddWithValue("@status", Status.Text)
                cmd.Parameters.AddWithValue("@id", empId)

                If Passwordemployee.Text.Trim() <> "" Then
                    cmd.Parameters.AddWithValue("@password", Passwordemployee.Text)
                End If

                cmd.ExecuteNonQuery()
            End Using

            MessageBox.Show("Employee updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            MyBase.Close()

        Catch ex As Exception
            MessageBox.Show("Error saving employee: " & ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub

    ' =========================
    ' SHOW / HIDE PASSWORD
    ' =========================
    Private Sub showpassword_CheckedChanged(sender As Object, e As EventArgs) Handles showpassword.CheckedChanged
        Passwordemployee.UseSystemPasswordChar = Not showpassword.Checked
    End Sub

    ' =========================
    ' CLOSE BUTTON
    ' =========================
    Private Sub close_Click(sender As Object, e As EventArgs) Handles close.Click
        MyBase.Close()
    End Sub

    ' =========================
    ' REAL-TIME INPUT VALIDATION
    ' =========================
    Private Sub fullname_KeyPress(sender As Object, e As KeyPressEventArgs) Handles fullname.KeyPress
        If Not Char.IsLetter(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsWhiteSpace(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub position_KeyPress(sender As Object, e As KeyPressEventArgs) Handles position.KeyPress
        If Not Char.IsLetter(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsWhiteSpace(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub contactnumber_KeyPress(sender As Object, e As KeyPressEventArgs) Handles contactnumber.KeyPress
        If Not Char.IsDigit(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    ' =========================
    ' SALARY KEY PRESS + AUTO FORMAT
    ' =========================
    Private Sub salary_KeyPress(sender As Object, e As KeyPressEventArgs) Handles salary.KeyPress
        If Not Char.IsDigit(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub salary_TextChanged(sender As Object, e As EventArgs) Handles salary.TextChanged
        If String.IsNullOrEmpty(salary.Text) Then Exit Sub

        Dim selStart As Integer = salary.SelectionStart
        Dim selLength As Integer = salary.SelectionLength

        Dim value As String = salary.Text.Replace(",", "")
        Dim number As Decimal
        If Decimal.TryParse(value, number) Then
            salary.Text = String.Format(CultureInfo.InvariantCulture, "{0:N0}", number)
            salary.SelectionStart = Math.Min(selStart + 1, salary.Text.Length)
        End If
    End Sub

End Class
