<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Home.Master" CodeBehind="Cobro_prestamos_manuales.aspx.vb" Inherits="Presentacion.Cobro_prestamos_manuales" %>
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

                     <div id="seccion_resultado_busqueda" visible="false" runat="server">
                       <div class="form-group">       
                            <div class="row justify-content-center">
                                  <div class="col-md-8">
                                        <label for="Label_clie">Prestamos activos para el cliente:</label>
                                        <asp:Label ID="Label_cliente" runat="server" Text=""></asp:Label>
                                  </div>  
                            </div>
                        </div>
                        <div class="form-group">       
                            <div class="row justify-content-center">
                                    <div class="col-md-8">
                                        <div class="card">
                                                <div class="card-body table-responsive p-0" style="height: 400px" onkeydown="tecla_op_botones(event);"> <%--div class="form-group"--%>
                            <asp:GridView ID="GridView1" runat="server" class="table table-head-fixed text-nowrap" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" 
                                   BorderColor="Black" GridLines="None" 
                                  EnableSortingAndPagingCallbacks="True"> 
                                    <Columns>
                                        <asp:BoundField DataField="Idprestamocredito" HeaderText="ID" >                                                               
                                        <HeaderStyle ForeColor="#0099FF" />
                                        </asp:BoundField>
                                        
                                        <asp:BoundField DataField="Fecha" HeaderText="Fecha" >
                                        <HeaderStyle ForeColor="#0099FF" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Importe" HeaderText="Importe" >
                                        <HeaderStyle ForeColor="#0099FF" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Saldo" HeaderText="Saldo" >
                                        <HeaderStyle ForeColor="#0099FF" />
                                        </asp:BoundField>
                                        
                                        
                                        <asp:TemplateField HeaderText="Seleccionar">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Button ID="Button1" runat="server" Font-Bold="True" ForeColor="Red" 
                                                    Text="Selec." Width="70px" CommandName="ID" 
                                                    CommandArgument='<%# Eval("Idprestamocredito") %>' />
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
                    
                 
         </div>

        </div>
        

</div>



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


<%--Modal MENSAJE OK ERROR_BUSQUEDA--%>
<div class="modal fade" id="modal_error_noactivos" tabindex="-1" role="dialog" aria-labelledby="exampleModalCenterTitle" aria-hidden="true" data-backdrop="static" data-keyboard="false">
        <div class="modal-dialog modal-sm modal-dialog-centered " role="document">
          <div class="modal-content">
            <div class="modal-header">
              <h4 class="modal-title">Error</h4>
              <button type="button" id="btn_close_error_noactivos" runat="server" class="close" tabindex="-1" data-dismiss="modal" aria-label="Close">
                <span aria-hidden="true">&times;</span>
              </button>
            </div>
            <div class="modal-body">
              <p>El cliente no posee prestamos activos!&hellip;</p>
            </div>
            <div class="modal-footer justify-content-center ">
            <%--<div class="modal-footer justify-content-between">--%>
              <%--<button type="button" class="btn btn-default" data-dismiss="modal">Close</button>--%>
              <button type="button" id="btn_ok_error_noactivos" runat="server" class="btn btn-primary" data-dismiss="modal">OK</button>
            </div>
          </div>
          <!-- /.modal-content -->
        </div>
        <!-- /.modal-dialog -->
      </div>
      <!-- /.modal -->


<div class="modal fade" id="modal-error_iniciar_dia" tabindex="-1" role="dialog" aria-labelledby="exampleModalCenterTitle" aria-hidden="true" data-backdrop="static" data-keyboard="false">
        <div class="modal-dialog modal-sm modal-dialog-centered " role="document">
          <div class="modal-content">
            <div class="modal-header">
              <h4 class="modal-title">Error!</h4>
              <button type="button" id="btn_error_iniciar_dia_close" runat="server" tabindex="-1" class="close" data-dismiss="modal" aria-label="Close">
                <span aria-hidden="true">&times;</span>
              </button>
            </div>
            <div class="modal-body">
              <p>Debe iniciar el dia!&hellip;</p>
            </div>
            <div class="modal-footer justify-content-center ">
            <%--<div class="modal-footer justify-content-between">--%>
              <%--<button type="button" class="btn btn-default" data-dismiss="modal">Close</button>--%>
              <button type="button" id="btn_error_iniciar_dia_ok" runat="server" tabindex="1"  class="btn btn-primary" data-dismiss="modal">OK</button>
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
