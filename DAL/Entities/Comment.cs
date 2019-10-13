using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class Comment : Entity<int>
    {
        public string Text { get; set; }
        public Author Author { get; set; }
        public int AuthorId { get; set; }
    }
}
