namespace Sport
{
    partial class ReportsForm
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.dataGridViewSalesReport = new System.Windows.Forms.DataGridView();
            this.dateTimePickerStartDate = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerEndDate = new System.Windows.Forms.DateTimePicker();
            this.btnLoadSalesReport = new System.Windows.Forms.Button();
            this.chartSales = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSalesReport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartSales)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewSalesReport
            // 
            this.dataGridViewSalesReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSalesReport.Location = new System.Drawing.Point(12, 12);
            this.dataGridViewSalesReport.Name = "dataGridViewSalesReport";
            this.dataGridViewSalesReport.Size = new System.Drawing.Size(370, 150);
            this.dataGridViewSalesReport.TabIndex = 0;
            // 
            // dateTimePickerStartDate
            // 
            this.dateTimePickerStartDate.Location = new System.Drawing.Point(414, 43);
            this.dateTimePickerStartDate.Name = "dateTimePickerStartDate";
            this.dateTimePickerStartDate.Size = new System.Drawing.Size(200, 20);
            this.dateTimePickerStartDate.TabIndex = 1;
            this.dateTimePickerStartDate.ValueChanged += new System.EventHandler(this.dateTimePickerStartDate_ValueChanged);
            // 
            // dateTimePickerEndDate
            // 
            this.dateTimePickerEndDate.Location = new System.Drawing.Point(414, 105);
            this.dateTimePickerEndDate.Name = "dateTimePickerEndDate";
            this.dateTimePickerEndDate.Size = new System.Drawing.Size(200, 20);
            this.dateTimePickerEndDate.TabIndex = 2;
            // 
            // btnLoadSalesReport
            // 
            this.btnLoadSalesReport.Location = new System.Drawing.Point(119, 243);
            this.btnLoadSalesReport.Name = "btnLoadSalesReport";
            this.btnLoadSalesReport.Size = new System.Drawing.Size(132, 23);
            this.btnLoadSalesReport.TabIndex = 3;
            this.btnLoadSalesReport.Text = "Сформировать отчет";
            this.btnLoadSalesReport.UseVisualStyleBackColor = true;
            this.btnLoadSalesReport.Click += new System.EventHandler(this.btnLoadSalesReport_Click_1);
            // 
            // chartSales
            // 
            chartArea4.Name = "ChartArea1";
            this.chartSales.ChartAreas.Add(chartArea4);
            legend4.Name = "Legend1";
            this.chartSales.Legends.Add(legend4);
            this.chartSales.Location = new System.Drawing.Point(414, 154);
            this.chartSales.Name = "chartSales";
            series4.ChartArea = "ChartArea1";
            series4.Legend = "Legend1";
            series4.Name = "Series1";
            this.chartSales.Series.Add(series4);
            this.chartSales.Size = new System.Drawing.Size(300, 300);
            this.chartSales.TabIndex = 4;
            this.chartSales.Text = "chart1";
            // 
            // ReportsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.chartSales);
            this.Controls.Add(this.btnLoadSalesReport);
            this.Controls.Add(this.dateTimePickerEndDate);
            this.Controls.Add(this.dateTimePickerStartDate);
            this.Controls.Add(this.dataGridViewSalesReport);
            this.Name = "ReportsForm";
            this.Text = "ReportsForm";
            this.Load += new System.EventHandler(this.ReportsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSalesReport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartSales)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewSalesReport;
        private System.Windows.Forms.DateTimePicker dateTimePickerStartDate;
        private System.Windows.Forms.DateTimePicker dateTimePickerEndDate;
        private System.Windows.Forms.Button btnLoadSalesReport;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartSales;
    }
}