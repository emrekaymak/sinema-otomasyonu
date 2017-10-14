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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }
        private void CmbFilmTurDoldur()
        {
            string query = "Select TurID, TurAdı from Film_Tur";
            SqlDataAdapter da = new SqlDataAdapter(query, bagla);
            DataSet ds = new DataSet();
            da.Fill(ds, "TurAdı");
            comboBox1.DisplayMember = "TurAdı";
            comboBox1.ValueMember = "TurID";
            comboBox1.DataSource = ds.Tables["TurAdı"];
        }
        private void CmbSalonDoldur()
        {
            string query = "Select SalonID, SalonAdı from Salon";
            SqlDataAdapter da = new SqlDataAdapter(query, bagla);
            DataSet ds = new DataSet();
            da.Fill(ds, "SalonAdı");
            comboBox4.DisplayMember = "SalonAdı";
            comboBox4.ValueMember = "SalonID";
            comboBox4.DataSource = ds.Tables["SalonAdı"];
        }
        private void CmbSeansnDoldur()
        {
            string query = "Select SeansID, Seans from Seans";
            SqlDataAdapter da = new SqlDataAdapter(query, bagla);
            DataSet ds = new DataSet();
            da.Fill(ds, "Seans");
            comboBox5.DisplayMember = "Seans";
            comboBox5.ValueMember = "SeansID";
            comboBox5.DataSource = ds.Tables["Seans"];
        }

        public void temiz()
        {
            verigoster("goster_film");
            textBox2.Clear();
            comboBox1.ResetText();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            comboBox4.ResetText();
            comboBox5.ResetText();
        }

        SqlConnection bagla = new SqlConnection("Data Source=DESKTOP-ONAIBD8;Initial Catalog=Sinema;Integrated Security=True");

        private void verigoster(string veriler)
        {
            SqlDataAdapter da = new SqlDataAdapter(veriler, bagla);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            //bagla.Open();
            //SqlCommand komut = new SqlCommand("goster_film", bagla);        
            //SqlDataReader oku = komut.ExecuteReader();
            //while (oku.Read())
            //{
            //    ListViewItem ekle = new ListViewItem();
            //    ekle.Text = oku["FilmID"].ToString();
            //    ekle.SubItems.Add(oku["FilmAdı"].ToString());
            //    ekle.SubItems.Add(oku["TurAdı"].ToString());
            //    ekle.SubItems.Add(oku["Yönetmen"].ToString());
            //    ekle.SubItems.Add(oku["VGririsTarihi"].ToString());
            //    ekle.SubItems.Add(oku["VCikisTarihi"].ToString());
            //    ekle.SubItems.Add(oku["SalonAdı"].ToString());
            //    ekle.SubItems.Add(oku["Seans"].ToString());
                
                
            //    listView1.Items.Add(ekle);
            //}
            //bagla.Close();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            verigoster("goster_film");
            CmbFilmTurDoldur();
            CmbSeansnDoldur();
            CmbSalonDoldur();
        }

   
        

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog resim = new OpenFileDialog();
            if (resim.ShowDialog() == DialogResult.OK)
            {
                this.pictureBox1.Image = new Bitmap(resim.OpenFile());
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
                bagla.Open();
                SqlCommand komut5 = new SqlCommand("Update Film set FilmAdı='" + textBox2.Text.ToString() + "',TurID='"+Convert.ToInt32(comboBox1.SelectedValue)+"',Yönetmen='" + textBox4.Text.ToString() + "',VGririsTarihi='" + textBox5.Text.ToString() + "',VCikisTarihi='" + textBox6.Text.ToString() + "',SalonID='" + Convert.ToInt32(comboBox4.SelectedValue) + "',SeansID='" + Convert.ToInt32(comboBox5.SelectedValue) + "' where FilmID='" + dataGridView1.SelectedCells[0].Value.ToString() + "'", bagla);
                komut5.ExecuteNonQuery();
                verigoster("goster_film");
                bagla.Close();
                temiz();
            //    bagla.Open();
            //    SqlCommand komut5 = new SqlCommand("Update Film set FilmAdı='" + textBox2.Text.ToString() + "',TurID='" + Convert.ToInt32(comboBox1.SelectedValue) + "',Yönetmen='" + textBox4.Text.ToString() + "',VGririsTarihi='" + textBox5.Text.ToString() + "',VCikisTarihi='" + textBox6.Text.ToString() + "',SalonID='" + Convert.ToInt32(comboBox2.SelectedValue) + "',SeansID='" + Convert.ToInt32(comboBox3.SelectedValue) + "' where FilmID=" + id + "", bagla);
            //    komut5.ExecuteNonQuery();
            //    bagla.Close();
            //    temiz();
           

        }
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                //bagla.Open();
                //SqlCommand komut5 = new SqlCommand("Delete From Film where FilmID=(" + id + ")", bagla);
                //komut5.ExecuteNonQuery();
                //bagla.Close();
                //temiz();

                bagla.Open();
                SqlCommand komut5 = new SqlCommand("Delete from Film where FilmID=@filmad", bagla);
                komut5.Parameters.AddWithValue("@filmad", dataGridView1.SelectedCells[0].Value.ToString());
                komut5.ExecuteNonQuery();
                verigoster("goster_film");
                bagla.Close();
                temiz();

            }
            catch (Exception)
            {
                MessageBox.Show("Silme işlemi için ilk önce listeden bir ID seçmelisiniz");
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                bagla.Open();
                SqlCommand komut5 = new SqlCommand("Insert Into Film (FilmAdı,TurID,Yönetmen,VGririsTarihi,VCikisTarihi,SalonID,SeansID) values('" + textBox2.Text.ToString() + "','" + Convert.ToInt32(comboBox1.SelectedValue) + "','" + textBox4.Text.ToString() + "','" + textBox5.Text.ToString() + "','" + textBox6.Text.ToString() + "','" + Convert.ToInt32(comboBox4.SelectedValue) + "','" + Convert.ToInt32(comboBox5.SelectedValue) + "')", bagla);
                komut5.ExecuteNonQuery();
                bagla.Close();
                temiz();
            }

            catch (Exception)
            {
                MessageBox.Show("1)Yanlış Biçimde Yazdığın Birşeyler Var.\n\n 2) ID Dolu olduğuna ve Farklı Olmasına Dikkat Et");
            }
        }
        private void button5_Click(object sender, EventArgs e)
        {
            Form2 geri = new Form2();
            geri.label2.Text = label9.Text;
            geri.label3.Text = label10.Text;
            geri.Show();
            this.Hide();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilialan = dataGridView1.SelectedCells[0].RowIndex;
            string ad = dataGridView1.Rows[secilialan].Cells[1].Value.ToString();
            string tur = dataGridView1.Rows[secilialan].Cells[2].Value.ToString();
            string yonetmen = dataGridView1.Rows[secilialan].Cells[3].Value.ToString();
            string vgt = dataGridView1.Rows[secilialan].Cells[4].Value.ToString();
            string vct = dataGridView1.Rows[secilialan].Cells[5].Value.ToString();
            string salon = dataGridView1.Rows[secilialan].Cells[6].Value.ToString();
            string seans = dataGridView1.Rows[secilialan].Cells[7].Value.ToString();
            textBox2.Text = ad;
            comboBox1.Text = tur;
            textBox4.Text = yonetmen;
            textBox5.Text = vgt;
            textBox6.Text = vct;
            comboBox4.Text = salon;
            comboBox5.Text = seans;

        }

        
    }
}
