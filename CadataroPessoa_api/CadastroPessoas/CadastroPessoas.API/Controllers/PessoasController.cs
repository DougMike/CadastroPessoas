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
                if (pessoa == null) return NotFound("Pessoa por id nao encontrado");

                return Ok(pessoa);

            }
            catch (Exception ex)
            {
                return BadRequest($"Erro na requisição. Error: {ex.Message}");

            }

        }

        [HttpPost]
        public async Task<IActionResult> AddPessoa(Pessoa pessoa)
        {
            try
            {
                if (pessoa == null)
                    return NotFound();

                object value = await Execute(() => _pessoaService.Add<PessoaValidator>(pessoa));
                return Ok("Adição Efetuada.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro na adição de registro: {ex.Message}");

            }

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemovePessoa(Guid id)
        {
            try
            {
                var pessoa = await _pessoaService.GetByIdAsync(id);
                if (pessoa == null) return NotFound();

                _pessoaService.Delete(pessoa);
                return Ok("Exclusão efetuada.");
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
                if (pessoaValid == null) return NotFound();

                pessoaValid.Id = id;

                await _pessoaService.Update(pessoaValid);
                return Ok(pessoa);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro na atualização de pessoa: {ex.Message}");
            }

        }
        private async Task<IActionResult> Execute(Func<object> func)
        {
            try
            {
                var result = func();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
