using Proyecto_Expertos.Domain.Entities;
namespace Proyecto_Expertos.Application.Interfaces

{
    public interface IPPERepository
    {
        Task<IEnumerable<PPE_Global>> GetAllAsync();
        Task<PPE_Global> AddSync(PPE_Global ppe);
    }
}