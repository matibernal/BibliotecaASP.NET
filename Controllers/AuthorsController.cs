using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BibliotecaAsp.Data;
using BibliotecaAsp.Models;

namespace BibliotecaAsp.Controllers
{
    public class AuthorsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AuthorsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Authors
        public async Task<IActionResult> Index(string sortOrder)
        {
            // Parametros de orden x cada columna
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) || sortOrder == "name_asc"
                ? "name_desc" : "name_asc";
            ViewData["SurnameSortParm"] = sortOrder == "surname_asc"
                ? "surname_desc" : "surname_asc";
            ViewData["DateSortParm"] = sortOrder == "date_asc"
                ? "date_desc" : "date_asc";

            var authors = _context.Authors.AsQueryable();

            authors = sortOrder switch
            {
                "name_desc" => authors.OrderByDescending(a => a.Name),
                "name_asc" => authors.OrderBy(a => a.Name),
                "surname_desc" => authors.OrderByDescending(a => a.Surname),
                "surname_asc" => authors.OrderBy(a => a.Surname),
                "date_desc" => authors.OrderByDescending(a => a.DateOfBirth),
                "date_asc" => authors.OrderBy(a => a.DateOfBirth),
                _ => authors.OrderBy(a => a.Name),  
            };

            return View(await authors.AsNoTracking().ToListAsync());
        }

        // GET: Authors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var author = await _context.Authors
                .Include(a => a.Books)              
                .FirstOrDefaultAsync(m => m.Id == id);

            if (author == null) return NotFound();
            return View(author);
        }


        // GET: Authors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Authors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Author author)
        {
            // VERIFICAR STATE
            Console.WriteLine($"Name recibido: '{author.Name}'");
            Console.WriteLine($"ModelState válido? {ModelState.IsValid}");
            foreach (var e in ModelState.Values.SelectMany(v => v.Errors))
                Console.WriteLine("  Error: " + e.ErrorMessage);

            if (!ModelState.IsValid)
                return View(author);

            _context.Authors.Add(author);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }



        // GET: Authors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var author = await _context.Authors.FindAsync(id);
            if (author == null)
            {
                return NotFound();
            }
            return View(author);
        }

        // POST: Authors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Surname,DateOfBirth")] Author author)
        {
            if (id != author.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(author);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AuthorExists(author.Id))
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
            return View(author);
        }

        // GET: Authors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var author = await _context.Authors
                .FirstOrDefaultAsync(m => m.Id == id);
            if (author == null)
            {
                return NotFound();
            }

            return View(author);
        }

        // POST: Authors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var author = await _context.Authors.FindAsync(id);
            if (author != null)
            {
                _context.Authors.Remove(author);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AuthorExists(int id)
        {
            return _context.Authors.Any(e => e.Id == id);
        }
    }
}
