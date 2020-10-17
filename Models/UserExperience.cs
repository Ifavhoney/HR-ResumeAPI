using System;
using System.Collections.Generic;

namespace ResumeAPI.Models
{
    public partial class UserExperience
    {
        public int Id { get; set; }
        public int? Fk_Info_Id { get; set; }
        public string JobTitle { get; set; }
        public string Duties { get; set; }
        public int? MonthsSpent { get; set; }
        public string CurrentlyEmployed { get; set; }
      
    }
}
