Public Class Evento_seleccionar
    Inherits System.Web.UI.Page
    Dim DAeventos As New Capa_de_datos.Eventos
    Dim DAinscripciones As New Capa_de_datos.Inscripciones
    Dim ds_a As New evento_ds


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            no_evento.Visible = False
            div_Modal_error_inscripto.Visible = False
            obtener_eventos_disponibles()
            Session("popup") = "si"
            'popup = "no"
            choco.Visible = False
            If Session("ConDni") = True Then
                Master.FindControl("Menu_Web").Visible = False
            End If

            If Session("tipo") = "Invitado" Then
                Master.FindControl("Menu_Web").Visible = False
            End If


        End If

    End Sub

    Private Sub obtener_eventos_disponibles()
        Dim ds_eventos As DataSet = DAeventos.Evento_ObetenerEventos()
        'If ds_eventos.Tables(1).Rows.Count <> 0 Then
        '    DropDownList_eventos.DataSource = ds_eventos.Tables(1)
        '    DropDownList_eventos.DataValueField = "id"
        '    DropDownList_eventos.DataTextField = "desc"
        '    DropDownList_eventos.DataBind()
        'End If

        If ds_eventos.Tables(2).Rows.Count <> 0 Then
            ds_a.eventos_disponibles.Merge(ds_eventos.Tables(2))
            GridView1.DataSource = ds_a.eventos_disponibles
            GridView1.DataBind()
        Else
            no_evento.Visible = True
            'choco.Visible = True
            '    Label12.Text = "choquito"
            'ModalPopupExtender1.Show()
        End If

    End Sub


    'System.Threading.Thread.Sleep(5000)
    'valido q se seleccione un evento
    'If DropDownList_eventos.Items.Count <> 0 Then
    '    'Session("usuario_id") = ID
    '    Session("evento_id") = DropDownList_eventos.SelectedValue
    '    Session("evento_desc") = DropDownList_eventos.SelectedItem.Text

    '    Response.Redirect("Evento_datos.aspx")
    'Else
    '    'aqui llamo al cartel q muestra q no hay eventos disponibles
    '    popup = "no" 'si es no...no lo pongo en visible=false
    '    'choco.Visible = True
    '    choco.Visible = True
    '    Label12.Text = "choquito"
    '    ModalPopupExtender1.Show()
    'End If

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


    Private Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
        If Session("tipo") = "Invitado" Then
            Session("SERVER_inscripcion_id") = 0
            If (e.CommandName = "ID") Then
                ' Retrieve the row index stored in the CommandArgument property.
                Dim index As Integer = Convert.ToInt32(e.CommandArgument)
                Dim id As Integer = Integer.Parse(e.CommandArgument.ToString())
                'Session("usuario_id") = id
                'Response.Redirect("Mensaje_Datos_Personales.aspx")
                Session("evento_id") = id

                Dim i As Integer = 0
                While i < GridView1.Rows.Count
                    Dim id_evento As Integer = CInt(GridView1.Rows(i).Cells(0).Text)
                    If id_evento = index Then
                        Session("evento_desc") = GridView1.Rows(i).Cells(1).Text
                        Session("SERVER_inscripcion_id") = 0
                        i = GridView1.Rows.Count
                        Response.Redirect("Evento_datos.aspx")
                    Else
                        i = i + 1
                    End If
                End While

            End If


        Else
            Session("SERVER_inscripcion_id") = 0
            If (e.CommandName = "ID") Then
                ' Retrieve the row index stored in the CommandArgument property.
                Dim index As Integer = Convert.ToInt32(e.CommandArgument)
                Dim id As Integer = Integer.Parse(e.CommandArgument.ToString())
                'Session("usuario_id") = id
                'Response.Redirect("Mensaje_Datos_Personales.aspx")
                Session("evento_id") = id

                'valido si el usuario no se ha inscripto ya.
                Dim usuario_id As Integer = Session("Us_id")
                Dim ds_inscripto As DataSet = DAinscripciones.Inscripcion_consultar_alumno_inscripto(id, usuario_id)

                If ds_inscripto.Tables(0).Rows.Count = 0 Then
                    Dim i As Integer = 0
                    While i < GridView1.Rows.Count
                        Dim id_evento As Integer = CInt(GridView1.Rows(i).Cells(0).Text)
                        If id_evento = index Then
                            Session("evento_desc") = GridView1.Rows(i).Cells(1).Text
                            Session("SERVER_inscripcion_id") = 0
                            i = GridView1.Rows.Count
                            Response.Redirect("Evento_datos.aspx")
                        Else
                            i = i + 1
                        End If
                    End While
                Else
                    'sino ya esta inscripto
                    div_Modal_error_inscripto.Visible = True
                    Modal_error_inscripto.Show()

                End If
            End If
        End If

        


    End Sub

    Private Sub Btn_Modal_si_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btn_Modal_si.Click
        DAinscripciones.Inscripcion_borrar_alumno(Session("Us_id"), Session("evento_id"))
    End Sub
End Class