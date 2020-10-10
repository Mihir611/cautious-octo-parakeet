using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace S.S.B_E_Mailing_System
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            if (bunifuMaterialTextbox1.Text == "" || bunifuMaterialTextbox2.Text == "")
            {
                MessageBox.Show("Please Enter the User Name or the PAssword Correctly");
            }
            else if (bunifuMaterialTextbox1.Text != "Gurudas" || bunifuMaterialTextbox2.Text != "saibaba")
            {
                MessageBox.Show("Please enter the UserName or Password Correctly");
            }
            else if (bunifuMaterialTextbox1.Text != "Gurudas")
            {
                MessageBox.Show("Please enter the User Name Correctly");
            }
            else if (bunifuMaterialTextbox2.Text != "saibaba")
            {
                MessageBox.Show("Please enter the Password Correctly");
            }
            else
            {
                bool connection = NetworkInterface.GetIsNetworkAvailable();
                if (connection == true)
                {
                    home h = new home();
                    h.Show();
                }
                else
                {
                    MessageBox.Show("Internet Not Coonnected Please Check the Connection and Try again");
                }
            }
        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void bunifuThinButton23_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
