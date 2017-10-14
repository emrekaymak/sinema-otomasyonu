using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace cinema1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection baglan = new SqlConnection("Data Source=DESKTOP-ONAIBD8;Initial Catalog=Sinema;Integrated Security=True");

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                baglan.Open();
                string sql = "select*from Personal where Ad=@adi and sifre=@sifresi";
                SqlParameter prm1 = new SqlParameter("adi", textb_ad.Text.Trim());
                SqlParameter prm2 = new SqlParameter("sifresi", textb_sifre.Text.Trim());
                SqlCommand komut = new SqlCommand(sql, baglan);
                komut.Parameters.Add(prm1);
                komut.Parameters.Add(prm2);
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(komut);
                da.Fill(dt);

                if (dt.Rows.Count >0)
                {
                    Form2 giris = new Form2();
                    giris.label2.Text = textb_ad.Text;
                    giris.label3.Text = textb_sifre.Text;
                    giris.Show();
                    this.Hide();
                    textb_ad.Clear();
                    textb_sifre.Clear();
                    
                }

            }

            catch (Exception)
            {
                MessageBox.Show("Kullanıcı adınızı veya şifrenizi yanlış girdiniz.\nLütfen tekrar deneyiniz.");
                textb_ad.Clear();
                textb_sifre.Clear();
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

    }
}
