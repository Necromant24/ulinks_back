using UsefulLinksBackend.Dtos;

namespace UsefulLinksBackend.Models;

public class UsefulLink
{
    

    public UsefulLink()
    {
    }

    public UsefulLink(UsefulLinkDto dto)
    {
        Id = dto.Id;
        Heading = dto.Heading;
        Link = dto.Link;
        Description = dto.Description;

        TagList = dto.TagList.Select(name => new ULinkTag() { Name = name }).ToList();

    }
    
    
    public int Id { get; set; }
    public string Heading { get; set; }
    public string Link { get; set; }
    public string Description { get; set; }
    public List<ULinkTag> TagList { get; set; }

}