Public Class inscripcion_persona
    Inherits System.Web.UI.Page
    Dim DAeventos As New Capa_de_datos.Eventos
    Dim DAreportes As New Capa_de_datos.Reportes


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        imprimir.Visible = False
        If Not IsPostBack Then
            obtener_eventos_disponibles()
            'imprimir.Visible = False
        End If
       

    End Sub
    Private Sub obtener_eventos_disponibles()

        'Dim ds_eventos As DataSet = DAeventos.Evento_obtenerEventos_inscripto(idd)
        Dim ds_eventos As DataSet = DAeventos.Evento_obtenerEventos_inscripto(Session("Us_id"))
        If ds_eventos.Tables(0).Rows.Count <> 0 Then
            DropDownList_eventos.DataSource = ds_eventos.Tables(0)
            DropDownList_eventos.DataValueField = "id"
            DropDownList_eventos.DataTextField = "desc"
            DropDownList_eventos.DataBind()
            recuperar_datos()
        Else
            lbl_selec.Visible = False
            DropDownList_eventos.Visible = False
            msje_Error.Visible = True


        End If

    End Sub


    Private Sub recuperar_datos()
        imprimir.Visible = True
        Dim ds_reporte As DataSet = DAreportes.Reporte_Inscripcion_Persona(CInt(Session("Us_id")), DropDownList_eventos.SelectedValue)
        Dim i = 0
        Dim enc = False
        If ds_reporte.Tables(0).Rows.Count <> 0 Then
            ''''Rutina para tildar los chk''''
            chk_forma.Checked = False
            chk_lucha.Checked = False
            chk_Rpoder.Checked = False
            chk_RHab.Checked = False

            While i < ds_reporte.Tables(0).Rows.Count
                If ds_reporte.Tables(0).Rows(i).Item("categoria_tipo") = "Lucha" Then
                    chk_lucha.Checked = True
                End If
                If ds_reporte.Tables(0).Rows(i).Item("categoria_tipo") = "Forma" Then
                    chk_forma.Checked = True

                End If
                If ds_reporte.Tables(0).Rows(i).Item("categoria_tipo") = "Rotura de Poder" Then
                    chk_Rpoder.Checked = True

                End If
                If ds_reporte.Tables(0).Rows(i).Item("categoria_tipo") = "Rotura Especial" Then
                    chk_RHab.Checked = True

                End If
                i = i + 1
            End While


            lbl_torneo.Text = ds_reporte.Tables(0).Rows(0).Item("evento_descripcion")
            lbl_grad.Text = ds_reporte.Tables(0).Rows(0).Item("graduacion_desc")
            lbl_Nombre.Text = ds_reporte.Tables(0).Rows(0).Item("apellido y nombre")
            lbl_peso.Text = ds_reporte.Tables(0).Rows(0).Item("inscripcion_peso")
            lbl_dni.Text = ds_reporte.Tables(0).Rows(0).Item("usuario_doc")


            Dim ImagenBD As Byte() = ds_reporte.Tables(0).Rows(0).Item("inscripcion_qr_imagen")
            Dim ImagenDataURL64 As String = "data:image/jpg;base64," + Convert.ToBase64String(ImagenBD)
            'string ImagenDataURL64 = "data:image/jpg;base64." + Convert.ToBase64String(ImagenOriginal);
            'choco
            'image1.ImageUrl = ImagenDataURL64
            Image1.ImageUrl = ImagenDataURL64






        End If
    End Sub

    Protected Sub DropDownList_eventos_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles DropDownList_eventos.SelectedIndexChanged
        recuperar_datos()
    End Sub
End Class