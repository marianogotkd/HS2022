<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/MasterPage.Master" CodeBehind="Datos_Personales.aspx.vb" Inherits="fitfa.Datos_Personales" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>




<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:ScriptManager ID="ScriptManager1" runat="server" 
        EnableScriptGlobalization="True">
  </asp:ScriptManager>

   <asp:UpdatePanel ID="upp" runat="server">
        <ContentTemplate>
       
       
       
<div class="card card-primary">
              <div class="card-header">
                <h3 class="card-title">Datos Personales</h3>
              </div>
              <!-- /.card-header -->
              <!-- form start -->
              <form role="form">
                <div class="card-body">
                  
                  <div class="row">
                  <div class="col-md-4 col-center">  
                  <div class="form-group" >
                    <%--<label>Nombre</label>--%>
                    <label>Nombre:</label>
                    <label id="lbl_errNom" class="label label-danger" runat="server">Debe Completar El Campo</label>
                      <input type="text" class="form-control" id="tb_nombre" runat="server" causesvalidation="False" required="" placeholder="Ingrese nombre..." maxlength="50"/>
                      
                  </div>
                    <div class="form-group">
                   <%-- <label for="exampleInputEmail1">Apellido</label>--%>
                    <label>Apellido:</label>
                    <label id="lbl_errApe" class="label label-danger" runat="server">Debe Completar El Campo</label>
                    <input type="text" class="form-control" id="tb_apellido" runat="server" 
                          required="" placeholder="Ingrese apellido..." maxlength="50">
                      
                  </div>
              
                 <div class="form-group">
                  <label>Fecha de Nacimiento:</label>
                  <label id="lbl_errFecNac" class="label label-danger" runat="server">Debe Completar El Campo</label>
                  <div class="input-group">
                    <div class="input-group-prepend">
                      <span class="input-group-text"><i class="fa fa-calendar"></i></span>
                    </div>
                    <input type="text" class="form-control" runat="server" id="tb_fechnacc" data-inputmask="'alias': 'dd/mm/yyyy'" data-mask="">
                  </div>
                  <!-- /.input group -->
                </div>

                 <div class="form-group">
                    <label>DNI</label>
  <label id="lbl_costo" class="label label-danger" visible="false" runat="server">Debe Completar El Campo</label>
  <asp:TextBox ID="tb_dni" CssClass="form-control" runat="server"  onkeypress="return justNumbers(event);"></asp:TextBox>  
  <cc1:FilteredTextBoxExtender 
            ID="FilteredTextBoxExtender2" runat="server" TargetControlID="tb_dni"
      FilterType="Numbers" ValidChars="0123456789" >
        </cc1:FilteredTextBoxExtender>
        </div>
                <%--
                  <div class="form-group">
                    <label id="lbl_errNac" class="label label-danger" runat="server">Debe Completar El Campo</label>
                    <label>Nacionalidad:</label>
                    <input type="text" class="form-control" id="tb_nacionalidad" runat="server" 
                          required="" placeholder="Ingrese nacionalidad..." maxlength="50"/>
                  </div>--%>

                   <div class="form-group">
                  <label>Sexo:</label>
                  <asp:DropDownList ID="combo_Sexo" runat="server" class="form-control">
                      <asp:ListItem Value="Hombre" Selected="True">Hombre</asp:ListItem>
                      <asp:ListItem Value="Mujer">Mujer</asp:ListItem>
                   </asp:DropDownList>
                </div>
                 
                              <div class="form-group">
               <%--   <label >Estado Civil:</label>--%>
                   <asp:DropDownList ID="combo_EstCivil" runat="server" class="form-control" Visible=false>
                   </asp:DropDownList>
                  </div>


                     <div class="form-group">
                  <%--  <label for="exampleInputEmail1">Domicilio</label>--%>
                    <label>Domicilio:</label>
                    <label id="lbl_errDir" class="label label-danger" runat="server">Debe Completar El Campo</label>
                    <input type="text" class="form-control" id="tb_dir" runat="server" required="" 
                             placeholder="Ingrese domicilio..." maxlength="50">
                     </div>

                     
                      <div class="form-group">
                   <%-- <label for="exampleInputEmail1">Codigo Postal</label>--%>
                    <label>Código Postal (CP):</label>
                    <label id="lbl_errCP" class="label label-danger" runat="server">Debe Completar El 
                          Campo</label><asp:TextBox ID="textbox_CP" class="form-control" runat="server" MaxLength="50" AutoPostBack="True"></asp:TextBox>
                          <cc1:FilteredTextBoxExtender ID="Filteredtextbox_CPExtender1" Enabled="True" TargetControlID="textbox_CP" ValidChars="0123456789" runat="server">
                          </cc1:FilteredTextBoxExtender>

                  </div>
                     
                     </div> <%--cierra el col-md-4 col-center--%>
                    
                    <div class="col-md-4 col-center">
                     

                  <div class="form-group">
                  <label>Provincia</label>
                  <asp:DropDownList ID="Combo_provincia" runat="server" class="form-control" AutoPostBack="true">
                   </asp:DropDownList>
                   <%--CssClass="form-control select2"--%>
                  </div>

                  <div class="form-group">
                  <label>Ciudad</label>
                   <asp:DropDownList ID="combo_ciudad" runat="server" class="form-control">
                   </asp:DropDownList>
                  </div>
             

                   <div class="form-group">
                  <%--  <label for="exampleInputEmail1">Telefono</label>--%>
                    <label>Teléfono:</label>
                    <label id="lbl_errTel" class="label label-danger" runat="server">Debe Completar El Campo</label>
                    <input type="text" class="form-control" id="tb_tel" runat="server" required="" placeholder="Ingrese teléfono..." maxlength="50"/>
                  </div>

                  <div class="form-group">
                   <%-- <label for="exampleInputEmail1">Correo Electronico</label>--%>
                    <label>Email:</label>
                    <label id="lbl_errMail" class="label label-danger" runat="server">Debe Completar El Campo</label>
                    <input type="text" class="form-control" id="tb_Email" runat="server" required="" placeholder="Ingrese email..." maxlength="50"/>
                  </div>

                  <div class="form-group">
                  <label>Nro. Libreta:</label>
                    <label id="lbl_err_libreta" class="label label-danger" runat="server">Debe Completar El Campo</label>
                    <input type="text" class="form-control" id="tb_nrolibreta" runat="server" required="" placeholder="Ingrese número de libreta..." maxlength="50"/>
                  </div>

                  <div class="form-group">
                  <label>Graduación:</label>
                  <input type="text" class="form-control" id="tb_grad" runat="server" maxlength="50" readonly="readonly"/>
                  <asp:DropDownList ID="Combo_graduacion" runat="server" class="form-control" visible="false">
                   </asp:DropDownList>
                   </div>

                       <div class="form-group">
                  <label>Instructor:</label>
                   <input type="text" class="form-control" id="tb_inst" runat="server" maxlength="50" readonly="readonly"/>
                  <asp:DropDownList ID="cmb_instructor" runat="server" class="form-control" visible="false">
                   </asp:DropDownList>
                   </div>
                 

                    </div> <%--cierra el col-md-4 col-center--%>


             <%--    /////////  FOTO ///////--%>
                     <%--<div class="col-md-4 col-center">
                     
                     
                     
                     <div class="r-form-1-top-left">
                                <h3>
                                    Foto personal</h3>
                                    
                                    
                                    
                                    <div>
                                    <asp:Image ID="Image1" runat="server" Height="221px" Width="256px" 
                                            ImageUrl="~/Registro/imagen/usuario-registrado.jpg" />
                                    
                                    </div>
                       
                                <dix>
                                    <asp:Button ID="Button_adjuntar" runat="server" Text="Seleccionar" 
                                        Visible="False" />
                                </dix>
                                <asp:Button ID="Button1" runat="server" BackColor="#00CC99" Font-Bold="True" 
                                    ForeColor="White" Text="Examinar" />
                                &nbsp;
                                <asp:Button ID="Button2" runat="server" BackColor="#FF6666" Font-Bold="True" 
                                    ForeColor="White" Text="Quitar" />

                            </div>
                          <div>
                            <asp:Panel ID="Panel2" runat="server" CssClass="form-control">
                                            <div>
                                            
                                            <div style="color: #FF00FF; "> 
                                            Foto de perfil
                                            </div>
                                                    
                                                    <asp:FileUpload ID="FileUpload1" runat="server"  />
                                                                                                
                                                <asp:Button ID="Btn_aceptar" runat="server" Text="Aceptar" 
                                                    BackColor="#00CC99" Font-Bold="True" ForeColor="White" />&nbsp;&nbsp;&nbsp;
                                                <asp:Button ID="Btn_cancelar"
                                                    runat="server" Text="Cancelar" BackColor="#FF6666" Font-Bold="True" 
                                                    ForeColor="White" />       
        
                                            
        
        
                                            </div>
                                 </asp:Panel>
                               
                              <cc1:ModalPopupExtender ID="ModalPopupExtender1" runat="server"
                              CancelControlID="Btn_cancelar" PopupControlID="Panel2" 
                              TargetControlID="Button1" BackgroundCssClass="modalBackground">
                              </cc1:ModalPopupExtender>
                            </div>

                             </div>--%>
                  
                    </div>
                      

                      



                  
                  </div>
                  
                  
              

                    </form>
            </div>
        
       
                 
   <%--<div class="card card-primary">
              <div class="card-header">
                <h3 class="card-title">Datos Institucionales</h3>
              </div>
              <form role="form">
                <div class="card-body">

                <div class="form-group">
                  <label>Graduaciones</label>
                  <select class="form-control select2" style="width: 100%;">
                    <option selected="selected">IX DAN</option>
                    <option>VIII DAN</option>
                    <option>VII DAN</option>
                    <option>VI DAN</option>
                    <option>V DAN</option>
                    <option>IV DAN</option>
                    <option>III DAN</option>
                    <option>II DAN</option>
                    <option>I DAN</option>
                    <option>I GUP(Rojo P/Negra)</option>
                    <option>II GUP(Rojo)</option>
                    <option>III GUP(Azul P/Roja)</option>
                    <option>IV GUP(Azul)</option>
                    <option>V GUP(Verde P/Azul)</option>
                    <option>VI GUP(Verde)</option>
                    <option>VII GUP(Amarillo P/Verde)</option>
                    <option>VIII GUP(Amarillo)</option>
                    <option>IX GUP(Blanco P/Amarilla)</option>
                    <option>Blanco</option>
                  </select>
                </div>

                 <div class="form-group">
                  <label>Provincia</label>
                  <select class="form-control select2" style="width: 100%;">
                    <option selected="selected">IX DAN</option>
                    <option>VIII DAN</option>
                  </select>
                </div>

                 <div class="form-group">
                  <label>Instructor</label>
                  <select class="form-control select2" style="width: 100%;">
                    <option selected="selected">IX DAN</option>
                    <option>VIII DAN</option>
                  </select>
                </div>

                 <div class="form-group">
                  <label>Institucion</label>
                  <select class="form-control select2" style="width: 100%;">
                    <option selected="selected">IX DAN</option>
                    <option>VIII DAN</option>
                  </select>
                </div>
                
                </div>
               </form>
              
              
  </div>--%>                
     
     
     <%--  <div class="card card-primary">
              <div class="card-header">
                <h3 class="card-title">Foto de Portada</h3>
              </div>
              <form role="form">
                <div class="card-body">
                
                
                </div>
              </form>
      </div>              --%>
               
                 <%-- <div class="form-group">
                    <label for="exampleInputFile">File input</label>
                    <div class="input-group">
                      <div class="custom-file">
                        <input type="file" class="custom-file-input" id="exampleInputFile">
                        <label class="custom-file-label" for="exampleInputFile">Choose file</label>
                      </div>
                      <div class="input-group-append">
                        <span class="input-group-text" id="">Upload</span>
                      </div>
                    </div>
                  </div>
                  <div class="form-check">
                    <input type="checkbox" class="form-check-input" id="exampleCheck1">
                    <label class="form-check-label" for="exampleCheck1">Check me out</label>
                  </div>
                </div>--%>
                <!-- /.card-body -->

                <div class="card-footer">
                  <button type="submit" class="btn btn-primary" runat="server" id="btn_guardar">Guarda Cambios</button>
                    <br />
                   
                
                </div>
                <div id="div_registro_guardado" runat="server" visible="false" 
                style="color: #00CC00; font-style: normal; font-variant: normal;">
                    Datos actualizados!
                </div>
            

          

            </span>
            

          
        <div id="div_modalmsjOK" runat="server">
                                <asp:HiddenField ID="HiddenField_msj" runat="server" />
                                    <asp:Panel ID="Panel1" runat="server" >
              
                                        <div class="card card-success">
                                        <div class="card-header">
                                            <h3 class="card-title">Datos personales</h3>
                                        </div>
                                        <form role="form">
                                          <div class="card-body"> 
                                            <div class="row">
                                                <div align="center">
                                                    <asp:Label ID="Label1" runat="server" Text="Datos actualizados exitosamente."></asp:Label>
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





     </ContentTemplate>
        
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

 
 