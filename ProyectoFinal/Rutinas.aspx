<%@ Page Title="" Language="C#" MasterPageFile="~/Menu.Master" AutoEventWireup="true" CodeBehind="Rutinas.aspx.cs" Inherits="ProyectoFinal.Rutinas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Rutinas</h1>
    <table class="auto-style1">
        <tr>
            <td>Nombre de Rutina:
                <asp:TextBox ID="tNombreR" runat="server"></asp:TextBox>
                <br />
                <br />
                Codigo a Borrar/Modificar:
                <asp:TextBox ID="tCodigoR" runat="server" Width="50px"></asp:TextBox>
                <br />
                <br />
                <asp:Button ID="bIngresar" class="button button4" runat="server" Text="Ingresar" OnClick="bIngresar_Click" />
&nbsp;&nbsp;
                <asp:Button ID="bBorrar" class="button button4" runat="server" Text="Borrar" OnClick="bBorrar_Click" />
&nbsp;&nbsp;
                <asp:Button ID="bModificar" class="button button4" runat="server" Text="Modificar" OnClick="bModificar_Click" />
                <br />
                <h2>Asignar rutinas</h2>
                <p>
                    Codigo de rutina:
                    <asp:TextBox ID="tCodigoR2" runat="server" Height="22px"></asp:TextBox>
                &nbsp;&nbsp; Cod a quitar:<asp:TextBox ID="tCod" runat="server" Width="30px"></asp:TextBox>
                </p>
                <p>
                    Codigo de cliente:
                    <asp:TextBox ID="tCodigoCl" runat="server"></asp:TextBox>
                </p>
                <p>
                    <asp:Button ID="bAsignar" class="button button4" runat="server" Text="Asignar" OnClick="bAsignar_Click" />
&nbsp;&nbsp;
                    <asp:Button ID="bQuitar" class="button button4" runat="server" Text="Quitar" OnClick="bQuitar_Click" />
&nbsp;&nbsp;
                </p>
            </td>
            <td>
                Rutinas:<asp:GridView ID="GridView1" CssClass="mydatagrid" PagerStyle-CssClass="pager" HeaderStyle-CssClass="header" RowStyle-CssClass="rows" runat="server">
                </asp:GridView>
                <br />
                Rutinas asignadas:<br />
                <asp:GridView ID="GridView2" CssClass="mydatagrid" PagerStyle-CssClass="pager" HeaderStyle-CssClass="header" RowStyle-CssClass="rows" runat="server">
                </asp:GridView>
            </td>
        </tr>
    </table>
</asp:Content>
