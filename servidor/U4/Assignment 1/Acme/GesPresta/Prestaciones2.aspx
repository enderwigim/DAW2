<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Prestaciones2.aspx.cs" Inherits="GesPresta.Prestaciones2" %>

<%@ Register Src="~/Cabecera.ascx" TagPrefix="uc1" TagName="Cabecera" %>


<%@ Register src="prestacionesBuscar.ascx" tagname="prestacionesBuscar" tagprefix="uc2" %>
<%@ Register Src="~/prestacionesBuscar.ascx" TagPrefix="uc1" TagName="prestacionesBuscar" %>



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
                    <asp:RequiredFieldValidator ID="rqdTxtCodPre" runat="server" ErrorMessage="El Codigo Prestación es obligatorio" 
                        ControlToValidate="txtCodPre" Text="*" ForeColor="Red"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="regTxtCodPre" runat="server" ControlToValidate="txtCodPre" 
                        ValidationExpression="\d{3}-\d{3}-\d{3}"
                        ErrorMessage="El formato de los datos a introducir debe ser: 3 dígitos, un guión, 3 dígitos, un guion y, 3 dígitos." 
                        Text="*" ForeColor="Red"></asp:RegularExpressionValidator>
                </div>
            </div>

            <div class="line">
                <div class="text">
                    Descripción
                </div>
                <div class="control">
                    <asp:TextBox ID="txtDesPre" runat="server" Width="200px"></asp:TextBox>
                    <div class="prestaciones-dropdown">
                        <uc1:prestacionesBuscar runat="server" id="prestacionesBuscar" Visible="false" />
                        <br />
                        <asp:Button ID="btnSeleccionar" runat="server" Text="Seleccionar" CausesValidation="False" Visible="false" 
                            OnClick="btnSeleccionar_Click"/>
                        <asp:Button ID="btnVerPrestaciones" runat="server" Text="Ver prestaciones" CausesValidation="False" 
                            OnClick="btnVerPrestaciones_Click"/>
                    </div>
                </div>
                
            </div>

            <div class="line">
                <div class="text">
                    Importe
                </div>
                <div class="control">
                    <asp:TextBox ID="txtImpPre" runat="server" Width="200px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rqdTxtImpPre" runat="server" ControlToValidate="txtImpPre"
                        ErrorMessage="El Importe es obligatorio" Text="*" ForeColor="Red"></asp:RequiredFieldValidator>
                    <asp:RangeValidator ID="rngTxtImpPre" runat="server" ControlToValidate="txtImpPre" 
                        ErrorMessage="El importe máximo de las prestaciones no debe superar 500,00€" Type="Double" 
                        MaximumValue="500,00" MinimumValue="0,00" Text="*" ForeColor="Red"></asp:RangeValidator>
                </div>
            </div>
            <div class="line">
                <div class="text">
                    Porcentaje de Importe
                </div>
                <div class="control">
                    <asp:TextBox ID="txtPorPre" runat="server" Width="200px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rqdTxtPorPre" runat="server" ControlToValidate="txtPorPre" 
                        ErrorMessage="El Porcentaje de Importe es obligatorio" Text="*" ForeColor="Red"></asp:RequiredFieldValidator>
                    <asp:RangeValidator ID="rngTxtPorPre" runat="server" ControlToValidate="txtPorPre" 
                        ErrorMessage="El valor introducido debe estar comprendido entre el 0,00 y el 15,00 %" Type="Double" 
                        MaximumValue="15,00" MinimumValue="0,00" Text="*" ForeColor="Red"></asp:RangeValidator>
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
            <asp:Button ID="cmdEnviar" runat="server" Text="Enviar" />
            <br />
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" DisplayMode="List" />
        </div>
</form>
</body>
</html>
