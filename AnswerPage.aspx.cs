using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class AnswerPage : System.Web.UI.Page
{
    SqlConnection con = null;
    SqlCommand cmd = null;
    SqlDataReader dr = null;
    private UInt64 user_id = 0;
    private UInt64 answer_id = 0;
    private UInt64 post_id = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        String name = getUname();
        if (name == null)
        {
            Response.Redirect("WelcomePage.aspx");
        }
        else
        {
            LblAnsMsgUserName.Text = "Welcome " + name;
        }
        try
        {
            answer_id = UInt64.Parse(Request.QueryString["answer_id"]);
            post_id = UInt64.Parse(Request.QueryString["post_id"]);
        }
        catch
        {
            Response.Write("Paramter passed was null " + answer_id + " " + post_id);
            return;
        }
        loadPost();
        loadAnswer();
        loadComments();
    }

    private void loadPost()
    {
        try
        {
            con = SqlHelper.getInstance();
            con.Open();
            cmd = new SqlCommand("select post_title,post_desc,user_name from Posts,Users where Posts.user_id = Users.user_id and post_id = " + post_id, con);
            dr = cmd.ExecuteReader();
            dr.Read();
            LblPostTitle.Text = "Title : " + dr[0].ToString();
            LblPostUName.Text = dr[2].ToString();
            LblPostDesciption.Text = dr[1].ToString();
            dr.Close();
            con.Close();
        }
        catch (Exception e)
        {
            Response.Write(e.ToString());
        }
    }

    private void loadAnswer()
    {
        try
        {
            con = SqlHelper.getInstance();
            con.Open();
            cmd = new SqlCommand("select answer_desc,user_name from Answers,Users where Answers.user_id = Users.user_id and answer_id = "+answer_id,con);
            dr = cmd.ExecuteReader();
            dr.Read();
            LblAnsUName.Text = dr[1].ToString();
            LblAnsDesc.Text = dr[0].ToString();
            dr.Close();
            con.Close();
        }
        catch (Exception e)
        {
            Response.Write(e.ToString());
        }
    }

    private void loadComments()
    {
        con = SqlHelper.getInstance();
        con.Open();
        cmd = new SqlCommand("select comment_id,comment_text,user_name from Comments, Users where Comments.user_id = Users.user_id and answer_id=" + answer_id, con);
        ListComments.DataSource = cmd.ExecuteReader();
        ListComments.DataBind();
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

    protected void BtnSubmitComment_Click(object sender, EventArgs e)
    {
        String comment = TxtComment.Text.ToString().Trim();

        if (comment.Length == 0)
        {
            LblCommentStatus.Text = "Answer cannot be empty";
            LblCommentStatus.ForeColor = System.Drawing.Color.Red;
            LblCommentStatus.Visible = true;
            return;
        }

        con = SqlHelper.getInstance();
        con.Open();
        cmd = new SqlCommand("insert into Comments(answer_id,user_id,comment_text) values(" + answer_id +
            "," + user_id + ",'" + comment + "')", con);

        int flag = cmd.ExecuteNonQuery();
        if (flag != 1)
        {
            LblCommentStatus.Text = "Could not submit answer";
            LblCommentStatus.ForeColor = System.Drawing.Color.Red;
            LblCommentStatus.Visible = true;
        }
        else
        {
            LblCommentStatus.Text = "Success";
            LblCommentStatus.ForeColor = System.Drawing.Color.Green;
            LblCommentStatus.Visible = true;
            TxtComment.Text = "";
        }
        con.Close();
    }
}