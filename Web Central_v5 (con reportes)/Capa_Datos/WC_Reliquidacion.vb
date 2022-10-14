Imports System.Data.OleDb
Imports System.Data.DataRow
Public Class WC_Reliquidacion
    Inherits Capa_Datos.Conexion

    Public Function Reliquidacion_Obtener_directorioBD() As DataSet
        Try
            dbconn.Open()
        Catch ex As Exception
        End Try
        Dim comando As New OleDbCommand("Reliquidacion_Obtener_directorioBD", dbconn)
        comando.CommandType = CommandType.StoredProcedure

        Dim ds As New DataSet()
        Dim DA As New OleDbDataAdapter(comando)

        DA.Fill(ds, "DirectorioBD")
        ''Cierro la conexión
        dbconn.Close()
        Return ds
    End Function


    Public Function restore_backup_WebCentral(ByVal bdName As String, ByVal PathTarget As String, ByVal devicePhyname As String) As DataSet
        Try
            dbconnMaster.Open()
        Catch ex As Exception
        End Try
        Dim comando As New OleDbCommand("restore_backup", dbconnMaster)
        comando.CommandType = CommandType.StoredProcedure
        comando.Parameters.Add(New OleDb.OleDbParameter("@bdName", bdName)) 'NOMBRE DE NUEVA BD
        comando.Parameters.Add(New OleDb.OleDbParameter("@PathTarget", PathTarget)) 'RUTA DESTINO DONDE SE GUARDARAN LOS ARCHIVOS .MDF Y .LDF
        comando.Parameters.Add(New OleDb.OleDbParameter("@devicePhyname", devicePhyname)) 'RUTA ORIGEN DONDE SE ENCUENTRA EL ARCHIVO .BAK


        Dim ds As New DataSet()
        Dim DA As New OleDbDataAdapter(comando)
        ''Fill= Método que Agrega filas al objeto DataSet y crea un objeto DataTable denominado "Tabla", en nuestro caso "Grupo".
        DA.Fill(ds, "BD_NUEVA")
        ''Cierro la conexión
        dbconnMaster.Close()
        Return ds
    End Function


    Public Function Reliquidacion_CerrarConexion() As DataSet
        Try
            dbconnMaster.Open()
        Catch ex As Exception
        End Try
        Dim comando As New OleDbCommand("Reliquidacion_CerrarConexion", dbconnMaster)
        comando.CommandType = CommandType.StoredProcedure

        Dim ds As New DataSet()
        Dim DA As New OleDbDataAdapter(comando)

        DA.Fill(ds, "CerrarConexion")
        ''Cierro la conexión
        dbconnMaster.Close()
        Return ds
    End Function


    Public Function Reliquidacion_TerminalesEstado(ByVal Terminales As Integer) As DataSet
        'se cambia el estado del campo Terminales ... 0 para deshabilitar, 1 para habilitar
        Try
            dbconn.Open()
        Catch ex As Exception
        End Try
        Dim comando As New OleDbCommand("Reliquidacion_TerminalesEstado", dbconn)
        comando.CommandType = CommandType.StoredProcedure
        comando.Parameters.Add(New OleDb.OleDbParameter("@Terminales", Terminales))

        Dim ds As New DataSet()
        Dim DA As New OleDbDataAdapter(comando)

        DA.Fill(ds, "Parametro")
        ''Cierro la conexión
        dbconn.Close()
        Return ds
    End Function

    Public Function Reliquidacion_ObtenerDeBkp() As DataSet
        'se cambia el estado del campo Terminales ... 0 para deshabilitar, 1 para habilitar
        Try
            dbconn.Open()
        Catch ex As Exception
        End Try
        Dim comando As New OleDbCommand("Reliquidacion_ObtenerDeBkp", dbconn)
        comando.CommandType = CommandType.StoredProcedure
        'comando.Parameters.Add(New OleDb.OleDbParameter("@Terminales", Terminales))

        Dim ds As New DataSet()
        Dim DA As New OleDbDataAdapter(comando)

        DA.Fill(ds, "Bkp")
        ''Cierro la conexión
        dbconn.Close()
        Return ds
    End Function



End Class
