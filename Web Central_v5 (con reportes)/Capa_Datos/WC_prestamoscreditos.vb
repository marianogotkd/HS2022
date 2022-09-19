Imports System.Data.OleDb
Imports System.Data.DataRow
Public Class WC_prestamoscreditos
    Inherits Capa_Datos.Conexion

    Public Function Prestamos_buscar_cliente_info(ByVal Codigo As String, ByVal Fecha As Date) As DataSet
        Try
            dbconn.Open()
        Catch ex As Exception
        End Try
        Dim comando As New OleDbCommand("Prestamos_buscar_cliente_info", dbconn)
        comando.CommandType = CommandType.StoredProcedure
        comando.Parameters.Add(New OleDb.OleDbParameter("@Codigo", Codigo))
        comando.Parameters.Add(New OleDb.OleDbParameter("@Fecha", Fecha))

        Dim ds As New DataSet()
        Dim DA As New OleDbDataAdapter(comando)
        ''Fill= Método que Agrega filas al objeto DataSet y crea un objeto DataTable denominado "Tabla", en nuestro caso "Grupos".
        DA.Fill(ds, "Prestamos")
        ''Cierro la conexión
        dbconn.Close()
        Return ds
    End Function

    Public Function Prestamos_alta(ByVal Cliente As Integer, ByVal Fecha As Date, ByVal Importe As Decimal, ByVal Tipocobro As String, ByVal Porcentaje As Decimal) As DataSet
        Try
            dbconn.Open()
        Catch ex As Exception
        End Try
        Dim tipo As String = "P"
        Dim comando As New OleDbCommand("PrestamosCreditos_alta", dbconn)
        comando.CommandType = CommandType.StoredProcedure
        comando.Parameters.Add(New OleDb.OleDbParameter("@Cliente", Cliente))
        comando.Parameters.Add(New OleDb.OleDbParameter("@Fecha", Fecha))
        comando.Parameters.Add(New OleDb.OleDbParameter("@Importe", Importe))
        comando.Parameters.Add(New OleDb.OleDbParameter("@Tipo", tipo))
        comando.Parameters.Add(New OleDb.OleDbParameter("@Tipocobro", Tipocobro))
        comando.Parameters.Add(New OleDb.OleDbParameter("@Porcentaje", Porcentaje))
        comando.Parameters.Add(New OleDb.OleDbParameter("@Dias", 0))
        comando.Parameters.Add(New OleDb.OleDbParameter("@Saldo", Importe))
        comando.Parameters.Add(New OleDb.OleDbParameter("@Cuota_valor", CDec(0)))

        Dim ds As New DataSet()
        Dim DA As New OleDbDataAdapter(comando)
        ''Fill= Método que Agrega filas al objeto DataSet y crea un objeto DataTable denominado "Tabla", en nuestro caso "Grupos".
        DA.Fill(ds, "Prestamos")
        ''Cierro la conexión
        dbconn.Close()
        Return ds
    End Function


    Public Function Prestamos_modificar(ByVal Cliente As Integer, ByVal Fecha As Date, ByVal Importe As Decimal, ByVal Tipocobro As String, ByVal Porcentaje As Decimal, ByVal Estado As Integer) As DataSet
        Try
            dbconn.Open()
        Catch ex As Exception
        End Try
        Dim tipo As String = "P"
        Dim comando As New OleDbCommand("Prestamos_modificar", dbconn)
        comando.CommandType = CommandType.StoredProcedure
        comando.Parameters.Add(New OleDb.OleDbParameter("@Cliente", Cliente))
        comando.Parameters.Add(New OleDb.OleDbParameter("@Fecha", Fecha))
        comando.Parameters.Add(New OleDb.OleDbParameter("@Importe", Importe))
        comando.Parameters.Add(New OleDb.OleDbParameter("@Tipocobro", Tipocobro))
        comando.Parameters.Add(New OleDb.OleDbParameter("@Porcentaje", Porcentaje))
        comando.Parameters.Add(New OleDb.OleDbParameter("@Tipo", tipo))
        'comando.Parameters.Add(New OleDb.OleDbParameter("@Dias", 0))
        comando.Parameters.Add(New OleDb.OleDbParameter("@Saldo", Importe))
        comando.Parameters.Add(New OleDb.OleDbParameter("@Estado_id", Estado))

        Dim ds As New DataSet()
        Dim DA As New OleDbDataAdapter(comando)
        ''Fill= Método que Agrega filas al objeto DataSet y crea un objeto DataTable denominado "Tabla", en nuestro caso "Grupos".
        DA.Fill(ds, "Prestamos")
        ''Cierro la conexión
        dbconn.Close()
        Return ds
    End Function

