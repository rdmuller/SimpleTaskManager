using Newtonsoft.Json;
using SimpleTaskManager.Application.BD;
using SimpleTaskManager.Application.UseCases.Task.GetAll;
using SimpleTaskManager.Communication.Request;
using SimpleTaskManager.Communication.Response;
using System.ComponentModel.Design;

namespace SimpleTaskManager.Application.UseCases.Task.Update;
public class UpdateTaskUsaCase : DataJsonRepository
{
    private const string TasksJsonFile = "Tasks";
    
    public ResponseErrors Execute(string id, RequestTask request)
    {
        var response = new ResponseErrors();
        var AllTasksUseCase = new GetAllTasksUseCase();
        var AllTasks = AllTasksUseCase.Execute();
        var NewListTasks = new ResponseAllTasks();
        bool TaskUpdated = false;

        foreach (var Task in AllTasks.ResponseTasks)
        {
            if (Task.Id.ToString() != id)
                NewListTasks.ResponseTasks.Add(Task);
            else
            {
                NewListTasks.ResponseTasks.Add(ConvertTask.ConvertRequestTaskToResponseTask(request, id));
                TaskUpdated = true;
            }
        }

        if (TaskUpdated)
        {
            JsonFilePath = TasksJsonFile;
            string json = JsonConvert.SerializeObject(NewListTasks);
            SaveJsonFile(json);
        } 
        else response.errors.Add("Tarefa não encontrada");

        return response;
    }
}
