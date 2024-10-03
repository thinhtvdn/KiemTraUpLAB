namespace SendEmailVBC
{
    partial class Form1
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
            this.Label6 = new System.Windows.Forms.Label();
            this.txtSoLuongNV = new System.Windows.Forms.TextBox();
            this.txtFileDuLieu = new System.Windows.Forms.TextBox();
            this.btExcel = new System.Windows.Forms.Button();
            this.btnCheck = new System.Windows.Forms.Button();
            this.btDong = new System.Windows.Forms.Button();
            this.oGrid = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.txtTenThuMuc = new System.Windows.Forms.TextBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.OpenFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSLThuMuc = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.oGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // Label6
            // 
            this.Label6.AutoSize = true;
            this.Label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label6.Location = new System.Drawing.Point(534, 16);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(139, 20);
            this.Label6.TabIndex = 50;
            this.Label6.Text = "Số dòng dữ liệu";
            // 
            // txtSoLuongNV
            // 
            this.txtSoLuongNV.Location = new System.Drawing.Point(690, 16);
            this.txtSoLuongNV.Name = "txtSoLuongNV";
            this.txtSoLuongNV.Size = new System.Drawing.Size(66, 26);
            this.txtSoLuongNV.TabIndex = 49;
            // 
            // txtFileDuLieu
            // 
            this.txtFileDuLieu.Location = new System.Drawing.Point(297, 12);
            this.txtFileDuLieu.Name = "txtFileDuLieu";
            this.txtFileDuLieu.Size = new System.Drawing.Size(228, 26);
            this.txtFileDuLieu.TabIndex = 52;
            // 
            // btExcel
            // 
            this.btExcel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btExcel.Location = new System.Drawing.Point(12, 8);
            this.btExcel.Name = "btExcel";
            this.btExcel.Size = new System.Drawing.Size(279, 34);
            this.btExcel.TabIndex = 53;
            this.btExcel.Text = "Lấy dữ liệu từ tập tin EXCEL";
            this.btExcel.UseVisualStyleBackColor = true;
            this.btExcel.Click += new System.EventHandler(this.btExcel_Click);
            // 
            // btnCheck
            // 
            this.btnCheck.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCheck.Location = new System.Drawing.Point(12, 92);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(279, 34);
            this.btnCheck.TabIndex = 54;
            this.btnCheck.Text = "Kiểm tra chưa Up LAB";
            this.btnCheck.UseVisualStyleBackColor = true;
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // btDong
            // 
            this.btDong.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btDong.Location = new System.Drawing.Point(774, 9);
            this.btDong.Name = "btDong";
            this.btDong.Size = new System.Drawing.Size(127, 34);
            this.btDong.TabIndex = 56;
            this.btDong.Text = "Đóng";
            this.btDong.UseVisualStyleBackColor = true;
            this.btDong.Click += new System.EventHandler(this.btDong_Click);
            // 
            // oGrid
            // 
            this.oGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.oGrid.Location = new System.Drawing.Point(0, 256);
            this.oGrid.Name = "oGrid";
            this.oGrid.RowHeadersWidth = 62;
            this.oGrid.Size = new System.Drawing.Size(1633, 563);
            this.oGrid.TabIndex = 42;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(12, 50);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(279, 34);
            this.button1.TabIndex = 62;
            this.button1.Text = "Chọn thư mục ";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtTenThuMuc
            // 
            this.txtTenThuMuc.Location = new System.Drawing.Point(297, 51);
            this.txtTenThuMuc.Name = "txtTenThuMuc";
            this.txtTenThuMuc.Size = new System.Drawing.Size(228, 26);
            this.txtTenThuMuc.TabIndex = 63;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(535, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 20);
            this.label1.TabIndex = 65;
            this.label1.Text = "Số thư mục";
            // 
            // txtSLThuMuc
            // 
            this.txtSLThuMuc.Location = new System.Drawing.Point(690, 54);
            this.txtSLThuMuc.Name = "txtSLThuMuc";
            this.txtSLThuMuc.Size = new System.Drawing.Size(66, 26);
            this.txtSLThuMuc.TabIndex = 64;
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(12, 132);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(608, 34);
            this.button2.TabIndex = 66;
            this.button2.Text = "Kiểm tra chưa Up - chỉ hiển thị danh sách chưa Up LAB";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1645, 819);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSLThuMuc);
            this.Controls.Add(this.txtTenThuMuc);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btDong);
            this.Controls.Add(this.btnCheck);
            this.Controls.Add(this.btExcel);
            this.Controls.Add(this.txtFileDuLieu);
            this.Controls.Add(this.Label6);
            this.Controls.Add(this.txtSoLuongNV);
            this.Controls.Add(this.oGrid);
            this.KeyPreview = true;
            this.Name = "Form1";
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.oGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        internal System.Windows.Forms.Label Label6;
        internal System.Windows.Forms.TextBox txtSoLuongNV;
        internal System.Windows.Forms.TextBox txtFileDuLieu;
        internal System.Windows.Forms.Button btExcel;
        internal System.Windows.Forms.Button btnCheck;
        internal System.Windows.Forms.Button btDong;
        internal System.Windows.Forms.DataGridView oGrid;
        internal System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtTenThuMuc;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.OpenFileDialog OpenFileDialog1;
        internal System.Windows.Forms.Label label1;
        internal System.Windows.Forms.TextBox txtSLThuMuc;
        internal System.Windows.Forms.Button button2;
    }
}

