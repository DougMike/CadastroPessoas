using CadastroPessoa_api.Data.Models;
using CadastroPessoa_api.Services.IServices;
using CadastroPessoa_api.Services.Validator;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

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
        public IEnumerable<Pessoa> GetAll()
        {
            return _pessoaService.GetAll();
        }

        [HttpGet("{id}")]
        public Pessoa GetById(Guid id)
        {
            return _pessoaService.GetById(id);
        }

        [HttpPost]
        public IActionResult AddPessoa(Pessoa pessoa)
        {
            if (pessoa == null)
                return NotFound();

            return Execute(() => _pessoaService.Add<PessoaValidator>(pessoa));

        }

        [HttpDelete("{id}")]
        public void RemovePessoa(Guid id)
        {
            Pessoa pessoa = _pessoaService.GetById(id);
            
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
