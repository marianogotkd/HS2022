Public Class LiquidacionGrupos_det
  Inherits System.Web.UI.Page

  Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    If Not IsPostBack Then

      Dim DS_liqgrupos As New DS_liqgrupos
      DS_liqgrupos.Tables("LiqGrupos").Merge(Session("Tabla_LiqGrupos"))
      GridView1.DataSource = DS_liqgrupos.Tables("LiqGrupos")
      GridView1.DataBind()

    End If
  End Sub

  Private Sub btn_continuar_ServerClick(sender As Object, e As EventArgs) Handles btn_continuar.ServerClick
    Response.Redirect("~/Inicio.aspx")
  End Sub
End Class
