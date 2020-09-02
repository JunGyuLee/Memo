using System.ComponentModel.Design.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KJMemo.Models.DAO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KJMemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NoteController : ControllerBase
    {

        [HttpGet]
        public IActionResult Test([FromQuery]Note note)
        {

            return Ok();
        }

    }
}