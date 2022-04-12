Imports System.Data.OleDb
Imports System.Data.DataRow
Public Class WC_grupos
    Inherits Capa_Datos.Conexion

    Public Function Grupos_alta(ByVal Nombre As String, ByVal Tipo As String,
                              ByVal Porcentaje As Decimal, ByVal Clienteporcentaje As Integer, ByVal Codigocobro As String, ByVal Fecha As Date, ByVal Saldo As Decimal, ByVal Saldoanterior As Decimal, ByVal Gastos As Decimal, ByVal Codigo As String, ByVal Importe As Decimal) As DataSet
        Try
            dbconn.Open()
        Catch ex As Exception
        End Try
        Dim comando As New OleDbCommand("Grupos_alta", dbconn)
        comando.CommandType = CommandType.StoredProcedure
        comando.Parameters.Add(New OleDb.OleDbParameter("@Nombre", Nombre))
        comando.Parameters.Add(New OleDb.OleDbParameter("@Tipo", Tipo))
        comando.Parameters.Add(New OleDb.OleDbParameter("@Porcentaje", Porcentaje))
        comando.Parameters.Add(New OleDb.OleDbParameter("@Clienteporcentaje", Clienteporcentaje))
        comando.Parameters.Add(New OleDb.OleDbParameter("@Codigocobro", Codigocobro))
        comando.Parameters.Add(New OleDb.OleDbParameter("@Fecha", Fecha))
        comando.Parameters.Add(New OleDb.OleDbParameter("@Saldo", Saldo))
        comando.Parameters.Add(New OleDb.OleDbParameter("@Saldoanterior", Saldoanterior))
        comando.Parameters.Add(New OleDb.OleDbParameter("@Gastos", Gastos))
        comando.Parameters.Add(New OleDb.OleDbParameter("@Codigo", Codigo))
        comando.Parameters.Add(New OleDb.OleDbParameter("@Importe", Importe))
        Dim ds As New DataSet()
        Dim DA As New OleDbDataAdapter(comando)
        ''Fill= Método que Agrega filas al objeto DataSet y crea un objeto DataTable denominado "Tabla", en nuestro caso "Grupos".
        DA.Fill(ds, "Grupos")
        ''Cierro la conexión
        dbconn.Close()
        Return ds
    End Function

    Public Function Grupos_modificar(ByVal Grupo_id As Integer, ByVal Nombre As String, ByVal Tipo As String,
                              ByVal Porcentaje As Decimal, ByVal Clienteporcentaje As Integer, ByVal Codigocobro As String, ByVal Fecha As Date,
                              ByVal Codigo As String, ByVal Importe As Decimal) As DataSet
        Try
            dbconn.Open()
        Catch ex As Exception
        End Try
        Dim comando As New OleDbCommand("Grupos_modificar", dbconn)
        comando.CommandType = CommandType.StoredProcedure
        comando.Parameters.Add(New OleDb.OleDbParameter("@Grupo_id", Grupo_id))
        comando.Parameters.Add(New OleDb.OleDbParameter("@Nombre", Nombre))
        comando.Parameters.Add(New OleDb.OleDbParameter("@Tipo", Tipo))
        comando.Parameters.Add(New OleDb.OleDbParameter("@Porcentaje", Porcentaje))
        comando.Parameters.Add(New OleDb.OleDbParameter("@Clienteporcentaje", Clienteporcentaje))
        comando.Parameters.Add(New OleDb.OleDbParameter("@Codigocobro", Codigocobro))
        comando.Parameters.Add(New OleDb.OleDbParameter("@Fecha", Fecha))
        comando.Parameters.Add(New OleDb.OleDbParameter("@Codigo", Codigo))
        comando.Parameters.Add(New OleDb.OleDbParameter("@Importe", Importe))

        Dim ds As New DataSet()
        Dim DA As New OleDbDataAdapter(comando)
        ''Fill= Método que Agrega filas al objeto DataSet y crea un objeto DataTable denominado "Tabla", en nuestro caso "Grupos".
        DA.Fill(ds, "Grupos")
        ''Cierro la conexión
        dbconn.Close()
        Return ds
    End Function

    Public Function Grupos_baja(ByVal Grupo_id As Integer) As DataSet
        Try
            dbconn.Open()
        Catch ex As Exception
        End Try
        Dim comando As New OleDbCommand("Grupos_baja", dbconn)
        comando.CommandType = CommandType.StoredProcedure
        comando.Parameters.Add(New OleDb.OleDbParameter("@Grupo_id", Grupo_id))

        Dim ds As New DataSet()
        Dim DA As New OleDbDataAdapter(comando)
        ''Fill= Método que Agrega filas al objeto DataSet y crea un objeto DataTable denominado "Tabla", en nuestro caso "Grupos".
        DA.Fill(ds, "Grupos")
        ''Cierro la conexión
        dbconn.Close()
        Return ds
    End Function

    Public Function Grupos_buscar(ByVal Nombre As String, ByVal Codigo As String) As DataSet
        Try
            dbconn.Open()
        Catch ex As Exception
        End Try
        Dim comando As New OleDbCommand("Grupos_buscar", dbconn)
        comando.CommandType = CommandType.StoredProcedure
        comando.Parameters.Add(New OleDb.OleDbParameter("@Nombre", Nombre))
        comando.Parameters.Add(New OleDb.OleDbParameter("@Codigo", Codigo))

        Dim ds As New DataSet()
        Dim DA As New OleDbDataAdapter(comando)
        ''Fill= Método que Agrega filas al objeto DataSet y crea un objeto DataTable denominado "Tabla", en nuestro caso "Grupos".
        DA.Fill(ds, "Grupos")
        ''Cierro la conexión
        dbconn.Close()
        Return ds
    End Function

    Public Function Grupos_buscar_codigo(ByVal Codigo As String) As DataSet
        Try
            dbconn.Open()
        Catch ex As Exception
        End Try
        Dim comando As New OleDbCommand("Grupos_buscar_codigo", dbconn)
        comando.CommandType = CommandType.StoredProcedure
        comando.Parameters.Add(New OleDb.OleDbParameter("@Codigo", Codigo))

        Dim ds As New DataSet()
        Dim DA As New OleDbDataAdapter(comando)
        ''Fill= Método que Agrega filas al objeto DataSet y crea un objeto DataTable denominado "Tabla", en nuestro caso "Grupos".
        DA.Fill(ds, "Grupos")
        ''Cierro la conexión
        dbconn.Close()
        Return ds
    End Function

    Public Function Grupos_obtenertodos() As DataSet
        Try
            dbconn.Open()
        Catch ex As Exception
        End Try
        Dim comando As New OleDbCommand("Grupos_obtenertodos", dbconn)
        comando.CommandType = CommandType.StoredProcedure
        'comando.Parameters.Add(New OleDb.OleDbParameter("@Nombre", Nombre))

        Dim ds As New DataSet()
        Dim DA As New OleDbDataAdapter(comando)
        ''Fill= Método que Agrega filas al objeto DataSet y crea un objeto DataTable denominado "Tabla", en nuestro caso "Grupos".
        DA.Fill(ds, "Grupos")
        ''Cierro la conexión
        dbconn.Close()
        Return ds
    End Function


    Public Function Grupos_obtener_clientes(ByVal Grupo_id As Integer) As DataSet
        Try
            dbconn.Open()
        Catch ex As Exception
        End Try
        Dim comando As New OleDbCommand("Grupos_obtener_clientes", dbconn)
        comando.CommandType = CommandType.StoredProcedure
        comando.Parameters.Add(New OleDb.OleDbParameter("@Grupo_id", Grupo_id))

        Dim ds As New DataSet()
        Dim DA As New OleDbDataAdapter(comando)
        ''Fill= Método que Agrega filas al objeto DataSet y crea un objeto DataTable denominado "Tabla", en nuestro caso "Grupos".
        DA.Fill(ds, "Grupos")
        ''Cierro la conexión
        dbconn.Close()
        Return ds
    End Function

End Class
