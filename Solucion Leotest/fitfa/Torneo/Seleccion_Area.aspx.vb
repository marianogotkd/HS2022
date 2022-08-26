Public Class Seleccion_Area
    Inherits System.Web.UI.Page
    Dim DaArea As New Capa_de_datos.Area
    Dim datorneo As New Capa_de_datos.Torneo


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then


            Dim ds_Area As DataSet = DaArea.area_obtener_asignadas(Session("Evento_id"), 0)
            If ds_Area.Tables(0).Rows.Count <> 0 Then
                DropDownList1.DataSource = ds_Area.Tables(0)
                DropDownList1.DataTextField = "Area"
                DropDownList1.DataValueField = "id"
                DropDownList1.DataBind()
            End If
        End If
    End Sub


    Private Sub btn_continuar_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_continuar.ServerClick
        Session("Nom_area") = DropDownList1.SelectedItem
        Session("Area") = DropDownList1.SelectedValue
        Response.Redirect("../Inicio_Blanco.aspx")
    End Sub
End Class