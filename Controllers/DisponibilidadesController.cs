using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FisioCard.Data;
using FisioCard.Models;

namespace FisioCard.Controllers
{
    public class DisponibilidadesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DisponibilidadesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Disponibilidades
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Disponibilidades.Include(d => d.Profissional);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Disponibilidades/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var disponibilidade = await _context.Disponibilidades
                .Include(d => d.Profissional)
                .FirstOrDefaultAsync(m => m.DisponibilidadeId == id);
            if (disponibilidade == null)
            {
                return NotFound();
            }

            return View(disponibilidade);
        }

        // GET: Disponibilidades/Create
        public IActionResult Create()
        {
            ViewData["ProfissionalId"] = new SelectList(_context.Profissionais, "ProfissionalId", "ProfissionalId");
            return View();
        }

        // POST: Disponibilidades/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DisponibilidadeId,ProfissionalId,DiaSemana,HoraInicio,HoraTermino")] Disponibilidade disponibilidade)
        {
            if (ModelState.IsValid)
            {
                _context.Add(disponibilidade);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProfissionalId"] = new SelectList(_context.Profissionais, "ProfissionalId", "ProfissionalId", disponibilidade.ProfissionalId);
            return View(disponibilidade);
        }

        // GET: Disponibilidades/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var disponibilidade = await _context.Disponibilidades.FindAsync(id);
            if (disponibilidade == null)
            {
                return NotFound();
            }
            ViewData["ProfissionalId"] = new SelectList(_context.Profissionais, "ProfissionalId", "ProfissionalId", disponibilidade.ProfissionalId);
            return View(disponibilidade);
        }

        // POST: Disponibilidades/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DisponibilidadeId,ProfissionalId,DiaSemana,HoraInicio,HoraTermino")] Disponibilidade disponibilidade)
        {
            if (id != disponibilidade.DisponibilidadeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(disponibilidade);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DisponibilidadeExists(disponibilidade.DisponibilidadeId))
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
            ViewData["ProfissionalId"] = new SelectList(_context.Profissionais, "ProfissionalId", "ProfissionalId", disponibilidade.ProfissionalId);
            return View(disponibilidade);
        }

        // GET: Disponibilidades/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var disponibilidade = await _context.Disponibilidades
                .Include(d => d.Profissional)
                .FirstOrDefaultAsync(m => m.DisponibilidadeId == id);
            if (disponibilidade == null)
            {
                return NotFound();
            }

            return View(disponibilidade);
        }

        // POST: Disponibilidades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var disponibilidade = await _context.Disponibilidades.FindAsync(id);
            if (disponibilidade != null)
            {
                _context.Disponibilidades.Remove(disponibilidade);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DisponibilidadeExists(int id)
        {
            return _context.Disponibilidades.Any(e => e.DisponibilidadeId == id);
        }
    }
}
