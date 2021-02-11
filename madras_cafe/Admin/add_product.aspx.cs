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
    public partial class add_product : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-N2BBETH\SQLEXPRESS;Initial Catalog=madras_cafe;Integrated Security=True");
        String a, b;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;
            sc.Items.Clear();
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select * from tbl_product_category";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                sc.Items.Add(dr["product_category"].ToString());
            }
            con.Close();

        }
        public static string GetRandomPassword(int length)
         {
            char[] chars = "abcdefghijklmnopqrstuvwxyz1234567890ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
            string password = string.Empty;
            Random random = new Random();


            for (int i = 0; i < length; i++)
            {
            int x = random.Next(1, chars.Length);
            //For avoiding Repetation of Characters
            if (!password.Contains(chars.GetValue(x).ToString()))
            password += chars.GetValue(x);
            else
            i=i-1;
            }
            return password;
        }

        protected void b1_Click(object sender, EventArgs e)
        {
            a = add_product.GetRandomPassword(10).ToString();
            b = "./images/" + a + fu_pim.FileName.ToString();
            fu_pim.SaveAs(Request.PhysicalApplicationPath + "./images/" + a + fu_pim.FileName.ToString());

            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into tbl_product values(@a,@b,@c,@d,@e,@f)";
            cmd.Parameters.AddWithValue("@a",txt_pn.Text);
            cmd.Parameters.AddWithValue("@b", txt_pd.Text);
            cmd.Parameters.AddWithValue("@c", txt_pp.Text);
            cmd.Parameters.AddWithValue("@d", txt_pqty.Text);
            cmd.Parameters.AddWithValue("@e", b);
            cmd.Parameters.AddWithValue("@f", sc.SelectedItem.ToString());
            txt_pn.Text = "";
            txt_pd.Text = "";
            txt_pp.Text = "";
            txt_pqty.Text = "";
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            Response.Write("<script>alert('Product Are Save')</script>");
        }
    }
}