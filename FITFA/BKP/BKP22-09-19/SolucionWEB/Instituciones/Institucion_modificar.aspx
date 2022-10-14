<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/MasterPage.Master" CodeBehind="Institucion_modificar.aspx.vb" Inherits="fitfa.Institucion_modificar" %>
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
           <h3 class="card-title">Modificar Institución</h3>
        </div>
        
        
        <form role="form">
            <div class="card-body">
            
            <%--<div class="form-group">--%>
            <label>Listado de Instituciones disponibles:</label>            
              
            <%--</div>--%>
            
            <div class="form-group">
                <button type="button" id="Nuevo_institucion" class="btn btn-default btn-sm" 
                        runat="server" title="Nueva institucion"><strong>Nuevo</strong></button>
                  
                <asp:GridView ID="GridView1" class="table table-hover" runat="server" 
                    AutoGenerateColumns="False" AllowSorting="True" BorderColor="Black" 
                    Font-Size="Small" >
                    <Columns>
                        <asp:BoundField DataField="institucion_id" HeaderText="ID" >
                        <HeaderStyle ForeColor="#0099FF" />
                        <ItemStyle VerticalAlign="Middle" />
                        </asp:BoundField>
                        <asp:BoundField DataField="provincia_id" HeaderText="provincia_id" 
                            Visible="False" /> 
                        <asp:BoundField DataField="provincia_desc" HeaderText="Provincia" >
                        <HeaderStyle ForeColor="#0099FF" />
                        </asp:BoundField>
                        <asp:BoundField DataField="institucion_descripcion" HeaderText="Institución" >
                        <HeaderStyle ForeColor="#0099FF" />
                        </asp:BoundField>
                        <asp:BoundField DataField="institucion_abreviacion" HeaderText="Abreviación" >
                        <HeaderStyle ForeColor="#0099FF" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="Editar">
                            <ItemTemplate>
                                <asp:ImageButton ID="ImageButton1" runat="server" CausesValidation="False" 
                                    CommandName="institucion_id" Height="30px" ImageAlign="AbsMiddle" 
                                    ImageUrl="~/img/icon-edit.jpg" ToolTip="Editar" Width="30px" 
                                    CommandArgument='<%# Eval("institucion_id") %>' />
                            </ItemTemplate>
                            <HeaderStyle ForeColor="#0099FF" />
                        </asp:TemplateField>
                    </Columns>
                    <HeaderStyle BackColor="#333333" />
                </asp:GridView>
                </div>
                
                <div class="row">
                
                </div>
            
            
            <div class="col-md-5 col-center">
            </div>
            <div class="col-md-5 col-center">
                
            </div>
            </div>
            </div>
        </form>


    </div>
    </ContentTemplate>      
    </asp:UpdatePanel>

</asp:Content>
