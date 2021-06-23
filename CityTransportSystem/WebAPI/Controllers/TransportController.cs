using AutoMapper;
using DataAccess.Entities;
using DataAccess.Interfaces;
using DataAccess.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TransportController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TransportController(IUnitOfWork unit, IMapper mapper)
        {
            _unitOfWork = unit;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetTransports()
        {
            return new JsonResult(_unitOfWork.TransportRepository.GetAll());
        }
    }
}
