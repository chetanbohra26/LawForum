using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class HomePage : System.Web.UI.Page
{
    SqlConnection con;
    SqlCommand cmd;
    SqlDataReader dr;
    private UInt64 user_id = 0;
    
    protected void Page_Load(object sender, EventArgs e)
    {
        String name = getUname();
        if (name == null)
        {
            Response.Redirect("WelcomePage.aspx");
        }
        else
        {
            LblHomeMsgUserName.Text = "Welcome " + name;
        }

        loadPosts();
    }

    public String getUname()
    {
        try
        {
            user_id = UInt64.Parse(Session["user_id"].ToString());
            con = SqlHelper.getInstance();
            con.Open();
            cmd = new SqlCommand("select user_name from Users where user_id=" + user_id, con);
            dr = cmd.ExecuteReader();
            dr.Read();
            return dr[0].ToString();
        }
        catch
        {
            return null;
        }
    }

    protected void BtnLogout_Click(object sender, EventArgs e)
    {
        Session["user_id"] = 0;
        Response.Redirect("WelcomePage.aspx");
    }

    private void loadPosts()
    {
        con = SqlHelper.getInstance();
        con.Open();
        cmd = new SqlCommand("select post_id,post_title,user_name from Posts,Users where Posts.user_id=Users.user_id", con);
        ListPosts.DataSource = cmd.ExecuteReader();
        ListPosts.DataBind();
    }

    protected void PostLink_Click(object sender, EventArgs e)
    {
        dr.Close();
        con.Close();
        Response.Redirect("PostPage.aspx?post_id=" + ((LinkButton)sender).Text);
    }
    protected void BtnSubmitPost_Click(object sender, EventArgs e)
    {
        String title = TxtPostTitle.Text.ToString().Trim();
        String desc = TxtPostDescription.Text.ToString().Trim();

        if (title.Length == 0)
        {
            LblPostStatus.Text = "Title cannot be empty";
            LblPostStatus.ForeColor = System.Drawing.Color.Red;
            LblPostStatus.Visible = true;
            return;
        }
        if (desc.Length == 0)
        {
            LblPostStatus.Text = "Decription cannot be empty";
            LblPostStatus.ForeColor = System.Drawing.Color.Red;
            LblPostStatus.Visible = true;
            return;
        }
        con = SqlHelper.getInstance();
        con.Open();
        cmd = new SqlCommand("insert into Posts(user_id,post_title,post_desc) values(" + user_id + ",'" + title + "','" + desc + "')", con);
        int flag = cmd.ExecuteNonQuery();
        if (flag != 1)
        {
            LblPostStatus.Text = "Could not submit post";
            LblPostStatus.ForeColor = System.Drawing.Color.Red;
            LblPostStatus.Visible = true;
        }
        else
        {
            LblPostStatus.Text = "Success";
            LblPostStatus.ForeColor = System.Drawing.Color.Green;
            LblPostStatus.Visible = true;
            TxtPostTitle.Text = "";
            TxtPostDescription.Text = "";
        }
    }
}