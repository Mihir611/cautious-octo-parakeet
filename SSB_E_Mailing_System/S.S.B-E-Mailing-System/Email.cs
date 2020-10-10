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
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System.Net.Mail;
using System.Net;

namespace S.S.B_E_Mailing_System
{
    public partial class Email : Form
    {
        public Email()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-IVV8MT7;Initial Catalog=SSBEMail;Integrated Security=True");
        string fileName="";

        private void Email_Load(object sender, EventArgs e)
        {
            fillcombo1();
            fillcombo2();
        }

        private void fillcombo1()
        {
            con.Open();
            SqlCommand cmd1 = new SqlCommand("Select Itme_Name,HSN,Supplier_Name,Pur_P from Item", con);
            SqlDataAdapter sdr = new SqlDataAdapter(cmd1);
            DataTable dt1 = new DataTable();
            sdr.Fill(dt1);
            comboBox1.DisplayMember = "Itme_Name";
            comboBox1.DataSource = dt1;
            bunifuCustomDataGrid1.DataSource = dt1;
            comboBox1.AutoCompleteMode = AutoCompleteMode.Suggest;
            comboBox1.AutoCompleteSource = AutoCompleteSource.ListItems;
            con.Close();
        }

        private void fillcombo2()
        {
            con.Open();
            SqlCommand cmd2 = new SqlCommand("SELECT  Supplier_Name from Item", con);
            DataTable dt2 = new DataTable();
            SqlDataAdapter sda2 = new SqlDataAdapter(cmd2);
            sda2.Fill(dt2);
            comboBox2.DisplayMember = "Supplier_Name";
            comboBox2.DataSource = dt2;
            comboBox2.AutoCompleteMode = AutoCompleteMode.Suggest;
            comboBox2.AutoCompleteSource = AutoCompleteSource.ListItems;
            con.Close();
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            bunifuCustomLabel20.Text = textBox6.Text;
            textBox6.Enabled = false;
            comboBox2.Enabled = false;
            Checkcontrols();
            addtodg();
            Clearcontrol();
        }

        private void Clearcontrol()
        {
            comboBox1.SelectedText = "";
            comboBox3.SelectedText = "";
            comboBox2.SelectedText = "";
            textBox4.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox5.Text = "";
        }

        private void addtodg()
        {
            int n = dataGridView1.Rows.Add();
            dataGridView1.Rows[n].Cells[1].Value = comboBox1.Text;
            dataGridView1.Rows[n].Cells[2].Value = maskedTextBox1.Text;
            dataGridView1.Rows[n].Cells[3].Value = textBox4.Text;
            dataGridView1.Rows[n].Cells[4].Value = textBox3.Text;
            dataGridView1.Rows[n].Cells[5].Value = textBox2.Text;
            dataGridView1.Rows[n].Cells[6].Value = textBox5.Text;
        }

        private void Checkcontrols()
        {
            if (textBox6.Text == "")
            {
                errorProvider1.SetError(textBox6, "Please Enter the Order Number");
                
            }
            else if (comboBox1.SelectedText == "")
            {
                errorProvider1.SetError(comboBox1, "Please Select the Item Name");
                
            }
            else if (comboBox2.SelectedText == "")
            {
                errorProvider1.SetError(comboBox2, "Please Select the Supplir Name");
                
            }
            else if (comboBox3.SelectedText == "")
            {
                errorProvider1.SetError(comboBox3, "Please Select the Transporter Name");
                
            }
            else if (textBox4.Text == "")
            {
                errorProvider1.SetError(textBox4, "Please Enter the Quantity Required");
               
            }
            else if (textBox2.Text == "")
            {
                errorProvider1.SetError(textBox2, "Please Enter the Size");
               
            }
            else if (textBox3.Text == "")
            {
                errorProvider1.SetError(textBox3, "Please Enter the Rate");
                
            }
            else if (textBox5.Text == "")
            {
                errorProvider1.SetError(textBox5, "Please Enter the Packaging");
               
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (con.State != ConnectionState.Closed)
            {
                con.Close();
            }
            con.Open();
            SqlCommand put = new SqlCommand("SELECT Email,Contact_Per,Phone,Address from Sup_Det where Supplier_Name = @name", con);
            put.Parameters.AddWithValue("@name", comboBox2.Text);
             SqlDataReader dr = put.ExecuteReader();
             while (dr.Read())
             {
                 bunifuCustomLabel10.Text = dr.GetValue(0).ToString();
                 bunifuCustomLabel12.Text = dr.GetValue(1).ToString();
                 bunifuCustomLabel11.Text = dr.GetValue(2).ToString();
                 textBox1.Text = dr.GetValue(3).ToString();
             }
        }

        //code to autoincrement the Sl.No field in Data Grid
        private void dataGridView1_RowPostPaint_1(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            dataGridView1.Rows[e.RowIndex].Cells[0].Value = (e.RowIndex + 1).ToString();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (con.State != ConnectionState.Closed)
            {
                con.Close();
            }
            con.Open();
            SqlCommand get = new SqlCommand("SELECT HSN,Pur_P from Item where Itme_Name=@n", con);
            get.Parameters.AddWithValue("@n", comboBox1.Text);
            SqlDataReader drget = get.ExecuteReader();
            while (drget.Read())
            {
                maskedTextBox1.Text = drget.GetValue(0).ToString();
                textBox3.Text = drget.GetValue(1).ToString();
            }
            con.Close();
        }

        //code to go-to Supplier details add
        private void bunifuThinButton24_Click(object sender, EventArgs e)
        {
            SuppInfo si = new SuppInfo();
            si.Show();
            Close();
        }

        //main button code with functions
        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            save();
            insertdgcontents();
            pdf();
            sendmail();
            Clearcontrol();
        }

