using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class Post : Entity<int>
    {
        public string Title { get; set; }
        public DateTime DatePosted { get; set; }
        public string Text { get; set; }
        public Author Author { get; set; }
        public int AuthorId { get; set; }

    }
}
