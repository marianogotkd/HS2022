<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Home.Master" CodeBehind="Cliente_alta_b.aspx.vb" Inherits="Presentacion.Cliente_alta_b" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
    //funcion para seleccionar todo le contenido de un textbox cuando se pone el foco sobre el control. se agrega como atributo en el codebehind
    function seleccionarTexto(obj) {
        if (obj != null) {
            obj.select();
        }
    }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="True"></asp:ScriptManager>
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
    <div class="col-lg-12">
    <div class="card">

    <div class="card-body">
        <div class="form-group">
                <div class="row justify-content-center">
                    <div class="col-md-4">
                            <asp:HiddenField ID="HF_cliente_id" runat="server" />
                            <label for="Label_cliente_id">Cliente:</label>
                            <asp:TextBox ID="Txt_cliente_codigo" runat="server" 
                                placeholder="Ingrese código..." class="form-control" 
                                onkeydown="tecla_op(event);" onkeypress="return justNumbers(event);" 
                                MaxLength="4"></asp:TextBox>
                            <asp:Label ID="lb_error_codigo" runat="server" ForeColor="Red" Text="*" 
                            Visible="false"></asp:Label>
                            <small id="emailHelp" runat="server" visible=false  class="form-text text-muted">Error, ingrese el dato solicitado.</small>
                    </div>
                    <div class="col-md-4">
                            <%--<label for="Label_cliente_id">DNI:</label>
                            <asp:TextBox ID="Txt_dni" runat="server" MaxLength="9" placeholder="Ingrese DNI..." class="form-control" CausesValidation="True" onkeydown="tecla_op(event);" onkeypress="return justNumbers(event);"></asp:TextBox>
                            <asp:Label ID="lb_error_dni" runat="server" ForeColor="Red" Text="*" Visible="False"></asp:Label>
                            <small id="Small2" runat="server" visible=false class="form-text text-muted">Error, ingrese el dato solicitado.</small>--%>
                    </div>
                </div>

        </div>
        
        
        
        <div class="form-group">
        <div class="row justify-content-center">
        <div class="col-md-4">
                <label for="Label_cliente_nomb">Nombre:</label>
                <asp:TextBox ID="Txt_cliente_nomb" runat="server" placeholder="Ingrese nombre..." class="form-control" MaxLength="50" onkeydown="tecla_op(event);"></asp:TextBox>
                <asp:Label ID="lb_error_nombre" runat="server" ForeColor="Red" Text="*" 
                            Visible="False"></asp:Label>
                <small id="Small1" runat="server" visible=false class="form-text text-muted">Error, ingrese el dato solicitado.</small>
        </div>
        <div class="col-md-4">
                <label for="Label_cliente_id">Grupo:</label>
                <asp:DropDownList ID="DropDownList_grupos" runat="server" class="form-control" onkeydown="tecla_op(event);"></asp:DropDownList>
                <asp:Label ID="lb_error_grupo" runat="server" ForeColor="Red" Text="*error, seleccione grupo" 
                            Visible="False"></asp:Label>
                <small id="Small2" runat="server" visible=false class="form-text text-muted">Error, seleccione grupo.</small>
        </div>
        </div>
        </div>
                   
              
        <div class="form-group">
                <div class="row justify-content-center">
                    <div class="col-md-2">
                            <label for="Label_comision">% Comision:</label>
                            <asp:TextBox ID="Txt_comision" runat="server" class="form-control" placeholder="0 %" CausesValidation="True" validationgroup="check_2" xmlns:asp="#unknown2" MaxLength="6" onkeydown="tecla_op(event);" onkeypress="return justNumbers(event);"></asp:TextBox>
                            <asp:Label ID="lb_error_comision" runat="server" ForeColor="Red" Text="*" 
                            Visible="False"></asp:Label>
                            <small id="Small3" runat="server" visible=false class="form-text text-muted">Error, ingrese el dato solicitado.</small>
                            <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
                            ControlToValidate="Txt_comision" ErrorMessage="Error!" Font-Size="X-Small" 
                            ForeColor="Red" SetFocusOnError="True" 
                            ValidationExpression="^\d+\.\d{1,2}$|^\d+\,\d{1,2}$|^\d+$" 
                            ValidationGroup="check_2" xmlns:asp="#unknown2"></asp:RegularExpressionValidator>--%>
                    </div>
                    <div class="col-md-2">
                            <label for="Label_regalo">% Regalo:</label>
                            <asp:TextBox ID="Txt_regalo" runat="server" class="form-control" placeholder="0 %" CausesValidation="True" validationgroup="check_2" xmlns:asp="#unknown2" MaxLength="6" onkeydown="tecla_op(event);" onkeypress="return justNumbers(event);"></asp:TextBox>
                            <small id="Small4" runat="server" visible=false class="form-text text-muted">Error, ingrese el dato solicitado.</small>
                            <asp:Label ID="lb_error_regalo" runat="server" ForeColor="Red" Text="*" 
                            Visible="False"></asp:Label>
                            <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" 
                            ControlToValidate="Txt_regalo" ErrorMessage="Error!" Font-Size="X-Small" 
                            ForeColor="Red" SetFocusOnError="True" 
                            ValidationExpression="^\d+\.\d{1,2}$|^\d+\,\d{1,2}$|^\d+$" 
                            ValidationGroup="check_2" xmlns:asp="#unknown2"></asp:RegularExpressionValidator>--%>
                    </div>
                    <div class="col-md-2">
                                    <label for="Label_comision">% Comision1:</label>
                                    <asp:TextBox ID="Txt_comision1" runat="server" CausesValidation="True" 
                                    validationgroup="check_2" class="form-control" placeholder="0 %" xmlns:asp="#unknown2" MaxLength="6" onkeydown="tecla_op(event);" onkeypress="return justNumbers(event);"></asp:TextBox>
                                    <small id="Small13" runat="server" visible=false class="form-text text-muted">Error, ingrese el dato solicitado.</small>
                                    <asp:Label ID="lb_error_comision1" runat="server" ForeColor="Red" Text="*" 
                                    Visible="False"></asp:Label>
                                    <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" 
                                    ControlToValidate="Txt_comision1" ErrorMessage="Error!" Font-Size="X-Small" 
                                    ForeColor="Red" SetFocusOnError="True" 
                                    ValidationExpression="^\d+\.\d{1,2}$|^\d+\,\d{1,2}$|^\d+$" 
                                    ValidationGroup="check_2" xmlns:asp="#unknown2"></asp:RegularExpressionValidator>--%>
                    </div>

                    <div class="col-md-2">
                            <label for="Label_comision">% Regalo1:</label>
                            <asp:TextBox ID="Txt_regalo1" runat="server" CausesValidation="True" 
                            validationgroup="check_2" class="form-control" placeholder="0 %" xmlns:asp="#unknown2" MaxLength="6" onkeydown="tecla_op(event);" onkeypress="return justNumbers(event);"></asp:TextBox>
                            <small id="Small14" runat="server" visible=false class="form-text text-muted">Error, ingrese el dato solicitado.</small>
                            <asp:Label ID="lb_error_regalo1" runat="server" ForeColor="Red" Text="*" 
                            Visible="False"></asp:Label>
                            <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" 
                            ControlToValidate="Txt_regalo1" ErrorMessage="Error!" Font-Size="X-Small" 
                            ForeColor="Red" SetFocusOnError="True" 
                            ValidationExpression="^\d+\.\d{1,2}$|^\d+\,\d{1,2}$|^\d+$" 
                            ValidationGroup="check_2" xmlns:asp="#unknown2"></asp:RegularExpressionValidator>--%>
                    </div>
                </div>

        </div>
        <div class="form-group">
                <div class="row justify-content-center">
                        <div class="col-md-2">
                        <label for="Label_proceso">Proceso:</label>
                        <asp:DropDownList ID="DropDownList_proceso" runat="server" class="form-control" onkeydown="tecla_op(event);"></asp:DropDownList>
                        <%--<asp:TextBox ID="Txt_proceso" runat="server" class="form-control" placeholder="ingrese opción"
                         
                        CausesValidation="True" validationgroup="check_3" xmlns:asp="#unknown3" 
                        MaxLength="1" onkeydown="tecla_op(event);" onkeypress="return proceso_validation(event);"></asp:TextBox>--%>
                        <small id="Small5" class="form-text text-muted">D=diario. S=semana. M=mensual.</small>
                        <asp:Label ID="lb_error_proceso" runat="server" ForeColor="Red" Text="*" 
                        Visible="False"></asp:Label>
                        <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="Txt_proceso" ErrorMessage="Error!" Font-Size="X-Small" ForeColor="Red" SetFocusOnError="True" ValidationExpression="[DSMdsm]" ValidationGroup="check_3" xmlns:asp="#unknown3"></asp:RegularExpressionValidator>--%>
                        
                        </div>

                        <div class="col-md-2">
                        <label for="Label_proceso">Calculo:</label>
                        <asp:DropDownList ID="DropDownList_calculo" runat="server" class="form-control" onkeydown="tecla_op(event);">
                            <asp:ListItem Selected="True" Value="0">0 - NO</asp:ListItem>
                            <asp:ListItem Value="1">1 - SI</asp:ListItem>
                            </asp:DropDownList>
                        <%--<asp:TextBox ID="Txt_calculo" runat="server" class="form-control" placeholder="ingrese opción" CausesValidation="True" validationgroup="check_4" xmlns:asp="#unknown4" MaxLength="1" onkeydown="tecla_op(event);" onkeypress="return solo_ceroyuno_valitation(event);"></asp:TextBox>--%>
                        <small id="Small6" class="form-text text-muted">0 = NO. 1 = SI.</small>
                        <asp:Label ID="lb_error_calculo" runat="server" ForeColor="Red" Text="*" 
                            Visible="False"></asp:Label>
                        <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ControlToValidate="Txt_calculo" ErrorMessage="Error!" Font-Size="X-Small" ForeColor="Red" SetFocusOnError="True" ValidationExpression="[01]" ValidationGroup="check_4" xmlns:asp="#unknown4"></asp:RegularExpressionValidator>                      --%>
                        
                        </div>

                        <div class="col-md-2">
                        <label for="Label_factor">Factor:</label>
                        <asp:DropDownList ID="DropDownList_factor" runat="server" class="form-control" onkeydown="tecla_op(event);">
                            <asp:ListItem Selected="True" Value="0">0 - NO</asp:ListItem>
                            <asp:ListItem Value="1">1 - SI</asp:ListItem>
                            </asp:DropDownList>
                        <%--<asp:TextBox ID="Txt_factor" runat="server" class="form-control" placeholder="ingrese opción" CausesValidation="True" validationgroup="check_6" xmlns:asp="#unknown6" MaxLength="1" onkeydown="tecla_op(event);" onkeypress="return solo_ceroyuno_valitation(event);"></asp:TextBox>--%>
                        <small id="Small7" class="form-text text-muted">0 = sin factor. 1 = con factor.</small>
                        <asp:Label ID="lb_error_factor" runat="server" ForeColor="Red" Text="*" 
                            Visible="False"></asp:Label>
                        <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator8" runat="server" ControlToValidate="Txt_factor" ErrorMessage="Error!" Font-Size="X-Small" ForeColor="Red" SetFocusOnError="True" ValidationExpression="[01]" ValidationGroup="check_6" xmlns:asp="#unknown6"></asp:RegularExpressionValidator>--%>
                        </div>

                        <div class="col-md-2">
                        <label for="Label_factor">Imprime calculo:</label>
                        <asp:DropDownList ID="DropDownList_imprimecalculo" runat="server" class="form-control" onkeydown="tecla_op(event);">
                            <asp:ListItem Selected="True" Value="0">0 - NO</asp:ListItem>
                            <asp:ListItem Value="1">1 - SI</asp:ListItem>
                            </asp:DropDownList>
                        <%--<asp:TextBox ID="Txt_imprimecalculo" runat="server" class="form-control" placeholder="ingrese opción" CausesValidation="True" validationgroup="check_5" xmlns:asp="#unknown5" MaxLength="1" onkeydown="tecla_op(event);" onkeypress="return solo_ceroyuno_valitation(event);"></asp:TextBox>--%>
                        <small id="Small8" class="form-text text-muted">0 = NO. 1 = SI.</small>
                        <asp:Label ID="lb_error_imprimecalculo" runat="server" ForeColor="Red" Text="*" 
                            Visible="False"></asp:Label>
                        <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" ControlToValidate="Txt_imprimecalculo" ErrorMessage="Error!" Font-Size="X-Small" ForeColor="Red" SetFocusOnError="True" ValidationExpression="[01]" ValidationGroup="check_5" xmlns:asp="#unknown5"></asp:RegularExpressionValidator>--%>
                        </div>

                </div>

        </div>


        <div class="form-group">
                <div class="row justify-content-center">
                        <div class="col-md-4">
                        <label for="Label_factor">Recorrido Nº:</label>
                        <asp:TextBox ID="Txt_recorrido" runat="server" class="form-control" placeholder="Ingrese Nº..." MaxLength="2" onkeydown="tecla_op(event);" onkeypress="return justNumbers(event);"></asp:TextBox>
                        <asp:Label ID="lb_error_recorrido" runat="server" ForeColor="Red" Text="*" 
                            Visible="False"></asp:Label>
                        <small id="Small9" runat="server" visible=false class="form-text text-muted">Error, ingrese el dato solicitado.</small>
                        </div>

                        <div class="col-md-4">
                        <label for="Label_orden">Orden Nº:</label>
                        <asp:TextBox ID="Txt_orden" runat="server" class="form-control" placeholder="Ingrese Nº..." MaxLength="3" onkeydown="tecla_op(event);" onkeypress="return justNumbers(event);"></asp:TextBox>
                        <asp:Label ID="lb_error_orden" runat="server" ForeColor="Red" Text="*" 
                            Visible="False"></asp:Label>
                        <small id="Small10" runat="server" visible=false class="form-text text-muted">Error, ingrese el dato solicitado.</small>
                        </div>
                </div>
        </div>

        <div class="form-group">
               <div class="row justify-content-center">
                        <div class="col-md-2">
                        <label for="Label_variable">Variable:</label>
                        <asp:DropDownList ID="DropDownList_variable" runat="server" class="form-control" onkeydown="tecla_op(event);">
                            <asp:ListItem Selected="True" Value="0">0 - NO</asp:ListItem>
                            <asp:ListItem Value="1">1 - SI</asp:ListItem>
                            </asp:DropDownList>
                        <%--<asp:TextBox ID="Txt_variable" runat="server" class="form-control" placeholder="Ingrese opción..." CausesValidation="True" validationgroup="check_7" xmlns:asp="#unknown7" MaxLength="1" onkeydown="tecla_op(event);" onkeypress="return solo_ceroyuno_valitation(event);" ></asp:TextBox>--%>
                        <small id="Small11" class="form-text text-muted">0 = NO. 1 = SI.</small>
                        <asp:Label ID="lb_error_variable" runat="server" ForeColor="Red" Text="*" 
                            Visible="False"></asp:Label>
                        <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator9" runat="server" ControlToValidate="Txt_variable" ErrorMessage="Error!" Font-Size="X-Small" ForeColor="Red" SetFocusOnError="True" ValidationExpression="[01]" ValidationGroup="check_7" xmlns:asp="#unknown7"></asp:RegularExpressionValidator>--%>
                        </div>

                        <div class="col-md-6">
                        <label for="Label_leyenda">Leyenda1:</label>
                        <asp:TextBox ID="Txt_leyenda" runat="server" class="form-control" placeholder="" MaxLength="40" onkeydown="tecla_op(event);"></asp:TextBox>
                        <asp:Label ID="lb_error_leyenda" runat="server" ForeColor="Red" Text="*" 
                            Visible="False"></asp:Label>
                        </div>
               </div>
        </div>

        <div class="form-group">
               <div class="row justify-content-center">
                        <div class="col-md-2">
                        <label for="Label_variable1">Variable1:</label>
                        <asp:DropDownList ID="DropDownList_variable1" runat="server" class="form-control" onkeydown="tecla_op(event);">
                            <asp:ListItem Selected="True" Value="0">0 - NO</asp:ListItem>
                            <asp:ListItem Value="1">1 - SI</asp:ListItem>
                            </asp:DropDownList>
                        <%--<asp:TextBox ID="Txt_variable1" runat="server" class="form-control" placeholder="Ingrese opción..." CausesValidation="True" validationgroup="check_8" xmlns:asp="#unknown8" MaxLength="1" onkeydown="tecla_op(event);" onkeypress="return solo_ceroyuno_valitation(event);"></asp:TextBox>--%>
                        <small id="Small12" class="form-text text-muted">0 = NO. 1 = SI.</small>
                        <asp:Label ID="lb_error_variable1" runat="server" ForeColor="Red" Text="*" 
                            Visible="False"></asp:Label>
                        <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator10" runat="server" ControlToValidate="Txt_variable1" ErrorMessage="Error!" Font-Size="X-Small" ForeColor="Red" SetFocusOnError="True" ValidationExpression="[01]" ValidationGroup="check_8" xmlns:asp="#unknown8"></asp:RegularExpressionValidator>--%>
                        </div>

                        <div class="col-md-6">
                        <label for="Label_leyenda1">Leyenda2:</label>
                        <asp:TextBox ID="Txt_leyenda1" runat="server" class="form-control" placeholder="" MaxLength="40" onkeydown="tecla_op(event);"></asp:TextBox>
                        <asp:Label ID="lb_error_leyenda1" runat="server" ForeColor="Red" Text="*" 
                            Visible="False"></asp:Label>
                        </div>
               </div>               
        </div>

        <div class="form-group">
        <div class="row justify-content-center">
        <div class="col-md-8">
        <asp:Label ID="Lb_error_validacion" runat="server" Font-Bold="True" 
                           ForeColor="Red" Text="Error!" Visible="False"></asp:Label>
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


      <%--Modal MENSAJE OK ERROR ELIMINAR--%>
<div class="modal fade" id="modal_sn_okerror_eliminar" tabindex="-1" role="dialog" aria-labelledby="exampleModalCenterTitle" aria-hidden="true" data-backdrop="static" data-keyboard="false">
        <div class="modal-dialog modal-sm modal-dialog-centered " role="document">
          <div class="modal-content">
            <div class="modal-header">
              <h4 class="modal-title">Error</h4>
              <button type="button" id="btn_error_eliminar_close" runat="server" class="close" tabindex="-1" data-dismiss="modal" aria-label="Close">
                <span aria-hidden="true">&times;</span>
              </button>
            </div>
            <div class="modal-body">
              <p>No se puede eliminar, el cliente posee saldo!&hellip;</p>
            </div>
            <div class="modal-footer justify-content-center ">
            <%--<div class="modal-footer justify-content-between">--%>
              <%--<button type="button" class="btn btn-default" data-dismiss="modal">Close</button>--%>
              <button type="button" id="btn_ok_erroreliminar" runat="server" class="btn btn-primary" data-dismiss="modal">OK</button>
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
