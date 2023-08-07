using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Restoran_API.DTO.jabatan;
using Restoran_API.Models;
using Restoran_API.Repository.IRepository;
using System.Net;

namespace Restoran_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class JabatanController : ControllerBase
    {
        protected DefaultAPIResponse _response;
        private readonly IJabatanRepository _IJabatan;
        private readonly IMapper _mapping;

        public JabatanController(IJabatanRepository IJabatan, IMapper mapping)
        {
            _IJabatan = IJabatan;
            _mapping = mapping;
            this._response = new();
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<DefaultAPIResponse>> GetJabatan()
        {
            try
            {
                IEnumerable<Jabatan> jabatan = await _IJabatan.getAllJabatan();
                _response.Result = _mapping.Map<List<jabatanDTO>>(jabatan);
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