using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webAPI_membro.Models;
using webAPI_membro.Service.membroService;
using webAPI_membro.Service.MembroService;

namespace webAPI_membro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembroController : ControllerBase
    {
        private readonly IMembroInterface _membroInterface;
        public MembroController(IMembroInterface membroInterface)
        {
            _membroInterface = membroInterface;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<MemboModel>>>> GetMembros()
        {
            return Ok( await _membroInterface.GetMembros());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<MemboModel>>> GetMembroById(int id)
        {
            ServiceResponse<MemboModel> serviceResponse = await _membroInterface.GetMembroById(id);

            return Ok(serviceResponse);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<MemboModel>>>> CreateMembro(MemboModel novoMembro)
        {
            return Ok(await _membroInterface.CreateMembro(novoMembro));
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<List<MemboModel>>>> UpdateMembro(MemboModel editadoMembro)
        {
            ServiceResponse<List<MemboModel>> serviceResponse = await _membroInterface.UpdateMembro(editadoMembro);

            return Ok(serviceResponse);
        }

        [HttpPut ("inativaMembro")]
        public async Task<ActionResult<ServiceResponse<List<MemboModel>>>> InativaMembro(int id)
        {
            ServiceResponse<List<MemboModel>> serviceResponse = await _membroInterface.InativaMembro(id);

            return Ok(serviceResponse);
        }

        [HttpDelete]
        public async Task<ActionResult<ServiceResponse<List<MemboModel>>>> DeleteMembro(int id)
        {
            ServiceResponse<List<MemboModel>> serviceResponse = await _membroInterface.DeleteMembro(id);

            return Ok(serviceResponse);
        }

    }
}
