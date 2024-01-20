using MedicalJournalApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace MedicalJournalApp.Components
{
    public class NavigationMenuViewComponent : ViewComponent
    {
        private IArticleRepository repository;

        public NavigationMenuViewComponent(IArticleRepository repo)
        {
            repository = repo;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedCategory = RouteData?.Values["category"];
            return View(repository.Articles
                .Select(a => a.Category)
                .Distinct()
                .OrderBy(a => a));
        }
    }
}
