using System;
using System.Collections.Generic;

namespace sample.Entities
{
    public partial class AttachFiles
    {
        public int AttachId { get; set; }
        public int LeaveId { get; set; }
        public int UserId { get; set; }
        public string AttachFiles1 { get; set; }
        public string ActiveStatus { get; set; }

        public virtual Leavedoc Leave { get; set; }
    }
}
