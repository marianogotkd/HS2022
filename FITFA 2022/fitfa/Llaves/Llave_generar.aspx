<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/MasterPage.Master" CodeBehind="Llave_generar.aspx.vb" Inherits="fitfa.Llave_generar" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>
<asp:UpdatePanel ID="UP1" runat="server">
<ContentTemplate>
<div class="card card-primary">
                           
              <div class="card-header">
                <h3 class="card-title">Generación de llaves - Evento:<asp:Label ID="Lb_evento" runat="server" Text="XXX - TITULO EVENTO"></asp:Label>      </h3>
                  <asp:HiddenField ID="HF_evento_id" runat="server" />
                  <asp:HiddenField ID="HF_area_id" runat="server" />
              </div>
              <form role="form">
              <div class="card-body"> 
                    
              <div align="center" style="background-color: #C0C0C0">
              <asp:Label ID="Label15" runat="server" Text="Datos del Torneo" Font-Bold="True"></asp:Label>      
              </div>
              
              <div align="left">
                    <asp:Label ID="Fechadelevento" runat="server" Text="Fecha del evento:" Font-Bold="True"></asp:Label>
                    <asp:Label ID="Lb_fecha" runat="server" Text="00/00/0000"></asp:Label>
              </div>  
              
              <div align="left">
                    <asp:Label ID="Fechadecierre" runat="server" Text="Fecha de cierre de inscripción" 
                        Font-Bold="True"></asp:Label>
                    <asp:Label ID="Lb_fecha_cierre" runat="server" Text="00/00/0000"></asp:Label>
              </div>  
              
              <div align="center" style="background-color: #C0C0C0">
              <asp:Label ID="Label2" runat="server" Text="Inscripciones en categorías" Font-Bold="True"></asp:Label>      
              </div>

              <div align="center">
               <div class="row">
                      
                       <div class="col-sm-12">
                       <table class="w-100">
                                  <tr>
                                      <td>
                                          <asp:Label ID="Label16" runat="server" Text="Seleccione modalidad y categoría:"></asp:Label>
                                          <asp:DropDownList ID="DropDown_modalidad" runat="server" AutoPostBack="True">
                                              <asp:ListItem Selected="True">Lucha</asp:ListItem>
                                              <asp:ListItem>Forma</asp:ListItem>
                                          </asp:DropDownList>
                                          <asp:DropDownList ID="DropDown_categoria" runat="server" Width="529px" AutoPostBack="True">
                                          </asp:DropDownList>
                                          <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/img/lupa.png" 
                                              Width="30px" />
                                      </td>
                                  </tr>
                                  <tr>
                                      <td>
                                          <asp:Label ID="Label19" runat="server" ForeColor="#00CC66" 
                                              Text="Nota: las categoria listadas son solamente las que tienen inscriptos"></asp:Label>
                                          <br />
                                          <asp:Label ID="Label6" runat="server" Text="TOTAL DE INSCRIPTOS:"></asp:Label>
                                          <asp:Label ID="LB_INSCRIPTOS" runat="server" Text=""></asp:Label>
                                      </td>
                                  </tr>
                              </table>
                       
                       </div>
                      
                      
               </div> 
                       
              
              </div>
              
              <div class="card-body table-responsive p-0">
              <asp:Label ID="Label17" runat="server" Font-Underline="True" 
                                              Text="Listado de inscriptos en:"></asp:Label>
                                          <asp:Label ID="label_catseleccionada" runat="server" 
                                              Text="Categoría seleccionada"></asp:Label>
              <asp:GridView ID="GridView1" class="table table-hover" runat="server" 
                      AutoGenerateColumns="False" AllowSorting="True" BorderColor="Black">
                                              <Columns>
                                                  <asp:TemplateField>
                                                      <ItemTemplate>
                                                          <asp:CheckBox ID="CheckBox_item" runat="server" />
                                                      </ItemTemplate>
                                                      <HeaderTemplate>
                                                          <asp:CheckBox ID="CheckBox_all" runat="server" onclick = "checkAll(this);" />
                                                      </HeaderTemplate>
                                                      <HeaderStyle Width="10px" />
                                                  </asp:TemplateField>
                                                  <asp:BoundField DataField="ID" HeaderText="ID">
                                                  <HeaderStyle ForeColor="#0099FF" Width="10px" />
                                                  </asp:BoundField>
                                                  <asp:BoundField DataField="dni" HeaderText="Dni">
                                                  <HeaderStyle ForeColor="#0099FF" Width="100px" />
                                                  </asp:BoundField>
                                                  <asp:BoundField DataField="ApellidoyNombre" HeaderText="Apellido y Nombre">
                                                  <HeaderStyle ForeColor="#0099FF" Width="300px" />
                                                  </asp:BoundField>
                                                  <asp:BoundField DataField="Institucion" HeaderText="Institución">
                                                  <HeaderStyle ForeColor="#0099FF" />
                                                  </asp:BoundField>
                                                  <asp:BoundField DataField="Institucion_abreviatura" HeaderText="Abreviatura">
                                                  <HeaderStyle ForeColor="#0099FF" />
                                                  </asp:BoundField>
                                                  <asp:BoundField DataField="Provincia" HeaderText="Provincia">
                                                  <HeaderStyle ForeColor="#0099FF" />
                                                  </asp:BoundField>
                                                  <asp:BoundField DataField="Peso" HeaderText="Peso">
                                                  <HeaderStyle ForeColor="#0099FF" />
                                                  </asp:BoundField>
                                                  <asp:BoundField DataField="instructor_id" HeaderText="Instructor_id" />
                                                  <asp:BoundField DataField="instructor" HeaderText="Instructor" />
                                                  <asp:BoundField DataField="Inscripcion_id" HeaderText="Inscripcion_id" />
                                              </Columns>
                                          </asp:GridView>
                                          <button ID="Button_eliminar_inscripto2" runat="server" class="btn btn-primary" 
                                              data-target="#modal_eliminar_inscripto" data-toggle="modal" type="button">
                                              Eliminar inscripto...
                                          </button>

                                          &nbsp;
                                          <button ID="Button_addkey" runat="server" class="btn btn-primary" 
                                              data-target="#Mod_keyadd" data-toggle="modal" type="button">
                                              Generar llave ...
                                          </button>

                                          &nbsp;<asp:Button ID="Button2" runat="server" 
                      class="btn btn-primary" Text="Generar llave" Visible="False" />
                                          &nbsp;<br />
                                          <asp:Label ID="Label20" runat="server" 
                      Font-Size="Larger" Font-Underline="True" 
                                              ForeColor="#0066FF" Text="Llaves generadas" 
                      Visible="False"></asp:Label>
                                              <asp:GridView ID="GridView2" 
                      class="table table-hover" runat="server" AutoGenerateColumns="False" 
                      AllowSorting="True" BorderColor="Black" Visible="False"
                                          >
                                              <Columns>
                                                  <asp:TemplateField>
                                                      <ItemTemplate>
                                                          <asp:CheckBox ID="CheckBox_item1" runat="server" />
                                                      </ItemTemplate>
                                                      <HeaderTemplate>
                                                          <asp:CheckBox ID="CheckBox_all1" runat="server" onclick = "checkAll(this);" />
                                                      </HeaderTemplate>
                                                  </asp:TemplateField>
                                                  <asp:BoundField DataField="ID" HeaderText="ID">
                                                  <HeaderStyle ForeColor="#0099FF" />
                                                  </asp:BoundField>
                                                  <asp:BoundField DataField="modalidad" HeaderText="Modalidad">
                                                  <HeaderStyle ForeColor="#0099FF" />
                                                  </asp:BoundField>
                                                  <asp:BoundField DataField="categoria" HeaderText="Categoría">
                                                  <HeaderStyle ForeColor="#0099FF" Width="500px" />
                                                  </asp:BoundField>
                                                  <asp:BoundField DataField="inscriptos" HeaderText="Inscriptos">
                                                  <HeaderStyle ForeColor="#0099FF" HorizontalAlign="Center" 
                                                      VerticalAlign="Middle" />
                                                  <ItemStyle HorizontalAlign="Center" />
                                                  </asp:BoundField>
                                                  <asp:TemplateField HeaderText="Ver">
                                                      <ItemTemplate>
                                                          <asp:ImageButton ID="ImageButton3" runat="server" CausesValidation="False" 
                                                              CommandName="ID" Height="30px" ImageAlign="AbsMiddle" ImageUrl="~/img/lupa.png" 
                                                              ToolTip="Ver inscriptos" Width="30px" CommandArgument='<%# Eval("ID") %>' />
                                                      </ItemTemplate>
                                                      <HeaderStyle ForeColor="#0099FF" />
                                                  </asp:TemplateField>
                                              </Columns>
                                          </asp:GridView>
                                          <button ID="btn_Examinar" runat="server" class="btn btn-primary" 
                                              data-target="#exampleModal" data-toggle="modal" 
                      type="button" visible="False">
                                              Eliminar llave...
                                          </button>
              

              </div>
              
              </div>
              
              
              </form>

    </div>
        <div class="modal fade" id="modal_generar_llave" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
                                                    <div class="modal-dialog modal-lg" role="document">
                                                    <div class="modal-content">
                                                      <div class="modal-header">
                                                        <h5 class="modal-title" id="H2">Generación de llave</h5>
                                                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                                          <span aria-hidden="true">&times;</span>
                                                        </button>
                                                      </div>
                                                      <div class="modal-body">
                                                        <div class="file-loading">
                                                          <%--<input id="FileUpload1" name="FileUpload1" multiple type="file" runat="server">--%>
                                                            <%--<asp:FileUpload ID="FileUpload1" runat="server" />--%>
                                                       </div>
                                                      </div>
                                                      <div class="modal-footer">
                                                        <button type="button" class="btn btn-secondary" data-dismiss="modal">Cancelar</button>
                                                        <button type="button" class="btn btn-primary" id="Gen_llave" runat="server" rutitle="Your custom upload logic" >Aceptar</button>
                                                      </div>
                                                    </div>
              </div>
                                              </div>
            
            
            <div class="modal fade" id="exampleModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
              <div class="modal-dialog modal-lg" role="document">
                <div class="modal-content">
                  <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalLabel">¿Esta seguro de eliminar la llave seleccionada?</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                      <span aria-hidden="true">&times;</span>
                    </button>
                  </div>
                  <div class="modal-body">
                    <div class="file-loading">
                      <%--<input id="FileUpload1" name="FileUpload1" multiple type="file" runat="server">--%>
                        <%--<asp:FileUpload ID="FileUpload1" runat="server" />--%>
                   </div>
                    <div id="kartik-file-errors"></div>
                  </div>
                  <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Cancelar</button>
                    <button type="button" class="btn btn-primary" id="Eliminar_llave" runat="server" rutitle="Your custom upload logic" >Aceptar</button>
                  </div>
                </div>
              </div>
            </div>


            <%--pop up del boton eliminar incripto 2---------------------INICIO-----------------------------------------------------------------%>
            <div class="modal fade" id="modal_eliminar_inscripto" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
              <div class="modal-dialog modal-lg" role="document">
                <div class="modal-content">
                  <div class="modal-header">
                    <h5 class="modal-title" id="H1">¿Esta seguro de eliminar la inscripción seleccionada?</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                      <span aria-hidden="true">&times;</span>
                    </button>
                  </div>
                  <div class="modal-body">
                    <div class="file-loading">
                      <%--<input id="FileUpload1" name="FileUpload1" multiple type="file" runat="server">--%>
                        <%--<asp:FileUpload ID="FileUpload1" runat="server" />--%>
                   </div>
                    <div id="Div2"></div>
                  </div>
                  <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Cancelar</button>
                    <button type="button" class="btn btn-primary" id="Eliminar_inscripto" runat="server" rutitle="Your custom upload logic" >Aceptar</button>
                  </div>
                </div>
              </div>
            </div>
            <%--pop up del boton eliminar incripto 2---------------------FIN-----------------------------------------------------------------%>
        

           <div class="modal fade" id="Mod_keyadd" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
              <div class="modal-dialog modal-lg" role="document">
                <div class="modal-content">
                  <div class="modal-header">
                    <h5 class="modal-title" id="H3">¿Quiere agregar llave nueva?</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                      <span aria-hidden="true">&times;</span>
                    </button>
                  </div>
                  <div class="modal-body">
                    <div class="file-loading">
                      <%--<input id="FileUpload1" name="FileUpload1" multiple type="file" runat="server">--%>
                        <%--<asp:FileUpload ID="FileUpload1" runat="server" />--%>
                   </div>
                                                        <div id="Div3">
                                                                <table class="w-200">
                                                                    <tr>
                                                                        <td>
                                                                            <asp:Label ID="Label3" runat="server" Text="Indique la prioridad:" 
                                                                                Font-Bold="True" ForeColor="#3333CC"></asp:Label>
                                                                            <asp:DropDownList ID="DropDownList1" runat="server">
                                                                                <asp:ListItem Selected="True">Random</asp:ListItem>
                                                                                <%--<asp:ListItem>Instructor</asp:ListItem>--%>
                                                                            </asp:DropDownList>
                                                                        </td>
            
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                        <asp:Label ID="Label5" runat="server" Text="Seleccione Area de trabajo:" 
                                                                                Font-Bold="True" ForeColor="#3333CC"></asp:Label>
                                                                            <asp:DropDownList ID="DropDownList_areas" runat="server" Width="200px">
                                                                            </asp:DropDownList>
                                                                            
                                                                            &nbsp;</td>
                                                                        <td>
                                                                            &nbsp;</td>
                                                                        <td>
                                                                            &nbsp;</td>
                                                                    </tr>
                                                                </table>
                    
                                                        </div>

                    <div id="Div4"></div>
                  </div>
                  <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Cancelar</button>
                    <button type="button" class="btn btn-primary" id="add_key" runat="server" rutitle="Your custom upload logic" >Aceptar</button>
                  </div>
                </div>
              </div>
            </div>


        
        <div id="div_modalllaveOK" runat="server">
                                <asp:HiddenField ID="HiddenField_msj" runat="server" />
                                    <asp:Panel ID="Panel1" runat="server" >
              
                                        <div class="card card-success">
                                        <div class="card-header">
                                            <h3 class="card-title">Llave</h3>
                                        </div>
                                        <form role="form">
                                          <div class="card-body"> 
                                            <div class="row">
                                                <div align="center">
                                                    <asp:Label ID="Label1" runat="server" Text="La llave se generó exitosamente."></asp:Label>
                                                    &nbsp;
                                                </div>
                                            </div>
                                          </div>
                                        </form>  
                                        <div align="center">
                                                <asp:Button ID="llave_ok" runat="server" Text="OK" CssClass="btn btn-success"  />
                                          </div> 
                                          <div>
                                             &nbsp;
                                          </div>             
                                        </div> 
                                    </asp:Panel>
        
                            <asp:ModalPopupExtender ID="Modal_llaveOK" runat="server" TargetControlID="HiddenField_msj" PopupControlID="Panel1" CancelControlID="llave_ok" BackgroundCssClass="modalBackground">
                            </asp:ModalPopupExtender>
    
        </div>
         
         <div id="div_modalllaveError" runat="server">
         <asp:HiddenField ID="HiddenField_msj2" runat="server" />
         <asp:Panel ID="Panel2" runat="server" >
              
                                        <div class="card card-danger">
                                        <div class="card-header">
                                            <h3 class="card-title">Llave</h3>
                                        </div>
                                        <form role="form">
                                          <div class="card-body"> 
                                            <div class="row">
                                                <div align="center">
                                                    <asp:Label ID="Label4" runat="server" Text="Error, debe seleccionar al menos 2 inscriptos para generar una llave."></asp:Label>
                                                    &nbsp;
                                                </div>
                                            </div>
                                          </div>
                                        </form>  
                                        <div align="center">
                                                <asp:Button ID="Button_ok" runat="server" Text="OK" CssClass="btn btn-danger"  />
                                          </div> 
                                          <div>
                                             &nbsp;
                                          </div>             
                                        </div> 
                                    </asp:Panel>
             <asp:ModalPopupExtender ID="Modal_llaveError" runat="server" TargetControlID="HiddenField_msj2" PopupControlID="Panel2" CancelControlID="Button_ok" BackgroundCssClass="modalBackground">
             </asp:ModalPopupExtender>
         </div>


    



</ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="DropDown_modalidad" 
            EventName="SelectedIndexChanged" />
        <asp:PostBackTrigger ControlID="Eliminar_llave" />   <%--IMPORTANTE , SINO NO SE OCULTA EL MODAL DESPUES DE ELIMINAR LA LLAVE--%>
        <asp:PostBackTrigger ControlID="Eliminar_inscripto" />   <%--IMPORTANTE , SINO NO SE OCULTA EL MODAL DESPUES DE ELIMINAR LA INSCRIPCION--%>
        <asp:PostBackTrigger ControlID="add_key" /> <%--IMPORTANTE , SINO NO SE OCULTA EL MODAL DESPUES DE ELIMINAR LA INSCRIPCION--%>
        <asp:AsyncPostBackTrigger ControlID="DropDown_categoria" 
            EventName="SelectedIndexChanged" />
        <asp:AsyncPostBackTrigger ControlID="DropDownList_areas" 
            EventName="SelectedIndexChanged" />
    </Triggers>
</asp:UpdatePanel>





        <asp:UpdateProgress ID="UpdateProgress1" runat="server" 
            AssociatedUpdatePanelID="UP1">
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



                
        
<script type = "text/javascript">

    function checkAll(objRef) {

        var GridView = objRef.parentNode.parentNode.parentNode;

        var inputList = GridView.getElementsByTagName("input");

        for (var i = 0; i < inputList.length; i++) {

            //Get the Cell To find out ColumnIndex

            var row = inputList[i].parentNode.parentNode;

            if (inputList[i].type == "checkbox" && objRef != inputList[i]) {

                if (objRef.checked) {

                    //If the header checkbox is checked

                    //check all checkboxes

                    //and highlight all rows

                    //row.style.backgroundColor = "aqua"; esta linea le pone color a la fila

                    inputList[i].checked = true;

                }

                else {

                    //If the header checkbox is checked

                    //uncheck all checkboxes

                    //and change rowcolor back to original

                    if (row.rowIndex % 2 == 0) {

                        //Alternating Row Color

                        //row.style.backgroundColor = "#C2D69B"; esta linea le pone color  a la fila

                    }

                    else {

                        //row.style.backgroundColor = "white"; esta linea le pone color a la fila

                    }

                    inputList[i].checked = false;

                }

            }

        }

    }

</script> 



</asp:Content>
