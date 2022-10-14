Imports System.Data.OleDb
Imports System.Data.DataRow
Public Class Eventos
    Inherits Capa_de_datos.Conexion

    Public Function Eventos_validar(ByVal evento_id As Integer) As DataSet
        Try
            dbconn.Open()
        Catch ex As Exception
        End Try

        Dim comando As New OleDbCommand("Eventos_validar", dbconn)
        comando.CommandType = CommandType.StoredProcedure

        comando.Parameters.Add(New OleDb.OleDbParameter("@evento_id", evento_id))


        Dim ds_usu As New DataSet()
        Dim da_usu As New OleDbDataAdapter(comando)
        da_usu.Fill(ds_usu, "Evento")
        dbconn.Close()
        Return ds_usu
    End Function

    Public Function Eventos_Alta(ByVal evento_descripcion As String,
                                 ByVal evento_foto As Byte(),
                                 ByVal evento_fecha As Date,
                                 ByVal evento_fechacierre As Date,
                                 ByVal evento_tipoevento As String,
                                 ByVal evento_costo As Decimal,
                                 ByVal evento_direccion As String,
                                 ByVal evento_cap_max_insc As Integer) As DataSet
        Try
            dbconn.Open()
        Catch ex As Exception
        End Try

        Dim comando As New OleDbCommand("Eventos_Alta", dbconn)
        comando.CommandType = CommandType.StoredProcedure

        comando.Parameters.Add(New OleDb.OleDbParameter("@evento_descripcion", evento_descripcion))
        comando.Parameters.Add(New OleDb.OleDbParameter("@evento_foto", evento_foto))
        comando.Parameters.Add(New OleDb.OleDbParameter("@evento_fecha", evento_fecha))
        comando.Parameters.Add(New OleDb.OleDbParameter("@evento_fechacierre", evento_fechacierre))
        comando.Parameters.Add(New OleDb.OleDbParameter("@evento_tipoevento", evento_tipoevento))
        comando.Parameters.Add(New OleDb.OleDbParameter("@evento_costo", evento_costo))
        comando.Parameters.Add(New OleDb.OleDbParameter("@evento_direccion", evento_direccion))
        comando.Parameters.Add(New OleDb.OleDbParameter("@evento_cap_max_insc", evento_cap_max_insc))

        Dim ds_usu As New DataSet()
        Dim da_usu As New OleDbDataAdapter(comando)
        da_usu.Fill(ds_usu, "Evento")
        dbconn.Close()
        Return ds_usu
    End Function

    Public Function ExamenTurno_alta(ByVal evento_id As Integer,
                                     ByVal ExamenTurno_desc As String
                                     ) As DataSet
        Try
            dbconn.Open()
        Catch ex As Exception
        End Try

        Dim comando As New OleDbCommand("ExamenTurno_alta", dbconn)
        comando.CommandType = CommandType.StoredProcedure

        comando.Parameters.Add(New OleDb.OleDbParameter("@evento_id", evento_id))
        comando.Parameters.Add(New OleDb.OleDbParameter("@ExamenTurno_desc", ExamenTurno_desc))

        Dim ds_usu As New DataSet()
        Dim da_usu As New OleDbDataAdapter(comando)
        da_usu.Fill(ds_usu, "ExamenTurno")
        dbconn.Close()
        Return ds_usu
    End Function

    Public Function ExamenTurno_eliminar(ByVal evento_id As Integer) As DataSet
        Try
            dbconn.Open()
        Catch ex As Exception
        End Try

        Dim comando As New OleDbCommand("ExamenTurno_eliminar", dbconn)
        comando.CommandType = CommandType.StoredProcedure

        comando.Parameters.Add(New OleDb.OleDbParameter("@evento_id", evento_id))
        'comando.Parameters.Add(New OleDb.OleDbParameter("@ExamenTurno_desc", ExamenTurno_desc))
        Dim ds_usu As New DataSet()
        Dim da_usu As New OleDbDataAdapter(comando)
        da_usu.Fill(ds_usu, "ExamenTurno")
        dbconn.Close()
        Return ds_usu
    End Function




    Public Function Evento_Seleccionar_Examen() As DataSet
        Try
            dbconn.Open()
        Catch ex As Exception
        End Try

        Dim comando As New OleDbCommand(" Evento_Seleccionar_Examen", dbconn)
        comando.CommandType = CommandType.StoredProcedure

        Dim ds_usu As New DataSet()
        Dim da_usu As New OleDbDataAdapter(comando)
        da_usu.Fill(ds_usu, "  Evento_Seleccionar_Examen")
        dbconn.Close()
        Return ds_usu
    End Function

    'trae todos los eventos donde aun no se haya cumplido la fecha de cierre de inscripcion
    Public Function Evento_ObetenerEventos() As DataSet
        Try
            dbconn.Open()
        Catch ex As Exception
        End Try

        Dim comando As New OleDbCommand("Evento_ObetenerEventos", dbconn)
        comando.CommandType = CommandType.StoredProcedure

        Dim ds_usu As New DataSet()
        Dim da_usu As New OleDbDataAdapter(comando)
        da_usu.Fill(ds_usu, " Eventos")
        dbconn.Close()
        Return ds_usu
    End Function

    'Trae solo los eventos que sean torneos,  no lleva la validacion de la fecha de cierre.
    Public Function Evento_obtener_torneos() As DataSet
        Try
            dbconn.Open()
        Catch ex As Exception
        End Try

        Dim comando As New OleDbCommand("Evento_obtener_torneos", dbconn)
        comando.CommandType = CommandType.StoredProcedure

        Dim ds_usu As New DataSet()
        Dim da_usu As New OleDbDataAdapter(comando)
        da_usu.Fill(ds_usu, " Eventos")
        dbconn.Close()
        Return ds_usu
    End Function


    Public Function Evento_ObetenerEvento_ID(ByVal Id_evento As String) As DataSet
        Try
            dbconn.Open()
        Catch ex As Exception
        End Try
        Dim comando As New OleDbCommand("Evento_ObetenerEvento_ID", dbconn)
        comando.CommandType = CommandType.StoredProcedure
        comando.Parameters.Add(New OleDb.OleDbParameter("@ID", Id_evento))
        ' crear dataset que sirve de contenedor para todos los datatables
        ''el dataset es un contenedor, repositorio
        Dim ds As New DataSet() 'System.Data.DataSet()
        Dim DA As New OleDbDataAdapter(comando)
        ''Fill= Método que Agrega filas al objeto DataSet y crea un objeto DataTable denominado "Tabla", en nuestro caso "Producto".
        DA.Fill(ds, "evento")
        ''Cierro la conexión
        dbconn.Close()
        ''Como toda función debe retornar al uso RETURN
        Return ds
    End Function


    Public Function Evento_Actualizar(ByVal evento_id As String,
                                 ByVal evento_descripcion As String,
                                 ByVal evento_foto As Byte(),
                                 ByVal evento_fecha As Date,
                                 ByVal evento_fechacierre As Date,
                                 ByVal evento_tipoevento As String,
                                 ByVal evento_costo As Decimal,
                                 ByVal evento_cap_max_insc As Decimal,
                                 ByVal evento_direccion As String) As DataSet
        Try
            dbconn.Open()
        Catch ex As Exception
        End Try

        Dim comando As New OleDbCommand("Evento_Actualizar", dbconn)
        comando.CommandType = CommandType.StoredProcedure

        comando.Parameters.Add(New OleDb.OleDbParameter("@evento_id", evento_id))
        comando.Parameters.Add(New OleDb.OleDbParameter("@evento_descripcion", evento_descripcion))
        comando.Parameters.Add(New OleDb.OleDbParameter("@evento_foto", evento_foto))
        comando.Parameters.Add(New OleDb.OleDbParameter("@evento_fecha", evento_fecha))
        comando.Parameters.Add(New OleDb.OleDbParameter("@evento_fechacierre", evento_fechacierre))
        comando.Parameters.Add(New OleDb.OleDbParameter("@evento_tipoevento", evento_tipoevento))
        comando.Parameters.Add(New OleDb.OleDbParameter("@evento_costo", evento_costo))
        comando.Parameters.Add(New OleDb.OleDbParameter("@evento_cap_max_insc", evento_cap_max_insc))
        comando.Parameters.Add(New OleDb.OleDbParameter("@evento_direccion", evento_direccion))

        Dim ds_usu As New DataSet()
        Dim da_usu As New OleDbDataAdapter(comando)
        da_usu.Fill(ds_usu, "Evento")
        dbconn.Close()
        Return ds_usu
    End Function


    Public Function Evento_inscripcion_cargar(ByVal usuario_id As Integer) As DataSet
        Try
            dbconn.Open()
        Catch ex As Exception
        End Try
        Dim comando As New OleDbCommand("Evento_inscripcion_cargar", dbconn)
        comando.CommandType = CommandType.StoredProcedure
        comando.Parameters.Add(New OleDb.OleDbParameter("@usuario_id", usuario_id))
        ' crear dataset que sirve de contenedor para todos los datatables
        ''el dataset es un contenedor, repositorio
        Dim ds As New DataSet() 'System.Data.DataSet()
        Dim DA As New OleDbDataAdapter(comando)
        ''Fill= Método que Agrega filas al objeto DataSet y crea un objeto DataTable denominado "Tabla", en nuestro caso "Producto".
        DA.Fill(ds, "usuario")
        ''Cierro la conexión
        dbconn.Close()
        ''Como toda función debe retornar al uso RETURN
        Return ds
    End Function


    Public Function imagen_subir(ByVal evento_foto As Byte()) As DataSet
        Try
            dbconn.Open()
        Catch ex As Exception
        End Try

        Dim comando As New OleDbCommand("imagen_subir", dbconn)
        comando.CommandType = CommandType.StoredProcedure


        comando.Parameters.Add(New OleDb.OleDbParameter("@evento_foto", evento_foto))


        Dim ds_usu As New DataSet()
        Dim da_usu As New OleDbDataAdapter(comando)
        da_usu.Fill(ds_usu, "Evento")
        dbconn.Close()
        Return ds_usu
    End Function

    Public Function imagen_obtener() As DataSet
        Try
            dbconn.Open()
        Catch ex As Exception
        End Try
        Dim comando As New OleDbCommand("imagen_obtener", dbconn)
        comando.CommandType = CommandType.StoredProcedure
        ' crear dataset que sirve de contenedor para todos los datatables
        ''el dataset es un contenedor, repositorio
        Dim ds As New DataSet() 'System.Data.DataSet()
        Dim DA As New OleDbDataAdapter(comando)
        ''Fill= Método que Agrega filas al objeto DataSet y crea un objeto DataTable denominado "Tabla", en nuestro caso "Producto".
        DA.Fill(ds, "evento")
        ''Cierro la conexión
        dbconn.Close()
        ''Como toda función debe retornar al uso RETURN
        Return ds
    End Function

    Public Function Evento_obtenerEventos_inscripto(ByVal usuario_id As Integer) As DataSet
        Try
            dbconn.Open()
        Catch ex As Exception
        End Try
        Dim comando As New OleDbCommand("Evento_obtenerEventos_inscripto", dbconn)
        comando.CommandType = CommandType.StoredProcedure
        comando.Parameters.Add(New OleDb.OleDbParameter("@usuario_id", usuario_id))
        ' crear dataset que sirve de contenedor para todos los datatables
        ''el dataset es un contenedor, repositorio
        Dim ds As New DataSet() 'System.Data.DataSet()
        Dim DA As New OleDbDataAdapter(comando)
        ''Fill= Método que Agrega filas al objeto DataSet y crea un objeto DataTable denominado "Tabla", en nuestro caso "Producto".
        DA.Fill(ds, "usuario")
        ''Cierro la conexión
        dbconn.Close()
        ''Como toda función debe retornar al uso RETURN
        Return ds
    End Function

    Public Function Evento_eliminar(ByVal evento_id As Integer) As DataSet
        Try
            dbconn.Open()
        Catch ex As Exception
        End Try
        Dim comando As New OleDbCommand("Evento_eliminar", dbconn)
        comando.CommandType = CommandType.StoredProcedure
        comando.Parameters.Add(New OleDb.OleDbParameter("@evento_id", evento_id))
        Dim ds_JE As New DataSet()
        Dim da_JE As New OleDbDataAdapter(comando)
        da_JE.Fill(ds_JE, "evento")
        dbconn.Close()
        Return ds_JE
    End Function
