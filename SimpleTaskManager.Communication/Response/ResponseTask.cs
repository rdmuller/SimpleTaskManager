using SimpleTaskManager.Communication.Enum;

namespace SimpleTaskManager.Communication.Response;
public class ResponseTask
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public TaskPriority Priority { get; set; }
    public Enum.TaskStatus Status { get; set; }
    public DateTime ExpireAt { get; set; }

}
