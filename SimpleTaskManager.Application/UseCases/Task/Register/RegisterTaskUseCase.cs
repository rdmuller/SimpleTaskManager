using Newtonsoft.Json;
using SimpleTaskManager.Application.BD;
using SimpleTaskManager.Application.UseCases.Task.GetAll;
using SimpleTaskManager.Communication.Request;
using SimpleTaskManager.Communication.Response;

namespace SimpleTaskManager.Application.UseCases.Task.Register;
public class RegisterTaskUseCase : DataJsonRepository
{
    private const string TasksJsonFile = "Tasks";

    public ResponseTaskId Execute(RequestTask request)
    {
        JsonFilePath = TasksJsonFile;

        ResponseTask newTask = ConvertTask.ConvertRequestTaskToResponseTask(request);

        var GetAllTasks = new GetAllTasksUseCase();

        ResponseAllTasks allTasks = GetAllTasks.Execute();

        allTasks.ResponseTasks.Add(newTask);

        string json = JsonConvert.SerializeObject(allTasks);

        SaveJsonFile(json);
        
        return new ResponseTaskId
        {
            Id = newTask.Id.ToString(),
        };
    }
}
