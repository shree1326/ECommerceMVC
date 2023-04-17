using eTickets.Data.Base;
using eTickets.Models;

namespace eTickets.Data.Services
{
    public class OrganizersService:EntityBaseRepository<Organizer>, IOrganizersService
    {
        public OrganizersService(AppDbContext context) : base(context)
        {
        }
    }
}
