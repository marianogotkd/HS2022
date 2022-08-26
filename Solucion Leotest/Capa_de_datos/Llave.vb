Imports System.Data.OleDb
Imports System.Data.DataRow
Public Class Llave
    Inherits Capa_de_datos.Conexion


    Public Function Llave_item_alta(ByVal Llave_item_usuario_id As Integer, ByVal Llave_item_PIzq As Integer,
ByVal Llave_item_PDerecho As Integer,
ByVal Llave_item_nivel As Integer,
ByVal Llave_item_Numero As Integer, ByVal estado As String, ByVal Llave_id As Integer) As DataSet
        Try
            dbconn.Open()
        Catch ex As Exception
        End Try
        Dim comando As New OleDbCommand("Llave_item_alta", dbconn)
        comando.CommandType = CommandType.StoredProcedure
        comando.Parameters.Add(New OleDb.OleDbParameter("@Llave_item_usuario_id", Llave_item_usuario_id))
        comando.Parameters.Add(New OleDb.OleDbParameter("@Llave_item_PIzq", Llave_item_PIzq))
        comando.Parameters.Add(New OleDb.OleDbParameter("@Llave_item_PDerecho", Llave_item_PDerecho))
        comando.Parameters.Add(New OleDb.OleDbParameter("@Llave_item_nivel", Llave_item_nivel))
        comando.Parameters.Add(New OleDb.OleDbParameter("@Llave_item_Numero", Llave_item_Numero))
        comando.Parameters.Add(New OleDb.OleDbParameter("@estado", estado))
        comando.Parameters.Add(New OleDb.OleDbParameter("@Llave_id", Llave_id))
        Dim ds_JE As New DataSet()
        Dim da_JE As New OleDbDataAdapter(comando)
        da_JE.Fill(ds_JE, "llave")
        dbconn.Close()
        Return ds_JE
    End Function

    Public Function Llave_item_actualizar(ByVal LLave_item_id As Integer) As DataSet
        Try
            dbconn.Open()
        Catch ex As Exception
        End Try
        Dim comando As New OleDbCommand("Llave_item_actualizar", dbconn)
        comando.CommandType = CommandType.StoredProcedure
        comando.Parameters.Add(New OleDb.OleDbParameter("@LLave_item_id", LLave_item_id))
        Dim ds_JE As New DataSet()
        Dim da_JE As New OleDbDataAdapter(comando)
        da_JE.Fill(ds_JE, "llave")
        dbconn.Close()
        Return ds_JE
    End Function

    Public Function Llave_item_actualizar_progreso(ByVal LLave_item_id As Integer, ByVal Llave_item_usuario_id As Integer) As DataSet
        Try
            dbconn.Open()
        Catch ex As Exception
        End Try
        Dim comando As New OleDbCommand("Llave_item_actualizar_progreso", dbconn)
        comando.CommandType = CommandType.StoredProcedure
        comando.Parameters.Add(New OleDb.OleDbParameter("@LLave_item_id", LLave_item_id))
        comando.Parameters.Add(New OleDb.OleDbParameter("@Llave_item_usuario_id", Llave_item_usuario_id))
        Dim ds_JE As New DataSet()
        Dim da_JE As New OleDbDataAdapter(comando)
        da_JE.Fill(ds_JE, "llave")
        dbconn.Close()
        Return ds_JE
    End Function

    Public Function Llave_item_actualizar_raiz(ByVal LLave_item_id As Integer) As DataSet
        Try
            dbconn.Open()
        Catch ex As Exception
        End Try
        Dim comando As New OleDbCommand("Llave_item_actualizar_raiz", dbconn)
        comando.CommandType = CommandType.StoredProcedure
        comando.Parameters.Add(New OleDb.OleDbParameter("@LLave_item_id", LLave_item_id))
        Dim ds_JE As New DataSet()
        Dim da_JE As New OleDbDataAdapter(comando)
        da_JE.Fill(ds_JE, "llave")
        dbconn.Close()
        Return ds_JE
    End Function


    Public Function Llave_item_actualizar_usuario(ByVal LLave_item_id As Integer, ByVal Llave_item_usuario_id As Integer) As DataSet
        Try
            dbconn.Open()
        Catch ex As Exception
        End Try
        Dim comando As New OleDbCommand("Llave_item_actualizar_usuario", dbconn)
        comando.CommandType = CommandType.StoredProcedure
        comando.Parameters.Add(New OleDb.OleDbParameter("@LLave_item_id", LLave_item_id))
        comando.Parameters.Add(New OleDb.OleDbParameter("@Llave_item_usuario_id", Llave_item_usuario_id))
        Dim ds_JE As New DataSet()
        Dim da_JE As New OleDbDataAdapter(comando)
        da_JE.Fill(ds_JE, "llave")
        dbconn.Close()
        Return ds_JE
    End Function

    Public Function Llave_item_consulta(ByVal Llave_id As Integer) As DataSet
        Try
            dbconn.Open()
        Catch ex As Exception
        End Try
        Dim comando As New OleDbCommand("Llave_item_consulta", dbconn)
        comando.CommandType = CommandType.StoredProcedure
        comando.Parameters.Add(New OleDb.OleDbParameter("@Llave_id", Llave_id))
        Dim ds_JE As New DataSet()
        Dim da_JE As New OleDbDataAdapter(comando)
        da_JE.Fill(ds_JE, "Usuario")
        dbconn.Close()
        Return ds_JE
    End Function

    Public Function Llave_item_consulta_nivel(ByVal Llave_item_nivel As Integer, ByVal Llave_id As Integer) As DataSet
        Try
            dbconn.Open()
        Catch ex As Exception
        End Try
        Dim comando As New OleDbCommand("Llave_item_consulta_nivel", dbconn)
        comando.CommandType = CommandType.StoredProcedure
        comando.Parameters.Add(New OleDb.OleDbParameter("@Llave_item_nivel", Llave_item_nivel))
        comando.Parameters.Add(New OleDb.OleDbParameter("@Llave_id", Llave_id))
        Dim ds_JE As New DataSet()
        Dim da_JE As New OleDbDataAdapter(comando)
        da_JE.Fill(ds_JE, "Usuario")
        dbconn.Close()
        Return ds_JE
    End Function

    Public Function Llave_item_borrar_hoja(ByVal LLave_item_id As Integer) As DataSet
        Try
            dbconn.Open()
        Catch ex As Exception
        End Try
        Dim comando As New OleDbCommand("Llave_item_borrar_hoja", dbconn)
        comando.CommandType = CommandType.StoredProcedure
        comando.Parameters.Add(New OleDb.OleDbParameter("@LLave_item_id", LLave_item_id))
        Dim ds_JE As New DataSet()
        Dim da_JE As New OleDbDataAdapter(comando)
        da_JE.Fill(ds_JE, "llave")
        dbconn.Close()
        Return ds_JE
    End Function

    Public Function Llave_item_quitar_enlace(ByVal LLave_item_id As Integer) As DataSet
        Try
            dbconn.Open()
        Catch ex As Exception
        End Try
        Dim comando As New OleDbCommand("Llave_item_quitar_enlace", dbconn)
        comando.CommandType = CommandType.StoredProcedure
        comando.Parameters.Add(New OleDb.OleDbParameter("@LLave_item_id", LLave_item_id))
        Dim ds_JE As New DataSet()
        Dim da_JE As New OleDbDataAdapter(comando)
        da_JE.Fill(ds_JE, "Usuario")
        dbconn.Close()
        Return ds_JE
    End Function

    Public Function LLave_obtener_inscriptos(ByVal evento_id As Integer) As DataSet
        Try
            dbconn.Open()
        Catch ex As Exception
        End Try
        Dim comando As New OleDbCommand("LLave_obtener_inscriptos", dbconn)
        comando.CommandType = CommandType.StoredProcedure
        comando.Parameters.Add(New OleDb.OleDbParameter("@evento_id", evento_id))

        Dim ds_JE As New DataSet()
        Dim da_JE As New OleDbDataAdapter(comando)
        da_JE.Fill(ds_JE, "llave")
        dbconn.Close()
        Return ds_JE
    End Function


    Public Function Llave_obtener_llaves_generadas_info(ByVal evento_id As Integer) As DataSet
        Try
            dbconn.Open()
        Catch ex As Exception
        End Try
        Dim comando As New OleDbCommand("Llave_obtener_llaves_generadas_info", dbconn)
        comando.CommandType = CommandType.StoredProcedure
        comando.Parameters.Add(New OleDb.OleDbParameter("@evento_id", evento_id))


        Dim ds_JE As New DataSet()
        Dim da_JE As New OleDbDataAdapter(comando)
        da_JE.Fill(ds_JE, "llave")
        dbconn.Close()
        Return ds_JE
    End Function


    Public Function Llave_obtener_llaves_generadas_infoArea(ByVal evento_id As Integer, ByVal area_id As Integer) As DataSet
        Try
            dbconn.Open()
        Catch ex As Exception
        End Try
        Dim comando As New OleDbCommand("Llave_obtener_llaves_generadas_infoArea", dbconn)
        comando.CommandType = CommandType.StoredProcedure
        comando.Parameters.Add(New OleDb.OleDbParameter("@evento_id", evento_id))
        comando.Parameters.Add(New OleDb.OleDbParameter("@area_id", area_id))
        Dim ds_JE As New DataSet()
        Dim da_JE As New OleDbDataAdapter(comando)
        da_JE.Fill(ds_JE, "llave")
        dbconn.Close()
        Return ds_JE
    End Function

    Public Function LLave_obtener_inscriptos_filtrados(ByVal evento_id As Integer, ByVal categoria_tipo As String) As DataSet
        Try
            dbconn.Open()
        Catch ex As Exception
        End Try
        Dim comando As New OleDbCommand("LLave_obtener_inscriptos_filtrados", dbconn)
        comando.CommandType = CommandType.StoredProcedure
        comando.Parameters.Add(New OleDb.OleDbParameter("@evento_id", evento_id))
        comando.Parameters.Add(New OleDb.OleDbParameter("@categoria_tipo", categoria_tipo))

        Dim ds_JE As New DataSet()
        Dim da_JE As New OleDbDataAdapter(comando)
        da_JE.Fill(ds_JE, "llave")
        dbconn.Close()
        Return ds_JE
    End Function

    Public Function LLave_obtener_inscriptos_sin_llave(ByVal evento_id As Integer, ByVal categoria_id As Integer) As DataSet
        Try
            dbconn.Open()
        Catch ex As Exception
        End Try
        Dim comando As New OleDbCommand("LLave_obtener_inscriptos_sin_llave", dbconn)
        comando.CommandType = CommandType.StoredProcedure
        comando.Parameters.Add(New OleDb.OleDbParameter("@evento_id", evento_id))
        comando.Parameters.Add(New OleDb.OleDbParameter("@categoria_id", categoria_id))

        Dim ds_JE As New DataSet()
        Dim da_JE As New OleDbDataAdapter(comando)
        da_JE.Fill(ds_JE, "llave")
        dbconn.Close()
        Return ds_JE
    End Function



    'esta rutina me trae todos los inscritos en un determinada categoria y evento.
    Public Function LLave_obtener_inscriptos_categoria(ByVal evento_id As Integer, ByVal categoria_id As Integer) As DataSet
        Try
            dbconn.Open()
        Catch ex As Exception
        End Try
        Dim comando As New OleDbCommand("LLave_obtener_inscriptos_categoria", dbconn)
        comando.CommandType = CommandType.StoredProcedure
        comando.Parameters.Add(New OleDb.OleDbParameter("@evento_id", evento_id))
        comando.Parameters.Add(New OleDb.OleDbParameter("@categoria_id", categoria_id))
        Dim ds_JE As New DataSet()
        Dim da_JE As New OleDbDataAdapter(comando)
        da_JE.Fill(ds_JE, "llave")
        dbconn.Close()
        Return ds_JE
    End Function

    Public Function Llave_alta(ByVal evento_id As Integer, ByVal categoria_id As Integer, ByVal Llave_cantidad As Integer, ByVal area_id As Integer) As DataSet
        Try
            dbconn.Open()
        Catch ex As Exception
        End Try

        Dim comando As New OleDbCommand("Llave_alta", dbconn)
        comando.CommandType = CommandType.StoredProcedure

        comando.Parameters.Add(New OleDb.OleDbParameter("@evento_id", evento_id))
        comando.Parameters.Add(New OleDb.OleDbParameter("@categoria_id", categoria_id))
        comando.Parameters.Add(New OleDb.OleDbParameter("@Llave_cantidad", Llave_cantidad))
        comando.Parameters.Add(New OleDb.OleDbParameter("@area_id", area_id))

        Dim ds_JE As New DataSet()
        Dim da_JE As New OleDbDataAdapter(comando)
        da_JE.Fill(ds_JE, "llave")
        dbconn.Close()
        Return ds_JE
    End Function



    Public Function LLave_obtener_llavegenerada_etc(ByVal evento_id As Integer, ByVal categoria_id As Integer) As DataSet
        Try
            dbconn.Open()
        Catch ex As Exception
        End Try
        Dim comando As New OleDbCommand("LLave_obtener_llavegenerada_etc", dbconn)
        comando.CommandType = CommandType.StoredProcedure
        comando.Parameters.Add(New OleDb.OleDbParameter("@evento_id", evento_id))
        comando.Parameters.Add(New OleDb.OleDbParameter("@categoria_id", categoria_id))
        Dim ds_JE As New DataSet()
        Dim da_JE As New OleDbDataAdapter(comando)
        da_JE.Fill(ds_JE, "llave")
        dbconn.Close()
        Return ds_JE
    End Function

    Public Function LLave_obtener_llavegenerada_etc_2(ByVal Llave_id As Integer) As DataSet
        Try
            dbconn.Open()
        Catch ex As Exception
        End Try
        Dim comando As New OleDbCommand("LLave_obtener_llavegenerada_etc_2", dbconn)
        comando.CommandType = CommandType.StoredProcedure
        comando.Parameters.Add(New OleDb.OleDbParameter("@Llave_id", Llave_id))
        Dim ds_JE As New DataSet()
        Dim da_JE As New OleDbDataAdapter(comando)
        da_JE.Fill(ds_JE, "llave")
        dbconn.Close()
        Return ds_JE
    End Function



    Public Function llave_eliminar(ByVal llave_id As Integer) As DataSet
        Try
            dbconn.Open()
        Catch ex As Exception
        End Try
        Dim comando As New OleDbCommand("llave_eliminar", dbconn)
        comando.CommandType = CommandType.StoredProcedure
        comando.Parameters.Add(New OleDb.OleDbParameter("@llave_id", llave_id))
        Dim ds_JE As New DataSet()
        Dim da_JE As New OleDbDataAdapter(comando)
        da_JE.Fill(ds_JE, "llave")
        dbconn.Close()
        Return ds_JE
    End Function

    Public Function Llave_deshacer_llave(ByVal usuario_id As Integer, ByVal evento_id As Integer, ByVal categoria_id As Integer) As DataSet
        Try
            dbconn.Open()
        Catch ex As Exception
        End Try
        Dim comando As New OleDbCommand("Llave_deshacer_llave", dbconn)
        comando.CommandType = CommandType.StoredProcedure
        comando.Parameters.Add(New OleDb.OleDbParameter("@usuario_id", usuario_id))
        comando.Parameters.Add(New OleDb.OleDbParameter("@evento_id", evento_id))
        comando.Parameters.Add(New OleDb.OleDbParameter("@categoria_id", categoria_id))
        Dim ds_JE As New DataSet()
        Dim da_JE As New OleDbDataAdapter(comando)
        da_JE.Fill(ds_JE, "llave")
        dbconn.Close()
        Return ds_JE
    End Function


    Public Function Llave_Verificar_existencia(ByVal cat_id As Integer, ByVal evento_id As Integer) As DataSet
        Try
            dbconn.Open()
        Catch ex As Exception
        End Try
        Dim comando As New OleDbCommand("Llave_Verificar_existencia", dbconn)
        comando.CommandType = CommandType.StoredProcedure
        comando.Parameters.Add(New OleDb.OleDbParameter("@cat_id", cat_id))
        comando.Parameters.Add(New OleDb.OleDbParameter("@evento_id", evento_id))
        Dim ds_JE As New DataSet()
        Dim da_JE As New OleDbDataAdapter(comando)
        da_JE.Fill(ds_JE, "llave")
        dbconn.Close()
        Return ds_JE
    End Function

End Class
