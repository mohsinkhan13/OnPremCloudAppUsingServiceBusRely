using System.ServiceModel;
using System.Web.Mvc;
using static CCHServer.EmployeeContract;

namespace ClientPortal.Controllers
{
    
    public class HomeController : Controller
    {
        

        static HomeController()
        {
            // Create shared access signature token credentials for authentication.
            //_channelFactory = new ChannelFactory<IEmployeeChannel>(new NetTcpRelayBinding(),
            //    "sb://mktestrelay.servicebus.windows.net/products");
            //_channelFactory.Endpoint.Behaviors.Add(new TransportClientEndpointBehavior
            //{
            //    TokenProvider = TokenProvider.CreateSharedAccessSignatureTokenProvider(
            //        "RootManageSharedAccessKey", "zMSPq+sqa7tjeTKvbdcTAXT6/rNNRDkQvzPb6zNiC2A=")
            //});
        }

        public ActionResult Index()
        {
            //using (IEmployeeChannel channel = _channelFactory.CreateChannel())
            //{
            //    // Return a view of the products inventory.
            //    return View(from prod in channel.AuthenticateUser(new EmployeeData())
            //                select new EmployeeViewModel
            //                {
            //                    UserId = prod.Id,
            //                    Username = prod.Name,
            //                }
            //               );
            //}
            return View();
        }
    }
}