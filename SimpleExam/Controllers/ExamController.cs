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
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Result()
        {
            return View();
        }
    }
}