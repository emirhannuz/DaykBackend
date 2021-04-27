using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OlcuBirimlerController : ControllerBase
    {
        IOlcuBirimService _olcuBirimService;
        public OlcuBirimlerController(IOlcuBirimService olcuBirimService)
        {
            _olcuBirimService = olcuBirimService;
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _olcuBirimService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            var result = _olcuBirimService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(OlcuBirim olcuBirim)
        {
            var result = _olcuBirimService.Add(olcuBirim);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(OlcuBirim olcuBirim)
        {
            var result = _olcuBirimService.Delete(olcuBirim);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(OlcuBirim olcuBirim)
        {
            var result = _olcuBirimService.Update(olcuBirim);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

    }
}
