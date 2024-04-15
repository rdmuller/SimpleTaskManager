using Newtonsoft.Json;
using SimpleTaskManager.Application.BD;
using SimpleTaskManager.Communication.Response;

namespace SimpleTaskManager.Application.UseCases.Task.GetAll;
public class GetAllTasksUseCase : DataJsonRepository
{
    private const string TasksJsonFile = "Tasks";

    public ResponseAllTasks Execute()
    {
        JsonFilePath = TasksJsonFile;

        string json = LoadJsonFile();

        ResponseAllTasks allTasks = JsonConvert.DeserializeObject<ResponseAllTasks>(json);

        if (allTasks != null)
            return allTasks;

        return new ResponseAllTasks();
    }
}
