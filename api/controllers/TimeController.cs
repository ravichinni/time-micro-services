using Microsoft.AspNetCore.Mvc;
using System;

namespace api.controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TimeController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(DateTime.UtcNow.ToString("o")); // ISO 8601 format
        }
    }
}
