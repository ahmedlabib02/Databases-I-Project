using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Caching;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace milestone3
{
    public partial class System_admin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["Milestone2#1"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            if (DropDownList1.SelectedIndex == 1)
            {
                MultiView1.ActiveViewIndex = 0;
            }
            if (DropDownList1.SelectedIndex == 2)
            {
                MultiView1.ActiveViewIndex = 1;
            }
            if(DropDownList1.SelectedIndex == 3)
            {
                MultiView1.ActiveViewIndex = 2;

            }
            if(DropDownList1.SelectedIndex == 4)
            {
                MultiView1.ActiveViewIndex = 3;
            }
            if(DropDownList1.SelectedIndex == 5)
            {
                MultiView1.ActiveViewIndex = 4;
            }

        }

        protected void addClub(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["Milestone2#1"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            String clubname = club_name.Text;
            String clubloc = club_location.Text;
            SqlCommand addclub = new SqlCommand("addClub",conn);
            addclub.CommandType = System.Data.CommandType.StoredProcedure;
            addclub.Parameters.Add(new SqlParameter("@name",clubname));
            addclub.Parameters.Add(new SqlParameter("@location", clubloc));
            conn.Open();
            String s1 = "select name from club";
            SqlCommand findclub = new SqlCommand(s1,conn);
            SqlDataReader findclubreader = findclub.ExecuteReader();
            Boolean flag = false;
            while (findclubreader.Read())
            {
                if (findclubreader["name"].ToString().ToLower() == clubname.ToLower())
                    flag = true;
            }
            findclubreader.Close();
            if (flag == true)
                Response.Write("club already exists");
            else
            {
                addclub.ExecuteNonQuery();
            }
        }

        protected void deleteClub(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["Milestone2#1"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            String clubname = club_name2.Text;
            SqlCommand deleteclub = new SqlCommand("deleteClub", conn);
            deleteclub.CommandType = System.Data.CommandType.StoredProcedure;
            deleteclub.Parameters.Add(new SqlParameter("@s", clubname));
            conn.Open();
            String s1 = "select name from club";
            SqlCommand findclub = new SqlCommand(s1, conn);
            SqlDataReader findclubreader = findclub.ExecuteReader();
            Boolean flag = false;
            while (findclubreader.Read())
            {
                if (findclubreader["name"].ToString().ToLower() == clubname.ToLower())
                    flag = true;
            }
            findclubreader.Close();
            if (!flag)
                Response.Write("club does not exist");
            else
            {
                deleteclub.ExecuteNonQuery();
            }

        }

        protected void addStadium(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["Milestone2#1"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            String sname = stadium_name.Text;
            String sloc = stadium_loc.Text;
            String scap = stadium_cap.Text;
            SqlCommand addStadium = new SqlCommand("addStadium", conn);
            addStadium.CommandType = System.Data.CommandType.StoredProcedure;
            addStadium.Parameters.Add(new SqlParameter("@name", sname));
            addStadium.Parameters.Add(new SqlParameter("@location", sloc));
            addStadium.Parameters.Add(new SqlParameter("@capacity", scap));
            conn.Open();
            String s1 = "select name from stadium";
            SqlCommand findstadium = new SqlCommand(s1, conn);
            SqlDataReader findstadiumreader = findstadium.ExecuteReader();
            Boolean flag = false;
            while (findstadiumreader.Read())
            {
                if (findstadiumreader["name"].ToString().ToLower() == sname.ToLower())
                    flag = true;
            }
            findstadiumreader.Close();
            if (flag == true)
                Response.Write("stadium already exists");
            else
            {
                addStadium.ExecuteNonQuery();
            }

        }

        protected void deleteStadium(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["Milestone2#1"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            String sname = stadium_name2.Text;
            SqlCommand delStadium = new SqlCommand("deleteStadium", conn);
            delStadium.CommandType = System.Data.CommandType.StoredProcedure;
            delStadium.Parameters.Add(new SqlParameter("@name", sname));
            conn.Open();
            String s1 = "select name from stadium";
            SqlCommand findstadium = new SqlCommand(s1, conn);
            SqlDataReader findstadiumreader = findstadium.ExecuteReader();
            Boolean flag = false;
            while (findstadiumreader.Read())
            {
                if (findstadiumreader["name"].ToString().ToLower() == sname.ToLower())
                    flag = true;
            }
            findstadiumreader.Close();
            if (!flag)
                Response.Write("stadium does not exist");
            else
            {
                delStadium.ExecuteNonQuery();
            }
        }

        protected void blockFan(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["Milestone2#1"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            String id = national_id.Text;
            SqlCommand blockfan = new SqlCommand("blockFan", conn);
            blockfan.CommandType = System.Data.CommandType.StoredProcedure;
            blockfan.Parameters.Add(new SqlParameter("@national_id", id));
            conn.Open();
            String s1 = "select national_id,status from fan";
            SqlCommand findfan = new SqlCommand(s1, conn);
            SqlDataReader findfanreader = findfan.ExecuteReader();
            Boolean flag = false;
            Boolean flag2 = false;
            while (findfanreader.Read())
            {
                if (findfanreader["national_id"].ToString().ToLower() == id.ToLower()) { 
                flag = true;
                    if ((bool)findfanreader["status"]== false)
                        flag2 = true;
            }
            }
            findfanreader.Close();
            if (!flag)
                Response.Write("this national id does not exist");
            else
            {
                if (!flag2)
                    blockfan.ExecuteNonQuery();
                else
                    Response.Write("fan is already blocked");
            }
        }
    }
}