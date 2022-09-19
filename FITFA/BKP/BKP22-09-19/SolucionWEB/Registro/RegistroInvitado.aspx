<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="RegistroInvitado.aspx.vb" Inherits="fitfa.RegistroInvitado" %>


<!--los div iniciales solucionan elproblema del calendario en blanco cuando pongo meses---->
<div>

</div>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>



<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
   
    <meta charset="utf-8">
        <meta http-equiv="X-UA-Compatible" content="IE=edge">
        <meta name="viewport" content="width=device-width, initial-scale=1">
        <title>Registro Federativo</title>

        <!-- CSS -->
        <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Raleway:400,700">
        <link rel="stylesheet" href="assets/bootstrap/css/bootstrap.min.css">
        <link rel="stylesheet" href="assets/font-awesome/css/font-awesome.min.css">
        <link rel="stylesheet" href="assets/css/animate.css">
        <link rel="stylesheet" href="assets/css/style.css">
        <link rel="stylesheet" href="assets/css/media-queries.css">

        <!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
        <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
        <!--[if lt IE 9]>
            <script src="https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js"></script>
            <script src="https://oss.maxcdn.com/libs/respond.js/1.4.2/respond.min.js"></script>
        <![endif]-->

        <!-- Favicon and touch icons -->
        <link rel="shortcut icon" href="assets/ico/favicon.png">
        <link rel="apple-touch-icon-precomposed" sizes="144x144" href="assets/ico/apple-touch-icon-144-precomposed.png">
        <link rel="apple-touch-icon-precomposed" sizes="114x114" href="assets/ico/apple-touch-icon-114-precomposed.png">
        <link rel="apple-touch-icon-precomposed" sizes="72x72" href="assets/ico/apple-touch-icon-72-precomposed.png">
        <link rel="apple-touch-icon-precomposed" href="assets/ico/apple-touch-icon-57-precomposed.png">

        <style>
        .modalBackground
        {
            background-color:black;
            filter:alpha(opacity=99) !important;
            opacity:0.6 ! important;
            z-index:20;
            }
        .modalpopup
        {
                      padding:0px 0px 24px 10px;
            position:fixed;
            width:500px;
            height:100px;
            background-color: Black;
            border:2px solid black;
            border-color: Gray; 
                 }
        
        input {
  font-family: monospace;
}
label {
  display: block;
}
div {
  margin: 0 0 1rem 0;
}

        
        
        
        </style>

