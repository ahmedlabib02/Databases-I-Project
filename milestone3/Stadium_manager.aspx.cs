using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace milestone3
{
    public partial class Stadium_manager : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            showData();
            showRequests();
            showPendingrequests();
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

        }

        void showData()
        {
            String connStr = WebConfigurationManager.ConnectionStrings["Milestone2#1"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            String username = Session["user"].ToString();
            String s = "select s.name,s.location,s.capactiy from stadium s inner join Stadium_manager sm on sm.Stadium_id=s.Id where sm.username = " + "'" + Session["user"].ToString() + "'";
            SqlDataAdapter viewInfo = new SqlDataAdapter(s, conn);
            DataTable t = new DataTable();
            viewInfo.Fill(t);
            GridView1.DataSource = t;
            GridView1.DataBind();



        }
        void showRequests()
        {
            String connStr = WebConfigurationManager.ConnectionStrings["Milestone2#1"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            String username = Session["user"].ToString();
            String s = "select * from allRequestsfromuser('" + username + "')";
            SqlDataAdapter viewInfo = new SqlDataAdapter(s, conn);
            DataTable t = new DataTable();
            viewInfo.Fill(t);
            GridView2.DataSource = t;
            GridView2.DataBind();
        }

        void showPendingrequests()
        {
            String connStr = WebConfigurationManager.ConnectionStrings["Milestone2#1"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            String username = Session["user"].ToString();
            String s = "select * from allPendingRequests2('" + username + "')";
            SqlDataAdapter viewInfo = new SqlDataAdapter(s, conn);
            DataTable t = new DataTable();
            viewInfo.Fill(t);
            GridView3.DataSource = t;
            GridView3.DataBind();

        }

        protected void GridView3_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["Milestone2#1"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            if (e.CommandName == "Accept")
            {
                int crow = Convert.ToInt32(e.CommandArgument.ToString());
                String club_representative = GridView3.Rows[crow].Cells[0].Text;
                String host = GridView3.Rows[crow].Cells[1].Text;
                String guest = GridView3.Rows[crow].Cells[2].Text;
                String start = GridView3.Rows[crow].Cells[3].Text;
                String username = Session["user"].ToString();
                DateTime sdate = Convert.ToDateTime(start);
                conn.Open();
                SqlCommand acceptRequest = new SqlCommand("acceptRequest",conn);
                acceptRequest.CommandType =  System.Data.CommandType.StoredProcedure;
                acceptRequest.Parameters.Add(new SqlParameter("@manager", username));
                acceptRequest.Parameters.Add(new SqlParameter("@host", host));
                acceptRequest.Parameters.Add(new SqlParameter("@visitor", guest));
                acceptRequest.Parameters.Add(new SqlParameter("@datetime", sdate));
                acceptRequest.ExecuteNonQuery();
                GridView3.DataBind();
                Response.Redirect("Stadium_Manager.aspx");


            }
            if (e.CommandName == "Reject")
            {
                int crow = Convert.ToInt32(e.CommandArgument.ToString());
                String club_representative = GridView3.Rows[crow].Cells[0].Text;
                String host = GridView3.Rows[crow].Cells[1].Text;
                String guest = GridView3.Rows[crow].Cells[2].Text;
                String start = GridView3.Rows[crow].Cells[3].Text;
                String username = Session["user"].ToString();
                DateTime sdate = Convert.ToDateTime(start);
                conn.Open();
                SqlCommand rejectRequest = new SqlCommand("rejectRequest", conn);
                rejectRequest.CommandType = System.Data.CommandType.StoredProcedure;
                rejectRequest.Parameters.Add(new SqlParameter("@manager", username));
                rejectRequest.Parameters.Add(new SqlParameter("@host", host));
                rejectRequest.Parameters.Add(new SqlParameter("@visitor", guest));
                rejectRequest.Parameters.Add(new SqlParameter("@datetime", sdate));
                rejectRequest.ExecuteNonQuery();
                GridView3.DataBind();
                Response.Redirect("Stadium_Manager.aspx");
            }
        }

     
    }
}