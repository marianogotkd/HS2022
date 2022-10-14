<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/MasterPage.Master" CodeBehind="mailbox.aspx.vb" Inherits="fitfa.mailbox" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<head>
<title>MailBox</title>

 <script type="text/javascript">
$(document).ready(function() {
$("tr").filter(function() {
return $('td', this).length && !$('table', this).length
}).css({ background: "ffffff" }).hover(
function() { $(this).css({ background: "#C1DAD7" }); },
function() { $(this).css({ background: "#ffffff" }); }
);
});
</script>

</head>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 

    <asp:ScriptManager ID="ScriptManager1" runat="server">
  </asp:ScriptManager>

   <asp:UpdatePanel ID="upp" runat="server">
        <ContentTemplate>

 <div class="card card-primary card-outline">
            <div class="card-header">
              <h3 class="card-title">Mensajes</h3>

              <div class="card-tools">
                <div class="input-group input-group-sm">
                  <input type="text" class="form-control" placeholder="Buscar Mensaje">
                  <div class="input-group-append">
                    <div class="btn btn-primary">
                      <i class="fa fa-search"></i>
                    </div>
                  </div>
                </div>
              </div>
              <!-- /.card-tools -->
            </div>
            <!-- /.card-header -->
            <div class="card-body p-0">
              <div class="mailbox-controls">
                <!-- Check all button -->
                <button type="button" id="chkallArriba" runat="server" class="btn btn-default btn-sm checkbox-toggle"><i class="fa fa-square-o"></i>
                </button>
                <button type="button" id="Chkokarriba" runat="server" class="btn btn-default btn-sm checkbox-toggle"><i class="fa fa-check-square-o"></i>
                </button>
                  <button type="button" id="BorrarArr" runat="server" class="btn btn-default btn-sm" data-toggle="tooltip" data-container="body" title="Borrar">
                    <i class="fa fa-trash-o"></i></button>
                <div class="btn-group">
                  <button type="button" id="AceptarArr" class="btn btn-default btn-sm" runat="server"><strong>Aceptar Solicitud</strong></button>
                
                </div>
                <!-- /.btn-group -->
                <button type="button" class="btn btn-default btn-sm" runat="server" id="actulizarArr"><i class="fa fa-refresh"></i></button>
                <div class="float-right">
                  1-50/200
                    <div class="btn-group">
                    <button type="button" class="btn btn-default btn-sm"><i class="fa fa-chevron-left"></i></button>
                    <button type="button" class="btn btn-default btn-sm"><i class="fa fa-chevron-right"></i></button>
                  </div>
                  <!-- /.btn-group -->
                </div>
                <!-- /.float-right -->
              </div>
              <div class="table-responsive mailbox-messages">

     <asp:GridView ID="GridView1" PageSize="99"  runat="server" 
                      CssClass="table table-hover table-striped table-borderless ">  
         <Columns>
             <asp:TemplateField >
                                      
                    <ItemTemplate>
                        <asp:CheckBox ID="CheckBox1" runat="server" />
                    </ItemTemplate>
             </asp:TemplateField>
             <asp:TemplateField>
                 <ItemTemplate>
                     <asp:ImageButton ID="ImageButton1" runat="server" Height="20px" 
                         ImageUrl="~/img/lupa.png" Width="18px"  CommandName='ID' CommandArgument='<%# Eval("usuario_id") %>' ToolTip="Detalle"/>
                        
                 </ItemTemplate>
             </asp:TemplateField>
         </Columns>
         
                                    
                  </asp:GridView>

               
                      <div class="alert alert-info" runat="server" id="div">
  <strong>No Hay Mensajes Nuevos!</strong> </div>

                <!-- /.table -->
              </div>
              <!-- /.mail-box-messages -->
            </div>
            <!-- /.card-body -->
            <div class="card-footer p-0">
              <div class="mailbox-controls">
                <!-- Check all button -->
                <button type="submit" id="Chkallabajo" class="btn btn-default btn-sm checkbox-toggle" runat="server"><i class="fa fa-square-o"></i>
                </button>
                 <button type="button" id="chkokabajo" runat="server" class="btn btn-default btn-sm checkbox-toggle"><i class="fa fa-check-square-o"></i>
                </button>
                 <button id="BorrarAb" type="button" runat="server" class="btn btn-default btn-sm" data-toggle="tooltip" data-container="body" title="Borrar">
                    <i class="fa fa-trash-o"></i></button>             
                <div class="btn-group">
                 <button type="button" id="AceptarAb" class="btn btn-default btn-sm" runat="server" ><strong>Aceptar Solicitud</strong></button>
                </div>
                <!-- /.btn-group -->
                <button type="button" class="btn btn-default btn-sm" runat="server" id="actulizarab"><i class="fa fa-refresh"></i></button>
                <div class="float-right">
                  1-50/200
                  <div class="btn-group">
                    <button type="button" class="btn btn-default btn-sm"><i class="fa fa-chevron-left"></i></button>
                    <button type="button" class="btn btn-default btn-sm"><i class="fa fa-chevron-right"></i></button>
                  </div>
                  <!-- /.btn-group -->
                </div>
                <!-- /.float-right -->
              </div>
            </div>
          </div>

   
         



               </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="AceptarAb" EventName="ServerClick" />
            <asp:AsyncPostBackTrigger ControlID="AceptarArr" EventName="ServerClick" />
            <asp:AsyncPostBackTrigger ControlID="Chkallabajo" EventName="ServerClick" />
            <asp:AsyncPostBackTrigger ControlID="chkallArriba" EventName="ServerClick" />
            <asp:AsyncPostBackTrigger ControlID="chkokabajo" EventName="ServerClick" />
            <asp:AsyncPostBackTrigger ControlID="Chkokarriba" EventName="ServerClick" />
            <asp:AsyncPostBackTrigger ControlID="GridView1" EventName="RowCommand" />
        </Triggers>
      </asp:UpdatePanel>


</asp:Content>

