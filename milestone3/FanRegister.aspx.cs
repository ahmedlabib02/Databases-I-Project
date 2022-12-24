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
    public partial class FanRegister : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void fanReg(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["Milestone2#1"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            String fName = fanNameTxt.Text;
            String fUsername = fanUsernameTxt.Text;
            String fPassword = fanPassTxt.Text;
            String fNatID = nationalIdTxt.Text;
            String fDOB = Calendar1.SelectedDate.ToString("yyyy/MM/dd");
            String fAddress = addressTxt.Text;
            String fPhoneNo = phoneNumberTxt.Text;
            String[] inputs = { fName, fUsername, fPassword, fNatID, fDOB, fAddress, fPhoneNo };
            
            conn.Open();
            SqlCommand addFan = new SqlCommand("addFan", conn);
            addFan.CommandType = System.Data.CommandType.StoredProcedure;
            
            bool emptyField = false;
            bool userExists = false;
            bool natIDExists = false;
            bool isNumber = int.TryParse(fPhoneNo, out int n);

            SqlCommand fanUsernames = new SqlCommand("select username from System_users", conn);
            SqlCommand fanNatIDs = new SqlCommand("select National_Id from Fan", conn);



            for (int i=0;i<inputs.Length;i++)
                {
                if (string.IsNullOrWhiteSpace(inputs[i]))
                    {
                    emptyField = true;
                    }
                if (i == 4)
                    {
                    if (inputs[i] == "0001/01/01") { emptyField = true; }
                    }
                }

            SqlDataReader fUsernameReader = fanUsernames.ExecuteReader();
            while(fUsernameReader.Read())
                {
                if (fUsernameReader["username"].ToString() == fUsername)
                    {
                    userExists = true;
                    }
                }
            fUsernameReader.Close();

            SqlDataReader fNatIDReader = fanNatIDs.ExecuteReader();
            while(fNatIDReader.Read())
                {
                if (fNatIDReader["National_Id"].ToString() == fNatID)
                    {
                    natIDExists = true;
                    }
                }
            fNatIDReader.Close();


            if (userExists) { Response.Write("This username is in use, enter another username"); }
            else if (emptyField)
            {
                Response.Write("Make Sure to Fill All Fields");
            }
            else if (natIDExists)
            {
                Response.Write("This national ID is already registered, enter another National ID");
            }
            else if (!isNumber)
            {
                Response.Write("Enter a valid phone number");
            }
            else
            {
                Response.Write("Registration Successful");
                addFan.Parameters.Add(new SqlParameter("@name", fName));
                addFan.Parameters.Add(new SqlParameter("@username", fUsername));
                addFan.Parameters.Add(new SqlParameter("@password", fPassword));
                addFan.Parameters.Add(new SqlParameter("@national", fNatID));
                addFan.Parameters.Add(new SqlParameter("@birth", fDOB));
                addFan.Parameters.Add(new SqlParameter("@address", fAddress));
                addFan.Parameters.Add(new SqlParameter("@phone", fPhoneNo));
                addFan.ExecuteNonQuery();
            }
        }
    }
}