namespace MASA.OfficialWebsite.Shared.Models;

public class Activity
{
    public string? Id { get; set; }

    public string Title { get; set; }

    public string Subtitle { get; set; }

    public string Cover { get; set; }

    public string Cover2 { get; set; }

    public DateTime StartAt { get; set; }

    /// <summary>
    /// hour
    /// </summary>
    public double Duration { get; set; }

    public ActivityType Type { get; set; }

    public DateOnly Date => DateOnly.FromDateTime(StartAt);

    public TimeOnly StartTime => TimeOnly.FromDateTime(StartAt);

    public TimeOnly EndTime => TimeOnly.FromDateTime(StartAt).AddHours(Duration);

    public Activity(string title, string subtitle, string cover, string cover2, DateTime startAt, double duration, ActivityType type,
        string? id = null)
    {
        Title = title;
        Subtitle = subtitle;
        Cover = cover;
        Cover2 = cover2;
        StartAt = startAt;
        Duration = duration;
        Type = type;
        Id = id;
    }
}
