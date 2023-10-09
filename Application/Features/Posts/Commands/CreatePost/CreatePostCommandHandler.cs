using Application.Contracts_Interfaces;
using AutoMapper;
using Domian;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Posts.Commands.CreatePost
{
    internal class CreatePostCommandHandler : IRequestHandler<CreatePostCommand , string>
    {
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;

        public CreatePostCommandHandler(IPostRepository postRepository, IMapper mapper)
        {
            _mapper = mapper;
            _postRepository = postRepository;
        }

        public async Task<string> Handle(CreatePostCommand request, CancellationToken cancellationToken)
        {
            

            Post post = new Post { 
                Id = Guid.NewGuid().ToString(),
                Title =request.Title,
                Content = request.Content,
                CategoryId = request.CategoryId
            };

            var validator = new CreateCommandValdator();
            var ruselt = await validator.ValidateAsync(request);

            if (ruselt.Errors.Any()) 
            {
                throw new Exception("Post is not valid");
            }

            post = await _postRepository.AddAsync(post);

            return post.Id;
        }
    }
}
