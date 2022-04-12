Imports System.Data.OleDb
Imports System.Data.DataRow
Public Class WB_usuarios
    Inherits Capa_Datos.Conexion

    Public Function Usuarios_ObtenerUsuario(ByVal Usuario As String, ByVal Contraseña As String) As DataSet
        Try
            dbconn.Open()
        Catch ex As Exception
        End Try
        Dim comando As New OleDbCommand("Usuarios_ObtenerUsuario", dbconn)
        comando.CommandType = CommandType.StoredProcedure
        comando.Parameters.Add(New OleDb.OleDbParameter("@Usuario", Usuario))
        comando.Parameters.Add(New OleDb.OleDbParameter("@Contraseña", Contraseña))

        Dim ds As New DataSet()
        Dim DA As New OleDbDataAdapter(comando)
        ''Fill= Método que Agrega filas al objeto DataSet y crea un objeto DataTable denominado "Tabla", en nuestro caso "Grupos".
        DA.Fill(ds, "Usuarios")
        ''Cierro la conexión
        dbconn.Close()
        Return ds
    End Function

End Class
