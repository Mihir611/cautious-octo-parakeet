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
    public partial class SuppInfo : Form
    {
        public SuppInfo()
        {
            InitializeComponent();
        }

        string g;
        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            Check();
            checkRadio();
            label1.Text = g;
            //database insert code
            try
            {
                SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-IVV8MT7;Initial Catalog=SSBEMail;Integrated Security=True");
                con.Open();
                SqlCommand cmd = new SqlCommand("Insert into Sup_Det (Supplier_Name,Address,GSTin,Email,Phone,Contact_Per,Supp_Of) values (@Supplier_Name,@Address,@GSTin,@Email,@Phone,@Contact_Per,@Supp_Of)", con);
                cmd.Parameters.AddWithValue("@Supplier_Name", bunifuMetroTextbox1.Text);
                cmd.Parameters.AddWithValue("@Address", bunifuCustomTextbox2.Text);
                cmd.Parameters.AddWithValue("@GSTin", bunifuMaterialTextbox1.Text);
                cmd.Parameters.AddWithValue("@Email", bunifuMaterialTextbox2.Text);
                cmd.Parameters.AddWithValue("@Phone", Convert.ToInt64(bunifuCustomTextbox3.Text));
                cmd.Parameters.AddWithValue("@Contact_Per", bunifuCustomTextbox1.Text);
                cmd.Parameters.AddWithValue("@Supp_Of", label1.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Record Inserted Successfully");
            }
            catch
            {
                throw;
            }
            //clearing the controls
           Claer();
        }

        private void Claer()
        {
            bunifuMetroTextbox1.Text = "";
            bunifuCustomTextbox2.Text = "";
            bunifuMaterialTextbox1.Text = "";
            bunifuMaterialTextbox2.Text = "";
            bunifuCustomTextbox3.Text = "";
            bunifuCustomTextbox1.Text = "";
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            radioButton4.Checked = false;
            radioButton5.Checked = false;
            radioButton6.Checked = false;
            g = "";
        }

        private void checkRadio()
        {
            //sending the radio name to g
            if (radioButton1.Checked == true)
            {
                g = radioButton1.Text;
            }
            else if (radioButton2.Checked == true)
            {
                g = radioButton2.Text;
            }
            else if (radioButton3.Checked == true)
            {
                g = radioButton3.Text;
            }
            else if (radioButton4.Checked == true)
            {
                g = radioButton4.Text;
            }
            else if (radioButton5.Checked == true)
            {
                g = radioButton5.Text;
            }
            else if (radioButton6.Checked == true)
            {
                g = radioButton6.Text;
            }
            //check if radio is checked or not
            else if (g == "")
            {
                errorProvider1.SetError(this.groupBox1, "Please Select the Dealer of Field");
                bunifuFlatButton1.Enabled = false;
            }
            else
            {
                bunifuFlatButton1.Enabled = true;
            }
        }

        private void Check()
        {
            //check if all fields are inputted or not
            if(bunifuMaterialTextbox1.Text=="")
            {
                errorProvider1.SetError(this.bunifuMaterialTextbox1, "Please Input the GSTin");
                bunifuFlatButton1.Enabled = false;
            }
            else if (bunifuCustomTextbox2.Text == "")
            {
                errorProvider1.SetError(this.bunifuCustomTextbox2, "Please Input the Address");
                bunifuFlatButton1.Enabled = false;
            }
            else if (bunifuMaterialTextbox2.Text == "")
            {
                errorProvider1.SetError(this.bunifuMaterialTextbox2, "Please Input the Email ID");
                bunifuFlatButton1.Enabled = false;
            }
            else if (bunifuCustomTextbox3.Text == "")
            {
                errorProvider1.SetError(this.bunifuCustomTextbox3, "Please Input the Correct Phone Number");
                bunifuFlatButton1.Enabled = false;
            }
            else if (bunifuCustomTextbox1.Text == "")
            {
                errorProvider1.SetError(this.bunifuCustomTextbox1, "Please Input the Details of the Person To be Contacted");
                bunifuFlatButton1.Enabled = false;
            }
            else if (bunifuMetroTextbox1.Text == "")
            {
                errorProvider1.SetError(this.bunifuMetroTextbox1, "Please Input the Supplier Name");
                bunifuFlatButton1.Enabled = false;
            }
            else
            {
                bunifuFlatButton1.Enabled = true;
            }
        }

        private void bunifuCustomTextbox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            //input phone number limit and accept only numbers
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

        private void bunifuMaterialTextbox2_Leave(object sender, EventArgs e)
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

        private void button2_Click(object sender, EventArgs e)
        {
            //btn cancel pressed then clear all fiels and hide the form
            Claer();
            Hide();
        }
    }
}
