using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleExam.Models
{
    public class Answer
    {
        public int Id { get; set; }

        public int UserExamId { get; set; }

        public int QuestionId { get; set; }

        public int? OptionId { get; set; }


        public UserExam UserExam { get; set; }
        public Question Question { get; set; }
        public Option Option { get; set; }
    }
}
