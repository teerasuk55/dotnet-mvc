using System;
using System.Collections.Generic;

namespace sample.Entities
{
    public partial class Masterstatus
    {
        public Masterstatus()
        {
            ApproveStep = new HashSet<ApproveStep>();
            Leavedoc = new HashSet<Leavedoc>();
        }

        public int StatusId { get; set; }
        public string StatusName { get; set; }
        public string ActiveStatus { get; set; }

        public virtual ICollection<ApproveStep> ApproveStep { get; set; }
        public virtual ICollection<Leavedoc> Leavedoc { get; set; }
    }
}
