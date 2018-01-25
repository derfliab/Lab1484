using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;


public partial class Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
 
    }

 
    protected void ShowDataBtn_Click(object sender, EventArgs e)
    {
        try
        {
            System.Data.SqlClient.SqlConnection sc = new System.Data.SqlClient.SqlConnection();
            sc.ConnectionString = @"Server =Localhost ;Database=Lab2;Trusted_Connection=Yes;";

            sc.Open();

            System.Data.SqlClient.SqlCommand insert = new System.Data.SqlClient.SqlCommand();
            insert.Connection = sc;
            insert.CommandText += "select * from [dbo].[EMPLOYEE]";
            SqlDataReader rdr = insert.ExecuteReader();
            GridView1.DataSource = rdr;
            GridView1.DataBind();
            sc.Close();
             

        }
        catch (Exception r)
        {
            Label.Text += "Error";
            Label.Text += r.Message;
        }
    }
}