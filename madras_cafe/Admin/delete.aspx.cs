using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace madras_cafe.Admin
{
    public partial class delete : System.Web.UI.Page
    {
        string category;
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-N2BBETH\SQLEXPRESS;Initial Catalog=madras_cafe;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {
            category=Request.QueryString["category"].ToString();
            if (category == null)
            {
                Response.Redirect("add_Delete_Category.aspx");
            }
            con.Open();
            
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Delete from tbl_product_category where product_category='"+category.ToString()+"'";
            cmd.ExecuteNonQuery();

            SqlCommand cmd1 = con.CreateCommand();
            cmd1.CommandType = CommandType.Text;
            cmd1.CommandText = "Delete from tbl_product where product_category='" + category.ToString() + "'";
            cmd1.ExecuteNonQuery();
            
            con.Close();
            Response.Redirect("add_Delete_Category.aspx");
        }
    }
}