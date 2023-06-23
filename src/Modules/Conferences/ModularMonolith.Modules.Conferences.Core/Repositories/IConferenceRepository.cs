// --------------------------------------------------------------------------------
//  Copyright (c) 2012-2021 by Bystronic Laser AG, CH-3362 Niederoenz
// --------------------------------------------------------------------------------

using ModularMonolith.Modules.Conferences.Core.Entities;

namespace ModularMonolith.Modules.Conferences.Core.Repositories;

internal interface IConferenceRepository
{
    Task<Conference?> GetAsync(Guid id);
    Task<IReadOnlyList<Conference>> BrowsAsync();
    Task AddAsync(Conference host);
    Task UpdateAsync(Conference host);
    Task DeleteAsync(Conference host);
}