<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/MasterPage.Master" CodeBehind="Evento_seleccionar_prueba.aspx.vb" Inherits="fitfa.Evento_seleccionar_prueba" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     
    

    <div class="card card-primary">
                           
              <div class="card-header">
                <h3 class="card-title">Eventos disponibles</h3>
                  
              </div>

              <form role="form">
              <div class="card-body"> 
              <div class="row">
                <div class="col-sm-4" align="center"></div>
                <div class="col-sm-4" align="center">
                    
                    <div class="form-group">
                    <asp:DropDownList ID="DropDownList_eventos" runat="server">
                    </asp:DropDownList>
                    </div>
                    <div class="form-group">
                    <button type="submit" class="btn btn-primary" runat="server" id="Btn_siguiente">Siguiente</button>
                    </div>
    
                </div>
                <div class="col-sm-4" align="center"></div>
                </div>
              </div>
              </form>

              <div class="card-footer">
                  <asp:Label ID="Label1" runat="server" Text="Seleccione el evento en el que desea participar"></asp:Label>
              </div>

    </div>
        
    


    <asp:HiddenField ID="HiddenField_msj" runat="server" />
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
        <asp:Panel ID="Panel1" runat="server">
            <div class="card card-primary">
            <div class="card-header">
                <h3 class="card-title">Advertencia</h3>
            </div>
            <form role="form">
              <div class="card-body"> 
              <div class="row">
              <div align="center">
                    <asp:Label ID="Label12" runat="server" Text="No hay eventos disponibles!"></asp:Label>
                    &nbsp;
              </div>
              <div align="center">
                    <asp:Button ID="Btb_msj_no_eventos" runat="server" Text="OK" />
              </div>  
              </div>
              </div>
            </form>
               
            </div>        
        
        </asp:Panel>

    <asp:ModalPopupExtender ID="ModalPopupExtender1" runat="server" TargetControlID="HiddenField_msj" PopupControlID="Panel1" CancelControlID="Btb_msj_no_eventos" BackgroundCssClass="modalBackground">
    </asp:ModalPopupExtender>


</asp:Content>
