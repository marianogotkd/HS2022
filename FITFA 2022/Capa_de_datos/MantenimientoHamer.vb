Imports System.Data.OleDb
Imports System.Data.DataRow
Public Class MantenimientoHamer
    Inherits Capa_de_datos.Conexion

    Public Function Mantenimiento_ObtenerInscriptos_AmbosSexosLucha(ByVal evento_id As Integer) As DataSet
        Try
            dbconn.Open()
        Catch ex As Exception
        End Try

        Dim comando As New OleDbCommand("Mantenimiento_ObtenerInscriptos_AmbosSexosLucha", dbconn)
        comando.CommandType = CommandType.StoredProcedure

        Dim ds_usu As New DataSet()
        Dim da_usu As New OleDbDataAdapter(comando)
        comando.Parameters.Add(New OleDb.OleDbParameter("@evento_id", evento_id))

        da_usu.Fill(ds_usu, "inscripciones")
        dbconn.Close()
        Return ds_usu
    End Function

    Public Function Mantenimiento_ObtenerInscriptos_todo(ByVal evento_id As Integer) As DataSet
        Try
            dbconn.Open()
        Catch ex As Exception
        End Try

        Dim comando As New OleDbCommand("Mantenimiento_ObtenerInscriptos_todo", dbconn)
        comando.CommandType = CommandType.StoredProcedure

        Dim ds_usu As New DataSet()
        Dim da_usu As New OleDbDataAdapter(comando)
        comando.Parameters.Add(New OleDb.OleDbParameter("@evento_id", evento_id))

        da_usu.Fill(ds_usu, "inscripciones")
        dbconn.Close()
        Return ds_usu
    End Function



    Public Function Mantenimiento_actualizar_inscripcion(ByVal torneo_id As Integer, ByVal categoria_id As Integer) As DataSet
        Try
            dbconn.Open()
        Catch ex As Exception
        End Try

        Dim comando As New OleDbCommand("Mantenimiento_actualizar_inscripcion", dbconn)
        comando.CommandType = CommandType.StoredProcedure

        Dim ds_usu As New DataSet()
        Dim da_usu As New OleDbDataAdapter(comando)
        comando.Parameters.Add(New OleDb.OleDbParameter("@torneo_id", torneo_id))
        comando.Parameters.Add(New OleDb.OleDbParameter("@categoria_id", categoria_id))

        da_usu.Fill(ds_usu, "inscripciones")
        dbconn.Close()
        Return ds_usu
    End Function



End Class
