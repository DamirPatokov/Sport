namespace Sport
{
    partial class MainForm
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
            this.btnWarehouse = new System.Windows.Forms.Button();
            this.btnSales = new System.Windows.Forms.Button();
            this.btnReports = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnWarehouse
            // 
            this.btnWarehouse.Location = new System.Drawing.Point(88, 84);
            this.btnWarehouse.Name = "btnWarehouse";
            this.btnWarehouse.Size = new System.Drawing.Size(125, 63);
            this.btnWarehouse.TabIndex = 0;
            this.btnWarehouse.Text = "Склад";
            this.btnWarehouse.UseVisualStyleBackColor = true;
            this.btnWarehouse.Click += new System.EventHandler(this.btn_Warehouse_Click);
            // 
            // btnSales
            // 
            this.btnSales.Location = new System.Drawing.Point(88, 170);
            this.btnSales.Name = "btnSales";
            this.btnSales.Size = new System.Drawing.Size(125, 61);
            this.btnSales.TabIndex = 1;
            this.btnSales.Text = "Продажи";
            this.btnSales.UseVisualStyleBackColor = true;
            this.btnSales.Click += new System.EventHandler(this.btn_Sales_Click);
            // 
            // btnReports
            // 
            this.btnReports.Location = new System.Drawing.Point(88, 255);
            this.btnReports.Name = "btnReports";
            this.btnReports.Size = new System.Drawing.Size(125, 68);
            this.btnReports.TabIndex = 2;
            this.btnReports.Text = "Отчеты";
            this.btnReports.UseVisualStyleBackColor = true;
            this.btnReports.Click += new System.EventHandler(this.btn_Reports_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(291, 450);
            this.Controls.Add(this.btnReports);
            this.Controls.Add(this.btnSales);
            this.Controls.Add(this.btnWarehouse);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnWarehouse;
        private System.Windows.Forms.Button btnSales;
        private System.Windows.Forms.Button btnReports;
    }
}