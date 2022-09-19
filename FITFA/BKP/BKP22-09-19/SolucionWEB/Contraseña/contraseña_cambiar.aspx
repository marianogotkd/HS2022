<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/MasterPage.Master" CodeBehind="contraseña_cambiar.aspx.vb" Inherits="fitfa.contraseña_cambiar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" 
        EnableScriptGlobalization="True">
  </asp:ScriptManager>



<asp:UpdatePanel ID="UpdatePanel1" runat="server">
   <ContentTemplate>                
                  
                  <div class="card card-primary">
                           
              <div class="card-header">
                <h3 class="card-title">Cambio de contraseña</h3>
                  
              </div>
              <!-- /.card-header -->
              <!-- form start -->
              <form role="form">
                <div class="card-body">
                  
                  <div class="form-group">
                      <asp:TextBox ID="txt_contraseña_actual" class="form-control" runat="server" TextMode="Password" placeholder="Contraseña actual..." ></asp:TextBox>
                  </div>
                  
                  <div class="form-group" id="div_pass_actual_error" runat="server" visible="false" >
                                <asp:Label ID="label_error_pass_actual" runat="server" Text="error!" ForeColor="#FF3300"></asp:Label>

                  </div>


                  <div class="form-group">
                      <asp:TextBox ID="txt_contraseñanueva1" class="form-control" runat="server" TextMode="Password" required="" placeholder="Contraseña nueva..."></asp:TextBox>
                  </div>

                  <div class="form-group" id="div_contraseña1_error" runat="server" visible="false">
                            <asp:Label ID="label_contraseña1_error_" runat="server" Text="error!" ForeColor="#FF3300"></asp:Label>
                  </div>

                  <div class="form-group">
                      <asp:TextBox ID="txt_contraseñanueva2" class="form-control" runat="server" TextMode="Password" required="" placeholder="Repita contraseña..."></asp:TextBox>
                  </div>

                  <div class="form-group" id="div_contraseña2_error" runat="server" visible="false">
                            <asp:Label ID="label_contraseña2_error" runat="server" Text="error!" ForeColor="#FF3300"></asp:Label>
                  </div>
              
              <div class="card-footer">
                  <button type="submit" class="btn btn-primary" runat="server" id="btn_guardar">Guarda Cambios</button>
                </div>
                             


                <div id="div_registro_guardado" runat="server" visible="false" 
                style="color: #00CC00; font-style: normal; font-variant: normal;">
                    Datos actualizados!
                </div>
                
                    </form>
            </div>
                  

   </ContentTemplate>
</asp:UpdatePanel>





</asp:Content>
