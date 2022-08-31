<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/MasterPage.Master" CodeBehind="Evento_datos.aspx.vb" Inherits="fitfa.Evento_datos" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style2
        {
            width: 413px;
        }
        .modalBackground
        {
            background-color:black;
            filter:alpha(opacity=99) !important;
            opacity:0.6 ! important;
            z-index:20;
            }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>
<div class="card card-primary">
                
                           
              <div class="card-header">
                <h3 class="card-title">Inscripcion a evento: <asp:Label ID="Lb_evento" runat="server" Text="XXX - TITULO EVENTO"></asp:Label>      </h3>
                  
              </div>
              <form role="form">
              <div class="card-body"> 
                    
              <div align="center" style="background-color: #C0C0C0">
              <asp:Label ID="Label15" runat="server" Text="DATOS PERSONALES" Font-Bold="True"></asp:Label>      
              </div>
              
              <div align="left">
                    <asp:Label ID="Label16" runat="server" Text="DNI:" Font-Bold="True"></asp:Label>
                    <asp:Label ID="Lb_dni" runat="server" Text="32547904"></asp:Label>
              </div>  
              
              <div align="left">
                    <asp:Label ID="Label18" runat="server" Text="Apellido y Nombre:" 
                        Font-Bold="True"></asp:Label>
                    <asp:Label ID="Lb_apenombre" runat="server" Text="Chocolonea, Pablo Maximiliano"></asp:Label>
              </div>  

              <div align="left">
                    <asp:Label ID="Label20" runat="server" Text="Sexo:" Font-Bold="True"></asp:Label>
                    <asp:Label ID="Lb_sexo" runat="server" Text="Masculino"></asp:Label>
              </div>  
              
              <div align="left">
                    <asp:Label ID="Label22" runat="server" Text="Edad:" Font-Bold="True"></asp:Label>
                    <asp:Label ID="Lb_edad" runat="server" Text="31"></asp:Label>
              </div>  

              <div align="center" style="background-color: #C0C0C0">
              <asp:Label ID="Label2" runat="server" Text="DATOS INSTITUCIONALES" Font-Bold="True"></asp:Label>      
              </div>

              <div align="left">
                    <asp:Label ID="Label7" runat="server" Text="Provincia:" Font-Bold="True"></asp:Label>
                    <asp:Label ID="Lb_provincia" runat="server" Text="Santiago del Estero"></asp:Label>
              </div>
              <div align="left">
                    <asp:Label ID="Label9" runat="server" Text="Institución:" Font-Bold="True"></asp:Label>
                    <asp:Label ID="Lb_institucion" runat="server" Text="ANT"></asp:Label>
              </div>    

              
              
              <div align="left">
                    <asp:Label ID="Label3" runat="server" Text="Graduación:" Font-Bold="True"></asp:Label>
                  <asp:DropDownList ID="DropDownList_graduacion" runat="server" Enabled="False">
                  </asp:DropDownList>
              </div>
                

              <div align="left">
                    <asp:Label ID="Label4" runat="server" Text="Instructor:" Font-Bold="True"></asp:Label>
                    <asp:Label ID="Lb_instructor" runat="server" Text="Gomez, Omil Mariano "></asp:Label>
              </div> 
               
              <div id="seccion_competencia" runat="server">
              <div align="center" style="background-color: #C0C0C0">
              <asp:Label ID="Label6" runat="server" Text="DATOS DE COMPETENCIA" Font-Bold="True"></asp:Label>      
              </div>

              <div align="left">
                    <table class="w-100">
                        <tr>
                            <td class="style2">
                                <asp:Label ID="Label11" runat="server" Font-Bold="True" Text="Peso:"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txt_peso" runat="server" MaxLength="5" 
                                    ToolTip="ejemplo(75,50 kg)" Height="25px" Width="70px"></asp:TextBox>
                                <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" 
                                    TargetControlID="txt_peso" ValidChars="0123456789.">
                                </asp:FilteredTextBoxExtender>
                                
                            </td>
                        </tr>
                        <tr>
                            <td class="style2">
                                <asp:Label ID="Label12" runat="server" Font-Bold="True" Text="Compite en Lucha:"></asp:Label>
                            </td>
                            <td>
                                <asp:RadioButton ID="RadioButton_lucha_si" runat="server" Text="Si" 
                                    AutoPostBack="True" />
                                <asp:RadioButton ID="RadioButton_lucha_no" runat="server" Checked="True" 
                                    Text="No" AutoPostBack="True" />
                            </td>
                        </tr>
                        <tr>
                            <td class="style2">
                                <asp:Label ID="Label13" runat="server" Font-Bold="True" Text="Compite en Formas:"></asp:Label></td>
                            <td>
                                <asp:RadioButton ID="RadioButton_formas_si" runat="server" Text="Si" 
                                    AutoPostBack="True" />
                                <asp:RadioButton ID="RadioButton_formas_no" runat="server" Checked="True" 
                                    Text="No" AutoPostBack="True" />
                            </td>
                        </tr>
                        <tr>
                            <td class="style2">
                                <asp:Label ID="Label14" runat="server" Font-Bold="True" Text="Compite en Rotura de Poder:"></asp:Label></td>
                            <td>
                                <asp:RadioButton ID="RadioButton_poder_si" runat="server" Text="Si" 
                                    AutoPostBack="True" />
                                <asp:RadioButton ID="RadioButton_poder_no" runat="server" Checked="True" 
                                    Text="No" AutoPostBack="True" />
                            </td>
                        </tr>
                        <tr>
                            <td class="style2">
                                <asp:Label ID="Label17" runat="server" Font-Bold="True" Text="Compite en Rotura con Técnica Especial:"></asp:Label></td>
                            <td>
                                <asp:RadioButton ID="RadioButton_tecnica_si" runat="server" Text="Si" 
                                    AutoPostBack="True" />
                                <asp:RadioButton ID="RadioButton_tecnica_no" runat="server" Checked="True" 
                                    Text="No" AutoPostBack="True" />
                            </td>
                        </tr>
                    </table>
                    
              </div> 
              </div>


              <div id="seccion_examen" runat="server" visible=false >
              <div align="center" style="background-color: #C0C0C0">
              <asp:Label ID="Label_datos_competencia" runat="server" Text="DATOS DEL EXAMEN" Font-Bold="True"></asp:Label>      
              </div>
              <div align="left">
                    <table class="w-100">
                        <tr>
                            <td class="style2">
                                <asp:Label ID="Label24" runat="server" Font-Bold="True" Text="Examen:"></asp:Label>
                                &nbsp;<asp:Label ID="Label_nombre_examen" runat="server" Font-Bold="True" Text=""></asp:Label>
                            </td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style2">
                                <asp:Label ID="Label10" runat="server" Font-Bold="True" Text="Dirección:"></asp:Label>
                                &nbsp;<asp:Label ID="Label_direccion_examen" runat="server" Font-Bold="True" Text=""></asp:Label>
                            </td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        
                        <tr>
                            <td class="style2">
                                <asp:Label ID="Label25" runat="server" Font-Bold="True" Text="Fecha del examen:"></asp:Label>
                                &nbsp;<asp:Label ID="Label_fecha_examen" runat="server" Font-Bold="True" Text=""></asp:Label>
                            </td>
                            <td>
                                &nbsp;</td>
                        </tr>

                        <tr>
                            <td class="style2">
                                <asp:Label ID="Label5" runat="server" Font-Bold="True" Text="Seleccione turno para el examen:"></asp:Label>
                                &nbsp;<asp:DropDownList ID="DropDownList_examen_turno" runat="server" Enabled="True">
                                </asp:DropDownList>
                            </td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        
                    </table>
                    
              </div>
              
              </div>
              
              
              <div align="left">
              <%--<button type="submit" class="btn btn-primary" runat="server" id="btn_guardar">Confirmar</button>--%>
                  <br />
                  
              <button type="submit" class="btn btn-primary" runat="server" id="Btn_confirmar_submit">Confirmar Inscripcion</button>
              
              </div>

              <div>
              <asp:Image ID="QrImagen" runat="server" />
              </div>
                  

              </div>
              </form>


              <div class="card-footer">
                  <asp:Label ID="Label1" runat="server" 
                      Text="Seleccione la categoría en la que desea participar"></asp:Label>
              </div>

    </div>
        
    <div id="popupMsjError" runat="server"> 
    <asp:HiddenField ID="HiddenField_msj_no_categorias" runat="server" />
        <asp:Panel ID="Panel_msj_no_categorias" runat="server">
        
              <div class="card card-danger">
            <div class="card-header">
                <h3 class="card-title">Inscripciones</h3>
            </div>
            <form role="form">
              <div class="card-body"> 
                <div class="row">
                    <div align="center">
                        <asp:Label ID="lbl_Modal_err" runat="server" Text="Error, Seleccione al menos una categoría"></asp:Label>
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
        
        </asp:Panel>

    <asp:ModalPopupExtender ID="ModalPopupExtender_error_cat" runat="server" CancelControlID="Btn_Modal_err" TargetControlID="HiddenField_msj_no_categorias" 
            PopupControlID="Panel_msj_no_categorias" BackgroundCssClass="modalBackground">
    </asp:ModalPopupExtender>

    </div>
    
  <div id="popupMsjGuardado" runat="server"> 
        <asp:HiddenField ID="HiddenField_msj_guardado" runat="server"/>
      <asp:Panel ID="Panel_guardado" runat="server" CssClass="panel panel-primary">
      <div class="card card-success">
            <div class="card-header">
                <h3 class="card-title">Inscripciones</h3>
            </div>
            <form role="form">
              <div class="card-body"> 
                <div class="row">
                    <div align="center">
                        <asp:Label ID="Label8" runat="server" Text="Inscripción registrada!"></asp:Label>
                        &nbsp;
                    </div>
                </div>
              </div>
            </form>  
            <div align="center">
                    <asp:Button ID="Btb_ok_inscripcion" runat="server" Text="OK" CssClass="btn btn-success"  />
              </div> 
              <div>
                 &nbsp;
              </div>             
            </div> 
      </asp:Panel>
        <asp:ModalPopupExtender ID="ModalPopupExtender_guardado" runat="server" TargetControlID="HiddenField_msj_guardado" 
            PopupControlID="Panel_guardado" BackgroundCssClass="modalBackground" Drag="true">
        </asp:ModalPopupExtender>    
        
        
        <%--<asp:UpdatePanel ID="UPanel_msj_guardado" runat="server">
        <ContentTemplate>
            <div class="card card-primary">
                    <div class="card-header">
                        <h3 class="card-title">Inscripcion!</h3>
                    </div>
                    <form role="form">
                      <div class="card-body"> 
                      <div class="row">
                      <div align="center">
                            <asp:Label ID="Label8" runat="server" Text="Registro exitoso!"></asp:Label>
                            &nbsp;
                      </div>
                      <div align="center">
                            <asp:Button ID="Btn_ok_guardado" runat="server" Text="OK" />
                          <asp:Button ID="BTN_MIAMI" runat="server" Text="MIAMEEEEE" />
                      </div>  
                      </div>
                      </div>
                    </form>
            </div>
         </ContentTemplate>
                    <Triggers>
                <asp:AsyncPostBackTrigger ControlID="BTN_MIAMI" EventName="Click" />
            </Triggers>
                </asp:UpdatePanel>--%>
     
    </div>


    <div id="popupMsjError_turno" runat="server"> 
    <asp:HiddenField ID="HiddenField_msj_no_turno" runat="server" />
    <asp:Panel ID="Panel_msj_no_turno" runat="server">
    <div class="card card-danger">
            <div class="card-header">
                <h3 class="card-title">Inscripciones</h3>
            </div>
            <form role="form">
              <div class="card-body"> 
                <div class="row">
                    <div align="center">
                        <asp:Label ID="lbl_Modal_err_turno" runat="server" Text="Error, no hay cupo para inscribirse en ese turno. Por favor seleccione otra opción."></asp:Label>
                        &nbsp;
                    </div>
                </div>
              </div>
            </form>  
            <div align="center">
                    <asp:Button ID="Btn_Modal_err_turno" runat="server" Text="OK" CssClass="btn btn-danger"  />
              </div> 
              <div>
                 &nbsp;
              </div>             
            </div>
    </asp:Panel>

    <asp:ModalPopupExtender ID="ModalPopupExtender_error_turno" runat="server" CancelControlID="Btn_Modal_err_turno" TargetControlID="HiddenField_msj_no_turno" 
            PopupControlID="Panel_msj_no_turno" BackgroundCssClass="modalBackground">
    </asp:ModalPopupExtender>

    </div>


</ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="RadioButton_lucha_si" 
            EventName="CheckedChanged" />
        <asp:AsyncPostBackTrigger ControlID="RadioButton_lucha_no" 
            EventName="CheckedChanged" />
        <asp:AsyncPostBackTrigger ControlID="RadioButton_formas_si" 
            EventName="CheckedChanged" />
        <asp:AsyncPostBackTrigger ControlID="RadioButton_formas_no" 
            EventName="CheckedChanged" />
        <asp:AsyncPostBackTrigger ControlID="RadioButton_poder_si" 
            EventName="CheckedChanged" />
        <asp:AsyncPostBackTrigger ControlID="RadioButton_poder_no" 
            EventName="CheckedChanged" />
        <asp:AsyncPostBackTrigger ControlID="RadioButton_tecnica_si" 
            EventName="CheckedChanged" />
        <asp:AsyncPostBackTrigger ControlID="RadioButton_tecnica_no" 
            EventName="CheckedChanged" />
    </Triggers>
</asp:UpdatePanel>


<asp:UpdateProgress ID="UpdateProgress1" runat="server" 
            AssociatedUpdatePanelID="UpdatePanel1">
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
