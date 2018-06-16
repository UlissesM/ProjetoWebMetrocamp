using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyPlaylist.Data;
using MyPlaylist.Models;

namespace MyPlaylist.Controllers
{
    public class HomeController : Controller
    {
        private UserManager<ApplicationUser> _userManager;
        public HomeController(UserManager<ApplicationUser> dbContext)
        {
            _userManager = dbContext;

        }
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            //var c = _dbContext.Users.Where(x => x.Id == "skadndasdn");
           return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";
            
            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
