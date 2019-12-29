using SimpleExam.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleExam.ViewModels
{
    public class UserExamViewModel
    {
        public int ExamId { get; set; }

        public string ExamName { get; set; }

        public DateTime? ExamTime { get; set; }

        public int ExamDuration { get; set; }

        public int NumberOfQuestions { get; set; }

        public int CorrectAnswers { get; set; }

        public UserExamStatus Status { get; set; }

        public bool IsExamTime { get; set; }
    }
}
