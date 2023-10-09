using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Posts.Commands.CreatePost
{
    public class CreateCommandValdator : AbstractValidator<CreatePostCommand>
    {
        public CreateCommandValdator()
        {
            RuleFor(p => p.Title)
                .NotEmpty()
                .NotNull()
                .MaximumLength(100);

            RuleFor(p => p .Content)
                .NotEmpty()
                .NotNull();
        }
    }
}
