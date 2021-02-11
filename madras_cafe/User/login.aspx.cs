using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;


namespace madras_cafe.User
{
    public partial class login : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-N2BBETH\SQLEXPRESS;Initial Catalog=madras_cafe;Integrated Security=True");
        int i = 0;
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void Submit_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select * from tbl_user where emailid=@a AND password=@b";
            cmd.Parameters.AddWithValue("@a",txt_email.Text);
            cmd.Parameters.AddWithValue("@b",txt_password.Text);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            i = Convert.ToInt32(dt.Rows.Count.ToString());
            if (i > 0)
            {
                if (Session["checkoutbutton"] == "yes")
                {
                    Session["user"] = txt_email.Text;
                    Response.Redirect("update_order_details.aspx");
                }
                else
                {
                    Session["user"] = txt_email.Text;
                    Response.Redirect("order_details.aspx");
                }
            }
            else if (txt_email.Text.Equals("admin@gmail.com") && txt_password.Text.Equals("admin"))  {
                Session["user"] = txt_email.Text;
                Response.Redirect("/Admin/test.aspx");

            }else {
                mess.Text = "Username OR Password Invalid";
            }
            txt_email.Text = "";
            txt_password.Text = "";
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

        }
    }
}