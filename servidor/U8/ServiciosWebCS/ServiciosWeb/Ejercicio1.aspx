<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Ejercicio1.aspx.cs" Inherits="ServiciosWeb.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <h2>CONSUMIR UN SERVICIO WEB YA EXISTENTE</h2>
    <h1>Titulaciones oficiales en la universidad de Alicante</h1>
    <form id="form1" runat="server">
        <div>
            <label>Curso academico (formato aaaa-aa)</label>
            <asp:TextBox ID="txtCurso" runat="server"></asp:TextBox>
            <asp:Button ID="btnObtenerInformacion" runat="server" Text="Obtener información" OnClick="btnObtenerInformacion_Click" />
            
        </div>
        <asp:Label ID="lblResultado" runat="server" Text=""></asp:Label>
        <asp:GridView ID="GridView1" runat="server">
        </asp:GridView>
    </form>
</body>
</html>
