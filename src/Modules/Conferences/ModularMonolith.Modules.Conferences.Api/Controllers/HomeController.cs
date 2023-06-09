﻿// --------------------------------------------------------------------------------
//  Copyright (c) 2012-2021 by Bystronic Laser AG, CH-3362 Niederoenz
// --------------------------------------------------------------------------------

using Microsoft.AspNetCore.Mvc;

namespace ModularMonolith.Modules.Conferences.Api.Controllers;

[Route(BasePath)]
internal class HomeController : BaseController
{
    [HttpGet]
    public ActionResult<string> Get() => "Conferences API";
}