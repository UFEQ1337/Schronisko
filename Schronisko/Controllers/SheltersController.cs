using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Schronisko.Data;
using Schronisko.Models;

namespace Schronisko.Controllers
{
    [Authorize]
    public class SheltersController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public SheltersController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Shelters
        public async Task<IActionResult> Index()
        {
            IdentityUser user = _userManager.FindByNameAsync(User.Identity.Name).Result;
            return View(await _context.Shelter
                .Where(x=>x.User.Id==user.Id)
                .ToListAsync());
        }

        // GET: Shelters/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shelter = await _context.Shelter
                .FirstOrDefaultAsync(m => m.ShelterId == id);
            if (shelter == null)
            {
                return NotFound();
            }

            return View(shelter);
        }

        // GET: Shelters/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Shelters/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ShelterId,ShelterName,ShelterAddress")] Shelter shelter)
        {
            IdentityUser user = _userManager.FindByNameAsync(User.Identity.Name).Result;
            shelter.UserId = user.Id;
            if (ModelState.IsValid)
            {
                _context.Add(shelter);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(shelter);
        }

        // GET: Shelters/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            IdentityUser user = _userManager.FindByNameAsync(User.Identity.Name).Result;
            
            if (id == null)
            {
                return NotFound();
            }

            var shelter = await _context.Shelter.FindAsync(id);
            shelter.UserId = user.Id;
            if (shelter == null)
            {
                return NotFound();
            }
            return View(shelter);
        }

        // POST: Shelters/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ShelterId,ShelterName,ShelterAddress")] Shelter shelter)
        {
            IdentityUser user = _userManager.FindByNameAsync(User.Identity.Name).Result;
            shelter.UserId = user.Id;
            if (id != shelter.ShelterId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(shelter);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ShelterExists(shelter.ShelterId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(shelter);
        }

        // GET: Shelters/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shelter = await _context.Shelter
                .FirstOrDefaultAsync(m => m.ShelterId == id);
            if (shelter == null)
            {
                return NotFound();
            }

            return View(shelter);
        }

        // POST: Shelters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var shelter = await _context.Shelter.FindAsync(id);
            if (shelter != null)
            {
                _context.Shelter.Remove(shelter);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ShelterExists(int id)
        {
            return _context.Shelter.Any(e => e.ShelterId == id);
        }
    }
}
