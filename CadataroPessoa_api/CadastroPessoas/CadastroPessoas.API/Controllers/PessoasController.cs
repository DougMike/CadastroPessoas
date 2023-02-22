using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using CadastroPessoa.Application.IServices;
using CadastroPessoa.Application.Validators;
using CadastroPessoa.Domain.DTO;

namespace CadastroPessoas.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PessoasController : ControllerBase
    {
        private readonly IPessoaService _pessoaService;

        public PessoasController(IPessoaService pessoaService)
        {
            _pessoaService = pessoaService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var listaPessoas = await _pessoaService.GetAllAsync();
                return Ok(listaPessoas);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            try
            {
                var pessoa = await _pessoaService.GetByIdAsync(id);
                if (pessoa == null) return NotFound("Não encontrado.");

                return Ok();

            }
            catch (Exception ex)
            {
                return BadRequest($"Erro na requisição. Error: {ex.Message}");

            }

        }

        [HttpPost]
        public async Task<IActionResult> AddPessoa([FromBody] Pessoa model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            try
            {
                object value = await _pessoaService.Add<PessoaValidator>(model);
                return Ok(value);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemovePessoa(Guid id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            try
            {
                var pessoa = await _pessoaService.GetByIdAsync(id);
                if (pessoa == null) return NotFound("Registro não encontrado.");

                _pessoaService.Delete(pessoa);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro na exclusão do retistros: {ex.Message}");
            }

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, Pessoa pessoa)
        {
            try
            {
                var pessoaValid = await _pessoaService.GetByIdAsync(id);
                if (pessoaValid == null) return NotFound("Registro não encontrado.");

                pessoaValid.Id = id;

                await _pessoaService.Update(pessoaValid);
                return Ok(pessoa);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro na atualização de pessoa: {ex.Message}");
            }

        }
    }
}
