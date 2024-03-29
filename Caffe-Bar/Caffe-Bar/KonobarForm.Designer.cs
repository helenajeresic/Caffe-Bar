﻿namespace CaffeBar
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
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.labelOdaberiPiceZaSank = new System.Windows.Forms.Label();
            this.comboBoxOdaberiPiceZaSank = new System.Windows.Forms.ComboBox();
            this.labelOdaberiKolicinu = new System.Windows.Forms.Label();
            this.buttonDodajUSank = new System.Windows.Forms.Button();
            this.numericUpDownOdaberiKolicinuZaSank = new System.Windows.Forms.NumericUpDown();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.buttonPrikaziStanjeSank = new System.Windows.Forms.Button();
            this.dataGridViewStanjeSank = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonStanjeSkladista = new System.Windows.Forms.Button();
            this.dataGridViewStanjeSkladista = new System.Windows.Forms.DataGridView();
            this.labelSkladiste = new System.Windows.Forms.Label();
            this.tabRacuni = new System.Windows.Forms.TabPage();
            this.groupBoxPregledRacuna = new System.Windows.Forms.GroupBox();
            this.dataGridViewRacuni = new System.Windows.Forms.DataGridView();
            this.buttonPrikaziRacune = new System.Windows.Forms.Button();
            this.tabNarudžba = new System.Windows.Forms.TabPage();
            this.groupBoxNarudzba = new System.Windows.Forms.GroupBox();
            this.groupBoxNarudzbeZalihe = new System.Windows.Forms.GroupBox();
            this.buttonNarudzbaZaliha = new System.Windows.Forms.Button();
            this.dataGridViewNarudzbaZaliha = new System.Windows.Forms.DataGridView();
            this.buttonNarudzba = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.labelNarudzbaPice = new System.Windows.Forms.Label();
            this.buttonNarudžba = new System.Windows.Forms.Button();
            this.dataGridViewNarudzba = new System.Windows.Forms.DataGridView();
            this.numericUpDownNarudzba = new System.Windows.Forms.NumericUpDown();
            this.comboBoxNarudzba = new System.Windows.Forms.ComboBox();
            this.gumbOdjavaKonobara = new System.Windows.Forms.Button();
            this.tabKonobar.SuspendLayout();
            this.tabIzdajRacun.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPica)).BeginInit();
            this.tabSkladiste.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownOdaberiKolicinuZaSank)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStanjeSank)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStanjeSkladista)).BeginInit();
            this.tabRacuni.SuspendLayout();
            this.groupBoxPregledRacuna.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRacuni)).BeginInit();
            this.tabNarudžba.SuspendLayout();
            this.groupBoxNarudzba.SuspendLayout();
            this.groupBoxNarudzbeZalihe.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewNarudzbaZaliha)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewNarudzba)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNarudzba)).BeginInit();
            this.SuspendLayout();
            // 
            // tabKonobar
            // 
            this.tabKonobar.Controls.Add(this.tabIzdajRacun);
            this.tabKonobar.Controls.Add(this.tabSkladiste);
            this.tabKonobar.Controls.Add(this.tabRacuni);
            this.tabKonobar.Controls.Add(this.tabNarudžba);
            this.tabKonobar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tabKonobar.ItemSize = new System.Drawing.Size(100, 50);
            this.tabKonobar.Location = new System.Drawing.Point(10, 12);
            this.tabKonobar.Multiline = true;
            this.tabKonobar.Name = "tabKonobar";
            this.tabKonobar.SelectedIndex = 0;
            this.tabKonobar.Size = new System.Drawing.Size(1194, 612);
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
            this.tabIzdajRacun.Margin = new System.Windows.Forms.Padding(5);
            this.tabIzdajRacun.Name = "tabIzdajRacun";
            this.tabIzdajRacun.Padding = new System.Windows.Forms.Padding(4);
            this.tabIzdajRacun.Size = new System.Drawing.Size(1186, 554);
            this.tabIzdajRacun.TabIndex = 0;
            this.tabIzdajRacun.Text = "Izdaj račun";
            this.tabIzdajRacun.UseVisualStyleBackColor = true;
            // 
            // labelUsername
            // 
            this.labelUsername.AutoSize = true;
            this.labelUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelUsername.Location = new System.Drawing.Point(827, 35);
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
            this.labelAkcijaUTijeku.Location = new System.Drawing.Point(448, 35);
            this.labelAkcijaUTijeku.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelAkcijaUTijeku.Name = "labelAkcijaUTijeku";
            this.labelAkcijaUTijeku.Size = new System.Drawing.Size(0, 25);
            this.labelAkcijaUTijeku.TabIndex = 9;
            // 
            // buttonOcistiRacun
            // 
            this.buttonOcistiRacun.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonOcistiRacun.Location = new System.Drawing.Point(999, 324);
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
            this.buttonKonobarskiPopust.Location = new System.Drawing.Point(999, 401);
            this.buttonKonobarskiPopust.Margin = new System.Windows.Forms.Padding(2);
            this.buttonKonobarskiPopust.Name = "buttonKonobarskiPopust";
            this.buttonKonobarskiPopust.Size = new System.Drawing.Size(155, 48);
            this.buttonKonobarskiPopust.TabIndex = 7;
            this.buttonKonobarskiPopust.Text = "Iskoristi popust";
            this.buttonKonobarskiPopust.UseVisualStyleBackColor = true;
            this.buttonKonobarskiPopust.Click += new System.EventHandler(this.buttonKonobarskiPopust_Click);
            // 
            // gumbIzdajRacun
            // 
            this.gumbIzdajRacun.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.gumbIzdajRacun.Location = new System.Drawing.Point(999, 488);
            this.gumbIzdajRacun.Margin = new System.Windows.Forms.Padding(2);
            this.gumbIzdajRacun.Name = "gumbIzdajRacun";
            this.gumbIzdajRacun.Size = new System.Drawing.Size(155, 48);
            this.gumbIzdajRacun.TabIndex = 6;
            this.gumbIzdajRacun.Text = "Izdaj račun";
            this.gumbIzdajRacun.UseVisualStyleBackColor = true;
            this.gumbIzdajRacun.Click += new System.EventHandler(this.gumbIzdajRacun_Click);
            // 
            // textRacuna
            // 
            this.textRacuna.Location = new System.Drawing.Point(453, 93);
            this.textRacuna.Name = "textRacuna";
            this.textRacuna.ReadOnly = true;
            this.textRacuna.Size = new System.Drawing.Size(527, 443);
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
            this.dataGridViewPica.AllowUserToAddRows = false;
            this.dataGridViewPica.AllowUserToDeleteRows = false;
            this.dataGridViewPica.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridViewPica.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridViewPica.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dataGridViewPica.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewPica.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPica.GridColor = System.Drawing.SystemColors.ActiveCaption;
            this.dataGridViewPica.Location = new System.Drawing.Point(22, 93);
            this.dataGridViewPica.Name = "dataGridViewPica";
            this.dataGridViewPica.ReadOnly = true;
            this.dataGridViewPica.RowHeadersWidth = 51;
            this.dataGridViewPica.Size = new System.Drawing.Size(413, 443);
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
            this.tabSkladiste.Controls.Add(this.groupBox3);
            this.tabSkladiste.Controls.Add(this.groupBox2);
            this.tabSkladiste.Controls.Add(this.groupBox1);
            this.tabSkladiste.Controls.Add(this.labelSkladiste);
            this.tabSkladiste.Location = new System.Drawing.Point(4, 54);
            this.tabSkladiste.Margin = new System.Windows.Forms.Padding(5);
            this.tabSkladiste.Name = "tabSkladiste";
            this.tabSkladiste.Padding = new System.Windows.Forms.Padding(4);
            this.tabSkladiste.Size = new System.Drawing.Size(1186, 554);
            this.tabSkladiste.TabIndex = 1;
            this.tabSkladiste.Text = "Zalihe";
            this.tabSkladiste.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.labelOdaberiPiceZaSank);
            this.groupBox3.Controls.Add(this.comboBoxOdaberiPiceZaSank);
            this.groupBox3.Controls.Add(this.labelOdaberiKolicinu);
            this.groupBox3.Controls.Add(this.buttonDodajUSank);
            this.groupBox3.Controls.Add(this.numericUpDownOdaberiKolicinuZaSank);
            this.groupBox3.Location = new System.Drawing.Point(92, 392);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox3.Size = new System.Drawing.Size(932, 151);
            this.groupBox3.TabIndex = 14;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Premjesti iz skladišta";
            // 
            // labelOdaberiPiceZaSank
            // 
            this.labelOdaberiPiceZaSank.AutoSize = true;
            this.labelOdaberiPiceZaSank.Location = new System.Drawing.Point(93, 39);
            this.labelOdaberiPiceZaSank.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelOdaberiPiceZaSank.Name = "labelOdaberiPiceZaSank";
            this.labelOdaberiPiceZaSank.Size = new System.Drawing.Size(124, 24);
            this.labelOdaberiPiceZaSank.TabIndex = 4;
            this.labelOdaberiPiceZaSank.Text = "Odaberi piće:";
            // 
            // comboBoxOdaberiPiceZaSank
            // 
            this.comboBoxOdaberiPiceZaSank.FormattingEnabled = true;
            this.comboBoxOdaberiPiceZaSank.Location = new System.Drawing.Point(232, 31);
            this.comboBoxOdaberiPiceZaSank.Margin = new System.Windows.Forms.Padding(2);
            this.comboBoxOdaberiPiceZaSank.Name = "comboBoxOdaberiPiceZaSank";
            this.comboBoxOdaberiPiceZaSank.Size = new System.Drawing.Size(184, 32);
            this.comboBoxOdaberiPiceZaSank.TabIndex = 5;
            // 
            // labelOdaberiKolicinu
            // 
            this.labelOdaberiKolicinu.AutoSize = true;
            this.labelOdaberiKolicinu.Location = new System.Drawing.Point(65, 72);
            this.labelOdaberiKolicinu.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelOdaberiKolicinu.Name = "labelOdaberiKolicinu";
            this.labelOdaberiKolicinu.Size = new System.Drawing.Size(152, 24);
            this.labelOdaberiKolicinu.TabIndex = 7;
            this.labelOdaberiKolicinu.Text = "Odaberi količinu:";
            // 
            // buttonDodajUSank
            // 
            this.buttonDodajUSank.Location = new System.Drawing.Point(232, 116);
            this.buttonDodajUSank.Margin = new System.Windows.Forms.Padding(2);
            this.buttonDodajUSank.Name = "buttonDodajUSank";
            this.buttonDodajUSank.Size = new System.Drawing.Size(184, 31);
            this.buttonDodajUSank.TabIndex = 6;
            this.buttonDodajUSank.Text = "Dodaj u šank";
            this.buttonDodajUSank.UseVisualStyleBackColor = true;
            this.buttonDodajUSank.Click += new System.EventHandler(this.buttonDodajUSank_Click);
            // 
            // numericUpDownOdaberiKolicinuZaSank
            // 
            this.numericUpDownOdaberiKolicinuZaSank.Location = new System.Drawing.Point(232, 67);
            this.numericUpDownOdaberiKolicinuZaSank.Margin = new System.Windows.Forms.Padding(2);
            this.numericUpDownOdaberiKolicinuZaSank.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.numericUpDownOdaberiKolicinuZaSank.Name = "numericUpDownOdaberiKolicinuZaSank";
            this.numericUpDownOdaberiKolicinuZaSank.Size = new System.Drawing.Size(184, 29);
            this.numericUpDownOdaberiKolicinuZaSank.TabIndex = 8;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.buttonPrikaziStanjeSank);
            this.groupBox2.Controls.Add(this.dataGridViewStanjeSank);
            this.groupBox2.Location = new System.Drawing.Point(574, 26);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(450, 349);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Stanje šanka";
            // 
            // buttonPrikaziStanjeSank
            // 
            this.buttonPrikaziStanjeSank.Location = new System.Drawing.Point(321, 26);
            this.buttonPrikaziStanjeSank.Margin = new System.Windows.Forms.Padding(2);
            this.buttonPrikaziStanjeSank.Name = "buttonPrikaziStanjeSank";
            this.buttonPrikaziStanjeSank.Size = new System.Drawing.Size(112, 41);
            this.buttonPrikaziStanjeSank.TabIndex = 10;
            this.buttonPrikaziStanjeSank.Text = "Prikaži";
            this.buttonPrikaziStanjeSank.UseVisualStyleBackColor = true;
            this.buttonPrikaziStanjeSank.Click += new System.EventHandler(this.buttonPrikaziStanjeSank_Click);
            // 
            // dataGridViewStanjeSank
            // 
            this.dataGridViewStanjeSank.AllowUserToAddRows = false;
            this.dataGridViewStanjeSank.AllowUserToDeleteRows = false;
            this.dataGridViewStanjeSank.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewStanjeSank.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridViewStanjeSank.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dataGridViewStanjeSank.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dataGridViewStanjeSank.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dataGridViewStanjeSank.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewStanjeSank.EnableHeadersVisualStyles = false;
            this.dataGridViewStanjeSank.GridColor = System.Drawing.Color.Gray;
            this.dataGridViewStanjeSank.Location = new System.Drawing.Point(21, 81);
            this.dataGridViewStanjeSank.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridViewStanjeSank.Name = "dataGridViewStanjeSank";
            this.dataGridViewStanjeSank.ReadOnly = true;
            this.dataGridViewStanjeSank.RowHeadersWidth = 51;
            this.dataGridViewStanjeSank.RowTemplate.Height = 24;
            this.dataGridViewStanjeSank.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewStanjeSank.Size = new System.Drawing.Size(412, 244);
            this.dataGridViewStanjeSank.TabIndex = 11;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonStanjeSkladista);
            this.groupBox1.Controls.Add(this.dataGridViewStanjeSkladista);
            this.groupBox1.Location = new System.Drawing.Point(91, 26);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(450, 349);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Stanje skladišta";
            // 
            // buttonStanjeSkladista
            // 
            this.buttonStanjeSkladista.Location = new System.Drawing.Point(322, 27);
            this.buttonStanjeSkladista.Margin = new System.Windows.Forms.Padding(2);
            this.buttonStanjeSkladista.Name = "buttonStanjeSkladista";
            this.buttonStanjeSkladista.Size = new System.Drawing.Size(112, 41);
            this.buttonStanjeSkladista.TabIndex = 1;
            this.buttonStanjeSkladista.Text = "Prikaži";
            this.buttonStanjeSkladista.UseVisualStyleBackColor = true;
            this.buttonStanjeSkladista.Click += new System.EventHandler(this.buttonStanjeSkladista_Click);
            // 
            // dataGridViewStanjeSkladista
            // 
            this.dataGridViewStanjeSkladista.AllowUserToAddRows = false;
            this.dataGridViewStanjeSkladista.AllowUserToDeleteRows = false;
            this.dataGridViewStanjeSkladista.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewStanjeSkladista.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridViewStanjeSkladista.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dataGridViewStanjeSkladista.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dataGridViewStanjeSkladista.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dataGridViewStanjeSkladista.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewStanjeSkladista.EnableHeadersVisualStyles = false;
            this.dataGridViewStanjeSkladista.GridColor = System.Drawing.Color.Gray;
            this.dataGridViewStanjeSkladista.Location = new System.Drawing.Point(22, 81);
            this.dataGridViewStanjeSkladista.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridViewStanjeSkladista.Name = "dataGridViewStanjeSkladista";
            this.dataGridViewStanjeSkladista.ReadOnly = true;
            this.dataGridViewStanjeSkladista.RowHeadersWidth = 51;
            this.dataGridViewStanjeSkladista.RowTemplate.Height = 24;
            this.dataGridViewStanjeSkladista.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewStanjeSkladista.Size = new System.Drawing.Size(412, 244);
            this.dataGridViewStanjeSkladista.TabIndex = 2;
            // 
            // labelSkladiste
            // 
            this.labelSkladiste.AutoSize = true;
            this.labelSkladiste.Location = new System.Drawing.Point(512, 37);
            this.labelSkladiste.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelSkladiste.Name = "labelSkladiste";
            this.labelSkladiste.Size = new System.Drawing.Size(15, 24);
            this.labelSkladiste.TabIndex = 3;
            this.labelSkladiste.Text = ".";
            // 
            // tabRacuni
            // 
            this.tabRacuni.Controls.Add(this.groupBoxPregledRacuna);
            this.tabRacuni.Location = new System.Drawing.Point(4, 54);
            this.tabRacuni.Margin = new System.Windows.Forms.Padding(5);
            this.tabRacuni.Name = "tabRacuni";
            this.tabRacuni.Padding = new System.Windows.Forms.Padding(4);
            this.tabRacuni.Size = new System.Drawing.Size(1186, 554);
            this.tabRacuni.TabIndex = 2;
            this.tabRacuni.Text = "Računi";
            this.tabRacuni.UseVisualStyleBackColor = true;
            // 
            // groupBoxPregledRacuna
            // 
            this.groupBoxPregledRacuna.Controls.Add(this.dataGridViewRacuni);
            this.groupBoxPregledRacuna.Controls.Add(this.buttonPrikaziRacune);
            this.groupBoxPregledRacuna.Location = new System.Drawing.Point(22, 25);
            this.groupBoxPregledRacuna.Margin = new System.Windows.Forms.Padding(2);
            this.groupBoxPregledRacuna.Name = "groupBoxPregledRacuna";
            this.groupBoxPregledRacuna.Padding = new System.Windows.Forms.Padding(2);
            this.groupBoxPregledRacuna.Size = new System.Drawing.Size(1125, 502);
            this.groupBoxPregledRacuna.TabIndex = 0;
            this.groupBoxPregledRacuna.TabStop = false;
            this.groupBoxPregledRacuna.Text = "Pregled svih računa";
            // 
            // dataGridViewRacuni
            // 
            this.dataGridViewRacuni.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewRacuni.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridViewRacuni.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dataGridViewRacuni.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dataGridViewRacuni.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dataGridViewRacuni.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewRacuni.GridColor = System.Drawing.Color.Gray;
            this.dataGridViewRacuni.Location = new System.Drawing.Point(20, 101);
            this.dataGridViewRacuni.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridViewRacuni.Name = "dataGridViewRacuni";
            this.dataGridViewRacuni.RowHeadersWidth = 51;
            this.dataGridViewRacuni.RowTemplate.Height = 24;
            this.dataGridViewRacuni.Size = new System.Drawing.Size(1076, 372);
            this.dataGridViewRacuni.TabIndex = 1;
            this.dataGridViewRacuni.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewRacuni_CellClick);
            // 
            // buttonPrikaziRacune
            // 
            this.buttonPrikaziRacune.Location = new System.Drawing.Point(20, 41);
            this.buttonPrikaziRacune.Margin = new System.Windows.Forms.Padding(2);
            this.buttonPrikaziRacune.Name = "buttonPrikaziRacune";
            this.buttonPrikaziRacune.Size = new System.Drawing.Size(158, 43);
            this.buttonPrikaziRacune.TabIndex = 0;
            this.buttonPrikaziRacune.Text = "Prikaži";
            this.buttonPrikaziRacune.UseVisualStyleBackColor = true;
            this.buttonPrikaziRacune.Click += new System.EventHandler(this.buttonPrikaziRacune_Click);
            // 
            // tabNarudžba
            // 
            this.tabNarudžba.Controls.Add(this.groupBoxNarudzba);
            this.tabNarudžba.Location = new System.Drawing.Point(4, 54);
            this.tabNarudžba.Margin = new System.Windows.Forms.Padding(5);
            this.tabNarudžba.Name = "tabNarudžba";
            this.tabNarudžba.Padding = new System.Windows.Forms.Padding(4);
            this.tabNarudžba.Size = new System.Drawing.Size(1186, 554);
            this.tabNarudžba.TabIndex = 3;
            this.tabNarudžba.Text = "Narudžba";
            this.tabNarudžba.UseVisualStyleBackColor = true;
            // 
            // groupBoxNarudzba
            // 
            this.groupBoxNarudzba.Controls.Add(this.groupBoxNarudzbeZalihe);
            this.groupBoxNarudzba.Controls.Add(this.buttonNarudzba);
            this.groupBoxNarudzba.Controls.Add(this.label2);
            this.groupBoxNarudzba.Controls.Add(this.labelNarudzbaPice);
            this.groupBoxNarudzba.Controls.Add(this.buttonNarudžba);
            this.groupBoxNarudzba.Controls.Add(this.dataGridViewNarudzba);
            this.groupBoxNarudzba.Controls.Add(this.numericUpDownNarudzba);
            this.groupBoxNarudzba.Controls.Add(this.comboBoxNarudzba);
            this.groupBoxNarudzba.Location = new System.Drawing.Point(16, 20);
            this.groupBoxNarudzba.Name = "groupBoxNarudzba";
            this.groupBoxNarudzba.Size = new System.Drawing.Size(1163, 527);
            this.groupBoxNarudzba.TabIndex = 0;
            this.groupBoxNarudzba.TabStop = false;
            this.groupBoxNarudzba.Text = "Izradi novu narudžbu";
            // 
            // groupBoxNarudzbeZalihe
            // 
            this.groupBoxNarudzbeZalihe.Controls.Add(this.buttonNarudzbaZaliha);
            this.groupBoxNarudzbeZalihe.Controls.Add(this.dataGridViewNarudzbaZaliha);
            this.groupBoxNarudzbeZalihe.Location = new System.Drawing.Point(22, 238);
            this.groupBoxNarudzbeZalihe.Name = "groupBoxNarudzbeZalihe";
            this.groupBoxNarudzbeZalihe.Size = new System.Drawing.Size(580, 270);
            this.groupBoxNarudzbeZalihe.TabIndex = 7;
            this.groupBoxNarudzbeZalihe.TabStop = false;
            this.groupBoxNarudzbeZalihe.Text = "Niske zalihe sljedećih pića";
            // 
            // buttonNarudzbaZaliha
            // 
            this.buttonNarudzbaZaliha.Location = new System.Drawing.Point(16, 40);
            this.buttonNarudzbaZaliha.Name = "buttonNarudzbaZaliha";
            this.buttonNarudzbaZaliha.Size = new System.Drawing.Size(172, 31);
            this.buttonNarudzbaZaliha.TabIndex = 1;
            this.buttonNarudzbaZaliha.Text = "Prikaži";
            this.buttonNarudzbaZaliha.UseVisualStyleBackColor = true;
            this.buttonNarudzbaZaliha.Click += new System.EventHandler(this.buttonNarudzbaZaliha_Click);
            // 
            // dataGridViewNarudzbaZaliha
            // 
            this.dataGridViewNarudzbaZaliha.AllowUserToAddRows = false;
            this.dataGridViewNarudzbaZaliha.AllowUserToDeleteRows = false;
            this.dataGridViewNarudzbaZaliha.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewNarudzbaZaliha.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridViewNarudzbaZaliha.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dataGridViewNarudzbaZaliha.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dataGridViewNarudzbaZaliha.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dataGridViewNarudzbaZaliha.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewNarudzbaZaliha.GridColor = System.Drawing.Color.Gray;
            this.dataGridViewNarudzbaZaliha.Location = new System.Drawing.Point(16, 77);
            this.dataGridViewNarudzbaZaliha.Name = "dataGridViewNarudzbaZaliha";
            this.dataGridViewNarudzbaZaliha.ReadOnly = true;
            this.dataGridViewNarudzbaZaliha.RowHeadersWidth = 51;
            this.dataGridViewNarudzbaZaliha.Size = new System.Drawing.Size(545, 187);
            this.dataGridViewNarudzbaZaliha.TabIndex = 0;
            // 
            // buttonNarudzba
            // 
            this.buttonNarudzba.Location = new System.Drawing.Point(180, 180);
            this.buttonNarudzba.Name = "buttonNarudzba";
            this.buttonNarudzba.Size = new System.Drawing.Size(247, 31);
            this.buttonNarudzba.TabIndex = 6;
            this.buttonNarudzba.Text = "Naruči";
            this.buttonNarudzba.UseVisualStyleBackColor = true;
            this.buttonNarudzba.Click += new System.EventHandler(this.buttonNarudzba_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 136);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(147, 24);
            this.label2.TabIndex = 5;
            this.label2.Text = "Odaberi količinu";
            // 
            // labelNarudzbaPice
            // 
            this.labelNarudzbaPice.AutoSize = true;
            this.labelNarudzbaPice.Location = new System.Drawing.Point(34, 79);
            this.labelNarudzbaPice.Name = "labelNarudzbaPice";
            this.labelNarudzbaPice.Size = new System.Drawing.Size(119, 24);
            this.labelNarudzbaPice.TabIndex = 4;
            this.labelNarudzbaPice.Text = "Odaberi piće";
            // 
            // buttonNarudžba
            // 
            this.buttonNarudžba.Location = new System.Drawing.Point(789, 28);
            this.buttonNarudžba.Name = "buttonNarudžba";
            this.buttonNarudžba.Size = new System.Drawing.Size(227, 32);
            this.buttonNarudžba.TabIndex = 3;
            this.buttonNarudžba.Text = "Prikaži sve narudžbe";
            this.buttonNarudžba.UseVisualStyleBackColor = true;
            this.buttonNarudžba.Click += new System.EventHandler(this.buttonNarudžba_Click);
            // 
            // dataGridViewNarudzba
            // 
            this.dataGridViewNarudzba.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewNarudzba.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridViewNarudzba.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dataGridViewNarudzba.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dataGridViewNarudzba.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dataGridViewNarudzba.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewNarudzba.GridColor = System.Drawing.Color.Gray;
            this.dataGridViewNarudzba.Location = new System.Drawing.Point(636, 79);
            this.dataGridViewNarudzba.Name = "dataGridViewNarudzba";
            this.dataGridViewNarudzba.RowHeadersWidth = 51;
            this.dataGridViewNarudzba.Size = new System.Drawing.Size(521, 429);
            this.dataGridViewNarudzba.TabIndex = 2;
            this.dataGridViewNarudzba.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewNarudzba_CellClick);
            // 
            // numericUpDownNarudzba
            // 
            this.numericUpDownNarudzba.Location = new System.Drawing.Point(180, 131);
            this.numericUpDownNarudzba.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDownNarudzba.Name = "numericUpDownNarudzba";
            this.numericUpDownNarudzba.Size = new System.Drawing.Size(247, 29);
            this.numericUpDownNarudzba.TabIndex = 1;
            this.numericUpDownNarudzba.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // comboBoxNarudzba
            // 
            this.comboBoxNarudzba.FormattingEnabled = true;
            this.comboBoxNarudzba.Location = new System.Drawing.Point(180, 71);
            this.comboBoxNarudzba.Name = "comboBoxNarudzba";
            this.comboBoxNarudzba.Size = new System.Drawing.Size(247, 32);
            this.comboBoxNarudzba.TabIndex = 0;
            // 
            // gumbOdjavaKonobara
            // 
            this.gumbOdjavaKonobara.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.gumbOdjavaKonobara.Location = new System.Drawing.Point(1066, 10);
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
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "KonobarForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "KonobarForm";
            this.tabKonobar.ResumeLayout(false);
            this.tabIzdajRacun.ResumeLayout(false);
            this.tabIzdajRacun.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPica)).EndInit();
            this.tabSkladiste.ResumeLayout(false);
            this.tabSkladiste.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownOdaberiKolicinuZaSank)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStanjeSank)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStanjeSkladista)).EndInit();
            this.tabRacuni.ResumeLayout(false);
            this.groupBoxPregledRacuna.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRacuni)).EndInit();
            this.tabNarudžba.ResumeLayout(false);
            this.groupBoxNarudzba.ResumeLayout(false);
            this.groupBoxNarudzba.PerformLayout();
            this.groupBoxNarudzbeZalihe.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewNarudzbaZaliha)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewNarudzba)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNarudzba)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabKonobar;
        private System.Windows.Forms.TabPage tabSkladiste;
        private System.Windows.Forms.Button gumbOdjavaKonobara;
        private System.Windows.Forms.TabPage tabRacuni;
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
        private System.Windows.Forms.GroupBox groupBoxNarudzba;
        private System.Windows.Forms.NumericUpDown numericUpDownNarudzba;
        private System.Windows.Forms.ComboBox comboBoxNarudzba;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelNarudzbaPice;
        private System.Windows.Forms.Button buttonNarudžba;
        private System.Windows.Forms.DataGridView dataGridViewNarudzba;
        private System.Windows.Forms.Button buttonNarudzba;
        private System.Windows.Forms.GroupBox groupBoxNarudzbeZalihe;
        private System.Windows.Forms.DataGridView dataGridViewNarudzbaZaliha;
        private System.Windows.Forms.Button buttonNarudzbaZaliha;
        private System.Windows.Forms.GroupBox groupBoxPregledRacuna;
        private System.Windows.Forms.Button buttonPrikaziRacune;
        private System.Windows.Forms.DataGridView dataGridViewRacuni;
    }
}