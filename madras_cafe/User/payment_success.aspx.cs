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
    public partial class payment_success : System.Web.UI.Page
    {
        string orderid;
        string s, t;
        int tot = 0;
        string[] a = new string[6];
        string order_id;
        string order="";
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-N2BBETH\SQLEXPRESS;Initial Catalog=madras_cafe;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {
            con.Open();
            if (Session["order_no"]==null)
            {
                Response.Redirect("login.aspx");
            }
            else
            {
                //this is for getting user details and storing it on order table
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Select * from tbl_user where emailid='" + Session["user"].ToString() + "'";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    SqlCommand cmd1 = con.CreateCommand();
                    cmd1.CommandType = CommandType.Text;
                    cmd1.CommandText = "insert into tbl_order values('" + Session["order_no"].ToString() + "','" + dr["name"].ToString() + "','" + dr["city"].ToString() + "','" + dr["address"].ToString() + "','" + dr["emailid"].ToString() + "','" + dr["pincode"].ToString() + "','" + dr["mnumber"].ToString() + "')";
                    cmd1.ExecuteNonQuery();
                }
                //end storing user details

                //now we are going to get order id from order table and using this order id insert record into order_details table
                SqlCommand cmd2 = con.CreateCommand();
                cmd2.CommandType = CommandType.Text;
                cmd2.CommandText = "Select * from tbl_order where id='" + Session["order_no"].ToString() + "' order by id desc";
                cmd2.ExecuteNonQuery();
                DataTable dt2 = new DataTable();
                SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
                da2.Fill(dt2);
                foreach (DataRow dr2 in dt2.Rows)
                {
                    order_id = dr2["id"].ToString();
                }
                //ending from getting order id

                //this from getting order items from cookies

                if (Request.Cookies["cd"] != null)
                {
                    s = Convert.ToString(Request.Cookies["cd"].Value);
                    string[] strarr = s.Split('|');
                    for (int i = 0; i < strarr.Length; i++)
                    {
                        t = Convert.ToString(strarr[i].ToString());
                        string[] strarr1 = t.Split(',');
                        for (int j = 0; j < strarr1.Length; j++)
                        {
                            a[j] = strarr1[j].ToString();
                        }
                        SqlCommand cmd3 = con.CreateCommand();
                        cmd3.CommandType = CommandType.Text;
                        cmd3.CommandText = "insert into tbl_order_details values('" + order_id.ToString() + "','" + a[0].ToString() + "','" + a[2].ToString() + "','" + a[3].ToString() + "','" + a[4].ToString() + "')";
                        cmd3.ExecuteNonQuery();
                    }

                }

                //end getting item from cookies

            }

            con.Close();

            Session["user"] = "";
            Response.Cookies["cd"].Expires = DateTime.Now.AddDays(-1);
            Response.Cookies["cd"].Expires = DateTime.Now.AddDays(-1);


            ordervalue.Text = Session["order_no"].ToString();
        }
    }
}