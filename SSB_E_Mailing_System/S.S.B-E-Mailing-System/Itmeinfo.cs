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
    public partial class Itmeinfo : Form
    {
        public Itmeinfo()
        {
            InitializeComponent();
        }

        public string g;
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-IVV8MT7;Initial Catalog=SSBEMail;Integrated Security=True");

        private void button1_Click(object sender, EventArgs e)
        {
            Claer();
            Hide();
        }

        private void Claer()
        {
            bunifuMetroTextbox1.Text = "";
            bunifuMetroTextbox2.Text = "";
            bunifuMetroTextbox3.Text = "";
            comboBox1.Text = "";
            bunifuMetroTextbox5.Text = "";
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            check();
            put_data();
            Claer();
        }

        public void check()
        {
            if (bunifuMetroTextbox1.Text == "")
            {
                errorProvider1.SetError(bunifuMetroTextbox1, "Please Enter the Item_Name");
                bunifuThinButton21.Enabled = false;
            }
            else if (bunifuMetroTextbox2.Text == "")
            {
                errorProvider1.SetError(bunifuMetroTextbox2, "Please Enter the HSN/ITEM _ CODE");
                bunifuThinButton21.Enabled = false;
            }
            else if (bunifuMetroTextbox3.Text == "")
            {
                errorProvider1.SetError(bunifuMetroTextbox3, "Please Enter the Cash Discount in %");
                bunifuThinButton21.Enabled = false;
            }
            else if (comboBox1.Text == "")
            {
                errorProvider1.SetError(comboBox1, "Please Enter the Supplir Name");
                bunifuThinButton21.Enabled = false;
            }
            else if (bunifuMetroTextbox5.Text == "")
            {
                errorProvider1.SetError(bunifuMetroTextbox5, "Please Enter the Purchase Price of the Item in INR(Rs.)");
                bunifuThinButton21.Enabled = false;
            }
            else if (bunifuMetroTextbox6.Text == "")
            {
                errorProvider1.SetError(bunifuMetroTextbox6, "Please Enter the Packagin(Size) of the Item");
                bunifuThinButton21.Enabled = false;
            }
        }

        public void put_data()
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO Item(Itme_Name,HSN,CD,Supplier_Name,Packaging,Pur_P,Pur_Price) values(@Itme_Name,@HSN,@CD,@Supplier_Name,@Packaging,@Pur_P,@Pur_Price)", con);
                cmd.Parameters.AddWithValue("@Itme_Name", bunifuMetroTextbox1.Text);
                cmd.Parameters.AddWithValue("@HSN", bunifuMetroTextbox2.Text);
                cmd.Parameters.AddWithValue("@CD", Convert.ToInt16(bunifuMetroTextbox3.Text));
                cmd.Parameters.AddWithValue("@Supplier_Name", comboBox1.Text);
                cmd.Parameters.AddWithValue("@Packaging", bunifuMetroTextbox6.Text);
                cmd.Parameters.AddWithValue("@Pur_P", Convert.ToDecimal(bunifuMetroTextbox5.Text));
                cmd.Parameters.AddWithValue("@Pur_Price", Convert.ToInt32(label1.Text));
                cmd.ExecuteNonQuery();
                MessageBox.Show("Record(s) inserted Successfully");
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void Itmeinfo_Load(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd2 = new SqlCommand("SELECT  Supplier_Name from Sup_Det", con);
            DataTable dt2 = new DataTable();
            SqlDataAdapter sda2 = new SqlDataAdapter(cmd2);
            sda2.Fill(dt2);
            comboBox1.DisplayMember = "Supplier_Name";
            comboBox1.DataSource = dt2;
            comboBox1.AutoCompleteMode = AutoCompleteMode.Suggest;
            comboBox1.AutoCompleteSource = AutoCompleteSource.ListItems;
            con.Close();
        }

        private void bunifuMetroTextbox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            if (System.Text.RegularExpressions.Regex.IsMatch(bunifuMetroTextbox5.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers.");
                bunifuMetroTextbox5.Text = bunifuMetroTextbox5.Text.Remove(bunifuMetroTextbox5.Text.Length - 1);
            }
        }

        private void bunifuMetroTextbox5_TabIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void bunifuMetroTextbox3_TabIndexChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(bunifuMetroTextbox5.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers.");
                bunifuMetroTextbox5.Text = bunifuMetroTextbox5.Text.Remove(bunifuMetroTextbox5.Text.Length - 1);
            }
        }
    }
}
