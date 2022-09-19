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


Partial Public Class Pago

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
    '''Control Txt_cliente_codigo.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents Txt_cliente_codigo As Global.System.Web.UI.WebControls.TextBox

    '''<summary>
    '''Control btn_buscar.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents btn_buscar As Global.System.Web.UI.HtmlControls.HtmlButton

    '''<summary>
    '''Control lb_error_codigo.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents lb_error_codigo As Global.System.Web.UI.WebControls.Label

    '''<summary>
    '''Control Txt_nombre.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents Txt_nombre As Global.System.Web.UI.WebControls.TextBox

    '''<summary>
    '''Control Txt_saldo.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents Txt_saldo As Global.System.Web.UI.WebControls.TextBox

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
    '''Control BOTON_GRABA.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents BOTON_GRABA As Global.System.Web.UI.HtmlControls.HtmlButton

    '''<summary>
    '''Control btn_close_error_limite.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents btn_close_error_limite As Global.System.Web.UI.HtmlControls.HtmlButton

    '''<summary>
    '''Control btn_ok_error_limite.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents btn_ok_error_limite As Global.System.Web.UI.HtmlControls.HtmlButton

    '''<summary>
    '''Control btn_erroringreso_close.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents btn_erroringreso_close As Global.System.Web.UI.HtmlControls.HtmlButton

    '''<summary>
    '''Control btn_erroringreso_ok.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents btn_erroringreso_ok As Global.System.Web.UI.HtmlControls.HtmlButton

    '''<summary>
    '''Control btn_close_error_noexiste.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents btn_close_error_noexiste As Global.System.Web.UI.HtmlControls.HtmlButton

    '''<summary>
    '''Control btn_ok_error_noexiste.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents btn_ok_error_noexiste As Global.System.Web.UI.HtmlControls.HtmlButton

    '''<summary>
    '''Control btn_close_error_fecha.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents btn_close_error_fecha As Global.System.Web.UI.HtmlControls.HtmlButton

    '''<summary>
    '''Control btn_ok_error_fecha.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents btn_ok_error_fecha As Global.System.Web.UI.HtmlControls.HtmlButton

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
