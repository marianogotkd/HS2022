Public Class Institucion_modificar
    Inherits System.Web.UI.Page
    Dim DAinstitucion As New Capa_de_datos.Instituciones


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim ds_institucion As DataSet = DAinstitucion.Institucion_obtenertodo
            GridView1.DataSource = ds_institucion.Tables(0)
            GridView1.DataBind()
        End If


    End Sub

    Private Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand

        If (e.CommandName = "institucion_id") Then
            Dim institucion_id As Integer = Integer.Parse(e.CommandArgument.ToString())
            Session("ID_institucion") = institucion_id
            Response.Redirect("~/Instituciones/Institucion_modificar_datos.aspx")

        End If


    End Sub

    Private Sub Nuevo_institucion_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Nuevo_institucion.ServerClick

        Session("procedencia") = "solo_institucion"
        Response.Redirect("~/Instituciones/Institucion_alta.aspx")

    End Sub
End Class