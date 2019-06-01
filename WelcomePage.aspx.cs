using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class _Default : System.Web.UI.Page
{
    SqlConnection con;
    SqlCommand cmd;
    SqlDataReader dr;
    private UInt64 user_id;

    protected void Page_Load(object sender, EventArgs e)
    {
        con = null;
        cmd = null;
        dr = null;
        user_id = 0;
        try
        {
            user_id = UInt64.Parse(Session["user_id"].ToString());
        }
        catch
        {
        }
        if (user_id != 0)
        {
            Response.Redirect("HomePage.aspx");
        }
    }

    protected void BtnLogin_Click(object sender, EventArgs e)
    {
        String mail = TxtLoginMail.Text.ToString().Trim();
        String pass = TxtLoginPass.Text.ToString().Trim();
        login(mail, pass);        
    }

    protected void BtnRegister_Click(object sender, EventArgs e)
    {
        String mail = TxtRegisterMail.Text.ToString().Trim();
        String name = TxtRegisterName.Text.ToString().Trim();
        String pass1 = TxtRegisterPasswd.Text.ToString().Trim();
        String pass2 = TxtRegisterPasswdConf.Text.ToString().Trim();

        //ValidRegMail.Validate();
        //LblRegisterStatus.Text = "ValidEmail :" + ValidRegMail.IsValid;
        //LblRegisterStatus.Visible = true;
        //return;

        if (name.Length < 3)
        {
            LblRegisterStatus.Text = "Name too short";
            LblRegisterStatus.Visible = true;
            return;
        }

        if (mail.Length < 5)
        {
            LblRegisterStatus.Text = "Mail too short";
            LblRegisterStatus.Visible = true;
            return;
        }
        ValidRegMail.Validate();
        if (ValidRegMail.IsValid == false)
        {
            LblRegisterStatus.Text = "Invalid e-mail";
            LblRegisterStatus.Visible = true;
            return;
        }

        if (pass1.Length < 8)
        {
            LblRegisterStatus.Text = "Password too short";
            LblRegisterStatus.Visible = true;
            return;
        }
        if (!pass1.Equals(pass2))
        {
            LblRegisterStatus.Text = "Passwords donot match";
            LblRegisterStatus.Visible = true;
            return;
        }
        LblRegisterStatus.Text = "OK";
        LblRegisterStatus.ForeColor = System.Drawing.Color.Green;
        LblRegisterStatus.Visible = true;
        int flag=0;

        try
        {
            con = SqlHelper.getInstance();
            con.Open();
            cmd = new SqlCommand("insert into Users(mail,user_name,password) values('" + mail + "','" + name + "','" + pass1 + "')", con);
            flag = cmd.ExecuteNonQuery();
            con.Close();
        }
        catch(Exception ex)
        {
            Response.Write(ex.ToString());
        }
        if (flag != 1)
        {
            LblRegisterStatus.Text = "Another account is already created using given email";
            LblRegisterStatus.Visible = true;
        }
        else
        {
            login(mail, pass1);
        }
    }

    private void login(String mail,String pass)
    {
        try
        {
            con = SqlHelper.getInstance();
            con.Open();
            cmd = new SqlCommand("select user_id,mail from Users where mail='" + mail + "' and password='" + pass + "'", con);
            dr = cmd.ExecuteReader();
        }
        catch
        {
            Response.Write("Invalid connection");
            return;
        }
        try
        {
            if (dr.Read() == true)
            {
                Session["user_id"] = dr[0].ToString();
                dr.Close();
                con.Close();
                Response.Redirect("HomePage.aspx");
            }
            else
            {
                LblLoginStatus.Visible = true;
            }

        }
        catch (Exception ex)
        {
            Response.Write(ex.ToString());
            return;
        }
    }

}