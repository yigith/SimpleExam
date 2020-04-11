using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleExam.Models
{
    public class Group
    {
        public int Id { get; set; }

        public string GroupName { get; set; }


        public List<StudentGroup> StudentGroups { get; set; }
        public List<ExamAssignment> ExamAssignments { get; set; }
    }
}
