using ULinksBackend.Repositories.Interfaces;
using ULinksBackend.Services.Interfaces;
using UsefulLinksBackend.Models;

namespace ULinksBackend.Services;

public class TagsService : ITagsService
{
    private ITagsRepository _tagsRepository;


    public TagsService(ITagsRepository tagsRepository)
    {
        _tagsRepository = tagsRepository;
    }

    public async Task<Tag> AddTag(Tag tag)
    {
        List<Tag> allTags = await _tagsRepository.GetTags();
        List<string> tagNames = allTags.Select(x => x.Name).ToList();

        if (tagNames.Contains(tag.Name))
        {
            return null;
        }

        return await _tagsRepository.Add(tag);
    }


    public async Task<List<Tag>> GetTags()
    {
        return await _tagsRepository.GetTags();
    }


    public async Task RemoveTag(Tag tag)
    {
        await _tagsRepository.RemoveTag(tag);
    }
    
    
}