using Microsoft.AspNetCore.Mvc;
using pract01.Models;
using pract01.Data;
using System.Linq;

namespace pract01.Controllers
{
    public class VideoGameController:Controller
    {
        private readonly ApplicationDbContext _context;

        public VideoGameController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            
            return View(_context.DataVideoGames.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(VideoGame objVideoGame)
        {
            _context.Add(objVideoGame);
            _context.SaveChanges();
            ViewData["Message"] = "El VideoJuego ya esta registrado";
            return View();
        }

        
        public IActionResult Edit(int id)
        {
            VideoGame objVideoGame = _context.DataVideoGames.Find(id);
            if(objVideoGame == null){
                return NotFound();
            }
            return View(objVideoGame);
        }

        [HttpPost]
        public IActionResult Edit(int id,[Bind("Id,Name,Categoria,Precio,Descuento")] VideoGame objVideoGame)
        {
             _context.Update(objVideoGame);
             _context.SaveChanges();
              ViewData["Message"] = "El registro de actualizo";
             return View(objVideoGame);
        }

        public IActionResult Delete(int id)
        {
            VideoGame objVideoGame = _context.DataVideoGames.Find(id);
            _context.DataVideoGames.Remove(objVideoGame);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}