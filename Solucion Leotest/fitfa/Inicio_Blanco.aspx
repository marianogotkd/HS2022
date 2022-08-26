<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/MasterPage.Master" CodeBehind="Inicio_Blanco.aspx.vb" Inherits="fitfa.Inicio_Blanco" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">



</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div class="col-md-3 col-sm-6 col-12" runat="server" id="div_area" visible="false">
            <div class="info-box bg-info">
              <span class="info-box-icon"><i class="fa fa-bookmark-o"></i></span>
                           
                <asp:Label ID="Lbl_Nomarea" runat="server" Text="Label" Font-Size="X-Large"></asp:Label>
            </div>
            <!-- /.info-box -->
          </div>


    <div>
    <div class="row" align="center">
        
                <div class="col-sm-8">
                    
                    <asp:Image ID="Image1" runat="server" Height="341px" 
        ImageUrl="~/img/ITF-Choi-Jung-Hwa.jpg" Width="506px" ImageAlign="Middle" />
                           
                        
                </div>
                
    
    
    


    </div>
    </div>
</asp:Content>
