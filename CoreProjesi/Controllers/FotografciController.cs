using CoreProjesi.Data;
using CoreProjesi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreProjesi.Controllers
{
    public class FotografciController : Controller
    {
        private readonly FotogracilikDbContext _context;


        public FotografciController(FotogracilikDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Fotografci> applicants;
            applicants = _context.Fotografcis.ToList();
            return View(applicants);

        }


        [HttpGet]
        public IActionResult Create()
        {
            Fotografci fotografci = new Fotografci();

            return View(fotografci);
        }

        [HttpPost]
        public IActionResult Create(Fotografci fotografci)
        {
            _context.Add(fotografci);
            _context.SaveChanges();
            return RedirectToAction("Index");

        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var applicant = await _context.Fotografcis.FindAsync(id);
            if (applicant == null)
            {
                return NotFound();
            }
            return View(applicant);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,AdSoyad,Cinsiyet,Maas")] Fotografci fotografci)
        {
            //view 
            _context.Update(fotografci);
            await _context.SaveChangesAsync();


            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id) //bunda view yap
        {
            if (id == 0)
            {
                return NotFound();
            }

            var user = await _context.Fotografcis.FirstOrDefaultAsync(m => m.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {//metodun ismi deleteconfired gürunuyo amam gercekte ismi delete 
            var user = await _context.Fotografcis.FirstOrDefaultAsync(m => m.Id == id);
            //await asenkron işlemlerde birbirini bekleme işlemi yapıyo 
            _context.Fotografcis.Remove(user);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }




    }
}
