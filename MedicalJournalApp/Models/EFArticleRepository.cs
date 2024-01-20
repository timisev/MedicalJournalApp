using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace MedicalJournalApp.Models
{
    public class EFArticleRepository : IArticleRepository
    {
        private ArticleContext context;

        public EFArticleRepository(ArticleContext ctx)
        {
            context = ctx;
        }

        public IQueryable<Article> Articles => context.Articles;

        public void SaveArticle(Article article)
        {
            if (article.Id == 0)
            {
                context.Articles.Add(article);
            }
            else
            {
                Article dbEntry = context.Articles.FirstOrDefault(a => a.Id == article.Id);
                if (dbEntry != null)
                {
                    dbEntry.Name = article.Name;
                    dbEntry.Text = article.Text;
                    dbEntry.Author = article.Author;
                }
            }
            context.SaveChanges();
        }

        public Article DeleteArticle(int articleId)
        {
            Article dbEntry = context.Articles.FirstOrDefault(a => a.Id == a.Id);

            if (dbEntry != null)
            {
                context.Articles.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }
    }
}
