<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/MasterPage.Master" CodeBehind="Instructores_nuevo.aspx.vb" Inherits="fitfa.Instructores_nuevo" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" 
        EnableScriptGlobalization="True">
  </asp:ScriptManager>
  <asp:UpdatePanel ID="upp" runat="server">
  <ContentTemplate>


  <div class="card card-primary" >

        <div class="card-header">
        <h3 class="card-title">Registro de Instructores Invitados</h3>
        </div>
                 <form role="form">
    <div class="card-body">
    <div class="container-fluid">
    <div class="row justify-content-center">
    <div class="col-lg-12">
    <div class="card">
                
                <div class="card-body">
                <div class="form-group">
                <div class="row justify-content-left">
                <div class="col-md-6">
                <label for="Label_DatosPersonales">DATOS PERSONALES</label>
                            <div class="form-group">
                            <label for="Label_apellido2">Apellido:</label>	
							<asp:TextBox ID="Txt_apellido2" runat="server" 
                                placeholder="Ingrese apellido..." class="form-control" 
                                onkeydown="tecla_op(event);"  
                                MaxLength="0"></asp:TextBox>
                            </div>
                            <div class="form-group" id="div_apellido_error" runat="server" visible="false">
                                <asp:Label ID="label_error_apellido" runat="server" 
                                Text="Error! Ingrese apellido." ForeColor="#FF3300"></asp:Label>

                            </div>
                            <div class="form-group">
                            <label for="Label_nombre2">Nombre:</label>
                            <asp:TextBox ID="Txt_nombre2" runat="server" 
                                placeholder="Ingrese nombre..." class="form-control" 
                                onkeydown="tecla_op(event);"  
                                MaxLength="0"></asp:TextBox>
                            </div>
                            <div class="form-group" id="div_nombre_error" runat="server" visible="false">
                                <asp:Label ID="label_error_nombre" runat="server" Text="Error! Ingrese nombre." 
                                    ForeColor="#FF3300"></asp:Label>
                            </div> 
                            <div class="form-group">    
                                <label for="Label_dni">DNI:</label>
                            <asp:TextBox ID="Txt_Dni2" runat="server" 
                                placeholder="Ingrese DNI" class="form-control" 
                                onkeydown="tecla_op(event);"  
                                MaxLength="8"></asp:TextBox>
                            </div>
                            <div class="form-group" id="div_dni_error" runat="server" visible="false">
                            <asp:Label ID="label_dni_error" runat="server" Text="error!" ForeColor="#FF3300"></asp:Label>
                            
                            </div>
                            <div class="row justify-content-left">
                                    <div class="col-md-6">
                                                    <div class="form-group">
                                                    <label for="Label_sexo2">Sexo:</label>
                                                    <asp:Label ID="label_error_sexo" runat="server" Text="error!" ForeColor="#FF3300" Visible="False"></asp:Label>
                                                    <asp:DropDownList ID="DropDownList_sexo" runat="server" 
                                                        CssClass="r-form-1-first-name form-control" placeholder="Sexo...">
                                                        <asp:ListItem Selected="True">Hombre</asp:ListItem>
                                                        <asp:ListItem>Mujer</asp:ListItem>
                                                    </asp:DropDownList>
                                                    </div>
                                    </div>
                                    <div class="col-md-6">
                                                    <div class="form-group">
                                                        <label for="Label_fechanac">Fecha de nacimiento:</label>
                                                        <asp:Label ID="label_error_fechanacimiento" runat="server" Text="error!" ForeColor="#FF3300" Visible="False"></asp:Label>
                                                        <asp:TextBox ID="Txt_fechanac_2" class="r-form-1-last-name form-control" placeholder="00/00/0000" 
                                                            ToolTip="fecha de nacimiento" runat="server"></asp:TextBox>
                            
                                                    </div>
                                        </div>
                            </div>
                </div>
                <div class="col-md-6">
                        <div id="seccion_datoscontacto" runat=server visible=false>
                        <label for="Label_DatosContacto">DATOS DE CONTACTO</label>
                        <div class="form-group">
                                <label for="Label_Provincia">Provincia:</label>
                                
                                <asp:DropDownList ID="DropDownList_provincia" runat="server" 
                                    AutoPostBack="True" class="r-form-1-first-name form-control" 
                                    ToolTip="Provincia">
                                </asp:DropDownList>
                        </div>
                        <div class="form-group">
                                <label for="Label_Ciudad">Ciudad:</label>
                                <asp:DropDownList ID="DropDownList_ciudad" runat="server" 
                                    class="r-form-1-first-name form-control" ToolTip="Ciudad">
                                </asp:DropDownList>
                        </div>
                        <div class="form-group">
                                <label for="Label_Domicilio">Domicilio:</label>
                                <asp:TextBox ID="txt_domilicio" runat="server" class="r-form-1-first-name form-control" placeholder="Domicilio..." MaxLength="50"></asp:TextBox>
                                
                        </div>
                        <div class="row justify-content-left">
                                <div class="col-md-6">
                                                <div class="form-group">
                                                    <label for="Label_Telefono">Telefono:</label>
                                                    <asp:TextBox ID="txt_telefono" runat="server" 
                                                        class="r-form-1-first-name form-control" placeholder="Teléfono..." 
                                                        MaxLength="50"></asp:TextBox>
                                                </div>
                                                <div class="form-group" id="div_telefono_error" runat="server" visible="false">
                                                    <asp:Label ID="label_error_telefono" runat="server" Text="Error, ingrese teléfono!" ForeColor="#FF3300"></asp:Label>
                            
                                                </div>

                                </div>

                                <div class="col-md-6">
                                                <div class="form-group">
                                                        <label for="Label_Email">Email:</label>
                                                        <asp:TextBox ID="txt_email" runat="server" class="r-form-1-email form-control" placeholder="Email..." MaxLength="50"></asp:TextBox>
                                                </div>
                                                <div class="form-group" id="div_email_error" runat="server" visible="false">
                                                    <asp:Label ID="label_error_email" runat="server" Text="Error, ingrese email!" ForeColor="#FF3300"></asp:Label>
                                                </div>
                                </div>
                        </div>
                        </div>
                        
                        
                        
                
                </div>
                <div class="col-md-6">
                        <label for="Label_DatosInstitucionales">DATOS INSTITUCIONALES</label>
                            <div class="form-group">
                                <label for="Label_Graduacion">Graduacion:</label>
                                <asp:DropDownList ID="DropDownList_graduacion" AutoPostBack="True" runat="server" 
                                    class="r-form-1-first-name form-control" placeholder="Graduación..." 
                                    ToolTip="Graduación">
                                </asp:DropDownList>
                            </div>
                            <div id="seccion_libreta" runat=server visible=false>
                            <div class="form-group">
                            <label for="Label_NroLibreta">Nro. Libreta:</label>
                                <asp:TextBox ID="txt_nrolibreta" runat="server" 
                                    CssClass="r-form-1-first-name form-control" placeholder="Nro. Libreta...(Dejar en blanco si no posee)" 
                                    MaxLength="50"></asp:TextBox>
                            </div>
                            </div>
                            
                </div>
                <div class="col-md-6">
                            <div id="seccion_foto" runat=server visible=false >
                            <label for="Label_FotoPersonal">FOTO PERSONAL</label>
                                <div class="r-form-1-top-center">
                                    
                                    <div>
                                    <asp:Image ID="Image1" runat="server" Height="221px" Width="256px" 
                                            ImageUrl="~/Registro/imagen/usuario-registrado.jpg" />
                                    
                                    </div>
                                    <dix>
                                        <asp:Button ID="Button_adjuntar" runat="server" Text="Seleccionar" 
                                            Visible="False" />
                                    </dix>
                                  

                                <asp:Button ID="Button1" runat="server" Text="Examinar" BackColor="#00CC99" 
                                    Font-Bold="True" ForeColor="White" />
                                  
                                &nbsp;
                                <asp:Button ID="Button2" runat="server" BackColor="#FF6666" Font-Bold="True" 
                                    ForeColor="White" Text="Quitar" />
                                  
                               </div>
                           </div>
                </div>
                </div>
                </div>
                </div>
                


    </div>
    
    </div>



    </div>

    </div>

    </div>
    
    
    
    
    
    
    </form>

  </div>

  <div class="card-footer">
                      <%--<button id="btn_back" type="submit" class="btn btn-default float-left" runat="server">Volver</button>--%>
                      <%--<button id="btn_continue" type="submit" class="btn btn-default float-left" runat="server">Guardar</button>--%>
      <asp:Button ID="Btn_continua" runat="server" Text="Guardar" /> 

                        
  </div>

  <asp:HiddenField ID="HiddenMostrar" runat="server" />
                            <asp:Panel ID="Panel_error1" runat="server" CssClass="modalpopup"> 
                                <div class="card card-success">
                                        <div class="card-header alert-danger ">
                                            <h3 class="card-title">ERROR!</h3>
                                        </div>
                                        <form role="form">
                                            <div class="card-body"> 
                                                    <div class="row">
                                                        <div align="center">
                                                                <asp:Label ID="Label12" runat="server" Text="Error, complete la info solicitada!"></asp:Label>
                                                        </div>
                                                    </div>
                                            </div>
                                        </form>
                                        <div align="center">
                                                <asp:Button ID="Btn_error1_ok" runat="server" Text="OK" />
                                        </div>
                                        <div>
                                             &nbsp;
                                        </div>

                                </div>
                                
                            </asp:Panel>
                 <cc1:ModalPopupExtender ID="ModalPopupExtender2" runat="server" PopupControlID="Panel_error1" TargetControlID="HiddenMostrar" BackgroundCssClass="modalBackground">
                 </cc1:ModalPopupExtender>
                            
 <asp:HiddenField ID="HiddenMostrar2" runat="server" />
                            <asp:Panel ID="Panel_error2" runat="server" CssClass="modalpopup"> 
                                <div class="card card-success">
                                    <div class="card-header alert-danger ">
                                            <h3 class="card-title">ERROR!</h3>
                                    </div>
                                    <form role="form">
                                            <div class="card-body"> 
                                                    <div class="row">
                                                        <div align="center">
                                                                <asp:Label ID="Label5" runat="server" Text="Error, el dni ya se encuentra registrado!"></asp:Label>
                                                                <br />
                                                                 <asp:Label ID="Label6" runat="server" Text="Verifique la info ingresada."></asp:Label>
                                                                
                                                                
                                            
                                                        </div>
                                                    </div>
                                            </div>
                                    </form>
                                    <div align="center">
                                            <asp:Button ID="Btn_error2_ok" runat="server" Text="OK" />
                                    </div>
                                    <div>
                                         &nbsp;
                                    </div>
                                </div>
                                
                                <%--<asp:Label ID="Label1" runat="server" Text="Error, El dni ya se encuentra registrado.!"></asp:Label>
                                <br />
                                <asp:Label ID="Label2" runat="server" Text="Verifique la info ingresada."></asp:Label>
                                <br />--%>
                                
                            </asp:Panel>
                 <cc1:ModalPopupExtender ID="ModalPopupExtender3" runat="server" PopupControlID="Panel_error2" TargetControlID="HiddenMostrar2" BackgroundCssClass="modalBackground">
                 </cc1:ModalPopupExtender>

 <asp:HiddenField ID="HiddenMostrar3" runat="server" />
                            <asp:Panel ID="Panel_error3" runat="server" CssClass="modalpopup"> 
                                <div class="card card-success">
                                        <div class="card-header alert-danger ">
                                            <h3 class="card-title">ERROR!</h3>
                                        </div>
                                        <form role="form">
                                            <div class="card-body"> 
                                                    <div class="row">
                                                        <div align="center">
                                                                <asp:Label ID="Label1" runat="server" Text="Error, ingrese fecha de nac. Válida!"></asp:Label>
                                                                
                                                        </div>
                                                    </div>
                                            </div>
                                        </form>
                                        <div align="center">
                                                <asp:Button ID="Btn_error3_ok" runat="server" Text="OK" />
                                        </div>

                                        <div>
                                         &nbsp;
                                        </div>  

                                </div>
                                
                            </asp:Panel>
                 <cc1:ModalPopupExtender ID="ModalPopupExtender4" runat="server" PopupControlID="Panel_error3" TargetControlID="HiddenMostrar3" BackgroundCssClass="modalBackground">
                 </cc1:ModalPopupExtender>

<asp:HiddenField ID="HiddenMostrarOK" runat="server" />
                <asp:Panel ID="Panel_msjok" runat="server">
              
                                        <div class="card card-success">
                                        <div class="card-header">
                                            <h3 class="card-title">Registro</h3>
                                        </div>
                                        <form role="form">
                                          <div class="card-body"> 
                                            <div class="row">
                                                <div align="center">
                                                    <asp:Label ID="Label4" runat="server" Text="Se guardó correctamente!"></asp:Label>
                                                    &nbsp;
                                                </div>
                                            </div>
                                          </div>
                                        </form>  
                                        <div align="center">
                                                <asp:Button ID="btn_MostrarOK" runat="server" Text="OK" CssClass="btn btn-success"  />
                                          </div> 
                                          <div>
                                             &nbsp;
                                          </div>             
                                        </div> 
                </asp:Panel>
      <cc1:ModalPopupExtender ID="ModalPopupExtender5" runat="server" PopupControlID="Panel_msjok" TargetControlID="HiddenMostrarOK" BackgroundCssClass="modalBackground">
      </cc1:ModalPopupExtender>




  </ContentTemplate>
                <Triggers>
                     
                 </Triggers>
  </asp:UpdatePanel>



</asp:Content>
