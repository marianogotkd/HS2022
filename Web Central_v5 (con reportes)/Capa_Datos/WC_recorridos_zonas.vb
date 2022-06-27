Imports System.Data.OleDb
Imports System.Data.DataRow
Public Class WC_recorridos_zonas
    Inherits Capa_Datos.Conexion

    Public Function recorridos_zonas_consultar_dia(ByVal Dia_id As Integer) As DataSet
        'trae todos los recorridos/zonas de 1 dia puntual.
        Try
            dbconn.Open()
        Catch ex As Exception
        End Try
        Dim comando As New OleDbCommand("recorridos_zonas_consultar_dia", dbconn)
        comando.CommandType = CommandType.StoredProcedure
        comando.Parameters.Add(New OleDb.OleDbParameter("@Dia_id", Dia_id))
        'comando.Parameters.Add(New OleDb.OleDbParameter("@Codigo", Codigo))

        Dim ds As New DataSet()
        Dim DA As New OleDbDataAdapter(comando)

        DA.Fill(ds, "Recorridos")
        ''Cierro la conexión
        dbconn.Close()
        Return ds
    End Function

    Public Function recorridos_zonas_activacion(ByVal Dia_id As Integer, ByVal Codigo As String, ByVal Habilitada As Integer) As DataSet
        Try
            dbconn.Open()
        Catch ex As Exception
        End Try
        Dim habi As Integer

        Try
            habi = CInt(Habilitada)
        Catch ex As Exception
            habi = 0
        End Try
        Dim comando As New OleDbCommand("recorridos_zonas_activacion", dbconn)
        comando.CommandType = CommandType.StoredProcedure
        comando.Parameters.Add(New OleDb.OleDbParameter("@Dia_id", Dia_id))
        comando.Parameters.Add(New OleDb.OleDbParameter("@Codigo", Codigo))
        comando.Parameters.Add(New OleDb.OleDbParameter("@Habilitada", habi))

        Dim ds As New DataSet()
        Dim DA As New OleDbDataAdapter(comando)
        ''Fill= Método que Agrega filas al objeto DataSet y crea un objeto DataTable denominado "Tabla", en nuestro caso "Grupos".
        DA.Fill(ds, "recorridos")
        ''Cierro la conexión
        dbconn.Close()
        Return ds
    End Function

#Region "CARGA DE RECORRIDOS Y ZONAS"
    Public Function recorridos_zonas_obtener_habilitados_x_dia(ByVal Dia_id As Integer) As DataSet
        'trae todos los recorridos/zonas de 1 dia puntual.
        Try
            dbconn.Open()
        Catch ex As Exception
        End Try
        Dim comando As New OleDbCommand("recorridos_zonas_obtener_habilitados_x_dia", dbconn)
        comando.CommandType = CommandType.StoredProcedure
        comando.Parameters.Add(New OleDb.OleDbParameter("@Dia_id", Dia_id))
        'comando.Parameters.Add(New OleDb.OleDbParameter("@Codigo", Codigo))

        Dim ds As New DataSet()
        Dim DA As New OleDbDataAdapter(comando)

        DA.Fill(ds, "Recorridos")
        ''Cierro la conexión
        dbconn.Close()
        Return ds
    End Function

    Public Function recorridos_zonas_buscar_codigo(ByVal Codigo As String, ByVal Dia_id As Integer) As DataSet
        'trae todos los recorridos/zonas de 1 dia puntual.
        Try
            dbconn.Open()
        Catch ex As Exception
        End Try
        Dim comando As New OleDbCommand("recorridos_zonas_buscar_codigo", dbconn)
        comando.CommandType = CommandType.StoredProcedure
        comando.Parameters.Add(New OleDb.OleDbParameter("@Codigo", Codigo))
        comando.Parameters.Add(New OleDb.OleDbParameter("@Dia_id", Dia_id))

        Dim ds As New DataSet()
        Dim DA As New OleDbDataAdapter(comando)

        DA.Fill(ds, "Recorridos")
        ''Cierro la conexión
        dbconn.Close()
        Return ds
    End Function
    Public Function recorridos_zonas_obtener_info_zona(ByVal Idrecorrido As Integer, ByVal Fecha As Date) As DataSet
        'trae todos los recorridos/zonas de 1 dia puntual.
        Try
            dbconn.Open()
        Catch ex As Exception
        End Try
        Dim comando As New OleDbCommand("recorridos_zonas_obtener_info_zona", dbconn)
        comando.CommandType = CommandType.StoredProcedure
        comando.Parameters.Add(New OleDb.OleDbParameter("@Idrecorrido", Idrecorrido))
        comando.Parameters.Add(New OleDb.OleDbParameter("@Fecha", Fecha))

        Dim ds As New DataSet()
        Dim DA As New OleDbDataAdapter(comando)

        DA.Fill(ds, "Recorridos")
        ''Cierro la conexión
        dbconn.Close()
        Return ds
    End Function


#End Region

End Class
