using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimpleExam.Data;
using SimpleExam.Extensions;
using SimpleExam.Models;
using SimpleExam.ViewModels;

namespace SimpleExam.Controllers
{
    public class HomeController : Controller
    {
        ApplicationDbContext _context;
        UserManager<IdentityUser> _userManager;
        public HomeController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [Authorize]
        public IActionResult Index()
        {
            var userId = User.GetLoggedInUserId<string>();
            var userExamViewModels = _context.UserExams
                .Include(x => x.Exam)
                .Where(x => x.Exam.IsActive)
                .Select(x => new UserExamViewModel
                {
                    ExamId = x.ExamId,
                    ExamName = x.Exam.Name,
                    ExamTime = x.Exam.StartTime,
                    ExamDuration = x.Exam.Duration,
                    NumberOfQuestions = x.Exam.Questions.Count,
                    CorrectAnswers = x.Answers.Count(answer => answer.Option.IsCorrect),
                    Status = x.Status,
                    IsExamTime = x.Exam.StartTime == null 
                    || (x.Exam.StartTime < DateTime.Now && x.Exam.Duration == 0) 
                    || (x.Exam.StartTime < DateTime.Now && DateTime.Now < x.Exam.StartTime.Value.AddMinutes(x.Exam.Duration))
                })
                .ToList();
            var vm = new HomeIndexViewModel
            {
                UserExamViewModels = userExamViewModels
            };
            return View(vm);
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
