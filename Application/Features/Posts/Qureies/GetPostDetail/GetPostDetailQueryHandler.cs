using Application.Contracts_Interfaces;
using Application.Features.Posts.Qureies.GetPostsList;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Posts.Qureies.GetPostDetail
{
    public class GetPostDetailQueryHandler : IRequestHandler<GetPostDetailQuery,GetPostDetailViewModel>
    {
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;

        public GetPostDetailQueryHandler(IPostRepository postRepository, IMapper mapper)
        {
            _mapper = mapper;
            _postRepository = postRepository;
        }

        public async Task<GetPostDetailViewModel> Handle(GetPostDetailQuery request, CancellationToken cancellationToken)
        {
            var post = await _postRepository.GetByIdAsync(request.PostId, true);

            var cat = new CategoryDto
            { 
                Id = post.Category.Id,
                Name = post.Category.Name,
            };

            GetPostDetailViewModel mypost = new GetPostDetailViewModel
            {
               Id= post.Id,
               Title = post.Title,
               Content = post.Content,
               Category = cat
            };

            return mypost;
        }
    }
}
