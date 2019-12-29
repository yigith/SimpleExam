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

        // in minutes, 0: unlimited
        public int Duration { get; set; }

        // if null, the exam can be taken anytime
        public DateTime? StartTime { get; set; }

        public bool IsActive { get; set; }


        public List<UserExam> UserExams { get; set; }
        public List<Question> Questions { get; set; }
    }
}
