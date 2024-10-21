<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageAdm.Master" AutoEventWireup="true" CodeBehind="ProductosMantener.aspx.cs" Inherits="GesTienda.ProductosMantener" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="InfoContenido" runat="server">
    <h1>Mantenimiento productos</h1>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [IdProducto], [DesPro], [PrePro] FROM [PRODUCTO]"></asp:SqlDataSource>
    
    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [UNIDAD]"></asp:SqlDataSource>
    
    <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [TIPO]"></asp:SqlDataSource>
    
    <section class="formulario">
        <article>
            <asp:GridView ID="grdProductos" runat="server" AllowPaging="True" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="IdProducto" DataSourceID="SqlDataSource1" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="grdProductos_SelectedIndexChanged">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                    <asp:CommandField ShowSelectButton="True" />
                    <asp:BoundField DataField="IdProducto" HeaderText="IdProducto" ReadOnly="True" SortExpression="IdProducto" />
                    <asp:BoundField DataField="DesPro" HeaderText="DesPro" SortExpression="DesPro" />
                    <asp:BoundField DataField="PrePro" HeaderText="PrePro" SortExpression="PrePro" />
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
        </article>
            <asp:Label ID="lblResultado" runat="server"></asp:Label> 
            <asp:Label ID="lblMensajes" ForeColor="red" runat="server"></asp:Label> 
        <article class="container">
            <div class="cont">
                <asp:Label ID="lblIdProducto" runat="server" Text="ID.Producto"></asp:Label> 
                <asp:TextBox ID="txtIdProducto" runat="server" Enabled="false"></asp:TextBox>
            </div>
            <div class="cont">
                <asp:Label ID="lblDesPro" runat="server" Text="Descripción"></asp:Label> 
                <asp:TextBox ID="txtDesPro" runat="server" Enabled="false"></asp:TextBox>
            </div>
            <div class="cont">
                <asp:Label ID="lblPrePro" runat="server" Text="Precio"></asp:Label> 
                <asp:TextBox ID="txtPrePro" runat="server" Text="0" Enabled="false"></asp:TextBox>
            </div>
            <div class="cont">
                <asp:Label ID="lblIdUnidad" runat="server" Text="Unidad"></asp:Label> 
                <asp:DropDownList ID="ddlIdUnidad" runat="server" DataSourceID="SqlDataSource2" DataTextField="IdUnidad" DataValueField="IdUnidad">
                </asp:DropDownList>
            </div>
            <div class="cont">
                <asp:Label ID="lblIdTipo" runat="server" Text="Tipo Producto"></asp:Label> 
                <asp:DropDownList ID="ddlIdTipo" runat="server" DataSourceID="SqlDataSource3" DataTextField="DesTip" DataValueField="IdTipo">
                </asp:DropDownList>
                <br />
                <asp:Button ID="btnNuevo" runat="server" Text="Nuevo" Visible="True" Width="200px" OnClick="btnNuevo_Click" />
                <asp:Button ID="btnEditar" runat="server" Text="Editar" Visible="True" Width="200px" OnClick="btnEditar_Click" />
                <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" Visible="True" Width="200px" OnClick="btnEliminar_Click" />
                <asp:Button ID="btnInsertar" runat="server" Text="Insertar" Visible="False" Width="200px" OnClick="btnInsertar_Click" />
                <asp:Button ID="btnModificar" runat="server" Text="Modificar" Visible="False" Width="200px" OnClick="btnModificar_Click" />
                <asp:Button ID="btnBorrar" runat="server" Text="Borrar" Visible="False" Width="200px" OnClick="btnBorrar_Click" />
                <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" Visible="False" Width="200px" OnClick="btnCancelar_Click" />
            </div>
            
        </article>
    </section>
</asp:Content>
