<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Home.Master" CodeBehind="Cliente_alta.aspx.vb" Inherits="Presentacion.Cliente_alta" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style1
        {
            width: 124px;
        }
        .style2
        {
            width: 301px;
        }
        .style4
        {
            width: 63px;
        }
        .style6
        {
            width: 100%;
        }
        .style8
        {
            width: 83px;
        }
        .style9
        {
            width: 210px;
        }
        .style10
        {
            width: 212px;
        }
        .style11
        {
            width: 217px;
        }
        .style12
        {
            width: 72px;
        }
        .style13
        {
            width: 44px;
        }
        .style14
        {
            width: 187px;
        }
        .style15
        {
            width: 188px;
        }
        .style16
        {
            width: 239px;
        }
        .style17
        {
            width: 184px;
        }
        .style18
        {
            width: 186px;
        }
        </style>

    <script>
        
        //funcion que reconoce teclas para ir a los botones retroceso, baja y graba
        function tecla_op(e) {
            var keycode = e.keyCode;
            ///ESC RETROCEDE
            if (keycode == '27') {
                e.preventDefault();
                document.getElementsByTagName('button')[0].focus();
                document.getElementsByTagName('button')[0].click();

            }
            ///se anula el enter
            if (keycode == '13') {
                e.preventDefault();
            }

            ///F4 ELIMINA
            if (keycode == '115') {
                e.preventDefault();
                document.getElementsByTagName('button')[1].focus();
                document.getElementsByTagName('button')[1].click();
            }

            //F8 GRABA
            if (keycode == '119') {
                e.preventDefault();
                document.getElementsByTagName('button')[2].focus();
                document.getElementsByTagName('button')[2].click();
            }
        }



        //funcion que reconoce teclas para ir a los botones retroceso, baja y graba
        function tecla_op_botones(e) {
            var keycode = e.keyCode;
            ///ESC RETROCEDE
            if (keycode == '27') {
                e.preventDefault();
                document.getElementsByTagName('button')[0].focus();
                document.getElementsByTagName('button')[0].click();

            }
            //        ///no voy a anular el ENTER
            //        if (keycode == '13') {
            //            e.preventDefault();
            //        }

            ///F4 ELIMINA
            if (keycode == '115') {
                e.preventDefault();
                document.getElementsByTagName('button')[1].focus();
                document.getElementsByTagName('button')[1].click();
            }

            //F8 GRABA
            if (keycode == '119') {
                e.preventDefault();
                document.getElementsByTagName('button')[2].focus();
                document.getElementsByTagName('button')[2].click();
            }
        }





    </script>




</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" 
                        EnableScriptGlobalization="True">
</asp:ScriptManager>

<asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
<ContentTemplate>
<div class="card card-primary">
<div class="card-header">
                <h3 class="card-title">A.B.M. CLIENTES</h3>
