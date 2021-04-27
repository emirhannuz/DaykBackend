using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AfetzedelerController : ControllerBase
    {
        IAfetzedeService _afetzedeService;

        public AfetzedelerController(IAfetzedeService afetzedeService)
        {
            _afetzedeService = afetzedeService;
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _afetzedeService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            var result = _afetzedeService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("{tcNo}")]
        public IActionResult GetByTc(string tcNo)
        {
            var result = _afetzedeService.GetByTc(tcNo);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("detay")]
        public IActionResult GetAllDetails()
        {
            var result = _afetzedeService.GetAllDetails();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpPost("add")]
        public IActionResult Add(Afetzede afetzede)
        {
            var result = _afetzedeService.Add(afetzede);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(Afetzede afetzede)
        {
            var result = _afetzedeService.Delete(afetzede);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(Afetzede afetzede)
        {
            var result = _afetzedeService.Update(afetzede);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

    }
}
