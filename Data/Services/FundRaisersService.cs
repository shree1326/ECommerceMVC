using eTickets.Data.Base;
using eTickets.Models;

namespace eTickets.Data.Services
{
    public class FundRaisersService: EntityBaseRepository<FundRaiser>, IFundRaisersService
    {
        public FundRaisersService(AppDbContext context) : base(context)
        {
        }
    }
}
