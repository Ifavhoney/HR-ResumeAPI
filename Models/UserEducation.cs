using System;
using System.Collections.Generic;

namespace ResumeAPI.Models
{
    public partial class UserEducation
    {
        public int Id { get; set; }
        public int? Fk_Info_Id { get; set; }
        public string School { get; set; }
        public string DegreeType { get; set; }
        public string Major { get; set; }
        public int? Gpa { get; set; }

        public UserInfo FkInfo { get; set; }
    }
}
