Imports MySql.Data.MySqlClient

Public Class Register

    ' =========================
    ' FORM LOAD
    ' =========================
    Private Sub Register_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ' Password mask
        Password.PasswordChar = "*"c
        confirmpassword.PasswordChar = "*"c

        ' ===== TAB ORDER (KEYBOARD TAB FLOW) =====
        Username.TabIndex = 0
        Email.TabIndex = 1
        Password.TabIndex = 2
        confirmpassword.TabIndex = 3
        Phonenumber.TabIndex = 4
        birthday.TabIndex = 5
        gender.TabIndex = 6
        age.TabIndex = 7
        Signup.TabIndex = 8
        BackSignin.TabIndex = 9

        ' ===== GENDER COMBOBOX =====
        gender.DropDownStyle = ComboBoxStyle.DropDownList
        gender.Items.Clear()
        gender.Items.Add("Male")
        gender.Items.Add("Female")

        ' ===== AGE TEXTBOX =====
        age.ReadOnly = True

        ' ===== BIRTHDAY FORMAT =====
        birthday.Format = DateTimePickerFormat.Custom
        birthday.CustomFormat = "MMMM dd yyyy"   ' 👉 June 30 2002
        birthday.MaxDate = Date.Today
    End Sub

    ' =========================
    ' PHONE NUMBER (NUMBERS ONLY)
    ' =========================
    Private Sub Phonenumber_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Phonenumber.KeyPress
        If Not Char.IsDigit(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    ' =========================
    ' AUTO COMPUTE AGE
    ' =========================
    Private Sub birthday_ValueChanged(sender As Object, e As EventArgs) Handles birthday.ValueChanged
        Dim today As Date = Date.Today
        Dim bday As Date = birthday.Value

        Dim computedAge As Integer = today.Year - bday.Year
        If bday > today.AddYears(-computedAge) Then
            computedAge -= 1
        End If

        age.Text = computedAge.ToString()
    End Sub

    ' =========================
    ' SHOW / HIDE PASSWORD
    ' =========================
    Private Sub Showpassword1_CheckedChanged(sender As Object, e As EventArgs) Handles Showpassword1.CheckedChanged
        If Showpassword1.Checked Then
            Password.PasswordChar = ControlChars.NullChar
            confirmpassword.PasswordChar = ControlChars.NullChar
        Else
            Password.PasswordChar = "*"c
            confirmpassword.PasswordChar = "*"c
        End If
    End Sub

    ' =========================
    ' BACK TO LOGIN
    ' =========================
    Private Sub BackSignin_Click(sender As Object, e As EventArgs) Handles BackSignin.Click
        LogIn.Show()
        Me.Close()
    End Sub

    ' =========================
    ' SIGN UP
    ' =========================
    Private Sub Signup_Click(sender As Object, e As EventArgs) Handles Signup.Click

        If Username.Text = "" Or Email.Text = "" Or
           Password.Text = "" Or confirmpassword.Text = "" Or
           Phonenumber.Text = "" Or
           gender.SelectedIndex = -1 Or age.Text = "" Then

            MessageBox.Show("Please fill up all fields", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        If Password.Text <> confirmpassword.Text Then
            MessageBox.Show("Password does not match", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        Try
            OpenConnection()

            Dim query As String =
                "INSERT INTO users
                (username, email, gender, phone_number, birthday, age, password, role)
                VALUES
                (@username, @email, @gender, @phone, @birthday, @age, @password, 'Admin')"

            Dim cmd As New MySqlCommand(query, Conn)

            cmd.Parameters.AddWithValue("@username", Username.Text)
            cmd.Parameters.AddWithValue("@email", Email.Text)
            cmd.Parameters.AddWithValue("@gender", gender.SelectedItem.ToString())
            cmd.Parameters.AddWithValue("@phone", Phonenumber.Text)
            cmd.Parameters.AddWithValue("@birthday", birthday.Value.Date) ' DB safe
            cmd.Parameters.AddWithValue("@age", Convert.ToInt32(age.Text))
            cmd.Parameters.AddWithValue("@password", Password.Text)

            cmd.ExecuteNonQuery()

            MessageBox.Show("Registration Successful!", "Success",
                            MessageBoxButtons.OK, MessageBoxIcon.Information)

            LogIn.Show()
            Me.Close()

        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        Finally
            CloseConnection()
        End Try

    End Sub

End Class
