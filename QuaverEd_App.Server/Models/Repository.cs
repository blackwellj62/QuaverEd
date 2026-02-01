namespace QuaverEd_App.Server.Models;

public class Repository
{
    public required long RepositoryId {get; set;}
    public required string Name {get; set;}
    public required string OwnerUsername {get; set;}
    public required string HtmlUrl {get; set;}
    public required DateTime CreatedAt {get; set;}
    public  DateTime? PushedAt {get; set;}
    public string? Description {get; set;}
    public required int StarCount {get; set;}
}