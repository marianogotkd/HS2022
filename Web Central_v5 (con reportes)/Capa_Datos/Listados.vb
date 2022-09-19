Imports System.Data.OleDb
Imports System.Data.DataRow
Public Class Listados
    Inherits Capa_Datos.Conexion

    Public Function SaldosyRegalos_obtener(ByVal Fecha As Date) As DataSet
        Try
            dbconn.Open()
        Catch ex As Exception
        End Try
        Dim comando As New OleDbCommand("SaldosyRegalos_obtener", dbconn)
        comando.CommandType = CommandType.StoredProcedure
        comando.Parameters.Add(New OleDb.OleDbParameter("@Fecha", Fecha))

        Dim ds As New DataSet()
        Dim DA As New OleDbDataAdapter(comando)

        DA.Fill(ds, "Clientes")
        ''Cierro la conexión
        dbconn.Close()
        Return ds
    End Function

    Public Function Listado_ClientesGanan(ByVal Fecha As Date) As DataSet
        Try
            dbconn.Open()
        Catch ex As Exception
        End Try
        Dim comando As New OleDbCommand("Listado_ClientesGanan", dbconn)
        comando.CommandType = CommandType.StoredProcedure
        comando.Parameters.Add(New OleDb.OleDbParameter("@Fecha", Fecha))

        Dim ds As New DataSet()
        Dim DA As New OleDbDataAdapter(comando)

        DA.Fill(ds, "Clientes")
        ''Cierro la conexión
        dbconn.Close()
        Return ds
    End Function


End Class
