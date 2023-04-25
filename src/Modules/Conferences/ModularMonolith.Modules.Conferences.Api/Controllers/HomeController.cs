// --------------------------------------------------------------------------------
//  Copyright (c) 2012-2021 by Bystronic Laser AG, CH-3362 Niederoenz
// --------------------------------------------------------------------------------

using Microsoft.AspNetCore.Mvc;

namespace ModularMonolith.Modules.Conferences.Api.Controllers;

[Route("conferences-module")]
internal class HomeController : ControllerBase
{
    [HttpGet]
    public ActionResult<string> Get() => "Conferences API";
}