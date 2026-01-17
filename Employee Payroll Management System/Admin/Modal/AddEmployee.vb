Imports MySql.Data.MySqlClient
Imports System.Text.RegularExpressions
Imports System.Globalization

Public Class AddEmployee

    ' =========================
    ' FORM LOAD
    ' =========================
    Private Sub AddEmployee_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.KeyPreview = True

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

        ' ===== POSITION LEVEL =====
        ComboBox1.Items.Clear()
        ComboBox1.Items.AddRange(New String() {
        "Intern Level", "Entry Level", "Junior Level", "Mid Level",
        "Senior Level", "Lead Level", "Supervisor Level", "Manager Level",
        "Senior Manager Level", "Executive Level"
        })

        ' ===== SEX =====
        sex.Items.Clear()
        sex.Items.AddRange(New String() {"Male", "Female", "Other"})

        ' ===== STATUS =====
        Status.Items.Clear()
        Status.Items.Add("Active")
        Status.Items.Add("Inactive")
        Status.SelectedIndex = 0

        ' ===== NO TYPING IN DROPDOWNS =====
        ComboBox1.DropDownStyle = ComboBoxStyle.DropDownList
        sex.DropDownStyle = ComboBoxStyle.DropDownList
        Status.DropDownStyle = ComboBoxStyle.DropDownList

        ' ===== PASSWORD HIDE =====
        Passwordemployee.UseSystemPasswordChar = True
    End Sub

    ' =========================
    ' CLOSE BUTTON
    ' =========================
    Private Sub close_Click(sender As Object, e As EventArgs) Handles close.Click
        MyBase.Close()
    End Sub

    ' =========================
    ' SAVE BUTTON
    ' =========================
    Private Sub save_Click(sender As Object, e As EventArgs) Handles save.Click

        ' ===== BASIC EMPTY CHECK =====
        If fullname.Text = "" Or email.Text = "" Or position.Text = "" _
            Or salary.Text = "" Or contactnumber.Text = "" _
            Or Passwordemployee.Text = "" Or Status.Text = "" Then

            MessageBox.Show("Please fill up all required fields.",
                            "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        ' ===== PASSWORD LENGTH =====
        If Passwordemployee.Text.Length < 3 Then
            MessageBox.Show("Password must be at least 3 characters.",
                            "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        ' ===== FULLNAME VALIDATION (LETTERS ONLY) =====
        If Not Regex.IsMatch(fullname.Text, "^[A-Za-z\s]+$") Then
            MessageBox.Show("Fullname must only contain letters and spaces.",
                            "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            fullname.Focus()
            Exit Sub
        End If

        ' ===== POSITION VALIDATION (LETTERS ONLY) =====
        If Not Regex.IsMatch(position.Text, "^[A-Za-z\s]+$") Then
            MessageBox.Show("Position must only contain letters and spaces.",
                            "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            position.Focus()
            Exit Sub
        End If

        ' ===== CONTACT NUMBER VALIDATION (NUMBERS ONLY, 10-15 DIGITS) =====
        If Not Regex.IsMatch(contactnumber.Text, "^\d{10,15}$") Then
            MessageBox.Show("Contact number must contain only numbers (10-15 digits).",
                            "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            contactnumber.Focus()
            Exit Sub
        End If

        ' ===== SAVE TO DATABASE =====
        Try
            OpenConnection()

            Dim query As String =
                "INSERT INTO employees
                (fullname, email, password, birthday, position_level,
                 job_position, salary, date_hired, sex, contact_number, status)
                 VALUES
                (@fullname, @email, @password, @birthday, @position_level,
                 @job_position, @salary, @date_hired, @sex, @contact_number, @status)"

            Using cmd As New MySqlCommand(query, Conn)
                cmd.Parameters.AddWithValue("@fullname", fullname.Text)
                cmd.Parameters.AddWithValue("@email", email.Text)
                cmd.Parameters.AddWithValue("@password", Passwordemployee.Text)
                cmd.Parameters.AddWithValue("@birthday", birthday.Value.ToString("yyyy-MM-dd"))
                cmd.Parameters.AddWithValue("@position_level", ComboBox1.Text)
                cmd.Parameters.AddWithValue("@job_position", position.Text)
                ' REMOVE FORMATTING BEFORE SAVING
                cmd.Parameters.AddWithValue("@salary", Convert.ToDecimal(salary.Text.Replace(",", "")))
                cmd.Parameters.AddWithValue("@date_hired", datehired.Value.ToString("yyyy-MM-dd"))
                cmd.Parameters.AddWithValue("@sex", sex.Text)
                cmd.Parameters.AddWithValue("@contact_number", contactnumber.Text)
                cmd.Parameters.AddWithValue("@status", Status.Text)

                cmd.ExecuteNonQuery()
            End Using

            MessageBox.Show("Employee saved successfully!",
                            "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

            ClearFields()

        Catch ex As Exception
            MessageBox.Show("Error saving data: " & ex.Message)
        Finally
            CloseConnection()
        End Try
    End Sub

    ' =========================
    ' CLEAR FIELDS
    ' =========================
    Private Sub ClearFields()
        fullname.Clear()
        email.Clear()
        position.Clear()
        salary.Clear()
        contactnumber.Clear()
        Passwordemployee.Clear()

        ComboBox1.SelectedIndex = -1
        sex.SelectedIndex = -1
        Status.SelectedIndex = 0
        birthday.Value = Date.Now
        datehired.Value = Date.Now
    End Sub

    ' =========================
    ' SHOW / HIDE PASSWORD
    ' =========================
    Private Sub showpassword_CheckedChanged(sender As Object, e As EventArgs) Handles showpassword.CheckedChanged
        Passwordemployee.UseSystemPasswordChar = Not showpassword.Checked
    End Sub

    ' =========================
    ' ENTER KEY BEHAVIOR
    ' =========================
    Private Sub Control_EnterAsTab(sender As Object, e As KeyEventArgs) _
    Handles fullname.KeyDown, email.KeyDown, position.KeyDown,
            salary.KeyDown, contactnumber.KeyDown, Passwordemployee.KeyDown

        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            Me.SelectNextControl(DirectCast(sender, Control), True, True, True, True)
        End If
    End Sub

    ' =========================
    ' DROPDOWN ENTER KEY BEHAVIOR
    ' =========================
    Private Sub ComboBox_EnterBehavior(sender As Object, e As KeyEventArgs) _
    Handles ComboBox1.KeyDown, sex.KeyDown, Status.KeyDown, birthday.KeyDown, datehired.KeyDown

        Dim cb As Control = DirectCast(sender, Control)
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True

            If TypeOf cb Is ComboBox Then
                Dim combo As ComboBox = CType(cb, ComboBox)
                If Not combo.DroppedDown Then
                    combo.DroppedDown = True
                Else
                    Me.SelectNextControl(cb, True, True, True, True)
                End If
            Else
                Me.SelectNextControl(cb, True, True, True, True)
            End If
        End If
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
        ' Allow digits and control keys only
        If Not Char.IsDigit(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub salary_TextChanged(sender As Object, e As EventArgs) Handles salary.TextChanged
        If String.IsNullOrEmpty(salary.Text) Then Exit Sub

        Dim selStart As Integer = salary.SelectionStart
        Dim selLength As Integer = salary.SelectionLength

        ' Remove commas and format
        Dim value As String = salary.Text.Replace(",", "")
        Dim number As Decimal
        If Decimal.TryParse(value, number) Then
            salary.Text = String.Format(CultureInfo.InvariantCulture, "{0:N0}", number)
            salary.SelectionStart = Math.Min(selStart + 1, salary.Text.Length)
        End If
    End Sub

End Class
