namespace HTQLCoffee.View
{
    partial class frmHDBan
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.delNL = new System.Windows.Forms.Button();
            this.dataGridViewSelectedProducts = new System.Windows.Forms.DataGridView();
            this.cbbDoUong = new System.Windows.Forms.ComboBox();
            this.numericUpDownSoluong = new System.Windows.Forms.NumericUpDown();
            this.txtDongia = new System.Windows.Forms.TextBox();
            this.addDU = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.xemDSHDBan = new System.Windows.Forms.Button();
            this.resetHDban = new System.Windows.Forms.Button();
            this.addHDBan = new System.Windows.Forms.Button();
            this.dateTimePickerNgaylap = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.comboboxNhanVien = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSelectedProducts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSoluong)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.delNL);
            this.groupBox1.Controls.Add(this.dataGridViewSelectedProducts);
            this.groupBox1.Controls.Add(this.cbbDoUong);
            this.groupBox1.Controls.Add(this.numericUpDownSoluong);
            this.groupBox1.Controls.Add(this.txtDongia);
            this.groupBox1.Controls.Add(this.addDU);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(62, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(876, 200);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin đồ uống";
            // 
            // delNL
            // 
            this.delNL.Location = new System.Drawing.Point(234, 135);
            this.delNL.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.delNL.Name = "delNL";
            this.delNL.Size = new System.Drawing.Size(91, 33);
            this.delNL.TabIndex = 43;
            this.delNL.Text = "Xóa ";
            this.delNL.UseVisualStyleBackColor = true;
            this.delNL.Click += new System.EventHandler(this.delNL_Click_1);
            // 
            // dataGridViewSelectedProducts
            // 
            this.dataGridViewSelectedProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSelectedProducts.Location = new System.Drawing.Point(401, 21);
            this.dataGridViewSelectedProducts.Name = "dataGridViewSelectedProducts";
            this.dataGridViewSelectedProducts.RowHeadersWidth = 51;
            this.dataGridViewSelectedProducts.RowTemplate.Height = 24;
            this.dataGridViewSelectedProducts.Size = new System.Drawing.Size(446, 169);
            this.dataGridViewSelectedProducts.TabIndex = 42;
            this.dataGridViewSelectedProducts.SelectionChanged += new System.EventHandler(this.dataGridViewSelectedProducts_SelectionChanged);
            // 
            // cbbDoUong
            // 
            this.cbbDoUong.FormattingEnabled = true;
            this.cbbDoUong.Location = new System.Drawing.Point(156, 35);
            this.cbbDoUong.Name = "cbbDoUong";
            this.cbbDoUong.Size = new System.Drawing.Size(227, 24);
            this.cbbDoUong.TabIndex = 39;
            // 
            // numericUpDownSoluong
            // 
            this.numericUpDownSoluong.Location = new System.Drawing.Point(293, 85);
            this.numericUpDownSoluong.Name = "numericUpDownSoluong";
            this.numericUpDownSoluong.Size = new System.Drawing.Size(90, 22);
            this.numericUpDownSoluong.TabIndex = 41;
            // 
            // txtDongia
            // 
            this.txtDongia.Location = new System.Drawing.Point(101, 82);
            this.txtDongia.Name = "txtDongia";
            this.txtDongia.Size = new System.Drawing.Size(100, 22);
            this.txtDongia.TabIndex = 40;
            // 
            // addDU
            // 
            this.addDU.Location = new System.Drawing.Point(49, 133);
            this.addDU.Name = "addDU";
            this.addDU.Size = new System.Drawing.Size(152, 35);
            this.addDU.TabIndex = 38;
            this.addDU.Text = "Thêm đồ uống";
            this.addDU.UseVisualStyleBackColor = true;
            this.addDU.Click += new System.EventHandler(this.addDU_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(217, 85);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 16);
            this.label4.TabIndex = 37;
            this.label4.Text = "Số lượng";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(31, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 16);
            this.label3.TabIndex = 36;
            this.label3.Text = "Đơn giá";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 16);
            this.label2.TabIndex = 35;
            this.label2.Text = "Đồ uống";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.xemDSHDBan);
            this.groupBox2.Controls.Add(this.resetHDban);
            this.groupBox2.Controls.Add(this.addHDBan);
            this.groupBox2.Controls.Add(this.dateTimePickerNgaylap);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.comboboxNhanVien);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Location = new System.Drawing.Point(62, 218);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(876, 210);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Thông tin hóa đơn";
            // 
            // xemDSHDBan
            // 
            this.xemDSHDBan.Location = new System.Drawing.Point(540, 139);
            this.xemDSHDBan.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.xemDSHDBan.Name = "xemDSHDBan";
            this.xemDSHDBan.Size = new System.Drawing.Size(136, 33);
            this.xemDSHDBan.TabIndex = 43;
            this.xemDSHDBan.Text = "Xem danh sách";
            this.xemDSHDBan.UseVisualStyleBackColor = true;
            this.xemDSHDBan.Click += new System.EventHandler(this.xemDSHDBan_Click);
            // 
            // resetHDban
            // 
            this.resetHDban.Location = new System.Drawing.Point(412, 139);
            this.resetHDban.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.resetHDban.Name = "resetHDban";
            this.resetHDban.Size = new System.Drawing.Size(91, 33);
            this.resetHDban.TabIndex = 42;
            this.resetHDban.Text = "Làm mới";
            this.resetHDban.UseVisualStyleBackColor = true;
            this.resetHDban.Click += new System.EventHandler(this.resetHDban_Click);
            // 
            // addHDBan
            // 
            this.addHDBan.Location = new System.Drawing.Point(287, 139);
            this.addHDBan.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.addHDBan.Name = "addHDBan";
            this.addHDBan.Size = new System.Drawing.Size(91, 33);
            this.addHDBan.TabIndex = 41;
            this.addHDBan.Text = "Thêm";
            this.addHDBan.UseVisualStyleBackColor = true;
            this.addHDBan.Click += new System.EventHandler(this.addHDBan_Click);
            // 
            // dateTimePickerNgaylap
            // 
            this.dateTimePickerNgaylap.Location = new System.Drawing.Point(572, 62);
            this.dateTimePickerNgaylap.Name = "dateTimePickerNgaylap";
            this.dateTimePickerNgaylap.Size = new System.Drawing.Size(200, 22);
            this.dateTimePickerNgaylap.TabIndex = 40;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(487, 62);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(62, 16);
            this.label7.TabIndex = 39;
            this.label7.Text = "Ngày tạo";
            // 
            // comboboxNhanVien
            // 
            this.comboboxNhanVien.FormattingEnabled = true;
            this.comboboxNhanVien.Location = new System.Drawing.Point(226, 58);
            this.comboboxNhanVien.Name = "comboboxNhanVien";
            this.comboboxNhanVien.Size = new System.Drawing.Size(227, 24);
            this.comboboxNhanVien.TabIndex = 35;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(110, 62);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 16);
            this.label5.TabIndex = 36;
            this.label5.Text = "Nhân viên";
            // 
            // frmHDBan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1232, 578);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmHDBan";
            this.Text = "frmHDBan";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSelectedProducts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSoluong)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button xemDSHDBan;
        private System.Windows.Forms.Button resetHDban;
        private System.Windows.Forms.Button addHDBan;
        private System.Windows.Forms.DateTimePicker dateTimePickerNgaylap;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox comboboxNhanVien;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button delNL;
        private System.Windows.Forms.DataGridView dataGridViewSelectedProducts;
        private System.Windows.Forms.ComboBox cbbDoUong;
        private System.Windows.Forms.NumericUpDown numericUpDownSoluong;
        private System.Windows.Forms.TextBox txtDongia;
        private System.Windows.Forms.Button addDU;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
    }
}