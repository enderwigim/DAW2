﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Empleados.aspx.cs" Inherits="GesPresta.Empleados" %>

<%@ Register Src="~/Cabecera.ascx" TagPrefix="uc1" TagName="Cabecera" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link rel="stylesheet" type="text/css" href="bodyStyle.css" />
    <link rel="stylesheet" type="text/css" href="header.css" />
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
                <asp:RequiredFieldValidator ID="rqdTxtCodEmp" runat="server" ErrorMessage="El Codigo Empleado es obligatorio" ControlToValidate="txtCodEmp"></asp:RequiredFieldValidator>
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
                <asp:RequiredFieldValidator ID="rqdTxtNifEmp" runat="server" ErrorMessage="El NIF es obligatorio" ControlToValidate="txtNifEmp"></asp:RequiredFieldValidator>
            </div>
        </div>

        <div class="line">
            <div class="text">
                Apellidos y Nombre
                <asp:RequiredFieldValidator ID="rqdTxtNomEmp" runat="server" ErrorMessage="El Apellidos y Nombre es obligatorio" ControlToValidate="txtNomEmp"></asp:RequiredFieldValidator>
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
                <asp:RequiredFieldValidator ID="rdqTxtTelEmp" runat="server" ErrorMessage="El Telefono es obligatorio" ControlToValidate="txtTelEmp"></asp:RequiredFieldValidator>

            </div>
            <div class="control">
                <asp:TextBox ID="txtTelEmp" runat="server" Width="200px"></asp:TextBox>
            </div>
        </div>

        <div class="line">
            <div class="text">
                Fecha de nacimiento
                <asp:RequiredFieldValidator ID="rdqTxtFnaEmp" runat="server"  ErrorMessage="La fecha de nacimiento es obligatoria" ControlToValidate="txtFnaEmp"></asp:RequiredFieldValidator>
            </div>
            <div class="control">
                <asp:TextBox ID="txtFnaEmp" runat="server" Width="200px"></asp:TextBox>
            </div>
        </div>

        <div class="line">
            <div class="text">
                <asp:RequiredFieldValidator ID="rdqTxtFinEmp" runat="server" ErrorMessage="La fecha de nacimiento es obligatoria" ControlToValidate="txtFinEmp"></asp:RequiredFieldValidator>
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
                    <asp:ListItem Value="H" Selected="True">Hombre</asp:ListItem>
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