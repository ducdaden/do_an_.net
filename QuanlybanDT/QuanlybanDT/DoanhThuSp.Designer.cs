namespace QuanlybanDT
{
    partial class DoanhThuSp
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DoanhThuSp));
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.cboThangDau = new System.Windows.Forms.ComboBox();
            this.cboNamDau = new System.Windows.Forms.ComboBox();
            this.cboThangCuoi = new System.Windows.Forms.ComboBox();
            this.cboNamCuoi = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.cboDienThoai = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(100, 169);
            this.chart1.Name = "chart1";
            this.chart1.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
            series1.ChartArea = "ChartArea1";
            series1.Color = System.Drawing.Color.SteelBlue;
            series1.IsValueShownAsLabel = true;
            series1.IsXValueIndexed = true;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(822, 408);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            // 
            // cboThangDau
            // 
            this.cboThangDau.FormattingEnabled = true;
            this.cboThangDau.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12"});
            this.cboThangDau.Location = new System.Drawing.Point(184, 50);
            this.cboThangDau.Name = "cboThangDau";
            this.cboThangDau.Size = new System.Drawing.Size(85, 24);
            this.cboThangDau.TabIndex = 1;
            // 
            // cboNamDau
            // 
            this.cboNamDau.FormattingEnabled = true;
            this.cboNamDau.Items.AddRange(new object[] {
            "2019",
            "2020",
            "2021"});
            this.cboNamDau.Location = new System.Drawing.Point(329, 50);
            this.cboNamDau.Name = "cboNamDau";
            this.cboNamDau.Size = new System.Drawing.Size(79, 24);
            this.cboNamDau.TabIndex = 2;
            this.cboNamDau.Text = "2020";
            // 
            // cboThangCuoi
            // 
            this.cboThangCuoi.FormattingEnabled = true;
            this.cboThangCuoi.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12"});
            this.cboThangCuoi.Location = new System.Drawing.Point(634, 54);
            this.cboThangCuoi.Name = "cboThangCuoi";
            this.cboThangCuoi.Size = new System.Drawing.Size(101, 24);
            this.cboThangCuoi.TabIndex = 3;
            this.cboThangCuoi.Text = "6";
            // 
            // cboNamCuoi
            // 
            this.cboNamCuoi.FormattingEnabled = true;
            this.cboNamCuoi.Items.AddRange(new object[] {
            "2019",
            "2020",
            "2021"});
            this.cboNamCuoi.Location = new System.Drawing.Point(794, 54);
            this.cboNamCuoi.Name = "cboNamCuoi";
            this.cboNamCuoi.Size = new System.Drawing.Size(93, 24);
            this.cboNamCuoi.TabIndex = 4;
            this.cboNamCuoi.Text = "2020";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(634, 104);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(103, 36);
            this.button1.TabIndex = 5;
            this.button1.Text = "Tìm";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(794, 107);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(93, 36);
            this.button2.TabIndex = 6;
            this.button2.Text = "(*)Tất cả";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // cboDienThoai
            // 
            this.cboDienThoai.FormattingEnabled = true;
            this.cboDienThoai.Location = new System.Drawing.Point(228, 104);
            this.cboDienThoai.Name = "cboDienThoai";
            this.cboDienThoai.Size = new System.Drawing.Size(155, 24);
            this.cboDienThoai.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(97, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 17);
            this.label1.TabIndex = 8;
            this.label1.Text = "Từ tháng";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(286, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 17);
            this.label2.TabIndex = 9;
            this.label2.Text = "Năm";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(554, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 17);
            this.label3.TabIndex = 10;
            this.label3.Text = "Đến tháng";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(751, 58);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 17);
            this.label4.TabIndex = 11;
            this.label4.Text = "Năm";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(97, 107);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(99, 17);
            this.label5.TabIndex = 12;
            this.label5.Text = "Tên điện thoại";
            // 
            // DoanhThuSp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(998, 614);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboDienThoai);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cboNamCuoi);
            this.Controls.Add(this.cboThangCuoi);
            this.Controls.Add(this.cboNamDau);
            this.Controls.Add(this.cboThangDau);
            this.Controls.Add(this.chart1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DoanhThuSp";
            this.Text = "DoanhThuSp";
            this.Load += new System.EventHandler(this.DoanhThuSp_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.ComboBox cboThangDau;
        private System.Windows.Forms.ComboBox cboNamDau;
        private System.Windows.Forms.ComboBox cboThangCuoi;
        private System.Windows.Forms.ComboBox cboNamCuoi;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ComboBox cboDienThoai;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}