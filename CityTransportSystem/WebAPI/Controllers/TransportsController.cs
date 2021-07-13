using AutoMapper;
using BusinessLogic.DTO;
using BusinessLogic.Interfaces;
using DataAccess.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI.ViewModels;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransportsController : ControllerBase
    {
        private readonly ITransportService _transportService;
        private readonly IMapper _mapper;

        public TransportsController(ITransportService transportService, IMapper mapper)
        {
            _transportService = transportService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetTransports()
        {
            var transports = _mapper.Map<IEnumerable<TransportViewModel>>(await _transportService.GetAllTransportsAsync());
            if (transports != null)
            {
                return Ok(transports);
            }
            return NotFound();
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetTransport(int id)
        {
            var transport = _mapper.Map<TransportViewModel>(await _transportService.GetTransportAsync(id));
            if (transport != null)
            {
                return Ok(transport);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> AddTransport(TransportViewModel transportViewModel)
        {
            var transportDto = _mapper.Map<TransportDto>(transportViewModel);
            await _transportService.AddTransportAsync(transportDto);
            return Ok(transportDto);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTransport(TransportViewModel transportViewModel)
        {
            var transportDto = _mapper.Map<TransportDto>(transportViewModel);
            await _transportService.UpdateTransportAsync(transportDto);
            return Ok(transportDto);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteTransport(int id)
        {
            var transportDto = await _transportService.GetTransportAsync(id);
            if (transportDto is null)
            {
                return NotFound();
            }
            await _transportService.DeleteTransportAsync(id);
            return Ok(transportDto);
        }
    }
}
