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
    public partial class product_desc : System.Web.UI.Page
    {
        string name, qty, images, desc, price;
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-N2BBETH\SQLEXPRESS;Initial Catalog=madras_cafe;Integrated Security=True");
        int id, q1;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] == null)
            {
                Response.Redirect("display_product.aspx");
            }
            else
            {
                id = Convert.ToInt32(Request.QueryString["id"].ToString());
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Select * from tbl_product where product_id=" + id + "";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                d1.DataSource = dt;
                d1.DataBind();
                con.Close();
            }

            q1 = get_qty(id);
            if (q1 == 0)
            {
                qty1.Visible = false;
                enq.Visible = false;
                b1.Visible = false;
                l1.Text="This Product Have Not Available in Stock";
            }
        }

        protected void b1_Click(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select * from tbl_product where product_id=" + id + "";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                name = dr["product_name"].ToString();
                desc = dr["product_desc"].ToString();
                price = dr["product_price"].ToString();
                qty = dr["product_qty"].ToString();
                images = dr["product_images"].ToString();
            }

            if (qty1.Text == "")
            {
                l1.Text = "Please Enter Quntity";
            }
            else if (Convert.ToInt32(qty1.Text) <= 0)
            {
                
                l1.Text = "This Formate is Not Valid";
            }
            else if (Convert.ToInt32(qty1.Text) > Convert.ToInt32(qty))
            {
                l1.Text = "This Quantity is not Avalibale";
            }
            else
            {
                l1.Text = "";
                if (Request.Cookies["cd"] == null)
                {
                    Response.Cookies["cd"].Value = name.ToString() + "," + desc.ToString() + "," + price.ToString() + "," + qty1.Text.ToString() + "," + images.ToString() + "," + id.ToString();
                    Response.Cookies["cd"].Expires = DateTime.Now.AddDays(1);
                }
                else
                {
                    Response.Cookies["cd"].Value = Request.Cookies["cd"].Value + "|" + name.ToString() + "," + desc.ToString() + "," + price.ToString() + "," + qty1.Text.ToString() + "," + images.ToString() + "," + id.ToString();
                    Response.Cookies["cd"].Expires = DateTime.Now.AddDays(1);
                }

                SqlCommand cmd1 = con.CreateCommand();
                cmd1.CommandType = CommandType.Text;
                cmd1.CommandText = "update tbl_product set product_qty=product_qty-" + qty1.Text + "where product_id=" + id;
                cmd1.ExecuteNonQuery();
                Response.Redirect("product_desc.aspx?id=" + id.ToString());
            }

        }

        public int get_qty(int id)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select * from tbl_product where product_id=" + id + "";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                q1 = Convert.ToInt32(dr["product_qty"].ToString());
            }
            return q1;
        }
    }
}