<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ControlError.aspx.cs" Inherits="GesTienda.ControlError" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="EstiloControlError.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <h1>Aplicación Web GesTienda</h1>
        <h4>Error en tiempo de ejecución</h4>
        <section>
            <article>
                <p>Error de ASP.NET:</p>
                <asp:Label ID="lblErrorASP" runat="server" Text="lblErroASP" ForeColor="Red"></asp:Label>

                <p>Error ADO.NET:</p>
                <asp:Label ID="lblErrorADO" runat="server"  Text="lblErroADO" ForeColor="Red"></asp:Label>
            </article>
        </section>
    </form>
</body>
</html>
