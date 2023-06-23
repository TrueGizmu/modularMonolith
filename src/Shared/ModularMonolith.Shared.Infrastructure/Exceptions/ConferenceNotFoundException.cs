// --------------------------------------------------------------------------------
//  Copyright (c) 2012-2021 by Bystronic Laser AG, CH-3362 Niederoenz
// --------------------------------------------------------------------------------

using ModularMonolith.Shared.Abstractions.Exceptions;

namespace ModularMonolith.Shared.Infrastructure.Exceptions;

public class ConferenceNotFoundException : CustomException
{
    public Guid ConferenceId { get; }

    public ConferenceNotFoundException(Guid id) : base($"Conference with ID: {id} was not found.")
    {
        ConferenceId = id;
    }
}