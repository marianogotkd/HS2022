Imports System.Data.OleDb
Imports System.Data.DataRow
Public Class WC_anticipados
    Inherits Capa_Datos.Conexion

    Public Function Anticipados_alta(ByVal Fecha As Date,
                                ByVal Cliente As Integer,
                                ByVal AnticipadosTipo_id As Integer,
                                ByVal Importe As Decimal,
                                ByVal Sincalculo As Integer,
                                ByVal Origen As Integer,
                                ByVal Descripcion As String,
                                ByVal FechaOrigen As Date,
                                ByVal Eliminado As Integer) As DataSet
        Try
            dbconn.Open()
        Catch ex As Exception
        End Try
        Dim comando As New OleDbCommand("Anticipados_alta", dbconn)
        comando.CommandType = CommandType.StoredProcedure
        comando.Parameters.Add(New OleDb.OleDbParameter("@Fecha", Fecha))
        comando.Parameters.Add(New OleDb.OleDbParameter("@Cliente", Cliente))
        comando.Parameters.Add(New OleDb.OleDbParameter("@AnticipadosTipo_id", AnticipadosTipo_id))
        comando.Parameters.Add(New OleDb.OleDbParameter("@Importe", Importe))
        comando.Parameters.Add(New OleDb.OleDbParameter("@Sincalculo", Sincalculo))
        comando.Parameters.Add(New OleDb.OleDbParameter("@Origen", Origen))
        comando.Parameters.Add(New OleDb.OleDbParameter("@Descripcion", Descripcion))
        comando.Parameters.Add(New OleDb.OleDbParameter("@FechaOrigen", FechaOrigen))
        comando.Parameters.Add(New OleDb.OleDbParameter("@Eliminado", Eliminado))
        
        Dim ds As New DataSet()
        Dim DA As New OleDbDataAdapter(comando)
        ''Fill= Método que Agrega filas al objeto DataSet y crea un objeto DataTable denominado "Tabla", en nuestro caso "Grupos".
        DA.Fill(ds, "Anticipados")
        ''Cierro la conexión
        dbconn.Close()
        Return ds
    End Function


    Public Function Anticipados_reclamo_alta(ByVal Fecha As Date,
                                ByVal Cliente As Integer,
                                ByVal AnticipadosTipo_id As Integer,
                                ByVal Importe As Decimal,
                                ByVal Sincalculo As Integer,
                                ByVal Origen As Integer,
                                ByVal Descripcion As String,
                                ByVal Eliminado As Integer) As DataSet
        Try
            dbconn.Open()
        Catch ex As Exception
        End Try
        Dim comando As New OleDbCommand("Anticipados_reclamo_alta", dbconn)
        comando.CommandType = CommandType.StoredProcedure
        comando.Parameters.Add(New OleDb.OleDbParameter("@Fecha", Fecha))
        comando.Parameters.Add(New OleDb.OleDbParameter("@Cliente", Cliente))
        comando.Parameters.Add(New OleDb.OleDbParameter("@AnticipadosTipo_id", AnticipadosTipo_id))
        comando.Parameters.Add(New OleDb.OleDbParameter("@Importe", Importe))
        comando.Parameters.Add(New OleDb.OleDbParameter("@Sincalculo", Sincalculo))
        comando.Parameters.Add(New OleDb.OleDbParameter("@Origen", Origen))
        comando.Parameters.Add(New OleDb.OleDbParameter("@Descripcion", Descripcion))
        'comando.Parameters.Add(New OleDb.OleDbParameter("@FechaOrigen", FechaOrigen))
        comando.Parameters.Add(New OleDb.OleDbParameter("@Eliminado", Eliminado))

        Dim ds As New DataSet()
        Dim DA As New OleDbDataAdapter(comando)
        ''Fill= Método que Agrega filas al objeto DataSet y crea un objeto DataTable denominado "Tabla", en nuestro caso "Grupos".
        DA.Fill(ds, "Anticipados")
        ''Cierro la conexión
        dbconn.Close()
        Return ds
    End Function


    Public Function Anticipados_pago_alta(ByVal Fecha As Date,
                                ByVal Cliente As Integer,
                                ByVal AnticipadosTipo_id As Integer,
                                ByVal Importe As Decimal,
                                ByVal Eliminado As Integer) As DataSet
        Try
            dbconn.Open()
        Catch ex As Exception
        End Try
        Dim comando As New OleDbCommand("Anticipados_pago_alta", dbconn)
        comando.CommandType = CommandType.StoredProcedure
        comando.Parameters.Add(New OleDb.OleDbParameter("@Fecha", Fecha))
        comando.Parameters.Add(New OleDb.OleDbParameter("@Cliente", Cliente))
        comando.Parameters.Add(New OleDb.OleDbParameter("@AnticipadosTipo_id", AnticipadosTipo_id))
        comando.Parameters.Add(New OleDb.OleDbParameter("@Importe", Importe))
        comando.Parameters.Add(New OleDb.OleDbParameter("@Eliminado", Eliminado))

        Dim ds As New DataSet()
        Dim DA As New OleDbDataAdapter(comando)
        ''Fill= Método que Agrega filas al objeto DataSet y crea un objeto DataTable denominado "Tabla", en nuestro caso "Grupos".
        DA.Fill(ds, "Anticipados")
        ''Cierro la conexión
        dbconn.Close()
        Return ds
    End Function


    Public Function Anticipados_cobro_alta(ByVal Fecha As Date,
                                ByVal Cliente As Integer,
                                ByVal AnticipadosTipo_id As Integer,
                                ByVal Importe As Decimal,
                                ByVal Eliminado As Integer) As DataSet
        Try
            dbconn.Open()
        Catch ex As Exception
        End Try
        Dim comando As New OleDbCommand("Anticipados_cobro_alta", dbconn)
        comando.CommandType = CommandType.StoredProcedure
        comando.Parameters.Add(New OleDb.OleDbParameter("@Fecha", Fecha))
        comando.Parameters.Add(New OleDb.OleDbParameter("@Cliente", Cliente))
        comando.Parameters.Add(New OleDb.OleDbParameter("@AnticipadosTipo_id", AnticipadosTipo_id))
        comando.Parameters.Add(New OleDb.OleDbParameter("@Importe", Importe))
        comando.Parameters.Add(New OleDb.OleDbParameter("@Eliminado", Eliminado))

        Dim ds As New DataSet()
        Dim DA As New OleDbDataAdapter(comando)
        ''Fill= Método que Agrega filas al objeto DataSet y crea un objeto DataTable denominado "Tabla", en nuestro caso "Grupos".
        DA.Fill(ds, "Anticipados")
        ''Cierro la conexión
        dbconn.Close()
        Return ds
    End Function


    Public Function Anticipados_resumen(ByVal Fecha As Date) As DataSet
        Try
            dbconn.Open()
        Catch ex As Exception
        End Try
        Dim comando As New OleDbCommand("Anticipados_resumen", dbconn)
        comando.CommandType = CommandType.StoredProcedure
        comando.Parameters.Add(New OleDb.OleDbParameter("@Fecha", Fecha))

        Dim ds As New DataSet()
        Dim DA As New OleDbDataAdapter(comando)
        ''Fill= Método que Agrega filas al objeto DataSet y crea un objeto DataTable denominado "Tabla", en nuestro caso "Grupos".
        DA.Fill(ds, "Anticipados")
        ''Cierro la conexión
        dbconn.Close()
        Return ds
    End Function

    Public Function Anticipados_eliminar(ByVal Anticipados_id As Integer) As DataSet
        Try
            dbconn.Open()
        Catch ex As Exception
        End Try
        Dim comando As New OleDbCommand("Anticipados_eliminar", dbconn)
        comando.CommandType = CommandType.StoredProcedure
        comando.Parameters.Add(New OleDb.OleDbParameter("@Anticipados_id", Anticipados_id))

        Dim ds As New DataSet()
        Dim DA As New OleDbDataAdapter(comando)
        ''Fill= Método que Agrega filas al objeto DataSet y crea un objeto DataTable denominado "Tabla", en nuestro caso "Grupos".
        DA.Fill(ds, "Anticipados")
        ''Cierro la conexión
        dbconn.Close()
        Return ds
    End Function



End Class
