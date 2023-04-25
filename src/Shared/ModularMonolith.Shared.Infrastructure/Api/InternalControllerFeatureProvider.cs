// --------------------------------------------------------------------------------
//  Copyright (c) 2012-2021 by Bystronic Laser AG, CH-3362 Niederoenz
// --------------------------------------------------------------------------------

using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;

namespace ModularMonolith.Shared.Infrastructure.Api;

/// <summary>
/// This is needed for controllers that are internal
/// </summary>
internal class InternalControllerFeatureProvider : ControllerFeatureProvider
{
    protected override bool IsController(TypeInfo typeInfo) => typeInfo.IsClass &&
                                                               !typeInfo.IsAbstract &&
                                                               !typeInfo.ContainsGenericParameters &&
                                                               !typeInfo.IsDefined(typeof(NonControllerAttribute)) &&
                                                               (typeInfo.Name.EndsWith("Controller",
                                                                    StringComparison.OrdinalIgnoreCase) ||
                                                                typeInfo.IsDefined(typeof(ControllerAttribute)));

}