</head>
<body>
    <form id="form1" runat="server">
    
    <asp:ScriptManager ID="ScriptManager1" runat="server" 
                                    EnableScriptGlobalization="True">
                             </asp:ScriptManager>
                               


    <div>
     	
				
        <!-- Top content -->
        <div class="top-content">
            <div class="container">
        	
			    <!--div class="row">
					<div class="col-sm-8 col-sm-offset-2 text">
						<h1 class="wow fadeInLeftBig">Register Landing Page</h1>
						<div class="description wow fadeInLeftBig">
							<p>
								We have been working very hard to create the new version of our app. It comes with a lot of new features. Check it out now!
							</p>
					    </div>
				    </div>
				</div-->

                
                
             <asp:UpdatePanel ID="UpdatePanel1" runat="server" >
             
             <ContentTemplate> 
				<div class="card card-primary" >
                    <div class="card-header">
                            <h3 class="card-title" style="color: #FFFFFF; font-size: x-large">REGISTRO DE INVITADOS</h3>
                    </div
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
                            
                            <label for="Label_DatosPersonales" style="background-color: #000066; color: #FFFFFF">DATOS PERSONALES</label>
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
                                
                                                        <!--AQUI CONFIGURO EL COLOR DEL CALENDARIO-->
                                                        <style type="text/css">
 
                                                                    .CalendarCSS
                                                                        {
                                                                            background-color: Black ;
                                                                            color: White;
                                                                        }
                                                            </style>
                                                        <cc1:CalendarExtender ID="txt_fechanacimiento_CalendarExtender" runat="server" 
                                                            BehaviorID="txt_fechanacimiento_CalendarExtender" cssclass="CalendarCSS" 
                                                            TargetControlID="txt_fechanacimiento"/>
                                                        <label for="Label_fechanac">Fecha de nacimiento:</label>
                                
                                                        <asp:Label ID="label_error_fechanacimiento" runat="server" Text="error!" ForeColor="#FF3300" Visible="False"></asp:Label>
                                                        <asp:TextBox ID="txt_fechanacimiento" runat="server" 
                                                            class="r-form-1-last-name form-control" placeholder="Fecha de nacimiento..." 
                                                            ReadOnly="True" autopostback="false" ToolTip="fecha de nacimiento" 
                                                            Visible="False"></asp:TextBox>
                                                        <!--label class="sr-only" for="r-form-1-last-name">fechanac</label>
									                        <input type="text" = "*9+-" placeholder="Fecha de nacimiento..." class="r-form-1-last-name form-control" id="txt_fechanac"-->
                            
                                                        <asp:TextBox ID="Txt_fechanac_2" class="r-form-1-last-name form-control" placeholder="00/00/0000" 
                                                            ToolTip="fecha de nacimiento" runat="server"></asp:TextBox>
                            
                                                    </div>
                                        </div>
                               </div>
                    
                            



                                 <label for="Label_DatosInstitucionales" style="background-color: #000066; color: #FFFFFF">DATOS INSTITUCIONALES</label>
                            <div class="form-group">
                                <label for="Label_Graduacion">Graduacion:</label>
                                <asp:DropDownList ID="DropDownList_graduacion" AutoPostBack="True" runat="server" 
                                    class="r-form-1-first-name form-control" placeholder="Graduación..." 
                                    ToolTip="Graduación">
                                </asp:DropDownList>
                            </div>
                            <div class="form-group">
                                <label for="Label_Instructor">Instructor:</label>
                                <asp:DropDownList ID="DropDownList_instructor" AutoPostBack="True" runat="server" 
                                    class="r-form-1-first-name form-control" placeholder="Instructor..." 
                                    ToolTip="Instructor">
                                </asp:DropDownList>
                            </div>

                            <div id="SeccionOculto_Libreta" runat=server visible=false>
                            <div class="form-group">
                            <label for="Label_NroLibreta">Nro. Libreta:</label>
                                <asp:TextBox ID="txt_nrolibreta" runat="server" 
                                    CssClass="r-form-1-first-name form-control" placeholder="Nro. Libreta...(Dejar en blanco si no posee)" 
                                    MaxLength="50"></asp:TextBox>
                            </div>
                            </div>
                    
                    </div>
                    <div class="col-md-6">
                            <label for="Label_FotoPersonal" style="background-color: #000066; color: #FFFFFF">FOTO PERSONAL</label>
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

                <div id="dos_columnas_ocultas" runat=server visible=false> <%--estas 2 columnas: en 1 estaba antes datos institucionales(que ahora se lo puso mas arriba) y en la otra está visible=falso los datos de contacto--%>
                <div class="form-group">
                <div class="row justify-content-left">
                    <div class="col-md-6">
                       
                            
                    </div>
                    <div class="col-md-6">
                            <div id="seccion_datoscontacto" runat=server visible=false>
                                <label for="Label_DatosContacto" style="background-color: #000066; color: #FFFFFF">DATOS DE CONTACTO</label>
                            
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

                <div class="form-group">
                <div class="row justify-content-left">
                <div class="col-md-4">

                </div>
                <div class="col-md-4">
                
                <div class="form-group">
                                          <asp:Button ID="Btn_registrate" runat="server" Text="Registrate!" 
                         class="btn btn-success" CssClass="r-form-1-first-name form-control" BackColor="#00CC99" 
                          Font-Bold="True" ForeColor="White"/>
                                          </div>


                </div>

                <div class="col-md-4">

                </div>
                </div>
                </div>


                                          

                                          <div class="form-group">
                                            <button id="btn_back" type="submit" class="btn btn-default float-right" runat="server">Volver</button>   
                                          </div>
                      
                         
                                
                         
                      
                </div>



                <div class="row">
				    
                
                	<%--<div class="col-sm-6 col-sm-offset-3 r-form-1-box wow fadeInUp">
				
                
                		<div class="r-form-1-top">
				 

        				    </div>
                            </div>--%>
                            </div>


                            <div>
                            <asp:Panel ID="Panel1" runat="server" CssClass="modalpopup">
                                            <div>
                                            
                                            <div style="color: #FF00FF; "> 
                                            Foto de perfil
                                            </div>
                                                    
                                                    <asp:FileUpload ID="FileUpload1" runat="server" />
                                                                                                
                                                <asp:Button ID="Btn_aceptar" runat="server" Text="Aceptar" 
                                                    BackColor="#00CC99" Font-Bold="True" ForeColor="White" />&nbsp;&nbsp;&nbsp;
                                                <asp:Button ID="Btn_cancelar"
                                                    runat="server" Text="Cancelar" BackColor="#FF6666" Font-Bold="True" 
                                                    ForeColor="White" />       
        
                                            
        
        
                                            </div>
                                 </asp:Panel>
                                <cc1:ModalPopupExtender ID="ModalPopupExtender1" runat="server" 
                                    CancelControlID="Btn_cancelar" PopupControlID="Panel1" 
                                    TargetControlID="Button1" BackgroundCssClass="modalBackground">
                                </cc1:ModalPopupExtender>  
                            </div>


                            <asp:HiddenField ID="HiddenMostrar" runat="server" />
                            <asp:Panel ID="Panel_error1" runat="server" CssClass="modalpopup">
                                <asp:Label ID="Label12" runat="server" Text="Error, complete la info solicitada!"></asp:Label>
                                <br />
                                <asp:Button ID="Btn_error1_ok" runat="server" Text="OK" />
                            </asp:Panel>
                 <cc1:ModalPopupExtender ID="ModalPopupExtender2" runat="server" PopupControlID="Panel_error1" TargetControlID="HiddenMostrar" BackgroundCssClass="modalBackground">
                 </cc1:ModalPopupExtender>
                            
                            <asp:HiddenField ID="HiddenMostrar2" runat="server" />
                            <asp:Panel ID="Panel_error2" runat="server" CssClass="modalpopup">
                                <asp:Label ID="Label1" runat="server" Text="Error, El dni ya se encuentra registrado.!"></asp:Label>
                                <br />
                                <asp:Label ID="Label2" runat="server" Text="Verifique la info ingresada."></asp:Label>
                                <br />
                                <asp:Button ID="Btn_error2_ok" runat="server" Text="OK" />
                            </asp:Panel>
                 <cc1:ModalPopupExtender ID="ModalPopupExtender3" runat="server" PopupControlID="Panel_error2" TargetControlID="HiddenMostrar2" BackgroundCssClass="modalBackground">
                 </cc1:ModalPopupExtender>

                            <asp:HiddenField ID="HiddenMostrar3" runat="server" />
                            <asp:Panel ID="Panel_error3" runat="server" CssClass="modalpopup">
                                <asp:Label ID="Label3" runat="server" Text="Error, ingrese fecha de nac. Válida!"></asp:Label>
                                <br />
                                <asp:Button ID="Btn_error3_ok" runat="server" Text="OK" />
                            </asp:Panel>
                 <cc1:ModalPopupExtender ID="ModalPopupExtender4" runat="server" PopupControlID="Panel_error3" TargetControlID="HiddenMostrar3" BackgroundCssClass="modalBackground">
                 </cc1:ModalPopupExtender>

                            <asp:HiddenField ID="HiddenGuardado" runat="server" />
                            <asp:Panel ID="Panel_Guardado" runat="server" CssClass="modalpopup">
                                <asp:Label ID="Label4" runat="server" Text="Registro exitoso!"></asp:Label>
                                <br />
                                <asp:Button ID="Btn_Guardado_ok" runat="server" Text="OK" />
                            </asp:Panel>
                 <cc1:ModalPopupExtender ID="ModalPopupExtender5" runat="server" PopupControlID="Panel_Guardado" TargetControlID="HiddenGuardado" BackgroundCssClass="modalBackground">
                 </cc1:ModalPopupExtender>





                            <div>
                            


                            </div>
                                


      </ContentTemplate> 
                 <Triggers>
                     <asp:AsyncPostBackTrigger ControlID="txt_fechanacimiento" EventName="Init" />
                     <asp:PostBackTrigger ControlID="Btn_aceptar" />
                 </Triggers>
      </asp:UpdatePanel>
                            
                            




                            
                            </div>
        </div>
        				

                        
					
				
                
            
        
						
        

        <!-- Features -->
        <!--div class="features-container section-container">
	        <div class="container">
	            <div class="row">
	                <div class="col-sm-12 features section-description wow fadeIn">
	                    <h2>Why You Should Join? . . . . . . .</div>
	                    <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et.
	                    	Ut wisi enim ad minim veniam, quis nostrud tempor incididunt ut labore et.</p>
	                </div>
	            </div>
	            <div class="row">
                	<div class="col-sm-4 features-box wow fadeInUp">
	                	<div class="features-box-icon"><i class="fa fa-thumbs-up"></i></div>
	                    <h3>Easy To Use</h3>
	                    <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt.</p>
                    </div>
                    <div class="col-sm-4 features-box wow fadeInDown">
	                	<div class="features-box-icon"><i class="fa fa-cog"></i></div>
	                    <h3>Responsive Design</h3>
	                    <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt.</p>
                    </div>
                    <div class="col-sm-4 features-box wow fadeInUp">
	                	<div class="features-box-icon"><i class="fa fa-commenting"></i></div>
	                    <h3>24/7 Support</h3>
	                    <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt.</p>
                    </div>
	            </div>
	            <div class="row">
	            	<div class="col-sm-12 section-bottom-button wow fadeInUp">
                        <a class="btn btn-link-1 scroll-link" href="#top-content">Sign Up Now <i class="fa fa-angle-right"></i></a>
	            	</div>
	            </div>
	        </div-->
        
        
        
        
        </div>
    
    




        <!-- Javascript -->
        <script src="assets/js/jquery-1.11.1.min.js"></script>
        <script src="assets/bootstrap/js/bootstrap.min.js"></script>
        <script src="assets/js/jquery.backstretch.min.js"></script>
        <script src="assets/js/wow.min.js"></script>
        <script src="assets/js/retina-1.1.0.min.js"></script>
        <script src="assets/js/scripts.js"></script>
       <%-- <script src="//static.codepen.io/assets/common/stopExecutionOnTimeout-41c52890748cd7143004e05d3c5f786c66b19939c4500ce446314d1748483e13.js"></script>
        <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery/3.1.1/jquery.min.js"></script>
        <script src="https://s3-us-west-2.amazonaws.com/s.cdpn.io/3/jquery.inputmask.bundle.js"></script>--%>

        <!--[if lt IE 10]>
            <script src="assets/js/placeholder.js"></script>
        <![endif]-->

        <script>
            $(":input").inputmask();

            $("#phone").inputmask({ "mask": "(999) 999-9999" });
        
        </script>


    </div>
    </form>
</body>
</html>