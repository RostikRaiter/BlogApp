using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Interfaces
{
    public interface IBlogService
    {
        Task<List<Blog>> GetBlogs();
        Task<Blog> GetBlog(int? id);
        Task CreateBlog(Blog blog);
        Task EditBlog(Blog blog);
        Task DeleteBlog(int? id);
    }
}
