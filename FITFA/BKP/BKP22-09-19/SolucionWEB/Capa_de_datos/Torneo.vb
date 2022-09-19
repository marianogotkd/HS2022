Imports System.Data.OleDb
Imports System.Data.DataRow
Public Class Torneo
    Inherits Capa_de_datos.Conexion
    Public TextoMaster = ""
    Public Function UsuarioEvento_Obtener(ByVal usuario_id As Integer) As DataSet
        Try
            dbconn.Open()
        Catch ex As Exception
        End Try

        Dim comando As New OleDbCommand("UsuarioEvento_Obtener", dbconn)
        comando.CommandType = CommandType.StoredProcedure

        Dim ds_usu As New DataSet()
        Dim da_usu As New OleDbDataAdapter(comando)
        comando.Parameters.Add(New OleDb.OleDbParameter("@usuario_id ", usuario_id))

        da_usu.Fill(ds_usu, "Usuario")
        dbconn.Close()
        Return ds_usu
    End Function

End Class
