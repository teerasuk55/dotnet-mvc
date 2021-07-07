using System;
using System.Collections.Generic;

namespace sample.Entities
{
    public partial class Provinces
    {
        public Provinces()
        {
            Districts = new HashSet<Districts>();
            Leavedoc = new HashSet<Leavedoc>();
        }

        public int Id { get; set; }
        public int Code { get; set; }
        public string NameInThai { get; set; }
        public string NameInEnglish { get; set; }

        public virtual ICollection<Districts> Districts { get; set; }
        public virtual ICollection<Leavedoc> Leavedoc { get; set; }
    }
}
