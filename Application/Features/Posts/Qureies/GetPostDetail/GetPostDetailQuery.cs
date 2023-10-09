using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Posts.Qureies.GetPostDetail
{
    public class GetPostDetailQuery : IRequest<GetPostDetailViewModel>
    {
        public string PostId { get; set; }
    }
}
