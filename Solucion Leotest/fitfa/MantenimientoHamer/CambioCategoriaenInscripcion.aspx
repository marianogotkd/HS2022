<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/MasterPage.Master" CodeBehind="CambioCategoriaenInscripcion.aspx.vb" Inherits="fitfa.CambioCategoriaenInscripcion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="card card-primary">
                <div class="card-header">
                <h3 class="card-title">MANTENIMIENTO HAMER 1<asp:Label ID="Lb_evento" runat="server" Text="CAMBIAR CATEGORIAS EN INSCRIPCION"></asp:Label>      </h3>
                  
              </div>
                <form role="form">
                    <div class="card-body"> 
                        <div class="container-fluid">
                    <div class="row justify-content-center">
                        <div class="col-lg-12">
                            <div class="card">
                                        <div class="card-body">
                                            <div class="row">
                                            <div class="col-sm-4" align="center"></div>
                                            <div class="col-sm-4" align="center">
                    
                                                <div class="form-group">
                                                <asp:DropDownList ID="DropDownList_eventos" runat="server">
                                                </asp:DropDownList>
                                                    
                                                </div>
                                                <div class="form-group">
                                                <asp:Button ID="Btn_SelecEvento" runat="server" Text="Obtener inscripciones" />
                                                </div>
    
                                            </div>
                                            <div class="col-sm-4" align="center"></div>
                                            </div>    
                                            
                                            
                                            
                                            
                                            
                                            <div class="form-group">
                                                    <div class="row justify-content-left">
                                                        <div class="col-md-6">
                                                            <label for="Label_InscReales" style="background-color: #000066; color: #FFFFFF">INSCRIPCIONES REALES</label>
                                                            <div id="DIV_GRIDCOMPETIDORES" class="card-body table-responsive p-0" runat ="server">
                                                                <asp:GridView ID="GridView_INSCRIPCIONES" class="table table-hover" runat="server" 
                                                                AllowSorting="True" 
                                                                           BorderColor="Black" GridLines="None" 
                                                                          EnableSortingAndPagingCallbacks="True">
                                                               </asp:GridView>
                                                            </div>
                                                        
                                                        </div>
                                                        <div class="col-md-6">
                                                            <label for="Label_RESULTADO" style="background-color: #000066; color: #FFFFFF">COMO CAMBIARIA</label>
                                                            <div class="form-group">
                                                            <asp:Button ID="BTN_ejecutar" runat="server" Text="EJECUTAR AMBOS SEXOS" />

                                                                <asp:Button ID="BTN_ejecutar2" runat="server" Text="EJECUTAR 12-13 Hombre-Mujer" />



                                                            </div>
                                                            <div id="DIV_RESULTADOS" class="card-body table-responsive p-0" runat ="server">
                                                                <asp:GridView ID="GridView_RESULTADOS" class="table table-hover" runat="server" 
                                                                AllowSorting="True" AutoGenerateColumns="False" 
                                                                           BorderColor="Black" GridLines="None" 
                                                                          EnableSortingAndPagingCallbacks="True">
                                                                          <Columns>
                                                                              <asp:BoundField DataField="evento_id" HeaderText="evento_id" >
                                                                              <HeaderStyle ForeColor="#0099FF" />
                                                                              </asp:BoundField>
                                                                              <asp:BoundField DataField="inscripcion_id" HeaderText="inscripcion_id" >
                                                                              <HeaderStyle ForeColor="#0099FF" />
                                                                              </asp:BoundField>
                                                                              <asp:BoundField DataField="categoria_id" HeaderText="categoria_id" >
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
                  </div>
                    </div>
                </form>
            </div>

            <%--<asp:HiddenField ID="HiddenMostrar" runat="server" />
            <asp:Panel ID="Panel_msj" runat="server" CssClass="modalpopup"> 
                                <div class="card card-success">
                                        <div class="card-header">
                                            <h3 class="card-title">Cambios Correctos</h3>
                                        </div>
                                        <form role="form">
                                            <div class="card-body"> 
                                                    <div class="row">
                                                        <div align="center">
                                                                <asp:Label ID="Label12" runat="server" Text="Cambios correctos!!"></asp:Label>
                                                        </div>
                                                    </div>
                                            </div>
                                        </form>
                                        <div align="center">
                                                <asp:Button ID="Btn_msj_ok" runat="server" Text="OK" />
                                        </div>
                                        <div>
                                             &nbsp;
                                        </div>

                                </div>
                                
                            </asp:Panel>
                 
            
            <cc1:ModalPopupExtender ID="ModalPopupExtender2" runat="server" PopupControlID="Panel_msj" TargetControlID="HiddenMostrar" BackgroundCssClass="modalBackground">
                 </cc1:ModalPopupExtender>--%>





        </ContentTemplate>
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
