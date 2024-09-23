<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Empleados.aspx.cs" Inherits="GesPresta.Empleados" %>

<%@ Register Src="~/Cabecera.ascx" TagPrefix="uc1" TagName="Cabecera" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
<link rel="stylesheet" type="text/css" href="styles.css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <uc1:Cabecera runat="server" ID="Cabecera" />
    </div>

    <div class="initial-form">
        <div class="line">
            <div class="text">
                Código Empleado
            </div>
            <div class="control">
                <asp:TextBox ID="txtCodEmp" runat="server" Width="200px"></asp:TextBox>
            </div>
        </div>

        <div class="line">
            <div class="text">
                NIF
            </div>
            <div class="control">
                <asp:TextBox ID="txtNifEmp" runat="server" Width="200px"></asp:TextBox>
            </div>
        </div>

        <div class="line">
            <div class="text">
                Apellidos y Nombre
            </div>
            <div class="control">
                <asp:TextBox ID="txtNomEmp" runat="server" Width="200px"></asp:TextBox>
            </div>
        </div>

        <div class="line">
            <div class="text">
                Dirección
            </div>
            <div class="control">
                <asp:TextBox ID="txtDirEmp" runat="server" Width="200px"></asp:TextBox>
            </div>
        </div>

        <div class="line">
            <div class="text">
                Ciudad
            </div>
            <div class="control">
                <asp:TextBox ID="txtCiuEmp" runat="server" Width="200px"></asp:TextBox>
            </div>
        </div>

        <div class="line">
            <div class="text">
                Teléfono
            </div>
            <div class="control">
                <asp:TextBox ID="txtTelEmp" runat="server" Width="200px"></asp:TextBox>
            </div>
        </div>

        <div class="line">
            <div class="text">
                Fecha de nacimiento
            </div>
            <div class="control">
                <asp:TextBox ID="txtFnaEmp" runat="server" Width="200px"></asp:TextBox>
            </div>
        </div>

        <div class="line">
            <div class="text">
                Fecha de ingreso
            </div>
            <div class="control">
                <asp:TextBox ID="txtFinEmp" runat="server" Width="200px"></asp:TextBox>
            </div>
        </div>

        <div class="line">
            <div class="text">
                Sexo
            </div>
            <div class="control">
                <asp:RadioButtonList ID="rblSexEmp" runat="server" RepeatDirection="Horizontal">
                    <asp:ListItem Value="H">Hombre</asp:ListItem>
                    <asp:ListItem Value="M">Mujer</asp:ListItem>
                </asp:RadioButtonList>
            </div>
        </div>

        <div class="line">
            <div class="text">
                Departamento
            </div>
            <div class="control">
                <asp:DropDownList ID="DropDownList1" runat="server">
                    <asp:ListItem Selected="True">Investigación</asp:ListItem>
                    <asp:ListItem>Desarrollo</asp:ListItem>
                    <asp:ListItem>Innovación</asp:ListItem>
                    <asp:ListItem>Administración</asp:ListItem>
                </asp:DropDownList>
            </div>
        </div>
    </div>

    <div class="btn">
        <br />
        <asp:Button ID="ddlDepEmp" runat="server" Text="Enviar" Width="95px" />
    </div>
</form>
</body>
</html>
