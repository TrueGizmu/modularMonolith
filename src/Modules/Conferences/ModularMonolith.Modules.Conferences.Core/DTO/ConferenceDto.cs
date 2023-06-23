// --------------------------------------------------------------------------------
//  Copyright (c) 2012-2021 by Bystronic Laser AG, CH-3362 Niederoenz
// --------------------------------------------------------------------------------

using System.ComponentModel.DataAnnotations;

namespace ModularMonolith.Modules.Conferences.Core.DTO;

public class ConferenceDto
{
    public Guid Id { get; set; }
    [Required]
    public Guid HostId { get; set; }
    [Required]
    [StringLength(100, MinimumLength = 3)]
    public string Name { get; set; } = string.Empty;
    public string HostName { get; set; } = string.Empty;
    public string Location { get; set; } = string.Empty;
    public string LogoUrl { get; set; } = string.Empty;
    public int? ParticipantsLimit { get; set; }
    public DateTime From { get; set; }
    public DateTime To { get; set; }
}

public class ConferenceDetailsDto : ConferenceDto
{
    [Required]
    [StringLength(300)]
    public string Description { get; set; }
}