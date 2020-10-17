using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResumeAPI.ViewModel
{
    public class ExperienceViewModel
    {
        //USER EXPERIENCE 
        public string JobTitle { get; set; }
        public string Duties { get; set; }
        public int? MonthsSpent { get; set; }
        public string CurrentlyEmployed { get; set; }
        public int? Fk_Info_Id { get; set; }

    }
}
