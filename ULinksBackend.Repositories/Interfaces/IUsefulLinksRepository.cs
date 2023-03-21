using ULinksBackend.Models.Dtos;
using UsefulLinksBackend.Models;

namespace ULinksBackend.Repositories.Interfaces;

public interface IUsefulLinksRepository
{
    public  Task<UsefulLink> Add(UsefulLink ulink);
    public  Task<PagedResultDto<UsefulLink>> GetPaged(PagedRequestDto requestDto);
    public Task RemoveTag(UsefulLink ulink);
}