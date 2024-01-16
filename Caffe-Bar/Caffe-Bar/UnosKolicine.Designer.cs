namespace Caffe_Bar
{
    partial class UnosKolicine
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
            this.labelUpisiKolicinu = new System.Windows.Forms.Label();
            this.gumbPotvrdi = new System.Windows.Forms.Button();
            this.gumbOdustani = new System.Windows.Forms.Button();
            this.labelPice = new System.Windows.Forms.Label();
            this.numericUpDownKolicina = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownKolicina)).BeginInit();
            this.SuspendLayout();
            // 
            // labelUpisiKolicinu
            // 
            this.labelUpisiKolicinu.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.labelUpisiKolicinu.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelUpisiKolicinu.Location = new System.Drawing.Point(172, 96);
            this.labelUpisiKolicinu.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelUpisiKolicinu.Name = "labelUpisiKolicinu";
            this.labelUpisiKolicinu.Size = new System.Drawing.Size(106, 29);
            this.labelUpisiKolicinu.TabIndex = 1;
            this.labelUpisiKolicinu.Text = "Kolicina:";
            // 
            // gumbPotvrdi
            // 
            this.gumbPotvrdi.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.gumbPotvrdi.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.gumbPotvrdi.Location = new System.Drawing.Point(135, 169);
            this.gumbPotvrdi.Name = "gumbPotvrdi";
            this.gumbPotvrdi.Size = new System.Drawing.Size(112, 34);
            this.gumbPotvrdi.TabIndex = 4;
            this.gumbPotvrdi.TabStop = false;
            this.gumbPotvrdi.Text = "Potvrdi";
            this.gumbPotvrdi.UseVisualStyleBackColor = true;
            this.gumbPotvrdi.Click += new System.EventHandler(this.gumbPotvrdi_Click);
            // 
            // gumbOdustani
            // 
            this.gumbOdustani.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.gumbOdustani.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.gumbOdustani.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.gumbOdustani.Location = new System.Drawing.Point(283, 169);
            this.gumbOdustani.Name = "gumbOdustani";
            this.gumbOdustani.Size = new System.Drawing.Size(112, 34);
            this.gumbOdustani.TabIndex = 5;
            this.gumbOdustani.Text = "Odustani";
            this.gumbOdustani.UseVisualStyleBackColor = true;
            this.gumbOdustani.Click += new System.EventHandler(this.gumbOdustani_Click);
            // 
            // labelPice
            // 
            this.labelPice.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.labelPice.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelPice.Location = new System.Drawing.Point(186, 36);
            this.labelPice.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelPice.Name = "labelPice";
            this.labelPice.Size = new System.Drawing.Size(275, 29);
            this.labelPice.TabIndex = 6;
            // 
            // numericUpDownKolicina
            // 
            this.numericUpDownKolicina.Location = new System.Drawing.Point(283, 96);
            this.numericUpDownKolicina.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownKolicina.Name = "numericUpDownKolicina";
            this.numericUpDownKolicina.Size = new System.Drawing.Size(74, 29);
            this.numericUpDownKolicina.TabIndex = 7;
            this.numericUpDownKolicina.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // UnosKolicine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(527, 266);
            this.Controls.Add(this.numericUpDownKolicina);
            this.Controls.Add(this.labelPice);
            this.Controls.Add(this.gumbOdustani);
            this.Controls.Add(this.gumbPotvrdi);
            this.Controls.Add(this.labelUpisiKolicinu);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "UnosKolicine";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Unos količine";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownKolicina)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelUpisiKolicinu;
        private System.Windows.Forms.Button gumbPotvrdi;
        private System.Windows.Forms.Button gumbOdustani;
        private System.Windows.Forms.Label labelPice;
        private System.Windows.Forms.NumericUpDown numericUpDownKolicina;
    }
}