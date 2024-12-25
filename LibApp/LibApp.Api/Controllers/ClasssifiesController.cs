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
    public class ClasssifiesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public ClasssifiesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var classify = _unitOfWork.Classifies.GetById(id);
            if (classify == null)
                return NotFound();
            return Ok(classify);
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var classifies = _unitOfWork.Classifies.GetAll();
            if (classifies.IsNullOrEmpty())
                return NotFound();
            return Ok(classifies);
        }

        [HttpGet("FindByName/{name}")]
        public IActionResult Find(string name)
        {
            var classify = _unitOfWork.Classifies.Find(b => b.Title == name);
            if (classify == null)
                return NotFound();
            return Ok(classify);
        }

        [HttpPost("Insert")]
        public IActionResult Insert(DtoClassify dtoClassify)
        {
            Classify classify = new()
            {
                Title = dtoClassify.Title
            };
            _unitOfWork.Classifies.Insert(classify);
            int cnt = _unitOfWork.Complete();
            if (cnt < 1)
                return BadRequest(new { message = "FAILED" });
            return Ok(new { message = "SUCCEEDED" });
        }

    }
}
