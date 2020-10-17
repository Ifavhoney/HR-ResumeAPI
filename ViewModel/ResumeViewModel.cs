using ResumeAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResumeAPI.ViewModel
{
    public class ResumeViewModel
    {
        //USER INFO
        public List<UserInfoViewModel> Personal { get; set; }


       // public string Fullname { get; set; }
       // public string Address { get; set; }
       // public string Email { get; set; }
       // public string FieldOfExpertise { get; set; }


        //USER EDUCATION
        public List<EducationViewModel> Education { get; set; }
        
      //  public string School { get; set; }
      //  public string DegreeType { get; set; }
      //  public string Major { get; set; }
      //  public int? Gpa { get; set; }

        //USER EXPERIENCE 

        public List<ExperienceViewModel> Experience { get; set; }
        // public string Duties { get; set; }
        // public int? MonthsSpent { get; set; }
        // public string CurrentlyEmployed { get; set; }

        //OTHER

        public List<OtherViewModel> Other { get; set; }







    }
}
