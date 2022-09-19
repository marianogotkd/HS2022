<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/MasterPage.Master" CodeBehind="Examenes_turnos_agregar.aspx.vb" Inherits="fitfa.Examenes_turnos_agregar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">



    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <div class="card card-primary">
        <div class="card-header">
                <h3 class="card-title">Nuevo Evento - seleccion de turnos.</h3>
  
        </div>
        
        <form role="form">
        <div class="card-body">
        <div class="row">
        <div class="col-md-4 col-center">
        <div class="form-group">
        <label>Capacidad máxima de inscriptos por turno: </label>
        <asp:TextBox ID="tb_capacidad_max" CssClass="form-control" runat="server" ></asp:TextBox>  
        </div>
        
        <div class="form-group">
        <label>Seleccione los turnos: </label>
        <div class="card-body table-responsive p-0">
            <asp:GridView ID="GridView1" runat="server" BorderColor="Black" GridLines="None">
                <Columns>
                    <asp:BoundField DataField="Turno" HeaderText="Turno" ReadOnly="True" />
                    <asp:CheckBoxField HeaderText="Seleccionar" />
                </Columns>
            </asp:GridView>
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
