using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Conclave.Models
{
    public class PostModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime DatePosted { get; set; }
        public string Text { get; set; }
        public int ThemeId { get; set; }
        public int AuthorId { get; set; }
    }
}
