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
    public partial class sistemdaxil : Form
    {
        public sistemdaxil()
        {
            InitializeComponent();
        }
        public string unvan = "Data Source=DESKTOP-UDQ6KSV\\SQLEXPRESS;Initial Catalog=Kafedraiclasss;Integrated Security=True";

        private void sistemg_Click(object sender, EventArgs e)
        {
            if (id.Text != "" && int.Parse(id.Text) > 0 && textad.Text != "" && textsoyad.Text != "" && textataad.Text != "" && textfunvan.Text != "" && textqeyunvan.Text != "" && textsifre.Text != "")
            {
                SqlConnection elaqe_yarat = new SqlConnection(unvan);
                elaqe_yarat.Open();
                SqlCommand daxiledilecekunvan = new SqlCommand("insert into isci_m ( ID, Ad, Soyad, Ata_adı, Doğum_tarixi, Faktiki_ünvan, Qeydiyyatdaki_ünvan, Şifrə ) values ('" + id.Text + "','" + textad.Text + "','" + textsoyad.Text + "','" + textataad.Text + "','" + DateTime.Parse(tarixT.Text) + "','" + textfunvan.Text + "','" + textqeyunvan.Text + "','" + textsifre.Text + "')", elaqe_yarat);

                daxiledilecekunvan.Parameters.AddWithValue("@ID", id.Text);
                daxiledilecekunvan.Parameters.AddWithValue("@Ad", textad.Text);
                daxiledilecekunvan.Parameters.AddWithValue("@Soyad", textsoyad.Text);
                daxiledilecekunvan.Parameters.AddWithValue("@Ata_adı", textataad.Text);
                daxiledilecekunvan.Parameters.AddWithValue("@Doğum_tarixi", DateTime.Parse(tarixT.Text));
                daxiledilecekunvan.Parameters.AddWithValue("@Faktiki_ünvan", textfunvan.Text);
                daxiledilecekunvan.Parameters.AddWithValue("@Qeydiyyatdaki_ünvan", textqeyunvan.Text);
                daxiledilecekunvan.Parameters.AddWithValue("@Şifrə", textsifre.Text);

                daxiledilecekunvan.ExecuteNonQuery();
                elaqe_yarat.Close();

                MessageBox.Show("Verilənlər yadda saxlanıldı");
                id.Text = "";
                textad.Text = "";
                textsoyad.Text = "";
                textataad.Text = "";
                textfunvan.Text = "";
                textqeyunvan.Text = "";
                textsifre.Text = "";
            }
            else
            {
                
                 MessageBox.Show("Verilmiş xanaları doldurun");
                
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            new mdaxet().ShowDialog();
            this.Hide();
        }

        private void id_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textsoyad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textataad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
