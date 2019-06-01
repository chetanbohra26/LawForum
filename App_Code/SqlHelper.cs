using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for SqlHelper
/// </summary>
public class SqlHelper
{
    private static String conString;
    private static String source = "AVINASHSHARMA\\SQLEXPRESS";
    private static String dbName = "LawForum";
    private static SqlConnection con;
	private SqlHelper()
	{
	}
    public static SqlConnection getInstance()
    {
        if (con == null)
        {
            //conString = "Data Source=" + source + ";Initial Catalog=" + dbName + ";Integrated Security=True";
            conString = "Data Source=AVINASHSHARMA\\SQLEXPRESS;Initial Catalog=LawForum;Integrated Security=True";
            con = new SqlConnection(conString);
        }
        //return con;
        //return new SqlConnection("Data Source=AVINASHSHARMA\\SQLEXPRESS;Initial Catalog=LawForum;Integrated Security=True");
        return new SqlConnection("Data Source=DARKWOLF\\SQLEXPRESS;Initial Catalog=LawForum;Integrated Security=True");
    }
}