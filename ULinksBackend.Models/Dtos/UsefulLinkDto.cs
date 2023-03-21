using UsefulLinksBackend.Models;

namespace UsefulLinksBackend.Dtos;

public class UsefulLinkDto
{
    public UsefulLinkDto()
    {
    }

    public UsefulLinkDto(UsefulLink model)
    {
        Id = model.Id;
        Heading = model.Heading;
        Link = model.Link;
        Description = model.Description;
        
    }
    
    
    
    public int Id { get; set; }
    public string Heading { get; set; }
    public string Link { get; set; }
    public string Description { get; set; }
    public List<string> TagList { get; set; }
}