<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/MasterPage.Master" CodeBehind="Evento_Crear.aspx.vb" Inherits="fitfa.Evento_Crear" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script language="javascript" type="text/javascript">
// <![CDATA[

        function btn_Examinar_onclick() {

        }

// ]]>
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" 
        EnableScriptGlobalization="True">
  </asp:ScriptManager>
  <asp:UpdatePanel ID="upp" runat="server">
  <ContentTemplate>
  <div class="card card-primary">
  <div class="card-header">
                <h3 class="card-title">Nuevo Evento</h3>
  </div>
  <form role="form">
  <div class="card-body">
  

  <div class="container-fluid">
<div class="row">
  <div class="col-lg-6">

  <div class="card">
  <div class="card-body">
  <div class="form-group">
  <label>Tipo de Evento</label>
  <asp:DropDownList ID="combo_TipoEvento" runat="server" class="form-control" AutoPostBack="True" Font-Bold="True">
                      <asp:ListItem Value="Torneo" Selected="True">Torneo</asp:ListItem>
                      <asp:ListItem Value="Curso">Curso</asp:ListItem>
                      <asp:ListItem Value="Examen">Examen</asp:ListItem>
  </asp:DropDownList>
  </div>
  <div class="form-group">
  <label>Nombre </label>
  <label id="lbl_errNom" class="label label-danger" runat="server">Debe Completar El Campo</label>
  <input type="text" class="form-control" id="tb_nombre" runat="server" causesvalidation="False" required="" placeholder="Ingrese nombre..." maxlength="50"/>
  </div>
  <div class="form-group">
   <label>Dirección </label>
   <input type="text" class="form-control" id="tb_direccion" runat="server" causesvalidation="False" required="" placeholder="Ingrese dirección..." maxlength="50"/> 
  </div> 

  
  
   </div>
  </div>  

  <div class="card">
    <div class="card-body">
    <div class="form-group">
  <label>Fecha del Evento</label>
  <label id="lbl_errfechaini" class="label label-danger" runat="server">Debe Completar El Campo</label>
  <div class="input-group">
                    <div class="input-group-prepend">
                      <span class="input-group-text"><i class="fa fa-calendar"></i></span>
                    </div>
                    <input type="text" class="form-control" required="" runat="server" id="tb_fechainicio" data-inputmask="'alias': 'dd/mm/yyyy'" data-mask="">
  </div>
  </div>
  <div class="form-group">
  <label>Fecha de cierre de inscripción </label>
  <label id="lbl_errFecCier" class="label label-danger" runat="server">Debe Completar El Campo</label>
  <div class="input-group">
        <div class="input-group-prepend">
          <span class="input-group-text"><i class="fa fa-calendar"></i></span>
        </div>
        <input type="text" required="" class="form-control" runat="server" id="tb_fechaCierre" data-inputmask="'alias': 'dd/mm/yyyy'" data-mask="">
  </div>
  </div>
  <asp:CompareValidator ID="cmpEndDate" runat="server" 
                        ErrorMessage="La fecha de cierre no puede ser mayor a la del evento" class="label label-danger" 
                        ControlToCompare="tb_fechaCierre" ControlToValidate="tb_fechainicio" 
                        Operator="GreaterThanEqual" Type="Date">
  </asp:CompareValidator>
  <div class="bootstrap-timepicker">
      <div class="form-group">
                    <label>Hora Limite:</label>
                     <label id="lbl_horaCierre" class="label label-danger" runat="server">Debe Completar El Campo</label>
                    <div class="input-group">
                      <input type="text" class="form-control timepicker" required="" id="tb_horaCierre" runat="server">

                      <div class="input-group-append">
                        <span class="input-group-text"><i class="fa fa-clock-o"></i></span>
                      </div>
                    </div>
                    <!-- /.input group -->
      </div>
                  <!-- /.form group -->
  </div>
  <div id="cost_seccion" runat="server" class="form-group" visible=true>
  <label>Costo</label>
  <label id="lbl_costo" class="label label-danger"  runat="server">Debe Completar El Campo</label>
  <asp:TextBox ID="textbox_Costo" CssClass="form-control" runat="server"  onkeypress="return justNumbers(event);"></asp:TextBox>  
  <cc1:FilteredTextBoxExtender 
            ID="FilteredTextBoxExtender2" runat="server" TargetControlID="textbox_Costo"
      FilterType="Numbers" ValidChars="0123456789" >
        </cc1:FilteredTextBoxExtender>
  </div>
    

    </div> <%--fin del card-body--%>
    </div> <%--fin del card--%>



  </div>

    
  <div class="col-lg-6">
    <div class="card">
    <div class="card-body">
      <div class="form-group">
  <label>Foto del Evento</label>
      <br />
  <asp:Image ID="Image1" runat="server" Height="286px" ImageUrl="~/Eventos/imagen/logo_evento.jpg" Width="286px" BorderStyle="Solid" />
      <br />
      &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;<br />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
          &nbsp;
  <button type="button" class="btn btn-primary" runat="server" id="btn_Examinar" onclick="return btn_Examinar_onclick()">Examinar</button>
          &nbsp;
  <button type="button" class="btn btn-danger" id="btn_quitar" runat="server" visible="True">
      &nbsp; &nbsp;Quitar&nbsp;</button>
  </div>
          


  
  </div> <%--fin del card-body--%>
  </div> <%--fin del card--%>
        
 


  </div>  <%--fin del col-lg-6--%>
   

  

  <div class="col-lg-6">
  <asp:Panel ID="Panel_examenes" runat="server" Visible="false" >
  
  <div class="card">
  <div class="card-body">
    <div class="form-group">
        <label>Capacidad máxima de inscriptos por turno: 
        <label ID="lbl_error_cap_max_inscr" runat="server" class="label label-danger">
        Ingrese capacidad máxima.</label></label>
        <asp:TextBox ID="tb_capacidad_max" CssClass="form-control" 
            runat="server" onkeypress="return justNumbers(event);" 
            AutoPostBack="True"></asp:TextBox>
        &nbsp;<%--onkeypress="return justNumbers(event);"--%><cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="tb_capacidad_max"
      FilterType="Numbers" ValidChars="0123456789" >
        </cc1:FilteredTextBoxExtender>
        <label>Seleccione los turnos para el examen:
        </label>
        &nbsp;<label ID="lbl_turnos_error0" runat="server" class="label label-danger">Debe 
        seleccionar al menos un turno</label></div>
 <div class="card-body table-responsive p-0">
      <asp:GridView ID="GridView1" class="table table-hover" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" 
                           BorderColor="Black" GridLines="None" 
                          EnableSortingAndPagingCallbacks="True" PageSize="20">
          <Columns>
              <asp:TemplateField HeaderText="Item">
                  <ItemTemplate>
                      <asp:CheckBox ID="chk_turno" runat="server" />
                  </ItemTemplate>
                  <EditItemTemplate>
                      <asp:CheckBox ID="CheckBox1" runat="server" />
                  </EditItemTemplate>
              </asp:TemplateField>
              <asp:BoundField DataField="Turno" HeaderText="Turno" />
          </Columns>
      </asp:GridView>
  
  </div> 
 
  
  
  
  
  </div> <%--fin del card-body--%> 
  </div> <%--fin del card--%>
  </asp:Panel>
  </div> <%--fin del col-lg-6--%>

    

    
  
  
  </div>

  </div>

  </div>
  </form>
  
  </div>
  <div class="card-footer">
  
  <div class="form-group" > 
  <button type="button" class="btn btn-primary" data-toggle="modal" runat="server" id="BOTON_GRABAR" data-target="#div_guardar_08102021">Guardar</button>    
  </div>
  
  </div>
  </span>
  
  
  <div id= "div_modal_msjOK" runat="server">
  <asp:HiddenField ID="HiddenField_msj" runat="server" />
  <asp:Panel ID="Panel1" runat="server" >
              
                                        <div class="card card-success">
                                        <div class="card-header">
                                            <h3 class="card-title">Evento</h3>
                                        </div>
                                        <form role="form">
                                          <div class="card-body"> 
                                            <div class="row">
                                                <div align="center">
                                                    <asp:Label ID="Label1" runat="server" Text="Evento generado exitosamente."></asp:Label>
                                                    &nbsp;
                                                </div>
                                            </div>
                                          </div>
                                        </form>  
                                        <div align="center">
                                                <asp:Button ID="boton_ok" runat="server" Text="OK" CssClass="btn btn-success"  />
                                          </div> 
                                          <div>
                                             &nbsp;
                                          </div>             
                                        </div> 
  </asp:Panel>
      <cc1:ModalPopupExtender ID="Modal_msjOK" runat="server" TargetControlID="HiddenField_msj" PopupControlID="Panel1" CancelControlID="boton_ok" BackgroundCssClass="modalBackground">
      </cc1:ModalPopupExtender>
  </div>



<div class="modal fade" id="div_guardar_08102021" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true" data-backdrop="static" data-keyboard="false">
              <div class="modal-dialog modal-lg" role="document">
                <div class="modal-content">
                  <div class="modal-header">
                    <h5 class="modal-title" id="H2">¿Desea guardar?</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                      <span aria-hidden="true">&times;</span>
                    </button>
                  </div>
                                    
                  <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Cancelar</button>
                    <button type="button" class="btn btn-primary" id="Btn_modal_guardar" runat="server" data-dismiss="modal" rutitle="Your custom upload logic" >Aceptar</button>
                  </div>
                </div>
              </div>
            </div>



  </ContentTemplate>
      <Triggers>
          <asp:AsyncPostBackTrigger ControlID="boton_ok" EventName="Click" />
      </Triggers>
  </asp:UpdatePanel>
       <asp:UpdateProgress ID="UpdateProgress1" runat="server" 
            AssociatedUpdatePanelID="upp">
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
