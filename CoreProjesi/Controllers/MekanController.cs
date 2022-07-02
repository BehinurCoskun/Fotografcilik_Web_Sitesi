using CoreProjesi.Data;
using CoreProjesi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreProjesi.Controllers
{
    public class MekanController : Controller
    {
        private readonly FotogracilikDbContext _context;


        public MekanController(FotogracilikDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Mekan> applicants;
            
            applicants= _context.Mekans.ToList();
            return View(applicants);

        }
        [HttpGet]
        public IActionResult Create()
        {
            Mekan mekan = new Mekan();

            return View(mekan);
        }

        [HttpPost]
        public IActionResult Create(Mekan mekan)
        {
            _context.Add(mekan);
            _context.SaveChanges();
            return RedirectToAction("Index");

        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var applicant = await _context.Mekans.FindAsync(id);
            if (applicant == null)
            {
                return NotFound();
            }
            return View(applicant);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Mekanadi,il,ilce")] Mekan mekan)
        {
            //view 
            _context.Update(mekan);
            await _context.SaveChangesAsync();


            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id) //bunda view yap
        {
            if (id == 0)
            {
                return NotFound();
            }

            var user = await _context.Mekans.FirstOrDefaultAsync(m => m.Id == id);
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
            var user = await _context.Mekans.FirstOrDefaultAsync(m => m.Id == id);
            //await asenkron işlemlerde birbirini bekleme işlemi yapıyo 
            _context.Mekans.Remove(user);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }



        //public IActionResult Index()
        //{
        //    return View();
        //}
    }
}
