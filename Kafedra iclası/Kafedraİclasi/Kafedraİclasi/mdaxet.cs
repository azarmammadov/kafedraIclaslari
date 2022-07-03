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
    public partial class mdaxet : Form
    {
        public mdaxet()
        {
            InitializeComponent();
        }



        private void mdaxet_Load(object sender, EventArgs e)
        {

        }

        public string unvan = "Data Source=DESKTOP-UDQ6KSV\\SQLEXPRESS;Initial Catalog=Kafedraiclasss;Integrated Security=True";

        private void sistemg_Click(object sender, EventArgs e)
        {
            if (protokol.Text !="" &&  shexs.Text != "" && shobe.Text != "" && qerarr.Text != "")
            {
                SqlConnection elaqe_yarat = new SqlConnection(unvan);
                elaqe_yarat.Open();
                SqlCommand daxiledilecekunvan = new SqlCommand("insert into dbo.iclaslar ( Protokollar, Şəxsin_iştirakı, Şöbə, Tarix, Şöbədən_verilən_qərar ) values ('" + protokol.Text + "',N'" + shexs.Text + "','" + shobe.Text + "','" + DateTime.Parse(tarixT.Text) + "','" + qerarr.Text + "')", elaqe_yarat);

                daxiledilecekunvan.Parameters.AddWithValue("@Protokollar", protokol.Text);
                daxiledilecekunvan.Parameters.AddWithValue("@Şəxsin_iştirakı", shexs.Text);
                daxiledilecekunvan.Parameters.AddWithValue("@Şöbə", shobe.Text);
                daxiledilecekunvan.Parameters.AddWithValue("@Doğum_tarixi", DateTime.Parse(tarixT.Text));
                daxiledilecekunvan.Parameters.AddWithValue("@Şöbədən_verilən_qərar", qerarr.Text);

                daxiledilecekunvan.ExecuteNonQuery();
                elaqe_yarat.Close();
                MessageBox.Show("Verilənlər yadda saxlanıldı");
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

        private void button1_Click(object sender, EventArgs e)
        {
            new Form1().ShowDialog();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new sdoicd().ShowDialog();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new sistemdaxil().ShowDialog();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            new isci_m().ShowDialog();
            this.Hide();
        }

        private void shexs_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if(dataGridView1.Rows.Count>0)
            {
                Microsoft.Office.Interop.Excel._Application exlkec = new Microsoft.Office.Interop.Excel.Application();
                Microsoft.Office.Interop.Excel._Workbook iskitab = exlkec.Workbooks.Add(Type.Missing);
                Microsoft.Office.Interop.Excel._Worksheet isvereqi = null;
                isvereqi = iskitab.Sheets["Sheets1"];
                isvereqi = iskitab.ActiveSheet;
                isvereqi.Name = "Iclas";

                for (int i = 1; i < dataGridView1.Columns.Count+1; i++)
                {
                    isvereqi.Cells[1, i] = dataGridView1.Columns[i - 1].HeaderText;
                }
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    for (int j = 0; j < dataGridView1.Columns.Count; j++)
                    {
                        isvereqi.Cells[i + 2, j + 1] = dataGridView1.Rows[i].Cells[j].Value.ToString();
                    }
                }

                var yaddasaxla = new SaveFileDialog();
                yaddasaxla.FileName = "output";
                yaddasaxla.DefaultExt = ".xlsx";
                if (yaddasaxla.ShowDialog()==DialogResult.OK)
                {
                    iskitab.SaveAs(yaddasaxla.FileName, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                       
                }
                


            }
        }
    }
}
