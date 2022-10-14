Imports System.Data.OleDb
Imports System.Data.DataRow
Public Class Graduacion
    Inherits Capa_de_datos.Conexion


    Public Function Graduacion_obtener_todo() As DataSet
        Try
            dbconn.Open()
        Catch ex As Exception
        End Try

        Dim comando As New OleDbCommand("Graduacion_obtener_todo", dbconn)
        comando.CommandType = CommandType.StoredProcedure

        Dim ds_usu As New DataSet()
        Dim da_usu As New OleDbDataAdapter(comando)
        da_usu.Fill(ds_usu, " Graduacion")
        dbconn.Close()
        Return ds_usu
    End Function
End Class
