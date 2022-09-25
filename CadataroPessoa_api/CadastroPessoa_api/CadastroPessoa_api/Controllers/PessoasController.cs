using CadastroPessoa_api.Data.Models;
using CadastroPessoa_api.Services.IServices;
using Microsoft.AspNetCore.Mvc;
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
    }
}
