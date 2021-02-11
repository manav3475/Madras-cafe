using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Security.Cryptography;

namespace madras_cafe.User
{
    public partial class update_order_details : System.Web.UI.Page
    {
        string s, t;
        int tot = 0;
        string[] a = new string[6];
        string order_no;
        string tnxid; 
        
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-N2BBETH\SQLEXPRESS;Initial Catalog=madras_cafe;Integrated Security=True");
        private string PreparePOSTForm(string url, System.Collections.Hashtable data)      // post form
        {
            //Set a name for the form
            string formID = "PostForm";
            //Build the form using the specified data to be posted.
            StringBuilder strForm = new StringBuilder();
            strForm.Append("<form id=\"" + formID + "\" name=\"" +
                           formID + "\" action=\"" + url +
                           "\" method=\"POST\">");

            foreach (System.Collections.DictionaryEntry key in data)
            {

                strForm.Append("<input type=\"hidden\" name=\"" + key.Key +
                               "\" value=\"" + key.Value + "\">");
            }


            strForm.Append("</form>");
            //Build the JavaScript which will do the Posting operation.
            StringBuilder strScript = new StringBuilder();
            strScript.Append("<script language='javascript'>");
            strScript.Append("var v" + formID + " = document." +
                             formID + ";");
            strScript.Append("v" + formID + ".submit();");
            strScript.Append("</script>");
            //Return the form and the script concatenated.
            //(The order is important, Form then JavaScript)
            return strForm.ToString() + strScript.ToString();
        }
        string mnum,name;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Random random = new Random();
                txnid.Value = (Convert.ToString(random.Next(10000, 20000)));
                txnid.Value = "MDSCF" + txnid.Value.ToString();
            }

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
                }
                Session["tot"] = tot.ToString();
            }



         
            if (Session["user"] == null)
            {
                Response.Redirect("login.aspx");
            }


            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select * from tbl_user where emailid=@a";
            cmd.Parameters.AddWithValue("@a", Session["user"].ToString());
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            foreach(DataRow dr in dt.Rows)
            {
                txt_name.Text = dr["name"].ToString();
                name = txt_name.Text;
                txt_add.Text = dr["address"].ToString();
                txt_pincode.Text = dr["pincode"].ToString();
                txt_mn.Text = dr["mnumber"].ToString();
                mnum = txt_mn.Text;
            }
            con.Close();
        }

        protected void btn_updateandcontinue_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "update tbl_user set name=@a,address=@b,pincode=@d,mnumber=@e where emailid=@s";
            cmd.Parameters.AddWithValue("@a", txt_name.Text);
            cmd.Parameters.AddWithValue("@b", txt_add.Text);
            cmd.Parameters.AddWithValue("@d",txt_pincode.Text);
            cmd.Parameters.AddWithValue("@e",txt_mn.Text);
            cmd.Parameters.AddWithValue("@s", Session["user"].ToString());
            cmd.ExecuteNonQuery();
            con.Close();

            Session["order_no"] = txnid.Value;

            Double amount = Convert.ToDouble(Session["tot"].ToString());

            String text = key.Value.ToString() + "|" + txnid.Value.ToString() + "|" + amount + "|" + "Madras Cafe Foods" + "|" + name + "|" + Session["user"].ToString() + "|" + "1" + "|" + "1" + "|" + "1" + "|" + "1" + "|" + "1" + "||||||" + salt.Value.ToString();
            //Response.Write(text);
            byte[] message = Encoding.UTF8.GetBytes(text);

            UnicodeEncoding UE = new UnicodeEncoding();
            byte[] hashValue;
            SHA512Managed hashString = new SHA512Managed();
            string hex = "";
            hashValue = hashString.ComputeHash(message);
            foreach (byte x in hashValue)
            {
                hex += String.Format("{0:x2}", x);
            }
            hash.Value = hex;

            System.Collections.Hashtable data = new System.Collections.Hashtable(); // adding values in gash table for data post
            data.Add("hash", hex.ToString());
            data.Add("txnid", txnid.Value);
            data.Add("key", key.Value);
            // string AmountForm = ;// eliminating trailing zeros

            data.Add("amount", amount);
            data.Add("firstname", name);
            data.Add("email", Session["user"].ToString());
            data.Add("phone", mnum);
            data.Add("productinfo", "Madras Cafe Foods");
            data.Add("udf1", "1");
            data.Add("udf2", "1");
            data.Add("udf3", "1");
            data.Add("udf4", "1");
            data.Add("udf5", "1");

            data.Add("surl", "http://localhost:23164/User/payment_success.aspx");
            data.Add("furl", "http://localhost:23164/User/payment_failed.aspx");

            data.Add("service_provider", "");


            string strForm = PreparePOSTForm("https://test.payu.in/_payment", data);
            Page.Controls.Add(new LiteralControl(strForm));
        }
    }
}