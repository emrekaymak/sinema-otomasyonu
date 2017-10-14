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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }
        SqlConnection bagla = new SqlConnection("Data Source=DESKTOP-ONAIBD8;Initial Catalog=Sinema;Integrated Security=True");
        public void temiz()
        {
            verigoster("goster");          
            textb_ad.Clear();
            textb_soyad.Clear();
            textBox1.Clear();
            cmb_seans.ResetText();
            cmb_türü.ResetText();
            cmb_film.ResetText();
            cmb_koltuk.ResetText();
            cmb_salon.ResetText();
         }        
        private void CmbFilmTurDoldur()
        {
            string query = "Select TurID, TurAdı from Film_Tur";
            SqlDataAdapter da = new SqlDataAdapter(query, bagla);
            DataSet ds = new DataSet();
            da.Fill(ds, "TurAdı");
            cmb_türü.DisplayMember = "TurAdı";
            cmb_türü.ValueMember = "TurID";
            cmb_türü.DataSource = ds.Tables["TurAdı"];
        }    
        private void CmbSalonDoldur()
        {
            //string query = "Select SalonID, SalonAdı from Salon";
            //SqlDataAdapter da = new SqlDataAdapter(query, bagla);
            //DataSet ds = new DataSet();
            //da.Fill(ds, "SalonAdı");
            //cmb_salon.DisplayMember = "SalonAdı";
            //cmb_salon.ValueMember = "SalonID";
            //cmb_salon.DataSource = ds.Tables["SalonAdı"];

            string query = "Select id, salon from Film_Salon where film='" + cmb_film.Text.ToString() + "'order by salon";
            SqlDataAdapter da = new SqlDataAdapter(query, bagla);
            DataSet ds = new DataSet();
            da.Fill(ds, "salon");
            cmb_salon.DisplayMember = "salon";
            cmb_salon.ValueMember = "id";
            cmb_salon.DataSource = ds.Tables["salon"];
        }
        private void CmbKoltukDoldur()
        {
            string query = "Select KoltukID, KoltukYer from Koltuk";
            SqlDataAdapter da = new SqlDataAdapter(query, bagla);
            DataSet ds = new DataSet();
            da.Fill(ds, "KoltukYer");
            cmb_koltuk.DisplayMember = "KoltukYer";
            cmb_koltuk.ValueMember = "KoltukID";
            cmb_koltuk.DataSource = ds.Tables["KoltukYer"];
        }
        private void koltuk()
        {
            SqlConnection bağlantı = new SqlConnection("Data Source=DESKTOP-ONAIBD8;Initial Catalog=Sinema;Integrated Security=True");
            SqlCommand komut = new SqlCommand("Select * from bilet", bağlantı);
            bağlantı.Open();
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                if (dr["TurID"].ToString() == Convert.ToInt32(cmb_türü.SelectedValue).ToString())
                {
                    if (dr["SeansID"].ToString() == Convert.ToInt32(cmb_seans.SelectedValue).ToString())
                    {
                        if (dr["SalonID"].ToString() == Convert.ToInt32(cmb_salon.SelectedValue).ToString())
                        {
                            if (dr["KoltukID"].ToString() == "1") { btn_A1.BackColor = Color.DarkGray; }
                            if (dr["KoltukID"].ToString() == "2") { btn_A2.BackColor = Color.DarkGray; }
                            if (dr["KoltukID"].ToString() == "3") { btn_A3.BackColor = Color.DarkGray; }
                            if (dr["KoltukID"].ToString() == "4") { btn_A4.BackColor = Color.DarkGray; }
                            if (dr["KoltukID"].ToString() == "5") { btn_A5.BackColor = Color.DarkGray; }
                            if (dr["KoltukID"].ToString() == "6") { btn_B1.BackColor = Color.DarkGray; }
                            if (dr["KoltukID"].ToString() == "7") { btn_B2.BackColor = Color.DarkGray; }
                            if (dr["KoltukID"].ToString() == "8") { btn_B3.BackColor = Color.DarkGray; }
                            if (dr["KoltukID"].ToString() == "9") { btn_B4.BackColor = Color.DarkGray; }
                            if (dr["KoltukID"].ToString() == "10") { btn_B5.BackColor = Color.DarkGray; }
                            if (dr["KoltukID"].ToString() == "11") { btn_C1.BackColor = Color.DarkGray; }
                            if (dr["KoltukID"].ToString() == "12") { btn_C2.BackColor = Color.DarkGray; }
                            if (dr["KoltukID"].ToString() == "13") { btn_C3.BackColor = Color.DarkGray; }
                            if (dr["KoltukID"].ToString() == "14") { btn_C4.BackColor = Color.DarkGray; }
                            if (dr["KoltukID"].ToString() == "15") { btn_C5.BackColor = Color.DarkGray; }
                            if (dr["KoltukID"].ToString() == "16") { btn_D1.BackColor = Color.DarkGray; }
                            if (dr["KoltukID"].ToString() == "17") { btn_D2.BackColor = Color.DarkGray; }
                            if (dr["KoltukID"].ToString() == "18") { btn_D3.BackColor = Color.DarkGray; }
                            if (dr["KoltukID"].ToString() == "19") { btn_D4.BackColor = Color.DarkGray; }
                            if (dr["KoltukID"].ToString() == "20") { btn_D5.BackColor = Color.DarkGray; }
                            if (dr["KoltukID"].ToString() == "21") { btn_E1.BackColor = Color.DarkGray; }
                            if (dr["KoltukID"].ToString() == "22") { btn_E2.BackColor = Color.DarkGray; }
                            if (dr["KoltukID"].ToString() == "23") { btn_E3.BackColor = Color.DarkGray; }
                            if (dr["KoltukID"].ToString() == "24") { btn_E4.BackColor = Color.DarkGray; }
                            if (dr["KoltukID"].ToString() == "25") { btn_E5.BackColor = Color.DarkGray; }
                        }
                    }
                }
            }
            bağlantı.Close();
        }              
        private void verigoster(string veriler)
        {
            SqlDataAdapter da = new SqlDataAdapter(veriler, bagla);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];            
         }   
 
        private void Form6_Load(object sender, EventArgs e)
        {
            verigoster("goster");
            CmbFilmTurDoldur();
            CmbSalonDoldur();
            CmbKoltukDoldur();
            cmb_koltuk.Enabled = false;
        }

        // butonlar
        private void btn_kaydet_Click(object sender, EventArgs e)
        {
            try
            {
                bagla.Open();
                SqlCommand komut3 = new SqlCommand("Insert Into Bilet(Adı,Soyadı,Telefon,TurID,FilmID,SeansID,SalonID,KoltukID,BiletFiyat) values(@Adıi,@Soyadıi,@Telefoni,@TurIDi,@FilmIDi,@SeansIDi,@SalonIDi,@KoltukIDi,@BiletFiyati)", bagla);
                komut3.Parameters.AddWithValue("@adıi", textb_ad.Text);
                komut3.Parameters.AddWithValue("@Soyadıi", textb_soyad.Text);
                komut3.Parameters.AddWithValue("@Telefoni", textBox1.Text);
                komut3.Parameters.AddWithValue("@TurIDi", Convert.ToInt32(cmb_türü.SelectedValue));
                komut3.Parameters.AddWithValue("@FilmIDi", Convert.ToInt32(cmb_türü.SelectedValue));
                komut3.Parameters.AddWithValue("@SeansIDi", Convert.ToInt32(cmb_seans.SelectedValue));
                komut3.Parameters.AddWithValue("@SalonIDi", Convert.ToInt32(cmb_salon.SelectedValue));
                komut3.Parameters.AddWithValue("@KoltukIDi", Convert.ToInt32(cmb_koltuk.SelectedValue));
                if (radioButton1.Checked == true)
                { komut3.Parameters.AddWithValue("@BiletFiyati", radioButton1.Text.ToString()); }
                else { komut3.Parameters.AddWithValue("@BiletFiyati", radioButton2.Text.ToString()); }
             
                komut3.ExecuteNonQuery();
                verigoster("goster");
                bagla.Close();
                temiz();
            }
            catch
            {
                MessageBox.Show("1)Yanlış Biçimde Yazdığın Birşeyler Var.\n\n 2) ID Dolu olduğuna ve Farklı Olmasına Dikkat Et");
            }
        }
        private void btn_sil_Click(object sender, EventArgs e)
        {
            try
            {
                bagla.Open();
                SqlCommand komut3 = new SqlCommand("delete from Bilet where BiletID=@adi", bagla);
                komut3.Parameters.AddWithValue("@adi", dataGridView1.SelectedCells[0].Value.ToString());
                komut3.ExecuteNonQuery();
                verigoster("goster");
                temiz();
                bagla.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Silme işlemi için ilk önce listeden bir ID seçmelisiniz");
            }
        }
        private void btn_düzelt_Click(object sender, EventArgs e)
        {
            try
            {
                bagla.Open();
                SqlCommand komut4 = new SqlCommand("update Bilet set Adı='" + textb_ad.Text.ToString() + "',Soyadı='" + textb_soyad.Text.ToString() + "',Telefon='" + textBox1.Text.ToString() + "',TurID='" + Convert.ToInt32(cmb_türü.SelectedValue) + "',FilmID='" + Convert.ToInt32(cmb_film.SelectedValue) + "',SeansID='" + Convert.ToInt32(cmb_seans.SelectedValue) + "',SalonID='" + Convert.ToInt32(cmb_salon.SelectedValue) + "',KoltukID='" + Convert.ToInt32(cmb_koltuk.SelectedValue) + "' where BiletID='" + dataGridView1.SelectedCells[0].Value.ToString() + "' ", bagla);
                verigoster("goster");
                komut4.ExecuteNonQuery();
                bagla.Close();
                temiz();
            }
            catch (Exception)
            {
                MessageBox.Show("Silme işlemi için ilk önce listeden bir ID seçmelisiniz");
            }
        }
        private void btn_geri_Click(object sender, EventArgs e)
        {
            Form2 geri = new Form2();
            geri.label2.Text = label17.Text;
            geri.label3.Text = label18.Text;
            geri.Show();
            this.Hide();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Form5 yazdır = new Form5();
            yazdır.Show();
            this.Hide();
        }

        int sayı1 = 0; int sayı2 = 0; int sayı3 = 0; int sayı4 = 0; int sayı5 = 0; int sayı6 = 0; int sayı7 = 0; int sayı8 = 0; int sayı9 = 0; int sayı10 = 0; int sayı11 = 0; int sayı12 = 0; int sayı13 = 0; int sayı14 = 0; int sayı15 = 0; int sayı16 = 0; int sayı17 = 0; int sayı18 = 0; int sayı19 = 0; int sayı20 = 0; int sayı21 = 0; int sayı22 = 0; int sayı23 = 0; int sayı24 = 0; int sayı25 = 0;int filmadet = 0;

        //koltuk yerleri
        private void btn_A1_Click(object sender, EventArgs e)
        {
           sayı1++;
            if (sayı1 % 2 == 1)
            {
                filmadet++;
                if (filmadet <= 1)
                {
                    btn_A1.BackColor = Color.DarkGray;                 
                    cmb_koltuk.Text = btn_A1.Text;
                }
                else
                { MessageBox.Show("En Fazla 1 Bilet Seçilebilir !!!"); }
            }
                if (sayı1 % 2 == 0)
                {
                    DialogResult soru;
                    soru = MessageBox.Show(btn_A1.Text + "koltuğu bırakmak istediğinize emin misiniz?", "Uyarı",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (soru == DialogResult.Yes)
                        btn_A1.BackColor = Color.Lime;
                    filmadet--;                    
                }          
        }
        private void btn_A2_Click(object sender, EventArgs e)
        {
           sayı2++;
            if (sayı2 % 2 == 1)
            {
                filmadet++;
                if(filmadet<= 1)
                { 
                btn_A2.BackColor = Color.DarkGray;
                 cmb_koltuk.Text = btn_A2.Text;
                }
                else
                {MessageBox.Show("En Fazla 1 Bilet Seçilebilir !!!");   }
            }
            if (sayı2 % 2 == 0)
            {
                DialogResult soru;
                soru = MessageBox.Show(btn_A2.Text + "koltuğu bırakmak istediğinize emin misiniz?", "Uyarı",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (soru == DialogResult.Yes)
                    btn_A2.BackColor = Color.Lime;
                filmadet--;  
           }
        }
        private void btn_A3_Click(object sender, EventArgs e)
        {
            sayı3++;
            if (sayı3 % 2 == 1)
            {
                filmadet++;
                if(filmadet<= 1)
                { 
                btn_A3.BackColor = Color.DarkGray;                
                cmb_koltuk.Text = btn_A3.Text;
                }
                else
                {MessageBox.Show("En Fazla 1 Bilet Seçilebilir !!!");}
            }
            if (sayı3 % 2 == 0)
            {
                DialogResult soru;
                soru = MessageBox.Show(btn_A3.Text + "koltuğu bırakmak istediğinize emin misiniz?", "Uyarı",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (soru == DialogResult.Yes)
                    btn_A3.BackColor = Color.Lime;
                filmadet--;
            }
        }
        private void btn_A4_Click_1(object sender, EventArgs e)
        {
            sayı4++;
            if (sayı4 % 2 == 1)
            {
                filmadet++;
                if(filmadet<=1)
                { 
                btn_A4.BackColor = Color.DarkGray;               
                cmb_koltuk.Text = btn_A4.Text;
                }
                else
                {MessageBox.Show("En Fazla 1 Bilet Seçilebilir !!!");}
            }
            if (sayı4 % 2 == 0)
            {
                DialogResult soru;
                soru = MessageBox.Show(btn_A4.Text + "koltuğu bırakmak istediğinize emin misiniz?", "Uyarı",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (soru == DialogResult.Yes)
                    btn_A4.BackColor = Color.Lime;
                filmadet--;               
            }
        }
        private void btn_A5_Click(object sender, EventArgs e)
        {
            sayı5++;
            if (sayı5 % 2 == 1)
            {
                filmadet++;
                if(filmadet<=1)
                { 
                btn_A5.BackColor = Color.DarkGray;                
                cmb_koltuk.Text = btn_A5.Text;
                }
                else
                {MessageBox.Show("En Fazla 1 Bilet Seçilebilir !!!");}
            }
            if (sayı5 % 2 == 0)
            {
                DialogResult soru;
                soru = MessageBox.Show(btn_A5.Text + "koltuğu bırakmak istediğinize emin misiniz?", "Uyarı",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (soru == DialogResult.Yes)
                    btn_A5.BackColor = Color.Lime;
                filmadet--;          
            }
        }

        private void btn_B1_Click(object sender, EventArgs e)
        {
            sayı6++;
            if (sayı6 % 2 == 1)
            {
                filmadet++;
                if(filmadet<=1)
                { 
                btn_B1.BackColor = Color.DarkGray;               
                cmb_koltuk.Text = btn_B1.Text;
                }
                else
                {MessageBox.Show("En Fazla 1 Bilet Seçilebilir !!!");}
            }
            if (sayı6 % 2 == 0)
            {
                DialogResult soru;
                soru = MessageBox.Show(btn_B1.Text + "koltuğu bırakmak istediğinize emin misiniz?", "Uyarı",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (soru == DialogResult.Yes)
                    btn_B1.BackColor = Color.Lime;
                filmadet--;              
            }
        }
        private void btn_B2_Click(object sender, EventArgs e)
        {
            sayı7++;
            if (sayı7 % 2 == 1)
            {
                filmadet++;
                if(filmadet<=1)
                { 
                btn_B2.BackColor = Color.DarkGray;                
                cmb_koltuk.Text = btn_B2.Text;
                }
                else
                {MessageBox.Show("En Fazla 1 Bilet Seçilebilir !!!");}
            }
            if (sayı7 % 2 == 0)
            {
                DialogResult soru;
                soru = MessageBox.Show(btn_B2.Text + "koltuğu bırakmak istediğinize emin misiniz?", "Uyarı",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (soru == DialogResult.Yes)
                    btn_B2.BackColor = Color.Lime;
                filmadet--;               
            }
        }
        private void btn_B3_Click(object sender, EventArgs e)
        {
            sayı8++;
            if (sayı8 % 2 == 1)
            {
                filmadet++;
                if(filmadet<=1)
                { 
                btn_B3.BackColor = Color.DarkGray;                
                cmb_koltuk.Text = btn_B3.Text;
                }
                else
                {MessageBox.Show("En Fazla 1 Bilet Seçilebilir !!!");}


            }
            if (sayı8 % 2 == 0)
            {
                DialogResult soru;
                soru = MessageBox.Show(btn_B3.Text + "koltuğu bırakmak istediğinize emin misiniz?", "Uyarı",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (soru == DialogResult.Yes)
                    btn_B3.BackColor = Color.Lime;
                filmadet--;               
            }
        }
        private void btn_B4_Click(object sender, EventArgs e)
        {
            sayı9++;
            if (sayı9 % 2 == 1)
            {
                filmadet++;
                if(filmadet<=1)
                {
                btn_B4.BackColor = Color.DarkGray;               
                cmb_koltuk.Text = btn_B4.Text;
                }
                else
                {MessageBox.Show("En Fazla 1 Bilet Seçilebilir !!!");}


            }
            if (sayı9 % 2 == 0)
            {
                DialogResult soru;
                soru = MessageBox.Show(btn_B4.Text + "koltuğu bırakmak istediğinize emin misiniz?", "Uyarı",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (soru == DialogResult.Yes)
                    btn_B4.BackColor = Color.Lime;
                filmadet--;              
            }
        }
        private void btn_B5_Click(object sender, EventArgs e)
        {
            sayı10++;
            if (sayı10 % 2 == 1)
            {
                filmadet++;
                if(filmadet<=1)
                { 
                btn_B5.BackColor = Color.DarkGray;            
                cmb_koltuk.Text = btn_B5.Text;
                }
                else
                {MessageBox.Show("En Fazla 1 Bilet Seçilebilir !!!");}


            }
            if (sayı10 % 2 == 0)
            {
                DialogResult soru;
                soru = MessageBox.Show(btn_B5.Text + "koltuğu bırakmak istediğinize emin misiniz?", "Uyarı",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (soru == DialogResult.Yes)
                    btn_B5.BackColor = Color.Lime;
                filmadet--;              
            }
        }

        private void btn_C1_Click(object sender, EventArgs e)
        {
            sayı11++;
            if (sayı11 % 2 == 1)
            {
                filmadet++;
                if(filmadet<=1)
                { 
                btn_C1.BackColor = Color.DarkGray;               
                cmb_koltuk.Text = btn_C1.Text;
                }
                else
                {MessageBox.Show("En Fazla 1 Bilet Seçilebilir !!!");}


            }
            if (sayı11 % 2 == 0)
            {
                DialogResult soru;
                soru = MessageBox.Show(btn_C1.Text + "koltuğu bırakmak istediğinize emin misiniz?", "Uyarı",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (soru == DialogResult.Yes)
                    btn_C1.BackColor = Color.Lime;
                filmadet--;               
            }
        }
        private void btn_C2_Click(object sender, EventArgs e)
        {
            sayı12++;
            if (sayı12 % 2 == 1)
            {
                filmadet++;
                if (filmadet <= 1)
                {
                    btn_C2.BackColor = Color.DarkGray;                  
                    cmb_koltuk.Text = btn_C2.Text;
                }
                else
                {
                    MessageBox.Show("En Fazla 1 Bilet Seçilebilir !!!");
                }
            }
            if (sayı12 % 2 == 0)
            {
                DialogResult soru;
                soru = MessageBox.Show(btn_C2.Text + "koltuğu bırakmak istediğinize emin misiniz?", "Uyarı",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (soru == DialogResult.Yes)
                    btn_C2.BackColor = Color.Lime;
                filmadet--;               
            }
        }
        private void btn_C3_Click(object sender, EventArgs e)
        {
            sayı13++;
            if (sayı13 % 2 == 1)
            {
                filmadet++;
                if (filmadet <= 1)
                {
                    btn_C3.BackColor = Color.DarkGray;                    
                    cmb_koltuk.Text = btn_C3.Text;
                }
                else
                { MessageBox.Show("En Fazla 1 Bilet Seçilebilir !!!");  }
            }
            if (sayı13 % 2 == 0)
            {
                DialogResult soru;
                soru = MessageBox.Show(btn_C3.Text + "koltuğu bırakmak istediğinize emin misiniz?", "Uyarı",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (soru == DialogResult.Yes)
                    btn_C3.BackColor = Color.Lime;
                filmadet--;               
            }
        }
        private void btn_C4_Click(object sender, EventArgs e)
        {
            sayı14++;
            if (sayı14 % 2 == 1)
            {
                filmadet++;
                if(filmadet<=1)
                { 
                btn_C4.BackColor = Color.DarkGray;               
                cmb_koltuk.Text = btn_C4.Text;
                }
                else
                { MessageBox.Show("En Fazla 1 Bilet Seçilebilir !!!"); }
            }
            if (sayı14 % 2 == 0)
            {
                DialogResult soru;
                soru = MessageBox.Show(btn_C4.Text + "koltuğu bırakmak istediğinize emin misiniz?", "Uyarı",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (soru == DialogResult.Yes)
                    btn_C4.BackColor = Color.Lime;
                filmadet--;               
            }
        }
        private void btn_C5_Click(object sender, EventArgs e)
        {
            sayı15++;
            if (sayı15 % 2 == 1)
            {
                filmadet++;
                if(filmadet<=1)
                { 
                btn_C5.BackColor = Color.DarkGray;                
                cmb_koltuk.Text = btn_C5.Text;
                }
                else{MessageBox.Show("En Fazla 1 Bilet Seçilebilir !!!");}
            }
            if (sayı15 % 2 == 0)
            {
                DialogResult soru;
                soru = MessageBox.Show(btn_C5.Text + "koltuğu bırakmak istediğinize emin misiniz?", "Uyarı",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (soru == DialogResult.Yes)
                    btn_C5.BackColor = Color.Lime;
                filmadet--;               
            }
        }

        private void btn_D1_Click(object sender, EventArgs e)
        {
            sayı16++;
            if (sayı16 % 2 == 1)
            {
                filmadet++;
                if(filmadet<=1)
                { 
                btn_D1.BackColor = Color.DarkGray;              
                cmb_koltuk.Text = btn_D1.Text;
                }
                else
                { MessageBox.Show("En Fazla 1 Bilet Seçilebilir !!!");  }
            }
            if (sayı16 % 2 == 0)
            {
                DialogResult soru;
                soru = MessageBox.Show(btn_D1.Text + "koltuğu bırakmak istediğinize emin misiniz?", "Uyarı",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (soru == DialogResult.Yes)
                    btn_D1.BackColor = Color.Lime;
                filmadet--;                
            }
        }
        private void btn_D2_Click(object sender, EventArgs e)
        {
            sayı17++;
            if (sayı17 % 2 == 1)
            {
                filmadet++;
                if(filmadet<=1)
                { 
                btn_D2.BackColor = Color.DarkGray;               
                cmb_koltuk.Text = btn_D2.Text;
                }
                else
                { MessageBox.Show("En Fazla 1 Bilet Seçilebilir !!!");  }
            }
            if (sayı17 % 2 == 0)
            {
                DialogResult soru;
                soru = MessageBox.Show(btn_D2.Text + "koltuğu bırakmak istediğinize emin misiniz?", "Uyarı",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (soru == DialogResult.Yes)
                    btn_D2.BackColor = Color.Lime;
                filmadet--;               
            }
        }
        private void btn_D3_Click(object sender, EventArgs e)
        {
            sayı18++;
            if (sayı18 % 2 == 1)
            {
                filmadet++;
                if(filmadet<=1)
                { 
                btn_D3.BackColor = Color.DarkGray;        
                cmb_koltuk.Text = btn_D3.Text;
                }
                else
                {MessageBox.Show("En Fazla 1 Bilet Seçilebilir !!!");}
            }
            if (sayı18 % 2 == 0)
            {
                DialogResult soru;
                soru = MessageBox.Show(btn_D3.Text + "koltuğu bırakmak istediğinize emin misiniz?", "Uyarı",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (soru == DialogResult.Yes)
                    btn_D3.BackColor = Color.Lime;
                filmadet--;               
            }
        }
        private void btn_D4_Click(object sender, EventArgs e)
        {
            sayı19++;
            if (sayı19 % 2 == 1)
            {
                filmadet++;
                if(filmadet<=1)
                { 
                btn_D4.BackColor = Color.DarkGray;               
                cmb_koltuk.Text = btn_D4.Text;
                }
                else
                { MessageBox.Show("En Fazla 1 Bilet Seçilebilir !!!"); }            

            }
            if (sayı19 % 2 == 0)
            {
                DialogResult soru;
                soru = MessageBox.Show(btn_D4.Text + "koltuğu bırakmak istediğinize emin misiniz?", "Uyarı",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (soru == DialogResult.Yes)
                    btn_D4.BackColor = Color.Lime;
                filmadet--;                
            }
        }
        private void btn_D5_Click(object sender, EventArgs e)
        {
            sayı20++;
            if (sayı20 % 2 == 1)
            {
                filmadet++;
                if(filmadet<=1)
                { 
                btn_D5.BackColor = Color.DarkGray;                
                cmb_koltuk.Text = btn_D5.Text;
                }
                else
                {  MessageBox.Show("En Fazla 1 Bilet Seçilebilir !!!");    }
            }
            if (sayı20 % 2 == 0)
            {
                DialogResult soru;
                soru = MessageBox.Show(btn_D5.Text + "koltuğu bırakmak istediğinize emin misiniz?", "Uyarı",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (soru == DialogResult.Yes)
                    btn_D5.BackColor= Color.Lime;
                filmadet--;
            }
        }

        private void btn_E1_Click(object sender, EventArgs e)
        {
            sayı21++;
            if (sayı21 % 2 == 1)
            {
                filmadet++;
                if(filmadet<=1)
                {
                btn_E1.BackColor = Color.DarkGray;                
                cmb_koltuk.Text = btn_E1.Text;
                }
                else
                {  MessageBox.Show("En Fazla 1 Bilet Seçilebilir !!!");  }
            }
            if (sayı21 % 2 == 0)
            {
                DialogResult soru;
                soru = MessageBox.Show(btn_E1.Text + "koltuğu bırakmak istediğinize emin misiniz?", "Uyarı",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (soru == DialogResult.Yes)
                    btn_E1.BackColor = Color.Lime;
                filmadet--;             
            }
        }
        private void btn_E2_Click(object sender, EventArgs e)
        {
            sayı22++;
            if (sayı22 % 2 == 1)
            {
                filmadet++;
                if(filmadet<=1)
                { 
                btn_E2.BackColor = Color.DarkGray;                
                cmb_koltuk.Text = btn_E2.Text;
                }
                else
                {      MessageBox.Show("En Fazla 1 Bilet Seçilebilir !!!");     }
            }
            if (sayı22 % 2 == 0)
            {
                DialogResult soru;
                soru = MessageBox.Show(btn_E2.Text + "koltuğu bırakmak istediğinize emin misiniz?", "Uyarı",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (soru == DialogResult.Yes)
                    btn_E2.BackColor = Color.Lime;
                filmadet--;             
            }
        }
        private void btn_E3_Click(object sender, EventArgs e)
        {
            sayı23++;
            if (sayı23 % 2 == 1)
            {
                filmadet++;
                if(filmadet<=1)
                { 
                btn_E3.BackColor = Color.DarkGray;                
                cmb_koltuk.Text = btn_E3.Text;
                }
                else
                {      MessageBox.Show("En Fazla 1 Bilet Seçilebilir !!!");     }
            }
            if (sayı23 % 2 == 0)
            {
                DialogResult soru;
                soru = MessageBox.Show(btn_E3.Text + "koltuğu bırakmak istediğinize emin misiniz?", "Uyarı",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (soru == DialogResult.Yes)
                    btn_E3.BackColor = Color.Lime;
                filmadet--;               
            }
        }
        private void btn_E4_Click(object sender, EventArgs e)
        {
            sayı24++;
            if (sayı24 % 2 == 1)
            {
                filmadet++;
                if(filmadet <=1)
                { 
                btn_E4.BackColor = Color.DarkGray;
                cmb_koltuk.Text = btn_E4.Text;
                }
                else
                {     MessageBox.Show("En Fazla 1 Bilet Seçilebilir !!!");           }
            }
            if (sayı24 % 2 == 0)
            {
                DialogResult soru;
                soru = MessageBox.Show(btn_E4.Text + "koltuğu bırakmak istediğinize emin misiniz?", "Uyarı",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (soru == DialogResult.Yes)
                    btn_E4.BackColor = Color.Lime;
                filmadet--;               
            }
        }
        private void btn_E5_Click(object sender, EventArgs e)
        {
            sayı25++;
            if (sayı25 % 2 == 1)
            {
                filmadet++;
                if(filmadet<=1)
                { 
                btn_E5.BackColor = Color.DarkGray;              
                cmb_koltuk.Text = btn_E5.Text;
                }
                else
                {           MessageBox.Show("En Fazla 1 Bilet Seçilebilir !!!"); }
            }
            if (sayı25 % 2 == 0)
            {
                DialogResult soru;
                soru = MessageBox.Show(btn_E4.Text + "koltuğu bırakmak istediğinize emin misiniz?", "Uyarı",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (soru == DialogResult.Yes)
                    btn_E5.BackColor = Color.Lime;
                filmadet--;                
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilialan = dataGridView1.SelectedCells[0].RowIndex;
            string ad = dataGridView1.Rows[secilialan].Cells[1].Value.ToString();
            string soyad = dataGridView1.Rows[secilialan].Cells[2].Value.ToString();
            string telefon = dataGridView1.Rows[secilialan].Cells[3].Value.ToString();
            string tur = dataGridView1.Rows[secilialan].Cells[4].Value.ToString();
            string film = dataGridView1.Rows[secilialan].Cells[5].Value.ToString();
            string seans = dataGridView1.Rows[secilialan].Cells[6].Value.ToString();
            string salon = dataGridView1.Rows[secilialan].Cells[7].Value.ToString();
            string koltuk = dataGridView1.Rows[secilialan].Cells[8].Value.ToString();
            textb_ad.Text = ad;
            textb_soyad.Text = soyad;
            textBox1.Text = telefon;
            cmb_türü.Text = tur;
            cmb_film.Text = film;
            cmb_seans.Text = seans;
            cmb_salon.Text = salon;
            cmb_koltuk.Text = koltuk;
        }

        private void cmb_türü_SelectedIndexChanged(object sender, EventArgs e)
        {
            string query = "Select FilmID, FilmAdı from Film where TurID='" + Convert.ToInt32(cmb_türü.SelectedValue) + "'";
            SqlDataAdapter da = new SqlDataAdapter(query, bagla);
            DataSet ds = new DataSet();
            da.Fill(ds, "FilmAdı");
            cmb_film.DisplayMember = "FilmAdı";
            cmb_film.ValueMember = "FilmID";
            cmb_film.DataSource = ds.Tables["FilmAdı"];
            koltuk();
         }
        private void cmb_film_SelectedIndexChanged(object sender, EventArgs e)
        {
            string query = "Select SeansID, Seans from Seans where SeansID='"+Convert.ToInt32(cmb_film.SelectedValue)+"'";
            SqlDataAdapter da = new SqlDataAdapter(query, bagla);
            DataSet ds = new DataSet();
            da.Fill(ds, "Seans");
            cmb_seans.DisplayMember = "Seans";
            cmb_seans.ValueMember = "SeansID";
            cmb_seans.DataSource = ds.Tables["Seans"];
            koltuk();
        }
        private void cmb_seans_SelectedIndexChanged(object sender, EventArgs e)
        {
            btn_A1.BackColor = Color.Lime; btn_A2.BackColor = Color.Lime; btn_A3.BackColor = Color.Lime; btn_A4.BackColor = Color.Lime; btn_A5.BackColor = Color.Lime; ; btn_B1.BackColor = Color.Lime; btn_B2.BackColor = Color.Lime; btn_B3.BackColor = Color.Lime; btn_B4.BackColor = Color.Lime; btn_B5.BackColor = Color.Lime; btn_C1.BackColor = Color.Lime; btn_C2.BackColor = Color.Lime; btn_C3.BackColor = Color.Lime; btn_C4.BackColor = Color.Lime; btn_C5.BackColor = Color.Lime; btn_D1.BackColor = Color.Lime; btn_D2.BackColor = Color.Lime; btn_D3.BackColor = Color.Lime; btn_D4.BackColor = Color.Lime; btn_D5.BackColor = Color.Lime; btn_E1.BackColor = Color.Lime; btn_E2.BackColor = Color.Lime; btn_E3.BackColor = Color.Lime; btn_E4.BackColor = Color.Lime; btn_E5.BackColor = Color.Lime;
            koltuk();

        }
        private void cmb_salon_SelectedIndexChanged(object sender, EventArgs e)
        {
            btn_A1.BackColor = Color.Lime; btn_A2.BackColor = Color.Lime; btn_A3.BackColor = Color.Lime; btn_A4.BackColor = Color.Lime; btn_A5.BackColor = Color.Lime; ; btn_B1.BackColor = Color.Lime; btn_B2.BackColor = Color.Lime; btn_B3.BackColor = Color.Lime; btn_B4.BackColor = Color.Lime; btn_B5.BackColor = Color.Lime; btn_C1.BackColor = Color.Lime; btn_C2.BackColor = Color.Lime; btn_C3.BackColor = Color.Lime; btn_C4.BackColor = Color.Lime; btn_C5.BackColor = Color.Lime; btn_D1.BackColor = Color.Lime; btn_D2.BackColor = Color.Lime; btn_D3.BackColor = Color.Lime; btn_D4.BackColor = Color.Lime; btn_D5.BackColor = Color.Lime; btn_E1.BackColor = Color.Lime; btn_E2.BackColor = Color.Lime; btn_E3.BackColor = Color.Lime; btn_E4.BackColor = Color.Lime; btn_E5.BackColor = Color.Lime;
            koltuk();
        }
    }
}
