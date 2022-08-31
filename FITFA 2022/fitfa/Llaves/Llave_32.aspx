<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/MasterPage.Master" CodeBehind="Llave_32.aspx.vb" Inherits="fitfa.Llave_32" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style3
        {
            width: 268px;
        }
        .style9
        {
            width: 125px;
        }
        .style11
        {
            width: 221px;
        }
        .style12
        {
            width: 253px;
        }
        .style13
        {
            width: 254px;
        }
        .style14
        {
            width: 248px;
        }
        .style15
        {
            width: 252px;
        }
        .style16
        {
            width: 256px;
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
                        
                        
                        
                      
                      
                      style="background-repeat: no-repeat; background-position: center center; table-layout: fixed; width: 1510px; height: 250px; background-color: #FFFFCC;">
                        <tr>
                            <td align="center" class="style3">
                                <asp:Button ID="B1" runat="server" Width="246px" ForeColor="#FF3300" 
                                    Font-Bold="True" />
                                <hr />
                            </td>
                            <td align="center" class="style12" rowspan="2">
                                <asp:Button ID="B33" runat="server" Width="246px" ForeColor="#FF3300" 
                                    Font-Bold="True" />
                                <hr />
                            </td>
                            <td align="center" class="style13" rowspan="2">
                                &nbsp;</td>
                            <td align="center" class="style14" rowspan="2">
                                &nbsp;</td>
                            <td align="center" class="style15" rowspan="2">
                                &nbsp;</td>
                            <td align="center" class="style16" rowspan="2">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td align="center" class="style3">
                                <asp:Button ID="B2" runat="server" Width="246px" ForeColor="#3366FF" 
                                    Font-Bold="True" />
                                <hr />
                            </td>
                        </tr>
                        <tr>
                            <td align="center" class="style3">
                                </td>
                            <td align="center" class="style12">
                                vs.&nbsp;</td>
                            <td align="center" class="style13">
                                <asp:Button ID="B49" runat="server" Width="246px" ForeColor="#FF3300" 
                                    Font-Bold="True" />
                                <hr />
                            </td>
                            <td align="center" class="style14">
                                &nbsp;</td>
                            <td align="center" class="style15">
                                &nbsp;</td>
                            <td align="center" class="style16">
                                &nbsp;</td>
                        </tr>
                                <tr>
                                    <td align="center" class="style3" rowspan="2">
                                        <asp:Button ID="B3" runat="server" Width="246px" ForeColor="#FF3300" 
                                            Font-Bold="True" />
                                        <hr />
                                    </td>
                                    <td align="center" class="style12" rowspan="3">
                                        <asp:Button ID="B34" runat="server" Width="246px" ForeColor="#3366FF" 
                                            Font-Bold="True" />
                                        <hr />
                                    </td>
                                    <td align="center" class="style13">
                                        &nbsp;</td>
                                    <td align="center" class="style14">
                                        &nbsp;</td>
                                    <td align="center" class="style15">
                                        &nbsp;</td>
                                    <td align="center" class="style16">
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td align="center" class="style13">
                                        </td>
                                    <td align="center" class="style14">
                                        </td>
                                    <td align="center" class="style15">
                                        &nbsp;</td>
                                    <td align="center" class="style16">
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td align="center" class="style3">
                                        <asp:Button ID="B4" runat="server" Width="246px" ForeColor="#3366FF" 
                                            Font-Bold="True" />
                                        <hr />
                                    </td>
                                    <td align="center" class="style13">
                                        </td>
                                    <td align="center" class="style14">
                                        </td>
                                    <td align="center" class="style15">
                                        &nbsp;</td>
                                    <td align="center" class="style16">
                                        &nbsp;</td>
                                </tr>
                        <tr>
                            <td align="center" class="style3">
                                &nbsp;</td>
                            <td align="center" class="style12">
                                &nbsp;</td>
                            <td align="center" class="style13">
                                vs.</td>
                            <td align="center" class="style14">
                                <asp:Button ID="B57" runat="server" Font-Bold="True" ForeColor="#FF3300" 
                                    Width="246px" />
                                <hr />
                            </td>
                            <td align="center" class="style15">
                                &nbsp;</td>
                            <td align="center" class="style16">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td align="center" class="style3">
                                <asp:Button ID="B5" runat="server" Font-Bold="True" ForeColor="#FF3300" 
                                    Width="246px" />
                                <hr />
                            </td>
                            <td align="center" class="style12" rowspan="2">
                                <asp:Button ID="B35" runat="server" Font-Bold="True" ForeColor="#FF3300" 
                                    Width="246px" />
                                <hr />
                            </td>
                            <td align="center" class="style13">
                            </td>
                            <td align="center" class="style14">
                                &nbsp;</td>
                            <td align="center" class="style15">
                                &nbsp;</td>
                            <td align="center" class="style16">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td align="center" class="style3">
                                <asp:Button ID="B6" runat="server" Font-Bold="True" ForeColor="#3366FF" 
                                    Width="246px" />
                                <hr />
                            </td>
                            <td align="center" class="style13">
                                </td>
                            <td align="center" class="style14">
                                </td>
                            <td align="center" class="style15">
                            </td>
                            <td align="center" class="style16">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td align="center" class="style3">
                                &nbsp;</td>
                            <td align="center" class="style12">
                                vs.</td>
                            <td align="center" class="style13">
                                <asp:Button ID="B50" runat="server" Font-Bold="True" ForeColor="#3366FF" 
                                    Width="246px" />
                                <hr />
                            </td>
                            <td align="center" class="style14">
                                &nbsp;</td>
                            <td align="center" class="style15">
                                &nbsp;</td>
                            <td align="center" class="style16">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td align="center" class="style3">
                                <asp:Button ID="B7" runat="server" Font-Bold="True" ForeColor="#FF3300" 
                                    Width="246px" />
                                <hr />
                            </td>
                            <td align="center" class="style12" rowspan="2">
                                <asp:Button ID="B36" runat="server" Font-Bold="True" ForeColor="#3366FF" 
                                    Width="246px" />
                                <hr />
                            </td>
                            <td align="center" class="style13">
                                &nbsp;</td>
                            <td align="center" class="style14">
                                &nbsp;</td>
                            <td align="center" class="style15">
                                &nbsp;</td>
                            <td align="center" class="style16">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td align="center" class="style3">
                                <asp:Button ID="B8" runat="server" Font-Bold="True" ForeColor="#3366FF" 
                                    Width="246px" />
                                <hr />
                            </td>
                            <td align="center" class="style13">
                            </td>
                            <td align="center" class="style14">
                            </td>
                            <td align="center" class="style15">
                            </td>
                            <td align="center" class="style16">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td align="center" class="style3">
                                &nbsp;</td>
                            <td align="center" class="style12">
                                &nbsp;</td>
                            <td align="center" class="style13">
                                &nbsp;</td>
                            <td align="center" class="style14">
                                vs.</td>
                            <td align="center" class="style15">
                                <asp:Button ID="B61" runat="server" Font-Bold="True" ForeColor="#FF3300" 
                                    Width="246px" />
                                <hr />
                            </td>
                            <td align="center" class="style16">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td align="center" class="style3">
                                <asp:Button ID="B9" runat="server" Font-Bold="True" ForeColor="#FF3300" 
                                    Width="246px" />
                                <hr />
                            </td>
                            <td align="center" class="style12" rowspan="2">
                                <asp:Button ID="B37" runat="server" Font-Bold="True" ForeColor="#FF3300" 
                                    Width="246px" />
                                <hr />
                            </td>
                            <td align="center" class="style13">
                                &nbsp;</td>
                            <td align="center" class="style14">
                                &nbsp;</td>
                            <td align="center" class="style15">
                                &nbsp;</td>
                            <td align="center" class="style16">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td align="center" class="style3">
                                <asp:Button ID="B10" runat="server" Font-Bold="True" ForeColor="#3366FF" 
                                    Width="246px" />
                                <hr />
                            </td>
                            <td align="center" class="style13">
                            </td>
                            <td align="center" class="style14">
                            </td>
                            <td align="center" class="style15">
                            </td>
                            <td align="center" class="style16">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td align="center" class="style3">
                                &nbsp;</td>
                            <td align="center" class="style12">
                                vs.</td>
                            <td align="center" class="style13">
                                <asp:Button ID="B51" runat="server" Font-Bold="True" ForeColor="#FF3300" 
                                    Width="246px" />
                                <hr />
                            </td>
                            <td align="center" class="style14">
                                &nbsp;</td>
                            <td align="center" class="style15">
                                &nbsp;</td>
                            <td align="center" class="style16">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td align="center" class="style3">
                                <asp:Button ID="B11" runat="server" Font-Bold="True" ForeColor="#FF3300" 
                                    Width="246px" />
                                <hr />
                            </td>
                            <td align="center" class="style12" rowspan="2">
                                <asp:Button ID="B38" runat="server" Font-Bold="True" ForeColor="#3366FF" 
                                    Width="246px" />
                                <hr />
                            </td>
                            <td align="center" class="style13">
                                &nbsp;</td>
                            <td align="center" class="style14">
                                &nbsp;</td>
                            <td align="center" class="style15">
                                &nbsp;</td>
                            <td align="center" class="style16">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td align="center" class="style3">
                                <asp:Button ID="B12" runat="server" Font-Bold="True" ForeColor="#3366FF" 
                                    Width="246px" />
                                <hr />
                            </td>
                            <td align="center" class="style13">
                            </td>
                            <td align="center" class="style14">
                            </td>
                            <td align="center" class="style15">
                            </td>
                            <td align="center" class="style16">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td align="center" class="style3">
                                &nbsp;</td>
                            <td align="center" class="style12">
                                &nbsp;</td>
                            <td align="center" class="style13">
                                vs.</td>
                            <td align="center" class="style14">
                                <asp:Button ID="B58" runat="server" Font-Bold="True" ForeColor="#3366FF" 
                                    Width="246px" />
                                <hr />
                            </td>
                            <td align="center" class="style15">
                                &nbsp;</td>
                            <td align="center" class="style16">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td align="center" class="style3">
                                <asp:Button ID="B13" runat="server" Font-Bold="True" ForeColor="#FF3300" 
                                    Width="246px" />
                                <hr />
                            </td>
                            <td align="center" class="style12" rowspan="2">
                                <asp:Button ID="B39" runat="server" Font-Bold="True" ForeColor="#FF3300" 
                                    Width="246px" />
                                <hr />
                            </td>
                            <td align="center" class="style13">
                                &nbsp;</td>
                            <td align="center" class="style14">
                                &nbsp;</td>
                            <td align="center" class="style15">
                                &nbsp;</td>
                            <td align="center" class="style16">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td align="center" class="style3">
                                <asp:Button ID="B14" runat="server" Font-Bold="True" ForeColor="#3366FF" 
                                    Width="246px" />
                                <hr />
                            </td>
                            <td align="center" class="style13">
                            </td>
                            <td align="center" class="style14">
                            </td>
                            <td align="center" class="style15">
                            </td>
                            <td align="center" class="style16">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td align="center" class="style3">
                                &nbsp;</td>
                            <td align="center" class="style12">
                                vs.</td>
                            <td align="center" class="style13">
                                <asp:Button ID="B52" runat="server" Font-Bold="True" ForeColor="#3366FF" 
                                    Width="246px" />
                                <hr />
                            </td>
                            <td align="center" class="style14">
                                &nbsp;</td>
                            <td align="center" class="style15">
                                &nbsp;</td>
                            <td align="center" class="style16">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td align="center" class="style3">
                                <asp:Button ID="B15" runat="server" Font-Bold="True" ForeColor="#FF3300" 
                                    Width="246px" />
                                <hr />
                            </td>
                            <td align="center" class="style12" rowspan="2">
                                <asp:Button ID="B40" runat="server" Font-Bold="True" ForeColor="#3366FF" 
                                    Width="246px" />
                                <hr />
                            </td>
                            <td align="center" class="style13">
                                &nbsp;</td>
                            <td align="center" class="style14">
                                &nbsp;</td>
                            <td align="center" class="style15">
                                &nbsp;</td>
                            <td align="center" class="style16">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td align="center" class="style3">
                                <asp:Button ID="B16" runat="server" Font-Bold="True" ForeColor="#3366FF" 
                                    Width="246px" />
                                <hr />
                            </td>
                            <td align="center" class="style13">
                            </td>
                            <td align="center" class="style14">
                            </td>
                            <td align="center" class="style15">
                            </td>
                            <td align="center" class="style16">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td align="center" class="style3">
                                &nbsp;</td>
                            <td align="center" class="style12">
                                &nbsp;</td>
                            <td align="center" class="style13">
                                &nbsp;</td>
                            <td align="center" class="style14">
                                &nbsp;</td>
                            <td align="center" class="style15">
                                vs.</td>
                            <td align="center" class="style16">
                                <asp:Button ID="B63" runat="server" Font-Bold="True" ForeColor="#FF3300" 
                                    Width="246px" />
                                <hr />
                            </td>
                        </tr>
                        <tr>
                            <td align="center" class="style3">
                                <asp:Button ID="B17" runat="server" Font-Bold="True" ForeColor="#FF3300" 
                                    Width="246px" />
                                <hr />
                            </td>
                            <td align="center" class="style12" rowspan="2">
                                <asp:Button ID="B41" runat="server" Font-Bold="True" ForeColor="#FF3300" 
                                    Width="246px" />
                                <hr />
                            </td>
                            <td align="center" class="style13">
                                &nbsp;</td>
                            <td align="center" class="style14">
                                &nbsp;</td>
                            <td align="center" class="style15">
                                &nbsp;</td>
                            <td align="center" class="style16">
                                <asp:Label ID="LB_WINNER" runat="server" Font-Bold="True" Font-Size="15pt" 
                                    Text="WINNER"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" class="style3">
                                <asp:Button ID="B18" runat="server" Font-Bold="True" ForeColor="#3366FF" 
                                    Width="246px" />
                                <hr />
                            </td>
                            <td align="center" class="style13">
                                &nbsp;</td>
                            <td align="center" class="style14">
                                &nbsp;</td>
                            <td align="center" class="style15">
                                &nbsp;</td>
                            <td align="center" class="style16">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td align="center" class="style3">
                                &nbsp;</td>
                            <td align="center" class="style12">
                                vs.</td>
                            <td align="center" class="style13">
                                <asp:Button ID="B53" runat="server" Font-Bold="True" ForeColor="#FF3300" 
                                    Width="246px" />
                                <hr />
                            </td>
                            <td align="center" class="style14">
                                &nbsp;</td>
                            <td align="center" class="style15">
                                &nbsp;</td>
                            <td align="center" class="style16">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td align="center" class="style3">
                                <asp:Button ID="B19" runat="server" Font-Bold="True" ForeColor="#FF3300" 
                                    Width="246px" />
                                <hr />
                            </td>
                            <td align="center" class="style12" rowspan="2">
                                <asp:Button ID="B42" runat="server" Font-Bold="True" ForeColor="#3366FF" 
                                    Width="246px" />
                                <hr />
                            </td>
                            <td align="center" class="style13">
                                &nbsp;</td>
                            <td align="center" class="style14">
                                &nbsp;</td>
                            <td align="center" class="style15">
                                &nbsp;</td>
                            <td align="center" class="style16">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td align="center" class="style3">
                                <asp:Button ID="B20" runat="server" Font-Bold="True" ForeColor="#3366FF" 
                                    Width="246px" />
                                <hr />
                            </td>
                            <td align="center" class="style13">
                                &nbsp;</td>
                            <td align="center" class="style14">
                                &nbsp;</td>
                            <td align="center" class="style15">
                                &nbsp;</td>
                            <td align="center" class="style16">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td align="center" class="style3">
                                &nbsp;</td>
                            <td align="center" class="style12">
                                &nbsp;</td>
                            <td align="center" class="style13">
                                vs.</td>
                            <td align="center" class="style14">
                                <asp:Button ID="B59" runat="server" Font-Bold="True" ForeColor="#FF3300" 
                                    Width="246px" />
                                <hr />
                            </td>
                            <td align="center" class="style15">
                                &nbsp;</td>
                            <td align="center" class="style16">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td align="center" class="style3">
                                <asp:Button ID="B21" runat="server" Font-Bold="True" ForeColor="#FF3300" 
                                    Width="246px" />
                                <hr />
                            </td>
                            <td align="center" class="style12" rowspan="2">
                                <asp:Button ID="B43" runat="server" Font-Bold="True" ForeColor="#FF3300" 
                                    Width="246px" />
                                <hr />
                            </td>
                            <td align="center" class="style13">
                                &nbsp;</td>
                            <td align="center" class="style14">
                                &nbsp;</td>
                            <td align="center" class="style15">
                                &nbsp;</td>
                            <td align="center" class="style16">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td align="center" class="style3">
                                <asp:Button ID="B22" runat="server" Font-Bold="True" ForeColor="#3366FF" 
                                    Width="246px" />
                                <hr />
                            </td>
                            <td align="center" class="style13">
                                &nbsp;</td>
                            <td align="center" class="style14">
                                &nbsp;</td>
                            <td align="center" class="style15">
                                &nbsp;</td>
                            <td align="center" class="style16">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td align="center" class="style3">
                                &nbsp;</td>
                            <td align="center" class="style12">
                                vs.</td>
                            <td align="center" class="style13">
                                <asp:Button ID="B54" runat="server" Font-Bold="True" ForeColor="#3366FF" 
                                    Width="246px" />
                                <hr />
                            </td>
                            <td align="center" class="style14">
                                &nbsp;</td>
                            <td align="center" class="style15">
                                &nbsp;</td>
                            <td align="center" class="style16">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td align="center" class="style3">
                                <asp:Button ID="B23" runat="server" Font-Bold="True" ForeColor="#FF3300" 
                                    Width="246px" />
                                <hr />
                            </td>
                            <td align="center" class="style12" rowspan="2">
                                <asp:Button ID="B44" runat="server" Font-Bold="True" ForeColor="#3366FF" 
                                    Width="246px" />
                                <hr />
                            </td>
                            <td align="center" class="style13">
                                &nbsp;</td>
                            <td align="center" class="style14">
                                &nbsp;</td>
                            <td align="center" class="style15">
                                &nbsp;</td>
                            <td align="center" class="style16">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td align="center" class="style3">
                                <asp:Button ID="B24" runat="server" Font-Bold="True" ForeColor="#3366FF" 
                                    Width="246px" />
                                <hr />
                            </td>
                            <td align="center" class="style13">
                                &nbsp;</td>
                            <td align="center" class="style14">
                                &nbsp;</td>
                            <td align="center" class="style15">
                                &nbsp;</td>
                            <td align="center" class="style16">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td align="center" class="style3">
                                &nbsp;</td>
                            <td align="center" class="style12">
                                &nbsp;</td>
                            <td align="center" class="style13">
                                &nbsp;</td>
                            <td align="center" class="style14">
                                vs.</td>
                            <td align="center" class="style15">
                                <asp:Button ID="B62" runat="server" Font-Bold="True" ForeColor="#3366FF" 
                                    Width="246px" />
                                <hr />
                            </td>
                            <td align="center" class="style16">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td align="center" class="style3">
                                <asp:Button ID="B25" runat="server" Font-Bold="True" ForeColor="#FF3300" 
                                    Width="246px" />
                                <hr />
                            </td>
                            <td align="center" class="style12" rowspan="2">
                                <asp:Button ID="B45" runat="server" Font-Bold="True" ForeColor="#FF3300" 
                                    Width="246px" />
                                <hr />
                            </td>
                            <td align="center" class="style13">
                                &nbsp;</td>
                            <td align="center" class="style14">
                                &nbsp;</td>
                            <td align="center" class="style15">
                                &nbsp;</td>
                            <td align="center" class="style16">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td align="center" class="style3">
                                <asp:Button ID="B26" runat="server" Font-Bold="True" ForeColor="#3366FF" 
                                    Width="246px" />
                                <hr />
                            </td>
                            <td align="center" class="style13">
                                &nbsp;</td>
                            <td align="center" class="style14">
                                &nbsp;</td>
                            <td align="center" class="style15">
                                &nbsp;</td>
                            <td align="center" class="style16">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td align="center" class="style3">
                                &nbsp;</td>
                            <td align="center" class="style12">
                                vs.</td>
                            <td align="center" class="style13">
                                <asp:Button ID="B55" runat="server" Font-Bold="True" ForeColor="#FF3300" 
                                    Width="246px" />
                                <hr />
                            </td>
                            <td align="center" class="style14">
                                &nbsp;</td>
                            <td align="center" class="style15">
                                &nbsp;</td>
                            <td align="center" class="style16">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td align="center" class="style3">
                                <asp:Button ID="B27" runat="server" Font-Bold="True" ForeColor="#FF3300" 
                                    Width="246px" />
                                <hr />
                            </td>
                            <td align="center" class="style12" rowspan="2">
                                <asp:Button ID="B46" runat="server" Font-Bold="True" ForeColor="#3366FF" 
                                    Width="246px" />
                                <hr />
                            </td>
                            <td align="center" class="style13">
                                &nbsp;</td>
                            <td align="center" class="style14">
                                &nbsp;</td>
                            <td align="center" class="style15">
                                &nbsp;</td>
                            <td align="center" class="style16">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td align="center" class="style3">
                                <asp:Button ID="B28" runat="server" Font-Bold="True" ForeColor="#3366FF" 
                                    Width="246px" />
                                <hr />
                            </td>
                            <td align="center" class="style13">
                                &nbsp;</td>
                            <td align="center" class="style14">
                                &nbsp;</td>
                            <td align="center" class="style15">
                                &nbsp;</td>
                            <td align="center" class="style16">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td align="center" class="style3">
                                &nbsp;</td>
                            <td align="center" class="style12">
                                &nbsp;</td>
                            <td align="center" class="style13">
                                vs.</td>
                            <td align="center" class="style14">
                                <asp:Button ID="B60" runat="server" Font-Bold="True" ForeColor="#3366FF" 
                                    Width="246px" />
                                <hr />
                            </td>
                            <td align="center" class="style15">
                                &nbsp;</td>
                            <td align="center" class="style16">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td align="center" class="style3">
                                <asp:Button ID="B29" runat="server" Font-Bold="True" ForeColor="#FF3300" 
                                    Width="246px" />
                                <hr />
                            </td>
                            <td align="center" class="style12" rowspan="2">
                                <asp:Button ID="B47" runat="server" Font-Bold="True" ForeColor="#FF3300" 
                                    Width="246px" />
                                <hr />
                            </td>
                            <td align="center" class="style13">
                                &nbsp;</td>
                            <td align="center" class="style14">
                                &nbsp;</td>
                            <td align="center" class="style15">
                                &nbsp;</td>
                            <td align="center" class="style16">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td align="center" class="style3">
                                <asp:Button ID="B30" runat="server" Font-Bold="True" ForeColor="#3366FF" 
                                    Width="246px" />
                                <hr />
                            </td>
                            <td align="center" class="style13">
                                &nbsp;</td>
                            <td align="center" class="style14">
                                &nbsp;</td>
                            <td align="center" class="style15">
                                &nbsp;</td>
                            <td align="center" class="style16">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td align="center" class="style3">
                                &nbsp;</td>
                            <td align="center" class="style12">
                                vs.</td>
                            <td align="center" class="style13">
                                <asp:Button ID="B56" runat="server" Font-Bold="True" ForeColor="#3366FF" 
                                    Width="246px" />
                                <hr />
                            </td>
                            <td align="center" class="style14">
                                &nbsp;</td>
                            <td align="center" class="style15">
                                &nbsp;</td>
                            <td align="center" class="style16">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td align="center" class="style3">
                                <asp:Button ID="B31" runat="server" Font-Bold="True" ForeColor="#FF3300" 
                                    Width="246px" />
                                <hr />
                            </td>
                            <td align="center" class="style12" rowspan="2">
                                <asp:Button ID="B48" runat="server" Font-Bold="True" ForeColor="#3366FF" 
                                    Width="246px" />
                                <hr />
                            </td>
                            <td align="center" class="style13">
                                &nbsp;</td>
                            <td align="center" class="style14">
                                &nbsp;</td>
                            <td align="center" class="style15">
                                &nbsp;</td>
                            <td align="center" class="style16">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td align="center" class="style3">
                                <asp:Button ID="B32" runat="server" Font-Bold="True" ForeColor="#3366FF" 
                                    Width="246px" />
                                <hr />
                            </td>
                            <td align="center" class="style13">
                                &nbsp;</td>
                            <td align="center" class="style14">
                                &nbsp;</td>
                            <td align="center" class="style15">
                                &nbsp;</td>
                            <td align="center" class="style16">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td align="center" class="style3">
                                &nbsp;</td>
                            <td align="center" class="style12">
                                &nbsp;</td>
                            <td align="center" class="style13">
                                &nbsp;</td>
                            <td align="center" class="style14">
                                &nbsp;</td>
                            <td align="center" class="style15">
                                &nbsp;</td>
                            <td align="center" class="style16">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td align="center" class="style3">
                                &nbsp;</td>
                            <td align="center" class="style12">
                                &nbsp;</td>
                            <td align="center" class="style13">
                                &nbsp;</td>
                            <td align="center" class="style14">
                                &nbsp;</td>
                            <td align="center" class="style15">
                                &nbsp;</td>
                            <td align="center" class="style16">
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
        
    
    
  


</ContentTemplate>
</asp:UpdatePanel>
</asp:Content>
