using Microsoft.AspNetCore.Mvc;
using ScrollServices.Interface;
using ScrollServices.Models;
using System.Diagnostics;
using System.Reflection.Metadata.Ecma335;

namespace ScrollServices.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IScrolling _scrolling;
        public HomeController(ILogger<HomeController> logger, IScrolling scrolling)
        {
            _logger = logger;
            _scrolling = scrolling;
        }

        public IActionResult Index()
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(int start, int count,string Forward, string Reverse)
        {
           
            if (Forward ==  ">>")
            {
                var ints = await _scrolling.GetInts(start, count,Forward);
                var msg = await _scrolling.Message();
                ViewBag.Message = msg;
                ViewBag.Count = ints[0];
                return await Task.FromResult(View());
            }
            if (Reverse == "<<")
            {
                var ints = await _scrolling.GetInts(start, count,Reverse);
                var msg = await _scrolling.Message();
                ViewBag.Message = msg;
                ViewBag.Count = ints[0];
                return await Task.FromResult(View());
            }
            //var ints = await _scrolling.GetInts(start, count);
            //ViewBag .Count = ints[0];
            return await Task.FromResult( View());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
