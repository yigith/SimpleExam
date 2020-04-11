using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleExam.Enums
{
    public enum UserExamStatus
    {
        [Display(Name = "Not Entered")]
        NotEntered = 0,
        [Display(Name = "In The Exam")]
        InTheExam = 1,
        [Display(Name = "Completed")]
        Completed = 2
    }
}