#Region "Creditos"
    Public Function Creditos_buscar_cliente_info(ByVal Codigo As String, ByVal Fecha As Date) As DataSet
        Try
            dbconn.Open()
        Catch ex As Exception
        End Try
        Dim comando As New OleDbCommand("Creditos_buscar_cliente_info", dbconn)
        comando.CommandType = CommandType.StoredProcedure
        comando.Parameters.Add(New OleDb.OleDbParameter("@Codigo", Codigo))
        comando.Parameters.Add(New OleDb.OleDbParameter("@Fecha", Fecha))

        Dim ds As New DataSet()
        Dim DA As New OleDbDataAdapter(comando)
        ''Fill= Método que Agrega filas al objeto DataSet y crea un objeto DataTable denominado "Tabla", en nuestro caso "Grupos".
        DA.Fill(ds, "Creditos")
        ''Cierro la conexión
        dbconn.Close()
        Return ds
    End Function

    Public Function Creditos_alta(ByVal Cliente As Integer, ByVal Fecha As Date, ByVal Importe As Decimal, ByVal Porcentaje As Decimal, ByVal Dias As String, ByVal Saldo As Decimal, ByVal Cuota_valor As Decimal) As DataSet
        Try
            dbconn.Open()
        Catch ex As Exception
        End Try
        Dim tipo As String = "C"
        Dim comando As New OleDbCommand("PrestamosCreditos_alta", dbconn)
        comando.CommandType = CommandType.StoredProcedure
        comando.Parameters.Add(New OleDb.OleDbParameter("@Cliente", Cliente))
        comando.Parameters.Add(New OleDb.OleDbParameter("@Fecha", Fecha))
        comando.Parameters.Add(New OleDb.OleDbParameter("@Importe", Importe))
        comando.Parameters.Add(New OleDb.OleDbParameter("@Tipo", tipo))
        comando.Parameters.Add(New OleDb.OleDbParameter("@Tipocobro", "")) 'nulo en creditos
        comando.Parameters.Add(New OleDb.OleDbParameter("@Porcentaje", Porcentaje))
        comando.Parameters.Add(New OleDb.OleDbParameter("@Dias", Dias))
        comando.Parameters.Add(New OleDb.OleDbParameter("@Saldo", Saldo)) 'surge de multiplicar = importe x porcentaje.
        comando.Parameters.Add(New OleDb.OleDbParameter("@Cuota_valor", Cuota_valor)) 'surge de la operacion = (importe x porcentaje) / dias.

        Dim ds As New DataSet()
        Dim DA As New OleDbDataAdapter(comando)
        ''Fill= Método que Agrega filas al objeto DataSet y crea un objeto DataTable denominado "Tabla", en nuestro caso "Grupos".
        DA.Fill(ds, "Creditos")
        ''Cierro la conexión
        dbconn.Close()
        Return ds
    End Function

    Public Function Creditos_modificar(ByVal Cliente As Integer, ByVal Fecha As Date, ByVal Importe As Decimal, ByVal Porcentaje As Decimal, ByVal Dias As String, ByVal Saldo As Decimal, ByVal Estado As Integer, ByVal Cuota_valor As Decimal) As DataSet
        Try
            dbconn.Open()
        Catch ex As Exception
        End Try
        Dim tipo As String = "C"
        Dim comando As New OleDbCommand("Creditos_modificar", dbconn)
        comando.CommandType = CommandType.StoredProcedure
        comando.Parameters.Add(New OleDb.OleDbParameter("@Cliente", Cliente))
        comando.Parameters.Add(New OleDb.OleDbParameter("@Fecha", Fecha))
        comando.Parameters.Add(New OleDb.OleDbParameter("@Importe", Importe))
        comando.Parameters.Add(New OleDb.OleDbParameter("@Dias", Dias))
        comando.Parameters.Add(New OleDb.OleDbParameter("@Porcentaje", Porcentaje))
        comando.Parameters.Add(New OleDb.OleDbParameter("@Tipo", tipo))
        comando.Parameters.Add(New OleDb.OleDbParameter("@Saldo", Saldo))
        comando.Parameters.Add(New OleDb.OleDbParameter("@Estado_id", Estado))
        comando.Parameters.Add(New OleDb.OleDbParameter("@Cuota_valor", Cuota_valor)) 'surge de la operacion = (importe x porcentaje) / dias.


        Dim ds As New DataSet()
        Dim DA As New OleDbDataAdapter(comando)
        ''Fill= Método que Agrega filas al objeto DataSet y crea un objeto DataTable denominado "Tabla", en nuestro caso "Grupos".
        DA.Fill(ds, "Creditos")
        ''Cierro la conexión
        dbconn.Close()
        Return ds
    End Function

