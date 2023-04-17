using eTickets.Data.Base;
using eTickets.Data.ViewModels;
using eTickets.Models;
using System.Threading.Tasks;

namespace eTickets.Data.Services
{
    public interface IPaintingsService:IEntityBaseRepository<Painting>
    {
        Task<Painting> GetPaintingByIdAsync(int id);
        Task<NewPaintingDropdownsVM> GetNewPaintingDropdownsValues();
        Task AddNewPaintingAsync(NewPaintingVM data);
        Task UpdatePaintingAsync(NewPaintingVM data);
    }
}
