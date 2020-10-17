using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResumeAPI.ViewModel
{
    public class EducationViewModel
    {
        public string School { get; set; }
        public string DegreeType { get; set; }
        public string Major { get; set; }
        public int? Gpa { get; set; }
        public int? Fk_Info_Id { get; set; }

    }
}