#End Region

#Region "RESUMEN"
    Public Function PrestamosCreditos_resumen(ByVal Fecha As Date) As DataSet
        Try
            dbconn.Open()
        Catch ex As Exception
        End Try

        Dim comando As New OleDbCommand("PrestamosCreditos_resumen", dbconn)
        comando.CommandType = CommandType.StoredProcedure
        comando.Parameters.Add(New OleDb.OleDbParameter("@Fecha", Fecha))
        
        Dim ds As New DataSet()
        Dim DA As New OleDbDataAdapter(comando)
        ''Fill= Método que Agrega filas al objeto DataSet y crea un objeto DataTable denominado "Tabla", en nuestro caso "Grupos".
        DA.Fill(ds, "RESUMEN")
        ''Cierro la conexión
        dbconn.Close()
        Return ds
    End Function

    Public Function PrestamosCreditos_eliminar(ByVal ID As Integer) As DataSet
        Try
            dbconn.Open()
        Catch ex As Exception
        End Try

        Dim comando As New OleDbCommand("PrestamosCreditos_eliminar", dbconn)
        comando.CommandType = CommandType.StoredProcedure
        comando.Parameters.Add(New OleDb.OleDbParameter("@Idprestamocredito", ID))

        Dim ds As New DataSet()
        Dim DA As New OleDbDataAdapter(comando)
        ''Fill= Método que Agrega filas al objeto DataSet y crea un objeto DataTable denominado "Tabla", en nuestro caso "Grupos".
        DA.Fill(ds, "RESUMEN")
        ''Cierro la conexión
        dbconn.Close()
        Return ds
    End Function

    Public Function PrestamosCreditos_baja(ByVal ID As Integer, ByVal Estado_id As Integer, ByVal Fecha_baja As Date) As DataSet
        Try
            dbconn.Open()
        Catch ex As Exception
        End Try

        Dim comando As New OleDbCommand("PrestamosCreditos_baja", dbconn)
        comando.CommandType = CommandType.StoredProcedure
        comando.Parameters.Add(New OleDb.OleDbParameter("@ID", ID))
        comando.Parameters.Add(New OleDb.OleDbParameter("@Estado_id", Estado_id))
        comando.Parameters.Add(New OleDb.OleDbParameter("@Fecha_baja", fecha_baja))

        Dim ds As New DataSet()
        Dim DA As New OleDbDataAdapter(comando)
        ''Fill= Método que Agrega filas al objeto DataSet y crea un objeto DataTable denominado "Tabla", en nuestro caso "Grupos".
        DA.Fill(ds, "RESUMEN")
        ''Cierro la conexión
        dbconn.Close()
        Return ds
    End Function


#End Region

#Region "COBRO PRESTAMOS MANUALES"
    Public Function Prestamos_cliente_buscar_activos(ByVal Codigo As String) As DataSet
        Try
            dbconn.Open()
        Catch ex As Exception
        End Try

        Dim comando As New OleDbCommand("Prestamos_cliente_buscar_activos", dbconn)
        comando.CommandType = CommandType.StoredProcedure
        comando.Parameters.Add(New OleDb.OleDbParameter("@Codigo", Codigo))
        

        Dim ds As New DataSet()
        Dim DA As New OleDbDataAdapter(comando)
        ''Fill= Método que Agrega filas al objeto DataSet y crea un objeto DataTable denominado "Tabla", en nuestro caso "Grupos".
        DA.Fill(ds, "Prestamos_Activos")
        ''Cierro la conexión
        dbconn.Close()
        Return ds
    End Function
    Public Function Prestamos_buscar_x_id(ByVal Idprestamocredito As Integer) As DataSet
        Try
            dbconn.Open()
        Catch ex As Exception
        End Try

        Dim comando As New OleDbCommand("Prestamos_buscar_x_id", dbconn)
        comando.CommandType = CommandType.StoredProcedure
        comando.Parameters.Add(New OleDb.OleDbParameter("@Idprestamocredito", Idprestamocredito))


        Dim ds As New DataSet()
        Dim DA As New OleDbDataAdapter(comando)
        ''Fill= Método que Agrega filas al objeto DataSet y crea un objeto DataTable denominado "Tabla", en nuestro caso "Grupos".
        DA.Fill(ds, "Prestamos_Activos")
        ''Cierro la conexión
        dbconn.Close()
        Return ds
    End Function

    Public Function CobroPrestamosCreditos_alta(ByVal IdPrestamoCredito As Integer,
                                                ByVal Fecha As Date,
                                                ByVal Importe As Decimal) As DataSet
        Try
            dbconn.Open()
        Catch ex As Exception
        End Try

        Dim comando As New OleDbCommand("CobroPrestamosCreditos_alta", dbconn)
        comando.CommandType = CommandType.StoredProcedure
        comando.Parameters.Add(New OleDb.OleDbParameter("@IdPrestamoCredito", IdPrestamoCredito))
        comando.Parameters.Add(New OleDb.OleDbParameter("@Fecha", Fecha))
        comando.Parameters.Add(New OleDb.OleDbParameter("@Importe", Importe))
        comando.Parameters.Add(New OleDb.OleDbParameter("@Cuota", CDec(0)))


        Dim ds As New DataSet()
        Dim DA As New OleDbDataAdapter(comando)
        ''Fill= Método que Agrega filas al objeto DataSet y crea un objeto DataTable denominado "Tabla", en nuestro caso "Grupos".
        DA.Fill(ds, "CobroPrestamosCreditos")
        ''Cierro la conexión
        dbconn.Close()
        Return ds
    End Function



