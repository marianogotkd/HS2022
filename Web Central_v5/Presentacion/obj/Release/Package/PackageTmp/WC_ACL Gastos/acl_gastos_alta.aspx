<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Home.Master" CodeBehind="acl_gastos_alta.aspx.vb" Inherits="Presentacion.acl_gastos_alta" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script>
    //funcion que reconoce teclas para ir a los botones retroceso, baja y graba
    function tecla_op(e) {
        var keycode = e.keyCode;
        ///ESC RETROCEDE
        if (keycode == '27') {
            e.preventDefault();
            document.getElementsByTagName('button')[0].focus();
            document.getElementsByTagName('button')[0].click();

        }
        ///se anula el enter Y VOY AL BOTON GRABA
        if (keycode == '13') {
            e.preventDefault();
            document.getElementsByTagName('button')[1].focus();
            document.getElementsByTagName('button')[1].click();
            
        }


        //F8 GRABA
        if (keycode == '119') {
            e.preventDefault();
            document.getElementsByTagName('button')[1].focus();
            document.getElementsByTagName('button')[1].click();
        }
    }

    //funcion que reconoce teclas para ir a los botones retroceso, baja y graba
    function tecla_op_botones(e) {
        var keycode = e.keyCode;
        ///ESC RETROCEDE
        if (keycode == '27') {
            e.preventDefault();
            document.getElementsByTagName('button')[0].focus();
            document.getElementsByTagName('button')[0].click();

        }
        //        ///no voy a anular el ENTER
        //        if (keycode == '13') {
        //            e.preventDefault();
        //        }


        //F8 GRABA
        if (keycode == '119') {
            e.preventDefault();
            document.getElementsByTagName('button')[1].focus();
            document.getElementsByTagName('button')[1].click();
        }
    }



</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="True"></asp:ScriptManager>
<asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
<ContentTemplate>
<div class="card card-primary">
<div class="card-header">
                <h3 class="card-title">A.C.L. GASTOS</h3>
</div>
<form role="form">
<div class="card-body">
<div class="container-fluid">
<div class="row justify-content-center">
<div class="col-lg-12">
<div class="card">

        <div class="card-body">
                <div class="form-group">
                    <div class="row justify-content-center">
                            <div class="col-md-4">
                                   <label for="Label_cliente_id">OPCION 1: ALTA DE GASTOS.</label> 
                            </div>  

                    </div>
                    
                </div>
                <div class="form-group">
                    <div class="row justify-content-center">
                            <div class="col-md-4">
                                    <label for="Label_cliente_id">Motivo:</label> 
                                    <asp:TextBox ID="Txt_motivo" runat="server" placeholder="ingrese motivo..." class="form-control" onkeydown="tecla_op(event);" MaxLength="20"></asp:TextBox>
                                    <asp:Label ID="lb_error_motivo" runat="server" ForeColor="Red" Text="*" 
                                    Visible="false"></asp:Label>
                            </div>
                    </div>

                </div>

                <div id="Div1" class="row justify-content-center" runat="server" visible="true">
                    <div class="col-md-8">
                    <div class="card">
                    <div class="card-header">
                              <h3 class="card-title">Listado de Gastos.</h3>

                              <%--<div class="card-tools">
                                    <div class="input-group input-group-sm" style="width: 150px;">
                                    <input type="text" id="txt_buscar" runat="server" onkeydown="tecla_op(event);" name="table_search" class="form-control float-right" placeholder="Buscar...">

                                    <div class="input-group-append">
                                    <button type="submit" class="btn btn-default" onkeydown="tecla_op_botones(event);"><i class="fas fa-search"></i></button>
                                    </div>
                                    </div>
                            </div>--%>
                    </div>
                    <!-- /.card-header -->
                    <div class="card-body table-responsive p-0" style="height: 200px" onkeydown="tecla_op_botones(event);" > <%--class="form-group"--%>
                            <asp:GridView ID="GridView1" runat="server" 
                            class="table table-head-fixed text-nowrap" AllowSorting="True" AutoGenerateColumns="False" 
                                   BorderColor="Black" GridLines="None" 
                                  EnableSortingAndPagingCallbacks="True"> <%--class="table table-hover" PageSize="20" --%>
                                    <Columns>
                                        <asp:BoundField DataField="Gastotipo_id" HeaderText="ID" Visible="False">
                                        <HeaderStyle ForeColor="#0099FF" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Motivo" HeaderText="Gasto" >
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
<div class="card-footer">
        <div class="row justify-content-center" >
        <div class="row align-items-center">
            <div class="form-group">
            <button type="submit" UseSubmitBehavior="false" class="btn btn-primary" runat="server" id="btn_retroceder" onkeydown="tecla_op_botones(event);">
                ESC = RETROCEDE</button>
            &nbsp;
            </div>

            

            <div class="form-group">
            <button type="button" id="BOTON_GRABAR" runat="server" class="btn btn-primary" onkeydown="tecla_op_botones(event);" data-toggle="modal" data-target="#Mdl_graba"> <%--data-targe="#modal-primary"--%>
                  F8 = GRABA
                </button>
            </div>
        
        </div>
        

        </div>
</div>


</div>

<!-- Modal BAJA CENTRADO EN PANTALLA -->
<div class="modal fade" id="Mdl_graba" tabindex="-1" role="dialog" aria-labelledby="exampleModalCenterTitle" aria-hidden="true" data-backdrop="static" data-keyboard="false">
  <div class="modal-dialog modal-dialog-centered" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <h5 class="modal-title" id="H1">Graba</h5>
        <button type="button" id="btn_graba_close" class="close" runat="server" tabindex="-1" data-dismiss="modal" aria-label="Close">
          <span aria-hidden="true">&times;</span>
        </button>
      </div>
      <div class="modal-body">
        ¿Confirma la operación?...
      </div>
      <div class="modal-footer">
        <button type="button" id="btn_graba_mdl_cancelar" class="btn btn-secondary" runat="server" data-dismiss="modal">Cancelar</button>
        <button type="button" id="btn_graba_mdll" class="btn btn-primary" runat="server" data-dismiss="modal">Confirmar</button>
      </div>
    </div>
  </div>
</div>

<div class="modal fade" id="modal-sm_error" tabindex="-1" role="dialog" aria-labelledby="exampleModalCenterTitle" aria-hidden="true" data-backdrop="static" data-keyboard="false">
        <div class="modal-dialog modal-sm modal-dialog-centered " role="document">
          <div class="modal-content">
            <div class="modal-header">
              <h4 class="modal-title">Error!</h4>
              <button type="button" id="btn_close_error" runat="server" class="close" tabindex="-1" data-dismiss="modal" aria-label="Close">
                <span aria-hidden="true">&times;</span>
              </button>
            </div>
            <div class="modal-body">
              <p>El motivo ya existe o es vacio, modifique el valor ingresado!&hellip;</p>
            </div>
            <div class="modal-footer justify-content-center ">
            <%--<div class="modal-footer justify-content-between">--%>
              <%--<button type="button" class="btn btn-default" data-dismiss="modal">Close</button>--%>
              <button type="button" id="btn_ok_error" runat="server" tabindex="1" class="btn btn-primary" data-dismiss="modal">OK</button>
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
