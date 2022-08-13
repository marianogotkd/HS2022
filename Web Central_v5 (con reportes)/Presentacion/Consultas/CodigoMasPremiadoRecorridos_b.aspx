<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Home.Master" CodeBehind="CodigoMasPremiadoRecorridos_b.aspx.vb" Inherits="Presentacion.CodigoMasPremiadoRecorridos_b" %>
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
        ///se anula el enter y va al boton graba
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
                <h3 class="card-title">CODIGO PREMIADO</h3>
          </div>
          <form role="form">
<div class="card-body">
<div class="container-fluid">
<div class="row justify-content-center">
<div class="col-lg"> <%--aqui decia col-lg-6--%>
<div class="card">
        <div class="card-body">
                <div class="form-group">
                        <div class="row justify-content-center">
                                <div class="col-4">
                                        <div class="form-group">
                                                <asp:Label ID="Label_dia" runat="server" Text="DIA:"></asp:Label>
                                                <asp:HiddenField ID="HF_dia_id" runat="server" />
                                        </div>
                                        <div class="form-group">
                                                <asp:HiddenField ID="HF_parametro_id" runat="server" />
                                            <asp:Label ID="LABEL_FECHA" runat="server" Text="FECHA:"></asp:Label>
                                            <asp:TextBox ID="Txt_fecha" onkeydown="tecla_op(event);" runat="server" TextMode="Date"></asp:TextBox>   
                                          <asp:HiddenField ID="HF_fecha" runat="server" />
                                        </div>
                                        <div class="form-group">
                                        <asp:Label ID="Label1" runat="server" Text="Referencia: verde-zonas cargadas."></asp:Label>
                                    </div>
                                    
                                </div>
                                <div class="col-4">
                                    
                                                                        
                                </div>
                                <div class="col-4">
                                    
                                                                        
                                </div>

                        </div>
                </div>

                <div class="form-group">
                        <div class="row">
                                <div class="col">
                                    <asp:Label ID="Label3" runat="server" Text="RECORRIDO 1" ForeColor="#6666FF"></asp:Label>
                                    <br />
                                    <div id = "Div_1A" runat="server" visible="false" >
                                      <asp:CheckBox ID="ChkBox_1A" runat="server" Visible="false" />  
                                      <asp:HiddenField ID="HF_1A_codigo" runat="server" />
                                      <asp:LinkButton ID="LK_1A" runat="server"></asp:LinkButton>
                                        
                                         <br />
                                         <br />
                                    </div>
                                    
                                    <div id = "Div_1B" runat="server" visible="false" >
                                      <asp:CheckBox ID="ChkBox_1B" runat="server" Visible="false"/>   
                                      <asp:HiddenField ID="HF_1B_codigo" runat="server" />
                                            <asp:LinkButton ID="LK_1B" runat="server"></asp:LinkButton>
                                          <br />
                                          <br />
                                    </div>
                                    <div id = "Div_1C" runat="server" visible="false" >
                                      <asp:CheckBox ID="ChkBox_1C" runat="server" Visible="false"/>
                                      <asp:HiddenField ID="HF_1C_codigo" runat="server" />
                                    <asp:LinkButton ID="LK_1C" runat="server"></asp:LinkButton>
                                    <br />
                                    <br />
                                    </div>
                                    <div id = "Div_1D" runat="server" visible="false" >
                                      <asp:CheckBox ID="ChkBox_1D" runat="server" Visible="false"/>
                                      <asp:HiddenField ID="HF_1D_codigo" runat="server" />
                                    <asp:LinkButton ID="LK_1D" runat="server"></asp:LinkButton>
                                    <br />
                                    <br />
                                    </div>
                                    <div id = "Div_1E" runat="server" visible="false" >
                                      <asp:CheckBox ID="ChkBox_1E" runat="server" Visible="false"/>
                                      <asp:HiddenField ID="HF_1E_codigo" runat="server" />
                                    <asp:LinkButton ID="LK_1E" runat="server"></asp:LinkButton>
                                    <br />
                                    <br />
                                    </div>
                                    <div id = "Div_1F" runat="server" visible="false" >
                                      <asp:CheckBox ID="ChkBox_1F" runat="server" Visible="false"/>
                                      <asp:HiddenField ID="HF_1F_codigo" runat="server" />
                                    <asp:LinkButton ID="LK_1F" runat="server"></asp:LinkButton>
                                    <br />
                                    <br />
                                    </div>
                                    <div id = "Div_1G" runat="server" visible="false" >
                                      <asp:CheckBox ID="ChkBox_1G" runat="server" Visible="false"/>
                                      <asp:HiddenField ID="HF_1G_codigo" runat="server" />
                                    <asp:LinkButton ID="LK_1G" runat="server"></asp:LinkButton>
                                    <br />
                                    <br />
                                    </div>
                                    <div id = "Div_1H" runat="server" visible="false" >
                                      <asp:CheckBox ID="ChkBox_1H" runat="server" Visible="false"/>
                                      <asp:HiddenField ID="HF_1H_codigo" runat="server" />
                                    <asp:LinkButton ID="LK_1H" runat="server"></asp:LinkButton>
                                    <br />
                                    <br />
                                    </div>
                                    <div id = "Div_1I" runat="server" visible="false" >
                                      <asp:CheckBox ID="ChkBox_1I" runat="server" Visible="false"/>
                                      <asp:HiddenField ID="HF_1I_codigo" runat="server" />
                                    <asp:LinkButton ID="LK_1I" runat="server"></asp:LinkButton>
                                    <br />
                                    <br />
                                    </div>
                                    <div id = "Div_1J" runat="server" visible="false" >
                                      <asp:CheckBox ID="ChkBox_1J" runat="server" Visible="false"/>
                                      <asp:HiddenField ID="HF_1J_codigo" runat="server" />
                                    <asp:LinkButton ID="LK_1J" runat="server"></asp:LinkButton>
                                    <br />
                                    <br />
                                    </div>
                                    <div id = "Div_1TODAS" runat="server" visible="false" >
                                    <asp:CheckBox ID="ChkBox_1TODAS" runat="server" Visible="false"/>
                                      <asp:HiddenField ID="HF_1TODAS" runat="server" />
                                    <asp:LinkButton ID="LK_1TODOS" runat="server"></asp:LinkButton>
                                    <br />
                                    <br />
                                    </div>
                                </div>

                                <div class="col">
                                <asp:Label ID="Label14" runat="server" Text="RECORRIDO 2" ForeColor="#6666FF"></asp:Label>
                                    <br />
                                    <div id = "Div_2A" runat="server" visible="false" >
                                      <asp:CheckBox ID="ChkBox_2A" runat="server" Visible="false"/>
                                      <asp:HiddenField ID="HF_2A_codigo" runat="server" />
                                    <asp:LinkButton ID="LK_2A" runat="server"></asp:LinkButton>
                                    <br />
                                    <br />
                                    </div>
                                    <div id = "Div_2B" runat="server" visible="false" >
                                      <asp:CheckBox ID="ChkBox_2B" runat="server" Visible="false"/>
                                      <asp:HiddenField ID="HF_2B_codigo" runat="server" />
                                    <asp:LinkButton ID="LK_2B" runat="server"></asp:LinkButton>
                                    <br />
                                    <br />
                                    </div>
                                    <div id = "Div_2C" runat="server" visible="false" >
                                      <asp:CheckBox ID="ChkBox_2C" runat="server" Visible="false"/>
                                      <asp:HiddenField ID="HF_2C_codigo" runat="server" />
                                    <asp:LinkButton ID="LK_2C" runat="server"></asp:LinkButton>
                                    <br />
                                    <br />
                                    </div>
                                    <div id = "Div_2D" runat="server" visible="false" >
                                      <asp:CheckBox ID="ChkBox_2D" runat="server" Visible="false"/>
                                      <asp:HiddenField ID="HF_2D_codigo" runat="server" />
                                    <asp:LinkButton ID="LK_2D" runat="server"></asp:LinkButton>
                                    <br />
                                    <br />
                                    </div>
                                    <div id = "Div_2E" runat="server" visible="false" >
                                      <asp:CheckBox ID="ChkBox_2E" runat="server" Visible="false"/>
                                      <asp:HiddenField ID="HF_2E_codigo" runat="server" />
                                    <asp:LinkButton ID="LK_2E" runat="server"></asp:LinkButton>
                                    <br />
                                    <br />
                                    </div>
                                    <div id = "Div_2F" runat="server" visible="false" >
                                      <asp:CheckBox ID="ChkBox_2F" runat="server" Visible="false"/>
                                      <asp:HiddenField ID="HF_2F_codigo" runat="server" />
                                    <asp:LinkButton ID="LK_2F" runat="server"></asp:LinkButton>
                                    <br />
                                    <br />
                                    </div>
                                    <div id = "Div_2G" runat="server" visible="false" >
                                      <asp:CheckBox ID="ChkBox_2G" runat="server" Visible="false"/>
                                      <asp:HiddenField ID="HF_2G_codigo" runat="server" />
                                    <asp:LinkButton ID="LK_2G" runat="server"></asp:LinkButton>
                                    <br />
                                    <br />
                                    </div>
                                    <div id = "Div_2H" runat="server" visible="false" >
                                      <asp:CheckBox ID="ChkBox_2H" runat="server" Visible="false"/>
                                      <asp:HiddenField ID="HF_2H_codigo" runat="server" />
                                    <asp:LinkButton ID="LK_2H" runat="server"></asp:LinkButton>
                                    <br />
                                    <br />
                                    </div>
                                    <div id = "Div_2I" runat="server" visible="false" >
                                      <asp:CheckBox ID="ChkBox_2I" runat="server" Visible="false"/>
                                      <asp:HiddenField ID="HF_2I_codigo" runat="server" />
                                    <asp:LinkButton ID="LK_2I" runat="server"></asp:LinkButton>
                                    <br />
                                    <br />
                                    </div>
                                    <div id = "Div_2J" runat="server" visible="false" >
                                      <asp:CheckBox ID="ChkBox_2J" runat="server" Visible="false"/>
                                      <asp:HiddenField ID="HF_2J_codigo" runat="server" />
                                    <asp:LinkButton ID="LK_2J" runat="server"></asp:LinkButton>
                                    <br />
                                    <br />
                                    </div>
                                    <div id = "Div_2TODAS" runat="server" visible="false" >
                                    <asp:CheckBox ID="ChkBox_2TODAS" runat="server" Visible="false"/>
                                      <asp:HiddenField ID="HF_2TODAS" runat="server" />
                                    <asp:LinkButton ID="LK_2TODAS" runat="server"></asp:LinkButton>
                                    <br />
                                    <br />
                                    </div>
                                </div>

                                <div class="col">
                                <asp:Label ID="Label25" runat="server" Text="RECORRIDO 3" ForeColor="#6666FF"></asp:Label>
                                    <br />
                                    <div id = "Div_3A" runat="server" visible="false" >
                                      <asp:CheckBox ID="ChkBox_3A" runat="server" Visible="false"/>
                                      <asp:HiddenField ID="HF_3A_codigo" runat="server" />
                                    <asp:LinkButton ID="LK_3A" runat="server"></asp:LinkButton>
                                    <br />
                                    <br />
                                    </div>
                                    <div id = "Div_3B" runat="server" visible="false" >
                                      <asp:CheckBox ID="ChkBox_3B" runat="server" Visible="false"/>
                                      <asp:HiddenField ID="HF_3B_codigo" runat="server" />
                                    <asp:LinkButton ID="LK_3B" runat="server"></asp:LinkButton>
                                    <br />
                                    <br />
                                    </div>
                                    <div id = "Div_3C" runat="server" visible="false" >
                                      <asp:CheckBox ID="ChkBox_3C" runat="server" Visible="false"/>
                                      <asp:HiddenField ID="HF_3C_codigo" runat="server" />
                                    <asp:LinkButton ID="LK_3C" runat="server"></asp:LinkButton>
                                    <br />
                                    <br />
                                    </div>
                                    <div id = "Div_3D" runat="server" visible="false" >
                                      <asp:CheckBox ID="ChkBox_3D" runat="server" Visible="false"/>
                                      <asp:HiddenField ID="HF_3D_codigo" runat="server" />
                                    <asp:LinkButton ID="LK_3D" runat="server"></asp:LinkButton>
                                    <br />
                                    <br />
                                    </div>
                                    <div id = "Div_3E" runat="server" visible="false" >
                                      <asp:CheckBox ID="ChkBox_3E" runat="server" Visible="false"/>
                                      <asp:HiddenField ID="HF_3E_codigo" runat="server" />
                                    <asp:LinkButton ID="LK_3E" runat="server"></asp:LinkButton>
                                    <br />
                                    <br />
                                    </div>
                                    <div id = "Div_3F" runat="server" visible="false" >
                                      <asp:CheckBox ID="ChkBox_3F" runat="server" Visible="false"/>
                                      <asp:HiddenField ID="HF_3F_codigo" runat="server" />
                                    <asp:LinkButton ID="LK_3F" runat="server"></asp:LinkButton>
                                    <br />
                                    <br />
                                    </div>
                                    <div id = "Div_3G" runat="server" visible="false" >
                                      <asp:CheckBox ID="ChkBox_3G" runat="server" Visible="false"/>
                                      <asp:HiddenField ID="HF_3G_codigo" runat="server" />
                                    <asp:LinkButton ID="LK_3G" runat="server"></asp:LinkButton>
                                    <br />
                                    <br />
                                    </div>
                                    <div id = "Div_3H" runat="server" visible="false" >
                                      <asp:CheckBox ID="ChkBox_3H" runat="server" Visible="false"/>
                                      <asp:HiddenField ID="HF_3H_codigo" runat="server" />
                                    <asp:LinkButton ID="LK_3H" runat="server"></asp:LinkButton>
                                    <br />
                                    <br />
                                    </div>
                                    <div id = "Div_3I" runat="server" visible="false" >
                                      <asp:CheckBox ID="ChkBox_3I" runat="server" Visible="false"/>
                                      <asp:HiddenField ID="HF_3I_codigo" runat="server" />
                                    <asp:LinkButton ID="LK_3I" runat="server"></asp:LinkButton>
                                    <br />
                                    <br />
                                    </div>
                                    <div id = "Div_3J" runat="server" visible="false" >
                                      <asp:CheckBox ID="ChkBox_3J" runat="server" Visible="false"/>
                                      <asp:HiddenField ID="HF_3J_codigo" runat="server" />
                                    <asp:LinkButton ID="LK_3J" runat="server"></asp:LinkButton>
                                    <br />
                                    <br />
                                    </div>
                                    <div id = "Div_3TODAS" runat="server" visible="false" >
                                    <asp:CheckBox ID="ChkBox_3TODAS" runat="server" Visible="false"/>
                                      <asp:HiddenField ID="HF_3TODAS" runat="server" />
                                    <asp:LinkButton ID="LK_3TODAS" runat="server"></asp:LinkButton>
                                    <br />
                                    <br />
                                    </div>
                                </div>

                                <div class="col">
                                <asp:Label ID="Label36" runat="server" Text="RECORRIDO 4" Font-Bold="False" 
                                        ForeColor="#6666FF"></asp:Label>
                                    <br />
                                    <div id = "Div_4A" runat="server" visible="false" >
                                      <asp:CheckBox ID="ChkBox_4A" runat="server" Visible="false"/>
                                      <asp:HiddenField ID="HF_4A_codigo" runat="server" />
                                    <asp:LinkButton ID="LK_4A" runat="server"></asp:LinkButton>
                                    <br />
                                    <br />
                                    </div>
                                    <div id = "Div_4B" runat="server" visible="false" >
                                      <asp:CheckBox ID="ChkBox_4B" runat="server" Visible="false"/>
                                      <asp:HiddenField ID="HF_4B_codigo" runat="server" />
                                    <asp:LinkButton ID="LK_4B" runat="server"></asp:LinkButton>
                                    <br />
                                    <br />
                                    </div>
                                    <div id = "Div_4C" runat="server" visible="false" >
                                      <asp:CheckBox ID="ChkBox_4C" runat="server" Visible="false"/>
                                      <asp:HiddenField ID="HF_4C_codigo" runat="server" />
                                    <asp:LinkButton ID="LK_4C" runat="server"></asp:LinkButton>
                                    <br />
                                    <br />
                                    </div>
                                    <div id = "Div_4D" runat="server" visible="false" >
                                      <asp:CheckBox ID="ChkBox_4D" runat="server" Visible="false"/>
                                      <asp:HiddenField ID="HF_4D_codigo" runat="server" />
                                    <asp:LinkButton ID="LK_4D" runat="server"></asp:LinkButton>
                                    <br />
                                    <br />
                                    </div>
                                    <div id = "Div_4E" runat="server" visible="false" >
                                      <asp:CheckBox ID="ChkBox_4E" runat="server" Visible="false"/>
                                      <asp:HiddenField ID="HF_4E_codigo" runat="server" />
                                    <asp:LinkButton ID="LK_4E" runat="server"></asp:LinkButton>
                                    <br />
                                    <br />
                                    </div>
                                    <div id = "Div_4F" runat="server" visible="false" >
                                      <asp:CheckBox ID="ChkBox_4F" runat="server" Visible="false"/>
                                      <asp:HiddenField ID="HF_4F_codigo" runat="server" />
                                    <asp:LinkButton ID="LK_4F" runat="server"></asp:LinkButton>
                                    <br />
                                    <br />
                                    </div>
                                    <div id = "Div_4G" runat="server" visible="false" >
                                      <asp:CheckBox ID="ChkBox_4G" runat="server" Visible="false"/>
                                      <asp:HiddenField ID="HF_4G_codigo" runat="server" />
                                    <asp:LinkButton ID="LK_4G" runat="server"></asp:LinkButton>
                                    <br />
                                    <br />
                                    </div>
                                    <div id = "Div_4H" runat="server" visible="false" >
                                      <asp:CheckBox ID="ChkBox_4H" runat="server" Visible="false"/>
                                      <asp:HiddenField ID="HF_4H_codigo" runat="server" />
                                    <asp:LinkButton ID="LK_4H" runat="server"></asp:LinkButton>
                                    <br />
                                    <br />
                                    </div>
                                    <div id = "Div_4I" runat="server" visible="false" >
                                      <asp:CheckBox ID="ChkBox_4I" runat="server" Visible="false"/>
                                      <asp:HiddenField ID="HF_4I_codigo" runat="server" />
                                    <asp:LinkButton ID="LK_4I" runat="server"></asp:LinkButton>
                                    <br />
                                    <br />
                                    </div>
                                    <div id = "Div_4J" runat="server" visible="false" >
                                      <asp:CheckBox ID="ChkBox_4J" runat="server" Visible="false"/>
                                      <asp:HiddenField ID="HF_4J_codigo" runat="server" />
                                    <asp:LinkButton ID="LK_4J" runat="server"></asp:LinkButton>
                                    <br />
                                    <br />
                                    </div>
                                    <div id = "Div_4TODAS" runat="server" visible="false" >
                                      <asp:CheckBox ID="ChkBox_4TODAS" runat="server" Visible="false"/>
                                      <asp:HiddenField ID="HF_4TODAS" runat="server" />
                                    <asp:LinkButton ID="LK_4TODAS" runat="server"></asp:LinkButton>
                                    <br />
                                    <br />
                                    </div>
                                </div>


                          <div class="col">
                                <asp:Label ID="Label2" runat="server" Text="RECORRIDO 5" Font-Bold="False" 
                                        ForeColor="#6666FF"></asp:Label>
                                    <br />
                                    <div id = "Div_5A" runat="server" visible="false" >
                                      <asp:CheckBox ID="ChkBox_5A" runat="server" Visible="false"/>
                                      <asp:HiddenField ID="HF_5A_codigo" runat="server" />
                                    <asp:LinkButton ID="LK_5A" runat="server"></asp:LinkButton>
                                    <br />
                                    <br />
                                    </div>
                                    <div id = "Div_5B" runat="server" visible="false" >
                                      <asp:CheckBox ID="ChkBox_5B" runat="server" Visible="false"/>
                                      <asp:HiddenField ID="HF_5B_codigo" runat="server" />
                                    <asp:LinkButton ID="LK_5B" runat="server"></asp:LinkButton>
                                    <br />
                                    <br />
                                    </div>
                                    <div id = "Div_5C" runat="server" visible="false" >
                                      <asp:CheckBox ID="ChkBox_5C" runat="server" Visible="false"/>
                                      <asp:HiddenField ID="HF_5C_codigo" runat="server" />
                                    <asp:LinkButton ID="LK_5C" runat="server"></asp:LinkButton>
                                    <br />
                                    <br />
                                    </div>
                                    <div id = "Div_5D" runat="server" visible="false" >
                                      <asp:CheckBox ID="ChkBox_5D" runat="server" Visible="false"/>
                                      <asp:HiddenField ID="HF_5D_codigo" runat="server" />
                                    <asp:LinkButton ID="LK_5D" runat="server"></asp:LinkButton>
                                    <br />
                                    <br />
                                    </div>
                                    <div id = "Div_5E" runat="server" visible="false" >
                                      <asp:CheckBox ID="ChkBox_5E" runat="server" Visible="false"/>
                                      <asp:HiddenField ID="HF_5E_codigo" runat="server" />
                                    <asp:LinkButton ID="LK_5E" runat="server"></asp:LinkButton>
                                    <br />
                                    <br />
                                    </div>
                                    <div id = "Div_5F" runat="server" visible="false" >
                                      <asp:CheckBox ID="ChkBox_5F" runat="server" Visible="false"/>
                                      <asp:HiddenField ID="HF_5F_codigo" runat="server" />
                                    <asp:LinkButton ID="LK_5F" runat="server"></asp:LinkButton>
                                    <br />
                                    <br />
                                    </div>
                                    <div id = "Div_5G" runat="server" visible="false" >
                                      <asp:CheckBox ID="ChkBox_5G" runat="server" Visible="false"/>
                                      <asp:HiddenField ID="HF_5G_codigo" runat="server" />
                                    <asp:LinkButton ID="LK_5G" runat="server"></asp:LinkButton>
                                    <br />
                                    <br />
                                    </div>
                                    <div id = "Div_5H" runat="server" visible="false" >
                                      <asp:CheckBox ID="ChkBox_5H" runat="server" Visible="false"/>
                                      <asp:HiddenField ID="HF_5H_codigo" runat="server" />
                                    <asp:LinkButton ID="LK_5H" runat="server"></asp:LinkButton>
                                    <br />
                                    <br />
                                    </div>
                                    <div id = "Div_5I" runat="server" visible="false" >
                                      <asp:CheckBox ID="ChkBox_5I" runat="server" Visible="false"/>
                                      <asp:HiddenField ID="HF_5I_codigo" runat="server" />
                                    <asp:LinkButton ID="LK_5I" runat="server"></asp:LinkButton>
                                    <br />
                                    <br />
                                    </div>
                                    <div id = "Div_5J" runat="server" visible="false" >
                                      <asp:CheckBox ID="ChkBox_5J" runat="server" Visible="false"/>
                                      <asp:HiddenField ID="HF_5J_codigo" runat="server" />
                                    <asp:LinkButton ID="LK_5J" runat="server"></asp:LinkButton>
                                    <br />
                                    <br />
                                    </div>
                                    <div id = "Div_5TODAS" runat="server" visible="false" >
                                      <asp:CheckBox ID="ChkBox_5TODAS" runat="server" Visible="false"/>
                                      <asp:HiddenField ID="HF_5TODAS" runat="server" />
                                    <asp:LinkButton ID="LK_5TODAS" runat="server"></asp:LinkButton>
                                    <br />
                                    <br />
                                    </div>
                                </div>


                        </div>
                </div>
                <div class="form-group">
                        <div class="row justify-content-center">
                                <div class="col-4">
                                    <asp:Label ID="Labl2" runat="server" Text="ZONA:"></asp:Label>
                                    <asp:TextBox ID="txt_zona" runat="server" MaxLength="2" Width="50px" onkeydown="tecla_op(event);"></asp:TextBox>
                                
                                </div>
                        </div>
                </div>
          <div class="form-group">
              <div class="row justify-content-center">
                <div class="col-4">


                </div>
              </div>
          </div>
            


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
            <button type="button" id="BOTON_GRABAR" runat="server" class="btn btn-primary" onkeydown="tecla_op_botones(event);"> <%--data-targe="#modal-primary"--%>
                  F8 = CONTINUA
                </button>
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

      <%--Modal MENSAJE ERROR OK 1--%>
