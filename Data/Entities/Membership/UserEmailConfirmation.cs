using System;

namespace BaffleTalk.Data.Entities.Membership
{
    public class UserEmailConfirmation
    {
        public Guid Id { get; set; }
        public int UserId { get; set; }
        public string Email { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateConfirmed { get; set; }

        public User User { get; set; }
    }
}