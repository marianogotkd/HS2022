Imports System.Data.OleDb
Imports System.Data.DataRow
Public Class Area
    Inherits Capa_de_datos.Conexion

    Public Function area_obtener_asignadas(ByVal evento_id As Integer, ByVal area_id As Integer) As DataSet
        Try
            dbconn.Open()
        Catch ex As Exception
        End Try
        Dim comando As New OleDbCommand("area_obtener_asignadas", dbconn)
        comando.CommandType = CommandType.StoredProcedure
        comando.Parameters.Add(New OleDb.OleDbParameter("@evento_id", evento_id))
        comando.Parameters.Add(New OleDb.OleDbParameter("@area_id", area_id))
        ' crear dataset que sirve de contenedor para todos los datatables
        ''el dataset es un contenedor, repositorio
        Dim ds As New DataSet() 'System.Data.DataSet()
        Dim DA As New OleDbDataAdapter(comando)
        ''Fill= Método que Agrega filas al objeto DataSet y crea un objeto DataTable denominado "Tabla", en nuestro caso "Producto".
        DA.Fill(ds, "area")
        ''Cierro la conexión
        dbconn.Close()
        ''Como toda función debe retornar al uso RETURN
        Return ds
    End Function


    'alta de area
    Public Function area_alta(ByVal area_descripcion As String, ByVal evento_id As Integer) As DataSet
        Try
            dbconn.Open()
        Catch ex As Exception
        End Try
        Dim comando As New OleDbCommand("area_alta", dbconn)
        comando.CommandType = CommandType.StoredProcedure
        comando.Parameters.Add(New OleDb.OleDbParameter("@area_descripcion", area_descripcion))
        comando.Parameters.Add(New OleDb.OleDbParameter("@evento_id", evento_id))
        Dim ds_usu As New DataSet()
        Dim da_usu As New OleDbDataAdapter(comando)
        da_usu.Fill(ds_usu, "Area")
        dbconn.Close()
        Return ds_usu
    End Function

End Class
