namespace CaffeBar
{
    partial class KonobarForm
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
            this.tabKonobar = new System.Windows.Forms.TabControl();
            this.tabIzdajRacun = new System.Windows.Forms.TabPage();
            this.labelUsername = new System.Windows.Forms.Label();
            this.labelAkcijaUTijeku = new System.Windows.Forms.Label();
            this.buttonOcistiRacun = new System.Windows.Forms.Button();
            this.buttonKonobarskiPopust = new System.Windows.Forms.Button();
            this.gumbIzdajRacun = new System.Windows.Forms.Button();
            this.textRacuna = new System.Windows.Forms.RichTextBox();
            this.textBoxTrazi = new System.Windows.Forms.TextBox();
            this.dataGridViewPica = new System.Windows.Forms.DataGridView();
            this.buttonPrikazPica = new System.Windows.Forms.Button();
            this.tabSkladiste = new System.Windows.Forms.TabPage();
            this.tabŠank = new System.Windows.Forms.TabPage();
            this.buttonPrikaziStanjeSanka = new System.Windows.Forms.Button();
            this.labelPotrebnoNapunitiSank = new System.Windows.Forms.Label();
            this.labelStanjeSanka = new System.Windows.Forms.Label();
            this.dataGridViewSank = new System.Windows.Forms.DataGridView();
            this.tabNarudžba = new System.Windows.Forms.TabPage();
            this.gumbOdjavaKonobara = new System.Windows.Forms.Button();
            this.tabKonobar.SuspendLayout();
            this.tabIzdajRacun.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPica)).BeginInit();
            this.tabŠank.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSank)).BeginInit();
            this.SuspendLayout();
            // 
            // tabKonobar
            // 
            this.tabKonobar.Controls.Add(this.tabIzdajRacun);
            this.tabKonobar.Controls.Add(this.tabSkladiste);
            this.tabKonobar.Controls.Add(this.tabŠank);
            this.tabKonobar.Controls.Add(this.tabNarudžba);
            this.tabKonobar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tabKonobar.ItemSize = new System.Drawing.Size(100, 50);
            this.tabKonobar.Location = new System.Drawing.Point(12, 13);
            this.tabKonobar.Multiline = true;
            this.tabKonobar.Name = "tabKonobar";
            this.tabKonobar.SelectedIndex = 0;
            this.tabKonobar.Size = new System.Drawing.Size(938, 531);
            this.tabKonobar.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabKonobar.TabIndex = 4;
            // 
            // tabIzdajRacun
            // 
            this.tabIzdajRacun.Controls.Add(this.labelUsername);
            this.tabIzdajRacun.Controls.Add(this.labelAkcijaUTijeku);
            this.tabIzdajRacun.Controls.Add(this.buttonOcistiRacun);
            this.tabIzdajRacun.Controls.Add(this.buttonKonobarskiPopust);
            this.tabIzdajRacun.Controls.Add(this.gumbIzdajRacun);
            this.tabIzdajRacun.Controls.Add(this.textRacuna);
            this.tabIzdajRacun.Controls.Add(this.textBoxTrazi);
            this.tabIzdajRacun.Controls.Add(this.dataGridViewPica);
            this.tabIzdajRacun.Controls.Add(this.buttonPrikazPica);
            this.tabIzdajRacun.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tabIzdajRacun.Location = new System.Drawing.Point(4, 54);
            this.tabIzdajRacun.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.tabIzdajRacun.Name = "tabIzdajRacun";
            this.tabIzdajRacun.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabIzdajRacun.Size = new System.Drawing.Size(930, 473);
            this.tabIzdajRacun.TabIndex = 0;
            this.tabIzdajRacun.Text = "Izdaj račun";
            this.tabIzdajRacun.UseVisualStyleBackColor = true;
            // 
            // labelUsername
            // 
            this.labelUsername.AutoSize = true;
            this.labelUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelUsername.Location = new System.Drawing.Point(662, 32);
            this.labelUsername.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelUsername.Name = "labelUsername";
            this.labelUsername.Size = new System.Drawing.Size(0, 25);
            this.labelUsername.TabIndex = 10;
            // 
            // labelAkcijaUTijeku
            // 
            this.labelAkcijaUTijeku.AutoSize = true;
            this.labelAkcijaUTijeku.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelAkcijaUTijeku.ForeColor = System.Drawing.Color.Blue;
            this.labelAkcijaUTijeku.Location = new System.Drawing.Point(370, 32);
            this.labelAkcijaUTijeku.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelAkcijaUTijeku.Name = "labelAkcijaUTijeku";
            this.labelAkcijaUTijeku.Size = new System.Drawing.Size(0, 25);
            this.labelAkcijaUTijeku.TabIndex = 9;
            // 
            // buttonOcistiRacun
            // 
            this.buttonOcistiRacun.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonOcistiRacun.Location = new System.Drawing.Point(1030, 387);
            this.buttonOcistiRacun.Name = "buttonOcistiRacun";
            this.buttonOcistiRacun.Size = new System.Drawing.Size(155, 48);
            this.buttonOcistiRacun.TabIndex = 8;
            this.buttonOcistiRacun.Text = "Očisti račun";
            this.buttonOcistiRacun.UseVisualStyleBackColor = true;
            this.buttonOcistiRacun.Click += new System.EventHandler(this.buttonOcistiRacun_Click);
            // 
            // buttonKonobarskiPopust
            // 
            this.buttonKonobarskiPopust.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonKonobarskiPopust.Location = new System.Drawing.Point(802, 370);
            this.buttonKonobarskiPopust.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonKonobarskiPopust.Name = "buttonKonobarskiPopust";
            this.buttonKonobarskiPopust.Size = new System.Drawing.Size(155, 48);
            this.buttonKonobarskiPopust.TabIndex = 7;
            this.buttonKonobarskiPopust.Text = "Iskoristi popust";
            this.buttonKonobarskiPopust.UseVisualStyleBackColor = true;
            // 
            // gumbIzdajRacun
            // 
            this.gumbIzdajRacun.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.gumbIzdajRacun.Location = new System.Drawing.Point(802, 427);
            this.gumbIzdajRacun.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gumbIzdajRacun.Name = "gumbIzdajRacun";
            this.gumbIzdajRacun.Size = new System.Drawing.Size(155, 48);
            this.gumbIzdajRacun.TabIndex = 6;
            this.gumbIzdajRacun.Text = "Izdaj račun";
            this.gumbIzdajRacun.UseVisualStyleBackColor = true;
            this.gumbIzdajRacun.Click += new System.EventHandler(this.gumbIzdajRacun_Click);
            // 
            // textRacuna
            // 
            this.textRacuna.Location = new System.Drawing.Point(487, 93);
            this.textRacuna.Name = "textRacuna";
            this.textRacuna.ReadOnly = true;
            this.textRacuna.Size = new System.Drawing.Size(395, 391);
            this.textRacuna.TabIndex = 3;
            this.textRacuna.Text = "";
            // 
            // textBoxTrazi
            // 
            this.textBoxTrazi.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBoxTrazi.Location = new System.Drawing.Point(165, 29);
            this.textBoxTrazi.MinimumSize = new System.Drawing.Size(150, 50);
            this.textBoxTrazi.Name = "textBoxTrazi";
            this.textBoxTrazi.Size = new System.Drawing.Size(150, 35);
            this.textBoxTrazi.TabIndex = 2;
            this.textBoxTrazi.TextChanged += new System.EventHandler(this.textBoxTrazi_TextChanged);
            // 
            // dataGridViewPica
            // 
            this.dataGridViewPica.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridViewPica.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridViewPica.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dataGridViewPica.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewPica.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPica.GridColor = System.Drawing.SystemColors.ActiveCaption;
            this.dataGridViewPica.Location = new System.Drawing.Point(22, 93);
            this.dataGridViewPica.Name = "dataGridViewPica";
            this.dataGridViewPica.Size = new System.Drawing.Size(326, 390);
            this.dataGridViewPica.TabIndex = 1;
            this.dataGridViewPica.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewPica_CellClick);
            this.dataGridViewPica.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridViewPica_CellFormatting);
            // 
            // buttonPrikazPica
            // 
            this.buttonPrikazPica.Location = new System.Drawing.Point(22, 23);
            this.buttonPrikazPica.Name = "buttonPrikazPica";
            this.buttonPrikazPica.Size = new System.Drawing.Size(124, 51);
            this.buttonPrikazPica.TabIndex = 0;
            this.buttonPrikazPica.Text = "Prikaži pića";
            this.buttonPrikazPica.UseVisualStyleBackColor = true;
            this.buttonPrikazPica.Click += new System.EventHandler(this.buttonPrikaziPica_Click);
            // 
            // tabSkladiste
            // 
            this.tabSkladiste.Location = new System.Drawing.Point(4, 54);
            this.tabSkladiste.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.tabSkladiste.Name = "tabSkladiste";
            this.tabSkladiste.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabSkladiste.Size = new System.Drawing.Size(930, 473);
            this.tabSkladiste.TabIndex = 1;
            this.tabSkladiste.Text = "Skladište";
            this.tabSkladiste.UseVisualStyleBackColor = true;
            // 
            // tabŠank
            // 
            this.tabŠank.Controls.Add(this.buttonPrikaziStanjeSanka);
            this.tabŠank.Controls.Add(this.labelPotrebnoNapunitiSank);
            this.tabŠank.Controls.Add(this.labelStanjeSanka);
            this.tabŠank.Controls.Add(this.dataGridViewSank);
            this.tabŠank.Location = new System.Drawing.Point(4, 54);
            this.tabŠank.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.tabŠank.Name = "tabŠank";
            this.tabŠank.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabŠank.Size = new System.Drawing.Size(930, 473);
            this.tabŠank.TabIndex = 2;
            this.tabŠank.Text = "Šank";
            this.tabŠank.UseVisualStyleBackColor = true;
            // 
            // buttonPrikaziStanjeSanka
            // 
            this.buttonPrikaziStanjeSanka.Location = new System.Drawing.Point(170, 24);
            this.buttonPrikaziStanjeSanka.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonPrikaziStanjeSanka.Name = "buttonPrikaziStanjeSanka";
            this.buttonPrikaziStanjeSanka.Size = new System.Drawing.Size(130, 37);
            this.buttonPrikaziStanjeSanka.TabIndex = 3;
            this.buttonPrikaziStanjeSanka.Text = "Prikaži";
            this.buttonPrikaziStanjeSanka.UseVisualStyleBackColor = true;
            this.buttonPrikaziStanjeSanka.Click += new System.EventHandler(this.buttonPrikaziStanjeSanka_Click_1);
            // 
            // labelPotrebnoNapunitiSank
            // 
            this.labelPotrebnoNapunitiSank.AutoSize = true;
            this.labelPotrebnoNapunitiSank.Location = new System.Drawing.Point(499, 50);
            this.labelPotrebnoNapunitiSank.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelPotrebnoNapunitiSank.Name = "labelPotrebnoNapunitiSank";
            this.labelPotrebnoNapunitiSank.Size = new System.Drawing.Size(0, 24);
            this.labelPotrebnoNapunitiSank.TabIndex = 2;
            // 
            // labelStanjeSanka
            // 
            this.labelStanjeSanka.AutoSize = true;
            this.labelStanjeSanka.Location = new System.Drawing.Point(44, 32);
            this.labelStanjeSanka.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelStanjeSanka.Name = "labelStanjeSanka";
            this.labelStanjeSanka.Size = new System.Drawing.Size(126, 24);
            this.labelStanjeSanka.TabIndex = 1;
            this.labelStanjeSanka.Text = "Stanje šanka: ";
            // 
            // dataGridViewSank
            // 
            this.dataGridViewSank.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridViewSank.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridViewSank.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSank.Location = new System.Drawing.Point(30, 74);
            this.dataGridViewSank.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dataGridViewSank.Name = "dataGridViewSank";
            this.dataGridViewSank.RowHeadersWidth = 51;
            this.dataGridViewSank.RowTemplate.Height = 24;
            this.dataGridViewSank.Size = new System.Drawing.Size(382, 285);
            this.dataGridViewSank.TabIndex = 0;
            // 
            // tabNarudžba
            // 
            this.tabNarudžba.Location = new System.Drawing.Point(4, 54);
            this.tabNarudžba.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.tabNarudžba.Name = "tabNarudžba";
            this.tabNarudžba.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabNarudžba.Size = new System.Drawing.Size(930, 473);
            this.tabNarudžba.TabIndex = 3;
            this.tabNarudžba.Text = "Narudžba";
            this.tabNarudžba.UseVisualStyleBackColor = true;
            // 
            // gumbOdjavaKonobara
            // 
            this.gumbOdjavaKonobara.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.gumbOdjavaKonobara.Location = new System.Drawing.Point(1096, 12);
            this.gumbOdjavaKonobara.Name = "gumbOdjavaKonobara";
            this.gumbOdjavaKonobara.Size = new System.Drawing.Size(131, 48);
            this.gumbOdjavaKonobara.TabIndex = 5;
            this.gumbOdjavaKonobara.Text = "Odjava";
            this.gumbOdjavaKonobara.UseVisualStyleBackColor = true;
            this.gumbOdjavaKonobara.Click += new System.EventHandler(this.gumbOdjavaKonobara_Click);
            // 
            // KonobarForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1238, 630);
            this.Controls.Add(this.gumbOdjavaKonobara);
            this.Controls.Add(this.tabKonobar);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "KonobarForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "KonobarForm";
            this.tabKonobar.ResumeLayout(false);
            this.tabIzdajRacun.ResumeLayout(false);
            this.tabIzdajRacun.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPica)).EndInit();
            this.tabŠank.ResumeLayout(false);
            this.tabŠank.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSank)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabKonobar;
        private System.Windows.Forms.TabPage tabSkladiste;
        private System.Windows.Forms.Button gumbOdjavaKonobara;
        private System.Windows.Forms.TabPage tabŠank;
        private System.Windows.Forms.TabPage tabNarudžba;
        public System.Windows.Forms.TabPage tabIzdajRacun;
        private System.Windows.Forms.DataGridView dataGridViewPica;
        private System.Windows.Forms.Button buttonPrikazPica;
        private System.Windows.Forms.TextBox textBoxTrazi;
        private System.Windows.Forms.RichTextBox textRacuna;
        private System.Windows.Forms.Button buttonKonobarskiPopust;
        private System.Windows.Forms.Button gumbIzdajRacun;
        private System.Windows.Forms.Button buttonOcistiRacun;
        private System.Windows.Forms.Label labelAkcijaUTijeku;
        private System.Windows.Forms.Label labelUsername;
        private System.Windows.Forms.Label labelStanjeSanka;
        private System.Windows.Forms.DataGridView dataGridViewSank;
        private System.Windows.Forms.Label labelPotrebnoNapunitiSank;
        private System.Windows.Forms.Button buttonPrikaziStanjeSanka;
    }
}