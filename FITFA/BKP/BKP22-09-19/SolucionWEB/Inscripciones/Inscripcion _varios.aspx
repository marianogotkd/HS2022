<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/MasterPage.Master" CodeBehind="Inscripcion _varios.aspx.vb" Inherits="fitfa.Inscripcion__varios" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <%--<style>
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
            background-color: White;
            border:2px solid black;
            border-color: Gray; 
                 }
        
        </style>--%>



</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
   
    <ContentTemplate>

    <div class="card card-primary">
                           
              <div class="card-header">
                <asp:Label ID="Label_titulo" runat="server" Font-Bold="True" Text="Inscripcion Para "></asp:Label>
               <div class="card-tools">
                  <div class="input-group input-group-sm" style="width: 150px;">
                    <asp:TextBox ID="txt_buscar" runat="server" class="form-control float-right" placeholder="Apellido y Nombre o DNI..." Font-Size="Small"></asp:TextBox>
                    <%--<input type="text" name="table_search" class="form-control float-right" placeholder="Buscar...">--%>

                    <div class="input-group-append">
                      <button type="submit" id="btn_buscar" runat="server"  class="btn btn-default"><i class="fa fa-search"></i></button>
                    </div>
                  </div>
                </div>   
              </div>
              <div >
              </div>
              <!-- /.card-header -->
              <!-- form start -->
              
              
              <!--form role="form">
                <div class="card-body"-->
                 
              <div> <asp:Label ID="Label11" runat="server" Font-Bold="True" Text="Alumnos de: "></asp:Label>
                    <asp:Label ID="Label_alumnosde" runat="server" ForeColor="#009933" 
                      Visible="False"></asp:Label>
                    &nbsp;
                    <asp:DropDownList ID="DropDownList_instructores" runat="server" 
                      AutoPostBack="True" Font-Bold="True" ForeColor="Blue">
                    </asp:DropDownList>
              </div>
               <div >
              </div>

<div class="mailbox-controls">
    <button type="submit" id="chk_false" 
        class="btn btn-default btn-sm checkbox-toggle" runat="server" 
        title="Ver inactivos"><i class="fa fa-square-o"></i>
                </button>
                 <button type="button" id="chk_true" runat="server" 
        class="btn btn-default btn-sm checkbox-toggle" title="Ver inactivos"><i class="fa fa-check-square-o"></i>
                </button>
                <button type="button" class="btn btn-default btn-sm" runat="server" id="Actualizar" data-toggle="tooltip" data-container="body" title="Actualizar"><i class="fa fa-refresh"></i></button>
                <div class="btn-group">
                  <button type="button" id="AceptarArr" class="btn btn-default btn-sm" 
                        runat="server" title="Selección de eventos"><strong>Volver</strong></button> 
                
                </div>

                 <div class="btn-group">
                  <button type="button" id="btn_insc_arr" class="btn btn-default btn-sm" 
                        runat="server" title="Inscribir"><strong>Inscribir Alumnos</strong></button>
                </div>
                <!-- /.btn-group -->
                                
                <!-- /.float-right -->
                <div class="row">
                        <div class="col-sm-4"></div>
                        <div class="col-sm_4">
                            <asp:Label ID="Lb_busqueda_error" runat="server" 
                                Text="La busqueda no arrojo resultados!" Align="center" Font-Bold="True" 
                                ForeColor="Red" Visible="False"></asp:Label></div>                       
                        <div class="col-sm-4"></div>
                </div>           
