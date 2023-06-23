using ModularMonolith.Shared.Abstractions.Exceptions;

namespace ModularMonolith.Shared.Infrastructure.Exceptions;

public class CannotDeleteConferenceException : CustomException
{
    public Guid ConferenceId { get; }

    public CannotDeleteConferenceException(Guid id) : base($"Conference with ID: {id} cannot be deleted.")
    {
        ConferenceId = id;
    }
}