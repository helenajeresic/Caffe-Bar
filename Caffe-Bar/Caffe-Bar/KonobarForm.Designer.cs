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
            this.tabSkladiste = new System.Windows.Forms.TabPage();
            this.tabŠank = new System.Windows.Forms.TabPage();
            this.tabNarudžba = new System.Windows.Forms.TabPage();
            this.gumbOdjavaKonobara = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.tabKonobar.SuspendLayout();
            this.tabIzdajRacun.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
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
            this.tabKonobar.Size = new System.Drawing.Size(976, 592);
            this.tabKonobar.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabKonobar.TabIndex = 4;
            // 
            // tabIzdajRacun
            // 
            this.tabIzdajRacun.Controls.Add(this.dataGridView1);
            this.tabIzdajRacun.Controls.Add(this.button1);
            this.tabIzdajRacun.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tabIzdajRacun.Location = new System.Drawing.Point(4, 54);
            this.tabIzdajRacun.Margin = new System.Windows.Forms.Padding(5);
            this.tabIzdajRacun.Name = "tabIzdajRacun";
            this.tabIzdajRacun.Padding = new System.Windows.Forms.Padding(5);
            this.tabIzdajRacun.Size = new System.Drawing.Size(968, 534);
            this.tabIzdajRacun.TabIndex = 0;
            this.tabIzdajRacun.Text = "Izdaj račun";
            this.tabIzdajRacun.UseVisualStyleBackColor = true;
            this.tabIzdajRacun.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // tabSkladiste
            // 
            this.tabSkladiste.Location = new System.Drawing.Point(4, 54);
            this.tabSkladiste.Margin = new System.Windows.Forms.Padding(5);
            this.tabSkladiste.Name = "tabSkladiste";
            this.tabSkladiste.Padding = new System.Windows.Forms.Padding(5);
            this.tabSkladiste.Size = new System.Drawing.Size(968, 534);
            this.tabSkladiste.TabIndex = 1;
            this.tabSkladiste.Text = "Skladište";
            this.tabSkladiste.UseVisualStyleBackColor = true;
            // 
            // tabŠank
            // 
            this.tabŠank.Location = new System.Drawing.Point(4, 54);
            this.tabŠank.Margin = new System.Windows.Forms.Padding(5);
            this.tabŠank.Name = "tabŠank";
            this.tabŠank.Padding = new System.Windows.Forms.Padding(5);
            this.tabŠank.Size = new System.Drawing.Size(968, 534);
            this.tabŠank.TabIndex = 2;
            this.tabŠank.Text = "Šank";
            this.tabŠank.UseVisualStyleBackColor = true;
            // 
            // tabNarudžba
            // 
            this.tabNarudžba.Location = new System.Drawing.Point(4, 54);
            this.tabNarudžba.Margin = new System.Windows.Forms.Padding(5);
            this.tabNarudžba.Name = "tabNarudžba";
            this.tabNarudžba.Padding = new System.Windows.Forms.Padding(5);
            this.tabNarudžba.Size = new System.Drawing.Size(968, 534);
            this.tabNarudžba.TabIndex = 3;
            this.tabNarudžba.Text = "Narudžba";
            this.tabNarudžba.UseVisualStyleBackColor = true;
            // 
            // gumbOdjavaKonobara
            // 
            this.gumbOdjavaKonobara.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.gumbOdjavaKonobara.Location = new System.Drawing.Point(847, 12);
            this.gumbOdjavaKonobara.Name = "gumbOdjavaKonobara";
            this.gumbOdjavaKonobara.Size = new System.Drawing.Size(131, 48);
            this.gumbOdjavaKonobara.TabIndex = 5;
            this.gumbOdjavaKonobara.Text = "Odjava";
            this.gumbOdjavaKonobara.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(22, 23);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(124, 51);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(313, 65);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(578, 389);
            this.dataGridView1.TabIndex = 1;
            // 
            // KonobarForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 617);
            this.Controls.Add(this.gumbOdjavaKonobara);
            this.Controls.Add(this.tabKonobar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "KonobarForm";
            this.Text = "KonobarForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.tabKonobar.ResumeLayout(false);
            this.tabIzdajRacun.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabKonobar;
        private System.Windows.Forms.TabPage tabSkladiste;
        private System.Windows.Forms.Button gumbOdjavaKonobara;
        private System.Windows.Forms.TabPage tabŠank;
        private System.Windows.Forms.TabPage tabNarudžba;
        public System.Windows.Forms.TabPage tabIzdajRacun;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button1;
    }
}