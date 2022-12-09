<%@ Page Title="" Language="C#" MasterPageFile="~/Menu.Master" AutoEventWireup="true" CodeBehind="Clientes.aspx.cs" Inherits="ProyectoFinal.Clientes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>
        Ingresar Cliente:</h1>
    <table class="auto-style1">
        <tr>
            <td>Nombre:
                <asp:TextBox ID="tNombre" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp; Apellido:
                <asp:TextBox ID="tApellido" runat="server"></asp:TextBox>
                <br />
                <br />
                Email:
                <asp:TextBox ID="tCorreo" runat="server" Width="186px"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp; Clave:
                <asp:TextBox ID="tClave" runat="server" Width="137px" TextMode="Password"></asp:TextBox>
                <br />
                <br />
                Telefono:
                <asp:TextBox ID="tTelefono" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp; Tipo:
                <asp:DropDownList ID="DropDownList1" runat="server">
                    <asp:ListItem>Cliente</asp:ListItem>
                    <asp:ListItem>Administrador</asp:ListItem>
                </asp:DropDownList>
                <br />
                <br />
                Codigo a Borrar/Modificar:
                <asp:TextBox ID="tID" runat="server" Width="50px"></asp:TextBox>
                <br />
                <br />
                <asp:Button ID="bIngresar" class="button button4" runat="server" Text="Ingresar" OnClick="bIngresar_Click" />
&nbsp;&nbsp;
                <asp:Button ID="bBorrar" class="button button4" runat="server" Text="Borrar" OnClick="bBorrar_Click" />
&nbsp;&nbsp;
                <asp:Button ID="bModificar" class="button button4" runat="server" Text="Modificar" OnClick="bModificar_Click" />
            </td>
            <td>
                <asp:GridView ID="GridView1" CssClass="mydatagrid" PagerStyle-CssClass="pager" HeaderStyle-CssClass="header" RowStyle-CssClass="rows" runat="server">
                </asp:GridView>
            </td>
        </tr>
    </table>
</asp:Content>
