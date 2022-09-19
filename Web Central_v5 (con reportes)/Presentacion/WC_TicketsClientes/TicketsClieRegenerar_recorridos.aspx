<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Home.Master" CodeBehind="TicketsClieRegenerar_recorridos.aspx.vb" Inherits="Presentacion.TicketsClieRegenerar_recorridos" %>
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
            document.getElementsByTagName('button')[1].focus();
            document.getElementsByTagName('button')[1].click();
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
                <h3 class="card-title">REGENERAR TICKETS CLIENTES POR RECORRIDOS.</h3>
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
                      <asp:HiddenField ID="HF_parametro_id" runat="server" />
                      <asp:Label ID="Label2" runat="server" Text="FECHA:"></asp:Label>
                      <asp:Label ID="Label_fecha" runat="server" Text=""></asp:Label>
                      <asp:HiddenField ID="HF_fecha" runat="server" />
            </div>
            <div class="col-md-4">
                      <asp:Label ID="Label3" runat="server" Text="DIA:"></asp:Label>
                      <asp:Label ID="Label_dia" runat="server" Text=""></asp:Label>
                    <asp:HiddenField ID="HF_dia_id" runat="server" />
            </div>
          
          </div>

        </div>

      <div class="form-group">
          <div class="row justify-content-center">
            <div class="col-md-8">
              <asp:Label ID="Label1" runat="server" Text="SELECCIONE CLIENTES A LISTAR LOS TICKETS"></asp:Label>
            </div>
          </div>
      </div>

      <div class="form-group">
          <div class="row justify-content-center">
                <div class="col-md-4">
                  <asp:Label ID="Label4" runat="server" Text="DESDE RECORRIDO:"></asp:Label>
                  <asp:TextBox ID="Txt_DesdeRecorrido" runat="server" 
                                placeholder="Ingrese codigo..." class="form-control" 
                                onkeydown="tecla_op(event);" onkeypress="return justNumbers(event);"  
                                MaxLength="2"></asp:TextBox>
                
                  <asp:Label ID="Label5" runat="server" Text="DESDE ORDEN:"></asp:Label>
                  <asp:TextBox ID="Txt_DesdeOrden" runat="server" 
                                placeholder="Ingrese codigo..." class="form-control" 
                                onkeydown="tecla_op(event);" onkeypress="return justNumbers(event);"  
                                MaxLength="3"></asp:TextBox>
                </div>
                <div class="col-md-4">
                  <asp:Label ID="Label6" runat="server" Text="HASTA RECORRIDO:"></asp:Label>
                  <asp:TextBox ID="Txt_HastaRecorridoCodigo" runat="server" 
                                placeholder="Ingrese codigo..." class="form-control" 
                                onkeydown="tecla_op(event);" onkeypress="return justNumbers(event);" 
                                MaxLength="2"></asp:TextBox>
                
                  <asp:Label ID="Label7" runat="server" Text="HASTA ORDEN:"></asp:Label>
                  <asp:TextBox ID="Txt_HastaOrden" runat="server" 
                                placeholder="Ingrese codigo..." class="form-control" 
                                onkeydown="tecla_op(event);" onkeypress="return justNumbers(event);"  
                                MaxLength="3"></asp:TextBox>
                </div>
          </div>
      </div>
            
      <div class="form-group">
        <div class="row justify-content-center">
          <div class="col-md-8">
            <asp:Label ID="Label8" runat="server" Text="MENSAJE GENERAL EN PIE DE PAGINA TICKET:"></asp:Label>
          <asp:TextBox ID="Txt_msjgeneral" runat="server" 
                                placeholder="" class="form-control" 
                                onkeydown="tecla_op(event);" ></asp:TextBox>
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
                  <button type="submit" UseSubmitBehavior="false" class="btn btn-primary" runat="server" id="btn_retroceder" onkeydown="tecla_op_botones(event);">ESC = RETROCEDER</button>
                    &nbsp;</div>
                      
            
                      <div class="form-group">
                                <button type="button" Class="btn btn-primary" id = "BOTON_GRABA" runat="server" onkeydown="tecla_op_botones(event);">F8 = GRABA</button>
        
                            </div>
            
            
            
                  
            
         </div>

        </div>
        

</div>


