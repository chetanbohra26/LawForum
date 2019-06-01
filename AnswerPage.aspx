<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AnswerPage.aspx.cs" Inherits="AnswerPage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="position:relative;top:0px">
        <asp:Label ID="LblAnsMsgUserName" runat="server" Text="Welcome User" ForeColor="Green" Width="100%" style="text-align:center" /><br />
    </div>
        <div style="position:absolute;top:10px;right:10px">
        <asp:LinkButton ID="BtnLogout" runat="server" Text="Logout" onclick="BtnLogout_Click" />
    </div>
    <br />
    <div>
        <asp:Label ID="LblPostTxt1" runat="server" Text="Original Question:" /><br />
        <asp:Label ID="LblPostTitle" runat="server" Text="Title" Font-Bold="true"/><br />
        <asp:Label ID="LblPostTxt2" runat="server" Text="Posted by : " Font-Bold="true" />
        <asp:Label ID="LblPostUName" runat="server" Text="User" /><br /><br />
        <asp:Label ID="LblPostDesciption" runat="server" Text="Description" /><br />
    </div>
    <hr />
    <div>
        <asp:Label ID="Label1" runat="server" Text="Suggested Answer:" /><br />
        <asp:Label ID="Label2" runat="server" Text="Posted by : " Font-Bold="true" />
        <asp:Label ID="LblAnsUName" runat="server" Text="User" /><br />
        <asp:Label ID="LblAnsDesc" runat="server" /><br />
    </div>
    <hr />
    <asp:Label ID="LblAnswer1" runat="server" Text="Comment on the suggested answer..." /><br />
        <asp:TextBox ID="TxtComment" runat="server" placeholder="Enter Comments"
            TextMode="multiline" Columns="50" Rows="5" /><br />
        <asp:Button ID="BtnSubmitComment" runat="server" Text="Submit Comment" onclick="BtnSubmitComment_Click" /><br />
        <asp:Label ID="LblCommentStatus" runat="server" Visible="false" Font-Bold="true" ForeColor="Red" /><br />
        <hr />
    <div>
        <asp:Label ID="LblAnsMessage" runat="server" Text="Comments from other users..." /><br />
        <asp:DataList ID="ListComments" runat="server" >
            <ItemTemplate>
                <table cellpadding="10" cellspacing="10" border="1" width="500px" style="border:dashed 2px">
                    <tr>
                        <tr >  
                        <td>  
                            <b>ID: </b><%# Eval("comment_id") %> <br />  
                            <b>Comment: </b><%# Eval("comment_text") %> <br />  
                            <b>Posted by: </b><%# Eval("user_name")%><br />  
                        </td>  
                    </tr>
                </table>
            </ItemTemplate>
        </asp:DataList>
    </div>
    </form>
</body>
</html>
