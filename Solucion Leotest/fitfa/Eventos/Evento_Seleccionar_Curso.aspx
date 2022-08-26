<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/MasterPage.Master" CodeBehind="Evento_Seleccionar_Curso.aspx.vb" Inherits="fitfa.Evento_Seleccionar_Curso" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

<style type = "text/css">
        #Background
        {
                          
           position: fixed;
            top: 0px;
            bottom: 0px;
            left: 0px;
            right: 0px;
            overflow: hidden;
            padding: 0;
            margin: 0;
            background-color: Black ;
            filter: alpha(opacity=99);
            opacity: 0.6;
            z-index: 100000;
                     
            
        }
        #Progress
        {
            position: fixed;
            top: 40%;
            left: 40%;
            height: 10%;
            width: 10%;
            z-index: 100001;
            background-color: #FFFFFF;
            border: 1px solid Gray;
            background-repeat: no-repeat;
            background-position: center;
            
        }          
        
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>

    
    <div class="card card-primary">
                           
              <div class="card-header">
                <h3 class="card-title">CURSO DISPONIBLES</h3>
                  
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
            
    <div id="choco" runat="server">
    <asp:HiddenField ID="HiddenField_msj" runat="server" />
        <asp:Panel ID="Panel1" runat="server" >
              
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
    
    </div>
           
    </ContentTemplate>

    </asp:UpdatePanel>

        <asp:UpdateProgress ID="UpdateProgress1" runat="server" 
            AssociatedUpdatePanelID="UpdatePanel1">
        <ProgressTemplate>
       
         <div style="background-color: Gray; filter:alpha(opacity=60); opacity:0.60; width: 100%; top: 0px; left: 0px; position: relative ; height: 100%;"> </div>
          <div style="margin:auto;
              font-family:Trebuchet MS;
              filter: alpha(opacity=100);
              opacity: 1;
              font-size:small;
              vertical-align: middle;
              top: 40%;
              position: fixed;
              right: 40%;
              color: #275721;
              text-align: center;
              background-color: White;
              height: 100px;
              ">


              <div class="card card-danger">
              <div class="card-header">
                <h3 class="card-title">Procesando Solicitud</h3>
              </div>
              <div class="card-body">
                Aguarde un Momento Por Favor...
              </div>
              <!-- /.card-body -->
              <!-- Loading (remove the following to stop the loading)-->
              <div class="overlay">
                <i class="fa fa-refresh fa-spin"></i>
              </div>
              <!-- end loading -->
            </div>
                     

        </div>

        
        </ProgressTemplate>
        
        </asp:UpdateProgress>



</asp:Content>

