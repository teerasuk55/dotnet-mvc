using System;
using System.Collections.Generic;

namespace sample.Entities
{
    public partial class Districts
    {
        public Districts()
        {
            Leavedoc = new HashSet<Leavedoc>();
            Subdistricts = new HashSet<Subdistricts>();
        }

        public int Id { get; set; }
        public int Code { get; set; }
        public string NameInThai { get; set; }
        public string NameInEnglish { get; set; }
        public int ProvinceId { get; set; }

        public virtual Provinces Province { get; set; }
        public virtual ICollection<Leavedoc> Leavedoc { get; set; }
        public virtual ICollection<Subdistricts> Subdistricts { get; set; }
    }
}
