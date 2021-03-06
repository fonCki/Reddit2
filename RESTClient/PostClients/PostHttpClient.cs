using System.Text;
using System.Text.Json;
using Contracts;
using Entities.Model;

namespace RESTClient.PostClients; 

public class PostHttpClient : IPostService {
    public async Task<ICollection<Post>> GetAllPostAsync() {
        using HttpClient client = new();
        HttpResponseMessage response = await client.GetAsync("https://localhost:7266/Posts");
        string content = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception($"Error: {response.StatusCode}, {content}");
        }
        
        ICollection<Post> posts = JsonSerializer.Deserialize<ICollection<Post>>(content, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
        return posts;
    }

    public async Task<Post> AddPost(Post post) {

        using HttpClient client = new();

        string postToJson = JsonSerializer.Serialize(post);
        Console.WriteLine(post);
        Console.WriteLine(postToJson + "Estoy aca"); //TODO
        
        StringContent content = new(postToJson, Encoding.UTF8, "application/json");
        Console.WriteLine(post.Uid);
        
        HttpResponseMessage response = await client.PostAsync("https://localhost:7266/Posts", content);
        string responseContent = await response.Content.ReadAsStringAsync();
        
        if (!response.IsSuccessStatusCode) {
            throw new Exception($"Error: {response.StatusCode}, {responseContent}");
        }
        
        Post returned = JsonSerializer.Deserialize<Post>(responseContent, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
        
        return null;
    }

    public async Task<Post> GetPost(string UID) {
        using HttpClient client = new();
        HttpResponseMessage response = await client.GetAsync($"https://localhost:7266/Posts/id?postId={UID}");
        string content = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception($"Error: {response.StatusCode}, {content}");
        }
        
        Post post = JsonSerializer.Deserialize<Post>(content, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
        return post;
    }

    public async Task<Post> AddComment(Comment comment) {
        using HttpClient client = new();

        string postToJson = JsonSerializer.Serialize(comment);



        StringContent content = new(postToJson, Encoding.UTF8, "application/json");
        
        Console.WriteLine("From Json" + postToJson + " Desde Json"); // TODO delete

 

        HttpResponseMessage response = await client.PostAsync($"https://localhost:7266/Posts/{comment.PostUid}/Comments", content);
        string responseContent = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode) {
            throw new Exception($"Error: {response.StatusCode}, {responseContent}");
        }

        Post returned = JsonSerializer.Deserialize<Post>(responseContent, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
        
        return returned;
    }
}