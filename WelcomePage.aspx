<%@ Page Language="C#" AutoEventWireup="true" CodeFile="WelcomePage.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="formWelcomePage" runat="server">
        <div style="position:absolute;top:10px;right:10px;float:right;">
            <asp:Label ID="LblLoginMsg" runat="server" Text="Enter Login details:" style="padding:12px 20px" /><br />
            <asp:TextBox ID="TxtLoginMail" runat="server" placeholder="Enter mail" />
            <asp:TextBox ID="TxtLoginPass" runat="server" placeholder="Enter password" TextMode="Password" />
            <asp:Button ID="BtnLogin" runat="server" Text="Login" onclick="BtnLogin_Click" /> &nbsp; <br />
            <asp:Label ID="LblLoginStatus" runat="server" Text="Incorrect Login Details..! Try Again..!" Visible="false" ForeColor="Red" Font-Bold="true" /><br />
            <hr />
            <asp:Label ID="LblRegisterMsg" runat="server" Text="Enter Register Details:" Width="100%" style="text-align:center" /><br />
            <asp:TextBox ID="TxtRegisterName" runat="server" placeholder="Enter full name" Width="100%" /><br />
            
            <asp:TextBox ID="TxtRegisterMail" runat="server" placeholder="Enter email address" Width="100%" />           
            <asp:TextBox ID="TxtRegisterPasswd" runat="server" TextMode="Password" placeholder="Enter password" Width="100%" /><br />
            <asp:TextBox ID="TxtRegisterPasswdConf" runat="server" TextMode="Password" placeholder="Enter confirm password" Width="100%" /><br />
            <asp:Button ID="BtnRegister" runat="server" Text="Register" onclick="BtnRegister_Click" ValidationGroup="RegisterGrp" /> <br />
            <asp:Label ID="LblRegisterStatus" runat="server" Visible="false" ForeColor="Red" Font-Bold="true" /> 
            <asp:RegularExpressionValidator ID="ValidRegMail" runat="server" 
                ControlToValidate="TxtRegisterMail" ErrorMessage="Please enter correct email" 
                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ForeColor="Red" ValidationGroup="RegisterGrp" Font-Bold="true"/>      
        </div>
    </form>
    
</body>
</html>
