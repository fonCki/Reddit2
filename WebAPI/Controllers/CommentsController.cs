using Contracts;
using Entities.Model;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers; 

[ApiController]
[Route("[controller]")]
public class CommentsController : ControllerBase {
    
    private IPostService postService;

    public CommentsController(IPostService postService) {
        this.postService = postService;
    }
    
    [HttpPost]
    [Route("Posts/{UID}/[controller]")]
    public async Task<ActionResult<Post>> AddComment([FromRoute] string UID, [FromBody] Comment comment) {
        Console.WriteLine(comment + "desde controller"); // TODO delete
        Console.WriteLine(UID + "desde controller"); // TODO delete
        
        try {
            Console.WriteLine("done");
            Post post = await postService.AddComment(comment);
            Console.WriteLine("Not done");
            return Ok(post);
        }
        catch (Exception e) {
            return StatusCode(500, e.Message);
        }
    }

}