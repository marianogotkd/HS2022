<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/MasterPage.Master" CodeBehind="Torneo_insc.aspx.vb" Inherits="fitfa.Torneo_insc" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>

<asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>
<div class="card card-primary">
<form role="form">
                      <div class="card-body"> 
                      <!-- Aqui va el codigo para la pestaña "TURNOS" -->
                      <div class="form-group">
                      <asp:Label ID="Label_evento_b" runat="server" Text="Evento:" 
                          forecolor = "#3399FF" Font-Bold="True"></asp:Label>
                          <asp:HiddenField ID="HF_evento_id" runat="server" />
                      </div>
                      <div class="form-group">
                      <asp:Label ID="Label_evento_fecha_b" runat="server" Text="Fecha:"></asp:Label>
                      </div>
                      <div class="form-group">
                      <asp:Label ID="Label_evento_categoria" runat="server" Text="Categoria:"></asp:Label>
                          <asp:HiddenField ID="HF_categoria_id" runat="server" />
                      </div>
                      <div class="form-group">
                      <asp:Label ID="Label_evento_cant_inscriptos_b" runat="server" Text="Cantidad de inscriptos:"></asp:Label>
                      </div>

                      
                      <div align="center">
                      <div class="row justify-content-center" >   <%--class="row"--%>
                      <div class="col-lg-12">
                      
                      <div id="Div1" class="row justify-content-center" runat="server" visible="true">
                        <div class="col-md-12">
                        <div class="card">
                        

                        <!-- /.card-header -->
                            <div class="card-body table-responsive p-0" style="height: 500px"> <%--class="form-group"--%>
                                    <%--class="table table-head-fixed text-nowrap"--%>
                                    <asp:GridView ID="GridView1" runat="server" class="table table-hover" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" 
                                           BorderColor="Black" GridLines="None" 
                                          EnableSortingAndPagingCallbacks="True"> <%--class="table table-hover" PageSize="20" --%>
                                            <Columns>
                                                
                              <asp:BoundField DataField="Alumno" HeaderText="Alumno" >
                              <HeaderStyle ForeColor="#0099FF" />
                              </asp:BoundField>
                              <asp:BoundField DataField="usuario_doc" HeaderText="Dni" >
                              <HeaderStyle ForeColor="#0099FF" />
                              </asp:BoundField>
                              <asp:BoundField DataField="graduacion_desc" HeaderText="Graduacion" >
                              <HeaderStyle ForeColor="#0099FF" />
                              </asp:BoundField>
                              <asp:BoundField DataField="instructor" HeaderText="Instructor" >
                              <HeaderStyle ForeColor="#0099FF" />
                              </asp:BoundField>
                              <asp:TemplateField HeaderText="Eliminar">
                                  <EditItemTemplate>
                                      <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                                  </EditItemTemplate>
                                  <ItemTemplate>
                                      <asp:Button ID="Button1" runat="server" CommandName="op_eliminar" CommandArgument='<%# Eval("inscripcion_id") %>' 
                                          Text="Eliminar" />
                                  </ItemTemplate>
                                  <HeaderStyle ForeColor="#FF5050" />
                              </asp:TemplateField>

                              <asp:TemplateField HeaderText="Modificar">
                                  <EditItemTemplate>
                                      <asp:TextBox ID="TextBox_modif" runat="server"></asp:TextBox>
                                  </EditItemTemplate>
                                  <ItemTemplate>
                                      <asp:Button ID="Button_modif" runat="server" CommandName="op_modificar" CommandArgument='<%# Eval("inscripcion_id") %>' 
                                          Text="Modificar" />
                                  </ItemTemplate>
                                  <HeaderStyle ForeColor="#FF5050" />
                              </asp:TemplateField>

                              <asp:BoundField DataField="usuario_id" HeaderText="usuario_id" 
                                  Visible="False" >
                              </asp:BoundField>
                              <asp:BoundField DataField="inscripcion_id" HeaderText="inscripcion_id" >
                              <HeaderStyle ForeColor="#0099FF" />
                              </asp:BoundField>
                              <asp:BoundField DataField="evento_id" HeaderText="evento_id" Visible="False" >
                              <HeaderStyle ForeColor="#0099FF" />
                              </asp:BoundField>
                                                
                                            </Columns>
                                        </asp:GridView>
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
    <div class="row justify-content-center" >
        <div class="row align-items-center">
            <div class="form-group">
                    <input type="button" class="btn btn btn-success" id="btnExport_Examen" value="Exportar a Excel" />
            </div>


        </div>
    </div>
    </div>


<div id="div_Modal_eliminar_inscripto" runat="server">
                <asp:HiddenField ID="HiddenField_Err" runat="server" />
                <asp:Panel ID="Panel_Modal_Err" runat="server" >
     
                    <div class="card card-danger">
            <div class="card-header">
                <h3 class="card-title">Eliminar Inscripción</h3>
            </div>
            <form role="form">
              <div class="card-body"> 
                <div class="row">
                    <div align="right">
                        
                    <asp:Label ID="Label3" runat="server" Text="¿Desea cancelar la inscripción?" Font-Size="Small"></asp:Label>
                    </div>
                </div>
              </div>
            </form>  
            <div align="center">
                    <asp:Button ID="Btn_Modal_si" runat="server" Text="Si" CssClass="btn btn-danger"  />
                    <asp:Button ID="Btn_Modal_no" runat="server" Text="No" CssClass="btn btn-danger"  />
              </div>
                          
              <div>
                 &nbsp;
              </div>             
            </div>
                    <%--<asp:ModalPopupExtender ID="Modal_eliminar_inscripto" runat="server" TargetControlID="HiddenField_Err" PopupControlID="Panel_Modal_Err" CancelControlID="Btn_Modal_no" BackgroundCssClass="modalBackground">
                    </asp:ModalPopupExtender>--%>
                    <asp:ModalPopupExtender ID="Modal_eliminar_inscripto" runat="server" TargetControlID="HiddenField_Err" PopupControlID="Panel_Modal_Err" CancelControlID="Btn_Modal_no" BackgroundCssClass="modalBackground">
                    </asp:ModalPopupExtender>

                 </asp:Panel>

</div>


</ContentTemplate>
</asp:UpdatePanel>
</asp:Content>
