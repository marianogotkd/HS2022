<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Home.Master" CodeBehind="carga_recorridos_zonas_b.aspx.vb" Inherits="Presentacion.carga_recorridos_zonas_b" %>
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
                <h3 class="card-title">CARGA DE RECORRIDOS/ZONAS.</h3>
</div>
<form role="form">
<div class="card-body">
<div class="container-fluid">
<div class="row justify-content-center">
<div class="col-lg-12"> <%--aqui decia col-lg-6--%>
<div class="card">
        <div class="card-body">
                <div class="form-group">
                        <div class="row justify-content-center">
                                <div class="col-md-4">
                                
                                <asp:Label ID="LABEL_zona" runat="server" Text="CARGA DE:"></asp:Label>
                                &nbsp;<asp:TextBox ID="txt_zona" runat="server" Text="" 
                                    enabled="false"  Width="100px"></asp:TextBox>
                                <br />
                                <br />
                                </div>
                                <asp:HiddenField ID="HF_idrecorrido" runat="server" />
                                <asp:HiddenField ID="HF_fecha" runat="server" />
                                <div class="col-md-4">
                                </div>
                                
                        </div>
                </div>
                <div class="form-group">
                        <div class="row justify-content-center">
                                <div class="col-md-2">
                                <asp:Label ID="Lb_01" runat="server" Text="01:"></asp:Label>
                                <asp:TextBox ID="txt_01" runat="server" MaxLength="4" Width="50px" onkeydown="tecla_op(event);"></asp:TextBox>
                                    <br />
                                    <br />
                                <asp:Label ID="Lb_02" runat="server" Text="02:"></asp:Label>
                                <asp:TextBox ID="txt_02" runat="server" MaxLength="4" Width="50px" onkeydown="tecla_op(event);" ></asp:TextBox>
                                    <br />
                                    <br />
                                <asp:Label ID="Lb_03" runat="server" Text="03:"></asp:Label>
                                <asp:TextBox ID="txt_03" runat="server" MaxLength="4" Width="50px" onkeydown="tecla_op(event);" ></asp:TextBox>
                                    <br />
                                    <br />
                                <asp:Label ID="Lb_04" runat="server" Text="04:"></asp:Label>
                                <asp:TextBox ID="txt_04" runat="server" MaxLength="4" Width="50px" onkeydown="tecla_op(event);" ></asp:TextBox>
                                    <br />
                                    <br />
                                <asp:Label ID="Lb_05" runat="server" Text="05:"></asp:Label>
                                <asp:TextBox ID="txt_05" runat="server" MaxLength="4" Width="50px" onkeydown="tecla_op(event);" ></asp:TextBox>
                                    <br />
                                    <br />
                                
                                </div>
                                <div class="col-md-2">
                                <asp:Label ID="Lb_06" runat="server" Text="06:"></asp:Label>
                                <asp:TextBox ID="txt_06" runat="server" MaxLength="4" Width="50px" onkeydown="tecla_op(event);" ></asp:TextBox>
                                    <br />
                                    <br />
                                <asp:Label ID="Lb_07" runat="server" Text="07:"></asp:Label>
                                <asp:TextBox ID="txt_07" runat="server" MaxLength="4" Width="50px" onkeydown="tecla_op(event);" ></asp:TextBox>
                                    <br />
                                    <br />
                                <asp:Label ID="Lb_08" runat="server" Text="08:"></asp:Label>
                                <asp:TextBox ID="txt_08" runat="server" MaxLength="4" Width="50px" onkeydown="tecla_op(event);" ></asp:TextBox>
                                    <br />
                                    <br />
                                <asp:Label ID="Lb_09" runat="server" Text="09:"></asp:Label>
                                <asp:TextBox ID="txt_09" runat="server" MaxLength="4" Width="50px" onkeydown="tecla_op(event);" ></asp:TextBox>
                                    <br />
                                    <br />
                                <asp:Label ID="Lb_10" runat="server" Text="10:"></asp:Label>
                                <asp:TextBox ID="txt_10" runat="server" MaxLength="4" Width="50px" onkeydown="tecla_op(event);" ></asp:TextBox>
                                    <br />
                                    <br />
                                </div>
                                <div class="col-md-2">
                                <asp:Label ID="Lb_11" runat="server" Text="11:"></asp:Label>
                                <asp:TextBox ID="txt_11" runat="server" MaxLength="4" Width="50px" onkeydown="tecla_op(event);"></asp:TextBox>
                                    <br />
                                    <br />
                                <asp:Label ID="Lb_12" runat="server" Text="12:"></asp:Label>
                                <asp:TextBox ID="txt_12" runat="server" MaxLength="4" Width="50px" onkeydown="tecla_op(event);" ></asp:TextBox>
                                    <br />
                                    <br />
                                <asp:Label ID="Lb_13" runat="server" Text="13:"></asp:Label>
                                <asp:TextBox ID="txt_13" runat="server" MaxLength="4" Width="50px" onkeydown="tecla_op(event);" ></asp:TextBox>
                                    <br />
                                    <br />
                                <asp:Label ID="Lb_14" runat="server" Text="14:"></asp:Label>
                                <asp:TextBox ID="txt_14" runat="server" MaxLength="4" Width="50px" onkeydown="tecla_op(event);" ></asp:TextBox>
                                    <br />
                                    <br />
                                <asp:Label ID="Lb_15" runat="server" Text="15:"></asp:Label>
                                <asp:TextBox ID="txt_15" runat="server" MaxLength="4" Width="50px" onkeydown="tecla_op(event);" ></asp:TextBox>
                                    <br />
                                    <br />
                                
                                </div>
                                <div class="col-md-2">
                                <asp:Label ID="Lb_16" runat="server" Text="16:"></asp:Label>
                                <asp:TextBox ID="txt_16" runat="server" MaxLength="4" Width="50px" onkeydown="tecla_op(event);" ></asp:TextBox>
                                    <br />
                                    <br />
                                <asp:Label ID="Lb_17" runat="server" Text="17:"></asp:Label>
                                <asp:TextBox ID="txt_17" runat="server" MaxLength="4" Width="50px" onkeydown="tecla_op(event);" ></asp:TextBox>
                                    <br />
                                    <br />
                                <asp:Label ID="Lb_18" runat="server" Text="18:"></asp:Label>
                                <asp:TextBox ID="txt_18" runat="server" MaxLength="4" Width="50px" onkeydown="tecla_op(event);" ></asp:TextBox>
                                    <br />
                                    <br />
                                <asp:Label ID="Lb_19" runat="server" Text="19:"></asp:Label>
                                <asp:TextBox ID="txt_19" runat="server" MaxLength="4" Width="50px" onkeydown="tecla_op(event);" ></asp:TextBox>
                                    <br />
                                    <br />
                                <asp:Label ID="Lb_20" runat="server" Text="20:"></asp:Label>
                                <asp:TextBox ID="txt_20" runat="server" MaxLength="4" Width="50px" onkeydown="tecla_op(event);" ></asp:TextBox>
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
            <button type="button" id="BOTON_GRABAR" runat="server" class="btn btn-primary" data-toggle="modal" data-target="#modal_grabar_pregunta" onkeydown="tecla_op_botones(event);"> <%--data-targe="#modal-primary"--%>
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

