using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Kafedraİclasi
{
    public partial class sistem : Form
    {
        public sistem()
        {
            InitializeComponent();
        }
        public string unvan = "Data Source=DESKTOP-UDQ6KSV\\SQLEXPRESS;Initial Catalog=Kafedraiclasss;Integrated Security=True";
        private void sistemg_Click(object sender, EventArgs e)
        {
            if (textad.Text != "" && textsoyad.Text !="" && textataad.Text !="" && textsifre.Text !="")
            {
                SqlConnection elaqe_yarat = new SqlConnection(unvan);
                elaqe_yarat.Open();

                SqlCommand yoxla = new SqlCommand("Select * from isci_m WHERE Ad=@Ad and Soyad=@Soyad and Ata_adı=@Ata_adı and Şifrə=@Şifrə", elaqe_yarat);

                yoxla.Parameters.AddWithValue("@Ad", textad.Text);
                yoxla.Parameters.AddWithValue("@Soyad", textsoyad.Text);
                yoxla.Parameters.AddWithValue("@Ata_adı", textataad.Text);
                yoxla.Parameters.AddWithValue("@Şifrə", textsifre.Text);

                SqlDataReader oxu = yoxla.ExecuteReader();

                if (oxu.Read() == true)
                {
                    new mdaxet().Show();
                    this.Hide();
                }

                else
                {
                    MessageBox.Show("Sistemdəki işçilərin adı ilə düzgün gəlmir.", "XƏTA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textad.Text = "";
                    textsoyad.Text = "";
                    textataad.Text = "";
                    textsifre.Text = "";
                }
            }
            else
            {
                MessageBox.Show("Verilmiş xanaları doldurun");
            }
        }

        private void protokolagoreaxtaris_Click(object sender, EventArgs e)
        {

            new Protokolagore().ShowDialog();
            this.Hide();
        }

        private void tarixegoreaxtaris_Click(object sender, EventArgs e)
        {

            new Tarixegore().ShowDialog();
            this.Hide();
        }

        private void sistirakina_Click(object sender, EventArgs e)
        {

            new sgore().ShowDialog();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {

            new sobeleregore().ShowDialog();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {

            new qerar().ShowDialog();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new Form1().ShowDialog();
            this.Hide();
        }

        private void textad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar)  && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textsoyad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar)  && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textataad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
