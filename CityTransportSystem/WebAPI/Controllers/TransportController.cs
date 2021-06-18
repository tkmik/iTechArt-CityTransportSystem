using AutoMapper;
using DataAccess.Entities;
using DataAccess.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TransportController : ControllerBase
    {
        private readonly IRepository<Transport> _transportRepository;
        private readonly IMapper _mapper;

        public TransportController(IRepository<Transport> repo, IMapper mapper)
        {
            _transportRepository = repo;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetTransports()
        {
            return new JsonResult(_transportRepository.GetList());
        }
    }
}
