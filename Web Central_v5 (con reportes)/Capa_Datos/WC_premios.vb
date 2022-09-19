Imports System.Data.OleDb
Imports System.Data.DataRow
Public Class WC_premios
    Inherits Capa_Datos.Conexion

    Public Function Premios_altaOP1y2(ByVal Fecha As Date,
                                 ByVal Recorrido_codigo As String,
                                 ByVal Pid As String, ByVal Importe As Decimal, ByVal Suc As Integer, ByVal R As Integer,
                                 ByVal Sincomputo As Integer, ByVal Premio As Decimal, ByVal Numeroticket As String,
                                 ByVal Terminal As String, ByVal Cliente_Codigo As String) As DataSet
        Try
            dbconn.Open()
        Catch ex As Exception
        End Try
        Dim Pid2 = DBNull.Value
        Dim comando As New OleDbCommand("Premios_alta", dbconn)
        comando.CommandType = CommandType.StoredProcedure
        comando.Parameters.Add(New OleDb.OleDbParameter("@Fecha", Fecha))
        comando.Parameters.Add(New OleDb.OleDbParameter("@Recorrido_codigo", Recorrido_codigo))
        comando.Parameters.Add(New OleDb.OleDbParameter("@Pid", Pid))
        comando.Parameters.Add(New OleDb.OleDbParameter("@Importe", Importe))
        comando.Parameters.Add(New OleDb.OleDbParameter("@Suc", Suc))
        comando.Parameters.Add(New OleDb.OleDbParameter("@Pid2", DBNull.Value))
        comando.Parameters.Add(New OleDb.OleDbParameter("@Suc2", DBNull.Value))
        comando.Parameters.Add(New OleDb.OleDbParameter("@R", R))
        comando.Parameters.Add(New OleDb.OleDbParameter("@Sincomputo", Sincomputo))
        comando.Parameters.Add(New OleDb.OleDbParameter("@Premio", Premio))
        comando.Parameters.Add(New OleDb.OleDbParameter("@Numeroticket", Numeroticket))
        comando.Parameters.Add(New OleDb.OleDbParameter("@Terminal", Terminal))
        comando.Parameters.Add(New OleDb.OleDbParameter("@Cliente_Codigo", Cliente_Codigo))


        Dim ds As New DataSet()
        Dim DA As New OleDbDataAdapter(comando)
        ''Fill= Método que Agrega filas al objeto DataSet y crea un objeto DataTable denominado "Tabla", en nuestro caso "Premios".
        DA.Fill(ds, "Premios")
        ''Cierro la conexión
        dbconn.Close()
        Return ds
    End Function
    Public Function Premios_altaOP3y4(ByVal Fecha As Date,
                             ByVal Recorrido_codigo As String,
                             ByVal Pid As String, ByVal Importe As Decimal, ByVal Suc As Integer,
                             ByVal Pid2 As String, ByVal Suc2 As Integer, ByVal R As Integer,
                             ByVal Sincomputo As Integer, ByVal Premio As Decimal, ByVal Numeroticket As String,
                             ByVal Terminal As String, ByVal Cliente_Codigo As String) As DataSet
        Try
            dbconn.Open()
        Catch ex As Exception
        End Try
        Dim comando As New OleDbCommand("Premios_alta", dbconn)
        comando.CommandType = CommandType.StoredProcedure
        comando.Parameters.Add(New OleDb.OleDbParameter("@Fecha", Fecha))
        comando.Parameters.Add(New OleDb.OleDbParameter("@Recorrido_codigo", Recorrido_codigo))
        comando.Parameters.Add(New OleDb.OleDbParameter("@Pid", Pid))
        comando.Parameters.Add(New OleDb.OleDbParameter("@Importe", Importe))
        comando.Parameters.Add(New OleDb.OleDbParameter("@Suc", Suc))
        comando.Parameters.Add(New OleDb.OleDbParameter("@Pid2", Pid2))
        comando.Parameters.Add(New OleDb.OleDbParameter("@Suc2", Suc2))
        comando.Parameters.Add(New OleDb.OleDbParameter("@R", R))
        comando.Parameters.Add(New OleDb.OleDbParameter("@Sincomputo", Sincomputo))
        comando.Parameters.Add(New OleDb.OleDbParameter("@Premio", Premio))
        comando.Parameters.Add(New OleDb.OleDbParameter("@Numeroticket", Numeroticket))
        comando.Parameters.Add(New OleDb.OleDbParameter("@Terminal", Terminal))
        comando.Parameters.Add(New OleDb.OleDbParameter("@Cliente_Codigo", Cliente_Codigo))


        Dim ds As New DataSet()
        Dim DA As New OleDbDataAdapter(comando)
        ''Fill= Método que Agrega filas al objeto DataSet y crea un objeto DataTable denominado "Tabla", en nuestro caso "Premios".
        DA.Fill(ds, "Premios")
        ''Cierro la conexión
        dbconn.Close()
        Return ds
    End Function


    Public Function Premios_ClienteobtenerXfecha(ByVal Fecha As Date, ByVal Cliente_Codigo As String) As DataSet
        Try
            dbconn.Open()
        Catch ex As Exception
        End Try
        Dim comando As New OleDbCommand("Premios_ClienteobtenerXfecha", dbconn)
        comando.CommandType = CommandType.StoredProcedure
        comando.Parameters.Add(New OleDb.OleDbParameter("@Fecha", Fecha))
        comando.Parameters.Add(New OleDb.OleDbParameter("@Cliente_Codigo", Cliente_Codigo))

        Dim ds As New DataSet()
        Dim DA As New OleDbDataAdapter(comando)
        ''Fill= Método que Agrega filas al objeto DataSet y crea un objeto DataTable denominado "Tabla", en nuestro caso "Premios".
        DA.Fill(ds, "Premios")
        ''Cierro la conexión
        dbconn.Close()
        Return ds
    End Function

End Class
