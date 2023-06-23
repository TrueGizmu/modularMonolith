// --------------------------------------------------------------------------------
//  Copyright (c) 2012-2021 by Bystronic Laser AG, CH-3362 Niederoenz
// --------------------------------------------------------------------------------

using ModularMonolith.Modules.Conferences.Core.DTO;
using ModularMonolith.Modules.Conferences.Core.Entities;
using ModularMonolith.Modules.Conferences.Core.Policies;
using ModularMonolith.Modules.Conferences.Core.Repositories;
using ModularMonolith.Shared.Infrastructure.Exceptions;

namespace ModularMonolith.Modules.Conferences.Core.Services;

internal class HostService : IHostService
{
    private readonly IHostRepository _hostRepository;
    private readonly IHostDeletionPolicy _hostDeletionPolicy;

    public HostService(IHostRepository hostRepository, IHostDeletionPolicy hostDeletionPolicy)
    {
        _hostRepository = hostRepository;
        _hostDeletionPolicy = hostDeletionPolicy;
    }
    
    public async Task AddAsync(HostDetailsDto dto)
    {
        dto.Id = Guid.NewGuid();
        await _hostRepository.AddAsync(new Host
        {
            Id = dto.Id,
            Name = dto.Name,
            Description = dto.Description
        });
    }

    public async Task<HostDetailsDto?> GetAsync(Guid id)
    {
        var host = await _hostRepository.GetAsync(id);

        if (host is null)
        {
            return null;
        }

        var dto = Map<HostDetailsDto>(host);
        dto.Conferences = host.Conferences?.Select(x => new ConferenceDto
        {
            Id = x.Id,
            HostId = x.HostId,
            HostName = x.Host.Name,
            Name = x.Name,
            From = x.From,
            Location = x.Location,
            To = x.To,
            LogoUrl = x.LogoUrl,
            ParticipantsLimit = x.ParticipantsLimit
        }).ToList();
        return dto;
    }

    public async Task<IReadOnlyList<HostDto>> BrowseAsync()
    {
        var hosts = await _hostRepository.BrowsAsync();

        return hosts.Select(Map<HostDto>).ToList();
    }

    public async Task UpdateAsync(HostDetailsDto dto)
    {
        var host = await _hostRepository.GetAsync(dto.Id);
        if (host is null)
        {
            throw new HostNotFoundException(dto.Id); 
        }

        host.Name = dto.Name;
        host.Description = dto.Description;
        await _hostRepository.UpdateAsync(host);
    }

    public async Task DeleteAsync(Guid id)
    {
        var host = await _hostRepository.GetAsync(id);
        if (host is null)
        {
            throw new HostNotFoundException(id); 
        }

        if (await _hostDeletionPolicy.CanDeleteAsync(host) is false)
        {
            throw new CannotDeleteHostException(id);
        }
        await _hostRepository.DeleteAsync(host);
    }

    private static T Map<T>(Host host) where T : HostDto, new()
    {
        return new T
        {
            Id = host.Id,
            Description = host.Description,
            Name = host.Name
        };
    }
}