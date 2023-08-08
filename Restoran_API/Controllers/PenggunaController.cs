using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restoran_API.DTO.jabatan;
using Restoran_API.DTO.pengguna;
using Restoran_API.Models;
using Restoran_API.Repository.IRepository;
using System.Net;

namespace Restoran_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PenggunaController : ControllerBase
    {
        protected DefaultAPIResponse _response;
        private readonly IPenggunaRepository _IPengguna;
        private readonly IMapper _mapping;

        public PenggunaController(IPenggunaRepository IPengguna, IMapper mapping)
        {
            _IPengguna = IPengguna;
            _mapping = mapping;
            this._response = new();
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<DefaultAPIResponse>> GetPengguna()
        {
            try
            {
                IEnumerable<Pengguna> penggunas = await _IPengguna.getAllPengguna();
                _response.Result = _mapping.Map<List<penggunaDTO>>(penggunas);
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
