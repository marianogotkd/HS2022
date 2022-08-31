<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/MasterPage.Master" CodeBehind="Reportes.aspx.vb" Inherits="fitfa.Reportes" %>








<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style1
        {
            font-weight: bold;
            font-size: medium;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" 
        EnableScriptGlobalization="True">
  </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
    <div class="card card-primary">
    <div class="card-header">
                <h3 class="card-title">Informes</h3>
              
              
    </div> 
    <div>
     &nbsp
    </div>
                 
              <form role="form">
                <div class="card-body">
                  <div>
                      <asp:Label ID="Lb_instructor" runat="server" Text="Seleccione instructor:"></asp:Label>
                      &nbsp;
                      <asp:DropDownList ID="DropDown_instructor" runat="server">
                      </asp:DropDownList>
                      &nbsp;
                      <asp:Label ID="Lb_evento" runat="server" Text="Seleccione evento:"></asp:Label>
                      &nbsp;
                      <asp:DropDownList ID="DropDown_Evento" runat="server">
                      </asp:DropDownList>
                      &nbsp;&nbsp;
                      <asp:Button ID="btn_buscar" runat="server" Text="Buscar" />
                      <br />
                  </div>
                  <div>
                   &nbsp
                  </div>

                  <div class="card-body table-responsive p-0" id="div_grid" visible=false runat="server">

                     
              <div align="center" style="background-color: #C0C0C0">
              <asp:Label ID="Label2" runat="server" Text="Alumnos Inscriptos" Font-Bold="True"></asp:Label>      
              </div>

              <div align="center">
               <div class="row">
                      
                       <div class="col-sm-12">
                       
                       
                       </div>
                      
                      
               </div> 
                       
              
              </div>
              

              <div class="card-body table-responsive p-0">
              <asp:Label ID="Label17" runat="server" Font-Underline="True" 
                                              Text="Listado de inscriptos en:" CssClass="style1" 
                      Visible="False"></asp:Label>
                                              &nbsp;<asp:Label ID="label_torneo" runat="server" 
                                              Text="Categoría seleccionada" CssClass="style1" 
                      Visible="False"></asp:Label>
                                              &nbsp;<div>
                                               &nbsp
                                              </div>

                                                <asp:Label ID="label1" runat="server" Font-Underline="True" 
                                              Text="Cantidad de inscriptos:" CssClass="style1" 
                      Visible="False"></asp:Label>
                                              &nbsp;<asp:Label ID="Label_cant" runat="server" 
                                              Text="Categoría seleccionada" CssClass="style1" 
                      Visible="False"></asp:Label>
                                              &nbsp;<div>
                                               &nbsp
                                              </div>

                  <br />
                   <input type="button" class="btn btn btn-success" id="btnExport_Examen" value="Exportar a Excel" />
                   
                   <br />
                   <br />

              <asp:GridView ID="GridView1" class="table table-hover" runat="server" 
                      AutoGenerateColumns="False" AllowSorting="True" BorderColor="Black">
                                              <Columns>
                                                  <asp:BoundField DataField="usuario_id" HeaderText="ID">
                                                  </asp:BoundField>
                                                  <asp:BoundField DataField="usuario_doc" HeaderText="Documento" />
                                                  <asp:BoundField DataField="usuario_apellido" HeaderText="Apellido" />
                                                  <asp:BoundField DataField="usuario_nombre" HeaderText="Nombre" />
                                                  <asp:BoundField DataField="graduacion" HeaderText="Graduacion" />
                                              </Columns>
                                          </asp:GridView>
                                          
                                          &nbsp;&nbsp;&nbsp;<br />
                                          
              

              </div>


                  <%--<asp:GridView ID="GridView2" class="table table-hover" runat="server" 
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

                    </asp:GridView>--%>
                  
                  </div>

                    <div>
                        <asp:Label ID="lbl_err" runat="server" align=center Visible=false
                            Text="No Tiene Inscriptos al evento seleccionado" Font-Bold="True" 
                            Font-Overline="False" ForeColor="#FF3300"></asp:Label>
                    </div>
                    <br />
                </div>
              </form>
       
    
    </div>
    
    </ContentTemplate>
  </asp:UpdatePanel>
    
    
</asp:Content>
