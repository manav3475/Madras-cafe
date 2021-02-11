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
    public partial class display_product : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-N2BBETH\SQLEXPRESS;Initial Catalog=madras_cafe;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;

            if (Request.QueryString["category"] == null)
            {
                cmd.CommandText = "Select * from tbl_product";
            }
            else {
                cmd.CommandText = "Select * from tbl_product where product_category='" + Request.QueryString["category"].ToString() + "'";
            }


            if (Request.QueryString["category"] == null && Request.QueryString["search"] != null)
            {
                cmd.CommandText = "Select * from tbl_product where product_name like('%" + Request.QueryString["search"].ToString() + "%')";
            }

            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            d1.DataSource = dt;
            d1.DataBind();
            con.Close();
        }
    }
}