</div>
<form role="form">
<div class="card-body">
<div class="container-fluid">
<div class="row justify-content-center">
<div class="col-lg-6">
<div class="card">
<div class="card-body">
        <div class="form-group">
        
            <table class="w-100">
                <tr>
                    <td class="style1">
                        <asp:Label ID="Label_cliente_id" runat="server" Text="Cliente:"></asp:Label>
                        &nbsp;<asp:TextBox ID="Txt_cliente_codigo" runat="server" Width="50px" onkeydown="tecla_op(event);" onkeypress="return justNumbers(event);"></asp:TextBox>
                        <asp:Label ID="lb_error_codigo" runat="server" ForeColor="Red" Text="*" 
                            Visible="False"></asp:Label>

                        <asp:HiddenField ID="HF_cliente_id" runat="server" />

                    </td>
                    <td class="style2">
                        <asp:Label ID="Label_cliente_nomb" runat="server" Text="Nombre:"></asp:Label>
                        &nbsp;<asp:TextBox ID="Txt_cliente_nomb" runat="server" MaxLength="50" onkeydown="tecla_op(event);"></asp:TextBox>
                        <asp:Label ID="lb_error_nombre" runat="server" ForeColor="Red" Text="*" 
                            Visible="False"></asp:Label>
                    </td>
                    <td>
                        
                    </td>
                </tr>
            </table>
            </div>
            <div class="form-group">
            <table class="w-100">
            <tr>
                <td>
                <asp:Label ID="Label28" runat="server" Text="DNI:"></asp:Label>
                &nbsp;<asp:TextBox ID="Txt_dni" runat="server" MaxLength="9" CausesValidation="True" onkeydown="tecla_op(event);" onkeypress="return justNumbers(event);"></asp:TextBox>
                    
                    <asp:Label ID="lb_error_dni" runat="server" ForeColor="Red" Text="*" 
                        Visible="False"></asp:Label>
                    
                <td>
            </tr>
            
            </table>
            </div>
            <div class="form-group">
            <table class="w-100">
            <tr>
                <td>
                <asp:Label ID="Label_grupo_nomb" runat="server" Text="Grupo:"></asp:Label>
                        &nbsp;<asp:DropDownList ID="DropDownList_grupos" runat="server" onkeydown="tecla_op(event);">
                        </asp:DropDownList>
                </td>
            
            </tr>
            
            </table>
            
            </div>
        <div class="form-group">

            <table class="w-100">
                <tr>
                    <td class="style9">
                        <asp:Label ID="Label1" runat="server" Text="% Comision: "></asp:Label>
                        &nbsp;<asp:TextBox ID="Txt_comision" runat="server" Width="70px" CausesValidation="True" validationgroup="check_2" xmlns:asp="#unknown2" MaxLength="6" onkeydown="tecla_op(event);" onkeypress="return onKeyDecimal(event, this);"></asp:TextBox>
                        <asp:Label ID="lb_error_comision" runat="server" ForeColor="Red" Text="*" 
                            Visible="False"></asp:Label>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
                            ControlToValidate="Txt_comision" ErrorMessage="Error!" Font-Size="X-Small" 
                            ForeColor="Red" SetFocusOnError="True" 
                            ValidationExpression="^\d+\.\d{1,2}$|^\d+\,\d{1,2}$|^\d+$" 
                            ValidationGroup="check_2" xmlns:asp="#unknown2"></asp:RegularExpressionValidator>
                        <%--<asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="Txt_comision" FilterType="Custom" ValidChars="0123456789,.">
                        </asp:FilteredTextBoxExtender>--%>

                    </td>
                    <td class="style10">
                        <asp:Label ID="Label2" runat="server" Text="% Regalo: "></asp:Label>
                        &nbsp;<asp:TextBox ID="Txt_regalo" runat="server" Width="70px" CausesValidation="True" validationgroup="check_2" xmlns:asp="#unknown2" MaxLength="6" onkeydown="tecla_op(event);" onkeypress="return onKeyDecimal(event, this);"></asp:TextBox>
                        <asp:Label ID="lb_error_regalo" runat="server" ForeColor="Red" Text="*" 
                            Visible="False"></asp:Label>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" 
                            ControlToValidate="Txt_regalo" ErrorMessage="Error!" Font-Size="X-Small" 
                            ForeColor="Red" SetFocusOnError="True" 
                            ValidationExpression="^\d+\.\d{1,2}$|^\d+\,\d{1,2}$|^\d+$" 
                            ValidationGroup="check_2" xmlns:asp="#unknown2"></asp:RegularExpressionValidator>
                        <%--<asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" TargetControlID="Txt_regalo" ValidChars="0123456789.,">
                        </asp:FilteredTextBoxExtender>--%>
                    </td>
                    <td class="style11">
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                
            </table>

        </div>
        <div class="form-group">
        <table class="w-100">
        <tr>
            <td class="style9">
                        <asp:Label ID="Label3" runat="server" Text="% Comision1:"></asp:Label>
                        <asp:TextBox ID="Txt_comision1" runat="server" CausesValidation="True" 
                            validationgroup="check_2" Width="70px" xmlns:asp="#unknown2" MaxLength="6" onkeydown="tecla_op(event);" onkeypress="return onKeyDecimal(event, this);"></asp:TextBox>
                        <asp:Label ID="lb_error_comision1" runat="server" ForeColor="Red" Text="*" 
                            Visible="False"></asp:Label>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" 
                            ControlToValidate="Txt_comision1" ErrorMessage="Error!" Font-Size="X-Small" 
                            ForeColor="Red" SetFocusOnError="True" 
                            ValidationExpression="^\d+\.\d{1,2}$|^\d+\,\d{1,2}$|^\d+$" 
                            ValidationGroup="check_2" xmlns:asp="#unknown2"></asp:RegularExpressionValidator>
                <%--<asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" TargetControlID="Txt_comision1" ValidChars="0123456789.,">
                </asp:FilteredTextBoxExtender>--%>
                    </td>
                    <td class="style10">
                        <asp:Label ID="Label4" runat="server" Text="% Regalo1:"></asp:Label>
                        <asp:TextBox ID="Txt_regalo1" runat="server" CausesValidation="True" 
                            validationgroup="check_2" Width="70px" xmlns:asp="#unknown2" MaxLength="6" onkeydown="tecla_op(event);" onkeypress="return onKeyDecimal(event, this);"></asp:TextBox>
                        <asp:Label ID="lb_error_regalo1" runat="server" ForeColor="Red" Text="*" 
                            Visible="False"></asp:Label>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" 
                            ControlToValidate="Txt_regalo1" ErrorMessage="Error!" Font-Size="X-Small" 
                            ForeColor="Red" SetFocusOnError="True" 
                            ValidationExpression="^\d+\.\d{1,2}$|^\d+\,\d{1,2}$|^\d+$" 
                            ValidationGroup="check_2" xmlns:asp="#unknown2"></asp:RegularExpressionValidator>
                        <%--<asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server" TargetControlID="Txt_regalo1" ValidChars="0123456789.,">
                        </asp:FilteredTextBoxExtender>--%>
                    </td>
                    <td class="style11">
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
        
        
        </tr>
        
        </table>
        </div>


        <div class="form-group">
        <table class="w-100">
        <tr>
            <td class="style14">
                <asp:Label ID="Label5" runat="server" Text="Proceso:"></asp:Label>
                &nbsp;<asp:TextBox ID="Txt_proceso" runat="server" Width="70px" 
                    CausesValidation="True" validationgroup="check_3" xmlns:asp="#unknown3" 
                    MaxLength="1" onkeydown="tecla_op(event);" onkeypress="return proceso_validation(event);"></asp:TextBox>
                <asp:Label ID="lb_error_proceso" runat="server" ForeColor="Red" Text="*" 
                    Visible="False"></asp:Label>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="Txt_proceso" ErrorMessage="Error!" Font-Size="X-Small" ForeColor="Red" SetFocusOnError="True" ValidationExpression="[DSMdsm]" ValidationGroup="check_3" xmlns:asp="#unknown3"></asp:RegularExpressionValidator>
                <%--<asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="Txt_proceso" ValidChars="dsmDSM">
                </asp:FilteredTextBoxExtender>--%>
            </td>
            <td class="style4">
                <asp:Label ID="Label6" runat="server" Text="D= diario." Font-Size="X-Small"></asp:Label>
            </td>
            <td class="style12">
                <asp:Label ID="Label7" runat="server" Text="S= semanal." Font-Size="X-Small"></asp:Label>
            </td>
            <td>
                <asp:Label ID="Label8" runat="server" Text="M= mensual." Font-Size="X-Small"></asp:Label>
            </td>
        </tr>
        </table>
        </div>
        
        <div class="form-group">
            <table class="style6">
                <tr>
                    <td class="style15">
                        <asp:Label ID="Label9" runat="server" Text="Calculo:"></asp:Label>
                        &nbsp;<asp:TextBox ID="Txt_calculo" runat="server" Width="70px" CausesValidation="True" validationgroup="check_4" xmlns:asp="#unknown4" MaxLength="1" onkeydown="tecla_op(event);" onkeypress="return solo_ceroyuno_valitation(event);"></asp:TextBox>
                        <asp:Label ID="lb_error_calculo" runat="server" ForeColor="Red" Text="*" 
                            Visible="False"></asp:Label>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ControlToValidate="Txt_calculo" ErrorMessage="Error!" Font-Size="X-Small" ForeColor="Red" SetFocusOnError="True" ValidationExpression="[01]" ValidationGroup="check_4" xmlns:asp="#unknown4"></asp:RegularExpressionValidator>
                        <%--<asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" TargetControlID="Txt_calculo" ValidChars="01">
                        </asp:FilteredTextBoxExtender>--%>
                    </td>
                    <td class="style13">
                        <asp:Label ID="Label10" runat="server" Text="0= NO." Font-Size="X-Small"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="Label11" runat="server" Text="1= SI." Font-Size="X-Small"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
        <div class="form-group">
        
            <table class="style6">
                <tr>
                    <td class="style15">
                        <asp:Label ID="Label12" runat="server" Text="Factor:"></asp:Label>
                        &nbsp;<asp:TextBox ID="Txt_factor" runat="server" Width="70px" CausesValidation="True" validationgroup="check_6" xmlns:asp="#unknown6" MaxLength="1" onkeydown="tecla_op(event);" onkeypress="return solo_ceroyuno_valitation(event);"></asp:TextBox>
                        <asp:Label ID="lb_error_factor" runat="server" ForeColor="Red" Text="*" 
                            Visible="False"></asp:Label>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator8" runat="server" ControlToValidate="Txt_factor" ErrorMessage="Error!" Font-Size="X-Small" ForeColor="Red" SetFocusOnError="True" ValidationExpression="[01]" ValidationGroup="check_6" xmlns:asp="#unknown6"></asp:RegularExpressionValidator>
                        <%--<asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" TargetControlID="Txt_factor" ValidChars="01">
                        </asp:FilteredTextBoxExtender>--%>
                    </td>
                    <td class="style8">
                        <asp:Label ID="Label13" runat="server" Text="0= sin factor." 
                            Font-Size="X-Small"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="Label14" runat="server" Text="1= con factor." 
                            Font-Size="X-Small"></asp:Label>
                    </td>
                </tr>
            </table>
        
        </div>
        <div class="form-group">
        
            <table class="style6">
                <tr>
                    <td class="style16">
                        <asp:Label ID="Label15" runat="server" Text="Imprime calculo:"></asp:Label>
                        &nbsp;<asp:TextBox ID="Txt_imprimecalculo" runat="server" Width="70px" CausesValidation="True" validationgroup="check_5" xmlns:asp="#unknown5" MaxLength="1" onkeydown="tecla_op(event);" onkeypress="return solo_ceroyuno_valitation(event);"></asp:TextBox>
                        <asp:Label ID="lb_error_imprimecalculo" runat="server" ForeColor="Red" Text="*" 
                            Visible="False"></asp:Label>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" ControlToValidate="Txt_imprimecalculo" ErrorMessage="Error!" Font-Size="X-Small" ForeColor="Red" SetFocusOnError="True" ValidationExpression="[01]" ValidationGroup="check_5" xmlns:asp="#unknown5"></asp:RegularExpressionValidator>
                        <%--<asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server" TargetControlID="Txt_imprimecalculo" ValidChars="01">
                        </asp:FilteredTextBoxExtender>--%>
                    </td>
                    <td class="style13">
                        <asp:Label ID="Label16" runat="server" Text="0= NO." Font-Size="X-Small"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="Label17" runat="server" Text="1= SI." Font-Size="X-Small"></asp:Label>
                    </td>
                </tr>
            </table>
        
        </div>
        <div class="form-group">
        
            <table class="style6">
                <tr>
                    <td class="style9">
                        <asp:Label ID="Label18" runat="server" Text="Recorrido Nº:"></asp:Label>
                        &nbsp;<asp:TextBox ID="Txt_recorrido" runat="server" Width="70px" MaxLength="2" onkeydown="tecla_op(event);" onkeypress="return justNumbers(event);"></asp:TextBox>
                        <asp:Label ID="lb_error_recorrido" runat="server" ForeColor="Red" Text="*" 
                            Visible="False"></asp:Label>
                        
                    </td>
                    <td>
                        <asp:Label ID="Label19" runat="server" Text="Orden Nº:"></asp:Label>
                        &nbsp;<asp:TextBox ID="Txt_orden" runat="server" Width="70px" MaxLength="3" onkeydown="tecla_op(event);" onkeypress="return justNumbers(event);"></asp:TextBox>
                        <asp:Label ID="lb_error_orden" runat="server" ForeColor="Red" Text="*" 
                            Visible="False"></asp:Label>
                        
                    </td>
                </tr>
            </table>
        
        </div>
        <div class="form-group">
        
            <table class="style6">
                <tr>
                    <td class="style17">
                        <asp:Label ID="Label22" runat="server" Text="Variable:" ></asp:Label>
                        &nbsp;<asp:TextBox ID="Txt_variable" runat="server" Width="70px" CausesValidation="True" validationgroup="check_7" xmlns:asp="#unknown7" MaxLength="1" onkeydown="tecla_op(event);" onkeypress="return solo_ceroyuno_valitation(event);" ></asp:TextBox>
                        <asp:Label ID="lb_error_variable" runat="server" ForeColor="Red" Text="*" 
                            Visible="False"></asp:Label>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator9" runat="server" ControlToValidate="Txt_variable" ErrorMessage="Error!" Font-Size="X-Small" ForeColor="Red" SetFocusOnError="True" ValidationExpression="[01]" ValidationGroup="check_7" xmlns:asp="#unknown7"></asp:RegularExpressionValidator>
                        <%--<asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender5" runat="server" TargetControlID="Txt_variable" ValidChars="01">
                        </asp:FilteredTextBoxExtender>--%>
                    </td>
                    <td class="style13">
                        <asp:Label ID="Label20" runat="server" Text="0= NO." Font-Size="X-Small"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="Label21" runat="server" Text="1= SI." Font-Size="X-Small"></asp:Label>
                    </td>
                </tr>
            </table>
        
        </div>
        <div class="form-group">
        
            <table class="style6">
                <tr>
                    <td>
                        <asp:Label ID="Label23" runat="server" Text="Leyenda:"></asp:Label>
                        &nbsp;<asp:TextBox ID="Txt_leyenda" runat="server" Width="200px" MaxLength="40" onkeydown="tecla_op(event);"></asp:TextBox>
                        <asp:Label ID="lb_error_leyenda" runat="server" ForeColor="Red" Text="*" 
                            Visible="False"></asp:Label>
                    </td>
                </tr>
            </table>
        
        </div>
        <div class="form-group">
            <table class="style6">
                <tr>
                    <td class="style18">
                        <asp:Label ID="Label24" runat="server" Text="Variable1:" ></asp:Label>
                        &nbsp;<asp:TextBox ID="Txt_variable1" runat="server" Width="70px" CausesValidation="True" validationgroup="check_8" xmlns:asp="#unknown8" MaxLength="1" onkeydown="tecla_op(event);" onkeypress="return solo_ceroyuno_valitation(event);"></asp:TextBox>
                        <asp:Label ID="lb_error_variable1" runat="server" ForeColor="Red" Text="*" 
                            Visible="False"></asp:Label>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator10" runat="server" ControlToValidate="Txt_variable1" ErrorMessage="Error!" Font-Size="X-Small" ForeColor="Red" SetFocusOnError="True" ValidationExpression="[01]" ValidationGroup="check_8" xmlns:asp="#unknown8"></asp:RegularExpressionValidator>
                        
                        <%--<asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender6" runat="server" TargetControlID="Txt_variable1" ValidChars="01">
                        </asp:FilteredTextBoxExtender>--%>
                    </td>
                    <td class="style13">
                        <asp:Label ID="Label25" runat="server" Text="0= NO." Font-Size="X-Small"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="Label26" runat="server" Text="1= SI." Font-Size="X-Small"></asp:Label>
                    </td>
                </tr>
            </table>
        
        </div>
        <div class="form-group">
            <table class="style6">
                <tr>
                    <td>
                        <asp:Label ID="Label27" runat="server" Text="Leyenda1:"></asp:Label>
                        &nbsp;<asp:TextBox ID="Txt_leyenda1" runat="server" Width="200px" MaxLength="40" onkeydown="tecla_op(event);"></asp:TextBox>
                        <asp:Label ID="lb_error_leyenda1" runat="server" ForeColor="Red" Text="*" 
                            Visible="False"></asp:Label>
                        <br />
                        <br />
                        <asp:Label ID="Lb_error_validacion" runat="server" Font-Bold="True" 
                           ForeColor="Red" Text="Error!" Visible="False"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
        </div>
