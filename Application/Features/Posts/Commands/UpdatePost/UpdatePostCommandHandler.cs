using Application.Contracts_Interfaces;
using AutoMapper;
using Domian;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Posts.Commands.UpdatePost
{
    public class UpdatePostCommandHandler : IRequestHandler<UpdatePostCommand,Unit>
    {
        private readonly IAsyncRepository<Post> _asyncRepository;
        private readonly IMapper _mapper;

        public UpdatePostCommandHandler(IAsyncRepository<Post> asyncRepository,IMapper mapper)
        {
            _asyncRepository = asyncRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdatePostCommand request, CancellationToken cancellationToken)
        {

            var post =new Post 
            { 
                Id = request.Id,
                Title = request.Titel,
                Content = request.Content,
                CategoryId = request.CategoryId,
            };
            await _asyncRepository.UpdateAsync(post);

            return Unit.Value;
        }

       

       
      
    }
}
