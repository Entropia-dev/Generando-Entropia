<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Admin_Productos.aspx.cs" Inherits="Vistas.admin_Productos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="StyleSheet1.css" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Editar de productos</title>
    <style type="text/css">
        .auto-style1 {
            width: 90px;
            height: 68px;
        }

        </style>
</head>

<body>
    <form id="form1" runat="server">
        <div id="container">
            <header>
                <h1>
                    <img src="../logo.jpg" alt="Revestimientos ayti" title="Revestimientos A&Ti" class="auto-style1" />Revestimientos A&TI</h1>

            </header>

            <nav>
                <ul style="height: 57px">
                    <li><a href="Home.aspx">Home</a></li>
                    <li><a href="Clientes.aspx">Clientes</a> </li>
                    <li><a href="Productos">Productos</a> </li>
                    <li><a href="Cuenta.aspx">Cuenta</a></li>
                    <li><a href="Presupuesto.aspx">Presupuesto</a></li>
                    <li><a href="Login.aspx">Ingresar</a></li>
                    <li></li>
                </ul>
            </nav>
            <br />
            <br />
            <br />
        </div>
        <div>
            <div>
                <h3>Ingrese ID del producto: 
        <asp:TextBox ID="txtId" runat="server"></asp:TextBox>
                </h3>
            </div>
            <div>

                <h3>Ingrese nombre del producto: 
        <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
                </h3>

            </div>
            <div>
                <h3>Estado:
             <asp:CheckBox ID="CheckBox1" runat="server" />
                </h3>
            </div>  
            <div>

                <asp:Button ID="btnDarAlta" runat="server" OnClick="btnDarAlta_Click" Text="Button" />

            </div>
            <div>

            <asp:Label ID="lblMensaje" runat="server"></asp:Label>

        </div>
        </div>
        

    </form>

</body>
</html>
