using ModularMonolith.Shared.Abstractions.Exceptions;

namespace ModularMonolith.Shared.Infrastructure.Exceptions;

public class CannotDeleteHostException : CustomException
{
    public Guid HostId { get; }

    public CannotDeleteHostException(Guid hostId) : base($"Host with ID: {hostId} cannot be deleted.")
    {
        HostId = hostId;
    }
}