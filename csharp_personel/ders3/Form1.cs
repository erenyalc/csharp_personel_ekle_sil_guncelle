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
    public partial class Form1 : Form
    {

        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        SqlDataAdapter da;
        DataSet ds;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sorgu = "SELECT * FROM login_2 where login_ad=@usr AND sifre=@psw";

            con = new SqlConnection("server=DESKTOP-LDCVGPO; Initial Catalog=testtest; Integrated Security=True");
            cmd = new SqlCommand(sorgu, con);
            cmd.Parameters.AddWithValue("@usr", textBox1.Text);
            cmd.Parameters.AddWithValue("@psw", textBox2.Text);
            con.Open();
            dr = cmd.ExecuteReader();
            {
                string username;

                string password;

                username = textBox1.Text;

                password = textBox2.Text;



                if (username == "eren" && password == "1234")
                {
                    this.Hide();
                    Form2 frm2 = new Form2();
                    frm2.Show();

                }
            }


            con.Close();
        }
    }
}
