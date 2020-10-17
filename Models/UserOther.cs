using System;
using System.Collections.Generic;

namespace ResumeAPI.Models
{
    public partial class UserOther
    {
        public int Id { get; set; }
        public int? Fk_Info_Id { get; set; }
        public string Skills { get; set; }
        public string Bilingual { get; set; }
        public string Certification { get; set; }

    }
}
