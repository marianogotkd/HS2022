<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Home.Master" CodeBehind="Grupos_agregar.aspx.vb" Inherits="Presentacion.Grupos_agregar" %>
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
        ///se anula el enter
        if (keycode == '13') {
            e.preventDefault();
        }

        ///F4 ELIMINA
        if (keycode == '115') {
            e.preventDefault();
            document.getElementsByTagName('button')[1].focus();
            document.getElementsByTagName('button')[1].click();
        }

        //F8 GRABA
        if (keycode == '119') {
            e.preventDefault();
            document.getElementsByTagName('button')[2].focus();
            document.getElementsByTagName('button')[2].click();
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

        ///F4 ELIMINA
        if (keycode == '115') {
            e.preventDefault();
            document.getElementsByTagName('button')[1].focus();
            document.getElementsByTagName('button')[1].click();
        }

        //F8 GRABA
        if (keycode == '119') {
            e.preventDefault();
            document.getElementsByTagName('button')[2].focus();
            document.getElementsByTagName('button')[2].click();
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
<asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="True"></asp:ScriptManager>
<asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
<ContentTemplate>
<div class="card card-primary">
<div class="card-header">
                <h3 class="card-title">A.B.M. GRUPOS</h3>
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
                    <div class="col-md-2">
                    <label for="Label_grupo_id">Grupo:</label>
                    <asp:TextBox ID="Txt_grupo_codigo" runat="server" placeholder="Ingrese código..." class="form-control" Visible="true"   
                    onkeydown="tecla_op(event);" onkeypress="return justNumbers(event);"></asp:TextBox>
                    <asp:Label ID="lb_error_codigo" runat="server" ForeColor="Red" Text="*" 
                    Visible="False"></asp:Label>
                    <asp:HiddenField ID="HF_grupo_id" runat="server" />
                    </div>
                    <div class="col-md-6">
                    <label for="Label_grupo_nombre">Nombre:</label>
                    <asp:TextBox ID="Txt_grupo_nomb" placeholder="Ingrese nombre..." 
                            class="form-control" onkeydown="tecla_op(event);" runat="server" MaxLength="20"></asp:TextBox>
                    <asp:Label ID="lb_error_nombre" runat="server" ForeColor="Red" Text="*" 
                    Visible="False"></asp:Label>
                    </div>
                    
            </div>
        </div>
        <div class="form-group">
            <div class="row justify-content-center">
                    <div class="col-md-2">
                    <label for="Label_tipo">Tipo:</label>
                    <asp:TextBox ID="Txt_tipo" runat="server" placeholder="Ingrese opción..." class="form-control" CausesValidation="True" 
                    MaxLength="1" onkeydown="tecla_op(event);" onkeypress="return solo_1234_valitation(event);" 
                    ToolTip="Ingrese tipo (1,2,3,4)" validationgroup="check" 
                    xmlns:asp="#unknown"></asp:TextBox>
                    <asp:Label ID="lb_error_tipo" runat="server" ForeColor="Red" Text="*" 
                    Visible="False"></asp:Label>
                    <small id="Small1" runat="server" visible=true class="form-text text-muted">1= % del grupo y descuento de los pagados por prestamos.</small>
                    <small id="Small2" runat="server" visible=true class="form-text text-muted">2= % de los que ganan no cobran.</small>
                    <small id="Small3" runat="server" visible=true class="form-text text-muted">3= % del grupo.</small>
                    <small id="Small4" runat="server" visible=true class="form-text text-muted">4= % no tiene calculo.</small>
                    </div>
                    <div class="col-md-2">
                    <label for="Label_porcentaje">Porcentaje:</label>
                    <asp:TextBox ID="Txt_porcentaje" runat="server" placeholder="0,00 %" class="form-control" 
                    CausesValidation="True" validationgroup="check_2" xmlns:asp="#unknown2" 
                    MaxLength="6" onkeydown="tecla_op(event);" onkeypress="return onKeyDecimal(event, this);"></asp:TextBox>
                    <asp:Label ID="lb_error_porcentaje" runat="server" ForeColor="Red" Text="*" 
                    Visible="False"></asp:Label>
                    </div>
                    <div class="col-md-2">
                    <label for="Label_tipo">Ciente Porcentaje:</label>
                    <asp:TextBox ID="Txt_clieporcentaje" runat="server" placeholder="0,00 %" class="form-control" CausesValidation="True" validationgroup="check_2" xmlns:asp="#unknown2" 
                    MaxLength="6" onkeydown="tecla_op(event);" onkeypress="return onKeyDecimal(event, this);"></asp:TextBox>
                    <asp:Label ID="lb_error_clieporcentaje" runat="server" ForeColor="Red" Text="*" 
                    Visible="False"></asp:Label>
                    </div>
                    <div class="col-md-2">
                    <label for="Label_codcobro">Cód. De Cobro:</label>
                    <asp:TextBox ID="Txt_codcobro" runat="server" placeholder="Ingrese opción..." class="form-control" CausesValidation="True" validationgroup="check_3" xmlns:asp="#unknown3" MaxLength="1" onkeydown="tecla_op(event);" onkeypress="return solo_1234_valitation(event);"></asp:TextBox>
            
                    <asp:Label ID="lb_error_codcobro" runat="server" ForeColor="Red" Text="*" 
                    Visible="False"></asp:Label>
                    <small id="Small5" runat="server" visible=true class="form-text text-muted">1= todo.</small>
                    <small id="Small6" runat="server" visible=true class="form-text text-muted">2= sin recibos.</small>
                    <small id="Small7" runat="server" visible=true class="form-text text-muted">3= con computo.</small>
                    <small id="Small8" runat="server" visible=true class="form-text text-muted">4= solo.</small>

                    </div>
            </div>
        </div>

        
        <div class="form-group">
            <div class="row justify-content-center">
                    <div class="col-md-2">
                    <label for="Label_fecha">Fecha de procesamiento:</label>
                    <asp:TextBox ID="Txt_fechaproc" onkeydown="tecla_op(event);" class="form-control" runat="server" TextMode="Date"></asp:TextBox>
                    <asp:Label ID="lb_error_fecha" runat="server" ForeColor="Red" Text="*" Visible="False"></asp:Label>
                    </div>
                    <div class="col-md-6">
                    <label for="Label_fecha">Fecha de procesamiento:</label>
                    <asp:TextBox ID="Txt_importe_fecha" runat="server" placeholder="0,00" class="form-control" CausesValidation="True" validationgroup="check_2" xmlns:asp="#unknown2" 
                    MaxLength="0" onkeydown="tecla_op(event);" onkeypress="return onKeyDecimal(event, this);"></asp:TextBox>
                    </div>

            </div>
        </div>
        <div class="form-group">
            <div class="row justify-content-center">
                    <div class="col-md-4">
                    <asp:Label ID="Lb_error_validacion" runat="server" Font-Bold="True" 
                    ForeColor="Red" Text="Error!" Visible="False"></asp:Label>
                    </div>
                    <div class="col-md-4">
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
            <button type="submit" UseSubmitBehavior="false" class="btn btn-primary" runat="server" id="btn_retroceder" onkeydown="tecla_op_botones(event);">
                ESC = RETROCEDE</button>
            &nbsp;
            </div>

            <div class="form-group">
            <button type="button" class="btn btn-primary" data-toggle="modal" data-target="#Mdl_baja" onkeydown="tecla_op_botones(event);">
                  F4 = DAR DE BAJA
                </button>
            &nbsp;
            </div>

            <div class="form-group">
            <button type="button" id="BOTON_GRABAR" runat="server" class="btn btn-primary" onkeydown="tecla_op_botones(event);"> <%--data-targe="#modal-primary"--%>
                  F8 = GRABA
                </button>
            </div>
        
        </div>
        

</div>
</div>


<div class="modal fade" id="modal-success">
        <div class="modal-dialog">
          <div class="modal-content bg-success">
            <div class="modal-header">
              <h4 class="modal-title">Information</h4>
              <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                <span aria-hidden="true">&times;</span></button>
            </div>
            <div class="modal-body">
              <p>One fine body&hellip;</p>
            </div>
            <div class="modal-footer justify-content-between">
              <button type="button" class="btn btn-outline-light" data-dismiss="modal">Close</button>
              <button type="button" class="btn btn-outline-light">Save changes</button>
            </div>
          </div>
          <!-- /.modal-content -->
        </div>
        <!-- /.modal-dialog -->
      </div>


<!-- Modal GRABA CENTRADO EN PANTALLA -->
<div class="modal fade" id="Mdl_graba" tabindex="-1" role="dialog" aria-labelledby="exampleModalCenterTitle" aria-hidden="true" data-backdrop="static" data-keyboard="false">
  <div class="modal-dialog modal-dialog-centered" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <h5 class="modal-title" id="exampleModalCenterTitle">Graba</h5>
        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
          <span aria-hidden="true">&times;</span>
        </button>
      </div>
      <div class="modal-body">
        ¿Confirma la operación?...
      </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-secondary" data-dismiss="modal">Cancelar</button>
        <button type="button" id="btn_grabar_mdl" class="btn btn-primary" runat="server" data-dismiss="modal">Confirmar</button>
      </div>
    </div>
  </div>
</div>

<!-- Modal BAJA CENTRADO EN PANTALLA -->
<div class="modal fade" id="Mdl_baja" tabindex="-1" role="dialog" aria-labelledby="exampleModalCenterTitle" aria-hidden="true" data-backdrop="static" data-keyboard="false">
  <div class="modal-dialog modal-dialog-centered" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <h5 class="modal-title" id="H1">Dar de Baja</h5>
        <button type="button" id="btn_baja_close" class="close" tabindex="-1" runat="server" data-dismiss="modal" aria-label="Close">
          <span aria-hidden="true">&times;</span>
        </button>
      </div>
      <div class="modal-body">
        ¿Confirma la operación?...
      </div>
      <div class="modal-footer">
        <button type="button" id="btn_baja_mdl_cancelar" class="btn btn-secondary" runat="server" data-dismiss="modal">Cancelar</button>
        <button type="button" id="btn_baja_mdl" class="btn btn-primary" runat="server" data-dismiss="modal">Confirmar</button>
      </div>
    </div>
  </div>
</div>


<%--Modal MENSAJE OK GRABADO--%>
<div class="modal fade" id="modal-sm_OKGRABADO" tabindex="-1" role="dialog" aria-labelledby="exampleModalCenterTitle" aria-hidden="true" data-backdrop="static" data-keyboard="false">
        <div class="modal-dialog modal-sm modal-dialog-centered " role="document">
          <div class="modal-content">
            <div class="modal-header">
              <h4 class="modal-title">Graba</h4>
              <button type="button" id="btn_graba_close" runat="server" class="close" tabindex="-1" data-dismiss="modal" aria-label="Close">
                <span aria-hidden="true">&times;</span>
              </button>
            </div>
            <div class="modal-body">
              <p>Se guardo correctamente!&hellip;</p>
            </div>
            <div class="modal-footer justify-content-center ">
            <%--<div class="modal-footer justify-content-between">--%>
              <%--<button type="button" class="btn btn-default" data-dismiss="modal">Close</button>--%>
              <button type="button" id="btn_ok" runat="server" class="btn btn-primary" data-dismiss="modal">OK</button>
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
