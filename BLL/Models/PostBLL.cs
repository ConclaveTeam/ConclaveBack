using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Models
{
    public class PostBLL
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime DatePosted { get; set; }
        public string Text { get; set; }
        public int ThemeId { get; set; }
        public int AuthorId { get; set; }
    }
}
