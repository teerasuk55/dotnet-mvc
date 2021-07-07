using System;
using System.Collections.Generic;

namespace sample.Entities
{
    public partial class User
    {
        public User()
        {
            DepartmentDeanUser = new HashSet<Department>();
            DepartmentHeadOfDepUser = new HashSet<Department>();
            Leavedoc = new HashSet<Leavedoc>();
            Quota = new HashSet<Quota>();
        }

        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int AcademicPositionId { get; set; }
        public int? ManagementPositionId { get; set; }
        public byte[] Signature { get; set; }
        public string UserStatus { get; set; }
        public int DepId { get; set; }

        public virtual AcademicPosition AcademicPosition { get; set; }
        public virtual Department Dep { get; set; }
        public virtual ManagementPosotion ManagementPosition { get; set; }
        public virtual ICollection<Department> DepartmentDeanUser { get; set; }
        public virtual ICollection<Department> DepartmentHeadOfDepUser { get; set; }
        public virtual ICollection<Leavedoc> Leavedoc { get; set; }
        public virtual ICollection<Quota> Quota { get; set; }
    }
}
