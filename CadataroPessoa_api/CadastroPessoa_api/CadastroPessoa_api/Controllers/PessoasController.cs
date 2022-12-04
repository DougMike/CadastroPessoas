using CadastroPessoa_api.Data.Models;
using CadastroPessoa_api.Services.IServices;
using CadastroPessoa_api.Services.Validator;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CadastroPessoa_api.Controllers
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
        public IActionResult AddPessoa(Pessoa pessoa)
        {
            if (pessoa == null)
                return NotFound();

            return Execute(() => _pessoaService.Add<PessoaValidator>(pessoa));

        }

        [HttpDelete("{id}")]
        public async void RemovePessoa(Guid id)
        {
            Pessoa pessoa = await _pessoaService.GetByIdAsync(id);

            _pessoaService.Delete(pessoa);
        }
        private IActionResult Execute(Func<object> func)
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
