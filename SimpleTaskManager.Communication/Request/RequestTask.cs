using SimpleTaskManager.Communication.Enum;

namespace SimpleTaskManager.Communication.Request;
public class RequestTask
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public TaskPriority Priority { get; set; }
    public Enum.TaskStatus Status { get; set; }
    public DateTime ExpireAt { get; set; }
}
