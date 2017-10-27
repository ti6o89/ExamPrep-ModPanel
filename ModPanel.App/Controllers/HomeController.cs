using SimpleMvc.Framework.Contracts;

namespace ModPanel.App.Controllers
{
    public class HomeController : BaseController
    {
        public IActionResult Index() => this.View();
    }
}
