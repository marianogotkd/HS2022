<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WebFormReporte01.aspx.vb" Inherits="Presentacion.WebFormReporte01" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
  <script lang="javaScript" type="text/javascript" src="crystalreportviewers13/js/crviewer/crv.js"></script> 
</head>
<body>
    <form id="form1" runat="server">
        <div>Hola :</div>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
            
   </asp:ScriptManager>
            <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true" ReportSourceID="CrystalReportSource1" EnableDatabaseLogonPrompt="False" EnableParameterPrompt="False" />
            
            <br />
        holaaaaaaaaaaaa<CR:CrystalReportSource ID="CrystalReportSource1" runat="server" ViewStateMode="Enabled">
                <Report FileName="F:\048 WebCentral.root\Web Central_v5\Presentacion\WC_Liquidacion Parcial\Reportes\CR01.rpt">
                </Report>
               
                
            </CR:CrystalReportSource>
       
            
    </form>
</body>
</html>

