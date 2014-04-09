<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Refresh.aspx.cs" Inherits="IdioSoft.Site.Util.Page.Refresh" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript">
        function myrefresh() {
            window.location.reload();
        }
        setTimeout('myrefresh()', 30000);
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
    </form>
</body>
</html>
