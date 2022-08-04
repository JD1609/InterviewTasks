using System.Windows;
using System.ServiceModel;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace Administration_app
{
    public partial class MainWindow : Window
    {
        private string connectionString;
        public MainWindow()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["Administration_app.Properties.Settings.DeviceDBConnectionString"].ConnectionString;
            ServiceHost host = new ServiceHost(typeof(DeviceControl));
            host.Open();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            PopulateListBox();
        }

        private void PopulateListBox() 
        {
            DeviceListBox.Items.Clear();

            using (SqlConnection connection = new SqlConnection(connectionString))
            using(SqlCommand cmd = new SqlCommand("SELECT Device_ID FROM Devices", connection))
            {
                connection.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read()) 
                {
                    if(!DeviceListBox.Items.Contains(reader["Device_ID"].ToString()))
                        DeviceListBox.Items.Add(reader["Device_ID"].ToString());
                }

                connection.Close();
            }
        }

        private void DeviceListBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (DeviceListBox.SelectedItem != null)
            {
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();

                SqlCommand cmd = new SqlCommand("SELECT Message FROM Devices WHERE Device_ID=@id", connection);
                cmd.Parameters.AddWithValue("@id", DeviceListBox.SelectedItem.ToString());
                cmd.ExecuteNonQuery();

                DataTable table = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(table);

                devicesDataGrid.ItemsSource = table.DefaultView;
                NoMLabel.Content = "Number of messages: " + table.Rows.Count.ToString();
                adapter.Update(table);
                connection.Close();
            }
            else 
            {
                DataTable dt = new DataTable();
                devicesDataGrid.ItemsSource = dt.DefaultView;
                NoMLabel.Content = "Number of messages:";
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            PopulateListBox();
        }
    }
}