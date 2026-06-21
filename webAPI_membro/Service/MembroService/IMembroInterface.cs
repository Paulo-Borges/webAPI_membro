using webAPI_membro.Models;

namespace webAPI_membro.Service.MembroService
{
    public interface IMembroInterface
    {

        //Task pra metodos assincrono   // retorna a Model ServiceResponse  
        // e retorna uma lista de membroModel  // e o nome do metodo
        
        Task<ServiceResponse<List<MemboModel>>> GetMembros();

        //Task pra metodos assincrono   // retorna a Model ServiceResponse  
        // e retorna uma lista de membroModel  // e o nome do metodo mas recebe um parametro e cria um novo
        Task<ServiceResponse<List<MemboModel>>> CreateMembro(MemboModel novoMembro);

        //task pra metodos assincronos  // retorna o ServiceResponse // e retorna um membroModel por id
        Task<ServiceResponse<MemboModel>> GetMembroById(int id);

        //Task pra metodos assincrono   // retorna a Model ServiceResponse  
        // e retorna uma lista de membroModel  // e o nome do metodo mas recebe um parametro e edita um novo
        Task<ServiceResponse<List<MemboModel>>> UpdateMembro(MemboModel editadoMembro);

        //Task pra metodos assincrono   // retorna a Model ServiceResponse  
        // e retorna uma lista de membroModel  // e o nome do metodo mas recebe um parametro id
        Task<ServiceResponse<List<MemboModel>>> DeleteMembro(int id);
        Task<ServiceResponse<List<MemboModel>>> InativaMembro(int id);
    }
}
