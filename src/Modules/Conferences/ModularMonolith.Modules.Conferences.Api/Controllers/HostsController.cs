// --------------------------------------------------------------------------------
//  Copyright (c) 2012-2021 by Bystronic Laser AG, CH-3362 Niederoenz
// --------------------------------------------------------------------------------

using Microsoft.AspNetCore.Mvc;
using ModularMonolith.Modules.Conferences.Core.DTO;
using ModularMonolith.Modules.Conferences.Core.Services;

namespace ModularMonolith.Modules.Conferences.Api.Controllers;

[Route(BasePath + "/[controller]")]
internal class HostsController : BaseController
{
    private readonly IHostService _hostService;

    public HostsController (IHostService hostService)
    {
        _hostService = hostService;
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<HostDetailsDto?>> Get(Guid id)
    {
        return OkOrNotFound(await _hostService.GetAsync(id));
    }

    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<HostDto>?>> Browse()
    {
        return Ok(await _hostService.BrowseAsync());
    }

    [HttpPost]
    public async Task<ActionResult> Add(HostDetailsDto host)
    {
        await _hostService.AddAsync(host);
        return new CreatedAtActionResult(nameof(Get), nameof(HostsController), new { id = host.Id }, null);
    }

    [HttpPut("{id:guid}")]
    public async Task<ActionResult> Update(Guid id, HostDetailsDto host)
    {
        host.Id = id;
        await _hostService.UpdateAsync(host);
        return new NoContentResult();
    }
    
    [HttpDelete("{id:guid}")]
    public async Task<ActionResult> Delete(Guid id)
    {
        await _hostService.DeleteAsync(id);
        return new NoContentResult();
    }
}