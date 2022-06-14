
namespace OgrenciKayit
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
            this.BtnOgrtGiris = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.MskTxtBoxOgrtNum = new System.Windows.Forms.MaskedTextBox();
            this.TxtBoxOgrtSifre = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.BtnOgrGiris = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.MskTxtBoxOgrNum = new System.Windows.Forms.MaskedTextBox();
            this.TxtBoxOgrSifre = new System.Windows.Forms.TextBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.BtnOgrtGiris);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.MskTxtBoxOgrtNum);
            this.groupBox1.Controls.Add(this.TxtBoxOgrtSifre);
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(502, 206);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Öğretmen";
            // 
            // BtnOgrtGiris
            // 
            this.BtnOgrtGiris.Location = new System.Drawing.Point(255, 103);
            this.BtnOgrtGiris.Name = "BtnOgrtGiris";
            this.BtnOgrtGiris.Size = new System.Drawing.Size(100, 23);
            this.BtnOgrtGiris.TabIndex = 3;
            this.BtnOgrtGiris.Text = "Giriş Yap";
            this.BtnOgrtGiris.UseVisualStyleBackColor = true;
            this.BtnOgrtGiris.Click += new System.EventHandler(this.BtnOgrtGiris_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(218, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Şifre:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(202, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Numara:";
            // 
            // MskTxtBoxOgrtNum
            // 
            this.MskTxtBoxOgrtNum.Location = new System.Drawing.Point(255, 54);
            this.MskTxtBoxOgrtNum.Mask = "0000";
            this.MskTxtBoxOgrtNum.Name = "MskTxtBoxOgrtNum";
            this.MskTxtBoxOgrtNum.Size = new System.Drawing.Size(100, 20);
            this.MskTxtBoxOgrtNum.TabIndex = 1;
            this.MskTxtBoxOgrtNum.ValidatingType = typeof(int);
            // 
            // TxtBoxOgrtSifre
            // 
            this.TxtBoxOgrtSifre.Location = new System.Drawing.Point(255, 77);
            this.TxtBoxOgrtSifre.Name = "TxtBoxOgrtSifre";
            this.TxtBoxOgrtSifre.Size = new System.Drawing.Size(100, 20);
            this.TxtBoxOgrtSifre.TabIndex = 2;
            this.TxtBoxOgrtSifre.UseSystemPasswordChar = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(3, 16);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(157, 184);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.BtnOgrGiris);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.MskTxtBoxOgrNum);
            this.groupBox2.Controls.Add(this.TxtBoxOgrSifre);
            this.groupBox2.Controls.Add(this.pictureBox2);
            this.groupBox2.Location = new System.Drawing.Point(12, 224);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(502, 214);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Öğrenci";
            // 
            // BtnOgrGiris
            // 
            this.BtnOgrGiris.Location = new System.Drawing.Point(255, 109);
            this.BtnOgrGiris.Name = "BtnOgrGiris";
            this.BtnOgrGiris.Size = new System.Drawing.Size(100, 23);
            this.BtnOgrGiris.TabIndex = 6;
            this.BtnOgrGiris.Text = "Giriş Yap";
            this.BtnOgrGiris.UseVisualStyleBackColor = true;
            this.BtnOgrGiris.Click += new System.EventHandler(this.BtnOgrGiris_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(218, 86);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Şifre:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label3.Location = new System.Drawing.Point(202, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Numara:";
            // 
            // MskTxtBoxOgrNum
            // 
            this.MskTxtBoxOgrNum.Location = new System.Drawing.Point(255, 58);
            this.MskTxtBoxOgrNum.Mask = "0000";
            this.MskTxtBoxOgrNum.Name = "MskTxtBoxOgrNum";
            this.MskTxtBoxOgrNum.Size = new System.Drawing.Size(100, 20);
            this.MskTxtBoxOgrNum.TabIndex = 4;
            this.MskTxtBoxOgrNum.ValidatingType = typeof(int);
            // 
            // TxtBoxOgrSifre
            // 
            this.TxtBoxOgrSifre.Location = new System.Drawing.Point(255, 83);
            this.TxtBoxOgrSifre.Name = "TxtBoxOgrSifre";
            this.TxtBoxOgrSifre.Size = new System.Drawing.Size(100, 20);
            this.TxtBoxOgrSifre.TabIndex = 5;
            this.TxtBoxOgrSifre.UseSystemPasswordChar = true;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(6, 19);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(154, 189);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(526, 450);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Okul Giriş Sistemi";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MaskedTextBox MskTxtBoxOgrtNum;
        private System.Windows.Forms.TextBox TxtBoxOgrtSifre;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.MaskedTextBox MskTxtBoxOgrNum;
        private System.Windows.Forms.TextBox TxtBoxOgrSifre;
        private System.Windows.Forms.Button BtnOgrtGiris;
        private System.Windows.Forms.Button BtnOgrGiris;
    }
}

