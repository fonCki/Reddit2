using System.Text.Json;
using Entities.Model;

namespace JsonDataAccess.Context;

public class JsonContext {
    private ForumContainer? forum;
    private readonly string forumPath = "forum.json";

    public JsonContext() {
        if (File.Exists(forumPath))
            LoadData();
        else
            CreateFile();
    }

    public ForumContainer Forum {
        get {
            if (forum == null) LoadData();

            return forum!;
        }
        private set { }
    }

    private void CreateFile() {
        forum = new ForumContainer();
        Task.FromResult(SaveChangesAsync());
    }

    private void LoadData() {
        var forumAsJson = File.ReadAllText(forumPath);
        forum = JsonSerializer.Deserialize<ForumContainer>(forumAsJson)!;
    }

    public async Task SaveChangesAsync() {
        var forumAsJson = JsonSerializer.Serialize(forum, new JsonSerializerOptions {
            WriteIndented = true,
            PropertyNameCaseInsensitive = false
        });
        await File.WriteAllTextAsync(forumPath, forumAsJson);
        forum = null;
    }
}