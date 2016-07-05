namespace CCHServer
{
    using Microsoft.ServiceBus;
    using System;
    using System.ServiceModel;
    using static EmployeeContract;
    class EmployeeService : IEmployeeService
    {
        public EmployeeData AuthenticateUser(EmployeeData employee)
        {
            Console.WriteLine("AuthenticateUser called.");
            if (employee.Username == "mohsink13@gmail.com")
            {
                Console.WriteLine($"Authentication successful for {employee.Username}");
                return new EmployeeData
                {
                    Username = employee.Username,
                    UserId = "1"
                };
            }
            Console.WriteLine($"Authentication failure for {employee.Username}");
            return null;
            
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var sh = new ServiceHost(typeof(EmployeeService));

            sh.AddServiceEndpoint(
                typeof(IEmployeeService), 
                new NetTcpRelayBinding(),
                ServiceBusEnvironment.CreateServiceUri("sb","mktestrelay","central"))
                .Behaviors.Add(new TransportClientEndpointBehavior
                {
                    TokenProvider = TokenProvider.CreateSharedAccessSignatureTokenProvider("RootManageSharedAccessKey", "zMSPq+sqa7tjeTKvbdcTAXT6/rNNRDkQvzPb6zNiC2A=")
                });


            sh.Open();

            Console.WriteLine("Press ENTER to close");
            Console.ReadLine();

            sh.Close();
        }
    }
}
