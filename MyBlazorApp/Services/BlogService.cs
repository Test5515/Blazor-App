using System;
using System.Collections.Generic;
using System.Linq;
using MyBlazorApp.Models;

namespace MyBlazorApp.Services
{
    public class BlogService
    {
        private readonly List<BlogPost> _posts = new List<BlogPost>
        {
            new BlogPost
            {
                Id = 1,
                Title = "First Post",
                Content = "This is the first blog post.",
                Author = "Jules",
                CreatedAt = DateTime.Now.AddDays(-2)
            },
            new BlogPost
            {
                Id = 2,
                Title = "Second Post",
                Content = "Another interesting post.",
                Author = "Jules",
                CreatedAt = DateTime.Now.AddDays(-1)
            }
        };

        private static int _nextId = 3;

        public List<BlogPost> GetAllPosts()
        {
            return _posts.OrderByDescending(p => p.CreatedAt).ToList();
        }

        public BlogPost? GetPostById(int id)
        {
            return _posts.FirstOrDefault(p => p.Id == id);
        }

        public void AddPost(BlogPost post)
        {
            post.Id = _nextId++;
            post.CreatedAt = DateTime.Now;
            _posts.Add(post);
        }

        public void UpdatePost(BlogPost post)
        {
            var existingPost = _posts.FirstOrDefault(p => p.Id == post.Id);
            if (existingPost != null)
            {
                existingPost.Title = post.Title;
                existingPost.Content = post.Content;
                existingPost.Author = post.Author;
            }
        }

        public void DeletePost(int id)
        {
            var postToRemove = _posts.FirstOrDefault(p => p.Id == id);
            if (postToRemove != null)
            {
                _posts.Remove(postToRemove);
            }
        }
    }
}
