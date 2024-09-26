<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Prestaciones1Respuesta.aspx.cs" Inherits="GesPresta.Prestaciones1Respuesta" %>

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

        <h2>DATOS DE LAS PRESTACIONES</h2> 
        <div class="respuesta-prestaciones">
            <asp:Label ID="lblValores" runat="server" Text="Label" BackColor="#C0FFFF" Width="70%" Visible="false"></asp:Label>
        </div>
</form>
</body>
</html>
