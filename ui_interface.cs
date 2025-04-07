using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace DataManagementSystem
{
    public partial class UIInterface : Form
    {
        SqlConnection con = new SqlConnection("Data Source=localhost;Initial Catalog=YourDatabaseName;Integrated Security=True");

        public UIInterface()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();

                // Insert user
                string insertUser = "INSERT INTO Users (name, email) VALUES (@name, @email); SELECT SCOPE_IDENTITY();";
                SqlCommand cmdUser = new SqlCommand(insertUser, con);
                cmdUser.Parameters.AddWithValue("@name", txtName.Text);
                cmdUser.Parameters.AddWithValue("@email", txtEmail.Text);
                int userId = Convert.ToInt32(cmdUser.ExecuteScalar());

                // Insert data record
                string insertRecord = "INSERT INTO DataRecords (user_id, data_value, data_type) VALUES (@userId, @value, @type)";
