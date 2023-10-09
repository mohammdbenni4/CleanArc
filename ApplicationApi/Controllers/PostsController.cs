using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Application.Features.Posts.Qureies.GetPostsList;
using Application.Features.Posts.Qureies.GetPostDetail;
using Application.Features.Posts.Commands.CreatePost;
using Application.Features.Posts.Commands.UpdatePost;
using Application.Features.Posts.Commands.DeletePost;

namespace ApplicationApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PostsController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet("all",Name = "getAllPosts")]
        public async Task<IActionResult>GetAllPosts()
        {
            var q = new GetPostsListQuery();
            var dtos = await _mediator.Send(q);
            if (dtos == null) { return BadRequest(); }
            return Ok(dtos);
        }

        [HttpGet("{id}",Name ="GetPostById")]
        public async Task<ActionResult<GetPostDetailViewModel>> GetPostById(string id)
        {
            var getEventDetailQuery = new GetPostDetailQuery { PostId = id };
            return Ok(await _mediator.Send(getEventDetailQuery));
        }

        [HttpPost(Name ="AddPost")]
        public async Task<ActionResult<string>> Create([FromBody] CreatePostCommand model)
        {
            string id = await _mediator.Send(model);
            return Ok(id);
        }


        [HttpPut(Name = "UpdatePost")]
        public async Task<ActionResult> Update([FromBody] UpdatePostCommand model)
        {
            await _mediator.Send(model);
            return Ok();
        }

        [HttpDelete("{id}",Name ="DeletePost")]
        public async Task<ActionResult> Delete(string id)
        {
            var deleteCommand = new DeletePostCommand { PostId = id };

            await _mediator.Send(deleteCommand);
            return Ok();

        }



    }
}
