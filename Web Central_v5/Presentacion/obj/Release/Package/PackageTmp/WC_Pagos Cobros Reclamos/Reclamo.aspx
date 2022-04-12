<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Home.Master" CodeBehind="Reclamo.aspx.vb" Inherits="Presentacion.Reclamo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script>
    //funcion que reconoce teclas para ir a los botones retroceso, baja y graba
    function tecla_op(e) {
        var keycode = e.keyCode;
        ///ESC RETROCEDE
        if (keycode == '27') {
            e.preventDefault();
            document.getElementsByTagName('button')[1].focus();
            document.getElementsByTagName('button')[1].click();

        }
        ///se anula el enter Y PASO AL BOTON DE GRABA
        if (keycode == '13') {
            e.preventDefault();

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
            document.getElementsByTagName('button')[1].focus();
            document.getElementsByTagName('button')[1].click();

        }
        //        ///no voy a anular el ENTER
        //        if (keycode == '13') {
        //            e.preventDefault();
        //        }


        //F8 GRABA
        if (keycode == '119') {
            e.preventDefault();
            document.getElementsByTagName('button')[2].focus();
            document.getElementsByTagName('button')[2].click();
        }
    }


    //funcion que reconoce teclas ENTER, EL BOTON DE BUSQUEDA, ESC Y GRABA...SOLO LO VOY A USAR EN LOS TEXTBOX CLIENTE Y FECHA.
    function tecla_op_BUSQUEDA(e) {
        var keycode = e.keyCode;
        ///ESC RETROCEDE
        if (keycode == '27') {
            e.preventDefault();
            document.getElementsByTagName('button')[1].focus();
            document.getElementsByTagName('button')[1].click();

        }
        ///se anula el enter Y PASO AL BOTON DE GRABA
        if (keycode == '13') {
            e.preventDefault();
            document.getElementsByTagName('button')[0].focus();
            document.getElementsByTagName('button')[0].click();
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
                <h3 class="card-title">CARGA PAGOS/COBROS/RECLAMOS.</h3>
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
                                    <div class="col-md-8">
                                        <label for="Label_cliente_id">OPCION 1: CARGA DE RECLAMO.</label> 
                                    </div>
                                    <%--<div class="col-md-4">
                                    </div>--%>
                            </div>
                    </div>
                    <div class="form-group">       
                                <div class="row justify-content-center">
                                        <div class="col-md-4">
                                                <label for="Label_cliente_id">Cliente:</label>
                                                <div class="input-group" >
                                                <asp:TextBox ID="Txt_cliente_codigo" placeholder="Ingrese código..." 
                                                        onkeydown="tecla_op_BUSQUEDA(event);" runat="server" name="table_search" 
                                                        class="form-control float-right" onkeypress="return justNumbers(event);" 
                                                        MaxLength="4"></asp:TextBox>
                                                <div class="input-group-append">
                                                <button type="submit" id="btn_buscar" runat="server" class="btn btn-default" onkeydown="tecla_op_botones(event);"><i class="fas fa-search"></i></button>
                                                </div>
                                                </div>
                                                                                               
                                                <asp:Label ID="lb_error_codigo" runat="server" ForeColor="Red" Text="*" Visible="false"></asp:Label>
                                                
                                        </div>
                                        <div class="col-md-4">
                                        </div>
                                        <%--<div class="col-md-2">
                                        
                                        </div>--%>
                                </div>
                     </div>
                     <div class="form-group">       
                                <div class="row justify-content-center">
                                        <div class="col-md-4">
                                                <label for="Label_nombre">Nombre:</label>
                                                 <asp:TextBox ID="Txt_nombre" runat="server" class="form-control" CausesValidation="True" validationgroup="check_2" xmlns:asp="#unknown2" onkeydown="tecla_op(event);"></asp:TextBox>              
                                                                                              
                                                
                                        </div>
                                        <div class="col-md-4">
                                                <label for="Label_saldo">Saldo $:</label>
                                                 <asp:TextBox ID="Txt_saldo" runat="server" class="form-control" CausesValidation="True" validationgroup="check_2" xmlns:asp="#unknown2" onkeydown="tecla_op(event);"></asp:TextBox>              
                                        
                                        </div>
                                </div>
                     </div>
                     <div class="form-group">       
                                <div class="row justify-content-center">
                                        <div class="col-md-4">
                                               <label for="Label_importe">Importe $:</label>
                                                <asp:TextBox ID="Txt_importe" runat="server" class="form-control" placeholder="0,00" CausesValidation="True" validationgroup="check_2" xmlns:asp="#unknown2" MaxLength="17" onkeydown="tecla_op(event);" onkeypress="return validateDecimalNegativoKeyPress(this, event);"></asp:TextBox>
                                                <asp:Label ID="lb_error_importe" runat="server" ForeColor="Red" Text="*" Visible="False"></asp:Label>
                                                
                                        </div>
                                        <div class="col-md-4">
                                            
                                        </div>
                                </div>
                        </div>
                        <div class="form-group">       
                                <div class="row justify-content-center">
                                        <div class="col-md-4">
                                                <label for="Label_sincalculo">Sin Calculo:</label>
                                                <asp:DropDownList ID="DropDownList_sincalculo" runat="server" class="form-control" onkeydown="tecla_op(event);">
                                                <asp:ListItem Selected="True" Value="0">0 - NO</asp:ListItem>
                                                <asp:ListItem Value="1">1 - SI</asp:ListItem>
                                                </asp:DropDownList>
                                                
                                                <%--<asp:TextBox ID="Txt_calculo" runat="server" class="form-control" placeholder="ingrese opción" CausesValidation="True" validationgroup="check_4" xmlns:asp="#unknown4" MaxLength="1" onkeydown="tecla_op(event);" onkeypress="return solo_ceroyuno_valitation(event);"></asp:TextBox>--%>
                                                <small id="smalllabel_calculo" class="form-text text-muted">0 = NO. 1 = SI.</small>
                                                <asp:Label ID="lb_error_sincalculo" runat="server" ForeColor="Red" Text="*" Visible="False"></asp:Label>
                                        </div>

                                        <div class="col-md-4">
                                                
                            
                                        </div>
                                </div>
                        </div>
                                                
                        <div class="form-group">       
                                <div class="row justify-content-center">
                                        <div class="col-md-4">
                                                <label for="Label_prestamocredito">Préstamo/Crédito:</label>
                                                <asp:DropDownList ID="DropDownList_prestamocredito" runat="server" class="form-control" onkeydown="tecla_op(event);">
                                                <asp:ListItem Selected="True" Value="0">0 - PRESTAMO</asp:ListItem>
                                                <asp:ListItem Value="1">1 - CREDITO</asp:ListItem>
                                                </asp:DropDownList>
                                                <%--<asp:TextBox ID="Txt_prestamocredito" runat="server" class="form-control" placeholder="ingrese opción" CausesValidation="True" validationgroup="check_4" xmlns:asp="#unknown4" MaxLength="1" onkeydown="tecla_op(event);" onkeypress="return solo_ceroyuno_valitation(event);"></asp:TextBox>--%>
                                                <small id="Small1" class="form-text text-muted">0 = PRESTAMO. 1 = CREDITO.</small>
                                                <asp:Label ID="lb_error_prestamocredito" runat="server" ForeColor="Red" Text="*" Visible="False"></asp:Label>
                                        </div>

                                        <div class="col-md-4">
                                                
                                                
                                        </div>
                                </div>
                        </div>
                        <div class="form-group">       
                                <div class="row justify-content-center">
                                        <div class="col-md-4">
                                                <label for="Label_descripcion">Descripción:</label>
                                                <asp:TextBox ID="Txt_descripcion" runat="server" class="form-control" CausesValidation="True" validationgroup="check_2" xmlns:asp="#unknown2" onkeydown="tecla_op(event);"></asp:TextBox>              
                                                <asp:Label ID="lb_error_descripcion" runat="server" ForeColor="Red" Text="*" Visible="False"></asp:Label>
                                        </div>

                                        <div class="col-md-4">

                                        </div>
                                </div>
                        </div>
                        <div class="form-group">       
                                <div class="row justify-content-center">
                                        <div class="col-md-4">
                                                <label for="Label_descripcion">Fecha:</label>        
                                                <asp:TextBox ID="Txt_fecha" onkeydown="tecla_op(event);" class="form-control" runat="server" TextMode="Date"></asp:TextBox>
                                                <asp:Label ID="lb_error_fecha" runat="server" ForeColor="Red" Text="*" Visible="False"></asp:Label>
                                        </div>
                                        <div class="col-md-4">

                                        </div>
                                </div>
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
                                <button type="button" Class="btn btn-primary" id = "BOTON_GRABA" runat="server" onkeydown="tecla_op_botones(event);">F8 = GRABA</button>
        
                 </div>
            
         </div>

        </div>
        

</div>

<div class="modal fade" id="modal-sm_error_limite" tabindex="-1" role="dialog" aria-labelledby="exampleModalCenterTitle" aria-hidden="true" data-backdrop="static" data-keyboard="false">
        <div class="modal-dialog modal-sm modal-dialog-centered " role="document">
          <div class="modal-content">
            <div class="modal-header">
              <h4 class="modal-title">Error!</h4>
              <button type="button" id="btn_close_error_limite" runat="server" tabindex="-1" class="close" data-dismiss="modal" aria-label="Close">
                <span aria-hidden="true">&times;</span>
              </button>
            </div>
            <div class="modal-body">
              <p>Se alcanzó el limite de créditos!&hellip;</p>
            </div>
            <div class="modal-footer justify-content-center ">
            <%--<div class="modal-footer justify-content-between">--%>
              <%--<button type="button" class="btn btn-default" data-dismiss="modal">Close</button>--%>
              <button type="button" id="btn_ok_error_limite" runat="server" tabindex="1"  class="btn btn-primary" data-dismiss="modal">OK</button>
            </div>
          </div>
          <!-- /.modal-content -->
        </div>
        <!-- /.modal-dialog -->
      </div>
      <!-- /.modal -->



<div class="modal fade" id="modal-sm_error_ingreso" tabindex="-1" role="dialog" aria-labelledby="exampleModalCenterTitle" aria-hidden="true" data-backdrop="static" data-keyboard="false">
        <div class="modal-dialog modal-sm modal-dialog-centered " role="document">
          <div class="modal-content">
            <div class="modal-header">
              <h4 class="modal-title">Error!</h4>
              <button type="button" id="btn_erroringreso_close" runat="server" tabindex="-1" class="close" data-dismiss="modal" aria-label="Close">
                <span aria-hidden="true">&times;</span>
              </button>
            </div>
            <div class="modal-body">
              <p>Ingrese los datos solicitados!&hellip;</p>
            </div>
            <div class="modal-footer justify-content-center ">
            <%--<div class="modal-footer justify-content-between">--%>
              <%--<button type="button" class="btn btn-default" data-dismiss="modal">Close</button>--%>
              <button type="button" id="btn_erroringreso_ok" runat="server" tabindex="1"  class="btn btn-primary" data-dismiss="modal">OK</button>
            </div>
          </div>
          <!-- /.modal-content -->
        </div>
        <!-- /.modal-dialog -->
      </div>
      <!-- /.modal -->


<div class="modal fade" id="modal-sm_error_noexiste" tabindex="-1" role="dialog" aria-labelledby="exampleModalCenterTitle" aria-hidden="true" data-backdrop="static" data-keyboard="false">
        <div class="modal-dialog modal-sm modal-dialog-centered " role="document">
          <div class="modal-content">
            <div class="modal-header">
              <h4 class="modal-title">Error!</h4>
              <button type="button" id="btn_close_error_noexiste" runat="server" tabindex="-1" class="close" data-dismiss="modal" aria-label="Close">
                <span aria-hidden="true">&times;</span>
              </button>
            </div>
            <div class="modal-body">
              <p>El código no existe!&hellip;</p>
            </div>
            <div class="modal-footer justify-content-center ">
            <%--<div class="modal-footer justify-content-between">--%>
              <%--<button type="button" class="btn btn-default" data-dismiss="modal">Close</button>--%>
              <button type="button" id="btn_ok_error_noexiste" runat="server" tabindex="1"  class="btn btn-primary" data-dismiss="modal">OK</button>
            </div>
          </div>
          <!-- /.modal-content -->
        </div>
        <!-- /.modal-dialog -->
      </div>
      <!-- /.modal -->

<div class="modal fade" id="modal-sm_error_fecha" tabindex="-1" role="dialog" aria-labelledby="exampleModalCenterTitle" aria-hidden="true" data-backdrop="static" data-keyboard="false">
        <div class="modal-dialog modal-sm modal-dialog-centered " role="document">
          <div class="modal-content">
            <div class="modal-header">
              <h4 class="modal-title">Error!</h4>
              <button type="button" id="btn_close_error_fecha" runat="server" tabindex="-1" class="close" data-dismiss="modal" aria-label="Close">
                <span aria-hidden="true">&times;</span>
              </button>
            </div>
            <div class="modal-body">
              <p>Ingrese una fecha válida!&hellip;</p>
            </div>
            <div class="modal-footer justify-content-center ">
            <%--<div class="modal-footer justify-content-between">--%>
              <%--<button type="button" class="btn btn-default" data-dismiss="modal">Close</button>--%>
              <button type="button" id="btn_ok_error_fecha" runat="server" tabindex="1"  class="btn btn-primary" data-dismiss="modal">OK</button>
            </div>
          </div>
          <!-- /.modal-content -->
        </div>
        <!-- /.modal-dialog -->
      </div>
      <!-- /.modal -->



<!-- Modal GRABAR MODIFICACION CENTRADO EN PANTALLA -->
<div class="modal fade" id="Mdl_graba" tabindex="-1" role="dialog" aria-labelledby="exampleModalCenterTitle" aria-hidden="true" data-backdrop="static" data-keyboard="false">
  <div class="modal-dialog modal-dialog-centered" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <h5 class="modal-title" id="H2">Graba</h5>
        <button type="button" id="btn_graba_close" class="close" tabindex="-1" runat="server" data-dismiss="modal" aria-label="Close">
          <span aria-hidden="true">&times;</span>
        </button>
      </div>
      <div class="modal-body">
        ¿Desea guardar el reclamo?...
      </div>
      <div class="modal-footer">
        <button type="button" id="btn_graba_cancelar" class="btn btn-secondary" runat="server" data-dismiss="modal">Cancelar</button>
        <button type="button" id="btn_graba_confirmar" class="btn btn-primary" runat="server" data-dismiss="modal">Confirmar</button>
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
              <button type="button" id="btn_ok_close" runat="server" class="close" tabindex="-1" data-dismiss="modal" aria-label="Close">
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
