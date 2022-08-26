<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/MasterPage.Master" CodeBehind="Credenciales_generar.aspx.vb" Inherits="fitfa.Credenciales_generar" %>
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
                <h3 class="card-title">Generación de Credenciales - Evento:<asp:Label ID="Lb_evento" runat="server" Text="XXX - TITULO EVENTO"></asp:Label>      </h3>
                  <asp:HiddenField ID="HF_evento_id" runat="server" />
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
                                              </Columns>
                                          </asp:GridView>

                                          &nbsp;
                                          <button ID="Button_addkey" runat="server" class="btn btn-primary" 
                                              data-target="#Mod_keyadd" data-toggle="modal" 
                      type="button" style="font-size: medium">
                                              Generar Credenciales
                                          </button>

                                          &nbsp;&nbsp;<br />
                                          


              

              </div>
              
              </div>
              
              
              </form>

    </div>
        

</ContentTemplate>
    <Triggers>
                  
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
