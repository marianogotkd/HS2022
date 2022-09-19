<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/MasterPage.Master" CodeBehind="Llave_mod_d.aspx.vb" Inherits="fitfa.Llave_mod_d" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style2
        {
            height: 35px;
        }
        .style4
        {
            height: 26px;
        }
        .style5
        {
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
                          <div class="col-sm-3" 
                              
                              
                              style="background-position: center center; background-repeat: no-repeat; background-attachment: scroll;"></div>
                    </div>
                    
                    
                    
              </div>
              <div align="left">
                    
                    <table ID="tabla" runat="server" align="center" class="style73" 
                        
                        
                        style="background-repeat: no-repeat; background-position: center center; table-layout: fixed; width: 1500px; height: 1500px; background-color: #FFFFCC;">
                        <tr>
                            <td align="center" class="style76">
                                <asp:Button ID="Button1" runat="server" Width="246px" Visible="False" />
                            </td>
                            <td align="center" class="style76" rowspan="2">
                                <asp:Button ID="Button17" runat="server" Width="246px" />
                            </td>
                            <td align="center" class="style76" rowspan="5">
                                <asp:Button ID="Button25" runat="server" Width="246px" />
                            </td>
                            <td align="center" class="style76">
                                &nbsp;</td>
                            <td align="center" class="style76">
                                &nbsp;</td>
                            <td align="center" class="style76">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td align="center" class="style76">
                                <asp:Button ID="Button2" runat="server" Width="246px" Visible="False" />
                            </td>
                            <td align="center" class="style76">
                                &nbsp;</td>
                            <td align="center" class="style76">
                                &nbsp;</td>
                            <td align="center" class="style76">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td align="center" class="style76">
                                &nbsp;</td>
                            <td align="center" class="style76">
                                vs.&nbsp;</td>
                            <td align="center" class="style76">
                                &nbsp;</td>
                            <td align="center" class="style76">
                                &nbsp;</td>
                            <td align="center" class="style76">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td align="center" class="style5">
                                <asp:Button ID="Button3" runat="server" Width="246px" Visible="False" />
                            </td>
                            <td align="center" class="style5" rowspan="2">
                                <asp:Button ID="Button18" runat="server" Width="246px" />
                            </td>
                            <td align="center" class="style5">
                            </td>
                            <td align="center" class="style5">
                                &nbsp;</td>
                            <td align="center" class="style5">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td align="center" class="style76">
                                <asp:Button ID="Button4" runat="server" Width="246px" Visible="False" />
                            </td>
                            <td align="center" class="style76">
                                &nbsp;</td>
                            <td align="center" class="style76">
                                &nbsp;</td>
                            <td align="center" class="style76">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td align="center" class="style76">
                                &nbsp;</td>
                            <td align="center" class="style76">
                                &nbsp;</td>
                            <td align="center" class="style76">
                                vs.</td>
                            <td align="center" class="style76">
                                <asp:Button ID="Button57" runat="server" Width="246px" />
                            </td>
                            <td align="center" class="style76">
                                &nbsp;</td>
                            <td align="center" class="style76">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td align="center" class="style76">
                                <asp:Button ID="Button5" runat="server" Width="246px" Visible="False" />
                            </td>
                            <td align="center" class="style76" rowspan="2">
                                <asp:Button ID="Button19" runat="server" Width="246px" />
                            </td>
                            <td align="center" class="style76" rowspan="5">
                                <asp:Button ID="Button50" runat="server" Width="246px" />
                            </td>
                            <td align="center" class="style76">
                                &nbsp;</td>
                            <td align="center" class="style76">
                                &nbsp;</td>
                            <td align="center" class="style76">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td align="center" class="style4">
                                <asp:Button ID="Button6" runat="server" Width="246px" Visible="False" />
                            </td>
                            <td align="center" class="style4">
                            </td>
                            <td align="center" class="style4">
                                &nbsp;</td>
                            <td align="center" class="style4">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td align="center" class="style76">
                                &nbsp;</td>
                            <td align="center" class="style76">
                                vs.</td>
                            <td align="center" class="style76">
                                &nbsp;</td>
                            <td align="center" class="style76">
                                &nbsp;</td>
                            <td align="center" class="style76">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td align="center" class="style76">
                                <asp:Button ID="Button7" runat="server" Width="246px" Visible="False" />
                            </td>
                            <td align="center" class="style76" rowspan="2">
                                <asp:Button ID="Button20" runat="server" Width="246px" />
                            </td>
                            <td align="center" class="style76">
                                &nbsp;</td>
                            <td align="center" class="style76">
                                &nbsp;</td>
                            <td align="center" class="style76">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td align="center" class="style2">
                                <asp:Button ID="Button8" runat="server" Width="246px" Visible="False" />
                            </td>
                            <td align="center" class="style2">
                                &nbsp;</td>
                            <td align="center" class="style2">
                                &nbsp;</td>
                            <td align="center" class="style2">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td align="center" class="style76">
                                &nbsp;</td>
                            <td align="center" class="style76">
                                &nbsp;</td>
                            <td align="center" class="style76">
                                &nbsp;</td>
                            <td align="center" class="style76">
                                vs.</td>
                            <td align="center" class="style76">
                                <asp:Button ID="Button61" runat="server" Width="246px" />
                            </td>
                            <td align="center" class="style76">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td align="center" class="style76">
                                <asp:Button ID="Button9" runat="server" Width="246px" Visible="False" />
                            </td>
                            <td align="center" class="style76" rowspan="2">
                                <asp:Button ID="Button21" runat="server" Width="246px" />
                            </td>
                            <td align="center" class="style76" rowspan="5">
                                <asp:Button ID="Button51" runat="server" Width="246px" />
                            </td>
                            <td align="center" class="style76">
                                &nbsp;</td>
                            <td align="center" class="style76">
                                &nbsp;</td>
                            <td align="center" class="style76">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td align="center" class="style76">
                                <asp:Button ID="Button10" runat="server" Width="246px" Visible="False" />
                            </td>
                            <td align="center" class="style76">
                                &nbsp;</td>
                            <td align="center" class="style76">
                                &nbsp;</td>
                            <td align="center" class="style76">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td align="center" class="style76">
                                &nbsp;</td>
                            <td align="center" class="style76">
                                vs.</td>
                            <td align="center" class="style76">
                                &nbsp;</td>
                            <td align="center" class="style76">
                                &nbsp;</td>
                            <td align="center" class="style76">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td align="center" class="style76">
                                <asp:Button ID="Button11" runat="server" Width="246px" Visible="False" />
                            </td>
                            <td align="center" class="style76" rowspan="2">
                                <asp:Button ID="Button22" runat="server" Width="246px" />
                            </td>
                            <td align="center" class="style76">
                                &nbsp;</td>
                            <td align="center" class="style76">
                                &nbsp;</td>
                            <td align="center" class="style76">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td align="center" class="style76">
                                <asp:Button ID="Button12" runat="server" Width="246px" Visible="False" />
                            </td>
                            <td align="center" class="style76">
                                &nbsp;</td>
                            <td align="center" class="style76">
                                &nbsp;</td>
                            <td align="center" class="style76">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td align="center" class="style76">
                                &nbsp;</td>
                            <td align="center" class="style76">
                                &nbsp;</td>
                            <td align="center" class="style76">
                                vs.</td>
                            <td align="center" class="style76">
                                <asp:Button ID="Button58" runat="server" Width="246px" />
                            </td>
                            <td align="center" class="style76">
                                &nbsp;</td>
                            <td align="center" class="style76">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td align="center" class="style76">
                                <asp:Button ID="Button13" runat="server" Width="246px" Visible="False" />
                            </td>
                            <td align="center" class="style76" rowspan="2">
                                <asp:Button ID="Button23" runat="server" Width="246px" />
                            </td>
                            <td align="center" class="style76" rowspan="5">
                                <asp:Button ID="Button52" runat="server" Width="246px" />
                            </td>
                            <td align="center" class="style76">
                                &nbsp;</td>
                            <td align="center" class="style76">
                                &nbsp;</td>
                            <td align="center" class="style76">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td align="center" class="style76">
                                <asp:Button ID="Button14" runat="server" Width="246px" Visible="False" />
                            </td>
                            <td align="center" class="style76">
                                &nbsp;</td>
                            <td align="center" class="style76">
                                &nbsp;</td>
                            <td align="center" class="style76">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td align="center" class="style76">
                                &nbsp;</td>
                            <td align="center" class="style76">
                                vs.</td>
                            <td align="center" class="style76">
                                &nbsp;</td>
                            <td align="center" class="style76">
                                &nbsp;</td>
                            <td align="center" class="style76">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td align="center" class="style76">
                                <asp:Button ID="Button15" runat="server" Width="246px" Visible="False" />
                            </td>
                            <td align="center" class="style76" rowspan="2">
                                <asp:Button ID="Button24" runat="server" Width="246px" />
                            </td>
                            <td align="center" class="style76">
                                &nbsp;</td>
                            <td align="center" class="style76">
                                &nbsp;</td>
                            <td align="center" class="style76">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td align="center" class="style76">
                                <asp:Button ID="Button16" runat="server" Width="246px" Visible="False" />
                            </td>
                            <td align="center" class="style76">
                                &nbsp;</td>
                            <td align="center" class="style76">
                                &nbsp;</td>
                            <td align="center" class="style76">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td align="center" class="style76">
                                &nbsp;</td>
                            <td align="center" class="style76">
                                &nbsp;</td>
                            <td align="center" class="style76">
                                &nbsp;</td>
                            <td align="center" class="style76">
                                &nbsp;</td>
                            <td align="center" class="style76">
                                vs.</td>
                            <td align="center" class="style76">
                                <asp:Button ID="Button63" runat="server" Width="246px" />
                            </td>
                        </tr>
                        <tr>
                            <td align="center" class="style76">
                                <asp:Button ID="Button26" runat="server" Width="246px" Visible="False" />
                            </td>
                            <td align="center" class="style76" rowspan="2">
                                <asp:Button ID="Button49" runat="server" Width="246px" />
                            </td>
                            <td align="center" class="style76" rowspan="5">
                                <asp:Button ID="Button53" runat="server" Width="246px" />
                            </td>
                            <td align="center" class="style76">
                                &nbsp;</td>
                            <td align="center" class="style76">
                                &nbsp;</td>
                            <td align="center" class="style76">
                                <asp:Label ID="LB_WINNER" runat="server" Font-Bold="True" Font-Size="15pt" 
                                    Text="WINNER"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" class="style76">
                                <asp:Button ID="Button27" runat="server" Width="246px" Visible="False" />
                            </td>
                            <td align="center" class="style76">
                                &nbsp;</td>
                            <td align="center" class="style76">
                                &nbsp;</td>
                            <td align="center" class="style76">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td align="center" class="style76">
                                &nbsp;</td>
                            <td align="center" class="style76">
                                vs.</td>
                            <td align="center" class="style76">
                                &nbsp;</td>
                            <td align="center" class="style76">
                                &nbsp;</td>
                            <td align="center" class="style76">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td align="center" class="style76">
                                <asp:Button ID="Button28" runat="server" Width="246px" Visible="False" />
                            </td>
                            <td align="center" class="style76" rowspan="2">
                                <asp:Button ID="Button48" runat="server" Width="246px" />
                            </td>
                            <td align="center" class="style76">
                                &nbsp;</td>
                            <td align="center" class="style76">
                                &nbsp;</td>
                            <td align="center" class="style76">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td align="center" class="style76">
                                <asp:Button ID="Button29" runat="server" Width="246px" Visible="False" />
                            </td>
                            <td align="center" class="style76">
                                &nbsp;</td>
                            <td align="center" class="style76">
                                &nbsp;</td>
                            <td align="center" class="style76">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td align="center" class="style76">
                                &nbsp;</td>
                            <td align="center" class="style76">
                                &nbsp;</td>
                            <td align="center" class="style76">
                                vs.</td>
                            <td align="center" class="style76">
                                <asp:Button ID="Button59" runat="server" Width="246px" />
                            </td>
                            <td align="center" class="style76">
                                &nbsp;</td>
                            <td align="center" class="style76">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td align="center" class="style76">
                                <asp:Button ID="Button30" runat="server" Width="246px" Visible="False" />
                            </td>
                            <td align="center" class="style76" rowspan="2">
                                <asp:Button ID="Button47" runat="server" Width="246px" />
                            </td>
                            <td align="center" class="style76" rowspan="5">
                                <asp:Button ID="Button54" runat="server" Width="246px" />
                            </td>
                            <td align="center" class="style76">
                                &nbsp;</td>
                            <td align="center" class="style76">
                                &nbsp;</td>
                            <td align="center" class="style76">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td align="center" class="style76">
                                <asp:Button ID="Button31" runat="server" Width="246px" Visible="False" />
                            </td>
                            <td align="center" class="style76">
                                &nbsp;</td>
                            <td align="center" class="style76">
                                &nbsp;</td>
                            <td align="center" class="style76">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td align="center" class="style76">
                                &nbsp;</td>
                            <td align="center" class="style76">
                                vs.</td>
                            <td align="center" class="style76">
                                &nbsp;</td>
                            <td align="center" class="style76">
                                &nbsp;</td>
                            <td align="center" class="style76">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td align="center" class="style76">
                                <asp:Button ID="Button32" runat="server" Width="246px" Visible="False" />
                            </td>
                            <td align="center" class="style76" rowspan="2">
                                <asp:Button ID="Button46" runat="server" Width="246px" />
                            </td>
                            <td align="center" class="style76">
                                &nbsp;</td>
                            <td align="center" class="style76">
                                &nbsp;</td>
                            <td align="center" class="style76">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td align="center" class="style76">
                                <asp:Button ID="Button33" runat="server" Width="246px" Visible="False" />
                            </td>
                            <td align="center" class="style76">
                                &nbsp;</td>
                            <td align="center" class="style76">
                                &nbsp;</td>
                            <td align="center" class="style76">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td align="center" class="style76">
                                &nbsp;</td>
                            <td align="center" class="style76">
                                &nbsp;</td>
                            <td align="center" class="style76">
                                &nbsp;</td>
                            <td align="center" class="style76">
                                vs.</td>
                            <td align="center" class="style76">
                                <asp:Button ID="Button62" runat="server" Width="246px" />
                            </td>
                            <td align="center" class="style76">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td align="center" class="style76">
                                <asp:Button ID="Button34" runat="server" Width="246px" Visible="False" />
                            </td>
                            <td align="center" class="style76" rowspan="2">
                                <asp:Button ID="Button45" runat="server" Width="246px" />
                            </td>
                            <td align="center" class="style76" rowspan="5">
                                <asp:Button ID="Button55" runat="server" Width="246px" />
                            </td>
                            <td align="center" class="style76">
                                &nbsp;</td>
                            <td align="center" class="style76">
                                &nbsp;</td>
                            <td align="center" class="style76">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td align="center" class="style76">
                                <asp:Button ID="Button35" runat="server" Width="246px" Visible="False" />
                            </td>
                            <td align="center" class="style76">
                                &nbsp;</td>
                            <td align="center" class="style76">
                                &nbsp;</td>
                            <td align="center" class="style76">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td align="center" class="style76">
                                &nbsp;</td>
                            <td align="center" class="style76">
                                vs.</td>
                            <td align="center" class="style76">
                                &nbsp;</td>
                            <td align="center" class="style76">
                                &nbsp;</td>
                            <td align="center" class="style76">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td align="center" class="style76">
                                <asp:Button ID="Button36" runat="server" Width="246px" Visible="False" />
                            </td>
                            <td align="center" class="style76" rowspan="2">
                                <asp:Button ID="Button44" runat="server" Width="246px" />
                            </td>
                            <td align="center" class="style76">
                                &nbsp;</td>
                            <td align="center" class="style76">
                                &nbsp;</td>
                            <td align="center" class="style76">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td align="center" class="style76">
                                <asp:Button ID="Button37" runat="server" Width="246px" Visible="False" />
                            </td>
                            <td align="center" class="style76">
                                &nbsp;</td>
                            <td align="center" class="style76">
                                &nbsp;</td>
                            <td align="center" class="style76">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td align="center" class="style4">
                            </td>
                            <td align="center" class="style4">
                            </td>
                            <td align="center" class="style4">
                                vs.</td>
                            <td align="center" class="style4">
                                <asp:Button ID="Button60" runat="server" Width="246px" />
                            </td>
                            <td align="center" class="style4">
                                &nbsp;</td>
                            <td align="center" class="style4">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td align="center" class="style76">
                                <asp:Button ID="Button38" runat="server" Width="246px" Visible="False" />
                            </td>
                            <td align="center" class="style76" rowspan="2">
                                <asp:Button ID="Button43" runat="server" Width="246px" />
                            </td>
                            <td align="center" class="style76" rowspan="5">
                                <asp:Button ID="Button56" runat="server" Width="246px" />
                            </td>
                            <td align="center" class="style76">
                                &nbsp;</td>
                            <td align="center" class="style76">
                                &nbsp;</td>
                            <td align="center" class="style76">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td align="center" class="style76">
                                <asp:Button ID="Button39" runat="server" Width="246px" Visible="False" />
                            </td>
                            <td align="center" class="style76">
                                &nbsp;</td>
                            <td align="center" class="style76">
                                &nbsp;</td>
                            <td align="center" class="style76">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td align="center" class="style76">
                                &nbsp;</td>
                            <td align="center" class="style76">
                                vs.</td>
                            <td align="center" class="style76">
                                &nbsp;</td>
                            <td align="center" class="style76">
                                &nbsp;</td>
                            <td align="center" class="style76">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td align="center" class="style76">
                                <asp:Button ID="Button40" runat="server" Width="246px" Visible="False" />
                            </td>
                            <td align="center" class="style76" rowspan="2">
                                <asp:Button ID="Button42" runat="server" Width="246px" />
                            </td>
                            <td align="center" class="style76">
                                &nbsp;</td>
                            <td align="center" class="style76">
                                &nbsp;</td>
                            <td align="center" class="style76">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td align="center" class="style76">
                                <asp:Button ID="Button41" runat="server" Width="246px" Visible="False" />
                            </td>
                            <td align="center" class="style76">
                                &nbsp;</td>
                            <td align="center" class="style76">
                                &nbsp;</td>
                            <td align="center" class="style76">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td align="center" class="style76">
                                &nbsp;</td>
                            <td align="center" class="style76">
                                &nbsp;</td>
                            <td align="center" class="style76">
                                &nbsp;</td>
                            <td align="center" class="style76">
                                &nbsp;</td>
                            <td align="center" class="style76">
                                &nbsp;</td>
                            <td align="center" class="style76">
                                &nbsp;</td>
                        </tr>
                    </table>
                    
                    <br />
                    
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
