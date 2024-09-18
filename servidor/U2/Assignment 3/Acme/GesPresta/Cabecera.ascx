<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Cabecera.ascx.cs" Inherits="GesPresta.Cabecera" %>

<div class="header">
    <asp:LinkButton ID="LinkButton1" runat="server" CssClass="linkbuttons" PostBackUrl="~/Default.aspx">Inicio</asp:LinkButton>
    <asp:LinkButton ID="LinkButton2" runat="server" CssClass="linkbuttons" PostBackUrl="~/Empleados.aspx">Empleados</asp:LinkButton>
    <asp:LinkButton ID="LinkButton3" runat="server" CssClass="linkbuttons" PostBackUrl="~/Prestaciones.aspx">Prestaciones</asp:LinkButton>
    <hr />
    <br />
    <h1>ACME INNOVACIÓN, S. FIG.</h1>
    <h3>Gestión de Prestaciones Sociales</h3>
    <hr />
</div>
