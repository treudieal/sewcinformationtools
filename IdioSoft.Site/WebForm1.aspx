<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="IdioSoft.Site.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="Scripts/ckeditor/ckeditor.js"></script>
    <script type="text/javascript" src="Scripts/jquery-1.9.1.js"></script>
    <script type="text/javascript">
        $(function () {
            $("#btnSubmit").click(function () {
                alert(editor.document.getBody().getHtml());
            });
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <textarea id="editor1" name="editor1" rows="10" cols="80">
                This is my textarea to be replaced with CKEditor.
            </textarea>
            <script>
                // Replace the <textarea id="editor1"> with a CKEditor
                // instance, using default configuration.
                var editor = CKEDITOR.replace('editor1');
            </script>
        </div>
        <input type="button" value="submit" id="btnSubmit" />
    </form>
</body>
</html>
