Imports System.Data.OleDb
Imports System.Data.DataRow
Public Class WB_Consultas
    Inherits Capa_Datos.Conexion
    '''####hola a todos 19:00

    Public Function CargasClientesDesdeHasta(ByVal Desde As String, ByVal Hasta As String, ByVal Codigos As String, ByVal Fecha As String) As DataTable
        Try
            dbconn.Open()
        Catch ex As Exception
        End Try
        Dim Consulta As String = ""

        Fecha = "'" + Fecha.ToString + "'" 'le agrego comillas a la fecha

        Consulta += "SELECT Pid,Importe,Recorrido_codigo FROM Xcargas"
        Consulta += " INNER JOIN XCargas_Recorridos ON XCargas.IDcarga = XCargas_Recorridos.IDcarga "
        Consulta += " WHERE Cliente BETWEEN " + Desde + " AND " + Hasta
        Consulta += " AND (Recorrido_Codigo IN (" + Codigos + "))"
        Consulta += " AND Fecha = " + Fecha

        Dim DA As New OleDbDataAdapter(Consulta, dbconn)
        Dim ds As New DataSet()
        DA.Fill(ds, "Clientes")
        dbconn.Close()
        Return ds.Tables(0)
        ''''### son las 20:16
    End Function


    Public Function Cargas_Zona_PID(ByVal Codigos As String, ByVal Pid As String, ByVal Fecha As String) As DataTable
        Try
            dbconn.Open()
        Catch ex As Exception
        End Try
        Dim Consulta As String = ""

        Fecha = "'" + Fecha.ToString + "'" 'le agrego comillas a la fecha

        Consulta += "SELECT Pid,Importe,Recorrido_codigo FROM Xcargas"
        Consulta += " INNER JOIN XCargas_Recorridos ON XCargas.IDcarga = XCargas_Recorridos.IDcarga "
        'Consulta += " WHERE Cliente BETWEEN " + Desde + " AND " + Hasta
        Consulta += " WHERE (Recorrido_Codigo IN (" + Codigos + "))"
        Consulta += "AND Pid = " + Pid
        Consulta += " AND Fecha = " + Fecha

        Dim DA As New OleDbDataAdapter(Consulta, dbconn)
        Dim ds As New DataSet()
        DA.Fill(ds, "Clientes")
        dbconn.Close()
        Return ds.Tables(0)
        ''''### son las 20:16
    End Function


    Public Function IngresoTerminales() As DataTable
        Try
            dbconn.Open()
        Catch ex As Exception
        End Try
        Dim Consulta As String = ""

        Consulta += "SELECT Terminal, COUNT(*) Registros , CONVERT(TIME, MAX(Hora)) Ultima_Carga FROM XCargas "
        'Consulta += " INNER JOIN XCargas_Recorridos ON XCargas.IDcarga = XCargas_Recorridos.IDcarga "
        Consulta += " GROUP BY Terminal"

        Dim DA As New OleDbDataAdapter(Consulta, dbconn)

        Dim ds As New DataSet()
        DA.Fill(ds, "Clientes")

        dbconn.Close()
        Return ds.Tables(0)

    End Function


End Class
