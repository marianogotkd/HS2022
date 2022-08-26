<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/MasterPage.Master" CodeBehind="inscripcion_persona.aspx.vb" Inherits="fitfa.inscripcion_persona" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        #Evento
    {
        text-align: center;
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
                <h3 class="card-title">Impresión De Comprobantes     </h3>
                  
              </div>
              </div>

       <div id="msje_Error" visible="false" runat="server">
         <div class="card card-danger">    
              <div class="card-header">
                <h3 class="card-title">Lo sentimos no te encuentras inscripto en ningún evento   </h3>
       
       </div>
       </div>
       </div>

                 
        <div id="Evento" runat="server">
        
            <asp:Label ID="lbl_selec" runat="server" Text="Seleccionar Evento" Font-Bold="true"></asp:Label>
            &nbsp;
            <asp:DropDownList ID="DropDownList_eventos" runat="server" Height="19px" 
                Width="301px" AutoPostBack="True">
            </asp:DropDownList>
        
        </div>
        <div>
         <p>&nbsp;</p>        
        </div>
       
        <div id="imprimir" runat="server">
     
      <div align="center" style="background-color: #C0C0C0">
              <asp:Label ID="lbl_torneo" runat="server" Text="DATOS PERSONALES" Font-Bold="True"></asp:Label>      
              </div>
       
        <div align="center">
             <div class="row" >

                <div class="col-sm-3">
                        <asp:Image ID="Image1" runat="server" Height="141px" Width="140px" 
                            ImageAlign="Middle" />
      
                </div>

                <div class="col-sm-3">
  
                      <table class="w-100" align="center">
            <tr>
                <td bgcolor="Black">
                   
    <div class="col" align="center" style="color: #FFFFFF">Datos Personales</div></td>
            </tr>
            <tr>
                <td>
                    <div class="col">
                    DNI:
                    <asp:Label ID="lbl_dni" runat="server" Font-Bold="True" Text="Label"></asp:Label>
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                     <div class="col">Nombre: <asp:Label ID="lbl_Nombre" runat="server" Text="Label" 
              Font-Bold="True"></asp:Label>
          <br />
      </div></td>
            </tr>
            <tr>
                <td>
                     <div class="col">Graduacion: <asp:Label ID="lbl_grad" runat="server" Text="Label" 
                 Font-Bold="True"></asp:Label>
             <br />
      </div>
      </td>
            </tr>
            <tr>
                <td>
                   <div class="col">Peso: <asp:Label ID="lbl_peso" runat="server" Text="Label" 
                Font-Bold="True"></asp:Label>
            <br />
      </div>
      </td>
            </tr>
        </table>
                        <br />
                </div>
                <div class="col-sm-3">

                      <table class="w-100" align="center">
          <tr>
              <td align="center" bgcolor="Black" style="color: #FFFFFF">
                  Categorias</td>
          </tr>
          <tr>
              <td>
                  <asp:CheckBox ID="chk_forma" runat="server" Text="Forma" Enabled="False" />
              </td>
          </tr>
          <tr>
              <td>
                  <asp:CheckBox ID="chk_lucha" runat="server" Text="Lucha" Enabled="False" />
              </td>
          </tr>
          <tr>
              <td>
                  <asp:CheckBox ID="chk_RHab" runat="server" Text="Rotura Habilidad" 
                      Enabled="False" />
              </td>
          </tr>
          <tr>
              <td>
                  <asp:CheckBox ID="chk_Rpoder" runat="server" Text="Rotura Poder" 
                      Enabled="False" />
              </td>
          </tr>
      </table>
                </div>
            </div> 
       </div>


        
       
      <div align="center" style="background-color: #C0C0C0">
            ----   
       </div>

        </div>
     

       


       
       
        </ContentTemplate>
    
    
    
    
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="DropDownList_eventos" 
                EventName="SelectedIndexChanged" />
        </Triggers>
    
    
    
    
    </asp:UpdatePanel>


 

    <script src="../../MasterPage/plugins/jspdf/jspdf.min.js" type="text/javascript"></script>
    <script src="../../MasterPage/plugins/html2canvas/html2canvas.js" type="text/javascript"></script>
      <script>
          function DescargarPDF(ContenidoID, nombre) {
              var pdf = new jsPDF('p', 'pt', 'letter');
              html = $('#' + ContenidoID).html();
              specialElementHandlers = {};
              margins = { top: 10, bottom: 20, left: 20, width: 522 };
              pdf.fromHTML(html, margins.left, margins.top, { 'width': margins.width }, function (dispose) { pdf.save(nombre + '.pdf'); }, margins);
          }
    </script>

   <script type="text/javascript">
       function genPDF() {
           html2canvas(document.body, {
               onrendered: function (canvas) {
                   var img = canvas.toDataURL("imagen/png");
                   var doc = new jsPDF();
                   doc.addImage(img, 'JPEG', 20, 20);
                   doc.save('test.pdf');
               }
           });
       }

   
   
   </script>
   
</asp:Content>

 