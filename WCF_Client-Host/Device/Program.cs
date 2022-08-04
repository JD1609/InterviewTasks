using System;
using Device.ServiceReference;

namespace Device
{
    class Program
    {
        static void Main(string[] args)
        {
            DeviceControlClient client = new DeviceControlClient("BasicHttpBinding_IDeviceControl");
            while (0 < 1) 
            {
                Console.WriteLine("Enter device ID:");
                Console.Write("\t");

                int id;
                var input = Console.ReadLine();
                int.TryParse(input, out id);

                if (id == 0)
                {
                    Console.WriteLine($"\tWrong input ('{input}')\n");
                    continue;
                }

                Console.WriteLine("Enter message:");
                Console.Write("\t");
                string message = Console.ReadLine();

                Console.WriteLine("\t" + client.SendMessage(id, message) + "\n");
            }
        }
    }
}
