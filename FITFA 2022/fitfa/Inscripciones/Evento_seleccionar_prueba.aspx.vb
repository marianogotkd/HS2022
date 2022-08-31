Public Class Evento_seleccionar_prueba
    Inherits System.Web.UI.Page
    Dim DAeventos As New Capa_de_datos.Eventos
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            obtener_eventos_disponibles()
            Session("popup") = "si"
            'popup = "no"

        End If
    End Sub

    Private Sub obtener_eventos_disponibles()

        Dim ds_eventos As DataSet = DAeventos.Evento_ObetenerEventos()
        If ds_eventos.Tables(1).Rows.Count <> 0 Then
            DropDownList_eventos.DataSource = ds_eventos.Tables(1)
            DropDownList_eventos.DataValueField = "id"
            DropDownList_eventos.DataTextField = "desc"
            DropDownList_eventos.DataBind()
        End If
    End Sub





    Private Sub Btn_siguiente_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btn_siguiente.ServerClick


        'valido q se seleccione un evento
        If DropDownList_eventos.DataSource <> "" Then
            Session("usuario_id") = ID
            Session("evento_id") = DropDownList_eventos.SelectedValue
            Session("evento_desc") = DropDownList_eventos.SelectedItem.Text
            Response.Redirect("Evento_datos.aspx")

        Else
            'aqui llamo al cartel q muestra q no hay eventos disponibles
            popup = "no" 'si es no...no lo pongo en visible=false
            'Panel1.Visible = True

            ModalPopupExtender1.Show()

        End If


    End Sub

    Private Sub Panel1_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Panel1.Disposed
        'If popup = "no" Then
        '    Panel1.Visible = True
        'End If
    End Sub

    Dim popup As String
    Private Sub Panel1_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Panel1.Init
        'If Session("popup") = "" Then
        '    Panel1.Visible = False
        'Else
        '    Panel1.Visible = True
        'End If

    End Sub

    Private Sub Panel1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Panel1.Load
        'aqui no anda
        'If popup = "no" Then
        '    Panel1.Visible = True
        'End If


    End Sub

    Private Sub Panel1_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles Panel1.PreRender
        'If popup = "no" Then
        '    Panel1.Visible = True
        'End If

    End Sub

    Private Sub ModalPopupExtender1_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles ModalPopupExtender1.Disposed
        'If popup = "no" Then
        '    Panel1.Visible = True
        'End If
    End Sub

    Private Sub ModalPopupExtender1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles ModalPopupExtender1.Load
        'If popup = "no" Then
        '    Panel1.Visible = True
        'End If
    End Sub

    Private Sub ModalPopupExtender1_ResolveControlID(ByVal sender As Object, ByVal e As AjaxControlToolkit.ResolveControlEventArgs) Handles ModalPopupExtender1.ResolveControlID
        'If popup = "no" Then
        '    Panel1.Visible = True
        'End If
    End Sub



End Class