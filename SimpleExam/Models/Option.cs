using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleExam.Models
{
    public class Option
    {
        public int Id { get; set; }

        public int QuestionId { get; set; }

        public string Text { get; set; }

        public bool IsCorrect { get; set; }

        public int SortOrder { get; set; }


        public Question Question { get; set; }
        public List<Answer> Answers { get; set; }
    }
}
