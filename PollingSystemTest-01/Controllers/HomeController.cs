using System;
using System.Linq;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PollingSystemTest_01.Data;
using PollingSystemTest_01.Models;

namespace PollingSystemTest_01.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private UserManager<ApplicationUser> _userManager;
        private RoleManager<IdentityRole> _roleManager;
        public ApplicationDbContext db;


        public HomeController(ApplicationDbContext Db, ILogger<HomeController> logger, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _logger = logger;
            db = Db;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        [Authorize]
        public async Task<ActionResult> Index(string sortOrder)
        {
            ViewBag.role = null;
            if (User.Identity.Name != null)
            {
                string userMail = User.Identity.Name;
                ApplicationUser user = await _userManager.FindByEmailAsync(userMail);
                ViewBag.CurrentUSer = user;
                ViewBag.role = await _userManager.GetRolesAsync(user);
            }

            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";
            ViewBag.MostAnsweredSortParm = sortOrder == "MostA" ? "LeastA" : "";
            // var quest = db.Questions.Include(q => q.Answers).ToList();
            var questions = from s in db.Questions.Include(q => q.PollOptions).Include(v => v.Votes).Include(u => u.User)

                            select s;
            switch (sortOrder)
            {
                case "name_desc":
                    questions = questions.OrderByDescending(s => s.Name);
                    break;
                case "Date":
                    questions = questions.OrderBy(s => s.DOC);
                    break;
                case "date_desc":
                    questions = questions.OrderByDescending(s => s.DOC);
                    break;
                case "MostA":
                    questions = questions.OrderByDescending(s => s.PollOptions.Count());
                    break;
                case "LeastA":
                    questions = questions.OrderByDescending(s => s.PollOptions.Count()).Reverse();
                    break;
                default:
                    questions = questions.OrderBy(s => s.Description.Length);
                    break;
            }
            return View(questions.ToList());
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

