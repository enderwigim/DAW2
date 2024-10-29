<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registrarse.aspx.cs" Inherits="GesTienda.Registrarse" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="~/Estilos/DefaultEstilo.css" rel="stylesheet" type="text/css" />
</head>
<body>
        <div id="cabecera">
        <div id="cabecera1">
            <br />
            comerciodaw.com
        </div>
        <div id="cabecera2">
            <br />
            TIENDA ONLINE - SHOPPING DAW<br />
            <br />
        </div>
    </div>
    <section>
        <h1>GesTienda</h1>
        <form id="form1" runat="server">


        <table>
            <tr>
                <td align="center" colspan="2"><h3>Registro de Usuario</h3></td>
            </tr>
            <tr>
                <td align="right">
                    <asp:Label ID="lblCorCli" runat="server" AssociatedControlID="txtCorCli">Correo Electrónico</asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtCorCli" runat="server" Width="234px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvTxtCorCli" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtCorCli"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td align="right">
                    <asp:Label ID="lblPassword1" runat="server" AssociatedControlID="txtPassword1">Contraseña:</asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtPassword1" runat="server" TextMode="Password" Width="158px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvTxtPassword1" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtPassword1"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td align="right">
                    <asp:Label ID="lblPassword2" runat="server" AssociatedControlID="txtPassword2">Confirmar contraseña:</asp:Label>                </td>
                <td>
                    <asp:TextBox ID="txtPassword2" runat="server" TextMode="Password" Width="158px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvTxtPassword2" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtPassword2"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td align="right">
                    <asp:Label ID="lblIdCliente" runat="server" AssociatedControlID="txtIdCliente">NIE/NIF/CIF</asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtIdCliente" runat="server" Width="182px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvTIdCliente" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtIdCliente"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td align="right">
                    <asp:Label ID="lblNomCli" runat="server" AssociatedControlID="txtNomCli">Nombre/Razón Social</asp:Label>

                </td>
                <td>
                    <asp:TextBox ID="txtNomCli" runat="server" Width="158px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvTxtNomCli" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtNomCli"></asp:RequiredFieldValidator>
                   
                </td>
            </tr>
            <tr>
                <td align="right">
                    <asp:Label ID="lblDirCli" runat="server" AssociatedControlID="txtDirCli">Dirección</asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtDirCli" runat="server" Width="156px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvTxtDirCli" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtDirCli"></asp:RequiredFieldValidator>
                             
                </td>
            </tr>
            <tr>
                <td align="right">
                    <asp:Label ID="lblPobCli" runat="server" AssociatedControlID="txtPobCli">Poblacion</asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtPobCli" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvTxtPobCli" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtPobCli"></asp:RequiredFieldValidator>
    
                </td>
            </tr>
            <tr>
                <td align="right">
                    <asp:Label ID="lblCpoCli" runat="server" AssociatedControlID="txtCpoCli">Codigo Postal</asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtCpoCli" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvTxtCpoCli" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtCpoCli"></asp:RequiredFieldValidator>
   
                </td>
            </tr>
            <tr>
                <td align="right">
                    <asp:Label ID="lblTelCli" runat="server" AssociatedControlID="txtTelCli">Teléfono</asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtTelCli" runat="server" Width="164px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvTxtTelCli" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtTelCli"></asp:RequiredFieldValidator>
                       
                </td>
            </tr>
            <tr>
                <td align="center" colspan="2">
                    <asp:Button ID="Registro" runat="server" Text="Insertar" Width="75%" OnClick="Registro_Click" />
                    <br />
                    <asp:Label ID="lblMensajes" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="center" colspan="2">
                    <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl="~/Default.aspx">Ir al Inicio</asp:LinkButton>
                </td>
            </tr>
        </table>

        </form>
    </section>
</body>
</html>
