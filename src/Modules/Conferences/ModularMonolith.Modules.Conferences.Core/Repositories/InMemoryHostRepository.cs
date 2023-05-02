// --------------------------------------------------------------------------------
//  Copyright (c) 2012-2021 by Bystronic Laser AG, CH-3362 Niederoenz
// --------------------------------------------------------------------------------

using ModularMonolith.Modules.Conferences.Core.Entities;

namespace ModularMonolith.Modules.Conferences.Core.Repositories;

internal class InMemoryHostRepository : IHostRepository
{
    private readonly List<Host> _hosts = new();

    public Task<Host?> GetAsync(Guid id) => Task.FromResult(_hosts.SingleOrDefault(x => x.Id == id));

    public Task<IReadOnlyList<Host>> BrowsAsync()
    {
        return Task.FromResult<IReadOnlyList<Host>>(_hosts);
    }

    public Task AddAsync(Host host)
    {
        _hosts.Add(host);
        return Task.CompletedTask;
    }

    public Task UpdateAsync(Host host)
    {
        return Task.CompletedTask;
    }

    public Task DeleteAsync(Host host)
    {
        _hosts.Remove(host);
        return Task.CompletedTask;
    }
}