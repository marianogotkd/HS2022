Imports System.Data.OleDb
Imports System.Data.DataRow
Public Class WC_parametro
    Inherits Capa_Datos.Conexion

    Public Function Parametro_Iniciar_dia(ByVal Fecha As Date, ByVal Dia As Integer, ByVal Recorrido As String) As DataSet
        Try
            dbconn.Open()
        Catch ex As Exception
        End Try
        Dim comando As New OleDbCommand("Parametro_Iniciar_dia", dbconn)
        comando.CommandType = CommandType.StoredProcedure
        comando.Parameters.Add(New OleDb.OleDbParameter("@Fecha", Fecha))
        comando.Parameters.Add(New OleDb.OleDbParameter("@Dia", Dia))
        comando.Parameters.Add(New OleDb.OleDbParameter("@Recorrido", Recorrido))
        
        Dim ds As New DataSet()
        Dim DA As New OleDbDataAdapter(comando)
        ''Fill= Método que Agrega filas al objeto DataSet y crea un objeto DataTable denominado "Tabla", en nuestro caso "Grupos".
        DA.Fill(ds, "Parametro")
        ''Cierro la conexión
        dbconn.Close()
        Return ds
    End Function

    Public Function Parametro_modificar_dia(ByVal Parametro_id As Integer, ByVal Fecha As Date, ByVal Dia As Integer, ByVal Recorrido As String) As DataSet
        Try
            dbconn.Open()
        Catch ex As Exception
        End Try
        Dim comando As New OleDbCommand("Parametro_modificar_dia", dbconn)
        comando.CommandType = CommandType.StoredProcedure
        comando.Parameters.Add(New OleDb.OleDbParameter("@Parametro_id", Parametro_id))
        comando.Parameters.Add(New OleDb.OleDbParameter("@Fecha", Fecha))
        comando.Parameters.Add(New OleDb.OleDbParameter("@Dia", Dia))
        comando.Parameters.Add(New OleDb.OleDbParameter("@Recorrido", Recorrido))

        Dim ds As New DataSet()
        Dim DA As New OleDbDataAdapter(comando)
        ''Fill= Método que Agrega filas al objeto DataSet y crea un objeto DataTable denominado "Tabla", en nuestro caso "Grupos".
        DA.Fill(ds, "Parametro")
        ''Cierro la conexión
        dbconn.Close()
        Return ds
    End Function




    Public Function Parametro_consultar_fecha(ByVal Fecha As Date) As DataSet
        Try
            dbconn.Open()
        Catch ex As Exception
        End Try
        Dim comando As New OleDbCommand("Parametro_consultar_fecha", dbconn)
        comando.CommandType = CommandType.StoredProcedure
        comando.Parameters.Add(New OleDb.OleDbParameter("@Fecha", Fecha))

        Dim ds As New DataSet()
        Dim DA As New OleDbDataAdapter(comando)
        ''Fill= Método que Agrega filas al objeto DataSet y crea un objeto DataTable denominado "Tabla", en nuestro caso "Grupos".
        DA.Fill(ds, "Parametro")
        ''Cierro la conexión
        dbconn.Close()
        Return ds
    End Function


    Public Function Parametro_obtener_dia() As DataSet
        Try
            dbconn.Open()
        Catch ex As Exception
        End Try
        Dim comando As New OleDbCommand("Parametro_obtener_dia", dbconn)
        comando.CommandType = CommandType.StoredProcedure
        'comando.Parameters.Add(New OleDb.OleDbParameter("@Fecha", Fecha))

        Dim ds As New DataSet()
        Dim DA As New OleDbDataAdapter(comando)
        ''Fill= Método que Agrega filas al objeto DataSet y crea un objeto DataTable denominado "Tabla", en nuestro caso "Grupos".
        DA.Fill(ds, "Parametro")
        ''Cierro la conexión
        dbconn.Close()
        Return ds
    End Function


End Class
