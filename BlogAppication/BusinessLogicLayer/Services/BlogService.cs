using DataAccessLayer.Models;
using DataAccessLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services
{
    public class BlogService : IBlogService
    {
        private readonly DatabaseContext _context;

        public BlogService(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<List<Blog>> GetBlogs()
        {
            return await _context.Blogs.ToListAsync();
        }

        public async Task<Blog> GetBlog(int? id)
        {
            return await _context.Blogs.FindAsync(id);
        }

        public async Task CreateBlog(Blog blog)
        {
            _context.Blogs.Add(blog);
            await _context.SaveChangesAsync();
        }

        public async Task EditBlog(Blog blog)
        {
            _context.Entry(blog).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteBlog(int? id)
        {
            var blog = await _context.Blogs.FindAsync(id);
            _context.Blogs.Remove(blog);
            await _context.SaveChangesAsync();
        }
    }
}
