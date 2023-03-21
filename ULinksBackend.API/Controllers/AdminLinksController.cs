using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ULinksBackend.Models.Dtos;
using ULinksBackend.Repositories.Interfaces;
using UsefulLinksBackend;
using UsefulLinksBackend.Dtos;
using UsefulLinksBackend.Models;

namespace ULinksBackend.API.Controllers;


[Route("api/admin/ulinks")]
[ApiController]
public class AdminLinksController : ControllerBase
{
    private IUsefulLinksRepository _uLinksRepository;

    public AdminLinksController(IUsefulLinksRepository uLinksRepository)
    {
        _uLinksRepository = uLinksRepository;
    }
    
    
    
    [HttpPost]
    public async Task<DataResultDto<UsefulLink>> Add([FromBody] UsefulLinkDto ulink)
    {
        foreach (var tag in ulink.TagList)
        {
            if (!Storage.AllTags.Contains(tag))
            {
                return new DataResultDto<UsefulLink>()
                {
                    Message = $"no such tag - {tag} presented in all tags, add this tag to tags",
                    Status = "error"
                };
            }
        }

        
        return new DataResultDto<UsefulLink>()
        {
            Model = await _uLinksRepository.Add(new UsefulLink(ulink))
        };
    }
    
    
    [Route("/api/ulinks")]
    [HttpPost]
    public async Task<DataResultDto<PagedResultDto<UsefulLink>>> Get([FromBody]PagedRequestDto? reqDto)
    {
        var ulinks = await _uLinksRepository.GetPaged(reqDto);
        return new DataResultDto<PagedResultDto<UsefulLink>>()
        {
            Model = ulinks
        };
    }
    
    
    [HttpDelete("{id}")]
    public async Task Remove(int id)
    {
        await _uLinksRepository.RemoveTag(new UsefulLink(){Id = id});
    }
    
    
    
    
}