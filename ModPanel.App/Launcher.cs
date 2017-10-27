using Microsoft.EntityFrameworkCore;
using ModPanel.App.Data;
using ModPanel.App.Infrastructure;
using SimpleMvc.Framework;
using SimpleMvc.Framework.Routers;

namespace ModPanel.App
{
    using WebServer;

    public class Launcher
    {
        static Launcher()
        {
            using (var db = new ModPanelDbContext())
            {
                db.Database.Migrate();
            }
        }

        public static void Main()
        => MvcEngine.Run(new WebServer(
                1337,
                DependencyControllerRouter.Get(),
                new ResourceRouter()));
    }
}
