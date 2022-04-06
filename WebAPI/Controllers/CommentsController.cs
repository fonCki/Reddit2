using Contracts;
using Entities.Model;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers; 

[ApiController]
public class CommentsController : ControllerBase {
    
    private IPostService postService;

    public CommentsController(IPostService postService) {
        this.postService = postService;
    }
    
    [HttpPost]
    [Route("Posts/{UID}/[controller]")]
    public async Task<ActionResult<Post>> AddComment([FromRoute] string UID, [FromBody] Comment comment) {
        try {
            Post post = await postService.AddComment(UID, comment);
            return Ok(post);
        }
        catch (Exception e) {
            return StatusCode(500, e.Message);
        }
    }

}