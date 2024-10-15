<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="MPEmpleados.aspx.cs" Inherits="GesPresta.MPEmpleados" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
            <div class="initial-form">
        <div class="line">
            <div class="text">
                Código Empleado
            </div>
            <div class="control">
                <asp:TextBox ID="txtCodEmp" runat="server" Width="200px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rqdTxtCodEmp" runat="server" ErrorMessage="El Codigo Empleado es obligatorio" 
                    ControlToValidate="txtCodEmp" Text="*" ForeColor="Red"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="regTxtCodEmp" ControlToValidate="txtCodEmp" ValidationExpression="\w\d{5}"
                    runat="server" ErrorMessage="El formato de los datos a introducir debe ser:  una letra y 5 dígitos." Text="*" ForeColor="Red"></asp:RegularExpressionValidator>
            </div>
        </div>

        <div class="line">
            <div class="text">
                NIF
&nbsp;</div>
            <div class="control">
                <asp:TextBox ID="txtNifEmp" runat="server" Width="200px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rqdTxtNifEmp" runat="server" ErrorMessage="El NIF es obligatorio" 
                    ControlToValidate="txtNifEmp" Text="*" ForeColor="Red"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="regTxtNifEmp" ControlToValidate="txtNifEmp" runat="server" ValidationExpression="\d{8}-\w"
                    ErrorMessage="El formato de los datos a introducir debe ser: 8 dígitos, un guion y una letra." Text="*" ForeColor="Red"></asp:RegularExpressionValidator>
            </div>
        </div>

        <div class="line">
            <div class="text">
                Apellidos y Nombre
            </div>
            <div class="control">
                <asp:TextBox ID="txtNomEmp" runat="server" Width="200px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rqdTxtNomEmp" runat="server" ErrorMessage="El Apellidos y Nombre es obligatorio" 
                    ControlToValidate="txtNomEmp" Text="*" ForeColor="Red"></asp:RequiredFieldValidator>
            </div>
        </div>

        <div class="line">
            <div class="text">
                Dirección
            </div>
            <div class="control">
                <asp:TextBox ID="txtDirEmp" runat="server" Width="200px"></asp:TextBox>
            </div>
        </div>

        <div class="line">
            <div class="text">
                Ciudad
            </div>
            <div class="control">
                <asp:TextBox ID="txtCiuEmp" runat="server" Width="200px"></asp:TextBox>
            </div>
        </div>

        <div class="line">
            <div class="text">
                Teléfono
            </div>
            <div class="control">
                <asp:TextBox ID="txtTelEmp" runat="server" Width="200px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rdqTxtTelEmp" runat="server" ErrorMessage="El Telefono es obligatorio" 
                    ControlToValidate="txtTelEmp" Text="*" ForeColor="Red"></asp:RequiredFieldValidator>
                
            </div>
        </div>

        <div class="line">
            <div class="text">
                Fecha de nacimiento
            </div>
            <div class="control">
                <asp:TextBox ID="txtFnaEmp" runat="server" Width="200px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rdqTxtFnaEmp" runat="server"  ErrorMessage="La fecha de nacimiento es obligatoria" 
                    ControlToValidate="txtFnaEmp" Text="*" ForeColor="Red"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="regTxtFnaEmp" runat="server" ControlToValidate="txtFnaEmp" ValidationExpression="\d\d\/\d\d\/\d\d\d\d"
                 ErrorMessage="El formato de los datos a introducir debe ser: Formato de fecha dd/mm/aaaa." ForeColor="Red" Text="*"></asp:RegularExpressionValidator>
                <asp:CompareValidator ID="cmptxtFnaEmp" ControlToValidate="txtFnaEmp" ControlToCompare="txtFinEmp"
                    runat="server" Type="Date" Operator="LessThan" 
                    ErrorMessage="La Fecha de Ingreso del Empleado debe ser mayor que la Fecha de Nacimiento" Text="*" ForeColor="Green"></asp:CompareValidator>     
                
            </div>
        </div>

        <div class="line">
            <div class="text">
                Fecha de ingreso
            </div>
            <div class="control">
                <asp:TextBox ID="txtFinEmp" runat="server" Width="200px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rdqTxtFinEmp" runat="server" ErrorMessage="La fecha de nacimiento es obligatoria" 
                    ControlToValidate="txtFinEmp" Text="*" ForeColor="Red"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="regTxtFinEmp" ControlToValidate="txtFinEmp" runat="server"
                        ValidationExpression="\d\d\/\d\d\/\d\d\d\d" Text="*"
                        ErrorMessage="El formato de los datos a introducir debe ser: Formato de fecha dd/mm/aaaa." ForeColor="Green"></asp:RegularExpressionValidator>
            </div>
        </div>

        <div class="line">
            <div class="text">
                Sexo
            </div>
            <div class="control">
                <asp:RadioButtonList ID="rblSexEmp" runat="server" RepeatDirection="Horizontal">
                    <asp:ListItem Value="H" Selected="True">Hombre</asp:ListItem>
                    <asp:ListItem Value="M">Mujer</asp:ListItem>
                </asp:RadioButtonList>
            </div>
        </div>

        <div class="line">
            <div class="text">
                Departamento
            </div>
            <div class="control">
                <asp:DropDownList ID="DropDownList1" runat="server">
                    <asp:ListItem Selected="True">Investigación</asp:ListItem>
                    <asp:ListItem>Desarrollo</asp:ListItem>
                    <asp:ListItem>Innovación</asp:ListItem>
                    <asp:ListItem>Administración</asp:ListItem>
                </asp:DropDownList>
            </div>
        </div>
    </div>

    <div class="btn">
        <br />
        <asp:Button ID="ddlDepEmp" runat="server" Text="Enviar" Width="95px" />
        <asp:ValidationSummary ID="ValidationSummary1" DisplayMode="List" runat="server" ForeColor="Red" />
    </div>
</asp:Content>
