Imports System.Data.OleDb
Imports System.Data.DataRow
Public Class WC_Liquidacion
    Inherits Capa_Datos.Conexion

    Public Function Liquidacion_validar_recorridos(ByVal Fecha As Date, ByVal Codigo As String) As DataSet
        Try
            dbconn.Open()
        Catch ex As Exception
        End Try
        Dim comando As New OleDbCommand("Liquidacion_validar_recorridos", dbconn)
        comando.CommandType = CommandType.StoredProcedure
        comando.Parameters.Add(New OleDb.OleDbParameter("@Fecha", Fecha))
        comando.Parameters.Add(New OleDb.OleDbParameter("@Codigo", Codigo))

        Dim ds As New DataSet()
        Dim DA As New OleDbDataAdapter(comando)
        ''Fill= Método que Agrega filas al objeto DataSet y crea un objeto DataTable denominado "Tabla", en nuestro caso "recorridos".
        DA.Fill(ds, "Recorridos")
        ''Cierro la conexión
        dbconn.Close()
        Return ds
    End Function

    Public Function Liquidacion_parcial_recuperar(ByVal Codigo As String) As DataSet
        Try
            dbconn.Open()
        Catch ex As Exception
        End Try
        Dim comando As New OleDbCommand("Liquidacion_parcial_recuperar", dbconn)
        comando.CommandType = CommandType.StoredProcedure
        comando.Parameters.Add(New OleDb.OleDbParameter("@Codigo", Codigo))

        Dim ds As New DataSet()
        Dim DA As New OleDbDataAdapter(comando)
        ''Fill= Método que Agrega filas al objeto DataSet y crea un objeto DataTable denominado "Tabla", en nuestro caso "XCargas".
        DA.Fill(ds, "XCargas")
        ''Cierro la conexión
        dbconn.Close()
        Return ds
    End Function

    Public Function Liquidacion_parcial_recuperarXcargas(ByVal Codigo As String, ByVal Fecha As Date) As DataSet
        Try
            dbconn.Open()
        Catch ex As Exception
        End Try
        Dim comando As New OleDbCommand("Liquidacion_parcial_recuperarXcargas", dbconn)
        comando.CommandType = CommandType.StoredProcedure
        comando.Parameters.Add(New OleDb.OleDbParameter("@Codigo", Codigo))
        comando.Parameters.Add(New OleDb.OleDbParameter("@Fecha", Fecha))

        Dim ds As New DataSet()
        Dim DA As New OleDbDataAdapter(comando)
        ''Fill= Método que Agrega filas al objeto DataSet y crea un objeto DataTable denominado "Tabla", en nuestro caso "XCargas".
        DA.Fill(ds, "XCargas")
        ''Cierro la conexión
        dbconn.Close()
        Return ds
    End Function

    Public Function Liquidacion_recuperarXcargas_totales() As DataSet
        Try
            dbconn.Open()
        Catch ex As Exception
        End Try
        Dim comando As New OleDbCommand("Liquidacion_recuperarXcargas_totales", dbconn)
        comando.CommandType = CommandType.StoredProcedure
        'comando.Parameters.Add(New OleDb.OleDbParameter("@Codigo", Codigo))
        'comando.Parameters.Add(New OleDb.OleDbParameter("@Fecha", Fecha))

        Dim ds As New DataSet()
        Dim DA As New OleDbDataAdapter(comando)
        ''Fill= Método que Agrega filas al objeto DataSet y crea un objeto DataTable denominado "Tabla", en nuestro caso "XCargas".
        DA.Fill(ds, "XCargas")
        ''Cierro la conexión
        dbconn.Close()
        Return ds
    End Function


    Public Function Liquidacion_todoXcargas() As DataSet
        Try
            dbconn.Open()
        Catch ex As Exception
        End Try
        Dim comando As New OleDbCommand("Liquidacion_todoXcargas", dbconn)
        comando.CommandType = CommandType.StoredProcedure
        'comando.Parameters.Add(New OleDb.OleDbParameter("@Codigo", Codigo))

        Dim ds As New DataSet()
        Dim DA As New OleDbDataAdapter(comando)
        ''Fill= Método que Agrega filas al objeto DataSet y crea un objeto DataTable denominado "Tabla", en nuestro caso "XCargas".
        DA.Fill(ds, "XCargas")
        ''Cierro la conexión
        dbconn.Close()
        Return ds
    End Function

    Public Function Liquidacion_obtenerBanderas() As DataSet
        Try
            dbconn.Open()
        Catch ex As Exception
        End Try
        Dim comando As New OleDbCommand("Liquidacion_obtenerBanderas", dbconn)
        comando.CommandType = CommandType.StoredProcedure
        'comando.Parameters.Add(New OleDb.OleDbParameter("@Codigo", Codigo))

        Dim ds As New DataSet()
        Dim DA As New OleDbDataAdapter(comando)
        ''Fill= Método que Agrega filas al objeto DataSet y crea un objeto DataTable denominado "Tabla", en nuestro caso "Banderas".
        DA.Fill(ds, "Banderas")
        ''Cierro la conexión
        dbconn.Close()
        Return ds
    End Function

    Public Function Liquidacion_final_recuperarXcargas(ByVal Fecha As Date) As DataSet
        Try
            dbconn.Open()
        Catch ex As Exception
        End Try
        Dim comando As New OleDbCommand("Liquidacion_final_recuperarXcargas", dbconn)
        comando.CommandType = CommandType.StoredProcedure
        comando.Parameters.Add(New OleDb.OleDbParameter("@Fecha", Fecha))

        Dim ds As New DataSet()
        Dim DA As New OleDbDataAdapter(comando)
        ''Fill= Método que Agrega filas al objeto DataSet y crea un objeto DataTable denominado "Tabla", en nuestro caso "Banderas".
        DA.Fill(ds, "Xcargas")
        ''Cierro la conexión
        dbconn.Close()
        Return ds
    End Function

