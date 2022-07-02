using CoreProjesi.Data;
using CoreProjesi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreProjesi.Controllers
{
    public class MusteriController : Controller
    {

        private readonly FotogracilikDbContext _context;

        public MusteriController(FotogracilikDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {

            List<Musteri> applicants;
            applicants = _context.Musteris.ToList();
            return View(applicants);

        }

        [HttpGet]
        public IActionResult Create()
        {
            Musteri musteri = new Musteri();

            return View(musteri);
        }

        [HttpPost]
        public IActionResult Create(Musteri musteri)
        {
            _context.Add(musteri);
            _context.SaveChanges();
            return RedirectToAction("Index");

        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var applicant = await _context.Musteris.FindAsync(id);
            if (applicant == null)
            {
                return NotFound();
            }
            return View(applicant);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,AdSoyad,Cinsiyet,Tur")] Musteri musteri)
        {
            //view 
            _context.Update(musteri);
            await _context.SaveChangesAsync();


            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> Delete(int id) //bunda view yap
        {
            if (id == 0)
            {
                return NotFound();
            }

            var user = await _context.Musteris.FirstOrDefaultAsync(m => m.Id == id);
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
            var user = await _context.Musteris.FirstOrDefaultAsync(m => m.Id == id);
            //await asenkron işlemlerde birbirini bekleme işlemi yapıyo 
            _context.Musteris.Remove(user);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        
    }
}
