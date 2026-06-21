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
    }
}