#Region "LIQUIDACION FINAL"
    Public Function LiquidacionFinal_obtener_prestamoscreditos(ByVal Fecha As Date, ByVal Cliente As Integer) As DataSet
        Try
            dbconn.Open()
        Catch ex As Exception
        End Try
        Dim comando As New OleDbCommand("LiquidacionFinal_obtener_prestamoscreditos", dbconn)
        comando.CommandType = CommandType.StoredProcedure
        comando.Parameters.Add(New OleDb.OleDbParameter("@Fecha", Fecha))
        comando.Parameters.Add(New OleDb.OleDbParameter("@Cliente", Cliente))

        Dim ds As New DataSet()
        Dim DA As New OleDbDataAdapter(comando)
        ''Fill= Método que Agrega filas al objeto DataSet y crea un objeto DataTable denominado "Tabla", en nuestro caso "PrestamosCreditos".
        DA.Fill(ds, "PrestamosCreditos")
        ''Cierro la conexión
        dbconn.Close()
        Return ds
    End Function


#End Region

#Region "LIQUIDACION DE REGALOS"
    'recuperar clientes, procedo="D"
    Public Function LiquidacionRegalos_obtener_ClieDiario() As DataSet
        Try
            dbconn.Open()
        Catch ex As Exception
        End Try
        Dim comando As New OleDbCommand("LiquidacionRegalos_obtener_ClieDiario", dbconn)
        comando.CommandType = CommandType.StoredProcedure
        'comando.Parameters.Add(New OleDb.OleDbParameter("@Fecha", Fecha))

        Dim ds As New DataSet()
        Dim DA As New OleDbDataAdapter(comando)
        ''Fill= Método que Agrega filas al objeto DataSet y crea un objeto DataTable denominado "Tabla", en nuestro caso "Clientes".
        DA.Fill(ds, "Clientes")
        ''Cierro la conexión
        dbconn.Close()
        Return ds
    End Function

    'obtiene la info de la ctacta del cliente para la fecha de la ultima liquidacion completada
    Public Function LiquidacionRegalos_obtenerctacte(ByVal Codigo As Integer, ByVal Fecha As Date) As DataSet
        Try
            dbconn.Open()
        Catch ex As Exception
        End Try
        Dim comando As New OleDbCommand("LiquidacionRegalos_obtenerctacte", dbconn)
        comando.CommandType = CommandType.StoredProcedure
        comando.Parameters.Add(New OleDb.OleDbParameter("@Codigo", Codigo))
        comando.Parameters.Add(New OleDb.OleDbParameter("@Fecha", Fecha))

        Dim ds As New DataSet()
        Dim DA As New OleDbDataAdapter(comando)
        ''Fill= Método que Agrega filas al objeto DataSet y crea un objeto DataTable denominado "Tabla", en nuestro caso "CtaCte".
        DA.Fill(ds, "CtaCte")
        ''Cierro la conexión
        dbconn.Close()
        Return ds
    End Function

    'actualizo ctacte el campo regalos
    Public Function LiquidacionRegalosDiario_actualizarCtaCte(ByVal IdCtaCte As Integer, ByVal Regalos As Decimal) As DataSet
        Try
            dbconn.Open()
        Catch ex As Exception
        End Try
        Dim comando As New OleDbCommand("LiquidacionRegalosDiario_actualizarCtaCte", dbconn)
        comando.CommandType = CommandType.StoredProcedure
        comando.Parameters.Add(New OleDb.OleDbParameter("@IdCtaCte", IdCtaCte))
        comando.Parameters.Add(New OleDb.OleDbParameter("@Regalos", Regalos))

        Dim ds As New DataSet()
        Dim DA As New OleDbDataAdapter(comando)
        ''Fill= Método que Agrega filas al objeto DataSet y crea un objeto DataTable denominado "Tabla", en nuestro caso "CtaCte".
        DA.Fill(ds, "CtaCte")
        ''Cierro la conexión
        dbconn.Close()
        Return ds
    End Function

    'actualizar en tabla cliente, campos saldoregalo y saldo
    Public Function LiquidacionRegalosDiario_actualizarClie(ByVal Cliente As Integer, ByVal SaldoRegalo As Decimal, ByVal Saldo As Decimal) As DataSet
        Try
            dbconn.Open()
        Catch ex As Exception
        End Try
        Dim comando As New OleDbCommand("LiquidacionRegalosDiario_actualizarClie", dbconn)
        comando.CommandType = CommandType.StoredProcedure
        comando.Parameters.Add(New OleDb.OleDbParameter("@Cliente", Cliente))
        comando.Parameters.Add(New OleDb.OleDbParameter("@SaldoRegalo", SaldoRegalo))
        comando.Parameters.Add(New OleDb.OleDbParameter("@Saldo", Saldo))

        Dim ds As New DataSet()
        Dim DA As New OleDbDataAdapter(comando)
        ''Fill= Método que Agrega filas al objeto DataSet y crea un objeto DataTable denominado "Tabla", en nuestro caso "CtaCte".
        DA.Fill(ds, "Cliente")
        ''Cierro la conexión
        dbconn.Close()
        Return ds
    End Function


    'recuperar clientes, procedo="S"
    Public Function LiquidacionRegalos_obtener_ClieSemanal() As DataSet
        Try
            dbconn.Open()
        Catch ex As Exception
        End Try
        Dim comando As New OleDbCommand("LiquidacionRegalos_obtener_ClieSemanal", dbconn)
        comando.CommandType = CommandType.StoredProcedure
        'comando.Parameters.Add(New OleDb.OleDbParameter("@Fecha", Fecha))

        Dim ds As New DataSet()
        Dim DA As New OleDbDataAdapter(comando)
        ''Fill= Método que Agrega filas al objeto DataSet y crea un objeto DataTable denominado "Tabla", en nuestro caso "Clientes".
        DA.Fill(ds, "Clientes")
        ''Cierro la conexión
        dbconn.Close()
        Return ds
    End Function

    'actualizo ctacte el campo regalos
    Public Function LiquidacionRegalosSemanal_actualizarCtaCte(ByVal IdCtaCte As Integer, ByVal Regalos As Decimal) As DataSet
        Try
            dbconn.Open()
        Catch ex As Exception
        End Try
        Dim comando As New OleDbCommand("LiquidacionRegalosSemanal_actualizarCtaCte", dbconn)
        comando.CommandType = CommandType.StoredProcedure
        comando.Parameters.Add(New OleDb.OleDbParameter("@IdCtaCte", IdCtaCte))
        comando.Parameters.Add(New OleDb.OleDbParameter("@Regalos", Regalos))

        Dim ds As New DataSet()
        Dim DA As New OleDbDataAdapter(comando)
        ''Fill= Método que Agrega filas al objeto DataSet y crea un objeto DataTable denominado "Tabla", en nuestro caso "CtaCte".
        DA.Fill(ds, "CtaCte")
        ''Cierro la conexión
        dbconn.Close()
        Return ds
    End Function

    'actualizar en tabla cliente, campos saldoregalo y saldo
    Public Function LiquidacionRegalosSemanal_actualizarClie(ByVal Cliente As Integer, ByVal SaldoRegalo As Decimal, ByVal Saldo As Decimal) As DataSet
        Try
            dbconn.Open()
        Catch ex As Exception
        End Try
        Dim comando As New OleDbCommand("LiquidacionRegalosSemanal_actualizarClie", dbconn)
        comando.CommandType = CommandType.StoredProcedure
        comando.Parameters.Add(New OleDb.OleDbParameter("@Cliente", Cliente))
        comando.Parameters.Add(New OleDb.OleDbParameter("@SaldoRegalo", SaldoRegalo))
        comando.Parameters.Add(New OleDb.OleDbParameter("@Saldo", Saldo))

        Dim ds As New DataSet()
        Dim DA As New OleDbDataAdapter(comando)
        ''Fill= Método que Agrega filas al objeto DataSet y crea un objeto DataTable denominado "Tabla", en nuestro caso "CtaCte".
        DA.Fill(ds, "Cliente")
        ''Cierro la conexión
        dbconn.Close()
        Return ds
    End Function

    'recuperar clientes, procedo="M"
    Public Function LiquidacionRegalos_obtener_ClieMensual() As DataSet
        Try
            dbconn.Open()
        Catch ex As Exception
        End Try
        Dim comando As New OleDbCommand("LiquidacionRegalos_obtener_ClieMensual", dbconn)
        comando.CommandType = CommandType.StoredProcedure
        'comando.Parameters.Add(New OleDb.OleDbParameter("@Fecha", Fecha))

        Dim ds As New DataSet()
        Dim DA As New OleDbDataAdapter(comando)
        ''Fill= Método que Agrega filas al objeto DataSet y crea un objeto DataTable denominado "Tabla", en nuestro caso "Clientes".
        DA.Fill(ds, "Clientes")
        ''Cierro la conexión
        dbconn.Close()
        Return ds
    End Function

    'actualizo ctacte el campo regalos
    Public Function LiquidacionRegalosMensual_actualizarCtaCte(ByVal IdCtaCte As Integer, ByVal Regalos As Decimal) As DataSet
        Try
            dbconn.Open()
        Catch ex As Exception
        End Try
        Dim comando As New OleDbCommand("LiquidacionRegalosMensual_actualizarCtaCte", dbconn)
        comando.CommandType = CommandType.StoredProcedure
        comando.Parameters.Add(New OleDb.OleDbParameter("@IdCtaCte", IdCtaCte))
        comando.Parameters.Add(New OleDb.OleDbParameter("@Regalos", Regalos))

        Dim ds As New DataSet()
        Dim DA As New OleDbDataAdapter(comando)
        ''Fill= Método que Agrega filas al objeto DataSet y crea un objeto DataTable denominado "Tabla", en nuestro caso "CtaCte".
        DA.Fill(ds, "CtaCte")
        ''Cierro la conexión
        dbconn.Close()
        Return ds
    End Function



    'actualizar en tabla cliente, campos saldoregalo y saldo
    Public Function LiquidacionRegalosMensual_actualizarClie(ByVal Cliente As Integer, ByVal SaldoRegalo As Decimal, ByVal Saldo As Decimal) As DataSet
        Try
            dbconn.Open()
        Catch ex As Exception
        End Try
        Dim comando As New OleDbCommand("LiquidacionRegalosMensual_actualizarClie", dbconn)
        comando.CommandType = CommandType.StoredProcedure
        comando.Parameters.Add(New OleDb.OleDbParameter("@Cliente", Cliente))
        comando.Parameters.Add(New OleDb.OleDbParameter("@SaldoRegalo", SaldoRegalo))
        comando.Parameters.Add(New OleDb.OleDbParameter("@Saldo", Saldo))

        Dim ds As New DataSet()
        Dim DA As New OleDbDataAdapter(comando)
        ''Fill= Método que Agrega filas al objeto DataSet y crea un objeto DataTable denominado "Tabla", en nuestro caso "CtaCte".
        DA.Fill(ds, "Cliente")
        ''Cierro la conexión
        dbconn.Close()
        Return ds
    End Function


