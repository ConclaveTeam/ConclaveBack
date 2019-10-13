using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class Themes : Entity<int>
    {
        public string Name { get; set; }
        public ICollection<Post> Posts { get; set; }
    }
}
