<%@ Page Language="C#" AutoEventWireup="true" CodeFile="HomePage.aspx.cs" Inherits="HomePage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="position:relative;top:0px">
        <asp:Label ID="LblHomeMsgUserName" runat="server" Text="Welcome User" ForeColor="Green" Width="100%" style="text-align:center" /><br />
    </div>
    <div style="position:absolute;top:10px;right:10px">
        <asp:LinkButton ID="BtnLogout" runat="server" Text="Logout" onclick="BtnLogout_Click" />
    </div>
    <br />
    <div style="position:relative;top:10" >
        <asp:Label ID="LblPost1" runat="server" Text="Post your query for experts to answer..." /><br />
        <asp:TextBox ID="TxtPostTitle" runat="server" placeholder="Enter Post Title"/><br />
        <asp:TextBox ID="TxtPostDescription" runat="server" placeholder="Enter Post Description"
            TextMode="multiline" Columns="50" Rows="5" /><br />
        <asp:Button ID="BtnSubmitPost" runat="server" Text="Submit Post" 
            onclick="BtnSubmitPost_Click" /><br />
        <asp:Label ID="LblPostStatus" runat="server" Visible="false" Font-Bold="true" ForeColor="Red" /><br />
        <hr />
        <asp:Label ID="LblHomeMessage" runat="server" Text="Or select one of the queries below to view content...." /><br />
        <asp:DataList ID="ListPosts" runat="server" >
            <ItemTemplate>
                <table cellpadding="10" cellspacing="10" border="1" width="500px" style="border:dashed 2px">
                    <tr>
                        <tr >  
                        <td>  
                            <b>ID: </b><asp:LinkButton ID="PostLink" runat="server" Text='<%# Eval("post_id") %>' onclick="PostLink_Click" /><br />  
                            <b>Title: </b><%# Eval("post_title") %><br />  
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
