namespace security_program
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
            this.btn_Encrypt = new System.Windows.Forms.Button();
            this.btn_Decrypt = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.btnclear = new System.Windows.Forms.Button();
            this.btnthoat = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtKetQua = new System.Windows.Forms.RichTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnchoose = new System.Windows.Forms.Button();
            this.btnopenkey = new System.Windows.Forms.Button();
            this.txt_anpha = new System.Windows.Forms.TextBox();
            this.txt_Xb = new System.Windows.Forms.TextBox();
            this.txt_Xa = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txt_e = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_q = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_p = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label = new System.Windows.Forms.Label();
            this.txtkey = new System.Windows.Forms.TextBox();
            this.rtxtbanma = new System.Windows.Forms.RichTextBox();
            this.rtxtbanro = new System.Windows.Forms.RichTextBox();
            this.cipher_type = new System.Windows.Forms.ComboBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.btntinhkhoabm = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_Encrypt
            // 
            this.btn_Encrypt.BackColor = System.Drawing.Color.Maroon;
            this.btn_Encrypt.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Encrypt.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_Encrypt.Location = new System.Drawing.Point(144, 627);
            this.btn_Encrypt.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Encrypt.Name = "btn_Encrypt";
            this.btn_Encrypt.Size = new System.Drawing.Size(167, 45);
            this.btn_Encrypt.TabIndex = 1;
            this.btn_Encrypt.Text = "Encryption";
            this.btn_Encrypt.UseVisualStyleBackColor = false;
            this.btn_Encrypt.Click += new System.EventHandler(this.encryption_Click);
            // 
            // btn_Decrypt
            // 
            this.btn_Decrypt.BackColor = System.Drawing.Color.Maroon;
            this.btn_Decrypt.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Decrypt.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_Decrypt.Location = new System.Drawing.Point(341, 629);
            this.btn_Decrypt.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Decrypt.Name = "btn_Decrypt";
            this.btn_Decrypt.Size = new System.Drawing.Size(166, 43);
            this.btn_Decrypt.TabIndex = 2;
            this.btn_Decrypt.Text = "Decryption";
            this.btn_Decrypt.UseVisualStyleBackColor = false;
            this.btn_Decrypt.Click += new System.EventHandler(this.Decryption_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label4);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1351, 61);
            this.panel1.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label4.Location = new System.Drawing.Point(351, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(641, 31);
            this.label4.TabIndex = 0;
            this.label4.Text = "CÁC THUẬT TOÁN MÃ HÓA - GIẢI MÃ CƠ BẢN";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnclear
            // 
            this.btnclear.BackColor = System.Drawing.Color.Gray;
            this.btnclear.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnclear.ForeColor = System.Drawing.Color.Yellow;
            this.btnclear.Location = new System.Drawing.Point(506, 25);
            this.btnclear.Name = "btnclear";
            this.btnclear.Size = new System.Drawing.Size(117, 35);
            this.btnclear.TabIndex = 14;
            this.btnclear.Text = "Clear";
            this.btnclear.UseVisualStyleBackColor = false;
            this.btnclear.Click += new System.EventHandler(this.btnclear_Click);
            // 
            // btnthoat
            // 
            this.btnthoat.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnthoat.Location = new System.Drawing.Point(1201, 637);
            this.btnthoat.Name = "btnthoat";
            this.btnthoat.Size = new System.Drawing.Size(113, 35);
            this.btnthoat.TabIndex = 14;
            this.btnthoat.Text = "Thoát";
            this.btnthoat.UseVisualStyleBackColor = true;
            this.btnthoat.Click += new System.EventHandler(this.button4_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.AutoSize = true;
            this.groupBox2.BackColor = System.Drawing.Color.Lavender;
            this.groupBox2.Controls.Add(this.txtKetQua);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(662, 63);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(9, 4, 4, 4);
            this.groupBox2.Size = new System.Drawing.Size(652, 555);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Output";
            // 
            // txtKetQua
            // 
            this.txtKetQua.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtKetQua.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtKetQua.Location = new System.Drawing.Point(9, 23);
            this.txtKetQua.Margin = new System.Windows.Forms.Padding(3, 2, 8, 2);
            this.txtKetQua.Name = "txtKetQua";
            this.txtKetQua.Size = new System.Drawing.Size(639, 528);
            this.txtKetQua.TabIndex = 0;
            this.txtKetQua.Text = "";
            // 
            // groupBox1
            // 
            this.groupBox1.AutoSize = true;
            this.groupBox1.BackColor = System.Drawing.Color.Lavender;
            this.groupBox1.Controls.Add(this.btnchoose);
            this.groupBox1.Controls.Add(this.btnopenkey);
            this.groupBox1.Controls.Add(this.txt_anpha);
            this.groupBox1.Controls.Add(this.txt_Xb);
            this.groupBox1.Controls.Add(this.txt_Xa);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.txt_e);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.btnclear);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txt_q);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txt_p);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label);
            this.groupBox1.Controls.Add(this.txtkey);
            this.groupBox1.Controls.Add(this.rtxtbanma);
            this.groupBox1.Controls.Add(this.rtxtbanro);
            this.groupBox1.Controls.Add(this.cipher_type);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 63);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(9, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(642, 555);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Input";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // btnchoose
            // 
            this.btnchoose.BackColor = System.Drawing.Color.Gray;
            this.btnchoose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnchoose.ForeColor = System.Drawing.Color.Yellow;
            this.btnchoose.Location = new System.Drawing.Point(506, 80);
            this.btnchoose.Name = "btnchoose";
            this.btnchoose.Size = new System.Drawing.Size(117, 44);
            this.btnchoose.TabIndex = 29;
            this.btnchoose.Text = "Choose file";
            this.btnchoose.UseVisualStyleBackColor = false;
            this.btnchoose.Click += new System.EventHandler(this.btnchoose_Click);
            // 
            // btnopenkey
            // 
            this.btnopenkey.BackColor = System.Drawing.Color.Gray;
            this.btnopenkey.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnopenkey.ForeColor = System.Drawing.Color.Yellow;
            this.btnopenkey.Location = new System.Drawing.Point(506, 152);
            this.btnopenkey.Name = "btnopenkey";
            this.btnopenkey.Size = new System.Drawing.Size(117, 35);
            this.btnopenkey.TabIndex = 30;
            this.btnopenkey.Text = "Open key";
            this.btnopenkey.UseVisualStyleBackColor = false;
            this.btnopenkey.Click += new System.EventHandler(this.btnopenkey_Click);
            // 
            // txt_anpha
            // 
            this.txt_anpha.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_anpha.Location = new System.Drawing.Point(144, 322);
            this.txt_anpha.Margin = new System.Windows.Forms.Padding(4);
            this.txt_anpha.Name = "txt_anpha";
            this.txt_anpha.Size = new System.Drawing.Size(479, 26);
            this.txt_anpha.TabIndex = 6;
            // 
            // txt_Xb
            // 
            this.txt_Xb.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Xb.Location = new System.Drawing.Point(174, 409);
            this.txt_Xb.Margin = new System.Windows.Forms.Padding(4);
            this.txt_Xb.Name = "txt_Xb";
            this.txt_Xb.Size = new System.Drawing.Size(449, 26);
            this.txt_Xb.TabIndex = 8;
            // 
            // txt_Xa
            // 
            this.txt_Xa.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Xa.Location = new System.Drawing.Point(195, 366);
            this.txt_Xa.Margin = new System.Windows.Forms.Padding(4);
            this.txt_Xa.Name = "txt_Xa";
            this.txt_Xa.Size = new System.Drawing.Size(428, 26);
            this.txt_Xa.TabIndex = 7;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(72, 328);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(64, 18);
            this.label9.TabIndex = 27;
            this.label9.Text = "Anpha: ";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(31, 417);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(124, 18);
            this.label10.TabIndex = 27;
            this.label10.Text = "Khóa riêng Xb: ";
            // 
            // txt_e
            // 
            this.txt_e.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_e.Location = new System.Drawing.Point(143, 279);
            this.txt_e.Margin = new System.Windows.Forms.Padding(4);
            this.txt_e.Name = "txt_e";
            this.txt_e.Size = new System.Drawing.Size(480, 26);
            this.txt_e.TabIndex = 5;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(50, 374);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(124, 18);
            this.label8.TabIndex = 27;
            this.label8.Text = "Khóa riêng Xa: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(91, 286);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 18);
            this.label3.TabIndex = 27;
            this.label3.Text = "e: ";
            // 
            // txt_q
            // 
            this.txt_q.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_q.Location = new System.Drawing.Point(143, 238);
            this.txt_q.Margin = new System.Windows.Forms.Padding(4);
            this.txt_q.Name = "txt_q";
            this.txt_q.Size = new System.Drawing.Size(480, 26);
            this.txt_q.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(87, 245);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 18);
            this.label2.TabIndex = 25;
            this.label2.Text = "Q: ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(89, 205);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 18);
            this.label1.TabIndex = 24;
            this.label1.Text = "P: ";
            // 
            // txt_p
            // 
            this.txt_p.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_p.Location = new System.Drawing.Point(143, 198);
            this.txt_p.Margin = new System.Windows.Forms.Padding(4);
            this.txt_p.Name = "txt_p";
            this.txt_p.Size = new System.Drawing.Size(480, 26);
            this.txt_p.TabIndex = 3;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(10, 492);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(108, 18);
            this.label7.TabIndex = 19;
            this.label7.Text = "Bản mã hóa: ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(50, 105);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 18);
            this.label6.TabIndex = 20;
            this.label6.Text = "Bản rõ: ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(31, 45);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 18);
            this.label5.TabIndex = 21;
            this.label5.Text = "Lựa chọn: ";
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label.Location = new System.Drawing.Point(72, 161);
            this.label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(46, 18);
            this.label.TabIndex = 22;
            this.label.Text = "Key: ";
            // 
            // txtkey
            // 
            this.txtkey.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtkey.Location = new System.Drawing.Point(143, 158);
            this.txtkey.Margin = new System.Windows.Forms.Padding(4);
            this.txtkey.Name = "txtkey";
            this.txtkey.Size = new System.Drawing.Size(344, 26);
            this.txtkey.TabIndex = 2;
            // 
            // rtxtbanma
            // 
            this.rtxtbanma.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtxtbanma.Location = new System.Drawing.Point(143, 454);
            this.rtxtbanma.Margin = new System.Windows.Forms.Padding(4);
            this.rtxtbanma.Name = "rtxtbanma";
            this.rtxtbanma.Size = new System.Drawing.Size(480, 74);
            this.rtxtbanma.TabIndex = 9;
            this.rtxtbanma.Text = "";
            // 
            // rtxtbanro
            // 
            this.rtxtbanro.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtxtbanro.Location = new System.Drawing.Point(143, 74);
            this.rtxtbanro.Margin = new System.Windows.Forms.Padding(4);
            this.rtxtbanro.Name = "rtxtbanro";
            this.rtxtbanro.Size = new System.Drawing.Size(344, 65);
            this.rtxtbanro.TabIndex = 1;
            this.rtxtbanro.Text = "";
            // 
            // cipher_type
            // 
            this.cipher_type.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cipher_type.FormattingEnabled = true;
            this.cipher_type.Location = new System.Drawing.Point(143, 29);
            this.cipher_type.Margin = new System.Windows.Forms.Padding(4);
            this.cipher_type.Name = "cipher_type";
            this.cipher_type.Size = new System.Drawing.Size(344, 28);
            this.cipher_type.TabIndex = 0;
            this.cipher_type.SelectedIndexChanged += new System.EventHandler(this.cipher_type_SelectedIndexChanged_1);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // btntinhkhoabm
            // 
            this.btntinhkhoabm.BackColor = System.Drawing.Color.Maroon;
            this.btntinhkhoabm.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btntinhkhoabm.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btntinhkhoabm.Location = new System.Drawing.Point(217, 627);
            this.btntinhkhoabm.Name = "btntinhkhoabm";
            this.btntinhkhoabm.Size = new System.Drawing.Size(231, 45);
            this.btntinhkhoabm.TabIndex = 16;
            this.btntinhkhoabm.Text = "Tính khóa bí mật";
            this.btntinhkhoabm.UseVisualStyleBackColor = false;
            this.btntinhkhoabm.Click += new System.EventHandler(this.btntinhkhoabm_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Lavender;
            this.ClientSize = new System.Drawing.Size(1351, 708);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnthoat);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btn_Decrypt);
            this.Controls.Add(this.btn_Encrypt);
            this.Controls.Add(this.btntinhkhoabm);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btn_Encrypt;
        private System.Windows.Forms.Button btn_Decrypt;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnclear;
        private System.Windows.Forms.Button btnthoat;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RichTextBox txtKetQua;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnchoose;
        private System.Windows.Forms.Button btnopenkey;
        private System.Windows.Forms.TextBox txt_e;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_q;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_p;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.TextBox txtkey;
        private System.Windows.Forms.RichTextBox rtxtbanma;
        private System.Windows.Forms.RichTextBox rtxtbanro;
        private System.Windows.Forms.ComboBox cipher_type;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.TextBox txt_anpha;
        private System.Windows.Forms.TextBox txt_Xb;
        private System.Windows.Forms.TextBox txt_Xa;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btntinhkhoabm;
    }
}

