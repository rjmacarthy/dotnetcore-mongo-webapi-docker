using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Model;
using Microsoft.AspNetCore.Mvc;

namespace c_.Controllers
{
    [Route("/")]
    [ApiController]
    public class IndexController : ControllerBase
    {
        private readonly IModelRepository _modelRepository;

        public IndexController(IModelRepository modelRepository)
        {
            _modelRepository = modelRepository;
        }
        
        [HttpGet]
        public ActionResult<string> Ping()
        {
            return "pong";
        }

        [HttpGet("/api/model")]
        public async Task<IEnumerable<BaseModel>> GetModels()
        {
            return await _modelRepository.Get();
        }

        [HttpPost("/api/model")]
        public async Task<IActionResult> Create()
        {
            BaseModel model = new BaseModel();
            await _modelRepository.Create(model);
            return new OkObjectResult(model);
        }

    }
}
