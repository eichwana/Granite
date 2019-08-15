using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraniteHouse.Data;
using GraniteHouse.Models;
using Microsoft.AspNetCore.Mvc;

namespace GraniteHouse.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SpecialTagsController : Controller
    {

        private readonly ApplicationDbContext _db;

        public SpecialTagsController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View(_db.SpecialTags.ToList());
        }


        //Get create action method
        public IActionResult Create()
        {
            return View();
        }

        //POST create action method
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SpecialTags SpecialTags)
        {
            if (ModelState.IsValid)
            {
                _db.Add(SpecialTags);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(SpecialTags);
        }



        //Get: edit action method
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var SpecialTag = await _db.SpecialTags.FindAsync(id);
            if (SpecialTag == null)
            {
                return NotFound();
            }

            return View(SpecialTag);
        }

        //POST: edit action method
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, SpecialTags SpecialTags)
        {
            if (id != SpecialTags.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _db.Update(SpecialTags);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(SpecialTags);
        }



        //Get: details action method
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var SpecialTag = await _db.SpecialTags.FindAsync(id);
            if (SpecialTag == null)
            {
                return NotFound();
            }

            return View(SpecialTag);
        }


        //Get: delete action method
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var SpecialTag = await _db.SpecialTags.FindAsync(id);
            if (SpecialTag == null)
            {
                return NotFound();
            }

            return View(SpecialTag);
        }

        //POST: Delete action method
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {

            var SpecialTags = await _db.SpecialTags.FindAsync(id);

            _db.SpecialTags.Remove(SpecialTags);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));


        }

    }
}