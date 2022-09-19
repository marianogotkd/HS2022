Imports System.Data.OleDb
Imports System.Data.DataRow
Public Class Inscripciones
    Inherits Capa_de_datos.Conexion

    Public Function Inscripcion_alta_usuario(ByVal USU_id As Integer, ByVal evento_id As Integer, ByVal inscripcion_fechahora As DateTime, ByVal inscripcion_peso As Decimal) As DataSet
        Try
            dbconn.Open()
        Catch ex As Exception
        End Try
        Dim comando As New OleDbCommand("Inscripcion_alta_usuario", dbconn)
        comando.CommandType = CommandType.StoredProcedure
        comando.Parameters.Add(New OleDb.OleDbParameter("@USU_id", USU_id))
        comando.Parameters.Add(New OleDb.OleDbParameter("@evento_id", evento_id))
        comando.Parameters.Add(New OleDb.OleDbParameter("@inscripcion_fechahora", inscripcion_fechahora))
        comando.Parameters.Add(New OleDb.OleDbParameter("@inscripcion_peso", inscripcion_peso))
        ' crear dataset que sirve de contenedor para todos los datatables
        ''el dataset es un contenedor, repositorio
        Dim ds As New DataSet() 'System.Data.DataSet()
        Dim DA As New OleDbDataAdapter(comando)
        ''Fill= Método que Agrega filas al objeto DataSet y crea un objeto DataTable denominado "Tabla", en nuestro caso "Producto".
        DA.Fill(ds, "inscripciones")
        ''Cierro la conexión
        dbconn.Close()
        ''Como toda función debe retornar al uso RETURN
        Return ds
    End Function

    Public Function Inscripcion_validar_alta(ByVal inscripcion_id As Integer) As DataSet
        Try
            dbconn.Open()
        Catch ex As Exception
        End Try
        Dim comando As New OleDbCommand("Inscripcion_validar_alta", dbconn)
        comando.CommandType = CommandType.StoredProcedure
        comando.Parameters.Add(New OleDb.OleDbParameter("@inscripcion_id", inscripcion_id))
        
        ' crear dataset que sirve de contenedor para todos los datatables
        ''el dataset es un contenedor, repositorio
        Dim ds As New DataSet() 'System.Data.DataSet()
        Dim DA As New OleDbDataAdapter(comando)
        ''Fill= Método que Agrega filas al objeto DataSet y crea un objeto DataTable denominado "Tabla", en nuestro caso "Producto".
        DA.Fill(ds, "inscripciones")
        ''Cierro la conexión
        dbconn.Close()
        ''Como toda función debe retornar al uso RETURN
        Return ds
    End Function


    Public Function Inscripcion_alta_masiva(ByVal USU_id_alumno As Integer, ByVal evento_id As Integer, ByVal inscripcion_fechahora As DateTime, ByVal inscripcion_peso As Decimal, ByVal USU_id_instructor As Integer) As DataSet
        Try
            dbconn.Open()
        Catch ex As Exception
        End Try
        Dim comando As New OleDbCommand("Inscripcion_alta_masiva", dbconn)
        comando.CommandType = CommandType.StoredProcedure
        comando.Parameters.Add(New OleDb.OleDbParameter("@USU_id_alumno", USU_id_alumno))
        comando.Parameters.Add(New OleDb.OleDbParameter("@evento_id", evento_id))
        comando.Parameters.Add(New OleDb.OleDbParameter("@inscripcion_fechahora", inscripcion_fechahora))
        comando.Parameters.Add(New OleDb.OleDbParameter("@inscripcion_peso", inscripcion_peso))
        comando.Parameters.Add(New OleDb.OleDbParameter("@USU_id_instructor", USU_id_instructor))
        ' crear dataset que sirve de contenedor para todos los datatables
        ''el dataset es un contenedor, repositorio
        Dim ds As New DataSet() 'System.Data.DataSet()
        Dim DA As New OleDbDataAdapter(comando)
        ''Fill= Método que Agrega filas al objeto DataSet y crea un objeto DataTable denominado "Tabla", en nuestro caso "Producto".
        DA.Fill(ds, "inscripciones")
        ''Cierro la conexión
        dbconn.Close()
        ''Como toda función debe retornar al uso RETURN
        Return ds
    End Function

    Public Function Inscripcion_borrar_alumno(ByVal usuario_id As Integer, ByVal evento_id As Integer) As DataSet
        Try
            dbconn.Open()
        Catch ex As Exception
        End Try
        Dim comando As New OleDbCommand("Inscripcion_borrar_alumno", dbconn)
        comando.CommandType = CommandType.StoredProcedure
        comando.Parameters.Add(New OleDb.OleDbParameter("@usuario_id", usuario_id))
        comando.Parameters.Add(New OleDb.OleDbParameter("@evento_id", evento_id))
        ' crear dataset que sirve de contenedor para todos los datatables
        ''el dataset es un contenedor, repositorio
        Dim ds As New DataSet() 'System.Data.DataSet()
        Dim DA As New OleDbDataAdapter(comando)
        ''Fill= Método que Agrega filas al objeto DataSet y crea un objeto DataTable denominado "Tabla", en nuestro caso "Producto".
        DA.Fill(ds, "inscripciones")
        ''Cierro la conexión
        dbconn.Close()
        ''Como toda función debe retornar al uso RETURN
        Return ds
    End Function

    Public Function Inscripcion_obtener_categoria() As DataSet
        Try
            dbconn.Open()
        Catch ex As Exception
        End Try

        Dim comando As New OleDbCommand("Inscripcion_obtener_categoria", dbconn)
        comando.CommandType = CommandType.StoredProcedure

        Dim ds_usu As New DataSet()
        Dim da_usu As New OleDbDataAdapter(comando)
        da_usu.Fill(ds_usu, " Categorias")
        dbconn.Close()
        Return ds_usu
    End Function

    Public Function Inscripcion_obtener_categoria_roturapoder() As DataSet
        Try
            dbconn.Open()
        Catch ex As Exception
        End Try

        Dim comando As New OleDbCommand("Inscripcion_obtener_categoria_roturapoder", dbconn)
        comando.CommandType = CommandType.StoredProcedure

        Dim ds_usu As New DataSet()
        Dim da_usu As New OleDbDataAdapter(comando)
        da_usu.Fill(ds_usu, " Categorias")
        dbconn.Close()
        Return ds_usu
    End Function

    Public Function Inscripcion_obtener_categoria_roturaespecial() As DataSet
        Try
            dbconn.Open()
        Catch ex As Exception
        End Try

        Dim comando As New OleDbCommand("Inscripcion_obtener_categoria_roturaespecial", dbconn)
        comando.CommandType = CommandType.StoredProcedure

        Dim ds_usu As New DataSet()
        Dim da_usu As New OleDbDataAdapter(comando)
        da_usu.Fill(ds_usu, " Categorias")
        dbconn.Close()
        Return ds_usu
    End Function

    Public Function Inscripcion_alta_categorias(ByVal inscripcion_id As Integer, ByVal categoria_id As Integer) As DataSet
        Try
            dbconn.Open()
        Catch ex As Exception
        End Try
        Dim comando As New OleDbCommand("Inscripcion_alta_categorias", dbconn)
        comando.CommandType = CommandType.StoredProcedure
        comando.Parameters.Add(New OleDb.OleDbParameter("@inscripcion_id", inscripcion_id))
        comando.Parameters.Add(New OleDb.OleDbParameter("@categoria_id", categoria_id))
        ' crear dataset que sirve de contenedor para todos los datatables
        ''el dataset es un contenedor, repositorio
        Dim ds As New DataSet() 'System.Data.DataSet()
        Dim DA As New OleDbDataAdapter(comando)
        ''Fill= Método que Agrega filas al objeto DataSet y crea un objeto DataTable denominado "Tabla", en nuestro caso "Producto".
        DA.Fill(ds, "inscripciones")
        ''Cierro la conexión
        dbconn.Close()
        ''Como toda función debe retornar al uso RETURN
        Return ds
    End Function


    Public Function Inscripcion_consultar_evento(ByVal evento_id As Integer) As DataSet
        Try
            dbconn.Open()
        Catch ex As Exception
        End Try
        Dim comando As New OleDbCommand("Inscripcion_consultar_evento", dbconn)
        comando.CommandType = CommandType.StoredProcedure
        comando.Parameters.Add(New OleDb.OleDbParameter("@evento_id", evento_id))
        ' crear dataset que sirve de contenedor para todos los datatables
        ''el dataset es un contenedor, repositorio
        Dim ds As New DataSet() 'System.Data.DataSet()
        Dim DA As New OleDbDataAdapter(comando)
        ''Fill= Método que Agrega filas al objeto DataSet y crea un objeto DataTable denominado "Tabla", en nuestro caso "Producto".
        DA.Fill(ds, "Eventos")
        ''Cierro la conexión
        dbconn.Close()
        ''Como toda función debe retornar al uso RETURN
        Return ds
    End Function

    Public Function Inscripcion_consultar_alumno_inscripto(ByVal evento_id As Integer, ByVal usuario_id As Integer) As DataSet
        Try
            dbconn.Open()
        Catch ex As Exception
        End Try
        Dim comando As New OleDbCommand("Inscripcion_consultar_alumno_inscripto", dbconn)
        comando.CommandType = CommandType.StoredProcedure
        comando.Parameters.Add(New OleDb.OleDbParameter("@evento_id", evento_id))
        comando.Parameters.Add(New OleDb.OleDbParameter("@usuario_id", usuario_id))
        ' crear dataset que sirve de contenedor para todos los datatables
        ''el dataset es un contenedor, repositorio
        Dim ds As New DataSet() 'System.Data.DataSet()
        Dim DA As New OleDbDataAdapter(comando)
        ''Fill= Método que Agrega filas al objeto DataSet y crea un objeto DataTable denominado "Tabla", en nuestro caso "Producto".
        DA.Fill(ds, "Eventos")
        ''Cierro la conexión
        dbconn.Close()
        ''Como toda función debe retornar al uso RETURN
        Return ds
    End Function


    Public Function inscripcion_imagenQR_Alta(ByVal inscripcion_id As Integer, ByVal imagenQR As Byte()) As DataSet
        Try
            dbconn.Open()
        Catch ex As Exception
        End Try
        Dim comando As New OleDbCommand("inscripcion_imagenQR_Alta", dbconn)
        comando.CommandType = CommandType.StoredProcedure
        comando.Parameters.Add(New OleDb.OleDbParameter("@inscripcion_id", inscripcion_id))
        comando.Parameters.Add(New OleDb.OleDbParameter("@imagenQR", imagenQR))
        ' crear dataset que sirve de contenedor para todos los datatables
        ''el dataset es un contenedor, repositorio
        Dim ds As New DataSet() 'System.Data.DataSet()
        Dim DA As New OleDbDataAdapter(comando)
        ''Fill= Método que Agrega filas al objeto DataSet y crea un objeto DataTable denominado "Tabla", en nuestro caso "Producto".
        DA.Fill(ds, "Eventos")
        ''Cierro la conexión
        dbconn.Close()
        ''Como toda función debe retornar al uso RETURN
        Return ds
    End Function



    Public Function Inscripciones_credenciales_obtener(ByVal evento_id As Integer) As DataSet
        Try
            dbconn.Open()
        Catch ex As Exception
        End Try
        Dim comando As New OleDbCommand("Inscripciones_credenciales_obtener", dbconn)
        comando.CommandType = CommandType.StoredProcedure
        comando.Parameters.Add(New OleDb.OleDbParameter("@evento_id", evento_id))
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

    Public Function inscripcion_recuperar_ID(ByVal usuario_id As Integer) As DataSet
        Try
            dbconn.Open()
        Catch ex As Exception
        End Try
        Dim comando As New OleDbCommand("inscripcion_recuperar_ID", dbconn)
        comando.CommandType = CommandType.StoredProcedure
        comando.Parameters.Add(New OleDb.OleDbParameter("@usuario_id", usuario_id))
        ' crear dataset que sirve de contenedor para todos los datatables
        ''el dataset es un contenedor, repositorio
        Dim ds As New DataSet() 'System.Data.DataSet()
        Dim DA As New OleDbDataAdapter(comando)
        ''Fill= Método que Agrega filas al objeto DataSet y crea un objeto DataTable denominado "Tabla", en nuestro caso "Producto".
        DA.Fill(ds, "inscripcion")
        ''Cierro la conexión
        dbconn.Close()
        ''Como toda función debe retornar al uso RETURN
        Return ds
    End Function

    Public Function Inscripcion_eliminar_alumno_torneo(ByVal inscripcion_id As Integer, ByVal categoria_id As Integer) As DataSet
        Try
            dbconn.Open()
        Catch ex As Exception
        End Try
        Dim comando As New OleDbCommand("Inscripcion_eliminar_alumno_torneo", dbconn)
        comando.CommandType = CommandType.StoredProcedure
        comando.Parameters.Add(New OleDb.OleDbParameter("@inscripcion_id", inscripcion_id))
        comando.Parameters.Add(New OleDb.OleDbParameter("@categoria_id", categoria_id))

        ' crear dataset que sirve de contenedor para todos los datatables
        ''el dataset es un contenedor, repositorio
        Dim ds As New DataSet() 'System.Data.DataSet()
        Dim DA As New OleDbDataAdapter(comando)
        ''Fill= Método que Agrega filas al objeto DataSet y crea un objeto DataTable denominado "Tabla", en nuestro caso "Producto".
        DA.Fill(ds, "inscripciones")
        ''Cierro la conexión
        dbconn.Close()
        ''Como toda función debe retornar al uso RETURN
        Return ds
    End Function

    Public Function Inscripcion_eliminar_masivo(ByVal inscripcion_id As Integer) As DataSet
        Try
            dbconn.Open()
        Catch ex As Exception
        End Try
        Dim comando As New OleDbCommand("Inscripcion_eliminar_masivo", dbconn)
        comando.CommandType = CommandType.StoredProcedure
        comando.Parameters.Add(New OleDb.OleDbParameter("@inscripcion_id", inscripcion_id))
        'comando.Parameters.Add(New OleDb.OleDbParameter("@categoria_id", categoria_id))

        ' crear dataset que sirve de contenedor para todos los datatables
        ''el dataset es un contenedor, repositorio
        Dim ds As New DataSet() 'System.Data.DataSet()
        Dim DA As New OleDbDataAdapter(comando)
        ''Fill= Método que Agrega filas al objeto DataSet y crea un objeto DataTable denominado "Tabla", en nuestro caso "Producto".
        DA.Fill(ds, "inscripciones")
        ''Cierro la conexión
        dbconn.Close()
        ''Como toda función debe retornar al uso RETURN
        Return ds
    End Function


