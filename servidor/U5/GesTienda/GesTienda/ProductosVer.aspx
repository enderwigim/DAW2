﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ProductosVer.aspx.cs" Inherits="GesTienda.ProductosVer" %>
<%@ OutputCache Duration="1" VaryByParam="None" %> 
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="InfoContenido" runat="server">
    <h1>Productos</h1>
    <asp:Label ID="lblResultado" runat="server"></asp:Label> 
    <asp:Label ID="lblMensajes" ForeColor="red" runat="server"></asp:Label> 
</asp:Content>
