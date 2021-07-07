using System;
using System.Collections.Generic;

namespace sample.Entities
{
    public partial class Department
    {
        public Department()
        {
            User = new HashSet<User>();
        }

        public int DepId { get; set; }
        public string DepName { get; set; }
        public int HeadOfDepUserId { get; set; }
        public int DeanUserId { get; set; }

        public virtual User DeanUser { get; set; }
        public virtual User HeadOfDepUser { get; set; }
        public virtual ICollection<User> User { get; set; }
    }
}
