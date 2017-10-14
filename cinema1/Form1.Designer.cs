namespace cinema1
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_cıkıs = new System.Windows.Forms.Button();
            this.btn_giris = new System.Windows.Forms.Button();
            this.textb_sifre = new System.Windows.Forms.TextBox();
            this.lbl_sifre = new System.Windows.Forms.Label();
            this.textb_ad = new System.Windows.Forms.TextBox();
            this.lbl_ad = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.ForestGreen;
            this.groupBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.groupBox1.Controls.Add(this.btn_cıkıs);
            this.groupBox1.Controls.Add(this.btn_giris);
            this.groupBox1.Controls.Add(this.textb_sifre);
            this.groupBox1.Controls.Add(this.lbl_sifre);
            this.groupBox1.Controls.Add(this.textb_ad);
            this.groupBox1.Controls.Add(this.lbl_ad);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.groupBox1.Location = new System.Drawing.Point(111, 53);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(317, 169);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Personal Girişi";
            // 
            // btn_cıkıs
            // 
            this.btn_cıkıs.BackColor = System.Drawing.Color.Red;
            this.btn_cıkıs.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_cıkıs.Location = new System.Drawing.Point(170, 126);
            this.btn_cıkıs.Name = "btn_cıkıs";
            this.btn_cıkıs.Size = new System.Drawing.Size(83, 37);
            this.btn_cıkıs.TabIndex = 5;
            this.btn_cıkıs.Text = "ÇIKIŞ";
            this.btn_cıkıs.UseVisualStyleBackColor = false;
            this.btn_cıkıs.Click += new System.EventHandler(this.button2_Click);
            // 
            // btn_giris
            // 
            this.btn_giris.BackColor = System.Drawing.Color.MediumTurquoise;
            this.btn_giris.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_giris.Location = new System.Drawing.Point(57, 126);
            this.btn_giris.Name = "btn_giris";
            this.btn_giris.Size = new System.Drawing.Size(83, 37);
            this.btn_giris.TabIndex = 4;
            this.btn_giris.Text = "GİRİŞ";
            this.btn_giris.UseVisualStyleBackColor = false;
            this.btn_giris.Click += new System.EventHandler(this.button1_Click);
            // 
            // textb_sifre
            // 
            this.textb_sifre.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textb_sifre.Location = new System.Drawing.Point(153, 80);
            this.textb_sifre.Name = "textb_sifre";
            this.textb_sifre.Size = new System.Drawing.Size(100, 23);
            this.textb_sifre.TabIndex = 3;
            this.textb_sifre.Text = "12";
            // 
            // lbl_sifre
            // 
            this.lbl_sifre.AutoSize = true;
            this.lbl_sifre.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbl_sifre.Location = new System.Drawing.Point(38, 80);
            this.lbl_sifre.Name = "lbl_sifre";
            this.lbl_sifre.Size = new System.Drawing.Size(47, 17);
            this.lbl_sifre.TabIndex = 2;
            this.lbl_sifre.Text = "Şifre:";
            // 
            // textb_ad
            // 
            this.textb_ad.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textb_ad.Location = new System.Drawing.Point(153, 38);
            this.textb_ad.Name = "textb_ad";
            this.textb_ad.Size = new System.Drawing.Size(100, 23);
            this.textb_ad.TabIndex = 1;
            this.textb_ad.Text = "emre";
            // 
            // lbl_ad
            // 
            this.lbl_ad.AutoSize = true;
            this.lbl_ad.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbl_ad.Location = new System.Drawing.Point(38, 44);
            this.lbl_ad.Name = "lbl_ad";
            this.lbl_ad.Size = new System.Drawing.Size(107, 17);
            this.lbl_ad.TabIndex = 0;
            this.lbl_ad.Text = " Kullanıcı Adı:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(533, 329);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_giris;
        private System.Windows.Forms.TextBox textb_sifre;
        private System.Windows.Forms.Label lbl_sifre;
        private System.Windows.Forms.TextBox textb_ad;
        private System.Windows.Forms.Label lbl_ad;
        private System.Windows.Forms.Button btn_cıkıs;
    }
}

