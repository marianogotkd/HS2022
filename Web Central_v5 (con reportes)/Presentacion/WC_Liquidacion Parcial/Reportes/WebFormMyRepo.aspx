<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Home.Master" CodeBehind="WebFormMyRepo.aspx.vb" Inherits="Presentacion.WebFormMyRepo" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
            
   </asp:ScriptManager>
 <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true" ReportSourceID="CrystalReportSource1" EnableDatabaseLogonPrompt="False" EnableParameterPrompt="False" />
            
            <CR:CrystalReportSource ID="CrystalReportSource1" runat="server" ViewStateMode="Enabled">
                <Report FileName="F:\048 WebCentral.root\Web Central_v5\Presentacion\WC_Liquidacion Parcial\Reportes\CR01.rpt">
                </Report>
               
                
            </CR:CrystalReportSource>
</asp:Content>
