// --------------------------------------------------------------------------------
//  Copyright (c) 2012-2021 by Bystronic Laser AG, CH-3362 Niederoenz
// --------------------------------------------------------------------------------

using System.ComponentModel.DataAnnotations;

namespace ModularMonolith.Modules.Conferences.Core.DTO;

public class HostDto
{
    public Guid Id { get; set; }

    [Required]
    [StringLength(100, MinimumLength = 3)]
    public string Name { get; set; } = string.Empty;

    [StringLength(1000, MinimumLength = 3)]
    public string Description { get; set; } = string.Empty;
}

public class HostDetailsDto : HostDto
{
    public List<ConferenceDto>? Conferences { get; set; }
}