#Region "EXAMENES"
    Public Function inscripciones_x_examen_eliminar(ByVal Inscexamen_id As Integer) As DataSet
        Try
            dbconn.Open()
        Catch ex As Exception
        End Try
        Dim comando As New OleDbCommand("inscripciones_x_examen_eliminar", dbconn)
        comando.CommandType = CommandType.StoredProcedure
        comando.Parameters.Add(New OleDb.OleDbParameter("@Inscexamen_id", Inscexamen_id))
        'comando.Parameters.Add(New OleDb.OleDbParameter("@ExamenTurno_id", ExamenTurno_id))
        'comando.Parameters.Add(New OleDb.OleDbParameter("@graduacion_actual_id", graduacion_actual_id))
        ' crear dataset que sirve de contenedor para todos los datatables
        ''el dataset es un contenedor, repositorio
        Dim ds As New DataSet() 'System.Data.DataSet()
        Dim DA As New OleDbDataAdapter(comando)
        ''Fill= Método que Agrega filas al objeto DataSet y crea un objeto DataTable denominado "Tabla", en nuestro caso "Producto".
        DA.Fill(ds, "INSCRIPCIONES")
        ''Cierro la conexión
        dbconn.Close()
        ''Como toda función debe retornar al uso RETURN
        Return ds
    End Function



    Public Function inscripciones_x_examen_alta(ByVal inscripcion_id As Integer, ByVal ExamenTurno_id As Integer, ByVal graduacion_actual_id As Integer) As DataSet
        Try
            dbconn.Open()
        Catch ex As Exception
        End Try
        Dim comando As New OleDbCommand("inscripciones_x_examen_alta", dbconn)
        comando.CommandType = CommandType.StoredProcedure
        comando.Parameters.Add(New OleDb.OleDbParameter("@inscripcion_id", inscripcion_id))
        comando.Parameters.Add(New OleDb.OleDbParameter("@ExamenTurno_id", ExamenTurno_id))
        comando.Parameters.Add(New OleDb.OleDbParameter("@graduacion_actual_id", graduacion_actual_id))
        ' crear dataset que sirve de contenedor para todos los datatables
        ''el dataset es un contenedor, repositorio
        Dim ds As New DataSet() 'System.Data.DataSet()
        Dim DA As New OleDbDataAdapter(comando)
        ''Fill= Método que Agrega filas al objeto DataSet y crea un objeto DataTable denominado "Tabla", en nuestro caso "Producto".
        DA.Fill(ds, "INSCRIPCIONES_EXAMENES")
        ''Cierro la conexión
        dbconn.Close()
        ''Como toda función debe retornar al uso RETURN
        Return ds
    End Function

    Public Function inscripciones_x_examen_modificar(ByVal Inscexamen_id As Integer, ByVal ExamenTurno_id As Integer) As DataSet
        Try
            dbconn.Open()
        Catch ex As Exception
        End Try
        Dim comando As New OleDbCommand("inscripciones_x_examen_modificar", dbconn)
        comando.CommandType = CommandType.StoredProcedure
        comando.Parameters.Add(New OleDb.OleDbParameter("@Inscexamen_id", Inscexamen_id))
        comando.Parameters.Add(New OleDb.OleDbParameter("@ExamenTurno_id", ExamenTurno_id))
        ' crear dataset que sirve de contenedor para todos los datatables
        ''el dataset es un contenedor, repositorio
        Dim ds As New DataSet() 'System.Data.DataSet()
        Dim DA As New OleDbDataAdapter(comando)
        ''Fill= Método que Agrega filas al objeto DataSet y crea un objeto DataTable denominado "Tabla", en nuestro caso "Producto".
        DA.Fill(ds, "INSCRIPCIONES_EXAMENES")
        ''Cierro la conexión
        dbconn.Close()
        ''Como toda función debe retornar al uso RETURN
        Return ds
    End Function

    Public Function inscripciones_x_examen_modificar_resultado(ByVal Inscexamen_id As Integer, ByVal ExamenTurno_id As Integer, ByVal resultado As String, ByVal graduacion_obtenida_id As Integer) As DataSet
        Try
            dbconn.Open()
        Catch ex As Exception
        End Try
        Dim comando As New OleDbCommand("inscripciones_x_examen_modificar_resultado", dbconn)
        comando.CommandType = CommandType.StoredProcedure
        comando.Parameters.Add(New OleDb.OleDbParameter("@Inscexamen_id", Inscexamen_id))
        comando.Parameters.Add(New OleDb.OleDbParameter("@ExamenTurno_id", ExamenTurno_id))
        comando.Parameters.Add(New OleDb.OleDbParameter("@resultado", resultado))
        comando.Parameters.Add(New OleDb.OleDbParameter("@graduacion_obtenida_id", graduacion_obtenida_id))
        ' crear dataset que sirve de contenedor para todos los datatables
        ''el dataset es un contenedor, repositorio
        Dim ds As New DataSet() 'System.Data.DataSet()
        Dim DA As New OleDbDataAdapter(comando)
        ''Fill= Método que Agrega filas al objeto DataSet y crea un objeto DataTable denominado "Tabla", en nuestro caso "Producto".
        DA.Fill(ds, "INSCRIPCIONES_EXAMENES")
        ''Cierro la conexión
        dbconn.Close()
        ''Como toda función debe retornar al uso RETURN
        Return ds
    End Function

    Public Function inscripciones_x_examen_validar(ByVal evento_id As Integer, ByVal ExamenTurno_id As Integer) As DataSet
        Try
            dbconn.Open()
        Catch ex As Exception
        End Try
        Dim comando As New OleDbCommand("inscripciones_x_examen_validar", dbconn)
        comando.CommandType = CommandType.StoredProcedure
        comando.Parameters.Add(New OleDb.OleDbParameter("@evento_id", evento_id))
        comando.Parameters.Add(New OleDb.OleDbParameter("@ExamenTurno_id", ExamenTurno_id))
        ' crear dataset que sirve de contenedor para todos los datatables
        ''el dataset es un contenedor, repositorio
        Dim ds As New DataSet() 'System.Data.DataSet()
        Dim DA As New OleDbDataAdapter(comando)
        ''Fill= Método que Agrega filas al objeto DataSet y crea un objeto DataTable denominado "Tabla", en nuestro caso "Producto".
        DA.Fill(ds, "INSCRIPCIONES_EXAMENES")
        ''Cierro la conexión
        dbconn.Close()
        ''Como toda función debe retornar al uso RETURN
        Return ds
    End Function

    Public Function ExamenCertificacion_alta(ByVal usuario_id As Integer, ByVal graduacion_id As Integer, ByVal evento_id As Integer) As DataSet
        Try
            dbconn.Open()
        Catch ex As Exception
        End Try
        Dim comando As New OleDbCommand("ExamenCertificacion_alta", dbconn)
        comando.CommandType = CommandType.StoredProcedure
        comando.Parameters.Add(New OleDb.OleDbParameter("@usuario_id", usuario_id))
        comando.Parameters.Add(New OleDb.OleDbParameter("@graduacion_id", graduacion_id))
        comando.Parameters.Add(New OleDb.OleDbParameter("@evento_id", evento_id))
        ' crear dataset que sirve de contenedor para todos los datatables
        ''el dataset es un contenedor, repositorio
        Dim ds As New DataSet() 'System.Data.DataSet()
        Dim DA As New OleDbDataAdapter(comando)
        ''Fill= Método que Agrega filas al objeto DataSet y crea un objeto DataTable denominado "Tabla", en nuestro caso "Producto".
        DA.Fill(ds, "certificacion")
        ''Cierro la conexión
        dbconn.Close()
        ''Como toda función debe retornar al uso RETURN
        Return ds
    End Function

