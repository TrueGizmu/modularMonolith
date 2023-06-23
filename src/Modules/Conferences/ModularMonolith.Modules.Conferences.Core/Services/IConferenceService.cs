// --------------------------------------------------------------------------------
//  Copyright (c) 2012-2021 by Bystronic Laser AG, CH-3362 Niederoenz
// --------------------------------------------------------------------------------

using ModularMonolith.Modules.Conferences.Core.DTO;

namespace ModularMonolith.Modules.Conferences.Core.Services;

public interface IConferenceService
{
    Task AddAsync(ConferenceDetailsDto dto);
    Task<ConferenceDetailsDto?> GetAsync(Guid id);
    Task<IReadOnlyList<ConferenceDto>> BrowseAsync();
    Task UpdateAsync(ConferenceDetailsDto dto);
    Task DeleteAsync(Guid id);
}