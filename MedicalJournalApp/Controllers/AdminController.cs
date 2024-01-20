using Microsoft.AspNetCore.Mvc;
using MedicalJournalApp.Models; 
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore.Storage;

namespace MedicalJournalApp.Controllers
{
    public class AdminController : Controller
    {
        private IArticleRepository repository;

        public AdminController(IArticleRepository repo)
        {
            repository = repo;
        }

        public ViewResult Index() => View(repository.Articles);

        public ViewResult Edit(int id) =>
            View(repository.Articles.FirstOrDefault(a => a.Id == id));

        [HttpPost]
        public IActionResult Edit(Article article)
        {
            if (ModelState.IsValid)
            {
                repository.SaveArticle(article);
                TempData["message"] = $"The article was successfully added";
                return RedirectToAction("Index");
            }
            else
            {
                return View(article);
            }
        }

        public ViewResult Create() => View("Edit", new Article());

        [HttpPost]
        public IActionResult Delete(int articleId)
        {
            Article deleteArticle = repository.DeleteArticle(articleId);
            if( deleteArticle != null)
            {
                TempData["message"] = $"{deleteArticle.Name} was deleted";
            }
            return RedirectToAction("index");
        }
    }
}