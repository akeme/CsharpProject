using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BDApi.Models;
using BDApi.Services;

namespace BDApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class LogsController : ControllerBase
    {
        private readonly LogService _logService;

        public LogsController(LogService logService)
        {
            _logService = logService;
        }

        [HttpGet]
        public ActionResult<List<Log>> Get() =>
            _logService.Get();

        [HttpGet("{id:length(24)}", Name = "GetLog")]
        public ActionResult<Log> Get(string id)
        {
            var log = _logService.Get(id);

            if (log == null)
            {
                return NotFound();
            }

            return log;
        }

        [HttpPost]
        public ActionResult<Log> Create(Log log)
        {
            _logService.Create(log);

            return CreatedAtRoute("GetLog", new { id = log.Id.ToString() }, log);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Log logIn)
        {
            var log = _logService.Get(id);

            if (log == null)
            {
                return NotFound();
            }

            _logService.Update(id, logIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var log = _logService.Get(id);

            if (log == null)
            {
                return NotFound();
            }

            _logService.Remove(log.Id);

            return NoContent();
        }
    }
}
