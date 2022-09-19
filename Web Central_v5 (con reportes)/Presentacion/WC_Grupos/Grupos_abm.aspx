<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Home.Master" CodeBehind="Grupos_abm.aspx.vb" Inherits="Presentacion.Grupos_abm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script language="javascript" type="text/javascript">
// <![CDATA[

        function btn_modificar_onclick() {

        }

        function btn_modificar_onclick() {

        }

// ]]>
    
    
    
    
    
    </script>

    <script>
        //funcion que reconoce teclas para ir a los botones retroceso, baja y graba
        function tecla_op(e) {
            var keycode = e.keyCode;
            
            ///se anula el enter y va al boton de continuar
            if (keycode == '13') {
                e.preventDefault();
                document.getElementsByTagName('button')[1].focus();
                document.getElementsByTagName('button')[1].click();
            }

            ///F2
            if (keycode == '119') {
                e.preventDefault();
                document.getElementsByTagName('button')[1].focus();
                document.getElementsByTagName('button')[1].click();
            }


            ///ESC RETROCEDE
            if (keycode == '27') {
                e.preventDefault();
                document.getElementsByTagName('button')[0].focus();
                document.getElementsByTagName('button')[0].click();

            }

        }



        //funcion que reconoce teclas para ir a los botones retroceso, baja y graba
        function tecla_op_botones(e) {
            var keycode = e.keyCode;
            
            ///no anulo el ENTER
//            if (keycode == '13') {
//                e.preventDefault();
//            }

            ///F2
            if (keycode == '119') {
                e.preventDefault();
                document.getElementsByTagName('button')[1].focus();
                document.getElementsByTagName('button')[1].click();
            }

            ///ESC RETROCEDE
            if (keycode == '27') {
                e.preventDefault();
                document.getElementsByTagName('button')[0].focus();
                document.getElementsByTagName('button')[0].click();

            }

        }

        //funcion para seleccionar todo le contenido de un textbox cuando se pone el foco sobre el control. se agrega como atributo en el codebehind
        function seleccionarTexto(obj) {
            if (obj != null) {
                obj.select();
            }
        }
    </script>

   <%-- <script type="text/javascript">
        function ShowPopup() {
            $("#btnShowPopup").click();
        }
    </script>  --%>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" 
                            EnableScriptGlobalization="True">
    </asp:ScriptManager>

<asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
<ContentTemplate>
<div class="card card-primary">
<div class="card-header">
                <h3 class="card-title">A.B.M. GRUPOS</h3>
</div>
<form role="form">
<div class="card-body">
    <div align="center">
    <div class="row justify-content-center" >   <%--class="row"--%>
        <div class="col-lg-12">
            <div class="card">
                <div class="card-body">
                    <div class="form-group">
                        <asp:Label ID="Lb_grupo" runat="server" Text="Grupos:"></asp:Label>
                        &nbsp;<asp:TextBox ID="Txt_grupo_id" placeholder="ingrese Cód." runat="server" 
                            CausesValidation="True" onkeydown="tecla_op(event);" 
                            onkeypress="return justNumbers(event);" MaxLength="3"></asp:TextBox>
                        
                    </div>
                    
                    <div class="row justify-content-center" runat="server" visible="false">
                    <div class="col-md-8">
                    <div class="card">
                    <div class="card-header">
                              <h3 class="card-title">Listado de Grupos.</h3>

                              <div class="card-tools">
                                    <div class="input-group input-group-sm" style="width: 150px;">
                                    <input type="text" id="txt_buscar" runat="server" onkeydown="tecla_op(event);" name="table_search" class="form-control float-right" placeholder="Buscar...">

                                    <div class="input-group-append">
                                    <button type="submit" class="btn btn-default" onkeydown="tecla_op_botones(event);"><i class="fas fa-search"></i></button>
                                    </div>
                                    </div>
                            </div>
                    </div>
                    <!-- /.card-header -->
                    <div class="card-body table-responsive p-0" style="height: 200px" onkeydown="tecla_op_botones(event);" > <%--class="form-group"--%>
                            <asp:GridView ID="GridView1" runat="server" class="table table-head-fixed text-nowrap" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" 
                                   BorderColor="Black" GridLines="None" 
                                  EnableSortingAndPagingCallbacks="True"> <%--class="table table-hover" PageSize="20" --%>
                                    <Columns>
                                        <asp:BoundField DataField="Codigo" HeaderText="Código">
                                        <HeaderStyle ForeColor="#0099FF" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Nombre" HeaderText="Grupo" >
                                        <HeaderStyle ForeColor="#0099FF" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Fecha" HeaderText="Fecha de Proc." >
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

