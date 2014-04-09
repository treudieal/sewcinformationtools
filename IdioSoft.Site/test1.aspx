<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="test1.aspx.cs" Inherits="IdioSoft.Site.test1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
        <asp:DropDownList ID="DropDownList1" runat="server"></asp:DropDownList>
         <asp:TextBox ID="txtPassword" runat="server"></asp:TextBox><asp:Button ID="btnLogin" runat="server" Text="Button" OnClick="btnLogin_Click" />
    </div>
       <img src="Style/images/yellow.png" />
    </form>
</body>
</html>
