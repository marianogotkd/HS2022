<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Home.Master" CodeBehind="Grupos_alta.aspx.vb" Inherits="Presentacion.Grupos_alta" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style2
        {
            width: 100%;
        }
        .style6
        {
            width: 146px;
        }
        .style10
        {
            width: 260px;
        }
        .style11
        {
            width: 235px;
        }
    </style>

    <script>
//        windows.onload = function () {

//            document.getElementsByTagName('button')[0].addEventListener("click", aceptar);

        //        }



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





    </script>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" 
                        EnableScriptGlobalization="True">
</asp:ScriptManager>
<asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
<ContentTemplate>


    <asp:Panel ID="Panel1" runat="server">
    </asp:Panel>



<div class="card card-primary">
<div class="card-header">
                <h3 class="card-title">A.B.M. GRUPOS</h3>
</div>
<form role="form">
<div class="card-body">
<div class="container-fluid">
<div class="row justify-content-center">
<div class="col-lg-6">
<div class="card">
<div class="card-body">
<div class="form-group">
<table class="style2">
        <tr>
            <td class="style10">
                <asp:Label ID="Label_grupo_id0" runat="server" Text="Grupo:"></asp:Label>
                &nbsp;<asp:TextBox ID="Txt_grupo_codigo" runat="server" Visible="true"   
                    Width="62px" onkeydown="tecla_op(event);" onkeypress="return justNumbers(event);"></asp:TextBox>
                <asp:Label ID="lb_error_codigo" runat="server" ForeColor="Red" Text="*" 
                    Visible="False"></asp:Label>
                <asp:HiddenField ID="HF_grupo_id" runat="server" />
            </td>
        </tr>
        
    </table>

</div>

<div class="form-group">
<table class="style2">
        <tr>
            <td class="style10">
                <asp:Label ID="Label_grupo_nomb" runat="server" Text="Nombre:"></asp:Label>
                &nbsp;<asp:TextBox ID="Txt_grupo_nomb" onkeydown="tecla_op(event);" runat="server"></asp:TextBox>
                <asp:Label ID="lb_error_nombre" runat="server" ForeColor="Red" Text="*" 
                    Visible="False"></asp:Label>
            </td>
        </tr>
    </table>
</div>



<div class="form-group">
   
    <table class="w-100">
        <tr>
            <td class="style6">
                <asp:Label ID="Label_tipo" runat="server" Text="Tipo:"></asp:Label>
                &nbsp;<asp:TextBox ID="Txt_tipo" runat="server" CausesValidation="True" 
                    MaxLength="1" onkeydown="tecla_op(event);" onkeypress="return justNumbers(event);" 
                    ToolTip="Ingrese tipo (1,2,3,4)" validationgroup="check" Width="62px" 
                    xmlns:asp="#unknown"></asp:TextBox>
                <asp:Label ID="lb_error_tipo" runat="server" ForeColor="Red" Text="*" 
                    Visible="False"></asp:Label>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                    controltovalidate="Txt_tipo" ErrorMessage="Error!" Font-Size="X-Small" 
                    ForeColor="Red" SetFocusOnError="True" ValidationExpression="[1234]" 
                    ValidationGroup="check" xmlns:asp="#unknown"></asp:RegularExpressionValidator>
                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="Txt_tipo" ErrorMessage="Campo requerido"  
                    SetFocusOnError="True" InitialValue=" "></asp:RequiredFieldValidator>--%>
            </td>
            <td>
                <asp:Label ID="Label_tipo1" runat="server" 
                    Text="1= % del grupo y descuento de los pagados por prestamos."></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style6">
                &nbsp;</td>
            <td>
                <asp:Label ID="Label_tipo2" runat="server" 
                    Text="2= % de los que ganan no cobran."></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style6">
                &nbsp;</td>
            <td>
                <asp:Label ID="Label_tipo3" runat="server" Text="3= % del grupo."></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style6">
                &nbsp;</td>
            <td>
                <asp:Label ID="Labeltipo4" runat="server" Text="4= no tiene calculo."></asp:Label>
            </td>
        </tr>
    </table>


</div>

