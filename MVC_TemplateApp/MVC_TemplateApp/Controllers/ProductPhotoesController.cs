using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC_TemplateApp.Models;

namespace MVC_TemplateApp.Controllers
{
    public class ProductPhotoesController : Controller
    {
        private readonly MvcDbContext _context;

        public ProductPhotoesController(MvcDbContext context)
        {
            _context = context;
        }

        // GET: ProductPhotoes
        public async Task<IActionResult> Index()
        {
            var mvcDbContext = _context.ProductPhotos.Include(p => p.Product);
            return View(await mvcDbContext.ToListAsync());
        }

        // GET: ProductPhotoes/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.ProductPhotos == null)
            {
                return NotFound();
            }

            var productPhoto = await _context.ProductPhotos
                .Include(p => p.Product)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (productPhoto == null)
            {
                return NotFound();
            }

            return View(productPhoto);
        }

        // GET: ProductPhotoes/Create
        public IActionResult Create()
        {
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Id");
            return View();
        }

        // POST: ProductPhotoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ProductId,Url")] ProductPhoto productPhoto)
            {
            if (ModelState.IsValid)
            {
                productPhoto.Id = Guid.NewGuid();
                _context.Add(productPhoto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Id", productPhoto.ProductId);
            return View(productPhoto);
        }

        // GET: ProductPhotoes/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.ProductPhotos == null)
            {
                return NotFound();
            }

            var productPhoto = await _context.ProductPhotos.FindAsync(id);
            if (productPhoto == null)
            {
                return NotFound();
            }
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Id", productPhoto.ProductId);
            return View(productPhoto);
        }

        // POST: ProductPhotoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,ProductId,Url")] ProductPhoto productPhoto)
        {
            if (id != productPhoto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(productPhoto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductPhotoExists(productPhoto.Id))
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
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Id", productPhoto.ProductId);
            return View(productPhoto);
        }

        // GET: ProductPhotoes/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.ProductPhotos == null)
            {
                return NotFound();
            }

            var productPhoto = await _context.ProductPhotos
                .Include(p => p.Product)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (productPhoto == null)
            {
                return NotFound();
            }

            return View(productPhoto);
        }

        // POST: ProductPhotoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.ProductPhotos == null)
            {
                return Problem("Entity set 'MvcDbContext.ProductPhotos'  is null.");
            }
            var productPhoto = await _context.ProductPhotos.FindAsync(id);
            if (productPhoto != null)
            {
                _context.ProductPhotos.Remove(productPhoto);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductPhotoExists(Guid id)
        {
          return _context.ProductPhotos.Any(e => e.Id == id);
        }
    }
}