#Region "Curso"
    Public Function Evento_Seleccionar_Curso() As DataSet
        Try
            dbconn.Open()
        Catch ex As Exception
        End Try

        Dim comando As New OleDbCommand("Evento_Seleccionar_Curso", dbconn)
        comando.CommandType = CommandType.StoredProcedure

        Dim ds_usu As New DataSet()
        Dim da_usu As New OleDbDataAdapter(comando)
        da_usu.Fill(ds_usu, "  Evento_Seleccionar_Curso")
        dbconn.Close()
        Return ds_usu
    End Function

    Public Function Curso_recuperar_inscriptos(ByVal evento_id As Integer) As DataSet
        Try
            dbconn.Open()
        Catch ex As Exception
        End Try
        Dim comando As New OleDbCommand("Curso_recuperar_inscriptos", dbconn)
        comando.CommandType = CommandType.StoredProcedure
        comando.Parameters.Add(New OleDb.OleDbParameter("@evento_id", evento_id))
        Dim ds_JE As New DataSet()
        Dim da_JE As New OleDbDataAdapter(comando)
        da_JE.Fill(ds_JE, "Inscriptos")
        dbconn.Close()
        Return ds_JE
    End Function

#End Region

#Region "Usuarios del evento" 'lo uso en el form Torneo_usuario_add y el login


    Public Function UsuarioEvento_obtener_evento(ByVal evento_id As Integer) As DataSet
        Try
            dbconn.Open()
        Catch ex As Exception
        End Try
        Dim comando As New OleDbCommand("UsuarioEvento_obtener_evento", dbconn)
        comando.CommandType = CommandType.StoredProcedure
        comando.Parameters.Add(New OleDb.OleDbParameter("@evento_id", evento_id))
        Dim ds_JE As New DataSet()
        Dim da_JE As New OleDbDataAdapter(comando)
        da_JE.Fill(ds_JE, "usuarioevento")
        dbconn.Close()
        Return ds_JE
    End Function


    Public Function UsuarioEvento_alta(ByVal evento_id As Integer, ByVal usuario_usuario As String, ByVal usuario_password As String) As DataSet
        Try
            dbconn.Open()
        Catch ex As Exception
        End Try
        Dim comando As New OleDbCommand("UsuarioEvento_alta", dbconn)
        comando.CommandType = CommandType.StoredProcedure
        comando.Parameters.Add(New OleDb.OleDbParameter("@evento_id", evento_id))
        comando.Parameters.Add(New OleDb.OleDbParameter("@usuario_usuario", usuario_usuario))
        comando.Parameters.Add(New OleDb.OleDbParameter("@usuario_password", usuario_password))
        Dim ds_JE As New DataSet()
        Dim da_JE As New OleDbDataAdapter(comando)
        da_JE.Fill(ds_JE, "usuarioevento")
        dbconn.Close()
        Return ds_JE
    End Function


