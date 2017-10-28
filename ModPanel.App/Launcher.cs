using Microsoft.EntityFrameworkCore;
using ModPanel.App.Data;
using SimpleMvc.Framework;
using SimpleMvc.Framework.Routers;

namespace ModPanel.App
{
    public class Launcher
    {
        static Launcher()
        {
            using (var db = new ModPanelDbContext())
            {
                db.Database.Migrate();
            }
        }

        public static void Main(string[] args)
        => MvcEngine.Run(
            new WebServer.WebServer(1337,
                new ControllerRouter(),
                new ResourceRouter()));
    }
}
