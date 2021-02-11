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
    public partial class delete_cart : System.Web.UI.Page
    {
        string s, t;
        string[] a = new string[6];
        int id,count=0,product_id,qty2;
        string name, qty, image, desc, price;
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-N2BBETH\SQLEXPRESS;Initial Catalog=madras_cafe;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {
                id = Convert.ToInt32(Request.QueryString["id"].ToString());
                DataTable dt = new DataTable();
                dt.Rows.Clear();
                dt.Columns.AddRange(new DataColumn[7] { new DataColumn("name"), new DataColumn("desc"), new DataColumn("price"), new DataColumn("qty"), new DataColumn("image"), new DataColumn("id"), new DataColumn("product_id") });

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
                        dt.Rows.Add(a[0].ToString(), a[1].ToString(), a[2].ToString(), a[3].ToString(), a[4].ToString(), i.ToString(),a[5].ToString());
                    }
                }



                count = 0;
                foreach (DataRow dr in dt.Rows)
                {
                    if (count == id)
                    {
                        product_id = Convert.ToInt32(dr["product_id"].ToString());
                        qty2 = Convert.ToInt32(dr["qty"].ToString());
                    }
                    count += 1;
                }

                count = 0;
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update tbl_product set product_qty=product_qty+"+qty2+"where product_id="+product_id;
                cmd.ExecuteNonQuery();
                con.Close();


                dt.Rows.RemoveAt(id);
                Response.Cookies["cd"].Expires = DateTime.Now.AddDays(-1);
                foreach (DataRow dr in dt.Rows)
                {
                    name = dr["name"].ToString();
                    desc = dr["desc"].ToString();
                    price = dr["price"].ToString();
                    qty = dr["qty"].ToString();
                    image = dr["image"].ToString();
                    product_id=Convert.ToInt32(dr["product_id"].ToString());

                    count += 1;

                    if (count == 1)
                    {
                        Response.Cookies["cd"].Value = name.ToString() + "," + desc.ToString() + "," + price.ToString() + "," + qty.ToString() + "," + image.ToString()+","+product_id.ToString();
                        Response.Cookies["cd"].Expires = DateTime.Now.AddDays(1);
                    }
                    else
                    {

                        Response.Cookies["cd"].Value = Request.Cookies["cd"].Value + "|" + name.ToString() + "," + desc.ToString() + "," + price.ToString() + "," + qty.ToString() + "," + image.ToString() + "," + product_id.ToString();
                        Response.Cookies["cd"].Expires = DateTime.Now.AddDays(1);
                    }
                }
                Response.Redirect("view_cart.aspx");
           
        }
    }
}