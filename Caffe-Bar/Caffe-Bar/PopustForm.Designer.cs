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
            this.gumbPotvrdiPopust = new System.Windows.Forms.Button();
            this.gumbOdustaniPopust = new System.Windows.Forms.Button();
            this.bazaDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bazaDataSet = new Caffe_Bar.bazaDataSet();
            this.odabirKonobara = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.bazaDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bazaDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // gumbPotvrdiPopust
            // 
            this.gumbPotvrdiPopust.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.gumbPotvrdiPopust.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.gumbPotvrdiPopust.Location = new System.Drawing.Point(468, 361);
            this.gumbPotvrdiPopust.Name = "gumbPotvrdiPopust";
            this.gumbPotvrdiPopust.Size = new System.Drawing.Size(112, 34);
            this.gumbPotvrdiPopust.TabIndex = 1;
            this.gumbPotvrdiPopust.Text = "Potvrdi";
            this.gumbPotvrdiPopust.UseVisualStyleBackColor = true;
            // 
            // gumbOdustaniPopust
            // 
            this.gumbOdustaniPopust.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.gumbOdustaniPopust.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.gumbOdustaniPopust.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.gumbOdustaniPopust.Location = new System.Drawing.Point(614, 361);
            this.gumbOdustaniPopust.Name = "gumbOdustaniPopust";
            this.gumbOdustaniPopust.Size = new System.Drawing.Size(112, 34);
            this.gumbOdustaniPopust.TabIndex = 2;
            this.gumbOdustaniPopust.TabStop = false;
            this.gumbOdustaniPopust.Text = "Odustani";
            this.gumbOdustaniPopust.UseVisualStyleBackColor = true;
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
            this.odabirKonobara.Location = new System.Drawing.Point(50, 44);
            this.odabirKonobara.Name = "odabirKonobara";
            this.odabirKonobara.Size = new System.Drawing.Size(245, 33);
            this.odabirKonobara.TabIndex = 3;
            // 
            // PopustForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.CancelButton = this.gumbOdustaniPopust;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.odabirKonobara);
            this.Controls.Add(this.gumbOdustaniPopust);
            this.Controls.Add(this.gumbPotvrdiPopust);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PopustForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PopustForm";
            ((System.ComponentModel.ISupportInitialize)(this.bazaDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bazaDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button gumbPotvrdiPopust;
        private System.Windows.Forms.Button gumbOdustaniPopust;
        private System.Windows.Forms.BindingSource bazaDataSetBindingSource;
        private Caffe_Bar.bazaDataSet bazaDataSet;
        private System.Windows.Forms.ComboBox odabirKonobara;
    }
}