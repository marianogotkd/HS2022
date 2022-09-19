Public Class MasterPage
    Inherits System.Web.UI.MasterPage
    Dim DAusuario As New Capa_de_datos.usuario
    Dim daevento As New Capa_de_datos.Eventos


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("tipo") = "Invitado" Then
            Label_usu_nombre.Text = "INVITADO"

            Dim HideDiv = Me.FindControl("li_MiEscuela")
            If HideDiv IsNot Nothing Then

                Dim li_MiEscuela As HtmlGenericControl = CType(HideDiv.FindControl("li_MiEscuela"), HtmlGenericControl)
                Dim li_Eventos As HtmlGenericControl = CType(HideDiv.FindControl("li_Eventos"), HtmlGenericControl)
                Dim li_Adm As HtmlGenericControl = CType(HideDiv.FindControl("li_Adm"), HtmlGenericControl)

                Dim tipo As String = Session("tipo")
                Select Case tipo
                    Case "Invitado"
                        li_Adm.Visible = False
                        li_Gen_llaves.Visible = False
                        li_Ver_llav_Gen.Visible = False
                End Select

            End If


        Else






            msje.Visible = False
            Verificar_msjes()

            'recuperar nombre de usuario
            Dim usuario_id As Integer = Session("Us_id")



            Dim ds_usu As DataSet = DAusuario.Datos_Personales_Obtener_Datos_Usuarios(usuario_id)

            If ds_usu.Tables(0).Rows.Count <> 0 Then

                Label_usu_nombre.Text = ds_usu.Tables(1).Rows(0).Item("usuario_usuario")

                If Not IsDBNull(ds_usu.Tables(0).Rows(0).Item("usuario_foto")) Then

                    Dim ImagenBD As Byte() = ds_usu.Tables(0).Rows(0).Item("usuario_foto")
                    Dim ImagenDataURL64 As String = "data:image/jpg;base64," + Convert.ToBase64String(ImagenBD)

                    imgusu.Src = ImagenDataURL64

                End If



            Else
                Label_usu_nombre.Text = "TEST"

            End If


            If ds_usu.Tables(2).Rows.Count <> 0 Then
                Session("instructor_id") = ds_usu.Tables(2).Rows(0).Item("instructor_id")
            End If


            Dim HideDiv = Me.FindControl("li_MiEscuela")
            If HideDiv IsNot Nothing Then

                Dim li_MiEscuela As HtmlGenericControl = CType(HideDiv.FindControl("li_MiEscuela"), HtmlGenericControl)
                Dim li_Eventos As HtmlGenericControl = CType(HideDiv.FindControl("li_Eventos"), HtmlGenericControl)
                Dim li_Adm As HtmlGenericControl = CType(HideDiv.FindControl("li_Adm"), HtmlGenericControl)

                Dim tipo As String = Session("tipo")
                Select Case tipo
                    Case "alumno"
                        li_MiEscuela.Visible = False
                        li_Adm.Visible = False
                        li_Gen_llaves.Visible = False
                        li_Ver_llav_Gen.Visible = False
                    Case "instructor"
                        li_Adm.Visible = False
                        li_Gen_llaves.Visible = False
                        li_Ver_llav_Gen.Visible = False
                    Case "Torneo"
                        li_Adm.Visible = False
                        li_MiEscuela.Visible = False
                        li_Eventos.Visible = False
                        li_DatosPersonales.Visible = False
                        li_ImpComp.Visible = False
                        li_Calendar.Visible = False
                        li_Msje_mailbox.Visible = False

                        Dim ds_torneo As DataSet = daevento.Evento_ObetenerEvento_ID(Session("Evento_id"))
                        lbl_torneo.Visible = True
                        lbl_torneo.Text = ds_torneo.Tables(0).Rows(0).Item(1).ToString




                End Select

            End If


        End If


    End Sub

    Public Sub Verificar_msjes()
        Dim busqueda As New Data.DataSet
        busqueda = DAusuario.Solicitudes_Pendientes(Session("Us_id"))
        ' ds_consultas.datos.Merge(busqueda.Tables(0))
        Dim datatable As DataTable
        datatable = busqueda.Tables(0)


        If busqueda.Tables(0).Rows.Count <> 0 Then
            msje.Visible = True
        End If


    End Sub


End Class