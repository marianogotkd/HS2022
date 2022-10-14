Public Class Torneo_insc_modif
    Inherits System.Web.UI.Page
    Dim DAcategoria As New Capa_de_datos.Categoria
    Dim DAinscripciones As New Capa_de_datos.Inscripciones
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            div_Modal_msj_error.Visible = False

            HF_evento_id.Value = Session("evento_id")
            HF_inscripcion_id.Value = Session("inscripcion_id")
            Label_alumno.Text = "Alumno: " + Session("alumno")
            Label_dni.Text = "DNI: " + CStr(Session("dni"))
            Label_Instructor.Text = "Instructor: " + CStr(Session("instructor"))
            Label_inscripcion.Text = "Inscripto en:" + Session("inscripcion_datos")
            HF_categoria_id.Value = CInt(Session("categoria_id")) 'esto tengo que mandar como parametro
            Dim ds_cat As DataSet = DAcategoria.Categoria_obtener_info(HF_categoria_id.Value)
            Dim categoria_tipo As String = ds_cat.Tables(0).Rows(0).Item("categoria_tipo").ToString
            HF_categoria_tipo.Value = categoria_tipo
            Dim categoria_sexo As String = ds_cat.Tables(0).Rows(0).Item("categoria_sexo").ToString
            HF_categoria_sexo.Value = categoria_sexo
            Dim graduacion_inicial As Integer = CInt(ds_cat.Tables(0).Rows(0).Item("categoria_gradinicial"))
            HF_graduacion_inicial.Value = graduacion_inicial
            Dim graduacion_final As Integer = CInt(ds_cat.Tables(0).Rows(0).Item("categoria_gradfinal"))
            HF_graduacion_final.Value = graduacion_final
            carga_combo(categoria_tipo, categoria_sexo, graduacion_inicial, graduacion_final)
            If categoria_tipo <> "Forma" Then
                carga_peso()
            End If

        End If
    End Sub

    Dim Lucha_Ds As New Torneo_ds
    Dim Edad_Ds As New Torneo_ds
    Dim Peso_Ds As New Torneo_ds
    Private Sub carga_combo(ByVal categoria_tipo As String, ByVal categoria_sexo As String, ByVal graduacion_inicial As Integer, ByVal graduacion_final As Integer)
        Select Case categoria_tipo
            Case "Lucha"
                Select Case categoria_sexo
                    Case "AMBOS SEXOS"
                        Select Case graduacion_inicial
                            Case 2
                                'aqui cargo edad.
                                Dim fila1 As DataRow = Edad_Ds.Combo_Edad.NewRow
                                fila1("nro") = 1
                                fila1("descripcion") = "0 a 5 años"
                                fila1("valor") = "0 a 5 años"
                                Edad_Ds.Combo_Edad.Rows.Add(fila1)
                                Dim fila2 As DataRow = Edad_Ds.Combo_Edad.NewRow
                                fila2("nro") = 2
                                fila2("descripcion") = "6 a 7 años"
                                fila2("valor") = "6 a 7 años"
                                Edad_Ds.Combo_Edad.Rows.Add(fila2)
                                Dim fila3 As DataRow = Edad_Ds.Combo_Edad.NewRow
                                fila3("nro") = 3
                                fila3("descripcion") = "8 a 9 años"
                                fila3("valor") = "8 a 9 años"
                                Edad_Ds.Combo_Edad.Rows.Add(fila3)
                                Dim fila4 As DataRow = Edad_Ds.Combo_Edad.NewRow
                                fila4("nro") = 4
                                fila4("descripcion") = "10 a 11 años"
                                fila4("valor") = "10 a 11 años"
                                Edad_Ds.Combo_Edad.Rows.Add(fila4)
                                DropDownList_edad.DataSource = Edad_Ds.Combo_Edad
                                DropDownList_edad.DataTextField = "descripcion"
                                DropDownList_edad.DataValueField = "nro"
                                DropDownList_edad.DataBind()
                            Case 4
                                'aqui cargo edad.
                                Dim fila1 As DataRow = Edad_Ds.Combo_Edad.NewRow
                                fila1("nro") = 1
                                fila1("descripcion") = "0 a 5 años"
                                fila1("valor") = "0 a 5 años"
                                Edad_Ds.Combo_Edad.Rows.Add(fila1)
                                Dim fila2 As DataRow = Edad_Ds.Combo_Edad.NewRow
                                fila2("nro") = 2
                                fila2("descripcion") = "6 a 7 años"
                                fila2("valor") = "6 a 7 años"
                                Edad_Ds.Combo_Edad.Rows.Add(fila2)
                                Dim fila3 As DataRow = Edad_Ds.Combo_Edad.NewRow
                                fila3("nro") = 3
                                fila3("descripcion") = "8 a 9 años"
                                fila3("valor") = "8 a 9 años"
                                Edad_Ds.Combo_Edad.Rows.Add(fila3)
                                Dim fila4 As DataRow = Edad_Ds.Combo_Edad.NewRow
                                fila4("nro") = 4
                                fila4("descripcion") = "10 a 11 años"
                                fila4("valor") = "10 a 11 años"
                                Edad_Ds.Combo_Edad.Rows.Add(fila4)
                                DropDownList_edad.DataSource = Edad_Ds.Combo_Edad
                                DropDownList_edad.DataTextField = "descripcion"
                                DropDownList_edad.DataValueField = "nro"
                                DropDownList_edad.DataBind()
                            Case 8
                                'aqui cargo edad.
                                Dim fila1 As DataRow = Edad_Ds.Combo_Edad.NewRow
                                fila1("nro") = 1
                                fila1("descripcion") = "0 a 5 años"
                                fila1("valor") = "0 a 5 años"
                                Edad_Ds.Combo_Edad.Rows.Add(fila1)
                                Dim fila2 As DataRow = Edad_Ds.Combo_Edad.NewRow
                                fila2("nro") = 2
                                fila2("descripcion") = "6 a 7 años"
                                fila2("valor") = "6 a 7 años"
                                Edad_Ds.Combo_Edad.Rows.Add(fila2)
                                Dim fila3 As DataRow = Edad_Ds.Combo_Edad.NewRow
                                fila3("nro") = 3
                                fila3("descripcion") = "8 a 9 años"
                                fila3("valor") = "8 a 9 años"
                                Edad_Ds.Combo_Edad.Rows.Add(fila3)
                                Dim fila4 As DataRow = Edad_Ds.Combo_Edad.NewRow
                                fila4("nro") = 4
                                fila4("descripcion") = "10 a 11 años"
                                fila4("valor") = "10 a 11 años"
                                Edad_Ds.Combo_Edad.Rows.Add(fila4)
                                DropDownList_edad.DataSource = Edad_Ds.Combo_Edad
                                DropDownList_edad.DataTextField = "descripcion"
                                DropDownList_edad.DataValueField = "nro"
                                DropDownList_edad.DataBind()
                            Case 12
                                'aqui cargo edad.
                                Dim fila4 As DataRow = Edad_Ds.Combo_Edad.NewRow
                                fila4("nro") = 1
                                fila4("descripcion") = "10 a 11 años"
                                fila4("valor") = "10 a 11 años"
                                Edad_Ds.Combo_Edad.Rows.Add(fila4)
                                DropDownList_edad.DataSource = Edad_Ds.Combo_Edad
                                DropDownList_edad.DataTextField = "descripcion"
                                DropDownList_edad.DataValueField = "nro"
                                DropDownList_edad.DataBind()
                        End Select
                    Case "Hombre"
                        Select Case graduacion_inicial
                            Case 2
                                'aqui cargo edad.
                                lucha_hombremujer_edad()
                            Case 4
                                lucha_hombremujer_edad()
                            Case 8
                                lucha_hombremujer_edad()
                            Case 12
                                lucha_hombremujer_edad()
                        End Select
                    Case "Mujer"
                        Select Case graduacion_inicial
                            Case 2
                                lucha_hombremujer_edad()
                            Case 4
                                lucha_hombremujer_edad()
                            Case 8
                                lucha_hombremujer_edad()
                            Case 12
                                lucha_hombremujer_edad()
                        End Select
                End Select
            Case "Forma"
                Select Case categoria_sexo
                    Case "AMBOS SEXOS"
                        Select Case graduacion_inicial
                            Case 2
                                'aqui cargo edad.
                                Dim fila1 As DataRow = Edad_Ds.Combo_Edad.NewRow
                                fila1("nro") = 1
                                fila1("descripcion") = "0 a 5 años"
                                fila1("valor") = "0 a 5 años"
                                Edad_Ds.Combo_Edad.Rows.Add(fila1)
                                'aqui cargo edad.
                                Dim fila2 As DataRow = Edad_Ds.Combo_Edad.NewRow
                                fila2("nro") = 2
                                fila2("descripcion") = "6 a 7 años"
                                fila2("valor") = "6 a 7 años"
                                Edad_Ds.Combo_Edad.Rows.Add(fila2)
                                'aqui cargo edad.
                                Dim fila3 As DataRow = Edad_Ds.Combo_Edad.NewRow
                                fila3("nro") = 3
                                fila3("descripcion") = "8 a 9 años"
                                fila3("valor") = "8 a 9 años"
                                Edad_Ds.Combo_Edad.Rows.Add(fila3)
                                'aqui cargo edad.
                                Dim fila4 As DataRow = Edad_Ds.Combo_Edad.NewRow
                                fila4("nro") = 4
                                fila4("descripcion") = "10 a 11 años"
                                fila4("valor") = "10 a 11 años"
                                Edad_Ds.Combo_Edad.Rows.Add(fila4)
                                DropDownList_edad.DataSource = Edad_Ds.Combo_Edad
                                DropDownList_edad.DataTextField = "descripcion"
                                DropDownList_edad.DataValueField = "nro"
                                DropDownList_edad.DataBind()
                            Case 4
                                'aqui cargo edad.
                                Dim fila1 As DataRow = Edad_Ds.Combo_Edad.NewRow
                                fila1("nro") = 1
                                fila1("descripcion") = "0 a 5 años"
                                fila1("valor") = "0 a 5 años"
                                Edad_Ds.Combo_Edad.Rows.Add(fila1)
                                'aqui cargo edad.
                                Dim fila2 As DataRow = Edad_Ds.Combo_Edad.NewRow
                                fila2("nro") = 2
                                fila2("descripcion") = "6 a 7 años"
                                fila2("valor") = "6 a 7 años"
                                Edad_Ds.Combo_Edad.Rows.Add(fila2)
                                'aqui cargo edad.
                                Dim fila3 As DataRow = Edad_Ds.Combo_Edad.NewRow
                                fila3("nro") = 3
                                fila3("descripcion") = "8 a 9 años"
                                fila3("valor") = "8 a 9 años"
                                Edad_Ds.Combo_Edad.Rows.Add(fila3)
                                'aqui cargo edad.
                                Dim fila4 As DataRow = Edad_Ds.Combo_Edad.NewRow
                                fila4("nro") = 4
                                fila4("descripcion") = "10 a 11 años"
                                fila4("valor") = "10 a 11 años"
                                Edad_Ds.Combo_Edad.Rows.Add(fila4)
                                DropDownList_edad.DataSource = Edad_Ds.Combo_Edad
                                DropDownList_edad.DataTextField = "descripcion"
                                DropDownList_edad.DataValueField = "nro"
                                DropDownList_edad.DataBind()
                            Case 8
                                'aqui cargo edad.
                                Dim fila1 As DataRow = Edad_Ds.Combo_Edad.NewRow
                                fila1("nro") = 1
                                fila1("descripcion") = "0 a 5 años"
                                fila1("valor") = "0 a 5 años"
                                Edad_Ds.Combo_Edad.Rows.Add(fila1)
                                'aqui cargo edad.
                                Dim fila2 As DataRow = Edad_Ds.Combo_Edad.NewRow
                                fila2("nro") = 2
                                fila2("descripcion") = "6 a 7 años"
                                fila2("valor") = "6 a 7 años"
                                Edad_Ds.Combo_Edad.Rows.Add(fila2)
                                'aqui cargo edad.
                                Dim fila3 As DataRow = Edad_Ds.Combo_Edad.NewRow
                                fila3("nro") = 3
                                fila3("descripcion") = "8 a 9 años"
                                fila3("valor") = "8 a 9 años"
                                Edad_Ds.Combo_Edad.Rows.Add(fila3)
                                'aqui cargo edad.
                                Dim fila4 As DataRow = Edad_Ds.Combo_Edad.NewRow
                                fila4("nro") = 4
                                fila4("descripcion") = "10 a 11 años"
                                fila4("valor") = "10 a 11 años"
                                Edad_Ds.Combo_Edad.Rows.Add(fila4)
                                DropDownList_edad.DataSource = Edad_Ds.Combo_Edad
                                DropDownList_edad.DataTextField = "descripcion"
                                DropDownList_edad.DataValueField = "nro"
                                DropDownList_edad.DataBind()
                            Case 12
                                'aqui cargo edad.
                                Dim fila1 As DataRow = Edad_Ds.Combo_Edad.NewRow
                                fila1("nro") = 1
                                fila1("descripcion") = "10 a 11 años"
                                fila1("valor") = "10 a 11 años"
                                Edad_Ds.Combo_Edad.Rows.Add(fila1)
                                DropDownList_edad.DataSource = Edad_Ds.Combo_Edad
                                DropDownList_edad.DataTextField = "descripcion"
                                DropDownList_edad.DataValueField = "nro"
                                DropDownList_edad.DataBind()
                            Case 13
                                'aqui cargo edad.
                                Dim fila1 As DataRow = Edad_Ds.Combo_Edad.NewRow
                                fila1("nro") = 1
                                fila1("descripcion") = "10 a 11 años"
                                fila1("valor") = "10 a 11 años"
                                Edad_Ds.Combo_Edad.Rows.Add(fila1)
                                DropDownList_edad.DataSource = Edad_Ds.Combo_Edad
                                DropDownList_edad.DataTextField = "descripcion"
                                DropDownList_edad.DataValueField = "nro"
                                DropDownList_edad.DataBind()
                        End Select
                    Case "Hombre"
                        Select Case graduacion_inicial
                            Case 2
                                'aqui cargo edad.
                                Dim fila1 As DataRow = Edad_Ds.Combo_Edad.NewRow
                                fila1("nro") = 1
                                fila1("descripcion") = "12 a 13 años"
                                fila1("valor") = "12 a 13 años"
                                Edad_Ds.Combo_Edad.Rows.Add(fila1)
                                Dim fila2 As DataRow = Edad_Ds.Combo_Edad.NewRow
                                fila2("nro") = 2
                                fila2("descripcion") = "14 a 15 años"
                                fila2("valor") = "14 a 15 años"
                                Edad_Ds.Combo_Edad.Rows.Add(fila2)
                                Dim fila3 As DataRow = Edad_Ds.Combo_Edad.NewRow
                                fila3("nro") = 3
                                fila3("descripcion") = "16 a 17 años"
                                fila3("valor") = "16 a 17 años"
                                Edad_Ds.Combo_Edad.Rows.Add(fila3)
                                Dim fila4 As DataRow = Edad_Ds.Combo_Edad.NewRow
                                fila4("nro") = 4
                                fila4("descripcion") = "18 a 35 años"
                                fila4("valor") = "18 a 35 años"
                                Edad_Ds.Combo_Edad.Rows.Add(fila4)
                                Dim fila5 As DataRow = Edad_Ds.Combo_Edad.NewRow
                                fila5("nro") = 5
                                fila5("descripcion") = "36 a 45 años"
                                fila5("valor") = "36 a 45 años"
                                Edad_Ds.Combo_Edad.Rows.Add(fila5)
                                DropDownList_edad.DataSource = Edad_Ds.Combo_Edad
                                DropDownList_edad.DataTextField = "descripcion"
                                DropDownList_edad.DataValueField = "nro"
                                DropDownList_edad.DataBind()
                            Case 4
                                'aqui cargo edad.
                                Dim fila1 As DataRow = Edad_Ds.Combo_Edad.NewRow
                                fila1("nro") = 1
                                fila1("descripcion") = "12 a 13 años"
                                fila1("valor") = "12 a 13 años"
                                Edad_Ds.Combo_Edad.Rows.Add(fila1)
                                Dim fila2 As DataRow = Edad_Ds.Combo_Edad.NewRow
                                fila2("nro") = 2
                                fila2("descripcion") = "14 a 15 años"
                                fila2("valor") = "14 a 15 años"
                                Edad_Ds.Combo_Edad.Rows.Add(fila2)
                                Dim fila3 As DataRow = Edad_Ds.Combo_Edad.NewRow
                                fila3("nro") = 3
                                fila3("descripcion") = "16 a 17 años"
                                fila3("valor") = "16 a 17 años"
                                Edad_Ds.Combo_Edad.Rows.Add(fila3)
                                Dim fila4 As DataRow = Edad_Ds.Combo_Edad.NewRow
                                fila4("nro") = 4
                                fila4("descripcion") = "18 a 35 años"
                                fila4("valor") = "18 a 35 años"
                                Edad_Ds.Combo_Edad.Rows.Add(fila4)
                                Dim fila5 As DataRow = Edad_Ds.Combo_Edad.NewRow
                                fila5("nro") = 5
                                fila5("descripcion") = "36 a 45 años"
                                fila5("valor") = "36 a 45 años"
                                Edad_Ds.Combo_Edad.Rows.Add(fila5)
                                DropDownList_edad.DataSource = Edad_Ds.Combo_Edad
                                DropDownList_edad.DataTextField = "descripcion"
                                DropDownList_edad.DataValueField = "nro"
                                DropDownList_edad.DataBind()
                            Case 8
                                'aqui cargo edad.
                                Dim fila1 As DataRow = Edad_Ds.Combo_Edad.NewRow
                                fila1("nro") = 1
                                fila1("descripcion") = "12 a 13 años"
                                fila1("valor") = "12 a 13 años"
                                Edad_Ds.Combo_Edad.Rows.Add(fila1)
                                Dim fila2 As DataRow = Edad_Ds.Combo_Edad.NewRow
                                fila2("nro") = 2
                                fila2("descripcion") = "14 a 15 años"
                                fila2("valor") = "14 a 15 años"
                                Edad_Ds.Combo_Edad.Rows.Add(fila2)
                                Dim fila3 As DataRow = Edad_Ds.Combo_Edad.NewRow
                                fila3("nro") = 3
                                fila3("descripcion") = "16 a 17 años"
                                fila3("valor") = "16 a 17 años"
                                Edad_Ds.Combo_Edad.Rows.Add(fila3)
                                Dim fila4 As DataRow = Edad_Ds.Combo_Edad.NewRow
                                fila4("nro") = 4
                                fila4("descripcion") = "18 a 35 años"
                                fila4("valor") = "18 a 35 años"
                                Edad_Ds.Combo_Edad.Rows.Add(fila4)
                                Dim fila5 As DataRow = Edad_Ds.Combo_Edad.NewRow
                                fila5("nro") = 5
                                fila5("descripcion") = "36 a 45 años"
                                fila5("valor") = "36 a 45 años"
                                Edad_Ds.Combo_Edad.Rows.Add(fila5)
                                DropDownList_edad.DataSource = Edad_Ds.Combo_Edad
                                DropDownList_edad.DataTextField = "descripcion"
                                DropDownList_edad.DataValueField = "nro"
                                DropDownList_edad.DataBind()
                            Case 12
                                'aqui cargo edad.
                                Dim fila1 As DataRow = Edad_Ds.Combo_Edad.NewRow
                                fila1("nro") = 1
                                fila1("descripcion") = "12 a 13 años"
                                fila1("valor") = "12 a 13 años"
                                Edad_Ds.Combo_Edad.Rows.Add(fila1)
                                Dim fila2 As DataRow = Edad_Ds.Combo_Edad.NewRow
                                fila2("nro") = 2
                                fila2("descripcion") = "14 a 15 años"
                                fila2("valor") = "14 a 15 años"
                                Edad_Ds.Combo_Edad.Rows.Add(fila2)
                                Dim fila3 As DataRow = Edad_Ds.Combo_Edad.NewRow
                                fila3("nro") = 3
                                fila3("descripcion") = "16 a 17 años"
                                fila3("valor") = "16 a 17 años"
                                Edad_Ds.Combo_Edad.Rows.Add(fila3)
                                Dim fila4 As DataRow = Edad_Ds.Combo_Edad.NewRow
                                fila4("nro") = 4
                                fila4("descripcion") = "18 a 35 años"
                                fila4("valor") = "18 a 35 años"
                                Edad_Ds.Combo_Edad.Rows.Add(fila4)
                                Dim fila5 As DataRow = Edad_Ds.Combo_Edad.NewRow
                                fila5("nro") = 5
                                fila5("descripcion") = "36 a 45 años"
                                fila5("valor") = "36 a 45 años"
                                Edad_Ds.Combo_Edad.Rows.Add(fila5)
                                DropDownList_edad.DataSource = Edad_Ds.Combo_Edad
                                DropDownList_edad.DataTextField = "descripcion"
                                DropDownList_edad.DataValueField = "nro"
                                DropDownList_edad.DataBind()
                            Case 13
                                'aqui cargo edad.
                                Dim fila1 As DataRow = Edad_Ds.Combo_Edad.NewRow
                                fila1("nro") = 1
                                fila1("descripcion") = "12 a 13 años"
                                fila1("valor") = "12 a 13 años"
                                Edad_Ds.Combo_Edad.Rows.Add(fila1)
                                Dim fila2 As DataRow = Edad_Ds.Combo_Edad.NewRow
                                fila2("nro") = 2
                                fila2("descripcion") = "14 a 15 años"
                                fila2("valor") = "14 a 15 años"
                                Edad_Ds.Combo_Edad.Rows.Add(fila2)
                                Dim fila3 As DataRow = Edad_Ds.Combo_Edad.NewRow
                                fila3("nro") = 3
                                fila3("descripcion") = "16 a 17 años"
                                fila3("valor") = "16 a 17 años"
                                Edad_Ds.Combo_Edad.Rows.Add(fila3)
                                Dim fila4 As DataRow = Edad_Ds.Combo_Edad.NewRow
                                fila4("nro") = 4
                                fila4("descripcion") = "18 a 35 años"
                                fila4("valor") = "18 a 35 años"
                                Edad_Ds.Combo_Edad.Rows.Add(fila4)
                                Dim fila5 As DataRow = Edad_Ds.Combo_Edad.NewRow
                                fila5("nro") = 5
                                fila5("descripcion") = "36 a 45 años"
                                fila5("valor") = "36 a 45 años"
                                Edad_Ds.Combo_Edad.Rows.Add(fila5)
                                DropDownList_edad.DataSource = Edad_Ds.Combo_Edad
                                DropDownList_edad.DataTextField = "descripcion"
                                DropDownList_edad.DataValueField = "nro"
                                DropDownList_edad.DataBind()
                            Case 14
                                'aqui cargo edad.
                                Dim fila1 As DataRow = Edad_Ds.Combo_Edad.NewRow
                                fila1("nro") = 1
                                fila1("descripcion") = "14 a 15 años"
                                fila1("valor") = "14 a 15 años"
                                Edad_Ds.Combo_Edad.Rows.Add(fila1)
                                Dim fila2 As DataRow = Edad_Ds.Combo_Edad.NewRow
                                fila2("nro") = 2
                                fila2("descripcion") = "16 a 17 años"
                                fila2("valor") = "16 a 17 años"
                                Edad_Ds.Combo_Edad.Rows.Add(fila2)
                                Dim fila3 As DataRow = Edad_Ds.Combo_Edad.NewRow
                                fila3("nro") = 3
                                fila3("descripcion") = "18 a 35 años"
                                fila3("valor") = "18 a 35 años"
                                Edad_Ds.Combo_Edad.Rows.Add(fila3)
                                Dim fila4 As DataRow = Edad_Ds.Combo_Edad.NewRow
                                fila4("nro") = 4
                                fila4("descripcion") = "36 a 45 años"
                                fila4("valor") = "36 a 45 años"
                                Edad_Ds.Combo_Edad.Rows.Add(fila4)
                                DropDownList_edad.DataSource = Edad_Ds.Combo_Edad
                                DropDownList_edad.DataTextField = "descripcion"
                                DropDownList_edad.DataValueField = "nro"
                                DropDownList_edad.DataBind()
                            Case 15
                                'aqui cargo edad.
                                Dim fila1 As DataRow = Edad_Ds.Combo_Edad.NewRow
                                fila1("nro") = 1
                                fila1("descripcion") = "18 a 35 años"
                                fila1("valor") = "18 a 35 años"
                                Edad_Ds.Combo_Edad.Rows.Add(fila1)
                                Dim fila2 As DataRow = Edad_Ds.Combo_Edad.NewRow
                                fila2("nro") = 2
                                fila2("descripcion") = "36 a 45 años"
                                fila2("valor") = "36 a 45 años"
                                Edad_Ds.Combo_Edad.Rows.Add(fila2)
                                DropDownList_edad.DataSource = Edad_Ds.Combo_Edad
                                DropDownList_edad.DataTextField = "descripcion"
                                DropDownList_edad.DataValueField = "nro"
                                DropDownList_edad.DataBind()
                            Case 16
                                'aqui cargo edad.
                                Dim fila1 As DataRow = Edad_Ds.Combo_Edad.NewRow
                                fila1("nro") = 1
                                fila1("descripcion") = "18 a 35 años"
                                fila1("valor") = "18 a 35 años"
                                Edad_Ds.Combo_Edad.Rows.Add(fila1)
                                Dim fila2 As DataRow = Edad_Ds.Combo_Edad.NewRow
                                fila2("nro") = 2
                                fila2("descripcion") = "36 a 45 años"
                                fila2("valor") = "36 a 45 años"
                                Edad_Ds.Combo_Edad.Rows.Add(fila2)
                                DropDownList_edad.DataSource = Edad_Ds.Combo_Edad
                                DropDownList_edad.DataTextField = "descripcion"
                                DropDownList_edad.DataValueField = "nro"
                                DropDownList_edad.DataBind()
                            Case 17
                                'aqui cargo edad.
                                Dim fila1 As DataRow = Edad_Ds.Combo_Edad.NewRow
                                fila1("nro") = 1
                                fila1("descripcion") = "18 a 35 años"
                                fila1("valor") = "18 a 35 años"
                                Edad_Ds.Combo_Edad.Rows.Add(fila1)
                                Dim fila2 As DataRow = Edad_Ds.Combo_Edad.NewRow
                                fila2("nro") = 2
                                fila2("descripcion") = "36 a 45 años"
                                fila2("valor") = "36 a 45 años"
                                Edad_Ds.Combo_Edad.Rows.Add(fila2)
                                DropDownList_edad.DataSource = Edad_Ds.Combo_Edad
                                DropDownList_edad.DataTextField = "descripcion"
                                DropDownList_edad.DataValueField = "nro"
                                DropDownList_edad.DataBind()
                        End Select
                    Case "Mujer"
                        Select Case graduacion_inicial
                            Case 2
                                'aqui cargo edad.
                                Dim fila1 As DataRow = Edad_Ds.Combo_Edad.NewRow
                                fila1("nro") = 1
                                fila1("descripcion") = "12 a 13 años"
                                fila1("valor") = "12 a 13 años"
                                Edad_Ds.Combo_Edad.Rows.Add(fila1)
                                Dim fila2 As DataRow = Edad_Ds.Combo_Edad.NewRow
                                fila2("nro") = 2
                                fila2("descripcion") = "14 a 15 años"
                                fila2("valor") = "14 a 15 años"
                                Edad_Ds.Combo_Edad.Rows.Add(fila2)
                                Dim fila3 As DataRow = Edad_Ds.Combo_Edad.NewRow
                                fila3("nro") = 3
                                fila3("descripcion") = "16 a 17 años"
                                fila3("valor") = "16 a 17 años"
                                Edad_Ds.Combo_Edad.Rows.Add(fila3)
                                Dim fila4 As DataRow = Edad_Ds.Combo_Edad.NewRow
                                fila4("nro") = 4
                                fila4("descripcion") = "18 a 35 años"
                                fila4("valor") = "18 a 35 años"
                                Edad_Ds.Combo_Edad.Rows.Add(fila4)
                                Dim fila5 As DataRow = Edad_Ds.Combo_Edad.NewRow
                                fila5("nro") = 5
                                fila5("descripcion") = "36 a 45 años"
                                fila5("valor") = "36 a 45 años"
                                Edad_Ds.Combo_Edad.Rows.Add(fila5)
                                DropDownList_edad.DataSource = Edad_Ds.Combo_Edad
                                DropDownList_edad.DataTextField = "descripcion"
                                DropDownList_edad.DataValueField = "nro"
                                DropDownList_edad.DataBind()
                            Case 4
                                'aqui cargo edad.
                                Dim fila1 As DataRow = Edad_Ds.Combo_Edad.NewRow
                                fila1("nro") = 1
                                fila1("descripcion") = "12 a 13 años"
                                fila1("valor") = "12 a 13 años"
                                Edad_Ds.Combo_Edad.Rows.Add(fila1)
                                Dim fila2 As DataRow = Edad_Ds.Combo_Edad.NewRow
                                fila2("nro") = 2
                                fila2("descripcion") = "14 a 15 años"
                                fila2("valor") = "14 a 15 años"
                                Edad_Ds.Combo_Edad.Rows.Add(fila2)
                                Dim fila3 As DataRow = Edad_Ds.Combo_Edad.NewRow
                                fila3("nro") = 3
                                fila3("descripcion") = "16 a 17 años"
                                fila3("valor") = "16 a 17 años"
                                Edad_Ds.Combo_Edad.Rows.Add(fila3)
                                Dim fila4 As DataRow = Edad_Ds.Combo_Edad.NewRow
                                fila4("nro") = 4
                                fila4("descripcion") = "18 a 35 años"
                                fila4("valor") = "18 a 35 años"
                                Edad_Ds.Combo_Edad.Rows.Add(fila4)
                                Dim fila5 As DataRow = Edad_Ds.Combo_Edad.NewRow
                                fila5("nro") = 5
                                fila5("descripcion") = "36 a 45 años"
                                fila5("valor") = "36 a 45 años"
                                Edad_Ds.Combo_Edad.Rows.Add(fila5)
                                DropDownList_edad.DataSource = Edad_Ds.Combo_Edad
                                DropDownList_edad.DataTextField = "descripcion"
                                DropDownList_edad.DataValueField = "nro"
                                DropDownList_edad.DataBind()
                            Case 8
                                'aqui cargo edad.
                                Dim fila1 As DataRow = Edad_Ds.Combo_Edad.NewRow
                                fila1("nro") = 1
                                fila1("descripcion") = "12 a 13 años"
                                fila1("valor") = "12 a 13 años"
                                Edad_Ds.Combo_Edad.Rows.Add(fila1)
                                Dim fila2 As DataRow = Edad_Ds.Combo_Edad.NewRow
                                fila2("nro") = 2
                                fila2("descripcion") = "14 a 15 años"
                                fila2("valor") = "14 a 15 años"
                                Edad_Ds.Combo_Edad.Rows.Add(fila2)
                                Dim fila3 As DataRow = Edad_Ds.Combo_Edad.NewRow
                                fila3("nro") = 3
                                fila3("descripcion") = "16 a 17 años"
                                fila3("valor") = "16 a 17 años"
                                Edad_Ds.Combo_Edad.Rows.Add(fila3)
                                Dim fila4 As DataRow = Edad_Ds.Combo_Edad.NewRow
                                fila4("nro") = 4
                                fila4("descripcion") = "18 a 35 años"
                                fila4("valor") = "18 a 35 años"
                                Edad_Ds.Combo_Edad.Rows.Add(fila4)
                                Dim fila5 As DataRow = Edad_Ds.Combo_Edad.NewRow
                                fila5("nro") = 5
                                fila5("descripcion") = "36 a 45 años"
                                fila5("valor") = "36 a 45 años"
                                Edad_Ds.Combo_Edad.Rows.Add(fila5)
                                DropDownList_edad.DataSource = Edad_Ds.Combo_Edad
                                DropDownList_edad.DataTextField = "descripcion"
                                DropDownList_edad.DataValueField = "nro"
                                DropDownList_edad.DataBind()
                            Case 12
                                'aqui cargo edad.
                                Dim fila1 As DataRow = Edad_Ds.Combo_Edad.NewRow
                                fila1("nro") = 1
                                fila1("descripcion") = "12 a 13 años"
                                fila1("valor") = "12 a 13 años"
                                Edad_Ds.Combo_Edad.Rows.Add(fila1)
                                Dim fila2 As DataRow = Edad_Ds.Combo_Edad.NewRow
                                fila2("nro") = 2
                                fila2("descripcion") = "14 a 15 años"
                                fila2("valor") = "14 a 15 años"
                                Edad_Ds.Combo_Edad.Rows.Add(fila2)
                                Dim fila3 As DataRow = Edad_Ds.Combo_Edad.NewRow
                                fila3("nro") = 3
                                fila3("descripcion") = "16 a 17 años"
                                fila3("valor") = "16 a 17 años"
                                Edad_Ds.Combo_Edad.Rows.Add(fila3)
                                Dim fila4 As DataRow = Edad_Ds.Combo_Edad.NewRow
                                fila4("nro") = 4
                                fila4("descripcion") = "18 a 35 años"
                                fila4("valor") = "18 a 35 años"
                                Edad_Ds.Combo_Edad.Rows.Add(fila4)
                                Dim fila5 As DataRow = Edad_Ds.Combo_Edad.NewRow
                                fila5("nro") = 5
                                fila5("descripcion") = "36 a 45 años"
                                fila5("valor") = "36 a 45 años"
                                Edad_Ds.Combo_Edad.Rows.Add(fila5)
                                DropDownList_edad.DataSource = Edad_Ds.Combo_Edad
                                DropDownList_edad.DataTextField = "descripcion"
                                DropDownList_edad.DataValueField = "nro"
                                DropDownList_edad.DataBind()
                            Case 13
                                'aqui cargo edad.
                                Dim fila1 As DataRow = Edad_Ds.Combo_Edad.NewRow
                                fila1("nro") = 1
                                fila1("descripcion") = "12 a 13 años"
                                fila1("valor") = "12 a 13 años"
                                Edad_Ds.Combo_Edad.Rows.Add(fila1)
                                Dim fila2 As DataRow = Edad_Ds.Combo_Edad.NewRow
                                fila2("nro") = 2
                                fila2("descripcion") = "14 a 15 años"
                                fila2("valor") = "14 a 15 años"
                                Edad_Ds.Combo_Edad.Rows.Add(fila2)
                                Dim fila3 As DataRow = Edad_Ds.Combo_Edad.NewRow
                                fila3("nro") = 3
                                fila3("descripcion") = "16 a 17 años"
                                fila3("valor") = "16 a 17 años"
                                Edad_Ds.Combo_Edad.Rows.Add(fila3)
                                Dim fila4 As DataRow = Edad_Ds.Combo_Edad.NewRow
                                fila4("nro") = 4
                                fila4("descripcion") = "18 a 35 años"
                                fila4("valor") = "18 a 35 años"
                                Edad_Ds.Combo_Edad.Rows.Add(fila4)
                                Dim fila5 As DataRow = Edad_Ds.Combo_Edad.NewRow
                                fila5("nro") = 5
                                fila5("descripcion") = "36 a 45 años"
                                fila5("valor") = "36 a 45 años"
                                Edad_Ds.Combo_Edad.Rows.Add(fila5)
                                DropDownList_edad.DataSource = Edad_Ds.Combo_Edad
                                DropDownList_edad.DataTextField = "descripcion"
                                DropDownList_edad.DataValueField = "nro"
                                DropDownList_edad.DataBind()
                            Case 14
                                'aqui cargo edad.
                                Dim fila1 As DataRow = Edad_Ds.Combo_Edad.NewRow
                                fila1("nro") = 1
                                fila1("descripcion") = "14 a 15 años"
                                fila1("valor") = "14 a 15 años"
                                Edad_Ds.Combo_Edad.Rows.Add(fila1)
                                Dim fila2 As DataRow = Edad_Ds.Combo_Edad.NewRow
                                fila2("nro") = 2
                                fila2("descripcion") = "16 a 17 años"
                                fila2("valor") = "16 a 17 años"
                                Edad_Ds.Combo_Edad.Rows.Add(fila2)
                                Dim fila3 As DataRow = Edad_Ds.Combo_Edad.NewRow
                                fila3("nro") = 3
                                fila3("descripcion") = "18 a 35 años"
                                fila3("valor") = "18 a 35 años"
                                Edad_Ds.Combo_Edad.Rows.Add(fila3)
                                Dim fila4 As DataRow = Edad_Ds.Combo_Edad.NewRow
                                fila4("nro") = 4
                                fila4("descripcion") = "36 a 45 años"
                                fila4("valor") = "36 a 45 años"
                                Edad_Ds.Combo_Edad.Rows.Add(fila4)
                                DropDownList_edad.DataSource = Edad_Ds.Combo_Edad
                                DropDownList_edad.DataTextField = "descripcion"
                                DropDownList_edad.DataValueField = "nro"
                                DropDownList_edad.DataBind()
                            Case 15
                                'aqui cargo edad.
                                Dim fila1 As DataRow = Edad_Ds.Combo_Edad.NewRow
                                fila1("nro") = 1
                                fila1("descripcion") = "18 a 35 años"
                                fila1("valor") = "18 a 35 años"
                                Edad_Ds.Combo_Edad.Rows.Add(fila1)
                                Dim fila2 As DataRow = Edad_Ds.Combo_Edad.NewRow
                                fila2("nro") = 2
                                fila2("descripcion") = "36 a 45 años"
                                fila2("valor") = "36 a 45 años"
                                Edad_Ds.Combo_Edad.Rows.Add(fila2)
                                DropDownList_edad.DataSource = Edad_Ds.Combo_Edad
                                DropDownList_edad.DataTextField = "descripcion"
                                DropDownList_edad.DataValueField = "nro"
                                DropDownList_edad.DataBind()
                            Case 16
                                'aqui cargo edad.
                                Dim fila1 As DataRow = Edad_Ds.Combo_Edad.NewRow
                                fila1("nro") = 1
                                fila1("descripcion") = "18 a 35 años"
                                fila1("valor") = "18 a 35 años"
                                Edad_Ds.Combo_Edad.Rows.Add(fila1)
                                Dim fila2 As DataRow = Edad_Ds.Combo_Edad.NewRow
                                fila2("nro") = 2
                                fila2("descripcion") = "36 a 45 años"
                                fila2("valor") = "36 a 45 años"
                                Edad_Ds.Combo_Edad.Rows.Add(fila2)
                                DropDownList_edad.DataSource = Edad_Ds.Combo_Edad
                                DropDownList_edad.DataTextField = "descripcion"
                                DropDownList_edad.DataValueField = "nro"
                                DropDownList_edad.DataBind()
                            Case 17
                                'aqui cargo edad.
                                Dim fila1 As DataRow = Edad_Ds.Combo_Edad.NewRow
                                fila1("nro") = 1
                                fila1("descripcion") = "18 a 35 años"
                                fila1("valor") = "18 a 35 años"
                                Edad_Ds.Combo_Edad.Rows.Add(fila1)
                                Dim fila2 As DataRow = Edad_Ds.Combo_Edad.NewRow
                                fila2("nro") = 2
                                fila2("descripcion") = "36 a 45 años"
                                fila2("valor") = "36 a 45 años"
                                Edad_Ds.Combo_Edad.Rows.Add(fila2)
                                DropDownList_edad.DataSource = Edad_Ds.Combo_Edad
                                DropDownList_edad.DataTextField = "descripcion"
                                DropDownList_edad.DataValueField = "nro"
                                DropDownList_edad.DataBind()
                        End Select
                End Select
                DropDownList_peso.Visible = False
            Case "Rotura de Poder"
                'todavia nada. mostrar cartel en construccion
                Response.Redirect("~/Error/UnderConstruction.aspx")
            Case "Rotura Especial"
                'todavia nada. mostrar cartel en construccion
                Response.Redirect("~/Error/UnderConstruction.aspx")
        End Select


    End Sub



    Private Sub carga_peso()
        Try
            Select Case HF_categoria_tipo.Value
                Case "Lucha"
                    Select Case HF_categoria_sexo.Value
                        Case "AMBOS SEXOS"
                            Select Case HF_graduacion_inicial.Value
                                Case 2
                                    Select Case DropDownList_edad.SelectedValue
                                        Case "1" '0 a 5 años
                                            Dim fila1 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila1("nro") = 1
                                            fila1("descripcion") = "0 a 15 kg"
                                            fila1("valor") = "0 a 15 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila1)
                                            Dim fila2 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila2("nro") = 2
                                            fila2("descripcion") = "15 a 20 kg"
                                            fila2("valor") = "15 a 20 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila2)
                                            Dim fila3 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila3("nro") = 3
                                            fila3("descripcion") = "20 a 25 kg"
                                            fila3("valor") = "20 a 25 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila3)
                                            Dim fila4 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila4("nro") = 4
                                            fila4("descripcion") = "25 a 30 kg"
                                            fila4("valor") = "25 a 30 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila4)
                                            Dim fila5 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila5("nro") = 5
                                            fila5("descripcion") = "30 a 35 kg"
                                            fila5("valor") = "30 a 35 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila5)
                                            Dim fila6 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila6("nro") = 6
                                            fila6("descripcion") = "35 a 40 kg"
                                            fila6("valor") = "35 a 40 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila6)
                                            Dim fila7 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila7("nro") = 7
                                            fila7("descripcion") = "40 a 45 kg"
                                            fila7("valor") = "40 a 45 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila7)
                                            Dim fila8 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila8("nro") = 8
                                            fila8("descripcion") = "45 a 50 kg"
                                            fila8("valor") = "45 a 50 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila8)
                                            Dim fila9 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila9("nro") = 9
                                            fila9("descripcion") = "50 a 55 kg"
                                            fila9("valor") = "50 a 55 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila9)
                                            Dim fila10 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila10("nro") = 10
                                            fila10("descripcion") = "55 a 60 kg"
                                            fila10("valor") = "55 a 60 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila10)
                                            Dim fila11 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila11("nro") = 11
                                            fila11("descripcion") = "60 a 65 kg"
                                            fila11("valor") = "60 a 65 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila11)
                                            Dim fila12 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila12("nro") = 12
                                            fila12("descripcion") = "65 a 70 kg"
                                            fila12("valor") = "65 a 70 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila12)
                                            DropDownList_peso.DataSource = Peso_Ds.Combo_Peso
                                            DropDownList_peso.DataTextField = "descripcion"
                                            DropDownList_peso.DataValueField = "nro"
                                            DropDownList_peso.DataBind()

                                        Case "2" '6 a 7
                                            Dim fila1 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila1("nro") = 1
                                            fila1("descripcion") = "0 a 15 kg"
                                            fila1("valor") = "0 a 15 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila1)
                                            Dim fila2 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila2("nro") = 2
                                            fila2("descripcion") = "15 a 20 kg"
                                            fila2("valor") = "15 a 20 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila2)
                                            Dim fila3 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila3("nro") = 3
                                            fila3("descripcion") = "20 a 25 kg"
                                            fila3("valor") = "20 a 25 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila3)
                                            Dim fila4 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila4("nro") = 4
                                            fila4("descripcion") = "25 a 30 kg"
                                            fila4("valor") = "25 a 30 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila4)
                                            Dim fila5 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila5("nro") = 5
                                            fila5("descripcion") = "30 a 35 kg"
                                            fila5("valor") = "30 a 35 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila5)
                                            Dim fila6 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila6("nro") = 6
                                            fila6("descripcion") = "35 a 40 kg"
                                            fila6("valor") = "35 a 40 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila6)
                                            Dim fila7 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila7("nro") = 7
                                            fila7("descripcion") = "40 a 45 kg"
                                            fila7("valor") = "40 a 45 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila7)
                                            Dim fila8 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila8("nro") = 8
                                            fila8("descripcion") = "45 a 50 kg"
                                            fila8("valor") = "45 a 50 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila8)
                                            Dim fila9 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila9("nro") = 9
                                            fila9("descripcion") = "50 a 55 kg"
                                            fila9("valor") = "50 a 55 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila9)
                                            Dim fila10 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila10("nro") = 10
                                            fila10("descripcion") = "55 a 60 kg"
                                            fila10("valor") = "55 a 60 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila10)
                                            Dim fila11 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila11("nro") = 11
                                            fila11("descripcion") = "60 a 65 kg"
                                            fila11("valor") = "60 a 65 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila11)
                                            Dim fila12 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila12("nro") = 12
                                            fila12("descripcion") = "65 a 70 kg"
                                            fila12("valor") = "65 a 70 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila12)
                                            Dim fila13 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila13("nro") = 13
                                            fila13("descripcion") = "70 a 75 kg"
                                            fila13("valor") = "70 a 75 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila13)
                                            Dim fila14 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila14("nro") = 14
                                            fila14("descripcion") = "75 a 80 kg"
                                            fila14("valor") = "75 a 80 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila14)

                                            DropDownList_peso.DataSource = Peso_Ds.Combo_Peso
                                            DropDownList_peso.DataTextField = "descripcion"
                                            DropDownList_peso.DataValueField = "nro"
                                            DropDownList_peso.DataBind()
                                        Case "3" '8 a 9
                                            Dim fila1 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila1("nro") = 1
                                            fila1("descripcion") = "0 a 15 kg"
                                            fila1("valor") = "0 a 15 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila1)
                                            Dim fila2 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila2("nro") = 2
                                            fila2("descripcion") = "15 a 20 kg"
                                            fila2("valor") = "15 a 20 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila2)
                                            Dim fila3 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila3("nro") = 3
                                            fila3("descripcion") = "20 a 25 kg"
                                            fila3("valor") = "20 a 25 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila3)
                                            Dim fila4 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila4("nro") = 4
                                            fila4("descripcion") = "25 a 30 kg"
                                            fila4("valor") = "25 a 30 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila4)
                                            Dim fila5 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila5("nro") = 5
                                            fila5("descripcion") = "30 a 35 kg"
                                            fila5("valor") = "30 a 35 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila5)
                                            Dim fila6 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila6("nro") = 6
                                            fila6("descripcion") = "35 a 40 kg"
                                            fila6("valor") = "35 a 40 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila6)
                                            Dim fila7 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila7("nro") = 7
                                            fila7("descripcion") = "40 a 45 kg"
                                            fila7("valor") = "40 a 45 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila7)
                                            Dim fila8 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila8("nro") = 8
                                            fila8("descripcion") = "45 a 50 kg"
                                            fila8("valor") = "45 a 50 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila8)
                                            Dim fila9 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila9("nro") = 9
                                            fila9("descripcion") = "50 a 55 kg"
                                            fila9("valor") = "50 a 55 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila9)
                                            Dim fila10 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila10("nro") = 10
                                            fila10("descripcion") = "55 a 60 kg"
                                            fila10("valor") = "55 a 60 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila10)
                                            Dim fila11 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila11("nro") = 11
                                            fila11("descripcion") = "60 a 65 kg"
                                            fila11("valor") = "60 a 65 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila11)
                                            Dim fila12 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila12("nro") = 12
                                            fila12("descripcion") = "65 a 70 kg"
                                            fila12("valor") = "65 a 70 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila12)
                                            Dim fila13 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila13("nro") = 13
                                            fila13("descripcion") = "70 a 75 kg"
                                            fila13("valor") = "70 a 75 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila13)
                                            Dim fila14 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila14("nro") = 14
                                            fila14("descripcion") = "75 a 80 kg"
                                            fila14("valor") = "75 a 80 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila14)
                                            Dim fila15 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila15("nro") = 15
                                            fila15("descripcion") = "80 a 85 kg"
                                            fila15("valor") = "80 a 85 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila15)
                                            Dim fila16 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila16("nro") = 16
                                            fila16("descripcion") = "85 a 90 kg"
                                            fila16("valor") = "85 a 90 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila16)

                                            DropDownList_peso.DataSource = Peso_Ds.Combo_Peso
                                            DropDownList_peso.DataTextField = "descripcion"
                                            DropDownList_peso.DataValueField = "nro"
                                            DropDownList_peso.DataBind()
                                        Case "4" '10 a 11
                                            Dim fila1 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila1("nro") = 1
                                            fila1("descripcion") = "0 a 15 kg"
                                            fila1("valor") = "0 a 15 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila1)
                                            Dim fila2 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila2("nro") = 2
                                            fila2("descripcion") = "15 a 20 kg"
                                            fila2("valor") = "15 a 20 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila2)
                                            Dim fila3 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila3("nro") = 3
                                            fila3("descripcion") = "20 a 25 kg"
                                            fila3("valor") = "20 a 25 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila3)
                                            Dim fila4 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila4("nro") = 4
                                            fila4("descripcion") = "25 a 30 kg"
                                            fila4("valor") = "25 a 30 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila4)
                                            Dim fila5 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila5("nro") = 5
                                            fila5("descripcion") = "30 a 35 kg"
                                            fila5("valor") = "30 a 35 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila5)
                                            Dim fila6 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila6("nro") = 6
                                            fila6("descripcion") = "35 a 40 kg"
                                            fila6("valor") = "35 a 40 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila6)
                                            Dim fila7 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila7("nro") = 7
                                            fila7("descripcion") = "40 a 45 kg"
                                            fila7("valor") = "40 a 45 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila7)
                                            Dim fila8 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila8("nro") = 8
                                            fila8("descripcion") = "45 a 50 kg"
                                            fila8("valor") = "45 a 50 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila8)
                                            Dim fila9 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila9("nro") = 9
                                            fila9("descripcion") = "50 a 55 kg"
                                            fila9("valor") = "50 a 55 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila9)
                                            Dim fila10 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila10("nro") = 10
                                            fila10("descripcion") = "55 a 60 kg"
                                            fila10("valor") = "55 a 60 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila10)
                                            Dim fila11 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila11("nro") = 11
                                            fila11("descripcion") = "60 a 65 kg"
                                            fila11("valor") = "60 a 65 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila11)
                                            Dim fila12 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila12("nro") = 12
                                            fila12("descripcion") = "65 a 70 kg"
                                            fila12("valor") = "65 a 70 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila12)
                                            Dim fila13 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila13("nro") = 13
                                            fila13("descripcion") = "70 a 75 kg"
                                            fila13("valor") = "70 a 75 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila13)
                                            Dim fila14 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila14("nro") = 14
                                            fila14("descripcion") = "75 a 80 kg"
                                            fila14("valor") = "75 a 80 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila14)
                                            Dim fila15 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila15("nro") = 15
                                            fila15("descripcion") = "80 a 85 kg"
                                            fila15("valor") = "80 a 85 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila15)
                                            Dim fila16 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila16("nro") = 16
                                            fila16("descripcion") = "85 a 90 kg"
                                            fila16("valor") = "85 a 90 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila16)
                                            Dim fila17 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila17("nro") = 17
                                            fila17("descripcion") = "90 a 95 kg"
                                            fila17("valor") = "90 a 95 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila17)
                                            Dim fila18 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila18("nro") = 18
                                            fila18("descripcion") = "95 a 100 kg"
                                            fila18("valor") = "95 a 100 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila18)

                                            DropDownList_peso.DataSource = Peso_Ds.Combo_Peso
                                            DropDownList_peso.DataTextField = "descripcion"
                                            DropDownList_peso.DataValueField = "nro"
                                            DropDownList_peso.DataBind()
                                    End Select
                                Case 4
                                    Select Case DropDownList_edad.SelectedValue
                                        Case "1" '0 a 5 años
                                            Dim fila1 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila1("nro") = 1
                                            fila1("descripcion") = "0 a 15 kg"
                                            fila1("valor") = "0 a 15 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila1)
                                            Dim fila2 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila2("nro") = 2
                                            fila2("descripcion") = "15 a 20 kg"
                                            fila2("valor") = "15 a 20 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila2)
                                            Dim fila3 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila3("nro") = 3
                                            fila3("descripcion") = "20 a 25 kg"
                                            fila3("valor") = "20 a 25 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila3)
                                            Dim fila4 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila4("nro") = 4
                                            fila4("descripcion") = "25 a 30 kg"
                                            fila4("valor") = "25 a 30 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila4)
                                            Dim fila5 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila5("nro") = 5
                                            fila5("descripcion") = "30 a 35 kg"
                                            fila5("valor") = "30 a 35 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila5)
                                            Dim fila6 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila6("nro") = 6
                                            fila6("descripcion") = "35 a 40 kg"
                                            fila6("valor") = "35 a 40 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila6)
                                            Dim fila7 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila7("nro") = 7
                                            fila7("descripcion") = "40 a 45 kg"
                                            fila7("valor") = "40 a 45 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila7)
                                            Dim fila8 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila8("nro") = 8
                                            fila8("descripcion") = "45 a 50 kg"
                                            fila8("valor") = "45 a 50 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila8)
                                            Dim fila9 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila9("nro") = 9
                                            fila9("descripcion") = "50 a 55 kg"
                                            fila9("valor") = "50 a 55 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila9)
                                            Dim fila10 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila10("nro") = 10
                                            fila10("descripcion") = "55 a 60 kg"
                                            fila10("valor") = "55 a 60 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila10)
                                            Dim fila11 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila11("nro") = 11
                                            fila11("descripcion") = "60 a 65 kg"
                                            fila11("valor") = "60 a 65 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila11)
                                            Dim fila12 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila12("nro") = 12
                                            fila12("descripcion") = "65 a 70 kg"
                                            fila12("valor") = "65 a 70 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila12)
                                            DropDownList_peso.DataSource = Peso_Ds.Combo_Peso
                                            DropDownList_peso.DataTextField = "descripcion"
                                            DropDownList_peso.DataValueField = "nro"
                                            DropDownList_peso.DataBind()

                                        Case "2" '6 a 7 años
                                            Dim fila1 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila1("nro") = 1
                                            fila1("descripcion") = "0 a 15 kg"
                                            fila1("valor") = "0 a 15 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila1)
                                            Dim fila2 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila2("nro") = 2
                                            fila2("descripcion") = "15 a 20 kg"
                                            fila2("valor") = "15 a 20 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila2)
                                            Dim fila3 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila3("nro") = 3
                                            fila3("descripcion") = "20 a 25 kg"
                                            fila3("valor") = "20 a 25 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila3)
                                            Dim fila4 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila4("nro") = 4
                                            fila4("descripcion") = "25 a 30 kg"
                                            fila4("valor") = "25 a 30 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila4)
                                            Dim fila5 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila5("nro") = 5
                                            fila5("descripcion") = "30 a 35 kg"
                                            fila5("valor") = "30 a 35 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila5)
                                            Dim fila6 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila6("nro") = 6
                                            fila6("descripcion") = "35 a 40 kg"
                                            fila6("valor") = "35 a 40 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila6)
                                            Dim fila7 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila7("nro") = 7
                                            fila7("descripcion") = "40 a 45 kg"
                                            fila7("valor") = "40 a 45 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila7)
                                            Dim fila8 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila8("nro") = 8
                                            fila8("descripcion") = "45 a 50 kg"
                                            fila8("valor") = "45 a 50 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila8)
                                            Dim fila9 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila9("nro") = 9
                                            fila9("descripcion") = "50 a 55 kg"
                                            fila9("valor") = "50 a 55 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila9)
                                            Dim fila10 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila10("nro") = 10
                                            fila10("descripcion") = "55 a 60 kg"
                                            fila10("valor") = "55 a 60 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila10)
                                            Dim fila11 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila11("nro") = 11
                                            fila11("descripcion") = "60 a 65 kg"
                                            fila11("valor") = "60 a 65 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila11)
                                            Dim fila12 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila12("nro") = 12
                                            fila12("descripcion") = "65 a 70 kg"
                                            fila12("valor") = "65 a 70 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila12)
                                            Dim fila13 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila13("nro") = 13
                                            fila13("descripcion") = "70 a 75 kg"
                                            fila13("valor") = "70 a 75 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila13)
                                            Dim fila14 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila14("nro") = 14
                                            fila14("descripcion") = "75 a 80 kg"
                                            fila14("valor") = "75 a 80 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila14)

                                            DropDownList_peso.DataSource = Peso_Ds.Combo_Peso
                                            DropDownList_peso.DataTextField = "descripcion"
                                            DropDownList_peso.DataValueField = "nro"
                                            DropDownList_peso.DataBind()
                                        Case "3" '8 a 9 años
                                            Dim fila1 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila1("nro") = 1
                                            fila1("descripcion") = "0 a 15 kg"
                                            fila1("valor") = "0 a 15 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila1)
                                            Dim fila2 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila2("nro") = 2
                                            fila2("descripcion") = "15 a 20 kg"
                                            fila2("valor") = "15 a 20 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila2)
                                            Dim fila3 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila3("nro") = 3
                                            fila3("descripcion") = "20 a 25 kg"
                                            fila3("valor") = "20 a 25 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila3)
                                            Dim fila4 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila4("nro") = 4
                                            fila4("descripcion") = "25 a 30 kg"
                                            fila4("valor") = "25 a 30 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila4)
                                            Dim fila5 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila5("nro") = 5
                                            fila5("descripcion") = "30 a 35 kg"
                                            fila5("valor") = "30 a 35 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila5)
                                            Dim fila6 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila6("nro") = 6
                                            fila6("descripcion") = "35 a 40 kg"
                                            fila6("valor") = "35 a 40 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila6)
                                            Dim fila7 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila7("nro") = 7
                                            fila7("descripcion") = "40 a 45 kg"
                                            fila7("valor") = "40 a 45 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila7)
                                            Dim fila8 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila8("nro") = 8
                                            fila8("descripcion") = "45 a 50 kg"
                                            fila8("valor") = "45 a 50 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila8)
                                            Dim fila9 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila9("nro") = 9
                                            fila9("descripcion") = "50 a 55 kg"
                                            fila9("valor") = "50 a 55 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila9)
                                            Dim fila10 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila10("nro") = 10
                                            fila10("descripcion") = "55 a 60 kg"
                                            fila10("valor") = "55 a 60 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila10)
                                            Dim fila11 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila11("nro") = 11
                                            fila11("descripcion") = "60 a 65 kg"
                                            fila11("valor") = "60 a 65 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila11)
                                            Dim fila12 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila12("nro") = 12
                                            fila12("descripcion") = "65 a 70 kg"
                                            fila12("valor") = "65 a 70 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila12)
                                            Dim fila13 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila13("nro") = 13
                                            fila13("descripcion") = "70 a 75 kg"
                                            fila13("valor") = "70 a 75 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila13)
                                            Dim fila14 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila14("nro") = 14
                                            fila14("descripcion") = "75 a 80 kg"
                                            fila14("valor") = "75 a 80 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila14)
                                            Dim fila15 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila15("nro") = 15
                                            fila15("descripcion") = "80 a 85 kg"
                                            fila15("valor") = "80 a 85 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila15)
                                            Dim fila16 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila16("nro") = 16
                                            fila16("descripcion") = "85 a 90 kg"
                                            fila16("valor") = "85 a 90 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila16)

                                            DropDownList_peso.DataSource = Peso_Ds.Combo_Peso
                                            DropDownList_peso.DataTextField = "descripcion"
                                            DropDownList_peso.DataValueField = "nro"
                                            DropDownList_peso.DataBind()
                                        Case "4" '10 a 11 años
                                            Dim fila1 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila1("nro") = 1
                                            fila1("descripcion") = "0 a 15 kg"
                                            fila1("valor") = "0 a 15 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila1)
                                            Dim fila2 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila2("nro") = 2
                                            fila2("descripcion") = "15 a 20 kg"
                                            fila2("valor") = "15 a 20 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila2)
                                            Dim fila3 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila3("nro") = 3
                                            fila3("descripcion") = "20 a 25 kg"
                                            fila3("valor") = "20 a 25 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila3)
                                            Dim fila4 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila4("nro") = 4
                                            fila4("descripcion") = "25 a 30 kg"
                                            fila4("valor") = "25 a 30 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila4)
                                            Dim fila5 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila5("nro") = 5
                                            fila5("descripcion") = "30 a 35 kg"
                                            fila5("valor") = "30 a 35 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila5)
                                            Dim fila6 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila6("nro") = 6
                                            fila6("descripcion") = "35 a 40 kg"
                                            fila6("valor") = "35 a 40 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila6)
                                            Dim fila7 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila7("nro") = 7
                                            fila7("descripcion") = "40 a 45 kg"
                                            fila7("valor") = "40 a 45 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila7)
                                            Dim fila8 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila8("nro") = 8
                                            fila8("descripcion") = "45 a 50 kg"
                                            fila8("valor") = "45 a 50 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila8)
                                            Dim fila9 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila9("nro") = 9
                                            fila9("descripcion") = "50 a 55 kg"
                                            fila9("valor") = "50 a 55 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila9)
                                            Dim fila10 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila10("nro") = 10
                                            fila10("descripcion") = "55 a 60 kg"
                                            fila10("valor") = "55 a 60 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila10)
                                            Dim fila11 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila11("nro") = 11
                                            fila11("descripcion") = "60 a 65 kg"
                                            fila11("valor") = "60 a 65 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila11)
                                            Dim fila12 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila12("nro") = 12
                                            fila12("descripcion") = "65 a 70 kg"
                                            fila12("valor") = "65 a 70 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila12)
                                            Dim fila13 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila13("nro") = 13
                                            fila13("descripcion") = "70 a 75 kg"
                                            fila13("valor") = "70 a 75 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila13)
                                            Dim fila14 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila14("nro") = 14
                                            fila14("descripcion") = "75 a 80 kg"
                                            fila14("valor") = "75 a 80 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila14)
                                            Dim fila15 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila15("nro") = 15
                                            fila15("descripcion") = "80 a 85 kg"
                                            fila15("valor") = "80 a 85 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila15)
                                            Dim fila16 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila16("nro") = 16
                                            fila16("descripcion") = "85 a 90 kg"
                                            fila16("valor") = "85 a 90 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila16)
                                            Dim fila17 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila17("nro") = 17
                                            fila17("descripcion") = "90 a 95 kg"
                                            fila17("valor") = "90 a 95 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila17)
                                            Dim fila18 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila18("nro") = 18
                                            fila18("descripcion") = "95 a 100 kg"
                                            fila18("valor") = "95 a 100 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila18)

                                            DropDownList_peso.DataSource = Peso_Ds.Combo_Peso
                                            DropDownList_peso.DataTextField = "descripcion"
                                            DropDownList_peso.DataValueField = "nro"
                                            DropDownList_peso.DataBind()
                                    End Select
                                Case 8
                                    Select Case DropDownList_edad.SelectedValue
                                        Case "1" '0 a 5 años
                                            Dim fila1 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila1("nro") = 1
                                            fila1("descripcion") = "0 a 15 kg"
                                            fila1("valor") = "0 a 15 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila1)
                                            Dim fila2 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila2("nro") = 2
                                            fila2("descripcion") = "15 a 20 kg"
                                            fila2("valor") = "15 a 20 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila2)
                                            Dim fila3 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila3("nro") = 3
                                            fila3("descripcion") = "20 a 25 kg"
                                            fila3("valor") = "20 a 25 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila3)
                                            Dim fila4 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila4("nro") = 4
                                            fila4("descripcion") = "25 a 30 kg"
                                            fila4("valor") = "25 a 30 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila4)
                                            Dim fila5 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila5("nro") = 5
                                            fila5("descripcion") = "30 a 35 kg"
                                            fila5("valor") = "30 a 35 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila5)
                                            Dim fila6 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila6("nro") = 6
                                            fila6("descripcion") = "35 a 40 kg"
                                            fila6("valor") = "35 a 40 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila6)
                                            Dim fila7 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila7("nro") = 7
                                            fila7("descripcion") = "40 a 45 kg"
                                            fila7("valor") = "40 a 45 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila7)
                                            Dim fila8 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila8("nro") = 8
                                            fila8("descripcion") = "45 a 50 kg"
                                            fila8("valor") = "45 a 50 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila8)
                                            Dim fila9 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila9("nro") = 9
                                            fila9("descripcion") = "50 a 55 kg"
                                            fila9("valor") = "50 a 55 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila9)
                                            Dim fila10 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila10("nro") = 10
                                            fila10("descripcion") = "55 a 60 kg"
                                            fila10("valor") = "55 a 60 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila10)
                                            Dim fila11 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila11("nro") = 11
                                            fila11("descripcion") = "60 a 65 kg"
                                            fila11("valor") = "60 a 65 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila11)
                                            Dim fila12 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila12("nro") = 12
                                            fila12("descripcion") = "65 a 70 kg"
                                            fila12("valor") = "65 a 70 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila12)
                                            DropDownList_peso.DataSource = Peso_Ds.Combo_Peso
                                            DropDownList_peso.DataTextField = "descripcion"
                                            DropDownList_peso.DataValueField = "nro"
                                            DropDownList_peso.DataBind()

                                        Case "2" '6 a 7 años
                                            Dim fila1 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila1("nro") = 1
                                            fila1("descripcion") = "0 a 15 kg"
                                            fila1("valor") = "0 a 15 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila1)
                                            Dim fila2 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila2("nro") = 2
                                            fila2("descripcion") = "15 a 20 kg"
                                            fila2("valor") = "15 a 20 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila2)
                                            Dim fila3 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila3("nro") = 3
                                            fila3("descripcion") = "20 a 25 kg"
                                            fila3("valor") = "20 a 25 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila3)
                                            Dim fila4 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila4("nro") = 4
                                            fila4("descripcion") = "25 a 30 kg"
                                            fila4("valor") = "25 a 30 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila4)
                                            Dim fila5 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila5("nro") = 5
                                            fila5("descripcion") = "30 a 35 kg"
                                            fila5("valor") = "30 a 35 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila5)
                                            Dim fila6 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila6("nro") = 6
                                            fila6("descripcion") = "35 a 40 kg"
                                            fila6("valor") = "35 a 40 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila6)
                                            Dim fila7 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila7("nro") = 7
                                            fila7("descripcion") = "40 a 45 kg"
                                            fila7("valor") = "40 a 45 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila7)
                                            Dim fila8 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila8("nro") = 8
                                            fila8("descripcion") = "45 a 50 kg"
                                            fila8("valor") = "45 a 50 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila8)
                                            Dim fila9 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila9("nro") = 9
                                            fila9("descripcion") = "50 a 55 kg"
                                            fila9("valor") = "50 a 55 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila9)
                                            Dim fila10 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila10("nro") = 10
                                            fila10("descripcion") = "55 a 60 kg"
                                            fila10("valor") = "55 a 60 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila10)
                                            Dim fila11 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila11("nro") = 11
                                            fila11("descripcion") = "60 a 65 kg"
                                            fila11("valor") = "60 a 65 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila11)
                                            Dim fila12 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila12("nro") = 12
                                            fila12("descripcion") = "65 a 70 kg"
                                            fila12("valor") = "65 a 70 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila12)
                                            Dim fila13 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila13("nro") = 13
                                            fila13("descripcion") = "70 a 75 kg"
                                            fila13("valor") = "70 a 75 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila13)
                                            Dim fila14 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila14("nro") = 14
                                            fila14("descripcion") = "75 a 80 kg"
                                            fila14("valor") = "75 a 80 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila14)

                                            DropDownList_peso.DataSource = Peso_Ds.Combo_Peso
                                            DropDownList_peso.DataTextField = "descripcion"
                                            DropDownList_peso.DataValueField = "nro"
                                            DropDownList_peso.DataBind()
                                        Case "3" '8 a 9 años
                                            Dim fila1 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila1("nro") = 1
                                            fila1("descripcion") = "0 a 15 kg"
                                            fila1("valor") = "0 a 15 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila1)
                                            Dim fila2 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila2("nro") = 2
                                            fila2("descripcion") = "15 a 20 kg"
                                            fila2("valor") = "15 a 20 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila2)
                                            Dim fila3 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila3("nro") = 3
                                            fila3("descripcion") = "20 a 25 kg"
                                            fila3("valor") = "20 a 25 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila3)
                                            Dim fila4 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila4("nro") = 4
                                            fila4("descripcion") = "25 a 30 kg"
                                            fila4("valor") = "25 a 30 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila4)
                                            Dim fila5 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila5("nro") = 5
                                            fila5("descripcion") = "30 a 35 kg"
                                            fila5("valor") = "30 a 35 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila5)
                                            Dim fila6 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila6("nro") = 6
                                            fila6("descripcion") = "35 a 40 kg"
                                            fila6("valor") = "35 a 40 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila6)
                                            Dim fila7 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila7("nro") = 7
                                            fila7("descripcion") = "40 a 45 kg"
                                            fila7("valor") = "40 a 45 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila7)
                                            Dim fila8 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila8("nro") = 8
                                            fila8("descripcion") = "45 a 50 kg"
                                            fila8("valor") = "45 a 50 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila8)
                                            Dim fila9 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila9("nro") = 9
                                            fila9("descripcion") = "50 a 55 kg"
                                            fila9("valor") = "50 a 55 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila9)
                                            Dim fila10 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila10("nro") = 10
                                            fila10("descripcion") = "55 a 60 kg"
                                            fila10("valor") = "55 a 60 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila10)
                                            Dim fila11 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila11("nro") = 11
                                            fila11("descripcion") = "60 a 65 kg"
                                            fila11("valor") = "60 a 65 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila11)
                                            Dim fila12 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila12("nro") = 12
                                            fila12("descripcion") = "65 a 70 kg"
                                            fila12("valor") = "65 a 70 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila12)
                                            Dim fila13 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila13("nro") = 13
                                            fila13("descripcion") = "70 a 75 kg"
                                            fila13("valor") = "70 a 75 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila13)
                                            Dim fila14 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila14("nro") = 14
                                            fila14("descripcion") = "75 a 80 kg"
                                            fila14("valor") = "75 a 80 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila14)
                                            Dim fila15 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila15("nro") = 15
                                            fila15("descripcion") = "80 a 85 kg"
                                            fila15("valor") = "80 a 85 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila15)
                                            Dim fila16 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila16("nro") = 16
                                            fila16("descripcion") = "85 a 90 kg"
                                            fila16("valor") = "85 a 90 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila16)

                                            DropDownList_peso.DataSource = Peso_Ds.Combo_Peso
                                            DropDownList_peso.DataTextField = "descripcion"
                                            DropDownList_peso.DataValueField = "nro"
                                            DropDownList_peso.DataBind()
                                        Case "4" '10 a 11 años
                                            Dim fila1 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila1("nro") = 1
                                            fila1("descripcion") = "0 a 15 kg"
                                            fila1("valor") = "0 a 15 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila1)
                                            Dim fila2 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila2("nro") = 2
                                            fila2("descripcion") = "15 a 20 kg"
                                            fila2("valor") = "15 a 20 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila2)
                                            Dim fila3 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila3("nro") = 3
                                            fila3("descripcion") = "20 a 25 kg"
                                            fila3("valor") = "20 a 25 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila3)
                                            Dim fila4 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila4("nro") = 4
                                            fila4("descripcion") = "25 a 30 kg"
                                            fila4("valor") = "25 a 30 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila4)
                                            Dim fila5 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila5("nro") = 5
                                            fila5("descripcion") = "30 a 35 kg"
                                            fila5("valor") = "30 a 35 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila5)
                                            Dim fila6 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila6("nro") = 6
                                            fila6("descripcion") = "35 a 40 kg"
                                            fila6("valor") = "35 a 40 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila6)
                                            Dim fila7 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila7("nro") = 7
                                            fila7("descripcion") = "40 a 45 kg"
                                            fila7("valor") = "40 a 45 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila7)
                                            Dim fila8 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila8("nro") = 8
                                            fila8("descripcion") = "45 a 50 kg"
                                            fila8("valor") = "45 a 50 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila8)
                                            Dim fila9 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila9("nro") = 9
                                            fila9("descripcion") = "50 a 55 kg"
                                            fila9("valor") = "50 a 55 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila9)
                                            Dim fila10 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila10("nro") = 10
                                            fila10("descripcion") = "55 a 60 kg"
                                            fila10("valor") = "55 a 60 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila10)
                                            Dim fila11 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila11("nro") = 11
                                            fila11("descripcion") = "60 a 65 kg"
                                            fila11("valor") = "60 a 65 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila11)
                                            Dim fila12 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila12("nro") = 12
                                            fila12("descripcion") = "65 a 70 kg"
                                            fila12("valor") = "65 a 70 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila12)
                                            Dim fila13 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila13("nro") = 13
                                            fila13("descripcion") = "70 a 75 kg"
                                            fila13("valor") = "70 a 75 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila13)
                                            Dim fila14 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila14("nro") = 14
                                            fila14("descripcion") = "75 a 80 kg"
                                            fila14("valor") = "75 a 80 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila14)
                                            Dim fila15 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila15("nro") = 15
                                            fila15("descripcion") = "80 a 85 kg"
                                            fila15("valor") = "80 a 85 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila15)
                                            Dim fila16 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila16("nro") = 16
                                            fila16("descripcion") = "85 a 90 kg"
                                            fila16("valor") = "85 a 90 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila16)
                                            Dim fila17 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila17("nro") = 17
                                            fila17("descripcion") = "90 a 95 kg"
                                            fila17("valor") = "90 a 95 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila17)
                                            Dim fila18 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila18("nro") = 18
                                            fila18("descripcion") = "95 a 100 kg"
                                            fila18("valor") = "95 a 100 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila18)

                                            DropDownList_peso.DataSource = Peso_Ds.Combo_Peso
                                            DropDownList_peso.DataTextField = "descripcion"
                                            DropDownList_peso.DataValueField = "nro"
                                            DropDownList_peso.DataBind()
                                    End Select
                                Case 12
                                    Select Case DropDownList_edad.SelectedValue
                                        Case 1 '10 a 11 años
                                            Dim fila1 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila1("nro") = 1
                                            fila1("descripcion") = "0 a 15 kg"
                                            fila1("valor") = "0 a 15 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila1)
                                            Dim fila2 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila2("nro") = 2
                                            fila2("descripcion") = "15 a 20 kg"
                                            fila2("valor") = "15 a 20 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila2)
                                            Dim fila3 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila3("nro") = 3
                                            fila3("descripcion") = "20 a 25 kg"
                                            fila3("valor") = "20 a 25 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila3)
                                            Dim fila4 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila4("nro") = 4
                                            fila4("descripcion") = "25 a 30 kg"
                                            fila4("valor") = "25 a 30 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila4)
                                            Dim fila5 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila5("nro") = 5
                                            fila5("descripcion") = "30 a 35 kg"
                                            fila5("valor") = "30 a 35 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila5)
                                            Dim fila6 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila6("nro") = 6
                                            fila6("descripcion") = "35 a 40 kg"
                                            fila6("valor") = "35 a 40 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila6)
                                            Dim fila7 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila7("nro") = 7
                                            fila7("descripcion") = "40 a 45 kg"
                                            fila7("valor") = "40 a 45 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila7)
                                            Dim fila8 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila8("nro") = 8
                                            fila8("descripcion") = "45 a 50 kg"
                                            fila8("valor") = "45 a 50 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila8)
                                            Dim fila9 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila9("nro") = 9
                                            fila9("descripcion") = "50 a 55 kg"
                                            fila9("valor") = "50 a 55 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila9)
                                            Dim fila10 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila10("nro") = 10
                                            fila10("descripcion") = "55 a 60 kg"
                                            fila10("valor") = "55 a 60 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila10)
                                            Dim fila11 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila11("nro") = 11
                                            fila11("descripcion") = "60 a 65 kg"
                                            fila11("valor") = "60 a 65 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila11)
                                            Dim fila12 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila12("nro") = 12
                                            fila12("descripcion") = "65 a 70 kg"
                                            fila12("valor") = "65 a 70 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila12)
                                            Dim fila13 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila13("nro") = 13
                                            fila13("descripcion") = "70 a 75 kg"
                                            fila13("valor") = "70 a 75 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila13)
                                            Dim fila14 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila14("nro") = 14
                                            fila14("descripcion") = "75 a 80 kg"
                                            fila14("valor") = "75 a 80 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila14)
                                            Dim fila15 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila15("nro") = 15
                                            fila15("descripcion") = "80 a 85 kg"
                                            fila15("valor") = "80 a 85 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila15)
                                            Dim fila16 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila16("nro") = 16
                                            fila16("descripcion") = "85 a 90 kg"
                                            fila16("valor") = "85 a 90 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila16)
                                            Dim fila17 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila17("nro") = 17
                                            fila17("descripcion") = "90 a 95 kg"
                                            fila17("valor") = "90 a 95 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila17)
                                            Dim fila18 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila18("nro") = 18
                                            fila18("descripcion") = "95 a 100 kg"
                                            fila18("valor") = "95 a 100 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila18)

                                            DropDownList_peso.DataSource = Peso_Ds.Combo_Peso
                                            DropDownList_peso.DataTextField = "descripcion"
                                            DropDownList_peso.DataValueField = "nro"
                                            DropDownList_peso.DataBind()
                                    End Select
                            End Select
                        Case "Hombre"
                            Select Case HF_graduacion_inicial.Value
                                Case 2 'esto es graduacion
                                    Select Case DropDownList_edad.SelectedValue
                                        Case 1 '12 a 13 años
                                            Dim fila1 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila1("nro") = 1
                                            fila1("descripcion") = "0 a 40 kg"
                                            fila1("valor") = "0 a 40 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila1)
                                            Dim fila2 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila2("nro") = 2
                                            fila2("descripcion") = "40 a 45 kg"
                                            fila2("valor") = "40 a 45 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila2)
                                            Dim fila3 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila3("nro") = 3
                                            fila3("descripcion") = "45 a 50 kg"
                                            fila3("valor") = "45 a 50 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila3)
                                            Dim fila4 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila4("nro") = 4
                                            fila4("descripcion") = "50 a 55 kg"
                                            fila4("valor") = "50 a 55 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila4)
                                            Dim fila5 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila5("nro") = 5
                                            fila5("descripcion") = "55 a 999 kg"
                                            fila5("valor") = "55 a 999 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila5)

                                            DropDownList_peso.DataSource = Peso_Ds.Combo_Peso
                                            DropDownList_peso.DataTextField = "descripcion"
                                            DropDownList_peso.DataValueField = "nro"
                                            DropDownList_peso.DataBind()
                                        Case 2 '14 a 15 años
                                            Dim fila1 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila1("nro") = 1
                                            fila1("descripcion") = "0 a 50 kg"
                                            fila1("valor") = "0 a 50 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila1)
                                            Dim fila2 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila2("nro") = 2
                                            fila2("descripcion") = "50 a 55 kg"
                                            fila2("valor") = "50 a 55 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila2)
                                            Dim fila3 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila3("nro") = 3
                                            fila3("descripcion") = "55 a 60 kg"
                                            fila3("valor") = "55 a 60 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila3)
                                            Dim fila4 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila4("nro") = 4
                                            fila4("descripcion") = "60 a 65 kg"
                                            fila4("valor") = "60 a 65 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila4)
                                            Dim fila5 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila5("nro") = 5
                                            fila5("descripcion") = "65 a 70 kg"
                                            fila5("valor") = "65 a 70 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila5)
                                            Dim fila6 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila6("nro") = 6
                                            fila6("descripcion") = "70 a 999 kg"
                                            fila6("valor") = "70 a 999 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila6)

                                            DropDownList_peso.DataSource = Peso_Ds.Combo_Peso
                                            DropDownList_peso.DataTextField = "descripcion"
                                            DropDownList_peso.DataValueField = "nro"
                                            DropDownList_peso.DataBind()
                                        Case 3 '16 a 17 años
                                            Dim fila1 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila1("nro") = 1
                                            fila1("descripcion") = "0 a 50 kg"
                                            fila1("valor") = "0 a 50 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila1)
                                            Dim fila2 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila2("nro") = 2
                                            fila2("descripcion") = "50 a 55 kg"
                                            fila2("valor") = "50 a 55 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila2)
                                            Dim fila3 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila3("nro") = 3
                                            fila3("descripcion") = "55 a 60 kg"
                                            fila3("valor") = "55 a 60 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila3)
                                            Dim fila4 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila4("nro") = 4
                                            fila4("descripcion") = "60 a 65 kg"
                                            fila4("valor") = "60 a 65 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila4)
                                            Dim fila5 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila5("nro") = 5
                                            fila5("descripcion") = "65 a 70 kg"
                                            fila5("valor") = "65 a 70 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila5)
                                            Dim fila6 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila6("nro") = 6
                                            fila6("descripcion") = "70 a 999 kg"
                                            fila6("valor") = "70 a 999 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila6)

                                            DropDownList_peso.DataSource = Peso_Ds.Combo_Peso
                                            DropDownList_peso.DataTextField = "descripcion"
                                            DropDownList_peso.DataValueField = "nro"
                                            DropDownList_peso.DataBind()
                                        Case 4 '18 a 35 años
                                            Dim fila1 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila1("nro") = 1
                                            fila1("descripcion") = "0 a 58 kg"
                                            fila1("valor") = "0 a 58 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila1)
                                            Dim fila2 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila2("nro") = 2
                                            fila2("descripcion") = "58 a 64 kg"
                                            fila2("valor") = "58 a 64 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila2)
                                            Dim fila3 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila3("nro") = 3
                                            fila3("descripcion") = "64 a 70 kg"
                                            fila3("valor") = "64 a 70 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila3)
                                            Dim fila4 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila4("nro") = 4
                                            fila4("descripcion") = "70 a 76 kg"
                                            fila4("valor") = "70 a 76 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila4)
                                            Dim fila5 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila5("nro") = 5
                                            fila5("descripcion") = "76 a 82 kg"
                                            fila5("valor") = "76 a 82 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila5)
                                            Dim fila6 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila6("nro") = 6
                                            fila6("descripcion") = "82 a 999 kg"
                                            fila6("valor") = "82 a 999 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila6)

                                            DropDownList_peso.DataSource = Peso_Ds.Combo_Peso
                                            DropDownList_peso.DataTextField = "descripcion"
                                            DropDownList_peso.DataValueField = "nro"
                                            DropDownList_peso.DataBind()

                                        Case 5 '36 a 45 años
                                            Dim fila1 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila1("nro") = 1
                                            fila1("descripcion") = "0 a 58 kg"
                                            fila1("valor") = "0 a 58 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila1)
                                            Dim fila2 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila2("nro") = 2
                                            fila2("descripcion") = "58 a 64 kg"
                                            fila2("valor") = "58 a 64 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila2)
                                            Dim fila3 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila3("nro") = 3
                                            fila3("descripcion") = "64 a 70 kg"
                                            fila3("valor") = "64 a 70 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila3)
                                            Dim fila4 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila4("nro") = 4
                                            fila4("descripcion") = "70 a 76 kg"
                                            fila4("valor") = "70 a 76 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila4)
                                            Dim fila5 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila5("nro") = 5
                                            fila5("descripcion") = "76 a 82 kg"
                                            fila5("valor") = "76 a 82 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila5)
                                            Dim fila6 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila6("nro") = 6
                                            fila6("descripcion") = "82 a 999 kg"
                                            fila6("valor") = "82 a 999 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila6)

                                            DropDownList_peso.DataSource = Peso_Ds.Combo_Peso
                                            DropDownList_peso.DataTextField = "descripcion"
                                            DropDownList_peso.DataValueField = "nro"
                                            DropDownList_peso.DataBind()
                                        Case 6 '46 a 55
                                            Dim fila1 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila1("nro") = 1
                                            fila1("descripcion") = "0 a 58 kg"
                                            fila1("valor") = "0 a 58 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila1)
                                            Dim fila2 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila2("nro") = 2
                                            fila2("descripcion") = "58 a 64 kg"
                                            fila2("valor") = "58 a 64 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila2)
                                            Dim fila3 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila3("nro") = 3
                                            fila3("descripcion") = "64 a 70 kg"
                                            fila3("valor") = "64 a 70 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila3)
                                            Dim fila4 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila4("nro") = 4
                                            fila4("descripcion") = "70 a 76 kg"
                                            fila4("valor") = "70 a 76 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila4)
                                            Dim fila5 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila5("nro") = 5
                                            fila5("descripcion") = "76 a 82 kg"
                                            fila5("valor") = "76 a 82 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila5)
                                            Dim fila6 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila6("nro") = 6
                                            fila6("descripcion") = "82 a 999 kg"
                                            fila6("valor") = "82 a 999 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila6)

                                            DropDownList_peso.DataSource = Peso_Ds.Combo_Peso
                                            DropDownList_peso.DataTextField = "descripcion"
                                            DropDownList_peso.DataValueField = "nro"
                                            DropDownList_peso.DataBind()
                                        Case 7 '56 a 99 años
                                            Dim fila1 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila1("nro") = 1
                                            fila1("descripcion") = "0 a 58 kg"
                                            fila1("valor") = "0 a 58 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila1)
                                            Dim fila2 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila2("nro") = 2
                                            fila2("descripcion") = "58 a 64 kg"
                                            fila2("valor") = "58 a 64 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila2)
                                            Dim fila3 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila3("nro") = 3
                                            fila3("descripcion") = "64 a 70 kg"
                                            fila3("valor") = "64 a 70 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila3)
                                            Dim fila4 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila4("nro") = 4
                                            fila4("descripcion") = "70 a 76 kg"
                                            fila4("valor") = "70 a 76 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila4)
                                            Dim fila5 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila5("nro") = 5
                                            fila5("descripcion") = "76 a 82 kg"
                                            fila5("valor") = "76 a 82 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila5)
                                            Dim fila6 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila6("nro") = 6
                                            fila6("descripcion") = "82 a 999 kg"
                                            fila6("valor") = "82 a 999 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila6)

                                            DropDownList_peso.DataSource = Peso_Ds.Combo_Peso
                                            DropDownList_peso.DataTextField = "descripcion"
                                            DropDownList_peso.DataValueField = "nro"
                                            DropDownList_peso.DataBind()
                                    End Select
                                Case 4
                                    Select Case DropDownList_edad.SelectedValue
                                        Case 1 '12 a 13 años
                                            Dim fila1 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila1("nro") = 1
                                            fila1("descripcion") = "0 a 40 kg"
                                            fila1("valor") = "0 a 40 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila1)
                                            Dim fila2 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila2("nro") = 2
                                            fila2("descripcion") = "40 a 45 kg"
                                            fila2("valor") = "40 a 45 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila2)
                                            Dim fila3 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila3("nro") = 3
                                            fila3("descripcion") = "45 a 50 kg"
                                            fila3("valor") = "45 a 50 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila3)
                                            Dim fila4 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila4("nro") = 4
                                            fila4("descripcion") = "50 a 55 kg"
                                            fila4("valor") = "50 a 55 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila4)
                                            Dim fila5 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila5("nro") = 5
                                            fila5("descripcion") = "55 a 999 kg"
                                            fila5("valor") = "55 a 999 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila5)

                                            DropDownList_peso.DataSource = Peso_Ds.Combo_Peso
                                            DropDownList_peso.DataTextField = "descripcion"
                                            DropDownList_peso.DataValueField = "nro"
                                            DropDownList_peso.DataBind()
                                        Case 2 '14 a 15 años
                                            Dim fila1 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila1("nro") = 1
                                            fila1("descripcion") = "0 a 50 kg"
                                            fila1("valor") = "0 a 50 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila1)
                                            Dim fila2 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila2("nro") = 2
                                            fila2("descripcion") = "50 a 55 kg"
                                            fila2("valor") = "50 a 55 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila2)
                                            Dim fila3 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila3("nro") = 3
                                            fila3("descripcion") = "55 a 60 kg"
                                            fila3("valor") = "55 a 60 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila3)
                                            Dim fila4 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila4("nro") = 4
                                            fila4("descripcion") = "60 a 65 kg"
                                            fila4("valor") = "60 a 65 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila4)
                                            Dim fila5 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila5("nro") = 5
                                            fila5("descripcion") = "65 a 70 kg"
                                            fila5("valor") = "65 a 70 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila5)
                                            Dim fila6 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila6("nro") = 6
                                            fila6("descripcion") = "70 a 999 kg"
                                            fila6("valor") = "70 a 999 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila6)

                                            DropDownList_peso.DataSource = Peso_Ds.Combo_Peso
                                            DropDownList_peso.DataTextField = "descripcion"
                                            DropDownList_peso.DataValueField = "nro"
                                            DropDownList_peso.DataBind()
                                        Case 3 '16 a 17 años
                                            Dim fila1 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila1("nro") = 1
                                            fila1("descripcion") = "0 a 50 kg"
                                            fila1("valor") = "0 a 50 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila1)
                                            Dim fila2 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila2("nro") = 2
                                            fila2("descripcion") = "50 a 55 kg"
                                            fila2("valor") = "50 a 55 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila2)
                                            Dim fila3 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila3("nro") = 3
                                            fila3("descripcion") = "55 a 60 kg"
                                            fila3("valor") = "55 a 60 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila3)
                                            Dim fila4 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila4("nro") = 4
                                            fila4("descripcion") = "60 a 65 kg"
                                            fila4("valor") = "60 a 65 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila4)
                                            Dim fila5 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila5("nro") = 5
                                            fila5("descripcion") = "65 a 70 kg"
                                            fila5("valor") = "65 a 70 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila5)
                                            Dim fila6 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila6("nro") = 6
                                            fila6("descripcion") = "70 a 999 kg"
                                            fila6("valor") = "70 a 999 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila6)

                                            DropDownList_peso.DataSource = Peso_Ds.Combo_Peso
                                            DropDownList_peso.DataTextField = "descripcion"
                                            DropDownList_peso.DataValueField = "nro"
                                            DropDownList_peso.DataBind()
                                        Case 4 '18 a 35 años
                                            Dim fila1 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila1("nro") = 1
                                            fila1("descripcion") = "0 a 58 kg"
                                            fila1("valor") = "0 a 58 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila1)
                                            Dim fila2 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila2("nro") = 2
                                            fila2("descripcion") = "58 a 64 kg"
                                            fila2("valor") = "58 a 64 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila2)
                                            Dim fila3 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila3("nro") = 3
                                            fila3("descripcion") = "64 a 70 kg"
                                            fila3("valor") = "64 a 70 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila3)
                                            Dim fila4 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila4("nro") = 4
                                            fila4("descripcion") = "70 a 76 kg"
                                            fila4("valor") = "70 a 76 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila4)
                                            Dim fila5 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila5("nro") = 5
                                            fila5("descripcion") = "76 a 82 kg"
                                            fila5("valor") = "76 a 82 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila5)
                                            Dim fila6 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila6("nro") = 6
                                            fila6("descripcion") = "82 a 999 kg"
                                            fila6("valor") = "82 a 999 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila6)

                                            DropDownList_peso.DataSource = Peso_Ds.Combo_Peso
                                            DropDownList_peso.DataTextField = "descripcion"
                                            DropDownList_peso.DataValueField = "nro"
                                            DropDownList_peso.DataBind()

                                        Case 5 '36 a 45 años
                                            Dim fila1 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila1("nro") = 1
                                            fila1("descripcion") = "0 a 58 kg"
                                            fila1("valor") = "0 a 58 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila1)
                                            Dim fila2 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila2("nro") = 2
                                            fila2("descripcion") = "58 a 64 kg"
                                            fila2("valor") = "58 a 64 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila2)
                                            Dim fila3 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila3("nro") = 3
                                            fila3("descripcion") = "64 a 70 kg"
                                            fila3("valor") = "64 a 70 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila3)
                                            Dim fila4 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila4("nro") = 4
                                            fila4("descripcion") = "70 a 76 kg"
                                            fila4("valor") = "70 a 76 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila4)
                                            Dim fila5 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila5("nro") = 5
                                            fila5("descripcion") = "76 a 82 kg"
                                            fila5("valor") = "76 a 82 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila5)
                                            Dim fila6 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila6("nro") = 6
                                            fila6("descripcion") = "82 a 999 kg"
                                            fila6("valor") = "82 a 999 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila6)

                                            DropDownList_peso.DataSource = Peso_Ds.Combo_Peso
                                            DropDownList_peso.DataTextField = "descripcion"
                                            DropDownList_peso.DataValueField = "nro"
                                            DropDownList_peso.DataBind()
                                        Case 6 '46 a 55
                                            Dim fila1 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila1("nro") = 1
                                            fila1("descripcion") = "0 a 58 kg"
                                            fila1("valor") = "0 a 58 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila1)
                                            Dim fila2 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila2("nro") = 2
                                            fila2("descripcion") = "58 a 64 kg"
                                            fila2("valor") = "58 a 64 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila2)
                                            Dim fila3 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila3("nro") = 3
                                            fila3("descripcion") = "64 a 70 kg"
                                            fila3("valor") = "64 a 70 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila3)
                                            Dim fila4 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila4("nro") = 4
                                            fila4("descripcion") = "70 a 76 kg"
                                            fila4("valor") = "70 a 76 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila4)
                                            Dim fila5 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila5("nro") = 5
                                            fila5("descripcion") = "76 a 82 kg"
                                            fila5("valor") = "76 a 82 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila5)
                                            Dim fila6 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila6("nro") = 6
                                            fila6("descripcion") = "82 a 999 kg"
                                            fila6("valor") = "82 a 999 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila6)

                                            DropDownList_peso.DataSource = Peso_Ds.Combo_Peso
                                            DropDownList_peso.DataTextField = "descripcion"
                                            DropDownList_peso.DataValueField = "nro"
                                            DropDownList_peso.DataBind()
                                        Case 7 '56 a 99 años
                                            Dim fila1 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila1("nro") = 1
                                            fila1("descripcion") = "0 a 58 kg"
                                            fila1("valor") = "0 a 58 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila1)
                                            Dim fila2 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila2("nro") = 2
                                            fila2("descripcion") = "58 a 64 kg"
                                            fila2("valor") = "58 a 64 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila2)
                                            Dim fila3 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila3("nro") = 3
                                            fila3("descripcion") = "64 a 70 kg"
                                            fila3("valor") = "64 a 70 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila3)
                                            Dim fila4 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila4("nro") = 4
                                            fila4("descripcion") = "70 a 76 kg"
                                            fila4("valor") = "70 a 76 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila4)
                                            Dim fila5 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila5("nro") = 5
                                            fila5("descripcion") = "76 a 82 kg"
                                            fila5("valor") = "76 a 82 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila5)
                                            Dim fila6 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila6("nro") = 6
                                            fila6("descripcion") = "82 a 999 kg"
                                            fila6("valor") = "82 a 999 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila6)

                                            DropDownList_peso.DataSource = Peso_Ds.Combo_Peso
                                            DropDownList_peso.DataTextField = "descripcion"
                                            DropDownList_peso.DataValueField = "nro"
                                            DropDownList_peso.DataBind()
                                    End Select
                                Case 8
                                    Select Case DropDownList_edad.SelectedValue
                                        Case 1 '12 a 13 años
                                            Dim fila1 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila1("nro") = 1
                                            fila1("descripcion") = "0 a 40 kg"
                                            fila1("valor") = "0 a 40 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila1)
                                            Dim fila2 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila2("nro") = 2
                                            fila2("descripcion") = "40 a 45 kg"
                                            fila2("valor") = "40 a 45 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila2)
                                            Dim fila3 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila3("nro") = 3
                                            fila3("descripcion") = "45 a 50 kg"
                                            fila3("valor") = "45 a 50 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila3)
                                            Dim fila4 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila4("nro") = 4
                                            fila4("descripcion") = "50 a 55 kg"
                                            fila4("valor") = "50 a 55 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila4)
                                            Dim fila5 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila5("nro") = 5
                                            fila5("descripcion") = "55 a 999 kg"
                                            fila5("valor") = "55 a 999 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila5)

                                            DropDownList_peso.DataSource = Peso_Ds.Combo_Peso
                                            DropDownList_peso.DataTextField = "descripcion"
                                            DropDownList_peso.DataValueField = "nro"
                                            DropDownList_peso.DataBind()
                                        Case 2 '14 a 15 años
                                            Dim fila1 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila1("nro") = 1
                                            fila1("descripcion") = "0 a 50 kg"
                                            fila1("valor") = "0 a 50 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila1)
                                            Dim fila2 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila2("nro") = 2
                                            fila2("descripcion") = "50 a 55 kg"
                                            fila2("valor") = "50 a 55 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila2)
                                            Dim fila3 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila3("nro") = 3
                                            fila3("descripcion") = "55 a 60 kg"
                                            fila3("valor") = "55 a 60 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila3)
                                            Dim fila4 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila4("nro") = 4
                                            fila4("descripcion") = "60 a 65 kg"
                                            fila4("valor") = "60 a 65 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila4)
                                            Dim fila5 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila5("nro") = 5
                                            fila5("descripcion") = "65 a 70 kg"
                                            fila5("valor") = "65 a 70 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila5)
                                            Dim fila6 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila6("nro") = 6
                                            fila6("descripcion") = "70 a 999 kg"
                                            fila6("valor") = "70 a 999 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila6)

                                            DropDownList_peso.DataSource = Peso_Ds.Combo_Peso
                                            DropDownList_peso.DataTextField = "descripcion"
                                            DropDownList_peso.DataValueField = "nro"
                                            DropDownList_peso.DataBind()
                                        Case 3 '16 a 17 años
                                            Dim fila1 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila1("nro") = 1
                                            fila1("descripcion") = "0 a 50 kg"
                                            fila1("valor") = "0 a 50 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila1)
                                            Dim fila2 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila2("nro") = 2
                                            fila2("descripcion") = "50 a 55 kg"
                                            fila2("valor") = "50 a 55 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila2)
                                            Dim fila3 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila3("nro") = 3
                                            fila3("descripcion") = "55 a 60 kg"
                                            fila3("valor") = "55 a 60 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila3)
                                            Dim fila4 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila4("nro") = 4
                                            fila4("descripcion") = "60 a 65 kg"
                                            fila4("valor") = "60 a 65 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila4)
                                            Dim fila5 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila5("nro") = 5
                                            fila5("descripcion") = "65 a 70 kg"
                                            fila5("valor") = "65 a 70 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila5)
                                            Dim fila6 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila6("nro") = 6
                                            fila6("descripcion") = "70 a 999 kg"
                                            fila6("valor") = "70 a 999 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila6)

                                            DropDownList_peso.DataSource = Peso_Ds.Combo_Peso
                                            DropDownList_peso.DataTextField = "descripcion"
                                            DropDownList_peso.DataValueField = "nro"
                                            DropDownList_peso.DataBind()
                                        Case 4 '18 a 35 años
                                            Dim fila1 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila1("nro") = 1
                                            fila1("descripcion") = "0 a 58 kg"
                                            fila1("valor") = "0 a 58 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila1)
                                            Dim fila2 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila2("nro") = 2
                                            fila2("descripcion") = "58 a 64 kg"
                                            fila2("valor") = "58 a 64 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila2)
                                            Dim fila3 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila3("nro") = 3
                                            fila3("descripcion") = "64 a 70 kg"
                                            fila3("valor") = "64 a 70 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila3)
                                            Dim fila4 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila4("nro") = 4
                                            fila4("descripcion") = "70 a 76 kg"
                                            fila4("valor") = "70 a 76 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila4)
                                            Dim fila5 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila5("nro") = 5
                                            fila5("descripcion") = "76 a 82 kg"
                                            fila5("valor") = "76 a 82 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila5)
                                            Dim fila6 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila6("nro") = 6
                                            fila6("descripcion") = "82 a 999 kg"
                                            fila6("valor") = "82 a 999 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila6)

                                            DropDownList_peso.DataSource = Peso_Ds.Combo_Peso
                                            DropDownList_peso.DataTextField = "descripcion"
                                            DropDownList_peso.DataValueField = "nro"
                                            DropDownList_peso.DataBind()

                                        Case 5 '36 a 45 años
                                            Dim fila1 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila1("nro") = 1
                                            fila1("descripcion") = "0 a 58 kg"
                                            fila1("valor") = "0 a 58 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila1)
                                            Dim fila2 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila2("nro") = 2
                                            fila2("descripcion") = "58 a 64 kg"
                                            fila2("valor") = "58 a 64 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila2)
                                            Dim fila3 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila3("nro") = 3
                                            fila3("descripcion") = "64 a 70 kg"
                                            fila3("valor") = "64 a 70 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila3)
                                            Dim fila4 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila4("nro") = 4
                                            fila4("descripcion") = "70 a 76 kg"
                                            fila4("valor") = "70 a 76 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila4)
                                            Dim fila5 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila5("nro") = 5
                                            fila5("descripcion") = "76 a 82 kg"
                                            fila5("valor") = "76 a 82 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila5)
                                            Dim fila6 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila6("nro") = 6
                                            fila6("descripcion") = "82 a 999 kg"
                                            fila6("valor") = "82 a 999 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila6)

                                            DropDownList_peso.DataSource = Peso_Ds.Combo_Peso
                                            DropDownList_peso.DataTextField = "descripcion"
                                            DropDownList_peso.DataValueField = "nro"
                                            DropDownList_peso.DataBind()
                                        Case 6 '46 a 55
                                            Dim fila1 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila1("nro") = 1
                                            fila1("descripcion") = "0 a 58 kg"
                                            fila1("valor") = "0 a 58 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila1)
                                            Dim fila2 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila2("nro") = 2
                                            fila2("descripcion") = "58 a 64 kg"
                                            fila2("valor") = "58 a 64 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila2)
                                            Dim fila3 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila3("nro") = 3
                                            fila3("descripcion") = "64 a 70 kg"
                                            fila3("valor") = "64 a 70 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila3)
                                            Dim fila4 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila4("nro") = 4
                                            fila4("descripcion") = "70 a 76 kg"
                                            fila4("valor") = "70 a 76 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila4)
                                            Dim fila5 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila5("nro") = 5
                                            fila5("descripcion") = "76 a 82 kg"
                                            fila5("valor") = "76 a 82 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila5)
                                            Dim fila6 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila6("nro") = 6
                                            fila6("descripcion") = "82 a 999 kg"
                                            fila6("valor") = "82 a 999 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila6)

                                            DropDownList_peso.DataSource = Peso_Ds.Combo_Peso
                                            DropDownList_peso.DataTextField = "descripcion"
                                            DropDownList_peso.DataValueField = "nro"
                                            DropDownList_peso.DataBind()
                                        Case 7 '56 a 99 años
                                            Dim fila1 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila1("nro") = 1
                                            fila1("descripcion") = "0 a 58 kg"
                                            fila1("valor") = "0 a 58 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila1)
                                            Dim fila2 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila2("nro") = 2
                                            fila2("descripcion") = "58 a 64 kg"
                                            fila2("valor") = "58 a 64 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila2)
                                            Dim fila3 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila3("nro") = 3
                                            fila3("descripcion") = "64 a 70 kg"
                                            fila3("valor") = "64 a 70 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila3)
                                            Dim fila4 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila4("nro") = 4
                                            fila4("descripcion") = "70 a 76 kg"
                                            fila4("valor") = "70 a 76 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila4)
                                            Dim fila5 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila5("nro") = 5
                                            fila5("descripcion") = "76 a 82 kg"
                                            fila5("valor") = "76 a 82 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila5)
                                            Dim fila6 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila6("nro") = 6
                                            fila6("descripcion") = "82 a 999 kg"
                                            fila6("valor") = "82 a 999 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila6)

                                            DropDownList_peso.DataSource = Peso_Ds.Combo_Peso
                                            DropDownList_peso.DataTextField = "descripcion"
                                            DropDownList_peso.DataValueField = "nro"
                                            DropDownList_peso.DataBind()
                                    End Select
                                Case 12
                                    Select Case DropDownList_edad.SelectedValue
                                        Case 1 '12 a 13 años
                                            Dim fila1 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila1("nro") = 1
                                            fila1("descripcion") = "0 a 40 kg"
                                            fila1("valor") = "0 a 40 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila1)
                                            Dim fila2 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila2("nro") = 2
                                            fila2("descripcion") = "40 a 45 kg"
                                            fila2("valor") = "40 a 45 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila2)
                                            Dim fila3 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila3("nro") = 3
                                            fila3("descripcion") = "45 a 50 kg"
                                            fila3("valor") = "45 a 50 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila3)
                                            Dim fila4 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila4("nro") = 4
                                            fila4("descripcion") = "50 a 55 kg"
                                            fila4("valor") = "50 a 55 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila4)
                                            Dim fila5 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila5("nro") = 5
                                            fila5("descripcion") = "55 a 999 kg"
                                            fila5("valor") = "55 a 999 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila5)

                                            DropDownList_peso.DataSource = Peso_Ds.Combo_Peso
                                            DropDownList_peso.DataTextField = "descripcion"
                                            DropDownList_peso.DataValueField = "nro"
                                            DropDownList_peso.DataBind()
                                        Case 2 '14 a 15 años
                                            Dim fila1 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila1("nro") = 1
                                            fila1("descripcion") = "0 a 50 kg"
                                            fila1("valor") = "0 a 50 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila1)
                                            Dim fila2 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila2("nro") = 2
                                            fila2("descripcion") = "50 a 55 kg"
                                            fila2("valor") = "50 a 55 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila2)
                                            Dim fila3 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila3("nro") = 3
                                            fila3("descripcion") = "55 a 60 kg"
                                            fila3("valor") = "55 a 60 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila3)
                                            Dim fila4 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila4("nro") = 4
                                            fila4("descripcion") = "60 a 65 kg"
                                            fila4("valor") = "60 a 65 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila4)
                                            Dim fila5 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila5("nro") = 5
                                            fila5("descripcion") = "65 a 70 kg"
                                            fila5("valor") = "65 a 70 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila5)
                                            Dim fila6 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila6("nro") = 6
                                            fila6("descripcion") = "70 a 999 kg"
                                            fila6("valor") = "70 a 999 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila6)

                                            DropDownList_peso.DataSource = Peso_Ds.Combo_Peso
                                            DropDownList_peso.DataTextField = "descripcion"
                                            DropDownList_peso.DataValueField = "nro"
                                            DropDownList_peso.DataBind()
                                        Case 3 '16 a 17 años
                                            Dim fila1 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila1("nro") = 1
                                            fila1("descripcion") = "0 a 50 kg"
                                            fila1("valor") = "0 a 50 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila1)
                                            Dim fila2 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila2("nro") = 2
                                            fila2("descripcion") = "50 a 55 kg"
                                            fila2("valor") = "50 a 55 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila2)
                                            Dim fila3 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila3("nro") = 3
                                            fila3("descripcion") = "55 a 60 kg"
                                            fila3("valor") = "55 a 60 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila3)
                                            Dim fila4 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila4("nro") = 4
                                            fila4("descripcion") = "60 a 65 kg"
                                            fila4("valor") = "60 a 65 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila4)
                                            Dim fila5 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila5("nro") = 5
                                            fila5("descripcion") = "65 a 70 kg"
                                            fila5("valor") = "65 a 70 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila5)
                                            Dim fila6 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila6("nro") = 6
                                            fila6("descripcion") = "70 a 999 kg"
                                            fila6("valor") = "70 a 999 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila6)

                                            DropDownList_peso.DataSource = Peso_Ds.Combo_Peso
                                            DropDownList_peso.DataTextField = "descripcion"
                                            DropDownList_peso.DataValueField = "nro"
                                            DropDownList_peso.DataBind()
                                        Case 4 '18 a 35 años
                                            Dim fila1 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila1("nro") = 1
                                            fila1("descripcion") = "0 a 58 kg"
                                            fila1("valor") = "0 a 58 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila1)
                                            Dim fila2 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila2("nro") = 2
                                            fila2("descripcion") = "58 a 64 kg"
                                            fila2("valor") = "58 a 64 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila2)
                                            Dim fila3 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila3("nro") = 3
                                            fila3("descripcion") = "64 a 70 kg"
                                            fila3("valor") = "64 a 70 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila3)
                                            Dim fila4 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila4("nro") = 4
                                            fila4("descripcion") = "70 a 76 kg"
                                            fila4("valor") = "70 a 76 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila4)
                                            Dim fila5 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila5("nro") = 5
                                            fila5("descripcion") = "76 a 82 kg"
                                            fila5("valor") = "76 a 82 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila5)
                                            Dim fila6 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila6("nro") = 6
                                            fila6("descripcion") = "82 a 999 kg"
                                            fila6("valor") = "82 a 999 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila6)

                                            DropDownList_peso.DataSource = Peso_Ds.Combo_Peso
                                            DropDownList_peso.DataTextField = "descripcion"
                                            DropDownList_peso.DataValueField = "nro"
                                            DropDownList_peso.DataBind()

                                        Case 5 '36 a 45 años
                                            Dim fila1 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila1("nro") = 1
                                            fila1("descripcion") = "0 a 58 kg"
                                            fila1("valor") = "0 a 58 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila1)
                                            Dim fila2 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila2("nro") = 2
                                            fila2("descripcion") = "58 a 64 kg"
                                            fila2("valor") = "58 a 64 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila2)
                                            Dim fila3 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila3("nro") = 3
                                            fila3("descripcion") = "64 a 70 kg"
                                            fila3("valor") = "64 a 70 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila3)
                                            Dim fila4 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila4("nro") = 4
                                            fila4("descripcion") = "70 a 76 kg"
                                            fila4("valor") = "70 a 76 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila4)
                                            Dim fila5 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila5("nro") = 5
                                            fila5("descripcion") = "76 a 82 kg"
                                            fila5("valor") = "76 a 82 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila5)
                                            Dim fila6 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila6("nro") = 6
                                            fila6("descripcion") = "82 a 999 kg"
                                            fila6("valor") = "82 a 999 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila6)

                                            DropDownList_peso.DataSource = Peso_Ds.Combo_Peso
                                            DropDownList_peso.DataTextField = "descripcion"
                                            DropDownList_peso.DataValueField = "nro"
                                            DropDownList_peso.DataBind()
                                        Case 6 '46 a 55
                                            Dim fila1 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila1("nro") = 1
                                            fila1("descripcion") = "0 a 58 kg"
                                            fila1("valor") = "0 a 58 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila1)
                                            Dim fila2 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila2("nro") = 2
                                            fila2("descripcion") = "58 a 64 kg"
                                            fila2("valor") = "58 a 64 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila2)
                                            Dim fila3 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila3("nro") = 3
                                            fila3("descripcion") = "64 a 70 kg"
                                            fila3("valor") = "64 a 70 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila3)
                                            Dim fila4 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila4("nro") = 4
                                            fila4("descripcion") = "70 a 76 kg"
                                            fila4("valor") = "70 a 76 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila4)
                                            Dim fila5 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila5("nro") = 5
                                            fila5("descripcion") = "76 a 82 kg"
                                            fila5("valor") = "76 a 82 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila5)
                                            Dim fila6 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila6("nro") = 6
                                            fila6("descripcion") = "82 a 999 kg"
                                            fila6("valor") = "82 a 999 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila6)

                                            DropDownList_peso.DataSource = Peso_Ds.Combo_Peso
                                            DropDownList_peso.DataTextField = "descripcion"
                                            DropDownList_peso.DataValueField = "nro"
                                            DropDownList_peso.DataBind()
                                        Case 7 '56 a 99 años
                                            Dim fila1 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila1("nro") = 1
                                            fila1("descripcion") = "0 a 58 kg"
                                            fila1("valor") = "0 a 58 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila1)
                                            Dim fila2 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila2("nro") = 2
                                            fila2("descripcion") = "58 a 64 kg"
                                            fila2("valor") = "58 a 64 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila2)
                                            Dim fila3 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila3("nro") = 3
                                            fila3("descripcion") = "64 a 70 kg"
                                            fila3("valor") = "64 a 70 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila3)
                                            Dim fila4 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila4("nro") = 4
                                            fila4("descripcion") = "70 a 76 kg"
                                            fila4("valor") = "70 a 76 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila4)
                                            Dim fila5 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila5("nro") = 5
                                            fila5("descripcion") = "76 a 82 kg"
                                            fila5("valor") = "76 a 82 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila5)
                                            Dim fila6 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila6("nro") = 6
                                            fila6("descripcion") = "82 a 999 kg"
                                            fila6("valor") = "82 a 999 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila6)

                                            DropDownList_peso.DataSource = Peso_Ds.Combo_Peso
                                            DropDownList_peso.DataTextField = "descripcion"
                                            DropDownList_peso.DataValueField = "nro"
                                            DropDownList_peso.DataBind()
                                    End Select

                            End Select

                        Case "Mujer"
                            Select Case HF_graduacion_inicial.Value
                                Case 2 'esto es graduacion
                                    Select Case DropDownList_edad.SelectedValue
                                        Case 1 '12 a 13 años
                                            Dim fila1 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila1("nro") = 1
                                            fila1("descripcion") = "0 a 35 kg"
                                            fila1("valor") = "0 a 35 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila1)
                                            Dim fila2 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila2("nro") = 2
                                            fila2("descripcion") = "35 a 40 kg"
                                            fila2("valor") = "35 a 40 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila2)
                                            Dim fila3 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila3("nro") = 3
                                            fila3("descripcion") = "40 a 45 kg"
                                            fila3("valor") = "40 a 45 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila3)
                                            Dim fila4 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila4("nro") = 4
                                            fila4("descripcion") = "45 a 50 kg"
                                            fila4("valor") = "45 a 50 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila4)
                                            Dim fila5 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila5("nro") = 5
                                            fila5("descripcion") = "50 a 999 kg"
                                            fila5("valor") = "50 a 999 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila5)

                                            DropDownList_peso.DataSource = Peso_Ds.Combo_Peso
                                            DropDownList_peso.DataTextField = "descripcion"
                                            DropDownList_peso.DataValueField = "nro"
                                            DropDownList_peso.DataBind()
                                        Case 2 '14 a 15 años
                                            Dim fila1 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila1("nro") = 1
                                            fila1("descripcion") = "0 a 45 kg"
                                            fila1("valor") = "0 a 45 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila1)
                                            Dim fila2 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila2("nro") = 2
                                            fila2("descripcion") = "45 a 50 kg"
                                            fila2("valor") = "45 a 50 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila2)
                                            Dim fila3 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila3("nro") = 3
                                            fila3("descripcion") = "50 a 55 kg"
                                            fila3("valor") = "50 a 55 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila3)
                                            Dim fila4 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila4("nro") = 4
                                            fila4("descripcion") = "55 a 60 kg"
                                            fila4("valor") = "55 a 60 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila4)
                                            Dim fila5 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila5("nro") = 5
                                            fila5("descripcion") = "60 a 65 kg"
                                            fila5("valor") = "60 a 65 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila5)
                                            Dim fila6 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila6("nro") = 6
                                            fila6("descripcion") = "65 a 999 kg"
                                            fila6("valor") = "65 a 999 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila6)

                                            DropDownList_peso.DataSource = Peso_Ds.Combo_Peso
                                            DropDownList_peso.DataTextField = "descripcion"
                                            DropDownList_peso.DataValueField = "nro"
                                            DropDownList_peso.DataBind()
                                        Case 3 '16 a 17 años
                                            Dim fila1 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila1("nro") = 1
                                            fila1("descripcion") = "0 a 45 kg"
                                            fila1("valor") = "0 a 45 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila1)
                                            Dim fila2 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila2("nro") = 2
                                            fila2("descripcion") = "45 a 50 kg"
                                            fila2("valor") = "45 a 50 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila2)
                                            Dim fila3 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila3("nro") = 3
                                            fila3("descripcion") = "50 a 55 kg"
                                            fila3("valor") = "50 a 55 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila3)
                                            Dim fila4 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila4("nro") = 4
                                            fila4("descripcion") = "55 a 60 kg"
                                            fila4("valor") = "55 a 60 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila4)
                                            Dim fila5 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila5("nro") = 5
                                            fila5("descripcion") = "60 a 65 kg"
                                            fila5("valor") = "60 a 65 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila5)
                                            Dim fila6 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila6("nro") = 6
                                            fila6("descripcion") = "65 a 999 kg"
                                            fila6("valor") = "65 a 999 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila6)

                                            DropDownList_peso.DataSource = Peso_Ds.Combo_Peso
                                            DropDownList_peso.DataTextField = "descripcion"
                                            DropDownList_peso.DataValueField = "nro"
                                            DropDownList_peso.DataBind()
                                        Case 4 '18 a 35 años
                                            Dim fila1 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila1("nro") = 1
                                            fila1("descripcion") = "0 a 50 kg"
                                            fila1("valor") = "0 a 50 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila1)
                                            Dim fila2 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila2("nro") = 2
                                            fila2("descripcion") = "50 a 55 kg"
                                            fila2("valor") = "50 a 55 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila2)
                                            Dim fila3 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila3("nro") = 3
                                            fila3("descripcion") = "55 a 60 kg"
                                            fila3("valor") = "55 a 60 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila3)
                                            Dim fila4 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila4("nro") = 4
                                            fila4("descripcion") = "60 a 65 kg"
                                            fila4("valor") = "60 a 65 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila4)
                                            Dim fila5 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila5("nro") = 5
                                            fila5("descripcion") = "65 a 70 kg"
                                            fila5("valor") = "65 a 70 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila5)
                                            Dim fila6 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila6("nro") = 6
                                            fila6("descripcion") = "70 a 999 kg"
                                            fila6("valor") = "70 a 999 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila6)

                                            DropDownList_peso.DataSource = Peso_Ds.Combo_Peso
                                            DropDownList_peso.DataTextField = "descripcion"
                                            DropDownList_peso.DataValueField = "nro"
                                            DropDownList_peso.DataBind()

                                        Case 5 '36 a 45 años
                                            Dim fila1 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila1("nro") = 1
                                            fila1("descripcion") = "0 a 50 kg"
                                            fila1("valor") = "0 a 50 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila1)
                                            Dim fila2 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila2("nro") = 2
                                            fila2("descripcion") = "50 a 55 kg"
                                            fila2("valor") = "50 a 55 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila2)
                                            Dim fila3 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila3("nro") = 3
                                            fila3("descripcion") = "55 a 60 kg"
                                            fila3("valor") = "55 a 60 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila3)
                                            Dim fila4 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila4("nro") = 4
                                            fila4("descripcion") = "60 a 65 kg"
                                            fila4("valor") = "60 a 65 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila4)
                                            Dim fila5 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila5("nro") = 5
                                            fila5("descripcion") = "65 a 70 kg"
                                            fila5("valor") = "65 a 70 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila5)
                                            Dim fila6 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila6("nro") = 6
                                            fila6("descripcion") = "70 a 999 kg"
                                            fila6("valor") = "70 a 999 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila6)

                                            DropDownList_peso.DataSource = Peso_Ds.Combo_Peso
                                            DropDownList_peso.DataTextField = "descripcion"
                                            DropDownList_peso.DataValueField = "nro"
                                            DropDownList_peso.DataBind()
                                        Case 6 '46 a 55
                                            Dim fila1 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila1("nro") = 1
                                            fila1("descripcion") = "0 a 50 kg"
                                            fila1("valor") = "0 a 50 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila1)
                                            Dim fila2 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila2("nro") = 2
                                            fila2("descripcion") = "50 a 55 kg"
                                            fila2("valor") = "50 a 55 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila2)
                                            Dim fila3 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila3("nro") = 3
                                            fila3("descripcion") = "55 a 60 kg"
                                            fila3("valor") = "55 a 60 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila3)
                                            Dim fila4 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila4("nro") = 4
                                            fila4("descripcion") = "60 a 65 kg"
                                            fila4("valor") = "60 a 65 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila4)
                                            Dim fila5 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila5("nro") = 5
                                            fila5("descripcion") = "65 a 70 kg"
                                            fila5("valor") = "65 a 70 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila5)
                                            Dim fila6 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila6("nro") = 6
                                            fila6("descripcion") = "70 a 999 kg"
                                            fila6("valor") = "70 a 999 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila6)

                                            DropDownList_peso.DataSource = Peso_Ds.Combo_Peso
                                            DropDownList_peso.DataTextField = "descripcion"
                                            DropDownList_peso.DataValueField = "nro"
                                            DropDownList_peso.DataBind()
                                        Case 7 '56 a 99 años
                                            Dim fila1 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila1("nro") = 1
                                            fila1("descripcion") = "0 a 50 kg"
                                            fila1("valor") = "0 a 50 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila1)
                                            Dim fila2 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila2("nro") = 2
                                            fila2("descripcion") = "50 a 55 kg"
                                            fila2("valor") = "50 a 55 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila2)
                                            Dim fila3 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila3("nro") = 3
                                            fila3("descripcion") = "55 a 60 kg"
                                            fila3("valor") = "55 a 60 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila3)
                                            Dim fila4 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila4("nro") = 4
                                            fila4("descripcion") = "60 a 65 kg"
                                            fila4("valor") = "60 a 65 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila4)
                                            Dim fila5 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila5("nro") = 5
                                            fila5("descripcion") = "65 a 70 kg"
                                            fila5("valor") = "65 a 70 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila5)
                                            Dim fila6 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila6("nro") = 6
                                            fila6("descripcion") = "70 a 999 kg"
                                            fila6("valor") = "70 a 999 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila6)

                                            DropDownList_peso.DataSource = Peso_Ds.Combo_Peso
                                            DropDownList_peso.DataTextField = "descripcion"
                                            DropDownList_peso.DataValueField = "nro"
                                            DropDownList_peso.DataBind()
                                    End Select
                                Case 4
                                    Select Case DropDownList_edad.SelectedValue
                                        Case 1 '12 a 13 años
                                            Dim fila1 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila1("nro") = 1
                                            fila1("descripcion") = "0 a 35 kg"
                                            fila1("valor") = "0 a 35 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila1)
                                            Dim fila2 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila2("nro") = 2
                                            fila2("descripcion") = "35 a 40 kg"
                                            fila2("valor") = "35 a 40 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila2)
                                            Dim fila3 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila3("nro") = 3
                                            fila3("descripcion") = "40 a 45 kg"
                                            fila3("valor") = "40 a 45 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila3)
                                            Dim fila4 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila4("nro") = 4
                                            fila4("descripcion") = "45 a 50 kg"
                                            fila4("valor") = "45 a 50 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila4)
                                            Dim fila5 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila5("nro") = 5
                                            fila5("descripcion") = "50 a 999 kg"
                                            fila5("valor") = "50 a 999 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila5)

                                            DropDownList_peso.DataSource = Peso_Ds.Combo_Peso
                                            DropDownList_peso.DataTextField = "descripcion"
                                            DropDownList_peso.DataValueField = "nro"
                                            DropDownList_peso.DataBind()
                                        Case 2 '14 a 15 años
                                            Dim fila1 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila1("nro") = 1
                                            fila1("descripcion") = "0 a 45 kg"
                                            fila1("valor") = "0 a 45 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila1)
                                            Dim fila2 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila2("nro") = 2
                                            fila2("descripcion") = "45 a 50 kg"
                                            fila2("valor") = "45 a 50 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila2)
                                            Dim fila3 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila3("nro") = 3
                                            fila3("descripcion") = "50 a 55 kg"
                                            fila3("valor") = "50 a 55 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila3)
                                            Dim fila4 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila4("nro") = 4
                                            fila4("descripcion") = "55 a 60 kg"
                                            fila4("valor") = "55 a 60 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila4)
                                            Dim fila5 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila5("nro") = 5
                                            fila5("descripcion") = "60 a 65 kg"
                                            fila5("valor") = "60 a 65 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila5)
                                            Dim fila6 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila6("nro") = 6
                                            fila6("descripcion") = "65 a 999 kg"
                                            fila6("valor") = "65 a 999 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila6)

                                            DropDownList_peso.DataSource = Peso_Ds.Combo_Peso
                                            DropDownList_peso.DataTextField = "descripcion"
                                            DropDownList_peso.DataValueField = "nro"
                                            DropDownList_peso.DataBind()
                                        Case 3 '16 a 17 años
                                            Dim fila1 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila1("nro") = 1
                                            fila1("descripcion") = "0 a 45 kg"
                                            fila1("valor") = "0 a 45 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila1)
                                            Dim fila2 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila2("nro") = 2
                                            fila2("descripcion") = "45 a 50 kg"
                                            fila2("valor") = "45 a 50 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila2)
                                            Dim fila3 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila3("nro") = 3
                                            fila3("descripcion") = "50 a 55 kg"
                                            fila3("valor") = "50 a 55 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila3)
                                            Dim fila4 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila4("nro") = 4
                                            fila4("descripcion") = "55 a 60 kg"
                                            fila4("valor") = "55 a 60 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila4)
                                            Dim fila5 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila5("nro") = 5
                                            fila5("descripcion") = "60 a 65 kg"
                                            fila5("valor") = "60 a 65 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila5)
                                            Dim fila6 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila6("nro") = 6
                                            fila6("descripcion") = "65 a 999 kg"
                                            fila6("valor") = "65 a 999 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila6)

                                            DropDownList_peso.DataSource = Peso_Ds.Combo_Peso
                                            DropDownList_peso.DataTextField = "descripcion"
                                            DropDownList_peso.DataValueField = "nro"
                                            DropDownList_peso.DataBind()
                                        Case 4 '18 a 35 años
                                            Dim fila1 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila1("nro") = 1
                                            fila1("descripcion") = "0 a 50 kg"
                                            fila1("valor") = "0 a 50 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila1)
                                            Dim fila2 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila2("nro") = 2
                                            fila2("descripcion") = "50 a 55 kg"
                                            fila2("valor") = "50 a 55 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila2)
                                            Dim fila3 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila3("nro") = 3
                                            fila3("descripcion") = "55 a 60 kg"
                                            fila3("valor") = "55 a 60 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila3)
                                            Dim fila4 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila4("nro") = 4
                                            fila4("descripcion") = "60 a 65 kg"
                                            fila4("valor") = "60 a 65 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila4)
                                            Dim fila5 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila5("nro") = 5
                                            fila5("descripcion") = "65 a 70 kg"
                                            fila5("valor") = "65 a 70 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila5)
                                            Dim fila6 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila6("nro") = 6
                                            fila6("descripcion") = "70 a 999 kg"
                                            fila6("valor") = "70 a 999 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila6)

                                            DropDownList_peso.DataSource = Peso_Ds.Combo_Peso
                                            DropDownList_peso.DataTextField = "descripcion"
                                            DropDownList_peso.DataValueField = "nro"
                                            DropDownList_peso.DataBind()

                                        Case 5 '36 a 45 años
                                            Dim fila1 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila1("nro") = 1
                                            fila1("descripcion") = "0 a 50 kg"
                                            fila1("valor") = "0 a 50 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila1)
                                            Dim fila2 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila2("nro") = 2
                                            fila2("descripcion") = "50 a 55 kg"
                                            fila2("valor") = "50 a 55 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila2)
                                            Dim fila3 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila3("nro") = 3
                                            fila3("descripcion") = "55 a 60 kg"
                                            fila3("valor") = "55 a 60 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila3)
                                            Dim fila4 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila4("nro") = 4
                                            fila4("descripcion") = "60 a 65 kg"
                                            fila4("valor") = "60 a 65 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila4)
                                            Dim fila5 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila5("nro") = 5
                                            fila5("descripcion") = "65 a 70 kg"
                                            fila5("valor") = "65 a 70 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila5)
                                            Dim fila6 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila6("nro") = 6
                                            fila6("descripcion") = "70 a 999 kg"
                                            fila6("valor") = "70 a 999 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila6)

                                            DropDownList_peso.DataSource = Peso_Ds.Combo_Peso
                                            DropDownList_peso.DataTextField = "descripcion"
                                            DropDownList_peso.DataValueField = "nro"
                                            DropDownList_peso.DataBind()
                                        Case 6 '46 a 55
                                            Dim fila1 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila1("nro") = 1
                                            fila1("descripcion") = "0 a 50 kg"
                                            fila1("valor") = "0 a 50 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila1)
                                            Dim fila2 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila2("nro") = 2
                                            fila2("descripcion") = "50 a 55 kg"
                                            fila2("valor") = "50 a 55 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila2)
                                            Dim fila3 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila3("nro") = 3
                                            fila3("descripcion") = "55 a 60 kg"
                                            fila3("valor") = "55 a 60 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila3)
                                            Dim fila4 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila4("nro") = 4
                                            fila4("descripcion") = "60 a 65 kg"
                                            fila4("valor") = "60 a 65 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila4)
                                            Dim fila5 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila5("nro") = 5
                                            fila5("descripcion") = "65 a 70 kg"
                                            fila5("valor") = "65 a 70 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila5)
                                            Dim fila6 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila6("nro") = 6
                                            fila6("descripcion") = "70 a 999 kg"
                                            fila6("valor") = "70 a 999 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila6)

                                            DropDownList_peso.DataSource = Peso_Ds.Combo_Peso
                                            DropDownList_peso.DataTextField = "descripcion"
                                            DropDownList_peso.DataValueField = "nro"
                                            DropDownList_peso.DataBind()
                                        Case 7 '56 a 99 años
                                            Dim fila1 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila1("nro") = 1
                                            fila1("descripcion") = "0 a 50 kg"
                                            fila1("valor") = "0 a 50 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila1)
                                            Dim fila2 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila2("nro") = 2
                                            fila2("descripcion") = "50 a 55 kg"
                                            fila2("valor") = "50 a 55 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila2)
                                            Dim fila3 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila3("nro") = 3
                                            fila3("descripcion") = "55 a 60 kg"
                                            fila3("valor") = "55 a 60 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila3)
                                            Dim fila4 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila4("nro") = 4
                                            fila4("descripcion") = "60 a 65 kg"
                                            fila4("valor") = "60 a 65 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila4)
                                            Dim fila5 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila5("nro") = 5
                                            fila5("descripcion") = "65 a 70 kg"
                                            fila5("valor") = "65 a 70 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila5)
                                            Dim fila6 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila6("nro") = 6
                                            fila6("descripcion") = "70 a 999 kg"
                                            fila6("valor") = "70 a 999 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila6)

                                            DropDownList_peso.DataSource = Peso_Ds.Combo_Peso
                                            DropDownList_peso.DataTextField = "descripcion"
                                            DropDownList_peso.DataValueField = "nro"
                                            DropDownList_peso.DataBind()
                                    End Select
                                Case 8
                                    Select Case DropDownList_edad.SelectedValue
                                        Case 1 '12 a 13 años
                                            Dim fila1 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila1("nro") = 1
                                            fila1("descripcion") = "0 a 35 kg"
                                            fila1("valor") = "0 a 35 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila1)
                                            Dim fila2 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila2("nro") = 2
                                            fila2("descripcion") = "35 a 40 kg"
                                            fila2("valor") = "35 a 40 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila2)
                                            Dim fila3 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila3("nro") = 3
                                            fila3("descripcion") = "40 a 45 kg"
                                            fila3("valor") = "40 a 45 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila3)
                                            Dim fila4 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila4("nro") = 4
                                            fila4("descripcion") = "45 a 50 kg"
                                            fila4("valor") = "45 a 50 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila4)
                                            Dim fila5 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila5("nro") = 5
                                            fila5("descripcion") = "50 a 999 kg"
                                            fila5("valor") = "50 a 999 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila5)

                                            DropDownList_peso.DataSource = Peso_Ds.Combo_Peso
                                            DropDownList_peso.DataTextField = "descripcion"
                                            DropDownList_peso.DataValueField = "nro"
                                            DropDownList_peso.DataBind()
                                        Case 2 '14 a 15 años
                                            Dim fila1 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila1("nro") = 1
                                            fila1("descripcion") = "0 a 45 kg"
                                            fila1("valor") = "0 a 45 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila1)
                                            Dim fila2 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila2("nro") = 2
                                            fila2("descripcion") = "45 a 50 kg"
                                            fila2("valor") = "45 a 50 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila2)
                                            Dim fila3 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila3("nro") = 3
                                            fila3("descripcion") = "50 a 55 kg"
                                            fila3("valor") = "50 a 55 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila3)
                                            Dim fila4 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila4("nro") = 4
                                            fila4("descripcion") = "55 a 60 kg"
                                            fila4("valor") = "55 a 60 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila4)
                                            Dim fila5 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila5("nro") = 5
                                            fila5("descripcion") = "60 a 65 kg"
                                            fila5("valor") = "60 a 65 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila5)
                                            Dim fila6 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila6("nro") = 6
                                            fila6("descripcion") = "65 a 999 kg"
                                            fila6("valor") = "65 a 999 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila6)

                                            DropDownList_peso.DataSource = Peso_Ds.Combo_Peso
                                            DropDownList_peso.DataTextField = "descripcion"
                                            DropDownList_peso.DataValueField = "nro"
                                            DropDownList_peso.DataBind()
                                        Case 3 '16 a 17 años
                                            Dim fila1 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila1("nro") = 1
                                            fila1("descripcion") = "0 a 45 kg"
                                            fila1("valor") = "0 a 45 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila1)
                                            Dim fila2 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila2("nro") = 2
                                            fila2("descripcion") = "45 a 50 kg"
                                            fila2("valor") = "45 a 50 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila2)
                                            Dim fila3 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila3("nro") = 3
                                            fila3("descripcion") = "50 a 55 kg"
                                            fila3("valor") = "50 a 55 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila3)
                                            Dim fila4 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila4("nro") = 4
                                            fila4("descripcion") = "55 a 60 kg"
                                            fila4("valor") = "55 a 60 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila4)
                                            Dim fila5 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila5("nro") = 5
                                            fila5("descripcion") = "60 a 65 kg"
                                            fila5("valor") = "60 a 65 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila5)
                                            Dim fila6 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila6("nro") = 6
                                            fila6("descripcion") = "65 a 999 kg"
                                            fila6("valor") = "65 a 999 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila6)

                                            DropDownList_peso.DataSource = Peso_Ds.Combo_Peso
                                            DropDownList_peso.DataTextField = "descripcion"
                                            DropDownList_peso.DataValueField = "nro"
                                            DropDownList_peso.DataBind()
                                        Case 4 '18 a 35 años
                                            Dim fila1 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila1("nro") = 1
                                            fila1("descripcion") = "0 a 50 kg"
                                            fila1("valor") = "0 a 50 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila1)
                                            Dim fila2 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila2("nro") = 2
                                            fila2("descripcion") = "50 a 55 kg"
                                            fila2("valor") = "50 a 55 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila2)
                                            Dim fila3 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila3("nro") = 3
                                            fila3("descripcion") = "55 a 60 kg"
                                            fila3("valor") = "55 a 60 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila3)
                                            Dim fila4 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila4("nro") = 4
                                            fila4("descripcion") = "60 a 65 kg"
                                            fila4("valor") = "60 a 65 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila4)
                                            Dim fila5 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila5("nro") = 5
                                            fila5("descripcion") = "65 a 70 kg"
                                            fila5("valor") = "65 a 70 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila5)
                                            Dim fila6 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila6("nro") = 6
                                            fila6("descripcion") = "70 a 999 kg"
                                            fila6("valor") = "70 a 999 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila6)

                                            DropDownList_peso.DataSource = Peso_Ds.Combo_Peso
                                            DropDownList_peso.DataTextField = "descripcion"
                                            DropDownList_peso.DataValueField = "nro"
                                            DropDownList_peso.DataBind()

                                        Case 5 '36 a 45 años
                                            Dim fila1 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila1("nro") = 1
                                            fila1("descripcion") = "0 a 50 kg"
                                            fila1("valor") = "0 a 50 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila1)
                                            Dim fila2 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila2("nro") = 2
                                            fila2("descripcion") = "50 a 55 kg"
                                            fila2("valor") = "50 a 55 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila2)
                                            Dim fila3 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila3("nro") = 3
                                            fila3("descripcion") = "55 a 60 kg"
                                            fila3("valor") = "55 a 60 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila3)
                                            Dim fila4 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila4("nro") = 4
                                            fila4("descripcion") = "60 a 65 kg"
                                            fila4("valor") = "60 a 65 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila4)
                                            Dim fila5 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila5("nro") = 5
                                            fila5("descripcion") = "65 a 70 kg"
                                            fila5("valor") = "65 a 70 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila5)
                                            Dim fila6 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila6("nro") = 6
                                            fila6("descripcion") = "70 a 999 kg"
                                            fila6("valor") = "70 a 999 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila6)

                                            DropDownList_peso.DataSource = Peso_Ds.Combo_Peso
                                            DropDownList_peso.DataTextField = "descripcion"
                                            DropDownList_peso.DataValueField = "nro"
                                            DropDownList_peso.DataBind()
                                        Case 6 '46 a 55
                                            Dim fila1 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila1("nro") = 1
                                            fila1("descripcion") = "0 a 50 kg"
                                            fila1("valor") = "0 a 50 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila1)
                                            Dim fila2 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila2("nro") = 2
                                            fila2("descripcion") = "50 a 55 kg"
                                            fila2("valor") = "50 a 55 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila2)
                                            Dim fila3 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila3("nro") = 3
                                            fila3("descripcion") = "55 a 60 kg"
                                            fila3("valor") = "55 a 60 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila3)
                                            Dim fila4 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila4("nro") = 4
                                            fila4("descripcion") = "60 a 65 kg"
                                            fila4("valor") = "60 a 65 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila4)
                                            Dim fila5 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila5("nro") = 5
                                            fila5("descripcion") = "65 a 70 kg"
                                            fila5("valor") = "65 a 70 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila5)
                                            Dim fila6 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila6("nro") = 6
                                            fila6("descripcion") = "70 a 999 kg"
                                            fila6("valor") = "70 a 999 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila6)

                                            DropDownList_peso.DataSource = Peso_Ds.Combo_Peso
                                            DropDownList_peso.DataTextField = "descripcion"
                                            DropDownList_peso.DataValueField = "nro"
                                            DropDownList_peso.DataBind()
                                        Case 7 '56 a 99 años
                                            Dim fila1 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila1("nro") = 1
                                            fila1("descripcion") = "0 a 50 kg"
                                            fila1("valor") = "0 a 50 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila1)
                                            Dim fila2 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila2("nro") = 2
                                            fila2("descripcion") = "50 a 55 kg"
                                            fila2("valor") = "50 a 55 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila2)
                                            Dim fila3 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila3("nro") = 3
                                            fila3("descripcion") = "55 a 60 kg"
                                            fila3("valor") = "55 a 60 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila3)
                                            Dim fila4 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila4("nro") = 4
                                            fila4("descripcion") = "60 a 65 kg"
                                            fila4("valor") = "60 a 65 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila4)
                                            Dim fila5 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila5("nro") = 5
                                            fila5("descripcion") = "65 a 70 kg"
                                            fila5("valor") = "65 a 70 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila5)
                                            Dim fila6 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila6("nro") = 6
                                            fila6("descripcion") = "70 a 999 kg"
                                            fila6("valor") = "70 a 999 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila6)

                                            DropDownList_peso.DataSource = Peso_Ds.Combo_Peso
                                            DropDownList_peso.DataTextField = "descripcion"
                                            DropDownList_peso.DataValueField = "nro"
                                            DropDownList_peso.DataBind()
                                    End Select
                                Case 12
                                    Select Case DropDownList_edad.SelectedValue
                                        Case 1 '12 a 13 años
                                            Dim fila1 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila1("nro") = 1
                                            fila1("descripcion") = "0 a 35 kg"
                                            fila1("valor") = "0 a 35 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila1)
                                            Dim fila2 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila2("nro") = 2
                                            fila2("descripcion") = "35 a 40 kg"
                                            fila2("valor") = "35 a 40 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila2)
                                            Dim fila3 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila3("nro") = 3
                                            fila3("descripcion") = "40 a 45 kg"
                                            fila3("valor") = "40 a 45 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila3)
                                            Dim fila4 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila4("nro") = 4
                                            fila4("descripcion") = "45 a 50 kg"
                                            fila4("valor") = "45 a 50 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila4)
                                            Dim fila5 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila5("nro") = 5
                                            fila5("descripcion") = "50 a 999 kg"
                                            fila5("valor") = "50 a 999 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila5)

                                            DropDownList_peso.DataSource = Peso_Ds.Combo_Peso
                                            DropDownList_peso.DataTextField = "descripcion"
                                            DropDownList_peso.DataValueField = "nro"
                                            DropDownList_peso.DataBind()
                                        Case 2 '14 a 15 años
                                            Dim fila1 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila1("nro") = 1
                                            fila1("descripcion") = "0 a 45 kg"
                                            fila1("valor") = "0 a 45 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila1)
                                            Dim fila2 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila2("nro") = 2
                                            fila2("descripcion") = "45 a 50 kg"
                                            fila2("valor") = "45 a 50 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila2)
                                            Dim fila3 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila3("nro") = 3
                                            fila3("descripcion") = "50 a 55 kg"
                                            fila3("valor") = "50 a 55 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila3)
                                            Dim fila4 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila4("nro") = 4
                                            fila4("descripcion") = "55 a 60 kg"
                                            fila4("valor") = "55 a 60 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila4)
                                            Dim fila5 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila5("nro") = 5
                                            fila5("descripcion") = "60 a 65 kg"
                                            fila5("valor") = "60 a 65 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila5)
                                            Dim fila6 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila6("nro") = 6
                                            fila6("descripcion") = "65 a 999 kg"
                                            fila6("valor") = "65 a 999 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila6)

                                            DropDownList_peso.DataSource = Peso_Ds.Combo_Peso
                                            DropDownList_peso.DataTextField = "descripcion"
                                            DropDownList_peso.DataValueField = "nro"
                                            DropDownList_peso.DataBind()
                                        Case 3 '16 a 17 años
                                            Dim fila1 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila1("nro") = 1
                                            fila1("descripcion") = "0 a 45 kg"
                                            fila1("valor") = "0 a 45 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila1)
                                            Dim fila2 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila2("nro") = 2
                                            fila2("descripcion") = "45 a 50 kg"
                                            fila2("valor") = "45 a 50 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila2)
                                            Dim fila3 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila3("nro") = 3
                                            fila3("descripcion") = "50 a 55 kg"
                                            fila3("valor") = "50 a 55 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila3)
                                            Dim fila4 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila4("nro") = 4
                                            fila4("descripcion") = "55 a 60 kg"
                                            fila4("valor") = "55 a 60 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila4)
                                            Dim fila5 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila5("nro") = 5
                                            fila5("descripcion") = "60 a 65 kg"
                                            fila5("valor") = "60 a 65 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila5)
                                            Dim fila6 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila6("nro") = 6
                                            fila6("descripcion") = "65 a 999 kg"
                                            fila6("valor") = "65 a 999 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila6)

                                            DropDownList_peso.DataSource = Peso_Ds.Combo_Peso
                                            DropDownList_peso.DataTextField = "descripcion"
                                            DropDownList_peso.DataValueField = "nro"
                                            DropDownList_peso.DataBind()
                                        Case 4 '18 a 35 años
                                            Dim fila1 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila1("nro") = 1
                                            fila1("descripcion") = "0 a 50 kg"
                                            fila1("valor") = "0 a 50 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila1)
                                            Dim fila2 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila2("nro") = 2
                                            fila2("descripcion") = "50 a 55 kg"
                                            fila2("valor") = "50 a 55 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila2)
                                            Dim fila3 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila3("nro") = 3
                                            fila3("descripcion") = "55 a 60 kg"
                                            fila3("valor") = "55 a 60 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila3)
                                            Dim fila4 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila4("nro") = 4
                                            fila4("descripcion") = "60 a 65 kg"
                                            fila4("valor") = "60 a 65 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila4)
                                            Dim fila5 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila5("nro") = 5
                                            fila5("descripcion") = "65 a 70 kg"
                                            fila5("valor") = "65 a 70 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila5)
                                            Dim fila6 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila6("nro") = 6
                                            fila6("descripcion") = "70 a 999 kg"
                                            fila6("valor") = "70 a 999 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila6)

                                            DropDownList_peso.DataSource = Peso_Ds.Combo_Peso
                                            DropDownList_peso.DataTextField = "descripcion"
                                            DropDownList_peso.DataValueField = "nro"
                                            DropDownList_peso.DataBind()

                                        Case 5 '36 a 45 años
                                            Dim fila1 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila1("nro") = 1
                                            fila1("descripcion") = "0 a 50 kg"
                                            fila1("valor") = "0 a 50 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila1)
                                            Dim fila2 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila2("nro") = 2
                                            fila2("descripcion") = "50 a 55 kg"
                                            fila2("valor") = "50 a 55 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila2)
                                            Dim fila3 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila3("nro") = 3
                                            fila3("descripcion") = "55 a 60 kg"
                                            fila3("valor") = "55 a 60 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila3)
                                            Dim fila4 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila4("nro") = 4
                                            fila4("descripcion") = "60 a 65 kg"
                                            fila4("valor") = "60 a 65 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila4)
                                            Dim fila5 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila5("nro") = 5
                                            fila5("descripcion") = "65 a 70 kg"
                                            fila5("valor") = "65 a 70 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila5)
                                            Dim fila6 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila6("nro") = 6
                                            fila6("descripcion") = "70 a 999 kg"
                                            fila6("valor") = "70 a 999 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila6)

                                            DropDownList_peso.DataSource = Peso_Ds.Combo_Peso
                                            DropDownList_peso.DataTextField = "descripcion"
                                            DropDownList_peso.DataValueField = "nro"
                                            DropDownList_peso.DataBind()
                                        Case 6 '46 a 55
                                            Dim fila1 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila1("nro") = 1
                                            fila1("descripcion") = "0 a 50 kg"
                                            fila1("valor") = "0 a 50 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila1)
                                            Dim fila2 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila2("nro") = 2
                                            fila2("descripcion") = "50 a 55 kg"
                                            fila2("valor") = "50 a 55 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila2)
                                            Dim fila3 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila3("nro") = 3
                                            fila3("descripcion") = "55 a 60 kg"
                                            fila3("valor") = "55 a 60 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila3)
                                            Dim fila4 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila4("nro") = 4
                                            fila4("descripcion") = "60 a 65 kg"
                                            fila4("valor") = "60 a 65 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila4)
                                            Dim fila5 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila5("nro") = 5
                                            fila5("descripcion") = "65 a 70 kg"
                                            fila5("valor") = "65 a 70 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila5)
                                            Dim fila6 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila6("nro") = 6
                                            fila6("descripcion") = "70 a 999 kg"
                                            fila6("valor") = "70 a 999 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila6)

                                            DropDownList_peso.DataSource = Peso_Ds.Combo_Peso
                                            DropDownList_peso.DataTextField = "descripcion"
                                            DropDownList_peso.DataValueField = "nro"
                                            DropDownList_peso.DataBind()
                                        Case 7 '56 a 99 años
                                            Dim fila1 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila1("nro") = 1
                                            fila1("descripcion") = "0 a 50 kg"
                                            fila1("valor") = "0 a 50 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila1)
                                            Dim fila2 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila2("nro") = 2
                                            fila2("descripcion") = "50 a 55 kg"
                                            fila2("valor") = "50 a 55 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila2)
                                            Dim fila3 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila3("nro") = 3
                                            fila3("descripcion") = "55 a 60 kg"
                                            fila3("valor") = "55 a 60 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila3)
                                            Dim fila4 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila4("nro") = 4
                                            fila4("descripcion") = "60 a 65 kg"
                                            fila4("valor") = "60 a 65 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila4)
                                            Dim fila5 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila5("nro") = 5
                                            fila5("descripcion") = "65 a 70 kg"
                                            fila5("valor") = "65 a 70 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila5)
                                            Dim fila6 As DataRow = Peso_Ds.Combo_Peso.NewRow
                                            fila6("nro") = 6
                                            fila6("descripcion") = "70 a 999 kg"
                                            fila6("valor") = "70 a 999 kg"
                                            Peso_Ds.Combo_Peso.Rows.Add(fila6)

                                            DropDownList_peso.DataSource = Peso_Ds.Combo_Peso
                                            DropDownList_peso.DataTextField = "descripcion"
                                            DropDownList_peso.DataValueField = "nro"
                                            DropDownList_peso.DataBind()
                                    End Select
                            End Select
                    End Select
                        Case "Forma"
                    'no tiene peso
                    Peso_Ds.Combo_Peso.Rows.Clear()
                    DropDownList_peso.DataSource = Peso_Ds.Combo_Peso
                    DropDownList_peso.DataTextField = "descripcion"
                    DropDownList_peso.DataValueField = "nro"
                    DropDownList_peso.DataBind()

                        Case "Rotura de Poder"
                    'pendiente
                        Case "Rotura Especial"
                    'pendiente
                    End Select
        Catch ex As Exception

        End Try
    End Sub

    Private Sub lucha_hombremujer_edad()
        Dim fila1 As DataRow = Edad_Ds.Combo_Edad.NewRow
        fila1("nro") = 1
        fila1("descripcion") = "12 a 13 años"
        fila1("valor") = "12 a 13 años"
        Edad_Ds.Combo_Edad.Rows.Add(fila1)
        'aqui cargo edad.
        Dim fila2 As DataRow = Edad_Ds.Combo_Edad.NewRow
        fila2("nro") = 2
        fila2("descripcion") = "14 a 15 años"
        fila2("valor") = "14 a 15 años"
        Edad_Ds.Combo_Edad.Rows.Add(fila2)
        'aqui cargo edad.
        Dim fila3 As DataRow = Edad_Ds.Combo_Edad.NewRow
        fila3("nro") = 3
        fila3("descripcion") = "16 a 17 años"
        fila3("valor") = "16 a 17 años"
        Edad_Ds.Combo_Edad.Rows.Add(fila3)
        'aqui cargo edad.
        Dim fila4 As DataRow = Edad_Ds.Combo_Edad.NewRow
        fila4("nro") = 4
        fila4("descripcion") = "18 a 35 años"
        fila4("valor") = "18 a 35 años"
        Edad_Ds.Combo_Edad.Rows.Add(fila4)
        'aqui cargo edad.
        Dim fila5 As DataRow = Edad_Ds.Combo_Edad.NewRow
        fila5("nro") = 5
        fila5("descripcion") = "36 a 45 años"
        fila5("valor") = "36 a 45 años"
        Edad_Ds.Combo_Edad.Rows.Add(fila5)
        'aqui cargo edad.
        Dim fila6 As DataRow = Edad_Ds.Combo_Edad.NewRow
        fila6("nro") = 6
        fila6("descripcion") = "46 a 55 años"
        fila6("valor") = "46 a 55 años"
        Edad_Ds.Combo_Edad.Rows.Add(fila6)
        'aqui cargo edad.
        Dim fila7 As DataRow = Edad_Ds.Combo_Edad.NewRow
        fila7("nro") = 7
        fila7("descripcion") = "56 a 99 años"
        fila7("valor") = "56 a 99 años"
        Edad_Ds.Combo_Edad.Rows.Add(fila7)
        DropDownList_edad.DataSource = Edad_Ds.Combo_Edad
        DropDownList_edad.DataTextField = "descripcion"
        DropDownList_edad.DataValueField = "nro"
        DropDownList_edad.DataBind()
    End Sub

    'Private Sub sexo_cargar(ByVal modalidad As String)
    '    Select Case modalidad
    '        Case "Lucha"
    '            Dim fila1 As DataRow = Lucha_Ds.Combo_Sexo.NewRow
    '            fila1("nro") = 1
    '            fila1("descripcion") = "Ambos Sexos"
    '            fila1("valor") = "AMBOS SEXOS"
    '            Lucha_Ds.Combo_Sexo.Rows.Add(fila1)

    '            Dim fila2 As DataRow = Lucha_Ds.Combo_Sexo.NewRow
    '            fila2("nro") = 2
    '            fila2("descripcion") = "Hombre"
    '            fila2("valor") = "Hombre"
    '            Lucha_Ds.Combo_Sexo.Rows.Add(fila2)

    '            Dim fila3 As DataRow = Lucha_Ds.Combo_Sexo.NewRow
    '            fila3("nro") = 3
    '            fila3("descripcion") = "Mujer"
    '            fila3("valor") = "Mujer"
    '            Lucha_Ds.Combo_Sexo.Rows.Add(fila3)

    '            DropDownList_sexo.DataSource = Lucha_Ds.Combo_Sexo
    '            DropDownList_sexo.DataTextField = "descripcion"
    '            DropDownList_sexo.DataValueField = "valor"
    '            DropDownList_sexo.DataBind()
    '        Case "Forma"
    '            Dim fila1 As DataRow = Lucha_Ds.Combo_Sexo.NewRow
    '            fila1("nro") = 1
    '            fila1("descripcion") = "Ambos Sexos"
    '            fila1("valor") = "AMBOS SEXOS"
    '            Lucha_Ds.Combo_Sexo.Rows.Add(fila1)

    '            Dim fila2 As DataRow = Lucha_Ds.Combo_Sexo.NewRow
    '            fila2("nro") = 2
    '            fila2("descripcion") = "Hombre"
    '            fila2("valor") = "Hombre"
    '            Lucha_Ds.Combo_Sexo.Rows.Add(fila2)

    '            Dim fila3 As DataRow = Lucha_Ds.Combo_Sexo.NewRow
    '            fila3("nro") = 3
    '            fila3("descripcion") = "Mujer"
    '            fila3("valor") = "Mujer"
    '            Lucha_Ds.Combo_Sexo.Rows.Add(fila3)

    '            DropDownList_sexo.DataSource = Lucha_Ds.Combo_Sexo
    '            DropDownList_sexo.DataTextField = "descripcion"
    '            DropDownList_sexo.DataValueField = "valor"
    '            DropDownList_sexo.DataBind()
    '    End Select





    'End Sub

    

    Private Sub DropDownList_edad_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownList_edad.SelectedIndexChanged
        carga_peso()
    End Sub

    Private Sub BOTON_GUARDAR_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles BOTON_GUARDAR.ServerClick

        '1) tengo que recuperar categoria_id segun lo que seleccione en los combos
        'en base a lo que seleccione en los combos, voy a buscar en la bd el id de la categoria.
        Dim categoria_sexo As String = HF_categoria_sexo.Value
        Dim categoria_tipo As String = HF_categoria_tipo.Value
        Dim categoria_gradinicial As String = HF_graduacion_inicial.Value
        Dim categoria_gradfinal As String = HF_graduacion_final.Value
        Dim categoria_edadinicial As String = ""
        Dim categoria_edadfinal As String = ""
        Dim categoria_peso_inicial As String = "0"
        Dim categoria_peso_Final As String = "0"
        Dim inscripcion_peso As Decimal = 0

        recuperar_parametros(categoria_sexo, categoria_tipo, categoria_gradinicial, categoria_gradfinal, categoria_edadinicial, categoria_edadfinal, categoria_peso_inicial, categoria_peso_Final)


        Dim ds_categoria As DataSet = DAcategoria.Categoria_buscar(categoria_sexo, categoria_tipo, categoria_gradinicial, categoria_gradfinal, categoria_edadinicial, categoria_edadfinal, categoria_peso_inicial, categoria_peso_Final)

        If ds_categoria.Tables(0).Rows.Count <> 0 Then
            'existe
            Dim categoria_id As Integer = ds_categoria.Tables(0).Rows(0).Item("categoria_id")
            'me fijo si hay inscriptos en la categoria a la cual voy a mover.
            Dim ds_consulta As DataSet = DAinscripciones.Inscripciones_categoria_consultar(HF_evento_id.Value, categoria_id)
            If ds_consulta.Tables(0).Rows.Count <> 0 Then
                DAinscripciones.Inscripcion_modificar(HF_inscripcion_id.Value, inscripcion_peso, HF_categoria_id.Value, categoria_id)
                'volver a evento.
                Session("evento_id") = HF_evento_id.Value
                Response.Redirect("Torneo.aspx")
            Else
                'aqui modal avisando que no hay inscriptos en la categoria a mover.
                div_Modal_msj_error.Visible = True
                Modal_error_inscripto.Show()

            End If



        End If

    End Sub


    Private Sub recuperar_parametros(ByRef categoria_sexo As String, ByRef categoria_tipo As String, ByRef categoria_gradinicial As String, ByRef categoria_gradfinal As String, ByRef categoria_edadinicial As String,
                                       ByRef categoria_edadfinal As String, ByRef categoria_peso_inicial As String, ByRef categoria_peso_Final As String)

        Select Case categoria_tipo
            Case "Lucha"
                Select Case categoria_sexo
                    Case "AMBOS SEXOS"
                        Select Case categoria_gradinicial
                            Case 2
                                Select Case DropDownList_edad.SelectedValue
                                    Case 1 ' 0 a 5 años
                                        categoria_edadinicial = 0
                                        categoria_edadfinal = 5
                                        Select Case DropDownList_peso.SelectedValue
                                            Case 1 '0 a 15 kg
                                                categoria_peso_inicial = 0
                                                categoria_peso_Final = 15
                                            Case 2 '15 a 20 kg
                                                categoria_peso_inicial = 15
                                                categoria_peso_Final = 20
                                            Case 3 '20 a 25 kg
                                                categoria_peso_inicial = 20
                                                categoria_peso_Final = 25
                                            Case 4 '25 a 30 kg
                                                categoria_peso_inicial = 25
                                                categoria_peso_Final = 30
                                            Case 5 '30 a 35 kg
                                                categoria_peso_inicial = 30
                                                categoria_peso_Final = 35
                                            Case 6 '35 a 40 kg
                                                categoria_peso_inicial = 35
                                                categoria_peso_Final = 40
                                            Case 7 '40 a 45 kg
                                                categoria_peso_inicial = 40
                                                categoria_peso_Final = 45
                                            Case 8 '45 a 50 kg
                                                categoria_peso_inicial = 45
                                                categoria_peso_Final = 50
                                            Case 9 '50 a 55 kg
                                                categoria_peso_inicial = 50
                                                categoria_peso_Final = 55
                                            Case 10 ' 55 a 60 kg
                                                categoria_peso_inicial = 55
                                                categoria_peso_Final = 60
                                            Case 11 '60 a 65 kg
                                                categoria_peso_inicial = 60
                                                categoria_peso_Final = 65
                                            Case 12 '65 a 70 kg
                                                categoria_peso_inicial = 65
                                                categoria_peso_Final = 70
                                        End Select
                                    Case 2 '6 a 7 años
                                        categoria_edadinicial = 6
                                        categoria_edadfinal = 7
                                        Select Case DropDownList_peso.SelectedValue
                                            Case 1 '0 a 15 kg
                                                categoria_peso_inicial = 0
                                                categoria_peso_Final = 15
                                            Case 2 '15 a 20 kg
                                                categoria_peso_inicial = 15
                                                categoria_peso_Final = 20
                                            Case 3 '20 a 25 kg
                                                categoria_peso_inicial = 20
                                                categoria_peso_Final = 25
                                            Case 4 '25 a 30 kg
                                                categoria_peso_inicial = 25
                                                categoria_peso_Final = 30
                                            Case 5 '30 a 35 kg
                                                categoria_peso_inicial = 30
                                                categoria_peso_Final = 35
                                            Case 6 '35 a 40 kg
                                                categoria_peso_inicial = 35
                                                categoria_peso_Final = 40
                                            Case 7 '40 a 45 kg
                                                categoria_peso_inicial = 40
                                                categoria_peso_Final = 45
                                            Case 8 '45 a 50 kg
                                                categoria_peso_inicial = 45
                                                categoria_peso_Final = 50
                                            Case 9 '50 a 55 kg
                                                categoria_peso_inicial = 50
                                                categoria_peso_Final = 55
                                            Case 10 ' 55 a 60 kg
                                                categoria_peso_inicial = 55
                                                categoria_peso_Final = 60
                                            Case 11 '60 a 65 kg
                                                categoria_peso_inicial = 60
                                                categoria_peso_Final = 65
                                            Case 12 '65 a 70 kg
                                                categoria_peso_inicial = 65
                                                categoria_peso_Final = 70
                                            Case 13 '70 a 75 kg
                                                categoria_peso_inicial = 70
                                                categoria_peso_Final = 75
                                            Case 14 '75 a 80 kg
                                                categoria_peso_inicial = 75
                                                categoria_peso_Final = 80
                                        End Select
                                    Case 3 '8 a 9 años
                                        categoria_edadinicial = 8
                                        categoria_edadfinal = 9
                                        Select Case DropDownList_peso.SelectedValue
                                            Case 1 '0 a 15 kg
                                                categoria_peso_inicial = 0
                                                categoria_peso_Final = 15
                                            Case 2 '15 a 20 kg
                                                categoria_peso_inicial = 15
                                                categoria_peso_Final = 20
                                            Case 3 '20 a 25 kg
                                                categoria_peso_inicial = 20
                                                categoria_peso_Final = 25
                                            Case 4 '25 a 30 kg
                                                categoria_peso_inicial = 25
                                                categoria_peso_Final = 30
                                            Case 5 '30 a 35 kg
                                                categoria_peso_inicial = 30
                                                categoria_peso_Final = 35
                                            Case 6 '35 a 40 kg
                                                categoria_peso_inicial = 35
                                                categoria_peso_Final = 40
                                            Case 7 '40 a 45 kg
                                                categoria_peso_inicial = 40
                                                categoria_peso_Final = 45
                                            Case 8 '45 a 50 kg
                                                categoria_peso_inicial = 45
                                                categoria_peso_Final = 50
                                            Case 9 '50 a 55 kg
                                                categoria_peso_inicial = 50
                                                categoria_peso_Final = 55
                                            Case 10 ' 55 a 60 kg
                                                categoria_peso_inicial = 55
                                                categoria_peso_Final = 60
                                            Case 11 '60 a 65 kg
                                                categoria_peso_inicial = 60
                                                categoria_peso_Final = 65
                                            Case 12 '65 a 70 kg
                                                categoria_peso_inicial = 65
                                                categoria_peso_Final = 70
                                            Case 13 '70 a 75 kg
                                                categoria_peso_inicial = 70
                                                categoria_peso_Final = 75
                                            Case 14 '75 a 80 kg
                                                categoria_peso_inicial = 75
                                                categoria_peso_Final = 80
                                            Case 15 '80 a 85 kg
                                                categoria_peso_inicial = 80
                                                categoria_peso_Final = 85
                                            Case 16 '85 a 90 kg
                                                categoria_peso_inicial = 85
                                                categoria_peso_Final = 90
                                        End Select
                                    Case 4 '10 a 11 años
                                        categoria_edadinicial = 10
                                        categoria_edadfinal = 11
                                        Select Case DropDownList_peso.SelectedValue
                                            Case 1 '0 a 15 kg
                                                categoria_peso_inicial = 0
                                                categoria_peso_Final = 15
                                            Case 2 '15 a 20 kg
                                                categoria_peso_inicial = 15
                                                categoria_peso_Final = 20
                                            Case 3 '20 a 25 kg
                                                categoria_peso_inicial = 20
                                                categoria_peso_Final = 25
                                            Case 4 '25 a 30 kg
                                                categoria_peso_inicial = 25
                                                categoria_peso_Final = 30
                                            Case 5 '30 a 35 kg
                                                categoria_peso_inicial = 30
                                                categoria_peso_Final = 35
                                            Case 6 '35 a 40 kg
                                                categoria_peso_inicial = 35
                                                categoria_peso_Final = 40
                                            Case 7 '40 a 45 kg
                                                categoria_peso_inicial = 40
                                                categoria_peso_Final = 45
                                            Case 8 '45 a 50 kg
                                                categoria_peso_inicial = 45
                                                categoria_peso_Final = 50
                                            Case 9 '50 a 55 kg
                                                categoria_peso_inicial = 50
                                                categoria_peso_Final = 55
                                            Case 10 ' 55 a 60 kg
                                                categoria_peso_inicial = 55
                                                categoria_peso_Final = 60
                                            Case 11 '60 a 65 kg
                                                categoria_peso_inicial = 60
                                                categoria_peso_Final = 65
                                            Case 12 '65 a 70 kg
                                                categoria_peso_inicial = 65
                                                categoria_peso_Final = 70
                                            Case 13 '70 a 75 kg
                                                categoria_peso_inicial = 70
                                                categoria_peso_Final = 75
                                            Case 14 '75 a 80 kg
                                                categoria_peso_inicial = 75
                                                categoria_peso_Final = 80
                                            Case 15 '80 a 85 kg
                                                categoria_peso_inicial = 80
                                                categoria_peso_Final = 85
                                            Case 16 '85 a 90 kg
                                                categoria_peso_inicial = 85
                                                categoria_peso_Final = 90
                                            Case 17 '90 a 95 kg
                                                categoria_peso_inicial = 90
                                                categoria_peso_Final = 95
                                            Case 18 '95 a 100 kg
                                                categoria_peso_inicial = 95
                                                categoria_peso_Final = 100
                                        End Select
                                End Select
                            Case 4
                                Select Case DropDownList_edad.SelectedValue
                                    Case 1 ' 0 a 5 años
                                        categoria_edadinicial = 0
                                        categoria_edadfinal = 5
                                        Select Case DropDownList_peso.SelectedValue
                                            Case 1 '0 a 15 kg
                                                categoria_peso_inicial = 0
                                                categoria_peso_Final = 15
                                            Case 2 '15 a 20 kg
                                                categoria_peso_inicial = 15
                                                categoria_peso_Final = 20
                                            Case 3 '20 a 25 kg
                                                categoria_peso_inicial = 20
                                                categoria_peso_Final = 25
                                            Case 4 '25 a 30 kg
                                                categoria_peso_inicial = 25
                                                categoria_peso_Final = 30
                                            Case 5 '30 a 35 kg
                                                categoria_peso_inicial = 30
                                                categoria_peso_Final = 35
                                            Case 6 '35 a 40 kg
                                                categoria_peso_inicial = 35
                                                categoria_peso_Final = 40
                                            Case 7 '40 a 45 kg
                                                categoria_peso_inicial = 40
                                                categoria_peso_Final = 45
                                            Case 8 '45 a 50 kg
                                                categoria_peso_inicial = 45
                                                categoria_peso_Final = 50
                                            Case 9 '50 a 55 kg
                                                categoria_peso_inicial = 50
                                                categoria_peso_Final = 55
                                            Case 10 ' 55 a 60 kg
                                                categoria_peso_inicial = 55
                                                categoria_peso_Final = 60
                                            Case 11 '60 a 65 kg
                                                categoria_peso_inicial = 60
                                                categoria_peso_Final = 65
                                            Case 12 '65 a 70 kg
                                                categoria_peso_inicial = 65
                                                categoria_peso_Final = 70
                                        End Select
                                    Case 2 '6 a 7 años
                                        categoria_edadinicial = 6
                                        categoria_edadfinal = 7
                                        Select Case DropDownList_peso.SelectedValue
                                            Case 1 '0 a 15 kg
                                                categoria_peso_inicial = 0
                                                categoria_peso_Final = 15
                                            Case 2 '15 a 20 kg
                                                categoria_peso_inicial = 15
                                                categoria_peso_Final = 20
                                            Case 3 '20 a 25 kg
                                                categoria_peso_inicial = 20
                                                categoria_peso_Final = 25
                                            Case 4 '25 a 30 kg
                                                categoria_peso_inicial = 25
                                                categoria_peso_Final = 30
                                            Case 5 '30 a 35 kg
                                                categoria_peso_inicial = 30
                                                categoria_peso_Final = 35
                                            Case 6 '35 a 40 kg
                                                categoria_peso_inicial = 35
                                                categoria_peso_Final = 40
                                            Case 7 '40 a 45 kg
                                                categoria_peso_inicial = 40
                                                categoria_peso_Final = 45
                                            Case 8 '45 a 50 kg
                                                categoria_peso_inicial = 45
                                                categoria_peso_Final = 50
                                            Case 9 '50 a 55 kg
                                                categoria_peso_inicial = 50
                                                categoria_peso_Final = 55
                                            Case 10 ' 55 a 60 kg
                                                categoria_peso_inicial = 55
                                                categoria_peso_Final = 60
                                            Case 11 '60 a 65 kg
                                                categoria_peso_inicial = 60
                                                categoria_peso_Final = 65
                                            Case 12 '65 a 70 kg
                                                categoria_peso_inicial = 65
                                                categoria_peso_Final = 70
                                            Case 13 '70 a 75 kg
                                                categoria_peso_inicial = 70
                                                categoria_peso_Final = 75
                                            Case 14 '75 a 80 kg
                                                categoria_peso_inicial = 75
                                                categoria_peso_Final = 80
                                        End Select
                                    Case 3 '8 a 9 años
                                        categoria_edadinicial = 8
                                        categoria_edadfinal = 9
                                        Select Case DropDownList_peso.SelectedValue
                                            Case 1 '0 a 15 kg
                                                categoria_peso_inicial = 0
                                                categoria_peso_Final = 15
                                            Case 2 '15 a 20 kg
                                                categoria_peso_inicial = 15
                                                categoria_peso_Final = 20
                                            Case 3 '20 a 25 kg
                                                categoria_peso_inicial = 20
                                                categoria_peso_Final = 25
                                            Case 4 '25 a 30 kg
                                                categoria_peso_inicial = 25
                                                categoria_peso_Final = 30
                                            Case 5 '30 a 35 kg
                                                categoria_peso_inicial = 30
                                                categoria_peso_Final = 35
                                            Case 6 '35 a 40 kg
                                                categoria_peso_inicial = 35
                                                categoria_peso_Final = 40
                                            Case 7 '40 a 45 kg
                                                categoria_peso_inicial = 40
                                                categoria_peso_Final = 45
                                            Case 8 '45 a 50 kg
                                                categoria_peso_inicial = 45
                                                categoria_peso_Final = 50
                                            Case 9 '50 a 55 kg
                                                categoria_peso_inicial = 50
                                                categoria_peso_Final = 55
                                            Case 10 ' 55 a 60 kg
                                                categoria_peso_inicial = 55
                                                categoria_peso_Final = 60
                                            Case 11 '60 a 65 kg
                                                categoria_peso_inicial = 60
                                                categoria_peso_Final = 65
                                            Case 12 '65 a 70 kg
                                                categoria_peso_inicial = 65
                                                categoria_peso_Final = 70
                                            Case 13 '70 a 75 kg
                                                categoria_peso_inicial = 70
                                                categoria_peso_Final = 75
                                            Case 14 '75 a 80 kg
                                                categoria_peso_inicial = 75
                                                categoria_peso_Final = 80
                                            Case 15 '80 a 85 kg
                                                categoria_peso_inicial = 80
                                                categoria_peso_Final = 85
                                            Case 16 '85 a 90 kg
                                                categoria_peso_inicial = 85
                                                categoria_peso_Final = 90
                                        End Select
                                    Case 4 '10 a 11 años
                                        categoria_edadinicial = 10
                                        categoria_edadfinal = 11
                                        Select Case DropDownList_peso.SelectedValue
                                            Case 1 '0 a 15 kg
                                                categoria_peso_inicial = 0
                                                categoria_peso_Final = 15
                                            Case 2 '15 a 20 kg
                                                categoria_peso_inicial = 15
                                                categoria_peso_Final = 20
                                            Case 3 '20 a 25 kg
                                                categoria_peso_inicial = 20
                                                categoria_peso_Final = 25
                                            Case 4 '25 a 30 kg
                                                categoria_peso_inicial = 25
                                                categoria_peso_Final = 30
                                            Case 5 '30 a 35 kg
                                                categoria_peso_inicial = 30
                                                categoria_peso_Final = 35
                                            Case 6 '35 a 40 kg
                                                categoria_peso_inicial = 35
                                                categoria_peso_Final = 40
                                            Case 7 '40 a 45 kg
                                                categoria_peso_inicial = 40
                                                categoria_peso_Final = 45
                                            Case 8 '45 a 50 kg
                                                categoria_peso_inicial = 45
                                                categoria_peso_Final = 50
                                            Case 9 '50 a 55 kg
                                                categoria_peso_inicial = 50
                                                categoria_peso_Final = 55
                                            Case 10 ' 55 a 60 kg
                                                categoria_peso_inicial = 55
                                                categoria_peso_Final = 60
                                            Case 11 '60 a 65 kg
                                                categoria_peso_inicial = 60
                                                categoria_peso_Final = 65
                                            Case 12 '65 a 70 kg
                                                categoria_peso_inicial = 65
                                                categoria_peso_Final = 70
                                            Case 13 '70 a 75 kg
                                                categoria_peso_inicial = 70
                                                categoria_peso_Final = 75
                                            Case 14 '75 a 80 kg
                                                categoria_peso_inicial = 75
                                                categoria_peso_Final = 80
                                            Case 15 '80 a 85 kg
                                                categoria_peso_inicial = 80
                                                categoria_peso_Final = 85
                                            Case 16 '85 a 90 kg
                                                categoria_peso_inicial = 85
                                                categoria_peso_Final = 90
                                            Case 17 '90 a 95 kg
                                                categoria_peso_inicial = 90
                                                categoria_peso_Final = 95
                                            Case 18 '95 a 100 kg
                                                categoria_peso_inicial = 95
                                                categoria_peso_Final = 100
                                        End Select
                                End Select
                            Case 8
                                Select Case DropDownList_edad.SelectedValue
                                    Case 1 ' 0 a 5 años
                                        categoria_edadinicial = 0
                                        categoria_edadfinal = 5
                                        Select Case DropDownList_peso.SelectedValue
                                            Case 1 '0 a 15 kg
                                                categoria_peso_inicial = 0
                                                categoria_peso_Final = 15
                                            Case 2 '15 a 20 kg
                                                categoria_peso_inicial = 15
                                                categoria_peso_Final = 20
                                            Case 3 '20 a 25 kg
                                                categoria_peso_inicial = 20
                                                categoria_peso_Final = 25
                                            Case 4 '25 a 30 kg
                                                categoria_peso_inicial = 25
                                                categoria_peso_Final = 30
                                            Case 5 '30 a 35 kg
                                                categoria_peso_inicial = 30
                                                categoria_peso_Final = 35
                                            Case 6 '35 a 40 kg
                                                categoria_peso_inicial = 35
                                                categoria_peso_Final = 40
                                            Case 7 '40 a 45 kg
                                                categoria_peso_inicial = 40
                                                categoria_peso_Final = 45
                                            Case 8 '45 a 50 kg
                                                categoria_peso_inicial = 45
                                                categoria_peso_Final = 50
                                            Case 9 '50 a 55 kg
                                                categoria_peso_inicial = 50
                                                categoria_peso_Final = 55
                                            Case 10 ' 55 a 60 kg
                                                categoria_peso_inicial = 55
                                                categoria_peso_Final = 60
                                            Case 11 '60 a 65 kg
                                                categoria_peso_inicial = 60
                                                categoria_peso_Final = 65
                                            Case 12 '65 a 70 kg
                                                categoria_peso_inicial = 65
                                                categoria_peso_Final = 70
                                        End Select
                                    Case 2 '6 a 7 años
                                        categoria_edadinicial = 6
                                        categoria_edadfinal = 7
                                        Select Case DropDownList_peso.SelectedValue
                                            Case 1 '0 a 15 kg
                                                categoria_peso_inicial = 0
                                                categoria_peso_Final = 15
                                            Case 2 '15 a 20 kg
                                                categoria_peso_inicial = 15
                                                categoria_peso_Final = 20
                                            Case 3 '20 a 25 kg
                                                categoria_peso_inicial = 20
                                                categoria_peso_Final = 25
                                            Case 4 '25 a 30 kg
                                                categoria_peso_inicial = 25
                                                categoria_peso_Final = 30
                                            Case 5 '30 a 35 kg
                                                categoria_peso_inicial = 30
                                                categoria_peso_Final = 35
                                            Case 6 '35 a 40 kg
                                                categoria_peso_inicial = 35
                                                categoria_peso_Final = 40
                                            Case 7 '40 a 45 kg
                                                categoria_peso_inicial = 40
                                                categoria_peso_Final = 45
                                            Case 8 '45 a 50 kg
                                                categoria_peso_inicial = 45
                                                categoria_peso_Final = 50
                                            Case 9 '50 a 55 kg
                                                categoria_peso_inicial = 50
                                                categoria_peso_Final = 55
                                            Case 10 ' 55 a 60 kg
                                                categoria_peso_inicial = 55
                                                categoria_peso_Final = 60
                                            Case 11 '60 a 65 kg
                                                categoria_peso_inicial = 60
                                                categoria_peso_Final = 65
                                            Case 12 '65 a 70 kg
                                                categoria_peso_inicial = 65
                                                categoria_peso_Final = 70
                                            Case 13 '70 a 75 kg
                                                categoria_peso_inicial = 70
                                                categoria_peso_Final = 75
                                            Case 14 '75 a 80 kg
                                                categoria_peso_inicial = 75
                                                categoria_peso_Final = 80
                                        End Select
                                    Case 3 '8 a 9 años
                                        categoria_edadinicial = 8
                                        categoria_edadfinal = 9
                                        Select Case DropDownList_peso.SelectedValue
                                            Case 1 '0 a 15 kg
                                                categoria_peso_inicial = 0
                                                categoria_peso_Final = 15
                                            Case 2 '15 a 20 kg
                                                categoria_peso_inicial = 15
                                                categoria_peso_Final = 20
                                            Case 3 '20 a 25 kg
                                                categoria_peso_inicial = 20
                                                categoria_peso_Final = 25
                                            Case 4 '25 a 30 kg
                                                categoria_peso_inicial = 25
                                                categoria_peso_Final = 30
                                            Case 5 '30 a 35 kg
                                                categoria_peso_inicial = 30
                                                categoria_peso_Final = 35
                                            Case 6 '35 a 40 kg
                                                categoria_peso_inicial = 35
                                                categoria_peso_Final = 40
                                            Case 7 '40 a 45 kg
                                                categoria_peso_inicial = 40
                                                categoria_peso_Final = 45
                                            Case 8 '45 a 50 kg
                                                categoria_peso_inicial = 45
                                                categoria_peso_Final = 50
                                            Case 9 '50 a 55 kg
                                                categoria_peso_inicial = 50
                                                categoria_peso_Final = 55
                                            Case 10 ' 55 a 60 kg
                                                categoria_peso_inicial = 55
                                                categoria_peso_Final = 60
                                            Case 11 '60 a 65 kg
                                                categoria_peso_inicial = 60
                                                categoria_peso_Final = 65
                                            Case 12 '65 a 70 kg
                                                categoria_peso_inicial = 65
                                                categoria_peso_Final = 70
                                            Case 13 '70 a 75 kg
                                                categoria_peso_inicial = 70
                                                categoria_peso_Final = 75
                                            Case 14 '75 a 80 kg
                                                categoria_peso_inicial = 75
                                                categoria_peso_Final = 80
                                            Case 15 '80 a 85 kg
                                                categoria_peso_inicial = 80
                                                categoria_peso_Final = 85
                                            Case 16 '85 a 90 kg
                                                categoria_peso_inicial = 85
                                                categoria_peso_Final = 90
                                        End Select
                                    Case 4 '10 a 11 años
                                        categoria_edadinicial = 10
                                        categoria_edadfinal = 11
                                        Select Case DropDownList_peso.SelectedValue
                                            Case 1 '0 a 15 kg
                                                categoria_peso_inicial = 0
                                                categoria_peso_Final = 15
                                            Case 2 '15 a 20 kg
                                                categoria_peso_inicial = 15
                                                categoria_peso_Final = 20
                                            Case 3 '20 a 25 kg
                                                categoria_peso_inicial = 20
                                                categoria_peso_Final = 25
                                            Case 4 '25 a 30 kg
                                                categoria_peso_inicial = 25
                                                categoria_peso_Final = 30
                                            Case 5 '30 a 35 kg
                                                categoria_peso_inicial = 30
                                                categoria_peso_Final = 35
                                            Case 6 '35 a 40 kg
                                                categoria_peso_inicial = 35
                                                categoria_peso_Final = 40
                                            Case 7 '40 a 45 kg
                                                categoria_peso_inicial = 40
                                                categoria_peso_Final = 45
                                            Case 8 '45 a 50 kg
                                                categoria_peso_inicial = 45
                                                categoria_peso_Final = 50
                                            Case 9 '50 a 55 kg
                                                categoria_peso_inicial = 50
                                                categoria_peso_Final = 55
                                            Case 10 ' 55 a 60 kg
                                                categoria_peso_inicial = 55
                                                categoria_peso_Final = 60
                                            Case 11 '60 a 65 kg
                                                categoria_peso_inicial = 60
                                                categoria_peso_Final = 65
                                            Case 12 '65 a 70 kg
                                                categoria_peso_inicial = 65
                                                categoria_peso_Final = 70
                                            Case 13 '70 a 75 kg
                                                categoria_peso_inicial = 70
                                                categoria_peso_Final = 75
                                            Case 14 '75 a 80 kg
                                                categoria_peso_inicial = 75
                                                categoria_peso_Final = 80
                                            Case 15 '80 a 85 kg
                                                categoria_peso_inicial = 80
                                                categoria_peso_Final = 85
                                            Case 16 '85 a 90 kg
                                                categoria_peso_inicial = 85
                                                categoria_peso_Final = 90
                                            Case 17 '90 a 95 kg
                                                categoria_peso_inicial = 90
                                                categoria_peso_Final = 95
                                            Case 18 '95 a 100 kg
                                                categoria_peso_inicial = 95
                                                categoria_peso_Final = 100
                                        End Select
                                End Select
                            Case 12
                                Select Case DropDownList_edad.SelectedValue
                                    Case 1 ' 10 a 11 años
                                        categoria_edadinicial = 10
                                        categoria_edadfinal = 11
                                        Select Case DropDownList_peso.SelectedValue
                                            Case 1 '0 a 15 kg
                                                categoria_peso_inicial = 0
                                                categoria_peso_Final = 15
                                            Case 2 '15 a 20 kg
                                                categoria_peso_inicial = 15
                                                categoria_peso_Final = 20
                                            Case 3 '20 a 25 kg
                                                categoria_peso_inicial = 20
                                                categoria_peso_Final = 25
                                            Case 4 '25 a 30 kg
                                                categoria_peso_inicial = 25
                                                categoria_peso_Final = 30
                                            Case 5 '30 a 35 kg
                                                categoria_peso_inicial = 30
                                                categoria_peso_Final = 35
                                            Case 6 '35 a 40 kg
                                                categoria_peso_inicial = 35
                                                categoria_peso_Final = 40
                                            Case 7 '40 a 45 kg
                                                categoria_peso_inicial = 40
                                                categoria_peso_Final = 45
                                            Case 8 '45 a 50 kg
                                                categoria_peso_inicial = 45
                                                categoria_peso_Final = 50
                                            Case 9 '50 a 55 kg
                                                categoria_peso_inicial = 50
                                                categoria_peso_Final = 55
                                            Case 10 ' 55 a 60 kg
                                                categoria_peso_inicial = 55
                                                categoria_peso_Final = 60
                                            Case 11 '60 a 65 kg
                                                categoria_peso_inicial = 60
                                                categoria_peso_Final = 65
                                            Case 12 '65 a 70 kg
                                                categoria_peso_inicial = 65
                                                categoria_peso_Final = 70
                                            Case 13 '70 a 75 kg
                                                categoria_peso_inicial = 70
                                                categoria_peso_Final = 75
                                            Case 14 '75 a 80 kg
                                                categoria_peso_inicial = 75
                                                categoria_peso_Final = 80
                                            Case 15 '80 a 85 kg
                                                categoria_peso_inicial = 80
                                                categoria_peso_Final = 85
                                            Case 16 '85 a 90 kg
                                                categoria_peso_inicial = 85
                                                categoria_peso_Final = 90
                                            Case 17 '90 a 95 kg
                                                categoria_peso_inicial = 90
                                                categoria_peso_Final = 95
                                            Case 18 '95 a 100 kg
                                                categoria_peso_inicial = 95
                                                categoria_peso_Final = 100
                                        End Select
                                End Select

                        End Select
                    Case "Hombre"
                        Select Case categoria_gradinicial
                            Case 2
                                Select Case DropDownList_edad.SelectedValue
                                    Case 1 '12 a 13 años
                                        categoria_edadinicial = 12
                                        categoria_edadfinal = 13
                                        Select Case DropDownList_peso.SelectedValue
                                            Case 1 '0 a 40 kg
                                                categoria_peso_inicial = 0
                                                categoria_peso_Final = 40
                                            Case 2 '40 a 45 kg
                                                categoria_peso_inicial = 40
                                                categoria_peso_Final = 45
                                            Case 3 '45 a 50 kg
                                                categoria_peso_inicial = 45
                                                categoria_peso_Final = 50
                                            Case 4 '55 a 999 kg
                                                categoria_peso_inicial = 55
                                                categoria_peso_Final = 999
                                        End Select
                                    Case 2 '14 a 15 años
                                        categoria_edadinicial = 14
                                        categoria_edadfinal = 15
                                        Select Case DropDownList_peso.SelectedValue
                                            Case 1 '0 a 50 kg
                                                categoria_peso_inicial = 0
                                                categoria_peso_Final = 50
                                            Case 2 '50 a 55 kg
                                                categoria_peso_inicial = 50
                                                categoria_peso_Final = 55
                                            Case 3 '55 a 60 kg
                                                categoria_peso_inicial = 55
                                                categoria_peso_Final = 60
                                            Case 4 '60 a 65 kg
                                                categoria_peso_inicial = 60
                                                categoria_peso_Final = 65
                                            Case 5 '65 a 70 kg
                                                categoria_peso_inicial = 65
                                                categoria_peso_Final = 70
                                            Case 6 '70 a 999 kg
                                                categoria_peso_inicial = 70
                                                categoria_peso_Final = 999

                                        End Select
                                    Case 3 '16 a 17 años
                                        categoria_edadinicial = 16
                                        categoria_edadfinal = 17
                                        Select Case DropDownList_peso.SelectedValue
                                            Case 1 '0 a 50 kg
                                                categoria_peso_inicial = 0
                                                categoria_peso_Final = 50
                                            Case 2 '50 a 55 kg
                                                categoria_peso_inicial = 50
                                                categoria_peso_Final = 55
                                            Case 3 '55 a 60 kg
                                                categoria_peso_inicial = 55
                                                categoria_peso_Final = 60
                                            Case 4 '60 a 65 kg
                                                categoria_peso_inicial = 60
                                                categoria_peso_Final = 65
                                            Case 5 '65 a 70 kg
                                                categoria_peso_inicial = 65
                                                categoria_peso_Final = 70
                                            Case 6 '70 a 999 kg
                                                categoria_peso_inicial = 70
                                                categoria_peso_Final = 999

                                        End Select
                                    Case 4 '18 a 35 años
                                        categoria_edadinicial = 18
                                        categoria_edadfinal = 35
                                        Select Case DropDownList_peso.SelectedValue
                                            Case 1 '0 a 58 kg
                                                categoria_peso_inicial = 0
                                                categoria_peso_Final = 58
                                            Case 2 '58 a 64 kg
                                                categoria_peso_inicial = 58
                                                categoria_peso_Final = 64
                                            Case 3 '64 a 70 kg
                                                categoria_peso_inicial = 64
                                                categoria_peso_Final = 70
                                            Case 4 '70 a 76 kg
                                                categoria_peso_inicial = 70
                                                categoria_peso_Final = 76
                                            Case 5 '76 a 82 kg
                                                categoria_peso_inicial = 76
                                                categoria_peso_Final = 82
                                            Case 6 '82 a 999 kg
                                                categoria_peso_inicial = 82
                                                categoria_peso_Final = 999
                                        End Select
                                    Case 5 '36 a 45 años
                                        categoria_edadinicial = 36
                                        categoria_edadfinal = 45
                                        Select Case DropDownList_peso.SelectedValue
                                            Case 1 '0 a 58 kg
                                                categoria_peso_inicial = 0
                                                categoria_peso_Final = 58
                                            Case 2 '58 a 64 kg
                                                categoria_peso_inicial = 58
                                                categoria_peso_Final = 64
                                            Case 3 '64 a 70 kg
                                                categoria_peso_inicial = 64
                                                categoria_peso_Final = 70
                                            Case 4 '70 a 76 kg
                                                categoria_peso_inicial = 70
                                                categoria_peso_Final = 76
                                            Case 5 '76 a 82 kg
                                                categoria_peso_inicial = 76
                                                categoria_peso_Final = 82
                                            Case 6 '82 a 999 kg
                                                categoria_peso_inicial = 82
                                                categoria_peso_Final = 999
                                        End Select
                                    Case 6 '46 a 55 años
                                        categoria_edadinicial = 46
                                        categoria_edadfinal = 55
                                        Select Case DropDownList_peso.SelectedValue
                                            Case 1 '0 a 58 kg
                                                categoria_peso_inicial = 0
                                                categoria_peso_Final = 58
                                            Case 2 '58 a 64 kg
                                                categoria_peso_inicial = 58
                                                categoria_peso_Final = 64
                                            Case 3 '64 a 70 kg
                                                categoria_peso_inicial = 64
                                                categoria_peso_Final = 70
                                            Case 4 '70 a 76 kg
                                                categoria_peso_inicial = 70
                                                categoria_peso_Final = 76
                                            Case 5 '76 a 82 kg
                                                categoria_peso_inicial = 76
                                                categoria_peso_Final = 82
                                            Case 6 '82 a 999 kg
                                                categoria_peso_inicial = 82
                                                categoria_peso_Final = 999
                                        End Select
                                    Case 7 '56 a 99 años
                                        categoria_edadinicial = 56
                                        categoria_edadfinal = 99
                                        Select Case DropDownList_peso.SelectedValue
                                            Case 1 '0 a 58 kg
                                                categoria_peso_inicial = 0
                                                categoria_peso_Final = 58
                                            Case 2 '58 a 64 kg
                                                categoria_peso_inicial = 58
                                                categoria_peso_Final = 64
                                            Case 3 '64 a 70 kg
                                                categoria_peso_inicial = 64
                                                categoria_peso_Final = 70
                                            Case 4 '70 a 76 kg
                                                categoria_peso_inicial = 70
                                                categoria_peso_Final = 76
                                            Case 5 '76 a 82 kg
                                                categoria_peso_inicial = 76
                                                categoria_peso_Final = 82
                                            Case 6 '82 a 999 kg
                                                categoria_peso_inicial = 82
                                                categoria_peso_Final = 999
                                        End Select
                                End Select
                            Case 4
                                Select Case DropDownList_edad.SelectedValue
                                    Case 1 '12 a 13 años
                                        categoria_edadinicial = 12
                                        categoria_edadfinal = 13
                                        Select Case DropDownList_peso.SelectedValue
                                            Case 1 '0 a 40 kg
                                                categoria_peso_inicial = 0
                                                categoria_peso_Final = 40
                                            Case 2 '40 a 45 kg
                                                categoria_peso_inicial = 40
                                                categoria_peso_Final = 45
                                            Case 3 '45 a 50 kg
                                                categoria_peso_inicial = 45
                                                categoria_peso_Final = 50
                                            Case 4 '55 a 999 kg
                                                categoria_peso_inicial = 55
                                                categoria_peso_Final = 999
                                        End Select
                                    Case 2 '14 a 15 años
                                        categoria_edadinicial = 14
                                        categoria_edadfinal = 15
                                        Select Case DropDownList_peso.SelectedValue
                                            Case 1 '0 a 50 kg
                                                categoria_peso_inicial = 0
                                                categoria_peso_Final = 50
                                            Case 2 '50 a 55 kg
                                                categoria_peso_inicial = 50
                                                categoria_peso_Final = 55
                                            Case 3 '55 a 60 kg
                                                categoria_peso_inicial = 55
                                                categoria_peso_Final = 60
                                            Case 4 '60 a 65 kg
                                                categoria_peso_inicial = 60
                                                categoria_peso_Final = 65
                                            Case 5 '65 a 70 kg
                                                categoria_peso_inicial = 65
                                                categoria_peso_Final = 70
                                            Case 6 '70 a 999 kg
                                                categoria_peso_inicial = 70
                                                categoria_peso_Final = 999

                                        End Select
                                    Case 3 '16 a 17 años
                                        categoria_edadinicial = 16
                                        categoria_edadfinal = 17
                                        Select Case DropDownList_peso.SelectedValue
                                            Case 1 '0 a 50 kg
                                                categoria_peso_inicial = 0
                                                categoria_peso_Final = 50
                                            Case 2 '50 a 55 kg
                                                categoria_peso_inicial = 50
                                                categoria_peso_Final = 55
                                            Case 3 '55 a 60 kg
                                                categoria_peso_inicial = 55
                                                categoria_peso_Final = 60
                                            Case 4 '60 a 65 kg
                                                categoria_peso_inicial = 60
                                                categoria_peso_Final = 65
                                            Case 5 '65 a 70 kg
                                                categoria_peso_inicial = 65
                                                categoria_peso_Final = 70
                                            Case 6 '70 a 999 kg
                                                categoria_peso_inicial = 70
                                                categoria_peso_Final = 999

                                        End Select
                                    Case 4 '18 a 35 años
                                        categoria_edadinicial = 18
                                        categoria_edadfinal = 35
                                        Select Case DropDownList_peso.SelectedValue
                                            Case 1 '0 a 58 kg
                                                categoria_peso_inicial = 0
                                                categoria_peso_Final = 58
                                            Case 2 '58 a 64 kg
                                                categoria_peso_inicial = 58
                                                categoria_peso_Final = 64
                                            Case 3 '64 a 70 kg
                                                categoria_peso_inicial = 64
                                                categoria_peso_Final = 70
                                            Case 4 '70 a 76 kg
                                                categoria_peso_inicial = 70
                                                categoria_peso_Final = 76
                                            Case 5 '76 a 82 kg
                                                categoria_peso_inicial = 76
                                                categoria_peso_Final = 82
                                            Case 6 '82 a 999 kg
                                                categoria_peso_inicial = 82
                                                categoria_peso_Final = 999
                                        End Select
                                    Case 5 '36 a 45 años
                                        categoria_edadinicial = 36
                                        categoria_edadfinal = 45
                                        Select Case DropDownList_peso.SelectedValue
                                            Case 1 '0 a 58 kg
                                                categoria_peso_inicial = 0
                                                categoria_peso_Final = 58
                                            Case 2 '58 a 64 kg
                                                categoria_peso_inicial = 58
                                                categoria_peso_Final = 64
                                            Case 3 '64 a 70 kg
                                                categoria_peso_inicial = 64
                                                categoria_peso_Final = 70
                                            Case 4 '70 a 76 kg
                                                categoria_peso_inicial = 70
                                                categoria_peso_Final = 76
                                            Case 5 '76 a 82 kg
                                                categoria_peso_inicial = 76
                                                categoria_peso_Final = 82
                                            Case 6 '82 a 999 kg
                                                categoria_peso_inicial = 82
                                                categoria_peso_Final = 999
                                        End Select
                                    Case 6 '46 a 55 años
                                        categoria_edadinicial = 46
                                        categoria_edadfinal = 55
                                        Select Case DropDownList_peso.SelectedValue
                                            Case 1 '0 a 58 kg
                                                categoria_peso_inicial = 0
                                                categoria_peso_Final = 58
                                            Case 2 '58 a 64 kg
                                                categoria_peso_inicial = 58
                                                categoria_peso_Final = 64
                                            Case 3 '64 a 70 kg
                                                categoria_peso_inicial = 64
                                                categoria_peso_Final = 70
                                            Case 4 '70 a 76 kg
                                                categoria_peso_inicial = 70
                                                categoria_peso_Final = 76
                                            Case 5 '76 a 82 kg
                                                categoria_peso_inicial = 76
                                                categoria_peso_Final = 82
                                            Case 6 '82 a 999 kg
                                                categoria_peso_inicial = 82
                                                categoria_peso_Final = 999
                                        End Select
                                    Case 7 '56 a 99 años
                                        categoria_edadinicial = 56
                                        categoria_edadfinal = 99
                                        Select Case DropDownList_peso.SelectedValue
                                            Case 1 '0 a 58 kg
                                                categoria_peso_inicial = 0
                                                categoria_peso_Final = 58
                                            Case 2 '58 a 64 kg
                                                categoria_peso_inicial = 58
                                                categoria_peso_Final = 64
                                            Case 3 '64 a 70 kg
                                                categoria_peso_inicial = 64
                                                categoria_peso_Final = 70
                                            Case 4 '70 a 76 kg
                                                categoria_peso_inicial = 70
                                                categoria_peso_Final = 76
                                            Case 5 '76 a 82 kg
                                                categoria_peso_inicial = 76
                                                categoria_peso_Final = 82
                                            Case 6 '82 a 999 kg
                                                categoria_peso_inicial = 82
                                                categoria_peso_Final = 999
                                        End Select
                                End Select
                            Case 8
                                Select Case DropDownList_edad.SelectedValue
                                    Case 1 '12 a 13 años
                                        categoria_edadinicial = 12
                                        categoria_edadfinal = 13
                                        Select Case DropDownList_peso.SelectedValue
                                            Case 1 '0 a 40 kg
                                                categoria_peso_inicial = 0
                                                categoria_peso_Final = 40
                                            Case 2 '40 a 45 kg
                                                categoria_peso_inicial = 40
                                                categoria_peso_Final = 45
                                            Case 3 '45 a 50 kg
                                                categoria_peso_inicial = 45
                                                categoria_peso_Final = 50
                                            Case 4 '55 a 999 kg
                                                categoria_peso_inicial = 55
                                                categoria_peso_Final = 999
                                        End Select
                                    Case 2 '14 a 15 años
                                        categoria_edadinicial = 14
                                        categoria_edadfinal = 15
                                        Select Case DropDownList_peso.SelectedValue
                                            Case 1 '0 a 50 kg
                                                categoria_peso_inicial = 0
                                                categoria_peso_Final = 50
                                            Case 2 '50 a 55 kg
                                                categoria_peso_inicial = 50
                                                categoria_peso_Final = 55
                                            Case 3 '55 a 60 kg
                                                categoria_peso_inicial = 55
                                                categoria_peso_Final = 60
                                            Case 4 '60 a 65 kg
                                                categoria_peso_inicial = 60
                                                categoria_peso_Final = 65
                                            Case 5 '65 a 70 kg
                                                categoria_peso_inicial = 65
                                                categoria_peso_Final = 70
                                            Case 6 '70 a 999 kg
                                                categoria_peso_inicial = 70
                                                categoria_peso_Final = 999

                                        End Select
                                    Case 3 '16 a 17 años
                                        categoria_edadinicial = 16
                                        categoria_edadfinal = 17
                                        Select Case DropDownList_peso.SelectedValue
                                            Case 1 '0 a 50 kg
                                                categoria_peso_inicial = 0
                                                categoria_peso_Final = 50
                                            Case 2 '50 a 55 kg
                                                categoria_peso_inicial = 50
                                                categoria_peso_Final = 55
                                            Case 3 '55 a 60 kg
                                                categoria_peso_inicial = 55
                                                categoria_peso_Final = 60
                                            Case 4 '60 a 65 kg
                                                categoria_peso_inicial = 60
                                                categoria_peso_Final = 65
                                            Case 5 '65 a 70 kg
                                                categoria_peso_inicial = 65
                                                categoria_peso_Final = 70
                                            Case 6 '70 a 999 kg
                                                categoria_peso_inicial = 70
                                                categoria_peso_Final = 999

                                        End Select
                                    Case 4 '18 a 35 años
                                        categoria_edadinicial = 18
                                        categoria_edadfinal = 35
                                        Select Case DropDownList_peso.SelectedValue
                                            Case 1 '0 a 58 kg
                                                categoria_peso_inicial = 0
                                                categoria_peso_Final = 58
                                            Case 2 '58 a 64 kg
                                                categoria_peso_inicial = 58
                                                categoria_peso_Final = 64
                                            Case 3 '64 a 70 kg
                                                categoria_peso_inicial = 64
                                                categoria_peso_Final = 70
                                            Case 4 '70 a 76 kg
                                                categoria_peso_inicial = 70
                                                categoria_peso_Final = 76
                                            Case 5 '76 a 82 kg
                                                categoria_peso_inicial = 76
                                                categoria_peso_Final = 82
                                            Case 6 '82 a 999 kg
                                                categoria_peso_inicial = 82
                                                categoria_peso_Final = 999
                                        End Select
                                    Case 5 '36 a 45 años
                                        categoria_edadinicial = 36
                                        categoria_edadfinal = 45
                                        Select Case DropDownList_peso.SelectedValue
                                            Case 1 '0 a 58 kg
                                                categoria_peso_inicial = 0
                                                categoria_peso_Final = 58
                                            Case 2 '58 a 64 kg
                                                categoria_peso_inicial = 58
                                                categoria_peso_Final = 64
                                            Case 3 '64 a 70 kg
                                                categoria_peso_inicial = 64
                                                categoria_peso_Final = 70
                                            Case 4 '70 a 76 kg
                                                categoria_peso_inicial = 70
                                                categoria_peso_Final = 76
                                            Case 5 '76 a 82 kg
                                                categoria_peso_inicial = 76
                                                categoria_peso_Final = 82
                                            Case 6 '82 a 999 kg
                                                categoria_peso_inicial = 82
                                                categoria_peso_Final = 999
                                        End Select
                                    Case 6 '46 a 55 años
                                        categoria_edadinicial = 46
                                        categoria_edadfinal = 55
                                        Select Case DropDownList_peso.SelectedValue
                                            Case 1 '0 a 58 kg
                                                categoria_peso_inicial = 0
                                                categoria_peso_Final = 58
                                            Case 2 '58 a 64 kg
                                                categoria_peso_inicial = 58
                                                categoria_peso_Final = 64
                                            Case 3 '64 a 70 kg
                                                categoria_peso_inicial = 64
                                                categoria_peso_Final = 70
                                            Case 4 '70 a 76 kg
                                                categoria_peso_inicial = 70
                                                categoria_peso_Final = 76
                                            Case 5 '76 a 82 kg
                                                categoria_peso_inicial = 76
                                                categoria_peso_Final = 82
                                            Case 6 '82 a 999 kg
                                                categoria_peso_inicial = 82
                                                categoria_peso_Final = 999
                                        End Select
                                    Case 7 '56 a 99 años
                                        categoria_edadinicial = 56
                                        categoria_edadfinal = 99
                                        Select Case DropDownList_peso.SelectedValue
                                            Case 1 '0 a 58 kg
                                                categoria_peso_inicial = 0
                                                categoria_peso_Final = 58
                                            Case 2 '58 a 64 kg
                                                categoria_peso_inicial = 58
                                                categoria_peso_Final = 64
                                            Case 3 '64 a 70 kg
                                                categoria_peso_inicial = 64
                                                categoria_peso_Final = 70
                                            Case 4 '70 a 76 kg
                                                categoria_peso_inicial = 70
                                                categoria_peso_Final = 76
                                            Case 5 '76 a 82 kg
                                                categoria_peso_inicial = 76
                                                categoria_peso_Final = 82
                                            Case 6 '82 a 999 kg
                                                categoria_peso_inicial = 82
                                                categoria_peso_Final = 999
                                        End Select
                                End Select
                            Case 12
                                Select Case DropDownList_edad.SelectedValue
                                    Case 1 '12 a 13 años
                                        categoria_edadinicial = 12
                                        categoria_edadfinal = 13
                                        Select Case DropDownList_peso.SelectedValue
                                            Case 1 '0 a 40 kg
                                                categoria_peso_inicial = 0
                                                categoria_peso_Final = 40
                                            Case 2 '40 a 45 kg
                                                categoria_peso_inicial = 40
                                                categoria_peso_Final = 45
                                            Case 3 '45 a 50 kg
                                                categoria_peso_inicial = 45
                                                categoria_peso_Final = 50
                                            Case 4 '55 a 999 kg
                                                categoria_peso_inicial = 55
                                                categoria_peso_Final = 999
                                        End Select
                                    Case 2 '14 a 15 años
                                        categoria_edadinicial = 14
                                        categoria_edadfinal = 15
                                        Select Case DropDownList_peso.SelectedValue
                                            Case 1 '0 a 50 kg
                                                categoria_peso_inicial = 0
                                                categoria_peso_Final = 50
                                            Case 2 '50 a 55 kg
                                                categoria_peso_inicial = 50
                                                categoria_peso_Final = 55
                                            Case 3 '55 a 60 kg
                                                categoria_peso_inicial = 55
                                                categoria_peso_Final = 60
                                            Case 4 '60 a 65 kg
                                                categoria_peso_inicial = 60
                                                categoria_peso_Final = 65
                                            Case 5 '65 a 70 kg
                                                categoria_peso_inicial = 65
                                                categoria_peso_Final = 70
                                            Case 6 '70 a 999 kg
                                                categoria_peso_inicial = 70
                                                categoria_peso_Final = 999

                                        End Select
                                    Case 3 '16 a 17 años
                                        categoria_edadinicial = 16
                                        categoria_edadfinal = 17
                                        Select Case DropDownList_peso.SelectedValue
                                            Case 1 '0 a 50 kg
                                                categoria_peso_inicial = 0
                                                categoria_peso_Final = 50
                                            Case 2 '50 a 55 kg
                                                categoria_peso_inicial = 50
                                                categoria_peso_Final = 55
                                            Case 3 '55 a 60 kg
                                                categoria_peso_inicial = 55
                                                categoria_peso_Final = 60
                                            Case 4 '60 a 65 kg
                                                categoria_peso_inicial = 60
                                                categoria_peso_Final = 65
                                            Case 5 '65 a 70 kg
                                                categoria_peso_inicial = 65
                                                categoria_peso_Final = 70
                                            Case 6 '70 a 999 kg
                                                categoria_peso_inicial = 70
                                                categoria_peso_Final = 999

                                        End Select
                                    Case 4 '18 a 35 años
                                        categoria_edadinicial = 18
                                        categoria_edadfinal = 35
                                        Select Case DropDownList_peso.SelectedValue
                                            Case 1 '0 a 58 kg
                                                categoria_peso_inicial = 0
                                                categoria_peso_Final = 58
                                            Case 2 '58 a 64 kg
                                                categoria_peso_inicial = 58
                                                categoria_peso_Final = 64
                                            Case 3 '64 a 70 kg
                                                categoria_peso_inicial = 64
                                                categoria_peso_Final = 70
                                            Case 4 '70 a 76 kg
                                                categoria_peso_inicial = 70
                                                categoria_peso_Final = 76
                                            Case 5 '76 a 82 kg
                                                categoria_peso_inicial = 76
                                                categoria_peso_Final = 82
                                            Case 6 '82 a 999 kg
                                                categoria_peso_inicial = 82
                                                categoria_peso_Final = 999
                                        End Select
                                    Case 5 '36 a 45 años
                                        categoria_edadinicial = 36
                                        categoria_edadfinal = 45
                                        Select Case DropDownList_peso.SelectedValue
                                            Case 1 '0 a 58 kg
                                                categoria_peso_inicial = 0
                                                categoria_peso_Final = 58
                                            Case 2 '58 a 64 kg
                                                categoria_peso_inicial = 58
                                                categoria_peso_Final = 64
                                            Case 3 '64 a 70 kg
                                                categoria_peso_inicial = 64
                                                categoria_peso_Final = 70
                                            Case 4 '70 a 76 kg
                                                categoria_peso_inicial = 70
                                                categoria_peso_Final = 76
                                            Case 5 '76 a 82 kg
                                                categoria_peso_inicial = 76
                                                categoria_peso_Final = 82
                                            Case 6 '82 a 999 kg
                                                categoria_peso_inicial = 82
                                                categoria_peso_Final = 999
                                        End Select
                                    Case 6 '46 a 55 años
                                        categoria_edadinicial = 46
                                        categoria_edadfinal = 55
                                        Select Case DropDownList_peso.SelectedValue
                                            Case 1 '0 a 58 kg
                                                categoria_peso_inicial = 0
                                                categoria_peso_Final = 58
                                            Case 2 '58 a 64 kg
                                                categoria_peso_inicial = 58
                                                categoria_peso_Final = 64
                                            Case 3 '64 a 70 kg
                                                categoria_peso_inicial = 64
                                                categoria_peso_Final = 70
                                            Case 4 '70 a 76 kg
                                                categoria_peso_inicial = 70
                                                categoria_peso_Final = 76
                                            Case 5 '76 a 82 kg
                                                categoria_peso_inicial = 76
                                                categoria_peso_Final = 82
                                            Case 6 '82 a 999 kg
                                                categoria_peso_inicial = 82
                                                categoria_peso_Final = 999
                                        End Select
                                    Case 7 '56 a 99 años
                                        categoria_edadinicial = 56
                                        categoria_edadfinal = 99
                                        Select Case DropDownList_peso.SelectedValue
                                            Case 1 '0 a 58 kg
                                                categoria_peso_inicial = 0
                                                categoria_peso_Final = 58
                                            Case 2 '58 a 64 kg
                                                categoria_peso_inicial = 58
                                                categoria_peso_Final = 64
                                            Case 3 '64 a 70 kg
                                                categoria_peso_inicial = 64
                                                categoria_peso_Final = 70
                                            Case 4 '70 a 76 kg
                                                categoria_peso_inicial = 70
                                                categoria_peso_Final = 76
                                            Case 5 '76 a 82 kg
                                                categoria_peso_inicial = 76
                                                categoria_peso_Final = 82
                                            Case 6 '82 a 999 kg
                                                categoria_peso_inicial = 82
                                                categoria_peso_Final = 999
                                        End Select
                                End Select
                        End Select
                    Case "Mujer"
                        Select Case categoria_gradinicial
                            Case 2
                                Select Case DropDownList_edad.SelectedValue
                                    Case 1 '12 a 13 años
                                        categoria_edadinicial = 12
                                        categoria_edadfinal = 13
                                        Select Case DropDownList_peso.SelectedValue
                                            Case 1 '0 a 35 kg
                                                categoria_peso_inicial = 0
                                                categoria_peso_Final = 35
                                            Case 2 '35 a 40 kg
                                                categoria_peso_inicial = 35
                                                categoria_peso_Final = 40
                                            Case 3 '40 a 45 kg
                                                categoria_peso_inicial = 40
                                                categoria_peso_Final = 45
                                            Case 4 '45 a 50 kg
                                                categoria_peso_inicial = 45
                                                categoria_peso_Final = 50
                                            Case 5 '50 a 999 kg
                                                categoria_peso_inicial = 50
                                                categoria_peso_Final = 999
                                        End Select
                                    Case 2 '14 a 15 años
                                        categoria_edadinicial = 14
                                        categoria_edadfinal = 15
                                        Select Case DropDownList_peso.SelectedValue
                                            Case 1 '0 a 45 kg
                                                categoria_peso_inicial = 0
                                                categoria_peso_Final = 45
                                            Case 2 '45 a 50 kg
                                                categoria_peso_inicial = 45
                                                categoria_peso_Final = 50
                                            Case 3 '50 a 55 kg
                                                categoria_peso_inicial = 50
                                                categoria_peso_Final = 55
                                            Case 4 '55 a 60 kg
                                                categoria_peso_inicial = 55
                                                categoria_peso_Final = 60
                                            Case 5 '60 a 65 kg
                                                categoria_peso_inicial = 60
                                                categoria_peso_Final = 65
                                            Case 6 '65 a 999 kg
                                                categoria_peso_inicial = 65
                                                categoria_peso_Final = 999

                                        End Select
                                    Case 3 '16 a 17 años
                                        categoria_edadinicial = 16
                                        categoria_edadfinal = 17
                                        Select Case DropDownList_peso.SelectedValue
                                            Case 1 '0 a 45 kg
                                                categoria_peso_inicial = 0
                                                categoria_peso_Final = 45
                                            Case 2 '45 a 50 kg
                                                categoria_peso_inicial = 45
                                                categoria_peso_Final = 50
                                            Case 3 '50 a 55 kg
                                                categoria_peso_inicial = 50
                                                categoria_peso_Final = 55
                                            Case 4 '55 a 60 kg
                                                categoria_peso_inicial = 55
                                                categoria_peso_Final = 60
                                            Case 5 '60 a 65 kg
                                                categoria_peso_inicial = 60
                                                categoria_peso_Final = 65
                                            Case 6 '65 a 999 kg
                                                categoria_peso_inicial = 65
                                                categoria_peso_Final = 999

                                        End Select
                                    Case 4 '18 a 35 años
                                        categoria_edadinicial = 18
                                        categoria_edadfinal = 35
                                        Select Case DropDownList_peso.SelectedValue
                                            Case 1 '0 a 50 kg
                                                categoria_peso_inicial = 0
                                                categoria_peso_Final = 50
                                            Case 2 '50 a 55 kg
                                                categoria_peso_inicial = 50
                                                categoria_peso_Final = 55
                                            Case 3 '55 a 60 kg
                                                categoria_peso_inicial = 55
                                                categoria_peso_Final = 60
                                            Case 4 '60 a 65 kg
                                                categoria_peso_inicial = 60
                                                categoria_peso_Final = 65
                                            Case 5 '65 a 70 kg
                                                categoria_peso_inicial = 65
                                                categoria_peso_Final = 70
                                            Case 6 '70 a 999 kg
                                                categoria_peso_inicial = 70
                                                categoria_peso_Final = 999
                                        End Select
                                    Case 5 '36 a 45 años
                                        categoria_edadinicial = 36
                                        categoria_edadfinal = 45
                                        Select Case DropDownList_peso.SelectedValue
                                            Case 1 '0 a 50 kg
                                                categoria_peso_inicial = 0
                                                categoria_peso_Final = 50
                                            Case 2 '50 a 55 kg
                                                categoria_peso_inicial = 50
                                                categoria_peso_Final = 55
                                            Case 3 '55 a 60 kg
                                                categoria_peso_inicial = 55
                                                categoria_peso_Final = 60
                                            Case 4 '60 a 65 kg
                                                categoria_peso_inicial = 60
                                                categoria_peso_Final = 65
                                            Case 5 '65 a 70 kg
                                                categoria_peso_inicial = 65
                                                categoria_peso_Final = 70
                                            Case 6 '70 a 999 kg
                                                categoria_peso_inicial = 70
                                                categoria_peso_Final = 999
                                        End Select
                                    Case 6 '46 a 55 años
                                        categoria_edadinicial = 46
                                        categoria_edadfinal = 55
                                        Select Case DropDownList_peso.SelectedValue
                                            Case 1 '0 a 50 kg
                                                categoria_peso_inicial = 0
                                                categoria_peso_Final = 50
                                            Case 2 '50 a 55 kg
                                                categoria_peso_inicial = 50
                                                categoria_peso_Final = 55
                                            Case 3 '55 a 60 kg
                                                categoria_peso_inicial = 55
                                                categoria_peso_Final = 60
                                            Case 4 '60 a 65 kg
                                                categoria_peso_inicial = 60
                                                categoria_peso_Final = 65
                                            Case 5 '65 a 70 kg
                                                categoria_peso_inicial = 65
                                                categoria_peso_Final = 70
                                            Case 6 '70 a 999 kg
                                                categoria_peso_inicial = 70
                                                categoria_peso_Final = 999
                                        End Select
                                    Case 7 '56 a 99 años
                                        categoria_edadinicial = 56
                                        categoria_edadfinal = 99
                                        Select Case DropDownList_peso.SelectedValue
                                            Case 1 '0 a 50 kg
                                                categoria_peso_inicial = 0
                                                categoria_peso_Final = 50
                                            Case 2 '50 a 55 kg
                                                categoria_peso_inicial = 50
                                                categoria_peso_Final = 55
                                            Case 3 '55 a 60 kg
                                                categoria_peso_inicial = 55
                                                categoria_peso_Final = 60
                                            Case 4 '60 a 65 kg
                                                categoria_peso_inicial = 60
                                                categoria_peso_Final = 65
                                            Case 5 '65 a 70 kg
                                                categoria_peso_inicial = 65
                                                categoria_peso_Final = 70
                                            Case 6 '70 a 999 kg
                                                categoria_peso_inicial = 70
                                                categoria_peso_Final = 999
                                        End Select
                                End Select
                            Case 4
                                Select Case DropDownList_edad.SelectedValue
                                    Case 1 '12 a 13 años
                                        categoria_edadinicial = 12
                                        categoria_edadfinal = 13
                                        Select Case DropDownList_peso.SelectedValue
                                            Case 1 '0 a 35 kg
                                                categoria_peso_inicial = 0
                                                categoria_peso_Final = 35
                                            Case 2 '35 a 40 kg
                                                categoria_peso_inicial = 35
                                                categoria_peso_Final = 40
                                            Case 3 '40 a 45 kg
                                                categoria_peso_inicial = 40
                                                categoria_peso_Final = 45
                                            Case 4 '45 a 50 kg
                                                categoria_peso_inicial = 45
                                                categoria_peso_Final = 50
                                            Case 5 '50 a 999 kg
                                                categoria_peso_inicial = 50
                                                categoria_peso_Final = 999
                                        End Select
                                    Case 2 '14 a 15 años
                                        categoria_edadinicial = 14
                                        categoria_edadfinal = 15
                                        Select Case DropDownList_peso.SelectedValue
                                            Case 1 '0 a 45 kg
                                                categoria_peso_inicial = 0
                                                categoria_peso_Final = 45
                                            Case 2 '45 a 50 kg
                                                categoria_peso_inicial = 45
                                                categoria_peso_Final = 50
                                            Case 3 '50 a 55 kg
                                                categoria_peso_inicial = 50
                                                categoria_peso_Final = 55
                                            Case 4 '55 a 60 kg
                                                categoria_peso_inicial = 55
                                                categoria_peso_Final = 60
                                            Case 5 '60 a 65 kg
                                                categoria_peso_inicial = 60
                                                categoria_peso_Final = 65
                                            Case 6 '65 a 999 kg
                                                categoria_peso_inicial = 65
                                                categoria_peso_Final = 999

                                        End Select
                                    Case 3 '16 a 17 años
                                        categoria_edadinicial = 16
                                        categoria_edadfinal = 17
                                        Select Case DropDownList_peso.SelectedValue
                                            Case 1 '0 a 45 kg
                                                categoria_peso_inicial = 0
                                                categoria_peso_Final = 45
                                            Case 2 '45 a 50 kg
                                                categoria_peso_inicial = 45
                                                categoria_peso_Final = 50
                                            Case 3 '50 a 55 kg
                                                categoria_peso_inicial = 50
                                                categoria_peso_Final = 55
                                            Case 4 '55 a 60 kg
                                                categoria_peso_inicial = 55
                                                categoria_peso_Final = 60
                                            Case 5 '60 a 65 kg
                                                categoria_peso_inicial = 60
                                                categoria_peso_Final = 65
                                            Case 6 '65 a 999 kg
                                                categoria_peso_inicial = 65
                                                categoria_peso_Final = 999

                                        End Select
                                    Case 4 '18 a 35 años
                                        categoria_edadinicial = 18
                                        categoria_edadfinal = 35
                                        Select Case DropDownList_peso.SelectedValue
                                            Case 1 '0 a 50 kg
                                                categoria_peso_inicial = 0
                                                categoria_peso_Final = 50
                                            Case 2 '50 a 55 kg
                                                categoria_peso_inicial = 50
                                                categoria_peso_Final = 55
                                            Case 3 '55 a 60 kg
                                                categoria_peso_inicial = 55
                                                categoria_peso_Final = 60
                                            Case 4 '60 a 65 kg
                                                categoria_peso_inicial = 60
                                                categoria_peso_Final = 65
                                            Case 5 '65 a 70 kg
                                                categoria_peso_inicial = 65
                                                categoria_peso_Final = 70
                                            Case 6 '70 a 999 kg
                                                categoria_peso_inicial = 70
                                                categoria_peso_Final = 999
                                        End Select
                                    Case 5 '36 a 45 años
                                        categoria_edadinicial = 36
                                        categoria_edadfinal = 45
                                        Select Case DropDownList_peso.SelectedValue
                                            Case 1 '0 a 50 kg
                                                categoria_peso_inicial = 0
                                                categoria_peso_Final = 50
                                            Case 2 '50 a 55 kg
                                                categoria_peso_inicial = 50
                                                categoria_peso_Final = 55
                                            Case 3 '55 a 60 kg
                                                categoria_peso_inicial = 55
                                                categoria_peso_Final = 60
                                            Case 4 '60 a 65 kg
                                                categoria_peso_inicial = 60
                                                categoria_peso_Final = 65
                                            Case 5 '65 a 70 kg
                                                categoria_peso_inicial = 65
                                                categoria_peso_Final = 70
                                            Case 6 '70 a 999 kg
                                                categoria_peso_inicial = 70
                                                categoria_peso_Final = 999
                                        End Select
                                    Case 6 '46 a 55 años
                                        categoria_edadinicial = 46
                                        categoria_edadfinal = 55
                                        Select Case DropDownList_peso.SelectedValue
                                            Case 1 '0 a 50 kg
                                                categoria_peso_inicial = 0
                                                categoria_peso_Final = 50
                                            Case 2 '50 a 55 kg
                                                categoria_peso_inicial = 50
                                                categoria_peso_Final = 55
                                            Case 3 '55 a 60 kg
                                                categoria_peso_inicial = 55
                                                categoria_peso_Final = 60
                                            Case 4 '60 a 65 kg
                                                categoria_peso_inicial = 60
                                                categoria_peso_Final = 65
                                            Case 5 '65 a 70 kg
                                                categoria_peso_inicial = 65
                                                categoria_peso_Final = 70
                                            Case 6 '70 a 999 kg
                                                categoria_peso_inicial = 70
                                                categoria_peso_Final = 999
                                        End Select
                                    Case 7 '56 a 99 años
                                        categoria_edadinicial = 56
                                        categoria_edadfinal = 99
                                        Select Case DropDownList_peso.SelectedValue
                                            Case 1 '0 a 50 kg
                                                categoria_peso_inicial = 0
                                                categoria_peso_Final = 50
                                            Case 2 '50 a 55 kg
                                                categoria_peso_inicial = 50
                                                categoria_peso_Final = 55
                                            Case 3 '55 a 60 kg
                                                categoria_peso_inicial = 55
                                                categoria_peso_Final = 60
                                            Case 4 '60 a 65 kg
                                                categoria_peso_inicial = 60
                                                categoria_peso_Final = 65
                                            Case 5 '65 a 70 kg
                                                categoria_peso_inicial = 65
                                                categoria_peso_Final = 70
                                            Case 6 '70 a 999 kg
                                                categoria_peso_inicial = 70
                                                categoria_peso_Final = 999
                                        End Select
                                End Select
                            Case 8
                                Select Case DropDownList_edad.SelectedValue
                                    Case 1 '12 a 13 años
                                        categoria_edadinicial = 12
                                        categoria_edadfinal = 13
                                        Select Case DropDownList_peso.SelectedValue
                                            Case 1 '0 a 35 kg
                                                categoria_peso_inicial = 0
                                                categoria_peso_Final = 35
                                            Case 2 '35 a 40 kg
                                                categoria_peso_inicial = 35
                                                categoria_peso_Final = 40
                                            Case 3 '40 a 45 kg
                                                categoria_peso_inicial = 40
                                                categoria_peso_Final = 45
                                            Case 4 '45 a 50 kg
                                                categoria_peso_inicial = 45
                                                categoria_peso_Final = 50
                                            Case 5 '50 a 999 kg
                                                categoria_peso_inicial = 50
                                                categoria_peso_Final = 999
                                        End Select
                                    Case 2 '14 a 15 años
                                        categoria_edadinicial = 14
                                        categoria_edadfinal = 15
                                        Select Case DropDownList_peso.SelectedValue
                                            Case 1 '0 a 45 kg
                                                categoria_peso_inicial = 0
                                                categoria_peso_Final = 45
                                            Case 2 '45 a 50 kg
                                                categoria_peso_inicial = 45
                                                categoria_peso_Final = 50
                                            Case 3 '50 a 55 kg
                                                categoria_peso_inicial = 50
                                                categoria_peso_Final = 55
                                            Case 4 '55 a 60 kg
                                                categoria_peso_inicial = 55
                                                categoria_peso_Final = 60
                                            Case 5 '60 a 65 kg
                                                categoria_peso_inicial = 60
                                                categoria_peso_Final = 65
                                            Case 6 '65 a 999 kg
                                                categoria_peso_inicial = 65
                                                categoria_peso_Final = 999

                                        End Select
                                    Case 3 '16 a 17 años
                                        categoria_edadinicial = 16
                                        categoria_edadfinal = 17
                                        Select Case DropDownList_peso.SelectedValue
                                            Case 1 '0 a 45 kg
                                                categoria_peso_inicial = 0
                                                categoria_peso_Final = 45
                                            Case 2 '45 a 50 kg
                                                categoria_peso_inicial = 45
                                                categoria_peso_Final = 50
                                            Case 3 '50 a 55 kg
                                                categoria_peso_inicial = 50
                                                categoria_peso_Final = 55
                                            Case 4 '55 a 60 kg
                                                categoria_peso_inicial = 55
                                                categoria_peso_Final = 60
                                            Case 5 '60 a 65 kg
                                                categoria_peso_inicial = 60
                                                categoria_peso_Final = 65
                                            Case 6 '65 a 999 kg
                                                categoria_peso_inicial = 65
                                                categoria_peso_Final = 999

                                        End Select
                                    Case 4 '18 a 35 años
                                        categoria_edadinicial = 18
                                        categoria_edadfinal = 35
                                        Select Case DropDownList_peso.SelectedValue
                                            Case 1 '0 a 50 kg
                                                categoria_peso_inicial = 0
                                                categoria_peso_Final = 50
                                            Case 2 '50 a 55 kg
                                                categoria_peso_inicial = 50
                                                categoria_peso_Final = 55
                                            Case 3 '55 a 60 kg
                                                categoria_peso_inicial = 55
                                                categoria_peso_Final = 60
                                            Case 4 '60 a 65 kg
                                                categoria_peso_inicial = 60
                                                categoria_peso_Final = 65
                                            Case 5 '65 a 70 kg
                                                categoria_peso_inicial = 65
                                                categoria_peso_Final = 70
                                            Case 6 '70 a 999 kg
                                                categoria_peso_inicial = 70
                                                categoria_peso_Final = 999
                                        End Select
                                    Case 5 '36 a 45 años
                                        categoria_edadinicial = 36
                                        categoria_edadfinal = 45
                                        Select Case DropDownList_peso.SelectedValue
                                            Case 1 '0 a 50 kg
                                                categoria_peso_inicial = 0
                                                categoria_peso_Final = 50
                                            Case 2 '50 a 55 kg
                                                categoria_peso_inicial = 50
                                                categoria_peso_Final = 55
                                            Case 3 '55 a 60 kg
                                                categoria_peso_inicial = 55
                                                categoria_peso_Final = 60
                                            Case 4 '60 a 65 kg
                                                categoria_peso_inicial = 60
                                                categoria_peso_Final = 65
                                            Case 5 '65 a 70 kg
                                                categoria_peso_inicial = 65
                                                categoria_peso_Final = 70
                                            Case 6 '70 a 999 kg
                                                categoria_peso_inicial = 70
                                                categoria_peso_Final = 999
                                        End Select
                                    Case 6 '46 a 55 años
                                        categoria_edadinicial = 46
                                        categoria_edadfinal = 55
                                        Select Case DropDownList_peso.SelectedValue
                                            Case 1 '0 a 50 kg
                                                categoria_peso_inicial = 0
                                                categoria_peso_Final = 50
                                            Case 2 '50 a 55 kg
                                                categoria_peso_inicial = 50
                                                categoria_peso_Final = 55
                                            Case 3 '55 a 60 kg
                                                categoria_peso_inicial = 55
                                                categoria_peso_Final = 60
                                            Case 4 '60 a 65 kg
                                                categoria_peso_inicial = 60
                                                categoria_peso_Final = 65
                                            Case 5 '65 a 70 kg
                                                categoria_peso_inicial = 65
                                                categoria_peso_Final = 70
                                            Case 6 '70 a 999 kg
                                                categoria_peso_inicial = 70
                                                categoria_peso_Final = 999
                                        End Select
                                    Case 7 '56 a 99 años
                                        categoria_edadinicial = 56
                                        categoria_edadfinal = 99
                                        Select Case DropDownList_peso.SelectedValue
                                            Case 1 '0 a 50 kg
                                                categoria_peso_inicial = 0
                                                categoria_peso_Final = 50
                                            Case 2 '50 a 55 kg
                                                categoria_peso_inicial = 50
                                                categoria_peso_Final = 55
                                            Case 3 '55 a 60 kg
                                                categoria_peso_inicial = 55
                                                categoria_peso_Final = 60
                                            Case 4 '60 a 65 kg
                                                categoria_peso_inicial = 60
                                                categoria_peso_Final = 65
                                            Case 5 '65 a 70 kg
                                                categoria_peso_inicial = 65
                                                categoria_peso_Final = 70
                                            Case 6 '70 a 999 kg
                                                categoria_peso_inicial = 70
                                                categoria_peso_Final = 999
                                        End Select
                                End Select
                            Case 12
                                Select Case DropDownList_edad.SelectedValue
                                    Case 1 '12 a 13 años
                                        categoria_edadinicial = 12
                                        categoria_edadfinal = 13
                                        Select Case DropDownList_peso.SelectedValue
                                            Case 1 '0 a 35 kg
                                                categoria_peso_inicial = 0
                                                categoria_peso_Final = 35
                                            Case 2 '35 a 40 kg
                                                categoria_peso_inicial = 35
                                                categoria_peso_Final = 40
                                            Case 3 '40 a 45 kg
                                                categoria_peso_inicial = 40
                                                categoria_peso_Final = 45
                                            Case 4 '45 a 50 kg
                                                categoria_peso_inicial = 45
                                                categoria_peso_Final = 50
                                            Case 5 '50 a 999 kg
                                                categoria_peso_inicial = 50
                                                categoria_peso_Final = 999
                                        End Select
                                    Case 2 '14 a 15 años
                                        categoria_edadinicial = 14
                                        categoria_edadfinal = 15
                                        Select Case DropDownList_peso.SelectedValue
                                            Case 1 '0 a 45 kg
                                                categoria_peso_inicial = 0
                                                categoria_peso_Final = 45
                                            Case 2 '45 a 50 kg
                                                categoria_peso_inicial = 45
                                                categoria_peso_Final = 50
                                            Case 3 '50 a 55 kg
                                                categoria_peso_inicial = 50
                                                categoria_peso_Final = 55
                                            Case 4 '55 a 60 kg
                                                categoria_peso_inicial = 55
                                                categoria_peso_Final = 60
                                            Case 5 '60 a 65 kg
                                                categoria_peso_inicial = 60
                                                categoria_peso_Final = 65
                                            Case 6 '65 a 999 kg
                                                categoria_peso_inicial = 65
                                                categoria_peso_Final = 999

                                        End Select
                                    Case 3 '16 a 17 años
                                        categoria_edadinicial = 16
                                        categoria_edadfinal = 17
                                        Select Case DropDownList_peso.SelectedValue
                                            Case 1 '0 a 45 kg
                                                categoria_peso_inicial = 0
                                                categoria_peso_Final = 45
                                            Case 2 '45 a 50 kg
                                                categoria_peso_inicial = 45
                                                categoria_peso_Final = 50
                                            Case 3 '50 a 55 kg
                                                categoria_peso_inicial = 50
                                                categoria_peso_Final = 55
                                            Case 4 '55 a 60 kg
                                                categoria_peso_inicial = 55
                                                categoria_peso_Final = 60
                                            Case 5 '60 a 65 kg
                                                categoria_peso_inicial = 60
                                                categoria_peso_Final = 65
                                            Case 6 '65 a 999 kg
                                                categoria_peso_inicial = 65
                                                categoria_peso_Final = 999

                                        End Select
                                    Case 4 '18 a 35 años
                                        categoria_edadinicial = 18
                                        categoria_edadfinal = 35
                                        Select Case DropDownList_peso.SelectedValue
                                            Case 1 '0 a 50 kg
                                                categoria_peso_inicial = 0
                                                categoria_peso_Final = 50
                                            Case 2 '50 a 55 kg
                                                categoria_peso_inicial = 50
                                                categoria_peso_Final = 55
                                            Case 3 '55 a 60 kg
                                                categoria_peso_inicial = 55
                                                categoria_peso_Final = 60
                                            Case 4 '60 a 65 kg
                                                categoria_peso_inicial = 60
                                                categoria_peso_Final = 65
                                            Case 5 '65 a 70 kg
                                                categoria_peso_inicial = 65
                                                categoria_peso_Final = 70
                                            Case 6 '70 a 999 kg
                                                categoria_peso_inicial = 70
                                                categoria_peso_Final = 999
                                        End Select
                                    Case 5 '36 a 45 años
                                        categoria_edadinicial = 36
                                        categoria_edadfinal = 45
                                        Select Case DropDownList_peso.SelectedValue
                                            Case 1 '0 a 50 kg
                                                categoria_peso_inicial = 0
                                                categoria_peso_Final = 50
                                            Case 2 '50 a 55 kg
                                                categoria_peso_inicial = 50
                                                categoria_peso_Final = 55
                                            Case 3 '55 a 60 kg
                                                categoria_peso_inicial = 55
                                                categoria_peso_Final = 60
                                            Case 4 '60 a 65 kg
                                                categoria_peso_inicial = 60
                                                categoria_peso_Final = 65
                                            Case 5 '65 a 70 kg
                                                categoria_peso_inicial = 65
                                                categoria_peso_Final = 70
                                            Case 6 '70 a 999 kg
                                                categoria_peso_inicial = 70
                                                categoria_peso_Final = 999
                                        End Select
                                    Case 6 '46 a 55 años
                                        categoria_edadinicial = 46
                                        categoria_edadfinal = 55
                                        Select Case DropDownList_peso.SelectedValue
                                            Case 1 '0 a 50 kg
                                                categoria_peso_inicial = 0
                                                categoria_peso_Final = 50
                                            Case 2 '50 a 55 kg
                                                categoria_peso_inicial = 50
                                                categoria_peso_Final = 55
                                            Case 3 '55 a 60 kg
                                                categoria_peso_inicial = 55
                                                categoria_peso_Final = 60
                                            Case 4 '60 a 65 kg
                                                categoria_peso_inicial = 60
                                                categoria_peso_Final = 65
                                            Case 5 '65 a 70 kg
                                                categoria_peso_inicial = 65
                                                categoria_peso_Final = 70
                                            Case 6 '70 a 999 kg
                                                categoria_peso_inicial = 70
                                                categoria_peso_Final = 999
                                        End Select
                                    Case 7 '56 a 99 años
                                        categoria_edadinicial = 56
                                        categoria_edadfinal = 99
                                        Select Case DropDownList_peso.SelectedValue
                                            Case 1 '0 a 50 kg
                                                categoria_peso_inicial = 0
                                                categoria_peso_Final = 50
                                            Case 2 '50 a 55 kg
                                                categoria_peso_inicial = 50
                                                categoria_peso_Final = 55
                                            Case 3 '55 a 60 kg
                                                categoria_peso_inicial = 55
                                                categoria_peso_Final = 60
                                            Case 4 '60 a 65 kg
                                                categoria_peso_inicial = 60
                                                categoria_peso_Final = 65
                                            Case 5 '65 a 70 kg
                                                categoria_peso_inicial = 65
                                                categoria_peso_Final = 70
                                            Case 6 '70 a 999 kg
                                                categoria_peso_inicial = 70
                                                categoria_peso_Final = 999
                                        End Select
                                End Select
                        End Select
                End Select
            Case "Forma"
                Select Case categoria_sexo
                    Case "AMBOS SEXOS"
                        Select Case categoria_gradinicial
                            Case 2
                                Select Case DropDownList_edad.SelectedValue
                                    Case 1 '0 a 5 años
                                        categoria_edadinicial = 0
                                        categoria_edadfinal = 5
                                    Case 2 '6 a 7 años
                                        categoria_edadinicial = 6
                                        categoria_edadfinal = 7
                                    Case 3 '8 a 9 años
                                        categoria_edadinicial = 8
                                        categoria_edadfinal = 9
                                    Case 4 '10 a 11 años
                                        categoria_edadinicial = 10
                                        categoria_edadfinal = 11
                                End Select
                            Case 4
                                Select Case DropDownList_edad.SelectedValue
                                    Case 1 '0 a 5 años
                                        categoria_edadinicial = 0
                                        categoria_edadfinal = 5
                                    Case 2 '6 a 7 años
                                        categoria_edadinicial = 6
                                        categoria_edadfinal = 7
                                    Case 3 '8 a 9 años
                                        categoria_edadinicial = 8
                                        categoria_edadfinal = 9
                                    Case 4 '10 a 11 años
                                        categoria_edadinicial = 10
                                        categoria_edadfinal = 11
                                End Select
                            Case 8
                                Select Case DropDownList_edad.SelectedValue
                                    Case 1 '0 a 5 años
                                        categoria_edadinicial = 0
                                        categoria_edadfinal = 5
                                    Case 2 '6 a 7 años
                                        categoria_edadinicial = 6
                                        categoria_edadfinal = 7
                                    Case 3 '8 a 9 años
                                        categoria_edadinicial = 8
                                        categoria_edadfinal = 9
                                    Case 4 '10 a 11 años
                                        categoria_edadinicial = 10
                                        categoria_edadfinal = 11
                                End Select
                            Case 12
                                Select Case DropDownList_edad.SelectedValue
                                    Case 1 '10 a 11 años
                                        categoria_edadinicial = 10
                                        categoria_edadfinal = 11
                                End Select
                            Case 13
                                Select Case DropDownList_edad.SelectedValue
                                    Case 1 '10 a 11 años
                                        categoria_edadinicial = 10
                                        categoria_edadfinal = 11
                                End Select

                        End Select
                    Case "Hombre"
                        Select Case categoria_gradinicial
                            Case 2
                                Select Case DropDownList_edad.SelectedValue
                                    Case 1 '12 a 13 años
                                        categoria_edadinicial = 12
                                        categoria_edadfinal = 13
                                    Case 2 '14 a 15 años
                                        categoria_edadinicial = 14
                                        categoria_edadfinal = 15
                                    Case 3 '16 a 17 años
                                        categoria_edadinicial = 16
                                        categoria_edadfinal = 17
                                    Case 4 '18 a 35 años
                                        categoria_edadinicial = 18
                                        categoria_edadfinal = 35
                                    Case 5 '36 a 45 años
                                        categoria_edadinicial = 36
                                        categoria_edadfinal = 45
                                End Select
                            Case 4
                                Select Case DropDownList_edad.SelectedValue
                                    Case 1 '12 a 13 años
                                        categoria_edadinicial = 12
                                        categoria_edadfinal = 13
                                    Case 2 '14 a 15 años
                                        categoria_edadinicial = 14
                                        categoria_edadfinal = 15
                                    Case 3 '16 a 17 años
                                        categoria_edadinicial = 16
                                        categoria_edadfinal = 17
                                    Case 4 '18 a 35 años
                                        categoria_edadinicial = 18
                                        categoria_edadfinal = 35
                                    Case 5 '36 a 45 años
                                        categoria_edadinicial = 36
                                        categoria_edadfinal = 45
                                End Select
                            Case 8
                                Select Case DropDownList_edad.SelectedValue
                                    Case 1 '12 a 13 años
                                        categoria_edadinicial = 12
                                        categoria_edadfinal = 13
                                    Case 2 '14 a 15 años
                                        categoria_edadinicial = 14
                                        categoria_edadfinal = 15
                                    Case 3 '16 a 17 años
                                        categoria_edadinicial = 16
                                        categoria_edadfinal = 17
                                    Case 4 '18 a 35 años
                                        categoria_edadinicial = 18
                                        categoria_edadfinal = 35
                                    Case 5 '36 a 45 años
                                        categoria_edadinicial = 36
                                        categoria_edadfinal = 45
                                End Select
                            Case 12
                                Select Case DropDownList_edad.SelectedValue
                                    Case 1 '12 a 13 años
                                        categoria_edadinicial = 12
                                        categoria_edadfinal = 13
                                    Case 2 '14 a 15 años
                                        categoria_edadinicial = 14
                                        categoria_edadfinal = 15
                                    Case 3 '16 a 17 años
                                        categoria_edadinicial = 16
                                        categoria_edadfinal = 17
                                    Case 4 '18 a 35 años
                                        categoria_edadinicial = 18
                                        categoria_edadfinal = 35
                                    Case 5 '36 a 45 años
                                        categoria_edadinicial = 36
                                        categoria_edadfinal = 45
                                End Select
                            Case 13
                                Select Case DropDownList_edad.SelectedValue
                                    Case 1 '12 a 13 años
                                        categoria_edadinicial = 12
                                        categoria_edadfinal = 13
                                    Case 2 '14 a 15 años
                                        categoria_edadinicial = 14
                                        categoria_edadfinal = 15
                                    Case 3 '16 a 17 años
                                        categoria_edadinicial = 16
                                        categoria_edadfinal = 17
                                    Case 4 '18 a 35 años
                                        categoria_edadinicial = 18
                                        categoria_edadfinal = 35
                                    Case 5 '36 a 45 años
                                        categoria_edadinicial = 36
                                        categoria_edadfinal = 45
                                End Select
                            Case 14
                                Select Case DropDownList_edad.SelectedValue
                                    Case 1 '14 a 15 años
                                        categoria_edadinicial = 14
                                        categoria_edadfinal = 15
                                    Case 2 '16 a 17 años
                                        categoria_edadinicial = 16
                                        categoria_edadfinal = 17
                                    Case 3 '18 a 35 años
                                        categoria_edadinicial = 18
                                        categoria_edadfinal = 35
                                    Case 4 '36 a 45 años
                                        categoria_edadinicial = 36
                                        categoria_edadfinal = 45
                                End Select
                            Case 15
                                Select Case DropDownList_edad.SelectedValue
                                    Case 1 '18 a 35 años
                                        categoria_edadinicial = 18
                                        categoria_edadfinal = 35
                                    Case 2 '36 a 45 años
                                        categoria_edadinicial = 36
                                        categoria_edadfinal = 45
                                End Select
                            Case 16
                                Select Case DropDownList_edad.SelectedValue
                                    Case 1 '18 a 35 años
                                        categoria_edadinicial = 18
                                        categoria_edadfinal = 35
                                    Case 2 '36 a 45 años
                                        categoria_edadinicial = 36
                                        categoria_edadfinal = 45
                                End Select
                            Case 17
                                Select Case DropDownList_edad.SelectedValue
                                    Case 1 '18 a 35 años
                                        categoria_edadinicial = 18
                                        categoria_edadfinal = 35
                                    Case 2 '36 a 45 años
                                        categoria_edadinicial = 36
                                        categoria_edadfinal = 45
                                End Select
                        End Select
                    Case "Mujer"
                        Select Case categoria_gradinicial
                            Case 2
                                Select Case DropDownList_edad.SelectedValue
                                    Case 1 '12 a 13 años
                                        categoria_edadinicial = 12
                                        categoria_edadfinal = 13
                                    Case 2 '14 a 15 años
                                        categoria_edadinicial = 14
                                        categoria_edadfinal = 15
                                    Case 3 '16 a 17 años
                                        categoria_edadinicial = 16
                                        categoria_edadfinal = 17
                                    Case 4 '18 a 35 años
                                        categoria_edadinicial = 18
                                        categoria_edadfinal = 35
                                    Case 5 '36 a 45 años
                                        categoria_edadinicial = 36
                                        categoria_edadfinal = 45
                                End Select
                            Case 4
                                Select Case DropDownList_edad.SelectedValue
                                    Case 1 '12 a 13 años
                                        categoria_edadinicial = 12
                                        categoria_edadfinal = 13
                                    Case 2 '14 a 15 años
                                        categoria_edadinicial = 14
                                        categoria_edadfinal = 15
                                    Case 3 '16 a 17 años
                                        categoria_edadinicial = 16
                                        categoria_edadfinal = 17
                                    Case 4 '18 a 35 años
                                        categoria_edadinicial = 18
                                        categoria_edadfinal = 35
                                    Case 5 '36 a 45 años
                                        categoria_edadinicial = 36
                                        categoria_edadfinal = 45
                                End Select
                            Case 8
                                Select Case DropDownList_edad.SelectedValue
                                    Case 1 '12 a 13 años
                                        categoria_edadinicial = 12
                                        categoria_edadfinal = 13
                                    Case 2 '14 a 15 años
                                        categoria_edadinicial = 14
                                        categoria_edadfinal = 15
                                    Case 3 '16 a 17 años
                                        categoria_edadinicial = 16
                                        categoria_edadfinal = 17
                                    Case 4 '18 a 35 años
                                        categoria_edadinicial = 18
                                        categoria_edadfinal = 35
                                    Case 5 '36 a 45 años
                                        categoria_edadinicial = 36
                                        categoria_edadfinal = 45
                                End Select
                            Case 12
                                Select Case DropDownList_edad.SelectedValue
                                    Case 1 '12 a 13 años
                                        categoria_edadinicial = 12
                                        categoria_edadfinal = 13
                                    Case 2 '14 a 15 años
                                        categoria_edadinicial = 14
                                        categoria_edadfinal = 15
                                    Case 3 '16 a 17 años
                                        categoria_edadinicial = 16
                                        categoria_edadfinal = 17
                                    Case 4 '18 a 35 años
                                        categoria_edadinicial = 18
                                        categoria_edadfinal = 35
                                    Case 5 '36 a 45 años
                                        categoria_edadinicial = 36
                                        categoria_edadfinal = 45
                                End Select
                            Case 13
                                Select Case DropDownList_edad.SelectedValue
                                    Case 1 '12 a 13 años
                                        categoria_edadinicial = 12
                                        categoria_edadfinal = 13
                                    Case 2 '14 a 15 años
                                        categoria_edadinicial = 14
                                        categoria_edadfinal = 15
                                    Case 3 '16 a 17 años
                                        categoria_edadinicial = 16
                                        categoria_edadfinal = 17
                                    Case 4 '18 a 35 años
                                        categoria_edadinicial = 18
                                        categoria_edadfinal = 35
                                    Case 5 '36 a 45 años
                                        categoria_edadinicial = 36
                                        categoria_edadfinal = 45
                                End Select
                            Case 14
                                Select Case DropDownList_edad.SelectedValue
                                    Case 1 '14 a 15 años
                                        categoria_edadinicial = 14
                                        categoria_edadfinal = 15
                                    Case 2 '16 a 17 años
                                        categoria_edadinicial = 16
                                        categoria_edadfinal = 17
                                    Case 3 '18 a 35 años
                                        categoria_edadinicial = 18
                                        categoria_edadfinal = 35
                                    Case 4 '36 a 45 años
                                        categoria_edadinicial = 36
                                        categoria_edadfinal = 45
                                End Select
                            Case 15
                                Select Case DropDownList_edad.SelectedValue
                                    Case 1 '18 a 35 años
                                        categoria_edadinicial = 18
                                        categoria_edadfinal = 35
                                    Case 2 '36 a 45 años
                                        categoria_edadinicial = 36
                                        categoria_edadfinal = 45
                                End Select
                            Case 16
                                Select Case DropDownList_edad.SelectedValue
                                    Case 1 '18 a 35 años
                                        categoria_edadinicial = 18
                                        categoria_edadfinal = 35
                                    Case 2 '36 a 45 años
                                        categoria_edadinicial = 36
                                        categoria_edadfinal = 45
                                End Select
                            Case 17
                                Select Case DropDownList_edad.SelectedValue
                                    Case 1 '18 a 35 años
                                        categoria_edadinicial = 18
                                        categoria_edadfinal = 35
                                    Case 2 '36 a 45 años
                                        categoria_edadinicial = 36
                                        categoria_edadfinal = 45
                                End Select
                        End Select
                End Select
            Case "Rotura de Poder"

            Case "Rotura Especial"

        End Select

    End Sub
End Class