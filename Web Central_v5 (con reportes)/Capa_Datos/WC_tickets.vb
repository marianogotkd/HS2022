Imports System.Data.OleDb
Imports System.Data.DataRow
Public Class WC_tickets
    Inherits Capa_Datos.Conexion

#Region "TICKETS CLIENTES POR ORDEN"
    Public Function RecorridosPuntos_obtener_fecha(ByVal Fecha As Date) As DataSet
        'trae todos los recorridos/zonas de 1 dia puntual.
        Try
            dbconn.Open()
        Catch ex As Exception
        End Try
        Dim comando As New OleDbCommand("RecorridosPuntos_obtener_fecha", dbconn)
        comando.CommandType = CommandType.StoredProcedure
        comando.Parameters.Add(New OleDb.OleDbParameter("@Fecha", Fecha))
        'comando.Parameters.Add(New OleDb.OleDbParameter("@Codigo", Codigo))

        Dim ds As New DataSet()
        Dim DA As New OleDbDataAdapter(comando)

        DA.Fill(ds, "Recorridos")
        ''Cierro la conexión
        dbconn.Close()
        Return ds
    End Function

    Public Function CtaCte_MovimientosBuscar(ByVal Fecha As Date, ByVal Grupo_codigo_desde As Integer, ByVal Cliente_codigo_desde As Integer, ByVal Grupo_codigo_hasta As Integer, ByVal Cliente_codigo_hasta As Integer) As DataSet
        'trae todos los movimientos para la fecha indicada en base a un rango de grupos y clientes.
        Try
            dbconn.Open()
        Catch ex As Exception
        End Try
        Dim comando As New OleDbCommand("CtaCte_MovimientosBuscar", dbconn)
        comando.CommandType = CommandType.StoredProcedure
        comando.Parameters.Add(New OleDb.OleDbParameter("@Fecha", Fecha))
        comando.Parameters.Add(New OleDb.OleDbParameter("@Grupo_codigo_desde", Grupo_codigo_desde))
        comando.Parameters.Add(New OleDb.OleDbParameter("@Cliente_codigo_desde", Cliente_codigo_desde))
        comando.Parameters.Add(New OleDb.OleDbParameter("@Grupo_codigo_hasta", Grupo_codigo_hasta))
        comando.Parameters.Add(New OleDb.OleDbParameter("@Cliente_codigo_hasta", Cliente_codigo_hasta))

        Dim ds As New DataSet()
        Dim DA As New OleDbDataAdapter(comando)

        DA.Fill(ds, "CtaCte")
        ''Cierro la conexión
        dbconn.Close()
        Return ds
    End Function

    Public Function Premios_Cliente_Obtener(ByVal Fecha As Date, ByVal Dia_id As Integer, ByVal Cliente As Integer) As DataSet
        'trae todos los premios para un cliente y fecha determinada
        Try
            dbconn.Open()
        Catch ex As Exception
        End Try
        Dim comando As New OleDbCommand("Premios_Cliente_Obtener", dbconn)
        comando.CommandType = CommandType.StoredProcedure
        comando.Parameters.Add(New OleDb.OleDbParameter("@Fecha", Fecha))
        comando.Parameters.Add(New OleDb.OleDbParameter("@Dia_id", Dia_id))
        comando.Parameters.Add(New OleDb.OleDbParameter("@Cliente", Cliente)) 'cliente es el id no el codigo, OJO

        Dim ds As New DataSet()
        Dim DA As New OleDbDataAdapter(comando)

        DA.Fill(ds, "CtaCte")
        ''Cierro la conexión
        dbconn.Close()
        Return ds
    End Function

    Public Function CobroCreditos_ClienteObtener(ByVal Fecha As Date, ByVal Cliente As Integer) As DataSet
        'trae todos los premios para un cliente y fecha determinada
        Try
            dbconn.Open()
        Catch ex As Exception
        End Try
        Dim comando As New OleDbCommand("CobroCreditos_ClienteObtener", dbconn)
        comando.CommandType = CommandType.StoredProcedure
        comando.Parameters.Add(New OleDb.OleDbParameter("@Fecha", Fecha))
        comando.Parameters.Add(New OleDb.OleDbParameter("@Cliente", Cliente)) 'cliente es el id no el codigo, OJO

        Dim ds As New DataSet()
        Dim DA As New OleDbDataAdapter(comando)

        DA.Fill(ds, "Credito")
        ''Cierro la conexión
        dbconn.Close()
        Return ds
    End Function

#End Region

End Class
