using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleExam.Models
{
    public class ExamAssignmentSetting
    {
        public int Id { get; set; }

        public int ExamAssignmentId { get; set; }

        // in minutes, 0: unlimited (default)
        // if not 0 and the exam has a StartTime, the user must end exam in this duration after the StartTime
        // if not 0 and the exam does not have a StartTime, the user must end exam in this duration after he started the exam.
        public int Duration { get; set; }

        // if null, the user can start the exam anytime after the ActiveTime
        // if not null, the user can start the exam after the StartTime within the Duration (minutes)
        // if not null and the duration is 0, the user can start the exam after StartTime and finish any time.
        public DateTime? StartTime { get; set; }

        // if null, the exam will be always listed
        // if not null, the exam will start being listed after the ListingStartTime
        public DateTime? ListingStartTime { get; set; }

        // if not null, the exam can not be taken until the ActiveTime
        public DateTime? ActiveStartTime { get; set; }

        // if true, exam can not be taken
        public bool IsSuspended { get; set; }

        // if true, the user can retake the exam
        // retaking won't delete previous scores and answers. 
        // the user will be able to see his scores for each taking.
        public bool IsRetakeable { get; set; }

        // if false, the exam will end when the time is StartTime + Duration
        // if true, the student will be given as the exact amount of time as Duration if s/he starts the exam between the StartTime and EndTime
        public bool ExtraTimeAllowed { get; set; }


        public ExamAssignment ExamAssignment { get; set; }
    }
}
