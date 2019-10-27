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

        public Post Post { get; set; }

        public int PostId { get; set; }

        public Comment ParentComment { get; set; }
        public int? ParentCommentId { get; set; }
        public ICollection<Comment> Comments { get; set; }

    }
}
