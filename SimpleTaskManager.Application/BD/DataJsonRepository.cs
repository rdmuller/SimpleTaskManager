namespace SimpleTaskManager.Application.BD;
public class DataJsonRepository
{
    private string _JsonFilePath = string.Empty;
    protected string JsonFilePath
    {
        get
        {
            return _JsonFilePath;
        }
        set
        {
            string userPath = Path.GetTempPath();
            _JsonFilePath = userPath + value + ".json";
        }
    }

    protected void SaveJsonFile(string json)
    {
        File.WriteAllText(_JsonFilePath, json);
    }

    protected string LoadJsonFile() 
    {
        if (File.Exists(_JsonFilePath))
            return File.ReadAllText(_JsonFilePath);

        return "";
    }
}