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
    public partial class SalesForm : Form
    {
        private readonly string connectionString = "Host=localhost;Username=postgres;Password=postgres;Database=Sport";
        private List<SalesItem> cart = new List<SalesItem>();
        private User currentUser;
        public SalesForm(User user)
        {
            InitializeComponent();
            currentUser = user;
            LoadProductData();
        }
        private async void LoadProductData()
        {
            using (IDbConnection db = new NpgsqlConnection(connectionString))
            {
                /*var products = await db.QueryAsync<Product>(
                    "SELECT w.product_id, p.name, w.unit_price, w.quantity " +
                    "FROM products p JOIN warehouse w ON p.product_id = w.product_id");*/
                var products = await db.QueryAsync<Product>(
    "SELECT w.product_id AS ProductId, p.name AS ProductName, w.quantity AS Quantity, w.unit_price AS UnitPrice " +
    "FROM warehouse w JOIN products p ON w.product_id = p.product_id");

                dataGridViewProducts.DataSource = products;
            }
        }

        private void btnAddToCart_Click(object sender, EventArgs e)
        {
            if (dataGridViewProducts.SelectedRows.Count > 0)
            {
                var selectedRow = dataGridViewProducts.SelectedRows[0];
                var product = new SalesItem
                {
                    ProductId = (int)selectedRow.Cells["ProductId"].Value,
                    ProductName = (string)selectedRow.Cells["ProductName"].Value,
                    UnitPrice = (decimal)selectedRow.Cells["UnitPrice"].Value,
                    Quantity = (int)numericUpDownQuantity.Value
                };

                cart.Add(product);
                UpdateCart();
            }
            else
            {
                MessageBox.Show("Please select a product to add to cart.");
            }
        }

        private void UpdateCart()
        {
            dataGridViewCart.DataSource = null;
            dataGridViewCart.DataSource = cart;
            dataGridViewCart.Refresh();
        }


        private async void btnCompleteSale_Click(object sender, EventArgs e)
        {
            try
            {
                using (IDbConnection db = new NpgsqlConnection(connectionString))
                {
                    // Создание записи о продаже
                    var saleDate = DateTime.Now;
                    var totalAmount = cart.Sum(item => item.Quantity * item.UnitPrice);

                    var saleId = await db.ExecuteScalarAsync<int>(
                        "INSERT INTO sales (sale_date, employee_id, total_amount) " +
                        "VALUES (@SaleDate, @EmployeeId, @TotalAmount) RETURNING sale_id",
                        new { SaleDate = saleDate, EmployeeId = currentUser.EmployeeId, TotalAmount = totalAmount });

                    // Создание записей о проданных товарах
                    foreach (var item in cart)
                    {
                        await db.ExecuteAsync(
                            "INSERT INTO sale_items (sale_id, product_id, quantity, price) " +
                            "VALUES (@SaleId, @ProductId, @Quantity, @Price)",
                            new { SaleId = saleId, ProductId = item.ProductId, Quantity = item.Quantity, Price = item.UnitPrice });
                    }

                    // Получение полной информации о продаже
                    var saleInfo = await db.QueryAsync<SaleInfo>(
                        "SELECT s.sale_id, s.sale_date, e.name AS employee_name, si.product_id, p.product_name, si.quantity, si.price " +
                        "FROM sales s " +
                        "JOIN employees e ON s.employee_id = e.employee_id " +
                        "JOIN sale_items si ON s.sale_id = si.sale_id " +
                        "JOIN products p ON si.product_id = p.product_id " +
                        "WHERE s.sale_id = @SaleId",
                        new { SaleId = saleId });

                    // Формирование сообщения с информацией о продаже
                    var message = $"Sale ID: {saleId}\nSale Date: {saleDate}\nEmployee: {currentUser.Name}\nTotal Amount: {totalAmount:C}\n\n";
                    message += "Items:\n";
                    foreach (var item in saleInfo)
                    {
                        message += $"Product: {item.ProductName}\nQuantity: {item.Quantity}\nPrice: {item.Price:C}\n\n";
                    }

                    // Очистка корзины
                    cart.Clear();
                    UpdateCart();

                    // Показ всплывающего окна с информацией о продаже
                    MessageBox.Show(message, "Sale Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error completing sale: {ex.Message}");
            }
        }

        private void SalesForm_Load(object sender, EventArgs e)
        {

        }

        private void btnAddToCart_Click_1(object sender, EventArgs e)
        {
            if (dataGridViewProducts.SelectedRows.Count > 0)
            {
                var selectedRow = dataGridViewProducts.SelectedRows[0];
                var product = new SalesItem
                {
                    ProductId = (int)selectedRow.Cells["ProductId"].Value,
                    ProductName = (string)selectedRow.Cells["ProductName"].Value,
                    UnitPrice = (decimal)selectedRow.Cells["UnitPrice"].Value,
                    Quantity = (int)numericUpDownQuantity.Value
                };

                cart.Add(product);
                UpdateCart();
            }
            else
            {
                MessageBox.Show("Please select a product to add to cart.");
            }
        }

        private async void btnCompleteSale_Click_1(object sender, EventArgs e)
        {
            try
            {
                using (IDbConnection db = new NpgsqlConnection(connectionString))
                {
                    // Создание записи о продаже
                    var saleDate = DateTime.Now;
                    var totalAmount = cart.Sum(item => item.Quantity * item.UnitPrice);

                    var saleId = await db.ExecuteScalarAsync<int>(
                        "INSERT INTO sales (sale_date, employee_id, total_amount) " +
                        "VALUES (@SaleDate, @EmployeeId, @TotalAmount) RETURNING sale_id",
                        new { SaleDate = saleDate, EmployeeId = 1, TotalAmount = totalAmount });

                    // Создание записей о проданных товарах
                    foreach (var item in cart)
                    {
                        await db.ExecuteAsync(
                            "INSERT INTO sale_items (sale_id, product_id, quantity, price) " +
                            "VALUES (@SaleId, @ProductId, @Quantity, @Price)",
                            new { SaleId = saleId, ProductId = item.ProductId, Quantity = item.Quantity, Price = item.UnitPrice });
                    }

                    // Получение полной информации о продаже
                    var saleInfo = await db.QueryAsync<SaleInfo>(
                        "SELECT s.sale_id, s.sale_date, e.username AS employee_name, si.product_id, p.name, si.quantity, si.price " +
                        "FROM sales s " +
                        "JOIN employees e ON s.employee_id = e.employee_id " +
                        "JOIN sale_items si ON s.sale_id = si.sale_id " +
                        "JOIN products p ON si.product_id = p.product_id " +
                        "WHERE s.sale_id = @SaleId",
                        new { SaleId = saleId });

                    // Формирование сообщения с информацией о продаже
                    var message = $"Sale ID: {saleId}\nSale Date: {saleDate}\nEmployee: {currentUser.Name}\nTotal Amount: {totalAmount:C}\n\n";
                    message += "Items:\n";
                    foreach (var item in saleInfo)
                    {
                        message += $"Product: {item.ProductName}\nQuantity: {item.Quantity}\nPrice: {item.Price:C}\n\n";
                    }

                    // Очистка корзины
                    cart.Clear();
                    UpdateCart();

                    // Показ всплывающего окна с информацией о продаже
                    MessageBox.Show(message, "Sale Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error completing sale: {ex.Message}");
            }

        }

        private void dataGridViewCart_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
    
}
