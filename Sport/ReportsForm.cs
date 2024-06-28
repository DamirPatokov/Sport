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
    public partial class ReportsForm : Form
    {
        private readonly string connectionString = "Host=localhost;Username=postgres;Password=postgres;Database=Sport";
        private User currentUser;
        public ReportsForm(User user)
        {
            InitializeComponent();
            currentUser = user;
        }
        private async void btnLoadSalesReport_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Button working");
            /*DateTime startDate = dateTimePickerStartDate.Value;
            DateTime endDate = dateTimePickerEndDate.Value;

            using (IDbConnection db = new NpgsqlConnection(connectionString))
            {
                var salesReport = await db.QueryAsync<SalesReport>(
                    "SELECT p.product_name, SUM(s.quantity) as QuantitySold, SUM(s.quantity * s.unit_price) as TotalSales " +
                    "FROM sales s JOIN products p ON s.product_id = p.product_id " +
                    "WHERE s.sale_date BETWEEN @StartDate AND @EndDate " +
                    "GROUP BY p.name",
                    new { StartDate = startDate, EndDate = endDate });

                dataGridViewSalesReport.DataSource = salesReport;
            }*/

            try
            {
                var startDate = dateTimePickerStartDate.Value.Date;
                var endDate = dateTimePickerEndDate.Value.Date;

                using (IDbConnection db = new NpgsqlConnection(connectionString))
                {
                    var salesReport = await db.QueryAsync<SalesReportItem>(
                        "SELECT s.sale_id AS SaleId, s.sale_date AS SaleDate, p.name AS ProductName , si.quantity AS Quantity, si.price AS Price " +
                        "FROM sales s " +
                        "JOIN sale_items si ON s.sale_id = si.sale_id " +
                        "JOIN products p ON si.product_id = p.product_id " +
                        "WHERE s.sale_date BETWEEN @StartDate AND @EndDate",
                        new { StartDate = startDate, EndDate = endDate });

                    if (!salesReport.Any())
                    {
                        MessageBox.Show("No sales data found for the selected period");
                        return;
                    }
                    foreach (var item in salesReport)
                    {
                        //Console.WriteLine($"Sale ID: {item.SaleId}, Product:{item.ProductName}, Quantity: {item.Quantity}, Price: {item.Price}");
                        Console.WriteLine($"Sale ID: {item.SaleId},Sale Date: {item.SaleDate}, Product:{item.ProductName}, Quantity: {item.Quantity}, Price: {item.Price}");
                    }
                    dataGridViewSalesReport.DataSource = salesReport.ToList();

                    // Построение диаграммы
                    var salesData = salesReport.GroupBy(sr => sr.ProductName)
                                               .Select(g => new { ProductName = g.Key, TotalQuantity = g.Sum(sr => sr.Quantity) })
                                               .ToList();

                    chartSales.Series.Clear();
                    var series = new System.Windows.Forms.DataVisualization.Charting.Series
                    {
                        Name = "Sales",
                        Color = System.Drawing.Color.Blue,
                        ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column
                    };
                    chartSales.Series.Add(series);

                    foreach (var data in salesData)
                    {
                        series.Points.AddXY(data.ProductName, data.TotalQuantity);
                    }

                    chartSales.Invalidate(); // Обновление диаграммы

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error generating report: {ex.Message}");
            }
        }
        private void ReportsForm_Load(object sender, EventArgs e)
        {

        }

        private void dateTimePickerStartDate_ValueChanged(object sender, EventArgs e)
        {

        }

        private async void btnLoadSalesReport_Click_1(object sender, EventArgs e)
        {
            try
            {
                var startDate = dateTimePickerStartDate.Value.Date;
                var endDate = dateTimePickerEndDate.Value.Date;

                using (IDbConnection db = new NpgsqlConnection(connectionString))
                {
                    var salesReport = await db.QueryAsync<SalesReportItem>(
                        "SELECT s.sale_id AS SaleId, s.sale_date AS SaleDate, p.name AS ProductName , si.quantity AS Quantity, si.price AS Price " +
                        "FROM sales s " +
                        "JOIN sale_items si ON s.sale_id = si.sale_id " +
                        "JOIN products p ON si.product_id = p.product_id " +
                        "WHERE s.sale_date BETWEEN @StartDate AND @EndDate",
                        new { StartDate = startDate, EndDate = endDate });

                    if (!salesReport.Any())
                    {
                        MessageBox.Show("No sales data found for the selected period");
                        return;
                    }
                    foreach (var item in salesReport)
                    {
                        //Console.WriteLine($"Sale ID: {item.SaleId}, Product:{item.ProductName}, Quantity: {item.Quantity}, Price: {item.Price}");
                        Console.WriteLine($"Sale ID: {item.SaleId},Sale Date: {item.SaleDate}, Product:{item.ProductName}, Quantity: {item.Quantity}, Price: {item.Price}");
                    }
                    dataGridViewSalesReport.DataSource = salesReport.ToList();

                    // Построение диаграммы
                    var salesData = salesReport.GroupBy(sr => sr.ProductName)
                                               .Select(g => new { ProductName = g.Key, TotalQuantity = g.Sum(sr => sr.Quantity) })
                                               .ToList();

                    chartSales.Series.Clear();
                    var series = new System.Windows.Forms.DataVisualization.Charting.Series
                    {
                        Name = "Sales",
                        Color = System.Drawing.Color.Blue,
                        ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column
                    };
                    chartSales.Series.Add(series);

                    foreach (var data in salesData)
                    {
                        series.Points.AddXY(data.ProductName, data.TotalQuantity);
                    }

                    chartSales.Invalidate(); // Обновление диаграммы

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error generating report: {ex.Message}");
            }
        }
    }
}
