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
    public class HistoricoMedicosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HistoricoMedicosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: HistoricoMedicos
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.HistoricoMedico.Include(h => h.Cliente);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: HistoricoMedicos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var historicoMedico = await _context.HistoricoMedico
                .Include(h => h.Cliente)
                .FirstOrDefaultAsync(m => m.HistoricoMedicoId == id);
            if (historicoMedico == null)
            {
                return NotFound();
            }

            return View(historicoMedico);
        }

        // GET: HistoricoMedicos/Create
        public IActionResult Create()
        {
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "ClienteId", "ClienteId");
            return View();
        }

        // POST: HistoricoMedicos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("HistoricoMedicoId,ClienteId,Data,Descricao")] HistoricoMedico historicoMedico)
        {
            if (ModelState.IsValid)
            {
                _context.Add(historicoMedico);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "ClienteId", "ClienteId", historicoMedico.ClienteId);
            return View(historicoMedico);
        }

        // GET: HistoricoMedicos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var historicoMedico = await _context.HistoricoMedico.FindAsync(id);
            if (historicoMedico == null)
            {
                return NotFound();
            }
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "ClienteId", "ClienteId", historicoMedico.ClienteId);
            return View(historicoMedico);
        }

        // POST: HistoricoMedicos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("HistoricoMedicoId,ClienteId,Data,Descricao")] HistoricoMedico historicoMedico)
        {
            if (id != historicoMedico.HistoricoMedicoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(historicoMedico);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HistoricoMedicoExists(historicoMedico.HistoricoMedicoId))
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
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "ClienteId", "ClienteId", historicoMedico.ClienteId);
            return View(historicoMedico);
        }

        // GET: HistoricoMedicos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var historicoMedico = await _context.HistoricoMedico
                .Include(h => h.Cliente)
                .FirstOrDefaultAsync(m => m.HistoricoMedicoId == id);
            if (historicoMedico == null)
            {
                return NotFound();
            }

            return View(historicoMedico);
        }

        // POST: HistoricoMedicos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var historicoMedico = await _context.HistoricoMedico.FindAsync(id);
            if (historicoMedico != null)
            {
                _context.HistoricoMedico.Remove(historicoMedico);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HistoricoMedicoExists(int id)
        {
            return _context.HistoricoMedico.Any(e => e.HistoricoMedicoId == id);
        }
    }
}
