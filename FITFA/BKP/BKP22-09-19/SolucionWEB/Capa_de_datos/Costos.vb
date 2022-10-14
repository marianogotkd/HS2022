Imports System.Data.OleDb
Imports System.Data.DataRow
Public Class Costos
    Inherits Capa_de_datos.Conexion
    Public Function Costos_obtener() As DataSet
        Try
            dbconn.Open()
        Catch ex As Exception
        End Try

        Dim comando As New OleDbCommand("Costos_obtener", dbconn)
        comando.CommandType = CommandType.StoredProcedure

        Dim ds_usu As New DataSet()
        Dim da_usu As New OleDbDataAdapter(comando)
        'comando.Parameters.Add(New OleDb.OleDbParameter("@usuario_id", usuario_id))

        da_usu.Fill(ds_usu, "Costos")
        dbconn.Close()
        Return ds_usu
    End Function

    Public Function Costos_modificar(ByVal Costos_id As Integer, ByVal Costos_monto As Decimal) As DataSet
        Try
            dbconn.Open()
        Catch ex As Exception
        End Try

        Dim comando As New OleDbCommand("Costos_modificar", dbconn)
        comando.CommandType = CommandType.StoredProcedure

        Dim ds_usu As New DataSet()
        Dim da_usu As New OleDbDataAdapter(comando)
        comando.Parameters.Add(New OleDb.OleDbParameter("@Costos_id", Costos_id))
        comando.Parameters.Add(New OleDb.OleDbParameter("@Costos_monto", Costos_monto))

        da_usu.Fill(ds_usu, "Costos")
        dbconn.Close()
        Return ds_usu
    End Function


End Class