#End Region


#Region "Curso"
    Public Function inscripciones_CURSO_eliminar(ByVal inscripcion_id As Integer) As DataSet
        Try
            dbconn.Open()
        Catch ex As Exception
        End Try
        Dim comando As New OleDbCommand("inscripciones_CURSO_eliminar", dbconn)
        comando.CommandType = CommandType.StoredProcedure
        comando.Parameters.Add(New OleDb.OleDbParameter("@inscripcion_id", inscripcion_id))
        ' crear dataset que sirve de contenedor para todos los datatables
        ''el dataset es un contenedor, repositorio
        Dim ds As New DataSet() 'System.Data.DataSet()
        Dim DA As New OleDbDataAdapter(comando)
        ''Fill= Método que Agrega filas al objeto DataSet y crea un objeto DataTable denominado "Tabla", en nuestro caso "Producto".
        DA.Fill(ds, "INSCRIPCIONES")
        ''Cierro la conexión
        dbconn.Close()
        ''Como toda función debe retornar al uso RETURN
        Return ds
    End Function
#End Region

#Region "TORNEO"
    Public Function Inscripciones_categoria_consultar(ByVal evento_id As Integer, ByVal categoria_id As Integer) As DataSet
        Try
            dbconn.Open()
        Catch ex As Exception
        End Try
        Dim comando As New OleDbCommand("Inscripciones_categoria_consultar", dbconn)
        comando.CommandType = CommandType.StoredProcedure
        comando.Parameters.Add(New OleDb.OleDbParameter("@evento_id", evento_id))
        comando.Parameters.Add(New OleDb.OleDbParameter("@categoria_id", categoria_id))
        

        ' crear dataset que sirve de contenedor para todos los datatables
        ''el dataset es un contenedor, repositorio
        Dim ds As New DataSet() 'System.Data.DataSet()
        Dim DA As New OleDbDataAdapter(comando)
        ''Fill= Método que Agrega filas al objeto DataSet y crea un objeto DataTable denominado "Tabla", en nuestro caso "Producto".
        DA.Fill(ds, "inscripciones")
        ''Cierro la conexión
        dbconn.Close()
        ''Como toda función debe retornar al uso RETURN
        Return ds
    End Function



