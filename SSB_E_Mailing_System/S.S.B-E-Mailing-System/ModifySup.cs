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
    public partial class ModifySup : Form
    {
        public ModifySup()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-IVV8MT7;Initial Catalog=SSBEMail;Integrated Security=True");

        private void ModifySup_Load(object sender, EventArgs e)
        {
            fillcombo1();
        }

        //filling the comboo box
        private void fillcombo1()
        {
            con.Open();
            SqlCommand cmd1 = new SqlCommand("Select Supplier_Name from Sup_Det", con);
            SqlDataAdapter sdr = new SqlDataAdapter(cmd1);
            DataTable dt1 = new DataTable();
            sdr.Fill(dt1);
            comboBox1.DisplayMember = "Supplier_Name";
            comboBox1.DataSource = dt1;
            comboBox1.AutoCompleteMode = AutoCompleteMode.Suggest;
            comboBox1.AutoCompleteSource = AutoCompleteSource.ListItems;
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            fill_others();
            borderPanel1.Visible = false;
        }

        //filling other fields
        private void fill_others()
        {
            if (con.State != ConnectionState.Closed)
            {
                con.Close();
            }
            con.Open();
            SqlCommand get = new SqlCommand("SELECT Supplier_Name,Address,GSTin,Email,Phone,Contact_Per from Sup_Det where Supplier_Name = @n", con);
            get.Parameters.AddWithValue("@n", comboBox1.Text);
            SqlDataReader drget = get.ExecuteReader();
            while (drget.Read())
            {
                bunifuMaterialTextbox3.Text = drget.GetValue(0).ToString();
                bunifuCustomTextbox2.Text = drget.GetValue(1).ToString();
                bunifuMaterialTextbox1.Text = drget.GetValue(2).ToString();
                bunifuMaterialTextbox2.Text = drget.GetValue(3).ToString();
                bunifuCustomTextbox3.Text = drget.GetValue(4).ToString();
                bunifuCustomTextbox1.Text = drget.GetValue(5).ToString();
            }
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            borderPanel1.Visible = true;
            clearcont();
        }

        private void clearcont()
        {
            bunifuMaterialTextbox3.Text = "";
            bunifuCustomTextbox2.Text = "";
            bunifuMaterialTextbox1.Text = "";
            bunifuMaterialTextbox2.Text="";
            bunifuCustomTextbox3.Text = "";
            bunifuCustomTextbox1.Text = "";
        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            try
            {
                if (con.State != ConnectionState.Closed)
                {
                    con.Close();
                }
                con.Open();
                SqlCommand cmd3 = new SqlCommand("update Sup_Det set Email = @em, Phone = @ph, Contact_Per = @cp where Supplier_Name=@n", con);
                cmd3.Parameters.AddWithValue("@n", bunifuMaterialTextbox3.Text);
                cmd3.Parameters.AddWithValue("@ph", Convert.ToInt64(bunifuCustomTextbox3.Text));
                cmd3.Parameters.AddWithValue("@em", bunifuMaterialTextbox2.Text);
                cmd3.Parameters.AddWithValue("@cp", bunifuCustomTextbox1.Text);
                cmd3.ExecuteNonQuery();
                MessageBox.Show("Records updated....");
            }
            catch
            {
                throw;
            }
            clearcont();
        }

        private void bunifuCustomTextbox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            //input only phone number
            string phone = @"^\(\d{3}\) \d{3}-\d{4}$";
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            else if (Regex.IsMatch(bunifuCustomTextbox3.Text, phone))
            {
                errorProvider1.Clear();
                bunifuFlatButton1.Enabled = true;
            }
            else
            {
                errorProvider1.SetError(this.bunifuCustomTextbox3, "Please Input the Correct Phone Number");
                bunifuFlatButton1.Enabled = false;
            }
        }

        private void bunifuMaterialTextbox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            //input e-mail validation
            string pattern = @"^(([\w-]+\.)+[\w-]+|([a-zA-Z]{1}|[\w-]{2,}))@"
     + @"((([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?
				[0-9]{1,2}|25[0-5]|2[0-4][0-9])\."
     + @"([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?
				[0-9]{1,2}|25[0-5]|2[0-4][0-9])){1}|"
     + @"([a-zA-Z0-9]+[\w-]+\.)+[a-zA-Z]{1}[a-zA-Z0-9-]{1,23})$";
            if (Regex.IsMatch(bunifuMaterialTextbox2.Text, pattern))
            {
                errorProvider1.Clear();
                bunifuFlatButton1.Enabled = true;
            }
            else
            {
                errorProvider1.SetError(this.bunifuMaterialTextbox2, "Please Provide Valid E-mail address");
                bunifuFlatButton1.Enabled = false;
            }
        }
    }
}
