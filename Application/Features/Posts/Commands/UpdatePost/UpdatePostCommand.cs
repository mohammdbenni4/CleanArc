using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Posts.Commands.UpdatePost
{
    public class UpdatePostCommand : IRequest<Unit>
    {
        public string Id { get; set; }
        public string Titel { get; set; }
        public string Content { get; set; }
        public string CategoryId { get; set; }
    }
}
