// --------------------------------------------------------------------------------
//  Copyright (c) 2012-2021 by Bystronic Laser AG, CH-3362 Niederoenz
// --------------------------------------------------------------------------------

using ModularMonolith.Shared.Abstractions;

namespace ModularMonolith.Shared.Infrastructure;

public class Clock : IClock
{
    public DateTime CurrentDate()
    {
        return DateTime.UtcNow;
    }
}