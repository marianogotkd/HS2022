<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Home.Master" CodeBehind="Iniciar_dia.aspx.vb" Inherits="Presentacion.Iniciar_dia" %>
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

    function dias_valitation(evt) {


        var charCode = (evt.which) ? evt.which : event.keyCode
        //                acepta solo 1 al 7). el caracter || es un OR


        if ((charCode == 49) || (charCode == 50) || (charCode == 51) || (charCode == 52) || (charCode == 53) || (charCode == 54) || (charCode == 55))
            return true;
        else
            return false;



    }



</script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="True"></asp:ScriptManager>
<asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
<ContentTemplate>
<div class="card card-primary">
<div class="card-header">
                <h3 class="card-title">INICIAR DIA</h3>
</div>
<form role="form">
<div class="card-body">
<div class="container-fluid">
<div class="row justify-content-center">
<div class="col-lg-6">
<div class="card">
        <div class="card-body">
                <div class="form-group">
                        <div class="row justify-content-center">
                                <div class="col-4">
                                    <%--<label for="Label_fecha">Iniciar dia:</label>--%>
                                    <asp:Label ID="Label8" runat="server" Text="Iniciar dia:"></asp:Label>
                                    <asp:TextBox ID="Txt_fecha" onkeydown="tecla_op(event);" runat="server" TextMode="Date"></asp:TextBox>
                                    <asp:Label ID="lb_error_fecha" runat="server" ForeColor="Red" Text="*" Visible="False"></asp:Label>
                                    <asp:HiddenField ID="HF_fecha" runat="server" />
                                </div>
                                <div class="col-4">
                                </div>
                        </div>                
                </div>
                <div class="form-group">
                        <div class="row justify-content-center">
                                <div class="col-4">
                                    <asp:Label ID="Label_dia" runat="server" Text="DIA:"></asp:Label>
                                    &nbsp;<asp:Label ID="DIA_recuperado" runat="server" ForeColor="#3333FF" 
                                        Visible="False"></asp:Label>
                                    <asp:TextBox ID="txt_dia" runat="server" MaxLength="1" Width="50px" onkeydown="tecla_op(event);" onkeypress="return dias_valitation(event);"></asp:TextBox>
                                </div>
                                <div class="col-4">
                                    
                                    <asp:LinkButton ID="LinkButton_Domingo" runat="server">1. Domingo</asp:LinkButton>
                                    <br />
                                    
                                    <asp:LinkButton ID="LinkButton_Lunes" runat="server">2. Lunes</asp:LinkButton>
                                    <br />
                                    
                                    <asp:LinkButton ID="LinkButton_Martes" runat="server">3. Martes</asp:LinkButton>
                                    <br />
                                    
                                    <asp:LinkButton ID="LinkButton_Miercoles" runat="server">4. Miercoles</asp:LinkButton>
                                    <br />
                                    
                                    <asp:LinkButton ID="LinkButton_Jueves" runat="server">5. Jueves</asp:LinkButton>
                                    <br />
                                    
                                    <asp:LinkButton ID="LinkButton_Viernes" runat="server">6. Viernes</asp:LinkButton>
                                    <br />
                                    
                                    <asp:LinkButton ID="LinkButton_Sabado" runat="server">7. Sabado.</asp:LinkButton>
                                </div>
                        </div>
                </div>
        </div>

        <div class="card-footer">
        <div class="row justify-content-center" >
        <div class="row align-items-center">
            <div class="form-group">
            <button type="submit" UseSubmitBehavior="false" class="btn btn-primary" runat="server" id="btn_retroceder" onkeydown="tecla_op_botones(event);">
                ESC = RETROCEDE</button>
            &nbsp;
            </div>

            

            <div class="form-group">
            <button type="button" id="BOTON_GRABAR" runat="server" class="btn btn-primary" data-toggle="modal" data-target="#Mdl_grabar" onkeydown="tecla_op_botones(event);"> <%--data-targe="#modal-primary"--%>
                  F8 = GRABA
                </button>
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