        //code to insert into database
        private void save()
        {
            if (con.State != ConnectionState.Closed)
            {
                con.Close();
            }
            con.Open();
            SqlCommand puttodb = new SqlCommand("INSERT INTO EmailInfo (Order_No,Date,Supplier_Name,Trans) values (@Order_No,@Date,@Supplier_Name,@Trans)", con);
            puttodb.Parameters.AddWithValue("@Order_No", bunifuCustomLabel20.Text);
            puttodb.Parameters.AddWithValue("@Date",Convert.ToDateTime(this.dateTimePicker1.Text));
            puttodb.Parameters.AddWithValue("@Supplier_Name", this.comboBox2.Text);
            puttodb.Parameters.AddWithValue("@Trans", this.comboBox3.Text);
            puttodb.ExecuteNonQuery();
            con.Close();
        }

        //code to insert the datagrid values to database
        private void insertdgcontents()
        {
            if (con.State != ConnectionState.Closed)
            {
                con.Close();
            }
            con.Open();
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                SqlCommand insertdg = new SqlCommand("INSERT INTO EmailInfo1 (Order_No,Item_Name,Code,Quty,Price,Size,Pack,Date,Qty) values('" + bunifuCustomLabel20.Text + "','" + dataGridView1.Rows[i].Cells[1].Value + "','" + dataGridView1.Rows[i].Cells[2].Value + "','" + dataGridView1.Rows[i].Cells[3].Value + "','" + dataGridView1.Rows[i].Cells[4].Value + "','" + dataGridView1.Rows[i].Cells[5].Value + "','" + dataGridView1.Rows[i].Cells[6].Value + "','" + this.dateTimePicker1.Text + "','" + this.bunifuCustomLabel21 .Text+ "')", con);
                insertdg.ExecuteNonQuery();
            }
            MessageBox.Show("Record's Inserted");
        }

        //code to create pdf
        private void pdf()
        {
            int j, k, u;
            Document doc = new Document(iTextSharp.text.PageSize.A4, 10, 10, 42, 35);
            PdfWriter wri = PdfWriter.GetInstance(doc, new FileStream("Order From S.S.B Agencies.pdf", FileMode.Create));
            doc.Open();
            doc.AddAuthor("Gurudas");
            doc.AddCreator("Gurudas");
            Paragraph v = new Paragraph("Date : " + dateTimePicker1.Text + "\nOrder Number : " + bunifuCustomLabel20.Text);
            v.Alignment = 2;
            Paragraph op = new Paragraph("From,\n  S.S.B Agencies, \n  12/3/62,\n  Skanda Prasad, \n  Convent Road, \n  Udupi-576101");
            Paragraph supadd = new Paragraph("\n\nTo,\n  " + comboBox2.Text + "\n  " + textBox1.Text);
            Paragraph salut = new Paragraph("\nDear Sir/Madam,");
            Paragraph bod = new Paragraph("\nPLEASE SEND US THE FOLLOWING ITEMS AS EARLY AS POSSIBLE IN THE FOLLOWING TRANSPORT "+comboBox3.Text+"\n\n");
            doc.Add(v);
            doc.Add(op);
            doc.Add(supadd);
            doc.Add(salut);
            doc.Add(bod);
            //adding table
            PdfPTable tab = new PdfPTable(dataGridView1.Columns.Count);
            tab.SetTotalWidth(new float[] { 50,180,80,80,80,50,80 });
            tab.DefaultCell.BackgroundColor = new iTextSharp.text.BaseColor(0, 250, 154);
            tab.DefaultCell.BorderColor = new iTextSharp.text.BaseColor(105, 105, 105);
            //adding header
            for (u = 0; u < dataGridView1.Columns.Count; u++)
            {
                tab.AddCell(new Phrase(dataGridView1.Columns[u].HeaderText));
            }
            //adding table body
            for (j = 0; j < dataGridView1.Rows.Count; j++)
            {
                for (k = 0; k < dataGridView1.Columns.Count; k++)
                {
                    if (dataGridView1[k, j].Value != null)
                    {
                        tab.AddCell(new Phrase(dataGridView1[k, j].Value.ToString()));
                    }
                }
            }
            doc.Add(tab);
            Paragraph reg = new Paragraph("\n\nThanking You,\nGURUDAS G,\nS.S.B Agencies.");
            doc.Add(reg);
            doc.Close();
            MessageBox.Show("PDF Generated Successfully!!!.");
        }

        private void textBox6_Leave_1(object sender, EventArgs e)
        {
            Checkcontrols();
        }

       ///code to send e-mail
        private void sendmail()
        {
            string h = bunifuCustomLabel10.Text;
            int r;
            r = Convert.ToUInt16("587");
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                mail.From = new MailAddress(bunifuCustomLabel1.Text);
                mail.To.Add(h);
                mail.Subject = "Order for materials";
                mail.Body = "mail with attachment";

                System.Net.Mail.Attachment attachment;
                attachment = new System.Net.Mail.Attachment("Order From S.S.B Agencies.pdf");
                mail.Attachments.Add(attachment);

                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential(bunifuCustomLabel1.Text, bunifuCustomLabel2.Text);
                SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);
                MessageBox.Show("mail Send");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
