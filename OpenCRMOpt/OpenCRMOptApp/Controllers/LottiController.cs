using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OpenCRMOptApp.Controllers
{
    public class LottiController : Controller
    {
        // GET: LottiController
        public ActionResult Index()
        {
            return View();
        }

        // GET: LottiController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: LottiController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LottiController/Create
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

        // GET: LottiController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: LottiController/Edit/5
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

        // GET: LottiController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: LottiController/Delete/5
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
