using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Restoran_API.DTO.jabatan;
using Restoran_API.DTO.menu;
using Restoran_API.DTO.pengguna;
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

                var pesanan = await _IPesanan.getPesanan(ss => ss.Id == id);


                if (pesanan == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    return NotFound(_response);
                }

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

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<DefaultAPIResponse>> CreatePesanan([FromBody] pesananHeaderCreateDTO createDTO)
        {
            try
            {

                // custom error with modelstate
                if (await _IPesanan.getPesanan(ss => ss.NoMeja == createDTO.NoMeja && ss.IsBayar == false) != null)
                {
                    ModelState.AddModelError("customError", "Nomor meja not available !");
                    return BadRequest(ModelState);
                }

                if (createDTO == null)
                {
                    return BadRequest(createDTO);
                }

                var pesananHeader = _mapping.Map<PesananHeader>(createDTO);
                var pesananDetail = _mapping.Map<List<PesananDetail>>(createDTO.PesananDetails);

                await _IPesanan.Create(pesananHeader, pesananDetail);

                _response.Result = createDTO;
                _response.StatusCode = HttpStatusCode.Created;
                return CreatedAtRoute("GetPesanan", new { id = pesananHeader.Id }, _response);
            }
            catch (Exception e)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { e.ToString() };
            }

            return _response;
        }



        [HttpPut("{id:int}", Name = "UpdatePesanan")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<DefaultAPIResponse>> UpdatePesanan(int id, [FromBody] pesananHeaderUpdateDTO updateDTO)
        {
            try
            {
                if (updateDTO == null || id != updateDTO.Id)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.IsSuccess = false;
                    return BadRequest(_response);
                }

                var pesananHeader = _mapping.Map<PesananHeader>(updateDTO);
                var pesananDetail = _mapping.Map<List<PesananDetail>>(updateDTO.PesananDetails);

                await _IPesanan.Update(pesananHeader, pesananDetail);

                _response.StatusCode = HttpStatusCode.NoContent;
                return Ok(_response);
            }
            catch (Exception e)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { e.ToString() };
            }

            return _response;
        }

        [HttpDelete("{id:int}", Name = "DeletePesanan")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<DefaultAPIResponse>> DeletePesanan(int id)
        {
            try
            {
                if (id == 0)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.IsSuccess = false;
                    return BadRequest(_response);
                }

                await _IPesanan.Delete(id);
                _response.StatusCode = HttpStatusCode.NoContent;

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
