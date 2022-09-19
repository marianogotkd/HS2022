<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/MasterPage.Master" CodeBehind="Reporte_Inscriptos_Categoria.aspx.vb" Inherits="fitfa.Reporte_Inscriptos_Categoria" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    
    <ContentTemplate>
    <div>
    
        <asp:Label ID="Label20" runat="server" Text="Seleccione el Evento"></asp:Label>
        &nbsp;<asp:DropDownList ID="DropDown_Evento" runat="server">
        </asp:DropDownList>
    
    </div>
    <div align="center">
               <div class="row">
                      
                       <div class="col-sm-12">
                       <table class="w-100">
                                  <tr>
                                      <td>
                                          <asp:Label ID="Label16" runat="server" Text="Seleccione modalidad y categoría:"></asp:Label>
                                          <asp:DropDownList ID="DropDown_modalidad" runat="server" AutoPostBack="True">
                                              <asp:ListItem Selected="True">Lucha</asp:ListItem>
                                              <asp:ListItem>Forma</asp:ListItem>
                                          </asp:DropDownList>
                                          <asp:DropDownList ID="DropDown_categoria" runat="server" Width="529px" AutoPostBack="True">
                                          </asp:DropDownList>
                                          <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/img/lupa.png" 
                                              Width="30px" />
                                      </td>
                                  </tr>
                                  <tr>
                                      <td>
                                          <asp:Label ID="Label19" runat="server" ForeColor="#00CC66" 
                                              Text="Nota: las categoria listadas son solamente las que tienen inscriptos"></asp:Label>
                                      </td>
                                  </tr>
                              </table>
                       
                 
                      
                      
               </div> 
                       
              
              </div>

              <div>
              
                  <asp:Label ID="Label17" runat="server" Font-Underline="True" 
                      Text="Listado de inscriptos en:"></asp:Label>
                  &nbsp;<asp:Label ID="label_catseleccionada" runat="server" 
                      Text="Categoría seleccionada"></asp:Label>
              
              </div>
              


               <div class="card-body table-responsive p-0">
                  <asp:GridView ID="GridView1" class="table table-hover" runat="server" 
                AllowSorting="True" AutoGenerateColumns="False" 
                           BorderColor="Black" GridLines="None" 
                          EnableSortingAndPagingCallbacks="True" PageSize="20">

                          <Columns>

                              <asp:BoundField HeaderText="ID" DataField="usuario_id" >
                              <HeaderStyle ForeColor="#0099FF" />
                              </asp:BoundField>
                              <asp:BoundField HeaderText="Apellido y Nombre" DataField="ApellidoyNombre" >
                              <HeaderStyle ForeColor="#0099FF" />
                              </asp:BoundField>
                              <asp:BoundField HeaderText="Edad" DataField="Edad" >
                              <HeaderStyle ForeColor="#0099FF" />
                              </asp:BoundField>
                              <asp:BoundField HeaderText="Sexo" DataField="categoria_sexo">
                              <HeaderStyle ForeColor="#0099FF" />
                              </asp:BoundField>
                              <asp:BoundField HeaderText="Graduación" DataField="graduacion"  >
                              <HeaderStyle ForeColor="#0099FF" />
                              </asp:BoundField>
                              <asp:BoundField HeaderText="Categoria" DataField="Categoria" >
                              <HeaderStyle ForeColor="#0099FF" />
                              </asp:BoundField>

                          </Columns>

                          <PagerSettings Position="TopAndBottom" />

                    </asp:GridView>
                  
                  </div>



    </ContentTemplate>



    </asp:UpdatePanel>

 
              
            

</asp:Content>
