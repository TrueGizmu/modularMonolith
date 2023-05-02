// --------------------------------------------------------------------------------
//  Copyright (c) 2012-2021 by Bystronic Laser AG, CH-3362 Niederoenz
// --------------------------------------------------------------------------------

using ModularMonolith.Shared.Abstractions.Exceptions;

namespace ModularMonolith.Shared.Infrastructure.Exceptions;

public class HostNotFoundException : CustomException
{
    public Guid HostId { get; }

    public HostNotFoundException(Guid hostId) : base($"Host with ID: {hostId} was not found.")
    {
        HostId = hostId;
    }
}