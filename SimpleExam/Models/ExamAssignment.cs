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

        public string StudentGroupId { get; set; }


        public Exam Exam { get; set; }
        public StudentGroup StudentGroup { get; set; }
        public ExamAssignmentSetting ExamAssignmentSetting { get; set; }
    }
}