#End Region

#Region "LIQUIDACION FINAL - PRESTAMOS MANUALES"
    Public Function CobroPrestamosCreditos_LiqObtener(ByVal Fecha As Date) As DataSet
        Try
            dbconn.Open()
        Catch ex As Exception
        End Try

        Dim comando As New OleDbCommand("CobroPrestamosCreditos_LiqObtener", dbconn)
        comando.CommandType = CommandType.StoredProcedure
        comando.Parameters.Add(New OleDb.OleDbParameter("@Fecha", Fecha))


        Dim ds As New DataSet()
        Dim DA As New OleDbDataAdapter(comando)
        ''Fill= Método que Agrega filas al objeto DataSet y crea un objeto DataTable denominado "Tabla", en nuestro caso "CobroPrestamos".
        DA.Fill(ds, "CobroPrestamos")
        ''Cierro la conexión
        dbconn.Close()
        Return ds
    End Function
    Public Function PrestamosCreditos_obtenerXid(ByVal Idprestamocredito As Integer) As DataSet
        Try
            dbconn.Open()
        Catch ex As Exception
        End Try
        Dim comando As New OleDbCommand("PrestamosCreditos_obtenerXid", dbconn)
        comando.CommandType = CommandType.StoredProcedure
        comando.Parameters.Add(New OleDb.OleDbParameter("@Idprestamocredito", Idprestamocredito))

        Dim ds As New DataSet()
        Dim DA As New OleDbDataAdapter(comando)
        ''Fill= Método que Agrega filas al objeto DataSet y crea un objeto DataTable denominado "Tabla", en nuestro caso "Grupos".
        DA.Fill(ds, "Prestamos")
        ''Cierro la conexión
        dbconn.Close()
        Return ds
    End Function

    Public Function PrestamosCreditos_ActualizarSaldo(ByVal Idprestamocredito As Integer, ByVal Saldo As Decimal, ByVal Estado_id As Integer) As DataSet
        Try
            dbconn.Open()
        Catch ex As Exception
        End Try

        Dim comando As New OleDbCommand("PrestamosCreditos_ActualizarSaldo", dbconn)
        comando.CommandType = CommandType.StoredProcedure
        comando.Parameters.Add(New OleDb.OleDbParameter("@Idprestamocredito", Idprestamocredito))
        comando.Parameters.Add(New OleDb.OleDbParameter("@Saldo", Saldo))
        comando.Parameters.Add(New OleDb.OleDbParameter("@Estado_id", Estado_id))


        Dim ds As New DataSet()
        Dim DA As New OleDbDataAdapter(comando)
        ''Fill= Método que Agrega filas al objeto DataSet y crea un objeto DataTable denominado "Tabla", en nuestro caso "PrestamosCreditos".
        DA.Fill(ds, "PrestamosCreditos")
        ''Cierro la conexión
        dbconn.Close()
        Return ds
    End Function

#End Region

