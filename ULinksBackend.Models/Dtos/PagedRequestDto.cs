namespace ULinksBackend.Models.Dtos;

public class PagedRequestDto
{
    
    public string Search { get; set; }
    public int ItemsTake { get; set; }
    public int ItemsSkip { get; set; }

    public List<string> Tags { get; set; }
}