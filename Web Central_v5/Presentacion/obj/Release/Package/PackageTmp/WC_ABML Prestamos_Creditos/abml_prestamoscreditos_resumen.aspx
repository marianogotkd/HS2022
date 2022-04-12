<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Home.Master" CodeBehind="abml_prestamoscreditos_resumen.aspx.vb" Inherits="Presentacion.abml_prestamoscreditos_resumen" %>
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
//        if (keycode == '119') {
//            e.preventDefault();
//            document.getElementsByTagName('button')[2].focus();
//            document.getElementsByTagName('button')[2].click();
//        }
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
//        if (keycode == '119') {
//            e.preventDefault();
//            document.getElementsByTagName('button')[2].focus();
//            document.getElementsByTagName('button')[2].click();
//        }
    
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
//        if (keycode == '119') {
//            e.preventDefault();
//            document.getElementsByTagName('button')[2].focus();
//            document.getElementsByTagName('button')[2].click();
//        }
    }


    //funcion para seleccionar todo le contenido de un textbox cuando se pone el foco sobre el control. se agrega como atributo en el codebehind
    function seleccionarTexto(obj) {
        if (obj != null) {
            obj.select();
        }
    }


//    /* Sets focus on the first element of the form */
//    $(document).ready(function () {

//        

//        $("#modal_error_busqueda").on('shown.bs.modal', function (event) {
//            // not setting focus to submit button
//            $("#btn_ok_error_busqueda").focus();
//        });
//    });






</script>





</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="True"></asp:ScriptManager>
<asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
<ContentTemplate>
<div class="card card-primary">
<div class="card-header">
                <h3 class="card-title">A.B.M.L. PRESTAMOS Y CREDITOS.</h3>
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
                                        <label for="Label_cliente_id">OPCION 3: RESUMEN.</label>
                                        <asp:HiddenField ID="Hf_FECHA" runat="server" />
                                    </div>
                             
                            </div>
                            </div>
                            
                            <div id="Div1" class="row justify-content-center" visible="True" runat="server">
                    <div class="col-md-12">
                    <div class="card">
                    <div class="card-header">
                              <%--<h3 class="card-title">RESUMEN A LA FECHA:</h3>--%>

                              <div class="card-tools">
                                    <div class="input-group input-group-sm" style="width: 200px;">
                                    <%--<input type="text" id="txt_buscar" runat="server" onkeydown="tecla_op(event);" name="table_search" class="form-control float-right" placeholder="Buscar...">--%>
                                    <asp:TextBox ID="txt_fecha" runat="server" onkeydown="tecla_op_BUSQUEDA(event);" name="table_search" class="form-control float-right" TextMode="Date" ></asp:TextBox>
                                    <div class="input-group-append">
                                    <button type="submit" id="btn_buscar" runat="server" class="btn btn-default" onkeydown="tecla_op_botones(event);"><i class="fas fa-search"></i></button>
                                    </div>
                                    </div>
                            </div>
                    </div>
                    <!-- /.card-header -->
                    <div class="card-body table-responsive p-0" style="height: 400px" onkeydown="tecla_op_botones(event);"> <%--div class="form-group"--%>
                            <asp:GridView ID="GridView1" runat="server" class="table table-head-fixed text-nowrap" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" 
                                   BorderColor="Black" GridLines="None" 
                                  EnableSortingAndPagingCallbacks="True"> 
                                    <Columns>
                                        <asp:BoundField DataField="ID" HeaderText="ID" >                                                               
                                        <HeaderStyle ForeColor="#0099FF" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Tipo" HeaderText="Tipo" >                                                               
                                        <HeaderStyle ForeColor="#0099FF" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Cliente" HeaderText="Cliente" >                                                               
                                        <HeaderStyle ForeColor="#0099FF" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Nombre" HeaderText="Nombre" >
                                        <HeaderStyle ForeColor="#0099FF" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Importe" HeaderText="Importe" >
                                        <HeaderStyle ForeColor="#0099FF" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Saldo" HeaderText="Saldo">
                                        <HeaderStyle ForeColor="#0099FF" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Porcentaje" HeaderText="%">
                                        <HeaderStyle ForeColor="#0099FF" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Cobro" HeaderText="Cobro" >
                                        <HeaderStyle ForeColor="#0099FF" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Estado" HeaderText="Estado">
                                        <HeaderStyle ForeColor="#0099FF" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Fecha" HeaderText="Fecha" >
                                        <HeaderStyle ForeColor="#0099FF" />
                                        </asp:BoundField>
                                        <asp:TemplateField HeaderText="Eliminar">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Button ID="Button1" runat="server" Font-Bold="True" ForeColor="Red" 
                                                    Text="Eliminar" Width="70px" CommandName="ID" CommandArgument='<%# Eval("ID") %>' />
                                            </ItemTemplate>
                                            <HeaderStyle ForeColor="#0099FF" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Dar de baja">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Button ID="Button2" runat="server" Font-Bold="True" ForeColor="Red" 
                                                    Text="Dar de baja" Width="98px" CommandName="ID_baja" 
                                                    CommandArgument='<%# Eval("ID") %>' />
                                            </ItemTemplate>
                                            <HeaderStyle ForeColor="#0099FF" />
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                        </div>


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
                    &nbsp;
                    

        
        
                    </div>

                    <div class="form-group">
                     <input type="button" class="btn btn btn-success" id="btnExport_Examen" value="EXPORTAR A EXCEL" onkeydown="tecla_op_botones(event);" />
                    </div>
                 
                
         </div>

        </div>
        

