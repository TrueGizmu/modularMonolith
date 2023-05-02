// --------------------------------------------------------------------------------
//  Copyright (c) 2012-2021 by Bystronic Laser AG, CH-3362 Niederoenz
// --------------------------------------------------------------------------------

using ModularMonolith.Modules.Conferences.Core.Entities;
using ModularMonolith.Shared.Abstractions;

namespace ModularMonolith.Modules.Conferences.Core.Policies;

internal class ConferenceDeletionPolicy : IConferenceDeletionPolicy
{
    private readonly IClock _clock;

    public ConferenceDeletionPolicy(IClock clock)
    {
        _clock = clock;
    }

    public Task<bool> CanDeleteAsync(Conference conference)
    {
        return Task.FromResult(_clock.CurrentDate().Date.AddDays(7) < conference.From.Date);
    }
}