#End Region

#Region "Examen"
    'consultar todos los incriptos a un examen ordenados por instructor.
    Public Function Examen_recuperar_inscriptos(ByVal evento_id As Integer) As DataSet
        Try
            dbconn.Open()
        Catch ex As Exception
        End Try
        Dim comando As New OleDbCommand("Examen_recuperar_inscriptos", dbconn)
        comando.CommandType = CommandType.StoredProcedure
        comando.Parameters.Add(New OleDb.OleDbParameter("@evento_id", evento_id))
        Dim ds_JE As New DataSet()
        Dim da_JE As New OleDbDataAdapter(comando)
        da_JE.Fill(ds_JE, "Inscriptos")
        dbconn.Close()
        Return ds_JE
    End Function

    Public Function Examen_recuperar_fecha(ByVal usuario_id As Integer) As DataSet
        Try
            dbconn.Open()
        Catch ex As Exception
        End Try
        Dim comando As New OleDbCommand("Examen_recuperar_fecha", dbconn)
        comando.CommandType = CommandType.StoredProcedure
        comando.Parameters.Add(New OleDb.OleDbParameter("@usuario_id", usuario_id))
        Dim ds_JE As New DataSet()
        Dim da_JE As New OleDbDataAdapter(comando)
        da_JE.Fill(ds_JE, "usuario")
        dbconn.Close()
        Return ds_JE
    End Function

    Public Function ExamenCostos_recuperar(ByVal evento_id As Integer) As DataSet
        Try
            dbconn.Open()
        Catch ex As Exception
        End Try
        Dim comando As New OleDbCommand("ExamenCostos_recuperar", dbconn)
        comando.CommandType = CommandType.StoredProcedure
        comando.Parameters.Add(New OleDb.OleDbParameter("@evento_id", evento_id))
        'comando.Parameters.Add(New OleDb.OleDbParameter("@ExamenTurno_id", ExamenTurno_id))
        ' crear dataset que sirve de contenedor para todos los datatables
        ''el dataset es un contenedor, repositorio
        Dim ds As New DataSet() 'System.Data.DataSet()
        Dim DA As New OleDbDataAdapter(comando)
        ''Fill= Método que Agrega filas al objeto DataSet y crea un objeto DataTable denominado "Tabla", en nuestro caso "Producto".
        DA.Fill(ds, "COSTOS")
        ''Cierro la conexión
        dbconn.Close()
        ''Como toda función debe retornar al uso RETURN
        Return ds
    End Function

    Public Function Examen_liquidacion_obtener_inscriptos(ByVal evento_id As Integer) As DataSet
        Try
            dbconn.Open()
        Catch ex As Exception
        End Try
        Dim comando As New OleDbCommand("Examen_liquidacion_obtener_inscriptos", dbconn)
        comando.CommandType = CommandType.StoredProcedure
        comando.Parameters.Add(New OleDb.OleDbParameter("@evento_id", evento_id))
        Dim ds_JE As New DataSet()
        Dim da_JE As New OleDbDataAdapter(comando)
        da_JE.Fill(ds_JE, "Inscriptos")
        dbconn.Close()
        Return ds_JE
    End Function


