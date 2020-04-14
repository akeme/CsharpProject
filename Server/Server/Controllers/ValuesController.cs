﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Server.Hubs;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ValuesController : ControllerBase
    {
        IHubContext<TestHub> _hubContext;
        public ValuesController(IHubContext<TestHub> hubContext)
        {
            _hubContext = hubContext;
        }

        //GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: Values/Details/5
        [HttpGet("{id}")]

        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
            _hubContext.Clients.All.SendAsync("Posted", value);
        }

        //PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {

        }
        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {


        }
    }
}