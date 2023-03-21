using ULinksBackend.Repositories.Interfaces;
using UsefulLinksBackend;
using UsefulLinksBackend.Database;
using UsefulLinksBackend.Models;

namespace ULinksBackend.Repositories.Repositories;

public class TagsRepository : ITagsRepository
{

    private AppDbContext _dbContext;


    public TagsRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }



    public async Task<Tag> Add(Tag tag)
    {
        tag.Name = tag.Name.Trim();
        
        var entity = await _dbContext.Tags.AddAsync(tag);
        await _dbContext.SaveChangesAsync();
        
        Storage.AllTags.Add(tag.Name);

        return entity.Entity;
    }


    public async Task<List<Tag>> GetTags()
    {
        return _dbContext.Tags.ToList();
    }

    public async Task RemoveTag(Tag tag)
    {
        _dbContext.Tags.Remove(tag);
        await _dbContext.SaveChangesAsync();
    }




}