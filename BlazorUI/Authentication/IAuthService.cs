using System.Security.Claims;
using Entities.Model;

namespace BlazorUI.Authentication; 

public interface IAuthService {
    public Task LoginAsync(string email, string password);
    public Task LogoutAsync();
    public Task<ClaimsPrincipal> GetAuthAsync();
    public Action<ClaimsPrincipal> OnAuthStateChanged { get; set; }
    public User MyUser { get; set; } 
    
}