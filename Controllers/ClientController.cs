using AutoMapper;
using DistripackAPI.Persistence;
using DistripackAPI.Persistence.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using GetModel = DistripackAPI.Controllers.ApiModels.Get;
using PostModel = DistripackAPI.Controllers.ApiModels.Post;

namespace DistripackAPI.Controllers
{
    [Route("api/clients")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientRepository repository;
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;

        public ClientController(IClientRepository repository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
            this.repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetClients()
        {
            var clientes = await repository.GetAll();
            var clients = mapper.Map<IList<GetModel.Client>>(clientes);
            return Ok(clients);
        }

        [HttpPost]
        public async Task<IActionResult> CreateClient([FromBody] PostModel.Client apiClient)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var client = mapper.Map<Models.Client>(apiClient);
            await repository.Add(client);
            await unitOfWork.Complete();
            return Ok(client);

        }

        // PUT: api/Client/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
