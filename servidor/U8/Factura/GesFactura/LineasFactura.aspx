<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LineasFactura.aspx.cs" Inherits="GesFactura.LineasFactura" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link rel="stylesheet" type="text/css" href="LineasFacturaStyle.css" />
</head>
<body>
    <form id="form1" runat="server">
        <h1>Uso de Servicio Web - Cálculos factura de un artículo</h1>
        <br />
        <table>
            <tr>
                <td>
                    <asp:Label ID="Label1" runat="server" Text="Cantidad"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtCantidad" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label2" runat="server" Text="Precio"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtPrecio" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label3" runat="server" Text="Descuento (%)"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtDescuento" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label4" runat="server" Text="Tipo de IVA (%)"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtTipoIVA" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="2" style="text-align: center;">
                    <asp:Button ID="btnEnviar" runat="server" Text="Enviar" OnClick="btnEnviar_Click" />
                </td>
            </tr>
        </table>

        <br />
        <p>Resultado de los calculos</p>
        <table style="width: 100%; text-align: center; border-collapse: collapse;">
            <tr>
                <th>Bruto</th>
                <th>Descuento</th>
                <th>Base Imponible</th>
                <th>IVA</th>
                <th>Total</th>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblBruto" runat="server" Text="[lblBruto]"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblDescuento" runat="server" Text="[lblDescuento]"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblBaseImponible" runat="server" Text="[lblBaseImponible]"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblIva" runat="server" Text="[lblIVA]"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblTotal" runat="server" Text="[lblTotal]"></asp:Label>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
