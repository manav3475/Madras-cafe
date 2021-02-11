using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Web.Security;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;


namespace madras_cafe.User
{
    public partial class GenPDF : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-N2BBETH\SQLEXPRESS;Initial Catalog=madras_cafe;Integrated Security=True");
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter da;
        DataTable dt;
        protected void Page_Load(object sender, EventArgs e)
        {   
            string id =Request.QueryString["id"].ToString();
            //string q = "Select * from tbl_order where emailid='" + Session["user"].ToString() + "'";
            //cmd = new SqlCommand(q, con);
            //da = new SqlDataAdapter(cmd);
            //dt = new DataTable();
            //da.Fill(dt);
            //gvReport.DataSource = dt;
            //gvReport.DataBind();
            //lblDataTitle.Text = Session["user"].ToString(); 

            string q = "Select id as ID,name as NAME,city as CITY,address as ADDRESS,emailid as EMAIL_ID,pincode as PINCODE,mnumber as MOBILE_NUMBER from tbl_order where id='" + id + "'";
            cmd = new SqlCommand(q, con);
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            gvReport.DataSource = dt;
            gvReport.DataBind();

            string q1 = "Select id as ID,order_id as ORDER_NUMBER,product_name as NAME,product_price as PRICE,product_qty as QUANTITY from tbl_order_details where order_id='" + id + "'";
            cmd = new SqlCommand(q1, con);
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            gvReport1.DataSource = dt;
            gvReport1.DataBind();





            int tot=0;
            String q5= "Select * from tbl_order_details where order_id='"+id+"'";
            cmd = new SqlCommand(q5,con);
            con.Open();
            cmd.ExecuteNonQuery();
             dt = new DataTable();
             da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                tot += Convert.ToInt32(dr["product_price"].ToString()) * Convert.ToInt32(dr["product_qty"].ToString());
            }
            lblTotal.Text = tot.ToString();
            con.Close();
            lblDate.Text = DateTime.Now.ToString();
            lblDataTitle.Text = "ORDER INVOICE";

            //SqlDataReader dr;
            //cmd = new SqlCommand("select COUNT(*) as count from tbl_order; ", con);
            //con.Open();
            //dr = cmd.ExecuteReader();
            //if (dr.Read())
            //{
            //    lblTotal.Text = " Total Order:" + dr["count"].ToString();
            //}
            //con.Close();
            //lblDate.Text = DateTime.Now.ToString();
            //lblDataTitle.Text = "Total Order";



            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=Order.pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            Panel1.RenderControl(hw);
            StringReader sr = new StringReader(sw.ToString());
            Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 100f, 0f);
            HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
            PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
            pdfDoc.Open();
            htmlparser.Parse(sr);
            pdfDoc.Close();
            Response.Write(pdfDoc);
            Response.End();



           
        }
 
    }
}