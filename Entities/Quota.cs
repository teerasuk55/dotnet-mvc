using System;
using System.Collections.Generic;

namespace sample.Entities
{
    public partial class Quota
    {
        public int QuotaId { get; set; }
        public int UserId { get; set; }
        public int QuataAmount { get; set; }
        public string QuataStatus { get; set; }

        public virtual User User { get; set; }
    }
}
