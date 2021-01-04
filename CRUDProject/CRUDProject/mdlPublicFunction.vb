Imports System.Data.OleDb
Module mdlPublicFunction
    Public isEdit As Boolean = False
    Public StudentID As Integer
    Public userID As Integer
    Public Function InsertUpdateDelete(ByVal sql As String) As Boolean
        Try
            cmd.Connection = con
            cmd.CommandText = sql
            cmd.ExecuteNonQuery()
            Return True

        Catch ex As Exception
            MsgBox(ex.ToString)
            Return False
        Finally
            cmd.Dispose()
        End Try

    End Function
End Module
