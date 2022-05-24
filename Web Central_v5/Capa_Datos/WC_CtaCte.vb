Imports System.Data.OleDb
Imports System.Data.DataRow
Public Class WC_CtaCte
    Inherits Capa_Datos.Conexion
    Public Function CtaCte_alta(ByVal Grupo_Id As Integer, ByVal Cliente_Codigo As Integer, ByVal Fecha As Date, ByVal SaldoAnterior As Decimal,
                                ByVal Recaudacion As Decimal, ByVal Comision As Decimal, ByVal Premios As Decimal, ByVal Reclamos As Decimal, ByVal DejoGano As Decimal,
                                ByVal RecaudacionSC As Decimal, ByVal ComisionSC As Decimal, ByVal PremiosSC As Decimal, ByVal ReclamosSC As Decimal, ByVal DejoGanoSC As Decimal,
                                ByVal RecaudacionB As Decimal, ByVal ComisionB As Decimal, ByVal PremiosB As Decimal, ByVal ReclamosB As Decimal, ByVal DejoGanoB As Decimal,
                                ByVal Cobros As Decimal, ByVal Pagos As Decimal) As DataSet
        Try
            dbconn.Open()
        Catch ex As Exception
        End Try
        Dim comando As New OleDbCommand("CtaCte_alta", dbconn)
        comando.CommandType = CommandType.StoredProcedure
        comando.Parameters.Add(New OleDb.OleDbParameter("@Grupo_Id", Grupo_Id))
        comando.Parameters.Add(New OleDb.OleDbParameter("@Codigo", Cliente_Codigo))
        comando.Parameters.Add(New OleDb.OleDbParameter("@Fecha", Fecha))
        comando.Parameters.Add(New OleDb.OleDbParameter("@SaldoAnterior", SaldoAnterior))

        comando.Parameters.Add(New OleDb.OleDbParameter("@Recaudacion", Recaudacion))
        comando.Parameters.Add(New OleDb.OleDbParameter("@Comision", Comision))
        comando.Parameters.Add(New OleDb.OleDbParameter("@Premios", Premios))
        comando.Parameters.Add(New OleDb.OleDbParameter("@Reclamos", Reclamos))
        comando.Parameters.Add(New OleDb.OleDbParameter("@DejoGano", DejoGano))

        comando.Parameters.Add(New OleDb.OleDbParameter("@RecaudacionSC", RecaudacionSC))
        comando.Parameters.Add(New OleDb.OleDbParameter("@ComisionSC", ComisionSC))
        comando.Parameters.Add(New OleDb.OleDbParameter("@PremiosSC", PremiosSC))
        comando.Parameters.Add(New OleDb.OleDbParameter("@ReclamosSC", ReclamosSC))
        comando.Parameters.Add(New OleDb.OleDbParameter("@DejoGanoSC", DejoGanoSC))

        comando.Parameters.Add(New OleDb.OleDbParameter("@RecaudacionB", RecaudacionB))
        comando.Parameters.Add(New OleDb.OleDbParameter("@ComisionB", ComisionB))
        comando.Parameters.Add(New OleDb.OleDbParameter("@PremiosB", PremiosB))
        comando.Parameters.Add(New OleDb.OleDbParameter("@ReclamosB", ReclamosB))
        comando.Parameters.Add(New OleDb.OleDbParameter("@DejoGanoB", DejoGanoB))

        comando.Parameters.Add(New OleDb.OleDbParameter("@Cobros", Cobros))
        comando.Parameters.Add(New OleDb.OleDbParameter("@Pagos", Pagos))

        comando.Parameters.Add(New OleDb.OleDbParameter("@Prestamo", CDec(0)))
        comando.Parameters.Add(New OleDb.OleDbParameter("@CobPrestamo", CDec(0)))
        comando.Parameters.Add(New OleDb.OleDbParameter("@Credito", CDec(0)))
        comando.Parameters.Add(New OleDb.OleDbParameter("@CobCredito", CDec(0)))
        comando.Parameters.Add(New OleDb.OleDbParameter("@Regalos", CDec(0)))

        Dim ds As New DataSet()
        Dim DA As New OleDbDataAdapter(comando)
        ''Fill= Método que Agrega filas al objeto DataSet y crea un objeto DataTable denominado "Tabla", en nuestro caso "Grupos".
        DA.Fill(ds, "CtaCte")
        ''Cierro la conexión
        dbconn.Close()
        Return ds
    End Function

    Public Function CtaCte_alta_2(ByVal Grupo_Id As Integer, ByVal Cliente_Codigo As Integer, ByVal Fecha As Date, ByVal CobPrestamo As Decimal) As DataSet
        Try
            dbconn.Open()
        Catch ex As Exception
        End Try
        Dim comando As New OleDbCommand("CtaCte_alta", dbconn)
        comando.CommandType = CommandType.StoredProcedure
        comando.Parameters.Add(New OleDb.OleDbParameter("@Grupo_Id", Grupo_Id))
        comando.Parameters.Add(New OleDb.OleDbParameter("@Codigo", Cliente_Codigo))
        comando.Parameters.Add(New OleDb.OleDbParameter("@Fecha", Fecha))
        comando.Parameters.Add(New OleDb.OleDbParameter("@SaldoAnterior", CDec(0)))

        comando.Parameters.Add(New OleDb.OleDbParameter("@Recaudacion", CDec(0)))
        comando.Parameters.Add(New OleDb.OleDbParameter("@Comision", CDec(0)))
        comando.Parameters.Add(New OleDb.OleDbParameter("@Premios", CDec(0)))
        comando.Parameters.Add(New OleDb.OleDbParameter("@Reclamos", CDec(0)))
        comando.Parameters.Add(New OleDb.OleDbParameter("@DejoGano", CDec(0)))

        comando.Parameters.Add(New OleDb.OleDbParameter("@RecaudacionSC", CDec(0)))
        comando.Parameters.Add(New OleDb.OleDbParameter("@ComisionSC", CDec(0)))
        comando.Parameters.Add(New OleDb.OleDbParameter("@PremiosSC", CDec(0)))
        comando.Parameters.Add(New OleDb.OleDbParameter("@ReclamosSC", CDec(0)))
        comando.Parameters.Add(New OleDb.OleDbParameter("@DejoGanoSC", CDec(0)))

        comando.Parameters.Add(New OleDb.OleDbParameter("@RecaudacionB", CDec(0)))
        comando.Parameters.Add(New OleDb.OleDbParameter("@ComisionB", CDec(0)))
        comando.Parameters.Add(New OleDb.OleDbParameter("@PremiosB", CDec(0)))
        comando.Parameters.Add(New OleDb.OleDbParameter("@ReclamosB", CDec(0)))
        comando.Parameters.Add(New OleDb.OleDbParameter("@DejoGanoB", CDec(0)))

        comando.Parameters.Add(New OleDb.OleDbParameter("@Cobros", CDec(0)))
        comando.Parameters.Add(New OleDb.OleDbParameter("@Pagos", CDec(0)))

        comando.Parameters.Add(New OleDb.OleDbParameter("@Prestamo", CDec(0)))
        comando.Parameters.Add(New OleDb.OleDbParameter("@CobPrestamo", CobPrestamo))
        comando.Parameters.Add(New OleDb.OleDbParameter("@Credito", CDec(0)))
        comando.Parameters.Add(New OleDb.OleDbParameter("@CobCredito", CDec(0)))
        comando.Parameters.Add(New OleDb.OleDbParameter("@Regalos", CDec(0)))

        Dim ds As New DataSet()
        Dim DA As New OleDbDataAdapter(comando)
        ''Fill= Método que Agrega filas al objeto DataSet y crea un objeto DataTable denominado "Tabla", en nuestro caso "Grupos".
        DA.Fill(ds, "CtaCte")
        ''Cierro la conexión
        dbconn.Close()
        Return ds
    End Function




    Public Function CtaCte_obtener(ByVal Codigo As Integer, ByVal Fecha As Date) As DataSet
        Try
            dbconn.Open()
        Catch ex As Exception
        End Try

        Dim comando As New OleDbCommand("CtaCte_obtener", dbconn)
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


    Public Function CtaCte_actualizarCobPrestamo(ByVal IdCtaCte As Integer, ByVal CobPrestamo As Decimal) As DataSet
        Try
            dbconn.Open()
        Catch ex As Exception
        End Try

        Dim comando As New OleDbCommand("CtaCte_actualizarCobPrestamo", dbconn)
        comando.CommandType = CommandType.StoredProcedure
        comando.Parameters.Add(New OleDb.OleDbParameter("@IdCtaCte", IdCtaCte))
        comando.Parameters.Add(New OleDb.OleDbParameter("@CobPrestamo", CobPrestamo))


        Dim ds As New DataSet()
        Dim DA As New OleDbDataAdapter(comando)
        ''Fill= Método que Agrega filas al objeto DataSet y crea un objeto DataTable denominado "Tabla", en nuestro caso "PrestamosCreditos".
        DA.Fill(ds, "CtaCte")
        ''Cierro la conexión
        dbconn.Close()
        Return ds
    End Function

    Public Function CtaCte_actualizarCobCredito(ByVal IdCtaCte As Integer, ByVal CobCredito As Decimal) As DataSet
        Try
            dbconn.Open()
        Catch ex As Exception
        End Try

        Dim comando As New OleDbCommand("CtaCte_actualizarCobCredito", dbconn)
        comando.CommandType = CommandType.StoredProcedure
        comando.Parameters.Add(New OleDb.OleDbParameter("@IdCtaCte", IdCtaCte))
        comando.Parameters.Add(New OleDb.OleDbParameter("@CobCredito", CobCredito))


        Dim ds As New DataSet()
        Dim DA As New OleDbDataAdapter(comando)
        ''Fill= Método que Agrega filas al objeto DataSet y crea un objeto DataTable denominado "Tabla", en nuestro caso "PrestamosCreditos".
        DA.Fill(ds, "CtaCte")
        ''Cierro la conexión
        dbconn.Close()
        Return ds
    End Function



End Class