</div>


<!-- Modal BAJA CENTRADO EN PANTALLA -->
<div class="modal fade" id="Mdl_eliminar" tabindex="-1" role="dialog" aria-labelledby="exampleModalCenterTitle" aria-hidden="true" data-backdrop="static" data-keyboard="false">
  <div class="modal-dialog modal-dialog-centered" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <h5 class="modal-title" id="H1">Eliminar registro</h5>
        <button type="button" id="btn_eliminar1_close" class="close" runat="server" tabindex="-1" data-dismiss="modal" aria-label="Close">
          <span aria-hidden="true">&times;</span>
        </button>
      </div>
      <div class="modal-body">
        ¿Confirma la operación?...
      </div>
      <div class="modal-footer">
        <button type="button" id="btn_eliminar_mdl_cancelar" class="btn btn-secondary" runat="server" data-dismiss="modal">Cancelar</button>
        <button type="button" id="btn_eliminar_mdll" class="btn btn-primary" runat="server" data-dismiss="modal">Confirmar</button>
      </div>
    </div>
  </div>
</div>


<%--Modal MENSAJE OK ELIMINADO CORRECTAMENTE--%>
<div class="modal fade" id="modal-sm_OKELIMINADO" tabindex="-1" role="dialog" aria-labelledby="exampleModalCenterTitle" aria-hidden="true" data-backdrop="static" data-keyboard="false">
        <div class="modal-dialog modal-sm modal-dialog-centered " role="document">
          <div class="modal-content">
            <div class="modal-header">
              <h4 class="modal-title">Eliminar registro</h4>
              <button type="button" id="btn_ELIMINAR_close" runat="server" class="close" tabindex="-1" data-dismiss="modal" aria-label="Close">
                <span aria-hidden="true">&times;</span>
              </button>
            </div>
            <div class="modal-body">
              <p>Se eliminó correctamente!&hellip;</p>
            </div>
            <div class="modal-footer justify-content-center ">
            <%--<div class="modal-footer justify-content-between">--%>
              <%--<button type="button" class="btn btn-default" data-dismiss="modal">Close</button>--%>
              <button type="button" id="btn_ok_elimnar" runat="server" class="btn btn-primary" data-dismiss="modal">OK</button>
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
        <h5 class="modal-title" id="H2">Dar de Baja</h5>
        <button type="button" id="Button3" class="close" runat="server" tabindex="-1" data-dismiss="modal" aria-label="Close">
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

<%--Modal MENSAJE OK ELIMINADO CORRECTAMENTE--%>
<div class="modal fade" id="modal-sm_OKBAJA" tabindex="-1" role="dialog" aria-labelledby="exampleModalCenterTitle" aria-hidden="true" data-backdrop="static" data-keyboard="false">
        <div class="modal-dialog modal-sm modal-dialog-centered " role="document">
          <div class="modal-content">
            <div class="modal-header">
              <h4 class="modal-title">Dar de baja</h4>
              <button type="button" id="btn_BAJA_close" runat="server" class="close" tabindex="-1" data-dismiss="modal" aria-label="Close">
                <span aria-hidden="true">&times;</span>
              </button>
            </div>
            <div class="modal-body">
              <p>Baja correcta!&hellip;</p>
            </div>
            <div class="modal-footer justify-content-center ">
            <%--<div class="modal-footer justify-content-between">--%>
              <%--<button type="button" class="btn btn-default" data-dismiss="modal">Close</button>--%>
              <button type="button" id="btn_ok_baja" runat="server" class="btn btn-primary" data-dismiss="modal">OK</button>
            </div>
          </div>
          <!-- /.modal-content -->
        </div>
        <!-- /.modal-dialog -->
      </div>
      <!-- /.modal -->


<%--Modal MENSAJE OK ERROR_BUSQUEDA--%>
<div class="modal fade" id="modal_error_busqueda" tabindex="-1" role="dialog" aria-labelledby="exampleModalCenterTitle" aria-hidden="true" data-backdrop="static" data-keyboard="false">
        <div class="modal-dialog modal-sm modal-dialog-centered " role="document">
          <div class="modal-content">
            <div class="modal-header">
              <h4 class="modal-title">Error</h4>
              <button type="button" id="btn_close_error_busqueda" runat="server" class="close" tabindex="-1" data-dismiss="modal" aria-label="Close">
                <span aria-hidden="true">&times;</span>
              </button>
            </div>
            <div class="modal-body">
              <p>La busqueda no arrojó resultados!&hellip;</p>
            </div>
            <div class="modal-footer justify-content-center ">
            <%--<div class="modal-footer justify-content-between">--%>
              <%--<button type="button" class="btn btn-default" data-dismiss="modal">Close</button>--%>
              <button type="button" id="btn_ok_error_busqueda" runat="server" class="btn btn-primary" data-dismiss="modal">OK</button>
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
