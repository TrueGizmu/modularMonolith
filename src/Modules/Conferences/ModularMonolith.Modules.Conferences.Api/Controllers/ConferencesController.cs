// --------------------------------------------------------------------------------
//  Copyright (c) 2012-2021 by Bystronic Laser AG, CH-3362 Niederoenz
// --------------------------------------------------------------------------------

using Microsoft.AspNetCore.Mvc;
using ModularMonolith.Modules.Conferences.Core.DTO;
using ModularMonolith.Modules.Conferences.Core.Services;

namespace ModularMonolith.Modules.Conferences.Api.Controllers;

internal class ConferencesController : BaseController
{
    private readonly IConferenceService _conferenceService;

    public ConferencesController (IConferenceService conferenceService)
    {
        _conferenceService = conferenceService;
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<ConferenceDetailsDto?>> Get(Guid id) =>
        OkOrNotFound(await _conferenceService.GetAsync(id));

    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<ConferenceDto>?>> Browse() => 
        Ok(await _conferenceService.BrowseAsync());

    [HttpPost]
    public async Task<ActionResult> Add(ConferenceDetailsDto conference)
    {
        await _conferenceService.AddAsync(conference);
        return new CreatedAtActionResult(nameof(Get), null, new { id = conference.Id }, conference);
    }

    [HttpPut("{id:guid}")]
    public async Task<ActionResult> Update(Guid id, ConferenceDetailsDto conference)
    {
        conference.Id = id;
        await _conferenceService.UpdateAsync(conference);
        return new NoContentResult();
    }
    
    [HttpDelete("{id:guid}")]
    public async Task<ActionResult> Delete(Guid id)
    {
        await _conferenceService.DeleteAsync(id);
        return new NoContentResult();
    }
}