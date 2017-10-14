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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        public void goster()
        {

            if (label2.Text == "emre" && label3.Text == "12")
            {
                btn_personel.Enabled = true;
            }

            else
            {
                btn_personel.Enabled = false;
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            Form3 personal = new Form3();
            personal.label1.Text = label2.Text;
            personal.label2.Text = label3.Text;
            personal.Show();
            this.Hide();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Form4 film = new Form4();
            film.label9.Text = label2.Text;
            film.label10.Text = label3.Text;
            film.Show();
            this.Hide();
        }
        
        private void button3_Click(object sender, EventArgs e)
        {
            Form6 bilet = new Form6();
            bilet.label17.Text = label2.Text;
            bilet.label18.Text = label3.Text;
            bilet.Show();
            this.Hide();

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Form1 giris = new Form1();
            giris.Show();
            this.Hide();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            goster();
        }

        private void btn_cıkıs_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }
    }
}
