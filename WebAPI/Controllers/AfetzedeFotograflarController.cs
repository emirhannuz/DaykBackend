using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AfetzedeFotograflarController : ControllerBase
    {
        IAfetzedeFotografService _afetzedeFotografService;

        public AfetzedeFotograflarController(IAfetzedeFotografService afetzedeFotografService)
        {
            _afetzedeFotografService = afetzedeFotografService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _afetzedeFotografService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("{afetzedeId:int}")]
        public IActionResult GetByAfetzedeId(int afetzedeId)
        {
            var result = _afetzedeFotografService.GetByAfetzedeId(afetzedeId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add([FromForm] int afetzedeId, IFormFile imageFile)
        {
            var result = _afetzedeFotografService.Add(afetzedeId, imageFile);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(AfetzedeFotograf afetzedeFotograf)
        {
            var result = _afetzedeFotografService.Delete(afetzedeFotograf);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

    }
}
