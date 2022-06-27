'------------------------------------------------------------------------------
' <generado automáticamente>
'     Este código fue generado por una herramienta.
'
'     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
'     se vuelve a generar el código. 
' </generado automáticamente>
'------------------------------------------------------------------------------

Option Strict On
Option Explicit On


Partial Public Class acl_gastos_carga

    '''<summary>
    '''Control ScriptManager1.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents ScriptManager1 As Global.System.Web.UI.ScriptManager

    '''<summary>
    '''Control UpdatePanel1.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents UpdatePanel1 As Global.System.Web.UI.UpdatePanel

    '''<summary>
    '''Control Txt_fecha.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents Txt_fecha As Global.System.Web.UI.WebControls.TextBox

    '''<summary>
    '''Control lb_error_fecha.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents lb_error_fecha As Global.System.Web.UI.WebControls.Label

    '''<summary>
    '''Control Txt_grupo_codigo.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents Txt_grupo_codigo As Global.System.Web.UI.WebControls.TextBox

    '''<summary>
    '''Control lb_error_grupocodigo.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents lb_error_grupocodigo As Global.System.Web.UI.WebControls.Label

    '''<summary>
    '''Control DropDownList_motivo.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents DropDownList_motivo As Global.System.Web.UI.WebControls.DropDownList

    '''<summary>
    '''Control Txt_importe.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents Txt_importe As Global.System.Web.UI.WebControls.TextBox

    '''<summary>
    '''Control lb_error_importe.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents lb_error_importe As Global.System.Web.UI.WebControls.Label

    '''<summary>
    '''Control btn_retroceder.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents btn_retroceder As Global.System.Web.UI.HtmlControls.HtmlButton

    '''<summary>
    '''Control BOTON_GRABAR.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents BOTON_GRABAR As Global.System.Web.UI.HtmlControls.HtmlButton

    '''<summary>
    '''Control btn_graba_close.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents btn_graba_close As Global.System.Web.UI.HtmlControls.HtmlButton

    '''<summary>
    '''Control btn_graba_cancelar.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents btn_graba_cancelar As Global.System.Web.UI.HtmlControls.HtmlButton

    '''<summary>
    '''Control btn_graba_confirmar.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents btn_graba_confirmar As Global.System.Web.UI.HtmlControls.HtmlButton

    '''<summary>
    '''Control btn_close_error_ingreso.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents btn_close_error_ingreso As Global.System.Web.UI.HtmlControls.HtmlButton

    '''<summary>
    '''Control btn_ok_error_ingreso.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents btn_ok_error_ingreso As Global.System.Web.UI.HtmlControls.HtmlButton

    '''<summary>
    '''Control btn_close_error_grupo.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents btn_close_error_grupo As Global.System.Web.UI.HtmlControls.HtmlButton

    '''<summary>
    '''Control btn_ok_error_grupo.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents btn_ok_error_grupo As Global.System.Web.UI.HtmlControls.HtmlButton

    '''<summary>
    '''Control btn_ok_close.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents btn_ok_close As Global.System.Web.UI.HtmlControls.HtmlButton

    '''<summary>
    '''Control btn_ok.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents btn_ok As Global.System.Web.UI.HtmlControls.HtmlButton
End Class
