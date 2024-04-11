
namespace HTQLCoffee.View
{
    partial class TaiKhoanView
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
            this.btnLammoi = new System.Windows.Forms.Button();
            this.dgv_TaiKhoan = new System.Windows.Forms.DataGridView();
            this.PK_iNhanvienID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sMatkhau = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PK_iPhanquyenID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sTennhanvien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cb_maNV = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btn_tim = new System.Windows.Forms.Button();
            this.btn_chinh = new System.Windows.Forms.Button();
            this.btn_xoa = new System.Windows.Forms.Button();
            this.brn_them = new System.Windows.Forms.Button();
            this.cb_quyen = new System.Windows.Forms.ComboBox();
            this.tbMatkhau = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_TaiKhoan)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnLammoi);
            this.groupBox1.Controls.Add(this.dgv_TaiKhoan);
            this.groupBox1.Controls.Add(this.cb_maNV);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.btn_tim);
            this.groupBox1.Controls.Add(this.btn_chinh);
            this.groupBox1.Controls.Add(this.btn_xoa);
            this.groupBox1.Controls.Add(this.brn_them);
            this.groupBox1.Controls.Add(this.cb_quyen);
            this.groupBox1.Controls.Add(this.tbMatkhau);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Location = new System.Drawing.Point(20, 38);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(608, 318);
            this.groupBox1.TabIndex = 21;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tạo tài khoản";
            // 
            // btnLammoi
            // 
            this.btnLammoi.Location = new System.Drawing.Point(422, 72);
            this.btnLammoi.Margin = new System.Windows.Forms.Padding(2);
            this.btnLammoi.Name = "btnLammoi";
            this.btnLammoi.Size = new System.Drawing.Size(73, 26);
            this.btnLammoi.TabIndex = 61;
            this.btnLammoi.Text = "Làm mới";
            this.btnLammoi.UseVisualStyleBackColor = true;
            this.btnLammoi.Click += new System.EventHandler(this.btnLammoi_Click);
            // 
            // dgv_TaiKhoan
            // 
            this.dgv_TaiKhoan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_TaiKhoan.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PK_iNhanvienID,
            this.sMatkhau,
            this.PK_iPhanquyenID,
            this.sTennhanvien});
            this.dgv_TaiKhoan.Location = new System.Drawing.Point(18, 144);
            this.dgv_TaiKhoan.Name = "dgv_TaiKhoan";
            this.dgv_TaiKhoan.Size = new System.Drawing.Size(572, 159);
            this.dgv_TaiKhoan.TabIndex = 60;
            this.dgv_TaiKhoan.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_TaiKhoan_CellClick);
            // 
            // PK_iNhanvienID
            // 
            this.PK_iNhanvienID.DataPropertyName = "PK_iNhanvienID";
            this.PK_iNhanvienID.HeaderText = "Mã Nhân viên";
            this.PK_iNhanvienID.Name = "PK_iNhanvienID";
            // 
            // sMatkhau
            // 
            this.sMatkhau.DataPropertyName = "sMatkhau";
            this.sMatkhau.HeaderText = "Mật khẩu";
            this.sMatkhau.Name = "sMatkhau";
            // 
            // PK_iPhanquyenID
            // 
            this.PK_iPhanquyenID.DataPropertyName = "PK_iPhanquyenID";
            this.PK_iPhanquyenID.HeaderText = "Quyền";
            this.PK_iPhanquyenID.Name = "PK_iPhanquyenID";
            // 
            // sTennhanvien
            // 
            this.sTennhanvien.DataPropertyName = "sTennhanvien";
            this.sTennhanvien.HeaderText = "Tên nhân viên";
            this.sTennhanvien.Name = "sTennhanvien";
            // 
            // cb_maNV
            // 
            this.cb_maNV.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_maNV.FormattingEnabled = true;
            this.cb_maNV.Location = new System.Drawing.Point(177, 42);
            this.cb_maNV.Name = "cb_maNV";
            this.cb_maNV.Size = new System.Drawing.Size(161, 21);
            this.cb_maNV.TabIndex = 59;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(286, 16);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(0, 17);
            this.label5.TabIndex = 58;
            // 
            // btn_tim
            // 
            this.btn_tim.Location = new System.Drawing.Point(465, 105);
            this.btn_tim.Margin = new System.Windows.Forms.Padding(2);
            this.btn_tim.Name = "btn_tim";
            this.btn_tim.Size = new System.Drawing.Size(73, 26);
            this.btn_tim.TabIndex = 54;
            this.btn_tim.Text = "Tìm kiếm";
            this.btn_tim.UseVisualStyleBackColor = true;
            this.btn_tim.Click += new System.EventHandler(this.btn_tim_Click);
            // 
            // btn_chinh
            // 
            this.btn_chinh.Location = new System.Drawing.Point(465, 37);
            this.btn_chinh.Margin = new System.Windows.Forms.Padding(2);
            this.btn_chinh.Name = "btn_chinh";
            this.btn_chinh.Size = new System.Drawing.Size(73, 26);
            this.btn_chinh.TabIndex = 55;
            this.btn_chinh.Text = "Cập nhật";
            this.btn_chinh.UseVisualStyleBackColor = true;
            this.btn_chinh.Click += new System.EventHandler(this.btn_chinh_Click);
            // 
            // btn_xoa
            // 
            this.btn_xoa.Location = new System.Drawing.Point(379, 105);
            this.btn_xoa.Margin = new System.Windows.Forms.Padding(2);
            this.btn_xoa.Name = "btn_xoa";
            this.btn_xoa.Size = new System.Drawing.Size(73, 26);
            this.btn_xoa.TabIndex = 56;
            this.btn_xoa.Text = "Xóa";
            this.btn_xoa.UseVisualStyleBackColor = true;
            this.btn_xoa.Click += new System.EventHandler(this.btn_xoa_Click);
            // 
            // brn_them
            // 
            this.brn_them.Location = new System.Drawing.Point(379, 37);
            this.brn_them.Margin = new System.Windows.Forms.Padding(2);
            this.brn_them.Name = "brn_them";
            this.brn_them.Size = new System.Drawing.Size(73, 26);
            this.brn_them.TabIndex = 57;
            this.brn_them.Text = "Thêm mới";
            this.brn_them.UseVisualStyleBackColor = true;
            this.brn_them.Click += new System.EventHandler(this.btn_them_Click);
            // 
            // cb_quyen
            // 
            this.cb_quyen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_quyen.FormattingEnabled = true;
            this.cb_quyen.Location = new System.Drawing.Point(177, 115);
            this.cb_quyen.Margin = new System.Windows.Forms.Padding(2);
            this.cb_quyen.Name = "cb_quyen";
            this.cb_quyen.Size = new System.Drawing.Size(161, 21);
            this.cb_quyen.TabIndex = 53;
            // 
            // tbMatkhau
            // 
            this.tbMatkhau.Location = new System.Drawing.Point(177, 79);
            this.tbMatkhau.Margin = new System.Windows.Forms.Padding(2);
            this.tbMatkhau.Name = "tbMatkhau";
            this.tbMatkhau.Size = new System.Drawing.Size(161, 20);
            this.tbMatkhau.TabIndex = 52;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(102, 118);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 13);
            this.label6.TabIndex = 49;
            this.label6.Text = "Tên quyền";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(102, 79);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 13);
            this.label7.TabIndex = 50;
            this.label7.Text = "Mật khẩu";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(102, 45);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(69, 13);
            this.label8.TabIndex = 51;
            this.label8.Text = "Mã tài khoản";
            // 
            // TaiKhoanView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(711, 450);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "TaiKhoanView";
            this.Text = "frmTaiKhoan";
            this.Load += new System.EventHandler(this.frmTaiKhoan_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_TaiKhoan)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnLammoi;
        private System.Windows.Forms.DataGridView dgv_TaiKhoan;
        private System.Windows.Forms.ComboBox cb_maNV;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btn_tim;
        private System.Windows.Forms.Button btn_chinh;
        private System.Windows.Forms.Button btn_xoa;
        private System.Windows.Forms.Button brn_them;
        private System.Windows.Forms.ComboBox cb_quyen;
        private System.Windows.Forms.TextBox tbMatkhau;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridViewTextBoxColumn PK_iNhanvienID;
        private System.Windows.Forms.DataGridViewTextBoxColumn sMatkhau;
        private System.Windows.Forms.DataGridViewTextBoxColumn PK_iPhanquyenID;
        private System.Windows.Forms.DataGridViewTextBoxColumn sTennhanvien;
    }
}