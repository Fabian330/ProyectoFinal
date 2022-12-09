<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Facturacion.aspx.cs" Inherits="ProyectoFinal.Facturacion" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="CSS/GridView.css" rel="stylesheet" />
    <link href="CSS/Botones.css" rel="stylesheet" />
    <link href="CSS/Menu.css" rel="stylesheet" />
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <style>
        body{
            background-color: slategrey
        }
    </style>
    <title>Facturacion</title>
    <style type="text/css">
        .auto-style1 {
            text-align: center;
        }
        .auto-style2 {
            text-align: center;
            height: 15px;
        }
        .auto-style3 {
            text-align: center;
            height: 15px;
            width: 315px;
        }
        .auto-style4 {
            text-align: center;
            width: 315px;
        }
        .auto-style5 {
            margin-top: 4px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <ul>
  <li><a href="Inicio.aspx">Inicio</a></li>
  <li><a href="Facturacion.aspx">Facturacion</a></li>
  <li class="dropdown">
    <a href="javascript:void(0)" class="dropbtn">Catalogos</a>
    <div class="dropdown-content">
      <a href="Clientes.aspx">Clientes</a>
      <a href="Articulos.aspx">Articulos</a>
        <a href="Rutinas.aspx">Rutinas</a>
        <a href="Direcciones.aspx">Direcciones</a>
    </div>
  </li>
</ul>
            <table style="width: 100%;" border="2">
                <tr>
                    <td class="auto-style3">Codigo</td>
                    <td class="auto-style2"><strong>Producto</strong></td>
                    <td class="auto-style2"><strong>Cantidad</strong></td>
                    <td class="auto-style2"><strong>Precio</strong></td>
                </tr>

                <tr>
                    <td class="auto-style4">
                        <asp:TextBox ID="tcodigo" runat="server" OnTextChanged="tcodigo_TextChanged" CssClass="auto-style5"></asp:TextBox>&nbsp;&nbsp;
                        </td>
                    <td class="auto-style1">
                        <asp:TextBox ID="tnombre" runat="server" Width="216px" Enabled="False"></asp:TextBox></td>
                    <td class="auto-style1">
                        <asp:TextBox ID="tcantidad" runat="server"></asp:TextBox></td>
                    <td class="auto-style1">
                        <asp:TextBox ID="tprecio" runat="server" Enabled="False"></asp:TextBox></td>
                </tr>


                <tr>
                    <td class="auto-style3">&nbsp;</td>
                    <td class="auto-style2">&nbsp;</td>
                    <td class="auto-style2">&nbsp;</td>
                    <td class="auto-style2">&nbsp;</td>
                </tr>

                 </table>
        </div>
        <asp:Button ID="bIngresar" CssClass="button button2" runat="server" OnClick="bIngresar_Click" Text="INGRESAR" />
        <div> 
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" GridLines="None"
                AllowPaging="true" CssClass="mydatagrid" PagerStyle-CssClass="pager" HeaderStyle-CssClass="header" RowStyle-CssClass="rows"
                PageSize="7" >
                <Columns>
                    <asp:BoundField DataField="Codigo" HeaderText="Codigo" />
                    <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                    <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" />
                    <asp:BoundField DataField="Precio" HeaderText="Precio" />
                    <asp:BoundField DataField="Subtotal" HeaderText="Subtotal" />
                </Columns>
            </asp:GridView>
        </div>

        <div>
            <table style="width: 100%;" border="1">
                <tr>
                    <td class="auto-style1"><strong>SUBTOTAL</strong></td>
                    <td class="auto-style1"><strong>IVA</strong></td>
                    <td class="auto-style1"><strong>TOTAL</strong></td>
                </tr>
                <tr>
                    <td class="auto-style1">
                        <asp:Label ID="LSB" runat="server" Font-Size="Large" Text="0"></asp:Label>
                    </td>
                    <td class="auto-style1">
                        <asp:Label ID="LIVA" runat="server" Font-Size="Large" Text="0"></asp:Label>
                    </td>
                    <td class="auto-style1">
                        <asp:Label ID="LTOTAL" runat="server" Font-Size="Large" Text="0"></asp:Label>
                    </td>
                    
                </tr>
                
            </table>
        </div>

    </form>
</body>
</html>
