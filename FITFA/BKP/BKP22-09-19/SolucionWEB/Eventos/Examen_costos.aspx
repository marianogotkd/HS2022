<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/MasterPage.Master" CodeBehind="Examen_costos.aspx.vb" Inherits="fitfa.Examen_costos" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <asp:ScriptManager ID="ScriptManager1" runat="server" 
                        EnableScriptGlobalization="True">
            </asp:ScriptManager>
  <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
            
    
        <ContentTemplate>

<div class="card card-primary">
              <div class="card-header">
                <h3 class="card-title">Costos Para Examenes</h3>
              </div>
              <!-- /.card-header -->
              <!-- form start -->
              <form role="form">
                <div class="card-body">


                <div class="row">
                  <div class="col-md-4 col-center">
                                  
                  <div class="form-group" >
                     <asp:Label ID="Label_examenes" runat="server" Text="EXAMENES:" ForeColor="#CC00FF"></asp:Label>
                      <div id="Div3" class="card-body table-responsive p-0" runat ="server">
                      <asp:GridView ID="GridView_examenes" class="table table-hover" runat="server" 
                AllowSorting="True" AutoGenerateColumns="False" 
                           BorderColor="Black" GridLines="None" 
                          EnableSortingAndPagingCallbacks="True">
                          <Columns>
                              <asp:BoundField DataField="Costos_id" HeaderText="ID" />
                              <asp:BoundField DataField="Costos_descripcion" HeaderText="Graduación" />
                              <asp:BoundField DataField="Costos_monto" HeaderText="Monto ($)" />
                              <asp:BoundField DataField="Costos_tipo" HeaderText="Costos_tipo" 
                                  Visible="False" />
                              <asp:BoundField DataField="graduacion_id" HeaderText="graduacion_id" 
                                  Visible="False" />
                              <asp:TemplateField HeaderText="Check">
                                  <EditItemTemplate>
                                      <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                                  </EditItemTemplate>
                                  <ItemTemplate>
                                      <asp:CheckBox ID="chk_select" runat="server" />
                                  </ItemTemplate>
                              </asp:TemplateField>
                          </Columns>
                      </asp:GridView>
                  
                  </div>
                      <asp:Label ID="Label1" runat="server" Text="Ingrese monto:"></asp:Label>
                      &nbsp;<asp:TextBox ID="txt_montoexamen" runat="server">0,00</asp:TextBox>
                      &nbsp;<asp:Button ID="Btn_confirmar_montoexamen" runat="server" 
                          Text="Guardar cambios" BackColor="#99CCFF" BorderColor="#3399FF" 
                          ForeColor="White" Width="131px" />
                          
                      <br />
                      <asp:Label ID="Label_error_monto1" runat="server" ForeColor="Red" 
                          Text="* ingrese un valor válido" Visible="False"></asp:Label>
                      <br />
                                   
                  </div>
                                                         
                    </div>
                    <div class="col-md-4 col-center">
                  <div class="form-group" >
                  <asp:Label ID="Label2" runat="server" Text="OTROS COSTOS:" ForeColor="#CC00FF"></asp:Label>
                  <div id="Div1" class="card-body table-responsive p-0" runat ="server">
                      <asp:GridView ID="GridView_OTROS" class="table table-hover" runat="server" 
                AllowSorting="True" AutoGenerateColumns="False" 
                           BorderColor="Black" GridLines="None" 
                          EnableSortingAndPagingCallbacks="True">
                          <Columns>
                              <asp:BoundField DataField="Costos_id" HeaderText="ID" />
                              <asp:BoundField DataField="Costos_descripcion" HeaderText="Descripción" />
                              <asp:BoundField DataField="Costos_monto" HeaderText="Monto ($)" />
                              <asp:BoundField DataField="Costos_tipo" HeaderText="Costos_tipo" 
                                  Visible="False" />
                              <asp:BoundField DataField="graduacion_id" HeaderText="graduacion_id" 
                                  Visible="False" />
                              <asp:TemplateField HeaderText="Check">
                                  <EditItemTemplate>
                                      <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                                  </EditItemTemplate>
                                  <ItemTemplate>
                                      <asp:CheckBox ID="chk_select" runat="server" />
                                  </ItemTemplate>
                              </asp:TemplateField>
                          </Columns>
                      </asp:GridView>
                  
                  </div>
                  <asp:Label ID="Label3" runat="server" Text="Ingrese monto:"></asp:Label>
                      &nbsp;<asp:TextBox ID="txt_monto_otro" runat="server">0,00</asp:TextBox>
                      &nbsp;<asp:Button ID="Btn_confirmar_montootros" runat="server" 
                          Text="Guardar cambios" BackColor="#99CCFF" BorderColor="#3399FF" 
                          ForeColor="White" Width="131px" />
                          
                      <br />
                      <asp:Label ID="Label_error_monto2" runat="server" ForeColor="Red" 
                          Text="* ingrese un valor válido" Visible="False"></asp:Label>
                      <br />    
                  </div>
                  
                  
                  </div>



                </div>


                
              
                    
          <div class="card-footer">
                </div>
                <label id="lbl_ok" class="label label-warning" visible="False" runat="server" >Evento Creado  </label>
                <div id="div_registro_guardado" runat="server" visible="false" 
                style="color: #00CC00; font-style: normal; font-variant: normal;">
                    Datos actualizados!
                </div>
                    


        <div id="div_modalOK" runat="server">
                                <asp:HiddenField ID="HiddenField_msj" runat="server" />
                                    <asp:Panel ID="Panel1" runat="server" >
              
                                        <div class="card card-success">
                                        <div class="card-header">
                                            <h3 class="card-title">Evento</h3>
                                        </div>
                                        <form role="form">
                                          <div class="card-body"> 
                                            <div class="row">
                                                <div align="center">
                                                    <asp:Label ID="Label16" runat="server" Text="Cambios realizados correctamente."></asp:Label>
                                                    &nbsp;
                                                </div>
                                            </div>
                                          </div>
                                        </form>  
                                        <div align="center">
                                                <asp:Button ID="Btb_msj_no_eventos" runat="server" Text="OK" CssClass="btn btn-success"  />
                                          </div> 
                                          <div>
                                             &nbsp;
                                          </div>             
                                        </div> 
                                    </asp:Panel>
        
            <asp:ModalPopupExtender ID="Modal_OK" runat="server" TargetControlID="HiddenField_msj" PopupControlID="Panel1" CancelControlID="Btb_msj_no_eventos" BackgroundCssClass="modalBackground">
            </asp:ModalPopupExtender>
                           
    
        </div>



                    </form>
            
                           
            
            
            </div>

                  </ContentTemplate>

                       
       
       
</asp:UpdatePanel>
</asp:Content>
