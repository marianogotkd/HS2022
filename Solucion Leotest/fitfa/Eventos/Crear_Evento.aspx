<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/MasterPage.Master" CodeBehind="Crear_Evento.aspx.vb" Inherits="fitfa.Crear_Evento" %>

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
                <h3 class="card-title">Crear Evento</h3>
              </div>
              <!-- /.card-header -->
              <!-- form start -->
              <form role="form">
                <div class="card-body">


                <div class="row">
                    <div class="col-md-4 col-center">
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
                        ErrorMessage="La fecha de cierre no puede ser anterior a la del evento" class="label label-danger" 
                        ControlToCompare="tb_fechainicio" ControlToValidate="tb_fechaCierre" 
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

                  <div class="form-group" >
                    <label>Costo</label>
                    <label id="lbl_costo" class="label label-danger" runat="server">Debe Completar El Campo</label>
                    <%--  <input type="text"  visible="false" class="form-control" id="tb_Costo" runat="server" causesvalidation="False" required="" placeholder="Costo"/>--%>
                         <asp:TextBox ID="textbox_Costo" CssClass="form-control" runat="server" ></asp:TextBox>                   
                   <%-- <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server"  Enabled="True" TargetControlID="textbox_Costo" ValidChars="0123456789," >
                    </asp:FilteredTextBoxExtender>
                  --%>
                  </div>
                    </div>

                    <div class="col-md-4 col-center">
                    <div class="form-group" > 
                 <div>   
               <label>Foto del Evento</label>  
               </div>
               <asp:Image ID="Image1" runat="server" Height="286px" 
         ImageUrl="~/Eventos/imagen/logo_evento.jpg" Width="286px" BorderStyle="Solid" /> 
                 <br />
        <button type="button" class="btn btn-primary" data-toggle="modal" runat="server" id="btn_Examinar" data-target="#exampleModal">Examinar</button>
        &nbsp;
        <button type="button" class="btn btn-danger" id="btn_quitar" runat="server" 
                     visible="True">Quitar</button>
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
                <div class="col-md-4 col-center">
                    </div>
                
                </div>

                  



    
                  

<%--           <div class="container">
            <h1>Bootstrap File Input Example</h1>
            <form enctype="multipart/form-data">
                <div class="form-group">
                    <input id="file-1" type="file" class="file" multiple=true data-preview-file-type="any">
                </div>
                <div class="form-group">
                    <input id="file-2" type="file" class="file" readonly=true>
                </div> 
                <div class="form-group">
                    <input id="file-3" type="file" multiple=true>
                </div>
                <div class="form-group">
                    <button class="btn btn-primary">Submit</button>
                    <button class="btn btn-default" type="reset">Reset</button>
                </div>
            </form>
        </div>
    </body>
	<script>
	    $("#file-3").fileinput({
	        showCaption: false,
	        browseClass: "btn btn-primary btn-lg",
	        fileType: "any"
	    });
	</script>
                 --%>


              <%--    <div class="form-group">
                    <label for="exampleInputFile">Subir Foto </label>
                    <div class="input-group">

                                   
                      <div class="custom-file">
                        <input type="file" class="custom-file-input" id="exampleInputFile">
                        <label class="custom-file-label" for="exampleInputFile"></label>
                      </div>
                      <div class="input-group-append">
                        <span class="input-group-text" id="">Subir</span>
                      </div>
                    </div>--%>

                    



                                    
                                       

              
                    
          <div class="card-footer">
                  <button type="submit" class="btn btn-primary" runat="server" id="btn_guardar">Guardar Cambios</button>
              <asp:Button ID="btn_save" runat="server" Text="Guardar ASP" class="btn btn-primary" />
                </div>
                <label id="lbl_ok" class="label label-warning" visible="False" runat="server" >Evento Creado  </label>
                <div id="div_registro_guardado" runat="server" visible="false" 
                style="color: #00CC00; font-style: normal; font-variant: normal;">
                    Datos actualizados!
                </div>
                    


        <div id="div_modalOK" runat="server">
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
                                                    <asp:Label ID="Label16" runat="server" Text="El evento se generó exitosamente"></asp:Label>
                                                    &nbsp;
                                                </div>
                                            </div>
                                          </div>
                                        </form>  
                                        <div align="center">
                                                <asp:Button ID="Btb_msj_no_eventos" runat="server" Text="OK" CssClass="btn btn-success"  />
                                          </div> 
                                          <div>
                                             &nbsp;
                                          </div>             
                                        </div> 
                                    </asp:Panel>
        
                            <asp:ModalPopupExtender ID="Modal_OK" runat="server" TargetControlID="HiddenField_msj" PopupControlID="Panel1" CancelControlID="Btb_msj_no_eventos" BackgroundCssClass="modalBackground">
                            </asp:ModalPopupExtender>
    
        </div>



                    </form>
            
            
            
            
            
            
            </div>

                

     
      


                   </ContentTemplate>

                          <Triggers>
                            <asp:PostBackTrigger ControlID="Subir_Foto" />
                            <asp:PostBackTrigger ControlID="tb_fechainicio" />
                        </Triggers>
       
       
</asp:UpdatePanel>
</asp:Content>
