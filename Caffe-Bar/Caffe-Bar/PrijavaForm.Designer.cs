namespace CaffeBar
{
    partial class PrijavaForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PrijavaForm));
            this.labelUpisiIme = new System.Windows.Forms.Label();
            this.textBoxIme = new System.Windows.Forms.TextBox();
            this.textBoxLozinka = new System.Windows.Forms.TextBox();
            this.labelUpisiLozinku = new System.Windows.Forms.Label();
            this.gumbPrijava = new System.Windows.Forms.Button();
            this.gumbOdustani = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelUpisiIme
            // 
            resources.ApplyResources(this.labelUpisiIme, "labelUpisiIme");
            this.labelUpisiIme.Name = "labelUpisiIme";
            // 
            // textBoxIme
            // 
            resources.ApplyResources(this.textBoxIme, "textBoxIme");
            this.textBoxIme.Name = "textBoxIme";
            // 
            // textBoxLozinka
            // 
            resources.ApplyResources(this.textBoxLozinka, "textBoxLozinka");
            this.textBoxLozinka.Name = "textBoxLozinka";
            // 
            // labelUpisiLozinku
            // 
            resources.ApplyResources(this.labelUpisiLozinku, "labelUpisiLozinku");
            this.labelUpisiLozinku.Name = "labelUpisiLozinku";
            // 
            // gumbPrijava
            // 
            resources.ApplyResources(this.gumbPrijava, "gumbPrijava");
            this.gumbPrijava.Name = "gumbPrijava";
            this.gumbPrijava.TabStop = false;
            this.gumbPrijava.UseVisualStyleBackColor = true;
            // 
            // gumbOdustani
            // 
            this.gumbOdustani.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            resources.ApplyResources(this.gumbOdustani, "gumbOdustani");
            this.gumbOdustani.Name = "gumbOdustani";
            this.gumbOdustani.UseVisualStyleBackColor = true;
            this.gumbOdustani.Click += new System.EventHandler(this.gumbOdustani_Click);
            // 
            // PrijavaForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gumbOdustani);
            this.Controls.Add(this.gumbPrijava);
            this.Controls.Add(this.textBoxLozinka);
            this.Controls.Add(this.labelUpisiLozinku);
            this.Controls.Add(this.textBoxIme);
            this.Controls.Add(this.labelUpisiIme);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PrijavaForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelUpisiIme;
        private System.Windows.Forms.TextBox textBoxIme;
        private System.Windows.Forms.TextBox textBoxLozinka;
        private System.Windows.Forms.Label labelUpisiLozinku;
        private System.Windows.Forms.Button gumbPrijava;
        private System.Windows.Forms.Button gumbOdustani;
    }
}