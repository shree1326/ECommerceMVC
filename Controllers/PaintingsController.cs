using eTickets.Data;
using eTickets.Data.Services;
using eTickets.Data.Static;
using eTickets.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    public class PaintingsController : Controller
    {
        private readonly IPaintingsService _service;

        public PaintingsController(IPaintingsService service)
        {
            _service = service;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var allPaintings = await _service.GetAllAsync(n => n.Organizer);
            return View(allPaintings);
        }

        [AllowAnonymous]
        public async Task<IActionResult> Filter(string searchString)
        {
            var allPaintings = await _service.GetAllAsync(n => n.Organizer);

            if (!string.IsNullOrEmpty(searchString))
            {

                var filteredResultNew = allPaintings.Where(n => string.Equals(n.Name, searchString, StringComparison.CurrentCultureIgnoreCase) || string.Equals(n.Description, searchString, StringComparison.CurrentCultureIgnoreCase)).ToList();

                return View("Index", filteredResultNew);
            }

            return View("Index", allPaintings);
        }

        //GET: Paintings/Details/1
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var paintingDetail = await _service.GetPaintingByIdAsync(id);
            return View(paintingDetail);
        }

        //GET: Paintings/Create
        public async Task<IActionResult> Create()
        {
            var paintingDropdownsData = await _service.GetNewPaintingDropdownsValues();

            ViewBag.Organizers = new SelectList(paintingDropdownsData.Organizers, "Id", "Name");
            ViewBag.FundRaisers = new SelectList(paintingDropdownsData.FundRaisers, "Id", "FullName");
            ViewBag.Artists = new SelectList(paintingDropdownsData.Artists, "Id", "FullName");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(NewPaintingVM painting)
        {
            if (!ModelState.IsValid)
            {
                var paintingDropdownsData = await _service.GetNewPaintingDropdownsValues();

                ViewBag.Organizers = new SelectList(paintingDropdownsData.Organizers, "Id", "Name");
                ViewBag.FundRaisers = new SelectList(paintingDropdownsData.FundRaisers, "Id", "FullName");
                ViewBag.Artists = new SelectList(paintingDropdownsData.Artists, "Id", "FullName");

                return View(painting);
            }

            await _service.AddNewPaintingAsync(painting);
            return RedirectToAction(nameof(Index));
        }


        //GET: Paintings/Edit/1
        public async Task<IActionResult> Edit(int id)
        {
            var paintingDetails = await _service.GetPaintingByIdAsync(id);
            if (paintingDetails == null) return View("NotFound");

            var response = new NewPaintingVM()
            {
                Id = paintingDetails.Id,
                Name = paintingDetails.Name,
                Description = paintingDetails.Description,
                Price = paintingDetails.Price,
                StartDate = paintingDetails.StartDate,
                EndDate = paintingDetails.EndDate,
                ImageURL = paintingDetails.ImageURL,
                PaintingCategory = paintingDetails.PaintingCategory,
                OrganizerId = paintingDetails.OrganizerId,
                FundRaiserId = paintingDetails.FundRaiserId,
                ArtistIds = paintingDetails.Artists_Paintings.Select(n => n.ArtistId).ToList(),
            };

            var paintingDropdownsData = await _service.GetNewPaintingDropdownsValues();
            ViewBag.Organizers = new SelectList(paintingDropdownsData.Organizers, "Id", "Name");
            ViewBag.FundRaisers = new SelectList(paintingDropdownsData.FundRaisers, "Id", "FullName");
            ViewBag.Artists = new SelectList(paintingDropdownsData.Artists, "Id", "FullName");

            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, NewPaintingVM painting)
        {
            if (id != painting.Id) return View("NotFound");

            if (!ModelState.IsValid)
            {
                var paintingDropdownsData = await _service.GetNewPaintingDropdownsValues();

                ViewBag.Organizers = new SelectList(paintingDropdownsData.Organizers, "Id", "Name");
                ViewBag.FundRaisers = new SelectList(paintingDropdownsData.FundRaisers, "Id", "FullName");
                ViewBag.Artists = new SelectList(paintingDropdownsData.Artists, "Id", "FullName");

                return View(painting);
            }

            await _service.UpdatePaintingAsync(painting);
            return RedirectToAction(nameof(Index));
        }
    }
}