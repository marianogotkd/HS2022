<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/MasterPage.Master" CodeBehind="Llave_detalle_evento.aspx.vb" Inherits="fitfa.Llave_detalle_evento" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<style type="text/css">
        .modalBackground
        {
            background-color:black;
            filter:alpha(opacity=99) !important;
            opacity:0.6 ! important;
            z-index:20;
            }
    .style83
    {
        width: 113px;
        height: 94px;
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
                <h3 class="card-title">Generación de llaves - Evento:<asp:Label ID="Lb_evento" runat="server" Text="XXX - TITULO EVENTO"></asp:Label>      </h3>
                  <asp:HiddenField ID="HF_evento_id" runat="server" />
              </div>
              <form role="form">
              <div class="card-body"> 
                    
              <div align="center" style="background-color: #C0C0C0">
              <asp:Label ID="Label15" runat="server" Text="Datos del Torneo" Font-Bold="True"></asp:Label>      
              </div>
              
              <div align="left">
                    <asp:Label ID="Fechadelevento" runat="server" Text="Fecha del evento:" Font-Bold="True"></asp:Label>
                    <asp:Label ID="Lb_fecha" runat="server" Text="00/00/0000"></asp:Label>
              </div>  
              
              <div align="left">
                    <asp:Label ID="Fechadecierre" runat="server" Text="Fecha de cierre de inscripción" 
                        Font-Bold="True"></asp:Label>
                    <asp:Label ID="Lb_fecha_cierre" runat="server" Text="00/00/0000"></asp:Label>
              </div>  
              
              <div align="center" style="background-color: #C0C0C0">
              <asp:Label ID="Label2" runat="server" Text="Inscripciones en categorías" Font-Bold="True"></asp:Label>      
              </div>

              <div align="left">
                    <div class="row">
                          <div class="col-sm-3" 
                              
                              style="background-position: center center; background-repeat: no-repeat; background-attachment: scroll;"></div>
                          <div class="col-sm-6">
                                <asp:GridView ID="GridView1" runat="server" class="table table-hover" 
                                    AllowSorting="True" AutoGenerateColumns="False" 
                           BorderColor="Black" GridLines="None" 
                          EnableSortingAndPagingCallbacks="True" PageSize="20" Font-Size="Small">
                            <Columns>
                                <asp:BoundField DataField="id" HeaderText="ID" >                                                               
                                <HeaderStyle ForeColor="#0099FF" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Categoria" HeaderText="Categoria" >
                                <HeaderStyle ForeColor="#0099FF" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Inscriptos" HeaderText="Inscriptos" >
                                <HeaderStyle ForeColor="#0099FF" />
                               </asp:BoundField>
                                <asp:BoundField DataField="Estado" HeaderText="Estado" >
                                <HeaderStyle ForeColor="#0099FF" />
                                </asp:BoundField>
                              <asp:TemplateField ShowHeader="False">
                                  <ItemTemplate>
                                      <asp:ImageButton ID="ImageButton1" runat="server" CausesValidation="false" 
                                          CommandName='ID' ImageUrl="~/img/lupa.png" 
                                          CommandArgument='<%# Eval("ID") %>' Text="" ToolTip="Generar llave" 
                                          ImageAlign="AbsMiddle" onclick="ImageButton1_Click" Height="128px" 
                                          Width="128px" />
                                  </ItemTemplate>
                                  <ControlStyle Height="20px" Width="20px" />
                                  <HeaderStyle ForeColor="#0099FF" />
                                  <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                              </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:ImageButton ID="ImageButton2" runat="server" Height="47px" 
                                            ImageUrl="~/img/26492775-boxing-gloves-hit-red-and-blue.jpg" Width="50px" CausesValidation="false" 
                                          CommandName="Id_categoria" CommandArgument='<%# Eval("ID") %>' ToolTip="Ver llave"/>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                        
                          </div>
                          <div class="col-sm-3" 
                              style="background-repeat: no-repeat; background-attachment: scroll; background-position: center center; background-image: url('../img/fight_small.medium.jpg');"></div>
                    </div>
                    
                    
                    
              </div>
              
              </div>
              </form>

    </div>
        
    
    
  





  <div id="div_Modal_err" runat="server">
    <asp:HiddenField ID="HiddenField_Err" runat="server" />
     <asp:Panel ID="Panel_Modal_Err" runat="server" >
     
      <div class="card card-danger">
            <div class="card-header">
                <h3 class="card-title">Advertencia</h3>
            </div>
            <form role="form">
              <div class="card-body"> 
                <div class="row">
                    <div align="center">
                        <asp:Label ID="lbl_Modal_err" runat="server" Text="Debe generar la llave."></asp:Label>
                        &nbsp;
                    </div>
                </div>
              </div>
            </form>  
            <div align="center">
                    <asp:Button ID="Btn_Modal_err" runat="server" Text="OK" CssClass="btn btn-danger"  />
              </div> 
              <div>
                 &nbsp;
              </div>             
            </div> 

         <asp:ModalPopupExtender ID="Modal_error" runat="server" TargetControlID="HiddenField_Err" PopupControlID="Panel_Modal_Err" CancelControlID="Btn_Modal_err" BackgroundCssClass="modalBackground">
</asp:ModalPopupExtender>
     </asp:Panel>
    </div>



<div id="div_Modal_error_generacion" runat="server">
                <asp:HiddenField ID="HiddenField1" runat="server" />
                <asp:Panel ID="Panel1" runat="server" >
     
                    <div class="card card-danger">
            <div class="card-header">
                <h3 class="card-title">Advertencia</h3>
            </div>
            <form role="form">
              <div class="card-body"> 
                <div class="row">
                    <div align="right">
                        <asp:Label ID="Label1" runat="server" Text="Ya se generó la llave para dicha categoría." Font-Size="Small"></asp:Label>
                        <br />
                    <asp:Label ID="Label3" runat="server" Text="¿Desea deshace y generar una nueva?" Font-Size="Small"></asp:Label>
                    </div>
                </div>
              </div>
            </form>  
            <div align="center">
                    <asp:Button ID="Btn_Modal_si" runat="server" Text="Si" CssClass="btn btn-danger"  />
                    <asp:Button ID="Btn_Modal_no" runat="server" Text="No" CssClass="btn btn-danger"  />
              </div>
                          
              <div>
                 &nbsp;
              </div>             
            </div>
                    <asp:ModalPopupExtender ID="Modal_error_inscripto" runat="server" TargetControlID="HiddenField_Err" PopupControlID="Panel_Modal_Err" CancelControlID="Btn_Modal_no" BackgroundCssClass="modalBackground">
                    </asp:ModalPopupExtender>
             
                 </asp:Panel>

</div>





</ContentTemplate>
</asp:UpdatePanel>


        <asp:UpdateProgress ID="UpdateProgress1" runat="server" 
            AssociatedUpdatePanelID="UpdatePanel1">
        <ProgressTemplate>
       
         <div style="background-color: Gray; filter:alpha(opacity=60); opacity:0.60; width: 100%; top: 0px; left: 0px; position: fixed; height: 100%;"> </div>
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
