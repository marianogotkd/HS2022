<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/MasterPage.Master" CodeBehind="Llave_mod_b.aspx.vb" Inherits="fitfa.Llave_mod_b" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<style type="text/css">
        .style2
        {
            width: 413px;
        }
        .modalBackground
        {
            background-color:black;
            filter:alpha(opacity=99) !important;
            opacity:0.6 ! important;
            z-index:20;
            }
    .style73
    {
        width: 700px;
        height: 500px;
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
                              style="background-position: center center; background-image: url('http://localhost:4770/img/FitfaLogo.png'); background-repeat: no-repeat; background-attachment: scroll;"></div>
                          <div class="col-sm-6">
                    <table id="tabla" runat="server" align="center" class="style73" 
                        style="background-image: url('../img/500x500.jpg'); background-repeat: no-repeat; background-position: center center; table-layout: fixed; width: 500px; height: 500px;">
                        <tr>
                            <td align="center">
                                <asp:Button ID="B1" runat="server" BackColor="#FF3300" Font-Size="Small" 
                                    ForeColor="White" Height="40px" Text="(0000)" Width="60px" 
                                    Visible="False" />
                            </td>
                            <td align="center">
                                &nbsp;</td>
                            <td align="center">
                                &nbsp;</td>
                            <td align="center">
                                &nbsp;</td>
                            <td align="center">
                                &nbsp;</td>
                            <td align="center">
                                &nbsp;</td>
                            <td align="center">
                                <asp:Button ID="Button2" runat="server" BackColor="#FFFFD9" Font-Size="Small" 
                                    ForeColor="#3333CC" Height="60px" Text="(0000)" Visible="False" Width="60px" />
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                <asp:Button ID="Button3" runat="server" BackColor="#FFFFD9" Font-Size="Small" 
                                    ForeColor="#3333CC" Height="60px" Text="(0000)" Visible="False" Width="60px" />
                            </td>
                            <td align="center">
                                &nbsp;</td>
                            <td align="center">
                                <asp:Button ID="B5" runat="server" BackColor="#FF3300" Font-Size="Small" 
                                    ForeColor="White" Height="40px" Text="(0000)" Width="60px" 
                                    Visible="False" />
                            </td>
                            <td align="center">
                                &nbsp;</td>
                            <td align="center">
                                &nbsp;</td>
                            <td align="center">
                                &nbsp;</td>
                            <td align="center">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td align="center">
                                <asp:Button ID="B2" runat="server" BackColor="#3399FF" Font-Bold="False" 
                                    Font-Size="Small" ForeColor="White" Height="40px" Text="(0000)" 
                                    Width="60px" Visible="False" />
                            </td>
                            <td align="center">
                                &nbsp;</td>
                            <td align="center">
                                &nbsp;</td>
                            <td align="center">
                                &nbsp;</td>
                            <td align="center">
                                &nbsp;</td>
                            <td align="center">
                                &nbsp;</td>
                            <td align="center">
                                <asp:Button ID="Button6" runat="server" BackColor="#FFFFD9" Font-Size="Small" 
                                    ForeColor="#3333CC" Height="60px" Text="(0000)" Visible="False" Width="60px" />
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                <asp:Button ID="Button9" runat="server" BackColor="#FFFFD9" Font-Size="Small" 
                                    ForeColor="#3333CC" Height="60px" Text="(0000)" Visible="False" Width="60px" />
                            </td>
                            <td align="center">
                                &nbsp;</td>
                            <td align="center">
                                &nbsp;</td>
                            <td align="center">
                                &nbsp;</td>
                            <td align="center">
                                &nbsp;</td>
                            <td align="center">
                                <asp:Button ID="B7" runat="server" BackColor="#FF3300" Font-Size="Small" 
                                    ForeColor="White" Height="40px" Text="(0000)" Width="60px" 
                                    Visible="False" />
                            </td>
                            <td align="center">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td align="center">
                                <asp:Button ID="B3" runat="server" BackColor="#FF3300" Font-Size="Small" 
                                    ForeColor="White" Height="40px" Text="(0000)" Width="60px" 
                                    Visible="False" />
                            </td>
                            <td align="center">
                                &nbsp;</td>
                            <td align="center">
                                <asp:Button ID="Button17" runat="server" BackColor="#FFFFD9" Font-Size="Small" 
                                    ForeColor="#3333CC" Height="60px" Text="(0000)" Visible="False" Width="60px" />
                            </td>
                            <td align="center">
                                &nbsp;</td>
                            <td align="center" colspan="3">
                                <asp:Label ID="LB_WINNER" runat="server" Font-Bold="True" Font-Size="15pt" 
                                    Text="WINNER" Visible="False"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                <asp:Button ID="Button18" runat="server" BackColor="#FFFFD9" Font-Size="Small" 
                                    ForeColor="#3333CC" Height="60px" Text="(0000)" Visible="False" Width="60px" />
                            </td>
                            <td align="center">
                                &nbsp;</td>
                            <td align="center">
                                <asp:Button ID="B6" runat="server" BackColor="#3399FF" Font-Bold="False" 
                                    Font-Size="Small" ForeColor="White" Height="40px" Text="(0000)" 
                                    Width="60px" Visible="False" />
                            </td>
                            <td align="center">
                                &nbsp;</td>
                            <td align="center">
                                &nbsp;</td>
                            <td align="center">
                                &nbsp;</td>
                            <td align="center">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td align="center">
                                <asp:Button ID="B4" runat="server" BackColor="#3399FF" Font-Bold="False" 
                                    Font-Size="Small" ForeColor="White" Height="40px" Text="(0000)" 
                                    Width="60px" Visible="False" />
                            </td>
                            <td align="center">
                                &nbsp;</td>
                            <td align="center">
                                &nbsp;</td>
                            <td align="center">
                                &nbsp;</td>
                            <td align="center">
                                &nbsp;</td>
                            <td align="center">
                                &nbsp;</td>
                            <td align="center">
                                <asp:Button ID="Button21" runat="server" BackColor="#FFFFD9" Font-Size="Small" 
                                    ForeColor="#3333CC" Height="60px" Text="(0000)" Visible="False" Width="60px" />
                            </td>
                        </tr>
                    </table>
                             
                        
                          </div>
                          <div class="col-sm-3" 
                              
                              style="background-position: center center; background-image: url('http://localhost:4770/img/FitfaLogo.png'); background-repeat: no-repeat; background-attachment: scroll;"></div>
                    </div>
                    
                    
                    
              </div>
               
              <div id="seccion_competencia" runat="server">
              <div align="center" style="background-color: #C0C0C0">
              <asp:Label ID="Label6" runat="server" Text="DATOS DE COMPETENCIA" Font-Bold="True"></asp:Label>      
              </div>

              <div align="left">
                    <table class="w-100">
                        <tr>
                            <td class="style2">
                                <asp:Label ID="Label11" runat="server" Font-Bold="True" Text="Peso:"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txt_peso" runat="server" MaxLength="5" 
                                    ToolTip="ejemplo(75,50 kg)" Height="25px" Width="70px"></asp:TextBox>
                                
                                
                            </td>
                        </tr>
                        <tr>
                            <td class="style2">
                                <asp:Label ID="Label12" runat="server" Font-Bold="True" Text="Compite en Lucha:"></asp:Label>
                            </td>
                            <td>
                                <asp:RadioButton ID="RadioButton_lucha_si" runat="server" Text="Si" 
                                    AutoPostBack="True" />
                                <asp:RadioButton ID="RadioButton_lucha_no" runat="server" Checked="True" 
                                    Text="No" AutoPostBack="True" />
                            </td>
                        </tr>
                        <tr>
                            <td class="style2">
                                <asp:Label ID="Label13" runat="server" Font-Bold="True" Text="Compite en Formas:"></asp:Label></td>
                            <td>
                                <asp:RadioButton ID="RadioButton_formas_si" runat="server" Text="Si" 
                                    AutoPostBack="True" />
                                <asp:RadioButton ID="RadioButton_formas_no" runat="server" Checked="True" 
                                    Text="No" AutoPostBack="True" />
                            </td>
                        </tr>
                        <tr>
                            <td class="style2">
                                <asp:Label ID="Label14" runat="server" Font-Bold="True" Text="Compite en Rotura de Poder:"></asp:Label></td>
                            <td>
                                <asp:RadioButton ID="RadioButton_poder_si" runat="server" Text="Si" 
                                    AutoPostBack="True" />
                                <asp:RadioButton ID="RadioButton_poder_no" runat="server" Checked="True" 
                                    Text="No" AutoPostBack="True" />
                            </td>
                        </tr>
                        <tr>
                            <td class="style2">
                                <asp:Label ID="Label17" runat="server" Font-Bold="True" Text="Compite en Rotura con Técnica Especial:"></asp:Label></td>
                            <td>
                                <asp:RadioButton ID="RadioButton_tecnica_si" runat="server" Text="Si" 
                                    AutoPostBack="True" />
                                <asp:RadioButton ID="RadioButton_tecnica_no" runat="server" Checked="True" 
                                    Text="No" AutoPostBack="True" />
                            </td>
                        </tr>
                    </table>
                    
              </div> 
              </div>


              
              
              </div>
              </form>


    </div>
        
    
    
  


</ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="RadioButton_lucha_si" 
            EventName="CheckedChanged" />
        <asp:AsyncPostBackTrigger ControlID="RadioButton_lucha_no" 
            EventName="CheckedChanged" />
        <asp:AsyncPostBackTrigger ControlID="RadioButton_formas_si" 
            EventName="CheckedChanged" />
        <asp:AsyncPostBackTrigger ControlID="RadioButton_formas_no" 
            EventName="CheckedChanged" />
        <asp:AsyncPostBackTrigger ControlID="RadioButton_poder_si" 
            EventName="CheckedChanged" />
        <asp:AsyncPostBackTrigger ControlID="RadioButton_poder_no" 
            EventName="CheckedChanged" />
        <asp:AsyncPostBackTrigger ControlID="RadioButton_tecnica_si" 
            EventName="CheckedChanged" />
        <asp:AsyncPostBackTrigger ControlID="RadioButton_tecnica_no" 
            EventName="CheckedChanged" />
    </Triggers>
</asp:UpdatePanel>


</asp:Content>
