namespace ULinksBackend.Models.Dtos;

public class PagedResultDto<T> where T : class 
{
    public List<T> Items { get; set; }
    public int AllCount { get; set; }
    
}