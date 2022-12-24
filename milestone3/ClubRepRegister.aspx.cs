using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace milestone3
{
    public partial class ClubRepRegister : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void repReg(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["Milestone2#1"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            String repName = repNameTxt.Text;
            String clubName = clubNameTxt.Text;
            String repUsername = repUsernameTxt.Text;
            String repPassword = repPasswordTxt.Text;
            String[] inputs = {repName, clubName, repUsername,repPassword};

            conn.Open();
            SqlCommand addRepresentative = new SqlCommand("addRepresentative", conn);
            addRepresentative.CommandType = System.Data.CommandType.StoredProcedure;

            bool emptyField = false;
            bool userExists = false;
            bool clubExists = false;
            bool clubHasRep = false;

            SqlCommand repUsernames = new SqlCommand("select username from System_users", conn);
            SqlCommand clubNames = new SqlCommand("select name from Club", conn);
            SqlCommand clubNameWithClubRep = new SqlCommand("Select Club.name FROM Club INNER JOIN Club_representative ON (Club.id = Club_representative.Club_id)", conn);

            for (int i = 0; i < inputs.Length; i++)
            {
                if (string.IsNullOrWhiteSpace(inputs[i]))
                {
                    emptyField = true;
                }
            }

            SqlDataReader repUsernameReader = repUsernames.ExecuteReader();
            while (repUsernameReader.Read())
            {
                if (repUsernameReader["username"].ToString() == repUsername)
                {
                    userExists = true;
                }
            }
            repUsernameReader.Close();

            SqlDataReader clubNamesReader = clubNames.ExecuteReader();
            while (clubNamesReader.Read())
            {
                if (clubNamesReader["name"].ToString().ToLower() == clubName.ToLower())
                {
                    clubExists = true;
                }
            }
            clubNamesReader.Close();

            SqlDataReader clubReader = clubNameWithClubRep.ExecuteReader();
            while (clubReader.Read())
            {
                if (clubReader["name"].ToString().ToLower() == clubName.ToLower())
                {
                    clubHasRep= true;
                }
            }
            clubReader.Close();

            if (userExists) { Response.Write("This username is in use, enter another username"); }
            else if (emptyField)
            {
                Response.Write("Make Sure to Fill All Fields");
            }
            else if (!clubExists)
            {
                Response.Write("This Club does not Exist, Input another Club Name");
            }
            else if (clubHasRep)
            {
                Response.Write("This Club already has a Representative, Input a Different Club");
            }
            else
            {
                Response.Write("Registration Successful");
                addRepresentative.Parameters.Add(new SqlParameter("@name", repName));
                addRepresentative.Parameters.Add(new SqlParameter("@clubname", clubName));
                addRepresentative.Parameters.Add(new SqlParameter("@username", repUsername));
                addRepresentative.Parameters.Add(new SqlParameter("@password", repPassword));
                addRepresentative.ExecuteNonQuery();
            }

        }
    }
}