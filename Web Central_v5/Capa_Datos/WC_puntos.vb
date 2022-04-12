Imports System.Data.OleDb
Imports System.Data.DataRow
Public Class WC_puntos
    Inherits Capa_Datos.Conexion

    Public Function Puntos_alta(ByVal Idrecorrido As Integer,
                                ByVal Fecha As Date,
                                ByVal P1 As String,
                                ByVal P2 As String,
                                ByVal P3 As String,
                                ByVal P4 As String,
                                ByVal P5 As String,
                                ByVal P6 As String,
                                ByVal P7 As String,
                                ByVal P8 As String,
                                ByVal P9 As String,
                                ByVal P10 As String,
                                ByVal P11 As String,
                                ByVal P12 As String,
                                ByVal P13 As String,
                                ByVal P14 As String,
                                ByVal P15 As String,
                                ByVal P16 As String,
                                ByVal P17 As String,
                                ByVal P18 As String,
                                ByVal P19 As String,
                                ByVal P20 As String) As DataSet
        Try
            dbconn.Open()
        Catch ex As Exception
        End Try
        Dim comando As New OleDbCommand("Puntos_alta", dbconn)
        comando.CommandType = CommandType.StoredProcedure
        comando.Parameters.Add(New OleDb.OleDbParameter("@Idrecorrido", Idrecorrido))
        comando.Parameters.Add(New OleDb.OleDbParameter("@Fecha", Fecha))
        comando.Parameters.Add(New OleDb.OleDbParameter("@P1", P1))
        comando.Parameters.Add(New OleDb.OleDbParameter("@P2", P2))
        comando.Parameters.Add(New OleDb.OleDbParameter("@P3", P3))
        comando.Parameters.Add(New OleDb.OleDbParameter("@P4", P4))
        comando.Parameters.Add(New OleDb.OleDbParameter("@P5", P5))
        comando.Parameters.Add(New OleDb.OleDbParameter("@P6", P6))
        comando.Parameters.Add(New OleDb.OleDbParameter("@P7", P7))
        comando.Parameters.Add(New OleDb.OleDbParameter("@P8", P8))
        comando.Parameters.Add(New OleDb.OleDbParameter("@P9", P9))
        comando.Parameters.Add(New OleDb.OleDbParameter("@P10", P10))
        comando.Parameters.Add(New OleDb.OleDbParameter("@P11", P11))
        comando.Parameters.Add(New OleDb.OleDbParameter("@P12", P12))
        comando.Parameters.Add(New OleDb.OleDbParameter("@P13", P13))
        comando.Parameters.Add(New OleDb.OleDbParameter("@P14", P14))
        comando.Parameters.Add(New OleDb.OleDbParameter("@P15", P15))
        comando.Parameters.Add(New OleDb.OleDbParameter("@P16", P16))
        comando.Parameters.Add(New OleDb.OleDbParameter("@P17", P17))
        comando.Parameters.Add(New OleDb.OleDbParameter("@P18", P18))
        comando.Parameters.Add(New OleDb.OleDbParameter("@P19", P19))
        comando.Parameters.Add(New OleDb.OleDbParameter("@P20", P20))

        Dim ds As New DataSet()
        Dim DA As New OleDbDataAdapter(comando)
        ''Fill= Método que Agrega filas al objeto DataSet y crea un objeto DataTable denominado "Tabla", en nuestro caso "Grupos".
        DA.Fill(ds, "Puntos")
        ''Cierro la conexión
        dbconn.Close()
        Return ds
    End Function


    Public Function Puntos_modificar(ByVal Idrecorrido As Integer,
                                ByVal Fecha As Date,
                                ByVal P1 As String,
                                ByVal P2 As String,
                                ByVal P3 As String,
                                ByVal P4 As String,
                                ByVal P5 As String,
                                ByVal P6 As String,
                                ByVal P7 As String,
                                ByVal P8 As String,
                                ByVal P9 As String,
                                ByVal P10 As String,
                                ByVal P11 As String,
                                ByVal P12 As String,
                                ByVal P13 As String,
                                ByVal P14 As String,
                                ByVal P15 As String,
                                ByVal P16 As String,
                                ByVal P17 As String,
                                ByVal P18 As String,
                                ByVal P19 As String,
                                ByVal P20 As String) As DataSet
        Try
            dbconn.Open()
        Catch ex As Exception
        End Try
        Dim comando As New OleDbCommand("Puntos_modificar", dbconn)
        comando.CommandType = CommandType.StoredProcedure
        comando.Parameters.Add(New OleDb.OleDbParameter("@Idrecorrido", Idrecorrido))
        comando.Parameters.Add(New OleDb.OleDbParameter("@Fecha", Fecha))
        comando.Parameters.Add(New OleDb.OleDbParameter("@P1", P1))
        comando.Parameters.Add(New OleDb.OleDbParameter("@P2", P2))
        comando.Parameters.Add(New OleDb.OleDbParameter("@P3", P3))
        comando.Parameters.Add(New OleDb.OleDbParameter("@P4", P4))
        comando.Parameters.Add(New OleDb.OleDbParameter("@P5", P5))
        comando.Parameters.Add(New OleDb.OleDbParameter("@P6", P6))
        comando.Parameters.Add(New OleDb.OleDbParameter("@P7", P7))
        comando.Parameters.Add(New OleDb.OleDbParameter("@P8", P8))
        comando.Parameters.Add(New OleDb.OleDbParameter("@P9", P9))
        comando.Parameters.Add(New OleDb.OleDbParameter("@P10", P10))
        comando.Parameters.Add(New OleDb.OleDbParameter("@P11", P11))
        comando.Parameters.Add(New OleDb.OleDbParameter("@P12", P12))
        comando.Parameters.Add(New OleDb.OleDbParameter("@P13", P13))
        comando.Parameters.Add(New OleDb.OleDbParameter("@P14", P14))
        comando.Parameters.Add(New OleDb.OleDbParameter("@P15", P15))
        comando.Parameters.Add(New OleDb.OleDbParameter("@P16", P16))
        comando.Parameters.Add(New OleDb.OleDbParameter("@P17", P17))
        comando.Parameters.Add(New OleDb.OleDbParameter("@P18", P18))
        comando.Parameters.Add(New OleDb.OleDbParameter("@P19", P19))
        comando.Parameters.Add(New OleDb.OleDbParameter("@P20", P20))

        Dim ds As New DataSet()
        Dim DA As New OleDbDataAdapter(comando)
        ''Fill= Método que Agrega filas al objeto DataSet y crea un objeto DataTable denominado "Tabla", en nuestro caso "Grupos".
        DA.Fill(ds, "Puntos")
        ''Cierro la conexión
        dbconn.Close()
        Return ds
    End Function

    Public Function Puntos_obtener_cargados(ByVal Fecha As Date,
                                ByVal Dia_id As Integer,
                                ByVal Codigo As String) As DataSet
        Try
            dbconn.Open()
        Catch ex As Exception
        End Try
        Dim comando As New OleDbCommand("Puntos_obtener_cargados", dbconn)
        comando.CommandType = CommandType.StoredProcedure
        comando.Parameters.Add(New OleDb.OleDbParameter("@Fecha", Fecha))
        comando.Parameters.Add(New OleDb.OleDbParameter("@Dia_id", Dia_id))
        comando.Parameters.Add(New OleDb.OleDbParameter("@Codigo", Codigo))

        Dim ds As New DataSet()
        Dim DA As New OleDbDataAdapter(comando)
        ''Fill= Método que Agrega filas al objeto DataSet y crea un objeto DataTable denominado "Tabla", en nuestro caso "Grupos".
        DA.Fill(ds, "Puntos")
        ''Cierro la conexión
        dbconn.Close()
        Return ds
    End Function

End Class
