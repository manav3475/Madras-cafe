using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Net;

namespace madras_cafe.User
{
    public partial class registration : System.Web.UI.Page
    {
       SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-N2BBETH\SQLEXPRESS;Initial Catalog=madras_cafe;Integrated Security=True");

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void submit_Click(object sender, EventArgs e)
        {
            if (cpass.Text != password.Text)
            {
                Response.Write("<script>alert('Password AND Confirm Password Not Match')</script>");
                return;
            }
           
            con.Open();
            String pass = password.Text; 
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into tbl_user values(@a,@b,@c,@d,@e,@f,@g)";
            cmd.Parameters.AddWithValue("@a",uname.Text);
            cmd.Parameters.AddWithValue("@b",ucity.Text);
            cmd.Parameters.AddWithValue("@c",uadd.Text);
            cmd.Parameters.AddWithValue("@d",uemail.Text);
            cmd.Parameters.AddWithValue("@e",upin.Text);
            cmd.Parameters.AddWithValue("@f",mnumber.Text);
            cmd.Parameters.AddWithValue("@g",password.Text);
            cmd.ExecuteNonQuery();
            con.Close();

            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.Credentials = new System.Net.NetworkCredential("17bmiit032@gmail.com","Man011299");
            smtp.EnableSsl=true;
            MailMessage msg = new MailMessage();
            msg.Subject = "Registration Confirmation";
            string m = "hii Welcome us "+uname.Text+" , Thanks For Registration at Madras Cafe\n"
                        +"Your Email Address " +uemail.Text+ " Was Confirmed To Madras Cafe\n"
                        +"We Will Provide You The Latest Update\n"
                        +"Thanking you";
            msg.Body = m;
            string add = uemail.Text;
            msg.To.Add(add);
            string formaddd = "Madras Cafe <17bmiit032@gmail.com>";
            msg.From = new MailAddress(formaddd);
            try
            {
                smtp.Send(msg);
                Response.Write("<script>alert('Registration Sccessfull...')</script>");
                uname.Text = "";
                uadd.Text = "";
                uemail.Text = "";
                upin.Text = "";
                mnumber.Text = "";
                password.Text = "";
                cpass.Text = "";
            }
            catch (Exception ex) {
                Response.Write(ex);
            }


            Response.Redirect("login.aspx");            

        }
    }
}