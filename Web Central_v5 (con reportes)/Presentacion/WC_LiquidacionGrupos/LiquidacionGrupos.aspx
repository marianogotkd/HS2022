<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Home.Master" CodeBehind="LiquidacionGrupos.aspx.vb" Inherits="Presentacion.LiquidacionGrupos" %>
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
        ///se anula el enter Y PASO AL BOTON DE GRABA
        if (keycode == '13') {
            e.preventDefault();
            
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


    //funcion que reconoce teclas ENTER, EL BOTON DE BUSQUEDA, ESC Y GRABA...SOLO LO VOY A USAR EN LOS TEXTBOX CLIENTE Y FECHA.
    function tecla_op_BUSQUEDA(e) {
        var keycode = e.keyCode;
        ///ESC RETROCEDE
        if (keycode == '27') {
            e.preventDefault();
            document.getElementsByTagName('button')[0].focus();
            document.getElementsByTagName('button')[0].click();

        }
        ///se anula el enter Y PASO AL BOTON DE GRABA
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


    //funcion para seleccionar todo le contenido de un textbox cuando se pone el foco sobre el control. se agrega como atributo en el codebehind
    function seleccionarTexto(obj) {
        if (obj != null) {
            obj.select();
        }
    }
    
</script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<asp:ScriptManager ID="ScriptManager1" runat="server" 
                            EnableScriptGlobalization="True">
</asp:ScriptManager>
  <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
<ContentTemplate>

<div class="card card-primary">
<div class="card-header">
                <h3 class="card-title">LIQUIDACION DE GRUPOS</h3>
</div>
<form role="form">
<div class="card-body">
    <div align="center">
    <div class="row justify-content-center" >   <%--class="row"--%>
        <div class="col-lg-12">
            <div class="card">
                <div class="card-body">
                    
                  <div class="form-group">       
                    <div class="row justify-content-center">
                          <div class="col-md-4">
                            <label for="Label_Fechadesde">FECHA DESDE:</label>
                            <div class="input-group" >
                                                    <asp:TextBox ID="Txt_fecha_desde" onkeydown="tecla_op(event);" runat="server" name="table_search" class="form-control float-right" TextMode="Date" ></asp:TextBox>
                                                    <%--<input type="text" id="txt_buscar" runat="server" onkeydown="tecla_op(event);" name="table_search" class="form-control float-right" placeholder="Buscar...">--%>

                                                    
                           </div>               
                          </div>

                          <div class="col-md-4">
                            <label for="Label_Fechahasta">FECHA HASTA:</label>
                            <div class="input-group" >
                                                    <asp:TextBox ID="Txt_fecha_hasta" onkeydown="tecla_op(event);" runat="server" name="table_search" class="form-control float-right" TextMode="Date" ></asp:TextBox>
                                                    <%--<input type="text" id="txt_buscar" runat="server" onkeydown="tecla_op(event);" name="table_search" class="form-control float-right" placeholder="Buscar...">--%>

                                                    
                           </div>               
                          </div>
                        <div class="col-md-2">

                          <label for="Label_grupo">GRUPO (999=TODOS):</label>
                          <div>
                                                <asp:TextBox ID="Txt_grupo_codigo" runat="server" class="form-control" placeholder="" MaxLength="3" 
                                                        onkeydown="tecla_op(event);" onkeypress="return justNumbers(event);" 
                                                        ></asp:TextBox>
                                                <asp:Label ID="lb_error_codigo" runat="server" ForeColor="Red" Text="*" Visible="false"></asp:Label>
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
                    <button type="button" id="btn_modificar" runat="server" class="btn btn-primary" onkeydown="tecla_op_botones(event);">
                          F8 = GRABA
                        </button>
                    
</div>


</div>
</div>
</div>




  <%--MODAL MSJ CENTRADO - ERROR OPCION--%>
<div class="modal fade" id="modal-sm_error1" tabindex="-1" role="dialog" aria-labelledby="exampleModalCenterTitle" aria-hidden="true" data-backdrop="static" data-keyboard="false">
        <div class="modal-dialog modal-sm modal-dialog-centered " role="document">
          <div class="modal-content">
            <div class="modal-header">
              <h4 class="modal-title">Error!</h4>
              <button type="button" id="btn_close_error1" runat="server" class="close" tabindex="-1" data-dismiss="modal" aria-label="Close">
                <span aria-hidden="true">&times;</span>
              </button>
            </div>
            <div class="modal-body">
              <p>Error, verifique la informacion ingresada!&hellip;</p>
            </div>
            <div class="modal-footer justify-content-center ">
            <%--<div class="modal-footer justify-content-between">--%>
              <%--<button type="button" class="btn btn-default" data-dismiss="modal">Close</button>--%>
              <button type="button" id="btn_ok_error1" runat="server" tabindex="1" class="btn btn-primary" data-dismiss="modal">OK</button>
            </div>
          </div>
          <!-- /.modal-content -->
        </div>
        <!-- /.modal-dialog -->
      </div>
      <!-- /.modal -->



  <%--MODAL MSJ CENTRADO - ERROR OPCION--%>
<div class="modal fade" id="modal-sm_error2" tabindex="-1" role="dialog" aria-labelledby="exampleModalCenterTitle" aria-hidden="true" data-backdrop="static" data-keyboard="false">
        <div class="modal-dialog modal-sm modal-dialog-centered " role="document">
          <div class="modal-content">
            <div class="modal-header">
              <h4 class="modal-title">Error!</h4>
              <button type="button" id="Btn_close_error2" runat="server" class="close" tabindex="-1" data-dismiss="modal" aria-label="Close">
                <span aria-hidden="true">&times;</span>
              </button>
            </div>
            <div class="modal-body">
              <p>Error, Ingrese fechas validas!&hellip;</p>
            </div>
            <div class="modal-footer justify-content-center ">
            <%--<div class="modal-footer justify-content-between">--%>
              <%--<button type="button" class="btn btn-default" data-dismiss="modal">Close</button>--%>
              <button type="button" id="Btn_ok_error2" runat="server" tabindex="1" class="btn btn-primary" data-dismiss="modal">OK</button>
            </div>
          </div>
          <!-- /.modal-content -->
        </div>
        <!-- /.modal-dialog -->
      </div>
      <!-- /.modal -->


    <%--MODAL MSJ CENTRADO - ERROR OPCION--%>
<div class="modal fade" id="modal-sm_error3" tabindex="-1" role="dialog" aria-labelledby="exampleModalCenterTitle" aria-hidden="true" data-backdrop="static" data-keyboard="false">
        <div class="modal-dialog modal-sm modal-dialog-centered " role="document">
          <div class="modal-content">
            <div class="modal-header">
              <h4 class="modal-title">Error!</h4>
              <button type="button" id="Btn_close_error3" runat="server" class="close" tabindex="-1" data-dismiss="modal" aria-label="Close">
                <span aria-hidden="true">&times;</span>
              </button>
            </div>
            <div class="modal-body">
              <p>Error, el codigo no existe!&hellip;</p>
            </div>
            <div class="modal-footer justify-content-center ">
            <%--<div class="modal-footer justify-content-between">--%>
              <%--<button type="button" class="btn btn-default" data-dismiss="modal">Close</button>--%>
              <button type="button" id="Btn_ok_error3" runat="server" tabindex="1" class="btn btn-primary" data-dismiss="modal">OK</button>
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
