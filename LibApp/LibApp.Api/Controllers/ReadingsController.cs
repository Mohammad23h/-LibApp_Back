using LibApp.Core.Interfaces;
using LibApp.Core.Models;
using LibApp.Core.Models.DTOReturns;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

namespace LibApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReadingsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public ReadingsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var reading = _unitOfWork.Readings.Find(b => b.Id == id , new[] {"reader"});
            if (reading == null)
                return NotFound(new { message = "there aren't any reading have this Id" });
            ReadingDto readingDto = new()
            {
                Id = id,
                BookId = reading.BookId,
                book = reading.book,
                ReaderId = reading.ReaderId,
                ReaderName = reading.reader.UserName,
                PublishDate = reading.PublishDate
            };
            return Ok(readingDto);
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var readings = _unitOfWork.Readings.GetAll(new[] {"reader"});
            if (readings.IsNullOrEmpty())
                return NotFound();
            ReadingDto readingDto;
            IList<ReadingDto> readingDtos = new List<ReadingDto>();
            foreach (var reading in readings)
            {
                readingDto = new()
                {
                    Id = reading.Id,
                    BookId = reading.BookId,
                    book = reading.book,
                    ReaderId = reading.ReaderId,
                    ReaderName = reading.reader.UserName,
                    PublishDate = reading.PublishDate
                };
                readingDtos.Add(readingDto); 
            }
            return Ok(readingDtos);
        }

        [HttpPost("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            Reading reading = _unitOfWork.Readings.GetById(id);
            _unitOfWork.Readings.Delete(reading);
            int c = _unitOfWork.Complete();
            if (c != 0)
                return Ok(new { message = "the reading has been deleted" });
            return BadRequest(new { message = "An Error has been occurd" });
        }

        [HttpPost("AddReading/{bookId}")]
        public IActionResult AddReading(int bookId)
        {
            if (!User.IsInRole(RoleName.Reader))
                return Unauthorized(new { message = "you aren't reader" });
            var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            bool result = LestenBook(userId, bookId);
            if (result)
                return Ok(new { message = " the insert function has been succeeded" });
            return BadRequest(new { message = "FAILED" });
        }


        [Authorize]
        [HttpGet("MyReadings")]
        public IActionResult GetMyReadings()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var readings = _unitOfWork.Readings.FindAll(b => b.ReaderId == userId , new[] {"reader"});
            var readingDtos = new List<ReadingDto>();
            ReadingDto readingDto;
            foreach (var reading in readings)
            {
                readingDto = new()
                {
                    Id = reading.Id,
                    BookId = reading.BookId,
                    book = reading.book,
                    ReaderId = userId,
                    ReaderName = User.FindFirst(ClaimTypes.Name).Value,
                    PublishDate = reading.PublishDate
                };
                readingDtos.Add(readingDto);
            }
            if (!readingDtos.IsNullOrEmpty())
                return Ok(readingDtos);
            return NotFound(new { message = "therer aren't any book that you had read it" });
        }

        /*
         * *****************************************this section for private functions**************************************************
         */
        private bool LestenBook(string userId,int bookId)
        {
            Reading reading = new()
            {
                ReaderId = userId,
                BookId = bookId
            };
            _unitOfWork.Readings.Insert(reading);
            int c = _unitOfWork.Complete();
            if (c > 0)
                return true;
            return false;
        }


    }
}