</div>
        <div class="card-body table-responsive p-0">
                      <asp:GridView ID="GridView1" class="table table-hover" runat="server" 
                          AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" 
                           BorderColor="Black" GridLines="None" 
                          EnableSortingAndPagingCallbacks="True" PageSize="20">



                          <Columns>
                              <asp:TemplateField>
                                  <ItemTemplate>
                                      <asp:CheckBox ID="CheckBox1" runat="server" />
                                  </ItemTemplate>
                              </asp:TemplateField>
                              <asp:BoundField HeaderText="ID" DataField="ID" >
                              <HeaderStyle ForeColor="#0099FF" />
                              </asp:BoundField>
                              <asp:BoundField HeaderText="Documento" DataField="Documento" >
                              <HeaderStyle ForeColor="#0099FF" />
                              </asp:BoundField>
                              <asp:BoundField HeaderText="Apellido y Nombre" DataField="Apellido y Nombre" >
                              <HeaderStyle ForeColor="#0099FF" />
                              </asp:BoundField>
                              <asp:BoundField HeaderText="Edad" DataField="Edad">
                              <HeaderStyle ForeColor="#0099FF" />
                              </asp:BoundField>
                              <asp:BoundField HeaderText="Teléfono" DataField="Teléfono" Visible="False" >
                              <HeaderStyle ForeColor="#0099FF" />
                              </asp:BoundField>
                              <asp:BoundField HeaderText="Graduación" DataField="Graduación" >
                              <HeaderStyle ForeColor="#0099FF" />
                              </asp:BoundField>
                              <asp:BoundField HeaderText="Tipo" DataField="Tipo" >
                              <HeaderStyle ForeColor="#0099FF" />
                              </asp:BoundField>
                              <asp:BoundField DataField="Instructor" HeaderText="Instructor">
                              <HeaderStyle ForeColor="#0099FF" />
                              </asp:BoundField>
                              <asp:TemplateField HeaderText="Peso">
                                  <ItemTemplate>
                                      <asp:TextBox ID="txt_peso" runat="server" Height="28px" 
                                          Width="71px"  ></asp:TextBox>
                                  </ItemTemplate>
                                  <EditItemTemplate>
                                      <asp:CheckBox ID="CheckBox1" runat="server" />
                                  </EditItemTemplate>
                                  <HeaderStyle ForeColor="#0099FF" />
                              </asp:TemplateField>
                              <asp:TemplateField HeaderText="Categorias">
                                  <ItemTemplate>
                                      <asp:CheckBox ID="chk_formas" runat="server" Checked="True" Text="Formas" />
                                      <asp:CheckBox ID="chk_lucha" runat="server" Checked="True" Text="Lucha" />
                                      &nbsp;<br />
                                      <asp:CheckBox ID="chk_poder" runat="server" Text="R. Poder" />
                                      <asp:CheckBox ID="chk_especial" runat="server" Text="R. Especial" />
                                  </ItemTemplate>
                                  <HeaderStyle ForeColor="#0099FF" />
                              </asp:TemplateField>
                              <asp:TemplateField ShowHeader="False" Visible="False">
                                  <ItemTemplate>
                                      <asp:ImageButton ID="ImageButton1" runat="server" CausesValidation="false" 
                                          CommandName='ID' ImageUrl="~/img/lupa.png" CommandArgument='<%# Eval("ID") %>' Text="" ToolTip="Ver datos" />
                                  </ItemTemplate>
                                  <ControlStyle Height="30px" Width="30px" />
                                  <HeaderStyle ForeColor="#0099FF" />
                                  <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                              </asp:TemplateField>
                              <asp:TemplateField ShowHeader="False">
                                  <ItemTemplate>
                                      <asp:ImageButton ID="ImageButton2" runat="server" CausesValidation="false" 
                                          CommandName="Id_instructor" ImageUrl="~/img/icono_alumnos.gif" CommandArgument='<%# Eval("ID") %>' Text="Botón" 
                                          ToolTip="Ver alumnos" />
                                  </ItemTemplate>
                                  <ControlStyle Height="30px" Width="30px" />
                              </asp:TemplateField>
                              <asp:TemplateField ShowHeader="False" Visible="False">
                                  <ItemTemplate>
                                      <asp:ImageButton ID="ImageButton3" runat="server" CausesValidation="false" 
                                          CommandName="" ImageUrl="~/img/question-mark-6x.png" Text="" 
                                          ToolTip="Ver estado" />
                                  </ItemTemplate>
                                  <ControlStyle Height="30px" Width="30px" />
                              </asp:TemplateField>
                              <asp:BoundField DataField="Sexo" HeaderText="Sexo" Visible="False" />
                              <asp:BoundField DataField="graduacion_id" HeaderText="graduacion_id" 
                                  Visible="False" />
                          </Columns>



                          <PagerSettings Position="TopAndBottom" />



                      </asp:GridView>
                  </div>
        
                  
                
                    <!--/form-->
            
                  
