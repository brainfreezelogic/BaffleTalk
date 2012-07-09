using System;

namespace BaffleTalk.Data.Entities.Membership
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string UniqueName { get; set; }
        public string DisplayName { get; set; }
        public DateTime BirthDate { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
    }
}