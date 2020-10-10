using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace S.S.B_E_Mailing_System
{
    public partial class EmailInfo : Form
    {
        public EmailInfo()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-IVV8MT7;Initial Catalog=SSBEMail;Integrated Security=True");

        private void EmailInfo_Load(object sender, EventArgs e)
        {
            fillcombo1();
        }

        private void fillcombo1()
        {
            con.Open();
            SqlCommand cmd1 = new SqlCommand("Select Order_No from EmailInfo", con);
            SqlDataAdapter sdr = new SqlDataAdapter(cmd1);
            DataTable dt1 = new DataTable();
            sdr.Fill(dt1);
            comboBox1.DisplayMember = "Order_No";
            comboBox1.DataSource = dt1;
            comboBox1.AutoCompleteMode = AutoCompleteMode.Suggest;
            comboBox1.AutoCompleteSource = AutoCompleteSource.ListItems;
            con.Close();
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            filldatagrid();
            getdate();
            filldatagrid1();
        }

        private void getdate()
        {
            if (con.State != ConnectionState.Closed)
            {
                con.Close();
            }
            con.Open();
            SqlCommand cmd4 = new SqlCommand("Select Date from EmailInfo1 where Order_No = @n", con);
            cmd4.Parameters.AddWithValue("@n", comboBox1.Text);
             SqlDataReader drdate = cmd4.ExecuteReader();
             while (drdate.Read())
             {
                 bunifuCustomLabel4.Text = drdate.GetValue(0).ToString();
             }
        }

        private void filldatagrid1()
        {
            if (con.State != ConnectionState.Closed)
            {
                con.Close();
            }
            con.Open();
            SqlCommand cmd = new SqlCommand("select Item_Name,Qty,Price from EmailInfo1 where Order_No = @n", con);
            cmd.Parameters.AddWithValue("@n", comboBox1.Text);
            SqlDataAdapter sdr = new SqlDataAdapter(cmd);
            DataTable dt1 = new DataTable();
            sdr.Fill(dt1);
            bunifuCustomDataGrid1.DataSource = dt1;
        }

        private void filldatagrid()
        {
            try
            {
                if (con.State != ConnectionState.Closed)
                {
                    con.Close();
                }
                con.Open();
                SqlCommand cmd = new SqlCommand("Select Supplier_Name from EmailInfo where Order_No = @n", con);
                cmd.Parameters.AddWithValue("@n", comboBox1.Text);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bunifuMaterialTextbox1.Text = dr.GetValue(0).ToString();
                }
                con.Close();
            }
            catch
            {
                throw;
            }
        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
