using System;
using System.Collections.Generic;

namespace sample.Entities
{
    public partial class Leavedoc
    {
        public Leavedoc()
        {
            ApproveStep = new HashSet<ApproveStep>();
            AttachFiles = new HashSet<AttachFiles>();
            UserDetail = new HashSet<UserDetail>();
        }

        public int LeaveId { get; set; }
        public string DocId { get; set; }
        public DateTime SubmitDate { get; set; }
        public DateTime UpdateFile { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime LastDate { get; set; }
        public int TotalLeaveDate { get; set; }
        public string LeaveReason { get; set; }
        public int TotalParticipants { get; set; }
        public int UserId { get; set; }
        public string PlaceName { get; set; }
        public int SubDistrictsId { get; set; }
        public int DistrictsId { get; set; }
        public int ProvincesId { get; set; }
        public int StatusId { get; set; }

        public virtual Districts Districts { get; set; }
        public virtual Provinces Provinces { get; set; }
        public virtual Masterstatus Status { get; set; }
        public virtual Subdistricts SubDistricts { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<ApproveStep> ApproveStep { get; set; }
        public virtual ICollection<AttachFiles> AttachFiles { get; set; }
        public virtual ICollection<UserDetail> UserDetail { get; set; }
    }
}
