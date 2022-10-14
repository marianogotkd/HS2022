<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/MasterPage.Master" CodeBehind="Llave_16.aspx.vb" Inherits="fitfa.Llave_16" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style2
        {
            width: 258px;
        }
        .style4
        {
            width: 259px;
        }
        .style5
        {
            width: 263px;
        }
        .style7
        {
            width: 270px;
        }
        .style8
        {
            width: 257px;
        }
        .style9
        {
            width: 438px;
        }
        .style11
        {
            width: 55px;
        }
        .style12
        {
            width: 263px;
            height: 51px;
        }
        .style14
        {
            width: 270px;
            height: 51px;
        }
        .style15
        {
            width: 258px;
            height: 51px;
        }
        .style16
        {
            width: 259px;
            height: 51px;
        }
        .style17
        {
            width: 263px;
            height: 58px;
        }
        .style18
        {
            width: 270px;
            height: 58px;
        }
        .style19
        {
            width: 258px;
            height: 58px;
        }
        .style20
        {
            width: 259px;
            height: 58px;
        }
        .style21
        {
            width: 263px;
            height: 53px;
        }
        .style22
        {
            width: 270px;
            height: 53px;
        }
        .style23
        {
            width: 258px;
            height: 53px;
        }
        .style24
        {
            width: 259px;
            height: 53px;
        }
        .style25
        {
            width: 263px;
            height: 52px;
        }
        .style26
        {
            width: 270px;
            height: 52px;
        }
        .style27
        {
            width: 258px;
            height: 52px;
        }
        .style28
        {
            width: 259px;
            height: 52px;
        }
        .style29
        {
            width: 263px;
            height: 61px;
        }
        .style30
        {
            width: 270px;
            height: 61px;
        }
        .style31
        {
            width: 258px;
            height: 61px;
        }
        .style32
        {
            width: 259px;
            height: 61px;
        }
        .style33
        {
            width: 263px;
            height: 50px;
        }
        .style34
        {
            width: 270px;
            height: 50px;
        }
        .style35
        {
            width: 258px;
            height: 50px;
        }
        .style36
        {
            width: 259px;
            height: 50px;
        }
        .style37
        {
            width: 257px;
            border-right-style: solid;
            border-top-style: solid;
        }
        .style38
        {
            border-right-style: solid;
            border-bottom-style: solid;
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
                            <td align="center" class="style5">
                                <asp:Button ID="B1" runat="server" Width="246px" ForeColor="#FF3300" 
                                    Font-Bold="True" />
                                <hr />
                            </td>
                            <td align="center" class="style8" rowspan="2">
                                <asp:Button ID="B17" runat="server" Width="246px" ForeColor="#FF3300" 
                                    Font-Bold="True" />
                                <hr />
                            </td>
                            <td align="center" class="style7" rowspan="2">
                                &nbsp;</td>
                            <td align="center" class="style2" rowspan="2">
                                &nbsp;</td>
                            <td align="center" class="style4" rowspan="2">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td align="center" class="style12">
                                <asp:Button ID="B2" runat="server" Width="246px" ForeColor="#3366FF" 
                                    Font-Bold="True" />
                                <hr />
                            </td>
                        </tr>
                        <tr>
                            <td align="center" class="style5">
                                </td>
                            <td align="center" class="style8">
                                vs.&nbsp;</td>
                            <td align="center" class="style7">
                                <asp:Button ID="B25" runat="server" Width="246px" ForeColor="#FF3300" 
                                    Font-Bold="True" />
                                <hr />
                            </td>
                            <td align="center" class="style2">
                                &nbsp;</td>
                            <td align="center" class="style4">
                                &nbsp;</td>
                        </tr>
                                <tr>
                                    <td align="center" class="style5" rowspan="2">
                                        <asp:Button ID="B3" runat="server" Width="246px" ForeColor="#FF3300" 
                                            Font-Bold="True" />
                                        <hr />
                                    </td>
                                    <td align="center" class="style8" rowspan="3">
                                        <asp:Button ID="B18" runat="server" Width="246px" ForeColor="#3366FF" 
                                            Font-Bold="True" />
                                        <hr />
                                    </td>
                                    <td align="center" class="style7">
                                        &nbsp;</td>
                                    <td align="center" class="style2">
                                        &nbsp;</td>
                                    <td align="center" class="style4">
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td align="center" class="style7">
                                        </td>
                                    <td align="center" class="style2">
                                        </td>
                                    <td align="center" class="style4">
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td align="center" class="style5">
                                        <asp:Button ID="B4" runat="server" Width="246px" ForeColor="#3366FF" 
                                            Font-Bold="True" />
                                        <hr />
                                    </td>
                                    <td align="center" class="style7">
                                        </td>
                                    <td align="center" class="style2">
                                        </td>
                                    <td align="center" class="style4">
                                        &nbsp;</td>
                                </tr>
                        <tr>
                            <td align="center" class="style5">
                                &nbsp;</td>
                            <td align="center" class="style8">
                                &nbsp;</td>
                            <td align="center" class="style7">
                                vs.</td>
                            <td align="center" class="style2">
                                <asp:Button ID="B29" runat="server" Font-Bold="True" ForeColor="#FF3300" 
                                    Width="246px" />
                                <hr />
                            </td>
                            <td align="center" class="style4">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td align="center" class="style5">
                                <asp:Button ID="B5" runat="server" Font-Bold="True" ForeColor="#FF3300" 
                                    Width="246px" />
                                <hr />
                            </td>
                            <td align="center" class="style8" rowspan="2">
                                <asp:Button ID="B19" runat="server" Font-Bold="True" ForeColor="#FF3300" 
                                    Width="246px" />
                                <hr />
                            </td>
                            <td align="center" class="style7">
                            </td>
                            <td align="center" class="style2">
                                &nbsp;</td>
                            <td align="center" class="style4">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td align="center" class="style12">
                                <asp:Button ID="B6" runat="server" Font-Bold="True" ForeColor="#3366FF" 
                                    Width="246px" />
                                <hr />
                            </td>
                            <td align="center" class="style14">
                                </td>
                            <td align="center" class="style15">
                                </td>
                            <td align="center" class="style16">
                            </td>
                        </tr>
                        <tr>
                            <td align="center" class="style5">
                                &nbsp;</td>
                            <td align="center" class="style8">
                                vs.</td>
                            <td align="center" class="style7">
                                <asp:Button ID="B26" runat="server" Font-Bold="True" ForeColor="#3366FF" 
                                    Width="246px" />
                                <hr />
                            </td>
                            <td align="center" class="style2">
                                &nbsp;</td>
                            <td align="center" class="style4">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td align="center" class="style5">
                                <asp:Button ID="B7" runat="server" Font-Bold="True" ForeColor="#FF3300" 
                                    Width="246px" />
                                <hr />
                            </td>
                            <td align="center" class="style8" rowspan="2">
                                <asp:Button ID="B20" runat="server" Font-Bold="True" ForeColor="#3366FF" 
                                    Width="246px" />
                                <hr />
                            </td>
                            <td align="center" class="style7">
                                &nbsp;</td>
                            <td align="center" class="style2">
                                &nbsp;</td>
                            <td align="center" class="style4">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td align="center" class="style17">
                                <asp:Button ID="B8" runat="server" Font-Bold="True" ForeColor="#3366FF" 
                                    Width="246px" />
                                <hr />
                            </td>
                            <td align="center" class="style18">
                            </td>
                            <td align="center" class="style19">
                            </td>
                            <td align="center" class="style20">
                            </td>
                        </tr>
                        <tr>
                            <td align="center" class="style5">
                                &nbsp;</td>
                            <td align="center" class="style8">
                                &nbsp;</td>
                            <td align="center" class="style7">
                                &nbsp;</td>
                            <td align="center" class="style2">
                                vs.</td>
                            <td align="center" class="style4">
                                <asp:Button ID="B31" runat="server" Font-Bold="True" ForeColor="#FF3300" 
                                    Width="246px" />
                                <hr />
                            </td>
                        </tr>
                        <tr>
                            <td align="center" class="style5">
                                <asp:Button ID="B9" runat="server" Font-Bold="True" ForeColor="#FF3300" 
                                    Width="246px" />
                                <hr />
                            </td>
                            <td align="center" rowspan="2">
                                <asp:Button ID="B21" runat="server" Font-Bold="True" ForeColor="#FF3300" 
                                    Width="246px" />
                                <hr />
                            </td>
                            <td align="center" class="style7">
                                &nbsp;</td>
                            <td align="center" class="style2">
                                &nbsp;</td>
                            <td align="center" class="style4">
                                <asp:Label ID="LB_WINNER" runat="server" Font-Bold="True" Font-Size="15pt" 
                                    Text="WINNER"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" class="style21">
                                <asp:Button ID="B10" runat="server" Font-Bold="True" ForeColor="#3366FF" 
                                    Width="246px" />
                                <hr />
                            </td>
                            <td align="center" class="style22">
                            </td>
                            <td align="center" class="style23">
                            </td>
                            <td align="center" class="style24">
                            </td>
                        </tr>
                        <tr>
                            <td align="center" class="style5">
                                &nbsp;</td>
                            <td align="center">
                                vs.</td>
                            <td align="center" class="style7">
                                <asp:Button ID="B27" runat="server" Font-Bold="True" ForeColor="#FF3300" 
                                    Width="246px" />
                                <hr />
                            </td>
                            <td align="center" class="style2">
                                &nbsp;</td>
                            <td align="center" class="style4">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td align="center" class="style5">
                                <asp:Button ID="B11" runat="server" Font-Bold="True" ForeColor="#FF3300" 
                                    Width="246px" />
                                <hr />
                            </td>
                            <td align="center" rowspan="2">
                                <asp:Button ID="B22" runat="server" Font-Bold="True" ForeColor="#3366FF" 
                                    Width="246px" />
                                <hr />
                            </td>
                            <td align="center" class="style7">
                                &nbsp;</td>
                            <td align="center" class="style2">
                                &nbsp;</td>
                            <td align="center" class="style4">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td align="center" class="style25">
                                <asp:Button ID="B12" runat="server" Font-Bold="True" ForeColor="#3366FF" 
                                    Width="246px" />
                                <hr />
                            </td>
                            <td align="center" class="style26">
                            </td>
                            <td align="center" class="style27">
                            </td>
                            <td align="center" class="style28">
                            </td>
                        </tr>
                        <tr>
                            <td align="center" class="style5">
                                &nbsp;</td>
                            <td align="center" class="style8">
                                &nbsp;</td>
                            <td align="center" class="style7">
                                vs.</td>
                            <td align="center" class="style2">
                                <asp:Button ID="B30" runat="server" Font-Bold="True" ForeColor="#3366FF" 
                                    Width="246px" />
                                <hr />
                            </td>
                            <td align="center" class="style4">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td align="center" class="style5">
                                <asp:Button ID="B13" runat="server" Font-Bold="True" ForeColor="#FF3300" 
                                    Width="246px" />
                                <hr />
                            </td>
                            <td align="center" class="style8" rowspan="2">
                                <asp:Button ID="B23" runat="server" Font-Bold="True" ForeColor="#FF3300" 
                                    Width="246px" />
                                <hr />
                            </td>
                            <td align="center" class="style7">
                                &nbsp;</td>
                            <td align="center" class="style2">
                                &nbsp;</td>
                            <td align="center" class="style4">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td align="center" class="style29">
                                <asp:Button ID="B14" runat="server" Font-Bold="True" ForeColor="#3366FF" 
                                    Width="246px" />
                                <hr />
                            </td>
                            <td align="center" class="style30">
                            </td>
                            <td align="center" class="style31">
                            </td>
                            <td align="center" class="style32">
                            </td>
                        </tr>
                        <tr>
                            <td align="center" class="style5">
                                &nbsp;</td>
                            <td align="center" class="style8">
                                vs.</td>
                            <td align="center" class="style7">
                                <asp:Button ID="B28" runat="server" Font-Bold="True" ForeColor="#3366FF" 
                                    Width="246px" />
                                <hr />
                            </td>
                            <td align="center" class="style2">
                                &nbsp;</td>
                            <td align="center" class="style4">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td align="center" class="style5">
                                <asp:Button ID="B15" runat="server" Font-Bold="True" ForeColor="#FF3300" 
                                    Width="246px" />
                                <hr />
                            </td>
                            <td align="center" class="style8" rowspan="2">
                                <asp:Button ID="B24" runat="server" Font-Bold="True" ForeColor="#3366FF" 
                                    Width="246px" />
                                <hr />
                            </td>
                            <td align="center" class="style7">
                                &nbsp;</td>
                            <td align="center" class="style2">
                                &nbsp;</td>
                            <td align="center" class="style4">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td align="center" class="style33">
                                <asp:Button ID="B16" runat="server" Font-Bold="True" ForeColor="#3366FF" 
                                    Width="246px" />
                                <hr />
                            </td>
                            <td align="center" class="style34">
                            </td>
                            <td align="center" class="style35">
                            </td>
                            <td align="center" class="style36">
                            </td>
                        </tr>
                        <tr>
                            <td align="center" class="style5">
                                &nbsp;</td>
                            <td align="center" class="style8">
                                &nbsp;</td>
                            <td align="center" class="style7">
                                &nbsp;</td>
                            <td align="center" class="style2">
                                &nbsp;</td>
                            <td align="center" class="style4">
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
            <td class="style11">
                <asp:Label ID="Label16" runat="server" Font-Bold="True" Text="1st"></asp:Label>
            </td>
            <td class="style9">
                <asp:Label ID="lb_1st" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style11">
                <asp:Label ID="Label17" runat="server" Font-Bold="True" Text="2nd"></asp:Label>
            </td>
            <td class="style9">
                <asp:Label ID="lb_2nd" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style11">
                <asp:Label ID="Label18" runat="server" Font-Bold="True" Text="3rd"></asp:Label>
            </td>
            <td class="style9">
                <asp:Label ID="lb_3rd_a" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style11">
                <asp:Label ID="Label19" runat="server" Font-Bold="True" Text="3rd"></asp:Label>
            </td>
            <td class="style9">
                <asp:Label ID="lb_3rd_b" runat="server"></asp:Label>
            </td>
        </tr>
    </table>

    <asp:Button ID="Btn_reporte" runat="server" Text="Reporte" /> 
        
    
    
  


</ContentTemplate>
</asp:UpdatePanel>
</asp:Content>