<!-- Modal GRABAR PREGUNTA CENTRADO EN PANTALLA -->
<div class="modal fade" id="modal_grabar_pregunta" tabindex="-1" role="dialog" aria-labelledby="exampleModalCenterTitle" aria-hidden="true" data-backdrop="static" data-keyboard="false">
  <div class="modal-dialog modal-dialog-centered" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <h5 class="modal-title" id="H1">Graba</h5>
        <button type="button" id="btn_grabar_pregunta_close" class="close" runat="server" tabindex="-1" data-dismiss="modal" aria-label="Close">
          <span aria-hidden="true">&times;</span>
        </button>
      </div>
      <div class="modal-body">
        ¿Confirma la operación?
      </div>
      <div class="modal-footer">
        <button type="button" id="btn_grabar_cancelar_modal" class="btn btn-secondary" runat="server" data-dismiss="modal">Cancelar</button>
        <button type="button" id="btn_grabar_pregunta_modal" class="btn btn-primary" runat="server" data-dismiss="modal">Confirmar</button>
      </div>
    </div>
  </div>
</div>

<%--Modal MENSAJE OK, grabado--%>
<div class="modal fade" id="modal_ok_grabado" tabindex="-1" role="dialog" aria-labelledby="exampleModalCenterTitle" aria-hidden="true" data-backdrop="static" data-keyboard="false">
        <div class="modal-dialog modal-sm modal-dialog-centered " role="document">
          <div class="modal-content">
            <div class="modal-header">
              <h4 class="modal-title">Graba</h4>
              <button type="button" id="btn_ok_close" runat="server" class="close" tabindex="-1" data-dismiss="modal" aria-label="Close">
                <span aria-hidden="true">&times;</span>
              </button>
            </div>
            <div class="modal-body">
              <p>Se guardó correctamente!&hellip;</p>
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
