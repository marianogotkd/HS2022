<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Home.Master" CodeBehind="CodigoMasPremiado.aspx.vb" Inherits="Presentacion.CodigoMasPremiado" %>
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
                <h3 class="card-title">CODIGOS MAS CARGADOS</h3>
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
                                <asp:HiddenField ID="HF_fecha" runat="server" />
                                    <%--<div class="col-md-4">
                                    </div>--%>
                            </div>
                    </div>

              <div class="form-group">       
                <div class="row justify-content-center">
                  <div class="col-md-4">
                                                <label for="lblClienteDesde">DESDE CLIENTE</label>
                                                <asp:TextBox ID="txtClienteDesde" runat="server" 
                                                    placeholder="." class="form-control" 
                                                    onkeydown="tecla_op(event);" onkeypress="return justNumbers(event);" 
                                                    MaxLength="4"></asp:TextBox>
                                                <asp:Label ID="lb_error_codigo" runat="server" ForeColor="Red" Text="*" Visible="false"></asp:Label>
                                                
                                    </div>
                  <div class="col-md-8">
                                          
                                                
                                    </div>
                  </div>
                </div>
                    <div class="form-group">       
                                <div class="row justify-content-center">
                                        
                                    

                                    <div class="col-md-4">
                                                  <caption>
                                                      <label for="lblClienteHasta">
                                                      HASTA CLIENTE</label>
                                                      <asp:TextBox ID="txtClienteHasta" runat="server" class="form-control" MaxLength="4" onkeydown="tecla_op(event);" onkeypress="return justNumbers(event);" placeholder=""></asp:TextBox>
                                                      <asp:Label ID="Label1" runat="server" ForeColor="Red" Text="*" Visible="false"></asp:Label>
                                                  </caption>
                                                
                                     </div>
                                  <div class="col-md-8">
                                    
                                  
                                  </div>
                               

                    </div>
          </div>
              <div class="form-group">       
                <div class="row justify-content-center">
                  <div class="col-md-4">
                                                  <label for="lblImporte1">IMPORTE MINIMO PARA 1 CIFRA:</label>
                                                  <asp:TextBox ID="txtImporte1" runat="server" class="form-control" placeholder="0,00" CausesValidation="True" validationgroup="check_2" xmlns:asp="#unknown2" MaxLength="17" onkeydown="tecla_op(event);" onkeypress="return validateDecimalKeyPress(this, event);"></asp:TextBox>
                                                  <asp:Label ID="Label2" runat="server" ForeColor="Red" Text="*" Visible="False"></asp:Label>
                            
                                     </div>

                  <div class="col-md-8">
                                      
                            
                                     </div>

                  </div>

                </div>
              <div class="form-group">       
                <div class="row justify-content-center">
                              <div class="col-md-4">
                                                  <label for="lblImporte2">IMPORTE MINIMO PARA 2 CIFRAS:</label>
                                                  <asp:TextBox ID="txtImporte2" runat="server" class="form-control" placeholder="0,00" CausesValidation="True" validationgroup="check_2" xmlns:asp="#unknown2" MaxLength="17" onkeydown="tecla_op(event);" onkeypress="return validateDecimalKeyPress(this, event);"></asp:TextBox>
                                                  <asp:Label ID="Label3" runat="server" ForeColor="Red" Text="*" Visible="False"></asp:Label>
                            
                                     </div>

                    <div class="col-md-8">

                      </div>
                  </div>
                </div>

              <div class="form-group">       
                <div class="row justify-content-center">
                                <div class="col-md-4">
                                                    <label for="lblImporte4">IMPORTE MINIMO PARA 3 CIFRAS:</label>
                                                    <asp:TextBox ID="txtImporte3" runat="server" class="form-control" placeholder="0,00" CausesValidation="True" validationgroup="check_2" xmlns:asp="#unknown2" MaxLength="17" onkeydown="tecla_op(event);" onkeypress="return validateDecimalKeyPress(this, event);"></asp:TextBox>
                                                    <asp:Label ID="Label4" runat="server" ForeColor="Red" Text="*" Visible="False"></asp:Label>
                            
                                       </div>

                    <div class="col-md-8">

                      </div>
                  </div>
                </div>


              <div class="form-group">       
                  <div class="row justify-content-center">
                                     
                 
                                      <div class="col-md-4">
                                                    <label for="lblImporte4">IMPORTE MINIMO PARA 4 CIFRAS:</label>
                                                    <asp:TextBox ID="txtImporte4" runat="server" class="form-control" placeholder="0,00" CausesValidation="True" validationgroup="check_2" xmlns:asp="#unknown2" MaxLength="17" onkeydown="tecla_op(event);" onkeypress="return validateDecimalKeyPress(this, event);"></asp:TextBox>
                                                    <asp:Label ID="Label5" runat="server" ForeColor="Red" Text="*" Visible="False"></asp:Label>
                            
                                       </div>
                    <div class="col-md-8">

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
        
                                
        
                &nbsp; </div>
           <div class="form-group">
                                <button type="button" Class="btn btn-primary" id = "btnBuscar" runat="server" onkeydown="tecla_op_botones(event);">BUSCAR</button>
        
                                
        
                 &nbsp; </div>
            
         </div>

        </div>
        

