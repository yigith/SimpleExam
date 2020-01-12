using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimpleExam.Data;
using SimpleExam.Enums;
using SimpleExam.Extensions;

namespace SimpleExam.Controllers
{
    [Authorize]
    public class ExamController : Controller
    {
        ApplicationDbContext _context;
        public ExamController(ApplicationDbContext context)
        {
            _context = context;
        }

        // id: ExamId
        public IActionResult Index(int id, int question = 1)
        {
            // todo: view exam question
            // return home index if not enrolled or not started or late  or completed

            // show the specified question with choices
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Start(int examId)
        {
            var now = DateTime.Now;

            var userId = User.GetLoggedInUserId<string>();
            var userExam = _context.UserExams
                .Include(x => x.Exam)
                .FirstOrDefault(x => x.ExamId == examId && x.UserId == userId);

            var exam = userExam.Exam;

            if (userExam == null)
            {
                return NotFound();
            }

            // Exam already started?
            if (userExam.Status != UserExamStatus.NotEntered)
            {
                return RedirectToAction("Index");
            }

            // Is Exam NOT startable?
            if (!exam.IsActive 
                || exam.ActiveTime.HasValue && now < exam.ActiveTime 
                || exam.StartTime.HasValue && now < exam.StartTime
                || exam.StartTime.HasValue && !exam.IsStartTimeFlexible && exam.Duration > 0 && now > exam.StartTime.Value.AddMinutes(exam.Duration)
                )
            {
                return RedirectToAction("Index");
            }

            // Start The Exam
            userExam.Status = UserExamStatus.InTheExam;
            userExam.StartTime = now;
            if (exam.Duration == 0)
            {
                userExam.EndTime = null;
            }
            else if(exam.IsStartTimeFlexible || exam.ExtraTimeAllowed)
            {
                userExam.EndTime = now.AddMinutes(exam.Duration);
            }
            else
            {
                userExam.EndTime = exam.StartTime.Value.AddMinutes(exam.Duration);
            }

            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Result()
        {
            return View();
        }
    }
}