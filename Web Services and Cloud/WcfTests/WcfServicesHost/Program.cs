using ClassLibrary1;
using System;
using System.ServiceModel;
using System.ServiceModel.Description;

namespace WcfServicesHost
{
    class Program
    {
        static void Main(string[] args)
        {
            var url = "http://127.0.0.1:9876";

            var behavior = new ServiceMetadataBehavior();
            behavior.HttpGetEnabled = true;

            ServiceHost host = new ServiceHost(typeof(MessageService), new Uri(url));

            host.Description.Behaviors.Add(behavior);
            host.Open();

            Console.WriteLine("Service working on {0}", url);

            Console.ReadKey(true);

            host.Close();
        }
    }
}
