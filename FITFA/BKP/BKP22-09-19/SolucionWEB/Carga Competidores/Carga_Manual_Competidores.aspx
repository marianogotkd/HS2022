<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/MasterPage.Master" CodeBehind="Carga_Manual_Competidores.aspx.vb" Inherits="fitfa.Carga_Manual_Competidores" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
        
            <asp:Label ID="Label1" runat="server" Text="Seleccionar Evento"></asp:Label>
        
        
        
        
            &nbsp; <asp:DropDownList ID="DropDownList_eventos" runat="server">
            </asp:DropDownList>
        
        
        
        
            <br />
            <br />
            <asp:Label ID="Label2" runat="server" Text="Sexo"></asp:Label>
            &nbsp;<asp:DropDownList ID="DropDownList_Sexo" runat="server" 
                AutoPostBack="True">
                <asp:ListItem Selected="True">Hombre</asp:ListItem>
                <asp:ListItem>Mujer</asp:ListItem>
                <asp:ListItem Value="AMBOS SEXOS">AMBOS </asp:ListItem>
            </asp:DropDownList>
            &nbsp;<asp:Label ID="Label3" runat="server" Text="Modalidad"></asp:Label>
            &nbsp;<asp:DropDownList ID="Drop_modalida" runat="server" AutoPostBack="True">
                <asp:ListItem Selected="True">Lucha</asp:ListItem>
                <asp:ListItem>Forma</asp:ListItem>
            </asp:DropDownList>
            &nbsp;<asp:Label ID="Label4" runat="server" Text="Categoria"></asp:Label>
            &nbsp;<asp:DropDownList ID="DropDownList4" runat="server" Width="513px">
            </asp:DropDownList>
        
        
        
        
            <br />
            <br />
            &nbsp;<asp:Label ID="Label5" runat="server" Text="Nombre:"></asp:Label>
            &nbsp;<asp:TextBox ID="tb_nombre" runat="server" Height="22px" Width="135px"></asp:TextBox>
            &nbsp;
            <asp:Label ID="lbl_ape" runat="server" Text="Apellido:"></asp:Label>
            &nbsp;<asp:TextBox ID="tb_apellido" runat="server" Height="22px" Width="135px"></asp:TextBox>
            &nbsp;<asp:Button ID="Btn_Agregar" runat="server" Text="Agregar" />
            &nbsp;<asp:Button ID="Btn_Agregar0" runat="server" Text="Quitar Ultimo" />
            <br />
            <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" 
                GridLines="None">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <EditRowStyle BackColor="#999999" />
                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#E9E7E2" />
                <SortedAscendingHeaderStyle BackColor="#506C8C" />
                <SortedDescendingCellStyle BackColor="#FFFDF8" />
                <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
            </asp:GridView>
            <br />
            <asp:Button ID="btn_guardar" runat="server" Text="Guardar LLave" />
        
        






  <div id="popupMsjGuardado" runat="server"> 
        <asp:HiddenField ID="HiddenField_msj_guardado" runat="server"/>
      <asp:Panel ID="Panel_guardado" runat="server" CssClass="panel panel-primary">
      <div class="card card-success">
            <div class="card-header">
                <h3 class="card-title">Inscripciones</h3>
            </div>
            <form role="form">
              <div class="card-body"> 
                <div class="row">
                    <div align="center">
                        <asp:Label ID="Label8" runat="server" Text="Inscripción registrada!"></asp:Label>
                        &nbsp;
                    </div>
                </div>
              </div>
            </form>  
            <div align="center">
                    <asp:Button ID="Btb_ok_inscripcion" runat="server" Text="OK" CssClass="btn btn-success"  />
              </div> 
              <div>
                 &nbsp;
              </div>             
            </div> 
      </asp:Panel>
        
      <asp:ModalPopupExtender ID="ModalPopupExtender_guardado" runat="server" TargetControlID="HiddenField_msj_guardado" 
            PopupControlID="Panel_guardado" BackgroundCssClass="modalBackground" Drag="true">
      </asp:ModalPopupExtender>
        
        
        
        
        

      
    </div>



        
        
        </ContentTemplate>
        </asp:UpdatePanel>
        


</asp:Content>
