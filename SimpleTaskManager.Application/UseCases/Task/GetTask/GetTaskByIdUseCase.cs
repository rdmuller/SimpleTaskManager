using SimpleTaskManager.Application.BD;
using SimpleTaskManager.Application.UseCases.Task.GetAll;
using SimpleTaskManager.Communication.Response;

namespace SimpleTaskManager.Application.UseCases.Task.GetTask;
public class GetTaskByIdUseCase
{
    private const string TasksJsonFile = "Tasks";

    public ResponseTask? Execute(string id)
    {
        if (id == null)
            return null;

        var allTasksUseCase = new GetAllTasksUseCase();
        var allTasks = allTasksUseCase.Execute();

        try
        {
            foreach (var task in allTasks.ResponseTasks)
            {
                if (task.Id.ToString() == id)
                    return task;
            }
        }
        catch { }

        return null;

    }
}
