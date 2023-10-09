using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Posts.Qureies.GetPostsList
{
    public class GetPostsListQuery : IRequest<List<GetPostsListViewModel>>
    {

    }
}
