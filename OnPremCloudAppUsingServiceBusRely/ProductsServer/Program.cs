namespace ProductsServer
{
    using Microsoft.ServiceBus;
    using System;
    using System.Collections.Generic;
    using System.ServiceModel;
    using static ProductsContract;
    class ProductsService : IProducts
    {
        ProductData[] products =
            new[]
                {
                    new ProductData{ Id = "1", Name = "Rock",
                                     Quantity = "1"},
                    new ProductData{ Id = "2", Name = "Paper",
                                     Quantity = "3"},
                    new ProductData{ Id = "3", Name = "Scissors",
                                     Quantity = "5"},
                    new ProductData{ Id = "4", Name = "Well",
                                     Quantity = "2500"},
                };

        public IList<ProductData> GetProducts()
        {
            Console.WriteLine("GetProducts called.");
            return products;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var sh = new ServiceHost(typeof(ProductsService));

            sh.AddServiceEndpoint(
                typeof(IProducts), 
                new NetTcpRelayBinding(),
                ServiceBusEnvironment.CreateServiceUri("sb","mktestrelay","products"))
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
