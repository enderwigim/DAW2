<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Empleados.aspx.cs" Inherits="GesPresta.WebForm1" %>

<%@ Register Src="~/Cabecera.ascx" TagPrefix="uc1" TagName="Cabecera" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <uc1:Cabecera runat="server" ID="Cabecera" />
        </div>
        <div>
            <div class="empleado_container">
                <label>Código Empleado</label>
                <asp:TextBox ID="txtCodEmp" runat="server"></asp:TextBox>

            </div>
            <div class="empleado_container">
                <label>NIF</label>
                <asp:TextBox ID="txtNifEmp" runat="server"></asp:TextBox>
            </div>
            <div class="empleado_container">
                <label>Apellidos y Nombre</label>
                <asp:TextBox ID="txtNomEmp" runat="server"></asp:TextBox>

            </div>
            <div class="empleado_container">
                <label>Dirección</label>
                <asp:TextBox ID="txtDirEmp" runat="server"></asp:TextBox>
            </div>
            
            <div class="empleado_container">
                <label>Ciudad</label>
                <asp:TextBox ID="txtCiuEmp" runat="server"></asp:TextBox>
            </div>
            <div class="empleado_container">
                <label>Telefono</label>
                <asp:TextBox ID="txtTelEmp" runat="server"></asp:TextBox>
            </div>
            <div class="empleado_container">
                <label>Fecha de nacimiento</label>
                <asp:TextBox ID="txtFnaEmp" runat="server"></asp:TextBox>
            </div>
            <div class="empleado_container">
                <label>Fecha de ingreso</label>
                <asp:TextBox ID="txtFinEmp" runat="server"></asp:TextBox>
            </div>
            <div class="empleado_container">
                <label>Sexo</label>
                <asp:RadioButtonList ID="rblSexEmp" runat="server">
                    <asp:ListItem Value="H">Hombre</asp:ListItem>
                    <asp:ListItem Value="M">Mujer</asp:ListItem>
                </asp:RadioButtonList>
            </div>
            <div class="empleado_container">
                <label>Departamento</label>
                <asp:DropDownList ID="DropDownList1" runat="server">
                    <asp:ListItem Selected="True">Investigación</asp:ListItem>
                    <asp:ListItem>Desarrollo</asp:ListItem>
                    <asp:ListItem>Innovación</asp:ListItem>
                    <asp:ListItem>Administración</asp:ListItem>
                </asp:DropDownList>
            </div>
        </div>

        <asp:Button ID="ddlDepEmp" runat="server" Text="Enviar" Width="95px" />

    </form>
</body>
</html>
