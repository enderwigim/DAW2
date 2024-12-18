﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Prestaciones1.aspx.cs" Inherits="GesPresta.Prestaciones1" %>

<%@ Register src="~/Cabecera.ascx" TagPrefix="uc1" TagName="Cabecera" %>


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
        <uc1:Cabecera runat="server" ID="Cabecera" />

        <h2>DATOS DE LAS PRESTACIONES</h2> 
        <div class="initial-form">
            <div class="line">
                <div class="text">
                    Código Prestación
                </div>
                <div class="control">
                    <asp:TextBox ID="txtCodPre" runat="server" Width="200px"></asp:TextBox>
                </div>
            </div>

            <div class="line">
                <div class="text">
                    Descripción
                </div>
                <div class="control">
                    <asp:TextBox ID="txtDesPre" runat="server" Width="200px"></asp:TextBox>
                </div>
            </div>

            <div class="line">
                <div class="text">
                    Importe
                </div>
                <div class="control">
                    <asp:TextBox ID="txtImpPre" runat="server" Width="200px"></asp:TextBox>
                </div>
            </div>

            <div class="line">
                <div class="text">
                    Porcentaje de Importe
                </div>
                <div class="control">
                    <asp:TextBox ID="txtPorPre" runat="server" Width="200px"></asp:TextBox>
                </div>
            </div>

            <div class="line">
                <div class="text">
                    Tipo de prestación
                </div>
                <div class="control">
                    <asp:DropDownList ID="ddlTipPre" runat="server">
                        <asp:ListItem>Dentaria</asp:ListItem>
                        <asp:ListItem>Familiar</asp:ListItem>
                        <asp:ListItem Selected="True">Ocultar</asp:ListItem>
                        <asp:ListItem>Otras</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
        </div>

        <div class="btn">
            <br />
            <asp:Button ID="cmdEnviar" runat="server" Text="Enviar" PostBackUrl="~/Prestaciones1Respuesta.aspx" />
        </div>

         <div class="error-lbls">
            <asp:Label ID="lblError" runat="server" Visible="False"></asp:Label>
        </div>
</form>
</body>
</html>
