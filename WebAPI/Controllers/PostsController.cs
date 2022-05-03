using Contracts;
using Entities.Model;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers; 

[ApiController]
[Route("[controller]")]
public class PostsController : ControllerBase {

    private IPostService postService;

    public PostsController(IPostService postService) {
        this.postService = postService;
    }

    [HttpGet]
    public async Task<ActionResult<ICollection<Post>>> GetPosts() {
        try {
            ICollection<Post> posts = await postService.GetAllPostAsync();
            return Ok(posts);
        }
        catch (Exception e) {
            return StatusCode(500, e.Message);
        }
    }

    [HttpGet]
    [Route("id")]
    public async Task<ActionResult<Post>> GetPost([FromQuery] string postId) {
        try {
            Post post = await postService.GetPost(postId);
            return Ok(post);
        }
        catch (Exception e) {
            return StatusCode(500, e.Message);
        }
    }

    [HttpPost]
    public async Task<ActionResult<Post>> AddPost([FromBody] Post post) {

        try {
            Post added = await postService.AddPost(post);
            
            return Created("added", added);
        }
        catch (Exception e) {
            return StatusCode(500, e.Message);
        }
    }
    

}