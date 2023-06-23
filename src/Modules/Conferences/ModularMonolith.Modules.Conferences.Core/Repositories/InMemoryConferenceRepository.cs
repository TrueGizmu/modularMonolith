// --------------------------------------------------------------------------------
//  Copyright (c) 2012-2021 by Bystronic Laser AG, CH-3362 Niederoenz
// --------------------------------------------------------------------------------

using ModularMonolith.Modules.Conferences.Core.Entities;

namespace ModularMonolith.Modules.Conferences.Core.Repositories;

internal class InMemoryConferenceRepository : IConferenceRepository
{
    private readonly List<Conference> _conferences = new();

    public Task<Conference?> GetAsync(Guid id) => Task.FromResult(_conferences.SingleOrDefault(x => x.Id == id));

    public Task<IReadOnlyList<Conference>> BrowsAsync()
    {
        return Task.FromResult<IReadOnlyList<Conference>>(_conferences);
    }

    public Task AddAsync(Conference conference)
    {
        _conferences.Add(conference);
        return Task.CompletedTask;
    }

    public Task UpdateAsync(Conference conference)
    {
        return Task.CompletedTask;
    }

    public Task DeleteAsync(Conference conference)
    {
        _conferences.Remove(conference);
        return Task.CompletedTask;
    }
}