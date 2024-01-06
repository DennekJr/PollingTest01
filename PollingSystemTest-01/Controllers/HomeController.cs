﻿using System;
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
using Microsoft.AspNetCore.Authentication.OAuth;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

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

        [HttpPost]
        public async Task<ActionResult> Index(int QId)
        {
            var questions = from s in db.Questions.Include(q => q.PollOptions).Include(v => v.Votes).Include(u => u.User)
                            select s;
            if (User.Identity.Name != null)
            {
                string userMail = User.Identity.Name;
                ApplicationUser user = await _userManager.FindByEmailAsync(userMail);
                PollQuestion questionToDelete = db.Questions.First(q => q.Id == QId);
                var votes = db.Votes.Include(x => x.PollOption).Include(q => q.PollQuestion);
                var options = db.Options.Include(q => q.PollQuestionToAnswer);
                foreach (var vote in votes)
                {
                    if (vote.PollOption.Id == questionToDelete.Id)
                    {
                        db.Votes.Remove(vote);
                    }
                }
                foreach (var option in options)
                {
                    if (option.PollQuestionId == questionToDelete.Id)
                    {
                        db.Options.Remove(option);

                    }
                }
                db.Questions.Remove(questionToDelete);

                ViewBag.CurrentUSer = user;
                ViewBag.role = await _userManager.GetRolesAsync(user);
            }

            db.SaveChanges();

            return View(questions.ToList());
        }

        [Authorize(Roles = "Admin")]
        public IActionResult CreateRole()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateRole(string newRoleName)
        {
            await _roleManager.CreateAsync(new IdentityRole(newRoleName));


            string currentUser = User.Identity.Name;
            ApplicationUser user = await _userManager.FindByNameAsync(currentUser);
            if (await _roleManager.RoleExistsAsync(newRoleName))
            {
                if (!await _userManager.IsInRoleAsync(user, newRoleName))
                {
                    await _userManager.AddToRoleAsync(user, newRoleName);
                    user.Role = newRoleName;
                    db.SaveChanges();
                }

            }


            db.SaveChanges();
            return View();
        }

        [Authorize]
        public IActionResult CreateQuestion()
        {
            var users = new List<string>();
            foreach (var user in db.Users)
            {
                users.Add(user.Email);
            }

            var usersList = new SelectList(users, "Email", "Email");
            ViewBag.users = db.Users;
            return View();
        }

        [HttpPost]
        public IActionResult CreateQuestion(string title, string question, string option1, string option2, string? option3, string? option4, string[] users)
        {
            string UserMail = User.Identity.Name;
            try
            {
                ApplicationUser user = db.Users.First(u => u.Email == UserMail);


                if (user != null)
                {
                    PollQuestion newQuestion = new PollQuestion { Description = question, Name = title, User = user };
                    PollOption Option1 = new PollOption { PollQuestionToAnswer = newQuestion, Description = option1, User = user };
                    PollOption Option2 = new PollOption { PollQuestionToAnswer = newQuestion, Description = option2, User = user };
                    PollOption Option3 = new PollOption { PollQuestionToAnswer = newQuestion, Description = option3, User = user };
                    PollOption Option4 = new PollOption { PollQuestionToAnswer = newQuestion, Description = option4, User = user };
                    newQuestion.PollOptions.Add(Option1);
                    newQuestion.PollOptions.Add(Option2);
                    newQuestion.PollOptions.Add(Option3);
                    newQuestion.PollOptions.Add(Option4);
                    foreach(var userEmail in users)
                    {
                        UsersSelected userSelected = new UsersSelected { UserEmail = userEmail, PollQuestionId = newQuestion.Id };
                        newQuestion.UsersSelected.Add(userSelected);
                        db.UsersSelected.Add(userSelected);
                        user.UsersSelected.Add(userSelected);
                        Console.WriteLine("Email");
                        Console.WriteLine(userEmail);
                    }
                    db.Questions.Add(newQuestion);
                    db.Options.Add(Option1);
                    db.Options.Add(Option2);
                    db.Options.Add(Option3);
                    db.Options.Add(Option4);
                    user.Questions.Add(newQuestion);
                    user.Options.Add(Option1);
                    user.Options.Add(Option2);
                    user.Options.Add(Option3);
                    user.Options.Add(Option4);
                    db.SaveChanges();
                }

            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
            ViewBag.userMail = UserMail;
            ViewBag.users = db.Users;
            return RedirectToAction("Index");
        }

        public IActionResult QuestionsDetail(int qId)
        {

            PollQuestion questionToDetail = db.Questions.Include(x => x.PollOptions).ThenInclude(v => v.Votes).First(x => x.Id == qId);
            string userMail = User.Identity.Name;
            ApplicationUser user = db.Users.First(u => u.UserName == userMail);
            ViewBag.userId = user.Id;

            ViewBag.question = questionToDetail;
            return View(questionToDetail);
        }

        [HttpPost]
        public IActionResult QuestionsDetail(int qId, int? CAId)
        {

            PollQuestion questionToDetail = db.Questions.Include(x => x.PollOptions).ThenInclude(v => v.Votes).First(x => x.Id == qId);
            string userMail = User.Identity.Name;
            ApplicationUser user = db.Users.First(u => u.UserName == userMail);
            ViewBag.userId = user.Id;
            //var Questions = db.Questions.Include(x => x.Tags).Where(x => x.Tags.Contains((Tag)tag));
            try
            {
                PollOption option = db.Options.Include(q => q.PollQuestionToAnswer).First(x => x.Id == CAId);
                var isVoted = user.Votes.First(x => x.PollOptionId == option.Id);
                if (isVoted != null)
                {
                    questionToDetail.disPlayPercentage = true;
                    db.SaveChanges();
                    return View(questionToDetail);
                }
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
            ViewBag.question = questionToDetail;
            return View();
        }

        public IActionResult VoteOption(int? VOId)
        {
            string UserMail = User.Identity.Name;
            ApplicationUser user = db.Users.First(u => u.Email == UserMail);
            // List<Journal> journalsForUser = db.Journals.Where(u->u.Name == email).ToList();
            if (VOId != null)
            {

                PollOption option = db.Options.First(x => x.Id == VOId);
                PollQuestion questionVotedOn = db.Questions.First(x => x.Id == option.PollQuestionId);
                if (VOId.HasValue)
                {
                    Vote newVote = new Vote { Decision = true, User = user, PollOption = option, PollOptionId = option.Id };
                    option.Votes.Add(newVote);
                    questionVotedOn.Votes.Add(newVote);
                    questionVotedOn.VoteCount++;
                    db.Votes.Add(newVote);
                    user.Votes.Add(newVote);
                }
                ViewBag.votedOption = option;
            }
            db.SaveChanges();
            return RedirectToAction("Index");
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

