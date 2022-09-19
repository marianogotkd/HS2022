Public Class Evento_Seleccionar_Torneo
    Inherits System.Web.UI.Page

    Dim DAeventos As New Capa_de_datos.Eventos
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            obtener_eventos_disponibles()
            Session("popup") = "si"
            'popup = "no"
            'choco.Visible = False

        End If
    End Sub
    Dim ds_eventos As New ds_eventos
    Private Sub obtener_eventos_disponibles()
        Dim ds_torneos As DataSet = DAeventos.Evento_Seleccionar_Torneo
        ds_eventos.Torneo.Rows.Clear()
        ds_eventos.Torneo.Merge(ds_torneos.Tables(0))

        GridView1.DataSource = ds_eventos.Torneo
        GridView1.DataBind()

    End Sub

    Private Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand

        If (e.CommandName = "ID") Then
            ' Retrieve the row index stored in the CommandArgument property.
            Dim index As Integer = Convert.ToInt32(e.CommandArgument)
            Dim id As Integer = Integer.Parse(e.CommandArgument.ToString())
            Session("evento_id") = CInt(id)
            Response.Redirect("Torneo.aspx")

        End If


    End Sub
    
End Class