#End Region

#Region "LIQUIDACION DE GRUPOS"

    Public Function LiquidacionGrupos_ObtenerCtaCtexrangofecha(ByVal FechaDesde As Date, ByVal FechaHasta As Date, ByVal Grupo_Id As Integer) As DataSet
        Try
            dbconn.Open()
        Catch ex As Exception
        End Try
        Dim comando As New OleDbCommand("LiquidacionGrupos_ObtenerCtaCtexrangofecha", dbconn)
        comando.CommandType = CommandType.StoredProcedure
        comando.Parameters.Add(New OleDb.OleDbParameter("@FechaDesde", FechaDesde))
        comando.Parameters.Add(New OleDb.OleDbParameter("@FechaHasta", FechaHasta))
        comando.Parameters.Add(New OleDb.OleDbParameter("@Grupo_Id", Grupo_Id))

        Dim ds As New DataSet()
        Dim DA As New OleDbDataAdapter(comando)
        ''Fill= Método que Agrega filas al objeto DataSet y crea un objeto DataTable denominado "Tabla", en nuestro caso "CtaCte".
        DA.Fill(ds, "CtaCte")
        ''Cierro la conexión
        dbconn.Close()
        Return ds
    End Function

    Public Function LiquidacionGrupos_ObtenerGastosxrangofecha(ByVal FechaDesde As Date, ByVal FechaHasta As Date, ByVal Grupo_Id As Integer) As DataSet
        Try
            dbconn.Open()
        Catch ex As Exception
        End Try
        Dim comando As New OleDbCommand("LiquidacionGrupos_ObtenerGastosxrangofecha", dbconn)
        comando.CommandType = CommandType.StoredProcedure
        comando.Parameters.Add(New OleDb.OleDbParameter("@FechaDesde", FechaDesde))
        comando.Parameters.Add(New OleDb.OleDbParameter("@FechaHasta", FechaHasta))
        comando.Parameters.Add(New OleDb.OleDbParameter("@Grupo_Id", Grupo_Id))

        Dim ds As New DataSet()
        Dim DA As New OleDbDataAdapter(comando)
        ''Fill= Método que Agrega filas al objeto DataSet y crea un objeto DataTable denominado "Tabla", en nuestro caso "CtaCte".
        DA.Fill(ds, "Gastos")
        ''Cierro la conexión
        dbconn.Close()
        Return ds
    End Function

    Public Function LiquidacionGrupos_GruposModiffecha(ByVal Grupo_Id As Integer, ByVal FechaHasta As Date) As DataSet
        Try
            dbconn.Open()
        Catch ex As Exception
        End Try
        Dim comando As New OleDbCommand("LiquidacionGrupos_GruposModiffecha", dbconn)
        comando.CommandType = CommandType.StoredProcedure
        comando.Parameters.Add(New OleDb.OleDbParameter("@Grupo_Id", Grupo_Id))
        comando.Parameters.Add(New OleDb.OleDbParameter("@Fecha", FechaHasta))


        Dim ds As New DataSet()
        Dim DA As New OleDbDataAdapter(comando)
        ''Fill= Método que Agrega filas al objeto DataSet y crea un objeto DataTable denominado "Tabla", en nuestro caso "Grupo".
        DA.Fill(ds, "Grupo")
        ''Cierro la conexión
        dbconn.Close()
        Return ds
    End Function

    Public Function LiquidacionGrupos_GruposModifimporte(ByVal Grupo_Id As Integer, ByVal Importe As Decimal) As DataSet
        Try
            dbconn.Open()
        Catch ex As Exception
        End Try
        Dim comando As New OleDbCommand("LiquidacionGrupos_GruposModifimporte", dbconn)
        comando.CommandType = CommandType.StoredProcedure
        comando.Parameters.Add(New OleDb.OleDbParameter("@Grupo_Id", Grupo_Id))
        comando.Parameters.Add(New OleDb.OleDbParameter("@Importe", Importe))


        Dim ds As New DataSet()
        Dim DA As New OleDbDataAdapter(comando)
        ''Fill= Método que Agrega filas al objeto DataSet y crea un objeto DataTable denominado "Tabla", en nuestro caso "Grupo".
        DA.Fill(ds, "Grupo")
        ''Cierro la conexión
        dbconn.Close()
        Return ds
    End Function

#End Region
End Class