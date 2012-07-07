﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaffleTalk.Data.Entities.Membership
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string UniqueName { get; set; }
        public string DisplayName { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
    }
}
