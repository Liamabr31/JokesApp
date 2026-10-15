using JokesApp.Data;
using JokesApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JokesApp.Controllers
{
    public class JokesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public JokesController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Joke.ToListAsync());
        }

        public IActionResult ShowSearchForm()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ShowSearchResults(string SearchPhrase)
        {
            if (string.IsNullOrWhiteSpace(SearchPhrase))
            {
                return RedirectToAction(nameof(Index));
            }

            var results = await _context.Joke
                .Where(j => j.JokeQuestion.Contains(SearchPhrase) ||
                            j.JokeAnswer.Contains(SearchPhrase))
                .ToListAsync();

            return View("Index", results);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var joke = await _context.Joke
                .FirstOrDefaultAsync(m => m.Id == id);

            if (joke == null)
            {
                return NotFound();
            }

            return View(joke);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Joke joke)
        {
            if (ModelState.IsValid)
            {
                _context.Add(joke);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(joke);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var joke = await _context.Joke.FindAsync(id);

            if (joke == null)
            {
                return NotFound();
            }

            return View(joke);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Joke joke)
        {
            if (id != joke.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.Update(joke);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(joke);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var joke = await _context.Joke
                .FirstOrDefaultAsync(m => m.Id == id);

            if (joke == null)
            {
                return NotFound();
            }

            return View(joke);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var joke = await _context.Joke.FindAsync(id);

            if (joke != null)
            {
                _context.Joke.Remove(joke);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
