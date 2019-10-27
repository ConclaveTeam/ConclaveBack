using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Services;
using Conclave.Models;
using Microsoft.AspNetCore.Mvc;

namespace Conclave.Controllers
{
    [Route("api/[controller]")]
    public class PostController
    {
        private readonly IPostService _postService;

        public PostController(IPostService postService)
        {
            _postService = postService;
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<PostModel> Get()
        {
            return _postService.GetAll().Select(p => new PostModel 
            {
                Id = p.Id,
                Title = p.Title,
                Text = p.Text,
                DatePosted = p.DatePosted,
                ThemeId = p.ThemeId,
                AuthorId = p.AuthorId,
            });
        }
    }
}
