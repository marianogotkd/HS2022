<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/MasterPage.Master" CodeBehind="Seleccion_Area.aspx.vb" Inherits="fitfa.Seleccion_Area" %>




<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
    .sidebar-mini
    {
        text-align: center;
    }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<asp:ScriptManager ID="ScriptManager1" runat="server" 
                        EnableScriptGlobalization="True">
            </asp:ScriptManager>

             <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
            
    
        <ContentTemplate>

        <div>
        <h1 class="m-0 text-dark">BIENVENIDO SELECCIONE EL AREA DE TRABAJO</h1>
            <p class="m-0 text-dark">
                &nbsp;</p>
        </div>
        
        <div>
         <asp:DropDownList ID="DropDownList1" runat="server" Font-Size="XX-Large">
                   </asp:DropDownList>
            <p>
             &nbsp;
            </p>
        </div>
        <div>
        
        </div>
        <div>
        <button type="button" class="btn btn-primary" id="btn_continuar" runat="server" 
                rutitle="Your custom upload logic" style="font-size: 25px" >Continuar</button>
        </div>
                  


                   





        
                   </ContentTemplate>

                          <Triggers>
                            
                        </Triggers>
       
       
</asp:UpdatePanel>



</asp:Content>
