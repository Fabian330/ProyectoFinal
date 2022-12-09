<%@ Page Title="" Language="C#" MasterPageFile="~/Menu2.Master" AutoEventWireup="true" CodeBehind="RutinasA.aspx.cs" Inherits="ProyectoFinal.RutinasA" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>
        Rutinas asignadas a los clientes:</h1>
    <p>
        <asp:GridView ID="GridView1" CssClass="mydatagrid" PagerStyle-CssClass="pager" HeaderStyle-CssClass="header" RowStyle-CssClass="rows" runat="server">
        </asp:GridView>
    </p>
</asp:Content>
