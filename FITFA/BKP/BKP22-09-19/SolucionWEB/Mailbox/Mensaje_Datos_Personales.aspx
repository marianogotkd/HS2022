<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/MasterPage.Master" CodeBehind="Mensaje_Datos_Personales.aspx.vb" Inherits="fitfa.Mensaje_Datos_Personales" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

 <asp:ScriptManager ID="ScriptManager1" runat="server">
  </asp:ScriptManager>

   <asp:UpdatePanel ID="upp" runat="server">
        <ContentTemplate>
   

          <div class="card card-primary card-outline">
            <div class="card-header">
              <h3 class="card-title">Solicitud de Usuario</h3>

              <div class="card-tools">
                <a href="#" class="btn btn-tool" data-toggle="tooltip" title="Previous"><i class="fa fa-chevron-left"></i></a>
                <a href="#" class="btn btn-tool" data-toggle="tooltip" title="Next"><i class="fa fa-chevron-right"></i></a>
              </div>
            </div>
            <!-- /.card-header -->
            <div class="card-body p-0">
              <div class="mailbox-read-info">
              
               <%-- <h5><asp:Label ID="Lbl_nombre" runat="server" Text="Label"></asp:Label></h5>
                <h6><asp:Label ID="Lbl_inst" runat="server" Text="Label"></asp:Label>--%>
                  <span class="mailbox-read-time float-right">
              <asp:Label ID="lbl_fecha" runat="server" Text="Label"></asp:Label></span></h6>
              </div>
              <!-- /.mailbox-read-info -->
              <div class="mailbox-controls with-border text-center">
                <div class="btn-group">
                  <button type="button" id="BorrarArr" runat="server" class="btn btn-default btn-sm" data-toggle="tooltip" data-container="body" title="Borrar">
                    <i class="fa fa-trash-o"></i></button>
                  </div>
                   <button type="button" id="btn_Aceptar" class="btn btn-default btn-sm" runat="server"><strong>Aceptar Solicitud</strong></button>
                <!-- /.btn-group -->
                <button type="button" id="ImprimirArr" runat="server" class="btn btn-default btn-sm" data-toggle="tooltip" title="Imprimir">
                  <i class="fa fa-print"></i></button>
              </div>
              <!-- /.mailbox-controls -->
              <div class="widget-user-header bg-warning">
                <div class="widget-user-image">
                <%--  <img class="img-circle elevation-2" src="../../MasterPage/dist/img/user7-128x128.jpg" alt="User Avatar">--%>
                  <asp:Image ID="Image1" CssClass="img-circle elevation-2" runat="server" Height="128" Width="128" />
                </div>
                <!-- /.widget-user-image -->
               <h3><strong><asp:Label ID="Lbl_nombre" runat="server" Text="Label" CssClass="widget-user-username"></asp:Label></strong></h3>
               <h5><strong><asp:Label ID="lbl_Tipo" runat="server" Text="Label" CssClass="widget-user-desc"></asp:Label></strong></h5>
              </div>

              <div class="mailbox-read-message">

            <%--   <h5><strong><asp:Label ID="lbl_Tipo" runat="server" Text="Label"></asp:Label></strong></h5>--%> 

               <strong>DNI: <p><asp:Label ID="lbl_doc" runat="server" Text="Label"></asp:Label></p></strong>
                
               <strong>Nombre: <p><asp:Label ID="lbl_NomCuerpo" runat="server" Text="Label"></asp:Label></p></strong>

               <strong>Provincia: <p><asp:Label ID="lbl_Provincia" runat="server" Text="Label"></asp:Label></p></strong>

               <strong>Institucion: <p><asp:Label ID="lbl_Institucion" runat="server" Text="Label"></asp:Label> </p></strong>

               <strong>Direccion: <p><asp:Label ID="lbl_Direccion" runat="server" Text="Label"></asp:Label></p></strong>

               <strong>Sexo: <p><asp:Label ID="lbl_Sexo" runat="server" Text="Label"></asp:Label></p> </strong>
              </div>
              <div class="alert alert-success alert-dismissible" id="MsjeOK" runat="server">
                  <button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button>
                  <h5><i class="icon fa fa-check"></i> Usuario Aceptado</h5>
                  El Usuario Fue Registrado Con Exito
                </div>

              <!-- /.mailbox-read-message -->
            </div>
            <!-- /.card-body -->
            <div class="card-footer bg-white">
              
            </div>
            <!-- /.card-footer -->
            <div class="card-footer">
              <button type="button" id="borrarAb" runat="server" class="btn btn-default"><i class="fa fa-trash-o"></i> Borrar</button>
              <button type="button" id="imprimirab" runat="server" class="btn btn-default"><i class="fa fa-print"></i> Imprimir</button>
              <button type="button" id="btn_aceptarAb" class="btn btn-default" runat="server"><strong>Aceptar Solicitud</strong></button>
                
            </div>
            <!-- /.card-footer -->
          </div>
      
          </ContentTemplate>
         </asp:UpdatePanel>



</asp:Content>
