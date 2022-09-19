Imports System.Data.OleDb
Imports System.Data.DataRow
Public Class Instituciones
    Inherits Capa_de_datos.Conexion

    Public Function Instituciones_alta(ByVal provincia_id As Integer, ByVal institucion_descripcion As String, ByVal institucion_abreviacion As String, ByVal institucion_logo As Byte(), ByVal instructor_id As Integer) As DataSet
        Try
            dbconn.Open()
        Catch ex As Exception
        End Try

        Dim comando As New OleDbCommand("Institucion_alta", dbconn)
        comando.CommandType = CommandType.StoredProcedure

        comando.Parameters.Add(New OleDb.OleDbParameter("@provincia_id", provincia_id))
        comando.Parameters.Add(New OleDb.OleDbParameter("@institucion_descripcion", institucion_descripcion))
        comando.Parameters.Add(New OleDb.OleDbParameter("@institucion_abreviacion", institucion_abreviacion))
        comando.Parameters.Add(New OleDb.OleDbParameter("@institucion_logo", institucion_logo))
        comando.Parameters.Add(New OleDb.OleDbParameter("@instructor_id", instructor_id))

        Dim ds_JE As New DataSet()
        Dim da_JE As New OleDbDataAdapter(comando)
        da_JE.Fill(ds_JE, "Institucion")
        dbconn.Close()
        Return ds_JE
    End Function

    Public Function Instituciones_modificar_con_foto(ByVal institucion_id As Integer, ByVal provincia_id As Integer, ByVal institucion_descripcion As String, ByVal institucion_abreviacion As String, ByVal institucion_logo As Byte()) As DataSet
        Try
            dbconn.Open()
        Catch ex As Exception
        End Try

        Dim comando As New OleDbCommand("institucion_actualizar", dbconn)
        comando.CommandType = CommandType.StoredProcedure

        comando.Parameters.Add(New OleDb.OleDbParameter("@institucion_id", institucion_id))
        comando.Parameters.Add(New OleDb.OleDbParameter("@provincia_id", provincia_id))
        comando.Parameters.Add(New OleDb.OleDbParameter("@institucion_descripcion", institucion_descripcion))
        comando.Parameters.Add(New OleDb.OleDbParameter("@institucion_abreviacion", institucion_abreviacion))
        comando.Parameters.Add(New OleDb.OleDbParameter("@institucion_logo", institucion_logo))

        Dim ds_JE As New DataSet()
        Dim da_JE As New OleDbDataAdapter(comando)
        da_JE.Fill(ds_JE, "Institucion")
        dbconn.Close()
        Return ds_JE
    End Function


    Public Function Instituciones_modificar_sin_foto(ByVal institucion_id As Integer, ByVal provincia_id As Integer, ByVal institucion_descripcion As String, ByVal institucion_abreviacion As String) As DataSet
        Try
            dbconn.Open()
        Catch ex As Exception
        End Try

        Dim comando As New OleDbCommand("institucion_actualizar_sin_foto", dbconn)
        comando.CommandType = CommandType.StoredProcedure

        comando.Parameters.Add(New OleDb.OleDbParameter("@institucion_id", institucion_id))
        comando.Parameters.Add(New OleDb.OleDbParameter("@provincia_id", provincia_id))
        comando.Parameters.Add(New OleDb.OleDbParameter("@institucion_descripcion", institucion_descripcion))
        comando.Parameters.Add(New OleDb.OleDbParameter("@institucion_abreviacion", institucion_abreviacion))


        Dim ds_JE As New DataSet()
        Dim da_JE As New OleDbDataAdapter(comando)
        da_JE.Fill(ds_JE, "Institucion")
        dbconn.Close()
        Return ds_JE
    End Function

    Public Function Institucion_obtenertodo() As DataSet
        Try
            dbconn.Open()
        Catch ex As Exception
        End Try

        Dim comando As New OleDbCommand("Institucion_obtenertodo", dbconn)
        comando.CommandType = CommandType.StoredProcedure

        Dim ds_usu As New DataSet()
        Dim da_usu As New OleDbDataAdapter(comando)
        da_usu.Fill(ds_usu, "Institucion")
        dbconn.Close()
        Return ds_usu
    End Function



    Public Function Institucion_obtener_instructor_alumnos(ByVal institucion_id As Integer, ByVal instructor_id As Integer) As DataSet
        Try
            dbconn.Open()
        Catch ex As Exception
        End Try

        Dim comando As New OleDbCommand("Institucion_obtener_instructor_alumnos", dbconn)
        comando.CommandType = CommandType.StoredProcedure

        Dim ds_usu As New DataSet()
        Dim da_usu As New OleDbDataAdapter(comando)
        comando.Parameters.Add(New OleDb.OleDbParameter("@institucion_id", institucion_id))
        comando.Parameters.Add(New OleDb.OleDbParameter("@instructor_id", instructor_id))

        da_usu.Fill(ds_usu, "institucion")
        dbconn.Close()
        Return ds_usu
    End Function

    Public Function institucion_obtener_de_instructor(ByVal instructor_id As Integer) As DataSet
        Try
            dbconn.Open()
        Catch ex As Exception
        End Try

        Dim comando As New OleDbCommand("institucion_obtener_de_instructor", dbconn)
        comando.CommandType = CommandType.StoredProcedure

        Dim ds_usu As New DataSet()
        Dim da_usu As New OleDbDataAdapter(comando)
        comando.Parameters.Add(New OleDb.OleDbParameter("@instructor_id", instructor_id))

        da_usu.Fill(ds_usu, "Usuario")
        dbconn.Close()
        Return ds_usu
    End Function

    Public Function institucion_buscar(ByVal institucion_id As Integer) As DataSet
        Try
            dbconn.Open()
        Catch ex As Exception
        End Try

        Dim comando As New OleDbCommand("institucion_buscar", dbconn)
        comando.CommandType = CommandType.StoredProcedure

        Dim ds_usu As New DataSet()
        Dim da_usu As New OleDbDataAdapter(comando)
        comando.Parameters.Add(New OleDb.OleDbParameter("@institucion_id ", institucion_id))

        da_usu.Fill(ds_usu, "Usuario")
        dbconn.Close()
        Return ds_usu
    End Function

    Public Function institucion_instructores_obtenertodos() As DataSet
        Try
            dbconn.Open()
        Catch ex As Exception
        End Try

        Dim comando As New OleDbCommand("institucion_instructores_obtenertodos", dbconn)
        comando.CommandType = CommandType.StoredProcedure

        Dim ds_usu As New DataSet()
        Dim da_usu As New OleDbDataAdapter(comando)
        'comando.Parameters.Add(New OleDb.OleDbParameter("@institucion_id ", institucion_id))

        da_usu.Fill(ds_usu, "instructores")
        dbconn.Close()
        Return ds_usu

    End Function

    'institucion_asignar esta rutina la uso para asignar una institucion existente a un nuevo instructor
    Public Function Institucion_asignar(ByVal instructor_id As Integer, ByVal institucion_id As Integer) As DataSet
        Try
            dbconn.Open()
        Catch ex As Exception
        End Try
        Dim comando As New OleDbCommand("Institucion_asignar", dbconn)
        comando.CommandType = CommandType.StoredProcedure
        comando.Parameters.Add(New OleDb.OleDbParameter("@instructor_id", instructor_id))
        comando.Parameters.Add(New OleDb.OleDbParameter("@institucion_id", institucion_id))
        Dim ds_JE As New DataSet()
        Dim da_JE As New OleDbDataAdapter(comando)
        da_JE.Fill(ds_JE, "Institucion")
        dbconn.Close()
        Return ds_JE
    End Function

    Public Function Institucion_desvincular(ByVal instructor_id As Integer, ByVal institucion_id As Integer) As DataSet
        Try
            dbconn.Open()
        Catch ex As Exception
        End Try
        Dim comando As New OleDbCommand("Institucion_desvincular", dbconn)
        comando.CommandType = CommandType.StoredProcedure
        comando.Parameters.Add(New OleDb.OleDbParameter("@instructor_id", instructor_id))
        comando.Parameters.Add(New OleDb.OleDbParameter("@institucion_id", institucion_id))
        Dim ds_JE As New DataSet()
        Dim da_JE As New OleDbDataAdapter(comando)
        da_JE.Fill(ds_JE, "Institucion")
        dbconn.Close()
        Return ds_JE
    End Function


End Class
