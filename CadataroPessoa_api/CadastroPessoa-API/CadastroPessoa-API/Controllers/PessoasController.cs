using CadastroPessoa_API.Models;
using CadastroPessoa_API.Services.IServices;
using CadastroPessoa_API.Services.Validator;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CadastroPessoa_API.Controllers
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
        public IEnumerable<Pessoa> Get()
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

            return Execute(() => _pessoaService.Add<PessoaValidator>(pessoa).Id);
        }

        [HttpPut("{id}")]
        public IActionResult UpdatePessoa(Guid id)
        {
            return Execute(() => _pessoaService.Update<PessoaValidator>(id));
        }

        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            var pessoa = _pessoaService.GetById(id);

            if(pessoa != null)
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
