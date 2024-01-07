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
    public class OwnersController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public OwnersController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Owners
        public async Task<IActionResult> Index()
        {
            IdentityUser user = _userManager.FindByNameAsync(User.Identity.Name).Result;
            var applicationDbContext = _context.Owner
                .Include(o => o.Animal)
                .Include(o => o.User)
                .Where(x=> x.User.Id == user.Id);
            return View(await applicationDbContext.Include(u=>u.User).Where(x => x.User.Id == user.Id).ToListAsync());
        }

        // GET: Owners/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var owner = await _context.Owner
                .Include(o => o.Animal)
                .Include(o => o.User)
                .FirstOrDefaultAsync(m => m.OwnerId == id);
            if (owner == null)
            {
                return NotFound();
            }

            return View(owner);
        }

        // GET: Owners/Create
        public async Task<IActionResult> Create()
        {
            ViewData["AnimalId"] = new SelectList(_context.Animal.Where(a => a.ForAdoption), "AnimalId", "Name");
            return View();
        }

        // POST: Owners/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OwnerId,OwnerName,AdoptionTime,AnimalId")] Owner owner)
        {
            IdentityUser user = _userManager.FindByNameAsync(User.Identity.Name).Result;
            owner.UserId = user.Id;

            if (ModelState.IsValid)
            {
                Animal animalToUpdate = await _context.Animal.FindAsync(owner.AnimalId);

                if (animalToUpdate != null)
                {
                    animalToUpdate.ForAdoption = false;
                    _context.Add(owner);
                    await _context.SaveChangesAsync();

                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Animal not found.");
                }
            }

            return View(owner);
        }


        // GET: Owners/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var owner = await _context.Owner.FindAsync(id);
            if (owner == null)
            {
                return NotFound();
            }
            ViewData["AnimalId"] = new SelectList(_context.Animal.Where(a => a.ForAdoption), "AnimalId", "Name", owner.AnimalId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "OwnerName", owner.UserId);
            return View(owner);
        }

        // POST: Owners/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OwnerId,OwnerName,AdoptionTime")] Owner owner)
        {
            if (id != owner.OwnerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(owner);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OwnerExists(owner.OwnerId))
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
            ViewData["AnimalId"] = new SelectList(_context.Animal, "AnimalId", "Name", owner.AnimalId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "OwnerName", owner.UserId);
            return View(owner);
        }

        // GET: Owners/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var owner = await _context.Owner
                .Include(o => o.Animal)
                .Include(o => o.User)
                .FirstOrDefaultAsync(m => m.OwnerId == id);
            if (owner == null)
            {
                return NotFound();
            }

            return View(owner);
        }

        // POST: Owners/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var owner = await _context.Owner
                .Include(o => o.Animal)  // Dodaj Include, aby załadować dane zwierzęcia
                .FirstOrDefaultAsync(m => m.OwnerId == id);

            if (owner != null)
            {
                Animal animal = owner.Animal;

                if (animal != null)
                {
                    animal.ForAdoption = true;
                    _context.Owner.Remove(owner);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Animal not found for the owner.");
                }
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Owner not found.");
            }

            return RedirectToAction(nameof(Index));
        }


        private bool OwnerExists(int id)
        {
            return _context.Owner.Any(e => e.OwnerId == id);
        }
    }
}
