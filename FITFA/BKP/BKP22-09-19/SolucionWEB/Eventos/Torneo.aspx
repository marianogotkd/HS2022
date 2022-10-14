<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/MasterPage.Master" CodeBehind="Torneo.aspx.vb" Inherits="fitfa.Torneo" %>
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
                          <asp:HiddenField ID="HD_evento_id" runat="server" />
                      <asp:Label ID="Label_evento_b" runat="server" Text="Evento:" 
                          forecolor = "#3399FF" Font-Bold="True"></asp:Label>
                      </div>
                      <div class="form-group">
                      <asp:Label ID="Label_evento_fecha_b" runat="server" Text="Fecha:"></asp:Label>
                      </div>
                      <div class="form-group">
                      <asp:Label ID="Label_evento_direccion_b" runat="server" Text="Direccion:"></asp:Label>
                      </div>
                      <div class="form-group">
                      <asp:Label ID="Label_evento_cant_inscriptos_b" runat="server" Text="Cantidad de inscriptos:"></asp:Label>
                      </div>

                      <div class="form-group">
                      <div align="center">
                      <div class="row justify-content-center" >   <%--class="row"--%>
                      <div class="col-lg-12">
                      
                      <div id="Div1_grilla" class="row justify-content-center" runat="server" visible="true">
                        <div class="col-md-12">
                        <div class="card">
                        

                        <!-- /.card-header -->
                            <div class="card-body table-responsive p-0" style="height: 300px"> <%--class="form-group"--%>
                                    <%--class="table table-head-fixed text-nowrap"--%>
                                    <asp:GridView ID="GridView1" class="table table-hover" runat="server" 
                                        AllowSorting="True" AutoGenerateColumns="False" 
                                                BorderColor="Black" 
                                        EnableSortingAndPagingCallbacks="True"> <%--class="table table-hover" PageSize="20" --%>
                                            <Columns>
                                                <asp:BoundField DataField="categoria_id" HeaderText="ID" />
                                                <asp:BoundField DataField="Modalidad" HeaderText="Modalidad">
                                                <HeaderStyle ForeColor="#0099FF" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Categoria" HeaderText="Categoria" >
                                                <HeaderStyle ForeColor="#0099FF" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" >
                                                <HeaderStyle ForeColor="#0099FF" />
                                                </asp:BoundField>
                                                
                                                
                                                <asp:TemplateField ShowHeader="False" HeaderText="Consultar">
                                                      <ItemTemplate>
                                                          <asp:ImageButton ID="ImageButton1" runat="server" CausesValidation="false" 
                                                              CommandName='ID' ImageUrl="~/img/lupa.png" 
                                                              CommandArgument='<%# Eval("categoria_id") %>' Text="" ToolTip="Ver inscriptos" 
                                                              ImageAlign= "Left"/>
                                                      </ItemTemplate>
                                                      <ControlStyle Height="30px" Width="30px" />
                                                      <HeaderStyle ForeColor="#0099FF" />
                                                      <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:TemplateField>



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
                      

                      <div class="form-group">
                      <div align="center">
                      <div class="row justify-content-center" >   <%--class="row"--%>
                      <div class="col-lg-12">
                      
                      <div id="Div1_grilla_solouno" class="row justify-content-center" runat="server" visible="true">
                        <div class="col-md-12">
                        <div class="card">
                        

                        <!-- /.card-header -->
                            <div class="card-body table-responsive p-0" style="height: 300px"> <%--class="form-group"--%>
                                    <%--class="table table-head-fixed text-nowrap"--%>
                                    <asp:GridView ID="GridView2" class="table table-hover" runat="server" 
                                        AllowSorting="True" AutoGenerateColumns="False" 
                                                BorderColor="Black" 
                                        EnableSortingAndPagingCallbacks="True"> <%--class="table table-hover" PageSize="20" --%>
                                            <Columns>
                                                <asp:BoundField DataField="categoria_id" HeaderText="ID" />
                                                <asp:BoundField DataField="Modalidad" HeaderText="Modalidad">
                                                <HeaderStyle ForeColor="#0099FF" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Categoria" HeaderText="Categoria" >
                                                <HeaderStyle ForeColor="#0099FF" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" >
                                                <HeaderStyle ForeColor="#0099FF" />
                                                </asp:BoundField>
                                                
                                                
                                                <asp:TemplateField ShowHeader="False" HeaderText="Consultar">
                                                      <ItemTemplate>
                                                          <asp:ImageButton ID="ImageButton1" runat="server" CausesValidation="false" 
                                                              CommandName='ID' ImageUrl="~/img/lupa.png" 
                                                              CommandArgument='<%# Eval("categoria_id") %>' Text="" ToolTip="Ver inscriptos" 
                                                              ImageAlign= "Left"/>
                                                      </ItemTemplate>
                                                      <ControlStyle Height="30px" Width="30px" />
                                                      <HeaderStyle ForeColor="#0099FF" />
                                                      <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:TemplateField>



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
          

    </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
