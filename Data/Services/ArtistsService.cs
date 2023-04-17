using eTickets.Data.Base;
using eTickets.Models;

namespace eTickets.Data.Services
{
    public class ArtistsService : EntityBaseRepository<Artist>, IArtistsService
    {
        public ArtistsService(AppDbContext context) : base(context) { }
    }
}
