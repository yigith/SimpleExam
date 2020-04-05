using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleExam.Models
{
    public class AppUser : IdentityUser
    {

        public List<StudentGroup> Groups { get; set; }
    }
}
