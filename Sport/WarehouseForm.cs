using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dapper;
using Npgsql;
namespace Sport
{
    public partial class WarehouseForm : Form
    {
        private readonly string connectionString = "Host=localhost;Username=postgres;Password=postgres;Database=Sport";
        private List<OrderItem> orderItems = new List<OrderItem>();
        private User currentUser;
        public WarehouseForm(User user)
        {
            InitializeComponent();
            currentUser = user;
            LoadWarehouseData();
        }
        /*private async void LoadWarehouseData()
        {
            using (IDbConnection db = new NpgsqlConnection(connectionString))
            {
                var items = await db.QueryAsync<WarehouseItem>(
                    "SELECT w.product_id, p.name, w.quantity, w.unit_price " +
                    "FROM warehouse w JOIN products p ON w.product_id = p.product_id");

                dataGridViewWarehouse.DataSource = items;
            }
        }*/
        private async void LoadWarehouseData()
        {
            using (IDbConnection db = new NpgsqlConnection(connectionString))
            {
                /*var items = await db.QueryAsync<WarehouseItem>(
                    "SELECT w.product_id, p.name, w.quantity, w.unit_price " +
                    "FROM warehouse w JOIN products p ON w.product_id = p.product_id");*/
                var items = await db.QueryAsync<WarehouseItem>(
    "SELECT w.product_id AS ProductId, p.name AS ProductName, w.quantity AS Quantity, w.unit_price AS UnitPrice " +
    "FROM warehouse w JOIN products p ON w.product_id = p.product_id");

                dataGridViewWarehouse.DataSource = items;
            }
        }
        private async void btnCreateOrder_Click(object sender, EventArgs e)
        {
            using (IDbConnection db = new NpgsqlConnection(connectionString))
            {
                var order = new Order
                {
                    EmployeeId = currentUser.EmployeeId,
                    OrderDate = DateTime.Now
                };

                var orderId = await db.ExecuteScalarAsync<int>(
                 "INSERT INTO orders (employee_id, order_date) VALUES (@EmployeeId, @OrderDate) RETURNING order_id",
                    order);
                foreach (var item in orderItems)
                {
                    item.OrderId = orderId;
                    await db.ExecuteAsync(
                        "INSERT INTO order_items (order_id, product_id, quantity, unit_price) VALUES (@OrderId, @ProductId, @Quantity, @UnitPrice)",
                        item);
                }
                MessageBox.Show($"Order created with ID: {orderId}");
                orderItems.Clear();
                UpdateOrderItems();
            }
        }
        private async void btnUpdateStock_Click(object sender, EventArgs e)
        {
            if (dataGridViewWarehouse.SelectedRows.Count > 0)
            {
                var selectedRow = dataGridViewWarehouse.SelectedRows[0];
                var productId = (int)selectedRow.Cells["ProductId"].Value;
                var newQuantity = (int)numericUpDownQuantity.Value;

                using (IDbConnection db = new NpgsqlConnection(connectionString))
                {
                    await db.ExecuteAsync(
                        "UPDATE warehouse SET quantity = @Quantity WHERE product_id = @ProductId",
                        new { Quantity = newQuantity, ProductId = productId });

                    MessageBox.Show("Stock updated successfully!");
                    LoadWarehouseData();
                }
            }
            else
            {
                MessageBox.Show("Please select a product to update.");
            }
        }

        private void WarehouseForm_Load(object sender, EventArgs e)
        {

        }

        private void btnAddToOrder_Click(object sender, EventArgs e)
        {
            if (dataGridViewWarehouse.SelectedRows.Count > 0)
            {
                var selectedRow = dataGridViewWarehouse.SelectedRows[0];
                var orderItem = new OrderItem
                {
                    ProductId = (int)selectedRow.Cells["ProductId"].Value,
                    ProductName = (string)selectedRow.Cells["ProductName"].Value,
                    Quantity = (int)numericUpDownQuantity.Value,
                    UnitPrice = (decimal)selectedRow.Cells["UnitPrice"].Value
                };

                orderItems.Add(orderItem);
                UpdateOrderItems();
            }

            else
            {
                MessageBox.Show("Please select a product to add to the order.");
            }

        }
        private async void btnAddToWarehouse_Click(object sender, EventArgs e)
        {
            using (IDbConnection db = new NpgsqlConnection(connectionString))
            {
                var product = new WarehouseItem
                {
                    ProductId = int.Parse(txtProductId.Text),
                    Quantity = int.Parse(txtQuantity.Text),
                    UnitPrice = decimal.Parse(txtUnitPrice.Text)
                };
                await db.ExecuteAsync(
                   "INSERT INTO warehouse (product_id, quantity, unit_price) VALUES (@ProductId, @Quantity, @UnitPrice)",
                   product);

                MessageBox.Show("Product added to warehouse.");
                LoadWarehouseData();

            }
        }
        private void UpdateOrderItems()
        {
            dataGridViewOrderItems.DataSource = null;
            dataGridViewOrderItems.DataSource = orderItems;
            dataGridViewOrderItems.Refresh();
        }

    }
}
