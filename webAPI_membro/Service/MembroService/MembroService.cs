using webAPI_membro.DataContext;
using webAPI_membro.Models;
using webAPI_membro.Service.MembroService;

namespace webAPI_membro.Service.membroService
{
    public class MembroService : IMembroInterface
    {
        private readonly ApplicationDbContext _context;
        public MembroService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<List<MemboModel>>> CreateMembro(MemboModel novoMembro)
        {
            ServiceResponse<List<MemboModel>> serviceResponse = new ServiceResponse<List<MemboModel>>();

            try
            {

                if(novoMembro == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Informar Dados!";
                    serviceResponse.Sucesso = false;

                    return serviceResponse;
                }

                _context.Add(novoMembro);
                await _context.SaveChangesAsync();

                serviceResponse.Dados = _context.Membros.ToList();

            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }
            return serviceResponse;
        }

        public Task<ServiceResponse<List<MemboModel>>> DeleteMembro(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<MemboModel>> GetMembroById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResponse<List<MemboModel>>> GetMembros()
        {
            ServiceResponse<List<MemboModel>> serviceResponse = new ServiceResponse<List<MemboModel>>();


            try
            {
                serviceResponse.Dados = _context.Membros.ToList();

                if (serviceResponse.Dados.Count == 0)
                {
                    serviceResponse.Mensagem = "Nenhum Dado encontrado!";
                }
            }catch(Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }
            return serviceResponse;
        }

        public Task<ServiceResponse<List<MemboModel>>> InativaMembro(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<List<MemboModel>>> UpdateMembro(MemboModel editadoMembro)
        {
            throw new NotImplementedException();
        }
    }
}
