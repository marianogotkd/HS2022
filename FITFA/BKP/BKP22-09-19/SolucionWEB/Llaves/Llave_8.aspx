<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/MasterPage.Master" CodeBehind="Llave_8.aspx.vb" Inherits="fitfa.Llave_8" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style1
        {
            height: 33px;
            width: 258px;
        }
        .style2
        {
            height: 49px;
            width: 270px;
        }
        .style3
        {
            height: 37px;
            width: 258px;
        }
        .style4
        {
            height: 24px;
            width: 270px;
        }
        .style6
        {
            height: 44px;
            width: 270px;
        }
        .style7
        {
            height: 41px;
            width: 258px;
        }
        .style8
        {
            height: 39px;
            width: 270px;
        }
        .style10
        {
            width: 52px;
        }
        .style11
        {
            width: 307px;
        }
        .style13
        {
            width: 436px;
        }
        .style15
        {
            height: 49px;
            width: 268px;
        }
        .style16
        {
            height: 39px;
            width: 258px;
        }
        .style17
        {
            height: 44px;
            width: 258px;
        }
        .style18
        {
            height: 49px;
            width: 258px;
        }
        .style19
        {
            width: 258px;
        }
        .style20
        {
            width: 268px;
        }
        .style21
        {
            height: 24px;
            width: 268px;
        }
        .style22
        {
            height: 16px;
            width: 268px;
        }
        .style24
        {
            height: 39px;
            width: 268px;
        }
        .style25
        {
            height: 44px;
            width: 268px;
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
                        
                        
                        
                      
                      style="background-repeat: no-repeat; background-position: center center; table-layout: fixed; width: 1004px; height: 250px; background-color: #FFFFCC;">
                        <tr>
                            <td align="center" class="style3">
                                <asp:Button ID="B1" runat="server" Width="246px" ForeColor="#FF3300" 
                                    Font-Bold="True" />
                                <hr />
                            </td>
                            <td align="center" class="style20" rowspan="2">
                                <asp:Button ID="B9" runat="server" Width="246px" ForeColor="#FF3300" 
                                    Font-Bold="True" />
                                <hr />
                            </td>
                            <td align="center" class="style20" rowspan="2">
                                &nbsp;</td>
                            <td align="center" class="style20" rowspan="2">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td align="center" class="style7">
                                <asp:Button ID="B2" runat="server" Width="246px" ForeColor="#3366FF" 
                                    Font-Bold="True" />
                                <hr />
                            </td>
                        </tr>
                        <tr>
                            <td align="center" class="style19">
                                </td>
                            <td align="center" class="style15">
                                vs.&nbsp;</td>
                            <td align="center" class="style21">
                                <asp:Button ID="B13" runat="server" Width="246px" ForeColor="#FF3300" 
                                    Font-Bold="True" />
                                <hr />
                            </td>
                            <td align="center" class="style21">
                                &nbsp;</td>
                        </tr>
                                <tr>
                                    <td align="center" class="style1" rowspan="2">
                                        <asp:Button ID="B3" runat="server" Width="246px" ForeColor="#FF3300" 
                                            Font-Bold="True" />
                                        <hr />
                                    </td>
                                    <td align="center" class="style20" rowspan="3">
                                        <asp:Button ID="B10" runat="server" Width="246px" ForeColor="#3366FF" 
                                            Font-Bold="True" />
                                        <hr />
                                    </td>
                                    <td align="center" class="style20">
                                        &nbsp;</td>
                                    <td align="center" class="style20">
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td align="center" class="style22">
                                        </td>
                                    <td align="center" class="style22">
                                        </td>
                                </tr>
                                <tr>
                                    <td align="center" class="style18">
                                        <asp:Button ID="B4" runat="server" Width="246px" ForeColor="#3366FF" 
                                            Font-Bold="True" />
                                        <hr />
                                    </td>
                                    <td align="center" class="style15">
                                        </td>
                                    <td align="center" class="style15">
                                        </td>
                                </tr>
                        <tr>
                            <td align="center" class="style19">
                                &nbsp;</td>
                            <td align="center" class="style20">
                                &nbsp;</td>
                            <td align="center" class="style20">
                                vs.</td>
                            <td align="center" class="style20">
                                <asp:Button ID="B15" runat="server" Font-Bold="True" ForeColor="#FF3300" 
                                    Width="246px" />
                                <hr />
                            </td>
                        </tr>
                        <tr>
                            <td align="center" class="style16">
                                <asp:Button ID="B5" runat="server" Font-Bold="True" ForeColor="#FF3300" 
                                    Width="246px" />
                                <hr />
                            </td>
                            <td align="center" class="style20" rowspan="2">
                                <asp:Button ID="B11" runat="server" Font-Bold="True" ForeColor="#FF3300" 
                                    Width="246px" />
                                <hr />
                            </td>
                            <td align="center" class="style24">
                            </td>
                            <td align="center" class="style24">
                                <asp:Label ID="LB_WINNER" runat="server" Font-Bold="True" Font-Size="15pt" 
                                    Text="WINNER"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" class="style19">
                                <asp:Button ID="B6" runat="server" Font-Bold="True" ForeColor="#3366FF" 
                                    Width="246px" />
                                <hr />
                            </td>
                            <td align="center" class="style20">
                                &nbsp;</td>
                            <td align="center" class="style20">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td align="center" class="style19">
                                &nbsp;</td>
                            <td align="center" class="style20">
                                vs.</td>
                            <td align="center" class="style20">
                                <asp:Button ID="B14" runat="server" Font-Bold="True" ForeColor="#3366FF" 
                                    Width="246px" />
                                <hr />
                            </td>
                            <td align="center" class="style20">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td align="center" class="style19">
                                <asp:Button ID="B7" runat="server" Font-Bold="True" ForeColor="#FF3300" 
                                    Width="246px" />
                                <hr />
                            </td>
                            <td align="center" class="style20" rowspan="2">
                                <asp:Button ID="B12" runat="server" Font-Bold="True" ForeColor="#3366FF" 
                                    Width="246px" />
                                <hr />
                            </td>
                            <td align="center" class="style20">
                                &nbsp;</td>
                            <td align="center" class="style20">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td align="center" class="style17">
                                <asp:Button ID="B8" runat="server" Font-Bold="True" ForeColor="#3366FF" 
                                    Width="246px" />
                                <hr />
                            </td>
                            <td align="center" class="style25">
                            </td>
                            <td align="center" class="style25">
                            </td>
                        </tr>
                        <tr>
                            <td align="center" class="style19">
                                &nbsp;</td>
                            <td align="center" class="style20">
                                &nbsp;</td>
                            <td align="center" class="style20">
                                &nbsp;</td>
                            <td align="center" class="style20">
                                &nbsp;</td>
                        </tr>
                    </table> 
              </div>
               
              <div id="seccion_competencia" runat="server">
              <div align="center" style="background-color: #C0C0C0">
              <asp:Label ID="Label6" runat="server" Text="DATOS DE COMPETENCIA" Font-Bold="True"></asp:Label>      
              </div>

              </div>


              
              
              </div>
              </form>


    </div>
        
    
    
  


    <table align="center" style="border: thin dotted #0000FF;">
        <tr>
            <td class="style10">
                <asp:Label ID="Label16" runat="server" Font-Bold="True" Text="1st"></asp:Label>
            </td>
            <td class="style13">
                <asp:Label ID="lb_1st" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style10">
                <asp:Label ID="Label17" runat="server" Font-Bold="True" Text="2nd"></asp:Label>
            </td>
            <td class="style13">
                <asp:Label ID="lb_2nd" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style10">
                <asp:Label ID="Label18" runat="server" Font-Bold="True" Text="3rd"></asp:Label>
            </td>
            <td class="style13">
                <asp:Label ID="lb_3rd_a" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style10">
                <asp:Label ID="Label19" runat="server" Font-Bold="True" Text="3rd"></asp:Label>
            </td>
            <td class="style13">
                <asp:Label ID="lb_3rd_b" runat="server"></asp:Label>
            </td>
        </tr>
    </table>
        
    
    <asp:Button ID="Btn_reporte" runat="server" Text="Reporte" />    
  


</ContentTemplate>
</asp:UpdatePanel>


</asp:Content>
