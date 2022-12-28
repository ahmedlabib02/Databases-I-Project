using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;

namespace milestone3
{
    public partial class Fans : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        void availableMatches()
        {
            String connStr = WebConfigurationManager.ConnectionStrings["Milestone2#1"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            String username = Session["user"].ToString();
            DateTime starttime = DateTime.Parse(start_time.Text);
            String s = starttime.ToString("yyyy/MM/dd HH:mm:ss");
            String func = "select * from availableMatchesToAttend2('"+s+"')";
        SqlDataAdapter viewInfo = new SqlDataAdapter(func, conn);
        DataTable t = new DataTable();
        viewInfo.Fill(t);
            GridView1.DataSource = t;
            GridView1.DataBind();
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if(e.CommandName=="Purchase")
            {
                String connStr = WebConfigurationManager.ConnectionStrings["Milestone2#1"].ToString();
                SqlConnection conn = new SqlConnection(connStr);
                int crow = Convert.ToInt32(e.CommandArgument.ToString());
                String s = "select national_id from fan where username = '" + Session["user"] + "'";
                String national_id;
                conn.Open();
                SqlCommand getNational = new SqlCommand(s,conn);
                SqlDataReader getNationalreader = getNational.ExecuteReader();
                getNationalreader.Read();
                national_id = getNationalreader["national_id"].ToString();
                getNationalreader.Close();
                SqlCommand purchase = new SqlCommand("purchaseTicket", conn);
                DateTime starttime = DateTime.Parse(start_time.Text);
                String s2 = starttime.ToString("yyyy/MM/dd HH:mm:ss");
                String host = GridView1.Rows[crow].Cells[0].Text;
                String guest = GridView1.Rows[crow].Cells[1].Text;
                 
                purchase.CommandType =  System.Data.CommandType.StoredProcedure;
                purchase.Parameters.Add(new SqlParameter("@natid",national_id));
                purchase.Parameters.Add(new SqlParameter("@host",host));
                purchase.Parameters.Add(new SqlParameter("@guest",guest));
                purchase.Parameters.Add(new SqlParameter("@sdate",s2));
                purchase.ExecuteNonQuery();
                Response.Write(s2);

                
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            DateTime starttime = DateTime.Parse(start_time.Text);
            if (starttime < DateTime.Now)
                Response.Write("Invalid date");
            else
                availableMatches();
        }
    }
}