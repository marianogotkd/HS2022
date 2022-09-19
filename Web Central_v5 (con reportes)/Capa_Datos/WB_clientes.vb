Imports System.Data.OleDb
Imports System.Data.DataRow
Public Class WB_clientes
    Inherits Capa_Datos.Conexion
    'EDITADO 2022-13-04 CHOCO GIT WEB
    Public Function Clientes_alta(ByVal Nombre As String,
                                ByVal Grupo_id As Integer,
                                ByVal Comision As Decimal,
                                ByVal Regalo As Decimal,
                                ByVal Comision1 As Decimal,
                                ByVal Regalo1 As Decimal,
                                ByVal Proceso As String,
                                ByVal Sincalculo As Integer,
                                ByVal Factor As Integer,
                                ByVal Imprime As Integer,
                                ByVal Recorrido As String,
                                ByVal Orden As String,
                                ByVal Variable As Integer,
                                ByVal Leyenda As String,
                                ByVal Variable1 As Integer,
                                ByVal Leyenda1 As String,
                                ByVal Leyenda2 As String,
                                ByVal Cantidadpc As String,
                                ByVal Saldo As Decimal,
                                ByVal Saldoanterior As Decimal,
                                ByVal Codigo As String,
                                ByVal SaldoRegalo As Decimal) As DataSet
        Try
            dbconn.Open()
        Catch ex As Exception
        End Try
        Dim comando As New OleDbCommand("Clientes_alta", dbconn)
        comando.CommandType = CommandType.StoredProcedure
        comando.Parameters.Add(New OleDb.OleDbParameter("@Nombre", Nombre))
        comando.Parameters.Add(New OleDb.OleDbParameter("@Grupo_id", Grupo_id))
        comando.Parameters.Add(New OleDb.OleDbParameter("@Comision", Comision))
        comando.Parameters.Add(New OleDb.OleDbParameter("@Regalo", Regalo))
        comando.Parameters.Add(New OleDb.OleDbParameter("@Comision1", Comision1))
        comando.Parameters.Add(New OleDb.OleDbParameter("@Regalo1", Regalo1))
        comando.Parameters.Add(New OleDb.OleDbParameter("@Proceso", Proceso))
        comando.Parameters.Add(New OleDb.OleDbParameter("@Sincalculo", Sincalculo))
        comando.Parameters.Add(New OleDb.OleDbParameter("@Factor", Factor))
        comando.Parameters.Add(New OleDb.OleDbParameter("@Imprime", Imprime))
        comando.Parameters.Add(New OleDb.OleDbParameter("@Recorrido", Recorrido))
        comando.Parameters.Add(New OleDb.OleDbParameter("@Orden", Orden))
        comando.Parameters.Add(New OleDb.OleDbParameter("@Variable", Variable))
        comando.Parameters.Add(New OleDb.OleDbParameter("@Leyenda", Leyenda))
        comando.Parameters.Add(New OleDb.OleDbParameter("@Variable1", Variable1))
        comando.Parameters.Add(New OleDb.OleDbParameter("@Leyenda1", Leyenda1))
        comando.Parameters.Add(New OleDb.OleDbParameter("@Leyenda2", Leyenda2))
        comando.Parameters.Add(New OleDb.OleDbParameter("@Cantidadpc", Cantidadpc))
        comando.Parameters.Add(New OleDb.OleDbParameter("@Saldo", Saldo))
        comando.Parameters.Add(New OleDb.OleDbParameter("@Saldoanterior", Saldoanterior))
        comando.Parameters.Add(New OleDb.OleDbParameter("@Codigo", Codigo))
        comando.Parameters.Add(New OleDb.OleDbParameter("@SaldoRegalo", SaldoRegalo))
        Dim ds As New DataSet()
        Dim DA As New OleDbDataAdapter(comando)
        ''Fill= Método que Agrega filas al objeto DataSet y crea un objeto DataTable denominado "Tabla", en nuestro caso "Grupos".
        DA.Fill(ds, "Clientes")
        ''Cierro la conexión
        dbconn.Close()
        Return ds
    End Function

    
    Public Function Clientes_buscar_codigo(ByVal Codigo As String) As DataSet
        Try
            dbconn.Open()
        Catch ex As Exception
        End Try
        Dim comando As New OleDbCommand("Clientes_buscar_codigo", dbconn)
        comando.CommandType = CommandType.StoredProcedure
        comando.Parameters.Add(New OleDb.OleDbParameter("@Codigo", Codigo))

        Dim ds As New DataSet()
        Dim DA As New OleDbDataAdapter(comando)
        ''Fill= Método que Agrega filas al objeto DataSet y crea un objeto DataTable denominado "Tabla", en nuestro caso "Grupos".
        DA.Fill(ds, "Clientes")
        ''Cierro la conexión
        dbconn.Close()
        Return ds
    End Function

    Public Function Clientes_buscar_id(ByVal Cliente_id As Integer) As DataSet
        Try
            dbconn.Open()
        Catch ex As Exception
        End Try
        Dim comando As New OleDbCommand("Clientes_buscar_id", dbconn)
        comando.CommandType = CommandType.StoredProcedure
        comando.Parameters.Add(New OleDb.OleDbParameter("@Cliente", Cliente_id))

        Dim ds As New DataSet()
        Dim DA As New OleDbDataAdapter(comando)
        ''Fill= Método que Agrega filas al objeto DataSet y crea un objeto DataTable denominado "Tabla", en nuestro caso "Grupos".
        DA.Fill(ds, "Clientes")
        ''Cierro la conexión
        dbconn.Close()
        Return ds
    End Function

    Public Function Clientes_modificar(ByVal Cliente_id As Integer, ByVal Nombre As String,
                                       ByVal Grupo_id As Integer,
                                ByVal Comision As Decimal,
                                ByVal Regalo As Decimal,
                                ByVal Comision1 As Decimal,
                                ByVal Regalo1 As Decimal,
                                ByVal Proceso As String,
                                ByVal Sincalculo As Integer,
                                ByVal Factor As Integer,
                                ByVal Imprime As Integer,
                                ByVal Recorrido As String,
                                ByVal Orden As String,
                                ByVal Variable As Integer,
                                ByVal Leyenda As String,
                                ByVal Variable1 As Integer,
                                ByVal Leyenda1 As String,
                                ByVal Leyenda2 As String,
                                ByVal Codigo As String) As DataSet
        'ByVal Cantidadpc As String) 
        'ByVal Saldo As Decimal,
        'ByVal Saldoanterior As Decimal) As DataSet
        Try
            dbconn.Open()
        Catch ex As Exception
        End Try
        Dim comando As New OleDbCommand("Clientes_modificar", dbconn)
        comando.CommandType = CommandType.StoredProcedure
        comando.Parameters.Add(New OleDb.OleDbParameter("@Cliente", Cliente_id))
        comando.Parameters.Add(New OleDb.OleDbParameter("@Nombre", Nombre))
        comando.Parameters.Add(New OleDb.OleDbParameter("@Grupo_id", Grupo_id))
        comando.Parameters.Add(New OleDb.OleDbParameter("@Comision", Comision))
        comando.Parameters.Add(New OleDb.OleDbParameter("@Regalo", Regalo))
        comando.Parameters.Add(New OleDb.OleDbParameter("@Comision1", Comision1))
        comando.Parameters.Add(New OleDb.OleDbParameter("@Regalo1", Regalo1))
        comando.Parameters.Add(New OleDb.OleDbParameter("@Proceso", Proceso))
        comando.Parameters.Add(New OleDb.OleDbParameter("@Sincalculo", Sincalculo))
        comando.Parameters.Add(New OleDb.OleDbParameter("@Factor", Factor))
        comando.Parameters.Add(New OleDb.OleDbParameter("@Imprime", Imprime))
        comando.Parameters.Add(New OleDb.OleDbParameter("@Recorrido", Recorrido))
        comando.Parameters.Add(New OleDb.OleDbParameter("@Orden", Orden))
        comando.Parameters.Add(New OleDb.OleDbParameter("@Variable", Variable))
        comando.Parameters.Add(New OleDb.OleDbParameter("@Leyenda", Leyenda))
        comando.Parameters.Add(New OleDb.OleDbParameter("@Variable1", Variable1))
        comando.Parameters.Add(New OleDb.OleDbParameter("@Leyenda1", Leyenda1))
        comando.Parameters.Add(New OleDb.OleDbParameter("@Leyenda2", Leyenda2))
        'comando.Parameters.Add(New OleDb.OleDbParameter("@Cantidadpc", Cantidadpc))
        'comando.Parameters.Add(New OleDb.OleDbParameter("@Saldo", Saldo))
        'comando.Parameters.Add(New OleDb.OleDbParameter("@Saldoanterior", Saldoanterior))
        comando.Parameters.Add(New OleDb.OleDbParameter("@Codigo", Codigo))
        Dim ds As New DataSet()
        Dim DA As New OleDbDataAdapter(comando)
        ''Fill= Método que Agrega filas al objeto DataSet y crea un objeto DataTable denominado "Tabla", en nuestro caso "Grupos".
        DA.Fill(ds, "Clientes")
        ''Cierro la conexión
        dbconn.Close()
        Return ds
    End Function

    Public Function Clientes_baja(ByVal Clientes_id As Integer) As DataSet
        Try
            dbconn.Open()
        Catch ex As Exception
        End Try
        Dim comando As New OleDbCommand("Clientes_baja", dbconn)
        comando.CommandType = CommandType.StoredProcedure
        comando.Parameters.Add(New OleDb.OleDbParameter("@Cliente", Clientes_id))

        Dim ds As New DataSet()
        Dim DA As New OleDbDataAdapter(comando)
        ''Fill= Método que Agrega filas al objeto DataSet y crea un objeto DataTable denominado "Tabla", en nuestro caso "Grupos".
        DA.Fill(ds, "Clientes")
        ''Cierro la conexión
        dbconn.Close()
        Return ds
    End Function

    Public Function Clientes_obtenertodos() As DataSet
        Try
            dbconn.Open()
        Catch ex As Exception
        End Try
        Dim comando As New OleDbCommand("Clientes_obtenertodos", dbconn)
        comando.CommandType = CommandType.StoredProcedure
        'comando.Parameters.Add(New OleDb.OleDbParameter("@Cliente", Cliente_id))

        Dim ds As New DataSet()
        Dim DA As New OleDbDataAdapter(comando)
        ''Fill= Método que Agrega filas al objeto DataSet y crea un objeto DataTable denominado "Tabla", en nuestro caso "Grupos".
        DA.Fill(ds, "Clientes")
        ''Cierro la conexión
        dbconn.Close()
        Return ds
    End Function

    Public Function Clientes_modificar_saldos(ByVal Cliente As Integer, ByVal Saldo As Decimal, ByVal SaldoRegalo As Decimal) As DataSet
        'nota: MODIFICA SALDO Y SALDO REGALO
        Try
            dbconn.Open()
        Catch ex As Exception
        End Try
        Dim comando As New OleDbCommand("Clientes_modificar_saldos", dbconn)
        comando.CommandType = CommandType.StoredProcedure
        comando.Parameters.Add(New OleDb.OleDbParameter("@Cliente", Cliente))
        comando.Parameters.Add(New OleDb.OleDbParameter("@Saldo", Saldo))
        comando.Parameters.Add(New OleDb.OleDbParameter("@SaldoRegalo", SaldoRegalo))

        Dim ds As New DataSet()
        Dim DA As New OleDbDataAdapter(comando)
        ''Fill= Método que Agrega filas al objeto DataSet y crea un objeto DataTable denominado "Tabla", en nuestro caso "Grupos".
        DA.Fill(ds, "Clientes")
        ''Cierro la conexión
        dbconn.Close()
        Return ds
    End Function

    Public Function Clientes_ActualizarSaldo(ByVal Cliente_Codigo As String, ByVal Saldoanterior As Decimal, ByVal Saldo As Decimal) As DataSet
        'nota: modifica saldoanterior y saldo, es parte del proceso de liquidacion final.
        Try
            dbconn.Open()
        Catch ex As Exception
        End Try
        Dim comando As New OleDbCommand("Clientes_ActualizarSaldo", dbconn)
        comando.CommandType = CommandType.StoredProcedure
        comando.Parameters.Add(New OleDb.OleDbParameter("@Codigo", Cliente_Codigo))
        comando.Parameters.Add(New OleDb.OleDbParameter("@Saldoanterior", Saldoanterior))
        comando.Parameters.Add(New OleDb.OleDbParameter("@Saldo", Saldo))

        Dim ds As New DataSet()
        Dim DA As New OleDbDataAdapter(comando)
        ''Fill= Método que Agrega filas al objeto DataSet y crea un objeto DataTable denominado "Tabla", en nuestro caso "Clientes".
        DA.Fill(ds, "Clientes")
        ''Cierro la conexión
        dbconn.Close()
        Return ds
    End Function

    Public Function Clientes_ActualizarSaldoRegalo(ByVal Cliente_Codigo As String, ByVal SaldoRegalo As Decimal) As DataSet
        'nota: modifica saldoregalo, es parte del proceso de liquidacion final.
        Try
            dbconn.Open()
        Catch ex As Exception
        End Try
        Dim comando As New OleDbCommand("Clientes_ActualizarSaldoRegalo", dbconn)
        comando.CommandType = CommandType.StoredProcedure
        comando.Parameters.Add(New OleDb.OleDbParameter("@Codigo", Cliente_Codigo))
        comando.Parameters.Add(New OleDb.OleDbParameter("@SaldoRegalo", SaldoRegalo))


        Dim ds As New DataSet()
        Dim DA As New OleDbDataAdapter(comando)
        ''Fill= Método que Agrega filas al objeto DataSet y crea un objeto DataTable denominado "Tabla", en nuestro caso "Clientes".
        DA.Fill(ds, "Clientes")
        ''Cierro la conexión
        dbconn.Close()
        Return ds
    End Function

    Public Function Clientes_ActualizarFechaLiq(ByVal UltFechaLiq As Date) As DataSet

        Try
            dbconn.Open()
        Catch ex As Exception
        End Try
        Dim comando As New OleDbCommand("Clientes_ActualizarFechaLiq", dbconn)
        comando.CommandType = CommandType.StoredProcedure
        comando.Parameters.Add(New OleDb.OleDbParameter("@UltFechaLiq", UltFechaLiq))


        Dim ds As New DataSet()
        Dim DA As New OleDbDataAdapter(comando)
        ''Fill= Método que Agrega filas al objeto DataSet y crea un objeto DataTable denominado "Tabla", en nuestro caso "Clientes".
        DA.Fill(ds, "Clientes")
        ''Cierro la conexión
        dbconn.Close()
        Return ds
    End Function

    'nota: cliente.saldo = cliente.saldo+ctacte.cobprestamo
    Public Function Cliente_ActualizarSaldo_ctacte(ByVal Cliente As Integer, ByVal Importe As Decimal) As DataSet

        Try
            dbconn.Open()
        Catch ex As Exception
        End Try
        Dim comando As New OleDbCommand("Cliente_ActualizarSaldo_ctacte", dbconn)
        comando.CommandType = CommandType.StoredProcedure
        comando.Parameters.Add(New OleDb.OleDbParameter("@Cliente", Cliente))
        comando.Parameters.Add(New OleDb.OleDbParameter("@Importe", Importe))


        Dim ds As New DataSet()
        Dim DA As New OleDbDataAdapter(comando)
        ''Fill= Método que Agrega filas al objeto DataSet y crea un objeto DataTable denominado "Tabla", en nuestro caso "Clientes".
        DA.Fill(ds, "Clientes")
        ''Cierro la conexión
        dbconn.Close()
        Return ds
    End Function


    'nota: cliente.saldo = cliente.saldo+ctacte.cobcredito
    Public Function Cliente_ActualizarSaldo_ctacte2(ByVal Cliente As Integer, ByVal Importe As Decimal) As DataSet

        Try
            dbconn.Open()
        Catch ex As Exception
        End Try
        Dim comando As New OleDbCommand("Cliente_ActualizarSaldo_ctacte2", dbconn)
        comando.CommandType = CommandType.StoredProcedure
        comando.Parameters.Add(New OleDb.OleDbParameter("@Cliente", Cliente))
        comando.Parameters.Add(New OleDb.OleDbParameter("@Importe", Importe))


        Dim ds As New DataSet()
        Dim DA As New OleDbDataAdapter(comando)
        ''Fill= Método que Agrega filas al objeto DataSet y crea un objeto DataTable denominado "Tabla", en nuestro caso "Clientes".
        DA.Fill(ds, "Clientes")
        ''Cierro la conexión
        dbconn.Close()
        Return ds
    End Function



End Class
