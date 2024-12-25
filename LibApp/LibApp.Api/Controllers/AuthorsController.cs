using LibApp.Core.Interfaces;
using LibApp.Core.Models;
using LibApp.Core.Models.DTOReturns;
using LibApp.Core.Models.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace LibApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public AuthorsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id) {
            var author = _unitOfWork.Authors.Find(b => b.Id == id);
            if (author == null)
                return NotFound();
            AuthorDto authorDto = new()
            {
                Id = author.Id,
                Name = author.Name
            };
            return Ok(authorDto);
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var authors = _unitOfWork.Authors.GetAll();
            if (authors.IsNullOrEmpty())
                return NotFound();
            IList<AuthorDto> authorDtos = new List<AuthorDto>();
            AuthorDto authorDto;
            foreach (var author in authors)
            {
                authorDto = new()
                {
                    Id = author.Id,
                    Name = author.Name
                };
                authorDtos.Add(authorDto);
            }
            
            return Ok(authorDtos.ToList());
        }

        [HttpGet("FindByName/{name}")]
        public IActionResult Find(string name)
        {
            var author = _unitOfWork.Authors.Find(b => b.Name == name);
            if (author == null)
                return NotFound();
            AuthorDto authorDto = new()
            {
                Id = author.Id,
                Name = author.Name
            };
            return Ok(authorDto);
        }

        [HttpPost("Insert")]
        public IActionResult Insert(DtoAuthor dtoAuthor)
        {
            Author author = new()
            {
                Name = dtoAuthor.Name
            };
            _unitOfWork.Authors.Insert(author);
            int cnt = _unitOfWork.Complete();
            if (cnt > 0)
                return Ok(new {message = "SUCCEEDED"});
            return BadRequest(new {message = "FAILED"});
        }

        [HttpGet("{id}/Books")]
        public IActionResult GetAuthorBooks(int id)
        {
            var bookAuthors = _unitOfWork.Book_Authors.FindAll(b => b.BookId == id, new[]{ "book"});
            IList<Book> books = new List<Book>();
            if (bookAuthors == null)
                return NotFound();
            foreach (var bookAuthor in bookAuthors)
            {
                books.Add(bookAuthor.book);
            }
            return Ok(books);
        }
    }
}
