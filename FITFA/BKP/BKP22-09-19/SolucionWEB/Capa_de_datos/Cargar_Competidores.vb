Imports System.Data.OleDb
Imports System.Data.DataRow
Public Class Cargar_Competidores
    Inherits Capa_de_datos.Conexion
    Public Function Carga_Competidor_Obtener_Categorias(ByVal sexo As String, ByVal tipo As String) As DataSet
        Try
            dbconn.Open()
        Catch ex As Exception
        End Try
        Dim comando As New OleDbCommand("Carga_Competidor_Obtener_Categorias", dbconn)
        comando.CommandType = CommandType.StoredProcedure
        comando.Parameters.Add(New OleDb.OleDbParameter("@sexo", sexo))
        comando.Parameters.Add(New OleDb.OleDbParameter("@tipo", tipo))
        Dim ds_JE As New DataSet()
        Dim da_JE As New OleDbDataAdapter(comando)
        da_JE.Fill(ds_JE, "Usuario")
        dbconn.Close()
        Return ds_JE
    End Function

    Public Function Carga_Competidor_Guardar(ByVal usuario_apellido As String,
                                             ByVal usuario_nombre As String,
                                             ByVal instructor_id As Integer,
                                             ByVal institucion_id As Integer,
                                             ByVal evento_id As Integer,
                                             ByVal inscripcion_fechahora As Date,
                                             ByVal inscripcion_peso As Decimal,
                                             ByVal categoria_id As Integer) As DataSet
        Try
            dbconn.Open()
        Catch ex As Exception
        End Try
        Dim comando As New OleDbCommand("Carga_Competidor_Guardar", dbconn)
        comando.CommandType = CommandType.StoredProcedure
        comando.Parameters.Add(New OleDb.OleDbParameter("@usuario_apellido", usuario_apellido))
        comando.Parameters.Add(New OleDb.OleDbParameter("@usuario_nombre", usuario_nombre))
        comando.Parameters.Add(New OleDb.OleDbParameter("@instructor_id", instructor_id))
        comando.Parameters.Add(New OleDb.OleDbParameter("@institucion_id", institucion_id))
        comando.Parameters.Add(New OleDb.OleDbParameter("@evento_id", evento_id))
        comando.Parameters.Add(New OleDb.OleDbParameter("@inscripcion_fechahora", inscripcion_fechahora))
        comando.Parameters.Add(New OleDb.OleDbParameter("@inscripcion_peso", inscripcion_peso))
        comando.Parameters.Add(New OleDb.OleDbParameter("@categoria_id", categoria_id))
        Dim ds_JE As New DataSet()
        Dim da_JE As New OleDbDataAdapter(comando)
        da_JE.Fill(ds_JE, "Usuario")
        dbconn.Close()
        Return ds_JE
    End Function
End Class