<div class="mailbox-controls">
    <button type="submit" id="Button2" 
        class="btn btn-default btn-sm checkbox-toggle" runat="server" 
        title="Ver inactivos"><i class="fa fa-square-o"></i>
                </button>
                 <button type="button" id="Button3" runat="server" visible="false"
                    class="btn btn-default btn-sm checkbox-toggle" title="Ver inactivos"><i class="fa fa-check-square-o"></i>
                </button>
                <button type="button" class="btn btn-default btn-sm" runat="server" id="Button4" data-toggle="tooltip" data-container="body" title="Actualizar"><i class="fa fa-refresh"></i></button>
                <div class="btn-group">
                  <button type="button" id="Button5" class="btn btn-default btn-sm" 
                        runat="server" title="instructor de la sesión"><strong>Volver</strong></button>
                        
                </div>

                 <div class="btn-group">
                  <button type="button" id="btn_insc_abj" class="btn btn-default btn-sm" 
                        runat="server" title="Inscribir"><strong>Inscribir Alumnos</strong></button>
                </div>
                <!-- /.btn-group -->
                
                
                <!-- /.float-right -->
              </div>
              
            
                  


              </div>

        <div id="popupdatospersonales" runat="server">
        <asp:HiddenField ID="HiddenField_entrar" runat="server"/>
        <asp:HiddenField ID="HiddenField_salir" runat="server" />
        <asp:Panel ID="Panel_datospersonales" runat="server">
              <div class="card card-widget widget-user">
              <!-- Add the bg color to the header using any of the bg-* classes -->
              <div class="widget-user-header text-white" style="background: url('../masterpage/dist/img/photo1.png') center center;">
                  <div class="card-tools" align="right">
                      <asp:Label ID="Lb_apenom" runat="server" Text="Chocolonea, Pablo Maximiliano" 
                      ></asp:Label>
                  <!--button type="button" class="btn btn-tool" data-widget="collapse"><i class="fa fa-minus"></i>
                  </button-->
                  <button type="button"  class="btn btn-tool" data-widget="remove" id="btn_cerrar_poup" runat="server"><i class="fa fa-times" ></i>
                  </button>
                  </div>   
                    
                    <h6 class="widget-user-desc">
                        <asp:Label ID="Lb_tipousuario" runat="server" Text="Alumno"></asp:Label>
                    </h6>                                        
              </div>
              <div class="widget-user-image">
                <!--img class="img-circle" src="../masterpage/dist/img/user3-128x128.jpg" 
                      alt="User Avatar"-->
                      <asp:Image ID="Image1" CssClass="img-circle" runat="server" Height="90" Width="90" />
              </div>
              <div class="card-footer">
                

                <!-- /.row -->
                 <div class="row">
    <div class="col-sm-6" style="background-color:lavender;">
                <div>
                    <asp:Label ID="Label14" runat="server" Text="Datos Personales" Font-Bold="True" Font-Underline="True"></asp:Label>
                    
                </div>
                <div>
                    <asp:Label ID="Label1" runat="server" Text="Dni:" Font-Bold="True"></asp:Label>
                    <asp:Label ID="Lb_dni" runat="server" Text="326547904"></asp:Label>
                </div>
                <div>
                    <asp:Label ID="Label10" runat="server" Text="Fecha de nacimiento:" Font-Bold="True"></asp:Label>
                    <asp:Label ID="Lb_fechanac" runat="server" Text="22/01/1987"></asp:Label>
                </div>
                <div>
                    <asp:Label ID="Label2" runat="server" Text="Tel:" Font-Bold="True"></asp:Label>
                    <asp:Label ID="Lb_telefono" runat="server" Text="03854212484"></asp:Label>
                </div>
                <div>
                    <asp:Label ID="Label4" runat="server" Text="Correo:" Font-Bold="True"></asp:Label>
                    <asp:Label ID="Lb_correo" runat="server" Text="pmchocolonea@hotmail.com"></asp:Label>
                </div>
                <div>
                    <asp:Label ID="Label5" runat="server" Text="Dir:" Font-Bold="True"></asp:Label>
                    <asp:Label ID="Lb_direccion" runat="server" Text="9 de julio 123"></asp:Label>
                </div>
                <div>
                    <asp:Label ID="Label7" runat="server" Text="Provincia:" Font-Bold="True"></asp:Label>
                    <asp:Label ID="Lb_provincia" runat="server" Text="Sgo del estero"></asp:Label>
                </div>
                <div>
                    <asp:Label ID="Label9" runat="server" Text="Ciudad:" Font-Bold="True"></asp:Label>
                    <asp:Label ID="Lb_ciudad" runat="server" Text="La Banda"></asp:Label>
                </div>
                <div>
                    <asp:Label ID="Label3" runat="server" Text="Nacionalidad:" Font-Bold="True"></asp:Label>
                    <asp:Label ID="Lb_nacionalidad" runat="server" Text="Argentino"></asp:Label>
                </div>
                <div>
                    <asp:Label ID="Label6" runat="server" Text="Estado civil:" Font-Bold="True"></asp:Label>
                    <asp:Label ID="Lb_estadocivil" runat="server" Text="Soltero"></asp:Label>
                </div>
                <div>
                    <asp:Label ID="Label8" runat="server" Text="Profesión:" Font-Bold="True"></asp:Label>
                    <asp:Label ID="Lb_profesion" runat="server" Text="Estudiante"></asp:Label>
                </div>
    
    </div>
    <div class="col-sm-6" style="background-color:lavenderblush;">
            <div>
              <asp:Label ID="Label13" runat="server" Text="Datos Institucionales" Font-Bold="True" Font-Underline="True"></asp:Label>
              
            </div>
            <div>
              <asp:Label ID="Label33" runat="server" Text="Provincia:" Font-Bold="True"></asp:Label>
              <asp:Label ID="Lb_dainstitucionales_provincia" runat="server" Text="Santiago del Estero"></asp:Label>
            </div>
            <div>
              <asp:Label ID="Label34" runat="server" Text="Institución:" Font-Bold="True"></asp:Label>
              <asp:Label ID="Lb_dainstitucionales_institucion" runat="server" Text="TAC"></asp:Label>
            </div>
            <div>
              <asp:Label ID="Label35" runat="server" Text="Instructor:" Font-Bold="True"></asp:Label>
              <asp:Label ID="Lb_dainstitucionales_instructor" runat="server" Text="Gomez Omil, Mariano"></asp:Label>
            </div>
            <div>
              <asp:Label ID="Label36" runat="server" Text="Graduación:" Font-Bold="True"></asp:Label>
              <asp:Label ID="Lb_dainstitucionales_graduacion" runat="server" Text="Blanco"></asp:Label>
            </div>
            <div>
              <asp:Label ID="Label37" runat="server" Text="Estado:" Font-Bold="True"></asp:Label>
              <asp:Label ID="Lb_dainstitucionales_estado" runat="server" Text="Activo"></asp:Label>
            </div>
    
    
    
    
    
    
    <%--<div class="card" style="font-size: small">
            <div class="card-header">
              <h3 class="card-title">Datos personales</h3>

              <div class="card-tools">
                <button type="button" class="btn btn-tool" data-widget="collapse"><i class="fa fa-minus"></i>
                </button>
              </div>
            </div>
            <div class="card-body p-0" style="display: block;">
              <!--ul class="nav nav-pills flex-column">
                <li class="nav-item active">
                  <a href="#" class="nav-link">
                    <i class="fa fa-inbox"></i> Inbox
                    <span class="badge bg-primary float-right">12</span>
                  </a>
                </li>
                <li class="nav-item">
                  <a href="#" class="nav-link">
                    <i class="fa fa-envelope-o"></i> Sent
                  </a>
                </li>
                <li class="nav-item">
                  <a href="#" class="nav-link">
                    <i class="fa fa-file-text-o"></i> Drafts
                  </a>
                </li>
                <li class="nav-item">
                  <a href="#" class="nav-link">
                    <i class="fa fa-filter"></i> Junk
                    <span class="badge bg-warning float-right">65</span>
                  </a>
                </li>
                <li class="nav-item">
                  <a href="#" class="nav-link">
                    <i class="fa fa-trash-o"></i> Trash
                  </a>
                </li>
              </ul-->

              <div>
                    <asp:Label ID="Label13" runat="server" Text="Dni:" Font-Bold="True"></asp:Label>
                    <asp:Label ID="Label14" runat="server" Text="326547904"></asp:Label>
                </div>
                <div>
                    <asp:Label ID="Label15" runat="server" Text="Fecha de nacimiento:" Font-Bold="True"></asp:Label>
                    <asp:Label ID="Label16" runat="server" Text="22/01/1987"></asp:Label>
                </div>
                <div>
                    <asp:Label ID="Label17" runat="server" Text="Tel:" Font-Bold="True"></asp:Label>
                    <asp:Label ID="Label18" runat="server" Text="03854212484"></asp:Label>
                </div>
                <div>
                    <asp:Label ID="Label19" runat="server" Text="Correo:" Font-Bold="True"></asp:Label>
                    <asp:Label ID="Label20" runat="server" Text="pmchocolonea@hotmail.com"></asp:Label>
                </div>
                <div>
                    <asp:Label ID="Label21" runat="server" Text="Dir:" Font-Bold="True"></asp:Label>
                    <asp:Label ID="Label22" runat="server" Text="9 de julio 123"></asp:Label>
                </div>
                <div>
                    <asp:Label ID="Label23" runat="server" Text="Provincia:" Font-Bold="True"></asp:Label>
                    <asp:Label ID="Label24" runat="server" Text="Sgo del estero"></asp:Label>
                </div>
                <div>
                    <asp:Label ID="Label25" runat="server" Text="Ciudad:" Font-Bold="True"></asp:Label>
                    <asp:Label ID="Label26" runat="server" Text="La Banda"></asp:Label>
                </div>
                <div>
                    <asp:Label ID="Label27" runat="server" Text="Nacionalidad:" Font-Bold="True"></asp:Label>
                    <asp:Label ID="Label28" runat="server" Text="Argentino"></asp:Label>
                </div>
                <div>
                    <asp:Label ID="Label29" runat="server" Text="Estado civil:" Font-Bold="True"></asp:Label>
                    <asp:Label ID="Label30" runat="server" Text="Soltero"></asp:Label>
                </div>
                <div>
                    <asp:Label ID="Label31" runat="server" Text="Profesión:" Font-Bold="True"></asp:Label>
                    <asp:Label ID="Label32" runat="server" Text="Estudiante"></asp:Label>
                </div>



            </div>
            <!-- /.card-body -->
            
          </div>--%>
    
    </div>
