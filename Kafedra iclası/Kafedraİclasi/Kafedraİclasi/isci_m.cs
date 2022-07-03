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
    public partial class isci_m : Form
    {
        public isci_m()
        {
            InitializeComponent();
        }

        public string unvan = "Data Source=DESKTOP-UDQ6KSV\\SQLEXPRESS;Initial Catalog=Kafedraiclasss;Integrated Security=True";


        private void isci_m_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            new mdaxet().ShowDialog();
            this.Hide();
        }

        private void sistemg_Click(object sender, EventArgs e)
        {
            if (id.Text!="" && int.Parse(id.Text) > 0 &&  textad.Text != "" && textsoyad.Text != "" && textataad.Text != "" && textFUnvan.Text != "" && textQunvan.Text != "" && textsifreeee.Text != "" )
            {
                SqlConnection yemelum = new SqlConnection(unvan);
                yemelum.Open();
                SqlCommand yemyaz = new SqlCommand("Update isci_m set Ad=@Ad , Soyad=@Soyad, Ata_adı=@Ata_adı, Doğum_tarixi=@Doğum_tarixi, Faktiki_ünvan=@Faktiki_ünvan, Qeydiyyatdaki_ünvan=@Qeydiyyatdaki_ünvan, Şifrə=@Şifrə where ID=@ID ", yemelum);

                yemyaz.Parameters.AddWithValue("@ID", id.Text);
                yemyaz.Parameters.AddWithValue("@Ad", textad.Text);
                yemyaz.Parameters.AddWithValue("@Soyad", textsoyad.Text);
                yemyaz.Parameters.AddWithValue("@Ata_adı", textataad.Text);
                yemyaz.Parameters.AddWithValue("@Doğum_tarixi", DateTime.Parse(tarixT.Text));
                yemyaz.Parameters.AddWithValue("@Faktiki_ünvan", textFUnvan.Text);
                yemyaz.Parameters.AddWithValue("@Qeydiyyatdaki_ünvan", textQunvan.Text);
                yemyaz.Parameters.AddWithValue("@Şifrə", textsifreeee.Text);

                yemyaz.ExecuteNonQuery();
                yemelum.Close();
                MessageBox.Show("Dəyişiklik edildi"); 
            }
            else
            {
                MessageBox.Show("Verilmiş xanaları doldurun");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            if (id.Text != "" && int.Parse(id.Text)> 0)
            {
                
                SqlConnection silisci = new SqlConnection(unvan);
                silisci.Open();
                SqlCommand sil = new SqlCommand(" Delete isci_m where ID=@ID ", silisci);
                sil.Parameters.AddWithValue("@ID", int.Parse(id.Text));

                sil.ExecuteNonQuery();
                silisci.Close();
                MessageBox.Show("Məlumat silindi");
            }
            else
            {
                MessageBox.Show("Verilmiş ID xanasın doldurun");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SqlConnection elaqe_yarat = new SqlConnection(unvan);
            elaqe_yarat.Open();
            SqlCommand burdangotur = new SqlCommand("Select * from isci_m", elaqe_yarat);

            SqlDataAdapter da = new SqlDataAdapter(burdangotur);
            DataTable melumatcedveli = new DataTable();
            da.Fill(melumatcedveli);
            iscimelumatcedveli.DataSource = melumatcedveli;
        }

        private void textad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textsoyad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar) && !char.IsControl(e.KeyChar))
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

        private void id_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar)  && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textad_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
