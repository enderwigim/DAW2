<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Prestaciones.aspx.cs" Inherits="GesPresta.WebForm2" %>

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
        <uc1:Cabecera runat="server" ID="Cabecera" />
        <div class="body-container">
                    <h2 class="lendings">DATOS DE LAS PRESTACIONES</h2>
                    <div class="text">
                        <label for="txtCodPre">Código Prestación</label>
                    </div>
                    <asp:TextBox ID="txtCodPre" runat="server"></asp:TextBox>
                    <div class="text">
                        <label for="txtDesPre">Descripción</label>
                    </div>
                    <asp:TextBox ID="txtDesPre" runat="server"></asp:TextBox>
                
                
                    <div class="text">
                        <label for="txtImpPre">Importe</label>
                    </div>
                    <asp:TextBox ID="txtImpPre" runat="server"></asp:TextBox>


                    <div class="text">
                        <label for="txtPorPre">Porcentaje de Importe</label>
                    </div>
                    <asp:TextBox ID="txtPorPre" runat="server"></asp:TextBox>
                
                    <div class="text">
                        <label for="ddlTipPre">Tipo de prestación</label>
                    </div>
                    <asp:DropDownList ID="ddlTipPre" runat="server">
                        <asp:ListItem>Dentaria</asp:ListItem>
                        <asp:ListItem>Familiar</asp:ListItem>
                        <asp:ListItem Selected="True">Ocultar</asp:ListItem>
                        <asp:ListItem>Otras</asp:ListItem>
                    </asp:DropDownList>
                    <br />
                    <div class="button-cont">
                        <div class="text">
                           
                        </div>
                        <asp:Button ID="cmdEnviar" runat="server" Text="Enviar" CssClass="button"/>
                    </div>
        </div>
    </form>
</body>
</html>
