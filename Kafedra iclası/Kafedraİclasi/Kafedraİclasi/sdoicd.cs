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
    public partial class sdoicd : Form
    {
        public sdoicd()
        {
            InitializeComponent();
        }

        public string unvan = "Data Source=DESKTOP-UDQ6KSV\\SQLEXPRESS;Initial Catalog=Kafedraiclasss;Integrated Security=True";


        private void sistemg_Click(object sender, EventArgs e)
        {
            if (protokol.Text !="" && shexs.Text !="" && shobe.Text !="" && qerarr.Text !="" )
            {

                SqlConnection con = new SqlConnection(unvan);
                con.Open();
                SqlCommand yenilenecekolanlar = new SqlCommand("Update iclaslar set  Protokollar=@Protokollar, Şəxsin_iştirakı=@Şəxsin_iştirakı, Şöbə=@Şöbə, Tarix=@Tarix, Şöbədən_verilən_qərar=@Şöbədən_verilən_qərar where Protokollar=@Protokollar ", con);

                yenilenecekolanlar.Parameters.AddWithValue("@Protokollar", protokol.Text);
                yenilenecekolanlar.Parameters.AddWithValue("@Şəxsin_iştirakı", shexs.Text);
                yenilenecekolanlar.Parameters.AddWithValue("@Şöbə", shobe.Text);
                yenilenecekolanlar.Parameters.AddWithValue("@Tarix", DateTime.Parse(tarixT.Text));
                yenilenecekolanlar.Parameters.AddWithValue("@Şöbədən_verilən_qərar", qerarr.Text);

                yenilenecekolanlar.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Sistemdə istədiyiniz dəyişikliklər edildi");
            }
            else
            {
                MessageBox.Show("Verilmiş xanaları doldurun");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SqlConnection elaqe_yarat = new SqlConnection(unvan);
            elaqe_yarat.Open();
            SqlCommand burdangotur = new SqlCommand("Select * from iclaslar", elaqe_yarat);

            SqlDataAdapter da = new SqlDataAdapter(burdangotur);
            DataTable melumatcedveli = new DataTable();
            da.Fill(melumatcedveli);
            dataGridView1.DataSource = melumatcedveli;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new mdaxet().ShowDialog();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (protokol.Text != "")
            {
                SqlConnection silisci = new SqlConnection(unvan);
                silisci.Open();
                SqlCommand sil = new SqlCommand(" Delete iclaslar where Protokollar=@Protokollar ", silisci);
                sil.Parameters.AddWithValue("@Protokollar", protokol.Text);

                sil.ExecuteNonQuery();
                silisci.Close();
                MessageBox.Show("Məlumat silindi");
            }
            else
            {
                MessageBox.Show("Xəta!");
            }
        }

        private void protokol_TextChanged(object sender, EventArgs e)
        {

        }

        private void shexs_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void shexs_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
