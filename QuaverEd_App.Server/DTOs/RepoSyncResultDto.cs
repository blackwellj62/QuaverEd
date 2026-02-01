namespace QuaverEd_App.Server.DTOs;

public class RepoSyncResultDto
{
    public int TotalProcessed { get; set; }
    public int Inserted { get; set; }
    public int Updated { get; set; }
    public DateTime TimestampUtc { get; set; }
}