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

End Class