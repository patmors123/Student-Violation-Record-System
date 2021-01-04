Imports System.Data.OleDb
Public Class Form4
    Dim con As New OleDb.OleDbConnection
    Dim dbProvider As String = "PROVIDER=Microsoft.ACE.OLEDB.12.0;"
    Dim dbSource As String = "Data Source=E:\Users\Home\Documents\PatmorsSystem.accdb"
    Dim adapter As OleDbDataAdapter
    Dim ds As DataSet
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Form1.Show()
        Me.Hide()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        con.ConnectionString = dbProvider & dbSource
        ds = New DataSet
        adapter = New OleDbDataAdapter("SELECT * FROM [User] where [Username]='" & TextBox1.Text & "' and [Password]='" & TextBox2.Text & "'", con)
        adapter.Fill(ds, "User")

        If ds.Tables("User").Rows.Count > 0 Then
            MessageBox.Show("Logged in successfully!")
            Form2.Show()
            Me.Hide()

            TextBox1.Clear()
            TextBox2.Clear()

        Else
            MessageBox.Show("Username or Password is Incorrect")
            TextBox1.Clear()
            TextBox2.Clear()

        End If


        If TextBox1.Text = "" Or TextBox2.Text = "" Then
            MsgBox("Please fill up the necessary fields")
        Else
            MsgBox("Data successfully saved to the DB")



        End If


    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            TextBox2.UseSystemPasswordChar = False
        Else
            TextBox2.UseSystemPasswordChar = True

        End If
    End Sub
End Class