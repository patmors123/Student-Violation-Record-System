Imports System.Data.OleDb
Public Class Form3
    Dim con As New OleDb.OleDbConnection
    Dim dbProvider As String = "PROVIDER=Microsoft.ACE.OLEDB.12.0;"
    Dim dbSource As String = "Data Source=E:\Users\Home\Documents\PatmorsSystem.accdb"
    Dim adapter As OleDbDataAdapter
    Dim ds As DataSet
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Form4.Show()
        Me.Hide()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Form1.Show()
        Me.Hide()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        con.ConnectionString = dbProvider & dbSource
        ds = New DataSet


        If TextBox2.Text <> TextBox3.Text Then
            MsgBox("Password do not match!")
        ElseIf TextBox1.Text = "" And TextBox2.Text = "" And TextBox3.Text = "" Then
            MsgBox("Please fill up the necessary fields")
        Else
            adapter = New OleDbDataAdapter("INSERT INTO [User] ([Username],[Password]) VALUES " & "('" & TextBox1.Text & "','" & TextBox2.Text & "')", con)
            adapter.Fill(ds, "User")
            TextBox1.Clear()
            TextBox2.Clear()
            TextBox3.Clear()
            MessageBox.Show("User Registered!")
            Form4.Show()
            Me.Hide()


        End If
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            TextBox2.UseSystemPasswordChar = False
            TextBox3.UseSystemPasswordChar = False
        Else
            TextBox3.UseSystemPasswordChar = True
            TextBox2.UseSystemPasswordChar = True
        End If
    End Sub
End Class