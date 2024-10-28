<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="GesTienda.Default" %>
<%@ OutputCache Duration="1" VaryByParam="None" %> 
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="~/Estilos/DefaultEstilo.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .auto-style1 {
            height: 22px;
        }
    </style>
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
            <section>
                <asp:Login ID="Login1" runat="server" OnAuthenticate="Login1_Authenticate">
                    <LayoutTemplate>
                        <table cellpadding="1" cellspacing="0" style="border-collapse:collapse;">
                            <tr>
                                <td>
                                    <table cellpadding="0">
                                        <tr>
                                            <td align="center" colspan="2"><h3>Iniciar sesión</h3></td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">Correo Electronico</asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="UserName" runat="server"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName" ErrorMessage="El nombre de usuario es obligatorio." ToolTip="El nombre de usuario es obligatorio." ValidationGroup="Login1">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password">Contraseña:</asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="Password" runat="server" TextMode="Password"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password" ErrorMessage="La contraseña es obligatoria." ToolTip="La contraseña es obligatoria." ValidationGroup="Login1">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" colspan="2" style="color:Red;">
                                               <asp:Literal ID="FailureText" runat="server" EnableViewState="false"></asp:Literal>
                                            </td>
                                        </tr>
                                        <caption>
                                            <br />
                                            <tr>
                                                <td align="center" class="auto-style1" colspan="2">
                                                    <asp:Button ID="LoginButton" runat="server" CommandName="Login" Text="Inicio de sesión" UseSubmitBehavior="False" ValidationGroup="Login1" />
                                                </td>
                                            </tr>
                                        </caption>
                                    </table>
                                </td>
                            </tr>
                        </table>

                    </LayoutTemplate>
                </asp:Login>
                <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl="~/Registrarse.aspx">Registrarse</asp:LinkButton>
            </section>
        </form>

    </section>
</body>
</html>
