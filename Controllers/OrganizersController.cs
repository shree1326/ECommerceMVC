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
    public class OrganizersController : Controller
    {
        private readonly IOrganizersService _service;

        public OrganizersController(IOrganizersService service)
        {
            _service = service;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var allOrganizers = await _service.GetAllAsync();
            return View(allOrganizers);
        }

        //Get: Organizers/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Logo,Name,Description")]Organizer organizer)
        {
            if (!ModelState.IsValid) return View(organizer);
            await _service.AddAsync(organizer);
            return RedirectToAction(nameof(Index));
        }

        //Get: Organizers/Details/1
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var organizerDetails = await _service.GetByIdAsync(id);
            if (organizerDetails == null) return View("NotFound");
            return View(organizerDetails);
        }

        //Get: Organizers/Edit/1
        public async Task<IActionResult> Edit(int id)
        {
            var organizerDetails = await _service.GetByIdAsync(id);
            if (organizerDetails == null) return View("NotFound");
            return View(organizerDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Logo,Name,Description")] Organizer organizer)
        {
            if (!ModelState.IsValid) return View(organizer);
            await _service.UpdateAsync(id, organizer);
            return RedirectToAction(nameof(Index));
        }

        //Get: Organizers/Delete/1
        public async Task<IActionResult> Delete(int id)
        {
            var organizerDetails = await _service.GetByIdAsync(id);
            if (organizerDetails == null) return View("NotFound");
            return View(organizerDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            var organizerDetails = await _service.GetByIdAsync(id);
            if (organizerDetails == null) return View("NotFound");

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
