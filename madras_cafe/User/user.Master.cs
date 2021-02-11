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
    public partial class user : System.Web.UI.MasterPage
    {
        string s, t;
        int tot = 0;
        int totcount = 0;
        string[] a = new string[6];
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-N2BBETH\SQLEXPRESS;Initial Catalog=madras_cafe;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select * from tbl_product_category";
            con.Open();
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            pc.DataSource = dt;
            pc.DataBind();
            con.Close();


            if (Request.Cookies["cd"] != null)
            {
                s = Convert.ToString(Request.Cookies["cd"].Value);
                string[] strarr = s.Split('|');
                for (int i = 0; i < strarr.Length; i++)
                {
                    t = strarr[i].ToString();
                    string[] strarr1 = t.Split(',');
                    for (int j = 0; j < strarr1.Length; j++)
                    {
                        a[j] = strarr1[j].ToString();
                    }
                    tot += (Convert.ToInt32(a[2].ToString()) * Convert.ToInt32(a[3].ToString()));
                    totcount += 1;
                }
                counttoitem.Text = totcount.ToString();
                counttoprice.Text = tot.ToString();
            }   
        }
    }
}