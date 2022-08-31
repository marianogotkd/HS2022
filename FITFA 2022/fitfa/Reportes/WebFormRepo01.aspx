<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WebFormRepo01.aspx.vb" Inherits="fitfa.WebFormRepo01" %>

<%@ Register assembly="CrystalDecisions.Web, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <CR:CrystalReportSource ID="CrystalReportSource1" runat="server">
                <report filename="Repo01.rpt">
                </report>
            </CR:CrystalReportSource>
            <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true" ReportSourceID="CrystalReportSource1" />
        </div>
    </form>
</body>
</html>
