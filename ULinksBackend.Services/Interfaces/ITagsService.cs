using UsefulLinksBackend.Models;

namespace ULinksBackend.Services.Interfaces;

public interface ITagsService
{
    public  Task<Tag> AddTag(Tag tag);
    public  Task<List<Tag>> GetTags();
    public  Task RemoveTag(Tag tag);
}