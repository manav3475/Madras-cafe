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
    public partial class book_table : System.Web.UI.Page
    {
        static Int32 bookingid;
        static String startdate;
        static String enddate;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Calendar1.SelectedDate = DateTime.Now.Date;
            }
        }

        protected void btn_btable_Click(object sender, EventArgs e)
        {
            GenerateBookingId();
            String mycon1 = "Data Source=DESKTOP-N2BBETH\\SQLEXPRESS;Initial Catalog=madras_cafe;Integrated Security=True";
            String updatepass = "insert into tbl_booktable(bookingid,tableno,customername,totalperson,dtstart,dtend) values(" + bookingid + ",'" + rdl_selecttable.SelectedItem.Text + "','" + txt_cname.Text + "'," + txt_nop.Text + ",'" + startdate + "','" + enddate + "')";
            SqlConnection con1 = new SqlConnection(mycon1);
            con1.Open();
            SqlCommand cmd1 = new SqlCommand();
            cmd1.CommandText = updatepass;
            cmd1.Connection = con1;
            cmd1.ExecuteNonQuery();
            lbl_booktabelname.Text = bookingid + rdl_selecttable.SelectedItem.Text + "Has Been Booked From " + startdate + " to " + enddate;
        }

        protected void btn_cava_Click(object sender, EventArgs e)
        {
            startdate = Calendar1.SelectedDate.Year + "-" + Calendar1.SelectedDate.Month + "-" + Calendar1.SelectedDate.Day + " " + drp_stime.Text;
            enddate = Calendar1.SelectedDate.Year + "-" + Calendar1.SelectedDate.Month + "-" + Calendar1.SelectedDate.Day + " " + drp_etime.Text;
            Response.Write(startdate);
            findAvailableTable();
            rdl_selecttable.Visible = true;
        }

        private void findAvailableTable()
        {
            try
            {
                String mycon = "Data Source=DESKTOP-N2BBETH\\SQLEXPRESS;Initial Catalog=madras_cafe;Integrated Security=True";
                String myq = "Select DISTINCT tableno from tbl_booktable where ((dtstart between '" + startdate + "' AND '" + enddate + "' ) OR (dtend between '" + startdate + "' AND '" + enddate + "' ))";
                SqlConnection con = new SqlConnection(mycon);
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = myq;
                cmd.Connection = con;
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                DataSet ds = new DataSet();
                da.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    //RadioButtonList1.Items.Clear();
                    Label1.Text = "Available Tables are Given Below";
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        rdl_selecttable.Items.Remove(rdl_selecttable.Items.FindByValue(dr["tableno"].ToString()));
                    }
                    if (rdl_selecttable.Items.Count == 0)
                    {
                        Label1.Text = "No Table Available to Book";
                    }

                }
                else
                {
                    Label1.Text = "Available Tables are Given Below";

                }
                con.Close();

            }
            catch (Exception e)
            {
                Response.Write(e);
            }
        }

        public void GenerateBookingId()
        {


            //String mycon = "Data Source=DESKTOP-N2BBETH\\SQLEXPRESS;Initial Catalog=madras_cafe;Integrated Security=True";
            //String myq = "Select DISTINCT tableno from tbl_booktable where ((dtstart between '" + startdate + "' AND '" + enddate + "' ) OR (dtend between '" + startdate + "' AND '" + enddate + "' ))";
            //SqlConnection con = new SqlConnection(mycon);
            //SqlCommand cmd = new SqlCommand();
            //cmd.CommandText = myq;
            //cmd.Connection = con;
            //SqlDataAdapter da = new SqlDataAdapter();
            //da.SelectCommand = cmd;
            //DataSet ds = new DataSet();
            //da.Fill(ds);


            String mycon = "Data Source=DESKTOP-N2BBETH\\SQLEXPRESS;Initial Catalog=madras_cafe;Integrated Security=True";
            SqlConnection scon = new SqlConnection(mycon);
            String myquery = "select bookingid from tbl_booktable";
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = myquery;
            cmd.Connection = scon;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataSet ds = new DataSet();
//            scon.Open();
            da.Fill(ds);
  //          scon.Close();
            if (ds.Tables[0].Rows.Count < 1)
            {
                bookingid = 50001;

            }
            else
            {


                String mycon1 = "Data Source=DESKTOP-N2BBETH\\SQLEXPRESS;Initial Catalog=madras_cafe;Integrated Security=True";
                String myquery1 = "Select max(bookingid) from tbl_booktable";
                SqlConnection scon1 = new SqlConnection(mycon1);
                SqlCommand cmd1 = new SqlCommand();
                cmd1.CommandText = myquery1;
                cmd1.Connection = scon1;
                SqlDataAdapter da1 = new SqlDataAdapter();
                da1.SelectCommand = cmd1;
                DataSet ds1 = new DataSet();
                da1.Fill(ds1);


                bookingid = Convert.ToInt32(ds1.Tables[0].Rows[0][0].ToString());

                bookingid = bookingid + 1;
                scon1.Close();
            }
        }


    }
}