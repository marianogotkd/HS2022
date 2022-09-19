<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/MasterPage.Master" CodeBehind="Llave_disponibles.aspx.vb" Inherits="fitfa.Llave_disponibles" %>
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
                <h3 class="card-title">Llaves disponibles - Evento:<asp:Label ID="Lb_evento" runat="server" Text="XXX - TITULO EVENTO"></asp:Label>      </h3>
                  <asp:HiddenField ID="HF_evento_id" runat="server" />
                  <asp:HiddenField ID="HF_area_id" runat="server" />
              </div>
              <form role="form">
              <div class="card-body" id="div_Grid" runat="server" visible=false> 
                    
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
              <asp:Label ID="Label2" runat="server" Text="Llaves disponibles para el evento" Font-Bold="True"></asp:Label>      
              </div>

              <div align="center">
               <div class="row">
                      
                       <div class="col-sm-12">
                       
                       
                           <asp:Label ID="Lab_no_llaves" runat="server" Font-Bold="True" ForeColor="Red" 
                               Text="No hay llaves generadas para el evento!" Visible="False"></asp:Label>
                       
                       </div>
                      
                      
               </div> 
                       
              
              </div>
              
              <div class="card-body table-responsive p-0">
                  <asp:GridView ID="GridView2" 
                      class="table table-hover" runat="server" AutoGenerateColumns="False" 
                      AllowSorting="True" BorderColor="Black"
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
                                                  <asp:BoundField DataField="Area" HeaderText="Area">
                                                  <HeaderStyle ForeColor="#0099FF" HorizontalAlign="Center" 
                                                      VerticalAlign="Middle" />
                                                  </asp:BoundField>
                                                  <asp:TemplateField HeaderText="Ver">
                                                      <ItemTemplate>
                                                          <asp:ImageButton ID="ImageButton3" runat="server" CausesValidation="False" 
                                                              CommandName="ID" Height="30px" ImageAlign="AbsMiddle" ImageUrl="~/img/lupa.png" 
                                                              ToolTip="Ver detalle de llave" Width="30px" CommandArgument='<%# Eval("ID") %>' />
                                                      </ItemTemplate>
                                                      <HeaderStyle ForeColor="#0099FF" />
                                                  </asp:TemplateField>
                                              </Columns>
                                          </asp:GridView>
                                          <button ID="btn_Examinar" runat="server" class="btn btn-primary" 
                                              data-target="#exampleModal" data-toggle="modal" type="button">
                                              Eliminar llave...
                                          </button>
              

              </div>
              <div align="center" style="background-color: #00CC00">
              <asp:Label ID="lbl_llf" runat="server" Text="LLAVES FINALIZADAS" Font-Bold="True" Visible="false"></asp:Label>      
              </div>
                    
                  <div class="card-body table-responsive p-0">
                  <asp:GridView ID="GridView_LLF" 
                      class="table table-hover" runat="server" AutoGenerateColumns="False" 
                      AllowSorting="True" BorderColor="Black"
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
                                                  <asp:BoundField DataField="Area" HeaderText="Area">
                                                  <HeaderStyle ForeColor="#0099FF" HorizontalAlign="Center" 
                                                      VerticalAlign="Middle" />
                                                  </asp:BoundField>
                                                  <asp:TemplateField HeaderText="Ver">
                                                      <ItemTemplate>
                                                          <asp:ImageButton ID="ImageButton3" runat="server" CausesValidation="False" 
                                                              CommandName="ID" Height="30px" ImageAlign="AbsMiddle" ImageUrl="~/img/lupa.png" 
                                                              ToolTip="Ver detalle de llave" Width="30px" CommandArgument='<%# Eval("ID") %>' />
                                                      </ItemTemplate>
                                                      <HeaderStyle ForeColor="#0099FF" />
                                                  </asp:TemplateField>
                                              </Columns>
                                          </asp:GridView>
                                                       

              </div>





              </div>
              
              <div id="div_Volver" runat="server" visible="false" >
                  <asp:Label ID="Label1" runat="server" 
                      Text="DEBE SELECCIONAR UN ÁREA PARA PODER TRABAJAR" Font-Bold="True" 
                      Font-Size="Large" ForeColor="Red"></asp:Label>
                  &nbsp;
                  <div>
                  &nbsp
                  </div>
                  <asp:Button ID="Button1" runat="server" Text="Volver" Font-Bold="True" 
                      Font-Size="Large" />
              
              </div>
              
              </form>

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
             
        
         
    



</ContentTemplate>
    <Triggers>
        <asp:PostBackTrigger ControlID="Eliminar_llave" />   <%--IMPORTANTE , SINO NO SE OCULTA EL MODAL DESPUES DE ELIMINAR LA LLAVE--%>
       
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
