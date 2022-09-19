<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="registro.aspx.vb" Inherits="fitfa.registro" Culture="Auto" UICulture="Auto" %>


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

                
                
             <asp:UpdatePanel ID="UpdatePanel1" runat="server">
             
             <ContentTemplate> 
				
                <div class="row">
				    
                
                	<div class="col-sm-6 col-sm-offset-3 r-form-1-box wow fadeInUp">
				
                
                		<div class="r-form-1-top">
				
                
                
                
                			<div class="r-form-1-top-left">
								<h3>Registrate ahora</h3>
								<p>Llena el formulario para crear tu cuenta:</p>
							</div>
							<div class="r-form-1-top-right">
								<i class="fa fa-pencil"></i>
							</div>
						
						    <div class="r-form-1-bottom">
                                <div class="r-form-1-top-left">
								<h3>Datos personales</h3>
							    </div>	
							</div>
                            <!--div class="form-group">
									<label class="sr-only" for="r-form-1-first-name">First name</label>
									<input type="text" name="r-form-1-first-name" placeholder="First name..." class="r-form-1-first-name form-control" id="r-form-1-first-name">
								</div-->
                            <div class="form-group">
                                <asp:TextBox ID="txt_apellido" runat="server" 
                                    CssClass="r-form-1-first-name form-control" placeholder="Apellido..." 
                                    MaxLength="50"></asp:TextBox>
                                
                            </div>

                            <div class="form-group" id="div_apellido_error" runat="server" visible="false">
                                <asp:Label ID="label_error_apellido" runat="server" 
                                    Text="Error! Ingrese apellido." ForeColor="#FF3300"></asp:Label>

                            </div>

                            <div class="form-group">
                                <asp:TextBox ID="txt_nombre" runat="server" 
                                    CssClass="r-form-1-first-name form-control" placeholder="Nombre..." 
                                    MaxLength="50"></asp:TextBox>
                            </div>
                            <div class="form-group" id="div_nombre_error" runat="server" visible="false">
                                <asp:Label ID="label_error_nombre" runat="server" Text="Error! Ingrese nombre." 
                                    ForeColor="#FF3300"></asp:Label>
                            </div>


                            <div class="form-group" id="seccion_dni" runat=server >
                                <asp:Label ID="Label1" runat="server" Text="Tipo de documento:"></asp:Label> 
                                <asp:Label ID="label_error_tipodoc" runat="server" Text="error!" 
                                    ForeColor="#FF3300" Visible="False"></asp:Label>
                                <asp:DropDownList ID="DropDownList_tipodoc" runat="server" 
                                    CssClass="r-form-1-first-name form-control">
                                    <asp:ListItem>Tipo de documento</asp:ListItem>
                                    <asp:ListItem>CI</asp:ListItem>
                                    <asp:ListItem Selected="True">DNI</asp:ListItem>
                                    <asp:ListItem>LC</asp:ListItem>
                                    <asp:ListItem>LE</asp:ListItem>
                                    <asp:ListItem>PAS</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="form-group">
                                    <asp:TextBox ID="txt_dni" runat="server" 
                                    class="r-form-1-last-name form-control" placeholder="Dni..." MaxLength="8"></asp:TextBox>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator_dni" runat="server" 
                                    ErrorMessage="error!" ControlToValidate="txt_dni" 
                                    ValidationExpression="^\d+$" Font-Bold="False" ForeColor="#FF3300"></asp:RegularExpressionValidator>

                                <!--label class="sr-only" for="r-form-1-last-name">Dni</label>
									<input type="text" = "*9+-" placeholder="Dni..." class="r-form-1-last-name form-control" id="txt_dni"-->
                            </div>

                            <div class="form-group" id="div_dni_error" runat="server" visible="false">
                            <asp:Label ID="label_dni_error" runat="server" Text="error!" ForeColor="#FF3300"></asp:Label>
                            
                            </div>

                            <div class="form-group">
                                <asp:Label ID="Label2" runat="server" Text="Sexo:"></asp:Label>
                                <asp:Label ID="label_error_sexo" runat="server" Text="error!" ForeColor="#FF3300" Visible="False"></asp:Label>
                                <asp:DropDownList ID="DropDownList_sexo" runat="server" 
                                    CssClass="r-form-1-first-name form-control" placeholder="Sexo...">
                                    <asp:ListItem Selected="True">Hombre</asp:ListItem>
                                    <asp:ListItem>Mujer</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="form-group">
                                <asp:TextBox ID="txt_nacionalidad" runat="server" visible="false" 
                                    class="r-form-1-email form-control" placeholder="Nacionalidad..." 
                                    MaxLength="50"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <asp:Label ID="Label3" runat="server" Text="Estado civil:" Visible="false"></asp:Label>
                                <asp:Label ID="label_error_estadocivil" runat="server" Text="error!" ForeColor="#FF3300" Visible="False"></asp:Label>

                                <asp:DropDownList ID="DropDownList_estadocivil" runat="server"  Visible="false"
                                    CssClass="r-form-1-first-name form-control">
                                </asp:DropDownList>
                            </div>
                            <div class="form-group">
                                <asp:TextBox ID="txt_profesion" runat="server"  Visible="false" 
                                    class="r-form-1-email form-control" placeholder="Profesión..." 
                                    MaxLength="50"></asp:TextBox>
                            </div>

                            <%--<div class="form-group">
                            
                            <div>
    <label for="date">Date</label>
    <input id="date" data-inputmask="'alias': 'date'" />
  </div>
                            
                            </div>--%>

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
                                <asp:Label ID="Label8" runat="server" Text="Fecha de nacimiento:"></asp:Label>
                                <asp:Label ID="label_error_fechanacimiento" runat="server" Text="error!" ForeColor="#FF3300" Visible="False"></asp:Label>
                                <asp:TextBox ID="txt_fechanacimiento" runat="server" 
                                    class="r-form-1-last-name form-control" placeholder="Fecha de nacimiento..." 
                                    ReadOnly="True" autopostback="false" ToolTip="fecha de nacimiento" 
                                    Visible="False"></asp:TextBox>
                                <!--label class="sr-only" for="r-form-1-last-name">fechanac</label>
									<input type="text" = "*9+-" placeholder="Fecha de nacimiento..." class="r-form-1-last-name form-control" id="txt_fechanac"-->
                            
                                <asp:TextBox ID="Txt_fechanac_2" class="r-form-1-last-name form-control" placeholder="Fecha de nacimiento..." 
                                    ToolTip="fecha de nacimiento" runat="server"></asp:TextBox>
                            
                            </div>
                            
                            <!--div class="form-group">
									<label class="sr-only" for="r-form-1-last-name">Last name</label>
									<input type="text" name="r-form-1-last-name" placeholder="Last name..." class="r-form-1-last-name form-control" id="r-form-1-last-name">
								</div>
								<div class="form-group">
									<label class="sr-only" for="r-form-1-email">Email</label>
									<input type="text" name="r-form-1-email" placeholder="Email..." class="r-form-1-email form-control" id="r-form-1-email">
								</div>
								<div class="form-group">
									<label class="sr-only" for="r-form-1-about-yourself">About yourself</label>
									<textarea name="r-form-1-about-yourself" placeholder="About yourself..." 
												class="r-form-1-about-yourself form-control" id="r-form-1-about-yourself"></textarea>
								</div-->
                            <div class="r-form-1-top-left">
                                <h3>
                                    Datos de contacto</h3>
                            </div>
                            <div class="form-group">
                                <asp:TextBox ID="txt_domilicio" runat="server" 
                                    class="r-form-1-first-name form-control" placeholder="Domicilio..." 
                                    MaxLength="50"></asp:TextBox>
                                
                            </div>

                            <div class="form-group" id="div_domicilio_error" runat="server" visible="false">
                                <asp:Label ID="label_error_domicilio" runat="server" Text="Error, ingrese domicilio!" ForeColor="#FF3300"></asp:Label>
                            </div>

                            <div class="form-group">
                                <asp:TextBox ID="txt_codigopostal" runat="server" 
                                    class="r-form-1-first-name form-control" placeholder="Código postal..." 
                                    MaxLength="10"></asp:TextBox>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                                    ErrorMessage="error!" ControlToValidate="txt_codigopostal" 
                                    ValidationExpression="^\d+$" Font-Bold="False" ForeColor="#FF3300"></asp:RegularExpressionValidator>
                            </div>

                            <div class="form-group">
                                
                                <asp:Label ID="Label4" runat="server" Text="Provincia:"></asp:Label>
                                
                                <asp:DropDownList ID="DropDownList_provincia" runat="server" 
                                    AutoPostBack="True" class="r-form-1-first-name form-control" 
                                    ToolTip="Provincia">
                                </asp:DropDownList>
                            </div>
                            <div class="form-group">
                                <asp:Label ID="Label5" runat="server" Text="Ciudad:"></asp:Label>
                                <asp:DropDownList ID="DropDownList_ciudad" runat="server" 
                                    class="r-form-1-first-name form-control" ToolTip="Ciudad">
                                </asp:DropDownList>
                            </div>
                            <div class="form-group">
                                <asp:TextBox ID="txt_telefono" runat="server" 
                                    class="r-form-1-first-name form-control" placeholder="Teléfono..." 
                                    MaxLength="50"></asp:TextBox>
                            </div>

                            <div class="form-group" id="div_telefono_error" runat="server" visible="false">
                                <asp:Label ID="label_error_telefono" runat="server" Text="Error, ingrese teléfono!" ForeColor="#FF3300"></asp:Label>
                            
                            </div>

                            <div class="form-group">
                                <asp:TextBox ID="txt_email" runat="server" class="r-form-1-email form-control" 
                                    placeholder="Email..." MaxLength="50"></asp:TextBox>
                            </div>

                            <div class="form-group" id="div_email_error" runat="server" visible="false">
                            <asp:Label ID="label_error_email" runat="server" Text="Error, ingrese email!" ForeColor="#FF3300"></asp:Label>
                            </div>



                            <!--DATOS INSTITUCIONALES----->
                            <div class="r-form-1-top-left">
                                <h3> Datos Institucionales</h3>
                                <asp:Label ID="Label6" runat="server" Text="Graduación:"></asp:Label>
                                <asp:Label ID="label_error_graduacion" runat="server" Text="error!" ForeColor="#FF3300" Visible="False"></asp:Label> 
                            </div>
                               
                            <div class="form-group">
                                <asp:DropDownList ID="DropDownList_graduacion" AutoPostBack="True" runat="server" 
                                    class="r-form-1-first-name form-control" placeholder="Graduación..." 
                                    ToolTip="Graduación">
                                </asp:DropDownList>
                            </div>

                            <div id="div_posee_alumnos" runat="server" visible="false">
                                <asp:Label ID="Label11" runat="server" Text="Posee alumnos:"></asp:Label>
                                <asp:CheckBox ID="CheckBox_posee_alumnos" runat="server" Text="Si" />
                            
                            </div>

                            <div id="seccion_oculta_provincia_e_institucion" runat="server" visible="false">
                                                

                            <div class="form-group">
                            <asp:Label ID="Label9" runat="server" Text="Provincia:"></asp:Label>
                                <asp:Label ID="label_error_provinstitucion" runat="server" Text="error!" ForeColor="#FF3300" Visible="False"></asp:Label> 
                                <asp:DropDownList ID="DropDown_prov_con_institucion" runat="server" AutoPostBack="True" ToolTip="Provincia" class="r-form-1-first-name form-control">
                                </asp:DropDownList>
                            </div>

                            <div class="form-group">
                            <asp:Label ID="Label10" runat="server" Text="Institución:"></asp:Label>
                                <asp:Label ID="label_error_instituciones" runat="server" Text="error!" ForeColor="#FF3300" Visible="False"></asp:Label> 
                                <asp:DropDownList ID="DropDownList_instituciones" runat="server" placeholder="Instituciones..." AutoPostBack="True" ToolTip="Instituciones" class="r-form-1-first-name form-control">
                                </asp:DropDownList>
                            </div>
                            </div>
                            
                            
                            <div class="form-group">
                                <asp:Label ID="Label7" runat="server" Text="Instructor:"></asp:Label>
                                <asp:Label ID="label_error_instructor" runat="server" Text="Error, seleccione un instructor!" ForeColor="#FF3300" Visible="False"></asp:Label>
                                <asp:DropDownList ID="DropDownList_instructor" runat="server" placeholder="Instructores..." AutoPostBack="True" ToolTip="Instructores" class="r-form-1-first-name form-control">
                                </asp:DropDownList>
                            </div>

                            <div class="form-group">
                                <asp:TextBox ID="txt_nrolibreta" runat="server" 
                                    CssClass="r-form-1-first-name form-control" placeholder="Nro. Libreta...(Dejar en blanco si no posee)" 
                                    MaxLength="50"></asp:TextBox>
                            </div>


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
                                  

                                <asp:Button ID="Button1" runat="server" Text="Examinar" BackColor="#00CC99" 
                                    Font-Bold="True" ForeColor="White" />
                                  
                                &nbsp;
                                <asp:Button ID="Button2" runat="server" BackColor="#FF6666" Font-Bold="True" 
                                    ForeColor="White" Text="Quitar" />
                                  
                            </div>
                            

                            <div class="r-form-1-top-left">
                                <h3>
                                    Seguridad</h3>
                            </div>
                            
                            <div class="form-group">
                                 <asp:TextBox ID="txt_usuario" runat="server" class="r-form-1-first-name form-control" 
                                    placeholder="Usuario..." MaxLength="50"></asp:TextBox>
                            </div>

                            <div class="form-group" id="div_usuario_error" runat="server" visible="false">
                            <asp:Label ID="label_usuario_error" runat="server" Text="error!" ForeColor="#FF3300"></asp:Label>
                            </div>
                            
                            
                            <div class="form-group">
                            <asp:TextBox ID="txt_contraseña1" runat="server" class="r-form-1-first-name form-control" 
                                    placeholder="Contraseña..." type="password" TextMode="Password" 
                                    MaxLength="50" ></asp:TextBox>
                                    
                                <!--label class="sr-only" for="r-form-1-first-name">
                                Contraseña</label>
                                <input ID="txt_contraseña" class="r-form-1-first-name form-control" 
                                    name="r-form-1-first-name" placeholder="Contraseña..." type="password">
                                </input-->
                                
                                </div>
                            <div class="form-group" id="div_contraseña1_error" runat="server" visible="false">
                            <asp:Label ID="label_contraseña1_error_" runat="server" Text="error!" ForeColor="#FF3300"></asp:Label>
                            </div>
                            
                            <div class="form-group">
                            <asp:TextBox ID="txt_contraseña2" runat="server" class="r-form-1-first-name form-control" 
                                    placeholder="Repite contraseña..." type="password" TextMode="Password" 
                                    MaxLength="50" ></asp:TextBox>
                            
                            
                            
                                <!--label class="sr-only" for="r-form-1-first-name">
                                confircontraseña</label>
                                <input ID="txt_contraseña2" class="r-form-1-first-name form-control" 
                                    name="r-form-1-first-name" placeholder="repite contraseña..." type="password">
                                </input-->
                                
                            </div>

                            <div class="form-group" id="div_contraseña2_error" runat="server" visible="false">
                            <asp:Label ID="label_contraseña2_error" runat="server" Text="error!" ForeColor="#FF3300"></asp:Label>
                            </div>
                            
                            <!--button class="btn" type="submit" ID="button_registrate">
                                Registrarte!
                            </button-->
                                                  
                 <div class="form-group">
                 <asp:Button ID="Btn_registrate" runat="server" Text="Registrate!" 
                         class="btn btn-success" BackColor="#00CC99" 
                         CssClass="r-form-1-first-name form-control" Font-Bold="True" ForeColor="White"/>
                     <asp:HiddenField ID="HiddenMostrar" runat="server" />
                     
                 </div>
                      


                 <div id="div_registroexitoso" runat="server" visible="false" style="color: #99CCFF">
                 Registro exitoso!
                 </div>
                            

                 

        				    </div>
                            </div>
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


                            <asp:Panel ID="Panel2" runat="server" CssClass="modalpopup">
                                <asp:Label ID="Label12" runat="server" Text="Registro exitoso!"></asp:Label>
                                <br />
                                <asp:Button ID="Btn_ok" runat="server" Text="OK" />
                            </asp:Panel>
                            <cc1:ModalPopupExtender ID="ModalPopupExtender2" runat="server" PopupControlID="Panel2" TargetControlID="HiddenMostrar" BackgroundCssClass="modalBackground">
                            </cc1:ModalPopupExtender>


                            <asp:HiddenField ID="Hidden_Error1" runat="server" />
                            <asp:Panel ID="Panel_error1" runat="server" CssClass="modalpopup">
                                <asp:Label ID="Label13" runat="server" Text="Error, complete la info solicitada!"></asp:Label>
                                <br />
                                <asp:Button ID="Btn_error1_ok" runat="server" Text="OK" />
                            </asp:Panel>
                 <cc1:ModalPopupExtender ID="ModalPopupExtender3" runat="server" PopupControlID="Panel_error1" TargetControlID="Hidden_Error1" BackgroundCssClass="modalBackground">
                 </cc1:ModalPopupExtender>

                            <div>
                            <div class="card-footer">
                  <button id="btn_login" type="submit" class="btn btn-info" runat="server">Iniciar Sesion</button>
                  <button id="btn_Volver" type="submit" class="btn btn-default float-right" runat="server">Volver</button>
                </div>


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
