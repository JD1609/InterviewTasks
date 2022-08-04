using System;
using System.Windows;
using System.Data.SqlClient;

namespace Administration_app
{
    public partial class Device_Registration : Window
    {
        private int ID { get; set; }

        public Device_Registration(int id)
        {
            InitializeComponent();
            ID = id;
            TitleLabel.Content = String.Format("New device with ID: {0} detected...!\nDo you want add this device to database?", id.ToString());
        }

        private void YesBtn_Click(object sender, RoutedEventArgs e)
        {
            object ob = new object();
            lock (ob) 
            {
                SqlConnectionStringBuilder csb = new SqlConnectionStringBuilder();
                csb.DataSource = @"(LocalDB)\MSSQLLocalDB";
                csb.InitialCatalog = "DeviceDB";
                csb.IntegratedSecurity = true;

                using (SqlConnection connection = new SqlConnection(csb.ConnectionString))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("INSERT INTO Devices (Device_ID) VALUES (ID)", connection);
                    connection.Close();
                }
            }
            this.Close();
        }

        private void NoBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
