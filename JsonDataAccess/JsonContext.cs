using System.Text.Json;
using Application.Contracts;
using Entities.Model;

namespace JsonDataAccess; 

public class JsonContext  {
    private string forumPath = "forum.json";

    private ForumContainer? forum;
    public ForumContainer Forum
    {
        get
        {
            if (forum == null)
            {
                LoadData();
            }

            return forum!;
        }
        private set{}
    }

    public JsonContext()
    {
        if (File.Exists(forumPath))
        {
            LoadData();
        }
        else
        {
            CreateFile();
            Console.WriteLine("created");
        }
    }

    private void CreateFile()
    {
        forum = new ForumContainer();
        forum.Users.Add(new User("jorge", "Jorge123"));
        Task.FromResult(SaveChangesAsync());
    }

    private void LoadData()
    {
        string forumAsJson = File.ReadAllText(forumPath);
        forum = JsonSerializer.Deserialize<ForumContainer>(forumAsJson)!;
    }

    public async Task SaveChangesAsync()
    {
        string forumAsJson = JsonSerializer.Serialize(forum, new JsonSerializerOptions
        {
            WriteIndented = true,
            PropertyNameCaseInsensitive = false
        });
        await File.WriteAllTextAsync(forumPath,forumAsJson);
        forum = null;
    }
    
    
}