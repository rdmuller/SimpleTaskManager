using System.Text.Json.Serialization;

namespace SimpleTaskManager.Communication.Response;
public class ResponseErrors
{
    public List<string> errors { get; set; } = [];
}
