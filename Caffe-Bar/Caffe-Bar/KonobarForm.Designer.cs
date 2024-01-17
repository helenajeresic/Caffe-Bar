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
            this.labelSkladiste = new System.Windows.Forms.Label();
            this.dataGridViewStanjeSkladista = new System.Windows.Forms.DataGridView();
            this.buttonStanjeSkladista = new System.Windows.Forms.Button();
            this.tabŠank = new System.Windows.Forms.TabPage();
            this.tabNarudžba = new System.Windows.Forms.TabPage();
            this.gumbOdjavaKonobara = new System.Windows.Forms.Button();
            this.labelOdaberiPiceZaSank = new System.Windows.Forms.Label();
            this.comboBoxOdaberiPiceZaSank = new System.Windows.Forms.ComboBox();
            this.buttonDodajUSank = new System.Windows.Forms.Button();
            this.labelOdaberiKolicinu = new System.Windows.Forms.Label();
            this.numericUpDownOdaberiKolicinuZaSank = new System.Windows.Forms.NumericUpDown();
            this.buttonPrikaziStanjeSank = new System.Windows.Forms.Button();
            this.dataGridViewStanjeSank = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tabKonobar.SuspendLayout();
            this.tabIzdajRacun.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPica)).BeginInit();
            this.tabSkladiste.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStanjeSkladista)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownOdaberiKolicinuZaSank)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStanjeSank)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
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
            this.tabKonobar.Location = new System.Drawing.Point(13, 15);
            this.tabKonobar.Margin = new System.Windows.Forms.Padding(4);
            this.tabKonobar.Multiline = true;
            this.tabKonobar.Name = "tabKonobar";
            this.tabKonobar.SelectedIndex = 0;
            this.tabKonobar.Size = new System.Drawing.Size(1592, 753);
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
            this.tabIzdajRacun.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.tabIzdajRacun.Name = "tabIzdajRacun";
            this.tabIzdajRacun.Padding = new System.Windows.Forms.Padding(5);
            this.tabIzdajRacun.Size = new System.Drawing.Size(1584, 695);
            this.tabIzdajRacun.TabIndex = 0;
            this.tabIzdajRacun.Text = "Izdaj račun";
            this.tabIzdajRacun.UseVisualStyleBackColor = true;
            // 
            // labelUsername
            // 
            this.labelUsername.AutoSize = true;
            this.labelUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelUsername.Location = new System.Drawing.Point(1125, 43);
            this.labelUsername.Name = "labelUsername";
            this.labelUsername.Size = new System.Drawing.Size(0, 31);
            this.labelUsername.TabIndex = 10;
            // 
            // labelAkcijaUTijeku
            // 
            this.labelAkcijaUTijeku.AutoSize = true;
            this.labelAkcijaUTijeku.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelAkcijaUTijeku.ForeColor = System.Drawing.Color.Blue;
            this.labelAkcijaUTijeku.Location = new System.Drawing.Point(551, 43);
            this.labelAkcijaUTijeku.Name = "labelAkcijaUTijeku";
            this.labelAkcijaUTijeku.Size = new System.Drawing.Size(0, 31);
            this.labelAkcijaUTijeku.TabIndex = 9;
            // 
            // buttonOcistiRacun
            // 
            this.buttonOcistiRacun.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonOcistiRacun.Location = new System.Drawing.Point(1332, 399);
            this.buttonOcistiRacun.Margin = new System.Windows.Forms.Padding(4);
            this.buttonOcistiRacun.Name = "buttonOcistiRacun";
            this.buttonOcistiRacun.Size = new System.Drawing.Size(207, 59);
            this.buttonOcistiRacun.TabIndex = 8;
            this.buttonOcistiRacun.Text = "Očisti račun";
            this.buttonOcistiRacun.UseVisualStyleBackColor = true;
            this.buttonOcistiRacun.Click += new System.EventHandler(this.buttonOcistiRacun_Click);
            // 
            // buttonKonobarskiPopust
            // 
            this.buttonKonobarskiPopust.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonKonobarskiPopust.Location = new System.Drawing.Point(1332, 494);
            this.buttonKonobarskiPopust.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonKonobarskiPopust.Name = "buttonKonobarskiPopust";
            this.buttonKonobarskiPopust.Size = new System.Drawing.Size(207, 59);
            this.buttonKonobarskiPopust.TabIndex = 7;
            this.buttonKonobarskiPopust.Text = "Iskoristi popust";
            this.buttonKonobarskiPopust.UseVisualStyleBackColor = true;
            // 
            // gumbIzdajRacun
            // 
            this.gumbIzdajRacun.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.gumbIzdajRacun.Location = new System.Drawing.Point(1332, 601);
            this.gumbIzdajRacun.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gumbIzdajRacun.Name = "gumbIzdajRacun";
            this.gumbIzdajRacun.Size = new System.Drawing.Size(207, 59);
            this.gumbIzdajRacun.TabIndex = 6;
            this.gumbIzdajRacun.Text = "Izdaj račun";
            this.gumbIzdajRacun.UseVisualStyleBackColor = true;
            this.gumbIzdajRacun.Click += new System.EventHandler(this.gumbIzdajRacun_Click);
            // 
            // textRacuna
            // 
            this.textRacuna.Location = new System.Drawing.Point(557, 114);
            this.textRacuna.Margin = new System.Windows.Forms.Padding(4);
            this.textRacuna.Name = "textRacuna";
            this.textRacuna.ReadOnly = true;
            this.textRacuna.Size = new System.Drawing.Size(701, 544);
            this.textRacuna.TabIndex = 3;
            this.textRacuna.Text = "";
            // 
            // textBoxTrazi
            // 
            this.textBoxTrazi.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBoxTrazi.Location = new System.Drawing.Point(220, 36);
            this.textBoxTrazi.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxTrazi.MinimumSize = new System.Drawing.Size(199, 50);
            this.textBoxTrazi.Name = "textBoxTrazi";
            this.textBoxTrazi.Size = new System.Drawing.Size(199, 41);
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
            this.dataGridViewPica.Location = new System.Drawing.Point(29, 114);
            this.dataGridViewPica.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridViewPica.Name = "dataGridViewPica";
            this.dataGridViewPica.RowHeadersWidth = 51;
            this.dataGridViewPica.Size = new System.Drawing.Size(485, 545);
            this.dataGridViewPica.TabIndex = 1;
            this.dataGridViewPica.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewPica_CellClick);
            this.dataGridViewPica.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridViewPica_CellFormatting);
            // 
            // buttonPrikazPica
            // 
            this.buttonPrikazPica.Location = new System.Drawing.Point(29, 28);
            this.buttonPrikazPica.Margin = new System.Windows.Forms.Padding(4);
            this.buttonPrikazPica.Name = "buttonPrikazPica";
            this.buttonPrikazPica.Size = new System.Drawing.Size(165, 63);
            this.buttonPrikazPica.TabIndex = 0;
            this.buttonPrikazPica.Text = "Prikaži pića";
            this.buttonPrikazPica.UseVisualStyleBackColor = true;
            this.buttonPrikazPica.Click += new System.EventHandler(this.buttonPrikaziPica_Click);
            // 
            // tabSkladiste
            // 
            this.tabSkladiste.Controls.Add(this.groupBox3);
            this.tabSkladiste.Controls.Add(this.groupBox2);
            this.tabSkladiste.Controls.Add(this.groupBox1);
            this.tabSkladiste.Controls.Add(this.labelSkladiste);
            this.tabSkladiste.Location = new System.Drawing.Point(4, 54);
            this.tabSkladiste.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.tabSkladiste.Name = "tabSkladiste";
            this.tabSkladiste.Padding = new System.Windows.Forms.Padding(5);
            this.tabSkladiste.Size = new System.Drawing.Size(1584, 695);
            this.tabSkladiste.TabIndex = 1;
            this.tabSkladiste.Text = "Zalihe";
            this.tabSkladiste.UseVisualStyleBackColor = true;
            // 
            // labelSkladiste
            // 
            this.labelSkladiste.AutoSize = true;
            this.labelSkladiste.Location = new System.Drawing.Point(682, 46);
            this.labelSkladiste.Name = "labelSkladiste";
            this.labelSkladiste.Size = new System.Drawing.Size(19, 29);
            this.labelSkladiste.TabIndex = 3;
            this.labelSkladiste.Text = ".";
            // 
            // dataGridViewStanjeSkladista
            // 
            this.dataGridViewStanjeSkladista.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridViewStanjeSkladista.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridViewStanjeSkladista.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewStanjeSkladista.Location = new System.Drawing.Point(30, 100);
            this.dataGridViewStanjeSkladista.Name = "dataGridViewStanjeSkladista";
            this.dataGridViewStanjeSkladista.RowHeadersWidth = 51;
            this.dataGridViewStanjeSkladista.RowTemplate.Height = 24;
            this.dataGridViewStanjeSkladista.Size = new System.Drawing.Size(550, 300);
            this.dataGridViewStanjeSkladista.TabIndex = 2;
            // 
            // buttonStanjeSkladista
            // 
            this.buttonStanjeSkladista.Location = new System.Drawing.Point(430, 33);
            this.buttonStanjeSkladista.Name = "buttonStanjeSkladista";
            this.buttonStanjeSkladista.Size = new System.Drawing.Size(150, 50);
            this.buttonStanjeSkladista.TabIndex = 1;
            this.buttonStanjeSkladista.Text = "Prikaži";
            this.buttonStanjeSkladista.UseVisualStyleBackColor = true;
            this.buttonStanjeSkladista.Click += new System.EventHandler(this.buttonStanjeSkladista_Click);
            // 
            // tabŠank
            // 
            this.tabŠank.Location = new System.Drawing.Point(4, 54);
            this.tabŠank.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.tabŠank.Name = "tabŠank";
            this.tabŠank.Padding = new System.Windows.Forms.Padding(5);
            this.tabŠank.Size = new System.Drawing.Size(1584, 695);
            this.tabŠank.TabIndex = 2;
            this.tabŠank.Text = "Šank";
            this.tabŠank.UseVisualStyleBackColor = true;
            // 
            // tabNarudžba
            // 
            this.tabNarudžba.Location = new System.Drawing.Point(4, 54);
            this.tabNarudžba.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.tabNarudžba.Name = "tabNarudžba";
            this.tabNarudžba.Padding = new System.Windows.Forms.Padding(5);
            this.tabNarudžba.Size = new System.Drawing.Size(1584, 695);
            this.tabNarudžba.TabIndex = 3;
            this.tabNarudžba.Text = "Narudžba";
            this.tabNarudžba.UseVisualStyleBackColor = true;
            // 
            // gumbOdjavaKonobara
            // 
            this.gumbOdjavaKonobara.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.gumbOdjavaKonobara.Location = new System.Drawing.Point(1421, 12);
            this.gumbOdjavaKonobara.Margin = new System.Windows.Forms.Padding(4);
            this.gumbOdjavaKonobara.Name = "gumbOdjavaKonobara";
            this.gumbOdjavaKonobara.Size = new System.Drawing.Size(175, 59);
            this.gumbOdjavaKonobara.TabIndex = 5;
            this.gumbOdjavaKonobara.Text = "Odjava";
            this.gumbOdjavaKonobara.UseVisualStyleBackColor = true;
            this.gumbOdjavaKonobara.Click += new System.EventHandler(this.gumbOdjavaKonobara_Click);
            // 
            // labelOdaberiPiceZaSank
            // 
            this.labelOdaberiPiceZaSank.AutoSize = true;
            this.labelOdaberiPiceZaSank.Location = new System.Drawing.Point(42, 40);
            this.labelOdaberiPiceZaSank.Name = "labelOdaberiPiceZaSank";
            this.labelOdaberiPiceZaSank.Size = new System.Drawing.Size(159, 29);
            this.labelOdaberiPiceZaSank.TabIndex = 4;
            this.labelOdaberiPiceZaSank.Text = "Odaberi piće:";
            // 
            // comboBoxOdaberiPiceZaSank
            // 
            this.comboBoxOdaberiPiceZaSank.FormattingEnabled = true;
            this.comboBoxOdaberiPiceZaSank.Location = new System.Drawing.Point(222, 37);
            this.comboBoxOdaberiPiceZaSank.Name = "comboBoxOdaberiPiceZaSank";
            this.comboBoxOdaberiPiceZaSank.Size = new System.Drawing.Size(244, 37);
            this.comboBoxOdaberiPiceZaSank.TabIndex = 5;
            // 
            // buttonDodajUSank
            // 
            this.buttonDodajUSank.Location = new System.Drawing.Point(127, 123);
            this.buttonDodajUSank.Name = "buttonDodajUSank";
            this.buttonDodajUSank.Size = new System.Drawing.Size(255, 53);
            this.buttonDodajUSank.TabIndex = 6;
            this.buttonDodajUSank.Text = "Dodaj u šank";
            this.buttonDodajUSank.UseVisualStyleBackColor = true;
            this.buttonDodajUSank.Click += new System.EventHandler(this.buttonDodajUSank_Click);
            // 
            // labelOdaberiKolicinu
            // 
            this.labelOdaberiKolicinu.AutoSize = true;
            this.labelOdaberiKolicinu.Location = new System.Drawing.Point(42, 85);
            this.labelOdaberiKolicinu.Name = "labelOdaberiKolicinu";
            this.labelOdaberiKolicinu.Size = new System.Drawing.Size(195, 29);
            this.labelOdaberiKolicinu.TabIndex = 7;
            this.labelOdaberiKolicinu.Text = "Odaberi količinu:";
            // 
            // numericUpDownOdaberiKolicinuZaSank
            // 
            this.numericUpDownOdaberiKolicinuZaSank.Location = new System.Drawing.Point(346, 83);
            this.numericUpDownOdaberiKolicinuZaSank.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.numericUpDownOdaberiKolicinuZaSank.Name = "numericUpDownOdaberiKolicinuZaSank";
            this.numericUpDownOdaberiKolicinuZaSank.Size = new System.Drawing.Size(120, 34);
            this.numericUpDownOdaberiKolicinuZaSank.TabIndex = 8;
            // 
            // buttonPrikaziStanjeSank
            // 
            this.buttonPrikaziStanjeSank.Location = new System.Drawing.Point(428, 32);
            this.buttonPrikaziStanjeSank.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonPrikaziStanjeSank.Name = "buttonPrikaziStanjeSank";
            this.buttonPrikaziStanjeSank.Size = new System.Drawing.Size(150, 50);
            this.buttonPrikaziStanjeSank.TabIndex = 10;
            this.buttonPrikaziStanjeSank.Text = "Prikaži";
            this.buttonPrikaziStanjeSank.UseVisualStyleBackColor = true;
            this.buttonPrikaziStanjeSank.Click += new System.EventHandler(this.buttonPrikaziStanjeSank_Click);
            // 
            // dataGridViewStanjeSank
            // 
            this.dataGridViewStanjeSank.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridViewStanjeSank.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridViewStanjeSank.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewStanjeSank.Location = new System.Drawing.Point(28, 100);
            this.dataGridViewStanjeSank.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridViewStanjeSank.Name = "dataGridViewStanjeSank";
            this.dataGridViewStanjeSank.RowHeadersWidth = 51;
            this.dataGridViewStanjeSank.RowTemplate.Height = 24;
            this.dataGridViewStanjeSank.Size = new System.Drawing.Size(550, 300);
            this.dataGridViewStanjeSank.TabIndex = 11;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonStanjeSkladista);
            this.groupBox1.Controls.Add(this.dataGridViewStanjeSkladista);
            this.groupBox1.Location = new System.Drawing.Point(121, 32);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(600, 430);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Stanje skladišta";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.buttonPrikaziStanjeSank);
            this.groupBox2.Controls.Add(this.dataGridViewStanjeSank);
            this.groupBox2.Location = new System.Drawing.Point(765, 32);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(600, 430);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Stanje šanka";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.labelOdaberiPiceZaSank);
            this.groupBox3.Controls.Add(this.comboBoxOdaberiPiceZaSank);
            this.groupBox3.Controls.Add(this.labelOdaberiKolicinu);
            this.groupBox3.Controls.Add(this.buttonDodajUSank);
            this.groupBox3.Controls.Add(this.numericUpDownOdaberiKolicinuZaSank);
            this.groupBox3.Location = new System.Drawing.Point(122, 482);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1243, 186);
            this.groupBox3.TabIndex = 14;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Premjesti iz skladišta";
            // 
            // KonobarForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1651, 775);
            this.Controls.Add(this.gumbOdjavaKonobara);
            this.Controls.Add(this.tabKonobar);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "KonobarForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "KonobarForm";
            this.Load += new System.EventHandler(this.KonobarForm_Load);
            this.tabKonobar.ResumeLayout(false);
            this.tabIzdajRacun.ResumeLayout(false);
            this.tabIzdajRacun.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPica)).EndInit();
            this.tabSkladiste.ResumeLayout(false);
            this.tabSkladiste.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStanjeSkladista)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownOdaberiKolicinuZaSank)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStanjeSank)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
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
        private System.Windows.Forms.DataGridView dataGridViewStanjeSkladista;
        private System.Windows.Forms.Button buttonStanjeSkladista;
        private System.Windows.Forms.Label labelSkladiste;
        private System.Windows.Forms.ComboBox comboBoxOdaberiPiceZaSank;
        private System.Windows.Forms.Label labelOdaberiPiceZaSank;
        private System.Windows.Forms.Button buttonDodajUSank;
        private System.Windows.Forms.NumericUpDown numericUpDownOdaberiKolicinuZaSank;
        private System.Windows.Forms.Label labelOdaberiKolicinu;
        private System.Windows.Forms.Button buttonPrikaziStanjeSank;
        private System.Windows.Forms.DataGridView dataGridViewStanjeSank;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
    }
}