<%@ Page Title="" Language="C#" MasterPageFile="~/Menu.Master" AutoEventWireup="true" CodeBehind="Direcciones.aspx.cs" Inherits="ProyectoFinal.Direcciones" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Direcciones</h1>
    <table class="auto-style1">
        <tr>
            <td>Codigo Cliente:
                <asp:TextBox ID="tCodigoCl" runat="server"></asp:TextBox>
                <br />
                <br />
                Provincia:
                <asp:TextBox ID="tProvincia" runat="server"></asp:TextBox>
                <br />
                <br />
                Canton:
                <asp:TextBox ID="tCanton" runat="server"></asp:TextBox>
                <br />
                <br />
                Distrito:
                <asp:TextBox ID="tDistrito" runat="server"></asp:TextBox>
                <br />
                <br />
                Codigo de direccion a Borrar/Modificar:
                <asp:TextBox ID="tCodigoD" runat="server"></asp:TextBox>
                <br />
                <br />
                <br />
            <asp:Button ID="bIngresar" class="button button4" runat="server" Text="Ingresar" OnClick="bIngresar_Click" />
                &nbsp;&nbsp;
                <asp:Button ID="bBorrar" class="button button4" runat="server" Text="Borrar" OnClick="bBorrar_Click" />
            &nbsp;&nbsp;
            <asp:Button ID="bModificar" class="button button4" runat="server" Text="Modificar" OnClick="bModificar_Click" /></td>
            <td>
                <asp:GridView ID="GridView1" CssClass="mydatagrid" PagerStyle-CssClass="pager" HeaderStyle-CssClass="header" RowStyle-CssClass="rows" runat="server">
                </asp:GridView>
            </td>
        </tr>
    </table>
</asp:Content>
