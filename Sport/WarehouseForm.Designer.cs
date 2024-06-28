namespace Sport
{
    partial class WarehouseForm
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
            this.dataGridViewWarehouse = new System.Windows.Forms.DataGridView();
            this.btnCreateOrder = new System.Windows.Forms.Button();
            this.numericUpDownQuantity = new System.Windows.Forms.NumericUpDown();
            this.dataGridViewOrderItems = new System.Windows.Forms.DataGridView();
            this.btnAddToOrder = new System.Windows.Forms.Button();
            this.txtProductId = new System.Windows.Forms.TextBox();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.txtUnitPrice = new System.Windows.Forms.TextBox();
            this.btnAddToWarehouse = new System.Windows.Forms.Button();
            this.lblProductId = new System.Windows.Forms.Label();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.lblUnitPrice = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewWarehouse)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownQuantity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOrderItems)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewWarehouse
            // 
            this.dataGridViewWarehouse.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewWarehouse.Location = new System.Drawing.Point(428, 12);
            this.dataGridViewWarehouse.Name = "dataGridViewWarehouse";
            this.dataGridViewWarehouse.Size = new System.Drawing.Size(369, 186);
            this.dataGridViewWarehouse.TabIndex = 0;
            // 
            // btnCreateOrder
            // 
            this.btnCreateOrder.Location = new System.Drawing.Point(32, 333);
            this.btnCreateOrder.Name = "btnCreateOrder";
            this.btnCreateOrder.Size = new System.Drawing.Size(101, 23);
            this.btnCreateOrder.TabIndex = 1;
            this.btnCreateOrder.Text = "Сделать заказ";
            this.btnCreateOrder.UseVisualStyleBackColor = true;
            // 
            // numericUpDownQuantity
            // 
            this.numericUpDownQuantity.Location = new System.Drawing.Point(308, 282);
            this.numericUpDownQuantity.Name = "numericUpDownQuantity";
            this.numericUpDownQuantity.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownQuantity.TabIndex = 3;
            // 
            // dataGridViewOrderItems
            // 
            this.dataGridViewOrderItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewOrderItems.Location = new System.Drawing.Point(0, 12);
            this.dataGridViewOrderItems.Name = "dataGridViewOrderItems";
            this.dataGridViewOrderItems.Size = new System.Drawing.Size(388, 186);
            this.dataGridViewOrderItems.TabIndex = 4;
            // 
            // btnAddToOrder
            // 
            this.btnAddToOrder.Location = new System.Drawing.Point(206, 333);
            this.btnAddToOrder.Name = "btnAddToOrder";
            this.btnAddToOrder.Size = new System.Drawing.Size(103, 23);
            this.btnAddToOrder.TabIndex = 5;
            this.btnAddToOrder.Text = "Добавить товар";
            this.btnAddToOrder.UseVisualStyleBackColor = true;
            this.btnAddToOrder.Click += new System.EventHandler(this.btnAddToOrder_Click);
            // 
            // txtProductId
            // 
            this.txtProductId.Location = new System.Drawing.Point(23, 390);
            this.txtProductId.Name = "txtProductId";
            this.txtProductId.Size = new System.Drawing.Size(100, 20);
            this.txtProductId.TabIndex = 6;
            // 
            // txtQuantity
            // 
            this.txtQuantity.Location = new System.Drawing.Point(192, 390);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(100, 20);
            this.txtQuantity.TabIndex = 7;
            // 
            // txtUnitPrice
            // 
            this.txtUnitPrice.Location = new System.Drawing.Point(407, 390);
            this.txtUnitPrice.Name = "txtUnitPrice";
            this.txtUnitPrice.Size = new System.Drawing.Size(100, 20);
            this.txtUnitPrice.TabIndex = 8;
            // 
            // btnAddToWarehouse
            // 
            this.btnAddToWarehouse.Location = new System.Drawing.Point(428, 333);
            this.btnAddToWarehouse.Name = "btnAddToWarehouse";
            this.btnAddToWarehouse.Size = new System.Drawing.Size(115, 23);
            this.btnAddToWarehouse.TabIndex = 9;
            this.btnAddToWarehouse.Text = "Добаить на склад";
            this.btnAddToWarehouse.UseVisualStyleBackColor = true;
            this.btnAddToWarehouse.Click += new System.EventHandler(this.btnAddToWarehouse_Click);
            // 
            // lblProductId
            // 
            this.lblProductId.AutoSize = true;
            this.lblProductId.Location = new System.Drawing.Point(41, 371);
            this.lblProductId.Name = "lblProductId";
            this.lblProductId.Size = new System.Drawing.Size(58, 13);
            this.lblProductId.TabIndex = 10;
            this.lblProductId.Text = "Product ID";
            // 
            // lblQuantity
            // 
            this.lblQuantity.AutoSize = true;
            this.lblQuantity.Location = new System.Drawing.Point(217, 371);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(46, 13);
            this.lblQuantity.TabIndex = 11;
            this.lblQuantity.Text = "Quantity";
            // 
            // lblUnitPrice
            // 
            this.lblUnitPrice.AutoSize = true;
            this.lblUnitPrice.Location = new System.Drawing.Point(425, 371);
            this.lblUnitPrice.Name = "lblUnitPrice";
            this.lblUnitPrice.Size = new System.Drawing.Size(53, 13);
            this.lblUnitPrice.TabIndex = 12;
            this.lblUnitPrice.Text = "Unit Price";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(217, 274);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Количество";
            // 
            // WarehouseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblUnitPrice);
            this.Controls.Add(this.lblQuantity);
            this.Controls.Add(this.lblProductId);
            this.Controls.Add(this.btnAddToWarehouse);
            this.Controls.Add(this.txtUnitPrice);
            this.Controls.Add(this.txtQuantity);
            this.Controls.Add(this.txtProductId);
            this.Controls.Add(this.btnAddToOrder);
            this.Controls.Add(this.dataGridViewOrderItems);
            this.Controls.Add(this.numericUpDownQuantity);
            this.Controls.Add(this.btnCreateOrder);
            this.Controls.Add(this.dataGridViewWarehouse);
            this.Name = "WarehouseForm";
            this.Text = "WarehouseForm";
            this.Load += new System.EventHandler(this.WarehouseForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewWarehouse)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownQuantity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOrderItems)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewWarehouse;
        private System.Windows.Forms.Button btnCreateOrder;
        private System.Windows.Forms.NumericUpDown numericUpDownQuantity;
        private System.Windows.Forms.DataGridView dataGridViewOrderItems;
        private System.Windows.Forms.Button btnAddToOrder;
        private System.Windows.Forms.TextBox txtProductId;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.TextBox txtUnitPrice;
        private System.Windows.Forms.Button btnAddToWarehouse;
        private System.Windows.Forms.Label lblProductId;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.Label lblUnitPrice;
        private System.Windows.Forms.Label label1;
    }
}