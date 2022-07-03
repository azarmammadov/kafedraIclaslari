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
    public partial class Tarixegore : Form
    {
        public Tarixegore()
        {
            InitializeComponent();
        }

        public string unvan = "Data Source=DESKTOP-UDQ6KSV\\SQLEXPRESS;Initial Catalog=Kafedraiclasss;Integrated Security=True";


        private void Tarixegore_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(unvan);
            con.Open();
            string cmd = "Select * from iclaslar where Tarix LIKE '%' + @Tarix +'%' ";

            SqlDataAdapter sqlda = new SqlDataAdapter(cmd, con);
            sqlda.SelectCommand.Parameters.AddWithValue("@Tarix", DateTime.Parse(tarixT.Text.Trim()));
            DataTable melumatcedveli = new DataTable();
            sqlda.Fill(melumatcedveli);
            melumatcedvelidizayn.DataSource = melumatcedveli;
            
        }

        private void button2_Click(object sender, EventArgs e)
        {

            new Protokolagore().ShowDialog();
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

        private void button3_Click(object sender, EventArgs e)
        {
            new Form1().ShowDialog();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
