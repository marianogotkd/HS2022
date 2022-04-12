<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Home.Master" CodeBehind="Cobro_prestamos_manuales_det.aspx.vb" Inherits="Presentacion.Cobro_prestamos_manuales_det" %>
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
        ///se anula el enter Y PASO AL BOTON DE GRABA
        if (keycode == '13') {
            e.preventDefault();

        }


        //F8 GRABA
        if (keycode == '119') {
            e.preventDefault();
            document.getElementsByTagName('button')[1].focus();
            document.getElementsByTagName('button')[1].click();
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


        //F8 GRABA
        if (keycode == '119') {
            e.preventDefault();
            document.getElementsByTagName('button')[1].focus();
            document.getElementsByTagName('button')[1].click();
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
                <h3 class="card-title">COBRO DE PRESTAMOS MANUALES.</h3>
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
                                    <asp:Label ID="Label1" runat="server" Text="CLIENTE Nº:"></asp:Label>
                                    <asp:Label ID="Label_cliente_codigo" runat="server" Text=""></asp:Label>
                                    <asp:HiddenField ID="HF_Idpredtamocredito" runat="server" />
                                </div>


                                <div class="col-md-4">
                                    <asp:Label ID="Label2" runat="server" Text="FECHA DEL PRESTAMO:"></asp:Label>
                                    <asp:Label ID="Label_fecha_prestamo" runat="server" Text=""></asp:Label>
                                </div>
                                </div>
                </div>
                <div class="form-group">       
                                <div class="row justify-content-center">
                                <div class="col-md-8">    
                                    <asp:Label ID="Label3" runat="server" Text="SALDO DEL PRESTAMO:"></asp:Label>
                                    <asp:Label ID="Label_saldoprestamo" runat="server" Text=""></asp:Label>
                                    
                                </div>


                </div>
                
                
                
                <div class="form-group">       
                                <div class="row justify-content-center">
                                        <div class="col-md-4">
                                                <label for="Label_cliente_id">IMPORTE A COBRAR:</label>
                                                <div class="input-group" >
                                                <asp:TextBox ID="Txt_importe_cobrar" runat="server" class="form-control" placeholder="0,00" CausesValidation="True" validationgroup="check_2" xmlns:asp="#unknown2" MaxLength="17" onkeydown="tecla_op(event);" onkeypress="return validateDecimalKeyPress(this, event);"></asp:TextBox>
                                                                                           
                                                
                                                </div>
                                                                                     
                                                
                                                
                                        </div>
                                        <div class="col-md-4">
                                        </div>
                                        <%--<div class="col-md-2">
                                        
                                        </div>--%>
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
        ¿Desea registrar el cobro?...
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
              <p>Ingrese un importe válido!&hellip;</p>
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



</ContentTemplate>
</asp:UpdatePanel>
</asp:Content>
