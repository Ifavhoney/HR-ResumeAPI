using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResumeAPI.ViewModel
{
    public class UserInfoViewModel
    {
        public string Fullname { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string FieldOfExpertise { get; set; }
        public int? Fk_Info_Id { get; set; }

    }
}
