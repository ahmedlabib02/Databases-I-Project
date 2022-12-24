using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace milestone3
{
    public partial class StadManagerRegister : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void StadManagerReg(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["Milestone2#1"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            String smName = smNameTxt.Text;
            String stadiumName = stadiumNameTxt.Text;
            String smUsername = smUsernameTxt.Text;
            String smPassword = smPasswordTxt.Text;
            String[] inputs = { smName, stadiumName, smUsername, smPassword };

            conn.Open();
            SqlCommand addStadiumManager = new SqlCommand("addStadiumManager", conn);
            addStadiumManager.CommandType = System.Data.CommandType.StoredProcedure;

            bool emptyField = false;
            bool userExists = false;
            bool stadiumExists = false;
            bool stadiumHasManager = false;

            SqlCommand smUsernames = new SqlCommand("select username from System_users", conn);
            SqlCommand stadiumNames = new SqlCommand("select name from stadium", conn);
            SqlCommand stadiumManagerswithStadiumID = new SqlCommand("SELECT stadium.name FROM stadium INNER JOIN Stadium_manager ON (stadium.Id = Stadium_manager.Stadium_id)",conn);

            for (int i = 0; i < inputs.Length; i++)
            {
                if (string.IsNullOrWhiteSpace(inputs[i]))
                {
                    emptyField = true;
                }
            }

            SqlDataReader smUsernameReader = smUsernames.ExecuteReader();
            while (smUsernameReader.Read())
            {
                if (smUsernameReader["username"].ToString() == smUsername)
                {
                    userExists = true;
                }
            }
            smUsernameReader.Close();

            SqlDataReader stadiumNameReader = stadiumNames.ExecuteReader();
            while (stadiumNameReader.Read())
            {
                if (stadiumNameReader["name"].ToString().ToLower() == stadiumName.ToLower())
                {
                    stadiumExists = true;
                }
            }
            stadiumNameReader.Close();

            SqlDataReader stadiumReader = stadiumManagerswithStadiumID.ExecuteReader();
            while (stadiumReader.Read())
            {
                if (stadiumReader["name"].ToString().ToLower() == stadiumName.ToLower())
                {
                    stadiumHasManager = true;
                }
            }
            stadiumReader.Close();

            if (userExists) { Response.Write("This username is in use, enter another username"); }
            else if (emptyField)
            {
                Response.Write("Make Sure to Fill All Fields");
            }
            else if (!stadiumExists)
            {
                Response.Write("This Stadium does not Exist, Input another Stadium");
            }
            else if (stadiumHasManager)
            {
                Response.Write("This Stadium Already has a Manager");
            }
            else
            {
                Response.Write("Registration Successful");
                addStadiumManager.Parameters.Add(new SqlParameter("@name", smName));
                addStadiumManager.Parameters.Add(new SqlParameter("@stadium", stadiumName));
                addStadiumManager.Parameters.Add(new SqlParameter("@username", smUsername));
                addStadiumManager.Parameters.Add(new SqlParameter("@password", smPassword));
                addStadiumManager.ExecuteNonQuery();
            }
        }
    }
}