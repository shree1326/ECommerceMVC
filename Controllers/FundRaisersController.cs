using eTickets.Data;
using eTickets.Data.Services;
using eTickets.Data.Static;
using eTickets.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace eTickets.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    public class FundRaisersController : Controller
    {
        private readonly IFundRaisersService _service;

        public FundRaisersController(IFundRaisersService service)
        {
            _service = service;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var allFundRaisers = await _service.GetAllAsync();
            return View(allFundRaisers);
        }

        //GET: FundRaiser/details/1
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var fundRaiserDetails = await _service.GetByIdAsync(id);
            if (fundRaiserDetails == null) return View("NotFound");
            return View(fundRaiserDetails);
        }

        //GET: FundRaisers/create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("ProfilePictureURL,FullName,Bio")]FundRaiser fundRaiser)
        {
            if (!ModelState.IsValid) return View(fundRaiser);

            await _service.AddAsync(fundRaiser);
            return RedirectToAction(nameof(Index));
        }

        //GET: FundRaisers/edit/1
        public async Task<IActionResult> Edit(int id)
        {
            var fundRaiserDetails = await _service.GetByIdAsync(id);
            if (fundRaiserDetails == null) return View("NotFound");
            return View(fundRaiserDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ProfilePictureURL,FullName,Bio")] FundRaiser fundRaiser)
        {
            if (!ModelState.IsValid) return View(fundRaiser);

            if(id == fundRaiser.Id)
            {
                await _service.UpdateAsync(id, fundRaiser);
                return RedirectToAction(nameof(Index));
            }
            return View(fundRaiser);
        }

        //GET: FundRaisers/delete/1
        public async Task<IActionResult> Delete(int id)
        {
            var fundRaiserDetails = await _service.GetByIdAsync(id);
            if (fundRaiserDetails == null) return View("NotFound");
            return View(fundRaiserDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var fundRaiserDetails = await _service.GetByIdAsync(id);
            if (fundRaiserDetails == null) return View("NotFound");

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
