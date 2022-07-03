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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public string unvan = "Data Source=DESKTOP-UDQ6KSV\\SQLEXPRESS;Initial Catalog=Kafedraiclasss;Integrated Security=True";
        private void Form1_Load(object sender, EventArgs e)
        {

        }   

        private void button1_Click(object sender, EventArgs e)
        {

            SqlConnection elaqe_yarat = new SqlConnection(unvan);
            elaqe_yarat.Open();
            SqlCommand burdangotur = new SqlCommand("Select * from iclaslar", elaqe_yarat);

            SqlDataAdapter da = new SqlDataAdapter(burdangotur);
            DataTable melumatcedveli = new DataTable();
            da.Fill(melumatcedveli);
            dataGridView1.DataSource = melumatcedveli;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            new Protokolagore().ShowDialog();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            new Tarixegore().ShowDialog();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
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

        private void button7_Click(object sender, EventArgs e)
        {

            new sistem().ShowDialog();
            this.Hide();
        }
    }
}
