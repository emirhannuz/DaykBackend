using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UrunlerController : ControllerBase
    {
        IUrunService _urunService;
        public UrunlerController(IUrunService urunService)
        {
            _urunService = urunService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _urunService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            var result = _urunService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("tur/{turId:int}")]
        public IActionResult GetByTurId(int turId)
        {
            var result = _urunService.GetByTurId(turId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("detaylar")]
        public IActionResult GetDetailById()
        {
            var result = _urunService.GetAllDetails();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("detaylar/{id:int}")]
        public IActionResult GetDetailById(int id)
        {
            var result = _urunService.GetDetailById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpPost("add")]
        public IActionResult Add(Urun urun)
        {
            var result = _urunService.Add(urun);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(Urun urun)
        {
            var result = _urunService.Delete(urun);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(Urun urun)
        {
            var result = _urunService.Update(urun);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


    }
}
