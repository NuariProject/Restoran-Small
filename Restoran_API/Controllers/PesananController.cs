using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restoran_API.DTO.jabatan;
using Restoran_API.DTO.menu;
using Restoran_API.DTO.pesanan;
using Restoran_API.Models;
using Restoran_API.Repository.IRepository;
using System.Net;

namespace Restoran_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PesananController : ControllerBase
    {
        protected DefaultAPIResponse _response;
        private readonly IPesananRepository _IPesanan;
        private readonly IMapper _mapping;

        public PesananController(IPesananRepository IPesanan, IMapper mapping)
        {
            _IPesanan = IPesanan;
            _mapping = mapping;
            this._response = new();
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<DefaultAPIResponse>> GetAllPesanan()
        {
            try
            {
                IEnumerable<pesananHeaderDTO> pesanan = await _IPesanan.getAllPesanan();
                _response.Result = pesanan;
                _response.StatusCode = HttpStatusCode.OK;
                return Ok(_response);
            }
            catch (Exception e)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { e.ToString() };
            }

            return _response;
        }


        [HttpGet("{id:int}", Name = "GetPesanan")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<DefaultAPIResponse>> GetPesanan(int id)
        {
            try
            {
                if (id == 0)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }

                var menu = await _IPesanan.getPesanan(ss => ss.Id == id);


                if (menu == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    return NotFound(_response);
                }

                _response.Result = menu;
                _response.StatusCode = HttpStatusCode.OK;
                return Ok(_response);
            }
            catch (Exception e)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { e.ToString() };
            }

            return _response;
        }
    }
}
