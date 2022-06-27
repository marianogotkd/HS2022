<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Home.Master" CodeBehind="LiquidacionGrupos_det.aspx.vb" Inherits="Presentacion.LiquidacionGrupos_det" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="True"></asp:ScriptManager>
  <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
      <div class="card card-primary">
          <div class="card-header">
                <h3 class="card-title">LIQUIDACION DE GRUPOS</h3>
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
              
                <div class="col-lg"> <%--estaba col-8--%>
                  
                <div class="card">
                    
                    <div class="card-body table-responsive p-0" style="height: 400px" onkeydown="tecla_op_botones(event);"> <%--div class="form-group"--%>
                            <asp:GridView ID="GridView1" runat="server" class="table table-head-fixed text-nowrap" AllowPaging="False" AllowSorting="True" AutoGenerateColumns="False" 
                                   BorderColor="Black" GridLines="None" 
                                  EnableSortingAndPagingCallbacks="True"  ShowHeader="False"> 
                                    <Columns>
                                        <asp:BoundField DataField="Columna1" HeaderText="Columna1" >                                                               
                                        <HeaderStyle ForeColor="#0099FF" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Columna2" HeaderText="Columna2" >                                                               
                                        <HeaderStyle ForeColor="#0099FF" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Columna3" HeaderText="Columna3" >                                                               
                                        <HeaderStyle ForeColor="#0099FF" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Columna4" HeaderText="Columna4" >                                                               
                                        <HeaderStyle ForeColor="#0099FF" />
                                        </asp:BoundField>
                                      
                                        
                                    </Columns>
                                </asp:GridView>
                        </div>

                  <div>
                          <asp:Label ID="Label_noregalos" runat="server" Text="No se registro liquidacion!" Visible="false" ForeColor="#6699FF"></asp:Label>

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
