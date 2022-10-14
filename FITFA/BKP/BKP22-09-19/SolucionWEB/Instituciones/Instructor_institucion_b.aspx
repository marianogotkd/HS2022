<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/MasterPage.Master" CodeBehind="Instructor_institucion_b.aspx.vb" Inherits="fitfa.Instructor_institucion_b" %>

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
           <h3 class="card-title">Asignar institución a instructor</h3>
        </div>
        
        
        <form role="form">
            <div class="card-body">
            

            <div class="form-group">
                <asp:Label ID="Label1" runat="server" Text="Instructor:" Font-Bold="True" 
                    Font-Size="Medium" ForeColor="#3333CC"></asp:Label> 
                <asp:Label ID="Label_instructor" runat="server" Font-Bold="True" 
                    Font-Size="Medium"></asp:Label>            
            </div>
         
            <div class="form-group">
                <asp:Label ID="Label2" runat="server" Text="DNI:" Font-Bold="True" 
                    Font-Size="Medium" ForeColor="#3333CC"></asp:Label>
                <asp:Label ID="Label_dni"
                    runat="server" Font-Bold="True" Font-Size="Medium"></asp:Label>
            </div>
            
            <div class="row" style="background-color: #F3F3F3">
                  <div class="col-3" id="seccion_provincia" runat=server>
                    <asp:Label ID="Label3" runat="server" Text="Provincia:" Font-Bold="True" 
                          Font-Underline="True"></asp:Label>
                    <asp:DropDownList ID="DropDown_provincia" runat="server" AutoPostBack="True" 
                          Width="250px">
                    </asp:DropDownList>
                  </div>
                  <div class="col-3" id="seccion_institucion" runat=server>
                    <asp:Label ID="Label4" runat="server" Text="Institucion:" Font-Bold="True" 
                          Font-Underline="True"></asp:Label>
                    <asp:DropDownList ID="DropDown_institucion" runat="server" AutoPostBack="True" 
                          Width="250px">
                    </asp:DropDownList>
                  </div>
                  <div class="col-3">
                      <button type="button" id="Btn_asignar" class="btn btn-default btn-sm" 
                        runat="server" title="Asignar"><strong>Asignar</strong></button>
                      &nbsp;
                  <button type="button" id="Nuevo_institucion" class="btn btn-default btn-sm" 
                        runat="server" title="Nueva institucion"><strong>Nuevo</strong></button>
                  </div>
                </div>






            <div class="form-group">
            <label>Listado de Instituciones vinculadas al instructor:</label>
                <br />
                <asp:Label ID="Label7" runat="server" 
                    Text="Nota: Recuerde que las instituciones vinculadas que figuran en el listado, estarán como opciones disponibles en el formulario de registro de usuario." 
                    Font-Bold="True" Font-Size="XX-Small" ForeColor="#3366FF"></asp:Label>
            </div>
            
            <div class="form-group">
            
            <asp:GridView ID="GridView1" class="table table-hover" runat="server" 
                    AutoGenerateColumns="False" AllowSorting="True" BorderColor="Black" 
                    Font-Size="Small" >
                    <Columns>
                        <asp:TemplateField HeaderText="Editar">
                            <ItemTemplate>
                                <asp:ImageButton ID="ImageButton1" runat="server" CausesValidation="False" 
                                    CommandArgument='<%# Eval("institucion_id") %>' CommandName="institucion_id" 
                                    Height="30px" ImageAlign="AbsMiddle" ImageUrl="~/img/icon-edit.jpg" 
                                    ToolTip="Editar" Width="30px" />
                            </ItemTemplate>
                            <HeaderStyle ForeColor="#0099FF" HorizontalAlign="Center" 
                                VerticalAlign="Middle" Width="40px" />
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="institucion_id" HeaderText="ID" > 
                        <HeaderStyle ForeColor="#0099FF" />
                        </asp:BoundField>
                        <asp:BoundField DataField="institucion_descripcion" HeaderText="Institución" >
                        <HeaderStyle ForeColor="#0099FF" />
                        </asp:BoundField>
                        <asp:BoundField DataField="institucion_abreviacion" HeaderText="Abreviatura" >
                        <HeaderStyle ForeColor="#0099FF" />
                        </asp:BoundField>
                        <asp:BoundField DataField="provincia_desc" HeaderText="Provincia" >
                        <HeaderStyle ForeColor="#0099FF" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="Quitar">
                            <ItemTemplate>
                                <asp:ImageButton ID="ImageButton2" runat="server" CausesValidation="False" CommandArgument='<%# Eval("institucion_id") %>'
                                    CommandName="ID_delete" Height="30px" ImageAlign="AbsMiddle" 
                                    ImageUrl="~/img/delete.jpg" ToolTip="Quitar vinculo" Width="30px"/>
                            </ItemTemplate>
                            <HeaderStyle ForeColor="#0099FF" HorizontalAlign="Center" 
                                VerticalAlign="Middle" />
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        </asp:TemplateField>
                    
                    </Columns>
                    <HeaderStyle BackColor="#333333" />
                </asp:GridView>
        <div class="modal fade" id="modal_quitar" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
    <div class="modal-dialog modal-lg" role="document">
                <div class="modal-content">
                  <div class="modal-header">
                    <h5 class="modal-title" id="H2">¿Esta seguro de quitar el vinculo con la institución seleccionada?</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                      <span aria-hidden="true">&times;</span>
                    </button>
                  </div>
                  <div class="modal-body">
                    <div class="file-loading">
                      <%--<input id="FileUpload1" name="FileUpload1" multiple type="file" runat="server">--%>
                        <%--<asp:FileUpload ID="FileUpload1" runat="server" />--%>
                   </div>
                    <div id="Div1"></div>
                  </div>
                  <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Cancelar</button>
                    <button type="button" class="btn btn-primary" id="Button1" runat="server" rutitle="Your custom upload logic" >Aceptar</button>
                  </div>
                </div>
              </div>
    </div>
            
            </div>
        </form>


    </div>

    <div class="modal fade" id="Mod_keyadd" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
    <div class="modal-dialog modal-lg" role="document">
                <div class="modal-content">
                  <div class="modal-header">
                    <h5 class="modal-title" id="H3">Seleccione provincia e institucion</h5>
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
                                                                <table class="w-50">
                                                                    <tr>
                                                                        <td>
                                                                            

