using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.NetworkInformation;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

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


            String upcomingMatchesStartTime = "SELECT start_time FROM upcomingMatchesOfClubNew(" +"'"+clubNameCurrent+"'"+")";
            
            SqlDataAdapter viewUpcomingStartTimes = new SqlDataAdapter(upcomingMatchesStartTime, conn);
            DataTable dtbl2 = new DataTable();
            viewUpcomingStartTimes.Fill(dtbl2);
            upcomingMatchesDropDown.DataSource = dtbl2;
            upcomingMatchesDropDown.DataBind();
            upcomingMatchesDropDown.DataTextField = "start_time";
            upcomingMatchesDropDown.DataValueField = "start_time";
            upcomingMatchesDropDown.DataBind();
            



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

            conn.Close();


        }

        protected void sendRequest(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["Milestone2#1"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            conn.Open();

            String stadiumName = stadiumDropDown.Text;
            String startTime = upcomingMatchesDropDown.Text;
            
            

            
            if(startTime == "")
            {
                requestSentNotification.Text = "You have not selected any upcoming matches";
            }
            else
            {
                DateTime start = Convert.ToDateTime(startTime);
                String startTimeFinal = start.ToString("yyyy/MM/dd HH:mm:ss");
                requestSentNotification.Text = "Request Sent Successfully";
                SqlCommand addHostRequest = new SqlCommand("addHostRequest", conn);
                addHostRequest.CommandType = System.Data.CommandType.StoredProcedure;


                String infoCommand = "Select C.id, C.name, C.location FROM Club_representative cr INNER JOIN Club C ON (cr.Club_id = C.id) WHERE cr.Username = " + "'" + Session["user"].ToString() + "'";
                String clubNameCurrent = "";

                SqlCommand clubInfo = new SqlCommand(infoCommand, conn);

                SqlDataReader infoReader = clubInfo.ExecuteReader();
                while (infoReader.Read())
                {
                    clubNameCurrent = infoReader["name"].ToString();
                }
                infoReader.Close();

                

                addHostRequest.Parameters.Add(new SqlParameter("@club",clubNameCurrent));
                addHostRequest.Parameters.Add(new SqlParameter("@stadium",stadiumName));
                addHostRequest.Parameters.Add(new SqlParameter("@start", startTimeFinal));
                addHostRequest.ExecuteNonQuery();
                
                Response.Write(startTimeFinal);


            }
        }
    }
}