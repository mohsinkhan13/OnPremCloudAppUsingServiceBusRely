namespace ProductsPortal.Controllers
{
    using System.Linq;
    using System.ServiceModel;
    using System.Web.Mvc;
    using Microsoft.ServiceBus;
    using Models;
    using static CCHServer.EmployeeContract;
    public class HomeController : Controller
    {
        // Declare the channel factory.
        private static ChannelFactory<IEmployeeChannel> _channelFactory;

        static HomeController()
        {
            // Create shared access signature token credentials for authentication.
            _channelFactory = new ChannelFactory<IEmployeeChannel>(new NetTcpRelayBinding(),
                "sb://mktestrelay.servicebus.windows.net/central");
            _channelFactory.Endpoint.Behaviors.Add(new  TransportClientEndpointBehavior
            {
                TokenProvider = TokenProvider.CreateSharedAccessSignatureTokenProvider(
                    "RootManageSharedAccessKey", "zMSPq+sqa7tjeTKvbdcTAXT6/rNNRDkQvzPb6zNiC2A=")
            });
        }

        public ActionResult Index()
        {
            using (IEmployeeChannel channel = _channelFactory.CreateChannel())
            {
                // Return a view of the products inventory.
                var res = channel.AuthenticateUser(new EmployeeData
                {
                    Username = "mohsink13@gmail.com",
                    Password = "sdasd"
                });

                if(res != null)
                {
                    var viewModel = new EmployeeViewModel
                    {
                        Username = res.Username
                    };
                    return View(viewModel);
                }

                return View(new EmployeeViewModel());
            }
        }
    }
}