<div class="modal fade" id="modal-ok_error" tabindex="-1" role="dialog" aria-labelledby="exampleModalCenterTitle" aria-hidden="true" data-backdrop="static" data-keyboard="false">
        <div class="modal-dialog modal-sm modal-dialog-centered " role="document">
          <div class="modal-content">
            <div class="modal-header">
              <h4 class="modal-title">Error</h4>
              <button type="button" id="btn_error_close" runat="server" class="close" tabindex="-1" data-dismiss="modal" aria-label="Close">
                <span aria-hidden="true">&times;</span>
              </button>
            </div>
            <div class="modal-body">
              <p>Error, primero debe iniciar dia!&hellip;</p>
            </div>
            <div class="modal-footer justify-content-center ">
            <%--<div class="modal-footer justify-content-between">--%>
              <%--<button type="button" class="btn btn-default" data-dismiss="modal">Close</button>--%>
              <button type="button" id="btn_ok_error" runat="server" class="btn btn-primary" data-dismiss="modal">OK</button>
            </div>
          </div>
          <!-- /.modal-content -->
        </div>
        <!-- /.modal-dialog -->
      </div>
      <!-- /.modal -->


      <%--Modal MENSAJE OK ERROR SIN SELECCION--%>
<div class="modal fade" id="modal_msjerror_liq01" tabindex="-1" role="dialog" aria-labelledby="exampleModalCenterTitle" aria-hidden="true" data-backdrop="static" data-keyboard="false">
        <div class="modal-dialog modal-sm modal-dialog-centered " role="document">
          <div class="modal-content">
            <div class="modal-header">
              <h4 class="modal-title">Error</h4>
              <button type="button" id="btn_close_error_liq01" runat="server" class="close" tabindex="-1" data-dismiss="modal" aria-label="Close">
                <span aria-hidden="true">&times;</span>
              </button>
            </div>
            <div class="modal-body">
              <p>No se seleccinó ningun item!&hellip;</p>
            </div>
            <div class="modal-footer justify-content-center ">
            <%--<div class="modal-footer justify-content-between">--%>
              <%--<button type="button" class="btn btn-default" data-dismiss="modal">Close</button>--%>
              <button type="button" id="btn_ok_error_liq01" runat="server" class="btn btn-primary" data-dismiss="modal">OK</button>
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
