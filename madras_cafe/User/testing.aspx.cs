using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace madras_cafe.User
{
    public partial class testing : System.Web.UI.Page
    {
        string s;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void b1_Click(object sender, EventArgs e)
        {
            try
            {
                s = Convert.ToString(Request.Cookies["cd"].Value);
                string[] strarr = s.Split('.');
                for (int i = 0; i < strarr.Length; i++)
                {
                    Response.Write(strarr[i].ToString());
                    Response.Write("<br>");
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex);
            }
          }
       }
 }

