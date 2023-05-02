// --------------------------------------------------------------------------------
//  Copyright (c) 2012-2021 by Bystronic Laser AG, CH-3362 Niederoenz
// --------------------------------------------------------------------------------

using System.Runtime.CompilerServices;
using Microsoft.Extensions.DependencyInjection;
using ModularMonolith.Modules.Conferences.Core.Policies;
using ModularMonolith.Modules.Conferences.Core.Repositories;
using ModularMonolith.Modules.Conferences.Core.Services;

[assembly:InternalsVisibleTo("ModularMonolith.Modules.Conferences.Api")]
namespace ModularMonolith.Modules.Conferences.Core;

internal static class Extensions
{
    public static IServiceCollection AddCore(this IServiceCollection services)
    {
        services
            .AddSingleton<IHostRepository, InMemoryHostRepository>()
            .AddSingleton<IHostDeletionPolicy, HostDeletionPolicy>()
            .AddSingleton<IConferenceDeletionPolicy, ConferenceDeletionPolicy>()
            .AddScoped<IHostService, HostService>();
        
        return services;
    }
}