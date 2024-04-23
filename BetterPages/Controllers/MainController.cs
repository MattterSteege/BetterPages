using BetterPages.utilities.attributes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BetterPages.Controllers
{
    public class MainController : Controller
    {
        string fallback = "/test";
        
        public IActionResult Index(string url = null)
        {
            if (url != null)
                HttpContext.Response.Cookies.Append("page_to_load", url);
            else if (HttpContext.Request.Cookies.ContainsKey("this_session_last_page"))
                HttpContext.Response.Cookies.Append("page_to_load", (HttpContext.Request.Cookies["this_session_last_page"] == "" ? fallback : HttpContext.Request.Cookies["this_session_last_page"]) ?? fallback);
            else
                HttpContext.Response.Cookies.Append("page_to_load", fallback);

            return View();
        }  
        
        [BetterPages]
        [Route("/test")]
        public IActionResult Test()
        {
            return PartialView();
        } 
        
        [BetterPages]
        [Route("/test2")]
        public IActionResult Test2()
        {
            return PartialView();
        } 
    }
}