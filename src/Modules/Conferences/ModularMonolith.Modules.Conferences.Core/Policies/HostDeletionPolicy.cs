// --------------------------------------------------------------------------------
//  Copyright (c) 2012-2021 by Bystronic Laser AG, CH-3362 Niederoenz
// --------------------------------------------------------------------------------

using ModularMonolith.Modules.Conferences.Core.Entities;

namespace ModularMonolith.Modules.Conferences.Core.Policies;

internal class HostDeletionPolicy : IHostDeletionPolicy
{
    private readonly IConferenceDeletionPolicy _conferenceDeletionPolicy;

    public HostDeletionPolicy(IConferenceDeletionPolicy conferenceDeletionPolicy)
    {
        _conferenceDeletionPolicy = conferenceDeletionPolicy;
    }
    
    public async Task<bool> CanDeleteAsync(Host host)
    {
        if (host.Conferences is null || !host.Conferences.Any())
        {
            return true;
        }

        foreach (var conference in host.Conferences)
        {
            if (await _conferenceDeletionPolicy.CanDeleteAsync(conference) is false)
            {
                return false;
            }
        }

        return true;
    }
}