<div class="card-footer">
<div class="row justify-content-center" >
<div class="row align-items-center">
<div class="form-group">
    <button type="submit" UseSubmitBehavior="false" class="btn btn-primary" runat="server" id="btn_retroceder" onkeydown="tecla_op_botones(event);">ESC = RETROCEDE</button>
    &nbsp;</div>
<div class="form-group">
    <button type="button" id="btn_modificar" runat="server" class="btn btn-primary" onkeydown="tecla_op_botones(event);">F8 = CONTINUAR</button>
</div>


</div>
</div>
</div>



<div class="modal fade" id="modal-baja">
        <div class="modal-dialog">
          <div class="modal-content bg-primary">
            <div class="modal-header">
              <h4 class="modal-title">Dar de Baja</h4>
              <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                <span aria-hidden="true">&times;</span></button>
            </div>
            <div class="modal-body">
              <p>¿Confirma la operación?&hellip;</p>
            </div>
            <div class="modal-footer justify-content-between">
              <button type="button"    class="btn btn-outline-light" data-dismiss="modal">Cancelar</button>
              <button type="button" id="btn_baja_modal" runat="server"  class="btn btn-outline-light" data-dismiss="modal">Confirmar</button>
            </div>
          </div>
          <!-- /.modal-content -->
        </div>
        <!-- /.modal-dialog -->
      </div>
      <!-- /.modal -->



<div class="modal fade" id="modal-noexiste">
        <div class="modal-dialog">
          <div class="modal-content bg-primary">
            <div class="modal-header">
              <h4 class="modal-title">Error</h4>
              <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                <span aria-hidden="true">&times;</span></button>
            </div>
            <div class="modal-body">
              <p>El código ingresado es incorrecto!&hellip;</p>
            </div>
            <div class="modal-footer justify-content-between">
              <%--<button type="button"    class="btn btn-outline-light" data-dismiss="modal">Cancelar</button>--%>
              <button type="button" id="Button1" runat="server"  class="btn btn-outline-light" data-dismiss="modal">OK</button>
            </div>
          </div>
          <!-- /.modal-content -->
        </div>
        <!-- /.modal-dialog -->
      </div>
      <!-- /.modal -->

<div class="modal fade" id="modal-sm_error" tabindex="-1" role="dialog" aria-labelledby="exampleModalCenterTitle" aria-hidden="true" data-backdrop="static" data-keyboard="false">
        <div class="modal-dialog modal-sm modal-dialog-centered " role="document">
          <div class="modal-content">
            <div class="modal-header">
              <h4 class="modal-title">Error!</h4>
              <button type="button" id="btn_close_error" runat="server" tabindex="-1" class="close" data-dismiss="modal" aria-label="Close">
                <span aria-hidden="true">&times;</span>
              </button>
            </div>
            <div class="modal-body">
              <p>El código no existe!&hellip;</p>
            </div>
            <div class="modal-footer justify-content-center ">
            <%--<div class="modal-footer justify-content-between">--%>
              <%--<button type="button" class="btn btn-default" data-dismiss="modal">Close</button>--%>
              <button type="button" id="btn_ok_error" runat="server" tabindex="1"  class="btn btn-primary" data-dismiss="modal">OK</button>
            </div>
          </div>
          <!-- /.modal-content -->
        </div>
        <!-- /.modal-dialog -->
      </div>
      <!-- /.modal -->
      

</ContentTemplate>
</asp:UpdatePanel>

</asp:Content>
