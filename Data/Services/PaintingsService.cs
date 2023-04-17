using eTickets.Data.Base;
using eTickets.Data.ViewModels;
using eTickets.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Data.Services
{
    public class PaintingsService : EntityBaseRepository<Painting>, IPaintingsService
    {
        private readonly AppDbContext _context;
        public PaintingsService(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task AddNewPaintingAsync(NewPaintingVM data)
        {
            var newPainting = new Painting()
            {
                Name = data.Name,
                Description = data.Description,
                Price = data.Price,
                ImageURL = data.ImageURL,
                OrganizerId = data.OrganizerId,
                StartDate = data.StartDate,
                EndDate = data.EndDate,
                PaintingCategory = data.PaintingCategory,
                FundRaiserId = data.FundRaiserId
            };
            await _context.Paintings.AddAsync(newPainting);
            await _context.SaveChangesAsync();

            //Add Painting Artists
            foreach (var artistId in data.ArtistIds)
            {
                var newArtistPainting = new Artist_Painting()
                {
                    PaintingId = newPainting.Id,
                    ArtistId = artistId
                };
                await _context.Artists_Paintings.AddAsync(newArtistPainting);
            }
            await _context.SaveChangesAsync();
        }

        public async Task<Painting> GetPaintingByIdAsync(int id)
        {
            var paintingDetails = await _context.Paintings
                .Include(c => c.Organizer)
                .Include(p => p.FundRaiser)
                .Include(am => am.Artists_Paintings).ThenInclude(a => a.Artist)
                .FirstOrDefaultAsync(n => n.Id == id);

            return paintingDetails;
        }

        public async Task<NewPaintingDropdownsVM> GetNewPaintingDropdownsValues()
        {
            var response = new NewPaintingDropdownsVM()
            {
                Artists = await _context.Artists.OrderBy(n => n.FullName).ToListAsync(),
                Organizers = await _context.Organizers.OrderBy(n => n.Name).ToListAsync(),
                FundRaisers = await _context.FundRaisers.OrderBy(n => n.FullName).ToListAsync()
            };

            return response;
        }

        public async Task UpdatePaintingAsync(NewPaintingVM data)
        {
            var dbPainting = await _context.Paintings.FirstOrDefaultAsync(n => n.Id == data.Id);

            if(dbPainting != null)
            {
                dbPainting.Name = data.Name;
                dbPainting.Description = data.Description;
                dbPainting.Price = data.Price;
                dbPainting.ImageURL = data.ImageURL;
                dbPainting.OrganizerId = data.OrganizerId;
                dbPainting.StartDate = data.StartDate;
                dbPainting.EndDate = data.EndDate;
                dbPainting.PaintingCategory = data.PaintingCategory;
                dbPainting.FundRaiserId = data.FundRaiserId;
                await _context.SaveChangesAsync();
            }

            //Remove existing artists
            var existingArtistsDb = _context.Artists_Paintings.Where(n => n.PaintingId == data.Id).ToList();
            _context.Artists_Paintings.RemoveRange(existingArtistsDb);
            await _context.SaveChangesAsync();

            //Add Painting Artists
            foreach (var artistId in data.ArtistIds)
            {
                var newArtistPainting = new Artist_Painting()
                {
                    PaintingId = data.Id,
                    ArtistId = artistId
                };
                await _context.Artists_Paintings.AddAsync(newArtistPainting);
            }
            await _context.SaveChangesAsync();
        }
    }
}
