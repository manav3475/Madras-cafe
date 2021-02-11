using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace madras_cafe.User
{
    public partial class payment_failed : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ordervalue.Text = Session["order_no"].ToString();
        }
    }
}