<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PostPage.aspx.cs" Inherits="PostPage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="position:relative;top:0px">
        <asp:Label ID="LblPostMsgUserName" runat="server" Text="Welcome User" ForeColor="Green" Width="100%" style="text-align:center" /><br />
    </div>
        <div style="position:absolute;top:10px;right:10px">
        <asp:LinkButton ID="BtnLogout" runat="server" Text="Logout" onclick="BtnLogout_Click" />
    </div>
    <br />
    <div>
        <asp:Label ID="LblPostTitle" runat="server" Text="Title" Font-Bold="true"/><br />
        <asp:Label ID="LblPostTxt1" runat="server" Text="Posted by : " Font-Bold="true" />
        <asp:Label ID="LblPostUName" runat="server" Text="User" /><br /><br />
        <asp:Label ID="LblPostDesciption" runat="server" Text="Description" /><br />
    </div>
    <hr />
    <div>
        <asp:Label ID="LblAnswer1" runat="server" Text="Answer the query above..." /><br />
        <asp:TextBox ID="TxtAnswerDescription" runat="server" placeholder="Enter Answer"
            TextMode="multiline" Columns="50" Rows="5" /><br />
        <asp:Button ID="BtnSubmitAnswer" runat="server" Text="Submit Answer" 
            onclick="BtnSubmitAnswer_Click" /><br />
        <asp:Label ID="LblAnswerStatus" runat="server" Visible="false" Font-Bold="true" ForeColor="Red" /><br />
        <hr />
        <asp:Label ID="LblAnsMessage" runat="server" Text="Or view answers below...." /><br />
        <asp:DataList ID="ListAnswers" runat="server" >
            <ItemTemplate>
                <table cellpadding="10" cellspacing="10" border="1" width="500px" style="border:dashed 2px">
                    <tr>
                        <tr >  
                        <td>  
                            <b>ID: </b><asp:LinkButton ID="AnsLink" runat="server" Text='<%# Eval("answer_id") %>' onclick="AnsLink_Click"/><br />  
                            <b>Answer: </b><%# Eval("answer_desc") %> <br />  
                            <b>Posted by: </b><%# Eval("user_name")%><br />  
                        </td>  
                    </tr>
                </table>
            </ItemTemplate>
        </asp:DataList>
    </div>
    <br />
    </form>
</body>
</html>
