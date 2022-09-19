Imports System.Data.OleDb
Imports System.Data.DataRow
Public Class Categoria
    Inherits Capa_de_datos.Conexion
    Public Function Categoria_obtener_info(ByVal categoria_id As Integer) As DataSet
        Try
            dbconn.Open()
        Catch ex As Exception
        End Try

        Dim comando As New OleDbCommand("Categoria_obtener_info", dbconn)
        comando.CommandType = CommandType.StoredProcedure

        Dim ds_usu As New DataSet()
        Dim da_usu As New OleDbDataAdapter(comando)
        comando.Parameters.Add(New OleDb.OleDbParameter("@categoria_id", categoria_id))

        da_usu.Fill(ds_usu, "Categoria")
        dbconn.Close()
        Return ds_usu
    End Function

    Public Function Categoria_buscar(ByVal categoria_sexo As String,
                                     ByVal categoria_tipo As String,
                                     ByVal categoria_gradinicial As String,
                                     ByVal categoria_gradfinal As String,
                                     ByVal categoria_edadinicial As String,
                                     ByVal categoria_edadfinal As String,
                                     ByVal categoria_peso_inicial As String,
                                     ByVal categoria_peso_Final As String) As DataSet
        Try
            dbconn.Open()
        Catch ex As Exception
        End Try

        Dim comando As New OleDbCommand("Categoria_buscar", dbconn)
        comando.CommandType = CommandType.StoredProcedure

        Dim ds_usu As New DataSet()
        Dim da_usu As New OleDbDataAdapter(comando)
        comando.Parameters.Add(New OleDb.OleDbParameter("@categoria_sexo", categoria_sexo))
        comando.Parameters.Add(New OleDb.OleDbParameter("@categoria_tipo", categoria_tipo))
        comando.Parameters.Add(New OleDb.OleDbParameter("@categoria_gradinicial", categoria_gradinicial))
        comando.Parameters.Add(New OleDb.OleDbParameter("@categoria_gradfinal", categoria_gradfinal))
        comando.Parameters.Add(New OleDb.OleDbParameter("@categoria_edadinicial", categoria_edadinicial))
        comando.Parameters.Add(New OleDb.OleDbParameter("@categoria_edadfinal", categoria_edadfinal))
        comando.Parameters.Add(New OleDb.OleDbParameter("@categoria_peso_inicial", categoria_peso_inicial))
        comando.Parameters.Add(New OleDb.OleDbParameter("@categoria_peso_Final", categoria_peso_Final))

        da_usu.Fill(ds_usu, "Categoria")
        dbconn.Close()
        Return ds_usu
    End Function


End Class
