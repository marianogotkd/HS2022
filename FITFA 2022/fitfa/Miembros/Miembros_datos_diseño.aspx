<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/MasterPage.Master" CodeBehind="Miembros_datos_diseño.aspx.vb" Inherits="fitfa.Miembros_datos_diseño" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<asp:Panel ID="Panel_datospersonales" runat="server" CssClass="modalpopup">
              <div class="card card-primary">
                           
                      <div class="card-header">
                        <h3 class="card-title">Datos Personales</h3>
                  
                      </div>
              <!-- /.card-header -->
              <!-- form start -->
                      <div class="widget-user-header bg-warning">
                <div class="widget-user-image">
                <%--  <img class="img-circle elevation-2" src="../../MasterPage/dist/img/user7-128x128.jpg" alt="User Avatar">--%>
                  <asp:Image ID="Image1" CssClass="img-circle elevation-2" runat="server" Height="128" Width="128" />
                </div>
                <!-- /.widget-user-image -->
               <h3><strong><asp:Label ID="Lbl_nombre" runat="server" Text="Label" CssClass="widget-user-username"></asp:Label></strong></h3>
               <h5><strong><asp:Label ID="lbl_Tipo" runat="server" Text="Label" CssClass="widget-user-desc"></asp:Label></strong></h5>
              </div>
                    

                      <form role="form">
                        <div class="card-body"> 
                             <div class="form-group">
                                  <asp:Label ID="Label1" runat="server" Text="Documento:"> </asp:Label>&nbsp;<asp:Label
                                  ID="Lb_dni" runat="server" Text=""></asp:Label>
                             </div> 
                             <div class="form-group">
                                 <asp:Label ID="Label2" runat="server" Text="Apellido y Nombre:"></asp:Label>&nbsp;<asp:Label
                                  ID="Lb_apenomb" runat="server" Text=""></asp:Label>
                             </div> 
                                   
              
                            <div class="card-footer">
                                <button type="submit" class="btn btn-primary" runat="server" id="btn_guardar">Cerrar</button>
                            </div>
                        </div>                                      
                
                     </form>
            </div>
            
            
            
            
            
            
            
        
        </asp:Panel>
</asp:Content>
