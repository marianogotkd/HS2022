Public Class IngresoTerminales
  Inherits System.Web.UI.Page

#Region "Declaraciones"
  Dim Daparametro As New Capa_Datos.WC_parametro
  Dim DALConsultas As New Capa_Datos.WB_Consultas
  Dim DALiquidacion As New Capa_Datos.WC_Liquidacion





#End Region
#Region "Eventos"
  Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    If Not IsPostBack Then

      'IMPORTANTE SE CARGA DESDE CERO LA TABLA XCARGAS Y XCARGAS RECORRIDOS. FECHA: 22-08-04
      DALiquidacion.XCargas_load()

      GridView1.DataSource = DALConsultas.IngresoTerminales
      GridView1.DataBind()
    End If
  End Sub

  Private Sub btn_retroceder_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_retroceder.ServerClick
    Response.Redirect("~/Consultas/MenuConsultas.aspx")
  End Sub




#End Region


#Region "Metodos"



#End Region





End Class
