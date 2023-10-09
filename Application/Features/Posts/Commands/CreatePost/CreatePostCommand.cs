using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Posts.Commands.CreatePost
{
    public class CreatePostCommand : IRequest<string>
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string CategoryId { get; set; }
    }
}