</div>
</div>
    
</div>
</div>
</div>
</form>
</div>


<div class="card-footer">
        <div class="row justify-content-center" >
        

         <div class="row align-items-center">
            
                <div class="form-group">
                  <button type="submit" UseSubmitBehavior="false" class="btn btn-primary" runat="server" id="btn_retroceder" onkeydown="tecla_op_botones(event);">ESC = RETROCEDE</button>
                    &nbsp;</div>
                      
                        <div class="form-group">
                            <button type="button" Class="btn btn-primary" data-toggle="modal" data-target="#Mdl_baja" onkeydown="tecla_op_botones(event);">F4 = DAR DE BAJA</button>
                            &nbsp;</div>  
            
            
                      <div class="form-group">
                                <button type="button" Class="btn btn-primary" id = "BOTON_GRABA" runat="server" onkeydown="tecla_op_botones(event);">F8 = GRABA</button>
        
                            </div>
            
            
            
                  
            
         </div>

        </div>
        

<%--<form role="form">
              <div class="card-body"> 
              <div class="row">
                <div class="col-sm-4" align="center"></div>
                <div class="col-sm-4" align="center">
                    
                      
    
                </div>
                <div class="col-sm-4" align="center"></div>
                </div>
              </div>
</form>--%>
</div>


<div class="modal fade" id="modal-graba">
        <div class="modal-dialog">
          <div class="modal-content bg-primary">
            <div class="modal-header">
              <h4 class="modal-title">Graba</h4>
              <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                <span aria-hidden="true">&times;</span></button>
            </div>
            <div class="modal-body">
              <p>¿Confirma la operación?&hellip;</p>
            </div>
            <div class="modal-footer justify-content-between">
              <button type="button"    class="btn btn-outline-light" data-dismiss="modal">Cancelar</button>
              <button type="button" id="btn_graba_modal" runat="server"  class="btn btn-outline-light" data-dismiss="modal">Confirmar</button>
            </div>
          </div>
          <!-- /.modal-content -->
        </div>
        <!-- /.modal-dialog -->
      </div>
      <!-- /.modal -->

