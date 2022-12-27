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
    public partial class Club_representative : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["Milestone2#1"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            String infoCommand = "Select C.id, C.name, C.location FROM Club_representative cr INNER JOIN Club C ON (cr.Club_id = C.id) WHERE cr.Username = " +"'"+ Session["user"].ToString()+"'";
            String clubNameCurrent="";
            conn.Open();

            SqlCommand clubInfo = new SqlCommand(infoCommand, conn);
            
            SqlDataReader infoReader = clubInfo.ExecuteReader();
            while(infoReader.Read())
            {
               clubID.Text = infoReader["id"].ToString();
               clubName.Text = infoReader["name"].ToString();
               clubLocation.Text = infoReader["location"].ToString();
               clubNameCurrent = infoReader["name"].ToString();
            }
            infoReader.Close();

            String upcomingMatchesFunction = "SELECT * FROM upcomingMatchesOfClubNew(" +"'"+clubNameCurrent+"'"+")";

            SqlDataAdapter viewUpcomingMatches = new SqlDataAdapter(upcomingMatchesFunction, conn);
            DataTable dtbl = new DataTable();
            viewUpcomingMatches.Fill(dtbl);
            upcomingMatchesTable.DataSource = dtbl;
            upcomingMatchesTable.DataBind();
            
            conn.Close();



        }

        protected void viewStadiums(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["Milestone2#1"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            conn.Open();
            DateTime timeInput = DateTime.Parse(dateInput.Text);
            String dateString = timeInput.ToString("yyyy/MM/dd");
            
            String availableStadiumsFunction = "SELECT * FROM viewAvailableStadiumsOn("+"'"+dateString+"'"+")";
            SqlDataAdapter viewAvailableStadiums= new SqlDataAdapter(availableStadiumsFunction, conn);
            DataTable dtbl = new DataTable();
            viewAvailableStadiums.Fill(dtbl);
            stadiumsTable.DataSource = dtbl;
            stadiumsTable.DataBind();


        }
    }
}