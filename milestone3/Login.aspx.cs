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
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            
        }

        protected void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        protected void login(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["Milestone2#1"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            String username = t1.Text;
            String password = t2.Text;
            SqlCommand finduser = new SqlCommand("findUser",conn);
            finduser.CommandType = System.Data.CommandType.StoredProcedure;
            finduser.Parameters.Add(new SqlParameter("@username", username));
            finduser.Parameters.Add(new SqlParameter("@password", password));
            conn.Open();
            SqlDataReader finduserReader = finduser.ExecuteReader();
            Boolean flag = false;
            

            while (finduserReader.Read())
            {
                
               if (finduserReader["username"] != null && finduserReader["password"] != null)
                {
                    flag = true;

                }
                      }
            finduserReader.Close();

            if (!flag)
                Response.Write("Either username or password are not valid");
            else
            {
                String allassoc = "select username from allassocManagers";
                String allfans = "select username from allFans";
                String allcr = "select username from allClubRepresentatives";
                String allsm = "select username from allStadiumManagers";
                String allsa = "select username from System_admin";
                SqlCommand assoc = new SqlCommand(allassoc, conn);
                SqlCommand fan = new SqlCommand(allfans, conn);
                SqlCommand cr = new SqlCommand(allcr, conn);
                SqlCommand sm = new SqlCommand(allsm, conn);
                SqlCommand sa = new SqlCommand(allsa, conn);
                SqlDataReader assocReader = assoc.ExecuteReader();
                while (assocReader.Read())
                {
                    if (assocReader["username"].ToString() == username) { 
                    Response.Write("association");
                    Response.Redirect("Sports_Association.aspx");
                }
                }
                assocReader.Close();
                SqlDataReader fanReader = fan.ExecuteReader();
                while (fanReader.Read())
                {
                    if (fanReader["username"].ToString() == username) { 
                    Response.Write("fan");
                    Response.Redirect("Fans.aspx");
                }
                }
                fanReader.Close();
                SqlDataReader crReader = cr.ExecuteReader();
                while (crReader.Read())
                {
                    if (crReader["username"].ToString() == username)
                    {
                        Response.Write("cr");
                        Response.Redirect("Club_representative.aspx");
                    }
                }
                crReader.Close();
                SqlDataReader smReader = sm.ExecuteReader();
                while (smReader.Read())
                {
                    if (smReader["username"].ToString() == username)
                    {
                        Response.Write("sm");
                        Response.Redirect("Stadium_Manager.aspx");
                    }
                }
                smReader.Close();
                SqlDataReader saReader = sa.ExecuteReader();
                while (saReader.Read())
                {
                    if (saReader["username"].ToString() == username)
                    {
                        Response.Write("sm");
                        Response.Redirect("System_admin.aspx");
                    }
                }
                smReader.Close();



            }
            


        }


        protected void fanRegister(object sender, EventArgs e)
        {   
            Response.Redirect("FanRegister.aspx");
        }

        protected void samRegister(object sender, EventArgs e)
        {
            Response.Redirect("SamRegister.aspx");
        }

        protected void stadmanagerRegister(object sender, EventArgs e)
        {
            Response.Redirect("StadManagerRegister.aspx");
        }

        protected void clubrepRegister(object sender, EventArgs e)
        {
            Response.Redirect("ClubRepRegister.aspx");
        }
        

    }
}