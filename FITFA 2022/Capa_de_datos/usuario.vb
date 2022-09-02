Imports System.Data.OleDb
Imports System.Data.DataRow
Public Class usuario
    Inherits Capa_de_datos.Conexion

    'USUARIO
    Public Function Usuario_Sesion(ByVal USU_usuario As String, ByVal USU_contr As String) As DataSet
        Try
            dbconn.Open()
        Catch ex As Exception
        End Try

        Dim comando As New OleDbCommand("Usuario_sesion", dbconn)
        comando.CommandType = CommandType.StoredProcedure

        comando.Parameters.Add(New OleDb.OleDbParameter("@USU_usuario", USU_usuario))
        comando.Parameters.Add(New OleDb.OleDbParameter("@USU_cont ", USU_contr))

        Dim ds_usu As New DataSet()
        Dim da_usu As New OleDbDataAdapter(comando)
        da_usu.Fill(ds_usu, "Usuario")
        dbconn.Close()
        Return ds_usu
    End Function


    'recuperar todas las provincias
    Public Function Usuario_ObtenerProvincias() As DataSet
        Try
            dbconn.Open()
        Catch ex As Exception
        End Try

        Dim comando As New OleDbCommand("Usuario_ObtenerProvincias", dbconn)
        comando.CommandType = CommandType.StoredProcedure

        Dim ds_usu As New DataSet()
        Dim da_usu As New OleDbDataAdapter(comando)
        da_usu.Fill(ds_usu, "Usuario")
        dbconn.Close()
        Return ds_usu
    End Function


    'recupero ciudades filtradas por provincia
    Public Function Usuario_filtrarciudades_x_Provincias(ByVal provincia_id As Integer) As DataSet
        Try
            dbconn.Open()
        Catch ex As Exception
        End Try

        Dim comando As New OleDbCommand("Usuario_filtrarciudades_x_Provincias", dbconn)
        comando.CommandType = CommandType.StoredProcedure

        Dim ds_usu As New DataSet()
        Dim da_usu As New OleDbDataAdapter(comando)
        comando.Parameters.Add(New OleDb.OleDbParameter("@provincia_id ", provincia_id))

        da_usu.Fill(ds_usu, "Usuario")
        dbconn.Close()
        Return ds_usu
    End Function



    'recuperar todas las graduaciones disponibles
    Public Function Usuario_ObtenerGraduaciones() As DataSet
        Try
            dbconn.Open()
        Catch ex As Exception
        End Try

        Dim comando As New OleDbCommand("Usuario_ObtenerGraduaciones", dbconn)
        comando.CommandType = CommandType.StoredProcedure

        Dim ds_usu As New DataSet()
        Dim da_usu As New OleDbDataAdapter(comando)
        da_usu.Fill(ds_usu, "Usuario")
        dbconn.Close()
        Return ds_usu
    End Function

    'recupero instituciones filtradas por provincia
    Public Function Usuario_ObtenerInstituciones_x_provincia(ByVal provincia_id As Integer) As DataSet
        Try
            dbconn.Open()
        Catch ex As Exception
        End Try

        Dim comando As New OleDbCommand("Usuario_ObtenerInstituciones_x_provincia", dbconn)
        comando.CommandType = CommandType.StoredProcedure

        Dim ds_usu As New DataSet()
        Dim da_usu As New OleDbDataAdapter(comando)
        comando.Parameters.Add(New OleDb.OleDbParameter("@provincia_id ", provincia_id))

        da_usu.Fill(ds_usu, "Usuario")
        dbconn.Close()
        Return ds_usu
    End Function



    'recupero instructores filtrados por institucion
    Public Function Usuario_ObtenerInstructor(ByVal institucion_id As Integer) As DataSet
        Try
            dbconn.Open()
        Catch ex As Exception
        End Try

        Dim comando As New OleDbCommand("Usuario_ObtenerInstructor", dbconn)
        comando.CommandType = CommandType.StoredProcedure

        Dim ds_usu As New DataSet()
        Dim da_usu As New OleDbDataAdapter(comando)
        comando.Parameters.Add(New OleDb.OleDbParameter("@institucion_id ", institucion_id))

        da_usu.Fill(ds_usu, "Usuario")
        dbconn.Close()
        Return ds_usu
    End Function




    'Usuario_alta
    Public Function Usuario_alta(ByVal usuario_foto As Byte(), ByVal usuario_apellido As String,
ByVal usuario_nombre As String,
ByVal tipodoc_id As Integer,
ByVal usuario_doc As Integer,
ByVal usuario_sexo As String,
ByVal usuario_nacionalidad As String,
ByVal estadocivil_id As Integer,
ByVal usuario_profesion As String,
ByVal usuario_fechanac As Date,
ByVal usuario_domicilio As String,
ByVal usuario_codigopostal As Integer,
ByVal provincia_id As Integer,
ByVal ciudad_id As Integer,
ByVal usuario_telefono As String,
ByVal usuario_mail As String,
ByVal graduacion_id As Integer,
ByVal usuario_password As String,
ByVal usuario_fecha_registro As DateTime,
ByVal instructor_id As Integer, ByVal usuario_tipo As String, ByVal usuario_usuario As String, ByVal institucion_id As Integer,
ByVal usuario_nrolibreta As String) As DataSet
        Try
            dbconn.Open()
        Catch ex As Exception
        End Try

        Dim comando As New OleDbCommand("Usuario_alta", dbconn)
        comando.CommandType = CommandType.StoredProcedure

        comando.Parameters.Add(New OleDb.OleDbParameter("@usuario_foto", usuario_foto))
        comando.Parameters.Add(New OleDb.OleDbParameter("@usuario_apellido", usuario_apellido))
        comando.Parameters.Add(New OleDb.OleDbParameter("@usuario_nombre", usuario_nombre))
        comando.Parameters.Add(New OleDb.OleDbParameter("@tipodoc_id", tipodoc_id))
        comando.Parameters.Add(New OleDb.OleDbParameter("@usuario_doc", usuario_doc))
        comando.Parameters.Add(New OleDb.OleDbParameter("@usuario_sexo", usuario_sexo))
        comando.Parameters.Add(New OleDb.OleDbParameter("@usuario_nacionalidad", usuario_nacionalidad))
        comando.Parameters.Add(New OleDb.OleDbParameter("@estadocivil_id", estadocivil_id))
        comando.Parameters.Add(New OleDb.OleDbParameter("@usuario_profesion", usuario_profesion))
        comando.Parameters.Add(New OleDb.OleDbParameter("@usuario_fechanac", usuario_fechanac))
        comando.Parameters.Add(New OleDb.OleDbParameter("@usuario_domicilio", usuario_domicilio))
        comando.Parameters.Add(New OleDb.OleDbParameter("@usuario_codigopostal", usuario_codigopostal))
        comando.Parameters.Add(New OleDb.OleDbParameter("@provincia_id", provincia_id))
        comando.Parameters.Add(New OleDb.OleDbParameter("@ciudad_id", ciudad_id))
        comando.Parameters.Add(New OleDb.OleDbParameter("@usuario_telefono", usuario_telefono))
        comando.Parameters.Add(New OleDb.OleDbParameter("@usuario_mail", usuario_mail))
        comando.Parameters.Add(New OleDb.OleDbParameter("@graduacion_id", graduacion_id))
        comando.Parameters.Add(New OleDb.OleDbParameter("@usuario_password", usuario_password))
        comando.Parameters.Add(New OleDb.OleDbParameter("@usuario_fecha_registro", usuario_fecha_registro))
        comando.Parameters.Add(New OleDb.OleDbParameter("@instructor_id", instructor_id))
        comando.Parameters.Add(New OleDb.OleDbParameter("@usuario_tipo", usuario_tipo))
        comando.Parameters.Add(New OleDb.OleDbParameter("@usuario_usuario", usuario_usuario))
        comando.Parameters.Add(New OleDb.OleDbParameter("@institucion_id", institucion_id))
        comando.Parameters.Add(New OleDb.OleDbParameter("@usuario_nrolibreta", usuario_nrolibreta))

        Dim ds_JE As New DataSet()
        Dim da_JE As New OleDbDataAdapter(comando)
        da_JE.Fill(ds_JE, "Usuario")
        dbconn.Close()
        Return ds_JE
    End Function


    Public Function Estado_civil_obtener() As DataSet
        Try
            dbconn.Open()
        Catch ex As Exception
        End Try

        Dim comando As New OleDbCommand("Estado_civil_obtener", dbconn)
        comando.CommandType = CommandType.StoredProcedure

        Dim ds_usu As New DataSet()
        Dim da_usu As New OleDbDataAdapter(comando)
        da_usu.Fill(ds_usu, "EstadoCivil")
        dbconn.Close()
        Return ds_usu
    End Function






    Public Function Mensaje_Nuevo_Registro(ByVal USU_usuario As String) As DataSet
        Try
            dbconn.Open()
        Catch ex As Exception
        End Try
        Dim comando As New OleDbCommand("Mensaje_Nuevo_Registro", dbconn)
        comando.CommandType = CommandType.StoredProcedure
        comando.Parameters.Add(New OleDb.OleDbParameter("@USU_usuario", USU_usuario))
        ' crear dataset que sirve de contenedor para todos los datatables
        ''el dataset es un contenedor, repositorio
        Dim ds As New DataSet() 'System.Data.DataSet()
        Dim DA As New OleDbDataAdapter(comando)
        ''Fill= Método que Agrega filas al objeto DataSet y crea un objeto DataTable denominado "Tabla", en nuestro caso "Producto".
        DA.Fill(ds, "USUARIOS")
        ''Cierro la conexión
        dbconn.Close()
        ''Como toda función debe retornar al uso RETURN
        Return ds
    End Function

    Public Function Solicitudes_Pendientes(ByVal Instructor_id As Integer) As DataSet
        Try
            dbconn.Open()
        Catch ex As Exception
        End Try
        Dim comando As New OleDbCommand("Solicitudes_Pendientes", dbconn)
        comando.CommandType = CommandType.StoredProcedure
        comando.Parameters.Add(New OleDb.OleDbParameter("@usuario_id", Instructor_id))
        ' crear dataset que sirve de contenedor para todos los datatables
        ''el dataset es un contenedor, repositorio
        Dim ds As New DataSet() 'System.Data.DataSet()
        Dim DA As New OleDbDataAdapter(comando)
        ''Fill= Método que Agrega filas al objeto DataSet y crea un objeto DataTable denominado "Tabla", en nuestro caso "Producto".
        DA.Fill(ds, "USUARIOS")
        ''Cierro la conexión
        dbconn.Close()
        ''Como toda función debe retornar al uso RETURN
        Return ds
    End Function

    Public Function Activar_Usuario(ByVal Usuario_id As Integer, ByVal Instructor_id As Integer, ByVal usuario_tipo As String, ByVal institucion_id As Integer) As DataSet
        Try
            dbconn.Open()
        Catch ex As Exception
        End Try

        Dim comando As New OleDbCommand("Activar_Usuario", dbconn)
        comando.CommandType = CommandType.StoredProcedure

        comando.Parameters.Add(New OleDb.OleDbParameter("@Usuario_id", Usuario_id))
        comando.Parameters.Add(New OleDb.OleDbParameter("@Instructor_id", Instructor_id))
        comando.Parameters.Add(New OleDb.OleDbParameter("@usuario_tipo", usuario_tipo))
        comando.Parameters.Add(New OleDb.OleDbParameter("@institucion_id", institucion_id))


        Dim ds_usu As New DataSet()
        Dim da_usu As New OleDbDataAdapter(comando)
        da_usu.Fill(ds_usu, "Usuario")
        dbconn.Close()
        Return ds_usu
    End Function

    Public Function Activar_InstructorInvitado(ByVal usuario_doc As Integer, ByVal Instructor_id As Integer, ByVal institucion_id As Integer) As DataSet
        Try
            dbconn.Open()
        Catch ex As Exception
        End Try

        Dim comando As New OleDbCommand("Activar_InstructorInvitado", dbconn)
        comando.CommandType = CommandType.StoredProcedure

        comando.Parameters.Add(New OleDb.OleDbParameter("@usuario_doc", usuario_doc))
        comando.Parameters.Add(New OleDb.OleDbParameter("@Instructor_id", Instructor_id))
        comando.Parameters.Add(New OleDb.OleDbParameter("@institucion_id", institucion_id))


        Dim ds_usu As New DataSet()
        Dim da_usu As New OleDbDataAdapter(comando)
        da_usu.Fill(ds_usu, "Usuario")
        dbconn.Close()
        Return ds_usu
    End Function




    Public Function Desactivar_Usuario(ByVal USU_id As Integer) As DataSet
        Try
            dbconn.Open()
        Catch ex As Exception
        End Try

        Dim comando As New OleDbCommand("Desactivar_Usuario", dbconn)
        comando.CommandType = CommandType.StoredProcedure

        comando.Parameters.Add(New OleDb.OleDbParameter("@Usuario_id", USU_id))

        Dim ds_usu As New DataSet()
        Dim da_usu As New OleDbDataAdapter(comando)
        da_usu.Fill(ds_usu, "Usuario")
        dbconn.Close()
        Return ds_usu
    End Function

    '16-05-2018 10:22 am
    Public Function Usuario_validar_registro(ByVal usuario As String, ByVal dni As Integer) As DataSet
        Try
            dbconn.Open()
        Catch ex As Exception
        End Try

        Dim comando As New OleDbCommand("Usuario_validar_registro", dbconn)
        comando.CommandType = CommandType.StoredProcedure

        comando.Parameters.Add(New OleDb.OleDbParameter("@Usuario_usuario", usuario))
        comando.Parameters.Add(New OleDb.OleDbParameter("@Usuario_doc", dni))

        Dim ds_usu As New DataSet()
        Dim da_usu As New OleDbDataAdapter(comando)
        da_usu.Fill(ds_usu, "Usuario")
        dbconn.Close()
        Return ds_usu
    End Function

    'Recupero los datos para actulizar los datos personales
    Public Function Datos_Personales_Obtener_Datos_Usuarios(ByVal Us_id As Integer) As DataSet
        Try
            dbconn.Open()
        Catch ex As Exception
        End Try

        Dim comando As New OleDbCommand("Datos_Personales_Obtener_Datos_Usuarios", dbconn)
        comando.CommandType = CommandType.StoredProcedure

        Dim ds_usu As New DataSet()
        Dim da_usu As New OleDbDataAdapter(comando)
        comando.Parameters.Add(New OleDb.OleDbParameter("@Us_id ", Us_id))

        da_usu.Fill(ds_usu, "Usuario")
        dbconn.Close()
        Return ds_usu
    End Function

    Public Function Datos_Personales_Validar_libreta(ByVal usuario_nrolibreta As String) As DataSet
        Try
            dbconn.Open()
        Catch ex As Exception
        End Try

        Dim comando As New OleDbCommand("Datos_Personales_Validar_libreta", dbconn)
        comando.CommandType = CommandType.StoredProcedure

        Dim ds_usu As New DataSet()
        Dim da_usu As New OleDbDataAdapter(comando)
        comando.Parameters.Add(New OleDb.OleDbParameter("@usuario_nrolibreta ", usuario_nrolibreta))

        da_usu.Fill(ds_usu, "Usuario")
        dbconn.Close()
        Return ds_usu
    End Function


    'Actualizo los campos en tabla usuarios
    Public Function Datos_Personales_Actualizar_Datos(
        ByVal usuario_id As Integer,
        ByVal usuario_nombre As String,
        ByVal usuario_apellido As String,
        ByVal usuario_fechanac As Date,
        ByVal usuario_nacionalidad As String,
        ByVal usuario_sexo As String,
        ByVal estadocivil_id As Integer,
        ByVal usuario_profesion As String,
        ByVal usuario_domicilio As String,
        ByVal usuario_codigopostal As Integer,
        ByVal provincia_id As Integer,
        ByVal ciudad_id As Integer,
        ByVal usuario_telefono As String,
        ByVal usuario_mail As String,
        ByVal usuario_nrolibreta As String,
        ByVal graduacion_id As Integer,
        ByVal usuario_usuario As String,
        ByVal usuario_password As String) As DataSet

        Try
            dbconn.Open()
        Catch ex As Exception
        End Try

        Dim comando As New OleDbCommand("Datos_Personales_Actualizar_Datos", dbconn)
        comando.CommandType = CommandType.StoredProcedure

        comando.Parameters.Add(New OleDb.OleDbParameter("@usuario_id", usuario_id))
        comando.Parameters.Add(New OleDb.OleDbParameter("@usuario_nombre", usuario_nombre))
        comando.Parameters.Add(New OleDb.OleDbParameter("@usuario_apellido", usuario_apellido))
        comando.Parameters.Add(New OleDb.OleDbParameter("@usuario_fechanac", usuario_fechanac))
        comando.Parameters.Add(New OleDb.OleDbParameter("@usuario_nacionalidad", usuario_nacionalidad))
        comando.Parameters.Add(New OleDb.OleDbParameter("@usuario_sexo", usuario_sexo))
        comando.Parameters.Add(New OleDb.OleDbParameter("@estadocivil_id", estadocivil_id))
        comando.Parameters.Add(New OleDb.OleDbParameter("@usuario_profesion", usuario_profesion))
        comando.Parameters.Add(New OleDb.OleDbParameter("@usuario_domicilio", usuario_domicilio))
        comando.Parameters.Add(New OleDb.OleDbParameter("@usuario_codigopostal", usuario_codigopostal))
        comando.Parameters.Add(New OleDb.OleDbParameter("@provincia_id", provincia_id))
        comando.Parameters.Add(New OleDb.OleDbParameter("@ciudad_id", ciudad_id))
        comando.Parameters.Add(New OleDb.OleDbParameter("@usuario_telefono", usuario_telefono))
        comando.Parameters.Add(New OleDb.OleDbParameter("@usuario_mail", usuario_mail))
        comando.Parameters.Add(New OleDb.OleDbParameter("@usuario_nrolibreta", usuario_nrolibreta))
        comando.Parameters.Add(New OleDb.OleDbParameter("@graduacion_id", graduacion_id))
        comando.Parameters.Add(New OleDb.OleDbParameter("@usuario_usuario", usuario_usuario))
        comando.Parameters.Add(New OleDb.OleDbParameter("@usuario_password", usuario_password))

        Dim ds_JE As New DataSet()
        Dim da_JE As New OleDbDataAdapter(comando)
        da_JE.Fill(ds_JE, "Usuario")
        dbconn.Close()
        Return ds_JE
    End Function



    Public Function Usuario_validar_contraseña(ByVal usuario_id As Integer, ByVal usuario_password As String) As DataSet
        Try
            dbconn.Open()
        Catch ex As Exception
        End Try

        Dim comando As New OleDbCommand("Usuario_validar_contraseña", dbconn)
        comando.CommandType = CommandType.StoredProcedure

        comando.Parameters.Add(New OleDb.OleDbParameter("@usuario_id", usuario_id))
        comando.Parameters.Add(New OleDb.OleDbParameter("@usuario_password", usuario_password))

        Dim ds_usu As New DataSet()
        Dim da_usu As New OleDbDataAdapter(comando)
        da_usu.Fill(ds_usu, "Usuario")
        dbconn.Close()
        Return ds_usu
    End Function

    Public Function Usuario_actualizar_contraseña(ByVal usuario_id As Integer, ByVal usuario_password As String) As DataSet

        Try
            dbconn.Open()
        Catch ex As Exception
        End Try

        Dim comando As New OleDbCommand("Usuario_actualizar_contraseña", dbconn)
        comando.CommandType = CommandType.StoredProcedure

        comando.Parameters.Add(New OleDb.OleDbParameter("@usuario_password", usuario_password))
        comando.Parameters.Add(New OleDb.OleDbParameter("@usuario_id", usuario_id))

        Dim ds_JE As New DataSet()
        Dim da_JE As New OleDbDataAdapter(comando)
        da_JE.Fill(ds_JE, "Usuario")
        dbconn.Close()
        Return ds_JE
    End Function


    Public Function Usuario_imagen_actualizar(ByVal usuario_id As Integer, ByVal usuario_imagen As Byte()) As DataSet

        Try
            dbconn.Open()
        Catch ex As Exception
        End Try

        Dim comando As New OleDbCommand("Usuario_imagen_actualizar", dbconn)
        comando.CommandType = CommandType.StoredProcedure

        comando.Parameters.Add(New OleDb.OleDbParameter("@usuario_id", usuario_id))
        comando.Parameters.Add(New OleDb.OleDbParameter("@usuario_imagen", usuario_imagen))

        Dim ds_JE As New DataSet()
        Dim da_JE As New OleDbDataAdapter(comando)
        da_JE.Fill(ds_JE, "Usuario")
        dbconn.Close()
        Return ds_JE
    End Function




    Public Function Miembros_obtener_datos_personales(ByVal usuario_id As Integer) As DataSet

        Try
            dbconn.Open()
        Catch ex As Exception
        End Try

        Dim comando As New OleDbCommand("Miembros_obtener_datos_personales", dbconn)
        comando.CommandType = CommandType.StoredProcedure

        comando.Parameters.Add(New OleDb.OleDbParameter("@usuario_id", usuario_id))

        Dim ds_JE As New DataSet()
        Dim da_JE As New OleDbDataAdapter(comando)
        da_JE.Fill(ds_JE, "Usuario")
        dbconn.Close()
        Return ds_JE
    End Function


    Public Function Usuario_validar_DNI(ByVal dni As Integer) As DataSet
        Try
            dbconn.Open()
        Catch ex As Exception
        End Try

        Dim comando As New OleDbCommand("Usuario_validar_DNI", dbconn)
        comando.CommandType = CommandType.StoredProcedure


        comando.Parameters.Add(New OleDb.OleDbParameter("@Usuario_doc", dni))

        Dim ds_usu As New DataSet()
        Dim da_usu As New OleDbDataAdapter(comando)
        da_usu.Fill(ds_usu, "Usuario_validar_DNI")
        dbconn.Close()
        Return ds_usu
    End Function

    Public Function alumuno_x_instructor_Actulizar(ByVal instructor_id As Integer, ByVal usuario_id As Integer) As DataSet

        Try
            dbconn.Open()
        Catch ex As Exception
        End Try

        Dim comando As New OleDbCommand("alumuno_x_instructor_Actulizar", dbconn)
        comando.CommandType = CommandType.StoredProcedure

        comando.Parameters.Add(New OleDb.OleDbParameter("@instructor_id", instructor_id))
        comando.Parameters.Add(New OleDb.OleDbParameter("@usuario_id", usuario_id))


        Dim ds_JE As New DataSet()
        Dim da_JE As New OleDbDataAdapter(comando)
        da_JE.Fill(ds_JE, "Usuario")
        dbconn.Close()
        Return ds_JE
    End Function


