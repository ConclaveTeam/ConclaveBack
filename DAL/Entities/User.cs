using DAL.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL.Entities
{
    public class User : Entity<int>
    {
        [Required]
        public string Login { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Salt { get; set; }
        [Required]
        public string Password { get; set; }

        public bool IsFrozenUser { get; set; }

        public Author Author { get; set; }
    }
}
