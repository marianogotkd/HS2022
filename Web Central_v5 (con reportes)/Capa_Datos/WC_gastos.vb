Imports System.Data.OleDb
Imports System.Data.DataRow
Public Class WC_gastos
    Inherits Capa_Datos.Conexion

    'CHOCO MODIFICO 20:24
    'LEO 20:31

#Region "Gastos Tipo"
    Public Function GastosTipo_validar(ByVal motivo As String) As DataSet
        Try
            dbconn.Open()
        Catch ex As Exception
        End Try
        Dim comando As New OleDbCommand("GastosTipo_validar", dbconn)
        comando.CommandType = CommandType.StoredProcedure
        comando.Parameters.Add(New OleDb.OleDbParameter("@motivo", motivo))


        Dim ds As New DataSet()
        Dim DA As New OleDbDataAdapter(comando)

        DA.Fill(ds, "GastosTipo")
        ''Cierro la conexión
        dbconn.Close()
        Return ds
    End Function

    Public Function GastosTipo_obtener_todos() As DataSet
        Try
            dbconn.Open()
        Catch ex As Exception
        End Try
        Dim comando As New OleDbCommand("GastosTipo_obtener_todos", dbconn)
        comando.CommandType = CommandType.StoredProcedure
        'comando.Parameters.Add(New OleDb.OleDbParameter("@motivo", motivo))


        Dim ds As New DataSet()
        Dim DA As New OleDbDataAdapter(comando)

        DA.Fill(ds, "GastosTipo")
        ''Cierro la conexión
        dbconn.Close()
        Return ds
    End Function

    Public Function GastosTipo_alta(ByVal motivo As String) As DataSet
        Try
            dbconn.Open()
        Catch ex As Exception
        End Try
        Dim comando As New OleDbCommand("GastosTipo_alta", dbconn)
        comando.CommandType = CommandType.StoredProcedure
        comando.Parameters.Add(New OleDb.OleDbParameter("@motivo", motivo))

        Dim ds As New DataSet()
        Dim DA As New OleDbDataAdapter(comando)
        ''Fill= Método que Agrega filas al objeto DataSet y crea un objeto DataTable denominado "Tabla", en nuestro caso "Grupos".
        DA.Fill(ds, "GastosTipo")
        ''Cierro la conexión
        dbconn.Close()
        Return ds
    End Function
#End Region


#Region "Gastos"
    Public Function Gastos_alta(ByVal Fecha As Date, ByVal Grupo_id As Integer, ByVal Gastotipo_id As Integer, ByVal Importe As Decimal) As DataSet
        Try
            dbconn.Open()
        Catch ex As Exception
        End Try
        Dim comando As New OleDbCommand("Gastos_alta", dbconn)
        comando.CommandType = CommandType.StoredProcedure
        comando.Parameters.Add(New OleDb.OleDbParameter("@Fecha", Fecha))
        comando.Parameters.Add(New OleDb.OleDbParameter("@Grupo_id", Grupo_id))
        comando.Parameters.Add(New OleDb.OleDbParameter("@Gastotipo_id", Gastotipo_id))
        comando.Parameters.Add(New OleDb.OleDbParameter("@Importe", Importe))
        comando.Parameters.Add(New OleDb.OleDbParameter("@Eliminado", 0))

        Dim ds As New DataSet()
        Dim DA As New OleDbDataAdapter(comando)

        DA.Fill(ds, "GastosTipo")
        ''Cierro la conexión
        dbconn.Close()
        Return ds
    End Function
#End Region

#Region "Resumen"
    Public Function Gastos_resumen(ByVal Fecha As Date) As DataSet
        Try
            dbconn.Open()
        Catch ex As Exception
        End Try
        Dim comando As New OleDbCommand("Gastos_resumen", dbconn)
        comando.CommandType = CommandType.StoredProcedure
        comando.Parameters.Add(New OleDb.OleDbParameter("@Fecha", Fecha))
        Dim ds As New DataSet()
        Dim DA As New OleDbDataAdapter(comando)

        DA.Fill(ds, "Resumen")
        ''Cierro la conexión
        dbconn.Close()
        Return ds
    End Function

    Public Function Gastos_eliminar(ByVal Idgastos As Integer) As DataSet
        Try
            dbconn.Open()
        Catch ex As Exception
        End Try
        Dim comando As New OleDbCommand("Gastos_eliminar", dbconn)
        comando.CommandType = CommandType.StoredProcedure
        comando.Parameters.Add(New OleDb.OleDbParameter("@Idgastos", Idgastos))
        Dim ds As New DataSet()
        Dim DA As New OleDbDataAdapter(comando)

        DA.Fill(ds, "Gastos")
        ''Cierro la conexión
        dbconn.Close()
        Return ds
    End Function

#End Region
End Class
