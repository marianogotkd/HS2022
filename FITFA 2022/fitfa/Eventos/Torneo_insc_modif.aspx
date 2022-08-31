<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/MasterPage.Master" CodeBehind="Torneo_insc_modif.aspx.vb" Inherits="fitfa.Torneo_insc_modif" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>
<div class="card card-primary">
<div class="card-header">
      <h3 class="card-title">MODIFICAR INSCRIPCION DEL ALUMNO</h3>
                  
</div>
<form role="form">
<div class="card-body">
<div class="container-fluid">
<div class="row justify-content-center">
<div class="col-lg-12">
<div class="card">
    <div class="card-body">
            <div class="form-group">
                <asp:HiddenField ID="HF_evento_id" runat="server" />
                <asp:HiddenField ID="HF_inscripcion_id" runat="server" />
                <asp:HiddenField ID="HF_categoria_id" runat="server" />
                <asp:HiddenField ID="HF_categoria_tipo" runat="server" />
                <asp:HiddenField ID="HF_categoria_sexo" runat="server" />
                <asp:HiddenField ID="HF_graduacion_inicial" runat="server" />
                <asp:HiddenField ID="HF_graduacion_final" runat="server" />
                <asp:Label ID="Label_alumno" runat="server" Text="Alumno:"></asp:Label>
            
            </div>
            <div class="form-group">
                <asp:Label ID="Label_dni" runat="server" Text="DNI:"></asp:Label>
            </div>

            <div class="form-group">
                <asp:Label ID="Label_Instructor" runat="server" Text="Instructor:"></asp:Label>
            </div>

            <div class="form-group">
                <asp:Label ID="Label_inscripcion" runat="server" Text="Inscripto en:"></asp:Label>
            </div>
            <div class="form-group">
                <asp:Label ID="Label1" runat="server" Text="A continuación puede modificar la información:"></asp:Label>
            </div>
            <div class="form-group">
                <div class="row justify-content-start">
                    
                    <div class="col-md-2">
                            <label for="Label_edad">Rango Edad:</label>
                            <asp:DropDownList ID="DropDownList_edad" runat="server" class="form-control" AutoPostBack="True"></asp:DropDownList>
                    </div>

                    <div class="col-md-2">
                            <label for="Label_modalidad">Rango Peso:</label>
                            <asp:DropDownList ID="DropDownList_peso" runat="server" class="form-control"></asp:DropDownList>
                    </div>
                </div>
            </div>

            <div class="form-group">
            <button type="button" Class="btn btn-primary" id = "BOTON_GUARDAR" runat="server">GUARDAR CAMBIOS</button>
            </div>
            
    </div>
</div>
</div>
</div>
</div>
</div>
</form>
</div>

<div id="div_Modal_msj_error" runat="server">
                <asp:HiddenField ID="HiddenField_Err" runat="server" />
                <asp:Panel ID="Panel_Modal_Err" runat="server" >
     
                    <div class="card card-danger">
            <div class="card-header">
                <h3 class="card-title">Error Inscripción</h3>
            </div>
            <form role="form">
              <div class="card-body"> 
                <div class="row">
                    <div align="right">
                        
                    <asp:Label ID="Label3" runat="server" Text="No hay competidores en la categoría seleccionada. Elija otra." Font-Size="Small"></asp:Label>
                    </div>
                </div>
              </div>
            </form>  
            <div align="center">
                    <asp:Button ID="Btn_Modal_error_ok" runat="server" Text="Ok" CssClass="btn btn-danger"  />
                    <%--<asp:Button ID="Btn_Modal_no" runat="server" Text="No" CssClass="btn btn-danger"  />--%>
              </div>
                          
              <div>
                 &nbsp;
              </div>             
            </div>
                    <%--<asp:ModalPopupExtender ID="Modal_eliminar_inscripto" runat="server" TargetControlID="HiddenField_Err" PopupControlID="Panel_Modal_Err" CancelControlID="Btn_Modal_no" BackgroundCssClass="modalBackground">
                    </asp:ModalPopupExtender>--%>
                    
                    <asp:ModalPopupExtender ID="Modal_error_inscripto" runat="server" TargetControlID="HiddenField_Err" PopupControlID="Panel_Modal_Err" CancelControlID="Btn_Modal_error_ok" BackgroundCssClass="modalBackground">
                    </asp:ModalPopupExtender>

                 </asp:Panel>

</div>



</ContentTemplate>
</asp:UpdatePanel>
</asp:Content>
