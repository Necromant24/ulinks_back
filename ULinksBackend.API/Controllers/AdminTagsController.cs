using Microsoft.AspNetCore.Mvc;
using ULinksBackend.Repositories.Interfaces;
using ULinksBackend.Services.Interfaces;
using UsefulLinksBackend;
using UsefulLinksBackend.Dtos;
using UsefulLinksBackend.Models;

namespace ULinksBackend.API.Controllers;


[Route("api/admin/tags")]
[ApiController]
public class AdminTagsController : ControllerBase
{

    private ITagsService _tagsService;


    public AdminTagsController(ITagsService tagsService)
    {
        _tagsService = tagsService;
    }

    [HttpPost]
    public async Task<DataResultDto<Tag>> Add([FromBody] Tag tag)
    {
        var model = await _tagsService.AddTag(tag);

        if (model != null)
        {
            return new DataResultDto<Tag>()
            {
                Model = model,
                Status = "ok"
            };
        }
        else
        {
            return new DataResultDto<Tag>()
            {
                Model = model,
                Status = "already contains this tag?"
            };
        }
        
        
    }
    
    
    [Route("/api/tags")]
    [HttpGet]
    public async Task<DataResultDto<List<Tag>>> Get()
    {
        return new DataResultDto<List<Tag>>()
        {
            Model = await _tagsService.GetTags()
        };
    }
    
    
    [HttpDelete]
    public async Task Remove([FromBody]Tag tag)
    {
        await _tagsService.RemoveTag(tag);
    }
    
    
    
    
}