#End Region

    Public Function Inscripcion_modificar(ByVal inscripcion_id As Integer, ByVal inscripcion_peso As Decimal, ByVal categoria_id_vieja As Integer, ByVal categoria_id_nueva As Integer) As DataSet
        Try
            dbconn.Open()
        Catch ex As Exception
        End Try
        Dim comando As New OleDbCommand("Inscripcion_modificar", dbconn)
        comando.CommandType = CommandType.StoredProcedure
        comando.Parameters.Add(New OleDb.OleDbParameter("@inscripcion_id", inscripcion_id))
        comando.Parameters.Add(New OleDb.OleDbParameter("@inscripcion_peso", inscripcion_peso))
        comando.Parameters.Add(New OleDb.OleDbParameter("@categoria_id_vieja", categoria_id_vieja))
        comando.Parameters.Add(New OleDb.OleDbParameter("@categoria_id_nueva", categoria_id_nueva))

        ' crear dataset que sirve de contenedor para todos los datatables
        ''el dataset es un contenedor, repositorio
        Dim ds As New DataSet() 'System.Data.DataSet()
        Dim DA As New OleDbDataAdapter(comando)
        ''Fill= Método que Agrega filas al objeto DataSet y crea un objeto DataTable denominado "Tabla", en nuestro caso "Producto".
        DA.Fill(ds, "inscripciones")
        ''Cierro la conexión
        dbconn.Close()
        ''Como toda función debe retornar al uso RETURN
        Return ds
    End Function


End Class
