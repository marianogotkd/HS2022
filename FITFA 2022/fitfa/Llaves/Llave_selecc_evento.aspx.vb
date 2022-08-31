Public Class Llave_selecc_evento
    Inherits System.Web.UI.Page
    Dim DAeventos As New Capa_de_datos.Eventos
    Dim DAinscripciones As New Capa_de_datos.Inscripciones
    Dim ds_a As New evento_ds

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            no_evento.Visible = False
            'div_Modal_error_inscripto.Visible = False
            obtener_eventos_disponibles()
            Session("popup") = "si"
            'popup = "no"
            evento_disp_div.Visible = False

        End If
    End Sub

    Private Sub obtener_eventos_disponibles()
        Dim ds_eventos As DataSet = DAeventos.Evento_obtener_torneos()
        'If ds_eventos.Tables(1).Rows.Count <> 0 Then
        '    DropDownList_eventos.DataSource = ds_eventos.Tables(1)
        '    DropDownList_eventos.DataValueField = "id"
        '    DropDownList_eventos.DataTextField = "desc"
        '    DropDownList_eventos.DataBind()
        'End If

        If ds_eventos.Tables(0).Rows.Count <> 0 Then
            ds_a.eventos_disponibles.Merge(ds_eventos.Tables(0))
            GridView1.DataSource = ds_a.eventos_disponibles
            GridView1.DataBind()
        Else
            no_evento.Visible = True
            'choco.Visible = True
            '    Label12.Text = "choquito"
            'ModalPopupExtender1.Show()
        End If

    End Sub
    Dim popup As String

    Private Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
        If (e.CommandName = "ID") Or (e.CommandName = "ID2") Or (e.CommandName = "ID3") Then
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
                    Session("fecha") = GridView1.Rows(i).Cells(3).Text
                    Session("fecha_cierre") = GridView1.Rows(i).Cells(4).Text
                    i = GridView1.Rows.Count
                    'Response.Redirect("Llave_detalle_evento.aspx") 'este es el original
                    'ahora veo a que formulario mandar: llave_generar o llave_disponibles
                    If (e.CommandName = "ID") Then
                        Response.Redirect("Llave_generar.aspx")
                    Else
                        If (e.CommandName = "ID2") Then
                            'aqui pongo el response.redirect a llave_disponibles
                            Response.Redirect("Llave_disponibles.aspx")
                        Else
                            If (e.CommandName = "ID3") Then
                                'aqui pongo el response.redirect a llave_disponibles
                                Response.Redirect("~/Credenciales/Credenciales_generar.aspx")
                                '~/Carpeta2/MiForm2.aspx
                            End If
                        End If

                    End If


                Else
                    i = i + 1
                End If
            End While

            ''valido si el usuario no se ha inscripto ya.
            'Dim usuario_id As Integer = Session("Us_id")
            'Dim ds_inscripto As DataSet = DAinscripciones.Inscripcion_consultar_alumno_inscripto(id, usuario_id)

            'If ds_inscripto.Tables(0).Rows.Count = 0 Then
            '    Dim i As Integer = 0
            '    While i < GridView1.Rows.Count
            '        Dim id_evento As Integer = CInt(GridView1.Rows(i).Cells(1).Text)
            '        If id_evento = index Then
            '            Session("evento_desc") = GridView1.Rows(i).Cells(1).Text
            '            i = GridView1.Rows.Count
            '            Response.Redirect("Evento_datos.aspx")
            '        Else
            '            i = i + 1
            '        End If
            '    End While
            'Else
            '    'sino ya esta inscripto
            '    'div_Modal_error_inscripto.Visible = True
            '    'Modal_error_inscripto.Show()

            'End If
        End If

    End Sub

End Class