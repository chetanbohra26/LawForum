using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class PostPage : System.Web.UI.Page
{
    SqlConnection con;
    SqlCommand cmd;
    SqlDataReader dr;
    private UInt64 user_id = 0;
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
            LblPostMsgUserName.Text = "Welcome " + name;
        }
        try
        {
            post_id = UInt64.Parse(Request.QueryString["post_id"]);
        }
        catch
        {
            Response.Write("Paramter passed was null");
        }

        loadPost();
        loadAnswers();
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
            LblPostDesciption.Text = dr[1].ToString();
            LblPostUName.Text = dr[2].ToString();
        }
        catch(Exception e)
        {
            Response.Write(e.ToString());
        }
    }

    private void loadAnswers()
    {
        con = SqlHelper.getInstance();
        con.Open();
        cmd = new SqlCommand("select answer_id,answer_desc,user_name from Answers, Users where Answers.user_id = Users.user_id and post_id="+post_id, con);
        ListAnswers.DataSource = cmd.ExecuteReader();
        ListAnswers.DataBind();
    }

    protected void BtnLogout_Click(object sender, EventArgs e)
    {
        Session["user_id"] = 0;
        Response.Redirect("WelcomePage.aspx");
    }
    protected void BtnSubmitAnswer_Click(object sender, EventArgs e)
    {
        String ans = TxtAnswerDescription.Text.ToString().Trim();

        if (ans.Length == 0)
        {
            LblAnswerStatus.Text = "Answer cannot be empty";
            LblAnswerStatus.ForeColor = System.Drawing.Color.Red;
            LblAnswerStatus.Visible = true;
            return;
        }

        con = SqlHelper.getInstance();
        con.Open();
        cmd = new SqlCommand("insert into Answers(post_id,user_id,answer_desc) values(" + post_id + "," + user_id + ",'" + ans + "')", con);
        int flag = cmd.ExecuteNonQuery();
        if (flag != 1)
        {
            LblAnswerStatus.Text = "Could not submit answer";
            LblAnswerStatus.ForeColor = System.Drawing.Color.Red;
            LblAnswerStatus.Visible = true;
        }
        else
        {
            LblAnswerStatus.Text = "Success";
            LblAnswerStatus.ForeColor = System.Drawing.Color.Green;
            LblAnswerStatus.Visible = true;
            TxtAnswerDescription.Text = "";
        }
        con.Close();
    }
    protected void AnsLink_Click(object sender, EventArgs e)
    {
        dr.Close();
        con.Close();
        Response.Redirect("AnswerPage.aspx?post_id=" + post_id + "&answer_id=" + ((LinkButton)sender).Text);//+ "&post_id=" + post_id);
    }
}