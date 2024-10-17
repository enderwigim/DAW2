<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageAdm.Master" AutoEventWireup="true" CodeBehind="PedidosPorCliente.aspx.cs" Inherits="GesTienda.PedidosPorCliente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="InfoContenido" runat="server">
    <h1>Pedidos realizados por los clientes</h1>
    </div>
    <asp:GridView ID="grdClientes" runat="server" AllowPaging="True" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="IdCliente" DataSourceID="SqlDataSource1" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="grdClientes_SelectedIndexChanged">
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        <Columns>
            <asp:CommandField ShowSelectButton="True" />
            <asp:BoundField DataField="IdCliente" HeaderText="Id del Cliente" ReadOnly="True" SortExpression="IdCliente" />
            <asp:BoundField DataField="NomCli" HeaderText="Nombre" SortExpression="NomCli" />
            <asp:BoundField DataField="PobCli" HeaderText="Población" SortExpression="PobCli" />
            <asp:BoundField DataField="CorCli" HeaderText="Correo Electrónico" SortExpression="CorCli" />
        </Columns>
        <EditRowStyle BackColor="#999999" />
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#E9E7E2" />
        <SortedAscendingHeaderStyle BackColor="#506C8C" />
        <SortedDescendingCellStyle BackColor="#FFFDF8" />
        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
    </asp:GridView>
                       <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [IdCliente], [NomCli], [PobCli], [CorCli] FROM [CLIENTE]"></asp:SqlDataSource>
    </div>
    <asp:Label ID="lblResultado" runat="server"></asp:Label> 
    <asp:Label ID="lblTotal" Visible=false runat="server"></asp:Label> 
    <asp:Label ID="lblMensajes" ForeColor="red" runat="server"></asp:Label> 
</asp:Content>
