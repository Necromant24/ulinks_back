using UsefulLinksBackend.Models;

namespace ULinksBackend.Repositories.Interfaces;

public interface ITagsRepository
{
    public  Task<Tag> Add(Tag tag);
    public Task<List<Tag>> GetTags();
    public  Task RemoveTag(Tag tag);
}