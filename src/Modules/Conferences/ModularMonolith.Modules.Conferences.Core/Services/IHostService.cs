// --------------------------------------------------------------------------------
//  Copyright (c) 2012-2021 by Bystronic Laser AG, CH-3362 Niederoenz
// --------------------------------------------------------------------------------

using ModularMonolith.Modules.Conferences.Core.DTO;

namespace ModularMonolith.Modules.Conferences.Core.Services;

internal interface IHostService
{
    Task AddAsync(HostDetailsDto dto);
    Task<HostDetailsDto?> GetAsync(Guid id);
    Task<IReadOnlyList<HostDto>> BrowseAsync();
    Task UpdateAsync(HostDetailsDto dto);
    Task DeleteAsync(Guid id);
}