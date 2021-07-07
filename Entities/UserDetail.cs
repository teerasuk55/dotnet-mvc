using System;
using System.Collections.Generic;

namespace sample.Entities
{
    public partial class UserDetail
    {
        public int UserDetailId { get; set; }
        public int LeaveId { get; set; }
        public string UserId { get; set; }

        public virtual Leavedoc Leave { get; set; }
    }
}
