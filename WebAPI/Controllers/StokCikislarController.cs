using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StokCikislarController : ControllerBase
    {
        IStokCikisService _stokCikisService;
        public StokCikislarController(IStokCikisService stokCikisService)
        {
            _stokCikisService = stokCikisService;
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _stokCikisService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            var result = _stokCikisService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("detaylar")]
        public IActionResult GetAllDetails()
        {
            var result = _stokCikisService.GetAllDetails();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("detaylar/{id:int}")]
        public IActionResult GetDetailById(int id)
        {
            var result = _stokCikisService.GetDetailsById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }



        [HttpGet("detaylar/afetzede/{afetzedeId:int}")]
        public IActionResult GetDetailByAfetzedeId(int afetzedeId)
        {
            var result = _stokCikisService.GetDetailsByAfetzedeId(afetzedeId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("urun/{urunId:int}")]
        public IActionResult GetByUrunId(int urunId)
        {
            var result = _stokCikisService.GetByUrunId(urunId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet("detaylar/olcu-birim/{olcuBirimId:int}")]
        public IActionResult GetByOlcuBirimId(int olcuBirimId)
        {
            var result = _stokCikisService.GetDetailsByOlcuBirimId(olcuBirimId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("detaylar/onaylayan/{onaylayanId:int}")]
        public IActionResult GetByOnaylayanId(int onaylayanId)
        {
            var result = _stokCikisService.GetByOnaylayanId(onaylayanId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("detaylar/teslim-eden/{teslimEdenId:int}")]
        public IActionResult GetByTeslimEdenId(int teslimEdenId)
        {
            var result = _stokCikisService.GetByTeslimEdenId(teslimEdenId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpPost("onayla")]
        public IActionResult Onayla(StokCikisOnay stokCikisOnay)
        {
            var result = _stokCikisService.StokCikisiOnayla(stokCikisOnay);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpPost("teslim")]
        public IActionResult TeslimEt(StokCikisTeslim stokCikisTeslim)
        {
            var result = _stokCikisService.StokCikisiTeslimEdildiOlarakİsaretle(stokCikisTeslim);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }




        [HttpPost("add")]
        public IActionResult Add(StokCikis stokCikis)
        {
            var result = _stokCikisService.Add(stokCikis);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }

        [HttpPost("delete")]
        public IActionResult Delete(StokCikis stokCikis)
        {
            var result = _stokCikisService.Delete(stokCikis);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }

        [HttpPost("update")]
        public IActionResult Update(StokCikis stokCikis)
        {
            var result = _stokCikisService.Update(stokCikis);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }

    }
}
