﻿using System;
using System.Collections.Generic;

namespace ResumeAPI.Models
{
    public partial class UserInfo
    {
      
        public int Id { get; set; }
        public string Fullname { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string FieldOfExpertise { get; set; }

    }
}
