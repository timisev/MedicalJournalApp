using Microsoft.AspNetCore.Mvc;
using MedicalJournalApp.Models;
using MedicalJournalApp.Models.ViewModels;

namespace MedicalJournalapp.controllers
{
    public class HomeController : Controller
    {
        private IArticleRepository repository;
        public int PageSize = 4;

        public HomeController(IArticleRepository repo)
        {
            repository = repo;
        }

        public ViewResult Index(string category, int articlePage = 1)
        {
            return View(new ArticlesListViewModel
            {
                Articles = repository.Articles
                    .Where(a => category == null || a.Category == category)
                    .OrderBy(a => a.Id)
                    .Skip((articlePage - 1) * PageSize)
                    .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = articlePage,
                    ItemsPerPage = PageSize,
                    TotalItems = category == null ?
                        repository.Articles.Count() :
                        repository.Articles.Where(a =>
                            a.Category == category).Count()
                },
                CurrentCategory = category
            });
        }

        public IActionResult Detail(int Id)
            => View(repository.Articles.FirstOrDefault(a => a.Id == Id));

        public async Task<IActionResult> Search(string name)
            => View(repository.Articles.Where(a => a.Name == name));
    }
}