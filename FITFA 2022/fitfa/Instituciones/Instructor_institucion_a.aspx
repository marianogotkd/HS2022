<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/MasterPage.Master" CodeBehind="Instructor_institucion_a.aspx.vb" Inherits="fitfa.Instructor_institucion_a" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" 
        EnableScriptGlobalization="True">
    </asp:ScriptManager>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
    <div class="card card-primary">
        <div class="card-header">
           <h3 class="card-title">Asignar institución a instructor</h3>
               
        
        </div>
        
        
        <form role="form">
            <div class="card-body">
            <div class="form-group">
            <label>Listado de Instructores:</label>            
            </div>
            <div class="form-group">
            <div class="card-tools">
                  <div class="input-group input-group-sm" style="width: 300px;">
                      <asp:TextBox ID="txt_buscar" runat="server" class="form-control float-right" placeholder="Apellido y Nombre, DNI o provincia..." Font-Size="Small"></asp:TextBox>
                    <%--<input type="text" name="table_search" class="form-control float-right" placeholder="Buscar..." id="txt_buscar" runat="server">--%>

                    <div class="input-group-append">
                      <button type="submit" id="btn_buscar" runat="server"  class="btn btn-default"><i class="fa fa-search"></i></button>
                    </div>
                  </div>
                </div>
            </div>
            


            <div class="form-group">
                               
                 <button type="button" id="Continuar_a" class="btn btn-default btn-sm" 
                        runat="server" title="Continuar"><strong>Continuar</strong></button>
            
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
                        <asp:BoundField DataField="instructor_id" HeaderText="ID" > 
                        <HeaderStyle ForeColor="#0099FF" />
                        </asp:BoundField>
                        <asp:BoundField DataField="usuario_doc" HeaderText="Dni" >
                        <HeaderStyle ForeColor="#0099FF" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Apellido_y_Nombre" HeaderText="Apellido y Nombre" >
                        <HeaderStyle ForeColor="#0099FF" />
                        </asp:BoundField>
                        <asp:BoundField DataField="provincia_desc" HeaderText="Provincia" >
                        <HeaderStyle ForeColor="#0099FF" />
                        </asp:BoundField>
                    </Columns>
                    <HeaderStyle BackColor="#333333" />
                </asp:GridView>
                <button type="button" id="Continuar_b" class="btn btn-default btn-sm" 
                        runat="server" title="Continuar"><strong>Continuar</strong></button>
                </div>
            </div>
            
            <div class="row">
            
            
            
            </div>
            
        </form>


    </div>
    </ContentTemplate>      
    </asp:UpdatePanel>


</asp:Content>
