namespace Bitcoin
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            datePickerStart = new DateTimePicker();
            datePickerEnd = new DateTimePicker();
            BtnAnalyze = new Button();
            LblMinPrice = new Label();
            LblMinPriceDate = new Label();
            LblMinVolume = new Label();
            LblMaxVolume = new Label();
            chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            tbMinPrice = new TextBox();
            LblStartDate = new Label();
            LblEndDate = new Label();
            tbMinPriceDate = new TextBox();
            tbMaxPrice = new TextBox();
            label1 = new Label();
            tbMaxPriceDate = new TextBox();
            tbVolumeMaxDate = new TextBox();
            tbVolumeMax = new TextBox();
            tbVolumeMinDate = new TextBox();
            tbVolumeMin = new TextBox();
            tbTrend = new TextBox();
            lbTrend = new Label();
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            exitToolStripMenuItem = new ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)chart1).BeginInit();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // datePickerStart
            // 
            datePickerStart.Location = new Point(47, 67);
            datePickerStart.Name = "datePickerStart";
            datePickerStart.Size = new Size(200, 23);
            datePickerStart.TabIndex = 0;
            // 
            // datePickerEnd
            // 
            datePickerEnd.Location = new Point(272, 67);
            datePickerEnd.Name = "datePickerEnd";
            datePickerEnd.Size = new Size(200, 23);
            datePickerEnd.TabIndex = 1;
            // 
            // BtnAnalyze
            // 
            BtnAnalyze.Location = new Point(502, 67);
            BtnAnalyze.Name = "BtnAnalyze";
            BtnAnalyze.Size = new Size(87, 23);
            BtnAnalyze.TabIndex = 2;
            BtnAnalyze.Text = "Analysoi";
            BtnAnalyze.UseVisualStyleBackColor = true;
            BtnAnalyze.Click += BtnAnalyze_Click;
            // 
            // LblMinPrice
            // 
            LblMinPrice.AutoSize = true;
            LblMinPrice.Location = new Point(56, 157);
            LblMinPrice.Name = "LblMinPrice";
            LblMinPrice.Size = new Size(63, 15);
            LblMinPrice.TabIndex = 3;
            LblMinPrice.Text = "Hinta Min:";
            // 
            // LblMinPriceDate
            // 
            LblMinPriceDate.AutoSize = true;
            LblMinPriceDate.Location = new Point(269, 136);
            LblMinPriceDate.Name = "LblMinPriceDate";
            LblMinPriceDate.Size = new Size(68, 15);
            LblMinPriceDate.TabIndex = 4;
            LblMinPriceDate.Text = "Päivämäärä";
            // 
            // LblMinVolume
            // 
            LblMinVolume.Location = new Point(56, 236);
            LblMinVolume.Name = "LblMinVolume";
            LblMinVolume.Size = new Size(87, 35);
            LblMinVolume.TabIndex = 5;
            LblMinVolume.Text = "Kaupankäynti Volyymi Min:";
            // 
            // LblMaxVolume
            // 
            LblMaxVolume.Location = new Point(56, 285);
            LblMaxVolume.Name = "LblMaxVolume";
            LblMaxVolume.Size = new Size(87, 37);
            LblMaxVolume.TabIndex = 6;
            LblMaxVolume.Text = "Kaupankäynti Volyymi Max:";
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            chart1.Legends.Add(legend1);
            chart1.Location = new Point(440, 135);
            chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            chart1.Series.Add(series1);
            chart1.Size = new Size(1232, 444);
            chart1.TabIndex = 7;
            chart1.Text = "chart1";
            // 
            // tbMinPrice
            // 
            tbMinPrice.Location = new Point(147, 154);
            tbMinPrice.Name = "tbMinPrice";
            tbMinPrice.ReadOnly = true;
            tbMinPrice.Size = new Size(100, 23);
            tbMinPrice.TabIndex = 8;
            tbMinPrice.TextAlign = HorizontalAlignment.Right;
            // 
            // LblStartDate
            // 
            LblStartDate.AutoSize = true;
            LblStartDate.Location = new Point(99, 42);
            LblStartDate.Name = "LblStartDate";
            LblStartDate.Size = new Size(75, 15);
            LblStartDate.TabIndex = 9;
            LblStartDate.Text = "Aloitus Päivä";
            // 
            // LblEndDate
            // 
            LblEndDate.AutoSize = true;
            LblEndDate.Location = new Point(333, 42);
            LblEndDate.Name = "LblEndDate";
            LblEndDate.Size = new Size(72, 15);
            LblEndDate.TabIndex = 10;
            LblEndDate.Text = "Loppu Päivä";
            // 
            // tbMinPriceDate
            // 
            tbMinPriceDate.Location = new Point(253, 154);
            tbMinPriceDate.Name = "tbMinPriceDate";
            tbMinPriceDate.ReadOnly = true;
            tbMinPriceDate.Size = new Size(100, 23);
            tbMinPriceDate.TabIndex = 11;
            tbMinPriceDate.TextAlign = HorizontalAlignment.Right;
            // 
            // tbMaxPrice
            // 
            tbMaxPrice.Location = new Point(147, 194);
            tbMaxPrice.Name = "tbMaxPrice";
            tbMaxPrice.ReadOnly = true;
            tbMaxPrice.Size = new Size(100, 23);
            tbMaxPrice.TabIndex = 12;
            tbMaxPrice.TextAlign = HorizontalAlignment.Right;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(56, 197);
            label1.Name = "label1";
            label1.Size = new Size(65, 15);
            label1.TabIndex = 13;
            label1.Text = "Hinta Max:";
            // 
            // tbMaxPriceDate
            // 
            tbMaxPriceDate.Location = new Point(253, 194);
            tbMaxPriceDate.Name = "tbMaxPriceDate";
            tbMaxPriceDate.ReadOnly = true;
            tbMaxPriceDate.Size = new Size(100, 23);
            tbMaxPriceDate.TabIndex = 14;
            tbMaxPriceDate.TextAlign = HorizontalAlignment.Right;
            // 
            // tbVolumeMaxDate
            // 
            tbVolumeMaxDate.Location = new Point(253, 299);
            tbVolumeMaxDate.Name = "tbVolumeMaxDate";
            tbVolumeMaxDate.ReadOnly = true;
            tbVolumeMaxDate.Size = new Size(100, 23);
            tbVolumeMaxDate.TabIndex = 18;
            tbVolumeMaxDate.TextAlign = HorizontalAlignment.Right;
            // 
            // tbVolumeMax
            // 
            tbVolumeMax.Location = new Point(147, 299);
            tbVolumeMax.Name = "tbVolumeMax";
            tbVolumeMax.ReadOnly = true;
            tbVolumeMax.Size = new Size(100, 23);
            tbVolumeMax.TabIndex = 17;
            tbVolumeMax.TextAlign = HorizontalAlignment.Right;
            // 
            // tbVolumeMinDate
            // 
            tbVolumeMinDate.Location = new Point(253, 245);
            tbVolumeMinDate.Name = "tbVolumeMinDate";
            tbVolumeMinDate.ReadOnly = true;
            tbVolumeMinDate.Size = new Size(100, 23);
            tbVolumeMinDate.TabIndex = 16;
            tbVolumeMinDate.TextAlign = HorizontalAlignment.Right;
            // 
            // tbVolumeMin
            // 
            tbVolumeMin.Location = new Point(147, 245);
            tbVolumeMin.Name = "tbVolumeMin";
            tbVolumeMin.ReadOnly = true;
            tbVolumeMin.Size = new Size(100, 23);
            tbVolumeMin.TabIndex = 15;
            tbVolumeMin.TextAlign = HorizontalAlignment.Right;
            // 
            // tbTrend
            // 
            tbTrend.Location = new Point(147, 340);
            tbTrend.Multiline = true;
            tbTrend.Name = "tbTrend";
            tbTrend.ReadOnly = true;
            tbTrend.Size = new Size(258, 72);
            tbTrend.TabIndex = 19;
            // 
            // lbTrend
            // 
            lbTrend.AutoSize = true;
            lbTrend.Location = new Point(56, 343);
            lbTrend.Name = "lbTrend";
            lbTrend.Size = new Size(42, 15);
            lbTrend.TabIndex = 20;
            lbTrend.Text = "Trendi:";
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1739, 24);
            menuStrip1.TabIndex = 21;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { exitToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(37, 20);
            fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(93, 22);
            exitToolStripMenuItem.Text = "Exit";
            exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1739, 669);
            Controls.Add(lbTrend);
            Controls.Add(tbTrend);
            Controls.Add(tbVolumeMaxDate);
            Controls.Add(tbVolumeMax);
            Controls.Add(tbVolumeMinDate);
            Controls.Add(tbVolumeMin);
            Controls.Add(tbMaxPriceDate);
            Controls.Add(label1);
            Controls.Add(tbMaxPrice);
            Controls.Add(tbMinPriceDate);
            Controls.Add(LblEndDate);
            Controls.Add(LblStartDate);
            Controls.Add(tbMinPrice);
            Controls.Add(chart1);
            Controls.Add(LblMaxVolume);
            Controls.Add(LblMinVolume);
            Controls.Add(LblMinPriceDate);
            Controls.Add(LblMinPrice);
            Controls.Add(BtnAnalyze);
            Controls.Add(datePickerEnd);
            Controls.Add(datePickerStart);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "MainForm";
            Text = "BitcoinApp";
            ((System.ComponentModel.ISupportInitialize)chart1).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DateTimePicker datePickerStart;
        private DateTimePicker datePickerEnd;
        private Button BtnAnalyze;
        private Label LblMinPrice;
        private Label LblMinPriceDate;
        private Label LblMinVolume;
        private Label LblMaxVolume;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private TextBox tbMinPrice;
        private Label LblStartDate;
        private Label LblEndDate;
        private TextBox tbMinPriceDate;
        private TextBox tbMaxPrice;
        private Label label1;
        private TextBox tbMaxPriceDate;
        private TextBox tbVolumeMaxDate;
        private TextBox tbVolumeMax;
        private TextBox tbVolumeMinDate;
        private TextBox tbVolumeMin;
        private TextBox tbTrend;
        private Label lbTrend;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
    }
}
