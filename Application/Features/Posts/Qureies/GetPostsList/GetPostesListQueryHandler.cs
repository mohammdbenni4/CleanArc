using Application.Contracts_Interfaces;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Posts.Qureies.GetPostsList
{
    public class GetPostesListQueryHandler : IRequestHandler<GetPostsListQuery , List<GetPostsListViewModel>>
    {
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;

        public GetPostesListQueryHandler(IPostRepository postRepository,IMapper mapper)
        {
            _mapper = mapper;
            _postRepository = postRepository;
        }

        async Task<List<GetPostsListViewModel>> IRequestHandler<GetPostsListQuery, List<GetPostsListViewModel>>.Handle(GetPostsListQuery request, CancellationToken cancellationToken)
        {
            var allPosts = await _postRepository.GetAllPostsAsync(true);

            List<GetPostsListViewModel> posts = allPosts.Select(x => new GetPostsListViewModel {
                Id = x.Id,
                Title = x.Title,
                

            }).ToList();


            return posts;
        }
    }
}
