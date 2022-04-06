

using BlazorUI.Authentication;
using Contracts;

using Microsoft.AspNetCore.Components.Authorization;
using Radzen;
using RESTClient.PostClients;
using RESTClient.UsersClients;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor().AddHubOptions((options => {
    options.MaximumReceiveMessageSize = 1000 * 1024 * 1024;
} ));
builder.Services.AddScoped<AuthenticationStateProvider, SimpleAuthenticationStateProvider>();
builder.Services.AddScoped<IAuthService, AuthServiceImpl>();

builder.Services.AddScoped<DialogService>();
builder.Services.AddScoped<NotificationService>();
builder.Services.AddScoped<TooltipService>();
builder.Services.AddScoped<ContextMenuService>();
builder.Services.AddScoped<IPostService, PostHttpClient>();
builder.Services.AddScoped<IUserService, UsersHttpClient>();

// builder.Services.AddAuthorization(options =>
// {
//     options.AddPolicy("MustBeVia",
//         pb =>
//             pb.RequireAuthenticatedUser().RequireClaim("Domain", "via"));
//
//     options.AddPolicy("SecurityLevel4",
//         a => 
//             a.RequireAuthenticatedUser().RequireClaim("Level", "4", "5"));
//     
//     options.AddPolicy("MustBeTeacher",
//         a => 
//             a.RequireAuthenticatedUser().RequireClaim("Role", "Teacher"));
//     
//     options.AddPolicy("SecurityLevel2",
//         a => 
//             a.RequireAuthenticatedUser().RequireAssertion(context =>
//             {
//                 Claim levelClaim = context.User.FindFirst(claim => claim.Type.Equals("Level"));
//                 if (levelClaim == null) return false;
//                 return int.Parse(levelClaim.Value) >= 2;
//             }));
// });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment()) {
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();