Imports System.IO
Imports System.Data.OleDb
Imports System.Data
Public Class mailbox
    Inherits System.Web.UI.Page
    Dim DAusuario As New Capa_de_datos.usuario
    Dim ds_consultas As New DataSet1

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        Chkokarriba.Visible = False
        chkokabajo.Visible = False
        div.Visible = False

        If Not IsPostBack Then

            Buscar_Pendientes()

        End If

    End Sub




#Region "Public Subs"

    

    Public Sub Buscar_Pendientes()

        Dim busqueda As New Data.DataSet
        busqueda = DAusuario.Solicitudes_Pendientes(Session("Us_id"))
        ' ds_consultas.datos.Merge(busqueda.Tables(0))
        Dim datatable As DataTable
        datatable = busqueda.Tables(0)

        GridView1.DataSource = datatable

        If busqueda.Tables(0).Rows.Count <> 0 Then
            GridView1.DataBind()

            'oculto las columnas q no necesito
            Me.GridView1.HeaderRow.Cells(2).Visible = False
            Me.GridView1.HeaderRow.Cells(6).Visible = False
            Me.GridView1.HeaderRow.Cells(7).Visible = False

            'rutina para ocultar celdas q no necesito
            Dim contador As Integer
            contador = 0
            Do While contador < Me.GridView1.Rows.Count
                Me.GridView1.Rows(contador).Cells(2).Visible = False
                Me.GridView1.Rows(contador).Cells(6).Visible = False
                Me.GridView1.Rows(contador).Cells(7).Visible = False

                If GridView1.Rows(contador).Cells(6).Text = "alumno" Then

                    'Cambio Los Mensajes
                    GridView1.Rows(contador).Cells(4).Text = "Solicitud Nuevo Usuario Registrado"
                Else
                    If GridView1.Rows(contador).Cells(6).Text = "instructor" Then
                        GridView1.Rows(contador).Cells(4).Text = "Solicitud Nuevo Instructor Registrado"
                    End If
                End If



                contador = contador + 1
            Loop
        Else
            div.Visible = True
            GridView1.DataBind()

        End If


    End Sub

    Public Sub Selectall()
        Dim indice As Integer = 0
        Dim SELECCIONADO As CheckBox
        Do While indice < Me.GridView1.Rows.Count

            chkallArriba.Visible = False
            Chkallabajo.Visible = False
            Chkokarriba.Visible = True
            chkokabajo.Visible = True

            SELECCIONADO = CType(Me.GridView1.Rows.Item(indice).FindControl("CheckBox1"), CheckBox)
            SELECCIONADO.Checked = True
            indice = indice + 1
        Loop
    End Sub
    Public Sub desSelectall()
        Dim indice As Integer = 0
        Dim SELECCIONADO As CheckBox
        Do While indice < Me.GridView1.Rows.Count

            chkallArriba.Visible = True
            Chkallabajo.Visible = True
            Chkokarriba.Visible = False
            chkokabajo.Visible = False

            SELECCIONADO = CType(Me.GridView1.Rows.Item(indice).FindControl("CheckBox1"), CheckBox)
            SELECCIONADO.Checked = False
            indice = indice + 1
        Loop
    End Sub

    Public Sub Solicitudes(ByVal Boton As String)
        Dim indice As Integer = 0
        Dim SELECCIONADO As CheckBox

        Do While indice < Me.GridView1.Rows.Count
            SELECCIONADO = CType(Me.GridView1.Rows.Item(indice).FindControl("CheckBox1"), CheckBox)
            If SELECCIONADO.Checked = True Then
                If Boton = "Activar" Then
                    DAusuario.Activar_Usuario(GridView1.Rows(indice).Cells(2).Text, Session("Us_id"), GridView1.Rows(indice).Cells(6).Text, GridView1.Rows(indice).Cells(7).Text)
                Else
                    DAusuario.Desactivar_Usuario(GridView1.Rows(indice).Cells(2).Text)
                End If

            End If
            indice = indice + 1
        Loop

        Buscar_Pendientes()


    End Sub

#End Region


    Private Sub chkallArriba_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkallArriba.ServerClick
        Selectall()
    End Sub

    Private Sub Chkokarriba_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Chkokarriba.ServerClick
        desSelectall()
    End Sub

    Private Sub chkokabajo_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkokabajo.ServerClick
        desSelectall()
    End Sub
    Private Sub Chkallabajo_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Chkallabajo.ServerClick

        Selectall()


    End Sub

    Private Sub AceptarAb_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles AceptarAb.ServerClick
        Solicitudes("Activar")
    End Sub

    Private Sub AceptarArr_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles AceptarArr.ServerClick
        Solicitudes("Activar")
    End Sub

    Private Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
        If (e.CommandName = "ID") Then
            ' Retrieve the row index stored in the CommandArgument property.
            Dim index As Integer = Convert.ToInt32(e.CommandArgument)
            Dim id As Integer = Integer.Parse(e.CommandArgument.ToString())

            Session("usuario_id") = id
            Response.Redirect("Mensaje_Datos_Personales.aspx")

        End If

    End Sub


    Private Sub BorrarAb_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles BorrarAb.ServerClick
        Solicitudes("Desactivar")
    End Sub

    Private Sub BorrarArr_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles BorrarArr.ServerClick
        Solicitudes("Desactivar")
    End Sub

    Private Sub actulizarab_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles actulizarab.ServerClick
        Response.Redirect("mailbox.aspx")
    End Sub

    Private Sub actulizarArr_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles actulizarArr.ServerClick
        Response.Redirect("mailbox.aspx")
    End Sub
End Class