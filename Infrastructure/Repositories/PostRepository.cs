using System;
using Application;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Contracts_Interfaces;
using Domian;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class PostRepository : AsyncRepository<Post>, IPostRepository
    {

        private readonly ApplicationDbContext _context;

        public PostRepository(ApplicationDbContext context):base(context) 
        {
            _context = context;
        }


        public async Task<List<Post>> GetAllPostsAsync(bool IncludeCategory)
        {
           List<Post> posts = new List<Post>();
            posts = IncludeCategory? await _context.Posts.Include(x =>x.Category).ToListAsync() :
                await _context.Posts.ToListAsync();

            return posts;
        }   

        public async Task<Post> GetByIdAsync(string id, bool IncludeCategory)
        {
            Post post = new Post();
            post = IncludeCategory ? await _context.Posts.Include(x => x.Category).FirstOrDefaultAsync(x => x.Id == id) :
               await GetByIdAsync(id);

            return post;
        }
    }
}
