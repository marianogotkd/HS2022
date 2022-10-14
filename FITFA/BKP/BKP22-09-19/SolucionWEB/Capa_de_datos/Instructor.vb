Imports System.Data.OleDb
Imports System.Data.DataRow

Public Class Instructor
    Inherits Capa_de_datos.Conexion

    Public Function Instructor_obtener_instructores(ByVal usuario_id As Integer) As DataSet
        Try
            dbconn.Open()
        Catch ex As Exception
        End Try

        Dim comando As New OleDbCommand("Instructor_obtener_instructores", dbconn)
        comando.CommandType = CommandType.StoredProcedure

        Dim ds_usu As New DataSet()
        Dim da_usu As New OleDbDataAdapter(comando)
        comando.Parameters.Add(New OleDb.OleDbParameter("@usuario_id", usuario_id))

        da_usu.Fill(ds_usu, "Usuario")
        dbconn.Close()
        Return ds_usu
    End Function

    Public Function Instructor_obtener_alumnos(ByVal usuario_id As Integer) As DataSet
        Try
            dbconn.Open()
        Catch ex As Exception
        End Try

        Dim comando As New OleDbCommand("Instructor_obtener_alumnos", dbconn)
        comando.CommandType = CommandType.StoredProcedure

        Dim ds_usu As New DataSet()
        Dim da_usu As New OleDbDataAdapter(comando)
        comando.Parameters.Add(New OleDb.OleDbParameter("@usuario_id", usuario_id))

        da_usu.Fill(ds_usu, "Usuario")
        dbconn.Close()
        Return ds_usu
    End Function

    Public Function Instructor_obtener_solo_alumnos_INSTRUCTORES(ByVal usuario_id As Integer) As DataSet
        Try
            dbconn.Open()
        Catch ex As Exception
        End Try

        Dim comando As New OleDbCommand("Instructor_obtener_solo_alumnos_INSTRUCTORES", dbconn)
        comando.CommandType = CommandType.StoredProcedure

        Dim ds_usu As New DataSet()
        Dim da_usu As New OleDbDataAdapter(comando)
        comando.Parameters.Add(New OleDb.OleDbParameter("@usuario_id", usuario_id))

        da_usu.Fill(ds_usu, "Usuario")
        dbconn.Close()
        Return ds_usu
    End Function

    Public Function Instructor_buscar_alumno(ByVal usuario_id As Integer, ByVal alumno_dni As Integer) As DataSet
        Try
            dbconn.Open()
        Catch ex As Exception
        End Try

        Dim comando As New OleDbCommand("Instructor_buscar_alumno", dbconn)
        comando.CommandType = CommandType.StoredProcedure

        Dim ds_usu As New DataSet()
        Dim da_usu As New OleDbDataAdapter(comando)
        comando.Parameters.Add(New OleDb.OleDbParameter("@usuario_id", usuario_id))
        comando.Parameters.Add(New OleDb.OleDbParameter("@alumno_dni", alumno_dni))

        da_usu.Fill(ds_usu, "Usuario")
        dbconn.Close()
        Return ds_usu
    End Function

    Public Function Instructor_buscar_alumno_recursivo(ByVal usuario_id As Integer) As DataSet
        Try
            dbconn.Open()
        Catch ex As Exception
        End Try

        Dim comando As New OleDbCommand("Instructor_buscar_alumno_recursivo", dbconn)
        comando.CommandType = CommandType.StoredProcedure

        Dim ds_usu As New DataSet()
        Dim da_usu As New OleDbDataAdapter(comando)
        comando.Parameters.Add(New OleDb.OleDbParameter("@usuario_id", usuario_id))

        da_usu.Fill(ds_usu, "Usuario")
        dbconn.Close()
        Return ds_usu
    End Function


    Public Function Instructor_Buscar_Inscriptos(ByVal evento_id As Integer, ByVal usuario_id_Instructor As Integer) As DataSet
        Try
            dbconn.Open()
        Catch ex As Exception
        End Try

        Dim comando As New OleDbCommand("Instructor_Buscar_Inscriptos", dbconn)
        comando.CommandType = CommandType.StoredProcedure

        Dim ds_usu As New DataSet()
        Dim da_usu As New OleDbDataAdapter(comando)
        comando.Parameters.Add(New OleDb.OleDbParameter("@evento_id", evento_id))
        comando.Parameters.Add(New OleDb.OleDbParameter("@usuario_id_Instructor", usuario_id_Instructor))

        da_usu.Fill(ds_usu, "Usuario")
        dbconn.Close()
        Return ds_usu
    End Function

    Public Function Instructor_obtener_id(ByVal usuario_id As Integer) As DataSet
        Try
            dbconn.Open()
        Catch ex As Exception
        End Try

        Dim comando As New OleDbCommand("Instructor_obtener_id", dbconn)
        comando.CommandType = CommandType.StoredProcedure

        Dim ds_usu As New DataSet()
        Dim da_usu As New OleDbDataAdapter(comando)
        comando.Parameters.Add(New OleDb.OleDbParameter("@usuario_id", usuario_id))

        da_usu.Fill(ds_usu, "Usuario")
        dbconn.Close()
        Return ds_usu
    End Function


    Public Function Instructor_obtener_INFO(ByVal instructor_id As Integer) As DataSet
        Try
            dbconn.Open()
        Catch ex As Exception
        End Try

        Dim comando As New OleDbCommand("Instructor_obtener_INFO", dbconn)
        comando.CommandType = CommandType.StoredProcedure

        Dim ds_usu As New DataSet()
        Dim da_usu As New OleDbDataAdapter(comando)
        comando.Parameters.Add(New OleDb.OleDbParameter("@instructor_id", instructor_id))

        da_usu.Fill(ds_usu, "instructor")
        dbconn.Close()
        Return ds_usu
    End Function

    Public Function Instructor_Obtener_Mi_ID_de_Instructor(ByVal usuario_id As Integer) As DataSet
        Try
            dbconn.Open()
        Catch ex As Exception
        End Try

        Dim comando As New OleDbCommand("Instructor_Obtener_Mi_ID_de_Instructor", dbconn)
        comando.CommandType = CommandType.StoredProcedure

        Dim ds_usu As New DataSet()
        Dim da_usu As New OleDbDataAdapter(comando)
        comando.Parameters.Add(New OleDb.OleDbParameter("@usuario_id", usuario_id))

        da_usu.Fill(ds_usu, "instructor")
        dbconn.Close()
        Return ds_usu
    End Function

    Public Function instructor_modificar_porcentaje(ByVal instructor_id As Integer, ByVal instructor_porcentaje As Decimal) As DataSet
        Try
            dbconn.Open()
        Catch ex As Exception
        End Try

        Dim comando As New OleDbCommand("instructor_modificar_porcentaje", dbconn)
        comando.CommandType = CommandType.StoredProcedure

        Dim ds_usu As New DataSet()
        Dim da_usu As New OleDbDataAdapter(comando)
        comando.Parameters.Add(New OleDb.OleDbParameter("@instructor_id", instructor_id))
        comando.Parameters.Add(New OleDb.OleDbParameter("@instructor_porcentaje", instructor_porcentaje))

        da_usu.Fill(ds_usu, "instructor")
        dbconn.Close()
        Return ds_usu
    End Function


    Public Function Instructor_obtener_invitado() As DataSet
        Try
            dbconn.Open()
        Catch ex As Exception
        End Try

        Dim comando As New OleDbCommand("Instructor_obtener_invitado", dbconn)
        comando.CommandType = CommandType.StoredProcedure

        Dim ds_usu As New DataSet()
        Dim da_usu As New OleDbDataAdapter(comando)
        'comando.Parameters.Add(New OleDb.OleDbParameter("@usuario_id", usuario_id))

        da_usu.Fill(ds_usu, "Usuario")
        dbconn.Close()
        Return ds_usu
    End Function

    Public Function Instructor_obtener_institucion_id(ByVal instructor_id As Integer) As DataSet
        Try
            dbconn.Open()
        Catch ex As Exception
        End Try

        Dim comando As New OleDbCommand("Instructor_obtener_institucion_id", dbconn)
        comando.CommandType = CommandType.StoredProcedure

        Dim ds_usu As New DataSet()
        Dim da_usu As New OleDbDataAdapter(comando)
        comando.Parameters.Add(New OleDb.OleDbParameter("@instructor_id", instructor_id))

        da_usu.Fill(ds_usu, "instructor")
        dbconn.Close()
        Return ds_usu
    End Function


End Class
