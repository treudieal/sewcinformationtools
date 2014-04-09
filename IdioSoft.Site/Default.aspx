<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="IdioSoft.Site._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="style/css/Default.css" />
    <link rel="stylesheet" type="text/css" href="style/css/icomoon.css" />

    <link rel="stylesheet" type="text/css" href="style/css/bootstrap.css" />
    <link rel="stylesheet" type="text/css" href="style/css/bootstrap-responsive.css" />
    <link rel="stylesheet" type="text/css" href="style/css/bootmetro.css" />
    <link rel="stylesheet" type="text/css" href="style/css/bootmetro-tiles.css" />
    <link rel="stylesheet" type="text/css" href="style/css/bootmetro-charms.css" />
    <link rel="stylesheet" type="text/css" href="style/css/metro-ui-light.css" />

    <script type="text/javascript" src="Scripts/jquery-1.9.1.js"></script>
    <script type="text/javascript" src="Scripts/modernizr-2.6.1.min.js"></script>
     
    <script type="text/javascript" src="Scripts/JsFunction.js"></script>
    <script type="text/javascript" src="Scripts/JsClass.js"></script>
    <script type="text/javascript" src="JsLibrary/Login/JsLogin-default.js"></script>
 
</head>
<body>
    <form id="form1" runat="server">
        <div id="divLogo">
            <img src="Style/images/logo.gif" border="0" alt="Siemens" />
        </div>
        <div>
            <div id="divLogin">

                <div style="text-align: center;">
                    <table border="0" style="margin: auto;">
                        <tr>
                            <td style="height: 20px;"></td>
                        </tr>
                        <tr>
                            <td colspan="3" class="LoginTitle">Sign in to Informationtools</td>
                        </tr>
                        <tr>
                            <td>
                                <div data-icon="&#xe008;" style="font-size: 96px;padding-right:20px;"></div>
                            </td>
                            <td colspan="2">
                                <table width="100%" border="0" cellspacing="4" cellpadding="0">
                                    <tr>
                                        <td>LoginName</td>
                                        <td width="80%" style="text-align: left;">
                                            <input type="text" name="txtLoginName" id="txtLoginName" placeholder="Input you name" style="width: 240px;" /></td>
                                    </tr>
                                    <tr>
                                        <td>Password</td>
                                        <td style="text-align: left;">
                                            <input type="password" name="txtLoginPwd" id="txtLoginPwd" placeholder="Input you password" style="width: 240px;" /></td>
                                    </tr>
                                    <tr>
                                        <td>&nbsp;</td>
                                        <td style="text-align: left;">
                                            <input type="button" name="btnLogin" id="btnLogin" value="Login" class="btn btn-info" />
                                            <input type="reset" name="btnRest" id="btnRest" value="Reset" class="btn" />
                                        </td>

                                        
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
        </div>
    </form>
    <script type="text/javascript" src="scripts/jquery.mousewheel.js"></script>
    <script type="text/javascript" src="scripts/jquery.scrollTo.js"></script>
    <script type="text/javascript" src="scripts/bootstrap.js"></script>
    <script type="text/javascript" src="scripts/bootmetro.js"></script>
    <script type="text/javascript" src="scripts/bootmetro-charms.js"></script>
    <script type="text/javascript" src="scripts/holder.js"></script>

    <script type="text/javascript">
        $(".metro").metro();
    </script>
</body>
</html>
