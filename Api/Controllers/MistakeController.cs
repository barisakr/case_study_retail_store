using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Api.Errors;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Api.Controllers
{
    public class MistakeController : BaseApiController
    {
        private readonly RetailStoreContext _context;
        public MistakeController(RetailStoreContext context)
        {
            _context = context;
        }

        [HttpGet("notfound")]
        public ActionResult NotFoundRequest()
        {
            return NotFound(new ApiResponse(404));
        }
        [HttpGet("servererror")]
        public ActionResult ServerError()
        {
            var thing = _context.Customers.Find(1311);
            var trl = thing.ToString();
            return Ok();
        }
        [HttpGet("badrequest")]
        public ActionResult GetBadRequest()
        {
            return BadRequest(new ApiResponse(400));
        }
        [HttpGet("badrequest/{id}")]
        public ActionResult NotFoundRequest(int id)
        {
            return Ok();
        }

    }
}