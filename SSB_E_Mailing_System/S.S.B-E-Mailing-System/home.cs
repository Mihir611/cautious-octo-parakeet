using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace S.S.B_E_Mailing_System
{
    public partial class home : Form
    {
        public home()
        {
            InitializeComponent();
        }

        private void addSuppliersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SuppInfo s = new SuppInfo();
            s.Show();
            s.MdiParent = this;
        }

        private void addItemsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Itmeinfo i = new Itmeinfo();
            i.Show();
            i.MdiParent = this;
        }

        private void sendEMailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Email E = new Email();
            E.Show();
            E.MdiParent = this;
        }

        private void modifySuppliersInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ModifySup m = new ModifySup();
            m.Show();
            m.MdiParent=this;
        }

        private void modifyItemInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ModiItem m1 = new ModiItem();
            m1.Show();
            m1.MdiParent = this;
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void emailSentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EmailInfo em = new EmailInfo();
            em.Show();
            em.MdiParent = this;
        }
    }
}
