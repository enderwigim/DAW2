<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Example 2-1.aspx.cs" Inherits="Example_U2.Example_2_1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Ejemplo 2-1</h1>
            <hr />
            <br />
            <asp:Label ID="Label1" runat="server" Text="Label">Introduzca su nombre: </asp:Label>
            <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox> <br /> <br />
            <asp:Button ID="btnEnviar" runat="server" Text="Enviar" OnClick="btnEnviar_Click"/> <br /> <br />
            <asp:Label ID="lblTexto" runat="server" Text=""></asp:Label>
        </div>
    </form>
</body>
</html>
