using Microsoft.EntityFrameworkCore;
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

        public async Task<ServiceResponse<List<MemboModel>>> DeleteMembro(int id)
        {
            ServiceResponse<List<MemboModel>> serviceResponse = new ServiceResponse<List<MemboModel>>();

            try
            {
                MemboModel membro = _context.Membros.FirstOrDefault(x => x.Id == id);

                if(membro == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Usuário não encontrado!";
                    serviceResponse.Sucesso = false;

                    return serviceResponse;
                }

                _context.Membros.Remove(membro);
                await _context.SaveChangesAsync();

            }catch(Exception ex)
            {

                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<MemboModel>> GetMembroById(int id)
        {
            ServiceResponse<MemboModel> serviceResponse = new ServiceResponse<MemboModel>();

            try
            {
                MemboModel membro = _context.Membros.FirstOrDefault(x => x.Id == id);

                if(membro == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Membro não encontrado!";
                    serviceResponse.Sucesso = false;
                }

                serviceResponse.Dados = membro;



            }catch(Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }
            return serviceResponse;
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

        public async Task<ServiceResponse<List<MemboModel>>> InativaMembro(int id)
        {
            ServiceResponse<List<MemboModel>> serviceResponse = new ServiceResponse<List<MemboModel>>();

            try
            {
                MemboModel membro = _context.Membros.FirstOrDefault(x => x.Id == id);

                if(membro == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Usuario não localizado!";
                    serviceResponse.Sucesso = false;
                }

                membro.Ativo = false;
                membro.DataDeAlteracao = DateTime.Now.ToLocalTime();

                _context.Membros.Update(membro);
                await _context.SaveChangesAsync();

                serviceResponse.Dados = _context.Membros.ToList();


            }catch(Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<MemboModel>>> UpdateMembro(MemboModel editadoMembro)
        {
            ServiceResponse<List<MemboModel>> serviceResponse = new ServiceResponse<List<MemboModel>>();

            try
            {
                MemboModel membro = _context.Membros.AsNoTracking().FirstOrDefault(x => x.Id == editadoMembro.Id);

                if(membro == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Usuário não encontrado!";
                    serviceResponse.Sucesso = false;
                }

                membro.DataDeAlteracao = DateTime.Now.ToLocalTime();

                _context.Membros.Update(editadoMembro);
                await _context.SaveChangesAsync();

                serviceResponse.Dados = _context.Membros.ToList();


            }catch(Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }
    }
}
