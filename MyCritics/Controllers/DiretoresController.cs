using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCritics.Controllers {
    public class DiretoresController : Controller {
        // GET: DiretoresController
        public ActionResult Index() {
            return View();
        }

        // GET: DiretoresController/Details/5
        public ActionResult Details(int id) {
            return View();
        }

        // GET: DiretoresController/Create
        public ActionResult Create() {
            return View();
        }

        // POST: DiretoresController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection) {
            try {
                return RedirectToAction(nameof(Index));
            }
            catch {
                return View();
            }
        }

        // GET: DiretoresController/Edit/5
        public ActionResult Edit(int id) {
            return View();
        }

        // POST: DiretoresController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection) {
            try {
                return RedirectToAction(nameof(Index));
            }
            catch {
                return View();
            }
        }

        // GET: DiretoresController/Delete/5
        public ActionResult Delete(int id) {
            return View();
        }

        // POST: DiretoresController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection) {
            try {
                return RedirectToAction(nameof(Index));
            }
            catch {
                return View();
            }
        }
    }
}
