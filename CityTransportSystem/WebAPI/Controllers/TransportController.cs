using AutoMapper;
using CTSCore.EF;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CTSWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TransportController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;
        private readonly IMapper _mapper;

        public TransportController(AppDbContext appDbContext, IMapper mapper)
        {
            _appDbContext = appDbContext;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetTransports()
        {
            return new JsonResult(await _appDbContext.Transport.ToListAsync());
        }
    }
}
