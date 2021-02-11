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
    public partial class view_full_order : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-N2BBETH\SQLEXPRESS;Initial Catalog=madras_cafe;Integrated Security=True");
        String id;
        int tot = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
         
            if (Session["user"] == null)
            {
                Response.Redirect("login.aspx");
            }


            id = Request.QueryString["id"].ToString();
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select * from tbl_order_details where order_id=@a";
            cmd.Parameters.AddWithValue("@a", id);
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                tot += Convert.ToInt32(dr["product_price"].ToString()) * Convert.ToInt32(dr["product_qty"].ToString());
            }
            r1.DataSource = dt;
            r1.DataBind();
            con.Close();
            l1.Text = "TOTAL AMOUNT=" + tot.ToString();
        }
    }
}