<%--                                                                            aqui estaban los combos--%>

                                                                        </td>
            
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
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

    



    <div class="modal fade" id="modal_eliminar" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
              <div class="modal-dialog modal-lg" role="document">
                <div class="modal-content">
                  <div class="modal-header">
                    <h5 class="modal-title" id="H1">¿Esta seguro de quitar el vinculo con la institucion seleccionada?</h5>
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



<%--------------MODAL DE ELIMINACION CORRECTA---------------------%>
<div id="div_modal_OKborrar" runat="server">
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
                                                    <asp:Label ID="Label16" runat="server" Text="Se desvinculó correctamente."></asp:Label>
                                                    &nbsp;
                                                </div>
                                            </div>
                                          </div>
                                        </form>  
                                        <div align="center">
                                                <asp:Button ID="Btb_ok" runat="server" Text="OK" CssClass="btn btn-success"  />
                                          </div> 
                                          <div>
                                             &nbsp;
                                          </div>             
                                        </div> 
                                    </asp:Panel>
    <asp:ModalPopupExtender ID="Modal_OKborrar" runat="server" TargetControlID="HiddenField_msj" PopupControlID="Panel1" CancelControlID="Btb_ok" BackgroundCssClass="modalBackground">
    </asp:ModalPopupExtender>

</div>
<%--------------FIN MODAL DE ELIMINACION CORRECTA---------------------%>


<%--------------MODAL DE error_no puede dejar vacia---------------------%>
<div id="div_modal_errorvacio" runat="server">
<asp:HiddenField ID="HiddenField1" runat="server" />
                                    <asp:Panel ID="Panel2" runat="server" >
              
                                        <div class="card card-danger ">
                                        <div class="card-header">
                                            <h3 class="card-title">Evento</h3>
                                        </div>
                                        <form role="form">
                                          <div class="card-body"> 
                                            <div class="row">
                                                <div align="center">
                                                    <asp:Label ID="Label5" runat="server" Text="Lo sentimos, la operación no se puede realizar. Debe pertenecer al menos a una institución."></asp:Label>
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
    <asp:ModalPopupExtender ID="Modal_errorvacio" runat="server" TargetControlID="HiddenField1" PopupControlID="Panel2" CancelControlID="Button2" BackgroundCssClass="modalBackground">
    </asp:ModalPopupExtender>

</div>
<%--------------MODAL DE error no puede dejar vacia---------------------%>

<%--------------MODAL DE error_no puede dejar vacia---------------------%>
<div id="div_modal_erroralumnos" runat="server">
<asp:HiddenField ID="HiddenField2" runat="server" />
                                    <asp:Panel ID="Panel3" runat="server" >
              
                                        <div class="card card-danger ">
                                        <div class="card-header">
                                            <h3 class="card-title">Evento</h3>
                                        </div>
                                        <form role="form">
                                          <div class="card-body"> 
                                            <div class="row">
                                                <div align="center">
                                                    <asp:Label ID="Label6" runat="server" Text="Lo sentimos, la operación no se puede realizar. Existen alumnos que dependen de esta institución."></asp:Label>
                                                    &nbsp;
                                                </div>
                                            </div>
                                          </div>
                                        </form>  
                                        <div align="center">
                                                <asp:Button ID="Button3" runat="server" Text="OK" CssClass="btn btn-danger "  />
                                          </div> 
                                          <div>
                                             &nbsp;
                                          </div>             
                                        </div> 
                                    </asp:Panel>

    <asp:ModalPopupExtender ID="modal_erroralumnos" runat="server" TargetControlID="HiddenField2" PopupControlID="Panel3" CancelControlID="Button3" BackgroundCssClass="modalBackground">
    </asp:ModalPopupExtender>


</div>


<%--------------final MODAL DE error_no puede dejar vacia---------------------%>


    </ContentTemplate>      
    </asp:UpdatePanel>

</asp:Content>
