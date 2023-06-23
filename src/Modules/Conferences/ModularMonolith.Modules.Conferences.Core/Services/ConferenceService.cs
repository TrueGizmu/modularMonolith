// --------------------------------------------------------------------------------
//  Copyright (c) 2012-2021 by Bystronic Laser AG, CH-3362 Niederoenz
// --------------------------------------------------------------------------------

using ModularMonolith.Modules.Conferences.Core.DTO;
using ModularMonolith.Modules.Conferences.Core.Entities;
using ModularMonolith.Modules.Conferences.Core.Policies;
using ModularMonolith.Modules.Conferences.Core.Repositories;
using ModularMonolith.Shared.Infrastructure.Exceptions;

namespace ModularMonolith.Modules.Conferences.Core.Services;

internal class ConferenceService : IConferenceService
{
    private readonly IConferenceRepository _conferenceRepository;
    private readonly IHostRepository _hostRepository;
    private readonly IConferenceDeletionPolicy _conferenceDeletionPolicy;

    public ConferenceService(IConferenceRepository conferenceRepository, IHostRepository hostRepository,
        IConferenceDeletionPolicy conferenceDeletionPolicy)
    {
        _conferenceRepository = conferenceRepository;
        _hostRepository = hostRepository;
        _conferenceDeletionPolicy = conferenceDeletionPolicy;
    }

    public async Task AddAsync(ConferenceDetailsDto dto)
    {
        var host = await _hostRepository.GetAsync(dto.HostId);
        if (host is null)
        {
            throw new HostNotFoundException(dto.Id);
        }
        
        dto.Id = Guid.NewGuid();
        await _conferenceRepository.AddAsync(new Conference
        {
            Id = dto.Id,
            HostId = dto.HostId,
            Host = host,
            Name = dto.Name,
            Description = dto.Description,
            ParticipantsLimit = dto.ParticipantsLimit,
            From = dto.From,
            Location = dto.Location,
            To = dto.To,
            LogoUrl = dto.LogoUrl
        });
    }

    public async Task<ConferenceDetailsDto?> GetAsync(Guid id)
    {
        var conference = await _conferenceRepository.GetAsync(id);

        if (conference is null)
        {
            return null;
        }

        var dto = Map<ConferenceDetailsDto>(conference);
        dto.Description = conference.Description;
        return dto;
    }

    public async Task<IReadOnlyList<ConferenceDto>> BrowseAsync()
    {
        var conferences = await _conferenceRepository.BrowsAsync();
        return conferences.Select(Map<ConferenceDto>).ToList();
    }

    public async Task UpdateAsync(ConferenceDetailsDto dto)
    {
        var conference = await _conferenceRepository.GetAsync(dto.Id);
        if (conference is null)
        {
            throw new ConferenceNotFoundException(dto.Id); 
        }

        conference.Name = dto.Name;
        conference.Description = dto.Description;
        conference.From = dto.From;
        conference.Location = dto.Location;
        conference.To = dto.To;
        conference.LogoUrl = dto.LogoUrl;
        conference.ParticipantsLimit = dto.ParticipantsLimit;
        
        await _conferenceRepository.UpdateAsync(conference);
    }

    public async Task DeleteAsync(Guid id)
    {
        var conference = await _conferenceRepository.GetAsync(id);
        if (conference is null)
        {
            throw new ConferenceNotFoundException(id); 
        }

        if (await _conferenceDeletionPolicy.CanDeleteAsync(conference) is false)
        {
            throw new CannotDeleteConferenceException(id);
        }
        
        await _conferenceRepository.DeleteAsync(conference);
    }
    
    private static T Map<T>(Conference conference) where T : ConferenceDto, new() =>
        new()
        {
            Id = conference.Id,
            Name = conference.Name,
            From = conference.From,
            Location = conference.Location,
            To = conference.To,
            LogoUrl = conference.LogoUrl,
            HostId = conference.HostId,
            HostName = conference.Host.Name,
            ParticipantsLimit = conference.ParticipantsLimit
        };
}