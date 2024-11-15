using FilmyApp.Models;
using Microsoft.AspNetCore.Mvc;


namespace FilmyApp.Controllers
{
    public class FilmController : Controller
    {
        private static IList<Film> films = new List<Film>
        {
            new Film { Id = 1, Name = "Film1", Description = "Opis1", Price = 4 },
            new Film { Id = 2, Name = "Film2", Description = "Opis2", Price = 5 },
            new Film { Id = 3, Name = "Film3", Description = "Opis3", Price = 6 },
        };

        // GET: FilmController
        public ActionResult Index()
        {
            return View(films);
        }

        // GET: FilmController/Details/5
        public ActionResult Details(int id)
        {
            return View(films.FirstOrDefault(x => x.Id == id));
        }

        // GET: FilmController/Create
        public ActionResult Create()
        {
            return View(new Film());
        }

        // POST: FilmController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Film film)
        {
            film.Id = films.Count + 1;
            films.Add(film);
            return RedirectToAction(nameof(Index));

        }

        // GET: FilmController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(films.FirstOrDefault(x => x.Id == id));
        }

        // POST: FilmController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Film film)
        {
            Film filmm = films.FirstOrDefault(x => x.Id == id);
            filmm.Name = film.Name;
            filmm.Description = film.Description;
            filmm.Price = film.Price;
            return RedirectToAction(nameof(Index));
        }

        // GET: FilmController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(films.FirstOrDefault(x => x.Id == id));
        }

        // POST: FilmController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Film film)
        {
            Film filmm = films.FirstOrDefault(x => x.Id == id);
            films.Remove(filmm);
            return RedirectToAction(nameof(Index));
        }
    }
}
