namespace ProductsPortal.Controllers
{
    using System.Linq;
    using System.ServiceModel;
    using System.Web.Mvc;
    using Microsoft.ServiceBus;
    using Models;
    using ProductsServer;
    using static ProductsServer.ProductsContract;
    public class HomeController : Controller
    {
        // Declare the channel factory.
        private static ChannelFactory<IProductsChannel> _channelFactory;

        static HomeController()
        {
            // Create shared access signature token credentials for authentication.
            _channelFactory = new ChannelFactory<IProductsChannel>(new NetTcpRelayBinding(),
                "sb://mktestrelay.servicebus.windows.net/products");
            _channelFactory.Endpoint.Behaviors.Add(new TransportClientEndpointBehavior
            {
                TokenProvider = TokenProvider.CreateSharedAccessSignatureTokenProvider(
                    "RootManageSharedAccessKey", "zMSPq+sqa7tjeTKvbdcTAXT6/rNNRDkQvzPb6zNiC2A=")
            });
        }

        public ActionResult Index()
        {
            using (IProductsChannel channel = _channelFactory.CreateChannel())
            {
                // Return a view of the products inventory.
                return View(from prod in channel.GetProducts()
                            select new Product
                                {
                                    Id = prod.Id,
                                    Name = prod.Name,
                                    Quantity = prod.Quantity
                                }
                           );
            }
        }
    }
}