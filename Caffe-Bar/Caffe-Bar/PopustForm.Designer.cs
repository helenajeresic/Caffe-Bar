namespace CaffeBar
{
    partial class PopustForm
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
            this.components = new System.ComponentModel.Container();
            this.gumbPopustIzdajRacun = new System.Windows.Forms.Button();
            this.gumbOdustaniPopust = new System.Windows.Forms.Button();
            this.bazaDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bazaDataSet = new Caffe_Bar.bazaDataSet();
            this.odabirKonobara = new System.Windows.Forms.ComboBox();
            this.labelOdabirKonobaraPopust = new System.Windows.Forms.Label();
            this.checkBoxIskoristiBesplatnuKavu = new System.Windows.Forms.CheckBox();
            this.checkBoxIskoristiBespalatanSok = new System.Windows.Forms.CheckBox();
            this.checkBoxIskoristiPopust = new System.Windows.Forms.CheckBox();
            this.buttonIskoristiPopust = new System.Windows.Forms.Button();
            this.labelStanjeNakonAkcije = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bazaDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bazaDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // gumbPopustIzdajRacun
            // 
            this.gumbPopustIzdajRacun.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.gumbPopustIzdajRacun.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.gumbPopustIzdajRacun.Location = new System.Drawing.Point(468, 374);
            this.gumbPopustIzdajRacun.Name = "gumbPopustIzdajRacun";
            this.gumbPopustIzdajRacun.Size = new System.Drawing.Size(112, 34);
            this.gumbPopustIzdajRacun.TabIndex = 1;
            this.gumbPopustIzdajRacun.Text = "Potvrdi";
            this.gumbPopustIzdajRacun.UseVisualStyleBackColor = true;
            this.gumbPopustIzdajRacun.Click += new System.EventHandler(this.gumbPopustIzdajRacun_Click);
            // 
            // gumbOdustaniPopust
            // 
            this.gumbOdustaniPopust.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.gumbOdustaniPopust.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.gumbOdustaniPopust.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.gumbOdustaniPopust.Location = new System.Drawing.Point(624, 374);
            this.gumbOdustaniPopust.Name = "gumbOdustaniPopust";
            this.gumbOdustaniPopust.Size = new System.Drawing.Size(112, 34);
            this.gumbOdustaniPopust.TabIndex = 2;
            this.gumbOdustaniPopust.TabStop = false;
            this.gumbOdustaniPopust.Text = "Odustani";
            this.gumbOdustaniPopust.UseVisualStyleBackColor = true;
            this.gumbOdustaniPopust.Click += new System.EventHandler(this.gumbOdustaniPopust_Click);
            // 
            // bazaDataSetBindingSource
            // 
            this.bazaDataSetBindingSource.DataSource = this.bazaDataSet;
            this.bazaDataSetBindingSource.Position = 0;
            // 
            // bazaDataSet
            // 
            this.bazaDataSet.DataSetName = "bazaDataSet";
            this.bazaDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // odabirKonobara
            // 
            this.odabirKonobara.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.odabirKonobara.FormattingEnabled = true;
            this.odabirKonobara.Location = new System.Drawing.Point(491, 27);
            this.odabirKonobara.Name = "odabirKonobara";
            this.odabirKonobara.Size = new System.Drawing.Size(245, 33);
            this.odabirKonobara.TabIndex = 3;
            this.odabirKonobara.SelectedIndexChanged += new System.EventHandler(this.odabirKonobara_SelectedIndexChanged);
            // 
            // labelOdabirKonobaraPopust
            // 
            this.labelOdabirKonobaraPopust.AutoSize = true;
            this.labelOdabirKonobaraPopust.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelOdabirKonobaraPopust.Location = new System.Drawing.Point(39, 30);
            this.labelOdabirKonobaraPopust.Name = "labelOdabirKonobaraPopust";
            this.labelOdabirKonobaraPopust.Size = new System.Drawing.Size(427, 25);
            this.labelOdabirKonobaraPopust.TabIndex = 4;
            this.labelOdabirKonobaraPopust.Text = "Odaberite konobara koji iskorištava popust:";
            // 
            // checkBoxIskoristiBesplatnuKavu
            // 
            this.checkBoxIskoristiBesplatnuKavu.AutoSize = true;
            this.checkBoxIskoristiBesplatnuKavu.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.checkBoxIskoristiBesplatnuKavu.Location = new System.Drawing.Point(44, 128);
            this.checkBoxIskoristiBesplatnuKavu.Name = "checkBoxIskoristiBesplatnuKavu";
            this.checkBoxIskoristiBesplatnuKavu.Size = new System.Drawing.Size(256, 29);
            this.checkBoxIskoristiBesplatnuKavu.TabIndex = 5;
            this.checkBoxIskoristiBesplatnuKavu.Text = "Iskoristi besplatnu kavu";
            this.checkBoxIskoristiBesplatnuKavu.UseVisualStyleBackColor = true;
            // 
            // checkBoxIskoristiBespalatanSok
            // 
            this.checkBoxIskoristiBespalatanSok.AutoSize = true;
            this.checkBoxIskoristiBespalatanSok.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.checkBoxIskoristiBespalatanSok.Location = new System.Drawing.Point(44, 188);
            this.checkBoxIskoristiBespalatanSok.Name = "checkBoxIskoristiBespalatanSok";
            this.checkBoxIskoristiBespalatanSok.Size = new System.Drawing.Size(244, 29);
            this.checkBoxIskoristiBespalatanSok.TabIndex = 6;
            this.checkBoxIskoristiBespalatanSok.Text = "Iskoristi besplatan sok";
            this.checkBoxIskoristiBespalatanSok.UseVisualStyleBackColor = true;
            // 
            // checkBoxIskoristiPopust
            // 
            this.checkBoxIskoristiPopust.AutoSize = true;
            this.checkBoxIskoristiPopust.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.checkBoxIskoristiPopust.Location = new System.Drawing.Point(44, 255);
            this.checkBoxIskoristiPopust.Name = "checkBoxIskoristiPopust";
            this.checkBoxIskoristiPopust.Size = new System.Drawing.Size(224, 29);
            this.checkBoxIskoristiPopust.TabIndex = 7;
            this.checkBoxIskoristiPopust.Text = "Iskoristi popust 20%";
            this.checkBoxIskoristiPopust.UseVisualStyleBackColor = true;
            // 
            // buttonIskoristiPopust
            // 
            this.buttonIskoristiPopust.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.buttonIskoristiPopust.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.buttonIskoristiPopust.Location = new System.Drawing.Point(44, 374);
            this.buttonIskoristiPopust.Name = "buttonIskoristiPopust";
            this.buttonIskoristiPopust.Size = new System.Drawing.Size(159, 34);
            this.buttonIskoristiPopust.TabIndex = 9;
            this.buttonIskoristiPopust.Text = "Iskoristi popust";
            this.buttonIskoristiPopust.UseVisualStyleBackColor = true;
            this.buttonIskoristiPopust.Click += new System.EventHandler(this.buttonIskoristiPopust_Click);
            // 
            // labelStanjeNakonAkcije
            // 
            this.labelStanjeNakonAkcije.AutoSize = true;
            this.labelStanjeNakonAkcije.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelStanjeNakonAkcije.Location = new System.Drawing.Point(468, 128);
            this.labelStanjeNakonAkcije.Name = "labelStanjeNakonAkcije";
            this.labelStanjeNakonAkcije.Size = new System.Drawing.Size(0, 24);
            this.labelStanjeNakonAkcije.TabIndex = 10;
            // 
            // PopustForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.CancelButton = this.gumbOdustaniPopust;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.labelStanjeNakonAkcije);
            this.Controls.Add(this.buttonIskoristiPopust);
            this.Controls.Add(this.checkBoxIskoristiPopust);
            this.Controls.Add(this.checkBoxIskoristiBespalatanSok);
            this.Controls.Add(this.checkBoxIskoristiBesplatnuKavu);
            this.Controls.Add(this.labelOdabirKonobaraPopust);
            this.Controls.Add(this.odabirKonobara);
            this.Controls.Add(this.gumbOdustaniPopust);
            this.Controls.Add(this.gumbPopustIzdajRacun);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PopustForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PopustForm";
            ((System.ComponentModel.ISupportInitialize)(this.bazaDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bazaDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button gumbPopustIzdajRacun;
        private System.Windows.Forms.Button gumbOdustaniPopust;
        private System.Windows.Forms.BindingSource bazaDataSetBindingSource;
        private Caffe_Bar.bazaDataSet bazaDataSet;
        private System.Windows.Forms.ComboBox odabirKonobara;
        private System.Windows.Forms.Label labelOdabirKonobaraPopust;
        private System.Windows.Forms.CheckBox checkBoxIskoristiBesplatnuKavu;
        private System.Windows.Forms.CheckBox checkBoxIskoristiBespalatanSok;
        private System.Windows.Forms.CheckBox checkBoxIskoristiPopust;
        private System.Windows.Forms.Button buttonIskoristiPopust;
        private System.Windows.Forms.Label labelStanjeNakonAkcije;
    }
}