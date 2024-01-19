namespace CaffeBar
{
    partial class IzdajRacun
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
            this.finalniRacun = new System.Windows.Forms.RichTextBox();
            this.gumbIzdajRacun = new System.Windows.Forms.Button();
            this.buttonOdustani = new System.Windows.Forms.Button();
            this.buttonIzracunajOstatak = new System.Windows.Forms.Button();
            this.labelDaniIznos = new System.Windows.Forms.Label();
            this.labelVratiOstatak = new System.Windows.Forms.Label();
            this.textDaniIznos = new System.Windows.Forms.TextBox();
            this.labelVratitiIznos = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // finalniRacun
            // 
            this.finalniRacun.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.finalniRacun.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.finalniRacun.Location = new System.Drawing.Point(30, 21);
            this.finalniRacun.Name = "finalniRacun";
            this.finalniRacun.ReadOnly = true;
            this.finalniRacun.Size = new System.Drawing.Size(576, 608);
            this.finalniRacun.TabIndex = 12;
            this.finalniRacun.Text = "";
            // 
            // gumbIzdajRacun
            // 
            this.gumbIzdajRacun.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.gumbIzdajRacun.Location = new System.Drawing.Point(686, 581);
            this.gumbIzdajRacun.Name = "gumbIzdajRacun";
            this.gumbIzdajRacun.Size = new System.Drawing.Size(155, 48);
            this.gumbIzdajRacun.TabIndex = 2;
            this.gumbIzdajRacun.Text = "Izdaj račun";
            this.gumbIzdajRacun.UseVisualStyleBackColor = true;
            this.gumbIzdajRacun.Click += new System.EventHandler(this.gumbIzdajRacun_Click);
            // 
            // buttonOdustani
            // 
            this.buttonOdustani.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonOdustani.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonOdustani.Location = new System.Drawing.Point(855, 581);
            this.buttonOdustani.Name = "buttonOdustani";
            this.buttonOdustani.Size = new System.Drawing.Size(155, 48);
            this.buttonOdustani.TabIndex = 3;
            this.buttonOdustani.Text = "Odustani";
            this.buttonOdustani.UseVisualStyleBackColor = true;
            // 
            // buttonIzracunajOstatak
            // 
            this.buttonIzracunajOstatak.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonIzracunajOstatak.Location = new System.Drawing.Point(686, 92);
            this.buttonIzracunajOstatak.Name = "buttonIzracunajOstatak";
            this.buttonIzracunajOstatak.Size = new System.Drawing.Size(172, 48);
            this.buttonIzracunajOstatak.TabIndex = 1;
            this.buttonIzracunajOstatak.Text = "Izračunaj ostatak";
            this.buttonIzracunajOstatak.UseVisualStyleBackColor = true;
            this.buttonIzracunajOstatak.Click += new System.EventHandler(this.buttonIzracunajOstatak_Click);
            // 
            // labelDaniIznos
            // 
            this.labelDaniIznos.AutoSize = true;
            this.labelDaniIznos.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelDaniIznos.Location = new System.Drawing.Point(681, 39);
            this.labelDaniIznos.Name = "labelDaniIznos";
            this.labelDaniIznos.Size = new System.Drawing.Size(195, 25);
            this.labelDaniIznos.TabIndex = 10;
            this.labelDaniIznos.Text = "Unesite dani iznos:";
            // 
            // labelVratiOstatak
            // 
            this.labelVratiOstatak.AutoSize = true;
            this.labelVratiOstatak.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelVratiOstatak.Location = new System.Drawing.Point(681, 188);
            this.labelVratiOstatak.Name = "labelVratiOstatak";
            this.labelVratiOstatak.Size = new System.Drawing.Size(169, 25);
            this.labelVratiOstatak.TabIndex = 11;
            this.labelVratiOstatak.Text = "Potrebno vratiti: ";
            // 
            // textDaniIznos
            // 
            this.textDaniIznos.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textDaniIznos.Location = new System.Drawing.Point(910, 33);
            this.textDaniIznos.Name = "textDaniIznos";
            this.textDaniIznos.Size = new System.Drawing.Size(100, 31);
            this.textDaniIznos.TabIndex = 0;
            // 
            // labelVratitiIznos
            // 
            this.labelVratitiIznos.AutoSize = true;
            this.labelVratitiIznos.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelVratitiIznos.Location = new System.Drawing.Point(856, 188);
            this.labelVratitiIznos.Name = "labelVratitiIznos";
            this.labelVratitiIznos.Size = new System.Drawing.Size(0, 25);
            this.labelVratitiIznos.TabIndex = 13;
            // 
            // IzdajRacun
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.CancelButton = this.buttonOdustani;
            this.ClientSize = new System.Drawing.Size(1080, 665);
            this.Controls.Add(this.labelVratitiIznos);
            this.Controls.Add(this.textDaniIznos);
            this.Controls.Add(this.labelVratiOstatak);
            this.Controls.Add(this.labelDaniIznos);
            this.Controls.Add(this.buttonIzracunajOstatak);
            this.Controls.Add(this.buttonOdustani);
            this.Controls.Add(this.gumbIzdajRacun);
            this.Controls.Add(this.finalniRacun);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "IzdajRacun";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "IzdajRacun";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox finalniRacun;
        private System.Windows.Forms.Button gumbIzdajRacun;
        private System.Windows.Forms.Button buttonOdustani;
        private System.Windows.Forms.Button buttonIzracunajOstatak;
        private System.Windows.Forms.Label labelDaniIznos;
        private System.Windows.Forms.Label labelVratiOstatak;
        private System.Windows.Forms.TextBox textDaniIznos;
        private System.Windows.Forms.Label labelVratitiIznos;
    }
}