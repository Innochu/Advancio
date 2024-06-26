﻿using Microsoft.AspNetCore.Identity;

namespace AdvansioIntLtd.Entities
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public ICollection<UserTransaction> UserTransactions { get; set; }
    }
}
