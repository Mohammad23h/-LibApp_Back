using LibApp.Core.Interfaces;
using LibApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibApp.EF
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public IBaseRepository<Author> Authors { get; private set; }
        public IBaseRepository<Book> Books { get; private set; }
        public IBaseRepository<Book_Author> Book_Authors { get; private set; }
        public IBaseRepository<Classify> Classifies { get; private set; }
        public IBaseRepository<Classification> Classifications { get; private set; }
        public IBaseRepository<AuthorComment> AuthorComments { get; private set; }
        public IBaseRepository<AuthorReview> AuthorReviews { get; private set; }
        public IBaseRepository<BookComment> BookComments { get; private set; }
        public IBaseRepository<BookReview> BookReviews { get; private set; }
        public IBaseRepository<Lestening> Lestenings { get; private set; }
        public IBaseRepository<Reading> Readings { get; private set; }
        public IBaseRepository<Tab> Tabs { get; private set; }
        public IBaseRepository<Voice> Voices { get; private set; }
        public IBaseRepository<Voice_Tab> Voice_Tabs { get; private set; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;

            Authors = new BaseRepository<Author>(_context);
            Books = new BaseRepository<Book>(_context);
            Book_Authors = new BaseRepository<Book_Author>(_context);
            Classifies = new BaseRepository<Classify>(_context);
            Classifications = new BaseRepository<Classification>(_context);
            AuthorComments = new BaseRepository<AuthorComment>(_context);
            AuthorReviews = new BaseRepository<AuthorReview>(_context);
            BookComments = new BaseRepository<BookComment>(_context);
            BookReviews = new BaseRepository<BookReview>(_context);
            Lestenings = new BaseRepository<Lestening>(_context);
            Readings = new BaseRepository<Reading>(_context);
            Tabs = new BaseRepository<Tab>(_context);
            Voices = new BaseRepository<Voice>(_context);
            Tabs = new BaseRepository<Tab>(_context);
            Voice_Tabs = new BaseRepository<Voice_Tab>(_context);
        }

        public int Complete()
        {
            return _context.SaveChanges();
        }


        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
