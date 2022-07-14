using MASA.OfficialWebsite.Shared.Components;

namespace MASA.OfficialWebsite.Shared.Models;

public class Activity
{
    public string Title { get; set; }

    public string Subtitle { get; set; }

    public string Cover { get; set; }

    public DateTime StartAt { get; set; }

    /// <summary>
    /// hour
    /// </summary>
    public double Duration { get; set; }

    public ActivityType? Type { get; set; }

    public DateOnly Date => DateOnly.FromDateTime(StartAt);

    public TimeOnly StartTime => TimeOnly.FromDateTime(StartAt);

    public TimeOnly EndTime => TimeOnly.FromDateTime(StartAt).AddHours(Duration);

    public Activity(string title, string subtitle, string cover, DateTime startAt, double duration, ActivityType type)
    {
        Title = title;
        Subtitle = subtitle;
        Cover = cover;
        StartAt = startAt;
        Duration = duration;
        Type = type;
    }
}
