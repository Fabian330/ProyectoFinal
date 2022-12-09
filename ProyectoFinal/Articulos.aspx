<%@ Page Title="" Language="C#" MasterPageFile="~/Menu.Master" AutoEventWireup="true" CodeBehind="Articulos.aspx.cs" Inherits="ProyectoFinal.Articulos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            height: 30px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <h1>Ingresar articulos:</h1>
<br />
    <table class="auto-style1">
        <tr>
            <td class="auto-style2">Nombre:
                <asp:TextBox ID="tNombre" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp; Precio:
                <asp:TextBox ID="tPrecio" runat="server"></asp:TextBox>
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
            <td class="auto-style2">
                <asp:GridView ID="GridView1" CssClass="mydatagrid" PagerStyle-CssClass="pager" HeaderStyle-CssClass="header" RowStyle-CssClass="rows" runat="server">
                </asp:GridView>
            </td>
        </tr>
    </table>
    <br />
    
</asp:Content>
