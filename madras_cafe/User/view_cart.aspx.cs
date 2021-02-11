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
    public partial class view_cart : System.Web.UI.Page
    {
        string s,t;
        int tot = 0;
        string[] a = new string[6];
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                dt.Columns.AddRange(new DataColumn[7] { new DataColumn("name"), new DataColumn("desc"), new DataColumn("price"), new DataColumn("qty"), new DataColumn("image"), new DataColumn("id"),new DataColumn("product_id")  });
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
                        dt.Rows.Add(a[0].ToString(), a[1].ToString(), a[2].ToString(), a[3].ToString(), a[4].ToString(), i.ToString(), a[5].ToString());
                        tot+=(Convert.ToInt32(a[2].ToString()) * Convert.ToInt32(a[3].ToString()));
                    }
                }   
                d1.DataSource = dt;
                d1.DataBind();

                if (tot == 0)
                {
                    mess.Visible = false;
                    btn_checkout.Visible = false;
                }
                else
                {
                    mess.Text = "TOTAL AMOUNT TO PAY:-"+tot.ToString();
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex);
            }

        }

        protected void btn_checkout_Click(object sender, EventArgs e)
        {
            Session["checkoutbutton"] = "yes";
            Response.Redirect("checkout.aspx");
        }
    }
}