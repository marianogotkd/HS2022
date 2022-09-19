<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/MasterPage.Master" CodeBehind="Modificar_Evento.aspx.vb" Inherits="fitfa.Modificar_Evento" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
 
 
 



</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">





<asp:ScriptManager ID="ScriptManager1" runat="server" 
        EnableScriptGlobalization="True">
  </asp:ScriptManager>
  
  <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        
    
        <ContentTemplate>

<div class="card card-primary">
              <div class="card-header">
                <h3 class="card-title">Modificar Evento</h3>
              </div>
              <!-- /.card-header -->
              <!-- form start -->
              <form role="form">
                <div class="card-body">

                <div class="container-fluid">
                <div class="row">
                <div class="col-lg-6">
                <div class="card">
                <div class="card-body">
                <div class="form-group">
                  <label>Seleccione El Evento a Modificar</label>
                  <asp:DropDownList ID="drop_evento" runat="server" class="form-control" 
                        AutoPostBack="True">
                     
                   </asp:DropDownList>
                </div>
                <div class="form-group">
                  <label>Tipo de Evento</label>
                  <asp:DropDownList ID="combo_TipoEvento" runat="server" class="form-control">
                      <asp:ListItem Value="Torneo" Selected="True">Torneo</asp:ListItem>
                      <asp:ListItem Value="Curso">Curso</asp:ListItem>
                      <asp:ListItem Value="Examen">Examen</asp:ListItem>
                   </asp:DropDownList>
                </div>
                <div class="form-group" >
                    <label>Nombre </label>
                    <label id="lbl_errNom" class="label label-danger" runat="server">Debe Completar El Campo</label>
                      <input type="text" class="form-control" id="tb_nombre" runat="server" causesvalidation="False" required="" placeholder="Nombre del Evento"/>
                      
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
                  <!-- /.input group -->
                </div>
                                  
                 <div class="form-group">
                  <label>Fecha de Cierre </label>
                  <label id="lbl_errFecCier" class="label label-danger" runat="server">Debe Completar El Campo</label>
                  <div class="input-group">
                    <div class="input-group-prepend">
                      <span class="input-group-text"><i class="fa fa-calendar"></i></span>
                    </div>
                    <input type="text" required="" class="form-control" runat="server" id="tb_fechaCierre" data-inputmask="'alias': 'dd/mm/yyyy'" data-mask="">
                  </div>
                  <!-- /.input group -->
                </div>
                
                  <asp:CompareValidator ID="cmpEndDate" runat="server" 
                        ErrorMessage="La fecha de cierre no puede ser mayor a la del evento" class="label label-danger" 
                        ControlToCompare="tb_fechaCierre" ControlToValidate="tb_fechainicio" 
                        Operator="GreaterThanEqual" Type="Date">
                        </asp:CompareValidator>
                  <!-- Hora -->
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
                <!-- Hora -->

                  <div id="cost_seccion" runat="server" class="form-group" visible="true" >
                    <label>Costo</label>
                    <label id="lbl_costo" class="label label-danger" runat="server">Debe Completar El Campo</label>
                    <asp:TextBox ID="textbox_Costo" CssClass="form-control" onkeypress="return justNumbers(event);" runat="server" ></asp:TextBox>                   
                   
                      <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" TargetControlID="textbox_Costo" FilterType="Numbers" ValidChars="0123456789">
                      </asp:FilteredTextBoxExtender>



                  </div>
                
                </div>
                </div>
                </div> <%--fin del col-lg-6--%>
                

                <div class="col-lg-6">
                <div class="card">
                <div class="card-body">
                <div class="form-group" > 
                 <div>   
               <label>Foto del Evento</label>  
               </div> 
         <asp:Image ID="Image1" runat="server" Height="286px" 
         ImageUrl="~/Eventos/imagen/logo_evento.jpg" Width="286px" Visible="true" 
                     BorderStyle="solid" />
                 <br />
                       &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;<br />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
          &nbsp;
        <button type="button" class="btn btn-primary" data-toggle="modal" runat="server" id="btn_Examinar" data-target="#exampleModal">Examinar</button>
        &nbsp;
        <button type="button" class="btn btn-danger" id="btn_quitar" runat="server" 
                     visible="True">
      &nbsp; &nbsp;Quitar&nbsp;</button>
        &nbsp;
        <label id="lbl_errImg" class="label label-danger" runat="server">Solo imagenes</label>
       
 
            <!-- Modal -->
            <div class="modal fade" id="exampleModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
              <div class="modal-dialog modal-lg" role="document">
                <div class="modal-content">
                  <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalLabel">Seleccione un Foto Para Subir</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                      <span aria-hidden="true">&times;</span>
                    </button>
                  </div>
                  <div class="modal-body">
                    <div class="file-loading">
                      <%--<input id="FileUpload1" name="FileUpload1" multiple type="file" runat="server">--%>
                        <asp:FileUpload ID="FileUpload1" runat="server" />
            

                    </div>
                    <div id="kartik-file-errors"></div>
                  </div>
                  <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Cerrar</button>
                    <button type="button" class="btn btn-primary" id="Subir_Foto" runat="server" rutitle="Your custom upload logic" >Subir</button>
                  </div>
                </div>
              </div>
            </div>
   
 </div>


                </div>
                </div>
                </div> <%--fin del col-lg-6--%>
                
                <div class="col-lg-6">
                         <asp:Panel ID="Panel_examenes" runat="server" Visible=false >
  
  <div class="card">
  <div class="card-body">
    <div class="form-group">
        <label>Capacidad máxima de inscriptos por turno: 
        <label ID="lbl_error_cap_max_inscr" runat="server" class="label label-danger">
        Ingrese capacidad máxima.</label></label><asp:TextBox ID="tb_capacidad_max" onkeypress="return justNumbers(event);" CssClass="form-control" runat="server" ></asp:TextBox>  
        <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="tb_capacidad_max" FilterType="Numbers" ValidChars="0123456789">
        </asp:FilteredTextBoxExtender>
                
               
        <label>Seleccione los turnos para el examen: </label>
        &nbsp;<label ID="lbl_turnos_error0" runat="server" class="label label-danger">Debe 
        seleccionar al menos un turno</label><br />
        <label ID="lbl_no_turnos" runat="server" class="label label-danger">
        * No puede modificar turnos, existen inscriptos registrados.</label></div>
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
                        



                 

                    

     <div id="Ocultar" runat="server" visible="false">
                  <asp:button id="hButton" runat="server" style="display:none;" />
                  <%--<asp:Button runat="server" ID="btnAdd" Text="Add" />--%>
                    <asp:ModalPopupExtender ID="ModalPopupExtender1" runat="server" TargetControlID="hButton"
                    PopupControlID="Panel1" Drag="true" BackgroundCssClass="modalBackground" CancelControlID="btn_Cerrar">
                    </asp:ModalPopupExtender>
                                       
                    
              
                    <asp:Panel ID="Panel1" runat="server" CssClass="panel panel-primary">
                                              
            <div class="card card-success">
              <div class="card-header">
                <h3 class="card-title" align="center">
                    <asp:Label ID="Label1" runat="server" Text="Eventos" Font-Bold="True" Font-Size="Large"></asp:Label></h3>

                <div class="card-tools">
                  <%--<button type="button" class="btn btn-tool" id="btn_cerrar_poup" runat="server" data-widget="remove"><i class="fa fa-times"></i>
                  </button>--%>
                </div>
                <!-- /.card-tools -->
              </div>
              <!-- /.card-header -->
              <div class="card-body">
                  <asp:Label ID="Label2" runat="server" Text="Evento Modificado" Font-Italic="True" Font-Bold="True" Font-Size="Medium"></asp:Label>
              <div>
              
              </div>
              <div align="center">
                  <asp:Button ID="btn_Cerrar" runat="server" Text="OK" CssClass="btn btn-primary" />
               </div>
              </div>
              <!-- /.card-body -->
            </div>
            <!-- /.card -->
          
                    </asp:Panel>
     </div>



     
                                       
                    <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1" >
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
                <h3 class="card-title"> Procesando Solicitud</h3>
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
              
                    </form>
            </div>

                <div class="card-footer">
                  <div class="row justify-content-lg-start" >
                  <div class="row align-items-lg-start">
                        <div class="form-group" > 
                        <button type="button" class="btn btn-primary" data-toggle="modal" runat="server" id="BOTON_GRABAR" data-target="#div_guardar_08102021">Guardar Cambios</button>    
                        &nbsp;
                        </div>

                        <div class="form-group" > 
                        <button type="button" class="btn btn-primary" data-toggle="modal" runat="server" id="Button1" data-target="#Div1">Eliminar</button>
                        </div>
                  
                  </div>
                  
                  </div>


                  
                    
                                                      

                
                
                  
                 </div> 
        
        
            <!-- Modal -->
            <div class="modal fade" id="Div1" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true" data-backdrop="static" data-keyboard="false">
              <div class="modal-dialog modal-lg" role="document">
                <div class="modal-content">
                  <div class="modal-header">
                    <h5 class="modal-title" id="H1">¿Está seguro que desea eliminar el evento?</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                      <span aria-hidden="true">&times;</span>
                    </button>
                  </div>
                  
                  <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Cerrar</button>
                    <button type="button" class="btn btn-primary" id="btn_eliminar" runat="server" rutitle="Your custom upload logic" >Eliminar</button>
                  </div>
                </div>
              </div>
            </div>
            
                            




                
             
 
 
 </div>




