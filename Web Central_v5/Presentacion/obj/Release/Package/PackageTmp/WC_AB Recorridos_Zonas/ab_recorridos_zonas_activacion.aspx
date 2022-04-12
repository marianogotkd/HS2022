<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Home.Master" CodeBehind="ab_recorridos_zonas_activacion.aspx.vb" Inherits="Presentacion.ab_recorridos_zonas_activacion" %>
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
                <h3 class="card-title">A.B. RECORRIDOS/ZONAS</h3>
</div>
<form role="form">
<div class="card-body">
<div class="container-fluid">
<div class="row justify-content-center">
<div class="col-lg"> <%--aqui decia col-lg-6--%>
<div class="card">
        <div class="card-body">
                <div class="form-group">
                        <div class="row justify-content-center">
                                <div class="col-4">
                                    <asp:Label ID="Label_dia" runat="server" Text="DIA:"></asp:Label>
                                    <asp:HiddenField ID="HF_dia_nro" runat="server" />
                                </div>

                                <div class="col-4">
                                    
                                          
                                    
                                </div>
                                <div class="col-4">
                                    
                                </div>

                        </div>
                </div>
                <div class="form-group">
                        <div class="row">
                                <div class="col">
                                    <asp:Label ID="Label3" runat="server" Text="RECORRIDO 1" ForeColor="#6666FF"></asp:Label>
                                    <br />
                                    <asp:Label ID="Lb_1a" runat="server" Text="" Width="100px"></asp:Label>
                                    &nbsp;<asp:DropDownList ID="Drop_1a" runat="server" onkeydown="tecla_op(event);">
                            <asp:ListItem Selected="True" Value="0">0-Deshabilita</asp:ListItem>
                            <asp:ListItem Value="1">1-Habilita</asp:ListItem>
                            </asp:DropDownList>
                                    <br />
                                    <br />
                                    <asp:Label ID="Lb_1b" runat="server" Text="" Width="100px"></asp:Label>
                                    &nbsp;<asp:DropDownList ID="Drop_1b" runat="server" onkeydown="tecla_op(event);">
                            <asp:ListItem Selected="True" Value="0">0-Deshabilita</asp:ListItem>
                            <asp:ListItem Value="1">1-Habilita</asp:ListItem>
                            </asp:DropDownList>
                                    <br />
                                    <br />
                                    <asp:Label ID="Lb_1c" runat="server" Text="" Width="100px"></asp:Label>
                                    &nbsp;<asp:DropDownList ID="Drop_1c" runat="server" onkeydown="tecla_op(event);">
                            <asp:ListItem Selected="True" Value="0">0-Deshabilita</asp:ListItem>
                            <asp:ListItem Value="1">1-Habilita</asp:ListItem>
                            </asp:DropDownList>
                                    <br />
                                    <br />
                                    <asp:Label ID="Lb_1d" runat="server" Text="" Width="100px"></asp:Label>
                                    &nbsp;<asp:DropDownList ID="Drop_1d" runat="server" onkeydown="tecla_op(event);">
                            <asp:ListItem Selected="True" Value="0">0-Deshabilita</asp:ListItem>
                            <asp:ListItem Value="1">1-Habilita</asp:ListItem>
                            </asp:DropDownList>
                                    <br />
                                    <br />
                                    <asp:Label ID="Lb_1e" runat="server" Text="" Width="100px"></asp:Label>
                                    &nbsp;<asp:DropDownList ID="Drop_1e" runat="server" onkeydown="tecla_op(event);">
                            <asp:ListItem Selected="True" Value="0">0-Deshabilita</asp:ListItem>
                            <asp:ListItem Value="1">1-Habilita</asp:ListItem>
                            </asp:DropDownList>
                                    <br />
                                    <br />
                                    <asp:Label ID="Lb_1f" runat="server" Text="" Width="100px"></asp:Label>
                                    &nbsp;<asp:DropDownList ID="Drop_1f" runat="server" onkeydown="tecla_op(event);">
                            <asp:ListItem Selected="True" Value="0">0-Deshabilita</asp:ListItem>
                            <asp:ListItem Value="1">1-Habilita</asp:ListItem>
                            </asp:DropDownList>
                                    <br />
                                    <br />
                                    <asp:Label ID="Lb_1g" runat="server" Text="" Width="100px"></asp:Label>
                                    &nbsp;<asp:DropDownList ID="Drop_1g" runat="server" onkeydown="tecla_op(event);">
                            <asp:ListItem Selected="True" Value="0">0-Deshabilita</asp:ListItem>
                            <asp:ListItem Value="1">1-Habilita</asp:ListItem>
                            </asp:DropDownList>
                                    <br />
                                    <br />
                                    <asp:Label ID="Lb_1h" runat="server" Text="" Width="100px"></asp:Label>
                                    &nbsp;<asp:DropDownList ID="Drop_1h" runat="server" onkeydown="tecla_op(event);">
                            <asp:ListItem Selected="True" Value="0">0-Deshabilita</asp:ListItem>
                            <asp:ListItem Value="1">1-Habilita</asp:ListItem>
                            </asp:DropDownList>
                                    <br />
                                    <br />
                                    <asp:Label ID="Lb_1i" runat="server" Text="" Width="100px"></asp:Label>
                                    &nbsp;<asp:DropDownList ID="Drop_1i" runat="server" onkeydown="tecla_op(event);">
                            <asp:ListItem Selected="True" Value="0">0-Deshabilita</asp:ListItem>
                            <asp:ListItem Value="1">1-Habilita</asp:ListItem>
                            </asp:DropDownList>
                                    <br />
                                    <br />
                                    <asp:Label ID="Lb_1j" runat="server" Text="" Width="100px"></asp:Label>
                                    &nbsp;<asp:DropDownList ID="Drop_1j" runat="server" onkeydown="tecla_op(event);">
                            <asp:ListItem Selected="True" Value="0">0-Deshabilita</asp:ListItem>
                            <asp:ListItem Value="1">1-Habilita</asp:ListItem>
                            </asp:DropDownList>
                                    <br />
                                    <br />
                                </div>

                                <div class="col">
                                <asp:Label ID="Label14" runat="server" Text="RECORRIDO 2" ForeColor="#6666FF"></asp:Label>
                                    <br />
                                    <asp:Label ID="Lb_2a" runat="server" Text="" Width="100px"></asp:Label>
                                    &nbsp;<asp:DropDownList ID="Drop_2a" runat="server" onkeydown="tecla_op(event);">
                            <asp:ListItem Selected="True" Value="0">0-Deshabilita</asp:ListItem>
                            <asp:ListItem Value="1">1-Habilita</asp:ListItem>
                            </asp:DropDownList>
                                    <br />
                                    <br />
                                    <asp:Label ID="Lb_2b" runat="server" Text="" Width="100px"></asp:Label>
                                    &nbsp;<asp:DropDownList ID="Drop_2b" runat="server" onkeydown="tecla_op(event);">
                            <asp:ListItem Selected="True" Value="0">0-Deshabilita</asp:ListItem>
                            <asp:ListItem Value="1">1-Habilita</asp:ListItem>
                            </asp:DropDownList>
                                    <br />
                                    <br />
                                    <asp:Label ID="Lb_2c" runat="server" Text="" Width="100px"></asp:Label>
                                    &nbsp;<asp:DropDownList ID="Drop_2c" runat="server" onkeydown="tecla_op(event);">
                            <asp:ListItem Selected="True" Value="0">0-Deshabilita</asp:ListItem>
                            <asp:ListItem Value="1">1-Habilita</asp:ListItem>
                            </asp:DropDownList>
                                    <br />
                                    <br />
                                    <asp:Label ID="Lb_2d" runat="server" Text="" Width="100px"></asp:Label>
                                    &nbsp;<asp:DropDownList ID="Drop_2d" runat="server" onkeydown="tecla_op(event);">
                            <asp:ListItem Selected="True" Value="0">0-Deshabilita</asp:ListItem>
                            <asp:ListItem Value="1">1-Habilita</asp:ListItem>
                            </asp:DropDownList>
                                    <br />
                                    <br />
                                    <asp:Label ID="Lb_2e" runat="server" Text="" Width="100px"></asp:Label>
                                    &nbsp;<asp:DropDownList ID="Drop_2e" runat="server" onkeydown="tecla_op(event);">
                            <asp:ListItem Selected="True" Value="0">0-Deshabilita</asp:ListItem>
                            <asp:ListItem Value="1">1-Habilita</asp:ListItem>
                            </asp:DropDownList>
                                    <br />
                                    <br />
                                    <asp:Label ID="Lb_2f" runat="server" Text="" Width="100px"></asp:Label>
                                    &nbsp;<asp:DropDownList ID="Drop_2f" runat="server" onkeydown="tecla_op(event);">
                            <asp:ListItem Selected="True" Value="0">0-Deshabilita</asp:ListItem>
                            <asp:ListItem Value="1">1-Habilita</asp:ListItem>
                            </asp:DropDownList>
                                    <br />
                                    <br />
                                    <asp:Label ID="Lb_2g" runat="server" Text="" Width="100px"></asp:Label>
                                    &nbsp;<asp:DropDownList ID="Drop_2g" runat="server" onkeydown="tecla_op(event);">
                            <asp:ListItem Selected="True" Value="0">0-Deshabilita</asp:ListItem>
                            <asp:ListItem Value="1">1-Habilita</asp:ListItem>
                            </asp:DropDownList>
                                    
                                    <br />
                                    <br />
                                    <asp:Label ID="Lb_2h" runat="server" Text="" Width="100px"></asp:Label>
                                    &nbsp;<asp:DropDownList ID="Drop_2h" runat="server" onkeydown="tecla_op(event);">
                            <asp:ListItem Selected="True" Value="0">0-Deshabilita</asp:ListItem>
                            <asp:ListItem Value="1">1-Habilita</asp:ListItem>
                            </asp:DropDownList>
                                    
                                    <br />
                                    <br />
                                    <asp:Label ID="Lb_2i" runat="server" Text="" Width="100px"></asp:Label>
                                    &nbsp;<asp:DropDownList ID="Drop_2i" runat="server" onkeydown="tecla_op(event);">
                            <asp:ListItem Selected="True" Value="0">0-Deshabilita</asp:ListItem>
                            <asp:ListItem Value="1">1-Habilita</asp:ListItem>
                            </asp:DropDownList>
                                    
                                    <br />
                                    <br />
                                    <asp:Label ID="Lb_2j" runat="server" Text="" Width="100px"></asp:Label>
                                    &nbsp;<asp:DropDownList ID="Drop_2j" runat="server" onkeydown="tecla_op(event);">
                            <asp:ListItem Selected="True" Value="0">0-Deshabilita</asp:ListItem>
                            <asp:ListItem Value="1">1-Habilita</asp:ListItem>
                            </asp:DropDownList>
                                    
                                    <br />
                                    <br />
                                </div>

                                <div class="col">
                                <asp:Label ID="Label25" runat="server" Text="RECORRIDO 3" ForeColor="#6666FF"></asp:Label>
                                    <br />
                                    <asp:Label ID="Lb_3a" runat="server" Text="" Width="100px"></asp:Label>
                                    &nbsp;<asp:DropDownList ID="Drop_3a" runat="server" onkeydown="tecla_op(event);">
                            <asp:ListItem Selected="True" Value="0">0-Deshabilita</asp:ListItem>
                            <asp:ListItem Value="1">1-Habilita</asp:ListItem>
                            </asp:DropDownList>
                                    
                                    <br />
                                    <br />
                                    <asp:Label ID="Lb_3b" runat="server" Text="" Width="100px"></asp:Label>
                                    &nbsp;<asp:DropDownList ID="Drop_3b" runat="server" onkeydown="tecla_op(event);">
                            <asp:ListItem Selected="True" Value="0">0-Deshabilita</asp:ListItem>
                            <asp:ListItem Value="1">1-Habilita</asp:ListItem>
                            </asp:DropDownList>
                                    
                                    <br />
                                    <br />
                                    <asp:Label ID="Lb_3c" runat="server" Text="" Width="100px"></asp:Label>
                                    &nbsp;<asp:DropDownList ID="Drop_3c" runat="server" onkeydown="tecla_op(event);">
                            <asp:ListItem Selected="True" Value="0">0-Deshabilita</asp:ListItem>
                            <asp:ListItem Value="1">1-Habilita</asp:ListItem>
                            </asp:DropDownList>
                                    
                                    <br />
                                    <br />
                                    <asp:Label ID="Lb_3d" runat="server" Text="" Width="100px"></asp:Label>
                                    &nbsp;<asp:DropDownList ID="Drop_3d" runat="server" onkeydown="tecla_op(event);">
                            <asp:ListItem Selected="True" Value="0">0-Deshabilita</asp:ListItem>
                            <asp:ListItem Value="1">1-Habilita</asp:ListItem>
                            </asp:DropDownList>
                                    
                                    <br />
                                    <br />
                                    <asp:Label ID="Lb_3e" runat="server" Text="" Width="100px"></asp:Label>
                                    &nbsp;<asp:DropDownList ID="Drop_3e" runat="server" onkeydown="tecla_op(event);">
                            <asp:ListItem Selected="True" Value="0">0-Deshabilita</asp:ListItem>
                            <asp:ListItem Value="1">1-Habilita</asp:ListItem>
                            </asp:DropDownList>
                                    
                                    <br />
                                    <br />
                                    <asp:Label ID="Lb_3f" runat="server" Text="" Width="100px"></asp:Label>
                                    &nbsp;<asp:DropDownList ID="Drop_3f" runat="server" onkeydown="tecla_op(event);">
                            <asp:ListItem Selected="True" Value="0">0-Deshabilita</asp:ListItem>
                            <asp:ListItem Value="1">1-Habilita</asp:ListItem>
                            </asp:DropDownList>
                                    
                                    <br />
                                    <br />
                                    <asp:Label ID="Lb_3g" runat="server" Text="" Width="100px"></asp:Label>
                                    &nbsp;<asp:DropDownList ID="Drop_3g" runat="server" onkeydown="tecla_op(event);">
                            <asp:ListItem Selected="True" Value="0">0-Deshabilita</asp:ListItem>
                            <asp:ListItem Value="1">1-Habilita</asp:ListItem>
                            </asp:DropDownList>
                                    
                                    <br />
                                    <br />
                                    <asp:Label ID="Lb_3h" runat="server" Text="" Width="100px"></asp:Label>
                                    &nbsp;<asp:DropDownList ID="Drop_3h" runat="server" onkeydown="tecla_op(event);">
                            <asp:ListItem Selected="True" Value="0">0-Deshabilita</asp:ListItem>
                            <asp:ListItem Value="1">1-Habilita</asp:ListItem>
                            </asp:DropDownList>
                                    
                                    <br />
                                    <br />
                                    <asp:Label ID="Lb_3i" runat="server" Text="" Width="100px"></asp:Label>
                                    &nbsp;<asp:DropDownList ID="Drop_3i" runat="server" onkeydown="tecla_op(event);">
                            <asp:ListItem Selected="True" Value="0">0-Deshabilita</asp:ListItem>
                            <asp:ListItem Value="1">1-Habilita</asp:ListItem>
                            </asp:DropDownList>
                                    
                                    <br />
                                    <br />
                                    <asp:Label ID="Lb_3j" runat="server" Text="" Width="100px"></asp:Label>
                                    &nbsp;<asp:DropDownList ID="Drop_3j" runat="server" onkeydown="tecla_op(event);">
                            <asp:ListItem Selected="True" Value="0">0-Deshabilita</asp:ListItem>
                            <asp:ListItem Value="1">1-Habilita</asp:ListItem>
                            </asp:DropDownList>
                                    
                                    <br />
                                    <br />
                                </div>

                                <div class="col">
                                <asp:Label ID="Label36" runat="server" Text="RECORRIDO 4" Font-Bold="False" 
                                        ForeColor="#6666FF"></asp:Label>
                                    <br />
                                    <asp:Label ID="Lb_4a" runat="server" Text="" Width="100px"></asp:Label>
                                    &nbsp;<asp:DropDownList ID="Drop_4a" runat="server" onkeydown="tecla_op(event);">
                            <asp:ListItem Selected="True" Value="0">0-Deshabilita</asp:ListItem>
                            <asp:ListItem Value="1">1-Habilita</asp:ListItem>
                            </asp:DropDownList>
                                    
                                    <br />
                                    <br />
                                    <asp:Label ID="Lb_4b" runat="server" Text="" Width="100px"></asp:Label>
                                    &nbsp;<asp:DropDownList ID="Drop_4b" runat="server" onkeydown="tecla_op(event);">
                            <asp:ListItem Selected="True" Value="0">0-Deshabilita</asp:ListItem>
                            <asp:ListItem Value="1">1-Habilita</asp:ListItem>
                            </asp:DropDownList>
                                    
                                    <br />
                                    <br />
                                    <asp:Label ID="Lb_4c" runat="server" Text="" Width="100px"></asp:Label>
                                    &nbsp;<asp:DropDownList ID="Drop_4c" runat="server" onkeydown="tecla_op(event);">
                            <asp:ListItem Selected="True" Value="0">0-Deshabilita</asp:ListItem>
                            <asp:ListItem Value="1">1-Habilita</asp:ListItem>
                            </asp:DropDownList>
                                    
                                    <br />
                                    <br />
                                    <asp:Label ID="Lb_4d" runat="server" Text="" Width="100px"></asp:Label>
                                    &nbsp;<asp:DropDownList ID="Drop_4d" runat="server" onkeydown="tecla_op(event);">
                            <asp:ListItem Selected="True" Value="0">0-Deshabilita</asp:ListItem>
                            <asp:ListItem Value="1">1-Habilita</asp:ListItem>
                            </asp:DropDownList>
                                    
                                    <br />
                                    <br />
                                    <asp:Label ID="Lb_4e" runat="server" Text="" Width="100px"></asp:Label>
                                    &nbsp;<asp:DropDownList ID="Drop_4e" runat="server" onkeydown="tecla_op(event);">
                            <asp:ListItem Selected="True" Value="0">0-Deshabilita</asp:ListItem>
                            <asp:ListItem Value="1">1-Habilita</asp:ListItem>
                            </asp:DropDownList>
                                    
                                    <br />
                                    <br />
                                    <asp:Label ID="Lb_4f" runat="server" Text="" Width="100px"></asp:Label>
                                    &nbsp;<asp:DropDownList ID="Drop_4f" runat="server" onkeydown="tecla_op(event);">
                            <asp:ListItem Selected="True" Value="0">0-Deshabilita</asp:ListItem>
                            <asp:ListItem Value="1">1-Habilita</asp:ListItem>
                            </asp:DropDownList>
                                    
                                    <br />
                                    <br />
                                    <asp:Label ID="Lb_4g" runat="server" Text="" Width="100px"></asp:Label>
                                    &nbsp;<asp:DropDownList ID="Drop_4g" runat="server" onkeydown="tecla_op(event);">
                            <asp:ListItem Selected="True" Value="0">0-Deshabilita</asp:ListItem>
                            <asp:ListItem Value="1">1-Habilita</asp:ListItem>
                            </asp:DropDownList>
                                    
                                    <br />
                                    <br />
                                    <asp:Label ID="Lb_4h" runat="server" Text="" Width="100px"></asp:Label>
                                    &nbsp;<asp:DropDownList ID="Drop_4h" runat="server" onkeydown="tecla_op(event);">
                            <asp:ListItem Selected="True" Value="0">0-Deshabilita</asp:ListItem>
                            <asp:ListItem Value="1">1-Habilita</asp:ListItem>
                            </asp:DropDownList>
                                    
                                    <br />
                                    <br />
                                    <asp:Label ID="Lb_4i" runat="server" Text="" Width="100px"></asp:Label>
                                    &nbsp;<asp:DropDownList ID="Drop_4i" runat="server" onkeydown="tecla_op(event);">
                            <asp:ListItem Selected="True" Value="0">0-Deshabilita</asp:ListItem>
                            <asp:ListItem Value="1">1-Habilita</asp:ListItem>
                            </asp:DropDownList>
                                    
                                    <br />
                                    <br />
                                    <asp:Label ID="Lb_4j" runat="server" Text="" Width="100px"></asp:Label>
                                    &nbsp;<asp:DropDownList ID="Drop_4j" runat="server" onkeydown="tecla_op(event);">
                            <asp:ListItem Selected="True" Value="0">0-Deshabilita</asp:ListItem>
                            <asp:ListItem Value="1">1-Habilita</asp:ListItem>
                            </asp:DropDownList>
                                    
                                    <br />
                                    <br />
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
            <button type="button" id="BOTON_GRABAR" runat="server" class="btn btn-primary" onkeydown="tecla_op_botones(event);"> <%--data-targe="#modal-primary"--%>
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
              <p>Ocurrión un problema, intente nuevamente!&hellip;</p>
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



</ContentTemplate>
</asp:UpdatePanel>


</asp:Content>