<%--    <div class="col-sm-6" style="background-color:lavender;">.col-sm-6</div>
--%>


  </div>




                





              </div>
            </div>
            
        </asp:Panel>
        <asp:ModalPopupExtender ID="ModalPopupExtender_DApersonales" runat="server" PopupControlID="Panel_datospersonales" CancelControlID="btn_cerrar_poup" TargetControlID="HiddenField_entrar" BackgroundCssClass="modalBackground">
        </asp:ModalPopupExtender>
        </div>
        
        <div id="popupmsj" runat="server"> 
        <asp:HiddenField ID="HiddenField_msj_no_alumnos" runat="server" />
        <asp:Panel ID="Panel_msj_no_alumnos" runat="server">
        <div class="card card-primary">
            <div class="card-header">
                <h3 class="card-title">Error!</h3>
            </div>
            <form role="form">
              <div class="card-body"> 
              <div class="row">
              <div align="center">
                    <asp:Label ID="Label15" runat="server" Text="No hay alumnos disponibles!"></asp:Label>
                    &nbsp;
              </div>
              <div align="center">
                    <asp:Button ID="Btb_msj_no_alumnos" runat="server" Text="OK" />
              </div>  
              </div>
              </div>
            </form>
            </div>        
        
        </asp:Panel>

            <asp:ModalPopupExtender ID="ModalPopupExtender_msj_no_alumnos" runat="server" 
            CancelControlID="Btb_msj_no_alumnos" TargetControlID="HiddenField_msj_no_alumnos" 
            PopupControlID="Panel_msj_no_alumnos" BackgroundCssClass="modalBackground">
            </asp:ModalPopupExtender>
        </div>
               


        <div id="popupMsjError" runat="server"> 
    <asp:HiddenField ID="HiddenField_msj_no_categorias" runat="server" />
        <asp:Panel ID="Panel_msj_no_categorias" runat="server">
        <div class="card card-primary">
            <div class="card-header">
                <h3 class="card-title">Error!</h3>
            </div>
            <form role="form">
              <div class="card-body"> 
              <div class="row">
              <div align="center">
                    <asp:Label ID="Label12" runat="server" Text="Seleccione al menos una categoría!"></asp:Label>
                    &nbsp;
              </div>
              <div align="center">
                    <asp:Button ID="Btb_msj_no_categoria" runat="server" Text="OK" />
              </div>  
              </div>
              </div>
            </form>
            </div>        
        
        </asp:Panel>

    
            <asp:ModalPopupExtender ID="ModalPopupExtender_error_cat" runat="server" CancelControlID="Btb_msj_no_categoria" TargetControlID="HiddenField_msj_no_categorias" 
            PopupControlID="Panel_msj_no_categorias" BackgroundCssClass="modalBackground">
    </asp:ModalPopupExtender>

    </div>

        <asp:UpdateProgress ID="UpdateProgress1" runat="server">

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
                


        <div id="popupMsjGuardado" runat="server">
    <asp:HiddenField ID="HiddenField_msj" runat="server" />
        <asp:Panel ID="Panel1" runat="server" >
              
            <div class="card card-success">
            <div class="card-header">
                <h3 class="card-title">Inscripciones</h3>
            </div>
            <form role="form">
              <div class="card-body"> 
                <div class="row">
                    <div align="center">
                        <asp:Label ID="Label16" runat="server" Text="Inscripciones registradas!"></asp:Label>
                        &nbsp;
                    </div>
                </div>
              </div>
            </form>  
            <div align="center">
                    <asp:Button ID="Btn_guardado_ok" runat="server" Text="OK" CssClass="btn btn-success"  />
              </div> 
              <div>
                 &nbsp;
              </div>             
            </div> 
        </asp:Panel>
        
<asp:ModalPopupExtender ID="ModalPopupExtender_guardado" runat="server" TargetControlID="HiddenField_msj" PopupControlID="Panel1"  BackgroundCssClass="modalBackground" Drag="true">
</asp:ModalPopupExtender>
    
    </div>

    <div id="div_Modal_err" runat="server">
    <asp:HiddenField ID="HiddenField_Err" runat="server" />
     <asp:Panel ID="Panel_Modal_Err" runat="server" >
     
      <div class="card card-danger">
            <div class="card-header">
                <h3 class="card-title">Inscripciones</h3>
            </div>
            <form role="form">
              <div class="card-body"> 
                <div class="row">
                    <div align="center">
                        <asp:Label ID="lbl_Modal_err" runat="server" Text="Error General"></asp:Label>
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
    
    
    </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="GridView1" EventName="RowCommand" />
            <asp:AsyncPostBackTrigger ControlID="GridView1" EventName="PageIndexChanged" />
            <asp:AsyncPostBackTrigger ControlID="GridView1" EventName="PageIndexChanging" />
        </Triggers>
     </asp:UpdatePanel>
               
              
              
</asp:Content>