<div class="form-group">

    <asp:Label ID="Label_porcentaje" runat="server" Text="Porcentaje:"></asp:Label>
    &nbsp;<asp:TextBox ID="Txt_porcentaje" runat="server" Width="62px" 
        CausesValidation="True" validationgroup="check_2" xmlns:asp="#unknown2" 
        MaxLength="6" onkeydown="tecla_op(event);" onkeypress="return onKeyDecimal(event, this);"></asp:TextBox>
        <asp:Label ID="lb_error_porcentaje" runat="server" ForeColor="Red" Text="*" 
        Visible="False"></asp:Label>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
        ControlToValidate="Txt_porcentaje" xmlns:asp="#unknown2" ErrorMessage="Error!" ValidationExpression="^\d+\.\d{1,2}$|^\d+\,\d{1,2}$|^\d+$" Font-Size="X-Small" 
        ForeColor="Red" ValidationGroup="check_2" SetFocusOnError="True"></asp:RegularExpressionValidator>
        <%--uso una expresion regular(enteros/enteros2decimales con punto/entero2decimales con coma)--%>
</div>

<div class="form-group">

    <asp:Label ID="Label_clieporcentaje" runat="server" Text="Cliente Porcentaje:" ></asp:Label>
    &nbsp;<asp:TextBox ID="Txt_clieporcentaje" runat="server" CausesValidation="True" validationgroup="check_2" xmlns:asp="#unknown2" Width="62px" 
        MaxLength="6" onkeydown="tecla_op(event);" onkeypress="return onKeyDecimal(event, this);"></asp:TextBox>

        

    <asp:Label ID="lb_error_clieporcentaje" runat="server" ForeColor="Red" Text="*" 
        Visible="False"></asp:Label>

        

    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" 
        ControlToValidate="Txt_clieporcentaje" ErrorMessage="Error!" Font-Size="X-Small" 
        ForeColor="Red" SetFocusOnError="True" 
        ValidationExpression="^\d+\.\d{1,2}$|^\d+\,\d{1,2}$|^\d+$" 
        ValidationGroup="check_2" xmlns:asp="#unknown2"></asp:RegularExpressionValidator>

        

</div>

<div class="form-group">


    
    <table class="w-100">
        <tr>
            <td class="style11">
                <asp:Label ID="Label_codcobro" runat="server" Text="Código de Cobro:"></asp:Label>
                &nbsp;<asp:TextBox ID="Txt_codcobro" runat="server" CausesValidation="True" validationgroup="check_3" xmlns:asp="#unknown3" Width="62px" MaxLength="1" onkeydown="tecla_op(event);" onkeypress="return justNumbers(event);"></asp:TextBox>
            
                <asp:Label ID="lb_error_codcobro" runat="server" ForeColor="Red" Text="*" 
                    Visible="False"></asp:Label>
            
                <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="Txt_codcobro" 
                    ErrorMessage="Error!" Font-Size="X-Small" ForeColor="Red" SetFocusOnError="True" ValidationExpression="[1234]" ValidationGroup="check_3" xmlns:asp="#unknown3"></asp:RegularExpressionValidator>
            
            </td>
            <td>
                <asp:Label ID="Label_cobro1" runat="server" Text="1= todo."></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style11">
                &nbsp;</td>
            <td>
                <asp:Label ID="Label_cobro2" runat="server" Text="2= sin recibos."></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style11">
                &nbsp;</td>
            <td>
                <asp:Label ID="Label_cobro3" runat="server" Text="3= con computo."></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style11">
                &nbsp;</td>
            <td>
                <asp:Label ID="Label_cobro4" runat="server" Text="4= solo."></asp:Label>
            </td>
        </tr>
    </table>

</div>

<div class="form-group">

    <asp:Label ID="Label_fechaproc" runat="server" Text="Fecha de procesamiento:"></asp:Label>
    &nbsp;<asp:TextBox ID="Txt_fechaproc" onkeydown="tecla_op(event);" runat="server" TextMode="Date"></asp:TextBox>

    


    <asp:Label ID="lb_error_fecha" runat="server" ForeColor="Red" Text="*" 
        Visible="False"></asp:Label>
    <br />
    <br />
    <asp:Label ID="Lb_error_validacion" runat="server" Font-Bold="True" 
        ForeColor="Red" Text="Error!" Visible="False"></asp:Label>
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


                          

<%--<form role="form">
              <div class="card-body"> 
              <div class="row">
                <div class="col-sm-4" align="center"></div>
                <div class="col-sm-4" align="center">
                    
                      
    
                </div>
                <div class="col-sm-4" align="center"></div>
                </div>
              </div>
</form>--%>
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
