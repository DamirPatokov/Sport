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
    public partial class MainForm : Form
    {
        private User currentUser;
        public MainForm(User user)
        {
            InitializeComponent();
            currentUser = user;

            if (currentUser.Position == "Manager")
            {
                btnWarehouse.Enabled = false;
                btnReports.Enabled = false;
            }
            else if (currentUser.Position == "Warehouse")
            {
                btnSales.Enabled = false;
            }
        }



        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void btn_Warehouse_Click(object sender, EventArgs e)
        {
            WarehouseForm warehouseForm = new WarehouseForm(currentUser);
            warehouseForm.Show();
        }

        private void btn_Sales_Click(object sender, EventArgs e)
        {
            SalesForm salesForm = new SalesForm(currentUser);
            salesForm.Show();
        }

        private void btn_Reports_Click(object sender, EventArgs e)
        {
            ReportsForm reportsForm = new ReportsForm(currentUser);
            reportsForm.Show();
        }
    }
}
