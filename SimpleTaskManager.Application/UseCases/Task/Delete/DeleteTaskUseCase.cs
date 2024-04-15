using Newtonsoft.Json;
using SimpleTaskManager.Application.BD;
using SimpleTaskManager.Application.UseCases.Task.GetAll;
using SimpleTaskManager.Communication.Response;

namespace SimpleTaskManager.Application.UseCases.Task.Delete;
public class DeleteTaskUseCase : DataJsonRepository
{
    private const string TasksJsonFile = "Tasks";

    public ResponseErrors? Execute(string id)
    {
        var response = new ResponseErrors();
        var AllTasks = new GetAllTasksUseCase().Execute();
        var newTaskList = new ResponseAllTasks();
        bool taskDeleted = false;

        foreach (var task in AllTasks.ResponseTasks)
        {
            if (task.Id.ToString() != id)
                newTaskList.ResponseTasks.Add(task);
            else taskDeleted = true;
        }

        if (taskDeleted)
        {
            JsonFilePath = TasksJsonFile;
            string json = JsonConvert.SerializeObject(newTaskList);
            SaveJsonFile(json);
        }
        else response.errors.Add("Tarefa não encontrada");

        return response;
    }
}
