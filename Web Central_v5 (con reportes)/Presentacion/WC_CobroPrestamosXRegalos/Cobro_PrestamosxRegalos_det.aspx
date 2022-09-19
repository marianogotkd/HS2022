<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Home.Master" CodeBehind="Cobro_PrestamosxRegalos_det.aspx.vb" Inherits="Presentacion.Cobro_PrestamosxRegalos_det" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="True"></asp:ScriptManager>
<asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
      <div class="card card-primary">
          <div class="card-header">
                <h3 class="card-title">COBRO DE PRESTAMOS X REGALOS</h3>
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
                                            <asp:Label ID="LABEL_FECHA" runat="server" Text="COBRO DE PRESTAMOS X REGALOS EN LA FECHA:"></asp:Label>
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
                            <asp:GridView ID="GridView1" runat="server" class="table table-head-fixed text-nowrap" AllowPaging="False" AllowSorting="True" AutoGenerateColumns="False" 
                                   BorderColor="Black" GridLines="None" 
                                  EnableSortingAndPagingCallbacks="True"  ShowHeader="False"> 
                                    <Columns>
                                        <asp:BoundField DataField="Cliente" HeaderText="CLIENTE" >                                                               
                                        <HeaderStyle ForeColor="#0099FF" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Fecha_Ori" HeaderText="FECHA ORI" >                                                               
                                        <HeaderStyle ForeColor="#0099FF" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Importe" HeaderText="IMPORTE COB" >                                                               
                                        <HeaderStyle ForeColor="#0099FF" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Saldo" HeaderText="SALDO PRESTAMO" >                                                               
                                        <HeaderStyle ForeColor="#0099FF" />
                                        </asp:BoundField>
                                      
                                        
                                    </Columns>
                                </asp:GridView>
                        </div>

                  <div>
                          <asp:Label ID="Label_noregalos" runat="server" Text="La consulta no arrojo resultados!" Visible="false" ForeColor="#6699FF"></asp:Label>

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

      




    </ContentTemplate>
  </asp:UpdatePanel>
</asp:Content>
