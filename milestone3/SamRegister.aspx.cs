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

        }
    }
}