#Region "EXAMENES"
    Public Function Usuario_modificar_graduacion(ByVal usuario_id As Integer, ByVal graduacion_id As Integer) As DataSet
        Try
            dbconn.Open()
        Catch ex As Exception
        End Try

        Dim comando As New OleDbCommand("Usuario_modificar_graduacion", dbconn)
        comando.CommandType = CommandType.StoredProcedure


        comando.Parameters.Add(New OleDb.OleDbParameter("@usuario_id", usuario_id))
        comando.Parameters.Add(New OleDb.OleDbParameter("@graduacion_id", graduacion_id))

        Dim ds_usu As New DataSet()
        Dim da_usu As New OleDbDataAdapter(comando)
        da_usu.Fill(ds_usu, "Usuario")
        dbconn.Close()
        Return ds_usu
    End Function
#End Region




    'Usuario_alta Invitado , estado="invitado"
    Public Function Usuario_alta_invitado(ByVal usuario_foto As Byte(), ByVal usuario_apellido As String,
ByVal usuario_nombre As String,
ByVal tipodoc_id As Integer,
ByVal usuario_doc As Integer,
ByVal usuario_sexo As String,
ByVal usuario_nacionalidad As String,
ByVal estadocivil_id As Integer,
ByVal usuario_profesion As String,
ByVal usuario_fechanac As Date,
ByVal usuario_domicilio As String,
ByVal usuario_codigopostal As Integer,
ByVal provincia_id As Integer,
ByVal ciudad_id As Integer,
ByVal usuario_telefono As String,
ByVal usuario_mail As String,
ByVal graduacion_id As Integer,
ByVal usuario_password As String,
ByVal usuario_fecha_registro As DateTime,
ByVal instructor_id As Integer, ByVal usuario_tipo As String, ByVal usuario_usuario As String, ByVal institucion_id As Integer,
ByVal usuario_nrolibreta As String,
ByVal usuario_obs As String) As DataSet
        Try
            dbconn.Open()
        Catch ex As Exception
        End Try

        Dim comando As New OleDbCommand("Usuario_alta_invitado", dbconn)
        comando.CommandType = CommandType.StoredProcedure

        comando.Parameters.Add(New OleDb.OleDbParameter("@usuario_foto", usuario_foto))
        comando.Parameters.Add(New OleDb.OleDbParameter("@usuario_apellido", usuario_apellido))
        comando.Parameters.Add(New OleDb.OleDbParameter("@usuario_nombre", usuario_nombre))
        comando.Parameters.Add(New OleDb.OleDbParameter("@tipodoc_id", tipodoc_id))
        comando.Parameters.Add(New OleDb.OleDbParameter("@usuario_doc", usuario_doc))
        comando.Parameters.Add(New OleDb.OleDbParameter("@usuario_sexo", usuario_sexo))
        comando.Parameters.Add(New OleDb.OleDbParameter("@usuario_nacionalidad", usuario_nacionalidad))
        comando.Parameters.Add(New OleDb.OleDbParameter("@estadocivil_id", estadocivil_id))
        comando.Parameters.Add(New OleDb.OleDbParameter("@usuario_profesion", usuario_profesion))
        comando.Parameters.Add(New OleDb.OleDbParameter("@usuario_fechanac", usuario_fechanac))
        comando.Parameters.Add(New OleDb.OleDbParameter("@usuario_domicilio", usuario_domicilio))
        comando.Parameters.Add(New OleDb.OleDbParameter("@usuario_codigopostal", usuario_codigopostal))
        comando.Parameters.Add(New OleDb.OleDbParameter("@provincia_id", provincia_id))
        comando.Parameters.Add(New OleDb.OleDbParameter("@ciudad_id", ciudad_id))
        comando.Parameters.Add(New OleDb.OleDbParameter("@usuario_telefono", usuario_telefono))
        comando.Parameters.Add(New OleDb.OleDbParameter("@usuario_mail", usuario_mail))
        comando.Parameters.Add(New OleDb.OleDbParameter("@graduacion_id", graduacion_id))
        comando.Parameters.Add(New OleDb.OleDbParameter("@usuario_password", usuario_password))
        comando.Parameters.Add(New OleDb.OleDbParameter("@usuario_fecha_registro", usuario_fecha_registro))
        comando.Parameters.Add(New OleDb.OleDbParameter("@instructor_id", instructor_id))
        comando.Parameters.Add(New OleDb.OleDbParameter("@usuario_tipo", usuario_tipo))
        comando.Parameters.Add(New OleDb.OleDbParameter("@usuario_usuario", usuario_usuario))
        comando.Parameters.Add(New OleDb.OleDbParameter("@institucion_id", institucion_id))
        comando.Parameters.Add(New OleDb.OleDbParameter("@usuario_nrolibreta", usuario_nrolibreta))
        comando.Parameters.Add(New OleDb.OleDbParameter("@usuario_obs", usuario_obs))

        Dim ds_JE As New DataSet()
        Dim da_JE As New OleDbDataAdapter(comando)
        da_JE.Fill(ds_JE, "Usuario")
        dbconn.Close()
        Return ds_JE
    End Function




End Class
