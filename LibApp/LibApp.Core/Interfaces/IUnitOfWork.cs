using LibApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibApp.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IBaseRepository<Author> Authors { get; }
        IBaseRepository<Book_Author> Book_Authors { get; }
        IBaseRepository<Book> Books { get; }
        IBaseRepository<Classify> Classifies { get; }
        IBaseRepository<Classification> Classifications { get; }
        IBaseRepository<AuthorComment> AuthorComments { get; }
        IBaseRepository<AuthorReview> AuthorReviews { get; }
        IBaseRepository<BookComment> BookComments { get; }
        IBaseRepository<BookReview> BookReviews { get; }
        IBaseRepository<Lestening> Lestenings { get; }
        IBaseRepository<Reading> Readings { get; }
        IBaseRepository<Tab> Tabs { get; }
        IBaseRepository<Voice> Voices { get; }
        IBaseRepository<Voice_Tab> Voice_Tabs { get; }
        int Complete();
    }
}