#End Region

#Region "Torneo"
    Public Function Evento_Seleccionar_Torneo() As DataSet
        Try
            dbconn.Open()
        Catch ex As Exception
        End Try

        Dim comando As New OleDbCommand("Evento_Seleccionar_Torneo", dbconn)
        comando.CommandType = CommandType.StoredProcedure

        Dim ds_usu As New DataSet()
        Dim da_usu As New OleDbDataAdapter(comando)
        da_usu.Fill(ds_usu, "Torneo")
        dbconn.Close()
        Return ds_usu
    End Function

    Public Function Torneo_recuperar_inscriptos(ByVal evento_id As Integer) As DataSet
        Try
            dbconn.Open()
        Catch ex As Exception
        End Try

        Dim comando As New OleDbCommand("Torneo_recuperar_inscriptos", dbconn)
        comando.CommandType = CommandType.StoredProcedure
        comando.Parameters.Add(New OleDb.OleDbParameter("@evento_id", evento_id))
        Dim ds_usu As New DataSet()
        Dim da_usu As New OleDbDataAdapter(comando)
        da_usu.Fill(ds_usu, "Torneo")
        dbconn.Close()
        Return ds_usu
    End Function

    Public Function Torneo_recuperar_inscriptos_categoria(ByVal evento_id As Integer, ByVal categoria_id As Integer) As DataSet
        Try
            dbconn.Open()
        Catch ex As Exception
        End Try

        Dim comando As New OleDbCommand("Torneo_recuperar_inscriptos_categoria", dbconn)
        comando.CommandType = CommandType.StoredProcedure
        comando.Parameters.Add(New OleDb.OleDbParameter("@evento_id", evento_id))
        comando.Parameters.Add(New OleDb.OleDbParameter("@categoria_id", categoria_id))
        Dim ds_usu As New DataSet()
        Dim da_usu As New OleDbDataAdapter(comando)
        da_usu.Fill(ds_usu, "Torneo")
        dbconn.Close()
        Return ds_usu
    End Function

#End Region



End Class