<%--Modal MENSAJE ERROR OK 1--%>
<div class="modal fade" id="modal-ok_error" tabindex="-1" role="dialog" aria-labelledby="exampleModalCenterTitle" aria-hidden="true" data-backdrop="static" data-keyboard="false">
        <div class="modal-dialog modal-sm modal-dialog-centered " role="document">
          <div class="modal-content">
            <div class="modal-header">
              <h4 class="modal-title">Error</h4>
              <button type="button" id="btn_error_close" runat="server" class="close" tabindex="-1" data-dismiss="modal" aria-label="Close">
                <span aria-hidden="true">&times;</span>
              </button>
            </div>
            <div class="modal-body">
              <p>Error, no hay liquidacion completada!&hellip;</p>
            </div>
            <div class="modal-footer justify-content-center ">
            <%--<div class="modal-footer justify-content-between">--%>
              <%--<button type="button" class="btn btn-default" data-dismiss="modal">Close</button>--%>
              <button type="button" id="btn_ok_error" runat="server" class="btn btn-primary" data-dismiss="modal">OK</button>
            </div>
          </div>
          <!-- /.modal-content -->
        </div>
        <!-- /.modal-dialog -->
      </div>
      <!-- /.modal -->


<%--Modal MENSAJE ERROR OK 2--%>
<div class="modal fade" id="modal-ok_error2" tabindex="-1" role="dialog" aria-labelledby="exampleModalCenterTitle" aria-hidden="true" data-backdrop="static" data-keyboard="false">
        <div class="modal-dialog modal-sm modal-dialog-centered " role="document">
          <div class="modal-content">
            <div class="modal-header">
              <h4 class="modal-title">Error</h4>
              <button type="button" id="btn_error_close2" runat="server" class="close" tabindex="-1" data-dismiss="modal" aria-label="Close">
                <span aria-hidden="true">&times;</span>
              </button>
            </div>
            <div class="modal-body">
              <p>Error, complete la informacion solicitada!&hellip;</p>
            </div>
            <div class="modal-footer justify-content-center ">
            <%--<div class="modal-footer justify-content-between">--%>
              <%--<button type="button" class="btn btn-default" data-dismiss="modal">Close</button>--%>
              <button type="button" id="btn_ok_error2" runat="server" class="btn btn-primary" data-dismiss="modal">OK</button>
            </div>
          </div>
          <!-- /.modal-content -->
        </div>
        <!-- /.modal-dialog -->
      </div>
      <!-- /.modal -->


  <%--Modal MENSAJE ERROR OK 3--%>
<div class="modal fade" id="modal-ok_error3" tabindex="-1" role="dialog" aria-labelledby="exampleModalCenterTitle" aria-hidden="true" data-backdrop="static" data-keyboard="false">
        <div class="modal-dialog modal-sm modal-dialog-centered " role="document">
          <div class="modal-content">
            <div class="modal-header">
              <h4 class="modal-title">Error</h4>
              <button type="button" id="btn_error_close3" runat="server" class="close" tabindex="-1" data-dismiss="modal" aria-label="Close">
                <span aria-hidden="true">&times;</span>
              </button>
            </div>
            <div class="modal-body">
              <p>Error, la busqueda no arrojo resultados!&hellip;</p>
            </div>
            <div class="modal-footer justify-content-center ">
            <%--<div class="modal-footer justify-content-between">--%>
              <%--<button type="button" class="btn btn-default" data-dismiss="modal">Close</button>--%>
              <button type="button" id="btn_ok_error3" runat="server" class="btn btn-primary" data-dismiss="modal">OK</button>
            </div>
          </div>
          <!-- /.modal-content -->
        </div>
        <!-- /.modal-dialog -->
      </div>
      <!-- /.modal -->


  <%--Modal MENSAJE ERROR OK 3--%>
<div class="modal fade" id="modal-ok" tabindex="-1" role="dialog" aria-labelledby="exampleModalCenterTitle" aria-hidden="true" data-backdrop="static" data-keyboard="false">
        <div class="modal-dialog modal-sm modal-dialog-centered " role="document">
          <div class="modal-content">
            <div class="modal-header">
              <h4 class="modal-title">Notificacion</h4>
              <button type="button" id="btn_ok_close" runat="server" class="close" tabindex="-1" data-dismiss="modal" aria-label="Close">
                <span aria-hidden="true">&times;</span>
              </button>
            </div>
            <div class="modal-body">
              <p>El archivo se genero correctamente!&hellip;</p>
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
