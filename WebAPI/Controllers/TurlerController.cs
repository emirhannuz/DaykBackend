using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TurlerController : ControllerBase
    {
        ITurService _turService;
        public TurlerController(ITurService turService)
        {
            _turService = turService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _turService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            var result = _turService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpPost("add")]
        public IActionResult Add(Tur tur)
        {
            var result = _turService.Add(tur);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(Tur tur)
        {
            var result = _turService.Delete(tur);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(Tur tur)
        {
            var result = _turService.Update(tur);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

    }
}
