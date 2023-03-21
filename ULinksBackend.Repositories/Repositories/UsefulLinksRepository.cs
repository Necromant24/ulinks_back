using Microsoft.EntityFrameworkCore;
using ULinksBackend.Models.Dtos;
using ULinksBackend.Repositories.Interfaces;
using UsefulLinksBackend;
using UsefulLinksBackend.Database;
using UsefulLinksBackend.Models;

namespace ULinksBackend.Repositories.Repositories;

public class UsefulLinksRepository : IUsefulLinksRepository
{
    
    private AppDbContext _dbContext;


    public UsefulLinksRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    
    public async Task<UsefulLink> Add(UsefulLink ulink)
    {
        var entity = await _dbContext.UsefulLinks.AddAsync(ulink);
        await _dbContext.SaveChangesAsync();

        return entity.Entity;
    }

    public async Task<PagedResultDto<UsefulLink>> GetPaged(PagedRequestDto requestDto)
    {
        if (requestDto.ItemsTake < 1)
        {
            requestDto.ItemsTake = 5;
        }

        var query = _dbContext.UsefulLinks.Select(x=>x);

        if (!string.IsNullOrEmpty(requestDto.Search))
        {
            query = query.Where(x => x.Heading.Contains(requestDto.Search));
        }

        if (requestDto.Tags != null && requestDto.Tags.Count>0)
        {
            query = query.Where(x => x.TagList.Any(x => requestDto.Tags.Contains(x.Name)));
        }

        var pagedRes = new PagedResultDto<UsefulLink>();
        
        pagedRes.AllCount = await query.CountAsync();

        query = query.Skip(requestDto.ItemsSkip);
        
        pagedRes.Items = await query.Take(requestDto.ItemsTake)
            .Include(x=>x.TagList).ToListAsync();

        

        return pagedRes;
    }


    public async Task RemoveTag(UsefulLink ulink)
    {
        _dbContext.UsefulLinks.Remove(ulink);
        await _dbContext.SaveChangesAsync();
    }
    
    
    
}