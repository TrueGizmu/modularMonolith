// --------------------------------------------------------------------------------
//  Copyright (c) 2012-2021 by Bystronic Laser AG, CH-3362 Niederoenz
// --------------------------------------------------------------------------------


using ModularMonolith.Modules.Conferences.Core.Entities;

namespace ModularMonolith.Modules.Conferences.Core.Policies;

public interface IHostDeletionPolicy
{
    Task<bool> CanDeleteAsync(Host host);
}