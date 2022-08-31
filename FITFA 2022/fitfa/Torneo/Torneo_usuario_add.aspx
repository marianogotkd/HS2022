<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/MasterPage.Master" CodeBehind="Torneo_usuario_add.aspx.vb" Inherits="fitfa.Torneo_usuario_add" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<asp:ScriptManager ID="ScriptManager1" runat="server" 
        EnableScriptGlobalization="True">
</asp:ScriptManager>
<asp:UpdatePanel ID="upp" runat="server">
<ContentTemplate>
  <div class="card card-primary">
              <div class="card-header">
                <h3 class="card-title">Creacion de usuario para Evento.</h3>
              </div>
              <!-- /.card-header -->
              <!-- form start -->
              <form role="form">
                <div class="card-body">
                  
                  <div class="row">
                  <div class="col-md-4 col-center">  
                  <div class="form-group" id="seccion_evento" runat=server>
                      <label>Seleccione un evento:</label>
                      <asp:DropDownList ID="DropDownEvento" runat="server" AutoPostBack="True" class="form-control">
                      </asp:DropDownList>
                                         
                  </div>
                    <div class="form-group">
                   <div id="no_evento" runat="server">
                          <div class="card card-warning">
                                <div class="card-header">
                                    <h3 class="card-title">Advertencia</h3>
                                </div>
                                <form role="form">
                                  <div class="card-body"> 
                                  <div class="row">
                                  <div align="center">
                                        <asp:Label ID="Label2" runat="server" Text="No hay eventos disponibles!"></asp:Label>
                                        &nbsp;
                                  </div>
               
                                  </div>
                                  </div>
                                </form>              
                        </div> 
                    
                    </div>
                      
                  </div>
              
                 <div class="form-group" id="Seccion_usuario" runat=server >
                  <label>Nombre de usuario:</label>
                  <input type="text" class="form-control" id="tb_nombre" runat="server" causesvalidation="False" required="" placeholder="Ingrese nombre..." maxlength="50"/>
                  <!-- /.input group -->
                  <label>Contraseña de usuario:</label>
                  <input type="text" class="form-control" id="tb_contraseña1" runat="server" causesvalidation="False" required="" placeholder="Ingrese contraseña..." maxlength="50"/>
                  <input type="text" class="form-control" id="tb_contraseña2" runat="server" causesvalidation="False" required="" placeholder="Repita contraseña..." maxlength="50"/>

                </div>
                      
                  <div class="form-group">
                   
                  </div>

                   <div class="form-group" >
                  <button type="submit" class="btn btn-primary" runat="server" id="btn_guardar">Agregar</button>
                  </div>


                  <div class="form-group" id="seccion_usuario_asignado" runat=server >
                  <label>Usuario asignado al evento:</label><asp:Label ID="Label_evento" runat="server"
                      Text=""></asp:Label>
                  <asp:GridView ID="GridView1" class="table table-hover" runat="server" 
                    AutoGenerateColumns="False" AllowSorting="True" BorderColor="Black" 
                    Font-Size="Small" >
                    <Columns>
                        <asp:TemplateField HeaderText="Check">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:CheckBox ID="CheckBox1" runat="server" ToolTip="seleccionar" />
                            </ItemTemplate>
                            <HeaderStyle ForeColor="#0099FF" HorizontalAlign="Center" 
                                VerticalAlign="Middle" Width="20px" />
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="id" HeaderText="ID" > 
                        <HeaderStyle ForeColor="#0099FF" HorizontalAlign="Center" 
                            VerticalAlign="Middle" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Usuario" HeaderText="Usuario" >
                        <HeaderStyle ForeColor="#0099FF" HorizontalAlign="Center" 
                            VerticalAlign="Middle" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Contraseña" HeaderText="Contraseña">
                        <HeaderStyle ForeColor="#0099FF" HorizontalAlign="Center" 
                            VerticalAlign="Middle" />
                        </asp:BoundField>
                    </Columns>
                    <HeaderStyle BackColor="#333333" />
                </asp:GridView>
                  </div>

                     </div>
                    
               
                  
                  
              

                    </form>
            </div>

<div id="div_modalOK" runat="server">
<asp:HiddenField ID="HiddenField_msj" runat="server" />
                                    <asp:Panel ID="Panel1" runat="server" >
              
                                        <div class="card card-success">
                                        <div class="card-header">
                                            <h3 class="card-title">FITFA</h3>
                                        </div>
                                        <form role="form">
                                          <div class="card-body"> 
                                            <div class="row">
                                                <div align="center">
                                                    <asp:Label ID="Label16" runat="server" Text="El usuario se generó exitosamente"></asp:Label>
                                                    &nbsp;
                                                </div>
                                            </div>
                                          </div>
                                        </form>  
                                        <div align="center">
                                                <asp:Button ID="Btb_ok_usuario" runat="server" Text="OK" CssClass="btn btn-success"  />
                                          </div> 
                                          <div>
                                             &nbsp;
                                          </div>             
                                        </div> 
                                    </asp:Panel>
    <cc1:ModalPopupExtender ID="Modal_OK" runat="server" TargetControlID="HiddenField_msj" PopupControlID="Panel1" CancelControlID="Btb_ok_usuario" BackgroundCssClass="modalBackground">
    </cc1:ModalPopupExtender>

</div>

<div id="div_modal_error" runat="server">
<asp:HiddenField ID="HiddenField1" runat="server" />
                                    <asp:Panel ID="Panel2" runat="server" >
              
                                        <div class="card card-danger">
                                        <div class="card-header">
                                            <h3 class="card-title">FITFA</h3>
                                        </div>
                                        <form role="form">
                                          <div class="card-body"> 
                                            <div class="row">
                                                <div align="center">
                                                    <asp:Label ID="Label_error" runat="server" Text="AQUI VA TEXTO DE ERROR"></asp:Label>
                                                    &nbsp;
                                                </div>
                                            </div>
                                          </div>
                                        </form>  
                                        <div align="center">
                                                <asp:Button ID="Button1" runat="server" Text="OK" CssClass="btn btn-danger "  />
                                          </div> 
                                          <div>
                                             &nbsp;
                                          </div>             
                                        </div> 
                                    </asp:Panel>
    <cc1:ModalPopupExtender ID="Modal_error" runat="server" TargetControlID="HiddenField1" PopupControlID="Panel2" CancelControlID="Button1" BackgroundCssClass="modalBackground">
    </cc1:ModalPopupExtender>

</div>





</ContentTemplate>
<Triggers>
          <asp:AsyncPostBackTrigger ControlID="DropDownEvento" 
              EventName="SelectedIndexChanged" />
        <asp:PostBackTrigger ControlID="Btb_ok_usuario" />
      </Triggers>
</asp:UpdatePanel>


</asp:Content>
