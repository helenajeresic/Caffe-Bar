namespace CaffeBar
{
    partial class ObracunForm
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
            this.buttonOK = new System.Windows.Forms.Button();
            this.groupBoxKolicina = new System.Windows.Forms.GroupBox();
            this.dataGridViewUkupniPromet = new System.Windows.Forms.DataGridView();
            this.groupBoxUkupniRacuni = new System.Windows.Forms.GroupBox();
            this.dataGridViewUkupniRacuni = new System.Windows.Forms.DataGridView();
            this.labelUkupnaZarada = new System.Windows.Forms.Label();
            this.labelUkupnaZaradaIznos = new System.Windows.Forms.Label();
            this.groupBoxKolicina.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUkupniPromet)).BeginInit();
            this.groupBoxUkupniRacuni.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUkupniRacuni)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonOK
            // 
            this.buttonOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.buttonOK.Location = new System.Drawing.Point(974, 541);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(149, 46);
            this.buttonOK.TabIndex = 0;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // groupBoxKolicina
            // 
            this.groupBoxKolicina.Controls.Add(this.dataGridViewUkupniPromet);
            this.groupBoxKolicina.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.groupBoxKolicina.Location = new System.Drawing.Point(603, 72);
            this.groupBoxKolicina.Name = "groupBoxKolicina";
            this.groupBoxKolicina.Size = new System.Drawing.Size(520, 423);
            this.groupBoxKolicina.TabIndex = 1;
            this.groupBoxKolicina.TabStop = false;
            this.groupBoxKolicina.Text = "Ukupno prodanih pića u smjeni";
            // 
            // dataGridViewUkupniPromet
            // 
            this.dataGridViewUkupniPromet.AllowUserToAddRows = false;
            this.dataGridViewUkupniPromet.AllowUserToDeleteRows = false;
            this.dataGridViewUkupniPromet.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewUkupniPromet.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridViewUkupniPromet.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dataGridViewUkupniPromet.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dataGridViewUkupniPromet.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dataGridViewUkupniPromet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewUkupniPromet.GridColor = System.Drawing.Color.Gray;
            this.dataGridViewUkupniPromet.Location = new System.Drawing.Point(24, 45);
            this.dataGridViewUkupniPromet.Name = "dataGridViewUkupniPromet";
            this.dataGridViewUkupniPromet.ReadOnly = true;
            this.dataGridViewUkupniPromet.RowHeadersWidth = 51;
            this.dataGridViewUkupniPromet.Size = new System.Drawing.Size(473, 355);
            this.dataGridViewUkupniPromet.TabIndex = 0;
            // 
            // groupBoxUkupniRacuni
            // 
            this.groupBoxUkupniRacuni.Controls.Add(this.dataGridViewUkupniRacuni);
            this.groupBoxUkupniRacuni.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.groupBoxUkupniRacuni.Location = new System.Drawing.Point(78, 72);
            this.groupBoxUkupniRacuni.Name = "groupBoxUkupniRacuni";
            this.groupBoxUkupniRacuni.Size = new System.Drawing.Size(498, 423);
            this.groupBoxUkupniRacuni.TabIndex = 2;
            this.groupBoxUkupniRacuni.TabStop = false;
            this.groupBoxUkupniRacuni.Text = "Svi računi u smjeni";
            // 
            // dataGridViewUkupniRacuni
            // 
            this.dataGridViewUkupniRacuni.AllowUserToAddRows = false;
            this.dataGridViewUkupniRacuni.AllowUserToDeleteRows = false;
            this.dataGridViewUkupniRacuni.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewUkupniRacuni.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridViewUkupniRacuni.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dataGridViewUkupniRacuni.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dataGridViewUkupniRacuni.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dataGridViewUkupniRacuni.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewUkupniRacuni.GridColor = System.Drawing.Color.Gray;
            this.dataGridViewUkupniRacuni.Location = new System.Drawing.Point(17, 45);
            this.dataGridViewUkupniRacuni.Name = "dataGridViewUkupniRacuni";
            this.dataGridViewUkupniRacuni.ReadOnly = true;
            this.dataGridViewUkupniRacuni.RowHeadersWidth = 51;
            this.dataGridViewUkupniRacuni.Size = new System.Drawing.Size(456, 355);
            this.dataGridViewUkupniRacuni.TabIndex = 0;
            // 
            // labelUkupnaZarada
            // 
            this.labelUkupnaZarada.AutoSize = true;
            this.labelUkupnaZarada.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUkupnaZarada.Location = new System.Drawing.Point(71, 545);
            this.labelUkupnaZarada.Name = "labelUkupnaZarada";
            this.labelUkupnaZarada.Size = new System.Drawing.Size(354, 54);
            this.labelUkupnaZarada.TabIndex = 3;
            this.labelUkupnaZarada.Text = "Ukupna zarada:";
            // 
            // labelUkupnaZaradaIznos
            // 
            this.labelUkupnaZaradaIznos.AutoSize = true;
            this.labelUkupnaZaradaIznos.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUkupnaZaradaIznos.Location = new System.Drawing.Point(373, 545);
            this.labelUkupnaZaradaIznos.Name = "labelUkupnaZaradaIznos";
            this.labelUkupnaZaradaIznos.Size = new System.Drawing.Size(61, 54);
            this.labelUkupnaZaradaIznos.TabIndex = 4;
            this.labelUkupnaZaradaIznos.Text = "0 ";
            // 
            // ObracunForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1238, 630);
            this.ControlBox = false;
            this.Controls.Add(this.labelUkupnaZaradaIznos);
            this.Controls.Add(this.labelUkupnaZarada);
            this.Controls.Add(this.groupBoxUkupniRacuni);
            this.Controls.Add(this.groupBoxKolicina);
            this.Controls.Add(this.buttonOK);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ObracunForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormObracun";
            this.Load += new System.EventHandler(this.ObracunForm_Load);
            this.groupBoxKolicina.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUkupniPromet)).EndInit();
            this.groupBoxUkupniRacuni.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUkupniRacuni)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.GroupBox groupBoxKolicina;
        private System.Windows.Forms.DataGridView dataGridViewUkupniPromet;
        private System.Windows.Forms.GroupBox groupBoxUkupniRacuni;
        private System.Windows.Forms.DataGridView dataGridViewUkupniRacuni;
        private System.Windows.Forms.Label labelUkupnaZarada;
        private System.Windows.Forms.Label labelUkupnaZaradaIznos;
    }
}