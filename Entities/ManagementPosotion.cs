using System;
using System.Collections.Generic;

namespace sample.Entities
{
    public partial class ManagementPosotion
    {
        public ManagementPosotion()
        {
            User = new HashSet<User>();
        }

        public int ManagementPositionId { get; set; }
        public string ManagementName { get; set; }
        public string ActiveStatus { get; set; }

        public virtual ICollection<User> User { get; set; }
    }
}
