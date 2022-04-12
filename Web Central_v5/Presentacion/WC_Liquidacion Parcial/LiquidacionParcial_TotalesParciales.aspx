<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Home.Master" CodeBehind="LiquidacionParcial_TotalesParciales.aspx.vb" Inherits="Presentacion.LiquidacionParcial_TotalesParciales" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="True"></asp:ScriptManager>
<asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
      <div class="card card-primary">
          <div class="card-header">
                <h3 class="card-title">LIQUIDACION PARCIAL - TOTALES PARCIALES</h3>
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
                                        <div class="form-group">
                                                <asp:HiddenField ID="HF_parametro_id" runat="server" />
                                            <asp:Label ID="LABEL_FECHA" runat="server" Text="TOTALES PARCIALES PARA LA FECHA:"></asp:Label>
                                          <asp:Label ID="LABEL_fecha_parametro" runat="server" Text=""></asp:Label>
                                            
                                          <asp:HiddenField ID="HF_fecha" runat="server" />
                                        </div>
                                        
                                    
                                </div>
                                <div class="col-4">
                                  
                                                                        
                                </div>
                                <div class="col-4">
                                    
                                                                        
                                </div>

                        </div>
                </div>


                
          <div class="form-group">
              <div class="row justify-content-center">
              
                <div class="col-8">
                  <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False">
                      <Columns>
                          <asp:BoundField DataField="Terminal" />
                          <asp:BoundField DataField="Registros" />
                          <asp:BoundField DataField="NoVerificados" />
                      </Columns>
                    </asp:GridView>
                <div class="card">
                    
                    <div class="card-body table-responsive p-0" style="height: 400px" onkeydown="tecla_op_botones(event);"> <%--div class="form-group"--%>
                            <asp:GridView ID="GridView1" runat="server" class="table table-head-fixed text-nowrap" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" 
                                   BorderColor="Black" GridLines="None" 
                                  EnableSortingAndPagingCallbacks="True"  ShowHeader="False"> 
                                    <Columns>
                                        <asp:BoundField DataField="Terminal" HeaderText="Terminal" >                                                               
                                        <HeaderStyle ForeColor="#0099FF" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Registros" HeaderText="Registros" >                                                               
                                        <HeaderStyle ForeColor="#0099FF" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="NoVerificados" HeaderText="No Verificados" >                                                               
                                        <HeaderStyle ForeColor="#0099FF" />
                                        </asp:BoundField>
                                        
                                        
                                    </Columns>
                                </asp:GridView>
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

    </ContentTemplate>
  </asp:UpdatePanel>

</asp:Content>
