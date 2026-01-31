using System.Text.Json.Serialization;

namespace QuaverEd_App.Server.DTOs;

public class GitHubSearchResponseDto
{
    [JsonPropertyName("items")]
    public List<GitHubRepoDto> Items { get; set; } = new();
}

public class GitHubRepoDto
{
    [JsonPropertyName("id")]
    public long Id { get; set; }
    [JsonPropertyName("name")]
    public string? Name { get; set; }
    [JsonPropertyName("html_url")]
    public string? HtmlUrl { get; set; }
    [JsonPropertyName("created_at")]
    public DateTime? CreatedAt { get; set; }
    [JsonPropertyName("pushed_at")]
    public  DateTime? PushedAt { get; set;}
    [JsonPropertyName("description")]
    public string? Description { get; set;}
    [JsonPropertyName("stargazers_count")]
    public int StargazersCount { get; set; }
    [JsonPropertyName("owner")]
    public GithubOwnerDto? Owner    { get; set; }
}

public class GithubOwnerDto
{
    [JsonPropertyName("login")]
    public string? Login { get; set; }
}