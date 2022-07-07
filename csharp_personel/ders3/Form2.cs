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

namespace ders3
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        SqlDataAdapter da;
        DataSet ds;

        void griddoldur()
        {
            con = new SqlConnection("server=DESKTOP-LDCVGPO; Initial Catalog=testtest; Integrated Security=True");
            da = new SqlDataAdapter("Select *From personel", con);
            ds = new DataSet();
            con.Open();
            da.Fill(ds, "personel");
            dataGridView1.DataSource = ds.Tables["personel"];
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            griddoldur();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "insert into personel(personel_id,personel_ad_soyad,personel_brans, personel_maas) values (" + textBox1.Text + ",'" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "')";
            cmd.ExecuteNonQuery();
            con.Close();
            griddoldur();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "delete from personel where personel_id=" + textBox1.Text + "";
            cmd.ExecuteNonQuery();
            con.Close();
            griddoldur();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "update personel set personel_ad_soyad='" + textBox2.Text + "',personel_brans='" + textBox3.Text + "',personel_maas='" + textBox4.Text + "' where personel_id=" + textBox1.Text + "";
            cmd.ExecuteNonQuery();
            con.Close();
            griddoldur();

        }
    }
}
