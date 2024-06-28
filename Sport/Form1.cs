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
    public partial class Form1 : Form
    {
        private readonly string connectionString = "Host=localhost;Username=postgres;Password=postgres;Database=Sport";
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            using (IDbConnection db = new NpgsqlConnection(connectionString))
            {

                var user = await db.QueryFirstOrDefaultAsync<User>("SELECT * FROM employees WHERE username = @Username AND password = @Password",
                    new { Username = username, Password = password });

                if (user != null)
                {
                    MainForm mainForm = new MainForm(user);
                    mainForm.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Invalid login credentials!");
                }
            }

        }
    }
}
