using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleExam.Models
{
    public class StudentGroup
    {
        public string AppUserId { get; set; }
        public int GroupId { get; set; }

        public AppUser Student { get; set; }
        public Group Group { get; set; }
    }
}
