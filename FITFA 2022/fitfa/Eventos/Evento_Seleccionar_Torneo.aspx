<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/MasterPage.Master" CodeBehind="Evento_Seleccionar_Torneo.aspx.vb" Inherits="fitfa.Evento_Seleccionar_Torneo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
    <div class="card card-primary">
                <div class="card-header">
                        <h3 class="card-title">TORNEOS DISPONIBLES</h3>
                  
                </div>
                <form role="form">
                <div class="card-body"> 
                <div align="center">
                <div class="row justify-content-center" >   <%--class="row"--%>
                <div class="col-lg-12">
                <div class="card-body">

                        <div id="Div1" class="row justify-content-center" runat="server" visible="true">
                        <div class="col-md-8">
                        <div class="card">
                        

                        <!-- /.card-header -->
                            <div class="card-body table-responsive p-0" style="height: 500px"> <%--class="form-group"--%>
                                    <%--class="table table-head-fixed text-nowrap"--%>
                                    <asp:GridView ID="GridView1" runat="server" class="table table-hover" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" 
                                           BorderColor="Black" GridLines="None" 
                                          EnableSortingAndPagingCallbacks="True"> <%--class="table table-hover" PageSize="20" --%>
                                            <Columns>
                                                <asp:BoundField DataField="evento_id" HeaderText="ID">
                                                <HeaderStyle ForeColor="#0099FF" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="evento_descripcion" HeaderText="Torneo" >
                                                <HeaderStyle ForeColor="#0099FF" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="evento_fecha" HeaderText="Fecha" >
                                                <HeaderStyle ForeColor="#0099FF" />
                                                </asp:BoundField>

                                                <asp:TemplateField ShowHeader="False" HeaderText="Consultar">
                                                      <ItemTemplate>
                                                          <asp:ImageButton ID="ImageButton1" runat="server" CausesValidation="false" 
                                                              CommandName='ID' ImageUrl="~/img/lupa.png" 
                                                              CommandArgument='<%# Eval("evento_id") %>' Text="" ToolTip="Ver" 
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
    </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
