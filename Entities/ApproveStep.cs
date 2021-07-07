using System;
using System.Collections.Generic;

namespace sample.Entities
{
    public partial class ApproveStep
    {
        public int ApproveStepId { get; set; }
        public int UserId { get; set; }
        public int MasterStatusId { get; set; }
        public int LeaveId { get; set; }
        public DateTime SubmitDate { get; set; }

        public virtual Leavedoc Leave { get; set; }
        public virtual Masterstatus MasterStatus { get; set; }
    }
}
