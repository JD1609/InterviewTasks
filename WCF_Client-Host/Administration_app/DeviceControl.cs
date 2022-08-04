using System.Data.SqlClient;
using System.Configuration;

namespace Administration_app
{
    public class DeviceControl : IDeviceControl
    {
        private string ConnectionString = ConfigurationManager.ConnectionStrings["Administration_app.Properties.Settings.DeviceDBConnectionString"].ConnectionString;

        public string SendMessage(int id, string message) 
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                using(SqlCommand cmd = new SqlCommand("INSERT INTO Devices (Device_ID, Message) VALUES (@id, @message);", connection))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@message", message);

                    connection.Open();
                    cmd.ExecuteNonQuery();
                }
                return "Message sent successfully...!";
            }
            catch
            {
                return "Error has occurred! Message wasn't sent...!";
            }
        }
    }
}