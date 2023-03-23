<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Visitas.aspx.cs" Inherits="WebFormsTEO7.Visitas" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        Nombres:&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtNombres" runat="server"></asp:TextBox>
        <p>
            Apellidos:&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtApellidos" runat="server"></asp:TextBox>
        </p>
        <p>
            <asp:FileUpload ID="fuImagen" runat="server" />
        </p>
        <p>
            <asp:Image ID="pbImage" runat="server" Height="239px" Width="267px" />
        </p>
        <p>
            <asp:TextBox ID="txtID" runat="server"></asp:TextBox>
        </p>
        <p>
            <asp:Button ID="btnAceptar" runat="server" OnClick="Button1_Click" Text="Aceptar" />
        </p>
    </form>
</body>
</html>
