using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleExam.Models
{
    public class StudentGroup
    {
        public int Id { get; set; }

        public string GroupName { get; set; }


        public List<AppUser> Students { get; set; }
    }
}
