namespace MedicalJournalApp.Models
{
    public interface IArticleRepository
    {
        IQueryable<Article> Articles { get; }
        void SaveArticle(Article article);
        Article DeleteArticle(int articleId);
    }
}
