using Microsoft.AspNetCore.Identity;
using SimpleExam.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleExam.Models
{
    public class UserExam
    {
        public int Id { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }

        [ForeignKey("Exam")]
        public int ExamId { get; set; }

        public DateTime? StartTime { get; set; }

        public DateTime? EndTime { get; set; }

        public UserExamStatus Status { get; set; }


        public AppUser User { get; set; }
        public Exam Exam { get; set; }
        public List<Answer> Answers { get; set; }
    }
}
