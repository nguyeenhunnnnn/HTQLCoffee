namespace HTQLCoffee.View
{
    partial class frmChiTietHDBan
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
            this.listChiTietBan = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.listChiTietBan)).BeginInit();
            this.SuspendLayout();
            // 
            // listChiTietBan
            // 
            this.listChiTietBan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.listChiTietBan.Location = new System.Drawing.Point(12, 66);
            this.listChiTietBan.Name = "listChiTietBan";
            this.listChiTietBan.RowHeadersWidth = 51;
            this.listChiTietBan.RowTemplate.Height = 24;
            this.listChiTietBan.Size = new System.Drawing.Size(776, 319);
            this.listChiTietBan.TabIndex = 1;
            // 
            // frmChiTietHDBan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.listChiTietBan);
            this.Name = "frmChiTietHDBan";
            this.Text = "frmChiTietHDBan";
            ((System.ComponentModel.ISupportInitialize)(this.listChiTietBan)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView listChiTietBan;
    }
}