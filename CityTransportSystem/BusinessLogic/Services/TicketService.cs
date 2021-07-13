using AutoMapper;
using BusinessLogic.DTO;
using BusinessLogic.Interfaces;
using DataAccess.Entities;
using DataAccess.UnitOfWork;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class TicketService : ITicketService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TicketService(IUnitOfWork uow, IMapper mapper)
        {
            _unitOfWork = uow;
            _mapper = mapper;
        }

        public async Task<TicketDto> GetTicketAsync(int id)
        {
            var ticket = _mapper.Map<TicketDto>(await _unitOfWork.TicketRepository.GetAsync(id));
            return ticket;
        }

        public async Task<IEnumerable<TicketDto>> GetAllTicketsAsync()
        {
            var tickets = _mapper.Map<IEnumerable<TicketDto>>(await _unitOfWork.TicketRepository.GetAllAsync());
            return tickets;
        }

        public async Task AddTicketAsync(TicketDto ticketDto)
        {
            var ticket = _mapper.Map<Ticket>(ticketDto);
            await _unitOfWork.TicketRepository.AddAsync(ticket);
            await _unitOfWork.SaveAsync();
        }

        public async Task UpdateTicketAsync(TicketDto ticketDto)
        {
            var ticket = _mapper.Map<Ticket>(ticketDto);
            await _unitOfWork.TicketRepository.UpdateAsync(ticket);
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteTicketAsync(int id)
        {
            await _unitOfWork.TicketRepository.DeleteAsync(id);
            await _unitOfWork.SaveAsync();
        }
    }
}
