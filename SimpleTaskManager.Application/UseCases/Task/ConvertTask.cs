using AutoMapper;
using SimpleTaskManager.Communication.Request;
using SimpleTaskManager.Communication.Response;

namespace SimpleTaskManager.Application.UseCases.Task;
public class ConvertTask
{
    public static ResponseTask ConvertRequestTaskToResponseTask(RequestTask request, string id = "")
    {
        MapperConfiguration config = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<RequestTask, ResponseTask>();
        });

        IMapper mapper = config.CreateMapper();

        ResponseTask Task = mapper.Map<ResponseTask>(request);

        if (!id.Equals(""))
            Task.Id = Guid.Parse(id);

        return Task;
    }
}
