using CH09.EmployeeService.Services;
using System;
using System.ServiceModel;
using System.ServiceModel.Description;

namespace CH09.SelfHostingDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceUrl = new Uri("http://localhost:59795/Services/EmployeeService");

            // create Service Host
            using (var serviceHost = new ServiceHost(typeof(EmployeeService.Services.EmployeeService), serviceUrl))
            {
                // add the service endpoint
                serviceHost.AddServiceEndpoint(typeof(IEmployeeService), new BasicHttpBinding(), "");
                serviceHost.Description.Behaviors.Add(new ServiceMetadataBehavior { HttpGetEnabled = true });

                // start the Service host
                serviceHost.Open();

                Console.WriteLine("Service hosting time: " + DateTime.Now.ToString());
                Console.WriteLine();
                Console.WriteLine("Service Host is running...");
                Console.WriteLine("Press [Enter] key to stop the host...");
                Console.ReadLine();

                // close the Service host
                serviceHost.Close();
            }
        }
    }
}
