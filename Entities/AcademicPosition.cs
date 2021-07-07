using System;
using System.Collections.Generic;

namespace sample.Entities
{
    public partial class AcademicPosition
    {
        public AcademicPosition()
        {
            User = new HashSet<User>();
        }

        public int AcademicPositionId { get; set; }
        public string AcademicPositionName { get; set; }
        public string ActiveStatus { get; set; }

        public virtual ICollection<User> User { get; set; }
    }
}
