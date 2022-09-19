<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/MasterPage.Master" CodeBehind="Llave_2.aspx.vb" Inherits="fitfa.Llave_2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style5
        {
            width: 244px;
            height: 63px;
        }
        .style6
        {
            width: 252px;
            height: 63px;
        }
        .style7
        {
            width: 43px;
        }
        .style8
        {
            width: 402px;
        }
        .style11
        {
            width: 252px;
            height: 50px;
        }
        .style12
        {
            width: 244px;
            height: 50px;
        }
        .style13
        {
            width: 252px;
            height: 46px;
        }
        .style14
        {
            width: 244px;
            height: 46px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>
<div class="card card-primary">
                           
              <div class="card-header">
                <h3 class="card-title">Generación de llaves - Evento:<asp:Label ID="Lb_evento" runat="server" Text="XXX - TITULO EVENTO"></asp:Label>      </h3>
                  
              </div>
              <form role="form">
              <div class="card-body"> 
                    
              <div align="center" style="background-color: #C0C0C0">
              <asp:Label ID="Label15" runat="server" Text="Datos del Torneo" Font-Bold="True"></asp:Label>      
              </div>
              
              <div align="left">
                    <asp:Label ID="Fechadelevento" runat="server" Text="Fecha del evento:" Font-Bold="True"></asp:Label>
                    <asp:Label ID="Lb_fecha" runat="server" Text="00/00/0000"></asp:Label>
              </div>  
              
              <div align="left">
                    <asp:Label ID="Fechadecierre" runat="server" Text="Fecha de cierre de inscripción" 
                        Font-Bold="True"></asp:Label>
                    <asp:Label ID="Lb_fecha_cierre" runat="server" Text="00/00/0000"></asp:Label>
              </div>  
              
              <div align="center" style="background-color: #C0C0C0">
              <asp:Label ID="Lb_categoria" runat="server" Text="Categoria:XXXXXX" Font-Bold="True"></asp:Label>      
              </div>

              <div align="left">
                    <div class="row">
                          <div class="col-sm-3" 
                              
                              style="background-position: center center; background-repeat: no-repeat; background-attachment: scroll;"></div>
                          <div class="col-sm-6">
                           
                          </div>
                          <div class="col-sm-3"></div>
                    </div>
                    
              </div>

              <div align="center">
              <table ID="tabla" runat="server" align="center" class="style73" 
                        
                        
                        style="background-repeat: no-repeat; background-position: center center; table-layout: fixed; width: 500px; height: 150px; background-color: #FFFFCC;">
                        <tr>
                            <td align="center" class="style11">
                                <asp:Button ID="B1" runat="server" Font-Bold="True" ForeColor="#FF3300" 
                                    Width="246px" Font-Size="Small" />
                                <hr />
                            </td>
                            <td align="center" class="style12">
                            </td>
                        </tr>
                        <tr>
                            <td align="center" class="style13">
                                </td>
                            <td align="center" class="style14">
                                <asp:Button ID="B3" runat="server" Width="246px" ForeColor="#FF3300" 
                                    Font-Bold="True" Font-Size="Small" />
                            </td>
                        </tr>
                        <tr>
                            <td align="center" class="style6">
                                <asp:Button ID="B2" runat="server" Font-Bold="True" ForeColor="#3366FF" 
                                    Width="246px" Font-Size="Small" />
                                <hr />
                            </td>
                            <td align="center" class="style5">
                                <hr />
                                &nbsp;<asp:Label ID="LB_WINNER" runat="server" Font-Bold="True" Font-Size="15pt" 
                                    Text="WINNER"></asp:Label>
                            </td>
                        </tr>
                    </table> 
              <asp:Button ID="Btn_reporte" runat="server" Text="Reporte" />
              
              </div>
               
              <div id="seccion_competencia" runat="server">
              <div align="center" style="background-color: #C0C0C0">
              <asp:Label ID="Label6" runat="server" Text="DATOS DE COMPETENCIA" Font-Bold="True"></asp:Label>      
              </div>

              </div>
                  <Div id="Seccion_tabla_resultados" runat="server" visible="false">
                      <table align="center" style="border: thin dotted #0000FF;">
        <tr>
            <td class="style7">
                <asp:Label ID="Label16" runat="server" Font-Bold="True" Text="1st"></asp:Label>
            </td>
            <td class="style8">
                <asp:Label ID="lb_1st" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style7">
                <asp:Label ID="Label17" runat="server" Font-Bold="True" Text="2nd"></asp:Label>
            </td>
            <td class="style8">
                <asp:Label ID="lb_2nd" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style7">
                <asp:Label ID="Label18" runat="server" Font-Bold="True" Text="3rd"></asp:Label>
            </td>
            <td class="style8">
                <asp:Label ID="lb_3rd_a" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style7">
                <asp:Label ID="Label19" runat="server" Font-Bold="True" Text="3rd"></asp:Label>
            </td>
            <td class="style8">
                <asp:Label ID="lb_3rd_b" runat="server"></asp:Label>
            </td>
        </tr>
    </table>

                  </Div>
                  

    

                  <div class="container-fluid">
                    <div class="row justify-content-center">
                        <div class="col-lg-12">
                            <div class="card">
                                        <div class="card-body">
                                                <div class="form-group">
                                                    <div class="row justify-content-left">
                                                        <div class="col-md-6">
                                                            <label for="Label_competidores" style="background-color: #000066; color: #FFFFFF">LISTADO DE COMPETIDORES</label>
                                                            <div id="DIV_GRIDCOMPETIDORES" class="card-body table-responsive p-0" runat ="server">
                                                                <asp:GridView ID="GridView_COMPETIDORES" class="table table-hover" runat="server" 
                                                                AllowSorting="True" AutoGenerateColumns="False" 
                                                                           BorderColor="Black" GridLines="None" 
                                                                          EnableSortingAndPagingCallbacks="True">
                                                                          <Columns>
                                                                              <asp:BoundField DataField="Competidor" HeaderText="Competidor" >
                                                                              <HeaderStyle ForeColor="#0099FF" />
                                                                              </asp:BoundField>
                                                                              <asp:BoundField DataField="Instructor" HeaderText="Instructor" >
                                                                              <HeaderStyle ForeColor="#0099FF" />
                                                                              </asp:BoundField>
                                                                              
                                                                          </Columns>
                                                               </asp:GridView>
                                                            </div>
                                                        
                                                        </div>
                                                        <div class="col-md-6">
                                                            <label for="Label_RESULTADO" style="background-color: #000066; color: #FFFFFF">RESULTADO DE LA LLAVE</label>
                                                            <div id="DIV_RESULTADOS" class="card-body table-responsive p-0" runat ="server">
                                                                <asp:GridView ID="GridView_RESULTADOS" class="table table-hover" runat="server" 
                                                                AllowSorting="True" AutoGenerateColumns="False" 
                                                                           BorderColor="Black" GridLines="None" 
                                                                          EnableSortingAndPagingCallbacks="True">
                                                                          <Columns>
                                                                              <asp:BoundField DataField="Puesto" HeaderText="Puesto" >
                                                                              <HeaderStyle ForeColor="#0099FF" />
                                                                              </asp:BoundField>
                                                                              <asp:BoundField DataField="Competidor" HeaderText="Competidor" >
                                                                              <HeaderStyle ForeColor="#0099FF" />
                                                                              </asp:BoundField>
                                                                              
                                                                              
                                                                          </Columns>
                                                               </asp:GridView>
                                                            </div>
                                                        </div>
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
