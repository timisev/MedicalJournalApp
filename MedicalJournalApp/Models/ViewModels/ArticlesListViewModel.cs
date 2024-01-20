namespace MedicalJournalApp.Models.ViewModels
{
    public class ArticlesListViewModel
    {
        public IEnumerable<Article> Articles { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public string CurrentCategory { get; set; }
    }
}