#Region "LIQUIDACION FINAL - PRESTAMOS X COMISION"
    Public Function Prestamos_obtener_prestamosxcomision() As DataSet
        Try
            dbconn.Open()
        Catch ex As Exception
        End Try

        Dim comando As New OleDbCommand("Prestamos_obtener_prestamosxcomision", dbconn)
        comando.CommandType = CommandType.StoredProcedure
        'comando.Parameters.Add(New OleDb.OleDbParameter("@Fecha", Fecha))


        Dim ds As New DataSet()
        Dim DA As New OleDbDataAdapter(comando)
        ''Fill= Método que Agrega filas al objeto DataSet y crea un objeto DataTable denominado "Tabla", en nuestro caso "CobroPrestamos".
        DA.Fill(ds, "Prestamos")
        ''Cierro la conexión
        dbconn.Close()
        Return ds
    End Function
#End Region

#Region "LIQUIDACION FINAL - CREDITOS"
    Public Function Creditos_obtener() As DataSet
        Try
            dbconn.Open()
        Catch ex As Exception
        End Try

        Dim comando As New OleDbCommand("Creditos_obtener", dbconn)
        comando.CommandType = CommandType.StoredProcedure
        'comando.Parameters.Add(New OleDb.OleDbParameter("@Fecha", Fecha))


        Dim ds As New DataSet()
        Dim DA As New OleDbDataAdapter(comando)
        ''Fill= Método que Agrega filas al objeto DataSet y crea un objeto DataTable denominado "Tabla", en nuestro caso "CobroPrestamos".
        DA.Fill(ds, "Creditos")
        ''Cierro la conexión
        dbconn.Close()
        Return ds
    End Function

    Public Function CobroPrestamosCreditos_altaCredito(ByVal IdPrestamoCredito As Integer,
                                                ByVal Fecha As Date,
                                                ByVal Importe As Decimal, ByVal Cuota As Decimal) As DataSet
        Try
            dbconn.Open()
        Catch ex As Exception
        End Try

        Dim comando As New OleDbCommand("CobroPrestamosCreditos_alta", dbconn)
        comando.CommandType = CommandType.StoredProcedure
        comando.Parameters.Add(New OleDb.OleDbParameter("@IdPrestamoCredito", IdPrestamoCredito))
        comando.Parameters.Add(New OleDb.OleDbParameter("@Fecha", Fecha))
        comando.Parameters.Add(New OleDb.OleDbParameter("@Importe", Importe))
        comando.Parameters.Add(New OleDb.OleDbParameter("@Cuota", Cuota))


        Dim ds As New DataSet()
        Dim DA As New OleDbDataAdapter(comando)
        ''Fill= Método que Agrega filas al objeto DataSet y crea un objeto DataTable denominado "Tabla", en nuestro caso "Grupos".
        DA.Fill(ds, "CobroPrestamosCreditos")
        ''Cierro la conexión
        dbconn.Close()
        Return ds
    End Function

    Public Function CobroPrestamosCreditos_obtener_cuota(ByVal IdPrestamoCredito As Integer) As DataSet
        Try
            dbconn.Open()
        Catch ex As Exception
        End Try

        Dim comando As New OleDbCommand("CobroPrestamosCreditos_obtener_cuota", dbconn)
        comando.CommandType = CommandType.StoredProcedure
        comando.Parameters.Add(New OleDb.OleDbParameter("@IdPrestamoCredito", IdPrestamoCredito))



        Dim ds As New DataSet()
        Dim DA As New OleDbDataAdapter(comando)
        ''Fill= Método que Agrega filas al objeto DataSet y crea un objeto DataTable denominado "Tabla", en nuestro caso "Grupos".
        DA.Fill(ds, "CobroPrestamosCreditos")
        ''Cierro la conexión
        dbconn.Close()
        Return ds
    End Function

#End Region

#Region "COBRO PRESTAMOS X REGALO"
    Public Function Prestamos_obtener_prestamosxregalo() As DataSet
        Try
            dbconn.Open()
        Catch ex As Exception
        End Try

        Dim comando As New OleDbCommand("Prestamos_obtener_prestamosxregalo", dbconn)
        comando.CommandType = CommandType.StoredProcedure
        'comando.Parameters.Add(New OleDb.OleDbParameter("@IdPrestamoCredito", IdPrestamoCredito))

        Dim ds As New DataSet()
        Dim DA As New OleDbDataAdapter(comando)
        ''Fill= Método que Agrega filas al objeto DataSet y crea un objeto DataTable denominado "Tabla", en nuestro caso "Grupos".
        DA.Fill(ds, "PrestamosxRegalo")
        ''Cierro la conexión
        dbconn.Close()
        Return ds
    End Function


#End Region

End Class
