using Domian;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts_Interfaces
{
    public interface IPostRepository : IAsyncRepository<Post>
    {
        Task<List<Post>> GetAllPostsAsync(bool IncludeCategory);
        Task<Post> GetByIdAsync(string id, bool IncludeCategory);
    }
}