<div class="modal fade" id="div_guardar_08102021" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true" data-backdrop="static" data-keyboard="false">
              <div class="modal-dialog modal-lg" role="document">
                <div class="modal-content">
                  <div class="modal-header">
                    <h5 class="modal-title" id="H2">¿Desea modificar?</h5>
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

<div class="modal fade" id="modal_error_complete" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true" data-backdrop="static" data-keyboard="false">
              <div class="modal-dialog modal-lg" role="document">
                <div class="modal-content">
                  <div class="modal-header">
                    <h5 class="modal-title" id="H3">Error! Verifique la información ingresada.</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                      <span aria-hidden="true">&times;</span>
                    </button>
                  </div>
                                    
                  <div class="modal-footer">
                    <%--<button type="button" class="btn btn-secondary" data-dismiss="modal">Cancelar</button>--%>
                    <button type="button" class="btn btn-primary" id="Button2" runat="server" data-dismiss="modal" rutitle="Your custom upload logic" >OK</button>
                  </div>
                </div>
              </div>
            </div>


</ContentTemplate>

                          <Triggers>
                            <asp:PostBackTrigger ControlID="Subir_Foto" />
                            <asp:PostBackTrigger ControlID="tb_fechainicio" />
                            <asp:PostBackTrigger ControlID="Button1" />
                            <asp:PostBackTrigger ControlID="btn_eliminar" />
                            
                                                       
                        </Triggers>
       
       
</asp:UpdatePanel>

    



</asp:Content>
