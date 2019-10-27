using BLL.Exceptions;
using BLL.Models;
using DAL.EF;
using DAL.Entities;
using DAL.Repositorys;
using System.Collections.Generic;
using System.Linq;

namespace BLL.Services
{
    public interface IPostService
    {
        void CreatePost(PostBLL postBll);
        void UpdatePost(PostBLL postBll);
        void DeletePost(int id);
        PostBLL GetPost(int id);
        IEnumerable<PostBLL> GetAll();
    }
    public class PostService : IPostService
    {
        private IRepository _repository;

        public PostService(IRepository repository)
        {
            _repository = repository;
        }

        public void CreatePost(PostBLL postBll)
        {
            if (_repository.GetById<Post>(postBll.Id) != null)
                throw new ValidationException("Пост с таким заголовком уже существует", "");

            var post = new Post
            {
                Title = postBll.Title,
                Text = postBll.Text,
                DatePosted = postBll.DatePosted,
                ThemeId = postBll.ThemeId,
                AuthorId = postBll.AuthorId
            };

            _repository.Create(post);
        }
        public void UpdatePost(PostBLL postBll)
        {
            if (_repository.GetById<Post>(postBll.Id) == null)
                throw new ValidationException("Такого поста не существует", "");

            if (_repository.Get<Post>(p => p.Title == postBll.Title).Any())
                throw new ValidationException("Пост с таким заголовком уже существует", "");

            var post = new Post
            {
                Title = postBll.Title,
                Text = postBll.Text,
                DatePosted = postBll.DatePosted,
                ThemeId = postBll.ThemeId,
                AuthorId = postBll.AuthorId
            };

            _repository.Update(post);
            _repository.Save();
        }

        public void DeletePost(int id)
        {
            var post = _repository.GetById<Post>(id);

            if (post == null)
                throw new ValidationException("Такого поста не существует", "");

            _repository.Delete(post);
            _repository.Save();
        }

        public PostBLL GetPost(int id)
        {
            var post = _repository.GetById<Post>(id);

            if (post == null)
                throw new ValidationException("Такого поста не существует", "");

            var postBll = new PostBLL
            {
                Id = post.Id,
                Title = post.Title,
                DatePosted = post.DatePosted,
                Text = post.Text,
                ThemeId = post.ThemeId,
                AuthorId = post.AuthorId
            };

            return postBll;
        }

        public IEnumerable<PostBLL> GetAll()
        {
            return _repository.GetAll<Post>().Select(p => new PostBLL
            {
                Id = p.Id,
                Title = p.Title,
                Text = p.Text,
                DatePosted = p.DatePosted,
                AuthorId = p.AuthorId,
                ThemeId = p.ThemeId
            }).ToArray();
        }
    }
}
