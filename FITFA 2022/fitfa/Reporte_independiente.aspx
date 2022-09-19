<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Reporte_independiente.aspx.vb" Inherits="fitfa.Reporte_independiente" %>
<%--
<%@ Register assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>
--%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <div style="text-align: center" visible=false >
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
    </div>
    <div>
<%--        <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" 
            AutoDataBind="true" ReportSourceID="CrystalReportSource1" 
            ToolPanelView="None" Height="1269px" Width="881px" 
            HasCrystalLogo="False" PageZoomFactor="150" />
        <CR:CrystalReportSource ID="CrystalReportSource1" runat="server">
            <Report FileName="Reportes\Inscripciones\CRprueba.rpt">
            </Report>
        </CR:CrystalReportSource>
--%>    </div>

    
    
    </div>
    </form>
</body>
</html>
