using LibApp.Core.Interfaces;
using LibApp.Core.Models.DTOReturns;
using LibApp.Core.Models.DTOs;
using LibApp.Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace LibApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public BooksController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var book = _unitOfWork.Books.Find(b => b.Id == id , new[] { "bookAuthors" });
            if (book == null)
                return NotFound();
            IList<Author> authors1 = new List<Author>();
            foreach (var bookAuthor in book.bookAuthors)
            {
                authors1.Add(bookAuthor.author);
            }
            BookDto bookDto = new()
            {
                Id = book.Id,
                Title = book.Title,
                Description = book.Description,
                ImageUrl = book.ImageUrl,
                BookEv = book.BookEv,
                authors = authors1
            };
            return Ok(bookDto);
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var books = _unitOfWork.Books.GetAll(new[] { "bookAuthors>author" });
            if (books.IsNullOrEmpty())
                return NotFound();
            IList<BookDto> bookDtos = new List<BookDto>();
            BookDto bookDto;
            IList<Author> authors1;
            foreach (var book in books)
            {
                authors1 = new List<Author>();
                foreach (var bookAuthor in book.bookAuthors)
                {
                    authors1.Add(bookAuthor.author);
                }
                bookDto = new()
                {
                    Id = book.Id,
                    Title = book.Title,
                    Description = book.Description,
                    ImageUrl = book.ImageUrl,
                    BookEv = book.BookEv,
                    authors = authors1
                };
                bookDtos.Add(bookDto);
            }

            return Ok(bookDtos.ToList());
        }

        [HttpGet("FindByName/{name}")]
        public IActionResult Find(string name)
        {
            var book = _unitOfWork.Books.Find(b => b.Title == name);
            if (book == null)
                return NotFound();
            IList<Author> authors1 = new List<Author>();
            foreach (var bookAuthor in book.bookAuthors)
            {
                authors1.Add(bookAuthor.author);
            }
            BookDto bookDto = new()
            {
                Id = book.Id,
                Title = book.Title,
                Description = book.Description,
                ImageUrl = book.ImageUrl,
                BookEv = book.BookEv,
                authors = authors1
            };
            return Ok(bookDto);
        }
        
        [HttpPost("Insert")]
        public IActionResult Insert(DtoBook dtoBook)
        {
            IList<Author> authors1 = new List<Author>();
            
            Book book = new()
            {
                Title = dtoBook.Title,
                Description = dtoBook.Description,
                ImageUrl = dtoBook.ImageUrl,
                BookEv = 0
            };
            _unitOfWork.Books.Insert(book);
            int cnt = _unitOfWork.Complete();
            if (cnt < 1)
                return BadRequest(new { message = "FAILED" });

            foreach (var authorId in dtoBook.AuthorIds) //Add the authors that writed the book
            {
                BookToAuthor(book.Id, authorId);
            }

            foreach (int classifyId in dtoBook.ClassifyIds) //Add the classifies of the book
            {
                BookToClassify(book.Id, classifyId);
            }
            return Ok(new { message = "SUCCEEDED" });
        }

        private bool BookToAuthor(int bookId,int authorId)
        {
            Book_Author book_Author = new()
            {
                AuthorId = authorId,
                BookId = bookId
            };
            _unitOfWork.Book_Authors.Insert(book_Author);
            int cnt = _unitOfWork.Complete();
            if (cnt > 0)
                return true;
            return false;
        }
        [HttpPost("Classific")]
        public IActionResult Classific(DtoClassification dtoClassification)
        {
            bool r = BookToClassify(dtoClassification.BookId, dtoClassification.ClassifyId);
            if (r)
                return Ok(new { message = "SUCCEEDED" });
            return BadRequest(new { message = "FAILED" });
        }
        private bool BookToClassify(int bookId,int classifyId)
        {
            Classification classification = new()
            {
                BookId = bookId,
                ClassifyId = classifyId
            };
            _unitOfWork.Classifications.Insert(classification);
            int cnt = _unitOfWork.Complete();
            if (cnt > 0)
                return true;
            return false;
        }
       
    }
}
