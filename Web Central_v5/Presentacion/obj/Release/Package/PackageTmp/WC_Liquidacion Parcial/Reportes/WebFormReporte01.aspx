<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WebFormReporte01.aspx.vb" Inherits="Presentacion.WebFormReporte01" %>

<%@ Register assembly="CrystalDecisions.Web, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
 <meta http-equiv="X-UA-Compatible" content="IE=Edge" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
      <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
      Hola a todos
      <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" ReportSourceID="CrystalReportSource1" ToolPanelView="None" ReuseParameterValuesOnRefresh="False" Height="1202px" SeparatePages="False" Width="903px" AutoDataBind="True" />

<CR:CrystalReportSource ID="CrystalReportSource1" runat="server">
    <Report FileName="CR01.rpt">
    </Report>

        </CR:CrystalReportSource>
        <div>          
          
        </div>
         
    </form>
    
       
</body>
</html>
