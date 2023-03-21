namespace UsefulLinksBackend.Models;

public class DataResultDto<T> where T : class
{
    public string Message { get; set; }
    public string Status { get; set; }
    public T Model { get; set; }
}