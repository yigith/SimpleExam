using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleExam.Models
{
    public class Exam
    {
        public int Id { get; set; }

        [Required, StringLength(100)]
        public string Name { get; set; }




        public List<UserExam> UserExams { get; set; }
        public List<Question> Questions { get; set; }
    }
}
