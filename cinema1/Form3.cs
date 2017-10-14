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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        public void temiz()
        {
            verigoster("goster_personal");          
            textb_ad.Clear();
            textb_soyad.Clear();
            textb_sifre.Clear();
            textb_telefon.Clear();
            textb_mail.Clear();
            textb_guvenlik2.Clear();
            cmb_güvenlik.ResetText();
            cmb_cinsiyet.ResetText();
            cmb_personal.ResetText();
        }
        SqlConnection bagla = new SqlConnection("Data Source=DESKTOP-ONAIBD8;Initial Catalog=Sinema;Integrated Security=True");

        private void verigoster( string veriler)
        {
            SqlDataAdapter da = new SqlDataAdapter(veriler, bagla);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            //bagla.Open();
            //SqlCommand komut = new SqlCommand("goster_personal", bagla);
            //komut.CommandType = CommandType.StoredProcedure;
            //SqlDataReader oku = komut.ExecuteReader();

           // while (oku.Read())
           // {
           //     ListViewItem ekle = new ListViewItem();
           //     ekle.Text = oku["PersonalID"].ToString();
           //     ekle.SubItems.Add(oku["ad"].ToString());
           //     ekle.SubItems.Add(oku["soyad"].ToString());
           //     ekle.SubItems.Add(oku["sifre"].ToString());
           //     ekle.SubItems.Add(oku["tel"].ToString());
           //     ekle.SubItems.Add(oku["Email"].ToString());
           //     ekle.SubItems.Add(oku["Soru"].ToString());
           //     ekle.SubItems.Add(oku["cinsiyet"].ToString());
           //     ekle.SubItems.Add(oku["TipAd"].ToString());
           //     listView1.Items.Add(ekle);
           // }
           //bagla.Close();
        }

       private void Form3_Load(object sender, EventArgs e)
        {
            verigoster("goster_personal");
            CmbCinsiyetTipiDoldur();
            CmbPersonelTipiDoldur();
            CmbGuvenlikSoruDoldur();    
        }

        private void CmbGuvenlikSoruDoldur()
        {
            string query = "Select SoruID,Soru from GuvenlikSoru";
            SqlDataAdapter da = new SqlDataAdapter(query, bagla);
            DataSet ds = new DataSet();
            da.Fill(ds, "Soru");
            cmb_güvenlik.DisplayMember = "Soru";
            cmb_güvenlik.ValueMember = "SoruID";
            cmb_güvenlik.DataSource = ds.Tables["Soru"];
        }
        private void CmbPersonelTipiDoldur()
        {
            string query = "select TipID,TipAd from PersonelTip";
            SqlDataAdapter da = new SqlDataAdapter(query, bagla);
            DataSet ds = new DataSet();
            da.Fill(ds, "TipAd");
            cmb_personal.DisplayMember = "TipAd";
            cmb_personal.ValueMember = "TipID";
            cmb_personal.DataSource = ds.Tables["TipAd"];
        }
        private void CmbCinsiyetTipiDoldur()
        {
            string query = "select CinsiyetID,Cinsiyet from Cinsiyet";
            SqlDataAdapter da = new SqlDataAdapter(query, bagla);
            DataSet ds = new DataSet();
            da.Fill(ds, "Cinsiyet");
            cmb_cinsiyet.DisplayMember = "Cinsiyet";
            cmb_cinsiyet.ValueMember = "CinsiyetID";
            cmb_cinsiyet.DataSource = ds.Tables["Cinsiyet"];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog resim = new OpenFileDialog();    
            if(resim.ShowDialog()==DialogResult.OK)
            {
                this.pictureBox1.Image = new Bitmap(resim.OpenFile());
            }

        }        
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                //bagla.Open();
                //SqlCommand komut3 = new SqlCommand("Delete From Personal where PersonalID=(" + id + ")", bagla);
                //komut3.ExecuteNonQuery();
                //bagla.Close();
                //temiz();
                bagla.Open();
                SqlCommand komut3 = new SqlCommand("Delete From Personal where PersonalID=@personal", bagla);
                komut3.Parameters.AddWithValue("@personal", dataGridView1.SelectedCells[0].Value.ToString());
                komut3.ExecuteNonQuery();
                verigoster("goster_personal");
                temiz();
                bagla.Close();
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
                //bagla.Open();
                //SqlCommand komut2 = new SqlCommand("Insert Into Personal (Ad,Soyad,Sifre,Tel,Email,SoruID,CinsiyetID,TipID) values('" + textb_ad.Text.ToString() + "','" + textb_soyad.Text.ToString() + "','" + textb_sifre.Text.ToString() + "','" + textb_telefon.Text.ToString() + "','" + textb_mail.Text.ToString() + "','" + Convert.ToInt32(cmb_güvenlik.SelectedValue) + "','" + Convert.ToInt32(cmb_cinsiyet.SelectedValue) + "', '" + Convert.ToInt32(cmb_personal.SelectedValue) + "')", bagla);
                //komut2.ExecuteNonQuery();
                //bagla.Close();
                //temiz();
                bagla.Open();
                SqlCommand komut2 = new SqlCommand("Insert Into Personal (Ad,Soyad,Sifre,Tel,Email,SoruID,CinsiyetID,TipID) values(@Adi,@Soyadi,@Sifrei,@Teli,@Emaili,@SoruIDi,@CinsiyetIDi,@TipIDi)", bagla);
                komut2.Parameters.AddWithValue("@Adi", textb_ad.Text);
                komut2.Parameters.AddWithValue("@Soyadi", textb_soyad.Text);
                komut2.Parameters.AddWithValue("@Sifrei", textb_sifre.Text);
                komut2.Parameters.AddWithValue("@Teli", textb_telefon.Text);
                komut2.Parameters.AddWithValue("@Emaili", textb_mail.Text);
                komut2.Parameters.AddWithValue("@SoruIDi", Convert.ToInt32(cmb_güvenlik.SelectedValue));
                komut2.Parameters.AddWithValue("@CinsiyetIDi", Convert.ToInt32(cmb_cinsiyet.SelectedValue));
                komut2.Parameters.AddWithValue("@TipIDi", Convert.ToInt32(cmb_personal.SelectedValue));
                komut2.ExecuteNonQuery();
                temiz();
                verigoster("goster_personal");
                bagla.Close();
            }


            catch (Exception)
            {
                MessageBox.Show("1)Yanlış Biçimde Yazdığın Birşeyler Var.\n\n 2) ID Dolu olduğuna ve Farklı Olmasına Dikkat Et");
            }
        }
        private void button2_Click_1(object sender, EventArgs e)
        {
            try
            {
                //bagla.Open();
                //SqlCommand komut4 = new SqlCommand("Update Personal set Ad='" + textb_ad.Text.ToString() + "',Soyad='" + textb_soyad.Text.ToString() + "',Sifre='" + textb_sifre.Text.ToString() + "',Tel='" + textb_telefon.Text.ToString() + "',Email='" + textb_mail.Text.ToString() + "',SoruID='" + Convert.ToInt32(cmb_güvenlik.SelectedValue) + "',CinsiyetID='" + Convert.ToInt32(cmb_cinsiyet.SelectedValue) + "',TipID='" + Convert.ToInt32(cmb_personal.SelectedValue) + "' where PersonalID=" + id + "", bagla);
                //komut4.ExecuteNonQuery();
                //bagla.Close();
                //temiz();
                bagla.Open();
                SqlCommand komut4 = new SqlCommand("Update Personal set Ad='" + textb_ad.Text.ToString() + "',Soyad='" + textb_soyad.Text.ToString() + "',Sifre='" + textb_sifre.Text.ToString() + "',Tel='" + textb_telefon.Text.ToString() + "',Email='" + textb_mail.Text.ToString() + "',SoruID='" + Convert.ToInt32(cmb_güvenlik.SelectedValue) + "',CinsiyetID='" + Convert.ToInt32(cmb_cinsiyet.SelectedValue) + "',TipID='" + Convert.ToInt32(cmb_personal.SelectedValue) + "' where PersonalID='" + dataGridView1.SelectedCells[0].Value.ToString
                    () + "' ", bagla);
                verigoster("goster_personal");
                komut4.ExecuteNonQuery();
                temiz();
                bagla.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Silme işlemi için ilk önce listeden bir ID seçmelisiniz");
            }

        }  
        private void button5_Click_1(object sender, EventArgs e)
        {
            Form2 geri = new Form2();
            geri.label2.Text = label1.Text;
            geri.label3.Text = label2.Text;
            geri.Show();
            this.Hide();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilialan = dataGridView1.SelectedCells[0].RowIndex;
            string ad = dataGridView1.Rows[secilialan].Cells[1].Value.ToString();
            string soyad = dataGridView1.Rows[secilialan].Cells[2].Value.ToString();
            string sifre = dataGridView1.Rows[secilialan].Cells[3].Value.ToString();
            string tel = dataGridView1.Rows[secilialan].Cells[4].Value.ToString();
            string mail = dataGridView1.Rows[secilialan].Cells[5].Value.ToString();
            string soru = dataGridView1.Rows[secilialan].Cells[6].Value.ToString();
            string cinsiyet = dataGridView1.Rows[secilialan].Cells[7].Value.ToString();
            string tip = dataGridView1.Rows[secilialan].Cells[8].Value.ToString();
            textb_ad.Text = ad;
            textb_soyad.Text = soyad;
            textb_sifre.Text = sifre;
            textb_telefon.Text = tel;
            textb_mail.Text = mail;
            cmb_güvenlik.Text = soru;
            cmb_cinsiyet.Text = cinsiyet;
            cmb_personal.Text=tip;

         
        }
    }
}
