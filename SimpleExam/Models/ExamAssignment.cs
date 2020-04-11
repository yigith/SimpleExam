using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleExam.Models
{
    public class ExamAssignment
    {
        public int Id { get; set; }

        public int ExamId { get; set; }

        public int GroupId { get; set; }


        public Exam Exam { get; set; }
        public Group Group { get; set; }
        public ExamAssignmentSetting ExamAssignmentSetting { get; set; }
    }
}
