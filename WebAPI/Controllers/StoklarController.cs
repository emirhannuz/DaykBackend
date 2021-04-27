using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoklarController : ControllerBase
    {
        IStokService _stokService;

        public StoklarController(IStokService stokService)
        {
            _stokService = stokService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _stokService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            var result = _stokService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("detaylar")]
        public IActionResult GetAllDetails()
        {
            var result = _stokService.GetAllStokDetail();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("detaylar/{id:int}")]
        public IActionResult GetAllDetailsById(int id)
        {
            var result = _stokService.GetStokDetailById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("urun/{urunId:int}")]
        public IActionResult GetByUrunId(int urunId)
        {
            var result = _stokService.GetByUrunId(urunId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("kayit-yapan/{id:int}")]
        public IActionResult GetByKayitYapanId(int id)
        {
            var result = _stokService.GetByKayitYapanId(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpPost("add")]
        public IActionResult Add(Stok stok)
        {
            var result = _stokService.Add(stok);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }

        [HttpPost("delete")]
        public IActionResult Delete(Stok stok)
        {
            var result = _stokService.Delete(stok);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }

        [HttpPost("update")]
        public IActionResult Update(Stok stok)
        {
            var result = _stokService.Update(stok);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }

    }
}
