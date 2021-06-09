using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Channels;
using System.Threading.Tasks;
using EventSpikeBack.Domain;
using EventSpikeBack.Interfaces.Services;

namespace EventSpikeBack.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;

        public UserController(IUserService service)
        {
            _service = service;
        }

        [HttpPost]
        public ActionResult Add(UserDomain user)
        {
            try
            {
                _service.Add(user);
                return StatusCode(200);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return StatusCode(418);
            }
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            try
            {
                _service.Delete(id);
                return StatusCode(200);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(418);
            }
        }

        [HttpPut]
        public ActionResult Update(UserDomain user)
        {
            try
            {
                _service.Update(user);
                return StatusCode(200);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(418);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<UserDomain> Get(int id)
        {
            try
            {
                var user = _service.Get(id);
                return StatusCode(200, user);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(418);
            }
        }

        [HttpGet]
        public ActionResult<List<UserDomain>> GetAll()
        {
            try
            {
                var users =_service.GetAll();
                return StatusCode(200, users);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(418);
            }
        }

    }
}
