using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace S.S.B_E_Mailing_System
{
    public partial class ModiItem : Form
    {
        public ModiItem()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-IVV8MT7;Initial Catalog=SSBEMail;Integrated Security=True");

        private void ModiItem_Load(object sender, EventArgs e)
        {
            flowLayoutPanel1.Visible = false;
            fillcombo1();
        }

        private void fillcombo1()
        {
            con.Open();
            SqlCommand cmd1 = new SqlCommand("Select Itme_Name from Item", con);
            SqlDataAdapter sdr = new SqlDataAdapter(cmd1);
            DataTable dt1 = new DataTable();
            sdr.Fill(dt1);
            dataGridViewComboBoxEditingControl1.DisplayMember = "Itme_Name";
            dataGridViewComboBoxEditingControl1.DataSource = dt1;
            dataGridViewComboBoxEditingControl1.AutoCompleteMode = AutoCompleteMode.Suggest;
            dataGridViewComboBoxEditingControl1.AutoCompleteSource = AutoCompleteSource.ListItems;
            con.Close();
            if (dataGridViewComboBoxEditingControl1.Text == "")
            {
                button1.Enabled = false;
            }
            else
            {
                button1.Enabled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.Visible = true;
            fill_oothers();
            bunifuGradientPanel1.Visible = false;
        }

        private void fill_oothers()
        {
            if (con.State != ConnectionState.Closed)
            {
                con.Close();
            }
            con.Open();
            SqlCommand get = new SqlCommand("SELECT Itme_Name,HSN,CD,Supplier_Name,Packaging,Pur_P from Item where Itme_Name = @n", con);
            get.Parameters.AddWithValue("@n", dataGridViewComboBoxEditingControl1.Text);
            SqlDataReader drget = get.ExecuteReader();
            while (drget.Read())
            {
                bunifuMetroTextbox1.Text = drget.GetValue(0).ToString();
                bunifuMetroTextbox2.Text = drget.GetValue(1).ToString();
                bunifuMetroTextbox3.Text = drget.GetValue(2).ToString();
                bunifuMaterialTextbox1.Text = drget.GetValue(3).ToString();
                bunifuMetroTextbox6.Text = drget.GetValue(4).ToString();
                bunifuMetroTextbox5.Text = drget.GetValue(5).ToString();
            }
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            clearcont();
            bunifuGradientPanel1.Visible = true;
            flowLayoutPanel1.Visible = false;
        }

        private void clearcont()
        {
            bunifuMetroTextbox1.Text = "";
            bunifuMetroTextbox2.Text ="";
            bunifuMetroTextbox3.Text ="";
            bunifuMaterialTextbox1.Text ="";
            bunifuMetroTextbox6.Text = "";
            bunifuMetroTextbox5.Text = "";
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            try
            {
                if (con.State != ConnectionState.Closed)
                {
                    con.Close();
                }
                con.Open();
                SqlCommand cmd3 = new SqlCommand("update Item set PUR_P = @p, Packaging = @pa where Itme_Name = @n", con);
                cmd3.Parameters.AddWithValue("@n", bunifuMetroTextbox1.Text);
                cmd3.Parameters.AddWithValue("@p", Convert.ToDecimal(bunifuMetroTextbox5.Text));
                cmd3.Parameters.AddWithValue("@pa", bunifuMetroTextbox6.Text);
                cmd3.ExecuteNonQuery();
                MessageBox.Show("Record Updated Successfully.........");
            }
            catch
            {
                throw;
            }
            clearcont();
            flowLayoutPanel1.Visible = false;
            bunifuGradientPanel1.Visible = true;
        }

        private void bunifuMetroTextbox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            string pattern = @"^[1-9]\d*(\.\d+)?$";
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            else if (Regex.IsMatch(bunifuMetroTextbox5.Text, pattern))
            {
                errorProvider1.Clear();
                bunifuThinButton21.Enabled = true;
            }
            else
            {
                errorProvider1.SetError(this.bunifuMetroTextbox5, "Please Input the Correct pattern");
                bunifuThinButton21.Enabled = false;
            }
        }
    }
}
