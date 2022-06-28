<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Form_rptprueba.aspx.vb" Inherits="Presentacion.Form_rptprueba" %>

<%@ Register assembly="CrystalDecisions.Web, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
          <CR:CrystalReportSource ID="CrystalReportSource1" runat="server"></CR:CrystalReportSource>
          <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true" />
          <asp:Button ID="Button1" runat="server" Text="Button" OnClientClick="window.open('asd.pdf','_blank')" />
          <asp:Button ID="Button2" runat="server" Text="HttpResponse" />
        </div>
    </form>
</body>
</html>
