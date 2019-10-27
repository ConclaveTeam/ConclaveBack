using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class Theme : Entity<int>
    {
        public string Name { get; set; }
        public ICollection<Post> Posts { get; set; }
    }
}
