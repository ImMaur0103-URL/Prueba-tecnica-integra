using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Prueba_Tecnica_Integra.Data;
using Prueba_Tecnica_Integra.Models;

namespace Prueba_Tecnica_Integra.Controllers
{
    public class SupplierManagement : Controller
    {
        private readonly PruebaTecnicaIntegraContext _context;

        public SupplierManagement(PruebaTecnicaIntegraContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var proveedores = await _context.T_PROVEEDOR
                .Include(p => p.GrupoProveedor)
                .ToListAsync();
            return View(proveedores);
        }

        // GET: SupplierManagement/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SupplierManagement/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SupplierManagement/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SupplierManagement/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SupplierManagement/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SupplierManagement/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SupplierManagement/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
