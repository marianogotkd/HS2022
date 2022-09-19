<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/MasterPage.Master" CodeBehind="Curso.aspx.vb" Inherits="fitfa.Curso" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
   
                    <!-- Aqui va el codigo para la pestaña "TURNOS" -->
                      <asp:Label ID="Label_evento_b" runat="server" Text="Evento:" 
                          forecolor = "#3399FF" Font-Bold="True"></asp:Label>
                      &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                      <asp:Label ID="Label_evento_fecha_b" runat="server" Text="Fecha:"></asp:Label>
                      &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                      <asp:Label ID="Label_evento_direccion_b" runat="server" Text="Direccion:"></asp:Label>
                      &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                      <asp:Label ID="Label_evento_cant_inscriptos_b" runat="server" Text="Cantidad de inscriptos:"></asp:Label>
                      <br />
                      

                       
                     <div id="Div1" >

                      <asp:GridView ID="GridView2" class="table table-hover" runat="server" 
                AllowSorting="True" AutoGenerateColumns="False" 
                           BorderColor="Black" 
                          EnableSortingAndPagingCallbacks="True">
                          <Columns>
                              <asp:BoundField DataField="Nro." HeaderText="Nro." >
                              <HeaderStyle ForeColor="#0099FF" />
                              </asp:BoundField>
                              <asp:BoundField DataField="Alumno" HeaderText="Alumno" >
                              <HeaderStyle ForeColor="#0099FF" />
                              </asp:BoundField>
                              <asp:BoundField DataField="usuario_doc" HeaderText="Dni" >
                              <HeaderStyle ForeColor="#0099FF" />
                              </asp:BoundField>
                              <asp:BoundField DataField="graduacion_desc" HeaderText="Graduacion" >
                              </asp:BoundField>
                              <asp:BoundField DataField="instructor" HeaderText="Instructor" >
                              </asp:BoundField>
                              <asp:TemplateField HeaderText="Eliminar">
                                  <EditItemTemplate>
                                      <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                                  </EditItemTemplate>
                                  <ItemTemplate>
                                      <asp:Button ID="Button1" runat="server" CommandName="op_eliminar" CommandArgument='<%# Eval("inscripcion_id") %>' 
                                          Text="Eliminar" />
                                  </ItemTemplate>
                                  <HeaderStyle ForeColor="#FF5050" />
                              </asp:TemplateField>
                              <asp:BoundField DataField="usuario_id" HeaderText="usuario_id" 
                                  Visible="False" >
                              </asp:BoundField>
                              <asp:BoundField DataField="inscripcion_id" HeaderText="inscripcion_id" >
                              <HeaderStyle ForeColor="#0099FF" />
                              </asp:BoundField>
                              <asp:BoundField DataField="evento_id" HeaderText="evento_id" Visible="False" >
                              <HeaderStyle ForeColor="#0099FF" />
                              </asp:BoundField>
                          </Columns>
                      </asp:GridView>
                      <br />
                      
                           <input type="button" class="btn btn btn-success" id="btnExport_Examen" value="Exportar a Excel" />

           <%--            
            </div   --%>
            
            <div id="div_msj_error_eliminar" runat="server" visible=false>
          
                <asp:Panel ID="Panel1" runat="server" >
                          <div class="card card-primary">
                                <div class="card-header">
                                  <h3 class="card-title">NO HAY INSCRIPTOS PARA EL EVENTO</h3>
                                </div>         
                          </div>
               </asp:Panel>
            </div>

 </ContentTemplate>

    </asp:UpdatePanel>
</asp:Content>
