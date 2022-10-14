<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/MasterPage.Master" CodeBehind="Area_asignar.aspx.vb" Inherits="fitfa.Area_asignar" %>
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
                <h3 class="card-title">Asignacion de Areas a Evento</h3>
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
              
                 <div class="form-group" id="seccion_area" runat=server >
                  <label>Cantidad de areas:</label>
                  <asp:DropDownList ID="DropDownList_nroareas" runat="server">
                          <asp:ListItem Selected="True">1</asp:ListItem>
                          <asp:ListItem>2</asp:ListItem>
                          <asp:ListItem>3</asp:ListItem>
                          <asp:ListItem>4</asp:ListItem>
                          <asp:ListItem>5</asp:ListItem>
                          <asp:ListItem>6</asp:ListItem>
                          <asp:ListItem>7</asp:ListItem>
                          <asp:ListItem>8</asp:ListItem>
                          <asp:ListItem>9</asp:ListItem>
                          <asp:ListItem>10</asp:ListItem>
                          <asp:ListItem>11</asp:ListItem>
                          <asp:ListItem>12</asp:ListItem>
                          <asp:ListItem>13</asp:ListItem>
                          <asp:ListItem>14</asp:ListItem>
                          <asp:ListItem>15</asp:ListItem>
                      </asp:DropDownList>
                  <!-- /.input group -->
                </div>
                      
                  <div class="form-group">
                   
                  </div>

                   <div class="form-group" >
                  <button type="submit" class="btn btn-primary" runat="server" id="btn_guardar">Agregar</button>
                  </div>


                  <div class="form-group" id="seccion_areas_asignadas" runat=server >
                  <label>Listado de mesas asignadas al evento:</label><asp:Label ID="Label_evento" runat="server"
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
                        <HeaderStyle ForeColor="#0099FF" HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Area" HeaderText="Area" >
                        <HeaderStyle ForeColor="#0099FF" HorizontalAlign="Center" />
                        </asp:BoundField>
                    </Columns>
                    <HeaderStyle BackColor="#333333" />
                </asp:GridView>
                  </div>

                     </div>
                    
               
                  
                  
              

                    </form>
            </div>
  
  </ContentTemplate>
      <Triggers>
          <asp:AsyncPostBackTrigger ControlID="DropDownEvento" 
              EventName="SelectedIndexChanged" />
      </Triggers>
  </asp:UpdatePanel> 




</asp:Content>
