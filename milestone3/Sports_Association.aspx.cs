using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace milestone3
{
    public partial class Sports_Association : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownList1.SelectedIndex == 1)
            {
                MultiView1.ActiveViewIndex = 0;
            }
            if (DropDownList1.SelectedIndex == 2)
            {
                MultiView1.ActiveViewIndex = 1;
            }
            if (DropDownList1.SelectedIndex == 3)
            {
                MultiView1.ActiveViewIndex = 2;

            }
            if (DropDownList1.SelectedIndex == 4)
            {
                MultiView1.ActiveViewIndex = 3;
            }
            if (DropDownList1.SelectedIndex == 5)
            {
                MultiView1.ActiveViewIndex = 4;
            }
        }

        protected void addMatch(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["Milestone2#1"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            String host = DropDownList2.SelectedItem.Text;
            String guest = DropDownList2.SelectedItem.Text;
            DateTime starttime = DateTime.Parse(start_time.Text);
            DateTime endtime = DateTime.Parse(end_time.Text);
            String start = starttime.ToString("yyyy/MM/dd HH:mm:ss");
            String end = endtime.ToString("yyyy/MM/dd HH:mm:ss");
            DateTime current_time = DateTime.Now;
            if (starttime < current_time|| endtime<starttime)
                Response.Write("invalid date");
            else
            {
                conn.Open();
                SqlCommand addMatch = new SqlCommand("addNewMatch", conn);

                addMatch.Parameters.Add(new SqlParameter("@hostclub",host));
                addMatch.Parameters.Add(new SqlParameter("@guestclub", guest));
                addMatch.Parameters.Add(new SqlParameter("@sdate", start));
                addMatch.Parameters.Add(new SqlParameter("@edate", end));
                addMatch.CommandType = System.Data.CommandType.StoredProcedure;
                addMatch.ExecuteNonQuery();
            }
            conn.Close();
        }

    }
}