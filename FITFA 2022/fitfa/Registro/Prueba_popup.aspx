<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/MasterPage.Master" CodeBehind="Prueba_popup.aspx.vb" Inherits="fitfa.Prueba_popup" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
    <center>
    
        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        </asp:ToolkitScriptManager>
        <asp:Panel ID="Panel1" runat="server">
        
        
        </asp:Panel>
        <asp:ModalPopupExtender ID="ModalPopupExtender1" runat="server">
        </asp:ModalPopupExtender>
    </center>
    
    
    </div>
</asp:Content>
