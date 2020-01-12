using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleExam.Models
{
    public class Exam
    {
        public int Id { get; set; }

        [Required, StringLength(100)]
        public string Name { get; set; }

        // in minutes, 0: unlimited
        // if not 0 and the exam has a StartTime, the user must end exam in this duration after the StartTime
        // if not 0 and the exam does not have a StartTime, the user must end exam in this duration after he started the exam.
        public int Duration { get; set; }

        // if not null, the user can start the exam after the StartTime within the Duration (minutes)
        // if not null and the duration is 0, the user can start the exam after StartTime and finish any time.
        public DateTime? StartTime { get; set; }

        // if not null, the exam will not be active (and not be listed) until the ActiveTime
        public DateTime? ActiveTime { get; set; }

        // the exam will be listed and can start depending on the StartTime and Duration
        public bool IsActive { get; set; }

        // if true, the user can re-start the exam and it will also reset its previous score and answers
        public bool IsRetakeable { get; set; }

        // if true, the student will be given as the exact amount of time as Duration if s/he starts the exam between the StartTime and EndTime
        public bool ExtraTimeAllowed { get; set; }

        // if true, as long as the time passed StartTime, the exam can start anytime regardless of duration.
        // but if duration is greater than 0, the exam must end within the Duration after the exam has started.
        public bool IsStartTimeFlexible { get; set; }


        public List<UserExam> UserExams { get; set; }
        public List<Question> Questions { get; set; }
    }
}
