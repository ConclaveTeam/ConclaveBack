using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class Author : Entity<int>
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public ICollection<Post> Posts { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
}
