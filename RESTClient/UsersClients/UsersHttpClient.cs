using System.Text;
using System.Text.Json;
using Contracts;
using Entities.Model;

namespace RESTClient.UsersClients;

public class UsersHttpClient : IUserService {
    public async Task<ICollection<User>> GetUsersAsync() {
        using HttpClient client = new();
        HttpResponseMessage response = await client.GetAsync("https://localhost:7266/User");
        string content = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode) {
            throw new Exception($"Error: {response.StatusCode}, {content}");
        }

        ICollection<User> users = JsonSerializer.Deserialize<ICollection<User>>(content, new JsonSerializerOptions {
            PropertyNameCaseInsensitive = true
        })!;
        return users;
    }

    public async Task<User> GetByUserAsyncByEmail(string email) {
        using HttpClient client = new();

      
        UriBuilder builder = new UriBuilder("https://localhost:7266/User/User"); // get the query
        builder.Query = $"email={email}";

        HttpResponseMessage response = await client.GetAsync(builder.Uri);
        string content = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode) {
            throw new Exception($"Error: {response.StatusCode}, {content}");
        }

        User user = JsonSerializer.Deserialize<User>(content, new JsonSerializerOptions {
            PropertyNameCaseInsensitive = true
        })!;
        return user;
    }

    public async Task<User> AddUserAsync(User user) {
        using HttpClient client = new();
        string userToJson = JsonSerializer.Serialize(user);
        StringContent content = new(userToJson, Encoding.UTF8, "application/json");
        HttpResponseMessage response = await client.PostAsync("https://localhost:7266/User", content);
        string responseContent = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode) {
            throw new Exception($"Error: {response.StatusCode}, {responseContent}");
        }

        User returned = JsonSerializer.Deserialize<User>(responseContent, new JsonSerializerOptions {
            PropertyNameCaseInsensitive = true
        })!;

        return returned;
    }

    public async Task DeleteUserAsync(string email) {
        throw new NotImplementedException();
    }

    public async Task<User> UpdateUserAsync(User user) {
        using HttpClient client = new();
        string userToJson = JsonSerializer.Serialize(user);
        StringContent content = new(userToJson, Encoding.UTF8, "application/json");
        HttpResponseMessage response = await client.PatchAsync("https://localhost:7266/User", content);
        string responseContent = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode) {
            throw new Exception($"Error: {response.StatusCode}, {responseContent}");
        }

        User returned = JsonSerializer.Deserialize<User>(responseContent, new JsonSerializerOptions {
            PropertyNameCaseInsensitive = true
        })!;
        return returned;
    }
}