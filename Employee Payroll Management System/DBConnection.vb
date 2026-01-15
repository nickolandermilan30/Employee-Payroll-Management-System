Imports MySql.Data.MySqlClient

Module DBConnection

    Public Conn As MySqlConnection

    Public Sub OpenConnection()
        Try
            Conn = New MySqlConnection("server=127.0.0.1; userid=root; password=; database=payroll_system;")
            If Conn.State = ConnectionState.Closed Then
                Conn.Open()
            End If
        Catch ex As Exception
            MessageBox.Show("Database connection error: " & ex.Message)
        End Try
    End Sub

    Public Sub CloseConnection()
        If Conn IsNot Nothing Then
            If Conn.State = ConnectionState.Open Then
                Conn.Close()
            End If
        End If
    End Sub

End Module
