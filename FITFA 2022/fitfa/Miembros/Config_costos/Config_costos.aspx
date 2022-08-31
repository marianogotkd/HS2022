<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/MasterPage.Master" CodeBehind="Config_costos.aspx.vb" Inherits="fitfa.Config_costos" %>

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
                <h3 class="card-title">Configurar liquidación de miembros</h3>
</div>
              <form role="form">
                <div class="card-body">


                <div class="row">
                  <div class="col-md-4 col-center">
                                  
                  <div class="form-group" >
                                           
                      <asp:Label ID="Label17" runat="server" Text="Para modificar los porcerntajes seleccione una opción:"></asp:Label>
                      <br />
                      <asp:RadioButton ID="Rb_instructor" runat="server" Checked="True" 
                          Text="Instructor seleccionado" AutoPostBack="True" />
                      <br />
                      <asp:RadioButton ID="Rb_graduacion" runat="server" Text="Graduación" 
                          AutoPostBack="True" />
                      <br />
                      &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                      <asp:DropDownList ID="DropDownList_graduacion" runat="server">
                      </asp:DropDownList>
                      <br />
                      <br />
                      <asp:Label ID="Label1" runat="server" Text="Ingrese porcentaje:"></asp:Label>
                      &nbsp;<asp:TextBox ID="txt_montoexamen" runat="server">0,00</asp:TextBox>
                      &nbsp;<asp:Button ID="Btn_confirmar_porcentaje" runat="server" 
                          Text="Guardar cambios" BackColor="#99CCFF" BorderColor="#3399FF" 
                          ForeColor="White" Width="131px" />
                          
                      <br />
                      <asp:Label ID="Label_error_monto1" runat="server" ForeColor="Red" 
                          Text="* ingrese un valor válido" Visible="False"></asp:Label>
                      <br />
                                   
                  </div>

                  
                                                         
                    </div>
                    <div id="Div3" class="card-body table-responsive p-0" runat ="server">
                      <asp:GridView ID="GridView_examenes" class="table table-hover" runat="server" 
                AllowSorting="True" AutoGenerateColumns="False" 
                           BorderColor="Black" GridLines="None" 
                          EnableSortingAndPagingCallbacks="True">
                          <Columns>
                              <asp:BoundField DataField="ID" HeaderText="ID" />
                              <asp:BoundField DataField="Documento" HeaderText="Documento" />
                              <asp:BoundField DataField="ApeNomb" HeaderText="Apellido y Nombre" />
                              <asp:BoundField DataField="Libreta" HeaderText="Libreta" />
                              <asp:BoundField DataField="Graduacion" HeaderText="Graduación" />
                              <asp:BoundField DataField="Porcentaje" HeaderText="Porcentaje (%)" />
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



                </div>


                
              
                    
          <div class="card-footer">
                </div>
                <label id="lbl_ok" class="label label-warning" visible="False" runat="server" >Evento Creado  </label>
                <div id="div_registro_guardado" runat="server" visible="false" 
                style="color: #00CC00; font-style: normal; font-variant: normal;">
                    Datos actualizados!
                </div>
                    
                    <%--aqui estaba el div_modal_ok--%>




                    </form>

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

</ContentTemplate>


</asp:UpdatePanel>


</asp:Content>
