namespace Client
{
    partial class MainClient
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
            this.TitleButton = new System.Windows.Forms.Label();
            this.SendMesaj = new System.Windows.Forms.Button();
            this.SendObje = new System.Windows.Forms.Button();
            this.SendImages = new System.Windows.Forms.Button();
            this.TitleMesaj = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.MessageBoxTxt = new System.Windows.Forms.TextBox();
            this.TitleObje = new System.Windows.Forms.Label();
            this.TitleName = new System.Windows.Forms.Label();
            this.TitleSurname = new System.Windows.Forms.Label();
            this.TitleJobs = new System.Windows.Forms.Label();
            this.TitleDate = new System.Windows.Forms.Label();
            this.Namebox = new System.Windows.Forms.TextBox();
            this.SurnameBox = new System.Windows.Forms.TextBox();
            this.JobsBox = new System.Windows.Forms.TextBox();
            this.DateBox = new System.Windows.Forms.TextBox();
            this.AdapterBox = new System.Windows.Forms.ComboBox();
            this.TitleServer = new System.Windows.Forms.Label();
            this.TitleNetwork = new System.Windows.Forms.Label();
            this.IpBox = new System.Windows.Forms.TextBox();
            this.ServerConnected = new System.Windows.Forms.Button();
            this.TitleStatus = new System.Windows.Forms.Label();
            this.Status = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // TitleButton
            // 
            this.TitleButton.AutoSize = true;
            this.TitleButton.Location = new System.Drawing.Point(12, 9);
            this.TitleButton.Name = "TitleButton";
            this.TitleButton.Size = new System.Drawing.Size(49, 13);
            this.TitleButton.TabIndex = 0;
            this.TitleButton.Text = "Buttonlar";
            // 
            // SendMesaj
            // 
            this.SendMesaj.Location = new System.Drawing.Point(15, 25);
            this.SendMesaj.Name = "SendMesaj";
            this.SendMesaj.Size = new System.Drawing.Size(224, 23);
            this.SendMesaj.TabIndex = 1;
            this.SendMesaj.Text = "Text Mesaj Gönder";
            this.SendMesaj.UseVisualStyleBackColor = true;
            this.SendMesaj.Click += new System.EventHandler(this.SendMesaj_Click);
            // 
            // SendObje
            // 
            this.SendObje.Location = new System.Drawing.Point(15, 55);
            this.SendObje.Name = "SendObje";
            this.SendObje.Size = new System.Drawing.Size(224, 23);
            this.SendObje.TabIndex = 2;
            this.SendObje.Text = "Nesne Tipi Gönder";
            this.SendObje.UseVisualStyleBackColor = true;
            this.SendObje.Click += new System.EventHandler(this.SendObje_Click);
            // 
            // SendImages
            // 
            this.SendImages.Location = new System.Drawing.Point(15, 84);
            this.SendImages.Name = "SendImages";
            this.SendImages.Size = new System.Drawing.Size(224, 23);
            this.SendImages.TabIndex = 3;
            this.SendImages.Text = "Resim Gönder";
            this.SendImages.UseVisualStyleBackColor = true;
            this.SendImages.Click += new System.EventHandler(this.SendImages_Click);
            // 
            // TitleMesaj
            // 
            this.TitleMesaj.AutoSize = true;
            this.TitleMesaj.Location = new System.Drawing.Point(15, 114);
            this.TitleMesaj.Name = "TitleMesaj";
            this.TitleMesaj.Size = new System.Drawing.Size(61, 13);
            this.TitleMesaj.TabIndex = 4;
            this.TitleMesaj.Text = "Text Mesajı";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 136);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Mesaj : ";
            // 
            // MessageBoxTxt
            // 
            this.MessageBoxTxt.Location = new System.Drawing.Point(66, 133);
            this.MessageBoxTxt.Name = "MessageBoxTxt";
            this.MessageBoxTxt.Size = new System.Drawing.Size(173, 20);
            this.MessageBoxTxt.TabIndex = 6;
            // 
            // TitleObje
            // 
            this.TitleObje.AutoSize = true;
            this.TitleObje.Location = new System.Drawing.Point(15, 172);
            this.TitleObje.Name = "TitleObje";
            this.TitleObje.Size = new System.Drawing.Size(58, 13);
            this.TitleObje.TabIndex = 7;
            this.TitleObje.Text = "Nesne Tipi";
            // 
            // TitleName
            // 
            this.TitleName.AutoSize = true;
            this.TitleName.Location = new System.Drawing.Point(25, 203);
            this.TitleName.Name = "TitleName";
            this.TitleName.Size = new System.Drawing.Size(29, 13);
            this.TitleName.TabIndex = 8;
            this.TitleName.Text = "Ad : ";
            // 
            // TitleSurname
            // 
            this.TitleSurname.AutoSize = true;
            this.TitleSurname.Location = new System.Drawing.Point(25, 229);
            this.TitleSurname.Name = "TitleSurname";
            this.TitleSurname.Size = new System.Drawing.Size(46, 13);
            this.TitleSurname.TabIndex = 9;
            this.TitleSurname.Text = "Soyad : ";
            // 
            // TitleJobs
            // 
            this.TitleJobs.AutoSize = true;
            this.TitleJobs.Location = new System.Drawing.Point(25, 258);
            this.TitleJobs.Name = "TitleJobs";
            this.TitleJobs.Size = new System.Drawing.Size(52, 13);
            this.TitleJobs.TabIndex = 10;
            this.TitleJobs.Text = "Mesleği : ";
            // 
            // TitleDate
            // 
            this.TitleDate.AutoSize = true;
            this.TitleDate.Location = new System.Drawing.Point(25, 284);
            this.TitleDate.Name = "TitleDate";
            this.TitleDate.Size = new System.Drawing.Size(56, 13);
            this.TitleDate.TabIndex = 11;
            this.TitleDate.Text = "D. Tarihi : ";
            // 
            // Namebox
            // 
            this.Namebox.Location = new System.Drawing.Point(66, 200);
            this.Namebox.Name = "Namebox";
            this.Namebox.Size = new System.Drawing.Size(173, 20);
            this.Namebox.TabIndex = 12;
            // 
            // SurnameBox
            // 
            this.SurnameBox.Location = new System.Drawing.Point(66, 229);
            this.SurnameBox.Name = "SurnameBox";
            this.SurnameBox.Size = new System.Drawing.Size(173, 20);
            this.SurnameBox.TabIndex = 13;
            // 
            // JobsBox
            // 
            this.JobsBox.Location = new System.Drawing.Point(66, 255);
            this.JobsBox.Name = "JobsBox";
            this.JobsBox.Size = new System.Drawing.Size(173, 20);
            this.JobsBox.TabIndex = 14;
            // 
            // DateBox
            // 
            this.DateBox.Location = new System.Drawing.Point(66, 281);
            this.DateBox.Name = "DateBox";
            this.DateBox.Size = new System.Drawing.Size(173, 20);
            this.DateBox.TabIndex = 15;
            // 
            // AdapterBox
            // 
            this.AdapterBox.FormattingEnabled = true;
            this.AdapterBox.Location = new System.Drawing.Point(16, 43);
            this.AdapterBox.Name = "AdapterBox";
            this.AdapterBox.Size = new System.Drawing.Size(202, 21);
            this.AdapterBox.TabIndex = 17;
            // 
            // TitleServer
            // 
            this.TitleServer.AutoSize = true;
            this.TitleServer.Location = new System.Drawing.Point(13, 79);
            this.TitleServer.Name = "TitleServer";
            this.TitleServer.Size = new System.Drawing.Size(65, 13);
            this.TitleServer.TabIndex = 18;
            this.TitleServer.Text = "Sunucu Ip : ";
            // 
            // TitleNetwork
            // 
            this.TitleNetwork.AutoSize = true;
            this.TitleNetwork.Location = new System.Drawing.Point(13, 24);
            this.TitleNetwork.Name = "TitleNetwork";
            this.TitleNetwork.Size = new System.Drawing.Size(84, 13);
            this.TitleNetwork.TabIndex = 19;
            this.TitleNetwork.Text = "NetworkAdapter";
            // 
            // IpBox
            // 
            this.IpBox.Location = new System.Drawing.Point(84, 76);
            this.IpBox.Name = "IpBox";
            this.IpBox.Size = new System.Drawing.Size(134, 20);
            this.IpBox.TabIndex = 20;
            this.IpBox.Text = "192.168.1.3";
            // 
            // ServerConnected
            // 
            this.ServerConnected.Location = new System.Drawing.Point(16, 106);
            this.ServerConnected.Name = "ServerConnected";
            this.ServerConnected.Size = new System.Drawing.Size(202, 23);
            this.ServerConnected.TabIndex = 21;
            this.ServerConnected.Text = "Sunucuya Bağlan";
            this.ServerConnected.UseVisualStyleBackColor = true;
            this.ServerConnected.Click += new System.EventHandler(this.ServerConnected_Click);
            // 
            // TitleStatus
            // 
            this.TitleStatus.AutoSize = true;
            this.TitleStatus.Location = new System.Drawing.Point(19, 147);
            this.TitleStatus.Name = "TitleStatus";
            this.TitleStatus.Size = new System.Drawing.Size(38, 13);
            this.TitleStatus.TabIndex = 22;
            this.TitleStatus.Text = "Durum";
            // 
            // Status
            // 
            this.Status.AutoSize = true;
            this.Status.Location = new System.Drawing.Point(99, 147);
            this.Status.Name = "Status";
            this.Status.Size = new System.Drawing.Size(37, 13);
            this.Status.TabIndex = 23;
            this.Status.Text = "Status";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Status);
            this.groupBox1.Controls.Add(this.AdapterBox);
            this.groupBox1.Controls.Add(this.TitleStatus);
            this.groupBox1.Controls.Add(this.TitleServer);
            this.groupBox1.Controls.Add(this.ServerConnected);
            this.groupBox1.Controls.Add(this.TitleNetwork);
            this.groupBox1.Controls.Add(this.IpBox);
            this.groupBox1.Location = new System.Drawing.Point(12, 333);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(227, 176);
            this.groupBox1.TabIndex = 24;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Terminal";
            // 
            // MainClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(251, 521);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.DateBox);
            this.Controls.Add(this.JobsBox);
            this.Controls.Add(this.SurnameBox);
            this.Controls.Add(this.Namebox);
            this.Controls.Add(this.TitleDate);
            this.Controls.Add(this.TitleJobs);
            this.Controls.Add(this.TitleSurname);
            this.Controls.Add(this.TitleName);
            this.Controls.Add(this.TitleObje);
            this.Controls.Add(this.MessageBoxTxt);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TitleMesaj);
            this.Controls.Add(this.SendImages);
            this.Controls.Add(this.SendObje);
            this.Controls.Add(this.SendMesaj);
            this.Controls.Add(this.TitleButton);
            this.Name = "MainClient";
            this.Text = "Client";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label TitleButton;
        private System.Windows.Forms.Button SendMesaj;
        private System.Windows.Forms.Button SendObje;
        private System.Windows.Forms.Button SendImages;
        private System.Windows.Forms.Label TitleMesaj;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox MessageBoxTxt;
        private System.Windows.Forms.Label TitleObje;
        private System.Windows.Forms.Label TitleName;
        private System.Windows.Forms.Label TitleSurname;
        private System.Windows.Forms.Label TitleJobs;
        private System.Windows.Forms.Label TitleDate;
        private System.Windows.Forms.TextBox Namebox;
        private System.Windows.Forms.TextBox SurnameBox;
        private System.Windows.Forms.TextBox JobsBox;
        private System.Windows.Forms.TextBox DateBox;
        private System.Windows.Forms.ComboBox AdapterBox;
        private System.Windows.Forms.Label TitleServer;
        private System.Windows.Forms.Label TitleNetwork;
        private System.Windows.Forms.TextBox IpBox;
        private System.Windows.Forms.Button ServerConnected;
        private System.Windows.Forms.Label TitleStatus;
        private System.Windows.Forms.Label Status;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}

