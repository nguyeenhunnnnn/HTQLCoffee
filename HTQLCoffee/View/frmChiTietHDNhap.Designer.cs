namespace HTQLCoffee.View
{
    partial class frmChiTietHDNhap
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
            this.listChiTietNhap = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.listChiTietNhap)).BeginInit();
            this.SuspendLayout();
            // 
            // listChiTietNhap
            // 
            this.listChiTietNhap.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.listChiTietNhap.Location = new System.Drawing.Point(12, 44);
            this.listChiTietNhap.Name = "listChiTietNhap";
            this.listChiTietNhap.RowHeadersWidth = 51;
            this.listChiTietNhap.RowTemplate.Height = 24;
            this.listChiTietNhap.Size = new System.Drawing.Size(776, 319);
            this.listChiTietNhap.TabIndex = 0;
            // 
            // frmChiTietHDNhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.listChiTietNhap);
            this.Name = "frmChiTietHDNhap";
            this.Text = "frmChiTietHDNhap";
            ((System.ComponentModel.ISupportInitialize)(this.listChiTietNhap)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView listChiTietNhap;
    }
}