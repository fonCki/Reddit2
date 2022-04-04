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
    
}