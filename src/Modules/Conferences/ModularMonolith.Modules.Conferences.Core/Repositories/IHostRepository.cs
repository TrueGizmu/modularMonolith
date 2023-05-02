// --------------------------------------------------------------------------------
//  Copyright (c) 2012-2021 by Bystronic Laser AG, CH-3362 Niederoenz
// --------------------------------------------------------------------------------

using ModularMonolith.Modules.Conferences.Core.Entities;

namespace ModularMonolith.Modules.Conferences.Core.Repositories;

internal interface IHostRepository
{
    Task<Host?> GetAsync(Guid id);
    Task<IReadOnlyList<Host>> BrowsAsync();
    Task AddAsync(Host host);
    Task UpdateAsync(Host host);
    Task DeleteAsync(Host host);
}