<%--MODAL MSJ CENTRADO - ERROR OPCION--%>
<div class="modal fade" id="modal-sm_error" tabindex="-1" role="dialog" aria-labelledby="exampleModalCenterTitle" aria-hidden="true" data-backdrop="static" data-keyboard="false">
        <div class="modal-dialog modal-sm modal-dialog-centered " role="document">
          <div class="modal-content">
            <div class="modal-header">
              <h4 class="modal-title">Error!</h4>
              <button type="button" id="btn_close_error" runat="server" class="close" tabindex="-1" data-dismiss="modal" aria-label="Close">
                <span aria-hidden="true">&times;</span>
              </button>
            </div>
            <div class="modal-body">
              <p>OPCION INCORRECTA!.
              Ingrese fecha y dia válido.&hellip;</p>
            </div>
            <div class="modal-footer justify-content-center ">
            <%--<div class="modal-footer justify-content-between">--%>
              <%--<button type="button" class="btn btn-default" data-dismiss="modal">Close</button>--%>
              <button type="button" id="btn_ok_error" runat="server" tabindex="1" class="btn btn-primary" data-dismiss="modal">OK</button>
            </div>
          </div>
          <!-- /.modal-content -->
        </div>
        <!-- /.modal-dialog -->
      </div>
      <!-- /.modal -->

<%--MODAL MSJ CENTRADO - ERROR OPCION--%>
<div class="modal fade" id="modal_sm_error_iniciodia" tabindex="-1" role="dialog" aria-labelledby="exampleModalCenterTitle" aria-hidden="true" data-backdrop="static" data-keyboard="false">
        <div class="modal-dialog modal-sm modal-dialog-centered " role="document">
          <div class="modal-content">
            <div class="modal-header">
              <h4 class="modal-title">Error!</h4>
              <button type="button" id="Button1" runat="server" class="close" tabindex="-1" data-dismiss="modal" aria-label="Close">
                <span aria-hidden="true">&times;</span>
              </button>
            </div>
            <div class="modal-body">
              <p>El día de trabajo ya se inició!
              &hellip;</p>
            </div>
            <div class="modal-footer justify-content-center ">
            <%--<div class="modal-footer justify-content-between">--%>
              <%--<button type="button" class="btn btn-default" data-dismiss="modal">Close</button>--%>
              <button type="button" id="Button2" runat="server" tabindex="1" class="btn btn-primary" data-dismiss="modal">OK</button>
            </div>
          </div>
          <!-- /.modal-content -->
        </div>
        <!-- /.modal-dialog -->
      </div>
      <!-- /.modal -->

<!-- Modal GUARDAR, "PREGUNTA" CENTRADO EN PANTALLA -->
<div class="modal fade" id="Mdl_grabar" tabindex="-1" role="dialog" aria-labelledby="exampleModalCenterTitle" aria-hidden="true" data-backdrop="static" data-keyboard="false">
  <div class="modal-dialog modal-dialog-centered" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <h5 class="modal-title" id="H1">Grabar</h5>
        <button type="button" id="btn_grabar_close" class="close" tabindex="-1" runat="server" data-dismiss="modal" aria-label="Close">
          <span aria-hidden="true">&times;</span>
        </button>
      </div>
      <div class="modal-body">
        ¿Está seguro de iniciar el día?...
      </div>
      <div class="modal-footer">
        <button type="button" id="btn_grabar_mdl_cancelar" class="btn btn-secondary" runat="server" data-dismiss="modal">Cancelar</button>
        <button type="button" id="btn_grabar_mdl" class="btn btn-primary" runat="server" data-dismiss="modal">Confirmar</button>
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

<!-- Modal GUARDAR, "PREGUNTA" CENTRADO EN PANTALLA -->
<div class="modal fade" id="Mdl_modif" tabindex="-1" role="dialog" aria-labelledby="exampleModalCenterTitle" aria-hidden="true" data-backdrop="static" data-keyboard="false">
  <div class="modal-dialog modal-dialog-centered" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <h5 class="modal-title" id="H2">Advertencia</h5>
        <button type="button" id="btn_modif_close_mdl" class="close" tabindex="-1" runat="server" data-dismiss="modal" aria-label="Close">
          <span aria-hidden="true">&times;</span>
        </button>
      </div>
      <div class="modal-body">
        Ya se encuentran datos registrados para esta fecha. Se actualizara la información.
        ¿Confirma la operación?...
      </div>
      <div class="modal-footer">
        <button type="button" id="btn_modif_cancelar_mdl" class="btn btn-secondary" runat="server" data-dismiss="modal">Cancelar</button>
        <button type="button" id="btn_modif_confirmar_mdl" class="btn btn-primary" runat="server" data-dismiss="modal">Confirmar</button>
      </div>
    </div>
  </div>
</div>


</ContentTemplate>
</asp:UpdatePanel>
</asp:Content>
