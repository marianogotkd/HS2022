<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Home.Master" CodeBehind="LiquidacionFinal_PrestamosManuales.aspx.vb" Inherits="Presentacion.LiquidacionFinal_PrestamosManuales" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="True"></asp:ScriptManager>
  <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
      <div class="card card-primary">
          <div class="card-header">
                <h3 class="card-title">LIQUIDACION FINAL - COBRO DE PRESTAMOS MANUALES</h3>
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
                                <div class="col-lg"> <%--antes col-4--%>
                                        <div class="form-group">
                                                <asp:HiddenField ID="HF_parametro_id" runat="server" />
                                            <asp:Label ID="LABEL_FECHA" runat="server" Text="COBRO DE PRESTAMOS MANUALES EN LA FECHA:"></asp:Label>
                                          <asp:Label ID="LABEL_fecha_parametro" runat="server" Text=""></asp:Label>
                                            
                                          <asp:HiddenField ID="HF_fecha" runat="server" />
                                        </div>
                                        
                                    
                                </div>
                                <%--<div class="col-4">
                                  
                                                                        
                                </div>
                                <div class="col-4">
                                    
                                                                        
                                </div>--%>

                        </div>
                </div>


                
          <div class="form-group">
              <div class="row justify-content-center">
              
                <div class="col-lg"> <%--estaba col-8--%>
                  
                <div class="card">
                    
                    <div class="card-body table-responsive p-0" style="height: 400px" onkeydown="tecla_op_botones(event);"> <%--div class="form-group"--%>
                            <asp:GridView ID="GridView1" runat="server" class="table table-head-fixed text-nowrap" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" 
                                   BorderColor="Black" GridLines="None" 
                                  EnableSortingAndPagingCallbacks="True"  ShowHeader="True"> 
                                    <Columns>
                                        <asp:BoundField DataField="Cliente" HeaderText="CLIENTE" >                                                               
                                        <HeaderStyle ForeColor="#0099FF" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Fecha_Ori" HeaderText="FECHA ORI" >                                                               
                                        <HeaderStyle ForeColor="#0099FF" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Importe_Cob" HeaderText="IMPORTE COB" >                                                               
                                        <HeaderStyle ForeColor="#0099FF" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Saldo" HeaderText="SALDO" >                                                               
                                        <HeaderStyle ForeColor="#0099FF" />
                                        </asp:BoundField>
                                      <asp:BoundField DataField="Prestamo" HeaderText="PRESTAMO" >                                                               
                                        <HeaderStyle ForeColor="#0099FF" />
                                        </asp:BoundField>
                                        
                                    </Columns>
                                </asp:GridView>
                        </div>

                  <div>
                          <asp:Label ID="Label_noprestamos" runat="server" Text="No se registraron cobros de prestamos manuales!" Visible="false" ForeColor="#6699FF"></asp:Label>

                  </div>


                    </div>  
                
                
                </div>
               
              </div>

          </div>
            


        </div>

        <div class="card-footer">
        <div class="row justify-content-center" >
        <div class="row align-items-center">
            <div class="form-group">
            <button type="submit" UseSubmitBehavior="false" class="btn btn-primary" runat="server" id="btn_continuar" onkeydown="tecla_op_botones(event);">
                CONTINUAR</button>
            &nbsp;
            </div>

            

            <div class="form-group">
            <button type="button" id="BOTON_GRABAR" runat="server" class="btn btn-primary" onkeydown="tecla_op_botones(event);"> <%--data-targe="#modal-primary"--%>
                  IMPRIMIR
                </button>
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
              <p>Error, primero debe iniciar dia!&hellip;</p>
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




      <!-- Modal GRABAR MODIFICACION CENTRADO EN PANTALLA -->
<div class="modal fade" id="Mdl_CobroPrestamosxComision" tabindex="-1" role="dialog" aria-labelledby="exampleModalCenterTitle" aria-hidden="true" data-backdrop="static" data-keyboard="false">
  <div class="modal-dialog modal-dialog-centered" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <h5 class="modal-title" id="H2"></h5>
        <button type="button" id="btn_CobroPresCom_close" class="close" tabindex="-1" runat="server" data-dismiss="modal" aria-label="Close">
          <span aria-hidden="true">&times;</span>
        </button>
      </div>
      <div class="modal-body">
        Desea descontar "Prestamos por Comision"?...
      </div>
      <div class="modal-footer">
        <button type="button" id="btn_CobroPresCom_no" class="btn btn-secondary" runat="server" data-dismiss="modal">No</button>
        <button type="button" id="btn_CobroPresCom_si" class="btn btn-primary" runat="server" data-dismiss="modal">Si</button>
      </div>
    </div>
  </div>
</div>

    </ContentTemplate>
  </asp:UpdatePanel>
</asp:Content>
