using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleExam.Models
{
    public class Question
    {
        public int Id { get; set; }

        public int ExamId { get; set; }

        public string Text { get; set; }

        public int SortOrder { get; set; }


        public Exam Exam { get; set; }
        public List<Option> Options { get; set; }
        public List<Answer> Answers { get; set; }

    }
}
