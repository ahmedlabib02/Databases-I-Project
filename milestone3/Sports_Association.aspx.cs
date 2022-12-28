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
            GridView1.DataBind();
            GridView2.DataBind();
            GridView3.DataBind();
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
            String guest = DropDownList3.SelectedItem.Text;
            DateTime starttime = DateTime.Parse(start_time.Text);
            DateTime endtime = DateTime.Parse(end_time.Text);
            String start = starttime.ToString("yyyy/MM/dd HH:mm:ss");
            String end = endtime.ToString("yyyy/MM/dd HH:mm:ss");
            DateTime current_time = DateTime.Now;
            if (starttime < current_time || endtime < starttime)
                Response.Write("invalid date");
            else
            if (host == guest)
                Response.Write("A club cannot face itself");

            else
            {
                conn.Open();
                SqlCommand addMatch = new SqlCommand("addNewMatch", conn);

                addMatch.Parameters.Add(new SqlParameter("@hostclub", host));
                addMatch.Parameters.Add(new SqlParameter("@guestclub", guest));
                addMatch.Parameters.Add(new SqlParameter("@sdate", start));
                addMatch.Parameters.Add(new SqlParameter("@edate", end));
                addMatch.CommandType = System.Data.CommandType.StoredProcedure;
                addMatch.ExecuteNonQuery();

            }
            conn.Close();
        }

        protected void deleteMatch(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["Milestone2#1"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            String host = DropDownList4.SelectedItem.Text;
            String guest = DropDownList5.SelectedItem.Text;
            DateTime starttime = DateTime.Parse(TextBox1.Text);
            DateTime endtime = DateTime.Parse(TextBox2.Text);
            String start = starttime.ToString("yyyy/MM/dd HH:mm:ss");
            String end = endtime.ToString("yyyy/MM/dd HH:mm:ss");
            conn.Open();
            SqlCommand deleteMatch = new SqlCommand("deleteMatchm3", conn);
            String s1 = "select  C1.name host, C2.name guest, m.start_time,m.end_time from match m inner join Club c1 on m.host_id= c1.id inner join club c2 on c2.id = m.visitor_id ";
            SqlCommand findallMatch = new SqlCommand(s1, conn);
            SqlDataReader findmatchreader = findallMatch.ExecuteReader();
            Boolean flag = false;

            while (findmatchreader.Read()) {
                if (((DateTime)findmatchreader["start_time"]).ToString("yyyy/MM/dd HH:mm:ss").Equals(start) && ((DateTime)findmatchreader["end_time"]).ToString("yyyy/MM/dd HH:mm:ss").Equals(end) &&
                    findmatchreader["host"].ToString().Equals(host) && findmatchreader["guest"].ToString().Equals(guest))
                    flag = true;
                        }
            findmatchreader.Close();
            if (flag)
            {
                deleteMatch.CommandType = System.Data.CommandType.StoredProcedure;
                deleteMatch.Parameters.Add(new SqlParameter("@host", host));
                deleteMatch.Parameters.Add(new SqlParameter("@guest", guest));
                deleteMatch.Parameters.Add(new SqlParameter("@sdate", start));
                deleteMatch.Parameters.Add(new SqlParameter("@edate", end));
                deleteMatch.ExecuteNonQuery();
               
            }
            else
               Response.Write("There is no such match");
            

        }
    }
}