<div class="modal fade" id="modal-baja" data-backdrop="static" data-keyboard="false">
        <div class="modal-dialog">
          <div class="modal-content bg-primary">
            <div class="modal-header">
              <h4 class="modal-title">Dar de Baja</h4>
              <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                <span aria-hidden="true">&times;</span></button>
            </div>
            <div class="modal-body">
              <p>¿Confirma la operación?&hellip;</p>
            </div>
            <div class="modal-footer justify-content-between">
              <button type="button"    class="btn btn-outline-light" data-dismiss="modal">Cancelar</button>
              <button type="button" id="btn_baja_modal" runat="server"  class="btn btn-outline-light" data-dismiss="modal">Confirmar</button>
            </div>
          </div>
          <!-- /.modal-content -->
        </div>
        <!-- /.modal-dialog -->
      </div>
      <!-- /.modal -->


<!-- Modal BAJA CENTRADO EN PANTALLA -->
<div class="modal fade" id="Mdl_baja" tabindex="-1" role="dialog" aria-labelledby="exampleModalCenterTitle" aria-hidden="true" data-backdrop="static" data-keyboard="false">
  <div class="modal-dialog modal-dialog-centered" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <h5 class="modal-title" id="H1">Dar de Baja</h5>
        <button type="button" id="btn_baja_close" class="close" runat="server" tabindex="-1" data-dismiss="modal" aria-label="Close">
          <span aria-hidden="true">&times;</span>
        </button>
      </div>
      <div class="modal-body">
        ¿Confirma la operación?...
      </div>
      <div class="modal-footer">
        <button type="button" id="btn_baja_mdl_cancelar" class="btn btn-secondary" runat="server" data-dismiss="modal">Cancelar</button>
        <button type="button" id="btn_baja_mdll" class="btn btn-primary" runat="server" data-dismiss="modal">Confirmar</button>
      </div>
    </div>
  </div>
