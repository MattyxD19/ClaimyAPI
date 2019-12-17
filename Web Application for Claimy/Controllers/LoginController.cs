using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using Web_Application_for_Claimy.Model;

namespace Web_Application_for_Claimy.Controllers
{
    public class LoginController : ApiController
    {
        public ClaimyModel db = new ClaimyModel();

        [ResponseType(typeof(tbl_Customer))]
        public bool AuthenticateLogin(AuthenticateModel authenticate)
        {
           

            SqlConnection sqlCon = new SqlConnection(@"data source=LAPTOP-EIELNEF8\CSDBSERVER;initial catalog=DB_Claimy;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework");
            bool returnValue = false;


            string sqlquery = "SELECT * FROM tbl_Customer WHERE fld_Email = '" + authenticate.Email  + "'";

            SqlDataAdapter sda = new SqlDataAdapter(sqlquery, sqlCon);
            DataTable dtbl = new DataTable();
            sda.Fill(dtbl);


            if (dtbl.Rows.Count == 1)
            {
                string savedPassword = dtbl.Rows[0][4].ToString();
                Console.WriteLine(savedPassword + "SAVED PASSWORD!!");
               

                //savedPassword = savedPassword.Replace(" ", "+");
                //int mod4 = savedPassword.Length % 4;
                //if (mod4 > 0)
                //{
                //    savedPassword += new string('=', 4 - mod4);
                //}

                //byte[] hashBytes = Convert.FromBase64String(savedPassword.Replace("","+"));
                //byte[] salt = new byte[13];

                

                //Array.Copy(hashBytes, 0, salt, 0, 13);

                //var pbkdf2 = new Rfc2898DeriveBytes(authenticate.Password, salt, 10000);
                //byte[] hash = pbkdf2.GetBytes(20);


                if (savedPassword.Equals(authenticate.Password))
                {
                    return true;
                    
                }

                //if (ok == 1)
                //{
                //    returnValue = true;
                //    Console.WriteLine("login succes");
                //}
                //else
                //{
                //    Console.WriteLine("failed login");
                //}

            }

            return returnValue;
        }
    }
}