using System.Web.Mvc;

namespace ManPowerSols.Areas.start
{
    public class startAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "start";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "start_default",
                "start/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}