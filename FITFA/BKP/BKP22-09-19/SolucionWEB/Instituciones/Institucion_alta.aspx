<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/MasterPage.Master" CodeBehind="Institucion_alta.aspx.vb" Inherits="fitfa.Institucion_alta" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
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
              <h3 class="card-title">Crear Institución<asp:HiddenField 
                      ID="HiddenField_instructor_id" runat="server" />
              </h3>
              </div>
              <form role="form">
              
                  <div class="card-body">
              
                    <div class="row">
                    <div class="col-md-5 col-center">
                         <div class="form-group" >
                              <label>Nombre:</label>
                              <input type="text" class="form-control" id="tb_nombre" runat="server" causesvalidation="False" required="" placeholder="Ingrese nombre de la institución..."/>
                          </div>

                          <div class="form-group">
                              <label>Abreviatura:</label>
                              <input type="text" class="form-control" id="tb_abreviatura" runat="server" causesvalidation="False" required="" placeholder="Ingrese abreviatura..."/>
                          </div>

                          <div class="form-group">
                              <label>Provincia:</label>
                              <asp:DropDownList ID="combo_provincia" runat="server" class="form-control" ToolTip="Seleccione la provincia">
                              </asp:DropDownList>
                              <%--CssClass="form-control select2" --%>
                          </div>
                        </div>
                        <div class="col-md-5 col-center">
                              <div class="form-group">
                              <label>Logo de la institución:</label>
                                      <br />
                                      <asp:Image ID="Image1" runat="server" Height="262px" 
                                        ImageUrl="~/Instituciones/Imagen/logo_institucion.jpg" Width="234px"  
                                      Visible="true" BorderStyle="Solid" />
                                  <br />
                                  <br />
                              <button type="button" class="btn btn-primary" data-toggle="modal" runat="server" id="btn_Examinar" data-target="#exampleModal">Examinar</button>
                                  &nbsp;
                              <button type="button" class="btn btn-danger" id="btn_quitar" runat="server" visible="true">Quitar</button>   
                              </div>
                                              
                        
                        </div>
                        <div class="col-md-5 col-center"></div>
                    </div>
                                         
              
                  </div>

                  <div class="card-footer">
                    <button type="submit" class="btn btn-primary" runat="server" id="btn_guardar">Guardar Cambios</button>
                  </div>
              
              </form>
    
    </div>

<%--    ------------MODAL PARA BOTON EXAMINAR-------------------------%>
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

<%--        ----------------------FIN MODAL PARA BOTON EXAMINAR-------------%>


        <%----------------MODAL PARA BOTON GUARDAR--------------------------%>
        <div id="div_modalOK" runat="server">
                                <asp:HiddenField ID="HiddenField_msj" runat="server" />
                                    <asp:Panel ID="Panel1" runat="server" >
              
                                        <div class="card card-success">
                                        <div class="card-header">
                                            <h3 class="card-title">Institución</h3>
                                        </div>
                                        <form role="form">
                                          <div class="card-body"> 
                                            <div class="row">
                                                <div align="center">
                                                    <asp:Label ID="Label16" runat="server" Text="La institución se agregó exitosamente"></asp:Label>
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
        <%---------------FIN MODAL PARA BOTON GUARDAR-------------------------%>
        



        <%----------------MODAL PARA BOTON ERROR, YA EXISTE--------------------------%>
        <div id="div_modal_errorexiste" runat="server">
        <asp:HiddenField ID="HiddenField1" runat="server" />
                                    <asp:Panel ID="Panel2" runat="server" >
              
                                        <div class="card card-danger ">
                                        <div class="card-header">
                                            <h3 class="card-title">Institución</h3>
                                        </div>
                                        <form role="form">
                                          <div class="card-body"> 
                                            <div class="row">
                                                <div align="center">
                                                    <asp:Label ID="Label1" runat="server" Text="Error, la institucion ya existe. Por favor modifica la información ingresada."></asp:Label>
                                                    &nbsp;
                                                </div>
                                            </div>
                                          </div>
                                        </form>  
                                        <div align="center">
                                                <asp:Button ID="Button1" runat="server" Text="OK" CssClass="btn btn-danger "  />
                                          </div> 
                                          <div>
                                             &nbsp;
                                          </div>             
                                        </div> 
                                    </asp:Panel>
        <asp:ModalPopupExtender ID="modal_errorexiste" runat="server" TargetControlID="HiddenField1" PopupControlID="Panel2" CancelControlID="Button1" BackgroundCssClass="modalBackground">
        </asp:ModalPopupExtender>
        
        </div>

        <%----------------FINMODAL PARA BOTON ERROR, YA EXISTE--------------------------%>
        

        <%----------------MODAL PARA BOTON ERROR, complete los datos--------------------------%>
        <div id="div_modal_errorcomplete" runat="server">
        <asp:HiddenField ID="HiddenField2" runat="server" />
                                    <asp:Panel ID="Panel3" runat="server" >
              
                                        <div class="card card-danger ">
                                        <div class="card-header">
                                            <h3 class="card-title">Institución</h3>
                                        </div>
                                        <form role="form">
                                          <div class="card-body"> 
                                            <div class="row">
                                                <div align="center">
                                                    <asp:Label ID="Label2" runat="server" Text="Error, complete la información solicitada."></asp:Label>
                                                    &nbsp;
                                                </div>
                                            </div>
                                          </div>
                                        </form>  
                                        <div align="center">
                                                <asp:Button ID="Button2" runat="server" Text="OK" CssClass="btn btn-danger "  />
                                          </div> 
                                          <div>
                                             &nbsp;
                                          </div>             
                                        </div> 
                                    </asp:Panel>
            <asp:ModalPopupExtender ID="modal_errorcomplete" runat="server" TargetControlID="HiddenField2" PopupControlID="Panel3" CancelControlID="Button2" BackgroundCssClass="modalBackground">
            </asp:ModalPopupExtender>

        </div>
        <%----------------FINMODAL PARA BOTON ERROR, complete--------------------------%>



    </ContentTemplate>
    
        <Triggers>
            <asp:PostBackTrigger ControlID="Subir_Foto"/><%-- 'ESTO ES IMPORTANTE PARA QUE ANDE EL MODAL POP UP--%>
        </Triggers>
    
    </asp:UpdatePanel>
</asp:Content>