</div>

  <div id="seccion1" runat="server" visible="false">
    <div class="row justify-content-center">
    <table class="centerTable">
      <tr>
      <th>UNA CIFRA</th>
      <th>DOS CIFRAS</th>
      <th>TRES CIFRAS</th>
      <th>CUATRO CIFRAS</th>
     </tr>
      <tr valign="top">
        <td>
            
            <asp:GridView ID="grvCifra1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
                <AlternatingRowStyle BackColor="White" />
                <EditRowStyle BackColor="#2461BF" />
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#EFF3FB" />
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#F5F7FB" />
                <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                <SortedDescendingCellStyle BackColor="#E9EBEF" />
                <SortedDescendingHeaderStyle BackColor="#4870BE" />
            </asp:GridView>
            

        </td>
        <td>
          <asp:GridView ID="grvCifra2" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
                <AlternatingRowStyle BackColor="White" />
                <EditRowStyle BackColor="#2461BF" />
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#EFF3FB" />
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#F5F7FB" />
                <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                <SortedDescendingCellStyle BackColor="#E9EBEF" />
                <SortedDescendingHeaderStyle BackColor="#4870BE" />
            </asp:GridView>
        </td>
        <td>
          <asp:GridView ID="grvCifra3" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
                <AlternatingRowStyle BackColor="White" />
                <EditRowStyle BackColor="#2461BF" />
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#EFF3FB" />
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#F5F7FB" />
                <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                <SortedDescendingCellStyle BackColor="#E9EBEF" />
                <SortedDescendingHeaderStyle BackColor="#4870BE" />
            </asp:GridView>
        </td>
        <td>
         <asp:GridView ID="grvCifra4" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
                <AlternatingRowStyle BackColor="White" />
                <EditRowStyle BackColor="#2461BF" />
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#EFF3FB" />
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#F5F7FB" />
                <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                <SortedDescendingCellStyle BackColor="#E9EBEF" />
                <SortedDescendingHeaderStyle BackColor="#4870BE" />
            </asp:GridView>
        </td>
      </tr>

    </table>

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
              <button type="button" id="btn_close_error_ingreso" runat="server" tabindex="-1" class="close" data-dismiss="modal" aria-label="Close">
                <span aria-hidden="true">&times;</span>
              </button>
            </div>
            <div class="modal-body">
              <p>Ingrese los datos solicitados!&hellip;</p>
            </div>
            <div class="modal-footer justify-content-center ">
            <%--<div class="modal-footer justify-content-between">--%>
              <%--<button type="button" class="btn btn-default" data-dismiss="modal">Close</button>--%>
              <button type="button" id="btn_ok_error_ingreso" runat="server" tabindex="1"  class="btn btn-primary" data-dismiss="modal">OK</button>
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

<!-- Modal GRABAR ALTA CENTRADO EN PANTALLA -->
<div class="modal fade" id="Mdl_graba_alta" tabindex="-1" role="dialog" aria-labelledby="exampleModalCenterTitle" aria-hidden="true" data-backdrop="static" data-keyboard="false">
  <div class="modal-dialog modal-dialog-centered" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <h5 class="modal-title" id="H1">Graba</h5>
        <button type="button" id="btn_graba_alta_close" class="close" tabindex="-1" runat="server" data-dismiss="modal" aria-label="Close">
          <span aria-hidden="true">&times;</span>
        </button>
      </div>
      <div class="modal-body">
        ¿Desea guardar el crédito?...
      </div>
      <div class="modal-footer">
        <button type="button" id="btn_graba_alta_cancelar" class="btn btn-secondary" runat="server" data-dismiss="modal">Cancelar</button>
        <button type="button" id="btn_graba_alta_confirmar" class="btn btn-primary" runat="server" data-dismiss="modal">Confirmar</button>
      </div>
    </div>
  </div>
</div>


<!-- Modal GRABAR MODIFICACION CENTRADO EN PANTALLA -->
<div class="modal fade" id="Mdl_graba_modif" tabindex="-1" role="dialog" aria-labelledby="exampleModalCenterTitle" aria-hidden="true" data-backdrop="static" data-keyboard="false">
  <div class="modal-dialog modal-dialog-centered" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <h5 class="modal-title" id="H2">Graba</h5>
        <button type="button" id="btn_graba_modif_close" class="close" tabindex="-1" runat="server" data-dismiss="modal" aria-label="Close">
          <span aria-hidden="true">&times;</span>
        </button>
      </div>
      <div class="modal-body">
        ¿Desea modificar el crédito?...
      </div>
      <div class="modal-footer">
        <button type="button" id="btn_graba_modif_cancelar" class="btn btn-secondary" runat="server" data-dismiss="modal">Cancelar</button>
        <button type="button" id="btn_graba_modif_confirmar" class="btn btn-primary" runat="server" data-dismiss="modal">Confirmar</button>
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

        <%--Modal MENSAJE OK ERROR BUSQUEDA SIN RESULTADOS--%>
<div class="modal fade" id="modal_msjerror_busqueda01" tabindex="-1" role="dialog" aria-labelledby="exampleModalCenterTitle" aria-hidden="true" data-backdrop="static" data-keyboard="false">
        <div class="modal-dialog modal-sm modal-dialog-centered " role="document">
          <div class="modal-content">
            <div class="modal-header">
              <h4 class="modal-title">Error</h4>
              <button type="button" id="btn_close_error_busqueda01" runat="server" class="close" tabindex="-1" data-dismiss="modal" aria-label="Close">
                <span aria-hidden="true">&times;</span>
              </button>
            </div>
            <div class="modal-body">
              <p>La busqueda no arrojo resultados!&hellip;</p>
            </div>
            <div class="modal-footer justify-content-center ">
            <%--<div class="modal-footer justify-content-between">--%>
              <%--<button type="button" class="btn btn-default" data-dismiss="modal">Close</button>--%>
              <button type="button" id="btn_ok_error_busqueda01" runat="server" class="btn btn-primary" data-dismiss="modal">OK</button>
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
