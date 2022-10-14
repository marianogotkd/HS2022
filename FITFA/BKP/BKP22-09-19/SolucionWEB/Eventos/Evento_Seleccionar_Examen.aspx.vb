Public Class Evento_Seleccionar_Examen
    Inherits System.Web.UI.Page
    Dim DAeventos As New Capa_de_datos.Eventos

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            obtener_eventos_disponibles()
            Session("popup") = "si"
            'popup = "no"
            choco.Visible = False

        End If
    End Sub

    Private Sub obtener_eventos_disponibles()
        Dim ds_eventos As DataSet = DAeventos.Evento_Seleccionar_Examen()
        If ds_eventos.Tables(0).Rows.Count <> 0 Then
            DropDownList_eventos.DataSource = ds_eventos.Tables(0)
            DropDownList_eventos.DataValueField = "evento_id"
            DropDownList_eventos.DataTextField = "evento_descripcion"
            DropDownList_eventos.DataBind()
        End If
    End Sub

    Dim popup As String
    Private Sub Btn_siguiente_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btn_siguiente.ServerClick
        System.Threading.Thread.Sleep(5000)
        'valido q se seleccione un evento
        If DropDownList_eventos.Items.Count <> 0 Then
            'Session("usuario_id") = ID
            Session("evento_id") = DropDownList_eventos.SelectedValue
            Session("evento_desc") = DropDownList_eventos.SelectedItem.Text

            'Response.Redirect("Inscripcion _varios.aspx")
            Response.Redirect("Examen.aspx")
        Else
            'aqui llamo al cartel q muestra q no hay eventos disponibles
            popup = "no" 'si es no...no lo pongo en visible=false
            'choco.Visible = True
            choco.Visible = True
            Label12.Text = "choquito"
            ModalPopupExtender1.Show()
        End If
    End Sub


End Class