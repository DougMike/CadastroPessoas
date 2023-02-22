using CadastroPessoa.Application.IServices;
using CadastroPessoa.Application.Validators;
using CadastroPessoa.Domain.DTO;
using CadastroPessoa.Persistence.IRepository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CadastroPessoas.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        private readonly IFileService _fileService;
        public FileController(IFileService fileService)
        {
            _fileService =fileService;

        }

        // GET: api/<FileController>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok(await _fileService.GetAllAsync());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<FileController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            try
            {
                var file = await _fileService.GetByIdAsync(id);
                if (file == null) return NotFound("Arquivo não encontrado.");

                return Ok(file);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<FileController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] File model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            try
            {
                object value = await _fileService.Add<FileValidator>(model);
                if (value == null) return BadRequest();

                return Ok(value);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // PUT api/<FileController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] File model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            try
            {
                object value = await _fileService.Update(model);
                return Ok(value);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<FileController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            try
            {
                var file = await _fileService.GetByIdAsync(id);
                if (file == null) return BadRequest("Resgistro não encontrado.");


                _fileService.Delete(file);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
