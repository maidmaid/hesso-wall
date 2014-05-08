<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm_Login.aspx.cs" Inherits="WebApplication1.WebForm_Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="lblUsername" runat="server" Text="Username"></asp:Label>
        <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox>
        <asp:Label ID="lblPassword" runat="server" Text="Password"></asp:Label>
        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
        <asp:Label ID="lblError" runat="server" Text="Username or password incorrect" Visible="False" ForeColor="Red"></asp:Label>
        <asp:Button ID="btnConnect" runat="server" Text="Connect" OnClick="btnConnect_Click" />
    </div>
    </form>
</body>
</html>