</div>

<%--Modal MENSAJE OK GRABADO--%>
<div class="modal fade" id="modal-sm_OKGRABADO" tabindex="-1" role="dialog" aria-labelledby="exampleModalCenterTitle" aria-hidden="true" data-backdrop="static" data-keyboard="false">
        <div class="modal-dialog modal-sm modal-dialog-centered " role="document">
          <div class="modal-content">
            <div class="modal-header">
              <h4 class="modal-title">Graba</h4>
              <button type="button" id="btn_graba_close" runat="server" class="close" tabindex="-1" data-dismiss="modal" aria-label="Close">
                <span aria-hidden="true">&times;</span>
              </button>
            </div>
            <div class="modal-body">
              <p>Se guardo correctamente!&hellip;</p>
            </div>
            <div class="modal-footer justify-content-center ">
            <%--<div class="modal-footer justify-content-between">--%>
              <%--<button type="button" class="btn btn-default" data-dismiss="modal">Close</button>--%>
              <button type="button" id="btn_ok" runat="server" class="btn btn-primary" data-dismiss="modal">OK</button>
            </div>
          </div>
          <!-- /.modal-content -->
        </div>
        <!-- /.modal-dialog -->
      </div>
      <!-- /.modal -->

</ContentTemplate>
</asp:UpdatePanel>
</asp:Content>
