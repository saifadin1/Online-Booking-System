using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OnlineBookingSystem
{
    public partial class TrainSelectionFormcs : Form
    {
        public TrainSelectionFormcs()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // i have a dataBase called DB in my local server and i have a table called Train in it 
            // and i have 4 columns in it (Train_ID,Class,Type)
            // i want to select all the data from the table and show it in the datagridview

            try
            {
                string connectionString = "Data Source=.;Initial Catalog=DB;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "SELECT t.Class, t.Type FROM Train t JOIN Trip tr ON t.Train_id = tr.Train_id WHERE tr.Departure = @Departure AND tr.Destination = @Destination";
                        
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@Departure", FromComboBox.Text);
                        command.Parameters.AddWithValue("@Destination", ToComboBox.Text);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            DataTable dt = new DataTable(); 
                            dt.Load(reader);
                            dataGridView1.DataSource = dt;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void FromComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void TrainSelectionFormcs_Load(object sender, EventArgs e)
        {
            try
            {
                string connectionString = "Data Source=.;Initial Catalog=DB;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = $"select distinct Departure from Trip";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                FromComboBox.Items.Add(reader.GetString(0));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            try
            {
                string connectionString = "Data Source=.;Initial Catalog=DB;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = $"select distinct Destination from Trip";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                ToComboBox.Items.Add(reader.GetString(0));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
