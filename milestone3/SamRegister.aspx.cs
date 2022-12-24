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
    public partial class SamRegister : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void samReg(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["Milestone2#1"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            String samName = samNameTxt.Text;
            String samUsername = samUsernameTxt.Text;
            String samPassword = samPasswordTxt.Text;
            String[] inputs = {samName, samUsername, samPassword};

            conn.Open();
            SqlCommand addAssociationManager = new SqlCommand("addAssociationManager", conn);
            addAssociationManager.CommandType = System.Data.CommandType.StoredProcedure;

            bool emptyField = false;
            bool userExists = false;

            SqlCommand samUsernames = new SqlCommand("select username from System_users", conn);

            for (int i = 0; i < inputs.Length; i++)
            {
                if (string.IsNullOrWhiteSpace(inputs[i]))
                {
                    emptyField = true;
                }
            }

            SqlDataReader sUsernameReader = samUsernames.ExecuteReader();
            while (sUsernameReader.Read())
            {
                if (sUsernameReader["username"].ToString() == samUsername)
                {
                    userExists = true;
                }
            }
            sUsernameReader.Close();

            if (userExists) { Response.Write("This username is in use, enter another username"); }
            else if (emptyField)
            {
                Response.Write("Make Sure to Fill All Fields");
            }
            else
            {
                Response.Write("Registration Successful");
                addAssociationManager.Parameters.Add(new SqlParameter("@name", samName));
                addAssociationManager.Parameters.Add(new SqlParameter("@username", samUsername));
                addAssociationManager.Parameters.Add(new SqlParameter("@password", samPassword));
                addAssociationManager.ExecuteNonQuery();
            }

        }
    }
}